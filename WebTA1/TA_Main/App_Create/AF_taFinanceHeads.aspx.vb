Partial Class AF_taFinanceHeads
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaFinanceHeads_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaFinanceHeads.Init
    DataClassName = "AtaFinanceHeads"
    SetFormView = FVtaFinanceHeads
  End Sub
  Protected Sub TBLtaFinanceHeads_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaFinanceHeads.Init
    SetToolBar = TBLtaFinanceHeads
  End Sub
  Protected Sub FVtaFinanceHeads_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaFinanceHeads.DataBound
    SIS.TA.taFinanceHeads.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaFinanceHeads_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaFinanceHeads.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taFinanceHeads.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaFinanceHeads") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaFinanceHeads", mStr)
    End If
    If Request.QueryString("FinanceHeadID") IsNot Nothing Then
      CType(FVtaFinanceHeads.FindControl("F_FinanceHeadID"), TextBox).Text = Request.QueryString("FinanceHeadID")
      CType(FVtaFinanceHeads.FindControl("F_FinanceHeadID"), TextBox).Enabled = False
    End If
  End Sub

End Class
