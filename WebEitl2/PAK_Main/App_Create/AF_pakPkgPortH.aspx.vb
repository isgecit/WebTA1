Partial Class AF_pakPkgPortH
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakPkgListH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPkgListH.Init
    DataClassName = "ApakPkgListH"
    SetFormView = FVpakPkgListH
  End Sub
  Protected Sub TBLpakPkgListH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakPkgListH.Init
    SetToolBar = TBLpakPkgListH
  End Sub
  Protected Sub FVpakPkgListH_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPkgListH.DataBound
    SIS.PAK.pakPkgListH.SetDefaultValues(sender, e)
  End Sub
  Protected Sub FVpakPkgListH_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPkgListH.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakPkgPortH.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakPkgPortH") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakPkgPortH", mStr)
    End If
    CType(FVpakPkgListH.FindControl("F_SerialNo"), TextBox).Text = "0"
    CType(FVpakPkgListH.FindControl("F_SerialNo"), TextBox).Enabled = False
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function SerialNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakPO.SelectpakPOAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function TransporterIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakBusinessPartner.SelectpakBusinessPartnerAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function VRExecutionNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.VR.vrRequestExecution.SelectvrRequestExecutionAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PAK_PkgListH_ProjectID(ByVal value As String) As String
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
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PAK_PkgListH_TransporterID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim TransporterID As String = CType(aVal(1), String)
    Dim oVar As SIS.PAK.pakBusinessPartner = SIS.PAK.pakBusinessPartner.pakBusinessPartnerGetByID(TransporterID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_PAK_PkgListH_VRExecutionNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim VRExecutionNo As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.vrRequestExecutionGetByID(VRExecutionNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function

End Class
