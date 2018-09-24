Partial Class GF_costFinYearProjects
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/COST_Main/App_Display/DF_costFinYearProjects.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?FinYear=" & aVal(0) & "&Quarter=" & aVal(1) & "&ProjectID=" & aVal(2)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVcostFinYearProjects_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVcostFinYearProjects.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim FinYear As Int32 = GVcostFinYearProjects.DataKeys(e.CommandArgument).Values("FinYear")  
        Dim Quarter As Int32 = GVcostFinYearProjects.DataKeys(e.CommandArgument).Values("Quarter")  
        Dim ProjectID As String = GVcostFinYearProjects.DataKeys(e.CommandArgument).Values("ProjectID")  
        Dim RedirectUrl As String = TBLcostFinYearProjects.EditUrl & "?FinYear=" & FinYear & "&Quarter=" & Quarter & "&ProjectID=" & ProjectID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim CombinedGroupID As String = CType(GVcostFinYearProjects.Rows(e.CommandArgument).FindControl("F_CombinedGroupID"), TextBox).Text
        Dim FinYear As Int32 = GVcostFinYearProjects.DataKeys(e.CommandArgument).Values("FinYear")
        Dim Quarter As Int32 = GVcostFinYearProjects.DataKeys(e.CommandArgument).Values("Quarter")
        Dim ProjectID As String = GVcostFinYearProjects.DataKeys(e.CommandArgument).Values("ProjectID")
        SIS.COST.costFinYearProjects.InitiateWF(FinYear, Quarter, ProjectID, CombinedGroupID)
        GVcostFinYearProjects.DataBind()
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "approvewf".ToLower Then
      Try
        Dim CombinedGroupID As String = CType(GVcostFinYearProjects.Rows(e.CommandArgument).FindControl("F_CombinedGroupID"), TextBox).Text
        Dim FinYear As Int32 = GVcostFinYearProjects.DataKeys(e.CommandArgument).Values("FinYear")
        Dim Quarter As Int32 = GVcostFinYearProjects.DataKeys(e.CommandArgument).Values("Quarter")
        Dim ProjectID As String = GVcostFinYearProjects.DataKeys(e.CommandArgument).Values("ProjectID")
        SIS.COST.costFinYearProjects.ApproveWF(FinYear, Quarter, ProjectID, CombinedGroupID)
        GVcostFinYearProjects.DataBind()
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "rejectwf".ToLower Then
      Try
        Dim CombinedGroupID As String = CType(GVcostFinYearProjects.Rows(e.CommandArgument).FindControl("F_CombinedGroupID"), TextBox).Text
        Dim FinYear As Int32 = GVcostFinYearProjects.DataKeys(e.CommandArgument).Values("FinYear")
        Dim Quarter As Int32 = GVcostFinYearProjects.DataKeys(e.CommandArgument).Values("Quarter")
        Dim ProjectID As String = GVcostFinYearProjects.DataKeys(e.CommandArgument).Values("ProjectID")
        SIS.COST.costFinYearProjects.RejectWF(FinYear, Quarter, ProjectID, CombinedGroupID)
        GVcostFinYearProjects.DataBind()
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "completewf".ToLower Then
      Try
        Dim CombinedGroupID As String = CType(GVcostFinYearProjects.Rows(e.CommandArgument).FindControl("F_CombinedGroupID"), TextBox).Text
        Dim FinYear As Int32 = GVcostFinYearProjects.DataKeys(e.CommandArgument).Values("FinYear")
        Dim Quarter As Int32 = GVcostFinYearProjects.DataKeys(e.CommandArgument).Values("Quarter")
        Dim ProjectID As String = GVcostFinYearProjects.DataKeys(e.CommandArgument).Values("ProjectID")
        SIS.COST.costFinYearProjects.CompleteWF(FinYear, Quarter, ProjectID, CombinedGroupID)
        GVcostFinYearProjects.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVcostFinYearProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVcostFinYearProjects.Init
    DataClassName = "GcostFinYearProjects"
    SetGridView = GVcostFinYearProjects
  End Sub
  Protected Sub TBLcostFinYearProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostFinYearProjects.Init
    SetToolBar = TBLcostFinYearProjects
  End Sub
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
  Protected Sub F_Quarter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_Quarter.SelectedIndexChanged
    Session("F_Quarter") = F_Quarter.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_ProjectID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ProjectID.TextChanged
    Session("F_ProjectID") = F_ProjectID.Text
    Session("F_ProjectID_Display") = F_ProjectID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.COST.costProjects.SelectcostProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
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
    F_Quarter.SelectedValue = String.Empty
    If Not Session("F_Quarter") Is Nothing Then
      If Session("F_Quarter") <> String.Empty Then
        F_Quarter.SelectedValue = Session("F_Quarter")
      End If
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
    Dim validateScriptProjectID As String = "<script type=""text/javascript"">" &
      "  function validate_ProjectID(o) {" &
      "    validated_FK_COST_FinYearProjects_ProjectID_main = true;" &
      "    validate_FK_COST_FinYearProjects_ProjectID(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateProjectID", validateScriptProjectID)
    End If
    Dim validateScriptFK_COST_FinYearProjects_ProjectID As String = "<script type=""text/javascript"">" &
      "  function validate_FK_COST_FinYearProjects_ProjectID(o) {" &
      "    var value = o.id;" &
      "    var ProjectID = $get('" & F_ProjectID.ClientID & "');" &
      "    try{" &
      "    if(ProjectID.value==''){" &
      "      if(validated_FK_COST_FinYearProjects_ProjectID.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + ProjectID.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_COST_FinYearProjects_ProjectID(value, validated_FK_COST_FinYearProjects_ProjectID);" &
      "  }" &
      "  validated_FK_COST_FinYearProjects_ProjectID_main = false;" &
      "  function validated_FK_COST_FinYearProjects_ProjectID(result) {" &
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_COST_FinYearProjects_ProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_COST_FinYearProjects_ProjectID", validateScriptFK_COST_FinYearProjects_ProjectID)
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_COST_FinYearProjects_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1), String)
    Dim oVar As SIS.COST.costProjects = SIS.COST.costProjects.costProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function CombinedGroupIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.COST.costProjectGroups.SelectcostProjectGroupsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_COST_FinYearProjects_IDCombinedGroup(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim CombinedGroupID As Int32 = 0
    Try
      CombinedGroupID = CType(aVal(1), Int32)
    Catch ex As Exception
    End Try
    Dim oVar As SIS.COST.costProjectGroups = SIS.COST.costProjectGroups.costProjectGroupsGetByID(CombinedGroupID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  Private Sub cmdSync_Click(sender As Object, e As EventArgs) Handles cmdSync.Click
    Dim st As Long = HttpContext.Current.Server.ScriptTimeout
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
    Dim FinYear As String = F_FinYear.Text
    Dim Quarter As String = F_Quarter.SelectedValue
    If FinYear <> String.Empty And Quarter <> String.Empty Then
      SIS.COST.costFinYearProjects.UpdateFromERP(FinYear, Quarter)
      GVcostFinYearProjects.DataBind()
    End If
    HttpContext.Current.Server.ScriptTimeout = st
  End Sub

End Class
