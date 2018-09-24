Partial Class GF_elogStuffingPoints
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ELOG_Main/App_Display/DF_elogStuffingPoints.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?StuffingPointID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVelogStuffingPoints_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVelogStuffingPoints.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim StuffingPointID As Int32 = GVelogStuffingPoints.DataKeys(e.CommandArgument).Values("StuffingPointID")  
        Dim RedirectUrl As String = TBLelogStuffingPoints.EditUrl & "?StuffingPointID=" & StuffingPointID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVelogStuffingPoints_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVelogStuffingPoints.Init
    DataClassName = "GelogStuffingPoints"
    SetGridView = GVelogStuffingPoints
  End Sub
  Protected Sub TBLelogStuffingPoints_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogStuffingPoints.Init
    SetToolBar = TBLelogStuffingPoints
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
