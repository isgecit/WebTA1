Partial Class GF_costGLNatures
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/COST_Main/App_Display/DF_costGLNatures.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?GLNatureID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVcostGLNatures_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVcostGLNatures.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim GLNatureID As Int32 = GVcostGLNatures.DataKeys(e.CommandArgument).Values("GLNatureID")  
        Dim RedirectUrl As String = TBLcostGLNatures.EditUrl & "?GLNatureID=" & GLNatureID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVcostGLNatures_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVcostGLNatures.Init
    DataClassName = "GcostGLNatures"
    SetGridView = GVcostGLNatures
  End Sub
  Protected Sub TBLcostGLNatures_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostGLNatures.Init
    SetToolBar = TBLcostGLNatures
  End Sub
  Protected Sub F_GLNatureID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_GLNatureID.TextChanged
    Session("F_GLNatureID") = F_GLNatureID.Text
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
