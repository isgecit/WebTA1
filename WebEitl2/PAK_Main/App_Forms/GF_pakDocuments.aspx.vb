Partial Class GF_pakDocuments
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PAK_Main/App_Display/DF_pakDocuments.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?DocumentNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpakDocuments_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakDocuments.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim DocumentNo As Int32 = GVpakDocuments.DataKeys(e.CommandArgument).Values("DocumentNo")  
        Dim RedirectUrl As String = TBLpakDocuments.EditUrl & "?DocumentNo=" & DocumentNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVpakDocuments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakDocuments.Init
    DataClassName = "GpakDocuments"
    SetGridView = GVpakDocuments
  End Sub
  Protected Sub TBLpakDocuments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakDocuments.Init
    SetToolBar = TBLpakDocuments
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
