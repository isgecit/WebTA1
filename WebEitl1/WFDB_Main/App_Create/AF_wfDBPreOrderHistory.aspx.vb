Partial Class AF_wfDBPreOrderHistory
  Inherits SIS.SYS.InsertBase
  Protected Sub FVwfDBPreOrderHistory_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVwfDBPreOrderHistory.Init
    DataClassName = "AwfDBPreOrderHistory"
    SetFormView = FVwfDBPreOrderHistory
  End Sub
  Protected Sub TBLwfDBPreOrderHistory_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLwfDBPreOrderHistory.Init
    SetToolBar = TBLwfDBPreOrderHistory
  End Sub
  Protected Sub ODSwfDBPreOrderHistory_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSwfDBPreOrderHistory.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.WFDB.wfDBPreOrderHistory = CType(e.ReturnValue,SIS.WFDB.wfDBPreOrderHistory)
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&WFID=" & oDC.WFID
      TBLwfDBPreOrderHistory.AfterInsertURL &= tmpURL 
    End If
  End Sub
  Protected Sub FVwfDBPreOrderHistory_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVwfDBPreOrderHistory.DataBound
    SIS.WFDB.wfDBPreOrderHistory.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVwfDBPreOrderHistory_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVwfDBPreOrderHistory.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/WFDB_Main/App_Create") & "/AF_wfDBPreOrderHistory.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptwfDBPreOrderHistory") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptwfDBPreOrderHistory", mStr)
    End If
    If Request.QueryString("WFID") IsNot Nothing Then
      CType(FVwfDBPreOrderHistory.FindControl("F_WFID"), TextBox).Text = Request.QueryString("WFID")
      CType(FVwfDBPreOrderHistory.FindControl("F_WFID"), TextBox).Enabled = False
    End If
  End Sub

End Class
