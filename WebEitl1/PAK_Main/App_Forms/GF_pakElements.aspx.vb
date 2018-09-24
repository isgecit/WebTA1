Partial Class GF_pakElements
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PAK_Main/App_Display/DF_pakElements.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ElementID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpakElements_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakElements.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ElementID As String = GVpakElements.DataKeys(e.CommandArgument).Values("ElementID")  
        Dim RedirectUrl As String = TBLpakElements.EditUrl & "?ElementID=" & ElementID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVpakElements_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakElements.Init
    DataClassName = "GpakElements"
    SetGridView = GVpakElements
  End Sub
  Protected Sub TBLpakElements_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakElements.Init
    SetToolBar = TBLpakElements
  End Sub
  Protected Sub F_ElementID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ElementID.TextChanged
    Session("F_ElementID") = F_ElementID.Text
    InitGridPage()
  End Sub
  Protected Sub F_ResponsibleAgencyID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ResponsibleAgencyID.SelectedIndexChanged
    Session("F_ResponsibleAgencyID") = F_ResponsibleAgencyID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_ResponsibleAgencyID.SelectedValue = String.Empty
    If Not Session("F_ResponsibleAgencyID") Is Nothing Then
      If Session("F_ResponsibleAgencyID") <> String.Empty Then
        F_ResponsibleAgencyID.SelectedValue = Session("F_ResponsibleAgencyID")
      End If
    End If
  End Sub
End Class
