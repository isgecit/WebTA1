Partial Class GF_eitlProjects
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/EITL_Main/App_Display/DF_eitlProjects.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ProjectID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVeitlProjects_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVeitlProjects.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim ProjectID As String = GVeitlProjects.DataKeys(e.CommandArgument).Values("ProjectID")  
				Dim RedirectUrl As String = TBLeitlProjects.EditUrl & "?ProjectID=" & ProjectID
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVeitlProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVeitlProjects.Init
    DataClassName = "GeitlProjects"
    SetGridView = GVeitlProjects
  End Sub
  Protected Sub TBLeitlProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlProjects.Init
    SetToolBar = TBLeitlProjects
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
