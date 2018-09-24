Partial Class GF_eitlImportPOList
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/EITL_Main/App_Display/DF_eitlImportPOList.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SerialNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVeitlImportPOList_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVeitlImportPOList.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim SerialNo As Int32 = GVeitlImportPOList.DataKeys(e.CommandArgument).Values("SerialNo")  
				Dim RedirectUrl As String = TBLeitlImportPOList.EditUrl & "?SerialNo=" & SerialNo
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
		If e.CommandName.ToLower = "initiatewf".ToLower Then
			Try
				Dim SerialNo As Int32 = GVeitlImportPOList.DataKeys(e.CommandArgument).Values("SerialNo")  
				SIS.EITL.eitlImportPOList.InitiateWF(SerialNo)
				GVeitlImportPOList.DataBind()
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVeitlImportPOList_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVeitlImportPOList.Init
    DataClassName = "GeitlImportPOList"
    SetGridView = GVeitlImportPOList
  End Sub
  Protected Sub TBLeitlImportPOList_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlImportPOList.Init
    SetToolBar = TBLeitlImportPOList
  End Sub
  Protected Sub cmdImport_Click(sender As Object, e As System.EventArgs) Handles cmdImport.Click
    If F_ProjectID.Text <> String.Empty Then
      'SIS.EITL.eitlImportPOList.ImportFromERP(F_ProjectID.Text, "")
      GVeitlImportPOList.DataBind()
    End If
  End Sub
  Protected Sub cmdPOImport_Click(sender As Object, e As System.EventArgs) Handles cmdPOImport.Click
    If F_PONumber.Text <> String.Empty Then
      'SIS.EITL.eitlImportPOList.ImportFromERP("", F_PONumber.Text)
      GVeitlImportPOList.DataBind()
    End If
  End Sub
End Class
