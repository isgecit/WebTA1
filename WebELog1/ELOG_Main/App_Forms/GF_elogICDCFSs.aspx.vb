Partial Class GF_elogICDCFSs
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ELOG_Main/App_Display/DF_elogICDCFSs.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ICDCFSID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVelogICDCFSs_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVelogICDCFSs.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ICDCFSID As Int32 = GVelogICDCFSs.DataKeys(e.CommandArgument).Values("ICDCFSID")  
        Dim RedirectUrl As String = TBLelogICDCFSs.EditUrl & "?ICDCFSID=" & ICDCFSID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVelogICDCFSs_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVelogICDCFSs.Init
    DataClassName = "GelogICDCFSs"
    SetGridView = GVelogICDCFSs
  End Sub
  Protected Sub TBLelogICDCFSs_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogICDCFSs.Init
    SetToolBar = TBLelogICDCFSs
  End Sub
  Protected Sub F_StuffingPointID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_StuffingPointID.SelectedIndexChanged
    Session("F_StuffingPointID") = F_StuffingPointID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_StuffingPointID.SelectedValue = String.Empty
    If Not Session("F_StuffingPointID") Is Nothing Then
      If Session("F_StuffingPointID") <> String.Empty Then
        F_StuffingPointID.SelectedValue = Session("F_StuffingPointID")
      End If
    End If
  End Sub
End Class
