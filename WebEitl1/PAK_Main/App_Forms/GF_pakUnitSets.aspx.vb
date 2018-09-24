Partial Class GF_pakUnitSets
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PAK_Main/App_Display/DF_pakUnitSets.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?UnitSetID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpakUnitSets_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakUnitSets.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim UnitSetID As Int32 = GVpakUnitSets.DataKeys(e.CommandArgument).Values("UnitSetID")  
        Dim RedirectUrl As String = TBLpakUnitSets.EditUrl & "?UnitSetID=" & UnitSetID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVpakUnitSets_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakUnitSets.Init
    DataClassName = "GpakUnitSets"
    SetGridView = GVpakUnitSets
  End Sub
  Protected Sub TBLpakUnitSets_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakUnitSets.Init
    SetToolBar = TBLpakUnitSets
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
