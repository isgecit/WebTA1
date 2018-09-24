Partial Class GF_taD_Lodging
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TA_Main/App_Display/DF_taD_Lodging.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SerialNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtaD_Lodging_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaD_Lodging.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVtaD_Lodging.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLtaD_Lodging.EditUrl & "?SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtaD_Lodging_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaD_Lodging.Init
    DataClassName = "GtaD_Lodging"
    SetGridView = GVtaD_Lodging
  End Sub
  Protected Sub TBLtaD_Lodging_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaD_Lodging.Init
    SetToolBar = TBLtaD_Lodging
  End Sub
  Protected Sub F_CategoryID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CategoryID.SelectedIndexChanged
    Session("F_CategoryID") = F_CategoryID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_CityTypeID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CityTypeID.SelectedIndexChanged
    Session("F_CityTypeID") = F_CityTypeID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_CategoryID.SelectedValue = String.Empty
    If Not Session("F_CategoryID") Is Nothing Then
      If Session("F_CategoryID") <> String.Empty Then
        F_CategoryID.SelectedValue = Session("F_CategoryID")
      End If
    End If
    F_CityTypeID.SelectedValue = String.Empty
    If Not Session("F_CityTypeID") Is Nothing Then
      If Session("F_CityTypeID") <> String.Empty Then
        F_CityTypeID.SelectedValue = Session("F_CityTypeID")
      End If
    End If
  End Sub
End Class
