Partial Class GF_erpTPTBillStatus
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ERP_Main/App_Display/DF_erpTPTBillStatus.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?BillStatusID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVerpTPTBillStatus_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVerpTPTBillStatus.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim BillStatusID As Int32 = GVerpTPTBillStatus.DataKeys(e.CommandArgument).Values("BillStatusID")  
				Dim RedirectUrl As String = TBLerpTPTBillStatus.EditUrl & "?BillStatusID=" & BillStatusID
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVerpTPTBillStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVerpTPTBillStatus.Init
    DataClassName = "GerpTPTBillStatus"
    SetGridView = GVerpTPTBillStatus
  End Sub
  Protected Sub TBLerpTPTBillStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpTPTBillStatus.Init
    SetToolBar = TBLerpTPTBillStatus
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
