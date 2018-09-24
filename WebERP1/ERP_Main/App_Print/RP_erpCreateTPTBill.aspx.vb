Partial Class RP_erpCreateTPTBill
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/ERP_Main/App_Display/DF_erpCreateTPTBill.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SerialNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
		Dim SerialNo As Int32 = CType(aVal(0),Int32)
		Dim oVar As SIS.ERP.erpCreateTPTBill = SIS.ERP.erpCreateTPTBill.erpCreateTPTBillGetByID(SerialNo)
    Dim oTbl As New Table
    oTbl.Width = 1000
    Dim oCol As TableCell = Nothing
    Dim oRow As TableRow = Nothing
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Serial No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.SerialNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Transporter Bill No."
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.TPTBillNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Transporter Bill Date"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.TPTBillDate
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Tpt. Bill Received On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.TPTBillReceivedOn
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Created By"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.CreatedBy
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.aspnet_Users7_UserFullName
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Created On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.CreatedOn
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "GR Nos."
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.GRNos
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Transporter Code"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.TPTCode
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VR_Transporters10_TransporterName
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Purchase Order No."
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.PONumber
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Project ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ProjectID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.IDM_Projects9_Description
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Tpt. Bill Amount"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.TPTBillAmount
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Basic Freight Value"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.BasicFreightValue
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Basic Freight Value ODC"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.BasicFvODC
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Detention at Loading Point"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DetentionatLP
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Detention at UnLoading Point"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DetentionatULP
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "ODC Charges In Contract"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ODCChargesInContract
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "ODC Charges Out Of Contract"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ODCChargesOutOfContract
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Empty Return Charges"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.EmptyReturnCharges
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "RTO Challan Amount"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.RTOChallanAmount
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Other Amount"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.OtherAmount
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Service Tax"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ServiceTax
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Total Bill Passed Amount"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.TotalBillPassedAmount
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Forwarded To [Accounts Emp.]"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DiscReturnedToByAC
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.aspnet_Users4_UserFullName
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Cheque No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ChequeNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Logistics Remarks"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.LgstRemarks
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Bill Status"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.BillStatus
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ERP_TPTBillStatus8_Description
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Forwarded To Accounts On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.FWDToAccountsOn
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Forwarded To Accounts By"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.FWDToAccountsBy
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.aspnet_Users1_UserFullName
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Received In Accounts On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.RECDByAccountsOn
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Received In Accounts By"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.RECDinAccountsBy
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.aspnet_Users2_UserFullName
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Disc.Doc. Returned By A/c On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DiscReturnedByACOn
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Disc.Doc. Returned By"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DiscReturnedinAcBy
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.aspnet_Users3_UserFullName
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Disc.Doc. Received in Logistics By"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DiscRecdInLgstBy
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.aspnet_Users5_UserFullName
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Disc.Doc. Received in Logistics On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DiscRecdInLgstOn
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Re-Submitted to Accounts By"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ReFwdToAcBy
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.aspnet_Users6_UserFullName
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Re-Submitted to Accounts On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ReFwdToACOn
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "PTR No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.PTRNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "PTR Amount"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.PTRAmount
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "PTR Date"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.PTRDate
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Bank Voucher No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.BankVCHNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Bank Voucher Amount"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.BankVCHAmount
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Bank Voucher Date"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.BankVCHDate
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Accounts Remarks"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.AccountsRemarks
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    form1.Controls.Add(oTbl)
  End Sub
End Class
