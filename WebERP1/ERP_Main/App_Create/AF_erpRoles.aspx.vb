Partial Class AF_erpRoles
  Inherits SIS.SYS.InsertBase
  Protected Sub FVerpRoles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpRoles.Init
    DataClassName = "AerpRoles"
    SetFormView = FVerpRoles
  End Sub
  Protected Sub TBLerpRoles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpRoles.Init
    SetToolBar = TBLerpRoles
  End Sub
  Protected Sub FVerpRoles_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpRoles.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ERP_Main/App_Create") & "/AF_erpRoles.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripterpRoles") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripterpRoles", mStr)
    End If
    If Request.QueryString("RoleID") IsNot Nothing Then
      CType(FVerpRoles.FindControl("F_RoleID"), TextBox).Text = Request.QueryString("RoleID")
      CType(FVerpRoles.FindControl("F_RoleID"), TextBox).Enabled = False
    End If
  End Sub

End Class
