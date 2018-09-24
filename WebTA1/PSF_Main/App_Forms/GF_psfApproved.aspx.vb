Partial Class GF_psfApproved
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PSF_Main/App_Display/DF_psfApproved.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SerialNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpsfApproved_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpsfApproved.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpsfApproved.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLpsfApproved.EditUrl & "?SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVpsfApproved_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpsfApproved.Init
    DataClassName = "GpsfApproved"
    SetGridView = GVpsfApproved
  End Sub
  Protected Sub TBLpsfApproved_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpsfApproved.Init
    SetToolBar = TBLpsfApproved
  End Sub
  Protected Sub F_SerialNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_SerialNo.TextChanged
    Session("F_SerialNo") = F_SerialNo.Text
    InitGridPage()
  End Sub
  Protected Sub F_SupplierCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_SupplierCode.TextChanged
    Session("F_SupplierCode") = F_SupplierCode.Text
    Session("F_SupplierCode_Display") = F_SupplierCode_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SupplierCodeCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PSF.psfSupplier.SelectpsfSupplierAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_CreatedBy_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CreatedBy.TextChanged
    Session("F_CreatedBy") = F_CreatedBy.Text
    Session("F_CreatedBy_Display") = F_CreatedBy_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function CreatedByCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taEmployees.SelecttaEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_ApprovedBy_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ApprovedBy.TextChanged
    Session("F_ApprovedBy") = F_ApprovedBy.Text
    Session("F_ApprovedBy_Display") = F_ApprovedBy_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ApprovedByCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taEmployees.SelecttaEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_SupplierCode_Display.Text = String.Empty
    If Not Session("F_SupplierCode_Display") Is Nothing Then
      If Session("F_SupplierCode_Display") <> String.Empty Then
        F_SupplierCode_Display.Text = Session("F_SupplierCode_Display")
      End If
    End If
    F_SupplierCode.Text = String.Empty
    If Not Session("F_SupplierCode") Is Nothing Then
      If Session("F_SupplierCode") <> String.Empty Then
        F_SupplierCode.Text = Session("F_SupplierCode")
      End If
    End If
    Dim strScriptSupplierCode As String = "<script type=""text/javascript""> " & _
      "function ACESupplierCode_Selected(sender, e) {" & _
      "  var F_SupplierCode = $get('" & F_SupplierCode.ClientID & "');" & _
      "  var F_SupplierCode_Display = $get('" & F_SupplierCode_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_SupplierCode.value = p[0];" & _
      "  F_SupplierCode_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_SupplierCode") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_SupplierCode", strScriptSupplierCode)
      End If
    Dim strScriptPopulatingSupplierCode As String = "<script type=""text/javascript""> " & _
      "function ACESupplierCode_Populating(o,e) {" & _
      "  var p = $get('" & F_SupplierCode.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACESupplierCode_Populated(o,e) {" & _
      "  var p = $get('" & F_SupplierCode.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_SupplierCodePopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_SupplierCodePopulating", strScriptPopulatingSupplierCode)
      End If
    F_CreatedBy_Display.Text = String.Empty
    If Not Session("F_CreatedBy_Display") Is Nothing Then
      If Session("F_CreatedBy_Display") <> String.Empty Then
        F_CreatedBy_Display.Text = Session("F_CreatedBy_Display")
      End If
    End If
    F_CreatedBy.Text = String.Empty
    If Not Session("F_CreatedBy") Is Nothing Then
      If Session("F_CreatedBy") <> String.Empty Then
        F_CreatedBy.Text = Session("F_CreatedBy")
      End If
    End If
    Dim strScriptCreatedBy As String = "<script type=""text/javascript""> " & _
      "function ACECreatedBy_Selected(sender, e) {" & _
      "  var F_CreatedBy = $get('" & F_CreatedBy.ClientID & "');" & _
      "  var F_CreatedBy_Display = $get('" & F_CreatedBy_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_CreatedBy.value = p[0];" & _
      "  F_CreatedBy_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_CreatedBy") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_CreatedBy", strScriptCreatedBy)
      End If
    Dim strScriptPopulatingCreatedBy As String = "<script type=""text/javascript""> " & _
      "function ACECreatedBy_Populating(o,e) {" & _
      "  var p = $get('" & F_CreatedBy.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACECreatedBy_Populated(o,e) {" & _
      "  var p = $get('" & F_CreatedBy.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_CreatedByPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_CreatedByPopulating", strScriptPopulatingCreatedBy)
      End If
    F_ApprovedBy_Display.Text = String.Empty
    If Not Session("F_ApprovedBy_Display") Is Nothing Then
      If Session("F_ApprovedBy_Display") <> String.Empty Then
        F_ApprovedBy_Display.Text = Session("F_ApprovedBy_Display")
      End If
    End If
    F_ApprovedBy.Text = String.Empty
    If Not Session("F_ApprovedBy") Is Nothing Then
      If Session("F_ApprovedBy") <> String.Empty Then
        F_ApprovedBy.Text = Session("F_ApprovedBy")
      End If
    End If
    Dim strScriptApprovedBy As String = "<script type=""text/javascript""> " & _
      "function ACEApprovedBy_Selected(sender, e) {" & _
      "  var F_ApprovedBy = $get('" & F_ApprovedBy.ClientID & "');" & _
      "  var F_ApprovedBy_Display = $get('" & F_ApprovedBy_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_ApprovedBy.value = p[0];" & _
      "  F_ApprovedBy_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ApprovedBy") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ApprovedBy", strScriptApprovedBy)
      End If
    Dim strScriptPopulatingApprovedBy As String = "<script type=""text/javascript""> " & _
      "function ACEApprovedBy_Populating(o,e) {" & _
      "  var p = $get('" & F_ApprovedBy.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEApprovedBy_Populated(o,e) {" & _
      "  var p = $get('" & F_ApprovedBy.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ApprovedByPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ApprovedByPopulating", strScriptPopulatingApprovedBy)
      End If
    Dim validateScriptSupplierCode As String = "<script type=""text/javascript"">" & _
      "  function validate_SupplierCode(o) {" & _
      "    validated_FK_PSF_HSBCMain_SupplierID_main = true;" & _
      "    validate_FK_PSF_HSBCMain_SupplierID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateSupplierCode") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateSupplierCode", validateScriptSupplierCode)
    End If
    Dim validateScriptCreatedBy As String = "<script type=""text/javascript"">" & _
      "  function validate_CreatedBy(o) {" & _
      "    validated_FK_PSF_HSBCMain_CreatedBy_main = true;" & _
      "    validate_FK_PSF_HSBCMain_CreatedBy(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateCreatedBy") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateCreatedBy", validateScriptCreatedBy)
    End If
    Dim validateScriptApprovedBy As String = "<script type=""text/javascript"">" & _
      "  function validate_ApprovedBy(o) {" & _
      "    validated_FK_PSF_HSBCMain_ApprovedBy_main = true;" & _
      "    validate_FK_PSF_HSBCMain_ApprovedBy(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateApprovedBy") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateApprovedBy", validateScriptApprovedBy)
    End If
    Dim validateScriptFK_PSF_HSBCMain_CreatedBy As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PSF_HSBCMain_CreatedBy(o) {" & _
      "    var value = o.id;" & _
      "    var CreatedBy = $get('" & F_CreatedBy.ClientID & "');" & _
      "    try{" & _
      "    if(CreatedBy.value==''){" & _
      "      if(validated_FK_PSF_HSBCMain_CreatedBy.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + CreatedBy.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PSF_HSBCMain_CreatedBy(value, validated_FK_PSF_HSBCMain_CreatedBy);" & _
      "  }" & _
      "  validated_FK_PSF_HSBCMain_CreatedBy_main = false;" & _
      "  function validated_FK_PSF_HSBCMain_CreatedBy(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PSF_HSBCMain_CreatedBy") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PSF_HSBCMain_CreatedBy", validateScriptFK_PSF_HSBCMain_CreatedBy)
    End If
    Dim validateScriptFK_PSF_HSBCMain_ApprovedBy As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PSF_HSBCMain_ApprovedBy(o) {" & _
      "    var value = o.id;" & _
      "    var ApprovedBy = $get('" & F_ApprovedBy.ClientID & "');" & _
      "    try{" & _
      "    if(ApprovedBy.value==''){" & _
      "      if(validated_FK_PSF_HSBCMain_ApprovedBy.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + ApprovedBy.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PSF_HSBCMain_ApprovedBy(value, validated_FK_PSF_HSBCMain_ApprovedBy);" & _
      "  }" & _
      "  validated_FK_PSF_HSBCMain_ApprovedBy_main = false;" & _
      "  function validated_FK_PSF_HSBCMain_ApprovedBy(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PSF_HSBCMain_ApprovedBy") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PSF_HSBCMain_ApprovedBy", validateScriptFK_PSF_HSBCMain_ApprovedBy)
    End If
    Dim validateScriptFK_PSF_HSBCMain_SupplierID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PSF_HSBCMain_SupplierID(o) {" & _
      "    var value = o.id;" & _
      "    var SupplierCode = $get('" & F_SupplierCode.ClientID & "');" & _
      "    try{" & _
      "    if(SupplierCode.value==''){" & _
      "      if(validated_FK_PSF_HSBCMain_SupplierID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + SupplierCode.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PSF_HSBCMain_SupplierID(value, validated_FK_PSF_HSBCMain_SupplierID);" & _
      "  }" & _
      "  validated_FK_PSF_HSBCMain_SupplierID_main = false;" & _
      "  function validated_FK_PSF_HSBCMain_SupplierID(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PSF_HSBCMain_SupplierID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PSF_HSBCMain_SupplierID", validateScriptFK_PSF_HSBCMain_SupplierID)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PSF_HSBCMain_CreatedBy(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim CreatedBy As String = CType(aVal(1),String)
    Dim oVar As SIS.TA.taEmployees = SIS.TA.taEmployees.taEmployeesGetByID(CreatedBy)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PSF_HSBCMain_ApprovedBy(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ApprovedBy As String = CType(aVal(1),String)
    Dim oVar As SIS.TA.taEmployees = SIS.TA.taEmployees.taEmployeesGetByID(ApprovedBy)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PSF_HSBCMain_SupplierID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SupplierCode As String = CType(aVal(1),String)
    Dim oVar As SIS.PSF.psfSupplier = SIS.PSF.psfSupplier.psfSupplierGetByID(SupplierCode)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
