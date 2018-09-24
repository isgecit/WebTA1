Partial Class GF_pakPOStatus
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PAK_Main/App_Display/DF_pakPOStatus.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?StatusID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpakPOStatus_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakPOStatus.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim StatusID As Int32 = GVpakPOStatus.DataKeys(e.CommandArgument).Values("StatusID")  
        Dim RedirectUrl As String = TBLpakPOStatus.EditUrl & "?StatusID=" & StatusID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVpakPOStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakPOStatus.Init
    DataClassName = "GpakPOStatus"
    SetGridView = GVpakPOStatus
  End Sub
  Protected Sub TBLpakPOStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakPOStatus.Init
    SetToolBar = TBLpakPOStatus
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
