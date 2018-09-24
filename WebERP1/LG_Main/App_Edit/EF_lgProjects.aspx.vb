Partial Class EF_lgProjects
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVlgProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVlgProjects.Init
    DataClassName = "ElgProjects"
    SetFormView = FVlgProjects
  End Sub
  Protected Sub TBLlgProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLlgProjects.Init
    SetToolBar = TBLlgProjects
  End Sub
  Protected Sub FVlgProjects_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVlgProjects.PreRender
		TBLlgProjects.PrintUrl &= Request.QueryString("ProjectID") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/LG_Main/App_Edit") & "/EF_lgProjects.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptlgProjects") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptlgProjects", mStr)
    End If
  End Sub

End Class
