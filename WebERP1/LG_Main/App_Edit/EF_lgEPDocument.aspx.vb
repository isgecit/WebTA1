Partial Class EF_lgEPDocument
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVlgEPDocument_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVlgEPDocument.Init
    DataClassName = "ElgEPDocument"
    SetFormView = FVlgEPDocument
  End Sub
  Protected Sub TBLlgEPDocument_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLlgEPDocument.Init
    SetToolBar = TBLlgEPDocument
  End Sub
  Protected Sub FVlgEPDocument_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVlgEPDocument.PreRender
		TBLlgEPDocument.PrintUrl &= Request.QueryString("DocPK") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/LG_Main/App_Edit") & "/EF_lgEPDocument.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptlgEPDocument") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptlgEPDocument", mStr)
    End If
  End Sub
  Partial Class gvBase
		Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvlgEPFileCC As New gvBase
  Protected Sub GVlgEPFile_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVlgEPFile.Init
		gvlgEPFileCC.DataClassName = "GlgEPFile"
		gvlgEPFileCC.SetGridView = GVlgEPFile
  End Sub
  Protected Sub TBLlgEPFile_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLlgEPFile.Init
		gvlgEPFileCC.SetToolBar = TBLlgEPFile
  End Sub
  Protected Sub GVlgEPFile_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVlgEPFile.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim DocPK As Int64 = GVlgEPFile.DataKeys(e.CommandArgument).Values("DocPK")  
				Dim FilePK As Int64 = GVlgEPFile.DataKeys(e.CommandArgument).Values("FilePK")  
				Dim RedirectUrl As String = TBLlgEPFile.EditUrl & "?DocPK=" & DocPK & "&FilePK=" & FilePK
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Private WithEvents gvlgEPAttachmentCC As New gvBase
  Protected Sub GVlgEPAttachment_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVlgEPAttachment.Init
		gvlgEPAttachmentCC.DataClassName = "GlgEPAttachment"
		gvlgEPAttachmentCC.SetGridView = GVlgEPAttachment
  End Sub
  Protected Sub TBLlgEPAttachment_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLlgEPAttachment.Init
		gvlgEPAttachmentCC.SetToolBar = TBLlgEPAttachment
  End Sub
  Protected Sub GVlgEPAttachment_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVlgEPAttachment.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim DocPK As Int64 = GVlgEPAttachment.DataKeys(e.CommandArgument).Values("DocPK")  
				Dim FilePK As Int64 = GVlgEPAttachment.DataKeys(e.CommandArgument).Values("FilePK")  
				Dim RedirectUrl As String = TBLlgEPAttachment.EditUrl & "?DocPK=" & DocPK & "&FilePK=" & FilePK
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Private WithEvents gvlgEPAttributesCC As New gvBase
  Protected Sub GVlgEPAttributes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVlgEPAttributes.Init
		gvlgEPAttributesCC.DataClassName = "GlgEPAttributes"
		gvlgEPAttributesCC.SetGridView = GVlgEPAttributes
  End Sub
  Protected Sub TBLlgEPAttributes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLlgEPAttributes.Init
		gvlgEPAttributesCC.SetToolBar = TBLlgEPAttributes
  End Sub
  Protected Sub GVlgEPAttributes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVlgEPAttributes.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim DocPK As Int64 = GVlgEPAttributes.DataKeys(e.CommandArgument).Values("DocPK")  
				Dim displayName As String = GVlgEPAttributes.DataKeys(e.CommandArgument).Values("displayName")  
				Dim RedirectUrl As String = TBLlgEPAttributes.EditUrl & "?DocPK=" & DocPK & "&displayName=" & displayName
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Private WithEvents gvlgEPDCRCC As New gvBase
  Protected Sub GVlgEPDCR_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVlgEPDCR.Init
		gvlgEPDCRCC.DataClassName = "GlgEPDCR"
		gvlgEPDCRCC.SetGridView = GVlgEPDCR
  End Sub
  Protected Sub TBLlgEPDCR_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLlgEPDCR.Init
		gvlgEPDCRCC.SetToolBar = TBLlgEPDCR
  End Sub
  Protected Sub GVlgEPDCR_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVlgEPDCR.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim DocPK As Int64 = GVlgEPDCR.DataKeys(e.CommandArgument).Values("DocPK")  
				Dim DCRID As String = GVlgEPDCR.DataKeys(e.CommandArgument).Values("DCRID")  
				Dim DCRLine As Int32 = GVlgEPDCR.DataKeys(e.CommandArgument).Values("DCRLine")  
				Dim RedirectUrl As String = TBLlgEPDCR.EditUrl & "?DocPK=" & DocPK & "&DCRID=" & DCRID & "&DCRLine=" & DCRLine
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.LG.lgProjects.SelectlgProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_LG_EPDocument_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim ProjectID As String = CType(aVal(1),String)
		Dim oVar As SIS.LG.lgProjects = SIS.LG.lgProjects.lgProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
