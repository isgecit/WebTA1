Partial Class GF_taD_LCModes
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TA_Main/App_Display/DF_taD_LCModes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SerialNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtaD_LCModes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaD_LCModes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVtaD_LCModes.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLtaD_LCModes.EditUrl & "?SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtaD_LCModes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaD_LCModes.Init
    DataClassName = "GtaD_LCModes"
    SetGridView = GVtaD_LCModes
  End Sub
  Protected Sub TBLtaD_LCModes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaD_LCModes.Init
    SetToolBar = TBLtaD_LCModes
  End Sub
  Protected Sub F_CategoryID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CategoryID.SelectedIndexChanged
    Session("F_CategoryID") = F_CategoryID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_LCModeID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_LCModeID.SelectedIndexChanged
    Session("F_LCModeID") = F_LCModeID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_CategoryID.SelectedValue = String.Empty
    If Not Session("F_CategoryID") Is Nothing Then
      If Session("F_CategoryID") <> String.Empty Then
        F_CategoryID.SelectedValue = Session("F_CategoryID")
      End If
    End If
    F_LCModeID.SelectedValue = String.Empty
    If Not Session("F_LCModeID") Is Nothing Then
      If Session("F_LCModeID") <> String.Empty Then
        F_LCModeID.SelectedValue = Session("F_LCModeID")
      End If
    End If
  End Sub
End Class
