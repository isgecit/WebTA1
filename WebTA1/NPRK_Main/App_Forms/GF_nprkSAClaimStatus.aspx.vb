Partial Class GF_nprkSAClaimStatus
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/NPRK_Main/App_Display/DF_nprkSAClaimStatus.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?StatusID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVnprkSAClaimStatus_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVnprkSAClaimStatus.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim StatusID As Int32 = GVnprkSAClaimStatus.DataKeys(e.CommandArgument).Values("StatusID")  
        Dim RedirectUrl As String = TBLnprkSAClaimStatus.EditUrl & "?StatusID=" & StatusID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVnprkSAClaimStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVnprkSAClaimStatus.Init
    DataClassName = "GnprkSAClaimStatus"
    SetGridView = GVnprkSAClaimStatus
  End Sub
  Protected Sub TBLnprkSAClaimStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkSAClaimStatus.Init
    SetToolBar = TBLnprkSAClaimStatus
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
