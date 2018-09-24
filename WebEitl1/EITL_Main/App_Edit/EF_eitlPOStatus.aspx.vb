Partial Class EF_eitlPOStatus
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVeitlPOStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlPOStatus.Init
    DataClassName = "EeitlPOStatus"
    SetFormView = FVeitlPOStatus
  End Sub
  Protected Sub TBLeitlPOStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlPOStatus.Init
    SetToolBar = TBLeitlPOStatus
  End Sub
  Protected Sub FVeitlPOStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlPOStatus.PreRender
		TBLeitlPOStatus.PrintUrl &= Request.QueryString("StatusID") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/EITL_Main/App_Edit") & "/EF_eitlPOStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripteitlPOStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripteitlPOStatus", mStr)
    End If
  End Sub

End Class
