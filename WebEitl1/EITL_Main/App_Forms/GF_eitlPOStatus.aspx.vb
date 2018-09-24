Partial Class GF_eitlPOStatus
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/EITL_Main/App_Display/DF_eitlPOStatus.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?StatusID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVeitlPOStatus_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVeitlPOStatus.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim StatusID As Int32 = GVeitlPOStatus.DataKeys(e.CommandArgument).Values("StatusID")  
				Dim RedirectUrl As String = TBLeitlPOStatus.EditUrl & "?StatusID=" & StatusID
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVeitlPOStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVeitlPOStatus.Init
    DataClassName = "GeitlPOStatus"
    SetGridView = GVeitlPOStatus
  End Sub
  Protected Sub TBLeitlPOStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlPOStatus.Init
    SetToolBar = TBLeitlPOStatus
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
