Partial Class GF_eitlProjectWiseUser
  Inherits SIS.SYS.GridBase
  Protected Sub GVeitlProjectWiseUser_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVeitlProjectWiseUser.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int64 = GVeitlProjectWiseUser.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim RedirectUrl As String = TBLeitlProjectWiseUser.EditUrl & "?SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVeitlProjectWiseUser_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVeitlProjectWiseUser.Init
    DataClassName = "GeitlProjectWiseUser"
    SetGridView = GVeitlProjectWiseUser
  End Sub
  Protected Sub TBLeitlProjectWiseUser_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlProjectWiseUser.Init
    SetToolBar = TBLeitlProjectWiseUser
  End Sub
  Protected Sub F_UserID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_UserID.TextChanged
    Session("F_UserID") = F_UserID.Text
    Session("F_UserID_Display") = F_UserID_Display.Text
    InitGridPage()
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function UserIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_ProjectID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ProjectID.TextChanged
    Session("F_ProjectID") = F_ProjectID.Text
    Session("F_ProjectID_Display") = F_ProjectID_Display.Text
    InitGridPage()
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_UserID_Display.Text = String.Empty
    If Not Session("F_UserID_Display") Is Nothing Then
      If Session("F_UserID_Display") <> String.Empty Then
        F_UserID_Display.Text = Session("F_UserID_Display")
      End If
    End If
    F_UserID.Text = String.Empty
    If Not Session("F_UserID") Is Nothing Then
      If Session("F_UserID") <> String.Empty Then
        F_UserID.Text = Session("F_UserID")
      End If
    End If
		Dim strScriptUserID As String = "<script type=""text/javascript""> " & _
			"function ACEUserID_Selected(sender, e) {" & _
			"  var F_UserID = $get('" & F_UserID.ClientID & "');" & _
			"  var F_UserID_Display = $get('" & F_UserID_Display.ClientID & "');" & _
			"  var retval = e.get_value();" & _
			"  var p = retval.split('|');" & _
			"  F_UserID_Display.innerHTML = e.get_text();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_UserID") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_UserID", strScriptUserID)
			End If
		Dim strScriptPopulatingUserID As String = "<script type=""text/javascript""> " & _
			"function ACEUserID_Populating(o,e) {" & _
			"  var p = $get('" & F_UserID.ClientID & "');" & _
			"  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat= 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACEUserID_Populated(o,e) {" & _
			"  var p = $get('" & F_UserID.ClientID & "');" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_UserIDPopulating") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_UserIDPopulating", strScriptPopulatingUserID)
			End If
    F_ProjectID_Display.Text = String.Empty
    If Not Session("F_ProjectID_Display") Is Nothing Then
      If Session("F_ProjectID_Display") <> String.Empty Then
        F_ProjectID_Display.Text = Session("F_ProjectID_Display")
      End If
    End If
    F_ProjectID.Text = String.Empty
    If Not Session("F_ProjectID") Is Nothing Then
      If Session("F_ProjectID") <> String.Empty Then
        F_ProjectID.Text = Session("F_ProjectID")
      End If
    End If
		Dim strScriptProjectID As String = "<script type=""text/javascript""> " & _
			"function ACEProjectID_Selected(sender, e) {" & _
			"  var F_ProjectID = $get('" & F_ProjectID.ClientID & "');" & _
			"  var F_ProjectID_Display = $get('" & F_ProjectID_Display.ClientID & "');" & _
			"  var retval = e.get_value();" & _
			"  var p = retval.split('|');" & _
			"  F_ProjectID.value = p[0];" & _
			"  F_ProjectID_Display.innerHTML = e.get_text();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ProjectID") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ProjectID", strScriptProjectID)
			End If
		Dim strScriptPopulatingProjectID As String = "<script type=""text/javascript""> " & _
			"function ACEProjectID_Populating(o,e) {" & _
			"  var p = $get('" & F_ProjectID.ClientID & "');" & _
			"  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat= 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACEProjectID_Populated(o,e) {" & _
			"  var p = $get('" & F_ProjectID.ClientID & "');" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ProjectIDPopulating") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ProjectIDPopulating", strScriptPopulatingProjectID)
			End If
		Dim validateScriptUserID As String = "<script type=""text/javascript"">" & _
			"  function validate_UserID(o) {" & _
			"    validated_FK_EITL_ProjectWiseUser_UserID_main = true;" & _
			"    validate_FK_EITL_ProjectWiseUser_UserID(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateUserID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateUserID", validateScriptUserID)
		End If
		Dim validateScriptProjectID As String = "<script type=""text/javascript"">" & _
			"  function validate_ProjectID(o) {" & _
			"    validated_FK_EITL_ProjectWiseUser_ProjectID_main = true;" & _
			"    validate_FK_EITL_ProjectWiseUser_ProjectID(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateProjectID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateProjectID", validateScriptProjectID)
		End If
		Dim validateScriptFK_EITL_ProjectWiseUser_UserID As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_EITL_ProjectWiseUser_UserID(o) {" & _
			"    var value = o.id;" & _
			"    var UserID = $get('" & F_UserID.ClientID & "');" & _
			"    try{" & _
			"    if(UserID.value==''){" & _
			"      if(validated_FK_EITL_ProjectWiseUser_UserID.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + UserID.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_EITL_ProjectWiseUser_UserID(value, validated_FK_EITL_ProjectWiseUser_UserID);" & _
			"  }" & _
			"  validated_FK_EITL_ProjectWiseUser_UserID_main = false;" & _
			"  function validated_FK_EITL_ProjectWiseUser_UserID(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_EITL_ProjectWiseUser_UserID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_EITL_ProjectWiseUser_UserID", validateScriptFK_EITL_ProjectWiseUser_UserID)
		End If
		Dim validateScriptFK_EITL_ProjectWiseUser_ProjectID As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_EITL_ProjectWiseUser_ProjectID(o) {" & _
			"    var value = o.id;" & _
			"    var ProjectID = $get('" & F_ProjectID.ClientID & "');" & _
			"    try{" & _
			"    if(ProjectID.value==''){" & _
			"      if(validated_FK_EITL_ProjectWiseUser_ProjectID.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + ProjectID.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_EITL_ProjectWiseUser_ProjectID(value, validated_FK_EITL_ProjectWiseUser_ProjectID);" & _
			"  }" & _
			"  validated_FK_EITL_ProjectWiseUser_ProjectID_main = false;" & _
			"  function validated_FK_EITL_ProjectWiseUser_ProjectID(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_EITL_ProjectWiseUser_ProjectID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_EITL_ProjectWiseUser_ProjectID", validateScriptFK_EITL_ProjectWiseUser_ProjectID)
		End If
  End Sub
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_EITL_ProjectWiseUser_UserID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim UserID As String = CType(aVal(1),String)
		Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(UserID)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_EITL_ProjectWiseUser_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim ProjectID As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
