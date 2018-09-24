Partial Class GF_taCountries
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TA_Main/App_Display/DF_taCountries.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?CountryID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtaCountries_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaCountries.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim CountryID As String = GVtaCountries.DataKeys(e.CommandArgument).Values("CountryID")  
        Dim RedirectUrl As String = TBLtaCountries.EditUrl & "?CountryID=" & CountryID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtaCountries_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaCountries.Init
    DataClassName = "GtaCountries"
    SetGridView = GVtaCountries
  End Sub
  Protected Sub TBLtaCountries_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaCountries.Init
    SetToolBar = TBLtaCountries
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
