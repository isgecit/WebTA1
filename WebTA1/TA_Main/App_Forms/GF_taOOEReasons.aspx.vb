Partial Class GF_taOOEReasons
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TA_Main/App_Display/DF_taOOEReasons.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ReasonID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtaOOEReasons_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaOOEReasons.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ReasonID As Int32 = GVtaOOEReasons.DataKeys(e.CommandArgument).Values("ReasonID")  
        Dim RedirectUrl As String = TBLtaOOEReasons.EditUrl & "?ReasonID=" & ReasonID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtaOOEReasons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaOOEReasons.Init
    DataClassName = "GtaOOEReasons"
    SetGridView = GVtaOOEReasons
  End Sub
  Protected Sub TBLtaOOEReasons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaOOEReasons.Init
    SetToolBar = TBLtaOOEReasons
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
