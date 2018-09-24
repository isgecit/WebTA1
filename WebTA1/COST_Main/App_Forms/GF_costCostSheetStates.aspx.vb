Partial Class GF_costCostSheetStates
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/COST_Main/App_Display/DF_costCostSheetStates.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?StatusID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVcostCostSheetStates_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVcostCostSheetStates.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim StatusID As Int32 = GVcostCostSheetStates.DataKeys(e.CommandArgument).Values("StatusID")  
        Dim RedirectUrl As String = TBLcostCostSheetStates.EditUrl & "?StatusID=" & StatusID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVcostCostSheetStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVcostCostSheetStates.Init
    DataClassName = "GcostCostSheetStates"
    SetGridView = GVcostCostSheetStates
  End Sub
  Protected Sub TBLcostCostSheetStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostCostSheetStates.Init
    SetToolBar = TBLcostCostSheetStates
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
