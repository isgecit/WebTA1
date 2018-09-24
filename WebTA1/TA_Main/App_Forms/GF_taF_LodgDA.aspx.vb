Partial Class GF_taF_LodgDA
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TA_Main/App_Display/DF_taF_LodgDA.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SerialNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtaF_LodgDA_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaF_LodgDA.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVtaF_LodgDA.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLtaF_LodgDA.EditUrl & "?SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtaF_LodgDA_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaF_LodgDA.Init
    DataClassName = "GtaF_LodgDA"
    SetGridView = GVtaF_LodgDA
  End Sub
  Protected Sub TBLtaF_LodgDA_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaF_LodgDA.Init
    SetToolBar = TBLtaF_LodgDA
  End Sub
  Protected Sub F_CategoryID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CategoryID.SelectedIndexChanged
    Session("F_CategoryID") = F_CategoryID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_RegionID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_RegionID.SelectedIndexChanged
    Session("F_RegionID") = F_RegionID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_CategoryID.SelectedValue = String.Empty
    If Not Session("F_CategoryID") Is Nothing Then
      If Session("F_CategoryID") <> String.Empty Then
        F_CategoryID.SelectedValue = Session("F_CategoryID")
      End If
    End If
    F_RegionID.SelectedValue = String.Empty
    If Not Session("F_RegionID") Is Nothing Then
      If Session("F_RegionID") <> String.Empty Then
        F_RegionID.SelectedValue = Session("F_RegionID")
      End If
    End If
  End Sub
End Class
