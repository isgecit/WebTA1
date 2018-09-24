Partial Class GF_erpApplications
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ERP_Main/App_Display/DF_erpApplications.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ApplID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVerpApplications_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVerpApplications.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim ApplID As Int32 = GVerpApplications.DataKeys(e.CommandArgument).Values("ApplID")  
				Dim RedirectUrl As String = TBLerpApplications.EditUrl & "?ApplID=" & ApplID
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVerpApplications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVerpApplications.Init
    DataClassName = "GerpApplications"
    SetGridView = GVerpApplications
  End Sub
  Protected Sub TBLerpApplications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpApplications.Init
    SetToolBar = TBLerpApplications
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
