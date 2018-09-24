Partial Class EF_lgEPAttachment
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVlgEPAttachment_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVlgEPAttachment.Init
    DataClassName = "ElgEPAttachment"
    SetFormView = FVlgEPAttachment
  End Sub
  Protected Sub TBLlgEPAttachment_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLlgEPAttachment.Init
    SetToolBar = TBLlgEPAttachment
  End Sub
  Protected Sub FVlgEPAttachment_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVlgEPAttachment.PreRender
		TBLlgEPAttachment.PrintUrl &= Request.QueryString("DocPK") & "|"
		TBLlgEPAttachment.PrintUrl &= Request.QueryString("FilePK") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/LG_Main/App_Edit") & "/EF_lgEPAttachment.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptlgEPAttachment") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptlgEPAttachment", mStr)
    End If
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.LG.lgProjects.SelectlgProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_LG_EPAttachment_ProjectID(ByVal value As String) As String
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
