Partial Class EF_erpApprovalByHOD
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVerpApprovalByHOD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpApprovalByHOD.Init
    DataClassName = "EerpApprovalByHOD"
    SetFormView = FVerpApprovalByHOD
  End Sub
  Protected Sub TBLerpApprovalByHOD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpApprovalByHOD.Init
    SetToolBar = TBLerpApprovalByHOD
  End Sub
  Protected Sub FVerpApprovalByHOD_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpApprovalByHOD.PreRender
		TBLerpApprovalByHOD.PrintUrl &= Request.QueryString("ApplID") & "|"
		TBLerpApprovalByHOD.PrintUrl &= Request.QueryString("RequestID") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ERP_Main/App_Edit") & "/EF_erpApprovalByHOD.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripterpApprovalByHOD") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripterpApprovalByHOD", mStr)
    End If
  End Sub
  Partial Class gvBase
		Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gverpRequestAttachmentsCC As New gvBase
  Protected Sub GVerpRequestAttachments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVerpRequestAttachments.Init
		gverpRequestAttachmentsCC.DataClassName = "GerpRequestAttachments"
		gverpRequestAttachmentsCC.SetGridView = GVerpRequestAttachments
  End Sub
  Protected Sub TBLerpRequestAttachments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpRequestAttachments.Init
		gverpRequestAttachmentsCC.SetToolBar = TBLerpRequestAttachments
  End Sub
  Protected Sub GVerpRequestAttachments_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVerpRequestAttachments.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim ApplID As Int32 = GVerpRequestAttachments.DataKeys(e.CommandArgument).Values("ApplID")  
				Dim RequestID As Int32 = GVerpRequestAttachments.DataKeys(e.CommandArgument).Values("RequestID")  
				Dim SerialNo As Int32 = GVerpRequestAttachments.DataKeys(e.CommandArgument).Values("SerialNo")  
				Dim RedirectUrl As String = TBLerpRequestAttachments.EditUrl & "?ApplID=" & ApplID & "&RequestID=" & RequestID & "&SerialNo=" & SerialNo
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub TBLerpRequestAttachments_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLerpRequestAttachments.AddClicked
		Dim ApplID As Int32 = CType(FVerpApprovalByHOD.FindControl("F_ApplID"),TextBox).Text
		Dim RequestID As Int32 = CType(FVerpApprovalByHOD.FindControl("F_RequestID"),TextBox).Text
		TBLerpRequestAttachments.AddUrl &= "?ApplID=" & ApplID
		TBLerpRequestAttachments.AddUrl &= "&RequestID=" & RequestID
  End Sub

End Class
