Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Imports System.IO
Partial Class GF_pakIQCListH
  Inherits SIS.SYS.GridBase
  Protected Sub GVpakIQCListH_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakIQCListH.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakIQCListH.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim QCLNo As Int32 = GVpakIQCListH.DataKeys(e.CommandArgument).Values("QCLNo")
        Dim RedirectUrl As String = TBLpakIQCListH.EditUrl & "?SerialNo=" & SerialNo & "&QCLNo=" & QCLNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "approvewf".ToLower Then
      Try
        Dim Remarks As String = CType(GVpakIQCListH.Rows(e.CommandArgument).FindControl("F_Remarks"), TextBox).Text
        Dim SerialNo As Int32 = GVpakIQCListH.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim QCLNo As Int32 = GVpakIQCListH.DataKeys(e.CommandArgument).Values("QCLNo")
        SIS.PAK.pakIQCListH.ApproveWF(SerialNo, QCLNo, Remarks)
        GVpakIQCListH.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "rejectwf".ToLower Then
      Try
        Dim Remarks As String = CType(GVpakIQCListH.Rows(e.CommandArgument).FindControl("F_Remarks"), TextBox).Text
        Dim SerialNo As Int32 = GVpakIQCListH.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim QCLNo As Int32 = GVpakIQCListH.DataKeys(e.CommandArgument).Values("QCLNo")
        SIS.PAK.pakIQCListH.RejectWF(SerialNo, QCLNo, Remarks)
        GVpakIQCListH.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpakIQCListH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakIQCListH.Init
    DataClassName = "GpakIQCListH"
    SetGridView = GVpakIQCListH
  End Sub
  Protected Sub TBLpakIQCListH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakIQCListH.Init
    SetToolBar = TBLpakIQCListH
  End Sub
  Protected Sub F_SerialNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_SerialNo.TextChanged
    Session("F_SerialNo") = F_SerialNo.Text
    Session("F_SerialNo_Display") = F_SerialNo_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function SerialNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakPO.SelectpakPOAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_QCLNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_QCLNo.TextChanged
    Session("F_QCLNo") = F_QCLNo.Text
    InitGridPage()
  End Sub
  Protected Sub F_CreatedBy_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CreatedBy.TextChanged
    Session("F_CreatedBy") = F_CreatedBy.Text
    Session("F_CreatedBy_Display") = F_CreatedBy_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function CreatedByCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_StatusID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_StatusID.TextChanged
    Session("F_StatusID") = F_StatusID.Text
    Session("F_StatusID_Display") = F_StatusID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function StatusIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakQCListStatus.SelectpakQCListStatusAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_ClearedBy_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ClearedBy.TextChanged
    Session("F_ClearedBy") = F_ClearedBy.Text
    Session("F_ClearedBy_Display") = F_ClearedBy_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ClearedByCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
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
    Dim strScriptSerialNo As String = "<script type=""text/javascript""> " &
      "function ACESerialNo_Selected(sender, e) {" &
      "  var F_SerialNo = $get('" & F_SerialNo.ClientID & "');" &
      "  var F_SerialNo_Display = $get('" & F_SerialNo_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_SerialNo.value = p[0];" &
      "  F_SerialNo_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_SerialNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_SerialNo", strScriptSerialNo)
    End If
    Dim strScriptPopulatingSerialNo As String = "<script type=""text/javascript""> " &
      "function ACESerialNo_Populating(o,e) {" &
      "  var p = $get('" & F_SerialNo.ClientID & "');" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACESerialNo_Populated(o,e) {" &
      "  var p = $get('" & F_SerialNo.ClientID & "');" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_SerialNoPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_SerialNoPopulating", strScriptPopulatingSerialNo)
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
    Dim strScriptCreatedBy As String = "<script type=""text/javascript""> " &
      "function ACECreatedBy_Selected(sender, e) {" &
      "  var F_CreatedBy = $get('" & F_CreatedBy.ClientID & "');" &
      "  var F_CreatedBy_Display = $get('" & F_CreatedBy_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_CreatedBy_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_CreatedBy") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_CreatedBy", strScriptCreatedBy)
    End If
    Dim strScriptPopulatingCreatedBy As String = "<script type=""text/javascript""> " &
      "function ACECreatedBy_Populating(o,e) {" &
      "  var p = $get('" & F_CreatedBy.ClientID & "');" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACECreatedBy_Populated(o,e) {" &
      "  var p = $get('" & F_CreatedBy.ClientID & "');" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_CreatedByPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_CreatedByPopulating", strScriptPopulatingCreatedBy)
    End If
    F_StatusID_Display.Text = String.Empty
    If Not Session("F_StatusID_Display") Is Nothing Then
      If Session("F_StatusID_Display") <> String.Empty Then
        F_StatusID_Display.Text = Session("F_StatusID_Display")
      End If
    End If
    F_StatusID.Text = String.Empty
    If Not Session("F_StatusID") Is Nothing Then
      If Session("F_StatusID") <> String.Empty Then
        F_StatusID.Text = Session("F_StatusID")
      End If
    End If
    Dim strScriptStatusID As String = "<script type=""text/javascript""> " &
      "function ACEStatusID_Selected(sender, e) {" &
      "  var F_StatusID = $get('" & F_StatusID.ClientID & "');" &
      "  var F_StatusID_Display = $get('" & F_StatusID_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_StatusID.value = p[0];" &
      "  F_StatusID_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_StatusID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_StatusID", strScriptStatusID)
    End If
    Dim strScriptPopulatingStatusID As String = "<script type=""text/javascript""> " &
      "function ACEStatusID_Populating(o,e) {" &
      "  var p = $get('" & F_StatusID.ClientID & "');" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACEStatusID_Populated(o,e) {" &
      "  var p = $get('" & F_StatusID.ClientID & "');" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_StatusIDPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_StatusIDPopulating", strScriptPopulatingStatusID)
    End If
    F_ClearedBy_Display.Text = String.Empty
    If Not Session("F_ClearedBy_Display") Is Nothing Then
      If Session("F_ClearedBy_Display") <> String.Empty Then
        F_ClearedBy_Display.Text = Session("F_ClearedBy_Display")
      End If
    End If
    F_ClearedBy.Text = String.Empty
    If Not Session("F_ClearedBy") Is Nothing Then
      If Session("F_ClearedBy") <> String.Empty Then
        F_ClearedBy.Text = Session("F_ClearedBy")
      End If
    End If
    Dim strScriptClearedBy As String = "<script type=""text/javascript""> " &
      "function ACEClearedBy_Selected(sender, e) {" &
      "  var F_ClearedBy = $get('" & F_ClearedBy.ClientID & "');" &
      "  var F_ClearedBy_Display = $get('" & F_ClearedBy_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_ClearedBy_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ClearedBy") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ClearedBy", strScriptClearedBy)
    End If
    Dim strScriptPopulatingClearedBy As String = "<script type=""text/javascript""> " &
      "function ACEClearedBy_Populating(o,e) {" &
      "  var p = $get('" & F_ClearedBy.ClientID & "');" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACEClearedBy_Populated(o,e) {" &
      "  var p = $get('" & F_ClearedBy.ClientID & "');" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ClearedByPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ClearedByPopulating", strScriptPopulatingClearedBy)
    End If
    Dim validateScriptSerialNo As String = "<script type=""text/javascript"">" &
      "  function validate_SerialNo(o) {" &
      "    validated_FK_PAK_QCListH_SerialNo_main = true;" &
      "    validate_FK_PAK_QCListH_SerialNo(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateSerialNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateSerialNo", validateScriptSerialNo)
    End If
    Dim validateScriptCreatedBy As String = "<script type=""text/javascript"">" &
      "  function validate_CreatedBy(o) {" &
      "    validated_FK_PAK_QCListH_CreatedBy_main = true;" &
      "    validate_FK_PAK_QCListH_CreatedBy(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateCreatedBy") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateCreatedBy", validateScriptCreatedBy)
    End If
    Dim validateScriptStatusID As String = "<script type=""text/javascript"">" &
      "  function validate_StatusID(o) {" &
      "    validated_FK_PAK_QCListH_StatusID_main = true;" &
      "    validate_FK_PAK_QCListH_StatusID(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateStatusID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateStatusID", validateScriptStatusID)
    End If
    Dim validateScriptClearedBy As String = "<script type=""text/javascript"">" &
      "  function validate_ClearedBy(o) {" &
      "    validated_FK_PAK_QCListH_ClearedBy_main = true;" &
      "    validate_FK_PAK_QCListH_ClearedBy(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateClearedBy") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateClearedBy", validateScriptClearedBy)
    End If
    Dim validateScriptFK_PAK_QCListH_CreatedBy As String = "<script type=""text/javascript"">" &
      "  function validate_FK_PAK_QCListH_CreatedBy(o) {" &
      "    var value = o.id;" &
      "    var CreatedBy = $get('" & F_CreatedBy.ClientID & "');" &
      "    try{" &
      "    if(CreatedBy.value==''){" &
      "      if(validated_FK_PAK_QCListH_CreatedBy.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + CreatedBy.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_PAK_QCListH_CreatedBy(value, validated_FK_PAK_QCListH_CreatedBy);" &
      "  }" &
      "  validated_FK_PAK_QCListH_CreatedBy_main = false;" &
      "  function validated_FK_PAK_QCListH_CreatedBy(result) {" &
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PAK_QCListH_CreatedBy") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PAK_QCListH_CreatedBy", validateScriptFK_PAK_QCListH_CreatedBy)
    End If
    Dim validateScriptFK_PAK_QCListH_SerialNo As String = "<script type=""text/javascript"">" &
      "  function validate_FK_PAK_QCListH_SerialNo(o) {" &
      "    var value = o.id;" &
      "    var SerialNo = $get('" & F_SerialNo.ClientID & "');" &
      "    try{" &
      "    if(SerialNo.value==''){" &
      "      if(validated_FK_PAK_QCListH_SerialNo.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + SerialNo.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_PAK_QCListH_SerialNo(value, validated_FK_PAK_QCListH_SerialNo);" &
      "  }" &
      "  validated_FK_PAK_QCListH_SerialNo_main = false;" &
      "  function validated_FK_PAK_QCListH_SerialNo(result) {" &
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PAK_QCListH_SerialNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PAK_QCListH_SerialNo", validateScriptFK_PAK_QCListH_SerialNo)
    End If
    Dim validateScriptFK_PAK_QCListH_StatusID As String = "<script type=""text/javascript"">" &
      "  function validate_FK_PAK_QCListH_StatusID(o) {" &
      "    var value = o.id;" &
      "    var StatusID = $get('" & F_StatusID.ClientID & "');" &
      "    try{" &
      "    if(StatusID.value==''){" &
      "      if(validated_FK_PAK_QCListH_StatusID.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + StatusID.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_PAK_QCListH_StatusID(value, validated_FK_PAK_QCListH_StatusID);" &
      "  }" &
      "  validated_FK_PAK_QCListH_StatusID_main = false;" &
      "  function validated_FK_PAK_QCListH_StatusID(result) {" &
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PAK_QCListH_StatusID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PAK_QCListH_StatusID", validateScriptFK_PAK_QCListH_StatusID)
    End If
    Dim validateScriptFK_PAK_QCListH_ClearedBy As String = "<script type=""text/javascript"">" &
      "  function validate_FK_PAK_QCListH_ClearedBy(o) {" &
      "    var value = o.id;" &
      "    var ClearedBy = $get('" & F_ClearedBy.ClientID & "');" &
      "    try{" &
      "    if(ClearedBy.value==''){" &
      "      if(validated_FK_PAK_QCListH_ClearedBy.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + ClearedBy.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_PAK_QCListH_ClearedBy(value, validated_FK_PAK_QCListH_ClearedBy);" &
      "  }" &
      "  validated_FK_PAK_QCListH_ClearedBy_main = false;" &
      "  function validated_FK_PAK_QCListH_ClearedBy(result) {" &
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PAK_QCListH_ClearedBy") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PAK_QCListH_ClearedBy", validateScriptFK_PAK_QCListH_ClearedBy)
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PAK_QCListH_CreatedBy(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim CreatedBy As String = CType(aVal(1), String)
    Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(CreatedBy)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PAK_QCListH_SerialNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim SerialNo As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.PAK.pakPO = SIS.PAK.pakPO.pakPOGetByID(SerialNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PAK_QCListH_StatusID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim StatusID As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.PAK.pakQCListStatus = SIS.PAK.pakQCListStatus.pakQCListStatusGetByID(StatusID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PAK_QCListH_ClearedBy(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim ClearedBy As String = CType(aVal(1), String)
    Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(ClearedBy)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  Private st As Long = HttpContext.Current.Server.ScriptTimeout
  Private Sub cmdTmplUpload_Command(sender As Object, e As CommandEventArgs) Handles cmdTmplUpload.Command
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
    If e.CommandName.ToLower = "tmplupload" Then
      Try
        With F_FileUpload
          If .HasFile Then
            Dim tmpPath As String = Server.MapPath("~/../App_Temp")
            Dim tmpName As String = IO.Path.GetRandomFileName()
            Dim tmpFile As String = tmpPath & "\\" & tmpName
            .SaveAs(tmpFile)
            Dim fi As FileInfo = New FileInfo(tmpFile)
            Dim IsError As Boolean = False
            Dim ErrMsg As String = ""
            Using xlP As ExcelPackage = New ExcelPackage(fi)
              Dim wsD As ExcelWorksheet = Nothing
              Try
                wsD = xlP.Workbook.Worksheets("QC List")
              Catch ex As Exception
                wsD = Nothing
              End Try
              '1. Process Document
              If wsD Is Nothing Then
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Invalid XL File") & "');", True)
                xlP.Dispose()
                HttpContext.Current.Server.ScriptTimeout = st
                Exit Sub
              End If

              Dim SerialNo As String = wsD.Cells(1, 3).Text
              Dim QCLNo As String = wsD.Cells(2, 3).Text
              Dim BOMNo As String = ""


              If SerialNo = "" Then
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Wrong SerialNo Uploaded.") & "');", True)
                xlP.Dispose()
                HttpContext.Current.Server.ScriptTimeout = st
                Exit Sub
              End If
              If QCLNo = "" Then
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Wrong Quality Clearance List Uploaded.") & "');", True)
                xlP.Dispose()
                HttpContext.Current.Server.ScriptTimeout = st
                Exit Sub
              End If
              'Check the status of PO & QC List Before Update
              'PO
              Dim tmpPO As SIS.PAK.pakQCPO = SIS.PAK.pakQCPO.pakQCPOGetByID(SerialNo)
              If tmpPO.POStatusID <> pakPOStates.UnderDespatch Then
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("PO status is not UNDER DESPATCH, cannot update Quality Clearance list.") & "');", True)
                xlP.Dispose()
                HttpContext.Current.Server.ScriptTimeout = st
                Exit Sub
              End If
              'QC List
              Dim tmpQCL As SIS.PAK.pakQCListH = SIS.PAK.pakQCListH.pakQCListHGetByID(SerialNo, QCLNo)
              Select Case tmpQCL.StatusID
                Case pakQCStates.UnderQualityInspection
                Case Else
                  ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("QC List status is not UNDER QUALITY CLEARANCE, cannot update QC list.") & "');", True)
                  xlP.Dispose()
                  HttpContext.Current.Server.ScriptTimeout = st
                  Exit Sub
              End Select
              'End of status Checking
              Dim qcHqcWt As Decimal = 0
              Dim ItemNo As String = ""
              Dim Updatable As Boolean = False
              Dim tmpQCQuantity As String = ""
              Dim tmpRemarks As String = ""

              For I As Integer = 9 To 99999
                BOMNo = wsD.Cells(I, 2).Text
                If BOMNo = String.Empty Then Exit For
                ItemNo = wsD.Cells(I, 3).Text
                Updatable = IIf(wsD.Cells(I, 6).Text <> String.Empty, True, False)
                If Not Updatable Then Continue For
                tmpQCQuantity = wsD.Cells(I, 15).Text
                tmpRemarks = wsD.Cells(I, 16).Text

                If Not IsNumeric(tmpQCQuantity) Then
                  tmpQCQuantity = "0.0000"
                End If
                Dim tmpListD As SIS.PAK.pakQCListD = Nothing
                tmpListD = SIS.PAK.pakQCListD.pakQCListDGetByID(SerialNo, QCLNo, BOMNo, ItemNo)
                If tmpListD IsNot Nothing Then
                  With tmpListD
                    .QualityClearedQty = tmpQCQuantity
                    .Remarks = tmpRemarks
                    .ClearedBy = HttpContext.Current.Session("LoginID")
                    .ClearedOn = Now
                  End With
                  '=====QC Cleared Weight=================
                  tmpListD.QualityClearedWt = SIS.PAK.pakPO.GetTotalWeight(tmpListD.QualityClearedQty, tmpListD.WeightPerUnit, tmpListD.UOMQuantity, tmpListD.UOMWeight)
                  '=======================================
                  Try
                    tmpListD = SIS.PAK.pakQCListD.UpdateData(tmpListD)
                    qcHqcWt += tmpListD.QualityClearedWt
                  Catch ex As Exception
                    IsError = True
                    ErrMsg = ErrMsg & IIf(ErrMsg = "", "", ", ") & ItemNo & "-QC List Update"
                  End Try
                End If
              Next 'Document Line
              '============Update QC H QC Wt=============
              Dim qcH As SIS.PAK.pakQCListH = SIS.PAK.pakQCListH.pakQCListHGetByID(SerialNo, QCLNo)
              qcH.QualityClearedWt = qcHqcWt
              qcH = SIS.PAK.pakQCListH.UpdateData(qcH)
              '==========================================
              xlP.Dispose()
              If IsError Then
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("ITEMS NOT INSERTED/UPDATED: " & ErrMsg) & "');", True)
              Else
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Updated") & "');", True)
              End If
            End Using
          End If
        End With
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    HttpContext.Current.Server.ScriptTimeout = st
  End Sub
End Class
