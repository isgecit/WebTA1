Partial Class AF_eitlPOItemStatus
  Inherits SIS.SYS.InsertBase
  Protected Sub FVeitlPOItemStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlPOItemStatus.Init
    DataClassName = "AeitlPOItemStatus"
    SetFormView = FVeitlPOItemStatus
  End Sub
  Protected Sub TBLeitlPOItemStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlPOItemStatus.Init
    SetToolBar = TBLeitlPOItemStatus
  End Sub
  Protected Sub FVeitlPOItemStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlPOItemStatus.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/EITL_Main/App_Create") & "/AF_eitlPOItemStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripteitlPOItemStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripteitlPOItemStatus", mStr)
    End If
    If Request.QueryString("StatusID") IsNot Nothing Then
      CType(FVeitlPOItemStatus.FindControl("F_StatusID"), TextBox).Text = Request.QueryString("StatusID")
      CType(FVeitlPOItemStatus.FindControl("F_StatusID"), TextBox).Enabled = False
    End If
  End Sub

End Class
