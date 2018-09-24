Partial Class GF_costERPGLCodes
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/COST_Main/App_Display/DF_costERPGLCodes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?GLCode=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVcostERPGLCodes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVcostERPGLCodes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim GLCode As String = GVcostERPGLCodes.DataKeys(e.CommandArgument).Values("GLCode")  
        Dim RedirectUrl As String = TBLcostERPGLCodes.EditUrl & "?GLCode=" & GLCode
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVcostERPGLCodes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVcostERPGLCodes.Init
    DataClassName = "GcostERPGLCodes"
    SetGridView = GVcostERPGLCodes
  End Sub
  Protected Sub TBLcostERPGLCodes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostERPGLCodes.Init
    SetToolBar = TBLcostERPGLCodes
  End Sub
  Protected Sub F_GLCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_GLCode.TextChanged
    Session("F_GLCode") = F_GLCode.Text
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
