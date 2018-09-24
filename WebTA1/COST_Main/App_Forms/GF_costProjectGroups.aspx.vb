Partial Class GF_costProjectGroups
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/COST_Main/App_Display/DF_costProjectGroups.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ProjectGroupID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVcostProjectGroups_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVcostProjectGroups.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ProjectGroupID As Int32 = GVcostProjectGroups.DataKeys(e.CommandArgument).Values("ProjectGroupID")  
        Dim RedirectUrl As String = TBLcostProjectGroups.EditUrl & "?ProjectGroupID=" & ProjectGroupID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVcostProjectGroups_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVcostProjectGroups.Init
    DataClassName = "GcostProjectGroups"
    SetGridView = GVcostProjectGroups
  End Sub
  Protected Sub TBLcostProjectGroups_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostProjectGroups.Init
    SetToolBar = TBLcostProjectGroups
  End Sub
  Protected Sub F_ProjectGroupID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ProjectGroupID.TextChanged
    Session("F_ProjectGroupID") = F_ProjectGroupID.Text
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
