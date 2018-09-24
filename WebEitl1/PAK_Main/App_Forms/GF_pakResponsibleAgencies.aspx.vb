Partial Class GF_pakResponsibleAgencies
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PAK_Main/App_Display/DF_pakResponsibleAgencies.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ResponsibleAgencyID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpakResponsibleAgencies_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakResponsibleAgencies.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ResponsibleAgencyID As Int32 = GVpakResponsibleAgencies.DataKeys(e.CommandArgument).Values("ResponsibleAgencyID")  
        Dim RedirectUrl As String = TBLpakResponsibleAgencies.EditUrl & "?ResponsibleAgencyID=" & ResponsibleAgencyID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVpakResponsibleAgencies_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakResponsibleAgencies.Init
    DataClassName = "GpakResponsibleAgencies"
    SetGridView = GVpakResponsibleAgencies
  End Sub
  Protected Sub TBLpakResponsibleAgencies_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakResponsibleAgencies.Init
    SetToolBar = TBLpakResponsibleAgencies
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
