Partial Class EF_lgWTAttachment
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVlgWTAttachment_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVlgWTAttachment.Init
    DataClassName = "ElgWTAttachment"
    SetFormView = FVlgWTAttachment
  End Sub
  Protected Sub TBLlgWTAttachment_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLlgWTAttachment.Init
    SetToolBar = TBLlgWTAttachment
  End Sub
  Protected Sub FVlgWTAttachment_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVlgWTAttachment.PreRender
		TBLlgWTAttachment.PrintUrl &= Request.QueryString("DocPK") & "|"
		TBLlgWTAttachment.PrintUrl &= Request.QueryString("FilePK") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/LG_Main/App_Edit") & "/EF_lgWTAttachment.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptlgWTAttachment") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptlgWTAttachment", mStr)
    End If
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.LG.lgProjects.SelectlgProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_LG_WTAttachment_ProjectID(ByVal value As String) As String
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
