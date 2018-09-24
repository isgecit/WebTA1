Partial Class AF_costWorkOrderTypes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVcostWorkOrderTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostWorkOrderTypes.Init
    DataClassName = "AcostWorkOrderTypes"
    SetFormView = FVcostWorkOrderTypes
  End Sub
  Protected Sub TBLcostWorkOrderTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostWorkOrderTypes.Init
    SetToolBar = TBLcostWorkOrderTypes
  End Sub
  Protected Sub FVcostWorkOrderTypes_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostWorkOrderTypes.DataBound
    SIS.COST.costWorkOrderTypes.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVcostWorkOrderTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostWorkOrderTypes.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Create") & "/AF_costWorkOrderTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostWorkOrderTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostWorkOrderTypes", mStr)
    End If
    If Request.QueryString("WorkOrderTypeID") IsNot Nothing Then
      CType(FVcostWorkOrderTypes.FindControl("F_WorkOrderTypeID"), TextBox).Text = Request.QueryString("WorkOrderTypeID")
      CType(FVcostWorkOrderTypes.FindControl("F_WorkOrderTypeID"), TextBox).Enabled = False
    End If
  End Sub

End Class
