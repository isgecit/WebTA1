Partial Class GF_costWorkOrderTypes
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/COST_Main/App_Display/DF_costWorkOrderTypes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?WorkOrderTypeID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVcostWorkOrderTypes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVcostWorkOrderTypes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim WorkOrderTypeID As Int32 = GVcostWorkOrderTypes.DataKeys(e.CommandArgument).Values("WorkOrderTypeID")  
        Dim RedirectUrl As String = TBLcostWorkOrderTypes.EditUrl & "?WorkOrderTypeID=" & WorkOrderTypeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVcostWorkOrderTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVcostWorkOrderTypes.Init
    DataClassName = "GcostWorkOrderTypes"
    SetGridView = GVcostWorkOrderTypes
  End Sub
  Protected Sub TBLcostWorkOrderTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostWorkOrderTypes.Init
    SetToolBar = TBLcostWorkOrderTypes
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
