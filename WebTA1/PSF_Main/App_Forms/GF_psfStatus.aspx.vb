Partial Class GF_psfStatus
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PSF_Main/App_Display/DF_psfStatus.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?PSFStatus=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpsfStatus_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpsfStatus.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim PSFStatus As Int32 = GVpsfStatus.DataKeys(e.CommandArgument).Values("PSFStatus")  
        Dim RedirectUrl As String = TBLpsfStatus.EditUrl & "?PSFStatus=" & PSFStatus
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVpsfStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpsfStatus.Init
    DataClassName = "GpsfStatus"
    SetGridView = GVpsfStatus
  End Sub
  Protected Sub TBLpsfStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpsfStatus.Init
    SetToolBar = TBLpsfStatus
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
