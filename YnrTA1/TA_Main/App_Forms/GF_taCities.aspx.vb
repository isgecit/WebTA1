Partial Class GF_taCities
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/TA_Main/App_Display/DF_taCities.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl & "?CityID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVtaCities_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaCities.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim CityID As String = GVtaCities.DataKeys(e.CommandArgument).Values("CityID")
        Dim RedirectUrl As String = TBLtaCities.EditUrl & "?CityID=" & CityID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtaCities_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaCities.Init
    DataClassName = "GtaCities"
    SetGridView = GVtaCities
  End Sub
  Protected Sub TBLtaCities_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaCities.Init
    SetToolBar = TBLtaCities
  End Sub
  Protected Sub F_CountryID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CountryID.TextChanged
    Session("F_CountryID") = F_CountryID.Text
    Session("F_CountryID_Display") = F_CountryID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function CountryIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taCountries.SelecttaCountriesAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_RegionID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_RegionID.SelectedIndexChanged
    Session("F_RegionID") = F_RegionID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_CurrencyID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CurrencyID.SelectedIndexChanged
    Session("F_CurrencyID") = F_CurrencyID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_RegionTypeID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_RegionTypeID.SelectedIndexChanged
    Session("F_RegionTypeID") = F_RegionTypeID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_CountryID_Display.Text = String.Empty
    If Not Session("F_CountryID_Display") Is Nothing Then
      If Session("F_CountryID_Display") <> String.Empty Then
        F_CountryID_Display.Text = Session("F_CountryID_Display")
      End If
    End If
    F_CountryID.Text = String.Empty
    If Not Session("F_CountryID") Is Nothing Then
      If Session("F_CountryID") <> String.Empty Then
        F_CountryID.Text = Session("F_CountryID")
      End If
    End If
    Dim strScriptCountryID As String = "<script type=""text/javascript""> " &
      "function ACECountryID_Selected(sender, e) {" &
      "  var F_CountryID = $get('" & F_CountryID.ClientID & "');" &
      "  var F_CountryID_Display = $get('" & F_CountryID_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_CountryID.value = p[0];" &
      "  F_CountryID_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_CountryID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_CountryID", strScriptCountryID)
    End If
    Dim strScriptPopulatingCountryID As String = "<script type=""text/javascript""> " &
      "function ACECountryID_Populating(o,e) {" &
      "  var p = $get('" & F_CountryID.ClientID & "');" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACECountryID_Populated(o,e) {" &
      "  var p = $get('" & F_CountryID.ClientID & "');" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_CountryIDPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_CountryIDPopulating", strScriptPopulatingCountryID)
    End If
    F_RegionID.SelectedValue = String.Empty
    If Not Session("F_RegionID") Is Nothing Then
      If Session("F_RegionID") <> String.Empty Then
        F_RegionID.SelectedValue = Session("F_RegionID")
      End If
    End If
    F_CurrencyID.SelectedValue = String.Empty
    If Not Session("F_CurrencyID") Is Nothing Then
      If Session("F_CurrencyID") <> String.Empty Then
        F_CurrencyID.SelectedValue = Session("F_CurrencyID")
      End If
    End If
    F_RegionTypeID.SelectedValue = String.Empty
    If Not Session("F_RegionTypeID") Is Nothing Then
      If Session("F_RegionTypeID") <> String.Empty Then
        F_RegionTypeID.SelectedValue = Session("F_RegionTypeID")
      End If
    End If
    Dim validateScriptCountryID As String = "<script type=""text/javascript"">" &
      "  function validate_CountryID(o) {" &
      "    validated_FK_TA_Cities_CountryID_main = true;" &
      "    validate_FK_TA_Cities_CountryID(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateCountryID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateCountryID", validateScriptCountryID)
    End If
    Dim validateScriptFK_TA_Cities_CountryID As String = "<script type=""text/javascript"">" &
      "  function validate_FK_TA_Cities_CountryID(o) {" &
      "    var value = o.id;" &
      "    var CountryID = $get('" & F_CountryID.ClientID & "');" &
      "    try{" &
      "    if(CountryID.value==''){" &
      "      if(validated_FK_TA_Cities_CountryID.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + CountryID.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_TA_Cities_CountryID(value, validated_FK_TA_Cities_CountryID);" &
      "  }" &
      "  validated_FK_TA_Cities_CountryID_main = false;" &
      "  function validated_FK_TA_Cities_CountryID(result) {" &
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_TA_Cities_CountryID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_TA_Cities_CountryID", validateScriptFK_TA_Cities_CountryID)
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_TA_Cities_CountryID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim CountryID As String = CType(aVal(1), String)
    Dim oVar As SIS.TA.taCountries = SIS.TA.taCountries.taCountriesGetByID(CountryID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function

  'Protected Sub abcd(sender As Object, e As EventArgs)
  '  GVtaCities.UpdateRow(GVtaCities.EditIndex, False)
  'End Sub

  Private Sub GF_taCities_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taCities.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaCities") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaCities", mStr)
    End If

  End Sub

End Class
