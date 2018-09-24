Imports System.Web.Script.Serialization
Partial Class GF_nprkLedgerEntry
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/NPRK_Main/App_Display/DF_nprkLedgerEntry.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?DocumentID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVnprkLedgerEntry_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVnprkLedgerEntry.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim DocumentID As Int32 = GVnprkLedgerEntry.DataKeys(e.CommandArgument).Values("DocumentID")  
        Dim RedirectUrl As String = TBLnprkLedgerEntry.EditUrl & "?DocumentID=" & DocumentID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVnprkLedgerEntry_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVnprkLedgerEntry.Init
    DataClassName = "GnprkLedgerEntry"
    SetGridView = GVnprkLedgerEntry
  End Sub
  Protected Sub TBLnprkLedgerEntry_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkLedgerEntry.Init
    SetToolBar = TBLnprkLedgerEntry
  End Sub
  Protected Sub F_EmployeeID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_EmployeeID.TextChanged
    Session("F_EmployeeID") = F_EmployeeID.Text
    Session("F_EmployeeID_Display") = F_EmployeeID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
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
    Dim strScriptEmployeeID As String = "<script type=""text/javascript""> " & _
      "function ACEEmployeeID_Selected(sender, e) {" & _
      "  var F_EmployeeID = $get('" & F_EmployeeID.ClientID & "');" & _
      "  var F_EmployeeID_Display = $get('" & F_EmployeeID_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_EmployeeID.value = p[0];" & _
      "  F_EmployeeID_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_EmployeeID") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_EmployeeID", strScriptEmployeeID)
      End If
    Dim strScriptPopulatingEmployeeID As String = "<script type=""text/javascript""> " & _
      "function ACEEmployeeID_Populating(o,e) {" & _
      "  var p = $get('" & F_EmployeeID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEEmployeeID_Populated(o,e) {" & _
      "  var p = $get('" & F_EmployeeID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
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
    Dim validateScriptEmployeeID As String = "<script type=""text/javascript"">" & _
      "  function validate_EmployeeID(o) {" & _
      "    validated_FK_PRK_Ledger_PRK_Employees_main = true;" & _
      "    validate_FK_PRK_Ledger_PRK_Employees(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateEmployeeID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateEmployeeID", validateScriptEmployeeID)
    End If
    Dim validateScriptFK_PRK_Ledger_PRK_Employees As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PRK_Ledger_PRK_Employees(o) {" & _
      "    var value = o.id;" & _
      "    var EmployeeID = $get('" & F_EmployeeID.ClientID & "');" & _
      "    try{" & _
      "    if(EmployeeID.value==''){" & _
      "      if(validated_FK_PRK_Ledger_PRK_Employees.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + EmployeeID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PRK_Ledger_PRK_Employees(value, validated_FK_PRK_Ledger_PRK_Employees);" & _
      "  }" & _
      "  validated_FK_PRK_Ledger_PRK_Employees_main = false;" & _
      "  function validated_FK_PRK_Ledger_PRK_Employees(result) {" & _
      "    var p = result.split('|');" & _
      "    var o = $get(p[1]);" & _
      "    var o_d = $get(p[1]+'_Display');" & _
      "    try{o_d.innerHTML = p[2];}catch(ex){}" & _
      "    o.style.backgroundImage  = 'none';" & _
      "    if(p[0]=='1'){" & _
      "      o.value='';" & _
      "      try{o_d.innerHTML = '';}catch(ex){}" & _
      "      __doPostBack(o.id, o.value);" & _
      "    }" & _
      "    else" & _
      "      __doPostBack(o.id, o.value);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PRK_Ledger_PRK_Employees") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PRK_Ledger_PRK_Employees", validateScriptFK_PRK_Ledger_PRK_Employees)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PRK_Ledger_PRK_Employees(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim EmployeeID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.NPRK.nprkEmployees = SIS.NPRK.nprkEmployees.nprkEmployeesGetByID(EmployeeID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
