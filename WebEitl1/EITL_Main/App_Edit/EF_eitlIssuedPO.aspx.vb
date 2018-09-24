Partial Class EF_eitlIssuedPO
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVeitlIssuedPO_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlIssuedPO.Init
    DataClassName = "EeitlIssuedPO"
    SetFormView = FVeitlIssuedPO
  End Sub
  Protected Sub TBLeitlIssuedPO_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlIssuedPO.Init
    SetToolBar = TBLeitlIssuedPO
  End Sub
  Protected Sub FVeitlIssuedPO_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlIssuedPO.PreRender
		TBLeitlIssuedPO.PrintUrl &= Request.QueryString("SerialNo") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/EITL_Main/App_Edit") & "/EF_eitlIssuedPO.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripteitlIssuedPO") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripteitlIssuedPO", mStr)
    End If
  End Sub
  Partial Class gvBase
		Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gveitlIssuedPODocumentCC As New gvBase
  Protected Sub GVeitlIssuedPODocument_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVeitlIssuedPODocument.Init
		gveitlIssuedPODocumentCC.DataClassName = "GeitlIssuedPODocument"
		gveitlIssuedPODocumentCC.SetGridView = GVeitlIssuedPODocument
  End Sub
  Protected Sub TBLeitlIssuedPODocument_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlIssuedPODocument.Init
		gveitlIssuedPODocumentCC.SetToolBar = TBLeitlIssuedPODocument
  End Sub
  Protected Sub GVeitlIssuedPODocument_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVeitlIssuedPODocument.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim SerialNo As Int32 = GVeitlIssuedPODocument.DataKeys(e.CommandArgument).Values("SerialNo")  
				Dim DocumentLineNo As Int32 = GVeitlIssuedPODocument.DataKeys(e.CommandArgument).Values("DocumentLineNo")  
				Dim RedirectUrl As String = TBLeitlIssuedPODocument.EditUrl & "?SerialNo=" & SerialNo & "&DocumentLineNo=" & DocumentLineNo
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Private WithEvents gveitlIssuedPOItemCC As New gvBase
  Protected Sub GVeitlIssuedPOItem_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVeitlIssuedPOItem.Init
		gveitlIssuedPOItemCC.DataClassName = "GeitlIssuedPOItem"
		gveitlIssuedPOItemCC.SetGridView = GVeitlIssuedPOItem
  End Sub
  Protected Sub TBLeitlIssuedPOItem_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlIssuedPOItem.Init
		gveitlIssuedPOItemCC.SetToolBar = TBLeitlIssuedPOItem
  End Sub
  Protected Sub GVeitlIssuedPOItem_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVeitlIssuedPOItem.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim SerialNo As Int32 = GVeitlIssuedPOItem.DataKeys(e.CommandArgument).Values("SerialNo")  
				Dim ItemLineNo As Int32 = GVeitlIssuedPOItem.DataKeys(e.CommandArgument).Values("ItemLineNo")  
				Dim RedirectUrl As String = TBLeitlIssuedPOItem.EditUrl & "?SerialNo=" & SerialNo & "&ItemLineNo=" & ItemLineNo
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub

End Class
