Partial Class GF_erpRoles
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ERP_Main/App_Display/DF_erpRoles.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?RoleID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVerpRoles_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVerpRoles.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim RoleID As Int32 = GVerpRoles.DataKeys(e.CommandArgument).Values("RoleID")  
				Dim RedirectUrl As String = TBLerpRoles.EditUrl & "?RoleID=" & RoleID
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVerpRoles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVerpRoles.Init
    DataClassName = "GerpRoles"
    SetGridView = GVerpRoles
  End Sub
  Protected Sub TBLerpRoles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpRoles.Init
    SetToolBar = TBLerpRoles
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
