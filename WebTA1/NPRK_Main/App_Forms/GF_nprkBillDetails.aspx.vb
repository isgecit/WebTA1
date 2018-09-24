Partial Class GF_nprkBillDetails
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/NPRK_Main/App_Display/DF_nprkBillDetails.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ClaimID=" & aVal(0) & "&ApplicationID=" & aVal(1) & "&AttachmentID=" & aVal(2)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVnprkBillDetails_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVnprkBillDetails.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ClaimID As Int32 = GVnprkBillDetails.DataKeys(e.CommandArgument).Values("ClaimID")  
        Dim ApplicationID As Int32 = GVnprkBillDetails.DataKeys(e.CommandArgument).Values("ApplicationID")  
        Dim AttachmentID As Int32 = GVnprkBillDetails.DataKeys(e.CommandArgument).Values("AttachmentID")  
        Dim RedirectUrl As String = TBLnprkBillDetails.EditUrl & "?ClaimID=" & ClaimID & "&ApplicationID=" & ApplicationID & "&AttachmentID=" & AttachmentID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVnprkBillDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVnprkBillDetails.Init
    DataClassName = "GnprkBillDetails"
    SetGridView = GVnprkBillDetails
  End Sub
  Protected Sub TBLnprkBillDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkBillDetails.Init
    SetToolBar = TBLnprkBillDetails
  End Sub
  Protected Sub F_ApplicationID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ApplicationID.TextChanged
    Session("F_ApplicationID") = F_ApplicationID.Text
    Session("F_ApplicationID_Display") = F_ApplicationID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ApplicationIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.NPRK.nprkApplications.SelectnprkApplicationsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_ClaimID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ClaimID.TextChanged
    Session("F_ClaimID") = F_ClaimID.Text
    Session("F_ClaimID_Display") = F_ClaimID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ClaimIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.NPRK.nprkUserClaims.SelectnprkUserClaimsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_ApplicationID_Display.Text = String.Empty
    If Not Session("F_ApplicationID_Display") Is Nothing Then
      If Session("F_ApplicationID_Display") <> String.Empty Then
        F_ApplicationID_Display.Text = Session("F_ApplicationID_Display")
      End If
    End If
    F_ApplicationID.Text = String.Empty
    If Not Session("F_ApplicationID") Is Nothing Then
      If Session("F_ApplicationID") <> String.Empty Then
        F_ApplicationID.Text = Session("F_ApplicationID")
      End If
    End If
    Dim strScriptApplicationID As String = "<script type=""text/javascript""> " & _
      "function ACEApplicationID_Selected(sender, e) {" & _
      "  var F_ApplicationID = $get('" & F_ApplicationID.ClientID & "');" & _
      "  var F_ApplicationID_Display = $get('" & F_ApplicationID_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_ApplicationID.value = p[1];" & _
      "  F_ApplicationID_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ApplicationID") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ApplicationID", strScriptApplicationID)
      End If
    Dim strScriptPopulatingApplicationID As String = "<script type=""text/javascript""> " & _
      "function ACEApplicationID_Populating(o,e) {" & _
      "  var p = $get('" & F_ApplicationID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEApplicationID_Populated(o,e) {" & _
      "  var p = $get('" & F_ApplicationID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ApplicationIDPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ApplicationIDPopulating", strScriptPopulatingApplicationID)
      End If
    F_ClaimID_Display.Text = String.Empty
    If Not Session("F_ClaimID_Display") Is Nothing Then
      If Session("F_ClaimID_Display") <> String.Empty Then
        F_ClaimID_Display.Text = Session("F_ClaimID_Display")
      End If
    End If
    F_ClaimID.Text = String.Empty
    If Not Session("F_ClaimID") Is Nothing Then
      If Session("F_ClaimID") <> String.Empty Then
        F_ClaimID.Text = Session("F_ClaimID")
      End If
    End If
    Dim strScriptClaimID As String = "<script type=""text/javascript""> " & _
      "function ACEClaimID_Selected(sender, e) {" & _
      "  var F_ClaimID = $get('" & F_ClaimID.ClientID & "');" & _
      "  var F_ClaimID_Display = $get('" & F_ClaimID_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_ClaimID.value = p[0];" & _
      "  F_ClaimID_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ClaimID") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ClaimID", strScriptClaimID)
      End If
    Dim strScriptPopulatingClaimID As String = "<script type=""text/javascript""> " & _
      "function ACEClaimID_Populating(o,e) {" & _
      "  var p = $get('" & F_ClaimID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEClaimID_Populated(o,e) {" & _
      "  var p = $get('" & F_ClaimID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ClaimIDPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ClaimIDPopulating", strScriptPopulatingClaimID)
      End If
    Dim validateScriptApplicationID As String = "<script type=""text/javascript"">" & _
      "  function validate_ApplicationID(o) {" & _
      "    validated_FK_PRK_BillDetails_PRK_Applications_main = true;" & _
      "    validate_FK_PRK_BillDetails_PRK_Applications(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateApplicationID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateApplicationID", validateScriptApplicationID)
    End If
    Dim validateScriptClaimID As String = "<script type=""text/javascript"">" & _
      "  function validate_ClaimID(o) {" & _
      "    validated_FK_PRK_BillDetails_ClaimID_main = true;" & _
      "    validate_FK_PRK_BillDetails_ClaimID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateClaimID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateClaimID", validateScriptClaimID)
    End If
    Dim validateScriptFK_PRK_BillDetails_PRK_Applications As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PRK_BillDetails_PRK_Applications(o) {" & _
      "    var value = o.id;" & _
      "    var ClaimID = $get('" & F_ClaimID.ClientID & "');" & _
      "    try{" & _
      "    if(ClaimID.value==''){" & _
      "      if(validated_FK_PRK_BillDetails_PRK_Applications.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + ClaimID.value ;" & _
      "    }catch(ex){}" & _
      "    var ApplicationID = $get('" & F_ApplicationID.ClientID & "');" & _
      "    try{" & _
      "    if(ApplicationID.value==''){" & _
      "      if(validated_FK_PRK_BillDetails_PRK_Applications.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + ApplicationID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PRK_BillDetails_PRK_Applications(value, validated_FK_PRK_BillDetails_PRK_Applications);" & _
      "  }" & _
      "  validated_FK_PRK_BillDetails_PRK_Applications_main = false;" & _
      "  function validated_FK_PRK_BillDetails_PRK_Applications(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PRK_BillDetails_PRK_Applications") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PRK_BillDetails_PRK_Applications", validateScriptFK_PRK_BillDetails_PRK_Applications)
    End If
    Dim validateScriptFK_PRK_BillDetails_ClaimID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PRK_BillDetails_ClaimID(o) {" & _
      "    var value = o.id;" & _
      "    var ClaimID = $get('" & F_ClaimID.ClientID & "');" & _
      "    try{" & _
      "    if(ClaimID.value==''){" & _
      "      if(validated_FK_PRK_BillDetails_ClaimID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + ClaimID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PRK_BillDetails_ClaimID(value, validated_FK_PRK_BillDetails_ClaimID);" & _
      "  }" & _
      "  validated_FK_PRK_BillDetails_ClaimID_main = false;" & _
      "  function validated_FK_PRK_BillDetails_ClaimID(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PRK_BillDetails_ClaimID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PRK_BillDetails_ClaimID", validateScriptFK_PRK_BillDetails_ClaimID)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PRK_BillDetails_PRK_Applications(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ClaimID As Int32 = CType(aVal(1),Int32)
    Dim ApplicationID As Int32 = CType(aVal(2),Int32)
    Dim oVar As SIS.NPRK.nprkApplications = SIS.NPRK.nprkApplications.nprkApplicationsGetByID(ClaimID,ApplicationID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PRK_BillDetails_ClaimID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ClaimID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.NPRK.nprkUserClaims = SIS.NPRK.nprkUserClaims.nprkUserClaimsGetByID(ClaimID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
