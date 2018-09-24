Partial Class GF_eitlMaterialState
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/EITL_Main/App_Display/DF_eitlMaterialState.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?StateID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVeitlMaterialState_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVeitlMaterialState.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim StateID As Int32 = GVeitlMaterialState.DataKeys(e.CommandArgument).Values("StateID")  
				Dim RedirectUrl As String = TBLeitlMaterialState.EditUrl & "?StateID=" & StateID
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVeitlMaterialState_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVeitlMaterialState.Init
    DataClassName = "GeitlMaterialState"
    SetGridView = GVeitlMaterialState
  End Sub
  Protected Sub TBLeitlMaterialState_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlMaterialState.Init
    SetToolBar = TBLeitlMaterialState
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
