Partial Class GF_psfSupplier
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PSF_Main/App_Display/DF_psfSupplier.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SupplierID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpsfSupplier_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpsfSupplier.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SupplierID As String = GVpsfSupplier.DataKeys(e.CommandArgument).Values("SupplierID")  
        Dim RedirectUrl As String = TBLpsfSupplier.EditUrl & "?SupplierID=" & SupplierID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVpsfSupplier_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpsfSupplier.Init
    DataClassName = "GpsfSupplier"
    SetGridView = GVpsfSupplier
  End Sub
  Protected Sub TBLpsfSupplier_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpsfSupplier.Init
    SetToolBar = TBLpsfSupplier
  End Sub
  Protected Sub F_SupplierID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_SupplierID.TextChanged
    Session("F_SupplierID") = F_SupplierID.Text
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
