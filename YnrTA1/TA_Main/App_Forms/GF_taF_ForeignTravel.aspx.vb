Partial Class GF_taF_ForeignTravel
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TA_Main/App_Display/DF_taF_ForeignTravel.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SerialNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtaF_ForeignTravel_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaF_ForeignTravel.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVtaF_ForeignTravel.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLtaF_ForeignTravel.EditUrl & "?SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtaF_ForeignTravel_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaF_ForeignTravel.Init
    DataClassName = "GtaF_ForeignTravel"
    SetGridView = GVtaF_ForeignTravel
  End Sub
  Protected Sub TBLtaF_ForeignTravel_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaF_ForeignTravel.Init
    SetToolBar = TBLtaF_ForeignTravel
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
