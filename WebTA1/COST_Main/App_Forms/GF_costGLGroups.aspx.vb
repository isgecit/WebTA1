Partial Class GF_costGLGroups
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/COST_Main/App_Display/DF_costGLGroups.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?GLGroupID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVcostGLGroups_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVcostGLGroups.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim GLGroupID As Int32 = GVcostGLGroups.DataKeys(e.CommandArgument).Values("GLGroupID")  
        Dim RedirectUrl As String = TBLcostGLGroups.EditUrl & "?GLGroupID=" & GLGroupID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "approvewf".ToLower Then
      Try
        Dim Sequence As Int32 = CType(GVcostGLGroups.Rows(e.CommandArgument).FindControl("F_Sequence"),TextBox).Text
        Dim GLGroupID As Int32 = GVcostGLGroups.DataKeys(e.CommandArgument).Values("GLGroupID")  
        SIS.COST.costGLGroups.ApproveWF(GLGroupID, Sequence)
        GVcostGLGroups.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVcostGLGroups_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVcostGLGroups.Init
    DataClassName = "GcostGLGroups"
    SetGridView = GVcostGLGroups
  End Sub
  Protected Sub TBLcostGLGroups_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostGLGroups.Init
    SetToolBar = TBLcostGLGroups
  End Sub
  Protected Sub F_GLGroupID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_GLGroupID.TextChanged
    Session("F_GLGroupID") = F_GLGroupID.Text
    InitGridPage()
  End Sub
  Protected Sub F_GLNatureID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_GLNatureID.SelectedIndexChanged
    Session("F_GLNatureID") = F_GLNatureID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_GLNatureID.SelectedValue = String.Empty
    If Not Session("F_GLNatureID") Is Nothing Then
      If Session("F_GLNatureID") <> String.Empty Then
        F_GLNatureID.SelectedValue = Session("F_GLNatureID")
      End If
    End If
  End Sub

End Class
