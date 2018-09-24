Partial Class AF_taBillStates
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaBillStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBillStates.Init
    DataClassName = "AtaBillStates"
    SetFormView = FVtaBillStates
  End Sub
  Protected Sub TBLtaBillStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaBillStates.Init
    SetToolBar = TBLtaBillStates
  End Sub
  Protected Sub FVtaBillStates_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBillStates.DataBound
    SIS.TA.taBillStates.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaBillStates_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBillStates.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taBillStates.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaBillStates") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaBillStates", mStr)
    End If
    If Request.QueryString("BillStatusID") IsNot Nothing Then
      CType(FVtaBillStates.FindControl("F_BillStatusID"), TextBox).Text = Request.QueryString("BillStatusID")
      CType(FVtaBillStates.FindControl("F_BillStatusID"), TextBox).Enabled = False
    End If
  End Sub

End Class
