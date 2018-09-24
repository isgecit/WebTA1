Partial Class AF_costQuarters
  Inherits SIS.SYS.InsertBase
  Protected Sub FVcostQuarters_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostQuarters.Init
    DataClassName = "AcostQuarters"
    SetFormView = FVcostQuarters
  End Sub
  Protected Sub TBLcostQuarters_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostQuarters.Init
    SetToolBar = TBLcostQuarters
  End Sub
  Protected Sub FVcostQuarters_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostQuarters.DataBound
    SIS.COST.costQuarters.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVcostQuarters_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostQuarters.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Create") & "/AF_costQuarters.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostQuarters") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostQuarters", mStr)
    End If
    If Request.QueryString("Quarter") IsNot Nothing Then
      CType(FVcostQuarters.FindControl("F_Quarter"), TextBox).Text = Request.QueryString("Quarter")
      CType(FVcostQuarters.FindControl("F_Quarter"), TextBox).Enabled = False
    End If
  End Sub

End Class
