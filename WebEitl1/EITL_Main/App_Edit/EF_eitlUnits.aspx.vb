Partial Class EF_eitlUnits
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVeitlUnits_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlUnits.Init
    DataClassName = "EeitlUnits"
    SetFormView = FVeitlUnits
  End Sub
  Protected Sub TBLeitlUnits_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlUnits.Init
    SetToolBar = TBLeitlUnits
  End Sub
  Protected Sub FVeitlUnits_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlUnits.PreRender
		TBLeitlUnits.PrintUrl &= Request.QueryString("UnitID") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/EITL_Main/App_Edit") & "/EF_eitlUnits.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripteitlUnits") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripteitlUnits", mStr)
    End If
  End Sub

End Class
