Partial Class AF_taExpenseHeads
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaExpenseHeads_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaExpenseHeads.Init
    DataClassName = "AtaExpenseHeads"
    SetFormView = FVtaExpenseHeads
  End Sub
  Protected Sub TBLtaExpenseHeads_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaExpenseHeads.Init
    SetToolBar = TBLtaExpenseHeads
  End Sub
  Protected Sub FVtaExpenseHeads_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaExpenseHeads.DataBound
    SIS.TA.taExpenseHeads.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaExpenseHeads_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaExpenseHeads.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taExpenseHeads.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaExpenseHeads") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaExpenseHeads", mStr)
    End If
    If Request.QueryString("ExpenseHeadID") IsNot Nothing Then
      CType(FVtaExpenseHeads.FindControl("F_ExpenseHeadID"), TextBox).Text = Request.QueryString("ExpenseHeadID")
      CType(FVtaExpenseHeads.FindControl("F_ExpenseHeadID"), TextBox).Enabled = False
    End If
  End Sub

End Class
