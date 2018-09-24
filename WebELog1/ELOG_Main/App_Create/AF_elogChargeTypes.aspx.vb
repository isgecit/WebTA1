Partial Class AF_elogChargeTypes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVelogChargeTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogChargeTypes.Init
    DataClassName = "AelogChargeTypes"
    SetFormView = FVelogChargeTypes
  End Sub
  Protected Sub TBLelogChargeTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogChargeTypes.Init
    SetToolBar = TBLelogChargeTypes
  End Sub
  Protected Sub FVelogChargeTypes_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogChargeTypes.DataBound
    SIS.ELOG.elogChargeTypes.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVelogChargeTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogChargeTypes.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Create") & "/AF_elogChargeTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogChargeTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogChargeTypes", mStr)
    End If
    If Request.QueryString("ChargeTypeID") IsNot Nothing Then
      CType(FVelogChargeTypes.FindControl("F_ChargeTypeID"), TextBox).Text = Request.QueryString("ChargeTypeID")
      CType(FVelogChargeTypes.FindControl("F_ChargeTypeID"), TextBox).Enabled = False
    End If
  End Sub

End Class
