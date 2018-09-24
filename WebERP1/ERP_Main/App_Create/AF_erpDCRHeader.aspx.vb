Partial Class AF_erpDCRHeader
  Inherits SIS.SYS.InsertBase
  Protected Sub FVerpDCRHeader_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpDCRHeader.Init
    DataClassName = "AerpDCRHeader"
    SetFormView = FVerpDCRHeader
  End Sub
  Protected Sub TBLerpDCRHeader_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpDCRHeader.Init
    SetToolBar = TBLerpDCRHeader
  End Sub
  Protected Sub FVerpDCRHeader_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpDCRHeader.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ERP_Main/App_Create") & "/AF_erpDCRHeader.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripterpDCRHeader") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripterpDCRHeader", mStr)
    End If
    If Request.QueryString("DCRNo") IsNot Nothing Then
      CType(FVerpDCRHeader.FindControl("F_DCRNo"), TextBox).Text = Request.QueryString("DCRNo")
      CType(FVerpDCRHeader.FindControl("F_DCRNo"), TextBox).Enabled = False
    End If
  End Sub

End Class
