Partial Class AF_erpRequestStatus
  Inherits SIS.SYS.InsertBase
  Protected Sub FVerpRequestStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpRequestStatus.Init
    DataClassName = "AerpRequestStatus"
    SetFormView = FVerpRequestStatus
  End Sub
  Protected Sub TBLerpRequestStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpRequestStatus.Init
    SetToolBar = TBLerpRequestStatus
  End Sub
  Protected Sub FVerpRequestStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpRequestStatus.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ERP_Main/App_Create") & "/AF_erpRequestStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripterpRequestStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripterpRequestStatus", mStr)
    End If
    If Request.QueryString("StatusID") IsNot Nothing Then
      CType(FVerpRequestStatus.FindControl("F_StatusID"), TextBox).Text = Request.QueryString("StatusID")
      CType(FVerpRequestStatus.FindControl("F_StatusID"), TextBox).Enabled = False
    End If
  End Sub

End Class
