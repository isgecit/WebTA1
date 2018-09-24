Partial Class GF_pakReasons
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PAK_Main/App_Display/DF_pakReasons.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ReasonID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpakReasons_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakReasons.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ReasonID As Int32 = GVpakReasons.DataKeys(e.CommandArgument).Values("ReasonID")  
        Dim RedirectUrl As String = TBLpakReasons.EditUrl & "?ReasonID=" & ReasonID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVpakReasons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakReasons.Init
    DataClassName = "GpakReasons"
    SetGridView = GVpakReasons
  End Sub
  Protected Sub TBLpakReasons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakReasons.Init
    SetToolBar = TBLpakReasons
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
