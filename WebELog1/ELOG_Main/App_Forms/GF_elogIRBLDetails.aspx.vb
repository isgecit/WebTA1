Partial Class GF_elogIRBLDetails
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ELOG_Main/App_Display/DF_elogIRBLDetails.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?IRNo=" & aVal(0) & "&SerialNo=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVelogIRBLDetails_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVelogIRBLDetails.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim IRNo As Int32 = GVelogIRBLDetails.DataKeys(e.CommandArgument).Values("IRNo")  
        Dim SerialNo As Int32 = GVelogIRBLDetails.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLelogIRBLDetails.EditUrl & "?IRNo=" & IRNo & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVelogIRBLDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVelogIRBLDetails.Init
    DataClassName = "GelogIRBLDetails"
    SetGridView = GVelogIRBLDetails
  End Sub
  Protected Sub TBLelogIRBLDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogIRBLDetails.Init
    SetToolBar = TBLelogIRBLDetails
  End Sub
  Protected Sub F_IRNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_IRNo.TextChanged
    Session("F_IRNo") = F_IRNo.Text
    Session("F_IRNo_Display") = F_IRNo_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function IRNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ELOG.elogIRBL.SelectelogIRBLAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_IRNo_Display.Text = String.Empty
    If Not Session("F_IRNo_Display") Is Nothing Then
      If Session("F_IRNo_Display") <> String.Empty Then
        F_IRNo_Display.Text = Session("F_IRNo_Display")
      End If
    End If
    F_IRNo.Text = String.Empty
    If Not Session("F_IRNo") Is Nothing Then
      If Session("F_IRNo") <> String.Empty Then
        F_IRNo.Text = Session("F_IRNo")
      End If
    End If
    Dim strScriptIRNo As String = "<script type=""text/javascript""> " & _
      "function ACEIRNo_Selected(sender, e) {" & _
      "  var F_IRNo = $get('" & F_IRNo.ClientID & "');" & _
      "  var F_IRNo_Display = $get('" & F_IRNo_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_IRNo.value = p[0];" & _
      "  F_IRNo_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_IRNo") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_IRNo", strScriptIRNo)
      End If
    Dim strScriptPopulatingIRNo As String = "<script type=""text/javascript""> " & _
      "function ACEIRNo_Populating(o,e) {" & _
      "  var p = $get('" & F_IRNo.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEIRNo_Populated(o,e) {" & _
      "  var p = $get('" & F_IRNo.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_IRNoPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_IRNoPopulating", strScriptPopulatingIRNo)
      End If
    Dim validateScriptIRNo As String = "<script type=""text/javascript"">" & _
      "  function validate_IRNo(o) {" & _
      "    validated_FK_ELOG_IRBLDetails_IRNo_main = true;" & _
      "    validate_FK_ELOG_IRBLDetails_IRNo(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateIRNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateIRNo", validateScriptIRNo)
    End If
    Dim validateScriptFK_ELOG_IRBLDetails_IRNo As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_ELOG_IRBLDetails_IRNo(o) {" & _
      "    var value = o.id;" & _
      "    var IRNo = $get('" & F_IRNo.ClientID & "');" & _
      "    try{" & _
      "    if(IRNo.value==''){" & _
      "      if(validated_FK_ELOG_IRBLDetails_IRNo.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + IRNo.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_ELOG_IRBLDetails_IRNo(value, validated_FK_ELOG_IRBLDetails_IRNo);" & _
      "  }" & _
      "  validated_FK_ELOG_IRBLDetails_IRNo_main = false;" & _
      "  function validated_FK_ELOG_IRBLDetails_IRNo(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ELOG_IRBLDetails_IRNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ELOG_IRBLDetails_IRNo", validateScriptFK_ELOG_IRBLDetails_IRNo)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ELOG_IRBLDetails_IRNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim IRNo As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.ELOG.elogIRBL = SIS.ELOG.elogIRBL.elogIRBLGetByID(IRNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
