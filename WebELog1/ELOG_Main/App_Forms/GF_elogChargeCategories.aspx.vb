Partial Class GF_elogChargeCategories
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ELOG_Main/App_Display/DF_elogChargeCategories.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ChargeCategoryID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVelogChargeCategories_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVelogChargeCategories.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ChargeCategoryID As Int32 = GVelogChargeCategories.DataKeys(e.CommandArgument).Values("ChargeCategoryID")  
        Dim RedirectUrl As String = TBLelogChargeCategories.EditUrl & "?ChargeCategoryID=" & ChargeCategoryID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVelogChargeCategories_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVelogChargeCategories.Init
    DataClassName = "GelogChargeCategories"
    SetGridView = GVelogChargeCategories
  End Sub
  Protected Sub TBLelogChargeCategories_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogChargeCategories.Init
    SetToolBar = TBLelogChargeCategories
  End Sub
  Protected Sub F_ShipmentModeID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ShipmentModeID.SelectedIndexChanged
    Session("F_ShipmentModeID") = F_ShipmentModeID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_LocationCountryID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_LocationCountryID.SelectedIndexChanged
    Session("F_LocationCountryID") = F_LocationCountryID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_CargoTypeID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CargoTypeID.SelectedIndexChanged
    Session("F_CargoTypeID") = F_CargoTypeID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_StuffingTypeID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_StuffingTypeID.SelectedIndexChanged
    Session("F_StuffingTypeID") = F_StuffingTypeID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_StuffingPointID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_StuffingPointID.SelectedIndexChanged
    Session("F_StuffingPointID") = F_StuffingPointID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_BreakbulkTypeID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_BreakbulkTypeID.SelectedIndexChanged
    Session("F_BreakbulkTypeID") = F_BreakbulkTypeID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_ChargeTypeID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ChargeTypeID.SelectedIndexChanged
    Session("F_ChargeTypeID") = F_ChargeTypeID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_ShipmentModeID.SelectedValue = String.Empty
    If Not Session("F_ShipmentModeID") Is Nothing Then
      If Session("F_ShipmentModeID") <> String.Empty Then
        F_ShipmentModeID.SelectedValue = Session("F_ShipmentModeID")
      End If
    End If
    F_LocationCountryID.SelectedValue = String.Empty
    If Not Session("F_LocationCountryID") Is Nothing Then
      If Session("F_LocationCountryID") <> String.Empty Then
        F_LocationCountryID.SelectedValue = Session("F_LocationCountryID")
      End If
    End If
    F_CargoTypeID.SelectedValue = String.Empty
    If Not Session("F_CargoTypeID") Is Nothing Then
      If Session("F_CargoTypeID") <> String.Empty Then
        F_CargoTypeID.SelectedValue = Session("F_CargoTypeID")
      End If
    End If
    F_StuffingTypeID.SelectedValue = String.Empty
    If Not Session("F_StuffingTypeID") Is Nothing Then
      If Session("F_StuffingTypeID") <> String.Empty Then
        F_StuffingTypeID.SelectedValue = Session("F_StuffingTypeID")
      End If
    End If
    F_StuffingPointID.SelectedValue = String.Empty
    If Not Session("F_StuffingPointID") Is Nothing Then
      If Session("F_StuffingPointID") <> String.Empty Then
        F_StuffingPointID.SelectedValue = Session("F_StuffingPointID")
      End If
    End If
    F_BreakbulkTypeID.SelectedValue = String.Empty
    If Not Session("F_BreakbulkTypeID") Is Nothing Then
      If Session("F_BreakbulkTypeID") <> String.Empty Then
        F_BreakbulkTypeID.SelectedValue = Session("F_BreakbulkTypeID")
      End If
    End If
    F_ChargeTypeID.SelectedValue = String.Empty
    If Not Session("F_ChargeTypeID") Is Nothing Then
      If Session("F_ChargeTypeID") <> String.Empty Then
        F_ChargeTypeID.SelectedValue = Session("F_ChargeTypeID")
      End If
    End If
  End Sub
End Class
