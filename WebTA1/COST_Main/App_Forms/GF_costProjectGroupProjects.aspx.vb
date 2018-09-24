Partial Class GF_costProjectGroupProjects
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/COST_Main/App_Display/DF_costProjectGroupProjects.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ProjectGroupID=" & aVal(0) & "&ProjectID=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVcostProjectGroupProjects_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVcostProjectGroupProjects.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ProjectGroupID As Int32 = GVcostProjectGroupProjects.DataKeys(e.CommandArgument).Values("ProjectGroupID")  
        Dim ProjectID As String = GVcostProjectGroupProjects.DataKeys(e.CommandArgument).Values("ProjectID")  
        Dim RedirectUrl As String = TBLcostProjectGroupProjects.EditUrl & "?ProjectGroupID=" & ProjectGroupID & "&ProjectID=" & ProjectID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVcostProjectGroupProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVcostProjectGroupProjects.Init
    DataClassName = "GcostProjectGroupProjects"
    SetGridView = GVcostProjectGroupProjects
  End Sub
  Protected Sub TBLcostProjectGroupProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostProjectGroupProjects.Init
    SetToolBar = TBLcostProjectGroupProjects
  End Sub
  Protected Sub F_ProjectGroupID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ProjectGroupID.TextChanged
    Session("F_ProjectGroupID") = F_ProjectGroupID.Text
    Session("F_ProjectGroupID_Display") = F_ProjectGroupID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectGroupIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.COST.costProjectGroups.SelectcostProjectGroupsAutoCompleteList(prefixText, count, contextKey)
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
    Dim strScriptProjectGroupID As String = "<script type=""text/javascript""> " & _
      "function ACEProjectGroupID_Selected(sender, e) {" & _
      "  var F_ProjectGroupID = $get('" & F_ProjectGroupID.ClientID & "');" & _
      "  var F_ProjectGroupID_Display = $get('" & F_ProjectGroupID_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_ProjectGroupID.value = p[0];" & _
      "  F_ProjectGroupID_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ProjectGroupID") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ProjectGroupID", strScriptProjectGroupID)
      End If
    Dim strScriptPopulatingProjectGroupID As String = "<script type=""text/javascript""> " & _
      "function ACEProjectGroupID_Populating(o,e) {" & _
      "  var p = $get('" & F_ProjectGroupID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEProjectGroupID_Populated(o,e) {" & _
      "  var p = $get('" & F_ProjectGroupID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ProjectGroupIDPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ProjectGroupIDPopulating", strScriptPopulatingProjectGroupID)
      End If
    Dim validateScriptProjectGroupID As String = "<script type=""text/javascript"">" & _
      "  function validate_ProjectGroupID(o) {" & _
      "    validated_FK_COST_ProjectGroupProjects_ProjectGroupID_main = true;" & _
      "    validate_FK_COST_ProjectGroupProjects_ProjectGroupID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateProjectGroupID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateProjectGroupID", validateScriptProjectGroupID)
    End If
    Dim validateScriptFK_COST_ProjectGroupProjects_ProjectGroupID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_COST_ProjectGroupProjects_ProjectGroupID(o) {" & _
      "    var value = o.id;" & _
      "    var ProjectGroupID = $get('" & F_ProjectGroupID.ClientID & "');" & _
      "    try{" & _
      "    if(ProjectGroupID.value==''){" & _
      "      if(validated_FK_COST_ProjectGroupProjects_ProjectGroupID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + ProjectGroupID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_COST_ProjectGroupProjects_ProjectGroupID(value, validated_FK_COST_ProjectGroupProjects_ProjectGroupID);" & _
      "  }" & _
      "  validated_FK_COST_ProjectGroupProjects_ProjectGroupID_main = false;" & _
      "  function validated_FK_COST_ProjectGroupProjects_ProjectGroupID(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_COST_ProjectGroupProjects_ProjectGroupID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_COST_ProjectGroupProjects_ProjectGroupID", validateScriptFK_COST_ProjectGroupProjects_ProjectGroupID)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_COST_ProjectGroupProjects_ProjectGroupID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ProjectGroupID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.COST.costProjectGroups = SIS.COST.costProjectGroups.costProjectGroupsGetByID(ProjectGroupID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
