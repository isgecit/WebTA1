Partial Class GF_costQuarters
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/COST_Main/App_Display/DF_costQuarters.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?Quarter=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVcostQuarters_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVcostQuarters.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim Quarter As Int32 = GVcostQuarters.DataKeys(e.CommandArgument).Values("Quarter")  
        Dim RedirectUrl As String = TBLcostQuarters.EditUrl & "?Quarter=" & Quarter
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVcostQuarters_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVcostQuarters.Init
    DataClassName = "GcostQuarters"
    SetGridView = GVcostQuarters
  End Sub
  Protected Sub TBLcostQuarters_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostQuarters.Init
    SetToolBar = TBLcostQuarters
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
