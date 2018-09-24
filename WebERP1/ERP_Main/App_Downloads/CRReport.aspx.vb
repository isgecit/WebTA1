Imports System.Data
Imports System.Data.SqlClient
Imports OfficeOpenXml
Partial Class CRReport
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
		Dim DWFile As String = "Change Requests " & FromDate & "_" & ToDate
		Dim FilePath As String = CreateFile(FromDate, ToDate)
		HttpContext.Current.Server.ScriptTimeout = mLastScriptTimeout
		Response.ClearContent()
		Response.AppendHeader("content-disposition", "attachment; filename=" & DWFile & ".xlsx" & """")
		Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(IO.Path.GetFileName(FilePath))
		Response.WriteFile(FilePath)
		Response.End()
	End Sub
	Private Function CreateFile(ByVal FromDate As String, ByVal ToDate As String) As String
		Dim FileName As String = Server.MapPath("~/..") & "App_Temp\" & Guid.NewGuid().ToString()
		IO.File.Copy(Server.MapPath("~/App_Templates") & "\ERPCRTemplate.xlsx", FileName)
		Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
		Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)

		Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("Data")
		Dim oDocs As List(Of SIS.ERP.erpChaneRequest) = ReportClass.GetAllReleasedDocuments(FromDate, ToDate)
		Dim r As Integer = 5
		Dim c As Integer = 1
		With xlWS
			For Each doc As SIS.ERP.erpChaneRequest In oDocs
				If r > 5 Then
					xlWS.InsertRow(r, 1, r + 1)
				End If
				.Cells(r, 2).Value = doc.RequestID
				.Cells(r, 3).Value = doc.ERP_RequestTypes6_Description
				If doc.StatusID = 12 Then
					.Cells(r, 3).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
					.Cells(r, 3).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen)
					.Cells(r, 3).Style.Font.Color.SetColor(System.Drawing.Color.DarkGreen)
				ElseIf doc.PlannedDeliveryDate <> String.Empty Then
					.Cells(r, 3).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
					.Cells(r, 3).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Gold)
					.Cells(r, 3).Style.Font.Color.SetColor(System.Drawing.Color.Black)
				End If
				.Cells(r, 4).Value = removeChars(doc.ChangeSubject)
				.Cells(r, 5).Value = RemoveChars(doc.ChangeDetails)
				Try
					.Cells(r, 6).Value = Convert.ToDateTime(doc.RequestedOn).ToString("dd/MM/yyyy")
				Catch ex As Exception
					.Cells(r, 6).Value = ""
				End Try
				.Cells(r, 7).Value = doc.FK_ERP_ChaneRequest_RequestedBy.UserFullName
				Try
					.Cells(r, 8).Value = Convert.ToDateTime(doc.ApprovedOn).ToString("dd/MM/yyyy")
				Catch ex As Exception
					.Cells(r, 8).Value = ""
				End Try
				Try
					.Cells(r, 9).Value = doc.FK_ERP_ChaneRequest_ApprovedBy.UserFullName
				Catch ex As Exception
					.Cells(r, 9).Value = ""
				End Try
				.Cells(r, 10).Value = RemoveChars(doc.EvaluationByIT)
				Try
					.Cells(r, 11).Value = Convert.ToDateTime(doc.EvaluationByESCOn).ToString("dd/MM/yyyy")
				Catch ex As Exception
					.Cells(r, 11).Value = ""
				End Try
				Select Case doc.StatusID
					Case 7, 8, 9
						.Cells(r, 12).Value = doc.ERP_RequestStatus5_Description
						.Cells(r, 13).Value = ""
					Case Else
						.Cells(r, 12).Value = ""
						.Cells(r, 13).Value = doc.ERP_RequestStatus5_Description
				End Select
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
Public Class ReportClass
	Public Shared Function GetAllReleasedDocuments(ByVal FromDate As String, ByVal ToDate As String) As List(Of SIS.ERP.erpChaneRequest)
		Dim Sql As String = ""
		Sql &= "  SELECT"
		Sql &= "		[ERP_ChaneRequest].[ApplID] ,"
		Sql &= "		[ERP_ChaneRequest].[RequestID] ,"
		Sql &= "		[ERP_ChaneRequest].[RequestedBy] ,"
		Sql &= "		[ERP_ChaneRequest].[RequestedOn] ,"
		Sql &= "		[ERP_ChaneRequest].[RequestTypeID] ,"
		Sql &= "		[ERP_ChaneRequest].[ChangeSubject] ,"
		Sql &= "		[ERP_ChaneRequest].[ChangeDetails] ,"
		Sql &= "		[ERP_ChaneRequest].[ReturnRemarks] ,"
		Sql &= "		[ERP_ChaneRequest].[ApprovedBy] ,"
		Sql &= "		[ERP_ChaneRequest].[ApprovedOn] ,"
		Sql &= "		[ERP_ChaneRequest].[EvaluationByIT] ,"
		Sql &= "		[ERP_ChaneRequest].[EvaluationByITOn] ,"
		Sql &= "		[ERP_ChaneRequest].[EvaluationByESC] ,"
		Sql &= "		[ERP_ChaneRequest].[EvaluationByESCOn] ,"
		Sql &= "		[ERP_ChaneRequest].[Justification] ,"
		Sql &= "		[ERP_ChaneRequest].[StatusID] ,"
		Sql &= "		[ERP_ChaneRequest].[PriorityID] ,"
		Sql &= "		[ERP_ChaneRequest].[MSLPortalNumber] ,"
		Sql &= "		[ERP_ChaneRequest].[MSLPortalOn] ,"
		Sql &= "		[ERP_ChaneRequest].[EffortEstimation] ,"
		Sql &= "		[ERP_ChaneRequest].[PlannedDeliveryDate] ,"
		Sql &= "		[ERP_ChaneRequest].[ActualDeliveryDate] ,"
		Sql &= "		[ERP_ChaneRequest].[ClosingRemarks] ,"
		Sql &= "		[aspnet_Users1].[UserFullName] AS aspnet_Users1_UserFullName,"
		Sql &= "		[aspnet_Users2].[UserFullName] AS aspnet_Users2_UserFullName,"
		Sql &= "		[ERP_Applications3].[ApplName] AS ERP_Applications3_ApplName,"
		Sql &= "		[ERP_RequestPriority4].[Description] AS ERP_RequestPriority4_Description,"
		Sql &= "		[ERP_RequestStatus5].[Description] AS ERP_RequestStatus5_Description,"
		Sql &= "		[ERP_RequestTypes6].[Description] AS ERP_RequestTypes6_Description "
		Sql &= "  FROM [ERP_ChaneRequest] "
		Sql &= "  INNER JOIN [aspnet_Users] AS [aspnet_Users1]"
		Sql &= "    ON [ERP_ChaneRequest].[RequestedBy] = [aspnet_Users1].[LoginID]"
		Sql &= "  LEFT OUTER JOIN [aspnet_Users] AS [aspnet_Users2]"
		Sql &= "    ON [ERP_ChaneRequest].[ApprovedBy] = [aspnet_Users2].[LoginID]"
		Sql &= "  INNER JOIN [ERP_Applications] AS [ERP_Applications3]"
		Sql &= "    ON [ERP_ChaneRequest].[ApplID] = [ERP_Applications3].[ApplID]"
		Sql &= "  LEFT OUTER JOIN [ERP_RequestPriority] AS [ERP_RequestPriority4]"
		Sql &= "    ON [ERP_ChaneRequest].[PriorityID] = [ERP_RequestPriority4].[PriorityID]"
		Sql &= "  INNER JOIN [ERP_RequestStatus] AS [ERP_RequestStatus5]"
		Sql &= "    ON [ERP_ChaneRequest].[StatusID] = [ERP_RequestStatus5].[StatusID]"
		Sql &= "  INNER JOIN [ERP_RequestTypes] AS [ERP_RequestTypes6]"
		Sql &= "    ON [ERP_ChaneRequest].[RequestTypeID] = [ERP_RequestTypes6].[RequestTypeID]"
		Sql &= "  WHERE"
		Sql &= "  [ERP_ChaneRequest].[ApplID] = 1"
		Sql &= "  AND ([ERP_ChaneRequest].[RequestID] >= " & FromDate & "AND [ERP_ChaneRequest].[RequestID] <= " & ToDate & ")"
		Sql &= "  ORDER BY [ERP_ChaneRequest].[RequestID]"

		Return GetReportClass(Sql)
	End Function
	Private Shared Function GetReportClass(ByVal Sql As String) As List(Of SIS.ERP.erpChaneRequest)
		Dim Results As List(Of SIS.ERP.erpChaneRequest) = Nothing
		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				Cmd.CommandText = Sql
				Cmd.CommandTimeout = 1200
				Results = New List(Of SIS.ERP.erpChaneRequest)
				Con.Open()
				Dim Reader As SqlDataReader = Cmd.ExecuteReader()
				While (Reader.Read())
					Results.Add(New SIS.ERP.erpChaneRequest(Reader))
				End While
				Reader.Close()
			End Using
		End Using
		Return Results

	End Function
	Sub New()
		'dummy
	End Sub
End Class
