Partial Class AF_erpCreateTPTBill
  Inherits SIS.SYS.InsertBase
  Protected Sub FVerpCreateTPTBill_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpCreateTPTBill.Init
    DataClassName = "AerpCreateTPTBill"
    SetFormView = FVerpCreateTPTBill
  End Sub
  Protected Sub TBLerpCreateTPTBill_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpCreateTPTBill.Init
    SetToolBar = TBLerpCreateTPTBill
  End Sub
  Protected Sub FVerpCreateTPTBill_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpCreateTPTBill.PreRender
    Dim oF_TPTCode_Display As Label  = FVerpCreateTPTBill.FindControl("F_TPTCode_Display")
    oF_TPTCode_Display.Text = String.Empty
    If Not Session("F_TPTCode_Display") Is Nothing Then
      If Session("F_TPTCode_Display") <> String.Empty Then
        oF_TPTCode_Display.Text = Session("F_TPTCode_Display")
      End If
    End If
    Dim oF_TPTCode As TextBox  = FVerpCreateTPTBill.FindControl("F_TPTCode")
    oF_TPTCode.Enabled = True
    oF_TPTCode.Text = String.Empty
    If Not Session("F_TPTCode") Is Nothing Then
      If Session("F_TPTCode") <> String.Empty Then
        oF_TPTCode.Text = Session("F_TPTCode")
      End If
    End If
    Dim oF_ProjectID_Display As Label  = FVerpCreateTPTBill.FindControl("F_ProjectID_Display")
    oF_ProjectID_Display.Text = String.Empty
    If Not Session("F_ProjectID_Display") Is Nothing Then
      If Session("F_ProjectID_Display") <> String.Empty Then
        oF_ProjectID_Display.Text = Session("F_ProjectID_Display")
      End If
    End If
    Dim oF_ProjectID As TextBox  = FVerpCreateTPTBill.FindControl("F_ProjectID")
    oF_ProjectID.Enabled = True
    oF_ProjectID.Text = String.Empty
    If Not Session("F_ProjectID") Is Nothing Then
      If Session("F_ProjectID") <> String.Empty Then
        oF_ProjectID.Text = Session("F_ProjectID")
      End If
    End If
    Dim oF_DiscReturnedToByAC_Display As Label  = FVerpCreateTPTBill.FindControl("F_DiscReturnedToByAC_Display")
    Dim oF_DiscReturnedToByAC As TextBox  = FVerpCreateTPTBill.FindControl("F_DiscReturnedToByAC")
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ERP_Main/App_Create") & "/AF_erpCreateTPTBill.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripterpCreateTPTBill") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripterpCreateTPTBill", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVerpCreateTPTBill.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVerpCreateTPTBill.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function TPTCodeCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.VR.vrTransporters.SelectvrTransportersAutoCompleteList(prefixText, count, contextKey)
  End Function
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function DiscReturnedToByACCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ERP_TransporterBill_DiscReturnedToByAc(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim DiscReturnedToByAC As String = CType(aVal(1),String)
		Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(DiscReturnedToByAC)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ERP_TransporterBill_ProjectID(ByVal value As String) As String
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
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_ERP_TransporterBill_TPTCode(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim TPTCode As String = CType(aVal(1),String)
		Dim oVar As SIS.VR.vrTransporters = SIS.VR.vrTransporters.vrTransportersGetByID(TPTCode)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
	<System.Web.Services.WebMethod()> _
 <System.Web.Script.Services.ScriptMethod()> _
	Public Shared Function CreatedByCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
		Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
	End Function
	<System.Web.Services.WebMethod()> _
	 Public Shared Function validate_FK_ERP_TransporterBill_CreatedBy(ByVal value As String) As String
		Dim aVal() As String = value.Split(",".ToCharArray)
		Dim mRet As String = "0|" & aVal(0)
		Dim CreatedBy As String = CType(aVal(1), String)
		Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(CreatedBy)
		If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found."
		Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
		End If
		Return mRet
	End Function
	<System.Web.Services.WebMethod()> _
	 Public Shared Function getIRData(ByVal value As String) As String
		Return SIS.ERP.erpCreateTPTBill.getIRData(value)
	End Function

End Class
