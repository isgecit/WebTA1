Partial Class EF_erpRequestStatus
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVerpRequestStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpRequestStatus.Init
    DataClassName = "EerpRequestStatus"
    SetFormView = FVerpRequestStatus
  End Sub
  Protected Sub TBLerpRequestStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpRequestStatus.Init
    SetToolBar = TBLerpRequestStatus
  End Sub
  Protected Sub FVerpRequestStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpRequestStatus.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ERP_Main/App_Edit") & "/EF_erpRequestStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripterpRequestStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripterpRequestStatus", mStr)
    End If
  End Sub

End Class
