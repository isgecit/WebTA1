Partial Class GF_elogIRBLStates
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ELOG_Main/App_Display/DF_elogIRBLStates.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?StatusID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVelogIRBLStates_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVelogIRBLStates.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim StatusID As Int32 = GVelogIRBLStates.DataKeys(e.CommandArgument).Values("StatusID")  
        Dim RedirectUrl As String = TBLelogIRBLStates.EditUrl & "?StatusID=" & StatusID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVelogIRBLStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVelogIRBLStates.Init
    DataClassName = "GelogIRBLStates"
    SetGridView = GVelogIRBLStates
  End Sub
  Protected Sub TBLelogIRBLStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogIRBLStates.Init
    SetToolBar = TBLelogIRBLStates
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
