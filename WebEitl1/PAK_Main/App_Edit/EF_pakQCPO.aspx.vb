Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Imports System.IO
Partial Class EF_pakQCPO
  Inherits SIS.SYS.UpdateBase
  Public Property Editable() As Boolean
    Get
      If ViewState("Editable") IsNot Nothing Then
        Return CType(ViewState("Editable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Editable", value)
    End Set
  End Property
  Public Property Deleteable() As Boolean
    Get
      If ViewState("Deleteable") IsNot Nothing Then
        Return CType(ViewState("Deleteable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Deleteable", value)
    End Set
  End Property
  Public Property PrimaryKey() As String
    Get
      If ViewState("PrimaryKey") IsNot Nothing Then
        Return CType(ViewState("PrimaryKey"), String)
      End If
      Return True
    End Get
    Set(ByVal value As String)
      ViewState.Add("PrimaryKey", value)
    End Set
  End Property
  Protected Sub ODSpakQCPO_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakQCPO.Selected
    Dim tmp As SIS.PAK.pakQCPO = CType(e.ReturnValue, SIS.PAK.pakQCPO)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakQCPO_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakQCPO.Init
    DataClassName = "EpakQCPO"
    SetFormView = FVpakQCPO
  End Sub
  Protected Sub TBLpakQCPO_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakQCPO.Init
    SetToolBar = TBLpakQCPO
  End Sub
  Protected Sub FVpakQCPO_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakQCPO.PreRender
    TBLpakQCPO.EnableSave = Editable
    TBLpakQCPO.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakQCPO.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakQCPO") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakQCPO", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpakQCListHCC As New gvBase
  Protected Sub GVpakQCListH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakQCListH.Init
    gvpakQCListHCC.DataClassName = "GpakQCListH"
    gvpakQCListHCC.SetGridView = GVpakQCListH
  End Sub
  Protected Sub TBLpakQCListH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakQCListH.Init
    gvpakQCListHCC.SetToolBar = TBLpakQCListH
  End Sub
  Protected Sub GVpakQCListH_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakQCListH.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakQCListH.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim QCLNo As Int32 = GVpakQCListH.DataKeys(e.CommandArgument).Values("QCLNo")
        Dim RedirectUrl As String = TBLpakQCListH.EditUrl & "?SerialNo=" & SerialNo & "&QCLNo=" & QCLNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakQCListH.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim QCLNo As Int32 = GVpakQCListH.DataKeys(e.CommandArgument).Values("QCLNo")
        SIS.PAK.pakQCListH.InitiateWF(SerialNo, QCLNo)
        GVpakQCListH.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "convertwf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakQCListH.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim QCLNo As Int32 = GVpakQCListH.DataKeys(e.CommandArgument).Values("QCLNo")
        SIS.PAK.pakQCListH.ConvertWF(SerialNo, QCLNo)
        GVpakQCListH.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub TBLpakQCListH_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLpakQCListH.AddClicked
    Dim SerialNo As Int32 = CType(FVpakQCPO.FindControl("F_SerialNo"), TextBox).Text
    Dim xTmp As New SIS.PAK.pakQCListH
    With xTmp
      .SerialNo = SerialNo
      .QCLNo = 0
      .SupplierRef = "System Created"
      .Remarks = ""
      .StatusID = pakQCStates.Free
      .CreatedBy = HttpContext.Current.Session("LoginID")
      .CreatedOn = Now
    End With
    xTmp = SIS.PAK.pakQCListH.InsertData(xTmp)
    Dim qclNo As String = xTmp.QCLNo
    TBLpakQCListH.AddUrl &= "?SerialNo=" & SerialNo
    TBLpakQCListH.AddUrl &= "&QCLNo=" & qclNo
  End Sub
  Private st As Long = HttpContext.Current.Server.ScriptTimeout
  Private Sub FVpakQCPO_ItemCommand(sender As Object, e As FormViewCommandEventArgs) Handles FVpakQCPO.ItemCommand
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
    If e.CommandName.ToLower = "tmplupload" Then
      Try
        Dim aVal() As String = e.CommandArgument.ToString.Split("|".ToCharArray)
        Dim SerialNo As String = ""
        Dim QCLNo As String = ""
        Dim BOMNo As String = ""
        Try
          SerialNo = aVal(0)
          QCLNo = aVal(1)
          BOMNo = aVal(2)
        Catch ex As Exception

        End Try
        With F_FileUpload
          If .HasFile Then
            Dim tmpPath As String = Server.MapPath("~/../App_Temp")
            Dim tmpName As String = IO.Path.GetRandomFileName()
            Dim tmpFile As String = tmpPath & "\\" & tmpName
            .SaveAs(tmpFile)
            Dim fi As FileInfo = New FileInfo(tmpFile)
            Dim IsError As Boolean = False
            Dim ErrMsg As String = ""
            Using xlP As ExcelPackage = New ExcelPackage(fi)
              Dim wsD As ExcelWorksheet = Nothing
              Try
                wsD = xlP.Workbook.Worksheets("Data")
              Catch ex As Exception
                wsD = Nothing
              End Try
              '1. Process Document
              If wsD Is Nothing Then
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Invalid XL File") & "');", True)
                xlP.Dispose()
                HttpContext.Current.Server.ScriptTimeout = st
                Exit Sub
              End If

              Dim tmpSerialNo As String = wsD.Cells(1, 3).Text
              Dim tmpQCLNo As String = wsD.Cells(2, 3).Text
              Dim tmpBomNo As String = wsD.Cells(3, 3).Text

              If SerialNo <> tmpSerialNo Then
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Wrong SerialNo Uploaded.") & "');", True)
                xlP.Dispose()
                HttpContext.Current.Server.ScriptTimeout = st
                Exit Sub
              End If
              If QCLNo <> String.Empty AndAlso QCLNo <> tmpQCLNo Then
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Wrong Quality Clearance List Uploaded.") & "');", True)
                xlP.Dispose()
                HttpContext.Current.Server.ScriptTimeout = st
                Exit Sub
              End If
              If BOMNo <> String.Empty AndAlso BOMNo <> tmpBomNo Then
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Wrong QC List/BOM No Uploaded.") & "');", True)
                xlP.Dispose()
                HttpContext.Current.Server.ScriptTimeout = st
                Exit Sub
              End If
              'Check the status of PO & QC List Before Update
              'PO
              Dim tmpPO As SIS.PAK.pakQCPO = SIS.PAK.pakQCPO.pakQCPOGetByID(SerialNo)
              If tmpPO.POStatusID <> pakPOStates.UnderDespatch Then
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("PO status is not UNDER DESPATCH, cannot update Quality Clearance list.") & "');", True)
                xlP.Dispose()
                HttpContext.Current.Server.ScriptTimeout = st
                Exit Sub
              End If
              'QC List
              Dim tmpQCL As SIS.PAK.pakQCListH = SIS.PAK.pakQCListH.pakQCListHGetByID(SerialNo, tmpQCLNo)
              Select Case tmpQCL.StatusID
                Case pakQCStates.Free, pakQCStates.Returned
                Case Else
                  ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("QC List status is not FREE/Returned, cannot update QC list.") & "');", True)
                  xlP.Dispose()
                  HttpContext.Current.Server.ScriptTimeout = st
                  Exit Sub
              End Select
              'End of status Checking
              Dim tmpQCHWt As Decimal = 0
              Dim tmpItemNo As String = ""
              Dim Updatable As Boolean = False
              Dim tmpQCQuantity As String = ""

              For I As Integer = 9 To 99999
                tmpBomNo = wsD.Cells(I, 2).Text
                If tmpBomNo = String.Empty Then Exit For
                tmpItemNo = wsD.Cells(I, 3).Text
                Updatable = IIf(wsD.Cells(I, 6).Text <> String.Empty, True, False)
                If Not Updatable Then Continue For
                tmpQCQuantity = wsD.Cells(I, 14).Text.Trim
                '======================================
                If tmpQCQuantity = "" Then Continue For
                If Not IsNumeric(tmpQCQuantity) Then Continue For
                '============================
                Dim Found As Boolean = True
                Dim tmpListD As SIS.PAK.pakQCListD = Nothing
                tmpListD = SIS.PAK.pakQCListD.pakQCListDGetByID(SerialNo, tmpQCLNo, tmpBomNo, tmpItemNo)
                If tmpListD Is Nothing Then
                  Dim tmpPOBItem As SIS.PAK.pakPOBItems = SIS.PAK.pakPOBItems.pakPOBItemsGetByID(tmpSerialNo, tmpBomNo, tmpItemNo)
                  Found = False
                  tmpListD = New SIS.PAK.pakQCListD
                  With tmpListD
                    .SerialNo = tmpSerialNo
                    .QCLNo = tmpQCLNo
                    .BOMNo = tmpBomNo
                    .ItemNo = tmpItemNo
                    .UOMQuantity = tmpPOBItem.UOMQuantity
                    .UOMWeight = tmpPOBItem.UOMWeight
                    .WeightPerUnit = tmpPOBItem.WeightPerUnit
                  End With
                End If
                With tmpListD
                  .Quantity = IIf(tmpQCQuantity = "", 0, tmpQCQuantity)
                  .QualityClearedQty = 0.0000
                End With
                tmpListD.TotalWeight = SIS.PAK.pakPO.GetTotalWeight(tmpListD.Quantity, tmpListD.WeightPerUnit, tmpListD.UOMQuantity, tmpListD.UOMWeight)
                If Found Then
                  If tmpListD.Quantity <= 0 Then
                    Try
                      SIS.PAK.pakQCListD.pakQCListDDelete(tmpListD)
                    Catch ex As Exception
                      IsError = True
                      ErrMsg = ErrMsg & IIf(ErrMsg = "", "", ", ") & tmpItemNo & "-D"
                    End Try
                  Else
                    Try
                      tmpListD = SIS.PAK.pakQCListD.UpdateData(tmpListD)
                      tmpQCHWt += tmpListD.TotalWeight
                    Catch ex As Exception
                      IsError = True
                      ErrMsg = ErrMsg & IIf(ErrMsg = "", "", ", ") & tmpItemNo & "-U"
                    End Try

                  End If
                Else
                  If tmpListD.Quantity > 0 Then
                    Try
                      tmpListD = SIS.PAK.pakQCListD.InsertData(tmpListD)
                      tmpQCHWt += tmpListD.TotalWeight
                    Catch ex As Exception
                      IsError = True
                      ErrMsg = ErrMsg & IIf(ErrMsg = "", "", ", ") & tmpItemNo & "-I"
                    End Try
                  End If
                End If
              Next 'Document Line
              'Update QC Header
              Dim qcH As SIS.PAK.pakQCListH = SIS.PAK.pakQCListH.pakQCListHGetByID(SerialNo, tmpQCLNo)
              qcH.TotalWeight = tmpQCHWt
              qcH = SIS.PAK.pakQCListH.UpdateData(qcH)
              '================
              xlP.Dispose()
              If IsError Then
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("ITEMS NOT INSERTED/UPDATED: " & ErrMsg) & "');", True)
              Else
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Updated") & "');", True)
              End If
              'GVpakSTCPOLRD.DataBind()
            End Using
          End If
        End With
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    HttpContext.Current.Server.ScriptTimeout = st
  End Sub
End Class
