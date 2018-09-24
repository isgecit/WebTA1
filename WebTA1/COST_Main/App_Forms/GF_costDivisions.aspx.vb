Partial Class GF_costDivisions
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/COST_Main/App_Display/DF_costDivisions.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?DivisionID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVcostDivisions_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVcostDivisions.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim DivisionID As Int32 = GVcostDivisions.DataKeys(e.CommandArgument).Values("DivisionID")  
        Dim RedirectUrl As String = TBLcostDivisions.EditUrl & "?DivisionID=" & DivisionID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVcostDivisions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVcostDivisions.Init
    DataClassName = "GcostDivisions"
    SetGridView = GVcostDivisions
  End Sub
  Protected Sub TBLcostDivisions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostDivisions.Init
    SetToolBar = TBLcostDivisions
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
