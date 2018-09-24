Imports System.Web.Script.Serialization
Partial Class GF_pakSitePkgH
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PAK_Main/App_Display/DF_pakSitePkgH.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ProjectID=" & aVal(0) & "&RecNo=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpakSitePkgH_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakSitePkgH.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ProjectID As String = GVpakSitePkgH.DataKeys(e.CommandArgument).Values("ProjectID")  
        Dim RecNo As Int32 = GVpakSitePkgH.DataKeys(e.CommandArgument).Values("RecNo")  
        Dim RedirectUrl As String = TBLpakSitePkgH.EditUrl & "?ProjectID=" & ProjectID & "&RecNo=" & RecNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim ProjectID As String = GVpakSitePkgH.DataKeys(e.CommandArgument).Values("ProjectID")  
        Dim RecNo As Int32 = GVpakSitePkgH.DataKeys(e.CommandArgument).Values("RecNo")  
        SIS.PAK.pakSitePkgH.InitiateWF(ProjectID, RecNo)
        GVpakSitePkgH.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "approvewf".ToLower Then
      Try
        Dim ProjectID As String = GVpakSitePkgH.DataKeys(e.CommandArgument).Values("ProjectID")  
        Dim RecNo As Int32 = GVpakSitePkgH.DataKeys(e.CommandArgument).Values("RecNo")  
        SIS.PAK.pakSitePkgH.ApproveWF(ProjectID, RecNo)
        GVpakSitePkgH.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpakSitePkgH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakSitePkgH.Init
    DataClassName = "GpakSitePkgH"
    SetGridView = GVpakSitePkgH
  End Sub
  Protected Sub TBLpakSitePkgH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSitePkgH.Init
    SetToolBar = TBLpakSitePkgH
  End Sub
  Protected Sub F_SerialNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_SerialNo.TextChanged
    Session("F_SerialNo") = F_SerialNo.Text
    Session("F_SerialNo_Display") = F_SerialNo_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SerialNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakPO.SelectpakPOAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_PkgNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_PkgNo.TextChanged
    Session("F_PkgNo") = F_PkgNo.Text
    Session("F_PkgNo_Display") = F_PkgNo_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function PkgNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakPkgListH.SelectpakPkgListHAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_ProjectID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ProjectID.TextChanged
    Session("F_ProjectID") = F_ProjectID.Text
    Session("F_ProjectID_Display") = F_ProjectID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.EITL.eitlProjects.SelecteitlProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_SupplierID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_SupplierID.TextChanged
    Session("F_SupplierID") = F_SupplierID.Text
    Session("F_SupplierID_Display") = F_SupplierID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SupplierIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakBusinessPartner.SelectpakBusinessPartnerAutoCompleteList(prefixText, count, contextKey)
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
    F_PkgNo_Display.Text = String.Empty
    If Not Session("F_PkgNo_Display") Is Nothing Then
      If Session("F_PkgNo_Display") <> String.Empty Then
        F_PkgNo_Display.Text = Session("F_PkgNo_Display")
      End If
    End If
    F_PkgNo.Text = String.Empty
    If Not Session("F_PkgNo") Is Nothing Then
      If Session("F_PkgNo") <> String.Empty Then
        F_PkgNo.Text = Session("F_PkgNo")
      End If
    End If
    Dim strScriptPkgNo As String = "<script type=""text/javascript""> " & _
      "function ACEPkgNo_Selected(sender, e) {" & _
      "  var F_PkgNo = $get('" & F_PkgNo.ClientID & "');" & _
      "  var F_PkgNo_Display = $get('" & F_PkgNo_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_PkgNo.value = p[1];" & _
      "  F_PkgNo_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_PkgNo") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_PkgNo", strScriptPkgNo)
      End If
    Dim strScriptPopulatingPkgNo As String = "<script type=""text/javascript""> " & _
      "function ACEPkgNo_Populating(o,e) {" & _
      "  var p = $get('" & F_PkgNo.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEPkgNo_Populated(o,e) {" & _
      "  var p = $get('" & F_PkgNo.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_PkgNoPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_PkgNoPopulating", strScriptPopulatingPkgNo)
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
      "    validated_FK_PAK_SitePkgH_SerialNo_main = true;" & _
      "    validate_FK_PAK_SitePkgH_SerialNo(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateSerialNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateSerialNo", validateScriptSerialNo)
    End If
    Dim validateScriptPkgNo As String = "<script type=""text/javascript"">" & _
      "  function validate_PkgNo(o) {" & _
      "    validated_FK_PAK_SitePkgH_PkgNo_main = true;" & _
      "    validate_FK_PAK_SitePkgH_PkgNo(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validatePkgNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validatePkgNo", validateScriptPkgNo)
    End If
    Dim validateScriptProjectID As String = "<script type=""text/javascript"">" & _
      "  function validate_ProjectID(o) {" & _
      "    validated_FK_PAK_SitePkgH_ProjectID_main = true;" & _
      "    validate_FK_PAK_SitePkgH_ProjectID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateProjectID", validateScriptProjectID)
    End If
    Dim validateScriptSupplierID As String = "<script type=""text/javascript"">" & _
      "  function validate_SupplierID(o) {" & _
      "    validated_FK_PAK_SitePkgH_SupplierID_main = true;" & _
      "    validate_FK_PAK_SitePkgH_SupplierID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateSupplierID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateSupplierID", validateScriptSupplierID)
    End If
    Dim validateScriptFK_PAK_SitePkgH_ProjectID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PAK_SitePkgH_ProjectID(o) {" & _
      "    var value = o.id;" & _
      "    var ProjectID = $get('" & F_ProjectID.ClientID & "');" & _
      "    try{" & _
      "    if(ProjectID.value==''){" & _
      "      if(validated_FK_PAK_SitePkgH_ProjectID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + ProjectID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PAK_SitePkgH_ProjectID(value, validated_FK_PAK_SitePkgH_ProjectID);" & _
      "  }" & _
      "  validated_FK_PAK_SitePkgH_ProjectID_main = false;" & _
      "  function validated_FK_PAK_SitePkgH_ProjectID(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PAK_SitePkgH_ProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PAK_SitePkgH_ProjectID", validateScriptFK_PAK_SitePkgH_ProjectID)
    End If
    Dim validateScriptFK_PAK_SitePkgH_PkgNo As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PAK_SitePkgH_PkgNo(o) {" & _
      "    var value = o.id;" & _
      "    var SerialNo = $get('" & F_SerialNo.ClientID & "');" & _
      "    try{" & _
      "    if(SerialNo.value==''){" & _
      "      if(validated_FK_PAK_SitePkgH_PkgNo.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + SerialNo.value ;" & _
      "    }catch(ex){}" & _
      "    var PkgNo = $get('" & F_PkgNo.ClientID & "');" & _
      "    try{" & _
      "    if(PkgNo.value==''){" & _
      "      if(validated_FK_PAK_SitePkgH_PkgNo.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + PkgNo.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PAK_SitePkgH_PkgNo(value, validated_FK_PAK_SitePkgH_PkgNo);" & _
      "  }" & _
      "  validated_FK_PAK_SitePkgH_PkgNo_main = false;" & _
      "  function validated_FK_PAK_SitePkgH_PkgNo(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PAK_SitePkgH_PkgNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PAK_SitePkgH_PkgNo", validateScriptFK_PAK_SitePkgH_PkgNo)
    End If
    Dim validateScriptFK_PAK_SitePkgH_SerialNo As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PAK_SitePkgH_SerialNo(o) {" & _
      "    var value = o.id;" & _
      "    var SerialNo = $get('" & F_SerialNo.ClientID & "');" & _
      "    try{" & _
      "    if(SerialNo.value==''){" & _
      "      if(validated_FK_PAK_SitePkgH_SerialNo.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + SerialNo.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PAK_SitePkgH_SerialNo(value, validated_FK_PAK_SitePkgH_SerialNo);" & _
      "  }" & _
      "  validated_FK_PAK_SitePkgH_SerialNo_main = false;" & _
      "  function validated_FK_PAK_SitePkgH_SerialNo(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PAK_SitePkgH_SerialNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PAK_SitePkgH_SerialNo", validateScriptFK_PAK_SitePkgH_SerialNo)
    End If
    Dim validateScriptFK_PAK_SitePkgH_SupplierID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PAK_SitePkgH_SupplierID(o) {" & _
      "    var value = o.id;" & _
      "    var SupplierID = $get('" & F_SupplierID.ClientID & "');" & _
      "    try{" & _
      "    if(SupplierID.value==''){" & _
      "      if(validated_FK_PAK_SitePkgH_SupplierID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + SupplierID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PAK_SitePkgH_SupplierID(value, validated_FK_PAK_SitePkgH_SupplierID);" & _
      "  }" & _
      "  validated_FK_PAK_SitePkgH_SupplierID_main = false;" & _
      "  function validated_FK_PAK_SitePkgH_SupplierID(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PAK_SitePkgH_SupplierID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PAK_SitePkgH_SupplierID", validateScriptFK_PAK_SitePkgH_SupplierID)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SitePkgH_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1),String)
    Dim oVar As SIS.EITL.eitlProjects = SIS.EITL.eitlProjects.eitlProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SitePkgH_PkgNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SerialNo As Int32 = CType(aVal(1),Int32)
    Dim PkgNo As Int32 = CType(aVal(2),Int32)
    Dim oVar As SIS.PAK.pakPkgListH = SIS.PAK.pakPkgListH.pakPkgListHGetByID(SerialNo,PkgNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SitePkgH_SerialNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SerialNo As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PAK.pakPO = SIS.PAK.pakPO.pakPOGetByID(SerialNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SitePkgH_SupplierID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SupplierID As String = CType(aVal(1),String)
    Dim oVar As SIS.PAK.pakBusinessPartner = SIS.PAK.pakBusinessPartner.pakBusinessPartnerGetByID(SupplierID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
