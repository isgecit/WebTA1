Partial Class GF_taComponents
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TA_Main/App_Display/DF_taComponents.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ComponentID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtaComponents_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaComponents.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ComponentID As Int32 = GVtaComponents.DataKeys(e.CommandArgument).Values("ComponentID")  
        Dim RedirectUrl As String = TBLtaComponents.EditUrl & "?ComponentID=" & ComponentID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtaComponents_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaComponents.Init
    DataClassName = "GtaComponents"
    SetGridView = GVtaComponents
  End Sub
  Protected Sub TBLtaComponents_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaComponents.Init
    SetToolBar = TBLtaComponents
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
