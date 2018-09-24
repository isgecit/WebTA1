Partial Class EF_eitlMyOpenRequest
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVeitlMyOpenRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlMyOpenRequest.Init
    DataClassName = "EeitlMyOpenRequest"
    SetFormView = FVeitlMyOpenRequest
  End Sub
  Protected Sub TBLeitlMyOpenRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlMyOpenRequest.Init
    SetToolBar = TBLeitlMyOpenRequest
  End Sub
  Protected Sub FVeitlMyOpenRequest_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlMyOpenRequest.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/EITL_Main/App_Edit") & "/EF_eitlMyOpenRequest.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripteitlMyOpenRequest") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripteitlMyOpenRequest", mStr)
    End If
  End Sub

End Class
