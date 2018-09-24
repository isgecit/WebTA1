Partial Class GF_eitlPOOpenRequest
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/EITL_Main/App_Display/DF_eitlPOOpenRequest.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?RequestNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVeitlPOOpenRequest_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVeitlPOOpenRequest.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim RequestNo As Int32 = GVeitlPOOpenRequest.DataKeys(e.CommandArgument).Values("RequestNo")  
				Dim RedirectUrl As String = TBLeitlPOOpenRequest.EditUrl & "?RequestNo=" & RequestNo
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
		If e.CommandName.ToLower = "approvewf".ToLower Then
			Try
				Dim ExecuterRemarks As String = CType(GVeitlPOOpenRequest.Rows(e.CommandArgument).FindControl("F_ExecuterRemarks"),TextBox).Text
				Dim RequestNo As Int32 = GVeitlPOOpenRequest.DataKeys(e.CommandArgument).Values("RequestNo")  
				SIS.EITL.eitlPOOpenRequest.ApproveWF(RequestNo, ExecuterRemarks)
				GVeitlPOOpenRequest.DataBind()
			Catch ex As Exception
			End Try
		End If
		If e.CommandName.ToLower = "rejectwf".ToLower Then
			Try
				Dim ExecuterRemarks As String = CType(GVeitlPOOpenRequest.Rows(e.CommandArgument).FindControl("F_ExecuterRemarks"),TextBox).Text
				Dim RequestNo As Int32 = GVeitlPOOpenRequest.DataKeys(e.CommandArgument).Values("RequestNo")  
				SIS.EITL.eitlPOOpenRequest.RejectWF(RequestNo, ExecuterRemarks)
				GVeitlPOOpenRequest.DataBind()
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVeitlPOOpenRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVeitlPOOpenRequest.Init
    DataClassName = "GeitlPOOpenRequest"
    SetGridView = GVeitlPOOpenRequest
  End Sub
  Protected Sub TBLeitlPOOpenRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlPOOpenRequest.Init
    SetToolBar = TBLeitlPOOpenRequest
  End Sub
  Protected Sub F_SerialNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_SerialNo.TextChanged
    Session("F_SerialNo") = F_SerialNo.Text
    Session("F_SerialNo_Display") = F_SerialNo_Display.Text
    InitGridPage()
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SerialNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.EITL.eitlPOList.SelecteitlPOListAutoCompleteList(prefixText, count, contextKey)
  End Function
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
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_SerialNo_Display.Text = String.Empty
    If Not Session("F_SerialNo_Display") Is Nothing Then
      If Session("F_SerialNo_Display") <> String.Empty Then
        F_SerialNo_Display.Text = Session("F_SerialNo_Display")
      End If
    End If
    F_SerialNo.Text = String.Empty
    If Not Session("F_SerialNo") Is Nothing Then
      If Session("F_SerialNo") <> String.Empty Then
        F_SerialNo.Text = Session("F_SerialNo")
      End If
    End If
		Dim strScriptSerialNo As String = "<script type=""text/javascript""> " & _
			"function ACESerialNo_Selected(sender, e) {" & _
			"  var F_SerialNo = $get('" & F_SerialNo.ClientID & "');" & _
			"  var F_SerialNo_Display = $get('" & F_SerialNo_Display.ClientID & "');" & _
			"  var retval = e.get_value();" & _
			"  var p = retval.split('|');" & _
			"  F_SerialNo.value = p[0];" & _
			"  F_SerialNo_Display.innerHTML = e.get_text();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_SerialNo") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_SerialNo", strScriptSerialNo)
			End If
		Dim strScriptPopulatingSerialNo As String = "<script type=""text/javascript""> " & _
			"function ACESerialNo_Populating(o,e) {" & _
			"  var p = $get('" & F_SerialNo.ClientID & "');" & _
			"  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat= 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACESerialNo_Populated(o,e) {" & _
			"  var p = $get('" & F_SerialNo.ClientID & "');" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_SerialNoPopulating") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_SerialNoPopulating", strScriptPopulatingSerialNo)
			End If
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
		Dim validateScriptSerialNo As String = "<script type=""text/javascript"">" & _
			"  function validate_SerialNo(o) {" & _
			"    validated_FK_EITL_POOpenRequest_SerialNo_main = true;" & _
			"    validate_FK_EITL_POOpenRequest_SerialNo(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateSerialNo") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateSerialNo", validateScriptSerialNo)
		End If
		Dim validateScriptSupplierID As String = "<script type=""text/javascript"">" & _
			"  function validate_SupplierID(o) {" & _
			"    validated_FK_EITL_POOpenRequest_SupplierID_main = true;" & _
			"    validate_FK_EITL_POOpenRequest_SupplierID(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateSupplierID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateSupplierID", validateScriptSupplierID)
		End If
		Dim validateScriptFK_EITL_POOpenRequest_SerialNo As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_EITL_POOpenRequest_SerialNo(o) {" & _
			"    var value = o.id;" & _
			"    var SerialNo = $get('" & F_SerialNo.ClientID & "');" & _
			"    try{" & _
			"    if(SerialNo.value==''){" & _
			"      if(validated_FK_EITL_POOpenRequest_SerialNo.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + SerialNo.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_EITL_POOpenRequest_SerialNo(value, validated_FK_EITL_POOpenRequest_SerialNo);" & _
			"  }" & _
			"  validated_FK_EITL_POOpenRequest_SerialNo_main = false;" & _
			"  function validated_FK_EITL_POOpenRequest_SerialNo(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_EITL_POOpenRequest_SerialNo") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_EITL_POOpenRequest_SerialNo", validateScriptFK_EITL_POOpenRequest_SerialNo)
		End If
		Dim validateScriptFK_EITL_POOpenRequest_SupplierID As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_EITL_POOpenRequest_SupplierID(o) {" & _
			"    var value = o.id;" & _
			"    var SupplierID = $get('" & F_SupplierID.ClientID & "');" & _
			"    try{" & _
			"    if(SupplierID.value==''){" & _
			"      if(validated_FK_EITL_POOpenRequest_SupplierID.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + SupplierID.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_EITL_POOpenRequest_SupplierID(value, validated_FK_EITL_POOpenRequest_SupplierID);" & _
			"  }" & _
			"  validated_FK_EITL_POOpenRequest_SupplierID_main = false;" & _
			"  function validated_FK_EITL_POOpenRequest_SupplierID(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_EITL_POOpenRequest_SupplierID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_EITL_POOpenRequest_SupplierID", validateScriptFK_EITL_POOpenRequest_SupplierID)
		End If
  End Sub
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_EITL_POOpenRequest_SerialNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim SerialNo As Int32 = CType(aVal(1),Int32)
		Dim oVar As SIS.EITL.eitlPOList = SIS.EITL.eitlPOList.eitlPOListGetByID(SerialNo)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_EITL_POOpenRequest_SupplierID(ByVal value As String) As String
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
End Class
