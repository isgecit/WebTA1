Partial Class GF_taBillGST
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TA_Main/App_Display/DF_taBillGST.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?TABillNo=" & aVal(0) & "&SerialNo=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtaBillGST_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaBillGST.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaBillGST.DataKeys(e.CommandArgument).Values("TABillNo")  
        Dim SerialNo As Int32 = GVtaBillGST.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLtaBillGST.EditUrl & "?TABillNo=" & TABillNo & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtaBillGST_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaBillGST.Init
    DataClassName = "GtaBillGST"
    SetGridView = GVtaBillGST
  End Sub
  Protected Sub TBLtaBillGST_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaBillGST.Init
    SetToolBar = TBLtaBillGST
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
