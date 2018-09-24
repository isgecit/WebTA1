Partial Class GF_nprkSiteAllowanceAdvice
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/NPRK_Main/App_Display/DF_nprkSiteAllowanceAdvice.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?FinYear=" & aVal(0) & "&Quarter=" & aVal(1) & "&AdviceNo=" & aVal(2)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVnprkSiteAllowanceAdvice_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVnprkSiteAllowanceAdvice.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim FinYear As Int32 = GVnprkSiteAllowanceAdvice.DataKeys(e.CommandArgument).Values("FinYear")  
        Dim Quarter As Int32 = GVnprkSiteAllowanceAdvice.DataKeys(e.CommandArgument).Values("Quarter")  
        Dim AdviceNo As Int32 = GVnprkSiteAllowanceAdvice.DataKeys(e.CommandArgument).Values("AdviceNo")  
        Dim RedirectUrl As String = TBLnprkSiteAllowanceAdvice.EditUrl & "?FinYear=" & FinYear & "&Quarter=" & Quarter & "&AdviceNo=" & AdviceNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim FinYear As Int32 = GVnprkSiteAllowanceAdvice.DataKeys(e.CommandArgument).Values("FinYear")  
        Dim Quarter As Int32 = GVnprkSiteAllowanceAdvice.DataKeys(e.CommandArgument).Values("Quarter")  
        Dim AdviceNo As Int32 = GVnprkSiteAllowanceAdvice.DataKeys(e.CommandArgument).Values("AdviceNo")  
        SIS.NPRK.nprkSiteAllowanceAdvice.InitiateWF(FinYear, Quarter, AdviceNo)
        GVnprkSiteAllowanceAdvice.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVnprkSiteAllowanceAdvice_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVnprkSiteAllowanceAdvice.Init
    DataClassName = "GnprkSiteAllowanceAdvice"
    SetGridView = GVnprkSiteAllowanceAdvice
  End Sub
  Protected Sub TBLnprkSiteAllowanceAdvice_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkSiteAllowanceAdvice.Init
    SetToolBar = TBLnprkSiteAllowanceAdvice
  End Sub
  Protected Sub F_FinYear_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_FinYear.TextChanged
    Session("F_FinYear") = F_FinYear.Text
    Session("F_FinYear_Display") = F_FinYear_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function FinYearCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.COST.costFinYear.SelectcostFinYearAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_Quarter_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_Quarter.TextChanged
    Session("F_Quarter") = F_Quarter.Text
    Session("F_Quarter_Display") = F_Quarter_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function QuarterCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.COST.costQuarters.SelectcostQuartersAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_StatusID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_StatusID.SelectedIndexChanged
    Session("F_StatusID") = F_StatusID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_FinYear_Display.Text = String.Empty
    If Not Session("F_FinYear_Display") Is Nothing Then
      If Session("F_FinYear_Display") <> String.Empty Then
        F_FinYear_Display.Text = Session("F_FinYear_Display")
      End If
    End If
    F_FinYear.Text = String.Empty
    If Not Session("F_FinYear") Is Nothing Then
      If Session("F_FinYear") <> String.Empty Then
        F_FinYear.Text = Session("F_FinYear")
      End If
    End If
    Dim strScriptFinYear As String = "<script type=""text/javascript""> " & _
      "function ACEFinYear_Selected(sender, e) {" & _
      "  var F_FinYear = $get('" & F_FinYear.ClientID & "');" & _
      "  var F_FinYear_Display = $get('" & F_FinYear_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_FinYear.value = p[0];" & _
      "  F_FinYear_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_FinYear") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_FinYear", strScriptFinYear)
      End If
    Dim strScriptPopulatingFinYear As String = "<script type=""text/javascript""> " & _
      "function ACEFinYear_Populating(o,e) {" & _
      "  var p = $get('" & F_FinYear.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEFinYear_Populated(o,e) {" & _
      "  var p = $get('" & F_FinYear.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_FinYearPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_FinYearPopulating", strScriptPopulatingFinYear)
      End If
    F_Quarter_Display.Text = String.Empty
    If Not Session("F_Quarter_Display") Is Nothing Then
      If Session("F_Quarter_Display") <> String.Empty Then
        F_Quarter_Display.Text = Session("F_Quarter_Display")
      End If
    End If
    F_Quarter.Text = String.Empty
    If Not Session("F_Quarter") Is Nothing Then
      If Session("F_Quarter") <> String.Empty Then
        F_Quarter.Text = Session("F_Quarter")
      End If
    End If
    Dim strScriptQuarter As String = "<script type=""text/javascript""> " & _
      "function ACEQuarter_Selected(sender, e) {" & _
      "  var F_Quarter = $get('" & F_Quarter.ClientID & "');" & _
      "  var F_Quarter_Display = $get('" & F_Quarter_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_Quarter.value = p[0];" & _
      "  F_Quarter_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_Quarter") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_Quarter", strScriptQuarter)
      End If
    Dim strScriptPopulatingQuarter As String = "<script type=""text/javascript""> " & _
      "function ACEQuarter_Populating(o,e) {" & _
      "  var p = $get('" & F_Quarter.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEQuarter_Populated(o,e) {" & _
      "  var p = $get('" & F_Quarter.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_QuarterPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_QuarterPopulating", strScriptPopulatingQuarter)
      End If
    F_StatusID.SelectedValue = String.Empty
    If Not Session("F_StatusID") Is Nothing Then
      If Session("F_StatusID") <> String.Empty Then
        F_StatusID.SelectedValue = Session("F_StatusID")
      End If
    End If
    Dim validateScriptFinYear As String = "<script type=""text/javascript"">" & _
      "  function validate_FinYear(o) {" & _
      "    validated_FK_PRK_SiteAllowanceAdvice_FinYear_main = true;" & _
      "    validate_FK_PRK_SiteAllowanceAdvice_FinYear(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFinYear") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFinYear", validateScriptFinYear)
    End If
    Dim validateScriptQuarter As String = "<script type=""text/javascript"">" & _
      "  function validate_Quarter(o) {" & _
      "    validated_FK_PRK_SiteAllowanceAdvice_Quarter_main = true;" & _
      "    validate_FK_PRK_SiteAllowanceAdvice_Quarter(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateQuarter") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateQuarter", validateScriptQuarter)
    End If
    Dim validateScriptFK_PRK_SiteAllowanceAdvice_FinYear As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PRK_SiteAllowanceAdvice_FinYear(o) {" & _
      "    var value = o.id;" & _
      "    var FinYear = $get('" & F_FinYear.ClientID & "');" & _
      "    try{" & _
      "    if(FinYear.value==''){" & _
      "      if(validated_FK_PRK_SiteAllowanceAdvice_FinYear.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + FinYear.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PRK_SiteAllowanceAdvice_FinYear(value, validated_FK_PRK_SiteAllowanceAdvice_FinYear);" & _
      "  }" & _
      "  validated_FK_PRK_SiteAllowanceAdvice_FinYear_main = false;" & _
      "  function validated_FK_PRK_SiteAllowanceAdvice_FinYear(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PRK_SiteAllowanceAdvice_FinYear") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PRK_SiteAllowanceAdvice_FinYear", validateScriptFK_PRK_SiteAllowanceAdvice_FinYear)
    End If
    Dim validateScriptFK_PRK_SiteAllowanceAdvice_Quarter As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PRK_SiteAllowanceAdvice_Quarter(o) {" & _
      "    var value = o.id;" & _
      "    var Quarter = $get('" & F_Quarter.ClientID & "');" & _
      "    try{" & _
      "    if(Quarter.value==''){" & _
      "      if(validated_FK_PRK_SiteAllowanceAdvice_Quarter.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + Quarter.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PRK_SiteAllowanceAdvice_Quarter(value, validated_FK_PRK_SiteAllowanceAdvice_Quarter);" & _
      "  }" & _
      "  validated_FK_PRK_SiteAllowanceAdvice_Quarter_main = false;" & _
      "  function validated_FK_PRK_SiteAllowanceAdvice_Quarter(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PRK_SiteAllowanceAdvice_Quarter") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PRK_SiteAllowanceAdvice_Quarter", validateScriptFK_PRK_SiteAllowanceAdvice_Quarter)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PRK_SiteAllowanceAdvice_FinYear(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim FinYear As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.COST.costFinYear = SIS.COST.costFinYear.costFinYearGetByID(FinYear)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PRK_SiteAllowanceAdvice_Quarter(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim Quarter As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.COST.costQuarters = SIS.COST.costQuarters.costQuartersGetByID(Quarter)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
