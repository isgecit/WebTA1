Partial Class GF_taExpenseHeads
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TA_Main/App_Display/DF_taExpenseHeads.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ExpenseHeadID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtaExpenseHeads_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaExpenseHeads.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ExpenseHeadID As Int32 = GVtaExpenseHeads.DataKeys(e.CommandArgument).Values("ExpenseHeadID")  
        Dim RedirectUrl As String = TBLtaExpenseHeads.EditUrl & "?ExpenseHeadID=" & ExpenseHeadID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtaExpenseHeads_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaExpenseHeads.Init
    DataClassName = "GtaExpenseHeads"
    SetGridView = GVtaExpenseHeads
  End Sub
  Protected Sub TBLtaExpenseHeads_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaExpenseHeads.Init
    SetToolBar = TBLtaExpenseHeads
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
