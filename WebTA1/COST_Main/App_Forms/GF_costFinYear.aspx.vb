Partial Class GF_costFinYear
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/COST_Main/App_Display/DF_costFinYear.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?FinYear=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVcostFinYear_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVcostFinYear.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim FinYear As Int32 = GVcostFinYear.DataKeys(e.CommandArgument).Values("FinYear")  
        Dim RedirectUrl As String = TBLcostFinYear.EditUrl & "?FinYear=" & FinYear
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVcostFinYear_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVcostFinYear.Init
    DataClassName = "GcostFinYear"
    SetGridView = GVcostFinYear
  End Sub
  Protected Sub TBLcostFinYear_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostFinYear.Init
    SetToolBar = TBLcostFinYear
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
