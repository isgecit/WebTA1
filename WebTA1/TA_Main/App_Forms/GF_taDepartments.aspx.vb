Partial Class GF_taDepartments
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TA_Main/App_Display/DF_taDepartments.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?DepartmentID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtaDepartments_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaDepartments.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim DepartmentID As String = GVtaDepartments.DataKeys(e.CommandArgument).Values("DepartmentID")  
        Dim RedirectUrl As String = TBLtaDepartments.EditUrl & "?DepartmentID=" & DepartmentID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtaDepartments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaDepartments.Init
    DataClassName = "GtaDepartments"
    SetGridView = GVtaDepartments
  End Sub
  Protected Sub TBLtaDepartments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaDepartments.Init
    SetToolBar = TBLtaDepartments
  End Sub
  Protected Sub F_DepartmentHead_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_DepartmentHead.TextChanged
    Session("F_DepartmentHead") = F_DepartmentHead.Text
    Session("F_DepartmentHead_Display") = F_DepartmentHead_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function DepartmentHeadCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taEmployees.SelecttaEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_BusinessHead_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_BusinessHead.TextChanged
    Session("F_BusinessHead") = F_BusinessHead.Text
    Session("F_BusinessHead_Display") = F_BusinessHead_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function BusinessHeadCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taEmployees.SelecttaEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_DepartmentHead_Display.Text = String.Empty
    If Not Session("F_DepartmentHead_Display") Is Nothing Then
      If Session("F_DepartmentHead_Display") <> String.Empty Then
        F_DepartmentHead_Display.Text = Session("F_DepartmentHead_Display")
      End If
    End If
    F_DepartmentHead.Text = String.Empty
    If Not Session("F_DepartmentHead") Is Nothing Then
      If Session("F_DepartmentHead") <> String.Empty Then
        F_DepartmentHead.Text = Session("F_DepartmentHead")
      End If
    End If
    Dim strScriptDepartmentHead As String = "<script type=""text/javascript""> " & _
      "function ACEDepartmentHead_Selected(sender, e) {" & _
      "  var F_DepartmentHead = $get('" & F_DepartmentHead.ClientID & "');" & _
      "  var F_DepartmentHead_Display = $get('" & F_DepartmentHead_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_DepartmentHead.value = p[0];" & _
      "  F_DepartmentHead_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_DepartmentHead") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_DepartmentHead", strScriptDepartmentHead)
      End If
    Dim strScriptPopulatingDepartmentHead As String = "<script type=""text/javascript""> " & _
      "function ACEDepartmentHead_Populating(o,e) {" & _
      "  var p = $get('" & F_DepartmentHead.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEDepartmentHead_Populated(o,e) {" & _
      "  var p = $get('" & F_DepartmentHead.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_DepartmentHeadPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_DepartmentHeadPopulating", strScriptPopulatingDepartmentHead)
      End If
    F_BusinessHead_Display.Text = String.Empty
    If Not Session("F_BusinessHead_Display") Is Nothing Then
      If Session("F_BusinessHead_Display") <> String.Empty Then
        F_BusinessHead_Display.Text = Session("F_BusinessHead_Display")
      End If
    End If
    F_BusinessHead.Text = String.Empty
    If Not Session("F_BusinessHead") Is Nothing Then
      If Session("F_BusinessHead") <> String.Empty Then
        F_BusinessHead.Text = Session("F_BusinessHead")
      End If
    End If
    Dim strScriptBusinessHead As String = "<script type=""text/javascript""> " & _
      "function ACEBusinessHead_Selected(sender, e) {" & _
      "  var F_BusinessHead = $get('" & F_BusinessHead.ClientID & "');" & _
      "  var F_BusinessHead_Display = $get('" & F_BusinessHead_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_BusinessHead.value = p[0];" & _
      "  F_BusinessHead_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_BusinessHead") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_BusinessHead", strScriptBusinessHead)
      End If
    Dim strScriptPopulatingBusinessHead As String = "<script type=""text/javascript""> " & _
      "function ACEBusinessHead_Populating(o,e) {" & _
      "  var p = $get('" & F_BusinessHead.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEBusinessHead_Populated(o,e) {" & _
      "  var p = $get('" & F_BusinessHead.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_BusinessHeadPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_BusinessHeadPopulating", strScriptPopulatingBusinessHead)
      End If
    Dim validateScriptDepartmentHead As String = "<script type=""text/javascript"">" & _
      "  function validate_DepartmentHead(o) {" & _
      "    validated_FK_HRM_Departments_DepartmentHead_main = true;" & _
      "    validate_FK_HRM_Departments_DepartmentHead(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateDepartmentHead") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateDepartmentHead", validateScriptDepartmentHead)
    End If
    Dim validateScriptBusinessHead As String = "<script type=""text/javascript"">" & _
      "  function validate_BusinessHead(o) {" & _
      "    validated_FK_HRM_Departments_BusinessHead_main = true;" & _
      "    validate_FK_HRM_Departments_BusinessHead(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateBusinessHead") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateBusinessHead", validateScriptBusinessHead)
    End If
    Dim validateScriptFK_HRM_Departments_BusinessHead As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_HRM_Departments_BusinessHead(o) {" & _
      "    var value = o.id;" & _
      "    var BusinessHead = $get('" & F_BusinessHead.ClientID & "');" & _
      "    try{" & _
      "    if(BusinessHead.value==''){" & _
      "      if(validated_FK_HRM_Departments_BusinessHead.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + BusinessHead.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_HRM_Departments_BusinessHead(value, validated_FK_HRM_Departments_BusinessHead);" & _
      "  }" & _
      "  validated_FK_HRM_Departments_BusinessHead_main = false;" & _
      "  function validated_FK_HRM_Departments_BusinessHead(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_HRM_Departments_BusinessHead") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_HRM_Departments_BusinessHead", validateScriptFK_HRM_Departments_BusinessHead)
    End If
    Dim validateScriptFK_HRM_Departments_DepartmentHead As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_HRM_Departments_DepartmentHead(o) {" & _
      "    var value = o.id;" & _
      "    var DepartmentHead = $get('" & F_DepartmentHead.ClientID & "');" & _
      "    try{" & _
      "    if(DepartmentHead.value==''){" & _
      "      if(validated_FK_HRM_Departments_DepartmentHead.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + DepartmentHead.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_HRM_Departments_DepartmentHead(value, validated_FK_HRM_Departments_DepartmentHead);" & _
      "  }" & _
      "  validated_FK_HRM_Departments_DepartmentHead_main = false;" & _
      "  function validated_FK_HRM_Departments_DepartmentHead(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_HRM_Departments_DepartmentHead") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_HRM_Departments_DepartmentHead", validateScriptFK_HRM_Departments_DepartmentHead)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_HRM_Departments_BusinessHead(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim BusinessHead As String = CType(aVal(1),String)
    Dim oVar As SIS.TA.taEmployees = SIS.TA.taEmployees.taEmployeesGetByID(BusinessHead)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_HRM_Departments_DepartmentHead(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim DepartmentHead As String = CType(aVal(1),String)
    Dim oVar As SIS.TA.taEmployees = SIS.TA.taEmployees.taEmployeesGetByID(DepartmentHead)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
