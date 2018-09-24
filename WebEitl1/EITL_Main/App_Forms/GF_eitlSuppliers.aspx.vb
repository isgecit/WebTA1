Partial Class GF_eitlSuppliers
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/EITL_Main/App_Display/DF_eitlSuppliers.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SupplierID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVeitlSuppliers_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVeitlSuppliers.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim SupplierID As String = GVeitlSuppliers.DataKeys(e.CommandArgument).Values("SupplierID")  
				Dim RedirectUrl As String = TBLeitlSuppliers.EditUrl & "?SupplierID=" & SupplierID
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVeitlSuppliers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVeitlSuppliers.Init
    DataClassName = "GeitlSuppliers"
    SetGridView = GVeitlSuppliers
  End Sub
  Protected Sub TBLeitlSuppliers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlSuppliers.Init
    SetToolBar = TBLeitlSuppliers
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
