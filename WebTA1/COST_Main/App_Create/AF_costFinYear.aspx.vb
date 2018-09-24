Partial Class AF_costFinYear
  Inherits SIS.SYS.InsertBase
  Protected Sub FVcostFinYear_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostFinYear.Init
    DataClassName = "AcostFinYear"
    SetFormView = FVcostFinYear
  End Sub
  Protected Sub TBLcostFinYear_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostFinYear.Init
    SetToolBar = TBLcostFinYear
  End Sub
  Protected Sub FVcostFinYear_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostFinYear.DataBound
    SIS.COST.costFinYear.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVcostFinYear_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostFinYear.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Create") & "/AF_costFinYear.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostFinYear") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostFinYear", mStr)
    End If
    If Request.QueryString("FinYear") IsNot Nothing Then
      CType(FVcostFinYear.FindControl("F_FinYear"), TextBox).Text = Request.QueryString("FinYear")
      CType(FVcostFinYear.FindControl("F_FinYear"), TextBox).Enabled = False
    End If
  End Sub

End Class
