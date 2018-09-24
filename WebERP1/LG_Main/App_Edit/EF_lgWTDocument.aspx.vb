Partial Class EF_lgWTDocument
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVlgWTDocument_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVlgWTDocument.Init
    DataClassName = "ElgWTDocument"
    SetFormView = FVlgWTDocument
  End Sub
  Protected Sub TBLlgWTDocument_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLlgWTDocument.Init
    SetToolBar = TBLlgWTDocument
  End Sub
  Protected Sub FVlgWTDocument_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVlgWTDocument.PreRender
		TBLlgWTDocument.PrintUrl &= Request.QueryString("DocPK") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/LG_Main/App_Edit") & "/EF_lgWTDocument.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptlgWTDocument") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptlgWTDocument", mStr)
    End If
  End Sub
  Partial Class gvBase
		Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvlgWTFileCC As New gvBase
  Protected Sub GVlgWTFile_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVlgWTFile.Init
		gvlgWTFileCC.DataClassName = "GlgWTFile"
		gvlgWTFileCC.SetGridView = GVlgWTFile
  End Sub
  Protected Sub TBLlgWTFile_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLlgWTFile.Init
		gvlgWTFileCC.SetToolBar = TBLlgWTFile
  End Sub
  Protected Sub GVlgWTFile_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVlgWTFile.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim DocPK As Int64 = GVlgWTFile.DataKeys(e.CommandArgument).Values("DocPK")  
				Dim FilePK As Int64 = GVlgWTFile.DataKeys(e.CommandArgument).Values("FilePK")  
				Dim RedirectUrl As String = TBLlgWTFile.EditUrl & "?DocPK=" & DocPK & "&FilePK=" & FilePK
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Private WithEvents gvlgWTAttachmentCC As New gvBase
  Protected Sub GVlgWTAttachment_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVlgWTAttachment.Init
		gvlgWTAttachmentCC.DataClassName = "GlgWTAttachment"
		gvlgWTAttachmentCC.SetGridView = GVlgWTAttachment
  End Sub
  Protected Sub TBLlgWTAttachment_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLlgWTAttachment.Init
		gvlgWTAttachmentCC.SetToolBar = TBLlgWTAttachment
  End Sub
  Protected Sub GVlgWTAttachment_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVlgWTAttachment.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim DocPK As Int64 = GVlgWTAttachment.DataKeys(e.CommandArgument).Values("DocPK")  
				Dim FilePK As Int64 = GVlgWTAttachment.DataKeys(e.CommandArgument).Values("FilePK")  
				Dim RedirectUrl As String = TBLlgWTAttachment.EditUrl & "?DocPK=" & DocPK & "&FilePK=" & FilePK
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Private WithEvents gvlgWTAttributesCC As New gvBase
  Protected Sub GVlgWTAttributes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVlgWTAttributes.Init
		gvlgWTAttributesCC.DataClassName = "GlgWTAttributes"
		gvlgWTAttributesCC.SetGridView = GVlgWTAttributes
  End Sub
  Protected Sub TBLlgWTAttributes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLlgWTAttributes.Init
		gvlgWTAttributesCC.SetToolBar = TBLlgWTAttributes
  End Sub
  Protected Sub GVlgWTAttributes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVlgWTAttributes.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim DocPK As Int64 = GVlgWTAttributes.DataKeys(e.CommandArgument).Values("DocPK")  
				Dim displayName As String = GVlgWTAttributes.DataKeys(e.CommandArgument).Values("displayName")  
				Dim RedirectUrl As String = TBLlgWTAttributes.EditUrl & "?DocPK=" & DocPK & "&displayName=" & displayName
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Private WithEvents gvlgWTDCRCC As New gvBase
  Protected Sub GVlgWTDCR_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVlgWTDCR.Init
		gvlgWTDCRCC.DataClassName = "GlgWTDCR"
		gvlgWTDCRCC.SetGridView = GVlgWTDCR
  End Sub
  Protected Sub TBLlgWTDCR_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLlgWTDCR.Init
		gvlgWTDCRCC.SetToolBar = TBLlgWTDCR
  End Sub
  Protected Sub GVlgWTDCR_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVlgWTDCR.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim DocPK As Int64 = GVlgWTDCR.DataKeys(e.CommandArgument).Values("DocPK")  
				Dim DCRID As String = GVlgWTDCR.DataKeys(e.CommandArgument).Values("DCRID")  
				Dim DCRLine As Int32 = GVlgWTDCR.DataKeys(e.CommandArgument).Values("DCRLine")  
				Dim RedirectUrl As String = TBLlgWTDCR.EditUrl & "?DocPK=" & DocPK & "&DCRID=" & DCRID & "&DCRLine=" & DCRLine
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
  Public Shared Function validate_FK_LG_WTDocument_ProjectID(ByVal value As String) As String
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
