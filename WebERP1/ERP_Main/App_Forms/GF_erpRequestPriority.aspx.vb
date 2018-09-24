Partial Class GF_erpRequestPriority
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ERP_Main/App_Display/DF_erpRequestPriority.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?PriorityID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVerpRequestPriority_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVerpRequestPriority.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim PriorityID As Int32 = GVerpRequestPriority.DataKeys(e.CommandArgument).Values("PriorityID")  
				Dim RedirectUrl As String = TBLerpRequestPriority.EditUrl & "?PriorityID=" & PriorityID
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVerpRequestPriority_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVerpRequestPriority.Init
    DataClassName = "GerpRequestPriority"
    SetGridView = GVerpRequestPriority
  End Sub
  Protected Sub TBLerpRequestPriority_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpRequestPriority.Init
    SetToolBar = TBLerpRequestPriority
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
