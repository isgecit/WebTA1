Partial Class GF_nprkRules
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/NPRK_Main/App_Display/DF_nprkRules.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?RuleID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVnprkRules_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVnprkRules.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim RuleID As Int32 = GVnprkRules.DataKeys(e.CommandArgument).Values("RuleID")  
        Dim RedirectUrl As String = TBLnprkRules.EditUrl & "?RuleID=" & RuleID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVnprkRules_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVnprkRules.Init
    DataClassName = "GnprkRules"
    SetGridView = GVnprkRules
  End Sub
  Protected Sub TBLnprkRules_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkRules.Init
    SetToolBar = TBLnprkRules
  End Sub
  Protected Sub F_PerkID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_PerkID.SelectedIndexChanged
    Session("F_PerkID") = F_PerkID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_CategoryID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CategoryID.SelectedIndexChanged
    Session("F_CategoryID") = F_CategoryID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_PerkID.SelectedValue = String.Empty
    If Not Session("F_PerkID") Is Nothing Then
      If Session("F_PerkID") <> String.Empty Then
        F_PerkID.SelectedValue = Session("F_PerkID")
      End If
    End If
    F_CategoryID.SelectedValue = String.Empty
    If Not Session("F_CategoryID") Is Nothing Then
      If Session("F_CategoryID") <> String.Empty Then
        F_CategoryID.SelectedValue = Session("F_CategoryID")
      End If
    End If
  End Sub
End Class
