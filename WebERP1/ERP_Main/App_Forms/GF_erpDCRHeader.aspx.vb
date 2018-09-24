Partial Class GF_erpDCRHeader
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ERP_Main/App_Display/DF_erpDCRHeader.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?DCRNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVerpDCRHeader_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVerpDCRHeader.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim DCRNo As String = GVerpDCRHeader.DataKeys(e.CommandArgument).Values("DCRNo")  
				Dim RedirectUrl As String = TBLerpDCRHeader.EditUrl & "?DCRNo=" & DCRNo
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
		If e.CommandName.ToLower = "initiatewf".ToLower Then
			Try
				Dim DCRNo As String = GVerpDCRHeader.DataKeys(e.CommandArgument).Values("DCRNo")  
				SIS.ERP.erpDCRHeader.InitiateWF(DCRNo)
				GVerpDCRHeader.DataBind()
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVerpDCRHeader_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVerpDCRHeader.Init
    DataClassName = "GerpDCRHeader"
    SetGridView = GVerpDCRHeader
  End Sub
  Protected Sub TBLerpDCRHeader_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpDCRHeader.Init
    SetToolBar = TBLerpDCRHeader
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
