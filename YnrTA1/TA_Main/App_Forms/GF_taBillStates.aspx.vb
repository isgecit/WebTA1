Partial Class GF_taBillStates
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TA_Main/App_Display/DF_taBillStates.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?BillStatusID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtaBillStates_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaBillStates.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim BillStatusID As Int32 = GVtaBillStates.DataKeys(e.CommandArgument).Values("BillStatusID")  
        Dim RedirectUrl As String = TBLtaBillStates.EditUrl & "?BillStatusID=" & BillStatusID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtaBillStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaBillStates.Init
    DataClassName = "GtaBillStates"
    SetGridView = GVtaBillStates
  End Sub
  Protected Sub TBLtaBillStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaBillStates.Init
    SetToolBar = TBLtaBillStates
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
