Partial Class AF_tarTravelRequest
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtarTravelRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtarTravelRequest.Init
    DataClassName = "AtarTravelRequest"
    SetFormView = FVtarTravelRequest
  End Sub
  Protected Sub TBLtarTravelRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtarTravelRequest.Init
    SetToolBar = TBLtarTravelRequest
  End Sub
  Protected Sub FVtarTravelRequest_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtarTravelRequest.DataBound
    SIS.TAR.tarTravelRequest.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtarTravelRequest_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtarTravelRequest.PreRender
    Dim oF_RequestedFor_Display As Label  = FVtarTravelRequest.FindControl("F_RequestedFor_Display")
    Dim oF_RequestedFor As TextBox  = FVtarTravelRequest.FindControl("F_RequestedFor")
    Dim oF_ProjectID_Display As Label  = FVtarTravelRequest.FindControl("F_ProjectID_Display")
    Dim oF_ProjectID As TextBox  = FVtarTravelRequest.FindControl("F_ProjectID")
    Dim oF_ProjectManagerID_Display As Label  = FVtarTravelRequest.FindControl("F_ProjectManagerID_Display")
    Dim oF_ProjectManagerID As TextBox  = FVtarTravelRequest.FindControl("F_ProjectManagerID")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TAR_Main/App_Create") & "/AF_tarTravelRequest.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttarTravelRequest") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttarTravelRequest", mStr)
    End If
    If Request.QueryString("RequestID") IsNot Nothing Then
      CType(FVtarTravelRequest.FindControl("F_RequestID"), TextBox).Text = Request.QueryString("RequestID")
      CType(FVtarTravelRequest.FindControl("F_RequestID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function RequestedForCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taWebUsers.SelecttaWebUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectManagerIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taWebUsers.SelecttaWebUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_TA_TravelRequest_RequestedFor(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim RequestedFor As String = CType(aVal(1),String)
    Dim oVar As SIS.TA.taWebUsers = SIS.TA.taWebUsers.taWebUsersGetByID(RequestedFor)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_TA_TravelRequest_ProjectManagerID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ProjectManagerID As String = CType(aVal(1),String)
    Dim oVar As SIS.TA.taWebUsers = SIS.TA.taWebUsers.taWebUsersGetByID(ProjectManagerID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_TA_TravelRequest_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
