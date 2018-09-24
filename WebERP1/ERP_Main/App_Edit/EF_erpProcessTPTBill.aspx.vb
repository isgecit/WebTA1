Partial Class EF_erpProcessTPTBill
	Inherits SIS.SYS.UpdateBase
	Protected Sub SaveAndReturn(ByVal s As Object, ByVal e As EventArgs)
		Dim SerialNo As Int32 = CType(s, Button).CommandArgument
		Dim Remarks As String = CType(FVerpProcessTPTBill.FindControl("F_AccountsRemarks"), TextBox).Text
		'FVerpProcessTPTBill.UpdateItem(True)
		SIS.ERP.erpProcessTPTBill.RejectWF(SerialNo, Remarks)
	End Sub
  Protected Sub FVerpProcessTPTBill_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpProcessTPTBill.Init
    DataClassName = "EerpProcessTPTBill"
    SetFormView = FVerpProcessTPTBill
  End Sub
  Protected Sub TBLerpProcessTPTBill_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLerpProcessTPTBill.Init
    SetToolBar = TBLerpProcessTPTBill
  End Sub
  Protected Sub FVerpProcessTPTBill_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVerpProcessTPTBill.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ERP_Main/App_Edit") & "/EF_erpProcessTPTBill.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripterpProcessTPTBill") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripterpProcessTPTBill", mStr)
		End If
		TBLerpProcessTPTBill.EnableSave = Editable
		TBLerpProcessTPTBill.EnableDelete = False
  End Sub
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
	Protected Sub ODSerpProcessTPTBill_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSerpProcessTPTBill.Selected
		Dim oTmp As SIS.ERP.erpCreateTPTBill = CType(e.ReturnValue, SIS.ERP.erpCreateTPTBill)
		Select Case oTmp.BillStatus
			Case TptBillStatus.Closed, TptBillStatus.UnderReceiveByAccounts, TptBillStatus.PaymentProcessed
				Editable = False
			Case Else
				Editable = True
		End Select

	End Sub
	<System.Web.Services.WebMethod()> _
	 Public Shared Function getPaymentData(ByVal value As String) As String
		Return SIS.ERP.erpCreateTPTBill.getPaymentData(value)
	End Function
End Class
