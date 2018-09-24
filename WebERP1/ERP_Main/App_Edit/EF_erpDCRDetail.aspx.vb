Partial Class EF_erpDCRDetail
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVerpDCRDetail_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpDCRDetail.Init
    DataClassName = "EerpDCRDetail"
    SetFormView = FVerpDCRDetail
  End Sub
  Protected Sub TBLerpDCRDetail_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpDCRDetail.Init
    SetToolBar = TBLerpDCRDetail
  End Sub
  Protected Sub FVerpDCRDetail_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpDCRDetail.PreRender
		TBLerpDCRDetail.PrintUrl &= Request.QueryString("DCRNo") & "|"
		TBLerpDCRDetail.PrintUrl &= Request.QueryString("DocumentID") & "|"
		TBLerpDCRDetail.PrintUrl &= Request.QueryString("RevisionNo") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ERP_Main/App_Edit") & "/EF_erpDCRDetail.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripterpDCRDetail") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripterpDCRDetail", mStr)
    End If
  End Sub

End Class
