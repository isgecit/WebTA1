Partial Class GF_nprkMobileBillPlans
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/NPRK_Main/App_Display/DF_nprkMobileBillPlans.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?MobileBillPlanID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVnprkMobileBillPlans_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVnprkMobileBillPlans.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim MobileBillPlanID As Int32 = GVnprkMobileBillPlans.DataKeys(e.CommandArgument).Values("MobileBillPlanID")  
        Dim RedirectUrl As String = TBLnprkMobileBillPlans.EditUrl & "?MobileBillPlanID=" & MobileBillPlanID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVnprkMobileBillPlans_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVnprkMobileBillPlans.Init
    DataClassName = "GnprkMobileBillPlans"
    SetGridView = GVnprkMobileBillPlans
  End Sub
  Protected Sub TBLnprkMobileBillPlans_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkMobileBillPlans.Init
    SetToolBar = TBLnprkMobileBillPlans
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
