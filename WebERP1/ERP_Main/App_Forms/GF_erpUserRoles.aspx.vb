Partial Class GF_erpUserRoles
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ERP_Main/App_Display/DF_erpUserRoles.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SerialNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVerpUserRoles_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVerpUserRoles.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim SerialNo As Int32 = GVerpUserRoles.DataKeys(e.CommandArgument).Values("SerialNo")  
				Dim RedirectUrl As String = TBLerpUserRoles.EditUrl & "?SerialNo=" & SerialNo
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVerpUserRoles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVerpUserRoles.Init
    DataClassName = "GerpUserRoles"
    SetGridView = GVerpUserRoles
  End Sub
  Protected Sub TBLerpUserRoles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpUserRoles.Init
    SetToolBar = TBLerpUserRoles
  End Sub
  Protected Sub F_RequesterID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_RequesterID.TextChanged
    Session("F_RequesterID") = F_RequesterID.Text
    Session("F_RequesterID_Display") = F_RequesterID_Display.Text
    InitGridPage()
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function RequesterIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_ApproverID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ApproverID.TextChanged
    Session("F_ApproverID") = F_ApproverID.Text
    Session("F_ApproverID_Display") = F_ApproverID_Display.Text
    InitGridPage()
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ApproverIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_RoleID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_RoleID.SelectedIndexChanged
    Session("F_RoleID") = F_RoleID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_RequesterID_Display.Text = String.Empty
    If Not Session("F_RequesterID_Display") Is Nothing Then
      If Session("F_RequesterID_Display") <> String.Empty Then
        F_RequesterID_Display.Text = Session("F_RequesterID_Display")
      End If
    End If
    F_RequesterID.Text = String.Empty
    If Not Session("F_RequesterID") Is Nothing Then
      If Session("F_RequesterID") <> String.Empty Then
        F_RequesterID.Text = Session("F_RequesterID")
      End If
    End If
		Dim strScriptRequesterID As String = "<script type=""text/javascript""> " & _
			"function ACERequesterID_Selected(sender, e) {" & _
			"  var F_RequesterID = $get('" & F_RequesterID.ClientID & "');" & _
			"  var F_RequesterID_Display = $get('" & F_RequesterID_Display.ClientID & "');" & _
			"  var retval = e.get_value();" & _
			"  var p = retval.split('|');" & _
			"  F_RequesterID.value = p[0];" & _
			"  F_RequesterID_Display.innerHTML = e.get_text();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_RequesterID") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_RequesterID", strScriptRequesterID)
			End If
		Dim strScriptPopulatingRequesterID As String = "<script type=""text/javascript""> " & _
			"function ACERequesterID_Populating(o,e) {" & _
			"  var p = $get('" & F_RequesterID.ClientID & "');" & _
			"  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat= 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACERequesterID_Populated(o,e) {" & _
			"  var p = $get('" & F_RequesterID.ClientID & "');" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_RequesterIDPopulating") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_RequesterIDPopulating", strScriptPopulatingRequesterID)
			End If
    F_ApproverID_Display.Text = String.Empty
    If Not Session("F_ApproverID_Display") Is Nothing Then
      If Session("F_ApproverID_Display") <> String.Empty Then
        F_ApproverID_Display.Text = Session("F_ApproverID_Display")
      End If
    End If
    F_ApproverID.Text = String.Empty
    If Not Session("F_ApproverID") Is Nothing Then
      If Session("F_ApproverID") <> String.Empty Then
        F_ApproverID.Text = Session("F_ApproverID")
      End If
    End If
		Dim strScriptApproverID As String = "<script type=""text/javascript""> " & _
			"function ACEApproverID_Selected(sender, e) {" & _
			"  var F_ApproverID = $get('" & F_ApproverID.ClientID & "');" & _
			"  var F_ApproverID_Display = $get('" & F_ApproverID_Display.ClientID & "');" & _
			"  var retval = e.get_value();" & _
			"  var p = retval.split('|');" & _
			"  F_ApproverID.value = p[0];" & _
			"  F_ApproverID_Display.innerHTML = e.get_text();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ApproverID") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ApproverID", strScriptApproverID)
			End If
		Dim strScriptPopulatingApproverID As String = "<script type=""text/javascript""> " & _
			"function ACEApproverID_Populating(o,e) {" & _
			"  var p = $get('" & F_ApproverID.ClientID & "');" & _
			"  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat= 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACEApproverID_Populated(o,e) {" & _
			"  var p = $get('" & F_ApproverID.ClientID & "');" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ApproverIDPopulating") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ApproverIDPopulating", strScriptPopulatingApproverID)
			End If
    F_RoleID.SelectedValue = String.Empty
    If Not Session("F_RoleID") Is Nothing Then
      If Session("F_RoleID") <> String.Empty Then
        F_RoleID.SelectedValue = Session("F_RoleID")
      End If
    End If
		Dim validateScriptRequesterID As String = "<script type=""text/javascript"">" & _
			"  function validate_RequesterID(o) {" & _
			"    validated_FK_ERP_UserRoles_RequesterID_main = true;" & _
			"    validate_FK_ERP_UserRoles_RequesterID(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateRequesterID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateRequesterID", validateScriptRequesterID)
		End If
		Dim validateScriptApproverID As String = "<script type=""text/javascript"">" & _
			"  function validate_ApproverID(o) {" & _
			"    validated_FK_ERP_UserRoles_ApproverID_main = true;" & _
			"    validate_FK_ERP_UserRoles_ApproverID(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateApproverID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateApproverID", validateScriptApproverID)
		End If
		Dim validateScriptRoleID As String = "<script type=""text/javascript"">" & _
			"  function validate_RoleID(o) {" & _
			"    validated_FK_ERP_UserRoles_RoleID_main = true;" & _
			"    validate_FK_ERP_UserRoles_RoleID(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateRoleID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateRoleID", validateScriptRoleID)
		End If
		Dim validateScriptFK_ERP_UserRoles_RequesterID As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_ERP_UserRoles_RequesterID(o) {" & _
			"    var value = o.id;" & _
			"    var RequesterID = $get('" & F_RequesterID.ClientID & "');" & _
			"    try{" & _
			"    if(RequesterID.value==''){" & _
			"      if(validated_FK_ERP_UserRoles_RequesterID.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + RequesterID.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_ERP_UserRoles_RequesterID(value, validated_FK_ERP_UserRoles_RequesterID);" & _
			"  }" & _
			"  validated_FK_ERP_UserRoles_RequesterID_main = false;" & _
			"  function validated_FK_ERP_UserRoles_RequesterID(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ERP_UserRoles_RequesterID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ERP_UserRoles_RequesterID", validateScriptFK_ERP_UserRoles_RequesterID)
		End If
		Dim validateScriptFK_ERP_UserRoles_ApproverID As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_ERP_UserRoles_ApproverID(o) {" & _
			"    var value = o.id;" & _
			"    var ApproverID = $get('" & F_ApproverID.ClientID & "');" & _
			"    try{" & _
			"    if(ApproverID.value==''){" & _
			"      if(validated_FK_ERP_UserRoles_ApproverID.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + ApproverID.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_ERP_UserRoles_ApproverID(value, validated_FK_ERP_UserRoles_ApproverID);" & _
			"  }" & _
			"  validated_FK_ERP_UserRoles_ApproverID_main = false;" & _
			"  function validated_FK_ERP_UserRoles_ApproverID(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ERP_UserRoles_ApproverID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ERP_UserRoles_ApproverID", validateScriptFK_ERP_UserRoles_ApproverID)
		End If
		Dim validateScriptFK_ERP_UserRoles_RoleID As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_ERP_UserRoles_RoleID(o) {" & _
			"    var value = o.id;" & _
			"    var RoleID = $get('" & F_RoleID.ClientID & "');" & _
			"    try{" & _
			"    if(RoleID.value==''){" & _
			"      if(validated_FK_ERP_UserRoles_RoleID.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + RoleID.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_ERP_UserRoles_RoleID(value, validated_FK_ERP_UserRoles_RoleID);" & _
			"  }" & _
			"  validated_FK_ERP_UserRoles_RoleID_main = false;" & _
			"  function validated_FK_ERP_UserRoles_RoleID(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ERP_UserRoles_RoleID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ERP_UserRoles_RoleID", validateScriptFK_ERP_UserRoles_RoleID)
		End If
  End Sub
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ERP_UserRoles_RequesterID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim RequesterID As String = CType(aVal(1),String)
		Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(RequesterID)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ERP_UserRoles_ApproverID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim ApproverID As String = CType(aVal(1),String)
		Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(ApproverID)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ERP_UserRoles_RoleID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim RoleID As Int32 = CType(aVal(1),Int32)
		Dim oVar As SIS.ERP.erpRoles = SIS.ERP.erpRoles.erpRolesGetByID(RoleID)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
