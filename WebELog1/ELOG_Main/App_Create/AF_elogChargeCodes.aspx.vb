Partial Class AF_elogChargeCodes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVelogChargeCodes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogChargeCodes.Init
    DataClassName = "AelogChargeCodes"
    SetFormView = FVelogChargeCodes
  End Sub
  Protected Sub TBLelogChargeCodes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogChargeCodes.Init
    SetToolBar = TBLelogChargeCodes
  End Sub
  Protected Sub FVelogChargeCodes_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogChargeCodes.DataBound
    SIS.ELOG.elogChargeCodes.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVelogChargeCodes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogChargeCodes.PreRender
    Dim oF_ChargeCategoryID As LC_elogChargeCategories = FVelogChargeCodes.FindControl("F_ChargeCategoryID")
    oF_ChargeCategoryID.Enabled = True
    oF_ChargeCategoryID.SelectedValue = String.Empty
    If Not Session("F_ChargeCategoryID") Is Nothing Then
      If Session("F_ChargeCategoryID") <> String.Empty Then
        oF_ChargeCategoryID.SelectedValue = Session("F_ChargeCategoryID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Create") & "/AF_elogChargeCodes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogChargeCodes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogChargeCodes", mStr)
    End If
    If Request.QueryString("ChargeCategoryID") IsNot Nothing Then
      CType(FVelogChargeCodes.FindControl("F_ChargeCategoryID"), LC_elogChargeCategories).SelectedValue = Request.QueryString("ChargeCategoryID")
      CType(FVelogChargeCodes.FindControl("F_ChargeCategoryID"), LC_elogChargeCategories).Enabled = False
    End If
    If Request.QueryString("ChargeCodeID") IsNot Nothing Then
      CType(FVelogChargeCodes.FindControl("F_ChargeCodeID"), TextBox).Text = Request.QueryString("ChargeCodeID")
      CType(FVelogChargeCodes.FindControl("F_ChargeCodeID"), TextBox).Enabled = False
    End If
  End Sub

End Class
