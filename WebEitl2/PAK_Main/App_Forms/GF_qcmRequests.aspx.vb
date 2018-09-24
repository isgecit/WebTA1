Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Partial Class GF_qcmRequests
  Inherits SIS.SYS.GridBase
  Protected Sub GVqcmRequests_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVqcmRequests.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim RequestID As Int32 = GVqcmRequests.DataKeys(e.CommandArgument).Values("RequestID")
        Dim RedirectUrl As String = TBLqcmRequests.EditUrl & "?RequestID=" & RequestID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "lgfwd".ToLower Then
      Try
        Dim RequestID As Int32 = GVqcmRequests.DataKeys(e.CommandArgument).Values("RequestID")
        SIS.QCM.qcmRequests.ForwardForAllotment(RequestID)
        GVqcmRequests.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", String.Format("alert({0});", ex.Message), True)
      End Try
    End If
    If e.CommandName.ToLower = "lgcopy".ToLower Then
      Try
        Dim RequestID As Int32 = GVqcmRequests.DataKeys(e.CommandArgument).Values("RequestID")
        Dim tmp As SIS.QCM.qcmRequests = SIS.QCM.qcmRequests.qcmRequestsGetByID(RequestID)
        With tmp
          .RequestID = 0
          '.ProjectID = ""
          '.OrderNo = ""
          '.OrderDate = ""
          '.SupplierID = ""
          '.Description = ""
          '.RegionID = ""
          .TotalRequestedQuantity = "0.00"
          .LotSize = "0.00"
          .UOM = "Nos"
          .DocumentID = ""
          '.RequestedInspectionStartDate = ""
          '.RequestedInspectionFinishDate = ""
          .ClientInspectionRequired = False
          .ThirdPartyInspectionRequired = False
          .InspectionStageiD = ""
          .RequestStateID = "OPEN"
          .FileAttached = False
          .ReceivedOn = ""
          .ReceivedBy = ""
          .ReceivingMediumID = ""
          .CreatedBy = HttpContext.Current.Session("LoginID")
          .CreatedOn = Now
          '.CreationRemarks = ""
          .AllotedTo = ""
          .AllotedStartDate = ""
          .AllotedFinishDate = ""
          .AllotedOn = ""
          .AllotedBy = ""
          .AllotmentRemarks = ""
          .InspectionStartDate = ""
          .InspectionFinishDate = ""
          .InspectionStatusID = ""
          .CancelledOn = ""
          .CancelledBy = ""
          .CancellationRemarks = ""
          .ReturnRemarks = ""
          .Paused = False
          .PausedHrs = 0
          .TotalHrs = 0
          .LastPausedOn = ""
        End With
        tmp = SIS.QCM.qcmRequests.InsertData(tmp)
        Dim RedirectUrl As String = TBLqcmRequests.EditUrl & "?RequestID=" & tmp.RequestID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        Dim message As String = New JavaScriptSerializer().Serialize(ex.Message)
        Dim script As String = String.Format("alert({0});", message)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      End Try
    End If
  End Sub
  Protected Sub GVqcmRequests_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVqcmRequests.Init
    DataClassName = "GqcmRequests"
    SetGridView = GVqcmRequests
  End Sub
  Protected Sub TBLqcmRequests_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLqcmRequests.Init
    SetToolBar = TBLqcmRequests
  End Sub
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
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
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
    Dim validateScriptProjectID As String = "<script type=""text/javascript"">" &
     "  function validate_ProjectID(o) {" &
     "    validated_FK_QCM_Requests_ProjectID_main = true;" &
     "    validate_FK_QCM_Requests_ProjectID(o);" &
     "  }" &
     "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateProjectID", validateScriptProjectID)
    End If
    Dim validateScriptFK_QCM_Requests_ProjectID As String = "<script type=""text/javascript"">" &
     "  function validate_FK_QCM_Requests_ProjectID(o) {" &
     "    var value = o.id;" &
     "    var ProjectID = $get('" & F_ProjectID.ClientID & "');" &
     "    try{" &
     "    if(ProjectID.value==''){" &
     "      if(validated_FK_QCM_Requests_ProjectID.main){" &
     "        var o_d = $get(o.id +'_Display');" &
     "        try{o_d.innerHTML = '';}catch(ex){}" &
     "      }" &
     "    }" &
     "    value = value + ',' + ProjectID.value ;" &
     "    }catch(ex){}" &
     "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
     "    o.style.backgroundRepeat= 'no-repeat';" &
     "    o.style.backgroundPosition = 'right';" &
     "    PageMethods.validate_FK_QCM_Requests_ProjectID(value, validated_FK_QCM_Requests_ProjectID);" &
     "  }" &
     "  validated_FK_QCM_Requests_ProjectID_main = false;" &
     "  function validated_FK_QCM_Requests_ProjectID(result) {" &
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_QCM_Requests_ProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_QCM_Requests_ProjectID", validateScriptFK_QCM_Requests_ProjectID)
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_QCM_Requests_ProjectID(ByVal value As String) As String
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

  Private Sub TBLqcmRequests_AddClicked(sender As Object, e As ImageClickEventArgs) Handles TBLqcmRequests.AddClicked
    Try
      Dim SupplierID As String = "S" & HttpContext.Current.Session("LoginID")
      Dim tmpLast As SIS.QCM.qcmRequests = Nothing
      If SIS.SYS.Utilities.SessionManager.IsAdmin Then
        SupplierID = ""
      End If
      tmpLast = SIS.QCM.qcmRequests.GetLastRequest(SupplierID)
      Dim tmp As New SIS.QCM.qcmRequests
      With tmp
        .RequestID = 0
        .ProjectID = ""
        .OrderNo = ""
        .OrderDate = ""
        .SupplierID = SupplierID
        .Description = ""
        .RegionID = ""
        .TotalRequestedQuantity = "0.00"
        .LotSize = "0.00"
        .UOM = "Nos"
        .DocumentID = ""
        .RequestedInspectionStartDate = ""
        .RequestedInspectionFinishDate = ""
        .ClientInspectionRequired = False
        .ThirdPartyInspectionRequired = False
        .InspectionStageiD = ""
        .RequestStateID = "OPEN"
        .FileAttached = False
        .ReceivedOn = ""
        .ReceivedBy = ""
        .ReceivingMediumID = ""
        .CreatedBy = HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
        .CreationRemarks = ""
        .AllotedTo = ""
        .AllotedStartDate = ""
        .AllotedFinishDate = ""
        .AllotedOn = ""
        .AllotedBy = ""
        .AllotmentRemarks = ""
        .InspectionStartDate = ""
        .InspectionFinishDate = ""
        .InspectionStatusID = ""
        .CancelledOn = ""
        .CancelledBy = ""
        .CancellationRemarks = ""
        .ReturnRemarks = ""
        .Paused = False
        .PausedHrs = 0
        .TotalHrs = 0
        .LastPausedOn = ""
        If tmpLast IsNot Nothing Then
          .CreationRemarks = tmpLast.CreationRemarks
          .RegionID = tmpLast.RegionID
        End If
      End With
      tmp = SIS.QCM.qcmRequests.InsertData(tmp)
      Dim RedirectUrl As String = TBLqcmRequests.EditUrl & "?RequestID=" & tmp.RequestID
      Response.Redirect(RedirectUrl)
    Catch ex As Exception
      Dim message As String = New JavaScriptSerializer().Serialize(ex.Message)
    Dim script As String = String.Format("alert({0});", message)
    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
    End Try

  End Sub
End Class
