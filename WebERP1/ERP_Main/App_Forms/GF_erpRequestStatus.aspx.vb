Partial Class GF_erpRequestStatus
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ERP_Main/App_Display/DF_erpRequestStatus.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?StatusID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVerpRequestStatus_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVerpRequestStatus.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim StatusID As Int32 = GVerpRequestStatus.DataKeys(e.CommandArgument).Values("StatusID")  
				Dim RedirectUrl As String = TBLerpRequestStatus.EditUrl & "?StatusID=" & StatusID
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVerpRequestStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVerpRequestStatus.Init
    DataClassName = "GerpRequestStatus"
    SetGridView = GVerpRequestStatus
  End Sub
  Protected Sub TBLerpRequestStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpRequestStatus.Init
    SetToolBar = TBLerpRequestStatus
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
