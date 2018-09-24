Partial Class EF_erpCreateTPTBill
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVerpCreateTPTBill_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpCreateTPTBill.Init
    DataClassName = "EerpCreateTPTBill"
    SetFormView = FVerpCreateTPTBill
  End Sub
  Protected Sub TBLerpCreateTPTBill_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpCreateTPTBill.Init
    SetToolBar = TBLerpCreateTPTBill
  End Sub
  Protected Sub FVerpCreateTPTBill_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpCreateTPTBill.PreRender
		TBLerpCreateTPTBill.PrintUrl &= Request.QueryString("SerialNo") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ERP_Main/App_Edit") & "/EF_erpCreateTPTBill.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripterpCreateTPTBill") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripterpCreateTPTBill", mStr)
		End If
		TBLerpCreateTPTBill.EnableSave = Editable
		TBLerpCreateTPTBill.EnableDelete = BillFree
		Dim oCtl As TextBox = Nothing
		Dim oChk As CheckBox = Nothing
		If Not BillFree Then
			oCtl = FVerpCreateTPTBill.FindControl("F_TPTBillNo")
			oCtl.Enabled = False
			oCtl = FVerpCreateTPTBill.FindControl("F_GRNos")
			oCtl.Enabled = False
			oCtl = FVerpCreateTPTBill.FindControl("F_TPTCode")
			oCtl.Enabled = False
			oCtl = FVerpCreateTPTBill.FindControl("F_TPTBillDate")
			oCtl.Enabled = False
			oCtl = FVerpCreateTPTBill.FindControl("F_TPTBillReceivedOn")
			oCtl.Enabled = False
			oCtl = FVerpCreateTPTBill.FindControl("F_PONumber")
			oCtl.Enabled = False
			oCtl = FVerpCreateTPTBill.FindControl("F_ProjectID")
			oCtl.Enabled = False
			oCtl = FVerpCreateTPTBill.FindControl("F_TPTBillAmount")
			oCtl.Enabled = False
			oCtl = FVerpCreateTPTBill.FindControl("F_BasicFreightValue")
			oCtl.Enabled = False
			oCtl = FVerpCreateTPTBill.FindControl("F_BasicFvODC")
			oCtl.Enabled = False
			oCtl = FVerpCreateTPTBill.FindControl("F_DetentionatLP")
			oCtl.Enabled = False
			oCtl = FVerpCreateTPTBill.FindControl("F_DetentionatULP")
			oCtl.Enabled = False
			oCtl = FVerpCreateTPTBill.FindControl("F_ODCChargesInContract")
			oCtl.Enabled = False
			oCtl = FVerpCreateTPTBill.FindControl("F_ODCChargesOutOfContract")
			oCtl.Enabled = False
			oCtl = FVerpCreateTPTBill.FindControl("F_EmptyReturnCharges")
			oCtl.Enabled = False
			oCtl = FVerpCreateTPTBill.FindControl("F_RTOChallanAmount")
			oCtl.Enabled = False
			oCtl = FVerpCreateTPTBill.FindControl("F_OtherAmount")
			oCtl.Enabled = False
			oCtl = FVerpCreateTPTBill.FindControl("F_ServiceTax")
			oCtl.Enabled = False
			oCtl = FVerpCreateTPTBill.FindControl("F_LgstRemarks")
			oCtl.Enabled = False
			oCtl = FVerpCreateTPTBill.FindControl("F_CreatedBy")
			oCtl.Enabled = False
			oCtl = FVerpCreateTPTBill.FindControl("F_BackToTownCharges")
			oCtl.Enabled = False
			oCtl = FVerpCreateTPTBill.FindControl("F_TarpaulinCharges")
			oCtl.Enabled = False
			oCtl = FVerpCreateTPTBill.FindControl("F_WoodenSleeperCharges")
			oCtl.Enabled = False
			oCtl = FVerpCreateTPTBill.FindControl("F_DetentionatDaysULP")
			oCtl.Enabled = False
			oChk = FVerpCreateTPTBill.FindControl("F_ULPisICDCFSPort")
			oChk.Enabled = False
			oCtl = FVerpCreateTPTBill.FindControl("F_DetentionatDaysLP")
			oCtl.Enabled = False
			oChk = FVerpCreateTPTBill.FindControl("F_LPisISGECWorks")
			oChk.Enabled = False
			oCtl = FVerpCreateTPTBill.FindControl("F_ChequeNo")
			oCtl.Style("background-color") = "yellow"
		Else
			oCtl = FVerpCreateTPTBill.FindControl("F_ChequeNo")
			oCtl.Style("background-color") = "yellow"
			oCtl.Enabled = False
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
	Public Property Editable() As Boolean
		Get
			If ViewState("Editable") IsNot Nothing Then
				Return Convert.ToBoolean(ViewState("Editable"))
			Else
				Return False
			End If
		End Get
		Set(ByVal value As Boolean)
			ViewState.Add("Editable", value)
		End Set
	End Property
	Public Property BillFree() As Boolean
		Get
			If ViewState("BillFree") IsNot Nothing Then
				Return Convert.ToBoolean(ViewState("BillFree"))
			Else
				Return True
			End If
		End Get
		Set(ByVal value As Boolean)
			ViewState.Add("BillFree", value)
		End Set
	End Property
	Protected Sub ODSerpCreateTPTBill_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSerpCreateTPTBill.Selected
		Dim oTmp As SIS.ERP.erpCreateTPTBill = CType(e.ReturnValue, SIS.ERP.erpCreateTPTBill)
		Select Case oTmp.BillStatus
			Case TptBillStatus.Cancelled, TptBillStatus.Closed, TptBillStatus.UnderPaymentProcessing, TptBillStatus.UnderReceiveByAccounts, TptBillStatus.UnderReceiveByLogistics
				Editable = False
			Case Else
				Editable = True
		End Select
		Select Case oTmp.BillStatus
			Case TptBillStatus.Free, TptBillStatus.UnderReSubmitbyLogistics
				BillFree = True
			Case Else
				BillFree = False
		End Select
	End Sub
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
