Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Imports System.IO
Partial Class EF_pakSTCPOL
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
  Protected Sub ODSpakSTCPOL_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakSTCPOL.Selected
    Dim tmp As SIS.PAK.pakSTCPOL = CType(e.ReturnValue, SIS.PAK.pakSTCPOL)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakSTCPOL_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSTCPOL.Init
    DataClassName = "EpakSTCPOL"
    SetFormView = FVpakSTCPOL
  End Sub
  Protected Sub TBLpakSTCPOL_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSTCPOL.Init
    SetToolBar = TBLpakSTCPOL
  End Sub
  Protected Sub FVpakSTCPOL_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSTCPOL.PreRender
    TBLpakSTCPOL.EnableSave = Editable
    TBLpakSTCPOL.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakSTCPOL.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSTCPOL") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSTCPOL", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpakSTCPOLRCC As New gvBase
  Protected Sub GVpakSTCPOLR_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakSTCPOLR.Init
    gvpakSTCPOLRCC.DataClassName = "GpakSTCPOLR"
    gvpakSTCPOLRCC.SetGridView = GVpakSTCPOLR
  End Sub
  Protected Sub TBLpakSTCPOLR_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSTCPOLR.Init
    gvpakSTCPOLRCC.SetToolBar = TBLpakSTCPOLR
  End Sub
  Protected Sub GVpakSTCPOLR_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakSTCPOLR.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakSTCPOLR.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim ItemNo As Int32 = GVpakSTCPOLR.DataKeys(e.CommandArgument).Values("ItemNo")
        Dim UploadNo As Int32 = GVpakSTCPOLR.DataKeys(e.CommandArgument).Values("UploadNo")
        Dim RedirectUrl As String = TBLpakSTCPOLR.EditUrl & "?SerialNo=" & SerialNo & "&ItemNo=" & ItemNo & "&UploadNo=" & UploadNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakSTCPOLR.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim ItemNo As Int32 = GVpakSTCPOLR.DataKeys(e.CommandArgument).Values("ItemNo")
        Dim UploadNo As Int32 = GVpakSTCPOLR.DataKeys(e.CommandArgument).Values("UploadNo")
        SIS.PAK.pakSTCPOLR.InitiateWF(SerialNo, ItemNo, UploadNo)
        GVpakSTCPOLR.DataBind()
        'Dim xUrl As String = SIS.PAK.pakSTCPOLR.GetCopyLink(SerialNo, ItemNo, UploadNo)
        'ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "copy_attach('" & xUrl & "');", True)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "lgcopy".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakSTCPOLR.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim ItemNo As Int32 = GVpakSTCPOLR.DataKeys(e.CommandArgument).Values("ItemNo")
        Dim UploadNo As Int32 = GVpakSTCPOLR.DataKeys(e.CommandArgument).Values("UploadNo")
        SIS.PAK.pakSTCPOLR.ReCopy(SerialNo, ItemNo, UploadNo)
        GVpakSTCPOLR.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "lgRevise".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakSTCPOLR.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim ItemNo As Int32 = GVpakSTCPOLR.DataKeys(e.CommandArgument).Values("ItemNo")
        Dim UploadNo As Int32 = GVpakSTCPOLR.DataKeys(e.CommandArgument).Values("UploadNo")
        Dim tmp As SIS.PAK.pakSTCPOLR = SIS.PAK.pakSTCPOLR.ReviseWF(SerialNo, ItemNo, UploadNo)
        GVpakSTCPOLR.DataBind()
        'Dim RedirectUrl As String = TBLpakSTCPOLR.EditUrl & "?SerialNo=" & tmp.SerialNo & "&ItemNo=" & tmp.ItemNo & "&UploadNo=" & tmp.UploadNo
        'Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub TBLpakSTCPOLR_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLpakSTCPOLR.AddClicked
    Dim SerialNo As Int32 = CType(FVpakSTCPOL.FindControl("F_SerialNo"), TextBox).Text
    Dim ItemNo As Int32 = CType(FVpakSTCPOL.FindControl("F_ItemNo"), TextBox).Text
    Dim xTmp As New SIS.PAK.pakSTCPOLR
    With xTmp
      .SerialNo = SerialNo
      .ItemNo = ItemNo
      .UploadNo = 0
      .DocumentCategoryID = 1
      .UploadRemarks = "System Created"
      .UploadStatusID = pakTCUploadStates.Free
      .CreatedBy = HttpContext.Current.Session("LoginID")
      .CreatedOn = Now
    End With
    xTmp = SIS.PAK.pakSTCPOLR.InsertData(xTmp)
    Dim UploadNo As String = xTmp.UploadNo
    Dim xdTmp As New SIS.PAK.pakSTCPOLRD
    With xdTmp
      .SerialNo = SerialNo
      .ItemNo = ItemNo
      .UploadNo = UploadNo
      .DocumentID = "Vendor Document"
      .DocumentDescription = "Uploaded By Vendor"
      .DocumentRev = "XX"
      .FileName = "NA"
      .DiskFileName = "NA"
      .ERPDocSerialNo = 1
      .AutoGenerated = True
    End With
    xdTmp = SIS.PAK.pakSTCPOLRD.InsertData(xdTmp)
    xTmp.SDocSerialNo = xdTmp.DocSerialNo
    xTmp = SIS.PAK.pakSTCPOLR.UpdateData(xTmp)

    TBLpakSTCPOLR.AddUrl &= "?SerialNo=" & SerialNo
    TBLpakSTCPOLR.AddUrl &= "&ItemNo=" & ItemNo
    'TBLpakSTCPOLR.AddUrl &= "&UploadNo=" & UploadNo
  End Sub

  'Private Sub FVpakSTCPOL_ItemCommand(sender As Object, e As FormViewCommandEventArgs) Handles FVpakSTCPOL.ItemCommand
  '  If e.CommandName.ToLower = "filesupload" Then
  '    Try
  '      Dim aVal() As String = e.CommandArgument.ToString.Split("|".ToCharArray)
  '      Dim SerialNo As String = aVal(0)
  '      Dim ItemNo As String = aVal(1)
  '      Dim UploadNo As String = ""
  '      '============Get or Create Upload Set===============
  '      Dim tmpUploads As List(Of SIS.PAK.pakSTCPOLR) = SIS.PAK.pakSTCPOLR.pakSTCPOLRSelectList(0, 9999, "", False, "", SerialNo, ItemNo)
  '      If tmpUploads.Count > 0 Then
  '        For Each tmpupl As SIS.PAK.pakSTCPOLR In tmpUploads
  '          If tmpupl.UploadStatusID = pakTCUploadStates.Free Then
  '            UploadNo = tmpupl.UploadNo
  '            'DO Not Exit find last UploadNo
  '          End If
  '        Next
  '      End If
  '      If UploadNo = String.Empty Then
  '        'Create NEW Upload Set
  '        Dim tmpUpl As New SIS.PAK.pakSTCPOLR
  '        With tmpUpl
  '          .SerialNo = SerialNo
  '          .ItemNo = ItemNo
  '          .UploadNo = 0
  '          .DocumentCategoryID = 1 'Critical
  '          .UploadRemarks = "Auto Created"
  '          .UploadStatusID = pakTCUploadStates.Free
  '          .CreatedBy = HttpContext.Current.Session("LoginID")
  '          .CreatedOn = Now
  '        End With
  '        tmpUpl = SIS.PAK.pakSTCPOLR.UZ_pakSTCPOLRInsert(tmpUpl)
  '        UploadNo = tmpUpl.UploadNo
  '      End If
  '      '================End of Get or Create Upload Set====
  '      Try
  '        If SIS.PAK.pakSTCPOLR.AddRequestFiles(Request, SerialNo & "|" & ItemNo & "|" & UploadNo) Then
  '          GVpakSTCPOLR.DataBind()
  '          Response.Redirect(Request.UrlReferrer.ToString)
  '        End If
  '      Catch ex As Exception
  '        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
  '      End Try
  '    Catch ex As Exception
  '      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
  '    End Try
  '  End If
  'End Sub
End Class
