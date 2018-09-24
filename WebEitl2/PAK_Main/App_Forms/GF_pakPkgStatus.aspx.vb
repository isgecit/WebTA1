Partial Class GF_pakPkgStatus
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PAK_Main/App_Display/DF_pakPkgStatus.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?StatusID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpakPkgStatus_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakPkgStatus.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim StatusID As Int32 = GVpakPkgStatus.DataKeys(e.CommandArgument).Values("StatusID")  
        Dim RedirectUrl As String = TBLpakPkgStatus.EditUrl & "?StatusID=" & StatusID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVpakPkgStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakPkgStatus.Init
    DataClassName = "GpakPkgStatus"
    SetGridView = GVpakPkgStatus
  End Sub
  Protected Sub TBLpakPkgStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakPkgStatus.Init
    SetToolBar = TBLpakPkgStatus
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
