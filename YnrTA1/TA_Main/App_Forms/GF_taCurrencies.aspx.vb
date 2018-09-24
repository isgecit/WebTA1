Partial Class GF_taCurrencies
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TA_Main/App_Display/DF_taCurrencies.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?CurrencyID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtaCurrencies_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaCurrencies.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim CurrencyID As String = GVtaCurrencies.DataKeys(e.CommandArgument).Values("CurrencyID")  
        Dim RedirectUrl As String = TBLtaCurrencies.EditUrl & "?CurrencyID=" & CurrencyID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtaCurrencies_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaCurrencies.Init
    DataClassName = "GtaCurrencies"
    SetGridView = GVtaCurrencies
  End Sub
  Protected Sub TBLtaCurrencies_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaCurrencies.Init
    SetToolBar = TBLtaCurrencies
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
