Partial Class AF_erpTPTBillReasons
  Inherits SIS.SYS.InsertBase
  Protected Sub FVerpTPTBillReasons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpTPTBillReasons.Init
    DataClassName = "AerpTPTBillReasons"
    SetFormView = FVerpTPTBillReasons
  End Sub
  Protected Sub TBLerpTPTBillReasons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpTPTBillReasons.Init
    SetToolBar = TBLerpTPTBillReasons
  End Sub
  Protected Sub FVerpTPTBillReasons_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpTPTBillReasons.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ERP_Main/App_Create") & "/AF_erpTPTBillReasons.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripterpTPTBillReasons") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripterpTPTBillReasons", mStr)
    End If
    If Request.QueryString("ReasonID") IsNot Nothing Then
      CType(FVerpTPTBillReasons.FindControl("F_ReasonID"), TextBox).Text = Request.QueryString("ReasonID")
      CType(FVerpTPTBillReasons.FindControl("F_ReasonID"), TextBox).Enabled = False
    End If
  End Sub

End Class
