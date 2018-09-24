Partial Class EF_lgEPAttributes
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVlgEPAttributes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVlgEPAttributes.Init
    DataClassName = "ElgEPAttributes"
    SetFormView = FVlgEPAttributes
  End Sub
  Protected Sub TBLlgEPAttributes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLlgEPAttributes.Init
    SetToolBar = TBLlgEPAttributes
  End Sub
  Protected Sub FVlgEPAttributes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVlgEPAttributes.PreRender
		TBLlgEPAttributes.PrintUrl &= Request.QueryString("DocPK") & "|"
		TBLlgEPAttributes.PrintUrl &= Request.QueryString("displayName") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/LG_Main/App_Edit") & "/EF_lgEPAttributes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptlgEPAttributes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptlgEPAttributes", mStr)
    End If
  End Sub

End Class
