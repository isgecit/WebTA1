Partial Class GF_nprkClaimStatus
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/NPRK_Main/App_Display/DF_nprkClaimStatus.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ClaimStatusID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVnprkClaimStatus_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVnprkClaimStatus.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ClaimStatusID As Int32 = GVnprkClaimStatus.DataKeys(e.CommandArgument).Values("ClaimStatusID")  
        Dim RedirectUrl As String = TBLnprkClaimStatus.EditUrl & "?ClaimStatusID=" & ClaimStatusID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVnprkClaimStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVnprkClaimStatus.Init
    DataClassName = "GnprkClaimStatus"
    SetGridView = GVnprkClaimStatus
  End Sub
  Protected Sub TBLnprkClaimStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkClaimStatus.Init
    SetToolBar = TBLnprkClaimStatus
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
