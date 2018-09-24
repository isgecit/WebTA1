Partial Class GF_lgEPAttachment
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/LG_Main/App_Display/DF_lgEPAttachment.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?DocPK=" & aVal(0) & "&FilePK=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVlgEPAttachment_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVlgEPAttachment.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim DocPK As Int64 = GVlgEPAttachment.DataKeys(e.CommandArgument).Values("DocPK")  
				Dim FilePK As Int64 = GVlgEPAttachment.DataKeys(e.CommandArgument).Values("FilePK")  
				Dim RedirectUrl As String = TBLlgEPAttachment.EditUrl & "?DocPK=" & DocPK & "&FilePK=" & FilePK
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVlgEPAttachment_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVlgEPAttachment.Init
    DataClassName = "GlgEPAttachment"
    SetGridView = GVlgEPAttachment
  End Sub
  Protected Sub TBLlgEPAttachment_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLlgEPAttachment.Init
    SetToolBar = TBLlgEPAttachment
  End Sub
  Protected Sub F_DocPK_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_DocPK.TextChanged
    Session("F_DocPK") = F_DocPK.Text
    Session("F_DocPK_Display") = F_DocPK_Display.Text
    InitGridPage()
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function DocPKCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.LG.lgEPDocument.SelectlgEPDocumentAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_DocPK_Display.Text = String.Empty
    If Not Session("F_DocPK_Display") Is Nothing Then
      If Session("F_DocPK_Display") <> String.Empty Then
        F_DocPK_Display.Text = Session("F_DocPK_Display")
      End If
    End If
    F_DocPK.Text = String.Empty
    If Not Session("F_DocPK") Is Nothing Then
      If Session("F_DocPK") <> String.Empty Then
        F_DocPK.Text = Session("F_DocPK")
      End If
    End If
		Dim strScriptDocPK As String = "<script type=""text/javascript""> " & _
			"function ACEDocPK_Selected(sender, e) {" & _
			"  var F_DocPK = $get('" & F_DocPK.ClientID & "');" & _
			"  var F_DocPK_Display = $get('" & F_DocPK_Display.ClientID & "');" & _
			"  var retval = e.get_value();" & _
			"  var p = retval.split('|');" & _
			"  F_DocPK.value = p[0];" & _
			"  F_DocPK_Display.innerHTML = e.get_text();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_DocPK") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_DocPK", strScriptDocPK)
			End If
		Dim strScriptPopulatingDocPK As String = "<script type=""text/javascript""> " & _
			"function ACEDocPK_Populating(o,e) {" & _
			"  var p = $get('" & F_DocPK.ClientID & "');" & _
			"  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat= 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACEDocPK_Populated(o,e) {" & _
			"  var p = $get('" & F_DocPK.ClientID & "');" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_DocPKPopulating") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_DocPKPopulating", strScriptPopulatingDocPK)
			End If
		Dim validateScriptDocPK As String = "<script type=""text/javascript"">" & _
			"  function validate_DocPK(o) {" & _
			"    validated_FK_LG_EPAttachment_DocPK_main = true;" & _
			"    validate_FK_LG_EPAttachment_DocPK(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateDocPK") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateDocPK", validateScriptDocPK)
		End If
		Dim validateScriptFK_LG_EPAttachment_DocPK As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_LG_EPAttachment_DocPK(o) {" & _
			"    var value = o.id;" & _
			"    var DocPK = $get('" & F_DocPK.ClientID & "');" & _
			"    try{" & _
			"    if(DocPK.value==''){" & _
			"      if(validated_FK_LG_EPAttachment_DocPK.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + DocPK.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_LG_EPAttachment_DocPK(value, validated_FK_LG_EPAttachment_DocPK);" & _
			"  }" & _
			"  validated_FK_LG_EPAttachment_DocPK_main = false;" & _
			"  function validated_FK_LG_EPAttachment_DocPK(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_LG_EPAttachment_DocPK") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_LG_EPAttachment_DocPK", validateScriptFK_LG_EPAttachment_DocPK)
		End If
  End Sub
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_LG_EPAttachment_DocPK(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim DocPK As Int64 = CType(aVal(1),Int64)
		Dim oVar As SIS.LG.lgEPDocument = SIS.LG.lgEPDocument.lgEPDocumentGetByID(DocPK)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
