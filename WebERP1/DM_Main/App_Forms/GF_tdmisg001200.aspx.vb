Partial Class GF_tdmisg001200
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/DM_Main/App_Display/DF_tdmisg001200.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?t_docn=" & aVal(0) & "&t_revn=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtdmisg001200_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtdmisg001200.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim t_docn As String = GVtdmisg001200.DataKeys(e.CommandArgument).Values("t_docn")  
				Dim t_revn As String = GVtdmisg001200.DataKeys(e.CommandArgument).Values("t_revn")  
				Dim RedirectUrl As String = TBLtdmisg001200.EditUrl & "?t_docn=" & t_docn & "&t_revn=" & t_revn
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVtdmisg001200_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtdmisg001200.Init
    DataClassName = "Gtdmisg001200"
    SetGridView = GVtdmisg001200
  End Sub
  Protected Sub TBLtdmisg001200_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtdmisg001200.Init
    SetToolBar = TBLtdmisg001200
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
