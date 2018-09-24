Partial Class GF_pakDivisions
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PAK_Main/App_Display/DF_pakDivisions.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?DivisionID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpakDivisions_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakDivisions.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim DivisionID As Int32 = GVpakDivisions.DataKeys(e.CommandArgument).Values("DivisionID")  
        Dim RedirectUrl As String = TBLpakDivisions.EditUrl & "?DivisionID=" & DivisionID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVpakDivisions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakDivisions.Init
    DataClassName = "GpakDivisions"
    SetGridView = GVpakDivisions
  End Sub
  Protected Sub TBLpakDivisions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakDivisions.Init
    SetToolBar = TBLpakDivisions
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
