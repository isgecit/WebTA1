Imports System.Web.Script.Serialization
Partial Class GF_pakSiteMtlIssD
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PAK_Main/App_Display/DF_pakSiteMtlIssD.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ProjectID=" & aVal(0) & "&IssueNo=" & aVal(1) & "&IssueSrNo=" & aVal(2)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpakSiteMtlIssD_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakSiteMtlIssD.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ProjectID As String = GVpakSiteMtlIssD.DataKeys(e.CommandArgument).Values("ProjectID")  
        Dim IssueNo As Int32 = GVpakSiteMtlIssD.DataKeys(e.CommandArgument).Values("IssueNo")  
        Dim IssueSrNo As Int32 = GVpakSiteMtlIssD.DataKeys(e.CommandArgument).Values("IssueSrNo")  
        Dim RedirectUrl As String = TBLpakSiteMtlIssD.EditUrl & "?ProjectID=" & ProjectID & "&IssueNo=" & IssueNo & "&IssueSrNo=" & IssueSrNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "approvewf".ToLower Then
      Try
        Dim ProjectID As String = GVpakSiteMtlIssD.DataKeys(e.CommandArgument).Values("ProjectID")  
        Dim IssueNo As Int32 = GVpakSiteMtlIssD.DataKeys(e.CommandArgument).Values("IssueNo")  
        Dim IssueSrNo As Int32 = GVpakSiteMtlIssD.DataKeys(e.CommandArgument).Values("IssueSrNo")  
        SIS.PAK.pakSiteMtlIssD.ApproveWF(ProjectID, IssueNo, IssueSrNo)
        GVpakSiteMtlIssD.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpakSiteMtlIssD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakSiteMtlIssD.Init
    DataClassName = "GpakSiteMtlIssD"
    SetGridView = GVpakSiteMtlIssD
  End Sub
  Protected Sub TBLpakSiteMtlIssD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSiteMtlIssD.Init
    SetToolBar = TBLpakSiteMtlIssD
  End Sub
  Protected Sub F_IssueNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_IssueNo.TextChanged
    Session("F_IssueNo") = F_IssueNo.Text
    Session("F_IssueNo_Display") = F_IssueNo_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function IssueNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakSiteIssReqH.SelectpakSiteIssReqHAutoCompleteList(prefixText, count, contextKey)
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
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_IssueNo_Display.Text = String.Empty
    If Not Session("F_IssueNo_Display") Is Nothing Then
      If Session("F_IssueNo_Display") <> String.Empty Then
        F_IssueNo_Display.Text = Session("F_IssueNo_Display")
      End If
    End If
    F_IssueNo.Text = String.Empty
    If Not Session("F_IssueNo") Is Nothing Then
      If Session("F_IssueNo") <> String.Empty Then
        F_IssueNo.Text = Session("F_IssueNo")
      End If
    End If
    Dim strScriptIssueNo As String = "<script type=""text/javascript""> " & _
      "function ACEIssueNo_Selected(sender, e) {" & _
      "  var F_IssueNo = $get('" & F_IssueNo.ClientID & "');" & _
      "  var F_IssueNo_Display = $get('" & F_IssueNo_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_IssueNo.value = p[1];" & _
      "  F_IssueNo_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_IssueNo") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_IssueNo", strScriptIssueNo)
      End If
    Dim strScriptPopulatingIssueNo As String = "<script type=""text/javascript""> " & _
      "function ACEIssueNo_Populating(o,e) {" & _
      "  var p = $get('" & F_IssueNo.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEIssueNo_Populated(o,e) {" & _
      "  var p = $get('" & F_IssueNo.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_IssueNoPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_IssueNoPopulating", strScriptPopulatingIssueNo)
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
    Dim validateScriptIssueNo As String = "<script type=""text/javascript"">" & _
      "  function validate_IssueNo(o) {" & _
      "    validated_FK_PAK_SiteIssueD_IssueNo_main = true;" & _
      "    validate_FK_PAK_SiteIssueD_IssueNo(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateIssueNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateIssueNo", validateScriptIssueNo)
    End If
    Dim validateScriptProjectID As String = "<script type=""text/javascript"">" & _
      "  function validate_ProjectID(o) {" & _
      "    validated_FK_PAK_SiteIssueD_ProjectID_main = true;" & _
      "    validate_FK_PAK_SiteIssueD_ProjectID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateProjectID", validateScriptProjectID)
    End If
    Dim validateScriptFK_PAK_SiteIssueD_ProjectID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PAK_SiteIssueD_ProjectID(o) {" & _
      "    var value = o.id;" & _
      "    var ProjectID = $get('" & F_ProjectID.ClientID & "');" & _
      "    try{" & _
      "    if(ProjectID.value==''){" & _
      "      if(validated_FK_PAK_SiteIssueD_ProjectID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + ProjectID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PAK_SiteIssueD_ProjectID(value, validated_FK_PAK_SiteIssueD_ProjectID);" & _
      "  }" & _
      "  validated_FK_PAK_SiteIssueD_ProjectID_main = false;" & _
      "  function validated_FK_PAK_SiteIssueD_ProjectID(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PAK_SiteIssueD_ProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PAK_SiteIssueD_ProjectID", validateScriptFK_PAK_SiteIssueD_ProjectID)
    End If
    Dim validateScriptFK_PAK_SiteIssueD_IssueNo As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PAK_SiteIssueD_IssueNo(o) {" & _
      "    var value = o.id;" & _
      "    var ProjectID = $get('" & F_ProjectID.ClientID & "');" & _
      "    try{" & _
      "    if(ProjectID.value==''){" & _
      "      if(validated_FK_PAK_SiteIssueD_IssueNo.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + ProjectID.value ;" & _
      "    }catch(ex){}" & _
      "    var IssueNo = $get('" & F_IssueNo.ClientID & "');" & _
      "    try{" & _
      "    if(IssueNo.value==''){" & _
      "      if(validated_FK_PAK_SiteIssueD_IssueNo.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + IssueNo.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PAK_SiteIssueD_IssueNo(value, validated_FK_PAK_SiteIssueD_IssueNo);" & _
      "  }" & _
      "  validated_FK_PAK_SiteIssueD_IssueNo_main = false;" & _
      "  function validated_FK_PAK_SiteIssueD_IssueNo(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PAK_SiteIssueD_IssueNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PAK_SiteIssueD_IssueNo", validateScriptFK_PAK_SiteIssueD_IssueNo)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SiteIssueD_ProjectID(ByVal value As String) As String
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
  Public Shared Function validate_FK_PAK_SiteIssueD_IssueNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1),String)
    Dim IssueNo As Int32 = CType(aVal(2),Int32)
    Dim oVar As SIS.PAK.pakSiteIssReqH = SIS.PAK.pakSiteIssReqH.pakSiteIssReqHGetByID(ProjectID,IssueNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
