Partial Class GF_nprkApplications
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/NPRK_Main/App_Display/DF_nprkApplications.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ApplicationID=" & aVal(0) & "&ClaimID=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVnprkApplications_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVnprkApplications.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ApplicationID As Int32 = GVnprkApplications.DataKeys(e.CommandArgument).Values("ApplicationID")  
        Dim ClaimID As Int32 = GVnprkApplications.DataKeys(e.CommandArgument).Values("ClaimID")  
        Dim RedirectUrl As String = TBLnprkApplications.EditUrl & "?ApplicationID=" & ApplicationID & "&ClaimID=" & ClaimID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVnprkApplications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVnprkApplications.Init
    DataClassName = "GnprkApplications"
    SetGridView = GVnprkApplications
  End Sub
  Protected Sub TBLnprkApplications_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkApplications.Init
    SetToolBar = TBLnprkApplications
  End Sub
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
    Dim validateScriptClaimID As String = "<script type=""text/javascript"">" & _
      "  function validate_ClaimID(o) {" & _
      "    validated_FK_PRK_Applications_ClaimID_main = true;" & _
      "    validate_FK_PRK_Applications_ClaimID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateClaimID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateClaimID", validateScriptClaimID)
    End If
    Dim validateScriptFK_PRK_Applications_ClaimID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PRK_Applications_ClaimID(o) {" & _
      "    var value = o.id;" & _
      "    var ClaimID = $get('" & F_ClaimID.ClientID & "');" & _
      "    try{" & _
      "    if(ClaimID.value==''){" & _
      "      if(validated_FK_PRK_Applications_ClaimID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + ClaimID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PRK_Applications_ClaimID(value, validated_FK_PRK_Applications_ClaimID);" & _
      "  }" & _
      "  validated_FK_PRK_Applications_ClaimID_main = false;" & _
      "  function validated_FK_PRK_Applications_ClaimID(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PRK_Applications_ClaimID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PRK_Applications_ClaimID", validateScriptFK_PRK_Applications_ClaimID)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PRK_Applications_ClaimID(ByVal value As String) As String
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
