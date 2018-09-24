Partial Class EF_erpRoles
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVerpRoles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpRoles.Init
    DataClassName = "EerpRoles"
    SetFormView = FVerpRoles
  End Sub
  Protected Sub TBLerpRoles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpRoles.Init
    SetToolBar = TBLerpRoles
  End Sub
  Protected Sub FVerpRoles_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpRoles.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ERP_Main/App_Edit") & "/EF_erpRoles.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripterpRoles") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripterpRoles", mStr)
    End If
  End Sub

End Class
