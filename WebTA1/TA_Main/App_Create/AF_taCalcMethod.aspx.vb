Partial Class AF_taCalcMethod
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaCalcMethod_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCalcMethod.Init
    DataClassName = "AtaCalcMethod"
    SetFormView = FVtaCalcMethod
  End Sub
  Protected Sub TBLtaCalcMethod_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaCalcMethod.Init
    SetToolBar = TBLtaCalcMethod
  End Sub
  Protected Sub FVtaCalcMethod_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCalcMethod.DataBound
    SIS.TA.taCalcMethod.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaCalcMethod_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCalcMethod.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taCalcMethod.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaCalcMethod") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaCalcMethod", mStr)
    End If
    If Request.QueryString("CalculationTypeID") IsNot Nothing Then
      CType(FVtaCalcMethod.FindControl("F_CalculationTypeID"), TextBox).Text = Request.QueryString("CalculationTypeID")
      CType(FVtaCalcMethod.FindControl("F_CalculationTypeID"), TextBox).Enabled = False
    End If
  End Sub

End Class
