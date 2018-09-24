Partial Class GF_nprkCategories
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/NPRK_Main/App_Display/DF_nprkCategories.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?CategoryID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVnprkCategories_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVnprkCategories.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim CategoryID As Int32 = GVnprkCategories.DataKeys(e.CommandArgument).Values("CategoryID")  
        Dim RedirectUrl As String = TBLnprkCategories.EditUrl & "?CategoryID=" & CategoryID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVnprkCategories_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVnprkCategories.Init
    DataClassName = "GnprkCategories"
    SetGridView = GVnprkCategories
  End Sub
  Protected Sub TBLnprkCategories_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkCategories.Init
    SetToolBar = TBLnprkCategories
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
