Imports System.Web.Script.Serialization
Partial Class GF_pakHPendingAtPort
  Inherits SIS.SYS.GridBase
  Protected Sub GVpakHPending_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakHPending.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakHPending.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim PkgNo As Int32 = GVpakHPending.DataKeys(e.CommandArgument).Values("PkgNo")
        Dim RedirectUrl As String = TBLpakHPending.EditUrl & "?SerialNo=" & SerialNo & "&PkgNo=" & PkgNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "approvewf".ToLower Then
      Try
        Dim SerialNo As Int32 = GVpakHPending.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim PkgNo As Int32 = GVpakHPending.DataKeys(e.CommandArgument).Values("PkgNo")
        SIS.PAK.pakHPending.ReceivedAtPortWF(SerialNo, PkgNo)
        GVpakHPending.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVpakHPending_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakHPending.Init
    DataClassName = "GpakHPending"
    SetGridView = GVpakHPending
  End Sub
  Protected Sub TBLpakHPending_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakHPending.Init
    SetToolBar = TBLpakHPending
  End Sub
  Protected Sub F_SerialNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_SerialNo.TextChanged
    Session("F_SerialNo") = F_SerialNo.Text
    Session("F_SerialNo_Display") = F_SerialNo_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function SerialNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakPO.SelectpakPOAutoCompleteList(prefixText, count, contextKey)
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
    Dim strScriptSerialNo As String = "<script type=""text/javascript""> " &
      "function ACESerialNo_Selected(sender, e) {" &
      "  var F_SerialNo = $get('" & F_SerialNo.ClientID & "');" &
      "  var F_SerialNo_Display = $get('" & F_SerialNo_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_SerialNo.value = p[0];" &
      "  F_SerialNo_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_SerialNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_SerialNo", strScriptSerialNo)
    End If
    Dim strScriptPopulatingSerialNo As String = "<script type=""text/javascript""> " &
      "function ACESerialNo_Populating(o,e) {" &
      "  var p = $get('" & F_SerialNo.ClientID & "');" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACESerialNo_Populated(o,e) {" &
      "  var p = $get('" & F_SerialNo.ClientID & "');" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_SerialNoPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_SerialNoPopulating", strScriptPopulatingSerialNo)
    End If
    Dim validateScriptSerialNo As String = "<script type=""text/javascript"">" &
      "  function validate_SerialNo(o) {" &
      "    validated_FK_PAK_PkgListH_SerialNo_main = true;" &
      "    validate_FK_PAK_PkgListH_SerialNo(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateSerialNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateSerialNo", validateScriptSerialNo)
    End If
    Dim validateScriptFK_PAK_PkgListH_SerialNo As String = "<script type=""text/javascript"">" &
      "  function validate_FK_PAK_PkgListH_SerialNo(o) {" &
      "    var value = o.id;" &
      "    var SerialNo = $get('" & F_SerialNo.ClientID & "');" &
      "    try{" &
      "    if(SerialNo.value==''){" &
      "      if(validated_FK_PAK_PkgListH_SerialNo.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + SerialNo.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_PAK_PkgListH_SerialNo(value, validated_FK_PAK_PkgListH_SerialNo);" &
      "  }" &
      "  validated_FK_PAK_PkgListH_SerialNo_main = false;" &
      "  function validated_FK_PAK_PkgListH_SerialNo(result) {" &
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PAK_PkgListH_SerialNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PAK_PkgListH_SerialNo", validateScriptFK_PAK_PkgListH_SerialNo)
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PAK_PkgListH_SerialNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim SerialNo As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.PAK.pakPO = SIS.PAK.pakPO.pakPOGetByID(SerialNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
End Class
