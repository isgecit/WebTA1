Partial Class AF_nprkMobileBillPlans
  Inherits SIS.SYS.InsertBase
  Protected Sub FVnprkMobileBillPlans_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkMobileBillPlans.Init
    DataClassName = "AnprkMobileBillPlans"
    SetFormView = FVnprkMobileBillPlans
  End Sub
  Protected Sub TBLnprkMobileBillPlans_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkMobileBillPlans.Init
    SetToolBar = TBLnprkMobileBillPlans
  End Sub
  Protected Sub FVnprkMobileBillPlans_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkMobileBillPlans.DataBound
    SIS.NPRK.nprkMobileBillPlans.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVnprkMobileBillPlans_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkMobileBillPlans.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Create") & "/AF_nprkMobileBillPlans.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkMobileBillPlans") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkMobileBillPlans", mStr)
    End If
    If Request.QueryString("MobileBillPlanID") IsNot Nothing Then
      CType(FVnprkMobileBillPlans.FindControl("F_MobileBillPlanID"), TextBox).Text = Request.QueryString("MobileBillPlanID")
      CType(FVnprkMobileBillPlans.FindControl("F_MobileBillPlanID"), TextBox).Enabled = False
    End If
  End Sub

End Class
