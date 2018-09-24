Imports System.Web.Script.Serialization
Partial Class GF_pakPkgListD
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PAK_Main/App_Display/DF_pakPkgListD.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SerialNo=" & aVal(0) & "&PkgNo=" & aVal(1) & "&BOMNo=" & aVal(2) & "&ItemNo=" & aVal(3)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpakPkgListD_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakPkgListD.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakPkgListD.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim PkgNo As Int32 = GVpakPkgListD.DataKeys(e.CommandArgument).Values("PkgNo")  
        Dim BOMNo As Int32 = GVpakPkgListD.DataKeys(e.CommandArgument).Values("BOMNo")  
        Dim ItemNo As Int32 = GVpakPkgListD.DataKeys(e.CommandArgument).Values("ItemNo")  
        Dim RedirectUrl As String = TBLpakPkgListD.EditUrl & "?SerialNo=" & SerialNo & "&PkgNo=" & PkgNo & "&BOMNo=" & BOMNo & "&ItemNo=" & ItemNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpakPkgListD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakPkgListD.Init
    DataClassName = "GpakPkgListD"
    SetGridView = GVpakPkgListD
  End Sub
  Protected Sub TBLpakPkgListD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakPkgListD.Init
    SetToolBar = TBLpakPkgListD
  End Sub
  Protected Sub F_PkgNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_PkgNo.TextChanged
    Session("F_PkgNo") = F_PkgNo.Text
    Session("F_PkgNo_Display") = F_PkgNo_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function PkgNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakPkgListH.SelectpakPkgListHAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_SerialNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_SerialNo.TextChanged
    Session("F_SerialNo") = F_SerialNo.Text
    Session("F_SerialNo_Display") = F_SerialNo_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SerialNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakPO.SelectpakPOAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_PkgNo_Display.Text = String.Empty
    If Not Session("F_PkgNo_Display") Is Nothing Then
      If Session("F_PkgNo_Display") <> String.Empty Then
        F_PkgNo_Display.Text = Session("F_PkgNo_Display")
      End If
    End If
    F_PkgNo.Text = String.Empty
    If Not Session("F_PkgNo") Is Nothing Then
      If Session("F_PkgNo") <> String.Empty Then
        F_PkgNo.Text = Session("F_PkgNo")
      End If
    End If
    Dim strScriptPkgNo As String = "<script type=""text/javascript""> " & _
      "function ACEPkgNo_Selected(sender, e) {" & _
      "  var F_PkgNo = $get('" & F_PkgNo.ClientID & "');" & _
      "  var F_PkgNo_Display = $get('" & F_PkgNo_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_PkgNo.value = p[1];" & _
      "  F_PkgNo_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_PkgNo") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_PkgNo", strScriptPkgNo)
      End If
    Dim strScriptPopulatingPkgNo As String = "<script type=""text/javascript""> " & _
      "function ACEPkgNo_Populating(o,e) {" & _
      "  var p = $get('" & F_PkgNo.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEPkgNo_Populated(o,e) {" & _
      "  var p = $get('" & F_PkgNo.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_PkgNoPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_PkgNoPopulating", strScriptPopulatingPkgNo)
      End If
    F_SerialNo_Display.Text = String.Empty
    If Not Session("F_SerialNo_Display") Is Nothing Then
      If Session("F_SerialNo_Display") <> String.Empty Then
        F_SerialNo_Display.Text = Session("F_SerialNo_Display")
      End If
    End If
    F_SerialNo.Text = String.Empty
    If Not Session("F_SerialNo") Is Nothing Then
      If Session("F_SerialNo") <> String.Empty Then
        F_SerialNo.Text = Session("F_SerialNo")
      End If
    End If
    Dim strScriptSerialNo As String = "<script type=""text/javascript""> " & _
      "function ACESerialNo_Selected(sender, e) {" & _
      "  var F_SerialNo = $get('" & F_SerialNo.ClientID & "');" & _
      "  var F_SerialNo_Display = $get('" & F_SerialNo_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_SerialNo.value = p[0];" & _
      "  F_SerialNo_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_SerialNo") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_SerialNo", strScriptSerialNo)
      End If
    Dim strScriptPopulatingSerialNo As String = "<script type=""text/javascript""> " & _
      "function ACESerialNo_Populating(o,e) {" & _
      "  var p = $get('" & F_SerialNo.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACESerialNo_Populated(o,e) {" & _
      "  var p = $get('" & F_SerialNo.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_SerialNoPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_SerialNoPopulating", strScriptPopulatingSerialNo)
      End If
    Dim validateScriptPkgNo As String = "<script type=""text/javascript"">" & _
      "  function validate_PkgNo(o) {" & _
      "    validated_FK_PAK_PkgListD_PkgNo_main = true;" & _
      "    validate_FK_PAK_PkgListD_PkgNo(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validatePkgNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validatePkgNo", validateScriptPkgNo)
    End If
    Dim validateScriptSerialNo As String = "<script type=""text/javascript"">" & _
      "  function validate_SerialNo(o) {" & _
      "    validated_FK_PAK_PkgListD_SerialNo_main = true;" & _
      "    validate_FK_PAK_PkgListD_SerialNo(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateSerialNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateSerialNo", validateScriptSerialNo)
    End If
    Dim validateScriptFK_PAK_PkgListD_PkgNo As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PAK_PkgListD_PkgNo(o) {" & _
      "    var value = o.id;" & _
      "    var SerialNo = $get('" & F_SerialNo.ClientID & "');" & _
      "    try{" & _
      "    if(SerialNo.value==''){" & _
      "      if(validated_FK_PAK_PkgListD_PkgNo.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + SerialNo.value ;" & _
      "    }catch(ex){}" & _
      "    var PkgNo = $get('" & F_PkgNo.ClientID & "');" & _
      "    try{" & _
      "    if(PkgNo.value==''){" & _
      "      if(validated_FK_PAK_PkgListD_PkgNo.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + PkgNo.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PAK_PkgListD_PkgNo(value, validated_FK_PAK_PkgListD_PkgNo);" & _
      "  }" & _
      "  validated_FK_PAK_PkgListD_PkgNo_main = false;" & _
      "  function validated_FK_PAK_PkgListD_PkgNo(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PAK_PkgListD_PkgNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PAK_PkgListD_PkgNo", validateScriptFK_PAK_PkgListD_PkgNo)
    End If
    Dim validateScriptFK_PAK_PkgListD_SerialNo As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PAK_PkgListD_SerialNo(o) {" & _
      "    var value = o.id;" & _
      "    var SerialNo = $get('" & F_SerialNo.ClientID & "');" & _
      "    try{" & _
      "    if(SerialNo.value==''){" & _
      "      if(validated_FK_PAK_PkgListD_SerialNo.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + SerialNo.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PAK_PkgListD_SerialNo(value, validated_FK_PAK_PkgListD_SerialNo);" & _
      "  }" & _
      "  validated_FK_PAK_PkgListD_SerialNo_main = false;" & _
      "  function validated_FK_PAK_PkgListD_SerialNo(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PAK_PkgListD_SerialNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PAK_PkgListD_SerialNo", validateScriptFK_PAK_PkgListD_SerialNo)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_PkgListD_PkgNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SerialNo As Int32 = CType(aVal(1),Int32)
    Dim PkgNo As Int32 = CType(aVal(2),Int32)
    Dim oVar As SIS.PAK.pakPkgListH = SIS.PAK.pakPkgListH.pakPkgListHGetByID(SerialNo,PkgNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_PkgListD_SerialNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SerialNo As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PAK.pakPO = SIS.PAK.pakPO.pakPOGetByID(SerialNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
