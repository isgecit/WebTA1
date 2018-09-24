Partial Class EF_erpChaneRequest
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVerpChaneRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpChaneRequest.Init
    DataClassName = "EerpChaneRequest"
    SetFormView = FVerpChaneRequest
  End Sub
  Protected Sub TBLerpChaneRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpChaneRequest.Init
    SetToolBar = TBLerpChaneRequest
  End Sub
  Protected Sub FVerpChaneRequest_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpChaneRequest.PreRender
		TBLerpChaneRequest.PrintUrl &= Request.QueryString("ApplID") & "|"
		TBLerpChaneRequest.PrintUrl &= Request.QueryString("RequestID") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ERP_Main/App_Edit") & "/EF_erpChaneRequest.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripterpChaneRequest") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripterpChaneRequest", mStr)
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
		Dim ApplID As Int32 = CType(FVerpChaneRequest.FindControl("F_ApplID"),TextBox).Text
		Dim RequestID As Int32 = CType(FVerpChaneRequest.FindControl("F_RequestID"),TextBox).Text
		TBLerpRequestAttachments.AddUrl &= "?ApplID=" & ApplID
		TBLerpRequestAttachments.AddUrl &= "&RequestID=" & RequestID
  End Sub
	Protected Sub cmdFileUpload_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles cmdFileUpload.Command
		With F_FileUpload
			If .HasFile Then
				Dim tmpPath As String = ConfigurationManager.AppSettings("RequestAttachmentPath")
				Dim tmpName As String = IO.Path.GetRandomFileName()
				.SaveAs(tmpPath & "\\" & tmpName)
				Dim ApplID As Int32 = CType(FVerpChaneRequest.FindControl("F_ApplID"), TextBox).Text
				Dim RequestNo As Int32 = CType(FVerpChaneRequest.FindControl("F_RequestID"), TextBox).Text
				Dim oReq As SIS.ERP.erpRequestAttachments = New SIS.ERP.erpRequestAttachments()
				oReq.ApplID = ApplID
				oReq.RequestID = RequestNo
				oReq.Description = .FileName
				oReq.FileName = .FileName
				oReq.DiskFile = tmpPath & "\" & tmpName
				SIS.ERP.erpRequestAttachments.InsertData(oReq)
				GVerpRequestAttachments.DataBind()
			End If
		End With
	End Sub

End Class
