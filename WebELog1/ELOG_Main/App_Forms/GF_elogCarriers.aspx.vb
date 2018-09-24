Partial Class GF_elogCarriers
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ELOG_Main/App_Display/DF_elogCarriers.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?CarrierID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVelogCarriers_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVelogCarriers.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim CarrierID As Int32 = GVelogCarriers.DataKeys(e.CommandArgument).Values("CarrierID")  
        Dim RedirectUrl As String = TBLelogCarriers.EditUrl & "?CarrierID=" & CarrierID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVelogCarriers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVelogCarriers.Init
    DataClassName = "GelogCarriers"
    SetGridView = GVelogCarriers
  End Sub
  Protected Sub TBLelogCarriers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogCarriers.Init
    SetToolBar = TBLelogCarriers
  End Sub
  Protected Sub F_ShipmentModeID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ShipmentModeID.SelectedIndexChanged
    Session("F_ShipmentModeID") = F_ShipmentModeID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_ShipmentModeID.SelectedValue = String.Empty
    If Not Session("F_ShipmentModeID") Is Nothing Then
      If Session("F_ShipmentModeID") <> String.Empty Then
        F_ShipmentModeID.SelectedValue = Session("F_ShipmentModeID")
      End If
    End If
  End Sub
End Class
