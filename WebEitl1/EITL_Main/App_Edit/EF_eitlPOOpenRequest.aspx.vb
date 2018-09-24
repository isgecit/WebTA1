Partial Class EF_eitlPOOpenRequest
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVeitlPOOpenRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlPOOpenRequest.Init
    DataClassName = "EeitlPOOpenRequest"
    SetFormView = FVeitlPOOpenRequest
  End Sub
  Protected Sub TBLeitlPOOpenRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlPOOpenRequest.Init
    SetToolBar = TBLeitlPOOpenRequest
  End Sub
  Protected Sub FVeitlPOOpenRequest_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlPOOpenRequest.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/EITL_Main/App_Edit") & "/EF_eitlPOOpenRequest.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripteitlPOOpenRequest") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripteitlPOOpenRequest", mStr)
    End If
  End Sub

End Class
