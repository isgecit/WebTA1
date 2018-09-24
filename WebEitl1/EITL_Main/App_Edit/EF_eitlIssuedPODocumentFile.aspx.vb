Partial Class EF_eitlIssuedPODocumentFile
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVeitlIssuedPODocumentFile_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlIssuedPODocumentFile.Init
    DataClassName = "EeitlIssuedPODocumentFile"
    SetFormView = FVeitlIssuedPODocumentFile
  End Sub
  Protected Sub TBLeitlIssuedPODocumentFile_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlIssuedPODocumentFile.Init
    SetToolBar = TBLeitlIssuedPODocumentFile
  End Sub
  Protected Sub FVeitlIssuedPODocumentFile_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlIssuedPODocumentFile.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/EITL_Main/App_Edit") & "/EF_eitlIssuedPODocumentFile.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripteitlIssuedPODocumentFile") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripteitlIssuedPODocumentFile", mStr)
    End If
  End Sub

End Class
