Partial Class AF_elogShipmentModes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVelogShipmentModes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogShipmentModes.Init
    DataClassName = "AelogShipmentModes"
    SetFormView = FVelogShipmentModes
  End Sub
  Protected Sub TBLelogShipmentModes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogShipmentModes.Init
    SetToolBar = TBLelogShipmentModes
  End Sub
  Protected Sub FVelogShipmentModes_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogShipmentModes.DataBound
    SIS.ELOG.elogShipmentModes.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVelogShipmentModes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogShipmentModes.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Create") & "/AF_elogShipmentModes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogShipmentModes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogShipmentModes", mStr)
    End If
    If Request.QueryString("ShipmentModeID") IsNot Nothing Then
      CType(FVelogShipmentModes.FindControl("F_ShipmentModeID"), TextBox).Text = Request.QueryString("ShipmentModeID")
      CType(FVelogShipmentModes.FindControl("F_ShipmentModeID"), TextBox).Enabled = False
    End If
  End Sub

End Class
