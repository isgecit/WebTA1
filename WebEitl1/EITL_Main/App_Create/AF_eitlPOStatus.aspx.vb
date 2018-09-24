Partial Class AF_eitlPOStatus
  Inherits SIS.SYS.InsertBase
  Protected Sub FVeitlPOStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlPOStatus.Init
    DataClassName = "AeitlPOStatus"
    SetFormView = FVeitlPOStatus
  End Sub
  Protected Sub TBLeitlPOStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlPOStatus.Init
    SetToolBar = TBLeitlPOStatus
  End Sub
  Protected Sub FVeitlPOStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlPOStatus.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/EITL_Main/App_Create") & "/AF_eitlPOStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripteitlPOStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripteitlPOStatus", mStr)
    End If
    If Request.QueryString("StatusID") IsNot Nothing Then
      CType(FVeitlPOStatus.FindControl("F_StatusID"), TextBox).Text = Request.QueryString("StatusID")
      CType(FVeitlPOStatus.FindControl("F_StatusID"), TextBox).Enabled = False
    End If
  End Sub

End Class
