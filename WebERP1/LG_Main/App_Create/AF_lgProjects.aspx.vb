Partial Class AF_lgProjects
  Inherits SIS.SYS.InsertBase
  Protected Sub FVlgProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVlgProjects.Init
    DataClassName = "AlgProjects"
    SetFormView = FVlgProjects
  End Sub
  Protected Sub TBLlgProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLlgProjects.Init
    SetToolBar = TBLlgProjects
  End Sub
  Protected Sub FVlgProjects_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVlgProjects.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/LG_Main/App_Create") & "/AF_lgProjects.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptlgProjects") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptlgProjects", mStr)
    End If
    If Request.QueryString("ProjectID") IsNot Nothing Then
      CType(FVlgProjects.FindControl("F_ProjectID"), TextBox).Text = Request.QueryString("ProjectID")
      CType(FVlgProjects.FindControl("F_ProjectID"), TextBox).Enabled = False
    End If
  End Sub
	<System.Web.Services.WebMethod()> _
  Public Shared Function validatePK_lgProjects(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim ProjectID As String = CType(aVal(1),String)
		Dim oVar As SIS.LG.lgProjects = SIS.LG.lgProjects.lgProjectsGetByID(ProjectID)
    If Not oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record allready exists." 
    End If
    Return mRet
  End Function

End Class
