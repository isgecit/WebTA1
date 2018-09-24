Partial Class GF_nprkSiteAllowanceClaims
  Inherits SIS.SYS.GridBase
  Protected Sub GVnprkSiteAllowanceClaims_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVnprkSiteAllowanceClaims.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim FinYear As Int32 = GVnprkSiteAllowanceClaims.DataKeys(e.CommandArgument).Values("FinYear")
        Dim Quarter As Int32 = GVnprkSiteAllowanceClaims.DataKeys(e.CommandArgument).Values("Quarter")
        Dim EmployeeID As String = GVnprkSiteAllowanceClaims.DataKeys(e.CommandArgument).Values("EmployeeID")
        Dim RedirectUrl As String = TBLnprkSiteAllowanceClaims.EditUrl & "?FinYear=" & FinYear & "&Quarter=" & Quarter & "&EmployeeID=" & EmployeeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim FinYear As Int32 = GVnprkSiteAllowanceClaims.DataKeys(e.CommandArgument).Values("FinYear")
        Dim Quarter As Int32 = GVnprkSiteAllowanceClaims.DataKeys(e.CommandArgument).Values("Quarter")
        Dim EmployeeID As String = GVnprkSiteAllowanceClaims.DataKeys(e.CommandArgument).Values("EmployeeID")
        SIS.NPRK.nprkSiteAllowanceClaims.InitiateWF(FinYear, Quarter, EmployeeID)
        GVnprkSiteAllowanceClaims.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVnprkSiteAllowanceClaims_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVnprkSiteAllowanceClaims.Init
    DataClassName = "GnprkSiteAllowanceClaims"
    SetGridView = GVnprkSiteAllowanceClaims
  End Sub
  Protected Sub TBLnprkSiteAllowanceClaims_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkSiteAllowanceClaims.Init
    SetToolBar = TBLnprkSiteAllowanceClaims
  End Sub
  Protected Sub F_FinYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_FinYear.SelectedIndexChanged
    Session("F_FinYear") = F_FinYear.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_Quarter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_Quarter.SelectedIndexChanged
    Session("F_Quarter") = F_Quarter.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_FinYear.SelectedValue = String.Empty
    If Not Session("F_FinYear") Is Nothing Then
      If Session("F_FinYear") <> String.Empty Then
        F_FinYear.SelectedValue = Session("F_FinYear")
      End If
    End If
    F_Quarter.SelectedValue = String.Empty
    If Not Session("F_Quarter") Is Nothing Then
      If Session("F_Quarter") <> String.Empty Then
        F_Quarter.SelectedValue = Session("F_Quarter")
      End If
    End If
  End Sub
End Class
