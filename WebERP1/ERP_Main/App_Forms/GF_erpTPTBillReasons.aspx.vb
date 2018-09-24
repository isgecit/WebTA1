Partial Class GF_erpTPTBillReasons
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ERP_Main/App_Display/DF_erpTPTBillReasons.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ReasonID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVerpTPTBillReasons_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVerpTPTBillReasons.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim ReasonID As Int32 = GVerpTPTBillReasons.DataKeys(e.CommandArgument).Values("ReasonID")  
				Dim RedirectUrl As String = TBLerpTPTBillReasons.EditUrl & "?ReasonID=" & ReasonID
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVerpTPTBillReasons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVerpTPTBillReasons.Init
    DataClassName = "GerpTPTBillReasons"
    SetGridView = GVerpTPTBillReasons
  End Sub
  Protected Sub TBLerpTPTBillReasons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpTPTBillReasons.Init
    SetToolBar = TBLerpTPTBillReasons
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
