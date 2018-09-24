Partial Class EF_eitlMaterialState
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVeitlMaterialState_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlMaterialState.Init
    DataClassName = "EeitlMaterialState"
    SetFormView = FVeitlMaterialState
  End Sub
  Protected Sub TBLeitlMaterialState_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlMaterialState.Init
    SetToolBar = TBLeitlMaterialState
  End Sub
  Protected Sub FVeitlMaterialState_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlMaterialState.PreRender
		TBLeitlMaterialState.PrintUrl &= Request.QueryString("StateID") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/EITL_Main/App_Edit") & "/EF_eitlMaterialState.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripteitlMaterialState") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripteitlMaterialState", mStr)
    End If
  End Sub

End Class
