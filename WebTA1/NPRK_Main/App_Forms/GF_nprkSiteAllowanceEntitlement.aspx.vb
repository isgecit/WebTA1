Partial Class GF_nprkSiteAllowanceEntitlement
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/NPRK_Main/App_Display/DF_nprkSiteAllowanceEntitlement.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SerialNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVnprkSiteAllowanceEntitlement_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVnprkSiteAllowanceEntitlement.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVnprkSiteAllowanceEntitlement.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLnprkSiteAllowanceEntitlement.EditUrl & "?SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVnprkSiteAllowanceEntitlement_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVnprkSiteAllowanceEntitlement.Init
    DataClassName = "GnprkSiteAllowanceEntitlement"
    SetGridView = GVnprkSiteAllowanceEntitlement
  End Sub
  Protected Sub TBLnprkSiteAllowanceEntitlement_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkSiteAllowanceEntitlement.Init
    SetToolBar = TBLnprkSiteAllowanceEntitlement
  End Sub
  Protected Sub F_TACategoryID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_TACategoryID.SelectedIndexChanged
    Session("F_TACategoryID") = F_TACategoryID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_TACategoryID.SelectedValue = String.Empty
    If Not Session("F_TACategoryID") Is Nothing Then
      If Session("F_TACategoryID") <> String.Empty Then
        F_TACategoryID.SelectedValue = Session("F_TACategoryID")
      End If
    End If
  End Sub
End Class
