Partial Class EF_erpTPTBillStatus
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVerpTPTBillStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpTPTBillStatus.Init
    DataClassName = "EerpTPTBillStatus"
    SetFormView = FVerpTPTBillStatus
  End Sub
  Protected Sub TBLerpTPTBillStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpTPTBillStatus.Init
    SetToolBar = TBLerpTPTBillStatus
  End Sub
  Protected Sub FVerpTPTBillStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpTPTBillStatus.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ERP_Main/App_Edit") & "/EF_erpTPTBillStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripterpTPTBillStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripterpTPTBillStatus", mStr)
    End If
  End Sub

End Class
