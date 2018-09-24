Partial Class GF_pakCItems
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/PAK_Main/App_Display/DF_pakCItems.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?RootItem=" & aVal(0) & "&ItemNo=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVpakCItems_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakCItems.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim RootItem As Int32 = GVpakCItems.DataKeys(e.CommandArgument).Values("RootItem")  
        Dim ItemNo As Int32 = GVpakCItems.DataKeys(e.CommandArgument).Values("ItemNo")  
        Dim RedirectUrl As String = TBLpakCItems.EditUrl & "?RootItem=" & RootItem & "&ItemNo=" & ItemNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim RootItem As Int32 = GVpakCItems.DataKeys(e.CommandArgument).Values("RootItem")  
        Dim ItemNo As Int32 = GVpakCItems.DataKeys(e.CommandArgument).Values("ItemNo")  
        SIS.PAK.pakCItems.DeleteWF(RootItem, ItemNo)
        GVpakCItems.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVpakCItems_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakCItems.Init
    DataClassName = "GpakCItems"
    SetGridView = GVpakCItems
  End Sub
  Protected Sub TBLpakCItems_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakCItems.Init
    SetToolBar = TBLpakCItems
  End Sub
  Protected Sub F_RootItem_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_RootItem.TextChanged
    Session("F_RootItem") = F_RootItem.Text
    Session("F_RootItem_Display") = F_RootItem_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function RootItemCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakItems.SelectpakItemsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_RootItem_Display.Text = String.Empty
    If Not Session("F_RootItem_Display") Is Nothing Then
      If Session("F_RootItem_Display") <> String.Empty Then
        F_RootItem_Display.Text = Session("F_RootItem_Display")
      End If
    End If
    F_RootItem.Text = String.Empty
    If Not Session("F_RootItem") Is Nothing Then
      If Session("F_RootItem") <> String.Empty Then
        F_RootItem.Text = Session("F_RootItem")
      End If
    End If
    Dim strScriptRootItem As String = "<script type=""text/javascript""> " & _
      "function ACERootItem_Selected(sender, e) {" & _
      "  var F_RootItem = $get('" & F_RootItem.ClientID & "');" & _
      "  var F_RootItem_Display = $get('" & F_RootItem_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_RootItem.value = p[0];" & _
      "  F_RootItem_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_RootItem") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_RootItem", strScriptRootItem)
      End If
    Dim strScriptPopulatingRootItem As String = "<script type=""text/javascript""> " & _
      "function ACERootItem_Populating(o,e) {" & _
      "  var p = $get('" & F_RootItem.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACERootItem_Populated(o,e) {" & _
      "  var p = $get('" & F_RootItem.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_RootItemPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_RootItemPopulating", strScriptPopulatingRootItem)
      End If
    Dim validateScriptRootItem As String = "<script type=""text/javascript"">" & _
      "  function validate_RootItem(o) {" & _
      "    validated_FK_PAK_Items_RootItem_main = true;" & _
      "    validate_FK_PAK_Items_RootItem(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateRootItem") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateRootItem", validateScriptRootItem)
    End If
    Dim validateScriptFK_PAK_Items_RootItem As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_PAK_Items_RootItem(o) {" & _
      "    var value = o.id;" & _
      "    var RootItem = $get('" & F_RootItem.ClientID & "');" & _
      "    try{" & _
      "    if(RootItem.value==''){" & _
      "      if(validated_FK_PAK_Items_RootItem.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + RootItem.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_PAK_Items_RootItem(value, validated_FK_PAK_Items_RootItem);" & _
      "  }" & _
      "  validated_FK_PAK_Items_RootItem_main = false;" & _
      "  function validated_FK_PAK_Items_RootItem(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_PAK_Items_RootItem") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_PAK_Items_RootItem", validateScriptFK_PAK_Items_RootItem)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_Items_RootItem(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim RootItem As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.PAK.pakItems = SIS.PAK.pakItems.pakItemsGetByID(RootItem)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
