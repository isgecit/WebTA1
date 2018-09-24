Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Partial Class GF_costCostSheet
  Inherits SIS.SYS.GridBase
  Protected Sub GVcostCostSheet_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVcostCostSheet.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ProjectGroupID As Int32 = GVcostCostSheet.DataKeys(e.CommandArgument).Values("ProjectGroupID")
        Dim FinYear As Int32 = GVcostCostSheet.DataKeys(e.CommandArgument).Values("FinYear")
        Dim Quarter As Int32 = GVcostCostSheet.DataKeys(e.CommandArgument).Values("Quarter")
        Dim Revision As Int32 = GVcostCostSheet.DataKeys(e.CommandArgument).Values("Revision")
        Dim RedirectUrl As String = TBLcostCostSheet.EditUrl & "?ProjectGroupID=" & ProjectGroupID & "&FinYear=" & FinYear & "&Quarter=" & Quarter & "&Revision=" & Revision
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "Downloadwf".ToLower Then
      Try
        Dim ProjectGroupID As Int32 = GVcostCostSheet.DataKeys(e.CommandArgument).Values("ProjectGroupID")
        Dim FinYear As Int32 = GVcostCostSheet.DataKeys(e.CommandArgument).Values("FinYear")
        Dim Quarter As Int32 = GVcostCostSheet.DataKeys(e.CommandArgument).Values("Quarter")
        Dim Revision As Int32 = GVcostCostSheet.DataKeys(e.CommandArgument).Values("Revision")
        SIS.COST.costCostSheet.DownloadWF(ProjectGroupID, FinYear, Quarter, Revision)
        GVcostCostSheet.DataBind()
      Catch ex As Exception
        Dim aa As String = ex.Message
      End Try
    End If
    If e.CommandName.ToLower = "Updatewf".ToLower Then
      Try
        Dim ProjectGroupID As Int32 = GVcostCostSheet.DataKeys(e.CommandArgument).Values("ProjectGroupID")
        Dim FinYear As Int32 = GVcostCostSheet.DataKeys(e.CommandArgument).Values("FinYear")
        Dim Quarter As Int32 = GVcostCostSheet.DataKeys(e.CommandArgument).Values("Quarter")
        Dim Revision As Int32 = GVcostCostSheet.DataKeys(e.CommandArgument).Values("Revision")
        SIS.COST.costCostSheet.UpdateWF(ProjectGroupID, FinYear, Quarter, Revision)
        GVcostCostSheet.DataBind()
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim ProjectGroupID As Int32 = GVcostCostSheet.DataKeys(e.CommandArgument).Values("ProjectGroupID")
        Dim FinYear As Int32 = GVcostCostSheet.DataKeys(e.CommandArgument).Values("FinYear")
        Dim Quarter As Int32 = GVcostCostSheet.DataKeys(e.CommandArgument).Values("Quarter")
        Dim Revision As Int32 = GVcostCostSheet.DataKeys(e.CommandArgument).Values("Revision")
        SIS.COST.costCostSheet.InitiateWF(ProjectGroupID, FinYear, Quarter, Revision)
        GVcostCostSheet.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVcostCostSheet_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVcostCostSheet.Init
    DataClassName = "GcostCostSheet"
    SetGridView = GVcostCostSheet
  End Sub
  Protected Sub TBLcostCostSheet_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostCostSheet.Init
    SetToolBar = TBLcostCostSheet
  End Sub
  Protected Sub F_ProjectGroupID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ProjectGroupID.TextChanged
    Session("F_ProjectGroupID") = F_ProjectGroupID.Text
    Session("F_ProjectGroupID_Display") = F_ProjectGroupID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ProjectGroupIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.COST.costProjectGroups.SelectcostProjectGroupsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_FinYear_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_FinYear.TextChanged
    Session("F_FinYear") = F_FinYear.Text
    Session("F_FinYear_Display") = F_FinYear_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function FinYearCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.COST.costFinYear.SelectcostFinYearAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_Quarter_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_Quarter.TextChanged
    Session("F_Quarter") = F_Quarter.Text
    Session("F_Quarter_Display") = F_Quarter_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function QuarterCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.COST.costQuarters.SelectcostQuartersAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_CreatedBy_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CreatedBy.TextChanged
    Session("F_CreatedBy") = F_CreatedBy.Text
    Session("F_CreatedBy_Display") = F_CreatedBy_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function CreatedByCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taWebUsers.SelecttaWebUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_StatusID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_StatusID.TextChanged
    Session("F_StatusID") = F_StatusID.Text
    Session("F_StatusID_Display") = F_StatusID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function StatusIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.COST.costCostSheetStates.SelectcostCostSheetStatesAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_ProjectGroupID_Display.Text = String.Empty
    If Not Session("F_ProjectGroupID_Display") Is Nothing Then
      If Session("F_ProjectGroupID_Display") <> String.Empty Then
        F_ProjectGroupID_Display.Text = Session("F_ProjectGroupID_Display")
      End If
    End If
    F_ProjectGroupID.Text = String.Empty
    If Not Session("F_ProjectGroupID") Is Nothing Then
      If Session("F_ProjectGroupID") <> String.Empty Then
        F_ProjectGroupID.Text = Session("F_ProjectGroupID")
      End If
    End If
    Dim strScriptProjectGroupID As String = "<script type=""text/javascript""> " &
      "function ACEProjectGroupID_Selected(sender, e) {" &
      "  var F_ProjectGroupID = $get('" & F_ProjectGroupID.ClientID & "');" &
      "  var F_ProjectGroupID_Display = $get('" & F_ProjectGroupID_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_ProjectGroupID.value = p[0];" &
      "  F_ProjectGroupID_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ProjectGroupID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ProjectGroupID", strScriptProjectGroupID)
    End If
    Dim strScriptPopulatingProjectGroupID As String = "<script type=""text/javascript""> " &
      "function ACEProjectGroupID_Populating(o,e) {" &
      "  var p = $get('" & F_ProjectGroupID.ClientID & "');" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACEProjectGroupID_Populated(o,e) {" &
      "  var p = $get('" & F_ProjectGroupID.ClientID & "');" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ProjectGroupIDPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ProjectGroupIDPopulating", strScriptPopulatingProjectGroupID)
    End If
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
    Dim strScriptFinYear As String = "<script type=""text/javascript""> " &
      "function ACEFinYear_Selected(sender, e) {" &
      "  var F_FinYear = $get('" & F_FinYear.ClientID & "');" &
      "  var F_FinYear_Display = $get('" & F_FinYear_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_FinYear.value = p[0];" &
      "  F_FinYear_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_FinYear") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_FinYear", strScriptFinYear)
    End If
    Dim strScriptPopulatingFinYear As String = "<script type=""text/javascript""> " &
      "function ACEFinYear_Populating(o,e) {" &
      "  var p = $get('" & F_FinYear.ClientID & "');" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACEFinYear_Populated(o,e) {" &
      "  var p = $get('" & F_FinYear.ClientID & "');" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
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
    Dim strScriptQuarter As String = "<script type=""text/javascript""> " &
      "function ACEQuarter_Selected(sender, e) {" &
      "  var F_Quarter = $get('" & F_Quarter.ClientID & "');" &
      "  var F_Quarter_Display = $get('" & F_Quarter_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_Quarter.value = p[0];" &
      "  F_Quarter_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_Quarter") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_Quarter", strScriptQuarter)
    End If
    Dim strScriptPopulatingQuarter As String = "<script type=""text/javascript""> " &
      "function ACEQuarter_Populating(o,e) {" &
      "  var p = $get('" & F_Quarter.ClientID & "');" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACEQuarter_Populated(o,e) {" &
      "  var p = $get('" & F_Quarter.ClientID & "');" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_QuarterPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_QuarterPopulating", strScriptPopulatingQuarter)
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
      "  F_CreatedBy.value = p[0];" &
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
    Dim validateScriptProjectGroupID As String = "<script type=""text/javascript"">" &
      "  function validate_ProjectGroupID(o) {" &
      "    validated_FK_COST_CostSheet_ProjectGroupID_main = true;" &
      "    validate_FK_COST_CostSheet_ProjectGroupID(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateProjectGroupID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateProjectGroupID", validateScriptProjectGroupID)
    End If
    Dim validateScriptFinYear As String = "<script type=""text/javascript"">" &
      "  function validate_FinYear(o) {" &
      "    validated_FK_COST_CostSheet_FinYear_main = true;" &
      "    validate_FK_COST_CostSheet_FinYear(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFinYear") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFinYear", validateScriptFinYear)
    End If
    Dim validateScriptQuarter As String = "<script type=""text/javascript"">" &
      "  function validate_Quarter(o) {" &
      "    validated_FK_COST_CostSheet_Quarter_main = true;" &
      "    validate_FK_COST_CostSheet_Quarter(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateQuarter") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateQuarter", validateScriptQuarter)
    End If
    Dim validateScriptCreatedBy As String = "<script type=""text/javascript"">" &
      "  function validate_CreatedBy(o) {" &
      "    validated_FK_COST_CostSheet_CreatedBy_main = true;" &
      "    validate_FK_COST_CostSheet_CreatedBy(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateCreatedBy") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateCreatedBy", validateScriptCreatedBy)
    End If
    Dim validateScriptStatusID As String = "<script type=""text/javascript"">" &
      "  function validate_StatusID(o) {" &
      "    validated_FK_COST_CostSheet_StatusID_main = true;" &
      "    validate_FK_COST_CostSheet_StatusID(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateStatusID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateStatusID", validateScriptStatusID)
    End If
    Dim validateScriptFK_COST_CostSheet_CreatedBy As String = "<script type=""text/javascript"">" &
      "  function validate_FK_COST_CostSheet_CreatedBy(o) {" &
      "    var value = o.id;" &
      "    var CreatedBy = $get('" & F_CreatedBy.ClientID & "');" &
      "    try{" &
      "    if(CreatedBy.value==''){" &
      "      if(validated_FK_COST_CostSheet_CreatedBy.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + CreatedBy.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_COST_CostSheet_CreatedBy(value, validated_FK_COST_CostSheet_CreatedBy);" &
      "  }" &
      "  validated_FK_COST_CostSheet_CreatedBy_main = false;" &
      "  function validated_FK_COST_CostSheet_CreatedBy(result) {" &
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_COST_CostSheet_CreatedBy") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_COST_CostSheet_CreatedBy", validateScriptFK_COST_CostSheet_CreatedBy)
    End If
    Dim validateScriptFK_COST_CostSheet_StatusID As String = "<script type=""text/javascript"">" &
      "  function validate_FK_COST_CostSheet_StatusID(o) {" &
      "    var value = o.id;" &
      "    var StatusID = $get('" & F_StatusID.ClientID & "');" &
      "    try{" &
      "    if(StatusID.value==''){" &
      "      if(validated_FK_COST_CostSheet_StatusID.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + StatusID.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_COST_CostSheet_StatusID(value, validated_FK_COST_CostSheet_StatusID);" &
      "  }" &
      "  validated_FK_COST_CostSheet_StatusID_main = false;" &
      "  function validated_FK_COST_CostSheet_StatusID(result) {" &
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_COST_CostSheet_StatusID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_COST_CostSheet_StatusID", validateScriptFK_COST_CostSheet_StatusID)
    End If
    Dim validateScriptFK_COST_CostSheet_FinYear As String = "<script type=""text/javascript"">" &
      "  function validate_FK_COST_CostSheet_FinYear(o) {" &
      "    var value = o.id;" &
      "    var FinYear = $get('" & F_FinYear.ClientID & "');" &
      "    try{" &
      "    if(FinYear.value==''){" &
      "      if(validated_FK_COST_CostSheet_FinYear.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + FinYear.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_COST_CostSheet_FinYear(value, validated_FK_COST_CostSheet_FinYear);" &
      "  }" &
      "  validated_FK_COST_CostSheet_FinYear_main = false;" &
      "  function validated_FK_COST_CostSheet_FinYear(result) {" &
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_COST_CostSheet_FinYear") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_COST_CostSheet_FinYear", validateScriptFK_COST_CostSheet_FinYear)
    End If
    Dim validateScriptFK_COST_CostSheet_ProjectGroupID As String = "<script type=""text/javascript"">" &
      "  function validate_FK_COST_CostSheet_ProjectGroupID(o) {" &
      "    var value = o.id;" &
      "    var ProjectGroupID = $get('" & F_ProjectGroupID.ClientID & "');" &
      "    try{" &
      "    if(ProjectGroupID.value==''){" &
      "      if(validated_FK_COST_CostSheet_ProjectGroupID.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + ProjectGroupID.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_COST_CostSheet_ProjectGroupID(value, validated_FK_COST_CostSheet_ProjectGroupID);" &
      "  }" &
      "  validated_FK_COST_CostSheet_ProjectGroupID_main = false;" &
      "  function validated_FK_COST_CostSheet_ProjectGroupID(result) {" &
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_COST_CostSheet_ProjectGroupID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_COST_CostSheet_ProjectGroupID", validateScriptFK_COST_CostSheet_ProjectGroupID)
    End If
    Dim validateScriptFK_COST_CostSheet_Quarter As String = "<script type=""text/javascript"">" &
      "  function validate_FK_COST_CostSheet_Quarter(o) {" &
      "    var value = o.id;" &
      "    var Quarter = $get('" & F_Quarter.ClientID & "');" &
      "    try{" &
      "    if(Quarter.value==''){" &
      "      if(validated_FK_COST_CostSheet_Quarter.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + Quarter.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_COST_CostSheet_Quarter(value, validated_FK_COST_CostSheet_Quarter);" &
      "  }" &
      "  validated_FK_COST_CostSheet_Quarter_main = false;" &
      "  function validated_FK_COST_CostSheet_Quarter(result) {" &
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_COST_CostSheet_Quarter") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_COST_CostSheet_Quarter", validateScriptFK_COST_CostSheet_Quarter)
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_COST_CostSheet_CreatedBy(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim CreatedBy As String = CType(aVal(1), String)
    Dim oVar As SIS.TA.taWebUsers = SIS.TA.taWebUsers.taWebUsersGetByID(CreatedBy)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_COST_CostSheet_StatusID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim StatusID As Int32 = 0
    Try
      StatusID = CType(aVal(1), Int32)
    Catch ex As Exception
    End Try
    Dim oVar As SIS.COST.costCostSheetStates = SIS.COST.costCostSheetStates.costCostSheetStatesGetByID(StatusID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_COST_CostSheet_FinYear(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim FinYear As Int32 = 0
    Try
      FinYear = CType(aVal(1), Int32)
    Catch ex As Exception
    End Try
    Dim oVar As SIS.COST.costFinYear = SIS.COST.costFinYear.costFinYearGetByID(FinYear)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_COST_CostSheet_ProjectGroupID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim ProjectGroupID As Int32 = 0
    Try
      ProjectGroupID = CType(aVal(1), Int32)
    Catch ex As Exception
    End Try
    Dim oVar As SIS.COST.costProjectGroups = SIS.COST.costProjectGroups.costProjectGroupsGetByID(ProjectGroupID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_COST_CostSheet_Quarter(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim Quarter As Int32 = 0
    Try
      Quarter = CType(aVal(1), Int32)
    Catch ex As Exception
    End Try
    Dim oVar As SIS.COST.costQuarters = SIS.COST.costQuarters.costQuartersGetByID(Quarter)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  Private Sub cmdFileUpdate_Click(sender As Object, e As EventArgs) Handles cmdFileUpload.Click
    Dim st As Long = HttpContext.Current.Server.ScriptTimeout
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
    Try
      With F_FileUpload
        If .HasFile Then
          Dim tmpPath As String = Server.MapPath("~/../App_Temp")
          Dim tmpName As String = IO.Path.GetRandomFileName()
          Dim tmpFile As String = tmpPath & "\\" & tmpName
          .SaveAs(tmpFile)
          Dim fi As FileInfo = New FileInfo(tmpFile)
          Using xlP As ExcelPackage = New ExcelPackage(fi)
            Dim wsD As ExcelWorksheet = Nothing
            Dim r As Integer = 2
            Try
              wsD = xlP.Workbook.Worksheets("CS_Data")
              Dim Last_GroupID As String = ""
              Dim Last_ProjectGroupName As String = ""
              Dim ProjectID As String = ""
              ProjectID = wsD.Cells(r, 1).Text
              Dim Finyear As String = wsD.Cells(r, 20).Text
              Dim Quarter As Integer = wsD.Cells(r, 21).Text
              Do While ProjectID <> String.Empty
                '1. Check and Create Project
                Dim tmp As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(ProjectID)
                If tmp Is Nothing Then
                  tmp = New SIS.QCM.qcmProjects
                  With tmp
                    .ProjectID = ProjectID
                    .Description = wsD.Cells(r, 5).Text
                  End With
                  Try
                    SIS.QCM.qcmProjects.InsertData(tmp)
                  Catch ex As Exception
                    wsD.Cells(r, 3).Value = "Err: Create Prj."
                  End Try
                End If
                '2. Update COST Data for Project In New Quarter Project [Also Create Quarter Project Record]
                Dim oP As SIS.COST.costQProjects = SIS.COST.costQProjects.costQProjectsGetByID(ProjectID, Finyear, Quarter)
                Dim Found As Boolean = False
                If oP Is Nothing Then
                  oP = New SIS.COST.costQProjects
                  Found = False
                Else
                  Found = True
                End If
                If oP IsNot Nothing Then
                  With oP
                    .ProjectID = ProjectID
                    .FinYear = Finyear
                    .Quarter = Quarter
                    .Description = wsD.Cells(r, 5).Text
                    .DivisionID = wsD.Cells(r, 7).Text
                    .ProjectOrderValue = wsD.Cells(r, 8).Text
                    .ProjectCost = wsD.Cells(r, 9).Text
                    .ProjectTypeID = wsD.Cells(r, 6).Text
                    .WarrantyPercentage = wsD.Cells(r, 13).Text
                    .CurrencyID = wsD.Cells(r, 10).Text
                    .WorkOrderTypeID = wsD.Cells(r, 11).Text
                    .CFforPOV = wsD.Cells(r, 12).Text
                    .MarginCurrentYear = wsD.Cells(r, 14).Text
                  End With
                  Try
                    If Found Then
                      SIS.COST.costQProjects.UZ_costQProjectsUpdate(oP)
                    Else
                      SIS.COST.costQProjects.UZ_costQProjectsInsert(oP)
                    End If
                  Catch ex As Exception
                    If Found Then
                      wsD.Cells(r, 3).Value = "Err: Update Quarterly COST Data for Prj."
                    Else
                      wsD.Cells(r, 3).Value = "Err: Insert Quarterly COST Data for Prj."
                    End If
                  End Try
                End If
                '3. Create/Update Project Group From First Line ONLY 
                Dim oPG As SIS.COST.costProjectGroups = Nothing
                Dim GroupID As String = wsD.Cells(r, 2).Text
                Dim GroupName As String = wsD.Cells(r, 4).Text
                Dim pgFound As Boolean = True
                If GroupID <> String.Empty Then
                  oPG = SIS.COST.costProjectGroups.costProjectGroupsGetByID(GroupID)
                  If oPG Is Nothing Then
                    oPG = SIS.COST.costProjectGroups.costProjectGroupsGetByName(GroupName)
                  End If
                Else
                  oPG = SIS.COST.costProjectGroups.costProjectGroupsGetByName(GroupName)
                End If
                If oPG Is Nothing Then
                  pgFound = False
                  oPG = New SIS.COST.costProjectGroups
                End If
                With oPG
                  .ProjectGroupDescription = GroupName
                  .ProjectTypeID = wsD.Cells(r, 6).Text
                  Try
                    If pgFound Then
                      Last_GroupID = oPG.ProjectGroupID
                      wsD.Cells(r, 2).Value = oPG.ProjectGroupID
                      oPG = SIS.COST.costProjectGroups.UpdateData(oPG)
                    Else
                      oPG = SIS.COST.costProjectGroups.InsertData(oPG)
                      wsD.Cells(r, 2).Value = oPG.ProjectGroupID
                      Last_GroupID = oPG.ProjectGroupID
                    End If
                    wsD.Cells(r, 2).Value = Last_GroupID
                  Catch ex As Exception
                    If pgFound Then
                      wsD.Cells(r, 3).Value = "Err: Update Prj.Gr"
                    Else
                      wsD.Cells(r, 3).Value = "Err: Create Prj.Gr"
                      oPG = Nothing
                    End If
                  End Try
                End With
                '4. Create Project Group Project if oPG is Not Nothing and Not Found
                If oPG IsNot Nothing Then
                  Dim oPGP As SIS.COST.costProjectGroupProjects = SIS.COST.costProjectGroupProjects.costProjectGroupProjectsGetByID(oPG.ProjectGroupID, ProjectID)
                  If oPGP Is Nothing Then
                    oPGP = New SIS.COST.costProjectGroupProjects
                    With oPGP
                      .ProjectGroupID = oPG.ProjectGroupID
                      .ProjectID = ProjectID
                    End With
                    Try
                      oPGP = SIS.COST.costProjectGroupProjects.InsertData(oPGP)
                    Catch ex As Exception
                      wsD.Cells(r, 3).Value = "Err: Create Prj.Gr.Prj."
                    End Try
                  End If
                End If
                '5. CostSheet(s) For FYr/Qtr, L_Yr if oPG is Not Nothing
                If oPG IsNot Nothing Then
                  Dim ProjectGroupID As Integer = oPG.ProjectGroupID
                  ''Dim Finyear As String = wsD.Cells(r, 20).Text
                  ''Dim Quarter As Integer = wsD.Cells(r, 21).Text
                  Dim LastYearCol As Integer = 21
                  'Check and create Cost Sheet For Current Yr/Qtr Only Not for Last Years
                  'Do While Finyear <> String.Empty
                  Found = True
                    Dim oCS As SIS.COST.costCostSheet = SIS.COST.costCostSheet.costCostSheetGetByID(ProjectGroupID, Finyear, Quarter, 1)
                    If oCS Is Nothing Then
                      Found = False
                      oCS = New SIS.COST.costCostSheet
                      oCS.Revision = 1
                      oCS.StatusID = 2
                    End If
                    With oCS
                      .ProjectGroupID = ProjectGroupID
                      .FinYear = Finyear
                      .Quarter = Quarter
                      .CreatedBy = HttpContext.Current.Session("LoginID")
                      .CreatedOn = Now
                      .Remarks = "By Excel Import"
                    End With
                    Try
                      If Found Then
                        SIS.COST.costCostSheet.UpdateData(oCS)
                      Else
                        SIS.COST.costCostSheet.InsertData(oCS)
                      End If
                    Catch ex As Exception
                      If Found Then
                        wsD.Cells(r, 3).Value = "Err: Update Costsheet"
                      Else
                        wsD.Cells(r, 3).Value = "Err: Create Costsheet"
                      End If
                    End Try
                  'LastYearCol += 1
                  'Finyear = wsD.Cells(r, LastYearCol).Text
                  'Quarter = 4
                  'Loop
                End If
                '6. Project Input(s) For FYr/Qtr, L_Yr if oPG is Not Nothing
                If oPG IsNot Nothing Then
                  Dim ProjectGroupID As Integer = oPG.ProjectGroupID
                  'Dim Finyear As String = wsD.Cells(r, 20).Text
                  'Dim Quarter As Integer = wsD.Cells(r, 21).Text
                  Dim LastYearCol As Integer = 21
                  'Do While Finyear <> String.Empty
                  Found = True
                    Dim oPI As SIS.COST.costProjectsInput = SIS.COST.costProjectsInput.costProjectsInputGetByID(ProjectGroupID, Finyear, Quarter)
                    If oPI Is Nothing Then
                      Found = False
                      oPI = New SIS.COST.costProjectsInput
                      oPI.StatusID = 2
                    End If
                    With oPI
                      .ProjectGroupID = ProjectGroupID
                      .FinYear = Finyear
                      .Quarter = Quarter
                      .ProjectRevenue = wsD.Cells(r, 15).Text
                      .ProjectMargin = wsD.Cells(r, 16).Text
                      .ExportIncentive = wsD.Cells(r, 17).Text
                      .CurrencyPR = wsD.Cells(r, 18).Text
                      .CFforPR = wsD.Cells(r, 19).Text
                      .CreatedBy = HttpContext.Current.Session("LoginID")
                      .CreatedOn = Now
                      .ApprovedBy = HttpContext.Current.Session("LoginID")
                      .ApprovedOn = Now
                      .Remarks = "By Excel Import"
                    End With
                    Try
                      If Found Then
                        SIS.COST.costProjectsInput.UZ_costProjectsInputUpdate(oPI)
                      Else
                        oPI = SIS.COST.costProjectsInput.UZ_costProjectsInputInsert(oPI)
                        SIS.COST.costProjectsIputApproval.ApproveWF(oPI.ProjectGroupID, oPI.FinYear, oPI.Quarter, "Auto approved by Excel Import")
                      End If
                    Catch ex As Exception
                      If Found Then
                        wsD.Cells(r, 3).Value = "Err: Update Project Input"
                      Else
                        wsD.Cells(r, 3).Value = "Err: Create Project Input"
                      End If
                    End Try
                  'LastYearCol += 1
                  'Finyear = wsD.Cells(r, LastYearCol).Text
                  'Quarter = 4
                  'Loop
                End If
                '7. Read NEXT EXCEL Line
                r += 1
                ProjectID = wsD.Cells(r, 1).Text
              Loop
            Catch ex As Exception
              wsD.Cells(r, 3).Value = ex.Message
            End Try
            xlP.Save()
            xlP.Dispose()
          End Using
          Dim FileNameForUser As String = F_FileUpload.FileName
          If IO.File.Exists(tmpFile) Then
            Response.Clear()
            Response.AppendHeader("content-disposition", "attachment; filename=" & FileNameForUser)
            Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(FileNameForUser)
            Response.WriteFile(tmpFile)
            HttpContext.Current.Server.ScriptTimeout = st
            Response.End()
          End If
        End If
      End With
    Catch ex As Exception
      HttpContext.Current.Server.ScriptTimeout = st
      Dim message As String = New JavaScriptSerializer().Serialize(ex.Message.ToString())
      Dim script As String = String.Format("alert({0});", message)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
    End Try
over:

  End Sub
  Protected Sub cmdDownload_Click(sender As Object, e As System.EventArgs) Handles cmdDownload.Click
    Dim st As Long = HttpContext.Current.Server.ScriptTimeout
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue

    Dim FinYear As String = F_FinYearD.Text
    Dim Quarter As String = F_QuarterD.Text
    If FinYear = String.Empty Or Quarter = String.Empty Then
      Dim message As String = New JavaScriptSerializer().Serialize("Fin.Year & Quarter is required for Template download.")
      Dim script As String = String.Format("alert({0});", message)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      Exit Sub
    End If
    Dim TemplateName As String = "CSData_Template.xlsx"
    Dim tmpFile As String = Server.MapPath("~/App_Templates/" & TemplateName)
    If IO.File.Exists(tmpFile) Then
      Dim FileName As String = Server.MapPath("~/..") & "App_Temp/" & Guid.NewGuid().ToString()
      IO.File.Copy(tmpFile, FileName)
      Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
      Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)

      '1.
      Dim r As Integer = 2
      Dim c As Integer = 1
      Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("CS_Data")

      Dim costSheetAll As List(Of SIS.COST.costCostSheet) = SIS.COST.costCostSheet.costCostSheetSelectList(0, 99999, "ProjectGroupID", False, "", 0, FinYear, Quarter, 0, "")

      With xlWS
        For Each cs As SIS.COST.costCostSheet In costSheetAll
          Dim csPrs As List(Of SIS.COST.costProjectGroupProjects) = SIS.COST.costProjectGroupProjects.GetByProjectGroupID(cs.ProjectGroupID, "ProjectID")
          For Each csPr As SIS.COST.costProjectGroupProjects In csPrs
            .Cells(r, 1).Value = csPr.ProjectID
            .Cells(r, 2).Value = cs.ProjectGroupID
            .Cells(r, 3).Value = cs.COST_CostSheetStates3_Description
            .Cells(r, 4).Value = csPr.COST_ProjectGroups1_ProjectGroupDescription
            .Cells(r, 5).Value = csPr.IDM_Projects2_Description
            .Cells(r, 6).Value = cs.FK_COST_CostSheet_ProjectGroupID.ProjectTypeID
            .Cells(r, 7).Value = csPr.FK_COST_ProjectGroupProjects_ProjectID.DivisionID
            .Cells(r, 8).Value = SIS.COST.costQProjects.costQProjectsGetByID(csPr.ProjectID, cs.FinYear, cs.Quarter).ProjectOrderValue
            .Cells(r, 9).Value = SIS.COST.costQProjects.costQProjectsGetByID(csPr.ProjectID, cs.FinYear, cs.Quarter).ProjectCost
            Dim PrIn As SIS.COST.costProjectsInput = SIS.COST.costProjectsInput.costProjectsInputGetByID(cs.ProjectGroupID, cs.FinYear, cs.Quarter)
            If PrIn Is Nothing Then
              PrIn = New SIS.COST.costProjectsInput
              With PrIn
                .ProjectMargin = 0
                .ProjectRevenue = 0
                .ExportIncentive = 0
                .CurrencyPR = "INR"
                .CFforPR = 1
              End With
            End If
            .Cells(r, 10).Value = SIS.COST.costQProjects.costQProjectsGetByID(csPr.ProjectID, cs.FinYear, cs.Quarter).CurrencyID
            .Cells(r, 11).Value = SIS.COST.costQProjects.costQProjectsGetByID(csPr.ProjectID, cs.FinYear, cs.Quarter).WorkOrderTypeID
            .Cells(r, 12).Value = SIS.COST.costQProjects.costQProjectsGetByID(csPr.ProjectID, cs.FinYear, cs.Quarter).CFforPOV
            .Cells(r, 13).Value = SIS.COST.costQProjects.costQProjectsGetByID(csPr.ProjectID, cs.FinYear, cs.Quarter).WarrantyPercentage
            .Cells(r, 14).Value = SIS.COST.costQProjects.costQProjectsGetByID(csPr.ProjectID, cs.FinYear, cs.Quarter).MarginCurrentYear
            .Cells(r, 15).Value = PrIn.ProjectRevenue
            .Cells(r, 16).Value = PrIn.ProjectMargin
            .Cells(r, 17).Value = PrIn.ExportIncentive
            .Cells(r, 18).Value = PrIn.CurrencyPR
            .Cells(r, 19).Value = PrIn.CFforPR
            .Cells(r, 20).Value = cs.FinYear
            .Cells(r, 21).Value = cs.Quarter
            'Dim csLast As List(Of SIS.COST.costCostSheet) = SIS.COST.costCostSheet.getcsLastYears(cs.ProjectGroupID, cs.FinYear, cs.Quarter, cs.Revision)
            'csLast.Sort(Function(x, y) x.FinYear.CompareTo(y.FinYear))
            'c = 22
            'For Each yr As SIS.COST.costCostSheet In csLast
            '  If yr.FinYear < cs.FinYear Then
            '    .Cells(r, c).Value = yr.FinYear
            '    c += 1
            '  End If
            'Next
            r += 1
          Next
        Next
      End With
      xlPk.Save()
      xlPk.Dispose()

      Response.Clear()
      Response.AppendHeader("content-disposition", "attachment; filename=CSList_" & FinYear & "_" & Quarter & "_Template.xlsx")
      Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(TemplateName)
      Response.WriteFile(FileName)
      HttpContext.Current.Server.ScriptTimeout = st
      Response.End()
    End If

  End Sub

  Protected Sub cmdERPLN_Click(sender As Object, e As System.EventArgs) Handles cmdERPLN.Click
    Dim st As Long = HttpContext.Current.Server.ScriptTimeout
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue

    Dim FinYear As String = F_FinYearE.Text
    Dim Quarter As String = F_QuarterE.Text
    If FinYear = String.Empty Or Quarter = String.Empty Or F_FGID.Text = String.Empty Or F_TGID.Text = String.Empty Then
      Dim message As String = New JavaScriptSerializer().Serialize("Fin.Year & Quarter is required for ERP-LN Update.")
      Dim script As String = String.Format("alert({0});", message)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      HttpContext.Current.Server.ScriptTimeout = st
      Exit Sub

    End If
    Dim fGid As Integer = 0
    Dim tGid As Integer = 0
    Try
      fGid = Convert.ToInt32(F_FGID.Text)
      tGid = Convert.ToInt32(F_TGID.Text)
    Catch ex As Exception
      Dim message As String = New JavaScriptSerializer().Serialize("Group ID Range is INVALID NUMBER.")
      Dim script As String = String.Format("alert({0});", message)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      HttpContext.Current.Server.ScriptTimeout = st
      Exit Sub
    End Try
    If tGid < fGid Then
      Dim message As String = New JavaScriptSerializer().Serialize("FROM Group ID is Greater than TO Group ID")
      Dim script As String = String.Format("alert({0});", message)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      HttpContext.Current.Server.ScriptTimeout = st
      Exit Sub
    End If
    Do While fGid <= tGid
      Dim costSheetAll As List(Of SIS.COST.costCostSheet) = SIS.COST.costCostSheet.costCostSheetSelectList(0, 1, "ProjectGroupID", False, "", fGid, FinYear, Quarter, 0, "")
      For Each cs As SIS.COST.costCostSheet In costSheetAll
        Select Case cs.StatusID
          Case CostSheetStates.Free, CostSheetStates.Returned
            Try
              SIS.COST.costCostSheetData.costCostSheetDataFromERPLN(cs.ProjectGroupID, cs.FinYear, cs.Quarter, cs.Revision)
              SIS.COST.costCostSheetLiability.costCostSheetLiabilityFromERPLN(cs.ProjectGroupID, cs.FinYear, cs.Quarter, cs.Revision)
            Catch ex As Exception
              Dim message As String = New JavaScriptSerializer().Serialize(ex.Message)
              Dim script As String = String.Format("alert({0});", message)
              ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
              HttpContext.Current.Server.ScriptTimeout = st
              Exit Sub
            End Try
        End Select
      Next
      fGid += 1
    Loop
    HttpContext.Current.Server.ScriptTimeout = st
  End Sub
End Class
