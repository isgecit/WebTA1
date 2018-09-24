Partial Class GF_eitlIssuedPO
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/EITL_Main/App_Display/DF_eitlIssuedPO.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SerialNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVeitlIssuedPO_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVeitlIssuedPO.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim SerialNo As Int32 = GVeitlIssuedPO.DataKeys(e.CommandArgument).Values("SerialNo")  
				Dim RedirectUrl As String = TBLeitlIssuedPO.EditUrl & "?SerialNo=" & SerialNo
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVeitlIssuedPO_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVeitlIssuedPO.Init
    DataClassName = "GeitlIssuedPO"
    SetGridView = GVeitlIssuedPO
  End Sub
  Protected Sub TBLeitlIssuedPO_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlIssuedPO.Init
    SetToolBar = TBLeitlIssuedPO
  End Sub
  Protected Sub F_SupplierID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_SupplierID.TextChanged
    Session("F_SupplierID") = F_SupplierID.Text
    Session("F_SupplierID_Display") = F_SupplierID_Display.Text
    InitGridPage()
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SupplierIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.EITL.eitlSuppliers.SelecteitlSuppliersAutoCompleteList(prefixText, count, contextKey)
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
  Protected Sub F_BuyerID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_BuyerID.TextChanged
    Session("F_BuyerID") = F_BuyerID.Text
    Session("F_BuyerID_Display") = F_BuyerID_Display.Text
    InitGridPage()
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function BuyerIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_POStatusID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_POStatusID.TextChanged
    Session("F_POStatusID") = F_POStatusID.Text
    Session("F_POStatusID_Display") = F_POStatusID_Display.Text
    InitGridPage()
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function POStatusIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.EITL.eitlPOStatus.SelecteitlPOStatusAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_SupplierID_Display.Text = String.Empty
    If Not Session("F_SupplierID_Display") Is Nothing Then
      If Session("F_SupplierID_Display") <> String.Empty Then
        F_SupplierID_Display.Text = Session("F_SupplierID_Display")
      End If
    End If
    F_SupplierID.Text = String.Empty
    If Not Session("F_SupplierID") Is Nothing Then
      If Session("F_SupplierID") <> String.Empty Then
        F_SupplierID.Text = Session("F_SupplierID")
      End If
    End If
		Dim strScriptSupplierID As String = "<script type=""text/javascript""> " & _
			"function ACESupplierID_Selected(sender, e) {" & _
			"  var F_SupplierID = $get('" & F_SupplierID.ClientID & "');" & _
			"  var F_SupplierID_Display = $get('" & F_SupplierID_Display.ClientID & "');" & _
			"  var retval = e.get_value();" & _
			"  var p = retval.split('|');" & _
			"  F_SupplierID.value = p[0];" & _
			"  F_SupplierID_Display.innerHTML = e.get_text();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_SupplierID") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_SupplierID", strScriptSupplierID)
			End If
		Dim strScriptPopulatingSupplierID As String = "<script type=""text/javascript""> " & _
			"function ACESupplierID_Populating(o,e) {" & _
			"  var p = $get('" & F_SupplierID.ClientID & "');" & _
			"  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat= 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACESupplierID_Populated(o,e) {" & _
			"  var p = $get('" & F_SupplierID.ClientID & "');" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_SupplierIDPopulating") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_SupplierIDPopulating", strScriptPopulatingSupplierID)
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
    F_BuyerID_Display.Text = String.Empty
    If Not Session("F_BuyerID_Display") Is Nothing Then
      If Session("F_BuyerID_Display") <> String.Empty Then
        F_BuyerID_Display.Text = Session("F_BuyerID_Display")
      End If
    End If
    F_BuyerID.Text = String.Empty
    If Not Session("F_BuyerID") Is Nothing Then
      If Session("F_BuyerID") <> String.Empty Then
        F_BuyerID.Text = Session("F_BuyerID")
      End If
    End If
		Dim strScriptBuyerID As String = "<script type=""text/javascript""> " & _
			"function ACEBuyerID_Selected(sender, e) {" & _
			"  var F_BuyerID = $get('" & F_BuyerID.ClientID & "');" & _
			"  var F_BuyerID_Display = $get('" & F_BuyerID_Display.ClientID & "');" & _
			"  var retval = e.get_value();" & _
			"  var p = retval.split('|');" & _
			"  F_BuyerID_Display.innerHTML = e.get_text();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_BuyerID") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_BuyerID", strScriptBuyerID)
			End If
		Dim strScriptPopulatingBuyerID As String = "<script type=""text/javascript""> " & _
			"function ACEBuyerID_Populating(o,e) {" & _
			"  var p = $get('" & F_BuyerID.ClientID & "');" & _
			"  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat= 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACEBuyerID_Populated(o,e) {" & _
			"  var p = $get('" & F_BuyerID.ClientID & "');" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_BuyerIDPopulating") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_BuyerIDPopulating", strScriptPopulatingBuyerID)
			End If
    F_POStatusID_Display.Text = String.Empty
    If Not Session("F_POStatusID_Display") Is Nothing Then
      If Session("F_POStatusID_Display") <> String.Empty Then
        F_POStatusID_Display.Text = Session("F_POStatusID_Display")
      End If
    End If
    F_POStatusID.Text = String.Empty
    If Not Session("F_POStatusID") Is Nothing Then
      If Session("F_POStatusID") <> String.Empty Then
        F_POStatusID.Text = Session("F_POStatusID")
      End If
    End If
		Dim strScriptPOStatusID As String = "<script type=""text/javascript""> " & _
			"function ACEPOStatusID_Selected(sender, e) {" & _
			"  var F_POStatusID = $get('" & F_POStatusID.ClientID & "');" & _
			"  var F_POStatusID_Display = $get('" & F_POStatusID_Display.ClientID & "');" & _
			"  var retval = e.get_value();" & _
			"  var p = retval.split('|');" & _
			"  F_POStatusID.value = p[0];" & _
			"  F_POStatusID_Display.innerHTML = e.get_text();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_POStatusID") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_POStatusID", strScriptPOStatusID)
			End If
		Dim strScriptPopulatingPOStatusID As String = "<script type=""text/javascript""> " & _
			"function ACEPOStatusID_Populating(o,e) {" & _
			"  var p = $get('" & F_POStatusID.ClientID & "');" & _
			"  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat= 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACEPOStatusID_Populated(o,e) {" & _
			"  var p = $get('" & F_POStatusID.ClientID & "');" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_POStatusIDPopulating") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_POStatusIDPopulating", strScriptPopulatingPOStatusID)
			End If
		Dim validateScriptSupplierID As String = "<script type=""text/javascript"">" & _
			"  function validate_SupplierID(o) {" & _
			"    validated_FK_EITL_POList_SupplierID_main = true;" & _
			"    validate_FK_EITL_POList_SupplierID(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateSupplierID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateSupplierID", validateScriptSupplierID)
		End If
		Dim validateScriptProjectID As String = "<script type=""text/javascript"">" & _
			"  function validate_ProjectID(o) {" & _
			"    validated_FK_EITL_POList_ProjectID_main = true;" & _
			"    validate_FK_EITL_POList_ProjectID(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateProjectID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateProjectID", validateScriptProjectID)
		End If
		Dim validateScriptBuyerID As String = "<script type=""text/javascript"">" & _
			"  function validate_BuyerID(o) {" & _
			"    validated_FK_EITL_POList_BuyerID_main = true;" & _
			"    validate_FK_EITL_POList_BuyerID(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateBuyerID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateBuyerID", validateScriptBuyerID)
		End If
		Dim validateScriptPOStatusID As String = "<script type=""text/javascript"">" & _
			"  function validate_POStatusID(o) {" & _
			"    validated_FK_EITL_POList_POStatusID_main = true;" & _
			"    validate_FK_EITL_POList_POStatusID(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validatePOStatusID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validatePOStatusID", validateScriptPOStatusID)
		End If
		Dim validateScriptFK_EITL_POList_BuyerID As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_EITL_POList_BuyerID(o) {" & _
			"    var value = o.id;" & _
			"    var BuyerID = $get('" & F_BuyerID.ClientID & "');" & _
			"    try{" & _
			"    if(BuyerID.value==''){" & _
			"      if(validated_FK_EITL_POList_BuyerID.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + BuyerID.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_EITL_POList_BuyerID(value, validated_FK_EITL_POList_BuyerID);" & _
			"  }" & _
			"  validated_FK_EITL_POList_BuyerID_main = false;" & _
			"  function validated_FK_EITL_POList_BuyerID(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_EITL_POList_BuyerID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_EITL_POList_BuyerID", validateScriptFK_EITL_POList_BuyerID)
		End If
		Dim validateScriptFK_EITL_POList_POStatusID As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_EITL_POList_POStatusID(o) {" & _
			"    var value = o.id;" & _
			"    var POStatusID = $get('" & F_POStatusID.ClientID & "');" & _
			"    try{" & _
			"    if(POStatusID.value==''){" & _
			"      if(validated_FK_EITL_POList_POStatusID.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + POStatusID.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_EITL_POList_POStatusID(value, validated_FK_EITL_POList_POStatusID);" & _
			"  }" & _
			"  validated_FK_EITL_POList_POStatusID_main = false;" & _
			"  function validated_FK_EITL_POList_POStatusID(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_EITL_POList_POStatusID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_EITL_POList_POStatusID", validateScriptFK_EITL_POList_POStatusID)
		End If
		Dim validateScriptFK_EITL_POList_SupplierID As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_EITL_POList_SupplierID(o) {" & _
			"    var value = o.id;" & _
			"    var SupplierID = $get('" & F_SupplierID.ClientID & "');" & _
			"    try{" & _
			"    if(SupplierID.value==''){" & _
			"      if(validated_FK_EITL_POList_SupplierID.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + SupplierID.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_EITL_POList_SupplierID(value, validated_FK_EITL_POList_SupplierID);" & _
			"  }" & _
			"  validated_FK_EITL_POList_SupplierID_main = false;" & _
			"  function validated_FK_EITL_POList_SupplierID(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_EITL_POList_SupplierID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_EITL_POList_SupplierID", validateScriptFK_EITL_POList_SupplierID)
		End If
		Dim validateScriptFK_EITL_POList_ProjectID As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_EITL_POList_ProjectID(o) {" & _
			"    var value = o.id;" & _
			"    var ProjectID = $get('" & F_ProjectID.ClientID & "');" & _
			"    try{" & _
			"    if(ProjectID.value==''){" & _
			"      if(validated_FK_EITL_POList_ProjectID.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + ProjectID.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_EITL_POList_ProjectID(value, validated_FK_EITL_POList_ProjectID);" & _
			"  }" & _
			"  validated_FK_EITL_POList_ProjectID_main = false;" & _
			"  function validated_FK_EITL_POList_ProjectID(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_EITL_POList_ProjectID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_EITL_POList_ProjectID", validateScriptFK_EITL_POList_ProjectID)
		End If
  End Sub
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_EITL_POList_BuyerID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim BuyerID As String = CType(aVal(1),String)
		Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(BuyerID)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_EITL_POList_POStatusID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim POStatusID As Int32 = CType(aVal(1),Int32)
		Dim oVar As SIS.EITL.eitlPOStatus = SIS.EITL.eitlPOStatus.eitlPOStatusGetByID(POStatusID)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_EITL_POList_SupplierID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim SupplierID As String = CType(aVal(1),String)
		Dim oVar As SIS.EITL.eitlSuppliers = SIS.EITL.eitlSuppliers.eitlSuppliersGetByID(SupplierID)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_EITL_POList_ProjectID(ByVal value As String) As String
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
