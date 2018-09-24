Imports System.Web.Script.Serialization
Partial Class GF_nprkUserClaims
  Inherits SIS.SYS.GridBase
  Protected Sub GVnprkUserClaims_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVnprkUserClaims.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ClaimID As Int32 = GVnprkUserClaims.DataKeys(e.CommandArgument).Values("ClaimID")
        Dim RedirectUrl As String = TBLnprkUserClaims.EditUrl & "?ClaimID=" & ClaimID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Dim uList As String = ConfigurationManager.AppSettings("PerkUsers")
      If uList.Trim <> "*" Then
        Dim aUList() As String = uList.Split(",".ToCharArray)
        Dim Found As Boolean = False
        Dim LoginID As String = HttpContext.Current.Session("LoginID")
        For Each usr As String In aUList
          If usr.Trim = LoginID Then
            Found = True
            Exit For
          End If
        Next
        If Not Found Then
          Dim message As String = New JavaScriptSerializer().Serialize("Claim submission is stopped by Accounts.")
          Dim script As String = String.Format("alert({0});", message)
          ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
        End If
      Else
        Try
          Dim ClaimID As Int32 = GVnprkUserClaims.DataKeys(e.CommandArgument).Values("ClaimID")
          SIS.NPRK.nprkUserClaims.InitiateWF(ClaimID)
          GVnprkUserClaims.DataBind()
        Catch ex As Exception
          Dim message As String = New JavaScriptSerializer().Serialize(ex.Message)
          Dim script As String = String.Format("alert({0});", message)
          ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
        End Try
      End If
    End If
    If e.CommandName.ToLower = "deletewf".ToLower Then
      Try
        Dim ClaimID As Int32 = GVnprkUserClaims.DataKeys(e.CommandArgument).Values("ClaimID")
        SIS.NPRK.nprkUserClaims.DeleteWF(ClaimID)
        GVnprkUserClaims.DataBind()
      Catch ex As Exception
        Dim message As String = New JavaScriptSerializer().Serialize(ex.Message)
        Dim script As String = String.Format("alert({0});", message)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      End Try
    End If
  End Sub
  Protected Sub GVnprkUserClaims_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVnprkUserClaims.Init
    DataClassName = "GnprkUserClaims"
    SetGridView = GVnprkUserClaims
  End Sub
  Protected Sub TBLnprkUserClaims_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkUserClaims.Init
    SetToolBar = TBLnprkUserClaims
  End Sub
  Protected Sub F_ClaimStatusID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ClaimStatusID.SelectedIndexChanged
    Session("F_ClaimStatusID") = F_ClaimStatusID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_ClaimStatusID.SelectedValue = String.Empty
    If Not Session("F_ClaimStatusID") Is Nothing Then
      If Session("F_ClaimStatusID") <> String.Empty Then
        F_ClaimStatusID.SelectedValue = Session("F_ClaimStatusID")
      End If
    End If
  End Sub
  Private Sub TBLnprkUserClaims_AddClicked(sender As Object, e As ImageClickEventArgs) Handles TBLnprkUserClaims.AddClicked
    Dim tmp As New SIS.NPRK.nprkUserClaims
    tmp = SIS.NPRK.nprkUserClaims.UZ_nprkUserClaimsInsert(tmp)
    Dim RedirectUrl As String = TBLnprkUserClaims.EditUrl & "?ClaimID=" & tmp.ClaimID
    Response.Redirect(RedirectUrl)
  End Sub
End Class
