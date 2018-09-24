Partial Class GF_elogIRBL
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ELOG_Main/App_Display/DF_elogIRBL.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?IRNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVelogIRBL_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVelogIRBL.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim IRNo As Int32 = GVelogIRBL.DataKeys(e.CommandArgument).Values("IRNo")  
        Dim RedirectUrl As String = TBLelogIRBL.EditUrl & "?IRNo=" & IRNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "approvewf".ToLower Then
      Try
        Dim IRNo As Int32 = GVelogIRBL.DataKeys(e.CommandArgument).Values("IRNo")  
        SIS.ELOG.elogIRBL.ApproveWF(IRNo)
        GVelogIRBL.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVelogIRBL_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVelogIRBL.Init
    DataClassName = "GelogIRBL"
    SetGridView = GVelogIRBL
  End Sub
  Protected Sub TBLelogIRBL_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogIRBL.Init
    SetToolBar = TBLelogIRBL
  End Sub
  Protected Sub F_SupplierID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_SupplierID.TextChanged
    Session("F_SupplierID") = F_SupplierID.Text
    Session("F_SupplierID_Display") = F_SupplierID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SupplierIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.VR.vrBusinessPartner.SelectvrBusinessPartnerAutoCompleteList(prefixText, count, contextKey)
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
  Protected Sub F_BLID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_BLID.TextChanged
    Session("F_BLID") = F_BLID.Text
    Session("F_BLID_Display") = F_BLID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function BLIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ELOG.elogBLHeader.SelectelogBLHeaderAutoCompleteList(prefixText, count, contextKey)
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
    F_BLID_Display.Text = String.Empty
    If Not Session("F_BLID_Display") Is Nothing Then
      If Session("F_BLID_Display") <> String.Empty Then
        F_BLID_Display.Text = Session("F_BLID_Display")
      End If
    End If
    F_BLID.Text = String.Empty
    If Not Session("F_BLID") Is Nothing Then
      If Session("F_BLID") <> String.Empty Then
        F_BLID.Text = Session("F_BLID")
      End If
    End If
    Dim strScriptBLID As String = "<script type=""text/javascript""> " & _
      "function ACEBLID_Selected(sender, e) {" & _
      "  var F_BLID = $get('" & F_BLID.ClientID & "');" & _
      "  var F_BLID_Display = $get('" & F_BLID_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_BLID.value = p[0];" & _
      "  F_BLID_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_BLID") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_BLID", strScriptBLID)
      End If
    Dim strScriptPopulatingBLID As String = "<script type=""text/javascript""> " & _
      "function ACEBLID_Populating(o,e) {" & _
      "  var p = $get('" & F_BLID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEBLID_Populated(o,e) {" & _
      "  var p = $get('" & F_BLID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_BLIDPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_BLIDPopulating", strScriptPopulatingBLID)
      End If
    Dim validateScriptSupplierID As String = "<script type=""text/javascript"">" & _
      "  function validate_SupplierID(o) {" & _
      "    validated_FK_ELOG_IRBL_SupplierID_main = true;" & _
      "    validate_FK_ELOG_IRBL_SupplierID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateSupplierID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateSupplierID", validateScriptSupplierID)
    End If
    Dim validateScriptProjectID As String = "<script type=""text/javascript"">" & _
      "  function validate_ProjectID(o) {" & _
      "    validated_FK_ELOG_IRBL_ProjectID_main = true;" & _
      "    validate_FK_ELOG_IRBL_ProjectID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateProjectID", validateScriptProjectID)
    End If
    Dim validateScriptBLID As String = "<script type=""text/javascript"">" & _
      "  function validate_BLID(o) {" & _
      "    validated_FK_ELOG_IRBL_BLID_main = true;" & _
      "    validate_FK_ELOG_IRBL_BLID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateBLID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateBLID", validateScriptBLID)
    End If
    Dim validateScriptFK_ELOG_IRBL_BLID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_ELOG_IRBL_BLID(o) {" & _
      "    var value = o.id;" & _
      "    var BLID = $get('" & F_BLID.ClientID & "');" & _
      "    try{" & _
      "    if(BLID.value==''){" & _
      "      if(validated_FK_ELOG_IRBL_BLID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + BLID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_ELOG_IRBL_BLID(value, validated_FK_ELOG_IRBL_BLID);" & _
      "  }" & _
      "  validated_FK_ELOG_IRBL_BLID_main = false;" & _
      "  function validated_FK_ELOG_IRBL_BLID(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ELOG_IRBL_BLID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ELOG_IRBL_BLID", validateScriptFK_ELOG_IRBL_BLID)
    End If
    Dim validateScriptFK_ELOG_IRBL_ProjectID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_ELOG_IRBL_ProjectID(o) {" & _
      "    var value = o.id;" & _
      "    var ProjectID = $get('" & F_ProjectID.ClientID & "');" & _
      "    try{" & _
      "    if(ProjectID.value==''){" & _
      "      if(validated_FK_ELOG_IRBL_ProjectID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + ProjectID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_ELOG_IRBL_ProjectID(value, validated_FK_ELOG_IRBL_ProjectID);" & _
      "  }" & _
      "  validated_FK_ELOG_IRBL_ProjectID_main = false;" & _
      "  function validated_FK_ELOG_IRBL_ProjectID(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ELOG_IRBL_ProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ELOG_IRBL_ProjectID", validateScriptFK_ELOG_IRBL_ProjectID)
    End If
    Dim validateScriptFK_ELOG_IRBL_SupplierID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_ELOG_IRBL_SupplierID(o) {" & _
      "    var value = o.id;" & _
      "    var SupplierID = $get('" & F_SupplierID.ClientID & "');" & _
      "    try{" & _
      "    if(SupplierID.value==''){" & _
      "      if(validated_FK_ELOG_IRBL_SupplierID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + SupplierID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_ELOG_IRBL_SupplierID(value, validated_FK_ELOG_IRBL_SupplierID);" & _
      "  }" & _
      "  validated_FK_ELOG_IRBL_SupplierID_main = false;" & _
      "  function validated_FK_ELOG_IRBL_SupplierID(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ELOG_IRBL_SupplierID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ELOG_IRBL_SupplierID", validateScriptFK_ELOG_IRBL_SupplierID)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ELOG_IRBL_BLID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim BLID As String = CType(aVal(1),String)
    Dim oVar As SIS.ELOG.elogBLHeader = SIS.ELOG.elogBLHeader.elogBLHeaderGetByID(BLID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ELOG_IRBL_ProjectID(ByVal value As String) As String
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
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ELOG_IRBL_SupplierID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SupplierID As String = CType(aVal(1),String)
    Dim oVar As SIS.VR.vrBusinessPartner = SIS.VR.vrBusinessPartner.vrBusinessPartnerGetByID(SupplierID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
