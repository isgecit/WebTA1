Partial Class GF_taFinanceHeads
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TA_Main/App_Display/DF_taFinanceHeads.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?FinanceHeadID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtaFinanceHeads_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaFinanceHeads.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim FinanceHeadID As Int32 = GVtaFinanceHeads.DataKeys(e.CommandArgument).Values("FinanceHeadID")  
        Dim RedirectUrl As String = TBLtaFinanceHeads.EditUrl & "?FinanceHeadID=" & FinanceHeadID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtaFinanceHeads_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaFinanceHeads.Init
    DataClassName = "GtaFinanceHeads"
    SetGridView = GVtaFinanceHeads
  End Sub
  Protected Sub TBLtaFinanceHeads_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaFinanceHeads.Init
    SetToolBar = TBLtaFinanceHeads
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
