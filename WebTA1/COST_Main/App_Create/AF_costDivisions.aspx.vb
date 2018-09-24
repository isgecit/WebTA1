Partial Class AF_costDivisions
  Inherits SIS.SYS.InsertBase
  Protected Sub FVcostDivisions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostDivisions.Init
    DataClassName = "AcostDivisions"
    SetFormView = FVcostDivisions
  End Sub
  Protected Sub TBLcostDivisions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostDivisions.Init
    SetToolBar = TBLcostDivisions
  End Sub
  Protected Sub FVcostDivisions_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostDivisions.DataBound
    SIS.COST.costDivisions.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVcostDivisions_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostDivisions.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Create") & "/AF_costDivisions.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostDivisions") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostDivisions", mStr)
    End If
    If Request.QueryString("DivisionID") IsNot Nothing Then
      CType(FVcostDivisions.FindControl("F_DivisionID"), TextBox).Text = Request.QueryString("DivisionID")
      CType(FVcostDivisions.FindControl("F_DivisionID"), TextBox).Enabled = False
    End If
  End Sub

End Class
