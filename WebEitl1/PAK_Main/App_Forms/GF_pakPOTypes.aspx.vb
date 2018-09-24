Partial Class GF_pakPOTypes
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PAK_Main/App_Display/DF_pakPOTypes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?POTypeID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpakPOTypes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakPOTypes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim POTypeID As Int32 = GVpakPOTypes.DataKeys(e.CommandArgument).Values("POTypeID")  
        Dim RedirectUrl As String = TBLpakPOTypes.EditUrl & "?POTypeID=" & POTypeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVpakPOTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakPOTypes.Init
    DataClassName = "GpakPOTypes"
    SetGridView = GVpakPOTypes
  End Sub
  Protected Sub TBLpakPOTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakPOTypes.Init
    SetToolBar = TBLpakPOTypes
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
