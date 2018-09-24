Partial Class AF_elogChargeCategories
  Inherits SIS.SYS.InsertBase
  Protected Sub FVelogChargeCategories_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogChargeCategories.Init
    DataClassName = "AelogChargeCategories"
    SetFormView = FVelogChargeCategories
  End Sub
  Protected Sub TBLelogChargeCategories_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogChargeCategories.Init
    SetToolBar = TBLelogChargeCategories
  End Sub
  Protected Sub ODSelogChargeCategories_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSelogChargeCategories.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.ELOG.elogChargeCategories = CType(e.ReturnValue,SIS.ELOG.elogChargeCategories)
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&ChargeCategoryID=" & oDC.ChargeCategoryID
      TBLelogChargeCategories.AfterInsertURL &= tmpURL 
    End If
  End Sub
  Protected Sub FVelogChargeCategories_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogChargeCategories.DataBound
    SIS.ELOG.elogChargeCategories.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVelogChargeCategories_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogChargeCategories.PreRender
    Dim oF_ShipmentModeID As LC_elogShipmentModes = FVelogChargeCategories.FindControl("F_ShipmentModeID")
    oF_ShipmentModeID.Enabled = True
    oF_ShipmentModeID.SelectedValue = String.Empty
    If Not Session("F_ShipmentModeID") Is Nothing Then
      If Session("F_ShipmentModeID") <> String.Empty Then
        oF_ShipmentModeID.SelectedValue = Session("F_ShipmentModeID")
      End If
    End If
    Dim oF_LocationCountryID As LC_elogLocationCountries = FVelogChargeCategories.FindControl("F_LocationCountryID")
    oF_LocationCountryID.Enabled = True
    oF_LocationCountryID.SelectedValue = String.Empty
    If Not Session("F_LocationCountryID") Is Nothing Then
      If Session("F_LocationCountryID") <> String.Empty Then
        oF_LocationCountryID.SelectedValue = Session("F_LocationCountryID")
      End If
    End If
    Dim oF_CargoTypeID As LC_elogCargoTypes = FVelogChargeCategories.FindControl("F_CargoTypeID")
    oF_CargoTypeID.Enabled = True
    oF_CargoTypeID.SelectedValue = String.Empty
    If Not Session("F_CargoTypeID") Is Nothing Then
      If Session("F_CargoTypeID") <> String.Empty Then
        oF_CargoTypeID.SelectedValue = Session("F_CargoTypeID")
      End If
    End If
    Dim oF_StuffingTypeID As LC_elogStuffingTypes = FVelogChargeCategories.FindControl("F_StuffingTypeID")
    oF_StuffingTypeID.Enabled = True
    oF_StuffingTypeID.SelectedValue = String.Empty
    If Not Session("F_StuffingTypeID") Is Nothing Then
      If Session("F_StuffingTypeID") <> String.Empty Then
        oF_StuffingTypeID.SelectedValue = Session("F_StuffingTypeID")
      End If
    End If
    Dim oF_StuffingPointID As LC_elogStuffingPoints = FVelogChargeCategories.FindControl("F_StuffingPointID")
    oF_StuffingPointID.Enabled = True
    oF_StuffingPointID.SelectedValue = String.Empty
    If Not Session("F_StuffingPointID") Is Nothing Then
      If Session("F_StuffingPointID") <> String.Empty Then
        oF_StuffingPointID.SelectedValue = Session("F_StuffingPointID")
      End If
    End If
    Dim oF_BreakbulkTypeID As LC_elogBreakbulkTypes = FVelogChargeCategories.FindControl("F_BreakbulkTypeID")
    oF_BreakbulkTypeID.Enabled = True
    oF_BreakbulkTypeID.SelectedValue = String.Empty
    If Not Session("F_BreakbulkTypeID") Is Nothing Then
      If Session("F_BreakbulkTypeID") <> String.Empty Then
        oF_BreakbulkTypeID.SelectedValue = Session("F_BreakbulkTypeID")
      End If
    End If
    Dim oF_ChargeTypeID As LC_elogChargeTypes = FVelogChargeCategories.FindControl("F_ChargeTypeID")
    oF_ChargeTypeID.Enabled = True
    oF_ChargeTypeID.SelectedValue = String.Empty
    If Not Session("F_ChargeTypeID") Is Nothing Then
      If Session("F_ChargeTypeID") <> String.Empty Then
        oF_ChargeTypeID.SelectedValue = Session("F_ChargeTypeID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Create") & "/AF_elogChargeCategories.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogChargeCategories") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogChargeCategories", mStr)
    End If
    If Request.QueryString("ChargeCategoryID") IsNot Nothing Then
      CType(FVelogChargeCategories.FindControl("F_ChargeCategoryID"), TextBox).Text = Request.QueryString("ChargeCategoryID")
      CType(FVelogChargeCategories.FindControl("F_ChargeCategoryID"), TextBox).Enabled = False
    End If
  End Sub

End Class
