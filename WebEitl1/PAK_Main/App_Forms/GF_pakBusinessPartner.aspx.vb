Partial Class GF_pakBusinessPartner
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PAK_Main/App_Display/DF_pakBusinessPartner.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?BPID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpakBusinessPartner_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakBusinessPartner.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim BPID As String = GVpakBusinessPartner.DataKeys(e.CommandArgument).Values("BPID")  
        Dim RedirectUrl As String = TBLpakBusinessPartner.EditUrl & "?BPID=" & BPID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVpakBusinessPartner_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakBusinessPartner.Init
    DataClassName = "GpakBusinessPartner"
    SetGridView = GVpakBusinessPartner
  End Sub
  Protected Sub TBLpakBusinessPartner_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakBusinessPartner.Init
    SetToolBar = TBLpakBusinessPartner
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
