Partial Class EF_lgDMisg
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVlgDMisg_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVlgDMisg.Init
    DataClassName = "ElgDMisg"
    SetFormView = FVlgDMisg
  End Sub
  Protected Sub TBLlgDMisg_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLlgDMisg.Init
    SetToolBar = TBLlgDMisg
  End Sub
  Protected Sub FVlgDMisg_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVlgDMisg.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/LG_Main/App_Edit") & "/EF_lgDMisg.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptlgDMisg") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptlgDMisg", mStr)
    End If
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function t_cprjCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.LG.lgProjects.SelectlgProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_tdmisg001200_t_cprj(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim t_cprj As String = CType(aVal(1),String)
		Dim oVar As SIS.LG.lgProjects = SIS.LG.lgProjects.lgProjectsGetByID(t_cprj)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
