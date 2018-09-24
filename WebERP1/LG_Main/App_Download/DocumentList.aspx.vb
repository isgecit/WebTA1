Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports OfficeOpenXml
Partial Class DocumentList
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Dim FPrj As String = ""
		Dim TPrj As String = ""
		Dim FDt As String = ""
		Dim TDt As String = ""
		Dim pFix As String = ""
		Try
			FPrj = Request.QueryString("fprj")
			TPrj = Request.QueryString("tprj")
			FDt = Request.QueryString("fdt")
			TDt = Request.QueryString("tdt")
			pFix = Request.QueryString("pfix")
		Catch ex As Exception
			FPrj = ""
			FDt = ""
			TPrj = ""
			TDt = ""
			pFix = ""
		End Try
		'If FPrj = String.Empty Then Return
		'If FDt = String.Empty Then Return
		Dim FilePath As String = CreateFile(FPrj, TPrj, FDt, TDt, pFix)
		Response.ClearContent()
    Response.AppendHeader("content-disposition", "attachment; filename=" & FPrj & "_" & TPrj & "_" & FDt & "_" & TDt & ".xlsx")
    Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(IO.Path.GetFileName(FilePath))
		Response.WriteFile(FilePath)
		Response.End()
	End Sub
	Private Function CreateFile(ByVal FPrj As String, ByVal TPrj As String, ByVal FDt As String, ByVal TDt As String, ByVal pFix As String) As String
		Dim FileName As String = Server.MapPath("~/..") & "App_Temp\" & Guid.NewGuid().ToString()
		IO.File.Copy(Server.MapPath("~/App_Templates") & "\DocumentTemplate.xlsx", FileName)
		Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
		Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)
		Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("Documents Changed")

		Dim oDocs As List(Of SIS.LG.lgDMisg) = GetDrawingListFromBaaN(FPrj, TPrj, FDt, TDt, pFix)

		Dim r As Integer = 5
		Dim c As Integer = 1
		r = 5
		With xlWS
			.Cells(2, 3).Value = FDt
			.Cells(3, 3).Value = TDt
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
					.Cells(r, c).Value = "Invalid Character in Title"
				End Try
				c += 1
				.Cells(r, c).Value = doc.DocStatus.Trim
				.Cells(r, c).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
				Select Case doc.t_wfst
					Case 1, 2, 3, 4
						.Cells(r, c).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Aqua)
						.Cells(r, c).Style.Font.Color.SetColor(System.Drawing.Color.RoyalBlue)
					Case 5
						.Cells(r, c).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen)
						.Cells(r, c).Style.Font.Color.SetColor(System.Drawing.Color.DarkGreen)
					Case 6
						.Cells(r, c).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LemonChiffon)
						.Cells(r, c).Style.Font.Color.SetColor(System.Drawing.Color.RosyBrown)
					Case 7, 8, 9
						.Cells(r, c).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightPink)
						.Cells(r, c).Style.Font.Color.SetColor(System.Drawing.Color.Red)
				End Select
				c += 1
				If doc.t_wfst = 5 Then
					.Cells(r, c).Value = doc.t_drdt.Trim
				Else
					.Cells(r, c).Value = doc.t_adat.Trim
				End If
				c += 1
				.Cells(r, c).Value = IIf(doc.t_erec = "1", "YES", "NO")
				c += 1
				.Cells(r, c).Value = IIf(doc.t_prod = "1", "YES", "NO")
				c += 1
				.Cells(r, c).Value = IIf(doc.t_appr = "1", "YES", "NO")
				r += 1
			Next
		End With
		xlWS = xlPk.Workbook.Worksheets("Revised Documents")
		r = 5
		With xlWS
			.Cells(2, 3).Value = FDt
			.Cells(3, 3).Value = TDt
			For Each doc As SIS.LG.lgDMisg In oDocs
				If doc.t_revn.Trim = "00" Then Continue For
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
					.Cells(r, c).Value = "Invalid Character in Title"
				End Try
				c += 1
				.Cells(r, c).Value = doc.DocStatus.Trim
				.Cells(r, c).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
				Select Case doc.t_wfst
					Case 1, 2, 3, 4
						.Cells(r, c).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Aqua)
						.Cells(r, c).Style.Font.Color.SetColor(System.Drawing.Color.RoyalBlue)
					Case 5
						.Cells(r, c).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen)
						.Cells(r, c).Style.Font.Color.SetColor(System.Drawing.Color.DarkGreen)
					Case 6
						.Cells(r, c).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LemonChiffon)
						.Cells(r, c).Style.Font.Color.SetColor(System.Drawing.Color.RosyBrown)
					Case 7, 8, 9
						.Cells(r, c).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightPink)
						.Cells(r, c).Style.Font.Color.SetColor(System.Drawing.Color.Red)
				End Select
				c += 1
				If doc.t_wfst = 5 Then
					.Cells(r, c).Value = doc.t_drdt.Trim
				Else
					.Cells(r, c).Value = doc.t_adat.Trim
				End If
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
	Public Shared Function GetDrawingListFromBaaN(ByVal FPrj As String, ByVal TPrj As String, ByVal FDt As String, ByVal TDt As String, ByVal pfix As String) As List(Of SIS.LG.lgDMisg)
		Dim Results As List(Of SIS.LG.lgDMisg) = Nothing
		TDt = Convert.ToDateTime(TDt).AddDays(1).ToString("dd/MM/yyyy")
		Dim Sql As String = ""
		Sql = Sql & "		SELECT"
		Sql = Sql & "			docM.t_docn ,"
		Sql = Sql & "			docM.t_revn ,"
		Sql = Sql & "			docM.t_dttl ,"
		Sql = Sql & "			docM.t_cspa ,"
		Sql = Sql & "			docM.t_cprj ,"
		Sql = Sql & "			docM.t_year ,"
		Sql = Sql & "			docM.t_stat ,"
		Sql = Sql & "			docM.t_wfst ,"
		Sql = Sql & "			docM.t_erec ,"
		Sql = Sql & "			docM.t_prod ,"
		Sql = Sql & "			docM.t_appr  "
		Sql = Sql & "		FROM tdmisg001200 as docM "
		Sql = Sql & "		WHERE docM.t_revn = (SELECT MAX(tmp.t_revn) FROM tdmisg001200 as tmp WHERE tmp.t_docn= docM.t_docn) "
		If FPrj <> String.Empty And TPrj <> String.Empty Then
			Sql = Sql & "			AND (docM.t_cprj >= '" & FPrj & "' AND docM.t_cprj <= '" & TPrj & "')"
		ElseIf pfix <> String.Empty Then
			Dim aFix() As String = pfix.Split(",".ToCharArray)
			pfix = ""
			For Each tmp As String In aFix
				If pfix = "" Then
					pfix &= "'" & tmp & "'"
				Else
					pfix &= ",'" & tmp & "'"
				End If
			Next
			Sql = Sql & "			AND (substring(docM.t_cprj,1,2) in (" & pfix & "))"
		End If
		Sql = Sql & "			AND ( (docM.t_rdat >= convert(datetime,'" & FDt & "', 103) and docM.t_rdat <= convert(datetime,'" & TDt & "', 103)) OR (docM.t_adat >= convert(datetime,'" & FDt & "', 103) and docM.t_adat <= convert(datetime,'" & TDt & "', 103)) )"
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = Sql
        Results = New List(Of SIS.LG.lgDMisg)
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        While (Reader.Read())
          Results.Add(New SIS.LG.lgDMisg(Reader))
        End While
        Reader.Close()
      End Using
    End Using
    Return Results
	End Function

End Class
