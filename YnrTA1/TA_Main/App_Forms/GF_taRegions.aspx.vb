Partial Class GF_taRegions
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TA_Main/App_Display/DF_taRegions.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?RegionID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtaRegions_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaRegions.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim RegionID As String = GVtaRegions.DataKeys(e.CommandArgument).Values("RegionID")  
        Dim RedirectUrl As String = TBLtaRegions.EditUrl & "?RegionID=" & RegionID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtaRegions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaRegions.Init
    DataClassName = "GtaRegions"
    SetGridView = GVtaRegions
  End Sub
  Protected Sub TBLtaRegions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaRegions.Init
    SetToolBar = TBLtaRegions
  End Sub
  Protected Sub F_RegionTypeID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_RegionTypeID.SelectedIndexChanged
    Session("F_RegionTypeID") = F_RegionTypeID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_CurrencyID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CurrencyID.SelectedIndexChanged
    Session("F_CurrencyID") = F_CurrencyID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_RegionTypeID.SelectedValue = String.Empty
    If Not Session("F_RegionTypeID") Is Nothing Then
      If Session("F_RegionTypeID") <> String.Empty Then
        F_RegionTypeID.SelectedValue = Session("F_RegionTypeID")
      End If
    End If
    F_CurrencyID.SelectedValue = String.Empty
    If Not Session("F_CurrencyID") Is Nothing Then
      If Session("F_CurrencyID") <> String.Empty Then
        F_CurrencyID.SelectedValue = Session("F_CurrencyID")
      End If
    End If
  End Sub
End Class
