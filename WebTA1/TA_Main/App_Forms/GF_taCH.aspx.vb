Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Partial Class GF_taCH
  Inherits SIS.SYS.GridBase
  Protected Sub GVtaCH_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVtaCH.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaCH.DataKeys(e.CommandArgument).Values("TABillNo")
        Dim RedirectUrl As String = TBLtaCH.EditUrl & "?TABillNo=" & TABillNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "Holdwf".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaCH.DataKeys(e.CommandArgument).Values("TABillNo")
        Dim oTA As SIS.TA.taCH = SIS.TA.taCH.taCHGetByID(TABillNo)
        If oTA.BillStatusID <> TAStates.UnderHoldByAccounts Then
          SIS.TA.taCH.HoldWF(TABillNo)
          GVtaCH.DataBind()
        End If
        Dim message As String = New JavaScriptSerializer().Serialize(oTA.GetHoldNotesLink)
        Dim script As String = String.Format("show_holdnotes({0});", message)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      Catch ex As Exception
        Dim message As String = New JavaScriptSerializer().Serialize(ex.Message)
        Dim script As String = String.Format("alert({0});", message)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      End Try
    End If
    If e.CommandName.ToLower = "Reminder".ToLower Then
      Try
        'Dim TABillNo As Int32 = GVtaCH.DataKeys(e.CommandArgument).Values("TABillNo")
        'SIS.TA.taCH.SendReminderEMail(SIS.TA.taCH.taCHGetByID(TABillNo))
        'GVtaCH.DataBind()
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "Unlockwf".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaCH.DataKeys(e.CommandArgument).Values("TABillNo")
        SIS.TA.taCH.UnlockWF(TABillNo)
        GVtaCH.DataBind()
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaCH.DataKeys(e.CommandArgument).Values("TABillNo")
        SIS.TA.taCH.InitiateWF(TABillNo)
        GVtaCH.DataBind()
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "approvewf".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaCH.DataKeys(e.CommandArgument).Values("TABillNo")
        SIS.TA.taCH.ApproveWF(TABillNo)
        GVtaCH.DataBind()
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "rejectwf".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaCH.DataKeys(e.CommandArgument).Values("TABillNo")
        SIS.TA.taCH.RejectWF(TABillNo)
        GVtaCH.DataBind()
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "completewf".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaCH.DataKeys(e.CommandArgument).Values("TABillNo")
        SIS.TA.taCH.CompleteWF(TABillNo)
        GVtaCH.DataBind()
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "Savewf".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaCH.DataKeys(e.CommandArgument).Values("TABillNo")
        Dim tmpValue As String = ""
        tmpValue = CType(GVtaCH.Rows(e.CommandArgument).FindControl("F_VoucherType"), TextBox).Text
        tmpValue &= "|" & CType(GVtaCH.Rows(e.CommandArgument).FindControl("F_VoucherNo"), TextBox).Text
        tmpValue &= "|" & CType(GVtaCH.Rows(e.CommandArgument).FindControl("F_VoucherCompany"), DropDownList).SelectedValue
        SIS.TA.taCH.SaveWF(TABillNo, tmpValue)
        GVtaCH.DataBind()
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "Cancelwf".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaCH.DataKeys(e.CommandArgument).Values("TABillNo")
        SIS.TA.taCH.CancelWF(TABillNo)
        GVtaCH.DataBind()
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "Lockwf".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaCH.DataKeys(e.CommandArgument).Values("TABillNo")
        SIS.TA.taCH.LockWF(TABillNo)
        GVtaCH.DataBind()
      Catch ex As Exception
        Dim message As String = New JavaScriptSerializer().Serialize(ex.Message)
        Dim script As String = String.Format("alert({0});", message)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      End Try
    End If
    If e.CommandName.ToLower = "PostWF".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaCH.DataKeys(e.CommandArgument).Values("TABillNo")
        SIS.TA.taCH.PostWF(TABillNo)
        GVtaCH.DataBind()
      Catch ex As Exception
        Dim message As String = New JavaScriptSerializer().Serialize(ex.Message)
        Dim script As String = String.Format("alert({0});", message)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      End Try
    End If
    If e.CommandName.ToLower = "SavePost".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaCH.DataKeys(e.CommandArgument).Values("TABillNo")
        Dim tmpValue As String = ""
        Dim VchOn As String = CType(GVtaCH.Rows(e.CommandArgument).FindControl("F_VCHOn"), TextBox).Text
        Dim Dept As String = CType(GVtaCH.Rows(e.CommandArgument).FindControl("F_Dept"), LC_taDepartments).SelectedValue
        Dim CC As String = CType(GVtaCH.Rows(e.CommandArgument).FindControl("F_CC"), LC_taDepartments).SelectedValue
        Dim Element As String = CType(GVtaCH.Rows(e.CommandArgument).FindControl("F_Element"), DropDownList).SelectedValue
        tmpValue = VchOn & "," & Dept & "," & CC & "," & Element
        SIS.TA.taCH.SavePost(TABillNo, tmpValue)
        GVtaCH.DataBind()
      Catch ex As Exception
        Dim message As String = New JavaScriptSerializer().Serialize(ex.Message)
        Dim script As String = String.Format("alert({0});", message)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      End Try
    End If
    If e.CommandName.ToLower = "CancelPost".ToLower Then
      Try
        Dim TABillNo As Int32 = GVtaCH.DataKeys(e.CommandArgument).Values("TABillNo")
        SIS.TA.taCH.CancelPost(TABillNo)
        GVtaCH.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVtaCH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaCH.Init
    DataClassName = "GtaCH"
    SetGridView = GVtaCH
  End Sub
  Protected Sub TBLtaCH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaCH.Init
    SetToolBar = TBLtaCH
  End Sub
  Protected Sub F_EmployeeID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_EmployeeID.TextChanged
    Session("F_EmployeeID") = F_EmployeeID.Text
    Session("F_EmployeeID_Display") = F_EmployeeID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function EmployeeIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taEmployees.SelecttaEmployeesAutoCompleteList(prefixText, count, contextKey)
  End Function
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
    F_EmployeeID_Display.Text = String.Empty
    If Not Session("F_EmployeeID_Display") Is Nothing Then
      If Session("F_EmployeeID_Display") <> String.Empty Then
        F_EmployeeID_Display.Text = Session("F_EmployeeID_Display")
      End If
    End If
    F_EmployeeID.Text = String.Empty
    If Not Session("F_EmployeeID") Is Nothing Then
      If Session("F_EmployeeID") <> String.Empty Then
        F_EmployeeID.Text = Session("F_EmployeeID")
      End If
    End If
    Dim strScriptEmployeeID As String = "<script type=""text/javascript""> " &
      "function ACEEmployeeID_Selected(sender, e) {" &
      "  var F_EmployeeID = $get('" & F_EmployeeID.ClientID & "');" &
      "  var F_EmployeeID_Display = $get('" & F_EmployeeID_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_EmployeeID.value = p[0];" &
      "  F_EmployeeID_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_EmployeeID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_EmployeeID", strScriptEmployeeID)
    End If
    Dim strScriptPopulatingEmployeeID As String = "<script type=""text/javascript""> " &
      "function ACEEmployeeID_Populating(o,e) {" &
      "  var p = $get('" & F_EmployeeID.ClientID & "');" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACEEmployeeID_Populated(o,e) {" &
      "  var p = $get('" & F_EmployeeID.ClientID & "');" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_EmployeeIDPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_EmployeeIDPopulating", strScriptPopulatingEmployeeID)
    End If
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
    Dim validateScriptEmployeeID As String = "<script type=""text/javascript"">" &
      "  function validate_EmployeeID(o) {" &
      "    validated_FK_TA_Bills_EmployeeID_main = true;" &
      "    validate_FK_TA_Bills_EmployeeID(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateEmployeeID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateEmployeeID", validateScriptEmployeeID)
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
    Dim validateScriptFK_TA_Bills_EmployeeID As String = "<script type=""text/javascript"">" &
      "  function validate_FK_TA_Bills_EmployeeID(o) {" &
      "    var value = o.id;" &
      "    var EmployeeID = $get('" & F_EmployeeID.ClientID & "');" &
      "    try{" &
      "    if(EmployeeID.value==''){" &
      "      if(validated_FK_TA_Bills_EmployeeID.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + EmployeeID.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_TA_Bills_EmployeeID(value, validated_FK_TA_Bills_EmployeeID);" &
      "  }" &
      "  validated_FK_TA_Bills_EmployeeID_main = false;" &
      "  function validated_FK_TA_Bills_EmployeeID(result) {" &
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_TA_Bills_EmployeeID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_TA_Bills_EmployeeID", validateScriptFK_TA_Bills_EmployeeID)
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
  Public Shared Function validate_FK_TA_Bills_EmployeeID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim EmployeeID As String = CType(aVal(1), String)
    Dim oVar As SIS.TA.taEmployees = SIS.TA.taEmployees.taEmployeesGetByID(EmployeeID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
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
    Dim BillStatusID As String = CType(aVal(1), String)
    Dim oVar As SIS.TA.taBillStates = Nothing
    Try
      oVar = SIS.TA.taBillStates.taBillStatesGetByID(BillStatusID)
    Catch ex As Exception
    End Try
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
End Class
