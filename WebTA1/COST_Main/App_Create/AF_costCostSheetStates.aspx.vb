Partial Class AF_costCostSheetStates
  Inherits SIS.SYS.InsertBase
  Protected Sub FVcostCostSheetStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostCostSheetStates.Init
    DataClassName = "AcostCostSheetStates"
    SetFormView = FVcostCostSheetStates
  End Sub
  Protected Sub TBLcostCostSheetStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostCostSheetStates.Init
    SetToolBar = TBLcostCostSheetStates
  End Sub
  Protected Sub FVcostCostSheetStates_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostCostSheetStates.DataBound
    SIS.COST.costCostSheetStates.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVcostCostSheetStates_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostCostSheetStates.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Create") & "/AF_costCostSheetStates.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostCostSheetStates") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostCostSheetStates", mStr)
    End If
    If Request.QueryString("StatusID") IsNot Nothing Then
      CType(FVcostCostSheetStates.FindControl("F_StatusID"), TextBox).Text = Request.QueryString("StatusID")
      CType(FVcostCostSheetStates.FindControl("F_StatusID"), TextBox).Enabled = False
    End If
  End Sub

End Class
