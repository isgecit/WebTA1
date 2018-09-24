Partial Class EF_erpRequestPriority
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVerpRequestPriority_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpRequestPriority.Init
    DataClassName = "EerpRequestPriority"
    SetFormView = FVerpRequestPriority
  End Sub
  Protected Sub TBLerpRequestPriority_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpRequestPriority.Init
    SetToolBar = TBLerpRequestPriority
  End Sub
  Protected Sub FVerpRequestPriority_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpRequestPriority.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ERP_Main/App_Edit") & "/EF_erpRequestPriority.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripterpRequestPriority") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripterpRequestPriority", mStr)
    End If
  End Sub

End Class
