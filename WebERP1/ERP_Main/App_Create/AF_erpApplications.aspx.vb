Partial Class AF_erpApplications
  Inherits SIS.SYS.InsertBase
  Protected Sub FVerpApplications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpApplications.Init
    DataClassName = "AerpApplications"
    SetFormView = FVerpApplications
  End Sub
  Protected Sub TBLerpApplications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpApplications.Init
    SetToolBar = TBLerpApplications
  End Sub
  Protected Sub FVerpApplications_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpApplications.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ERP_Main/App_Create") & "/AF_erpApplications.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripterpApplications") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripterpApplications", mStr)
    End If
    If Request.QueryString("ApplID") IsNot Nothing Then
      CType(FVerpApplications.FindControl("F_ApplID"), TextBox).Text = Request.QueryString("ApplID")
      CType(FVerpApplications.FindControl("F_ApplID"), TextBox).Enabled = False
    End If
  End Sub

End Class
