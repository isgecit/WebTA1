Partial Class GF_nprkPerks
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/NPRK_Main/App_Display/DF_nprkPerks.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?PerkID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVnprkPerks_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVnprkPerks.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim PerkID As Int32 = GVnprkPerks.DataKeys(e.CommandArgument).Values("PerkID")  
        Dim RedirectUrl As String = TBLnprkPerks.EditUrl & "?PerkID=" & PerkID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVnprkPerks_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVnprkPerks.Init
    DataClassName = "GnprkPerks"
    SetGridView = GVnprkPerks
  End Sub
  Protected Sub TBLnprkPerks_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkPerks.Init
    SetToolBar = TBLnprkPerks
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
