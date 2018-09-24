Partial Class GF_elogLocationCountries
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ELOG_Main/App_Display/DF_elogLocationCountries.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?LocationCountryID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVelogLocationCountries_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVelogLocationCountries.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim LocationCountryID As Int32 = GVelogLocationCountries.DataKeys(e.CommandArgument).Values("LocationCountryID")  
        Dim RedirectUrl As String = TBLelogLocationCountries.EditUrl & "?LocationCountryID=" & LocationCountryID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVelogLocationCountries_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVelogLocationCountries.Init
    DataClassName = "GelogLocationCountries"
    SetGridView = GVelogLocationCountries
  End Sub
  Protected Sub TBLelogLocationCountries_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogLocationCountries.Init
    SetToolBar = TBLelogLocationCountries
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
