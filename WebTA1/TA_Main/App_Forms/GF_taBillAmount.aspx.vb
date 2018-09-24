Partial Class GF_taBillAmount
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TA_Main/App_Display/DF_taBillAmount.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?TABillNo=" & aVal(0) & "&ComponentID=" & aVal(1) & "&CurrencyID=" & aVal(2) & "&CostCenterID=" & aVal(3)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtaBillAmount_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaBillAmount.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaBillAmount.DataKeys(e.CommandArgument).Values("TABillNo")  
        Dim ComponentID As Int32 = GVtaBillAmount.DataKeys(e.CommandArgument).Values("ComponentID")  
        Dim CurrencyID As String = GVtaBillAmount.DataKeys(e.CommandArgument).Values("CurrencyID")  
        Dim CostCenterID As String = GVtaBillAmount.DataKeys(e.CommandArgument).Values("CostCenterID")  
        Dim RedirectUrl As String = TBLtaBillAmount.EditUrl & "?TABillNo=" & TABillNo & "&ComponentID=" & ComponentID & "&CurrencyID=" & CurrencyID & "&CostCenterID=" & CostCenterID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtaBillAmount_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaBillAmount.Init
    DataClassName = "GtaBillAmount"
    SetGridView = GVtaBillAmount
  End Sub
  Protected Sub TBLtaBillAmount_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaBillAmount.Init
    SetToolBar = TBLtaBillAmount
  End Sub
  Protected Sub F_TABillNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_TABillNo.TextChanged
    Session("F_TABillNo") = F_TABillNo.Text
    Session("F_TABillNo_Display") = F_TABillNo_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function TABillNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taBH.SelecttaBHAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_TABillNo_Display.Text = String.Empty
    If Not Session("F_TABillNo_Display") Is Nothing Then
      If Session("F_TABillNo_Display") <> String.Empty Then
        F_TABillNo_Display.Text = Session("F_TABillNo_Display")
      End If
    End If
    F_TABillNo.Text = String.Empty
    If Not Session("F_TABillNo") Is Nothing Then
      If Session("F_TABillNo") <> String.Empty Then
        F_TABillNo.Text = Session("F_TABillNo")
      End If
    End If
    Dim strScriptTABillNo As String = "<script type=""text/javascript""> " & _
      "function ACETABillNo_Selected(sender, e) {" & _
      "  var F_TABillNo = $get('" & F_TABillNo.ClientID & "');" & _
      "  var F_TABillNo_Display = $get('" & F_TABillNo_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_TABillNo.value = p[0];" & _
      "  F_TABillNo_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_TABillNo") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_TABillNo", strScriptTABillNo)
      End If
    Dim strScriptPopulatingTABillNo As String = "<script type=""text/javascript""> " & _
      "function ACETABillNo_Populating(o,e) {" & _
      "  var p = $get('" & F_TABillNo.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACETABillNo_Populated(o,e) {" & _
      "  var p = $get('" & F_TABillNo.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_TABillNoPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_TABillNoPopulating", strScriptPopulatingTABillNo)
      End If
    Dim validateScriptTABillNo As String = "<script type=""text/javascript"">" & _
      "  function validate_TABillNo(o) {" & _
      "    validated_FK_TA_BillAmount_TABillNo_main = true;" & _
      "    validate_FK_TA_BillAmount_TABillNo(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateTABillNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateTABillNo", validateScriptTABillNo)
    End If
    Dim validateScriptFK_TA_BillAmount_TABillNo As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_TA_BillAmount_TABillNo(o) {" & _
      "    var value = o.id;" & _
      "    var TABillNo = $get('" & F_TABillNo.ClientID & "');" & _
      "    try{" & _
      "    if(TABillNo.value==''){" & _
      "      if(validated_FK_TA_BillAmount_TABillNo.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + TABillNo.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_TA_BillAmount_TABillNo(value, validated_FK_TA_BillAmount_TABillNo);" & _
      "  }" & _
      "  validated_FK_TA_BillAmount_TABillNo_main = false;" & _
      "  function validated_FK_TA_BillAmount_TABillNo(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_TA_BillAmount_TABillNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_TA_BillAmount_TABillNo", validateScriptFK_TA_BillAmount_TABillNo)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_TA_BillAmount_TABillNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim TABillNo As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.TA.taBH = SIS.TA.taBH.taBHGetByID(TABillNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
