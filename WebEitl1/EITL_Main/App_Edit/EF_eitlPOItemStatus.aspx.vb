Partial Class EF_eitlPOItemStatus
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVeitlPOItemStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlPOItemStatus.Init
    DataClassName = "EeitlPOItemStatus"
    SetFormView = FVeitlPOItemStatus
  End Sub
  Protected Sub TBLeitlPOItemStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlPOItemStatus.Init
    SetToolBar = TBLeitlPOItemStatus
  End Sub
  Protected Sub FVeitlPOItemStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlPOItemStatus.PreRender
		TBLeitlPOItemStatus.PrintUrl &= Request.QueryString("StatusID") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/EITL_Main/App_Edit") & "/EF_eitlPOItemStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripteitlPOItemStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripteitlPOItemStatus", mStr)
    End If
  End Sub

End Class
