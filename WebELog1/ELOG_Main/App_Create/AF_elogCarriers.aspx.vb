Partial Class AF_elogCarriers
  Inherits SIS.SYS.InsertBase
  Protected Sub FVelogCarriers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogCarriers.Init
    DataClassName = "AelogCarriers"
    SetFormView = FVelogCarriers
  End Sub
  Protected Sub TBLelogCarriers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogCarriers.Init
    SetToolBar = TBLelogCarriers
  End Sub
  Protected Sub FVelogCarriers_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogCarriers.DataBound
    SIS.ELOG.elogCarriers.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVelogCarriers_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogCarriers.PreRender
    Dim oF_ShipmentModeID As LC_elogShipmentModes = FVelogCarriers.FindControl("F_ShipmentModeID")
    oF_ShipmentModeID.Enabled = True
    oF_ShipmentModeID.SelectedValue = String.Empty
    If Not Session("F_ShipmentModeID") Is Nothing Then
      If Session("F_ShipmentModeID") <> String.Empty Then
        oF_ShipmentModeID.SelectedValue = Session("F_ShipmentModeID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Create") & "/AF_elogCarriers.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogCarriers") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogCarriers", mStr)
    End If
    If Request.QueryString("CarrierID") IsNot Nothing Then
      CType(FVelogCarriers.FindControl("F_CarrierID"), TextBox).Text = Request.QueryString("CarrierID")
      CType(FVelogCarriers.FindControl("F_CarrierID"), TextBox).Enabled = False
    End If
  End Sub

End Class
