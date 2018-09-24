Partial Class EF_eitlIssuedPODocument
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVeitlIssuedPODocument_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlIssuedPODocument.Init
    DataClassName = "EeitlIssuedPODocument"
    SetFormView = FVeitlIssuedPODocument
  End Sub
  Protected Sub TBLeitlIssuedPODocument_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlIssuedPODocument.Init
    SetToolBar = TBLeitlIssuedPODocument
  End Sub
  Protected Sub FVeitlIssuedPODocument_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlIssuedPODocument.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/EITL_Main/App_Edit") & "/EF_eitlIssuedPODocument.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripteitlIssuedPODocument") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripteitlIssuedPODocument", mStr)
    End If
  End Sub
  Partial Class gvBase
		Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gveitlIssuedPODocumentFileCC As New gvBase
  Protected Sub GVeitlIssuedPODocumentFile_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVeitlIssuedPODocumentFile.Init
		gveitlIssuedPODocumentFileCC.DataClassName = "GeitlIssuedPODocumentFile"
		gveitlIssuedPODocumentFileCC.SetGridView = GVeitlIssuedPODocumentFile
  End Sub
  Protected Sub TBLeitlIssuedPODocumentFile_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlIssuedPODocumentFile.Init
		gveitlIssuedPODocumentFileCC.SetToolBar = TBLeitlIssuedPODocumentFile
  End Sub
  Protected Sub GVeitlIssuedPODocumentFile_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVeitlIssuedPODocumentFile.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim SerialNo As Int32 = GVeitlIssuedPODocumentFile.DataKeys(e.CommandArgument).Values("SerialNo")  
				Dim DocumentLineNo As Int32 = GVeitlIssuedPODocumentFile.DataKeys(e.CommandArgument).Values("DocumentLineNo")  
				Dim FileNo As Int32 = GVeitlIssuedPODocumentFile.DataKeys(e.CommandArgument).Values("FileNo")  
				Dim RedirectUrl As String = TBLeitlIssuedPODocumentFile.EditUrl & "?SerialNo=" & SerialNo & "&DocumentLineNo=" & DocumentLineNo & "&FileNo=" & FileNo
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub

End Class
