Partial Class EF_erpRequestAttachments
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVerpRequestAttachments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpRequestAttachments.Init
    DataClassName = "EerpRequestAttachments"
    SetFormView = FVerpRequestAttachments
  End Sub
  Protected Sub TBLerpRequestAttachments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpRequestAttachments.Init
    SetToolBar = TBLerpRequestAttachments
  End Sub
  Protected Sub FVerpRequestAttachments_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpRequestAttachments.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ERP_Main/App_Edit") & "/EF_erpRequestAttachments.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripterpRequestAttachments") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripterpRequestAttachments", mStr)
    End If
  End Sub

End Class
