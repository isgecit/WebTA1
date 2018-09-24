Partial Class GF_elogBLHeader
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ELOG_Main/App_Display/DF_elogBLHeader.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?BLID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVelogBLHeader_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVelogBLHeader.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim BLID As String = GVelogBLHeader.DataKeys(e.CommandArgument).Values("BLID")  
        Dim RedirectUrl As String = TBLelogBLHeader.EditUrl & "?BLID=" & BLID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVelogBLHeader_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVelogBLHeader.Init
    DataClassName = "GelogBLHeader"
    SetGridView = GVelogBLHeader
  End Sub
  Protected Sub TBLelogBLHeader_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogBLHeader.Init
    SetToolBar = TBLelogBLHeader
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
