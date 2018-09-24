Partial Class EF_eitlSuppliers
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVeitlSuppliers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlSuppliers.Init
    DataClassName = "EeitlSuppliers"
    SetFormView = FVeitlSuppliers
  End Sub
  Protected Sub TBLeitlSuppliers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlSuppliers.Init
    SetToolBar = TBLeitlSuppliers
  End Sub
  Protected Sub FVeitlSuppliers_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlSuppliers.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/EITL_Main/App_Edit") & "/EF_eitlSuppliers.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripteitlSuppliers") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripteitlSuppliers", mStr)
    End If
  End Sub

End Class
