Imports System.Web.Script.Serialization
Partial Class GF_pakSiteItemMasterLocation
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PAK_Main/App_Display/DF_pakSiteItemMasterLocation.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ProjectID=" & aVal(0) & "&SiteMarkNo=" & aVal(1) & "&LocationID=" & aVal(2)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpakSiteItemMasterLocation_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakSiteItemMasterLocation.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ProjectID As String = GVpakSiteItemMasterLocation.DataKeys(e.CommandArgument).Values("ProjectID")  
        Dim SiteMarkNo As String = GVpakSiteItemMasterLocation.DataKeys(e.CommandArgument).Values("SiteMarkNo")  
        Dim LocationID As Int32 = GVpakSiteItemMasterLocation.DataKeys(e.CommandArgument).Values("LocationID")  
        Dim RedirectUrl As String = TBLpakSiteItemMasterLocation.EditUrl & "?ProjectID=" & ProjectID & "&SiteMarkNo=" & SiteMarkNo & "&LocationID=" & LocationID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpakSiteItemMasterLocation_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakSiteItemMasterLocation.Init
    DataClassName = "GpakSiteItemMasterLocation"
    SetGridView = GVpakSiteItemMasterLocation
  End Sub
  Protected Sub TBLpakSiteItemMasterLocation_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSiteItemMasterLocation.Init
    SetToolBar = TBLpakSiteItemMasterLocation
  End Sub
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
  Protected Sub F_SiteMarkNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_SiteMarkNo.TextChanged
    Session("F_SiteMarkNo") = F_SiteMarkNo.Text
    Session("F_SiteMarkNo_Display") = F_SiteMarkNo_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SiteMarkNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakSiteItemMaster.SelectpakSiteItemMasterAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
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
    F_SiteMarkNo_Display.Text = String.Empty
    If Not Session("F_SiteMarkNo_Display") Is Nothing Then
      If Session("F_SiteMarkNo_Display") <> String.Empty Then
        F_SiteMarkNo_Display.Text = Session("F_SiteMarkNo_Display")
      End If
    End If
    F_SiteMarkNo.Text = String.Empty
    If Not Session("F_SiteMarkNo") Is Nothing Then
      If Session("F_SiteMarkNo") <> String.Empty Then
        F_SiteMarkNo.Text = Session("F_SiteMarkNo")
      End If
    End If
    Dim strScriptSiteMarkNo As String = "<script type=""text/javascript""> " & _
      "function ACESiteMarkNo_Selected(sender, e) {" & _
      "  var F_SiteMarkNo = $get('" & F_SiteMarkNo.ClientID & "');" & _
      "  var F_SiteMarkNo_Display = $get('" & F_SiteMarkNo_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_SiteMarkNo.value = p[1];" & _
      "  F_SiteMarkNo_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_SiteMarkNo") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_SiteMarkNo", strScriptSiteMarkNo)
      End If
    Dim strScriptPopulatingSiteMarkNo As String = "<script type=""text/javascript""> " & _
      "function ACESiteMarkNo_Populating(o,e) {" & _
      "  var p = $get('" & F_SiteMarkNo.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACESiteMarkNo_Populated(o,e) {" & _
      "  var p = $get('" & F_SiteMarkNo.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_SiteMarkNoPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_SiteMarkNoPopulating", strScriptPopulatingSiteMarkNo)
      End If
    Dim validateScriptProjectID As String = "<script type=""text/javascript"">" & _
      "  function validate_ProjectID(o) {" & _
      "    validated_FK_PAK_SiteItemMasterLocation_ProjectID_main = true;" & _
      "    validate_FK_PAK_SiteItemMasterLocation_ProjectID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateProjectID", validateScriptProjectID)
    End If
    Dim validateScriptSiteMarkNo As String = "<script type=""text/javascript"">" & _
      "  function validate_SiteMarkNo(o) {" & _
      "    validated_FK_PAK_SiteItemMasterLocation_SiteMarkNo_main = true;" & _
      "    validate_FK_PAK_SiteItemMasterLocation_SiteMarkNo(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateSiteMarkNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateSiteMarkNo", validateScriptSiteMarkNo)
    End If
    Dim validateScriptFK_PAK_SiteItemMasterLocation_ProjectID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PAK_SiteItemMasterLocation_ProjectID(o) {" & _
      "    var value = o.id;" & _
      "    var ProjectID = $get('" & F_ProjectID.ClientID & "');" & _
      "    try{" & _
      "    if(ProjectID.value==''){" & _
      "      if(validated_FK_PAK_SiteItemMasterLocation_ProjectID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + ProjectID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PAK_SiteItemMasterLocation_ProjectID(value, validated_FK_PAK_SiteItemMasterLocation_ProjectID);" & _
      "  }" & _
      "  validated_FK_PAK_SiteItemMasterLocation_ProjectID_main = false;" & _
      "  function validated_FK_PAK_SiteItemMasterLocation_ProjectID(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PAK_SiteItemMasterLocation_ProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PAK_SiteItemMasterLocation_ProjectID", validateScriptFK_PAK_SiteItemMasterLocation_ProjectID)
    End If
    Dim validateScriptFK_PAK_SiteItemMasterLocation_SiteMarkNo As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PAK_SiteItemMasterLocation_SiteMarkNo(o) {" & _
      "    var value = o.id;" & _
      "    var ProjectID = $get('" & F_ProjectID.ClientID & "');" & _
      "    try{" & _
      "    if(ProjectID.value==''){" & _
      "      if(validated_FK_PAK_SiteItemMasterLocation_SiteMarkNo.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + ProjectID.value ;" & _
      "    }catch(ex){}" & _
      "    var SiteMarkNo = $get('" & F_SiteMarkNo.ClientID & "');" & _
      "    try{" & _
      "    if(SiteMarkNo.value==''){" & _
      "      if(validated_FK_PAK_SiteItemMasterLocation_SiteMarkNo.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + SiteMarkNo.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PAK_SiteItemMasterLocation_SiteMarkNo(value, validated_FK_PAK_SiteItemMasterLocation_SiteMarkNo);" & _
      "  }" & _
      "  validated_FK_PAK_SiteItemMasterLocation_SiteMarkNo_main = false;" & _
      "  function validated_FK_PAK_SiteItemMasterLocation_SiteMarkNo(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PAK_SiteItemMasterLocation_SiteMarkNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PAK_SiteItemMasterLocation_SiteMarkNo", validateScriptFK_PAK_SiteItemMasterLocation_SiteMarkNo)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SiteItemMasterLocation_ProjectID(ByVal value As String) As String
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
  Public Shared Function validate_FK_PAK_SiteItemMasterLocation_SiteMarkNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1),String)
    Dim SiteMarkNo As String = CType(aVal(2),String)
    Dim oVar As SIS.PAK.pakSiteItemMaster = SIS.PAK.pakSiteItemMaster.pakSiteItemMasterGetByID(ProjectID,SiteMarkNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
