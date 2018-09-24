Partial Class GF_nprkPetrolRate
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/NPRK_Main/App_Display/DF_nprkPetrolRate.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?FinYear=" & aVal(0) & "&MonthID=" & aVal(1) & "&LocationID=" & aVal(2)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVnprkPetrolRate_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVnprkPetrolRate.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim FinYear As Int32 = GVnprkPetrolRate.DataKeys(e.CommandArgument).Values("FinYear")  
        Dim MonthID As Int32 = GVnprkPetrolRate.DataKeys(e.CommandArgument).Values("MonthID")  
        Dim LocationID As Int32 = GVnprkPetrolRate.DataKeys(e.CommandArgument).Values("LocationID")  
        Dim RedirectUrl As String = TBLnprkPetrolRate.EditUrl & "?FinYear=" & FinYear & "&MonthID=" & MonthID & "&LocationID=" & LocationID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVnprkPetrolRate_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVnprkPetrolRate.Init
    DataClassName = "GnprkPetrolRate"
    SetGridView = GVnprkPetrolRate
  End Sub
  Protected Sub TBLnprkPetrolRate_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkPetrolRate.Init
    SetToolBar = TBLnprkPetrolRate
  End Sub
  Protected Sub F_FinYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_FinYear.SelectedIndexChanged
    Session("F_FinYear") = F_FinYear.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_MonthID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_MonthID.SelectedIndexChanged
    Session("F_MonthID") = F_MonthID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_LocationID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_LocationID.SelectedIndexChanged
    Session("F_LocationID") = F_LocationID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_FinYear.SelectedValue = String.Empty
    If Not Session("F_FinYear") Is Nothing Then
      If Session("F_FinYear") <> String.Empty Then
        F_FinYear.SelectedValue = Session("F_FinYear")
      End If
    End If
    F_MonthID.SelectedValue = String.Empty
    If Not Session("F_MonthID") Is Nothing Then
      If Session("F_MonthID") <> String.Empty Then
        F_MonthID.SelectedValue = Session("F_MonthID")
      End If
    End If
    F_LocationID.SelectedValue = String.Empty
    If Not Session("F_LocationID") Is Nothing Then
      If Session("F_LocationID") <> String.Empty Then
        F_LocationID.SelectedValue = Session("F_LocationID")
      End If
    End If
  End Sub
End Class
