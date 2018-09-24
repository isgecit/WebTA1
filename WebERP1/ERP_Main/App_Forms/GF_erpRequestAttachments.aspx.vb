Partial Class GF_erpRequestAttachments
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ERP_Main/App_Display/DF_erpRequestAttachments.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ApplID=" & aVal(0) & "&RequestID=" & aVal(1) & "&SerialNo=" & aVal(2)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVerpRequestAttachments_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVerpRequestAttachments.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim ApplID As Int32 = GVerpRequestAttachments.DataKeys(e.CommandArgument).Values("ApplID")  
				Dim RequestID As Int32 = GVerpRequestAttachments.DataKeys(e.CommandArgument).Values("RequestID")  
				Dim SerialNo As Int32 = GVerpRequestAttachments.DataKeys(e.CommandArgument).Values("SerialNo")  
				Dim RedirectUrl As String = TBLerpRequestAttachments.EditUrl & "?ApplID=" & ApplID & "&RequestID=" & RequestID & "&SerialNo=" & SerialNo
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVerpRequestAttachments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVerpRequestAttachments.Init
    DataClassName = "GerpRequestAttachments"
    SetGridView = GVerpRequestAttachments
  End Sub
  Protected Sub TBLerpRequestAttachments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpRequestAttachments.Init
    SetToolBar = TBLerpRequestAttachments
  End Sub
  Protected Sub F_ApplID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ApplID.TextChanged
    Session("F_ApplID") = F_ApplID.Text
    Session("F_ApplID_Display") = F_ApplID_Display.Text
    InitGridPage()
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ApplIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ERP.erpApplications.SelecterpApplicationsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_RequestID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_RequestID.TextChanged
    Session("F_RequestID") = F_RequestID.Text
    Session("F_RequestID_Display") = F_RequestID_Display.Text
    InitGridPage()
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function RequestIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ERP.erpChaneRequest.SelecterpChaneRequestAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_ApplID_Display.Text = String.Empty
    If Not Session("F_ApplID_Display") Is Nothing Then
      If Session("F_ApplID_Display") <> String.Empty Then
        F_ApplID_Display.Text = Session("F_ApplID_Display")
      End If
    End If
    F_ApplID.Text = String.Empty
    If Not Session("F_ApplID") Is Nothing Then
      If Session("F_ApplID") <> String.Empty Then
        F_ApplID.Text = Session("F_ApplID")
      End If
    End If
		Dim strScriptApplID As String = "<script type=""text/javascript""> " & _
			"function ACEApplID_Selected(sender, e) {" & _
			"  var F_ApplID = $get('" & F_ApplID.ClientID & "');" & _
			"  var F_ApplID_Display = $get('" & F_ApplID_Display.ClientID & "');" & _
			"  var retval = e.get_value();" & _
			"  var p = retval.split('|');" & _
			"  F_ApplID.value = p[0];" & _
			"  F_ApplID_Display.innerHTML = e.get_text();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ApplID") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ApplID", strScriptApplID)
			End If
		Dim strScriptPopulatingApplID As String = "<script type=""text/javascript""> " & _
			"function ACEApplID_Populating(o,e) {" & _
			"  var p = $get('" & F_ApplID.ClientID & "');" & _
			"  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat= 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACEApplID_Populated(o,e) {" & _
			"  var p = $get('" & F_ApplID.ClientID & "');" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ApplIDPopulating") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ApplIDPopulating", strScriptPopulatingApplID)
			End If
    F_RequestID_Display.Text = String.Empty
    If Not Session("F_RequestID_Display") Is Nothing Then
      If Session("F_RequestID_Display") <> String.Empty Then
        F_RequestID_Display.Text = Session("F_RequestID_Display")
      End If
    End If
    F_RequestID.Text = String.Empty
    If Not Session("F_RequestID") Is Nothing Then
      If Session("F_RequestID") <> String.Empty Then
        F_RequestID.Text = Session("F_RequestID")
      End If
    End If
		Dim strScriptRequestID As String = "<script type=""text/javascript""> " & _
			"function ACERequestID_Selected(sender, e) {" & _
			"  var F_RequestID = $get('" & F_RequestID.ClientID & "');" & _
			"  var F_RequestID_Display = $get('" & F_RequestID_Display.ClientID & "');" & _
			"  var retval = e.get_value();" & _
			"  var p = retval.split('|');" & _
			"  F_RequestID.value = p[1];" & _
			"  F_RequestID_Display.innerHTML = e.get_text();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_RequestID") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_RequestID", strScriptRequestID)
			End If
		Dim strScriptPopulatingRequestID As String = "<script type=""text/javascript""> " & _
			"function ACERequestID_Populating(o,e) {" & _
			"  var p = $get('" & F_RequestID.ClientID & "');" & _
			"  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat= 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACERequestID_Populated(o,e) {" & _
			"  var p = $get('" & F_RequestID.ClientID & "');" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_RequestIDPopulating") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_RequestIDPopulating", strScriptPopulatingRequestID)
			End If
		Dim validateScriptApplID As String = "<script type=""text/javascript"">" & _
			"  function validate_ApplID(o) {" & _
			"    validated_FK_ERP_RequestAttachments_ApplID_main = true;" & _
			"    validate_FK_ERP_RequestAttachments_ApplID(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateApplID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateApplID", validateScriptApplID)
		End If
		Dim validateScriptRequestID As String = "<script type=""text/javascript"">" & _
			"  function validate_RequestID(o) {" & _
			"    validated_FK_ERP_RequestAttachments_ApplID_RequestID_main = true;" & _
			"    validate_FK_ERP_RequestAttachments_ApplID_RequestID(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateRequestID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateRequestID", validateScriptRequestID)
		End If
		Dim validateScriptFK_ERP_RequestAttachments_ApplID As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_ERP_RequestAttachments_ApplID(o) {" & _
			"    var value = o.id;" & _
			"    var ApplID = $get('" & F_ApplID.ClientID & "');" & _
			"    try{" & _
			"    if(ApplID.value==''){" & _
			"      if(validated_FK_ERP_RequestAttachments_ApplID.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + ApplID.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_ERP_RequestAttachments_ApplID(value, validated_FK_ERP_RequestAttachments_ApplID);" & _
			"  }" & _
			"  validated_FK_ERP_RequestAttachments_ApplID_main = false;" & _
			"  function validated_FK_ERP_RequestAttachments_ApplID(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ERP_RequestAttachments_ApplID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ERP_RequestAttachments_ApplID", validateScriptFK_ERP_RequestAttachments_ApplID)
		End If
		Dim validateScriptFK_ERP_RequestAttachments_ApplID_RequestID As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_ERP_RequestAttachments_ApplID_RequestID(o) {" & _
			"    var value = o.id;" & _
			"    var ApplID = $get('" & F_ApplID.ClientID & "');" & _
			"    try{" & _
			"    if(ApplID.value==''){" & _
			"      if(validated_FK_ERP_RequestAttachments_ApplID_RequestID.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + ApplID.value ;" & _
			"    }catch(ex){}" & _
			"    var RequestID = $get('" & F_RequestID.ClientID & "');" & _
			"    try{" & _
			"    if(RequestID.value==''){" & _
			"      if(validated_FK_ERP_RequestAttachments_ApplID_RequestID.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + RequestID.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_ERP_RequestAttachments_ApplID_RequestID(value, validated_FK_ERP_RequestAttachments_ApplID_RequestID);" & _
			"  }" & _
			"  validated_FK_ERP_RequestAttachments_ApplID_RequestID_main = false;" & _
			"  function validated_FK_ERP_RequestAttachments_ApplID_RequestID(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ERP_RequestAttachments_ApplID_RequestID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ERP_RequestAttachments_ApplID_RequestID", validateScriptFK_ERP_RequestAttachments_ApplID_RequestID)
		End If
  End Sub
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ERP_RequestAttachments_ApplID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim ApplID As Int32 = CType(aVal(1),Int32)
		Dim oVar As SIS.ERP.erpApplications = SIS.ERP.erpApplications.erpApplicationsGetByID(ApplID)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ERP_RequestAttachments_ApplID_RequestID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim ApplID As Int32 = CType(aVal(1),Int32)
		Dim RequestID As Int32 = CType(aVal(2),Int32)
		Dim oVar As SIS.ERP.erpChaneRequest = SIS.ERP.erpChaneRequest.erpChaneRequestGetByID(ApplID,RequestID)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
