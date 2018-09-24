Partial Class GF_taD_GuestHouseDA
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TA_Main/App_Display/DF_taD_GuestHouseDA.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SerialNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtaD_GuestHouseDA_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaD_GuestHouseDA.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVtaD_GuestHouseDA.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLtaD_GuestHouseDA.EditUrl & "?SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtaD_GuestHouseDA_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaD_GuestHouseDA.Init
    DataClassName = "GtaD_GuestHouseDA"
    SetGridView = GVtaD_GuestHouseDA
  End Sub
  Protected Sub TBLtaD_GuestHouseDA_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaD_GuestHouseDA.Init
    SetToolBar = TBLtaD_GuestHouseDA
  End Sub
  Protected Sub F_CategoryID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CategoryID.SelectedIndexChanged
    Session("F_CategoryID") = F_CategoryID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_CityID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CityID.TextChanged
    Session("F_CityID") = F_CityID.Text
    Session("F_CityID_Display") = F_CityID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function CityIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taCities.SelecttaCitiesAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_CategoryID.SelectedValue = String.Empty
    If Not Session("F_CategoryID") Is Nothing Then
      If Session("F_CategoryID") <> String.Empty Then
        F_CategoryID.SelectedValue = Session("F_CategoryID")
      End If
    End If
    F_CityID_Display.Text = String.Empty
    If Not Session("F_CityID_Display") Is Nothing Then
      If Session("F_CityID_Display") <> String.Empty Then
        F_CityID_Display.Text = Session("F_CityID_Display")
      End If
    End If
    F_CityID.Text = String.Empty
    If Not Session("F_CityID") Is Nothing Then
      If Session("F_CityID") <> String.Empty Then
        F_CityID.Text = Session("F_CityID")
      End If
    End If
    Dim strScriptCityID As String = "<script type=""text/javascript""> " & _
      "function ACECityID_Selected(sender, e) {" & _
      "  var F_CityID = $get('" & F_CityID.ClientID & "');" & _
      "  var F_CityID_Display = $get('" & F_CityID_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_CityID.value = p[0];" & _
      "  F_CityID_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_CityID") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_CityID", strScriptCityID)
      End If
    Dim strScriptPopulatingCityID As String = "<script type=""text/javascript""> " & _
      "function ACECityID_Populating(o,e) {" & _
      "  var p = $get('" & F_CityID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACECityID_Populated(o,e) {" & _
      "  var p = $get('" & F_CityID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_CityIDPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_CityIDPopulating", strScriptPopulatingCityID)
      End If
    Dim validateScriptCityID As String = "<script type=""text/javascript"">" & _
      "  function validate_CityID(o) {" & _
      "    validated_FK_TA_D_GuestHouseDA_CityID_main = true;" & _
      "    validate_FK_TA_D_GuestHouseDA_CityID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateCityID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateCityID", validateScriptCityID)
    End If
    Dim validateScriptFK_TA_D_GuestHouseDA_CityID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_TA_D_GuestHouseDA_CityID(o) {" & _
      "    var value = o.id;" & _
      "    var CityID = $get('" & F_CityID.ClientID & "');" & _
      "    try{" & _
      "    if(CityID.value==''){" & _
      "      if(validated_FK_TA_D_GuestHouseDA_CityID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + CityID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_TA_D_GuestHouseDA_CityID(value, validated_FK_TA_D_GuestHouseDA_CityID);" & _
      "  }" & _
      "  validated_FK_TA_D_GuestHouseDA_CityID_main = false;" & _
      "  function validated_FK_TA_D_GuestHouseDA_CityID(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_TA_D_GuestHouseDA_CityID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_TA_D_GuestHouseDA_CityID", validateScriptFK_TA_D_GuestHouseDA_CityID)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_TA_D_GuestHouseDA_CityID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim CityID As String = CType(aVal(1),String)
    Dim oVar As SIS.TA.taCities = SIS.TA.taCities.taCitiesGetByID(CityID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
