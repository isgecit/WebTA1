Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization

Partial Class filedownload
    Inherits System.Web.UI.Page
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim docPK As String = ""
    Dim filePK As String = ""
    Dim downloadType As Integer = 0
    '0=Template
    '1=Attachement
    Dim val() As String = Nothing
    Dim Value As String = ""
    If Request.QueryString("tmpl") IsNot Nothing Then
      val = Request.QueryString("tmpl").Split("|".ToCharArray)
      DownloadItem(val(0))
    ElseIf Request.QueryString("bomi") IsNot Nothing Then
      Value = Request.QueryString("bomi")
      DownloadBOMI(Value)
    ElseIf Request.QueryString("bomipo") IsNot Nothing Then
      Value = Request.QueryString("bomipo")
      DownloadBOMIPO(Value)
    ElseIf Request.QueryString("stcpolr") IsNot Nothing Then
      Value = Request.QueryString("stcpolr")
      DownloadSTCPOLR(Value)
    ElseIf Request.QueryString("stcpolrd") IsNot Nothing Then
      Value = Request.QueryString("stcpolrd")
      DownloadSTCPOLRD(Value)

    End If
  End Sub
#Region " BItem "
  Private POStatusID As Integer = 0
  Private Function WriteBItemXL(ByVal xlWS As ExcelWorksheet, ByVal r As Integer, ByVal SerialNo As Integer, ByVal BOMNo As Integer, ByVal pItemNo As Integer, Optional ByVal IsPO As Boolean = False) As Integer
    Dim Items As List(Of SIS.PAK.pakPOBItems) = SIS.PAK.pakPOBItems.GetByParentPOBItemNo(SerialNo, BOMNo, pItemNo, "")
    If Items.Count > 0 Then
      For Each tmp As SIS.PAK.pakPOBItems In Items
        With xlWS
          r += 1
          Dim c As Integer = 1
          .Cells(r, c).Value = tmp.ItemNo
          c += 1
          .Cells(r, c).Value = tmp.ElementID
          c += 1
          .Cells(r, c).Value = tmp.ItemCode
          c += 1
          .Cells(r, c).Value = tmp.ItemDescription
          If Not tmp.Bottom Then
            .Cells(r, c).Style.Font.Bold = True
            .Cells(r, c).Style.Font.Color.SetColor(tmp.GetColor)
            .Cells(r, c + 1, r, c + 7).Style.Locked = True
          End If
          If tmp.Bottom Then
            c += 1
            If tmp.UOMQuantity <> "" Then .Cells(r, c).Value = tmp.PAK_Units10_Description
            c += 1
            .Cells(r, c).Value = tmp.Quantity
            c += 1
            If tmp.UOMWeight <> "" Then .Cells(r, c).Value = tmp.PAK_Units11_Description
            c += 1
            .Cells(r, c).Value = tmp.WeightPerUnit
            c += 1
            If POStatusID = pakPOStates.UnderSupplierVerification Then
              .Cells(r, c).Value = IIf(tmp.Accepted, "Y", "N")
              c += 1
            ElseIf POStatusID = pakPOStates.UnderISGECApproval Then
              .Cells(r, c).Value = IIf(tmp.Freezed, "Y", "N")
              c += 1
            End If
            .Cells(r, c).Value = tmp.SupplierRemarks
            c += 1
            .Cells(r, c).Value = tmp.ISGECRemarks
            c += 1
            Try
              .Cells(r, c).Value = tmp.PAK_POBOMStatus9_Description
              c += 1
            Catch ex As Exception
            End Try
          End If
          If Not tmp.Bottom Then
            r = WriteBItemXL(xlWS, r, tmp.SerialNo, tmp.BOMNo, tmp.ItemNo, IsPO)
          End If
        End With
      Next
    End If
    Return r
  End Function

  Private Sub DownloadBItem(ByVal value As String, Optional ByVal IsPO As Boolean = False)
    Dim val() As String = value.Split("|".ToCharArray)
    Dim SerialNo As Integer = val(0)
    Dim BOMNo As Integer = val(1)
    Dim ItemNo As Integer = val(2)

    Dim tmpPO As SIS.PAK.pakPO = SIS.PAK.pakPO.pakPOGetByID(SerialNo)
    Dim tmpBOM As SIS.PAK.pakPOBOM = SIS.PAK.pakPOBOM.pakPOBOMGetByID(SerialNo, BOMNo)

    Dim st As Long = HttpContext.Current.Server.ScriptTimeout
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue

    If ItemNo <= 0 Then
      Dim message As String = New JavaScriptSerializer().Serialize("BOM Item ID is required for Template download.")
      Dim script As String = String.Format("alert({0});", message)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      Exit Sub
    End If

    POStatusID = tmpPO.POStatusID

    Dim TemplateName As String = "PAK_POBOM_FREE.xlsx"
    If Not IsPO Then
      Select Case tmpPO.POStatusID
        Case pakPOStates.Free
          TemplateName = "POBOM_Free.xlsx"
        Case pakPOStates.UnderSupplierVerification
          TemplateName = "POBOM_Verification.xlsx"
        Case pakPOStates.UnderISGECApproval
          TemplateName = "POBOM_Approval.xlsx"
          TemplateName = "POBOM_Verification.xlsx"
        Case pakPOStates.IssuedtoSupplier
          TemplateName = "POBOM_Issued.xlsx"
          TemplateName = "POBOM_Verification.xlsx"
        Case pakPOStates.UnderDespatch
          TemplateName = "POBOM_Despatch.xlsx"
        Case pakPOStates.Closed
          TemplateName = "POBOM_Closed.xlsx"
      End Select
    Else
      TemplateName = "POBOMPO_Free.xlsx"
    End If
    Dim tmpFile As String = Server.MapPath("~/App_Templates/" & TemplateName)
    If IO.File.Exists(tmpFile) Then
      Dim FileName As String = Server.MapPath("~/..") & "App_Temp/" & Guid.NewGuid().ToString()
      IO.File.Copy(tmpFile, FileName)
      Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
      Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)

      '1.
      Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("Master")
      Dim oUOMs As List(Of SIS.PAK.pakUnits) = SIS.PAK.pakUnits.pakUnitsSelectList("")
      Dim r As Integer = 2
      Dim c As Integer = 1
      Dim cnt As Integer = 1
      With xlWS
        .Cells("C").Clear()
        For Each tmp As SIS.PAK.pakUnits In oUOMs
          On Error Resume Next
          .Cells(r, 3).Value = tmp.Description
          r += 1
        Next
      End With

      '2. 
      xlWS = xlPk.Workbook.Worksheets("Data")
      r = 8
      c = 1
      Dim tmpBItem As SIS.PAK.pakPOBItems = SIS.PAK.pakPOBItems.pakPOBItemsGetByID(SerialNo, BOMNo, ItemNo)
      With xlWS
        .Cells(2, 4).Value = tmpBItem.ItemDescription
        .Cells(3, 2).Value = tmpBItem.SerialNo
        .Cells(4, 2).Value = tmpBItem.BOMNo
        .Cells(5, 2).Value = tmpBItem.ItemNo
        .Cells(3, 4).Value = tmpPO.PONumber
        .Cells(4, 4).Value = tmpPO.VR_BusinessPartner9_BPName
        .Cells(5, 4).Value = tmpPO.ProjectID & " - " & tmpPO.IDM_Projects4_Description
        .Cells(3, 6).Value = "'" & tmpPO.PODate
        .Cells(4, 6).Value = tmpPO.FK_PAK_PO_BuyerID.UserFullName
        .Cells(5, 6).Value = tmpPO.POStatusID & "-" & tmpPO.PAK_POStatus6_Description
      End With

      r = WriteBItemXL(xlWS, r, SerialNo, BOMNo, ItemNo, IsPO)

      xlPk.Save()
      xlPk.Dispose()

      Response.Clear()
      Response.AppendHeader("content-disposition", "attachment; filename=" & "POBom_" & ItemNo & "_" & Now.ToString("dd-MM-yyyy") & ".xlsx")
      Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(TemplateName)
      Response.WriteFile(FileName)
      HttpContext.Current.Server.ScriptTimeout = st
      Response.End()
    End If
  End Sub

#End Region
#Region " BOMI "
  Private Sub DownloadBOMI(ByVal value As String)
    Dim val() As String = value.Split("|".ToCharArray)
    Dim tmp As SIS.PAK.pakPOBOM = SIS.PAK.pakPOBOM.pakPOBOMGetByID(val(0), val(1))
    DownloadBItem(val(0) & "|" & val(1) & "|" & tmp.ItemNo)
  End Sub

#End Region
#Region " BOMIPO "
  Private Sub DownloadBOMIPO(ByVal value As String)
    Dim val() As String = value.Split("|".ToCharArray)
    Dim tmp As SIS.PAK.pakPOBOM = SIS.PAK.pakPOBOM.pakPOBOMGetByID(val(0), val(1))
    DownloadBItem(val(0) & "|" & val(1) & "|" & tmp.ItemNo, True)
  End Sub

#End Region

#Region " TMPL "
  Private Function WriteXL(ByVal xlWS As ExcelWorksheet, ByVal r As Integer, ByVal pItemNo As Integer) As Integer
    Dim Items As List(Of SIS.PAK.pakItems) = SIS.PAK.pakItems.GetByParentItemNo(pItemNo, "")
    If Items.Count > 0 Then
      For Each tmp As SIS.PAK.pakItems In Items
        With xlWS
          r += 1
          Dim c As Integer = 1
          .Cells(r, c).Value = tmp.ItemNo
          c += 1
          .Cells(r, c).Value = tmp.ParentItemNo
          c += 1
          .Cells(r, c).Value = tmp.PAK_Items4_ItemDescription
          c += 1
          .Cells(r, c).Value = "I"
          c += 1
          .Cells(r, c).Value = tmp.ElementID
          c += 1
          .Cells(r, c).Value = tmp.ItemCode
          c += 1
          .Cells(r, c).Value = tmp.ItemDescription
          c += 1
          'If tmp.Bottom Then
          If tmp.UOMQuantity <> "" Then .Cells(r, 8).Value = tmp.PAK_Units5_Description
            c += 1
            .Cells(r, c).Value = tmp.Quantity
            c += 1
            If tmp.UOMWeight <> "" Then .Cells(r, 10).Value = tmp.PAK_Units6_Description
            c += 1
            .Cells(r, c).Value = tmp.WeightPerUnit
            c += 1
            .Cells(r, c).Value = tmp.DocumentNo
            c += 1
          'End If
          If Not tmp.Bottom Then
            '.Cells(r, 8, r, 12).Style.Locked = True
            .Cells(r, 4).Value = "H" & tmp.ItemLevel + 1
            .Cells(r, 5, r, 7).Style.Font.Bold = True
            r = WriteXL(xlWS, r, tmp.ItemNo)
          End If
        End With
      Next
    End If
    Return r
  End Function
  Private Sub DownloadItem(ByVal ItemNo As String)
    Dim st As Long = HttpContext.Current.Server.ScriptTimeout
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue

    If ItemNo = String.Empty Then
      'Dim message As String = New JavaScriptSerializer().Serialize("ITEM No is required for Template download.")
      'Dim script As String = String.Format("alert({0});", message)
      'ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("ITEM No is required for Template download.") & "');", True)
      Exit Sub
    End If
    Dim TemplateName As String = "PAK_ITEM_TEMPLATE.xlsx"
    Dim tmpFile As String = Server.MapPath("~/App_Templates/" & TemplateName)
    If IO.File.Exists(tmpFile) Then
      Dim FileName As String = Server.MapPath("~/..") & "App_Temp/" & Guid.NewGuid().ToString()
      IO.File.Copy(tmpFile, FileName)
      Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
      Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)

      '1.
      Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("Master")
      Dim oUOMs As List(Of SIS.PAK.pakUnits) = SIS.PAK.pakUnits.pakUnitsSelectList("")
      Dim r As Integer = 2
      Dim c As Integer = 1
      Dim cnt As Integer = 1
      With xlWS
        .Cells("C").Clear()
        For Each tmp As SIS.PAK.pakUnits In oUOMs
          On Error Resume Next
          .Cells(r, 3).Value = tmp.Description
          r += 1
        Next
      End With

      '2. 
      xlWS = xlPk.Workbook.Worksheets("Data")
      r = 5
      c = 1
      Dim itm As SIS.PAK.pakItems = SIS.PAK.pakItems.pakItemsGetByID(ItemNo)
      With xlWS
        .Cells(1, 2).Value = itm.ItemNo
        .Cells(2, 2).Value = itm.ItemDescription
      End With

      r = WriteXL(xlWS, r, ItemNo)

      xlPk.Save()
      xlPk.Dispose()

      Response.Clear()
      Response.AppendHeader("content-disposition", "attachment; filename=Item_" & ItemNo & "_Template.xlsx")
      Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(TemplateName)
      Response.WriteFile(FileName)
      HttpContext.Current.Server.ScriptTimeout = st
      Response.End()
    End If
  End Sub

#End Region

#Region " STCPOLR "
  Private Sub DownloadSTCPOLR(ByVal Value As String)
    Dim st As Long = HttpContext.Current.Server.ScriptTimeout
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue

    Dim aVal() As String = Value.Split("|".ToCharArray)

    Dim SerialNo As String = aVal(0)
    Dim ItemNo As String = aVal(1)
    Dim UploadNo As String = aVal(2)

    'If ItemNo = String.Empty Then
    '  ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("ITEM No is required for Template download.") & "');", True)
    '  Exit Sub
    'End If
    Dim TemplateName As String = "STCPOLR_TEMPLATE.xlsx"
    Dim tmpFile As String = Server.MapPath("~/App_Templates/" & TemplateName)
    If IO.File.Exists(tmpFile) Then
      Dim FileName As String = Server.MapPath("~/..") & "App_Temp/" & Guid.NewGuid().ToString()
      IO.File.Copy(tmpFile, FileName)
      Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
      Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)

      '1.
      Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("Data")
      Dim r As Integer = 1
      Dim c As Integer = 1
      Dim cnt As Integer = 1

      r = 7
      c = 1
      Dim Upd As SIS.PAK.pakTCPOLR = SIS.PAK.pakTCPOLR.pakTCPOLRGetByID(SerialNo, ItemNo, UploadNo)

      Dim Docs As List(Of SIS.PAK.pakTCPOLRD) = SIS.PAK.pakTCPOLRD.pakTCPOLRDSelectList(0, 9999, "DocSerialNo", False, "", SerialNo, ItemNo, UploadNo)
      With xlWS
        .Cells(1, 2).Value = SerialNo
        .Cells(2, 2).Value = ItemNo
        .Cells(3, 2).Value = UploadNo
      End With

      For Each tmp As SIS.PAK.pakTCPOLRD In Docs
        With xlWS
          c = 1
          .Cells(r, c).Value = tmp.DocSerialNo
          c += 1
          .Cells(r, c).Value = tmp.DocumentID
          c += 1
          .Cells(r, c).Value = tmp.DocumentRev
          c += 1
          .Cells(r, c).Value = tmp.DocumentDescription
          c += 1
          .Cells(r, c).Value = tmp.FileName
          c += 1
        End With
        r += 1
      Next

      xlPk.Save()
      xlPk.Dispose()

      Response.Clear()
      Response.AppendHeader("content-disposition", "attachment; filename=Documents_" & SerialNo & "_" & ItemNo & "_" & UploadNo & ".xlsx")
      Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(TemplateName)
      Response.WriteFile(FileName)
      HttpContext.Current.Server.ScriptTimeout = st
      Response.End()
    End If
  End Sub

#End Region

#Region " STCPOLRD "
  Private Sub DownloadSTCPOLRD(ByVal value As String)
    Dim val() As String = value.Split("|".ToCharArray)
    Dim tmp As SIS.PAK.pakSTCPOLRD = SIS.PAK.pakSTCPOLRD.pakSTCPOLRDGetByID(val(0), val(1), val(2), val(3))
    Dim tmpFile As String = tmp.DiskFileName
    If IO.File.Exists(tmpFile) Then
      Dim FileName As String = Server.MapPath("~/..") & "App_Temp/" & Guid.NewGuid().ToString()
      IO.File.Copy(tmpFile, FileName)
      Response.Clear()
      Response.AppendHeader("content-disposition", "attachment; filename=""" & tmp.FileName & """")
      Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(tmp.FileName)
      Response.WriteFile(FileName)
      Response.End()
    End If
  End Sub

#End Region

End Class
