Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Partial Class GF_pakPOItem
  Inherits SIS.SYS.GridBase
  Protected Sub GVpakPO_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakPO.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakPO.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim RedirectUrl As String = TBLpakPO.EditUrl & "?SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakPO.DataKeys(e.CommandArgument).Values("SerialNo")
        SIS.PAK.pakPO.InitiateWF(SerialNo)
        GVpakPO.DataBind()
      Catch ex As Exception
        Dim message As String = New JavaScriptSerializer().Serialize(ex.Message.ToString())
        Dim script As String = String.Format("alert({0});", message)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      End Try
    End If
    If e.CommandName.ToLower = "approvewf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakPO.DataKeys(e.CommandArgument).Values("SerialNo")
        SIS.PAK.pakPO.ApproveWF(SerialNo)
        GVpakPO.DataBind()
      Catch ex As Exception
        Dim message As String = New JavaScriptSerializer().Serialize(ex.Message.ToString())
        Dim script As String = String.Format("alert({0});", message)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      End Try
    End If
    If e.CommandName.ToLower = "rejectwf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakPO.DataKeys(e.CommandArgument).Values("SerialNo")
        SIS.PAK.pakPO.RejectWF(SerialNo)
        GVpakPO.DataBind()
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "completewf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakPO.DataKeys(e.CommandArgument).Values("SerialNo")
        SIS.PAK.pakPO.CompleteWF(SerialNo)
        GVpakPO.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVpakPO_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakPO.Init
    DataClassName = "GpakPO"
    SetGridView = GVpakPO
  End Sub
  Protected Sub TBLpakPO_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakPO.Init
    SetToolBar = TBLpakPO
  End Sub
  Protected Sub F_SupplierID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_SupplierID.TextChanged
    Session("F_SupplierID") = F_SupplierID.Text
    Session("F_SupplierID_Display") = F_SupplierID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function SupplierIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakBusinessPartner.SelectpakBusinessPartnerAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_ProjectID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ProjectID.TextChanged
    Session("F_ProjectID") = F_ProjectID.Text
    Session("F_ProjectID_Display") = F_ProjectID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_POStatusID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_POStatusID.SelectedIndexChanged
    Session("F_POStatusID") = F_POStatusID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_IssuedBy_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_IssuedBy.TextChanged
    Session("F_IssuedBy") = F_IssuedBy.Text
    Session("F_IssuedBy_Display") = F_IssuedBy_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function IssuedByCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_BuyerID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_BuyerID.TextChanged
    Session("F_BuyerID") = F_BuyerID.Text
    Session("F_BuyerID_Display") = F_BuyerID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function BuyerIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_POTypeID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_POTypeID.SelectedIndexChanged
    Session("F_POTypeID") = F_POTypeID.SelectedValue
    InitGridPage()
  End Sub
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
    Dim strScriptSupplierID As String = "<script type=""text/javascript""> " &
      "function ACESupplierID_Selected(sender, e) {" &
      "  var F_SupplierID = $get('" & F_SupplierID.ClientID & "');" &
      "  var F_SupplierID_Display = $get('" & F_SupplierID_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_SupplierID.value = p[0];" &
      "  F_SupplierID_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_SupplierID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_SupplierID", strScriptSupplierID)
    End If
    Dim strScriptPopulatingSupplierID As String = "<script type=""text/javascript""> " &
      "function ACESupplierID_Populating(o,e) {" &
      "  var p = $get('" & F_SupplierID.ClientID & "');" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACESupplierID_Populated(o,e) {" &
      "  var p = $get('" & F_SupplierID.ClientID & "');" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
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
    Dim strScriptProjectID As String = "<script type=""text/javascript""> " &
      "function ACEProjectID_Selected(sender, e) {" &
      "  var F_ProjectID = $get('" & F_ProjectID.ClientID & "');" &
      "  var F_ProjectID_Display = $get('" & F_ProjectID_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_ProjectID.value = p[0];" &
      "  F_ProjectID_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ProjectID", strScriptProjectID)
    End If
    Dim strScriptPopulatingProjectID As String = "<script type=""text/javascript""> " &
      "function ACEProjectID_Populating(o,e) {" &
      "  var p = $get('" & F_ProjectID.ClientID & "');" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACEProjectID_Populated(o,e) {" &
      "  var p = $get('" & F_ProjectID.ClientID & "');" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ProjectIDPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ProjectIDPopulating", strScriptPopulatingProjectID)
    End If
    F_POStatusID.SelectedValue = String.Empty
    If Not Session("F_POStatusID") Is Nothing Then
      If Session("F_POStatusID") <> String.Empty Then
        F_POStatusID.SelectedValue = Session("F_POStatusID")
      End If
    End If
    F_IssuedBy_Display.Text = String.Empty
    If Not Session("F_IssuedBy_Display") Is Nothing Then
      If Session("F_IssuedBy_Display") <> String.Empty Then
        F_IssuedBy_Display.Text = Session("F_IssuedBy_Display")
      End If
    End If
    F_IssuedBy.Text = String.Empty
    If Not Session("F_IssuedBy") Is Nothing Then
      If Session("F_IssuedBy") <> String.Empty Then
        F_IssuedBy.Text = Session("F_IssuedBy")
      End If
    End If
    Dim strScriptIssuedBy As String = "<script type=""text/javascript""> " &
      "function ACEIssuedBy_Selected(sender, e) {" &
      "  var F_IssuedBy = $get('" & F_IssuedBy.ClientID & "');" &
      "  var F_IssuedBy_Display = $get('" & F_IssuedBy_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_IssuedBy_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_IssuedBy") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_IssuedBy", strScriptIssuedBy)
    End If
    Dim strScriptPopulatingIssuedBy As String = "<script type=""text/javascript""> " &
      "function ACEIssuedBy_Populating(o,e) {" &
      "  var p = $get('" & F_IssuedBy.ClientID & "');" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACEIssuedBy_Populated(o,e) {" &
      "  var p = $get('" & F_IssuedBy.ClientID & "');" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_IssuedByPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_IssuedByPopulating", strScriptPopulatingIssuedBy)
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
    Dim strScriptBuyerID As String = "<script type=""text/javascript""> " &
      "function ACEBuyerID_Selected(sender, e) {" &
      "  var F_BuyerID = $get('" & F_BuyerID.ClientID & "');" &
      "  var F_BuyerID_Display = $get('" & F_BuyerID_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_BuyerID_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_BuyerID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_BuyerID", strScriptBuyerID)
    End If
    Dim strScriptPopulatingBuyerID As String = "<script type=""text/javascript""> " &
      "function ACEBuyerID_Populating(o,e) {" &
      "  var p = $get('" & F_BuyerID.ClientID & "');" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACEBuyerID_Populated(o,e) {" &
      "  var p = $get('" & F_BuyerID.ClientID & "');" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_BuyerIDPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_BuyerIDPopulating", strScriptPopulatingBuyerID)
    End If
    F_POTypeID.SelectedValue = String.Empty
    If Not Session("F_POTypeID") Is Nothing Then
      If Session("F_POTypeID") <> String.Empty Then
        F_POTypeID.SelectedValue = Session("F_POTypeID")
      End If
    End If
    Dim validateScriptSupplierID As String = "<script type=""text/javascript"">" &
      "  function validate_SupplierID(o) {" &
      "    validated_FK_PAK_SupplierID_main = true;" &
      "    validate_FK_PAK_SupplierID(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateSupplierID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateSupplierID", validateScriptSupplierID)
    End If
    Dim validateScriptProjectID As String = "<script type=""text/javascript"">" &
      "  function validate_ProjectID(o) {" &
      "    validated_FK_PAK_PO_ProjectID_main = true;" &
      "    validate_FK_PAK_PO_ProjectID(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateProjectID", validateScriptProjectID)
    End If
    Dim validateScriptIssuedBy As String = "<script type=""text/javascript"">" &
      "  function validate_IssuedBy(o) {" &
      "    validated_FK_PAK_PO_IssuedBy_main = true;" &
      "    validate_FK_PAK_PO_IssuedBy(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateIssuedBy") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateIssuedBy", validateScriptIssuedBy)
    End If
    Dim validateScriptBuyerID As String = "<script type=""text/javascript"">" &
      "  function validate_BuyerID(o) {" &
      "    validated_FK_PAK_PO_BuyerID_main = true;" &
      "    validate_FK_PAK_PO_BuyerID(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateBuyerID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateBuyerID", validateScriptBuyerID)
    End If
    Dim validateScriptFK_PAK_PO_BuyerID As String = "<script type=""text/javascript"">" &
      "  function validate_FK_PAK_PO_BuyerID(o) {" &
      "    var value = o.id;" &
      "    var BuyerID = $get('" & F_BuyerID.ClientID & "');" &
      "    try{" &
      "    if(BuyerID.value==''){" &
      "      if(validated_FK_PAK_PO_BuyerID.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + BuyerID.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_PAK_PO_BuyerID(value, validated_FK_PAK_PO_BuyerID);" &
      "  }" &
      "  validated_FK_PAK_PO_BuyerID_main = false;" &
      "  function validated_FK_PAK_PO_BuyerID(result) {" &
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PAK_PO_BuyerID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PAK_PO_BuyerID", validateScriptFK_PAK_PO_BuyerID)
    End If
    Dim validateScriptFK_PAK_PO_IssuedBy As String = "<script type=""text/javascript"">" &
      "  function validate_FK_PAK_PO_IssuedBy(o) {" &
      "    var value = o.id;" &
      "    var IssuedBy = $get('" & F_IssuedBy.ClientID & "');" &
      "    try{" &
      "    if(IssuedBy.value==''){" &
      "      if(validated_FK_PAK_PO_IssuedBy.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + IssuedBy.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_PAK_PO_IssuedBy(value, validated_FK_PAK_PO_IssuedBy);" &
      "  }" &
      "  validated_FK_PAK_PO_IssuedBy_main = false;" &
      "  function validated_FK_PAK_PO_IssuedBy(result) {" &
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PAK_PO_IssuedBy") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PAK_PO_IssuedBy", validateScriptFK_PAK_PO_IssuedBy)
    End If
    Dim validateScriptFK_PAK_PO_ProjectID As String = "<script type=""text/javascript"">" &
      "  function validate_FK_PAK_PO_ProjectID(o) {" &
      "    var value = o.id;" &
      "    var ProjectID = $get('" & F_ProjectID.ClientID & "');" &
      "    try{" &
      "    if(ProjectID.value==''){" &
      "      if(validated_FK_PAK_PO_ProjectID.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + ProjectID.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_PAK_PO_ProjectID(value, validated_FK_PAK_PO_ProjectID);" &
      "  }" &
      "  validated_FK_PAK_PO_ProjectID_main = false;" &
      "  function validated_FK_PAK_PO_ProjectID(result) {" &
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PAK_PO_ProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PAK_PO_ProjectID", validateScriptFK_PAK_PO_ProjectID)
    End If
    Dim validateScriptFK_PAK_SupplierID As String = "<script type=""text/javascript"">" &
      "  function validate_FK_PAK_SupplierID(o) {" &
      "    var value = o.id;" &
      "    var SupplierID = $get('" & F_SupplierID.ClientID & "');" &
      "    try{" &
      "    if(SupplierID.value==''){" &
      "      if(validated_FK_PAK_SupplierID.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + SupplierID.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_PAK_SupplierID(value, validated_FK_PAK_SupplierID);" &
      "  }" &
      "  validated_FK_PAK_SupplierID_main = false;" &
      "  function validated_FK_PAK_SupplierID(result) {" &
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PAK_SupplierID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PAK_SupplierID", validateScriptFK_PAK_SupplierID)
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PAK_PO_BuyerID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim BuyerID As String = CType(aVal(1), String)
    Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(BuyerID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PAK_PO_IssuedBy(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim IssuedBy As String = CType(aVal(1), String)
    Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(IssuedBy)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PAK_PO_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1), String)
    Dim oVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PAK_SupplierID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim SupplierID As String = CType(aVal(1), String)
    Dim oVar As SIS.PAK.pakBusinessPartner = SIS.PAK.pakBusinessPartner.pakBusinessPartnerGetByID(SupplierID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function

  'Private Sub cmdImport_Click(sender As Object, e As EventArgs) Handles cmdImport.Click
  '  Try
  '    SIS.PAK.erpData.erpPO.ImportFromERP("", F_PONumber.Text)
  '    GVpakPO.DataBind()
  '  Catch ex As Exception
  '    Dim message As String = New JavaScriptSerializer().Serialize(ex.Message.ToString())
  '    Dim script As String = String.Format("alert({0});", message)
  '    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
  '  End Try

  'End Sub
End Class
