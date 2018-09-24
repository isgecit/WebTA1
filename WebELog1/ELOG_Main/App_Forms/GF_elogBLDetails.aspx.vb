Partial Class GF_elogBLDetails
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/ELOG_Main/App_Display/DF_elogBLDetails.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?BLID=" & aVal(0) & "&SerialNo=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVelogBLDetails_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVelogBLDetails.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim BLID As String = GVelogBLDetails.DataKeys(e.CommandArgument).Values("BLID")  
        Dim SerialNo As Int32 = GVelogBLDetails.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLelogBLDetails.EditUrl & "?BLID=" & BLID & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVelogBLDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVelogBLDetails.Init
    DataClassName = "GelogBLDetails"
    SetGridView = GVelogBLDetails
  End Sub
  Protected Sub TBLelogBLDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogBLDetails.Init
    SetToolBar = TBLelogBLDetails
  End Sub
  Protected Sub F_BLID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_BLID.TextChanged
    Session("F_BLID") = F_BLID.Text
    Session("F_BLID_Display") = F_BLID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function BLIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.ELOG.elogBLHeader.SelectelogBLHeaderAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_BLID_Display.Text = String.Empty
    If Not Session("F_BLID_Display") Is Nothing Then
      If Session("F_BLID_Display") <> String.Empty Then
        F_BLID_Display.Text = Session("F_BLID_Display")
      End If
    End If
    F_BLID.Text = String.Empty
    If Not Session("F_BLID") Is Nothing Then
      If Session("F_BLID") <> String.Empty Then
        F_BLID.Text = Session("F_BLID")
      End If
    End If
    Dim strScriptBLID As String = "<script type=""text/javascript""> " & _
      "function ACEBLID_Selected(sender, e) {" & _
      "  var F_BLID = $get('" & F_BLID.ClientID & "');" & _
      "  var F_BLID_Display = $get('" & F_BLID_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_BLID.value = p[0];" & _
      "  F_BLID_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_BLID") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_BLID", strScriptBLID)
      End If
    Dim strScriptPopulatingBLID As String = "<script type=""text/javascript""> " & _
      "function ACEBLID_Populating(o,e) {" & _
      "  var p = $get('" & F_BLID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEBLID_Populated(o,e) {" & _
      "  var p = $get('" & F_BLID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_BLIDPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_BLIDPopulating", strScriptPopulatingBLID)
      End If
    Dim validateScriptBLID As String = "<script type=""text/javascript"">" & _
      "  function validate_BLID(o) {" & _
      "    validated_FK_ELOG_BLDetails_BLID_main = true;" & _
      "    validate_FK_ELOG_BLDetails_BLID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateBLID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateBLID", validateScriptBLID)
    End If
    Dim validateScriptFK_ELOG_BLDetails_BLID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_ELOG_BLDetails_BLID(o) {" & _
      "    var value = o.id;" & _
      "    var BLID = $get('" & F_BLID.ClientID & "');" & _
      "    try{" & _
      "    if(BLID.value==''){" & _
      "      if(validated_FK_ELOG_BLDetails_BLID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + BLID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_ELOG_BLDetails_BLID(value, validated_FK_ELOG_BLDetails_BLID);" & _
      "  }" & _
      "  validated_FK_ELOG_BLDetails_BLID_main = false;" & _
      "  function validated_FK_ELOG_BLDetails_BLID(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_ELOG_BLDetails_BLID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_ELOG_BLDetails_BLID", validateScriptFK_ELOG_BLDetails_BLID)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ELOG_BLDetails_BLID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim BLID As String = CType(aVal(1),String)
    Dim oVar As SIS.ELOG.elogBLHeader = SIS.ELOG.elogBLHeader.elogBLHeaderGetByID(BLID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
