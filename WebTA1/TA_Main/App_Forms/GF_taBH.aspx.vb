Imports System.Web.Script.Serialization
Partial Class GF_taBH
  Inherits SIS.SYS.GridBase
  Protected Sub GVtaBH_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaBH.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaBH.DataKeys(e.CommandArgument).Values("TABillNo")
        Dim RedirectUrl As String = TBLtaBH.EditUrl & "?TABillNo=" & TABillNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaBH.DataKeys(e.CommandArgument).Values("TABillNo")
        SIS.TA.taBH.InitiateWF(TABillNo)
        GVtaBH.DataBind()
      Catch ex As Exception
        Dim str As String = New JavaScriptSerializer().Serialize(ex.Message)
        Dim script As String = String.Format("alert({0});", str)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      End Try
    End If
    If e.CommandName.ToLower = "budgetwf".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaBH.DataKeys(e.CommandArgument).Values("TABillNo")
        Dim tmpStr As String = SIS.TA.taBH.SanctionAvailableHTML(TABillNo)
        Dim str As String = New JavaScriptSerializer().Serialize(tmpStr)
        Dim script As String = String.Format("show_message({0});", str)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      Catch ex As Exception
        Dim str As String = New JavaScriptSerializer().Serialize(ex.Message)
        Dim script As String = String.Format("alert({0});", str)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      End Try
    End If
  End Sub
  Protected Sub GVtaBH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaBH.Init
    DataClassName = "GtaBH"
    SetGridView = GVtaBH
  End Sub
  Protected Sub TBLtaBH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaBH.Init
    SetToolBar = TBLtaBH
  End Sub
  Protected Sub F_DestinationCity_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_DestinationCity.TextChanged
    Session("F_DestinationCity") = F_DestinationCity.Text
    Session("F_DestinationCity_Display") = F_DestinationCity_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function DestinationCityCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taCities.SelecttaCitiesAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_ProjectID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ProjectID.TextChanged
    Session("F_ProjectID") = F_ProjectID.Text
    Session("F_ProjectID_Display") = F_ProjectID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_BillStatusID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_BillStatusID.TextChanged
    Session("F_BillStatusID") = F_BillStatusID.Text
    Session("F_BillStatusID_Display") = F_BillStatusID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function BillStatusIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taBillStates.SelecttaBillStatesAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_TravelTypeID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_TravelTypeID.SelectedIndexChanged
    Session("F_TravelTypeID") = F_TravelTypeID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_DestinationCity_Display.Text = String.Empty
    If Not Session("F_DestinationCity_Display") Is Nothing Then
      If Session("F_DestinationCity_Display") <> String.Empty Then
        F_DestinationCity_Display.Text = Session("F_DestinationCity_Display")
      End If
    End If
    F_DestinationCity.Text = String.Empty
    If Not Session("F_DestinationCity") Is Nothing Then
      If Session("F_DestinationCity") <> String.Empty Then
        F_DestinationCity.Text = Session("F_DestinationCity")
      End If
    End If
    Dim strScriptDestinationCity As String = "<script type=""text/javascript""> " &
      "function ACEDestinationCity_Selected(sender, e) {" &
      "  var F_DestinationCity = $get('" & F_DestinationCity.ClientID & "');" &
      "  var F_DestinationCity_Display = $get('" & F_DestinationCity_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_DestinationCity.value = p[0];" &
      "  F_DestinationCity_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_DestinationCity") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_DestinationCity", strScriptDestinationCity)
    End If
    Dim strScriptPopulatingDestinationCity As String = "<script type=""text/javascript""> " &
      "function ACEDestinationCity_Populating(o,e) {" &
      "  var p = $get('" & F_DestinationCity.ClientID & "');" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACEDestinationCity_Populated(o,e) {" &
      "  var p = $get('" & F_DestinationCity.ClientID & "');" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_DestinationCityPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_DestinationCityPopulating", strScriptPopulatingDestinationCity)
    End If
    F_ProjectID_Display.Text = String.Empty
    If Not Session("F_ProjectID_Display") Is Nothing Then
      If Session("F_ProjectID_Display") <> String.Empty Then
        F_ProjectID_Display.Text = Session("F_ProjectID_Display")
      End If
    End If
    F_ProjectID.Text = String.Empty
    If Not Session("F_ProjectID") Is Nothing Then
      If Session("F_ProjectID") <> String.Empty Then
        F_ProjectID.Text = Session("F_ProjectID")
      End If
    End If
    Dim strScriptProjectID As String = "<script type=""text/javascript""> " &
      "function ACEProjectID_Selected(sender, e) {" &
      "  var F_ProjectID = $get('" & F_ProjectID.ClientID & "');" &
      "  var F_ProjectID_Display = $get('" & F_ProjectID_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_ProjectID.value = p[0];" &
      "  F_ProjectID_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ProjectID", strScriptProjectID)
    End If
    Dim strScriptPopulatingProjectID As String = "<script type=""text/javascript""> " &
      "function ACEProjectID_Populating(o,e) {" &
      "  var p = $get('" & F_ProjectID.ClientID & "');" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACEProjectID_Populated(o,e) {" &
      "  var p = $get('" & F_ProjectID.ClientID & "');" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ProjectIDPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ProjectIDPopulating", strScriptPopulatingProjectID)
    End If
    F_BillStatusID_Display.Text = String.Empty
    If Not Session("F_BillStatusID_Display") Is Nothing Then
      If Session("F_BillStatusID_Display") <> String.Empty Then
        F_BillStatusID_Display.Text = Session("F_BillStatusID_Display")
      End If
    End If
    F_BillStatusID.Text = String.Empty
    If Not Session("F_BillStatusID") Is Nothing Then
      If Session("F_BillStatusID") <> String.Empty Then
        F_BillStatusID.Text = Session("F_BillStatusID")
      End If
    End If
    Dim strScriptBillStatusID As String = "<script type=""text/javascript""> " &
      "function ACEBillStatusID_Selected(sender, e) {" &
      "  var F_BillStatusID = $get('" & F_BillStatusID.ClientID & "');" &
      "  var F_BillStatusID_Display = $get('" & F_BillStatusID_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_BillStatusID.value = p[0];" &
      "  F_BillStatusID_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_BillStatusID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_BillStatusID", strScriptBillStatusID)
    End If
    Dim strScriptPopulatingBillStatusID As String = "<script type=""text/javascript""> " &
      "function ACEBillStatusID_Populating(o,e) {" &
      "  var p = $get('" & F_BillStatusID.ClientID & "');" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACEBillStatusID_Populated(o,e) {" &
      "  var p = $get('" & F_BillStatusID.ClientID & "');" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_BillStatusIDPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_BillStatusIDPopulating", strScriptPopulatingBillStatusID)
    End If
    F_TravelTypeID.SelectedValue = String.Empty
    If Not Session("F_TravelTypeID") Is Nothing Then
      If Session("F_TravelTypeID") <> String.Empty Then
        F_TravelTypeID.SelectedValue = Session("F_TravelTypeID")
      End If
    End If
    Dim validateScriptDestinationCity As String = "<script type=""text/javascript"">" &
      "  function validate_DestinationCity(o) {" &
      "    validated_FK_TA_Bills_DestinationCity_main = true;" &
      "    validate_FK_TA_Bills_DestinationCity(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateDestinationCity") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateDestinationCity", validateScriptDestinationCity)
    End If
    Dim validateScriptProjectID As String = "<script type=""text/javascript"">" &
      "  function validate_ProjectID(o) {" &
      "    validated_FK_TA_Bills_ProjectID_main = true;" &
      "    validate_FK_TA_Bills_ProjectID(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateProjectID", validateScriptProjectID)
    End If
    Dim validateScriptBillStatusID As String = "<script type=""text/javascript"">" &
      "  function validate_BillStatusID(o) {" &
      "    validated_FK_TA_Bills_BillStatusID_main = true;" &
      "    validate_FK_TA_Bills_BillStatusID(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateBillStatusID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateBillStatusID", validateScriptBillStatusID)
    End If
    Dim validateScriptFK_TA_Bills_ProjectID As String = "<script type=""text/javascript"">" &
      "  function validate_FK_TA_Bills_ProjectID(o) {" &
      "    var value = o.id;" &
      "    var ProjectID = $get('" & F_ProjectID.ClientID & "');" &
      "    try{" &
      "    if(ProjectID.value==''){" &
      "      if(validated_FK_TA_Bills_ProjectID.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + ProjectID.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_TA_Bills_ProjectID(value, validated_FK_TA_Bills_ProjectID);" &
      "  }" &
      "  validated_FK_TA_Bills_ProjectID_main = false;" &
      "  function validated_FK_TA_Bills_ProjectID(result) {" &
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_TA_Bills_ProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_TA_Bills_ProjectID", validateScriptFK_TA_Bills_ProjectID)
    End If
    Dim validateScriptFK_TA_Bills_DestinationCity As String = "<script type=""text/javascript"">" &
      "  function validate_FK_TA_Bills_DestinationCity(o) {" &
      "    var value = o.id;" &
      "    var DestinationCity = $get('" & F_DestinationCity.ClientID & "');" &
      "    try{" &
      "    if(DestinationCity.value==''){" &
      "      if(validated_FK_TA_Bills_DestinationCity.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + DestinationCity.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_TA_Bills_DestinationCity(value, validated_FK_TA_Bills_DestinationCity);" &
      "  }" &
      "  validated_FK_TA_Bills_DestinationCity_main = false;" &
      "  function validated_FK_TA_Bills_DestinationCity(result) {" &
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_TA_Bills_DestinationCity") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_TA_Bills_DestinationCity", validateScriptFK_TA_Bills_DestinationCity)
    End If
    Dim validateScriptFK_TA_Bills_BillStatusID As String = "<script type=""text/javascript"">" &
      "  function validate_FK_TA_Bills_BillStatusID(o) {" &
      "    var value = o.id;" &
      "    var BillStatusID = $get('" & F_BillStatusID.ClientID & "');" &
      "    try{" &
      "    if(BillStatusID.value==''){" &
      "      if(validated_FK_TA_Bills_BillStatusID.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + BillStatusID.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_TA_Bills_BillStatusID(value, validated_FK_TA_Bills_BillStatusID);" &
      "  }" &
      "  validated_FK_TA_Bills_BillStatusID_main = false;" &
      "  function validated_FK_TA_Bills_BillStatusID(result) {" &
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_TA_Bills_BillStatusID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_TA_Bills_BillStatusID", validateScriptFK_TA_Bills_BillStatusID)
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_TA_Bills_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1), String)
    Dim oVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_TA_Bills_DestinationCity(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim DestinationCity As String = CType(aVal(1), String)
    Dim oVar As SIS.TA.taCities = SIS.TA.taCities.taCitiesGetByID(DestinationCity)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_TA_Bills_BillStatusID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim BillStatusID As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.TA.taBillStates = SIS.TA.taBillStates.taBillStatesGetByID(BillStatusID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
End Class
