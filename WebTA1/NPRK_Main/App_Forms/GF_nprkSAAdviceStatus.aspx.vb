Partial Class GF_nprkSAAdviceStatus
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/NPRK_Main/App_Display/DF_nprkSAAdviceStatus.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?StatusID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVnprkSAAdviceStatus_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVnprkSAAdviceStatus.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim StatusID As Int32 = GVnprkSAAdviceStatus.DataKeys(e.CommandArgument).Values("StatusID")  
        Dim RedirectUrl As String = TBLnprkSAAdviceStatus.EditUrl & "?StatusID=" & StatusID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVnprkSAAdviceStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVnprkSAAdviceStatus.Init
    DataClassName = "GnprkSAAdviceStatus"
    SetGridView = GVnprkSAAdviceStatus
  End Sub
  Protected Sub TBLnprkSAAdviceStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkSAAdviceStatus.Init
    SetToolBar = TBLnprkSAAdviceStatus
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
