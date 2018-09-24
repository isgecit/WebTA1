Partial Class GF_taTravelModes
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TA_Main/App_Display/DF_taTravelModes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ModeID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtaTravelModes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaTravelModes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ModeID As Int32 = GVtaTravelModes.DataKeys(e.CommandArgument).Values("ModeID")  
        Dim RedirectUrl As String = TBLtaTravelModes.EditUrl & "?ModeID=" & ModeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtaTravelModes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaTravelModes.Init
    DataClassName = "GtaTravelModes"
    SetGridView = GVtaTravelModes
  End Sub
  Protected Sub TBLtaTravelModes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaTravelModes.Init
    SetToolBar = TBLtaTravelModes
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
