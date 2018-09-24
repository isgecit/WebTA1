Partial Class GF_erpApprovalByHOD
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ERP_Main/App_Display/DF_erpApprovalByHOD.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ApplID=" & aVal(0) & "&RequestID=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVerpApprovalByHOD_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVerpApprovalByHOD.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim ApplID As Int32 = GVerpApprovalByHOD.DataKeys(e.CommandArgument).Values("ApplID")  
				Dim RequestID As Int32 = GVerpApprovalByHOD.DataKeys(e.CommandArgument).Values("RequestID")  
				Dim RedirectUrl As String = TBLerpApprovalByHOD.EditUrl & "?ApplID=" & ApplID & "&RequestID=" & RequestID
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
		If e.CommandName.ToLower = "approvewf".ToLower Then
			Try
				Dim ReturnRemarks As String = CType(GVerpApprovalByHOD.Rows(e.CommandArgument).FindControl("F_ReturnRemarks"),TextBox).Text
				Dim ApplID As Int32 = GVerpApprovalByHOD.DataKeys(e.CommandArgument).Values("ApplID")  
				Dim RequestID As Int32 = GVerpApprovalByHOD.DataKeys(e.CommandArgument).Values("RequestID")  
				SIS.ERP.erpApprovalByHOD.ApproveWF(ApplID, RequestID, ReturnRemarks)
				GVerpApprovalByHOD.DataBind()
			Catch ex As Exception
			End Try
		End If
		If e.CommandName.ToLower = "rejectwf".ToLower Then
			Try
				Dim ReturnRemarks As String = CType(GVerpApprovalByHOD.Rows(e.CommandArgument).FindControl("F_ReturnRemarks"),TextBox).Text
				Dim ApplID As Int32 = GVerpApprovalByHOD.DataKeys(e.CommandArgument).Values("ApplID")  
				Dim RequestID As Int32 = GVerpApprovalByHOD.DataKeys(e.CommandArgument).Values("RequestID")  
				SIS.ERP.erpApprovalByHOD.RejectWF(ApplID, RequestID, ReturnRemarks)
				GVerpApprovalByHOD.DataBind()
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVerpApprovalByHOD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVerpApprovalByHOD.Init
    DataClassName = "GerpApprovalByHOD"
    SetGridView = GVerpApprovalByHOD
  End Sub
  Protected Sub TBLerpApprovalByHOD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpApprovalByHOD.Init
    SetToolBar = TBLerpApprovalByHOD
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
  Protected Sub F_RequestedBy_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_RequestedBy.TextChanged
    Session("F_RequestedBy") = F_RequestedBy.Text
    Session("F_RequestedBy_Display") = F_RequestedBy_Display.Text
    InitGridPage()
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function RequestedByCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_RequestTypeID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_RequestTypeID.SelectedIndexChanged
    Session("F_RequestTypeID") = F_RequestTypeID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_StatusID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_StatusID.SelectedIndexChanged
    Session("F_StatusID") = F_StatusID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_PriorityID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_PriorityID.SelectedIndexChanged
    Session("F_PriorityID") = F_PriorityID.SelectedValue
    InitGridPage()
  End Sub
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
    F_RequestedBy_Display.Text = String.Empty
    If Not Session("F_RequestedBy_Display") Is Nothing Then
      If Session("F_RequestedBy_Display") <> String.Empty Then
        F_RequestedBy_Display.Text = Session("F_RequestedBy_Display")
      End If
    End If
    F_RequestedBy.Text = String.Empty
    If Not Session("F_RequestedBy") Is Nothing Then
      If Session("F_RequestedBy") <> String.Empty Then
        F_RequestedBy.Text = Session("F_RequestedBy")
      End If
    End If
		Dim strScriptRequestedBy As String = "<script type=""text/javascript""> " & _
			"function ACERequestedBy_Selected(sender, e) {" & _
			"  var F_RequestedBy = $get('" & F_RequestedBy.ClientID & "');" & _
			"  var F_RequestedBy_Display = $get('" & F_RequestedBy_Display.ClientID & "');" & _
			"  var retval = e.get_value();" & _
			"  var p = retval.split('|');" & _
			"  F_RequestedBy_Display.innerHTML = e.get_text();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_RequestedBy") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_RequestedBy", strScriptRequestedBy)
			End If
		Dim strScriptPopulatingRequestedBy As String = "<script type=""text/javascript""> " & _
			"function ACERequestedBy_Populating(o,e) {" & _
			"  var p = $get('" & F_RequestedBy.ClientID & "');" & _
			"  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat= 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACERequestedBy_Populated(o,e) {" & _
			"  var p = $get('" & F_RequestedBy.ClientID & "');" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_RequestedByPopulating") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_RequestedByPopulating", strScriptPopulatingRequestedBy)
			End If
    F_RequestTypeID.SelectedValue = String.Empty
    If Not Session("F_RequestTypeID") Is Nothing Then
      If Session("F_RequestTypeID") <> String.Empty Then
        F_RequestTypeID.SelectedValue = Session("F_RequestTypeID")
      End If
    End If
    F_StatusID.SelectedValue = String.Empty
    If Not Session("F_StatusID") Is Nothing Then
      If Session("F_StatusID") <> String.Empty Then
        F_StatusID.SelectedValue = Session("F_StatusID")
      End If
    End If
    F_PriorityID.SelectedValue = String.Empty
    If Not Session("F_PriorityID") Is Nothing Then
      If Session("F_PriorityID") <> String.Empty Then
        F_PriorityID.SelectedValue = Session("F_PriorityID")
      End If
    End If
		Dim validateScriptApplID As String = "<script type=""text/javascript"">" & _
			"  function validate_ApplID(o) {" & _
			"    validated_FK_ERP_ChaneRequest_ApplID_main = true;" & _
			"    validate_FK_ERP_ChaneRequest_ApplID(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateApplID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateApplID", validateScriptApplID)
		End If
		Dim validateScriptRequestedBy As String = "<script type=""text/javascript"">" & _
			"  function validate_RequestedBy(o) {" & _
			"    validated_FK_ERP_ChaneRequest_RequestedBy_main = true;" & _
			"    validate_FK_ERP_ChaneRequest_RequestedBy(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateRequestedBy") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateRequestedBy", validateScriptRequestedBy)
		End If
		Dim validateScriptRequestTypeID As String = "<script type=""text/javascript"">" & _
			"  function validate_RequestTypeID(o) {" & _
			"    validated_FK_ERP_ChaneRequest_RequestTypeID_main = true;" & _
			"    validate_FK_ERP_ChaneRequest_RequestTypeID(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateRequestTypeID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateRequestTypeID", validateScriptRequestTypeID)
		End If
		Dim validateScriptStatusID As String = "<script type=""text/javascript"">" & _
			"  function validate_StatusID(o) {" & _
			"    validated_FK_ERP_ChaneRequest_StatusID_main = true;" & _
			"    validate_FK_ERP_ChaneRequest_StatusID(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateStatusID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateStatusID", validateScriptStatusID)
		End If
		Dim validateScriptPriorityID As String = "<script type=""text/javascript"">" & _
			"  function validate_PriorityID(o) {" & _
			"    validated_FK_ERP_ChaneRequest_PriorityID_main = true;" & _
			"    validate_FK_ERP_ChaneRequest_PriorityID(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validatePriorityID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validatePriorityID", validateScriptPriorityID)
		End If
		Dim validateScriptFK_ERP_ChaneRequest_RequestedBy As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_ERP_ChaneRequest_RequestedBy(o) {" & _
			"    var value = o.id;" & _
			"    var RequestedBy = $get('" & F_RequestedBy.ClientID & "');" & _
			"    try{" & _
			"    if(RequestedBy.value==''){" & _
			"      if(validated_FK_ERP_ChaneRequest_RequestedBy.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + RequestedBy.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_ERP_ChaneRequest_RequestedBy(value, validated_FK_ERP_ChaneRequest_RequestedBy);" & _
			"  }" & _
			"  validated_FK_ERP_ChaneRequest_RequestedBy_main = false;" & _
			"  function validated_FK_ERP_ChaneRequest_RequestedBy(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ERP_ChaneRequest_RequestedBy") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ERP_ChaneRequest_RequestedBy", validateScriptFK_ERP_ChaneRequest_RequestedBy)
		End If
		Dim validateScriptFK_ERP_ChaneRequest_ApplID As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_ERP_ChaneRequest_ApplID(o) {" & _
			"    var value = o.id;" & _
			"    var ApplID = $get('" & F_ApplID.ClientID & "');" & _
			"    try{" & _
			"    if(ApplID.value==''){" & _
			"      if(validated_FK_ERP_ChaneRequest_ApplID.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + ApplID.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_ERP_ChaneRequest_ApplID(value, validated_FK_ERP_ChaneRequest_ApplID);" & _
			"  }" & _
			"  validated_FK_ERP_ChaneRequest_ApplID_main = false;" & _
			"  function validated_FK_ERP_ChaneRequest_ApplID(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ERP_ChaneRequest_ApplID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ERP_ChaneRequest_ApplID", validateScriptFK_ERP_ChaneRequest_ApplID)
		End If
		Dim validateScriptFK_ERP_ChaneRequest_PriorityID As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_ERP_ChaneRequest_PriorityID(o) {" & _
			"    var value = o.id;" & _
			"    var PriorityID = $get('" & F_PriorityID.ClientID & "');" & _
			"    try{" & _
			"    if(PriorityID.value==''){" & _
			"      if(validated_FK_ERP_ChaneRequest_PriorityID.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + PriorityID.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_ERP_ChaneRequest_PriorityID(value, validated_FK_ERP_ChaneRequest_PriorityID);" & _
			"  }" & _
			"  validated_FK_ERP_ChaneRequest_PriorityID_main = false;" & _
			"  function validated_FK_ERP_ChaneRequest_PriorityID(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ERP_ChaneRequest_PriorityID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ERP_ChaneRequest_PriorityID", validateScriptFK_ERP_ChaneRequest_PriorityID)
		End If
		Dim validateScriptFK_ERP_ChaneRequest_StatusID As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_ERP_ChaneRequest_StatusID(o) {" & _
			"    var value = o.id;" & _
			"    var StatusID = $get('" & F_StatusID.ClientID & "');" & _
			"    try{" & _
			"    if(StatusID.value==''){" & _
			"      if(validated_FK_ERP_ChaneRequest_StatusID.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + StatusID.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_ERP_ChaneRequest_StatusID(value, validated_FK_ERP_ChaneRequest_StatusID);" & _
			"  }" & _
			"  validated_FK_ERP_ChaneRequest_StatusID_main = false;" & _
			"  function validated_FK_ERP_ChaneRequest_StatusID(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ERP_ChaneRequest_StatusID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ERP_ChaneRequest_StatusID", validateScriptFK_ERP_ChaneRequest_StatusID)
		End If
		Dim validateScriptFK_ERP_ChaneRequest_RequestTypeID As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_ERP_ChaneRequest_RequestTypeID(o) {" & _
			"    var value = o.id;" & _
			"    var RequestTypeID = $get('" & F_RequestTypeID.ClientID & "');" & _
			"    try{" & _
			"    if(RequestTypeID.value==''){" & _
			"      if(validated_FK_ERP_ChaneRequest_RequestTypeID.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + RequestTypeID.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_ERP_ChaneRequest_RequestTypeID(value, validated_FK_ERP_ChaneRequest_RequestTypeID);" & _
			"  }" & _
			"  validated_FK_ERP_ChaneRequest_RequestTypeID_main = false;" & _
			"  function validated_FK_ERP_ChaneRequest_RequestTypeID(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ERP_ChaneRequest_RequestTypeID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ERP_ChaneRequest_RequestTypeID", validateScriptFK_ERP_ChaneRequest_RequestTypeID)
		End If
  End Sub
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ERP_ChaneRequest_RequestedBy(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim RequestedBy As String = CType(aVal(1),String)
		Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(RequestedBy)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ERP_ChaneRequest_ApplID(ByVal value As String) As String
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
  Public Shared Function validate_FK_ERP_ChaneRequest_PriorityID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim PriorityID As Int32 = CType(aVal(1),Int32)
		Dim oVar As SIS.ERP.erpRequestPriority = SIS.ERP.erpRequestPriority.erpRequestPriorityGetByID(PriorityID)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ERP_ChaneRequest_StatusID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim StatusID As Int32 = CType(aVal(1),Int32)
		Dim oVar As SIS.ERP.erpRequestStatus = SIS.ERP.erpRequestStatus.erpRequestStatusGetByID(StatusID)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ERP_ChaneRequest_RequestTypeID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim RequestTypeID As Int32 = CType(aVal(1),Int32)
		Dim oVar As SIS.ERP.erpRequestTypes = SIS.ERP.erpRequestTypes.erpRequestTypesGetByID(RequestTypeID)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
