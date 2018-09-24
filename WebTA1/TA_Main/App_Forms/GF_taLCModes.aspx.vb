Partial Class GF_taLCModes
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TA_Main/App_Display/DF_taLCModes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ModeID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtaLCModes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaLCModes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ModeID As Int32 = GVtaLCModes.DataKeys(e.CommandArgument).Values("ModeID")  
        Dim RedirectUrl As String = TBLtaLCModes.EditUrl & "?ModeID=" & ModeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtaLCModes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaLCModes.Init
    DataClassName = "GtaLCModes"
    SetGridView = GVtaLCModes
  End Sub
  Protected Sub TBLtaLCModes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaLCModes.Init
    SetToolBar = TBLtaLCModes
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
