Imports System.Data
Imports System.Data.SqlClient
Imports OfficeOpenXml
Imports System.Drawing

Partial Class DCReport
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Dim mLastScriptTimeout As Integer = HttpContext.Current.Server.ScriptTimeout
		HttpContext.Current.Server.ScriptTimeout = 1200
		Dim FromDate As String = ""
		Dim ToDate As String = ""
		Dim Division As String = ""
		Try
			FromDate = Request.QueryString("fd")
			ToDate = Request.QueryString("td")
			Division = Request.QueryString("typ")
		Catch ex As Exception
			FromDate = ""
			ToDate = ""
			Division = ""
		End Try
		If FromDate = String.Empty Then Return
		Dim DWFile As String = "Delivery Challan List"
		Dim FilePath As String = CreateFile(FromDate, ToDate)
		HttpContext.Current.Server.ScriptTimeout = mLastScriptTimeout
		Response.ClearContent()
		Response.AppendHeader("content-disposition", "attachment; filename=" & DWFile & ".xlsx")
		Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(IO.Path.GetFileName(FilePath))
		Response.WriteFile(FilePath)
		Response.End()
	End Sub
	Private Function CreateFile(ByVal FromDate As String, ByVal ToDate As String) As String
		Dim FileName As String = Server.MapPath("~/..") & "App_Temp\" & Guid.NewGuid().ToString()
		IO.File.Copy(Server.MapPath("~/App_Templates") & "\DCTemplate.xlsx", FileName)
		Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
		Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)

		Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("Data")
		Dim oDocs As List(Of DCReportClass) = DCReportClass.GetData(FromDate, ToDate)
		Dim r As Integer = 5
		Dim c As Integer = 2
		Dim s As Integer = 1
		Dim identifier As String = ""
		'xlWS.Cells(2, 2).Value = Now
		xlWS.Cells(3, 2).Value = "Delivery Challan Report From " & FromDate & " TO " & ToDate
		With xlWS
			For Each doc As DCReportClass In oDocs
				If r > 5 Then
					xlWS.InsertRow(r, 1, r + 1)
				End If
				c = 2

				If identifier <> doc.ChallanID Then
					.Cells(r, 2).Value = s

					'xlWS.Cells(r, 2).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
					'xlWS.Cells(r, 2).Style.Fill.BackgroundColor.SetColor(Color.Orange)
					s = s + 1
					'c = c + 1
					.Cells(r, 3).Value = doc.ChallanID
					'xlWS.Cells(r, 3).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
					'xlWS.Cells(r, 3).Style.Fill.BackgroundColor.SetColor(Color.Orange)
					'c = c + 1
					.Cells(r, 4).Value = doc.ChallanDate
					'c = c + 1
					.Cells(r, 5).Value = doc.BillNODate
					'c = c + 1
					.Cells(r, 6).Value = doc.PONo
					'c = c + 1
					.Cells(r, 7).Value = doc.ProjectID
					'c = c + 1
					.Cells(r, 8).Value = doc.ProjectName
					'c = c + 1
					.Cells(r, 9).Value = doc.ConsignerName
					'c = c + 1
					.Cells(r, 10).Value = doc.ConsigneeName
					'c = c + 1
					.Cells(r, 11).Value = doc.ConsigneeGSTINNo
					'c = c + 1
					'.Cells(r, c).Value = doc.ConsigneeGSTIN
					'c = c + 1
					.Cells(r, 12).Value = doc.ConsigneeAddress1Line & ", " & doc.ConsigneeAddress2Line & " " & doc.ConsigneeAddress3Line
					c = c + 1
					'.Cells(r, c).Value = doc.ConsigneeAddress2Line
					'c = c + 1
					'.Cells(r, c).Value = doc.ConsigneeAddress3Line
					'c = c + 1
					'.Cells(r, c).Value = doc.ConsigneeStateID
					'c = c + 1
					.Cells(r, 13).Value = doc.StateDescription
					'c = c + 1
					.Cells(r, 14).Value = doc.Purpose
					'c = c + 1

					'c = c + 1
					.Cells(r, 15).Value = doc.StatusDescription
					.Cells(r, 26).Value = doc.TotalAmountonHeader
				Else
					'c = c + 1
					.Cells(r, 2).Value = ""
					'c = c + 1
					.Cells(r, 3).Value = ""
					'c = c + 1
					.Cells(r, 4).Value = ""
					'c = c + 1
					.Cells(r, 5).Value = ""
					'c = c + 1
					.Cells(r, 6).Value = ""
					'c = c + 1
					.Cells(r, 7).Value = ""
					'c = c + 1
					.Cells(r, 8).Value = ""
					'c = c + 1
					.Cells(r, 9).Value = ""
					'c = c + 1
					.Cells(r, 10).Value = ""
					'c = c + 1
					'.Cells(r, c).Value = doc.ConsigneeGSTIN
					'c = c + 1
					.Cells(r, 11).Value = ""
					'c = c + 1
					'.Cells(r, c).Value = doc.ConsigneeAddress2Line
					'c = c + 1
					'.Cells(r, c).Value = doc.ConsigneeAddress3Line
					'c = c + 1
					'.Cells(r, c).Value = doc.ConsigneeStateID
					'c = c + 1
					.Cells(r, 12).Value = ""
					'c = c + 1
					.Cells(r, 13).Value = ""
					'c = c + 1
					.Cells(r, 14).Value = ""
					'c = c + 1
					.Cells(r, 15).Value = ""
					.Cells(r, 26).Value = ""
					'r = r + 1

				End If
				'xlWS.Cells(r, 16).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
				'xlWS.Cells(r, 16).Style.Fill.BackgroundColor.SetColor(Color.LightYellow)
				'c = c + 1
				.Cells(r, 16).Value = doc.SerialNo
				'c = c + 1
				.Cells(r, 17).Value = doc.ItemDescription
				'c = c + 1
				.Cells(r, 18).Value = doc.Quantity
				'c = c + 1
				.Cells(r, 19).Value = doc.UnitOfMeasurement
				'c = c + 1

				'c = c + 1
				.Cells(r, 20).Value = doc.AssessableValue
				'c = c + 1
				.Cells(r, 21).Value = doc.IGSTAmount
				'c = c + 1
				.Cells(r, 22).Value = doc.SGSTAmount
				'c = c + 1
				.Cells(r, 23).Value = doc.CGSTAmount
				'c = c + 1
				.Cells(r, 24).Value = doc.TotalGST
				'c = c + 1
				.Cells(r, 25).Value = doc.TotalAmount
				'c = c + 1

				.Cells(r, 27).Value = doc.IsgecInvoiceNo
				'c = c + 1
				.Cells(r, 28).Value = doc.IsgecInvoiceDate
				'c = c + 1
				identifier = doc.ChallanID
				r += 1

			Next
		End With


		xlPk.Save()
		xlPk.Dispose()
		Return FileName
	End Function
	Private Function RemoveChars(ByVal mstr As String) As String
		'Dim tstr As String = ""
		'For i As Integer = 0 To mstr.Length - 1
		'	If Asc(mstr.Chars(i)) Then

		'	End If
		'Next
		Return mstr.Replace(vbCr, "").Replace(vbLf, "").Replace(vbCrLf, "").Replace(vbNewLine, "")
	End Function
End Class
Public Class DCReportClass

	Private _challanID As String = ""
	Public Property ChallanID() As String
		Get
			Return _challanID
		End Get
		Set(ByVal value As String)
			_challanID = value
		End Set
	End Property
	Private _challanDate As String = ""
	Public Property ChallanDate() As String
		Get
			Return _challanDate
		End Get
		Set(ByVal value As String)
			_challanDate = value
		End Set
	End Property
	Private _billNODate As String = ""
	Public Property BillNODate() As String
		Get
			Return _billNODate
		End Get
		Set(ByVal value As String)
			_billNODate = value
		End Set
	End Property
	Private _unitOfMeasurement As String = ""
	Public Property UnitOfMeasurement() As String
		Get
			Return _unitOfMeasurement
		End Get
		Set(ByVal value As String)
			_unitOfMeasurement = value
		End Set
	End Property
	Private _quantity As String = ""
	Public Property Quantity() As String
		Get
			Return _quantity
		End Get
		Set(ByVal value As String)
			_quantity = value
		End Set
	End Property

	Private _pONo As String = ""
	Public Property PONo() As String
		Get
			Return _pONo
		End Get
		Set(ByVal value As String)
			_pONo = value
		End Set
	End Property


	Private _projectID As String = ""
	Public Property ProjectID() As String
		Get
			Return _projectID
		End Get
		Set(ByVal value As String)
			_projectID = value
		End Set
	End Property

	Private _projectName As String = ""
	Public Property ProjectName() As String
		Get
			Return _projectName
		End Get
		Set(ByVal value As String)
			_projectName = value
		End Set
	End Property


	Private _consignerName As String = ""
	Public Property ConsignerName() As String
		Get
			Return _consignerName
		End Get
		Set(ByVal value As String)
			_consignerName = value
		End Set
	End Property

	Private _consigneeName As String = ""
	Public Property ConsigneeName() As String
		Get
			Return _consigneeName
		End Get
		Set(ByVal value As String)
			_consigneeName = value
		End Set
	End Property


	Private _consigneeGSTINNo As String = ""
	Public Property ConsigneeGSTINNo() As String
		Get
			Return _consigneeGSTINNo
		End Get
		Set(ByVal value As String)
			_consigneeGSTINNo = value
		End Set
	End Property
	Private _consigneeGSTIN As String = ""
	Public Property ConsigneeGSTIN() As String
		Get
			Return _consigneeGSTIN
		End Get
		Set(ByVal value As String)
			_consigneeGSTIN = value
		End Set
	End Property


	Private _consigneeAddress1Line As String = ""
	Public Property ConsigneeAddress1Line() As String
		Get
			Return _consigneeAddress1Line
		End Get
		Set(ByVal value As String)
			_consigneeAddress1Line = value
		End Set
	End Property

	Private _consigneeAddress2Line As String = ""
	Public Property ConsigneeAddress2Line() As String
		Get
			Return _consigneeAddress2Line
		End Get
		Set(ByVal value As String)
			_consigneeAddress2Line = value
		End Set
	End Property


	Private _consigneeAddress3Line As String = ""
	Public Property ConsigneeAddress3Line() As String
		Get
			Return _consigneeAddress3Line
		End Get
		Set(ByVal value As String)
			_consigneeAddress3Line = value
		End Set
	End Property


	Private _consigneeStateID As String = ""
	Public Property ConsigneeStateID() As String
		Get
			Return _consigneeStateID
		End Get
		Set(ByVal value As String)
			_consigneeStateID = value
		End Set
	End Property


	Private _purpose As String = ""
	Public Property Purpose() As String
		Get
			Return _purpose
		End Get
		Set(ByVal value As String)
			_purpose = value
		End Set
	End Property

	Private _assessableValue As String = ""
	Public Property AssessableValue() As String
		Get
			Return _assessableValue
		End Get
		Set(ByVal value As String)
			_assessableValue = value
		End Set
	End Property


	Private _iGSTAmount As String = ""
	Public Property IGSTAmount() As String
		Get
			Return _iGSTAmount
		End Get
		Set(ByVal value As String)
			_iGSTAmount = value
		End Set
	End Property
	Private _sGSTAmount As String = ""
	Public Property SGSTAmount() As String
		Get
			Return _sGSTAmount
		End Get
		Set(ByVal value As String)
			_sGSTAmount = value
		End Set
	End Property


	Private _cGSTAmount As String = ""
	Public Property CGSTAmount() As String
		Get
			Return _cGSTAmount
		End Get
		Set(ByVal value As String)
			_cGSTAmount = value
		End Set
	End Property

	Private _totalGST As String = ""
	Public Property TotalGST() As String
		Get
			Return _totalGST
		End Get
		Set(ByVal value As String)
			_totalGST = value
		End Set
	End Property


	Private _totalAmount As String = ""
	Public Property TotalAmount() As String
		Get
			Return _totalAmount
		End Get
		Set(ByVal value As String)
			_totalAmount = value
		End Set
	End Property


	Private _totalAmountonHeader As String = ""
	Public Property TotalAmountonHeader() As String
		Get
			Return _totalAmountonHeader
		End Get
		Set(ByVal value As String)
			_totalAmountonHeader = value
		End Set
	End Property


	Private _statusID As String = ""
	Public Property StatusID() As String
		Get
			Return _statusID
		End Get
		Set(ByVal value As String)
			_statusID = value
		End Set
	End Property

	Private _isgecInvoiceNo As String = ""
	Public Property IsgecInvoiceNo() As String
		Get
			Return _isgecInvoiceNo
		End Get
		Set(ByVal value As String)
			_isgecInvoiceNo = value
		End Set
	End Property


	Private _isgecInvoiceDate As String = ""
	Public Property IsgecInvoiceDate() As String
		Get
			Return _isgecInvoiceDate
		End Get
		Set(ByVal value As String)
			_isgecInvoiceDate = value
		End Set
	End Property
	Private _statedescription As String = ""
	Public Property StateDescription() As String
		Get
			Return _statedescription
		End Get
		Set(ByVal value As String)
			_statedescription = value
		End Set
	End Property
	Private _statusdescription As String = ""
	Public Property StatusDescription() As String
		Get
			Return _statusdescription
		End Get
		Set(ByVal value As String)
			_statusdescription = value
		End Set
	End Property
	Private _serialNo As String = ""
	Public Property SerialNo() As String
		Get
			Return _serialNo
		End Get
		Set(ByVal value As String)
			_serialNo = value
		End Set
	End Property
	Private _itemDescription As String = ""
	Public Property ItemDescription() As String
		Get
			Return _itemDescription
		End Get
		Set(ByVal value As String)
			_itemDescription = value
		End Set
	End Property



	Public Sub New(ByVal Reader As SqlDataReader)
		Try
			For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
				If pi.MemberType = Reflection.MemberTypes.Property Then
					Try
						Dim Found As Boolean = False
						For I As Integer = 0 To Reader.FieldCount - 1
							If Reader.GetName(I).ToLower = pi.Name.ToLower Then
								Found = True
								Exit For
							End If
						Next
						If Found Then
							If Convert.IsDBNull(Reader(pi.Name)) Then
								Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
									Case "decimal"
										CallByName(Me, pi.Name, CallType.Let, "0.00")
									Case "bit"
										CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
									Case Else
										CallByName(Me, pi.Name, CallType.Let, String.Empty)
								End Select
							Else
								CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
							End If
						End If
					Catch ex As Exception
					End Try
				End If
			Next
		Catch ex As Exception
		End Try
	End Sub
	Public Sub New()
	End Sub
	Public Shared Function GetData(ByVal FromDate As String, ByVal ToDate As String) As List(Of DCReportClass)
		Dim Sql As String = ""
		Sql &= "  SELECT "
		Sql &= "   * "
		Sql &= "   FROM SPMT_DC_Report"
		Sql &= "  WHERE"
		Sql &= "  ([ChallanDate] >= convert(datetime,'" & FromDate & "', 103)  AND [ChallanDate] <= convert(datetime,'" & ToDate & "', 103))"
		Sql &= "  ORDER BY [ChallanDate]"

		Return GetDCReportClass(Sql)
	End Function
	Private Shared Function GetDCReportClass(ByVal Sql As String) As List(Of DCReportClass)
		Dim Results As List(Of DCReportClass) = Nothing
		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				Cmd.CommandText = Sql
				Cmd.CommandTimeout = 1200
				Results = New List(Of DCReportClass)
				Con.Open()
				Dim Reader As SqlDataReader = Cmd.ExecuteReader()
				While (Reader.Read())
					Results.Add(New DCReportClass(Reader))
				End While
				Reader.Close()
			End Using
		End Using
		Return Results

	End Function

End Class
