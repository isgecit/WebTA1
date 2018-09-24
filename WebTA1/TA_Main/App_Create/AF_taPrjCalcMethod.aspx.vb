Partial Class AF_taPrjCalcMethod
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaPrjCalcMethod_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaPrjCalcMethod.Init
    DataClassName = "AtaPrjCalcMethod"
    SetFormView = FVtaPrjCalcMethod
  End Sub
  Protected Sub TBLtaPrjCalcMethod_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaPrjCalcMethod.Init
    SetToolBar = TBLtaPrjCalcMethod
  End Sub
  Protected Sub FVtaPrjCalcMethod_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaPrjCalcMethod.DataBound
    SIS.TA.taPrjCalcMethod.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaPrjCalcMethod_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaPrjCalcMethod.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taPrjCalcMethod.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaPrjCalcMethod") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaPrjCalcMethod", mStr)
    End If
    If Request.QueryString("ProjectCalcID") IsNot Nothing Then
      CType(FVtaPrjCalcMethod.FindControl("F_ProjectCalcID"), TextBox).Text = Request.QueryString("ProjectCalcID")
      CType(FVtaPrjCalcMethod.FindControl("F_ProjectCalcID"), TextBox).Enabled = False
    End If
  End Sub

End Class
