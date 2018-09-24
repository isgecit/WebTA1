Partial Class GF_eitlPOItemStatus
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/EITL_Main/App_Display/DF_eitlPOItemStatus.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?StatusID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVeitlPOItemStatus_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVeitlPOItemStatus.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim StatusID As Int32 = GVeitlPOItemStatus.DataKeys(e.CommandArgument).Values("StatusID")  
				Dim RedirectUrl As String = TBLeitlPOItemStatus.EditUrl & "?StatusID=" & StatusID
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVeitlPOItemStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVeitlPOItemStatus.Init
    DataClassName = "GeitlPOItemStatus"
    SetGridView = GVeitlPOItemStatus
  End Sub
  Protected Sub TBLeitlPOItemStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlPOItemStatus.Init
    SetToolBar = TBLeitlPOItemStatus
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
