Partial Class GF_taApprovalWFTypes
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TA_Main/App_Display/DF_taApprovalWFTypes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?WFTypeID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtaApprovalWFTypes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaApprovalWFTypes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim WFTypeID As Int32 = GVtaApprovalWFTypes.DataKeys(e.CommandArgument).Values("WFTypeID")  
        Dim RedirectUrl As String = TBLtaApprovalWFTypes.EditUrl & "?WFTypeID=" & WFTypeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtaApprovalWFTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaApprovalWFTypes.Init
    DataClassName = "GtaApprovalWFTypes"
    SetGridView = GVtaApprovalWFTypes
  End Sub
  Protected Sub TBLtaApprovalWFTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaApprovalWFTypes.Init
    SetToolBar = TBLtaApprovalWFTypes
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
