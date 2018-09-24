Imports System.Web.Script.Serialization
Partial Class GF_nprkApvrApplications
  Inherits SIS.SYS.GridBase
  Protected Sub GVnprkApvrApplications_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVnprkApvrApplications.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ClaimID As Int32 = GVnprkApvrApplications.DataKeys(e.CommandArgument).Values("ClaimID")
        Dim ApplicationID As Int32 = GVnprkApvrApplications.DataKeys(e.CommandArgument).Values("ApplicationID")
        Dim RedirectUrl As String = TBLnprkApvrApplications.EditUrl & "?ClaimID=" & ClaimID & "&ApplicationID=" & ApplicationID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "approvewf".ToLower Then
      Try
        Dim PaymentMethod As String = CType(GVnprkApvrApplications.Rows(e.CommandArgument).FindControl("F_PaymentMethod"), DropDownList).SelectedValue
        Dim Approved As Boolean = CType(GVnprkApvrApplications.Rows(e.CommandArgument).FindControl("F_Approved"), DropDownList).SelectedValue
        Dim ApprovedAmt As Decimal = CType(GVnprkApvrApplications.Rows(e.CommandArgument).FindControl("F_ApprovedAmt"), TextBox).Text
        Dim ApproverRemark As String = CType(GVnprkApvrApplications.Rows(e.CommandArgument).FindControl("F_ApproverRemark"), TextBox).Text
        Dim ClaimID As Int32 = GVnprkApvrApplications.DataKeys(e.CommandArgument).Values("ClaimID")
        Dim ApplicationID As Int32 = GVnprkApvrApplications.DataKeys(e.CommandArgument).Values("ApplicationID")
        SIS.NPRK.nprkApvrApplications.ApproveWF(ClaimID, ApplicationID, PaymentMethod, Approved, ApprovedAmt, ApproverRemark)
        GVnprkApvrApplications.DataBind()
      Catch ex As Exception
        Dim message As String = New JavaScriptSerializer().Serialize(ex.Message.ToString())
        Dim script As String = String.Format("alert({0});", message)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      End Try
    End If
    If e.CommandName.ToLower = "rejectwf".ToLower Then
      Try
        Dim PaymentMethod As String = CType(GVnprkApvrApplications.Rows(e.CommandArgument).FindControl("F_PaymentMethod"), DropDownList).SelectedValue
        Dim Approved As Boolean = CType(GVnprkApvrApplications.Rows(e.CommandArgument).FindControl("F_Approved"), DropDownList).SelectedValue
        Dim ApprovedAmt As Decimal = CType(GVnprkApvrApplications.Rows(e.CommandArgument).FindControl("F_ApprovedAmt"), TextBox).Text
        Dim ApproverRemark As String = CType(GVnprkApvrApplications.Rows(e.CommandArgument).FindControl("F_ApproverRemark"), TextBox).Text
        Dim ClaimID As Int32 = GVnprkApvrApplications.DataKeys(e.CommandArgument).Values("ClaimID")
        Dim ApplicationID As Int32 = GVnprkApvrApplications.DataKeys(e.CommandArgument).Values("ApplicationID")
        SIS.NPRK.nprkApvrApplications.RejectWF(ClaimID, ApplicationID, PaymentMethod, Approved, ApprovedAmt, ApproverRemark)
        GVnprkApvrApplications.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVnprkApvrApplications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVnprkApvrApplications.Init
    DataClassName = "GnprkApvrApplications"
    SetGridView = GVnprkApvrApplications
  End Sub
  Protected Sub TBLnprkApvrApplications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkApvrApplications.Init
    SetToolBar = TBLnprkApvrApplications
  End Sub
  Protected Sub F_EmployeeID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_EmployeeID.TextChanged
    Session("F_EmployeeID") = F_EmployeeID.Text
    Session("F_EmployeeID_Display") = F_EmployeeID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function EmployeeIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.NPRK.nprkEmployees.SelectnprkEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_PerkID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_PerkID.SelectedIndexChanged
    Session("F_PerkID") = F_PerkID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_EmployeeID_Display.Text = String.Empty
    If Not Session("F_EmployeeID_Display") Is Nothing Then
      If Session("F_EmployeeID_Display") <> String.Empty Then
        F_EmployeeID_Display.Text = Session("F_EmployeeID_Display")
      End If
    End If
    F_EmployeeID.Text = String.Empty
    If Not Session("F_EmployeeID") Is Nothing Then
      If Session("F_EmployeeID") <> String.Empty Then
        F_EmployeeID.Text = Session("F_EmployeeID")
      End If
    End If
    Dim strScriptEmployeeID As String = "<script type=""text/javascript""> " &
      "function ACEEmployeeID_Selected(sender, e) {" &
      "  var F_EmployeeID = $get('" & F_EmployeeID.ClientID & "');" &
      "  var F_EmployeeID_Display = $get('" & F_EmployeeID_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_EmployeeID.value = p[0];" &
      "  F_EmployeeID_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_EmployeeID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_EmployeeID", strScriptEmployeeID)
    End If
    Dim strScriptPopulatingEmployeeID As String = "<script type=""text/javascript""> " &
      "function ACEEmployeeID_Populating(o,e) {" &
      "  var p = $get('" & F_EmployeeID.ClientID & "');" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACEEmployeeID_Populated(o,e) {" &
      "  var p = $get('" & F_EmployeeID.ClientID & "');" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_EmployeeIDPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_EmployeeIDPopulating", strScriptPopulatingEmployeeID)
    End If
    F_PerkID.SelectedValue = String.Empty
    If Not Session("F_PerkID") Is Nothing Then
      If Session("F_PerkID") <> String.Empty Then
        F_PerkID.SelectedValue = Session("F_PerkID")
      End If
    End If
    Dim validateScriptEmployeeID As String = "<script type=""text/javascript"">" &
      "  function validate_EmployeeID(o) {" &
      "    validated_FK_PRK_Applications_PRK_Employees_main = true;" &
      "    validate_FK_PRK_Applications_PRK_Employees(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateEmployeeID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateEmployeeID", validateScriptEmployeeID)
    End If
    Dim validateScriptFK_PRK_Applications_PRK_Employees As String = "<script type=""text/javascript"">" &
      "  function validate_FK_PRK_Applications_PRK_Employees(o) {" &
      "    var value = o.id;" &
      "    var EmployeeID = $get('" & F_EmployeeID.ClientID & "');" &
      "    try{" &
      "    if(EmployeeID.value==''){" &
      "      if(validated_FK_PRK_Applications_PRK_Employees.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + EmployeeID.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_PRK_Applications_PRK_Employees(value, validated_FK_PRK_Applications_PRK_Employees);" &
      "  }" &
      "  validated_FK_PRK_Applications_PRK_Employees_main = false;" &
      "  function validated_FK_PRK_Applications_PRK_Employees(result) {" &
      "    var p = result.split('|');" &
      "    var o = $get(p[1]);" &
      "    var o_d = $get(p[1]+'_Display');" &
      "    try{o_d.innerHTML = p[2];}catch(ex){}" &
      "    o.style.backgroundImage  = 'none';" &
      "    if(p[0]=='1'){" &
      "      o.value='';" &
      "      try{o_d.innerHTML = '';}catch(ex){}" &
      "      __doPostBack(o.id, o.value);" &
      "    }" &
      "    else" &
      "      __doPostBack(o.id, o.value);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PRK_Applications_PRK_Employees") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PRK_Applications_PRK_Employees", validateScriptFK_PRK_Applications_PRK_Employees)
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PRK_Applications_PRK_Employees(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim EmployeeID As String = aVal(1)
    Dim oVar As SIS.NPRK.nprkEmployees = Nothing
    Try
      oVar = SIS.NPRK.nprkEmployees.nprkEmployeesGetByID(EmployeeID)
    Catch ex As Exception
    End Try
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function

  Private Sub UPGSnprkApvrApplications_DataBinding(sender As Object, e As EventArgs) Handles UPGSnprkApvrApplications.DataBinding
    GVnprkApvrApplications.DataBind()
  End Sub
  Private Sub lc_yeardate1_YearDateChanged(sender As Object, e As EventArgs) Handles lc_yeardate1.YearDateChanged
    UPNLnprkApvrApplications.DataBind()
  End Sub

End Class
