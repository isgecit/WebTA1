Partial Class RP_nprkEntitlementSheet
  Inherits System.Web.UI.Page
  Public Property EmployeeToDisplay() As String
    Get
      If ViewState("EmployeeToDisplay") IsNot Nothing Then
        Return ViewState("EmployeeToDisplay")
      End If
      Return "0"
    End Get
    Set(ByVal value As String)
      If value = "" Then value = "0"
      ViewState.Add("EmployeeToDisplay", value)
    End Set
  End Property
  Protected Sub F_EmployeeID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_EmployeeID.TextChanged
    EmployeeToDisplay = F_EmployeeID.Text
    Session("F_EmployeeID") = F_EmployeeID.Text
    Session("F_EmployeeID_Display") = F_EmployeeID_Display.Text
    DataList1.DataBind()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function EmployeeIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.NPRK.nprkEmployees.SelectnprkEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
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
  Protected Sub ShowPerkBalance(ByVal sender As Object, ByVal e As System.EventArgs)
    Dim oBal As LC_PrkBalance = CType(sender, LC_PrkBalance)
    If Not oBal Is Nothing Then
      oBal.EmployeeID = Session("F_EmployeeID")
      oBal.LoadData()
      If oBal.LedgerCount <= 0 And oBal.EntitlementsCount <= 0 Then
        Select Case oBal.PerkID
          Case prkPerk.Mobile, prkPerk.Telephone
            oBal.Visible = True
          Case Else
            oBal.Visible = False
        End Select
      End If
    End If
  End Sub

End Class
