Partial Class GF_pakPkgIStatus
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PAK_Main/App_Display/DF_pakPkgIStatus.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?StatusID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpakPkgIStatus_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakPkgIStatus.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim StatusID As Int32 = GVpakPkgIStatus.DataKeys(e.CommandArgument).Values("StatusID")  
        Dim RedirectUrl As String = TBLpakPkgIStatus.EditUrl & "?StatusID=" & StatusID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVpakPkgIStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakPkgIStatus.Init
    DataClassName = "GpakPkgIStatus"
    SetGridView = GVpakPkgIStatus
  End Sub
  Protected Sub TBLpakPkgIStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakPkgIStatus.Init
    SetToolBar = TBLpakPkgIStatus
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
