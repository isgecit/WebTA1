Partial Class GF_elogShipmentModes
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ELOG_Main/App_Display/DF_elogShipmentModes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ShipmentModeID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVelogShipmentModes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVelogShipmentModes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ShipmentModeID As Int32 = GVelogShipmentModes.DataKeys(e.CommandArgument).Values("ShipmentModeID")  
        Dim RedirectUrl As String = TBLelogShipmentModes.EditUrl & "?ShipmentModeID=" & ShipmentModeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVelogShipmentModes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVelogShipmentModes.Init
    DataClassName = "GelogShipmentModes"
    SetGridView = GVelogShipmentModes
  End Sub
  Protected Sub TBLelogShipmentModes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogShipmentModes.Init
    SetToolBar = TBLelogShipmentModes
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
