Imports System.Web.Script.Serialization
Partial Class GF_taEmployees
  Inherits SIS.SYS.GridBase
  Protected Sub GVtaEmployees_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaEmployees.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim CardNo As String = GVtaEmployees.DataKeys(e.CommandArgument).Values("CardNo")
        Dim RedirectUrl As String = TBLtaEmployees.EditUrl & "?CardNo=" & CardNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim CardNo As String = GVtaEmployees.DataKeys(e.CommandArgument).Values("CardNo")
        Dim oUsr As MembershipUser = Membership.GetUser(CardNo)
        If Not oUsr Is Nothing Then
          oUsr.UnlockUser()
        Else
          SIS.TA.taEmployees.CreateWebUserAndAuthorization(SIS.TA.taEmployees.taEmployeesGetByID(CardNo))
        End If
        'SIS.TA.taEmployees.InitiateWF(CardNo)
        'GVtaEmployees.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "approvewf".ToLower Then
      Try
        Dim CardNo As String = GVtaEmployees.DataKeys(e.CommandArgument).Values("CardNo")
        Dim oUsr As MembershipUser = Membership.GetUser(CardNo)
        If SIS.SYS.Utilities.GlobalVariables.mkPass(CardNo) Then
          If Not oUsr Is Nothing Then
            oUsr.ChangePassword("lg", CardNo)
          End If
        End If
        'SIS.TA.taEmployees.ApproveWF(CardNo)
        'GVtaEmployees.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVtaEmployees_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaEmployees.Init
    DataClassName = "GtaEmployees"
    SetGridView = GVtaEmployees
  End Sub
  Protected Sub TBLtaEmployees_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaEmployees.Init
    SetToolBar = TBLtaEmployees
  End Sub
  Protected Sub F_C_DepartmentID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_C_DepartmentID.SelectedIndexChanged
    Session("F_C_DepartmentID") = F_C_DepartmentID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_C_DesignationID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_C_DesignationID.SelectedIndexChanged
    Session("F_C_DesignationID") = F_C_DesignationID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_C_DivisionID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_C_DivisionID.SelectedIndexChanged
    Session("F_C_DivisionID") = F_C_DivisionID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_CategoryID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CategoryID.SelectedIndexChanged
    Session("F_CategoryID") = F_CategoryID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_C_OfficeID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_C_OfficeID.SelectedIndexChanged
    Session("F_C_OfficeID") = F_C_OfficeID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_C_CompanyID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_C_CompanyID.SelectedIndexChanged
    Session("F_C_CompanyID") = F_C_CompanyID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_C_DepartmentID.SelectedValue = String.Empty
    If Not Session("F_C_DepartmentID") Is Nothing Then
      If Session("F_C_DepartmentID") <> String.Empty Then
        F_C_DepartmentID.SelectedValue = Session("F_C_DepartmentID")
      End If
    End If
    F_C_DesignationID.SelectedValue = String.Empty
    If Not Session("F_C_DesignationID") Is Nothing Then
      If Session("F_C_DesignationID") <> String.Empty Then
        F_C_DesignationID.SelectedValue = Session("F_C_DesignationID")
      End If
    End If
    F_C_DivisionID.SelectedValue = String.Empty
    If Not Session("F_C_DivisionID") Is Nothing Then
      If Session("F_C_DivisionID") <> String.Empty Then
        F_C_DivisionID.SelectedValue = Session("F_C_DivisionID")
      End If
    End If
    F_CategoryID.SelectedValue = String.Empty
    If Not Session("F_CategoryID") Is Nothing Then
      If Session("F_CategoryID") <> String.Empty Then
        F_CategoryID.SelectedValue = Session("F_CategoryID")
      End If
    End If
    F_C_OfficeID.SelectedValue = String.Empty
    If Not Session("F_C_OfficeID") Is Nothing Then
      If Session("F_C_OfficeID") <> String.Empty Then
        F_C_OfficeID.SelectedValue = Session("F_C_OfficeID")
      End If
    End If
    F_C_CompanyID.SelectedValue = String.Empty
    If Not Session("F_C_CompanyID") Is Nothing Then
      If Session("F_C_CompanyID") <> String.Empty Then
        F_C_CompanyID.SelectedValue = Session("F_C_CompanyID")
      End If
    End If
  End Sub
End Class
