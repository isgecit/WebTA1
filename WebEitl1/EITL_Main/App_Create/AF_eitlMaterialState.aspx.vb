Partial Class AF_eitlMaterialState
  Inherits SIS.SYS.InsertBase
  Protected Sub FVeitlMaterialState_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlMaterialState.Init
    DataClassName = "AeitlMaterialState"
    SetFormView = FVeitlMaterialState
  End Sub
  Protected Sub TBLeitlMaterialState_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlMaterialState.Init
    SetToolBar = TBLeitlMaterialState
  End Sub
  Protected Sub FVeitlMaterialState_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlMaterialState.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/EITL_Main/App_Create") & "/AF_eitlMaterialState.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripteitlMaterialState") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripteitlMaterialState", mStr)
    End If
    If Request.QueryString("StateID") IsNot Nothing Then
      CType(FVeitlMaterialState.FindControl("F_StateID"), TextBox).Text = Request.QueryString("StateID")
      CType(FVeitlMaterialState.FindControl("F_StateID"), TextBox).Enabled = False
    End If
  End Sub

End Class
