Partial Class GF_pakUnits
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PAK_Main/App_Display/DF_pakUnits.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?UnitID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpakUnits_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakUnits.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim UnitID As Int32 = GVpakUnits.DataKeys(e.CommandArgument).Values("UnitID")  
        Dim RedirectUrl As String = TBLpakUnits.EditUrl & "?UnitID=" & UnitID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVpakUnits_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakUnits.Init
    DataClassName = "GpakUnits"
    SetGridView = GVpakUnits
  End Sub
  Protected Sub TBLpakUnits_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakUnits.Init
    SetToolBar = TBLpakUnits
  End Sub
  Protected Sub F_UnitSetID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_UnitSetID.SelectedIndexChanged
    Session("F_UnitSetID") = F_UnitSetID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_UnitSetID.SelectedValue = String.Empty
    If Not Session("F_UnitSetID") Is Nothing Then
      If Session("F_UnitSetID") <> String.Empty Then
        F_UnitSetID.SelectedValue = Session("F_UnitSetID")
      End If
    End If
  End Sub
End Class
