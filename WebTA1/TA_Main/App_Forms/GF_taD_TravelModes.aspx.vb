Partial Class GF_taD_TravelModes
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TA_Main/App_Display/DF_taD_TravelModes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SerialNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtaD_TravelModes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaD_TravelModes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVtaD_TravelModes.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLtaD_TravelModes.EditUrl & "?SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtaD_TravelModes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaD_TravelModes.Init
    DataClassName = "GtaD_TravelModes"
    SetGridView = GVtaD_TravelModes
  End Sub
  Protected Sub TBLtaD_TravelModes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaD_TravelModes.Init
    SetToolBar = TBLtaD_TravelModes
  End Sub
  Protected Sub F_CategoryID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CategoryID.SelectedIndexChanged
    Session("F_CategoryID") = F_CategoryID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_TravelModeID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_TravelModeID.SelectedIndexChanged
    Session("F_TravelModeID") = F_TravelModeID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_CategoryID.SelectedValue = String.Empty
    If Not Session("F_CategoryID") Is Nothing Then
      If Session("F_CategoryID") <> String.Empty Then
        F_CategoryID.SelectedValue = Session("F_CategoryID")
      End If
    End If
    F_TravelModeID.SelectedValue = String.Empty
    If Not Session("F_TravelModeID") Is Nothing Then
      If Session("F_TravelModeID") <> String.Empty Then
        F_TravelModeID.SelectedValue = Session("F_TravelModeID")
      End If
    End If
  End Sub
End Class
