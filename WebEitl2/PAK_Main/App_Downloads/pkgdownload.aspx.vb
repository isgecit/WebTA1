﻿Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization

Partial Class pkgdownload
  Inherits System.Web.UI.Page
  Private st As Long = HttpContext.Current.Server.ScriptTimeout
  Public QCRequired As Boolean = False
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
    Dim docPK As String = ""
    Dim filePK As String = ""
    Dim downloadType As Integer = 0
    '0=Template
    '1=Attachement
    Dim val() As String = Nothing
    Dim Value As String = ""
    If Request.QueryString("pkg") IsNot Nothing Then
      Value = Request.QueryString("pkg")
      DownloadTmplForPkg(Value)
    End If
    If Request.QueryString("PortPkg") IsNot Nothing Then
      Value = Request.QueryString("PortPkg")
      DownloadTmplForPortPkg(Value)
    End If
  End Sub

#Region " TMPL FOR PKG "

  Private Function WriteBItemXL(ByVal xlWS As ExcelWorksheet, ByVal r As Integer, ByVal SerialNo As Integer, ByVal BOMNo As Integer, ByVal pItemNo As Integer, ByRef cnt As Integer, ByVal PkgItems As List(Of SIS.PAK.pakPkgListD)) As Integer
    Dim Items As List(Of SIS.PAK.pakPOBItems) = SIS.PAK.pakPOBItems.GetByParentPOBItemNo(SerialNo, BOMNo, pItemNo, "")
    If Items.Count > 0 Then
      For Each tmp As SIS.PAK.pakPOBItems In Items
        With xlWS
          Dim c As Integer = 1
          If Not tmp.Bottom Then
            .Cells(r, c).Value = cnt
            c += 1
            .Cells(r, c).Value = tmp.BOMNo
            c += 1
            .Cells(r, c).Value = tmp.ItemNo
            c += 1
            .Cells(r, c).Value = tmp.ItemCode
            c += 1
            .Cells(r, c).Value = tmp.Prefix & tmp.ItemDescription
            .Cells(r, c).Style.Font.Bold = True
            .Cells(r, c).Style.Font.Color.SetColor(tmp.GetColor)
            cnt += 1
            r += 1
          End If
          If tmp.Bottom Then
            Dim PrintIt As Boolean = True
            If QCRequired Then
              If tmp.QualityClearedQty <= 0 Then
                PrintIt = False
              Else
                tmp.Quantity = tmp.QualityClearedQty
              End If
            End If
            If PrintIt Then
              c = 1
              .Cells(r, c).Value = cnt
              c += 1
              .Cells(r, c).Value = tmp.BOMNo
              c += 1
              .Cells(r, c).Value = tmp.ItemNo
              c += 1
              .Cells(r, c).Value = tmp.ItemCode
              c += 1
              .Cells(r, c).Value = tmp.Prefix & tmp.ItemDescription
              c += 1
              .Cells(r, c).Value = "*"
              c += 1
              If tmp.UOMQuantity <> "" Then .Cells(r, c).Value = tmp.PAK_Units10_Description
              c += 1
              .Cells(r, c).Value = tmp.Quantity
              c += 1
              If tmp.UOMWeight <> "" Then .Cells(r, c).Value = tmp.PAK_Units11_Description
              c += 1
              .Cells(r, c).Value = tmp.WeightPerUnit
              c += 1
              .Cells(r, c).Value = (tmp.WeightPerUnit * tmp.Quantity).ToString("n")
              c += 1
              .Cells(r, c).Value = tmp.Quantity - tmp.QuantityDespatched
              c += 1
              .Cells(r, c).Value = (tmp.Quantity * tmp.WeightPerUnit) - tmp.TotalWeightDespatched
              c += 1
              Dim pkgFound As Boolean = False
              For Each tmpItm As SIS.PAK.pakPkgListD In PkgItems
                If tmpItm.ItemNo = tmp.ItemNo And tmpItm.BOMNo = tmp.BOMNo Then
                  pkgFound = True
                  .Cells(r, c).Value = tmpItm.Quantity
                  c += 1
                  .Cells(r, c).Value = tmpItm.WeightPerUnit
                  c += 1
                  .Cells(r, c).Value = tmpItm.DocumentNo
                  c += 1
                  .Cells(r, c).Value = tmpItm.DocumentRevision
                  c += 1
                  .Cells(r, c).Value = tmpItm.PAK_PakTypes1_Description
                  c += 1
                  .Cells(r, c).Value = tmpItm.PackingMark
                  c += 1
                  .Cells(r, c).Value = tmpItm.PAK_Units8_Description
                  c += 1
                  .Cells(r, c).Value = tmpItm.PackLength
                  c += 1
                  .Cells(r, c).Value = tmpItm.PackWidth
                  c += 1
                  .Cells(r, c).Value = tmpItm.PackHeight
                  c += 1
                  .Cells(r, c).Value = tmpItm.Remarks
                  c += 1
                  PkgItems.Remove(tmpItm)
                  Exit For
                End If
              Next
              If Not pkgFound Then
                c += 1
                .Cells(r, c).Value = tmp.WeightPerUnit
                c += 1
                If tmp.DocumentNo <> "" Then
                  .Cells(r, c).Value = tmp.FK_PAK_POBItems_DocumentNo.DocumentID
                  c += 1
                  .Cells(r, c).Value = tmp.FK_PAK_POBItems_DocumentNo.DocumentRevision
                Else
                  .Cells(r, c).Value = ""
                  c += 1
                  .Cells(r, c).Value = ""
                End If
              End If
              cnt += 1
              r += 1
            End If 'End of PrintIT
          End If
          If Not tmp.Bottom Then
            r = WriteBItemXL(xlWS, r, tmp.SerialNo, tmp.BOMNo, tmp.ItemNo, cnt, PkgItems)
          End If
        End With
      Next
    End If
    Return r
  End Function

  Private Sub DownloadTmplForPkg(ByVal Value As String)
    Dim aVal() As String = Value.Split("|".ToCharArray)
    Dim SerialNo As String = ""
    Dim PkgNo As String = ""
    Dim BOMNo As String = ""
    Try
      SerialNo = aVal(0)
      PkgNo = aVal(1)
      BOMNo = aVal(2)
    Catch ex As Exception
    End Try
    If PkgNo = String.Empty Then
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Package No is required for Template download.") & "');", True)
      HttpContext.Current.Server.ScriptTimeout = st
      Exit Sub
    End If

    Dim TemplateName As String = "PKG_TEMPLATE.xlsx"

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


      With xlWS
        .Cells(1, 3).Value = SerialNo
        .Cells(2, 3).Value = PkgNo
        .Cells(3, 3).Value = BOMNo
      End With

      '1. Write Master Data Units & Package Type
      '1.a Units
      Dim tmpUnits As List(Of SIS.PAK.pakUnits) = SIS.PAK.pakUnits.pakUnitsSelectList("")
      r = 2
      c = 8
      For Each tmp As SIS.PAK.pakUnits In tmpUnits
        With xlWS
          .Cells(r, c).Value = tmp.Description
        End With
        r += 1
        If r > 5 Then
          r = 2
          c += 1
        End If
        If c > 19 Then
          Exit For
        End If
      Next
      '1.b Package Types
      Dim tmpPacks As List(Of SIS.PAK.pakPakTypes) = SIS.PAK.pakPakTypes.pakPakTypesSelectList("")
      r = 2
      c = 21
      For Each tmp As SIS.PAK.pakPakTypes In tmpPacks
        With xlWS
          .Cells(r, c).Value = tmp.Description
        End With
        r += 1
        If r > 5 Then
          r = 2
          c += 1
        End If
        If c > 24 Then
          Exit For
        End If
      Next
      '2. Data
      r = 9
      c = 1
      Dim PO As SIS.PAK.pakPO = SIS.PAK.pakPO.pakPOGetByID(SerialNo)
      QCRequired = PO.QCRequired

      Dim POBOMs As List(Of SIS.PAK.pakPOBOM) = SIS.PAK.pakPOBOM.pakPOBOMSelectList(0, 99999, "", False, "", SerialNo)

      Dim PkgItems As List(Of SIS.PAK.pakPkgListD) = SIS.PAK.pakPkgListD.pakPkgListDSelectList(0, 99999, "", False, "", PkgNo, SerialNo)

      For Each tmp As SIS.PAK.pakPOBOM In POBOMs
        If BOMNo <> String.Empty Then If tmp.BOMNo <> BOMNo Then Continue For
        With xlWS
          c = 1
          .Cells(r, c).Value = cnt
          c += 1
          .Cells(r, c).Value = tmp.BOMNo
          c += 1
          .Cells(r, c).Value = tmp.ItemNo
          c += 1
          .Cells(r, c).Value = tmp.ItemCode
          c += 1
          .Cells(r, c).Value = tmp.Prefix & tmp.ItemDescription
          If Not tmp.Bottom Then
            .Cells(r, c).Style.Font.Bold = True
            .Cells(r, c).Style.Font.Color.SetColor(tmp.GetColor)
          End If
          cnt += 1
          r += 1
        End With
        r = WriteBItemXL(xlWS, r, SerialNo, tmp.BOMNo, tmp.ItemNo, cnt, PkgItems)

      Next

      xlPk.Save()
      xlPk.Dispose()

      Response.Clear()
      Response.AppendHeader("content-disposition", "attachment; filename=PackingList_" & SerialNo & "_" & PkgNo & ".xlsx")
      Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(TemplateName)
      Response.WriteFile(FileName)
      HttpContext.Current.Server.ScriptTimeout = st
      Response.End()
    End If
  End Sub

#End Region

#Region " TMPL FOR PORT PKG "

  Private Sub DownloadTmplForPortPkg(ByVal Value As String)
    Dim aVal() As String = Value.Split("|".ToCharArray)
    Dim SerialNo As String = ""
    Dim PkgNo As String = ""
    Dim BOMNo As String = ""
    Try
      SerialNo = aVal(0)
      PkgNo = aVal(1)
      BOMNo = aVal(2)
    Catch ex As Exception
    End Try
    If PkgNo = String.Empty Then
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Package No is required for Template download.") & "');", True)
      HttpContext.Current.Server.ScriptTimeout = st
      Exit Sub
    End If

    Dim oPkg As SIS.PAK.pakPkgListH = SIS.PAK.pakPkgListH.pakPkgPortHGetByID(0, PkgNo)

    Dim TemplateName As String = "PKG_PORTTEMPLATE.xlsx"

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


      With xlWS
        .Cells(1, 3).Value = SerialNo
        .Cells(2, 3).Value = PkgNo
        .Cells(3, 3).Value = BOMNo
        .Cells(4, 3).Value = oPkg.ProjectID
        .Cells(5, 3).Value = oPkg.PortID
        .Cells(4, 4).Value = oPkg.IDM_Projects9_Description
        .Cells(5, 4).Value = oPkg.ELOG_Ports8_Description
      End With

      '2. Data
      r = 9
      c = 1

      Dim pkgItems As List(Of SIS.PAK.pakPkgListD) = SIS.PAK.pakPkgListD.UZ_pakPkgPortDSelectList(0, 99999, "", False, "", PkgNo, 0)

      Dim allItems As List(Of SIS.PAK.lgPortItems) = SIS.PAK.pakPkgListD.UZ_ReceivedAtPortPkgD(oPkg.ProjectID, oPkg.PortID)

      For Each tmp As SIS.PAK.lgPortItems In allItems
        With xlWS
          c = 1
          .Cells(r, c).Value = cnt
          c += 1
          .Cells(r, c).Value = tmp.pD.SerialNo
          c += 1
          .Cells(r, c).Value = tmp.pD.PkgNo
          c += 1
          .Cells(r, c).Value = tmp.pD.BOMNo
          c += 1
          .Cells(r, c).Value = tmp.pD.ItemNo
          c += 1
          .Cells(r, c).Value = tmp.pT.ItemCode
          c += 1
          .Cells(r, c).Value = tmp.pT.Prefix & tmp.pT.ItemDescription
          If Not tmp.pT.Bottom Then
            .Cells(r, c).Style.Font.Bold = True
            .Cells(r, c).Style.Font.Color.SetColor(tmp.pT.GetColor)
          End If
          cnt += 1
          .Cells(r, c).Value = "*"
          c += 1
          .Cells(r, c).Value = tmp.pD.DocumentNo
          c += 1
          .Cells(r, c).Value = tmp.pD.DocumentRevision
          c += 1
          .Cells(r, c).Value = tmp.pD.PackTypeID
          c += 1
          .Cells(r, c).Value = tmp.pD.PackingMark
          c += 1
          .Cells(r, c).Value = tmp.pD.UOMPack
          c += 1
          .Cells(r, c).Value = tmp.pD.PackLength
          c += 1
          .Cells(r, c).Value = tmp.pD.PackWidth
          c += 1
          .Cells(r, c).Value = tmp.pD.PackHeight
          c += 1
          .Cells(r, c).Value = tmp.pD.Remarks
          c += 1
          .Cells(r, c).Value = tmp.pT.UOMQuantity
          c += 1
          .Cells(r, c).Value = tmp.pT.QuantityReceivedAtPort
          c += 1
          .Cells(r, c).Value = tmp.pT.UOMWeight
          c += 1
          .Cells(r, c).Value = tmp.pT.WeightPerUnit
          c += 1
          .Cells(r, c).Value = tmp.pT.TotalWeightReceivedAtPort
          c += 1

          .Cells(r, c).Value = (tmp.pT.QuantityReceivedAtPort - tmp.pT.QuantityDespatchedfromPort)
          c += 1
          .Cells(r, c).Value = (tmp.pT.TotalWeightReceivedAtPort - tmp.pT.TotalWeightDespatchedFromPort)
          c += 1

          For Each pkg As SIS.PAK.pakPkgListD In pkgItems
            If pkg.SerialNo = tmp.pT.SerialNo And pkg.BOMNo = tmp.pT.BOMNo And pkg.ItemNo = tmp.pT.ItemNo Then
              .Cells(r, c).Value = pkg.Quantity
              c += 1
              Exit For
            End If
          Next

          r += 1
        End With

      Next

      xlPk.Save()
      xlPk.Dispose()

      Response.Clear()
      Response.AppendHeader("content-disposition", "attachment; filename=PortPkg" & "_" & PkgNo & ".xlsx")
      Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(TemplateName)
      Response.WriteFile(FileName)
      HttpContext.Current.Server.ScriptTimeout = st
      Response.End()
    End If
  End Sub

#End Region

End Class
