Partial Class GF_pakPakTypes
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PAK_Main/App_Display/DF_pakPakTypes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?PackTypeID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpakPakTypes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakPakTypes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim PackTypeID As Int32 = GVpakPakTypes.DataKeys(e.CommandArgument).Values("PackTypeID")  
        Dim RedirectUrl As String = TBLpakPakTypes.EditUrl & "?PackTypeID=" & PackTypeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVpakPakTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakPakTypes.Init
    DataClassName = "GpakPakTypes"
    SetGridView = GVpakPakTypes
  End Sub
  Protected Sub TBLpakPakTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakPakTypes.Init
    SetToolBar = TBLpakPakTypes
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
