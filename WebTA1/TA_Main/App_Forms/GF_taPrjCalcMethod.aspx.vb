Partial Class GF_taPrjCalcMethod
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TA_Main/App_Display/DF_taPrjCalcMethod.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ProjectCalcID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtaPrjCalcMethod_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaPrjCalcMethod.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ProjectCalcID As Int32 = GVtaPrjCalcMethod.DataKeys(e.CommandArgument).Values("ProjectCalcID")  
        Dim RedirectUrl As String = TBLtaPrjCalcMethod.EditUrl & "?ProjectCalcID=" & ProjectCalcID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtaPrjCalcMethod_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaPrjCalcMethod.Init
    DataClassName = "GtaPrjCalcMethod"
    SetGridView = GVtaPrjCalcMethod
  End Sub
  Protected Sub TBLtaPrjCalcMethod_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaPrjCalcMethod.Init
    SetToolBar = TBLtaPrjCalcMethod
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
