Partial Class GF_costGLGroupGLs
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/COST_Main/App_Display/DF_costGLGroupGLs.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?GLGroupID=" & aVal(0) & "&GLCode=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVcostGLGroupGLs_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVcostGLGroupGLs.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim GLGroupID As Int32 = GVcostGLGroupGLs.DataKeys(e.CommandArgument).Values("GLGroupID")  
        Dim GLCode As String = GVcostGLGroupGLs.DataKeys(e.CommandArgument).Values("GLCode")  
        Dim RedirectUrl As String = TBLcostGLGroupGLs.EditUrl & "?GLGroupID=" & GLGroupID & "&GLCode=" & GLCode
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVcostGLGroupGLs_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVcostGLGroupGLs.Init
    DataClassName = "GcostGLGroupGLs"
    SetGridView = GVcostGLGroupGLs
  End Sub
  Protected Sub TBLcostGLGroupGLs_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostGLGroupGLs.Init
    SetToolBar = TBLcostGLGroupGLs
  End Sub
  Protected Sub F_GLGroupID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_GLGroupID.TextChanged
    Session("F_GLGroupID") = F_GLGroupID.Text
    Session("F_GLGroupID_Display") = F_GLGroupID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function GLGroupIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.COST.costGLGroups.SelectcostGLGroupsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_GLGroupID_Display.Text = String.Empty
    If Not Session("F_GLGroupID_Display") Is Nothing Then
      If Session("F_GLGroupID_Display") <> String.Empty Then
        F_GLGroupID_Display.Text = Session("F_GLGroupID_Display")
      End If
    End If
    F_GLGroupID.Text = String.Empty
    If Not Session("F_GLGroupID") Is Nothing Then
      If Session("F_GLGroupID") <> String.Empty Then
        F_GLGroupID.Text = Session("F_GLGroupID")
      End If
    End If
    Dim strScriptGLGroupID As String = "<script type=""text/javascript""> " & _
      "function ACEGLGroupID_Selected(sender, e) {" & _
      "  var F_GLGroupID = $get('" & F_GLGroupID.ClientID & "');" & _
      "  var F_GLGroupID_Display = $get('" & F_GLGroupID_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_GLGroupID.value = p[0];" & _
      "  F_GLGroupID_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_GLGroupID") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_GLGroupID", strScriptGLGroupID)
      End If
    Dim strScriptPopulatingGLGroupID As String = "<script type=""text/javascript""> " & _
      "function ACEGLGroupID_Populating(o,e) {" & _
      "  var p = $get('" & F_GLGroupID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEGLGroupID_Populated(o,e) {" & _
      "  var p = $get('" & F_GLGroupID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_GLGroupIDPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_GLGroupIDPopulating", strScriptPopulatingGLGroupID)
      End If
    Dim validateScriptGLGroupID As String = "<script type=""text/javascript"">" & _
      "  function validate_GLGroupID(o) {" & _
      "    validated_FK_COST_GLGroupGLs_GLGroupID_main = true;" & _
      "    validate_FK_COST_GLGroupGLs_GLGroupID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateGLGroupID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateGLGroupID", validateScriptGLGroupID)
    End If
    Dim validateScriptFK_COST_GLGroupGLs_GLGroupID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_COST_GLGroupGLs_GLGroupID(o) {" & _
      "    var value = o.id;" & _
      "    var GLGroupID = $get('" & F_GLGroupID.ClientID & "');" & _
      "    try{" & _
      "    if(GLGroupID.value==''){" & _
      "      if(validated_FK_COST_GLGroupGLs_GLGroupID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + GLGroupID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_COST_GLGroupGLs_GLGroupID(value, validated_FK_COST_GLGroupGLs_GLGroupID);" & _
      "  }" & _
      "  validated_FK_COST_GLGroupGLs_GLGroupID_main = false;" & _
      "  function validated_FK_COST_GLGroupGLs_GLGroupID(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_COST_GLGroupGLs_GLGroupID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_COST_GLGroupGLs_GLGroupID", validateScriptFK_COST_GLGroupGLs_GLGroupID)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_COST_GLGroupGLs_GLGroupID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim GLGroupID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.COST.costGLGroups = SIS.COST.costGLGroups.costGLGroupsGetByID(GLGroupID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
