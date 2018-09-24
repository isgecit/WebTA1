Partial Class GF_erpDCRDetail
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ERP_Main/App_Display/DF_erpDCRDetail.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?DCRNo=" & aVal(0) & "&DocumentID=" & aVal(1) & "&RevisionNo=" & aVal(2)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVerpDCRDetail_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVerpDCRDetail.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim DCRNo As String = GVerpDCRDetail.DataKeys(e.CommandArgument).Values("DCRNo")  
				Dim DocumentID As String = GVerpDCRDetail.DataKeys(e.CommandArgument).Values("DocumentID")  
				Dim RevisionNo As String = GVerpDCRDetail.DataKeys(e.CommandArgument).Values("RevisionNo")  
				Dim RedirectUrl As String = TBLerpDCRDetail.EditUrl & "?DCRNo=" & DCRNo & "&DocumentID=" & DocumentID & "&RevisionNo=" & RevisionNo
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
		If e.CommandName.ToLower = "initiatewf".ToLower Then
			Try
				Dim DCRNo As String = GVerpDCRDetail.DataKeys(e.CommandArgument).Values("DCRNo")  
				Dim DocumentID As String = GVerpDCRDetail.DataKeys(e.CommandArgument).Values("DocumentID")  
				Dim RevisionNo As String = GVerpDCRDetail.DataKeys(e.CommandArgument).Values("RevisionNo")  
				SIS.ERP.erpDCRDetail.InitiateWF(DCRNo, DocumentID, RevisionNo)
				GVerpDCRDetail.DataBind()
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVerpDCRDetail_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVerpDCRDetail.Init
    DataClassName = "GerpDCRDetail"
    SetGridView = GVerpDCRDetail
  End Sub
  Protected Sub TBLerpDCRDetail_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpDCRDetail.Init
    SetToolBar = TBLerpDCRDetail
  End Sub
  Protected Sub F_DCRNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_DCRNo.TextChanged
    Session("F_DCRNo") = F_DCRNo.Text
    Session("F_DCRNo_Display") = F_DCRNo_Display.Text
    InitGridPage()
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function DCRNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ERP.erpDCRHeader.SelecterpDCRHeaderAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_DCRNo_Display.Text = String.Empty
    If Not Session("F_DCRNo_Display") Is Nothing Then
      If Session("F_DCRNo_Display") <> String.Empty Then
        F_DCRNo_Display.Text = Session("F_DCRNo_Display")
      End If
    End If
    F_DCRNo.Text = String.Empty
    If Not Session("F_DCRNo") Is Nothing Then
      If Session("F_DCRNo") <> String.Empty Then
        F_DCRNo.Text = Session("F_DCRNo")
      End If
    End If
		Dim strScriptDCRNo As String = "<script type=""text/javascript""> " & _
			"function ACEDCRNo_Selected(sender, e) {" & _
			"  var F_DCRNo = $get('" & F_DCRNo.ClientID & "');" & _
			"  var F_DCRNo_Display = $get('" & F_DCRNo_Display.ClientID & "');" & _
			"  var retval = e.get_value();" & _
			"  var p = retval.split('|');" & _
			"  F_DCRNo.value = p[0];" & _
			"  F_DCRNo_Display.innerHTML = e.get_text();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_DCRNo") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_DCRNo", strScriptDCRNo)
			End If
		Dim strScriptPopulatingDCRNo As String = "<script type=""text/javascript""> " & _
			"function ACEDCRNo_Populating(o,e) {" & _
			"  var p = $get('" & F_DCRNo.ClientID & "');" & _
			"  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat= 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACEDCRNo_Populated(o,e) {" & _
			"  var p = $get('" & F_DCRNo.ClientID & "');" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_DCRNoPopulating") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_DCRNoPopulating", strScriptPopulatingDCRNo)
			End If
		Dim validateScriptDCRNo As String = "<script type=""text/javascript"">" & _
			"  function validate_DCRNo(o) {" & _
			"    validated_FK_ERP_DCRDetail_DCRNo_main = true;" & _
			"    validate_FK_ERP_DCRDetail_DCRNo(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateDCRNo") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateDCRNo", validateScriptDCRNo)
		End If
		Dim validateScriptFK_ERP_DCRDetail_DCRNo As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_ERP_DCRDetail_DCRNo(o) {" & _
			"    var value = o.id;" & _
			"    var DCRNo = $get('" & F_DCRNo.ClientID & "');" & _
			"    try{" & _
			"    if(DCRNo.value==''){" & _
			"      if(validated_FK_ERP_DCRDetail_DCRNo.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + DCRNo.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_ERP_DCRDetail_DCRNo(value, validated_FK_ERP_DCRDetail_DCRNo);" & _
			"  }" & _
			"  validated_FK_ERP_DCRDetail_DCRNo_main = false;" & _
			"  function validated_FK_ERP_DCRDetail_DCRNo(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ERP_DCRDetail_DCRNo") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ERP_DCRDetail_DCRNo", validateScriptFK_ERP_DCRDetail_DCRNo)
		End If
  End Sub
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ERP_DCRDetail_DCRNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim DCRNo As String = CType(aVal(1),String)
		Dim oVar As SIS.ERP.erpDCRHeader = SIS.ERP.erpDCRHeader.erpDCRHeaderGetByID(DCRNo)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
