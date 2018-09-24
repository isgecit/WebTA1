Partial Class GF_nprkFinYears
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/NPRK_Main/App_Display/DF_nprkFinYears.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?FinYear=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVnprkFinYears_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVnprkFinYears.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim FinYear As Int32 = GVnprkFinYears.DataKeys(e.CommandArgument).Values("FinYear")  
        Dim RedirectUrl As String = TBLnprkFinYears.EditUrl & "?FinYear=" & FinYear
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVnprkFinYears_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVnprkFinYears.Init
    DataClassName = "GnprkFinYears"
    SetGridView = GVnprkFinYears
  End Sub
  Protected Sub TBLnprkFinYears_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkFinYears.Init
    SetToolBar = TBLnprkFinYears
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
