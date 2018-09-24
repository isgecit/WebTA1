Partial Class EF_erpDCRHeader
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVerpDCRHeader_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpDCRHeader.Init
    DataClassName = "EerpDCRHeader"
    SetFormView = FVerpDCRHeader
  End Sub
  Protected Sub TBLerpDCRHeader_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpDCRHeader.Init
    SetToolBar = TBLerpDCRHeader
  End Sub
  Protected Sub FVerpDCRHeader_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpDCRHeader.PreRender
		TBLerpDCRHeader.PrintUrl &= Request.QueryString("DCRNo") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ERP_Main/App_Edit") & "/EF_erpDCRHeader.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripterpDCRHeader") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripterpDCRHeader", mStr)
    End If
  End Sub
  Partial Class gvBase
		Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gverpDCRDetailCC As New gvBase
  Protected Sub GVerpDCRDetail_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVerpDCRDetail.Init
		gverpDCRDetailCC.DataClassName = "GerpDCRDetail"
		gverpDCRDetailCC.SetGridView = GVerpDCRDetail
  End Sub
  Protected Sub TBLerpDCRDetail_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpDCRDetail.Init
		gverpDCRDetailCC.SetToolBar = TBLerpDCRDetail
  End Sub
  Protected Sub GVerpDCRDetail_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVerpDCRDetail.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim DCRNo As String = GVerpDCRDetail.DataKeys(e.CommandArgument).Values("DCRNo")  
				Dim DocumentID As String = GVerpDCRDetail.DataKeys(e.CommandArgument).Values("DocumentID")  
				Dim RevisionNo As String = GVerpDCRDetail.DataKeys(e.CommandArgument).Values("RevisionNo")  
				Dim RedirectUrl As String = TBLerpDCRDetail.EditUrl & "?DCRNo=" & DCRNo & "&DocumentID=" & DocumentID & "&RevisionNo=" & RevisionNo
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
		If e.CommandName.ToLower = "initiatewf".ToLower Then
			Try
				Dim DCRNo As String = GVerpDCRDetail.DataKeys(e.CommandArgument).Values("DCRNo")  
				Dim DocumentID As String = GVerpDCRDetail.DataKeys(e.CommandArgument).Values("DocumentID")  
				Dim RevisionNo As String = GVerpDCRDetail.DataKeys(e.CommandArgument).Values("RevisionNo")  
				SIS.ERP.erpDCRDetail.InitiateWF(DCRNo, DocumentID, RevisionNo)
				GVerpDCRDetail.DataBind()
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub TBLerpDCRDetail_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLerpDCRDetail.AddClicked
		Dim DCRNo As String = CType(FVerpDCRHeader.FindControl("F_DCRNo"),TextBox).Text
		TBLerpDCRDetail.AddUrl &= "?DCRNo=" & DCRNo
  End Sub

End Class
