Partial Class EF_erpApplications
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVerpApplications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpApplications.Init
    DataClassName = "EerpApplications"
    SetFormView = FVerpApplications
  End Sub
  Protected Sub TBLerpApplications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpApplications.Init
    SetToolBar = TBLerpApplications
  End Sub
  Protected Sub FVerpApplications_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpApplications.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ERP_Main/App_Edit") & "/EF_erpApplications.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripterpApplications") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripterpApplications", mStr)
    End If
  End Sub

End Class
