Partial Class GF_erpRequestTypes
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ERP_Main/App_Display/DF_erpRequestTypes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?RequestTypeID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVerpRequestTypes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVerpRequestTypes.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim RequestTypeID As Int32 = GVerpRequestTypes.DataKeys(e.CommandArgument).Values("RequestTypeID")  
				Dim RedirectUrl As String = TBLerpRequestTypes.EditUrl & "?RequestTypeID=" & RequestTypeID
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVerpRequestTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVerpRequestTypes.Init
    DataClassName = "GerpRequestTypes"
    SetGridView = GVerpRequestTypes
  End Sub
  Protected Sub TBLerpRequestTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpRequestTypes.Init
    SetToolBar = TBLerpRequestTypes
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
