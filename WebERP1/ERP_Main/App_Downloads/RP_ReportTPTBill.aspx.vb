Imports System.Data
Imports System.Data.SqlClient
Imports OfficeOpenXml
Partial Class RP_ReportTPTBill
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		'================
		Dim mLastScriptTimeout As Integer = HttpContext.Current.Server.ScriptTimeout
		HttpContext.Current.Server.ScriptTimeout = 1200
		'================

		Dim FromDate As String = ""
		Dim ToDate As String = ""
		Dim StatusID As String = ""
		Try
			FromDate = Request.QueryString("fd")
			ToDate = Request.QueryString("td")
			StatusID = Request.QueryString("typ")
		Catch ex As Exception
			FromDate = ""
			ToDate = ""
			StatusID = ""
		End Try
		If FromDate = String.Empty Then Return
		Dim DWFile As String = "Bill_" & Convert.ToDateTime(ToDate).Month.ToString & "_" & Convert.ToDateTime(ToDate).Year.ToString
		Dim FilePath As String = CreateFile(FromDate, ToDate, StatusID)
		'================
		HttpContext.Current.Server.ScriptTimeout = mLastScriptTimeout
		'===============
		Response.ClearContent()
		Response.AppendHeader("content-disposition", "attachment; filename=" & DWFile & ".xlsx" & """")
		Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(IO.Path.GetFileName(FilePath))
		Response.WriteFile(FilePath)
		Response.End()
	End Sub
	Private Function CreateFile(ByVal FromDate As String, ByVal ToDate As String, ByVal StatusID As String) As String
		Dim FileName As String = Server.MapPath("~/..") & "App_Temp\" & Guid.NewGuid().ToString()
		IO.File.Copy(Server.MapPath("~/App_Templates") & "\TPTBill_Template.xlsx", FileName)
		Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
		Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)
		Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("Report")


		Dim mPage As Integer = 0
		Dim mSize As Integer = 50
		Dim oDocs As List(Of SIS.ERP.erpCreateTPTBill) = SIS.ERP.erpCreateTPTBill.GetByReceiptDate(mPage, mSize, FromDate, ToDate, StatusID)
		Dim r As Integer = 6
		Dim c As Integer = 1
		Dim tc As Integer = 7
		With xlWS
			.Cells(2, 2).Value = FromDate
			.Cells(2, 3).Value = ToDate

			Dim aToPrint() As String = "SerialNo,TPTBillNo,TPTBillDate,TPTBillReceivedOn,ERP_TPTBillStatus8_Description,CreatedBy,CreatedOn,GRNos,TPTCode,VR_Transporters10_TransporterName,PONumber,ProjectID,IDM_Projects9_Description,TPTBillAmount,BasicFreightValue,BasicFvODC,DetentionatLP,DetentionatULP,ODCChargesInContract,ODCChargesOutOfContract,EmptyReturnCharges,RTOChallanAmount,OtherAmount,ServiceTax,TotalBillPassedAmount,ChequeNo,FWDToAccountsOn,FWDToAccountsBy,RECDByAccountsOn,RECDinAccountsBy,DiscReturnedByACOn,DiscReturnedinAcBy,DiscRecdInLgstBy,DiscRecdInLgstOn,ReFwdToAcBy,ReFwdToACOn,PTRNo,PTRAmount,PTRDate,BankVCHNo,BankVCHAmount,BankVCHDate,AccountsRemarks,LgstRemarks".Split(",")
			Do While oDocs.Count > 0
				For Each rq As SIS.ERP.erpCreateTPTBill In oDocs
					'If r = 5 Then
					'	'Print Header
					'	For Each p As System.Reflection.PropertyInfo In rq.GetType().GetProperties()
					'		If p.CanRead Then
					'			.Cells(r, c).Value = p.Name
					'			c = c + 1
					'		End If
					'	Next
					'	r += 1
					'End If
					If r > 6 Then xlWS.InsertRow(r, 1, r + 1)
					c = 1
					For Each atr As String In aToPrint
						.Cells(r, c).Value = rq.GetType.GetProperty(atr).GetValue(rq, Nothing)
						c = c + 1
					Next
					If rq.LPisISGECWorks Then
						.Cells(r, c).Value = rq.DetentionatDaysLP
					Else
						.Cells(r, c + 1).Value = rq.DetentionatDaysLP
					End If
					c = c + 2
					If rq.ULPisICDCFSPort Then
						.Cells(r, c + 1).Value = rq.DetentionatDaysULP
					Else
						.Cells(r, c).Value = rq.DetentionatDaysULP
					End If
					c = c + 2
					.Cells(r, c).Value = rq.BackToTownCharges
					c = c + 1
					.Cells(r, c).Value = rq.TarpaulinCharges
					c = c + 1
					.Cells(r, c).Value = rq.WoodenSleeperCharges
					c = c + 1

					r += 1
				Next
				mPage += mSize
				oDocs = SIS.ERP.erpCreateTPTBill.GetByReceiptDate(mPage, mSize, FromDate, ToDate, StatusID)
			Loop
		End With

		'xlWS = xlPk.Workbook.Worksheets("NOT ISSUED")
		'oDocs = ProductivityReportClass.GetDocumentNotIssued(FromDate, ToDate, Division)
		'r = 5
		'With xlWS
		'	For Each doc As ProductivityReportClass In oDocs
		'		If r > 5 Then xlWS.InsertRow(r, 1, r + 1)
		'		c = 1
		'		.Cells(r, c).Value = doc.ProjectID
		'		c += 1
		'		.Cells(r, c).Value = doc.DocumentID.Trim
		'		c += 1
		'		.Cells(r, c).Value = doc.RevisionNo
		'		c += 1
		'		.Cells(r, c).Value = doc.IssueDate
		'		r += 1
		'	Next
		'End With


		xlPk.Save()
		xlPk.Dispose()

		Return FileName
	End Function
End Class
