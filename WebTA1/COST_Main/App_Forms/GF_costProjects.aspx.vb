Partial Class GF_costProjects
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/COST_Main/App_Display/DF_costProjects.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ProjectID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVcostProjects_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVcostProjects.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ProjectID As String = GVcostProjects.DataKeys(e.CommandArgument).Values("ProjectID")  
        Dim RedirectUrl As String = TBLcostProjects.EditUrl & "?ProjectID=" & ProjectID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVcostProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVcostProjects.Init
    DataClassName = "GcostProjects"
    SetGridView = GVcostProjects
  End Sub
  Protected Sub TBLcostProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostProjects.Init
    SetToolBar = TBLcostProjects
  End Sub
  Protected Sub F_ProjectID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ProjectID.TextChanged
    Session("F_ProjectID") = F_ProjectID.Text
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
