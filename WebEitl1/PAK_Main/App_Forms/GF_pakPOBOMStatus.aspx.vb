Partial Class GF_pakPOBOMStatus
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PAK_Main/App_Display/DF_pakPOBOMStatus.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?StatusID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpakPOBOMStatus_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakPOBOMStatus.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim StatusID As Int32 = GVpakPOBOMStatus.DataKeys(e.CommandArgument).Values("StatusID")  
        Dim RedirectUrl As String = TBLpakPOBOMStatus.EditUrl & "?StatusID=" & StatusID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVpakPOBOMStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakPOBOMStatus.Init
    DataClassName = "GpakPOBOMStatus"
    SetGridView = GVpakPOBOMStatus
  End Sub
  Protected Sub TBLpakPOBOMStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakPOBOMStatus.Init
    SetToolBar = TBLpakPOBOMStatus
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
