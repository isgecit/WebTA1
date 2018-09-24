Imports OfficeOpenXml
Partial Class ErectionDocumentList
	Inherits System.Web.UI.Page
	Private Function GetDiskFileName(ByVal mStr As String) As String
		mStr = mStr.Replace("/", "_")
		mStr = mStr.Replace("\", "_")
		mStr = mStr.Replace(":", "_")
		mStr = mStr.Replace("*", "_")
		mStr = mStr.Replace("?", "_")
		mStr = mStr.Replace("""", "_")
		mStr = mStr.Replace(">", "_")
		mStr = mStr.Replace("<", "_")
		mStr = mStr.Replace("|", "_")
		mStr = mStr.Trim
		Return mStr
	End Function
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Dim ProjectID As String = ""
		Dim Days As String = ""
		Try
			ProjectID = Request.QueryString("id")
			Days = Request.QueryString("dy")
		Catch ex As Exception
			ProjectID = ""
			Days = ""
		End Try
		If ProjectID = String.Empty Then Return
		If Days = String.Empty Then Days = "30"
		Dim IntDays As Integer = 0
		Try
			IntDays = Convert.ToInt32(Days)
		Catch ex As Exception
			IntDays = 30
		End Try
		Dim FilePath As String = CreateFile(ProjectID.ToUpper, IntDays)
		Response.ClearContent()
    Response.AppendHeader("content-disposition", "attachment; filename=" & ProjectID & ".xlsx")
    Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(IO.Path.GetFileName(FilePath))
		Response.WriteFile(FilePath)
		Response.End()
	End Sub
	Private Function CreateFile(ByVal ProjectID As String, ByVal Days As Integer) As String
		Dim FileName As String = Server.MapPath("~/..") & "App_Temp\" & Guid.NewGuid().ToString()
		IO.File.Copy(Server.MapPath("~/App_Templates") & "\ErectionDocumentTemplate.xlsx", FileName)
		Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
		Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)
		Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("Released Document List")

		Dim mPage As Integer = 0
		Dim mSize As Integer = 50
		Dim oDocs As List(Of SIS.LG.lgDMisg) = SIS.LG.lgDMisg.GetErectionDrawingListFromBaaN(mPage, mSize, "", False, "", ProjectID)

		Dim r As Integer = 3
		Dim c As Integer = 1
		Dim tc As Integer = 10
		With xlWS
			Do While oDocs.Count > 0
				For Each doc As SIS.LG.lgDMisg In oDocs
					If r > 3 Then xlWS.InsertRow(r, 1, r + 1)
					c = 1
					.Cells(r, c).Value = doc.t_cprj.Trim
					c += 1
					.Cells(r, c).Value = doc.t_cspa.Trim
					c += 1
					.Cells(r, c).Value = doc.t_docn.Trim
					c += 1
					.Cells(r, c).Value = doc.t_revn.Trim
					c += 1
					Try
						.Cells(r, c).Value = doc.t_dttl.Trim
					Catch ex As Exception
						.Cells(r, c).Value = "Invalid Char in Title"
					End Try
					c += 1
					.Cells(r, c).Value = doc.Stat.Trim
					c += 1
					.Cells(r, c).Value = doc.t_drdt.Trim
					c += 1
					.Cells(r, c).Value = IIf(doc.t_erec = "1", "YES", "NO")
					c += 1
					.Cells(r, c).Value = IIf(doc.t_prod = "1", "YES", "NO")
					c += 1
					.Cells(r, c).Value = IIf(doc.t_appr = "1", "YES", "NO")
					r += 1
				Next
				mPage = mPage + mSize
				oDocs = SIS.LG.lgDMisg.GetErectionDrawingListFromBaaN(mPage, mSize, "", False, "", ProjectID)
			Loop
		End With
		'2. Sheet For Summary Report
		xlWS = xlPk.Workbook.Worksheets("Released or Modified Document")
		oDocs = SIS.LG.lgDMisg.GetErectionDrawingListFromBaaN_New(Days, ProjectID)

		r = 5
		With xlWS
			.Cells(2, 3).Value = Now.ToString("dd/MM/yyyy")
			.Cells(3, 3).Value = Days
			For Each doc As SIS.LG.lgDMisg In oDocs
				If r > 5 Then xlWS.InsertRow(r, 1, r + 1)
				c = 1
				.Cells(r, c).Value = doc.t_cprj.Trim
				c += 1
				.Cells(r, c).Value = doc.t_cspa.Trim
				c += 1
				.Cells(r, c).Value = doc.t_docn.Trim
				c += 1
				.Cells(r, c).Value = doc.t_revn.Trim
				c += 1
				Try
					.Cells(r, c).Value = doc.t_dttl.Trim
				Catch ex As Exception
					.Cells(r, c).Value = "Invalid Char in Title"
				End Try
				c += 1
				.Cells(r, c).Value = doc.WFStat.Trim
				.Cells(r, c).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
				If doc.t_wfst = 7 Then
					.Cells(r, c).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightPink)
					.Cells(r, c).Style.Font.Color.SetColor(System.Drawing.Color.Red)
				Else
					.Cells(r, c).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen)
					.Cells(r, c).Style.Font.Color.SetColor(System.Drawing.Color.DarkGreen)
				End If
				c += 1
				.Cells(r, c).Value = doc.t_drdt.Trim
				c += 1
				.Cells(r, c).Value = IIf(doc.t_erec = "1", "YES", "NO")
				c += 1
				.Cells(r, c).Value = IIf(doc.t_prod = "1", "YES", "NO")
				c += 1
				.Cells(r, c).Value = IIf(doc.t_appr = "1", "YES", "NO")
				r += 1
			Next
		End With
		Try
			xlPk.Save()
			xlPk.Dispose()
		Catch ex As Exception
			xlPk.Dispose()
		End Try
		Return FileName
	End Function
End Class
