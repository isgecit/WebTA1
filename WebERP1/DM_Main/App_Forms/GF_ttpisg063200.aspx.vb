Partial Class GF_ttpisg063200
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/DM_Main/App_Display/DF_ttpisg063200.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?t_cprj=" & aVal(0) & "&t_cspa=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVttpisg063200_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVttpisg063200.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim t_cprj As String = GVttpisg063200.DataKeys(e.CommandArgument).Values("t_cprj")  
				Dim t_cspa As String = GVttpisg063200.DataKeys(e.CommandArgument).Values("t_cspa")  
				Dim RedirectUrl As String = TBLttpisg063200.EditUrl & "?t_cprj=" & t_cprj & "&t_cspa=" & t_cspa
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVttpisg063200_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVttpisg063200.Init
    DataClassName = "Gttpisg063200"
    SetGridView = GVttpisg063200
  End Sub
  Protected Sub TBLttpisg063200_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLttpisg063200.Init
    SetToolBar = TBLttpisg063200
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
