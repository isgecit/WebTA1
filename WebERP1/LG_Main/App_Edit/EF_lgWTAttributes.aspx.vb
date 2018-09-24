Partial Class EF_lgWTAttributes
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVlgWTAttributes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVlgWTAttributes.Init
    DataClassName = "ElgWTAttributes"
    SetFormView = FVlgWTAttributes
  End Sub
  Protected Sub TBLlgWTAttributes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLlgWTAttributes.Init
    SetToolBar = TBLlgWTAttributes
  End Sub
  Protected Sub FVlgWTAttributes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVlgWTAttributes.PreRender
		TBLlgWTAttributes.PrintUrl &= Request.QueryString("DocPK") & "|"
		TBLlgWTAttributes.PrintUrl &= Request.QueryString("displayName") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/LG_Main/App_Edit") & "/EF_lgWTAttributes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptlgWTAttributes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptlgWTAttributes", mStr)
    End If
  End Sub

End Class
