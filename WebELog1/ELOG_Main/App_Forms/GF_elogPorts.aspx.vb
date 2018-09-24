Partial Class GF_elogPorts
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ELOG_Main/App_Display/DF_elogPorts.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?PortID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVelogPorts_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVelogPorts.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim PortID As Int32 = GVelogPorts.DataKeys(e.CommandArgument).Values("PortID")  
        Dim RedirectUrl As String = TBLelogPorts.EditUrl & "?PortID=" & PortID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVelogPorts_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVelogPorts.Init
    DataClassName = "GelogPorts"
    SetGridView = GVelogPorts
  End Sub
  Protected Sub TBLelogPorts_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogPorts.Init
    SetToolBar = TBLelogPorts
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
