Partial Class GF_hrmOfficeLocation
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/HRM_Main/App_Display/DF_hrmOfficeLocation.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?LocationID=" & aVal(0) & "&OfficeID=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVhrmOfficeLocation_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVhrmOfficeLocation.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim LocationID As Int32 = GVhrmOfficeLocation.DataKeys(e.CommandArgument).Values("LocationID")  
        Dim OfficeID As Int32 = GVhrmOfficeLocation.DataKeys(e.CommandArgument).Values("OfficeID")  
        Dim RedirectUrl As String = TBLhrmOfficeLocation.EditUrl & "?LocationID=" & LocationID & "&OfficeID=" & OfficeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVhrmOfficeLocation_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVhrmOfficeLocation.Init
    DataClassName = "GhrmOfficeLocation"
    SetGridView = GVhrmOfficeLocation
  End Sub
  Protected Sub TBLhrmOfficeLocation_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLhrmOfficeLocation.Init
    SetToolBar = TBLhrmOfficeLocation
  End Sub
  Protected Sub F_LocationID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_LocationID.SelectedIndexChanged
    Session("F_LocationID") = F_LocationID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_LocationID.SelectedValue = String.Empty
    If Not Session("F_LocationID") Is Nothing Then
      If Session("F_LocationID") <> String.Empty Then
        F_LocationID.SelectedValue = Session("F_LocationID")
      End If
    End If
  End Sub
End Class
