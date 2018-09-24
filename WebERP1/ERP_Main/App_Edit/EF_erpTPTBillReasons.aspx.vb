Partial Class EF_erpTPTBillReasons
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVerpTPTBillReasons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpTPTBillReasons.Init
    DataClassName = "EerpTPTBillReasons"
    SetFormView = FVerpTPTBillReasons
  End Sub
  Protected Sub TBLerpTPTBillReasons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpTPTBillReasons.Init
    SetToolBar = TBLerpTPTBillReasons
  End Sub
  Protected Sub FVerpTPTBillReasons_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpTPTBillReasons.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ERP_Main/App_Edit") & "/EF_erpTPTBillReasons.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripterpTPTBillReasons") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripterpTPTBillReasons", mStr)
    End If
  End Sub

End Class
