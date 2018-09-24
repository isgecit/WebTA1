Imports System.Web.Script.Serialization
Partial Class GF_pakTCPOLR
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PAK_Main/App_Display/DF_pakTCPOLR.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SerialNo=" & aVal(0) & "&ItemNo=" & aVal(1) & "&UploadNo=" & aVal(2)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpakTCPOLR_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakTCPOLR.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakTCPOLR.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim ItemNo As Int32 = GVpakTCPOLR.DataKeys(e.CommandArgument).Values("ItemNo")  
        Dim UploadNo As Int32 = GVpakTCPOLR.DataKeys(e.CommandArgument).Values("UploadNo")  
        Dim RedirectUrl As String = TBLpakTCPOLR.EditUrl & "?SerialNo=" & SerialNo & "&ItemNo=" & ItemNo & "&UploadNo=" & UploadNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpakTCPOLR_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakTCPOLR.Init
    DataClassName = "GpakTCPOLR"
    SetGridView = GVpakTCPOLR
  End Sub
  Protected Sub TBLpakTCPOLR_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakTCPOLR.Init
    SetToolBar = TBLpakTCPOLR
  End Sub
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
  Protected Sub F_ItemNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ItemNo.TextChanged
    Session("F_ItemNo") = F_ItemNo.Text
    Session("F_ItemNo_Display") = F_ItemNo_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ItemNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakTCPOL.SelectpakTCPOLAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
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
    F_ItemNo_Display.Text = String.Empty
    If Not Session("F_ItemNo_Display") Is Nothing Then
      If Session("F_ItemNo_Display") <> String.Empty Then
        F_ItemNo_Display.Text = Session("F_ItemNo_Display")
      End If
    End If
    F_ItemNo.Text = String.Empty
    If Not Session("F_ItemNo") Is Nothing Then
      If Session("F_ItemNo") <> String.Empty Then
        F_ItemNo.Text = Session("F_ItemNo")
      End If
    End If
    Dim strScriptItemNo As String = "<script type=""text/javascript""> " & _
      "function ACEItemNo_Selected(sender, e) {" & _
      "  var F_ItemNo = $get('" & F_ItemNo.ClientID & "');" & _
      "  var F_ItemNo_Display = $get('" & F_ItemNo_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_ItemNo.value = p[1];" & _
      "  F_ItemNo_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ItemNo") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ItemNo", strScriptItemNo)
      End If
    Dim strScriptPopulatingItemNo As String = "<script type=""text/javascript""> " & _
      "function ACEItemNo_Populating(o,e) {" & _
      "  var p = $get('" & F_ItemNo.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEItemNo_Populated(o,e) {" & _
      "  var p = $get('" & F_ItemNo.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ItemNoPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ItemNoPopulating", strScriptPopulatingItemNo)
      End If
    Dim validateScriptSerialNo As String = "<script type=""text/javascript"">" & _
      "  function validate_SerialNo(o) {" & _
      "    validated_FK_PAK_POLineRec_SerialNo_main = true;" & _
      "    validate_FK_PAK_POLineRec_SerialNo(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateSerialNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateSerialNo", validateScriptSerialNo)
    End If
    Dim validateScriptItemNo As String = "<script type=""text/javascript"">" & _
      "  function validate_ItemNo(o) {" & _
      "    validated_FK_PAK_POLineRec_ItemNo_main = true;" & _
      "    validate_FK_PAK_POLineRec_ItemNo(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateItemNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateItemNo", validateScriptItemNo)
    End If
    Dim validateScriptFK_PAK_POLineRec_SerialNo As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PAK_POLineRec_SerialNo(o) {" & _
      "    var value = o.id;" & _
      "    var SerialNo = $get('" & F_SerialNo.ClientID & "');" & _
      "    try{" & _
      "    if(SerialNo.value==''){" & _
      "      if(validated_FK_PAK_POLineRec_SerialNo.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + SerialNo.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PAK_POLineRec_SerialNo(value, validated_FK_PAK_POLineRec_SerialNo);" & _
      "  }" & _
      "  validated_FK_PAK_POLineRec_SerialNo_main = false;" & _
      "  function validated_FK_PAK_POLineRec_SerialNo(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PAK_POLineRec_SerialNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PAK_POLineRec_SerialNo", validateScriptFK_PAK_POLineRec_SerialNo)
    End If
    Dim validateScriptFK_PAK_POLineRec_ItemNo As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PAK_POLineRec_ItemNo(o) {" & _
      "    var value = o.id;" & _
      "    var SerialNo = $get('" & F_SerialNo.ClientID & "');" & _
      "    try{" & _
      "    if(SerialNo.value==''){" & _
      "      if(validated_FK_PAK_POLineRec_ItemNo.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + SerialNo.value ;" & _
      "    }catch(ex){}" & _
      "    var ItemNo = $get('" & F_ItemNo.ClientID & "');" & _
      "    try{" & _
      "    if(ItemNo.value==''){" & _
      "      if(validated_FK_PAK_POLineRec_ItemNo.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + ItemNo.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PAK_POLineRec_ItemNo(value, validated_FK_PAK_POLineRec_ItemNo);" & _
      "  }" & _
      "  validated_FK_PAK_POLineRec_ItemNo_main = false;" & _
      "  function validated_FK_PAK_POLineRec_ItemNo(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PAK_POLineRec_ItemNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PAK_POLineRec_ItemNo", validateScriptFK_PAK_POLineRec_ItemNo)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_POLineRec_SerialNo(ByVal value As String) As String
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
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_POLineRec_ItemNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SerialNo As Int32 = CType(aVal(1),Int32)
    Dim ItemNo As Int32 = CType(aVal(2),Int32)
    Dim oVar As SIS.PAK.pakTCPOL = SIS.PAK.pakTCPOL.pakTCPOLGetByID(SerialNo,ItemNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
