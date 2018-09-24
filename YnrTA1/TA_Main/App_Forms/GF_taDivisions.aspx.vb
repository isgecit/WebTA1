Partial Class GF_taDivisions
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TA_Main/App_Display/DF_taDivisions.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?DivisionID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtaDivisions_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaDivisions.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim DivisionID As String = GVtaDivisions.DataKeys(e.CommandArgument).Values("DivisionID")  
        Dim RedirectUrl As String = TBLtaDivisions.EditUrl & "?DivisionID=" & DivisionID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtaDivisions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaDivisions.Init
    DataClassName = "GtaDivisions"
    SetGridView = GVtaDivisions
  End Sub
  Protected Sub TBLtaDivisions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaDivisions.Init
    SetToolBar = TBLtaDivisions
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
