Partial Class GF_lgEPDocument
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/LG_Main/App_Display/DF_lgEPDocument.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?DocPK=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVlgEPDocument_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVlgEPDocument.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim DocPK As Int64 = GVlgEPDocument.DataKeys(e.CommandArgument).Values("DocPK")  
				Dim RedirectUrl As String = TBLlgEPDocument.EditUrl & "?DocPK=" & DocPK
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVlgEPDocument_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVlgEPDocument.Init
    DataClassName = "GlgEPDocument"
    SetGridView = GVlgEPDocument
  End Sub
  Protected Sub TBLlgEPDocument_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLlgEPDocument.Init
    SetToolBar = TBLlgEPDocument
  End Sub
  Protected Sub F_ProjectID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ProjectID.TextChanged
    Session("F_ProjectID") = F_ProjectID.Text
    Session("F_ProjectID_Display") = F_ProjectID_Display.Text
    InitGridPage()
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.LG.lgProjects.SelectlgProjectsAutoCompleteList(prefixText, count, contextKey)
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
		Dim validateScriptProjectID As String = "<script type=""text/javascript"">" & _
			"  function validate_ProjectID(o) {" & _
			"    validated_FK_LG_EPDocument_ProjectID_main = true;" & _
			"    validate_FK_LG_EPDocument_ProjectID(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateProjectID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateProjectID", validateScriptProjectID)
		End If
		Dim validateScriptFK_LG_EPDocument_ProjectID As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_LG_EPDocument_ProjectID(o) {" & _
			"    var value = o.id;" & _
			"    var ProjectID = $get('" & F_ProjectID.ClientID & "');" & _
			"    try{" & _
			"    if(ProjectID.value==''){" & _
			"      if(validated_FK_LG_EPDocument_ProjectID.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + ProjectID.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_LG_EPDocument_ProjectID(value, validated_FK_LG_EPDocument_ProjectID);" & _
			"  }" & _
			"  validated_FK_LG_EPDocument_ProjectID_main = false;" & _
			"  function validated_FK_LG_EPDocument_ProjectID(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_LG_EPDocument_ProjectID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_LG_EPDocument_ProjectID", validateScriptFK_LG_EPDocument_ProjectID)
		End If
  End Sub
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_LG_EPDocument_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim ProjectID As String = CType(aVal(1),String)
		Dim oVar As SIS.LG.lgProjects = SIS.LG.lgProjects.lgProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
	'Protected Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
	'	If HttpContext.Current.Session("LoginID") <> "0340" Then Exit Sub
	'	SIS.SYS.Utilities.ApplicationSpacific.UpdateDownloadedFileNameLocationFromWindChill()
	'End Sub
End Class
