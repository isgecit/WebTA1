Partial Class GF_hrmLocations
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/HRM_Main/App_Display/DF_hrmLocations.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?LocationID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVhrmLocations_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVhrmLocations.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim LocationID As Int32 = GVhrmLocations.DataKeys(e.CommandArgument).Values("LocationID")  
        Dim RedirectUrl As String = TBLhrmLocations.EditUrl & "?LocationID=" & LocationID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVhrmLocations_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVhrmLocations.Init
    DataClassName = "GhrmLocations"
    SetGridView = GVhrmLocations
  End Sub
  Protected Sub TBLhrmLocations_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLhrmLocations.Init
    SetToolBar = TBLhrmLocations
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
