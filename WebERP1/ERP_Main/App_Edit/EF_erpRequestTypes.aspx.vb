Partial Class EF_erpRequestTypes
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVerpRequestTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpRequestTypes.Init
    DataClassName = "EerpRequestTypes"
    SetFormView = FVerpRequestTypes
  End Sub
  Protected Sub TBLerpRequestTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpRequestTypes.Init
    SetToolBar = TBLerpRequestTypes
  End Sub
  Protected Sub FVerpRequestTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpRequestTypes.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ERP_Main/App_Edit") & "/EF_erpRequestTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripterpRequestTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripterpRequestTypes", mStr)
    End If
  End Sub

End Class
