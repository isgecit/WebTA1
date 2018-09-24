Imports System.Data
Imports System.Data.SqlClient
Imports OfficeOpenXml
Partial Class DCRReport
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
		Dim DWFile As String = Division & "_" & Convert.ToDateTime(FromDate).Month.ToString & "_" & Convert.ToDateTime(FromDate).Year.ToString
		Dim FilePath As String = CreateFile(FromDate, ToDate, Division)
		HttpContext.Current.Server.ScriptTimeout = mLastScriptTimeout
		Response.ClearContent()
    Response.AppendHeader("content-disposition", "attachment; filename=" & DWFile & ".xlsx")
    Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(IO.Path.GetFileName(FilePath))
		Response.WriteFile(FilePath)
		Response.End()
	End Sub
	Private Function CreateFile(ByVal FromDate As String, ByVal ToDate As String, ByVal Division As String) As String
		Dim FileName As String = Server.MapPath("~/..") & "App_Temp\" & Guid.NewGuid().ToString()
		IO.File.Copy(Server.MapPath("~/App_Templates") & "\DCRReportTemplate.xlsx", FileName)
		Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
		Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)

		Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("Documents Data")
		Dim oDocs As List(Of ReportClass) = ReportClass.GetAllReleasedDocuments(FromDate, ToDate, Division)
		Dim r As Integer = 4
		Dim c As Integer = 1
		With xlWS
			.Cells(2, 1).Value = Division
			For Each doc As ReportClass In oDocs
				If r > 4 Then
					xlWS.InsertRow(r, 1, r - 1)
					.Cells(r, 2).FormulaR1C1 = .Cells(r - 1, 2).FormulaR1C1
				End If
				.Cells(r, 1).Value = MonthName(doc.MonthName, True) & "-" & doc.YearName
				.Cells(r, 3).Value = doc.DocumentCount
				'.Cells(r, 4).Value = doc.DocumentCount
				r += 1
			Next
		End With
		oDocs = ReportClass.GetAboveZeroRevReleasedDocuments(FromDate, ToDate, Division)
		r = 4
		With xlWS
			For Each doc As ReportClass In oDocs
				.Cells(r, 4).Value = doc.DocumentCount
				r += 1
			Next
			r = r - 1
			Dim ec As Drawing.Chart.ExcelChart = .Drawings("Chart1")
			ec.Series.Add("B4:B" & r, "A4:A" & r)

		End With

		xlWS = xlPk.Workbook.Worksheets("DCR Data")
		oDocs = ReportClass.GetAllDCR(FromDate, ToDate, Division)
		r = 4
		With xlWS
			For Each doc As ReportClass In oDocs
				If r > 4 Then
					xlWS.InsertRow(r, 1, r - 1)
					.Cells(r, 3).FormulaR1C1 = .Cells(r - 1, 3).FormulaR1C1
					.Cells(r, 4).FormulaR1C1 = .Cells(r - 1, 4).FormulaR1C1
				End If
				.Cells(r, 1).Value = doc.MonthName
				.Cells(r, 2).Value = doc.DocumentCount
				r += 1
			Next
			r = r - 1
			Dim ec As Drawing.Chart.ExcelChart = .Drawings("Chart2")
			ec.Series.Delete(0)
			ec.Series.Add("B4:B" & r, "A4:A" & r)

		End With
		xlWS = xlPk.Workbook.Worksheets("DocumentsInLastMonthDCR")
		oDocs = ReportClass.GetAboveZeroRevReleasedInLastMonthDocumentList(FromDate, ToDate, Division)
		r = 6
		With xlWS
			For Each doc As ReportClass In oDocs
				If r > 6 Then
					xlWS.InsertRow(r, 1, r - 1)
				End If
				.Cells(r, 1).Value = doc.ProjectID
				.Cells(r, 2).Value = doc.DocumentID
				.Cells(r, 3).Value = doc.RevisionNo
				.Cells(r, 4).Value = doc.ReleaseDate
        .Cells(r, 5).Value = doc.DCRDesc
        .Cells(r, 6).Value = doc.Discipline
        r += 1
      Next

    End With
    'DocumentsReleased
    xlWS = xlPk.Workbook.Worksheets("DocumentsReleased")
    oDocs = ReportClass.GetAllReleasedDocumentsListInLastMonth(FromDate, ToDate, Division)
    r = 6
    With xlWS
      For Each doc As ReportClass In oDocs
        If r > 6 Then
          xlWS.InsertRow(r, 1, r - 1)
        End If
        .Cells(r, 1).Value = doc.ProjectID
        .Cells(r, 2).Value = doc.DocumentID
        .Cells(r, 3).Value = doc.RevisionNo
        .Cells(r, 4).Value = doc.ReleaseDate
        .Cells(r, 5).Value = doc.Discipline
        '.Cells(r, 5).Value = doc.DCRDesc
        r += 1
      Next

    End With

    xlPk.Save()
    xlPk.Dispose()
    Return FileName
  End Function
End Class
Public Class ReportClass
  Public ProjectID As String = ""
  Public DocumentID As String = ""
  Public RevisionNo As String = ""
  Public ReleaseDate As String = ""
  Public MonthName As String = ""
  Public YearName As String = ""
  Public DocumentCount As Integer = 0
  Public DCRCate As String = ""
  Public DCRDesc As String = ""
  Public Discipline As String = ""
  'Public Sub New(ByVal Reader As SqlDataReader)
  '  Try
  '    For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
  '      If pi.MemberType = Reflection.MemberTypes.Property Then
  '        Try
  '          Dim Found As Boolean = False
  '          For I As Integer = 0 To Reader.FieldCount - 1
  '            If Reader.GetName(I).ToLower = pi.Name.ToLower Then
  '              Found = True
  '              Exit For
  '            End If
  '          Next
  '          If Found Then
  '            If Convert.IsDBNull(Reader(pi.Name)) Then
  '              Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
  '                Case "decimal"
  '                  CallByName(Me, pi.Name, CallType.Let, "0.00")
  '                Case "bit"
  '                  CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
  '                Case Else
  '                  CallByName(Me, pi.Name, CallType.Let, String.Empty)
  '              End Select
  '            Else
  '              CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
  '            End If
  '          End If
  '        Catch ex As Exception
  '        End Try
  '      End If
  '    Next
  '  Catch ex As Exception
  '  End Try
  'End Sub

  Sub New(ByVal Rd As SqlDataReader)
    On Error Resume Next
    ProjectID = Rd("ProjectID")
    DocumentID = Rd("DocumentID")
    ReleaseDate = Rd("ReleaseDate")
    RevisionNo = Rd("RevisionNo")
    MonthName = Rd("MonthName")
    YearName = Rd("YearName")
    DocumentCount = Rd("DocumentCount")
    DCRCate = Rd("DCRCate")
    DCRDesc = Rd("DCRDesc")
    Discipline = Rd("Discipline")
  End Sub
  Public Shared Function GetAllDCR(ByVal FromDate As String, ByVal ToDate As String, ByVal Division As String) As List(Of ReportClass)
    'Convert From & TO Date yyyy-mm-dd
    'Below line is commented because it was giving Jan DCR insted of Dec
    'ToDate = Convert.ToDateTime(ToDate).AddDays(1)
    FromDate = FromDate.Substring(6, 4) & "-" & FromDate.Substring(3, 2) & "-" & FromDate.Substring(0, 2)
    ToDate = ToDate.Substring(6, 4) & "-" & ToDate.Substring(3, 2) & "-" & ToDate.Substring(0, 2)
    Dim VaultDB As String = "BOILER"
    Select Case Division
      Case "SMD"
        VaultDB = "SMD"
      Case "EPC"
        VaultDB = "EPC"
      Case "APC"
        VaultDB = "PC"
      Case "BOILER"
        VaultDB = "BOILER"
    End Select
    Dim Sql As String = ""
    Sql &= "select "
    Sql &= "count(dl.t_catg) as DocumentCount,"
    Sql &= "cm.t_dsca as MonthName "
    Sql &= "from tdmisg115200 as dl "
    Sql &= "inner join tdmisg114200 as dh on dl.t_dcrn = dh.t_dcrn "
    Sql &= "left outer join tdmisg111200 as cm on dl.t_catg = cm.t_code "
    Sql &= "inner join tdmisg001200 as dm on (dl.t_docd = dm.t_docn and dl.t_revn = dm.t_revn) "
    Sql &= "where month(dh.t_apdt)=" & ToDate.Substring(5, 2) & " and year(dh.t_apdt)= " & ToDate.Substring(0, 4)
    Sql &= "  and substring(dl.t_docd,17,3) not in ('VEN','SPC','POS','CCL','GPD','VSH','DOC','TDS','MIS','DCL','FNT','MTO') "
    Sql &= "	and upper(dm.t_name) = '" & VaultDB & "' "
    Sql &= "  and dm.t_type = 'DWG' "
    Sql &= "group by cm.t_dsca"

    Return GetReportClass(Sql)
  End Function
  Public Shared Function GetAboveZeroRevReleasedInLastMonthDocumentList(ByVal FromDate As String, ByVal ToDate As String, ByVal Division As String) As List(Of ReportClass)
    'Convert From & TO Date yyyy-mm-dd
    'ToDate = Convert.ToDateTime(ToDate).AddDays(1)
    'FromDate = FromDate.Substring(6, 4) & "-" & FromDate.Substring(3, 2) & "-" & FromDate.Substring(0, 2)
    'ToDate = ToDate.Substring(6, 4) & "-" & ToDate.Substring(3, 2) & "-" & ToDate.Substring(0, 2)
    Dim VaultDB As String = "BOILER"
    Select Case Division
      Case "SMD"
        VaultDB = "SMD"
      Case "EPC"
        VaultDB = "EPC"
      Case "APC"
        VaultDB = "PC"
      Case "BOILER"
        VaultDB = "BOILER"
    End Select
    Dim Sql As String = ""
    Sql &= "select "
    Sql &= "dm.t_cprj as ProjectID,"
    Sql &= "dm.t_docn as DocumentID,"
    Sql &= "dm.t_revn as RevisionNo,"
    Sql &= "dm.t_adat as ReleaseDate, "
    Sql &= "dl.t_catg as DCRCate, "
    Sql &= "cm.t_dsca as DCRDesc,"
    Sql &= "(select top 1 ltrim(t_resp) from tdmisg121200 where t_docn=dm.t_docn And t_revn=dm.t_revn) as Discipline "
    Sql &= "from tdmisg001200 as dm "
    Sql &= "left outer join tdmisg115200 as dl on (dm.t_docn=dl.t_docd and  right('00'+ltrim(str(convert(int,dm.t_revn)-1)),2)=dl.t_revn) "
    Sql &= "left outer join tdmisg111200 as cm on dl.t_catg = cm.t_code "
    Sql &= "where ((Month(dm.t_adat) = Month(convert(datetime,'" & ToDate & "',103))) AND (Year(dm.t_adat) = Year(convert(datetime,'" & ToDate & "',103)))) "
    Sql &= "  and substring(dm.t_docn,17,3) not in ('VEN','SPC','POS','CCL','GPD','VSH','DOC','TDS','MIS','DCL','FNT','MTO') "
    Sql &= "  and (dm.t_wfst = 5) "
    'Sql &= "  and dm.t_docn+dm.t_revn in (select isu.t_docn+isu.t_revi from tdmisg011200 as isu where month(isu.t_isdt) = month(dm.t_adat) and year(isu.t_isdt) = year(dm.t_adat)) "
    Sql &= "  and dm.t_revn > '00' "
    Sql &= "	and upper(dm.t_name) = '" & VaultDB & "' "
    Sql &= "  and dm.t_type = 'DWG' "
    Sql &= "order by dm.t_cprj, dm.t_docn,dm.t_revn "

    Return GetReportClass(Sql)
  End Function
  Public Shared Function GetAboveZeroRevReleasedDocuments(ByVal FromDate As String, ByVal ToDate As String, ByVal Division As String) As List(Of ReportClass)
    'Convert From & TO Date yyyy-mm-dd
    ToDate = Convert.ToDateTime(ToDate).AddDays(1)
    FromDate = FromDate.Substring(6, 4) & "-" & FromDate.Substring(3, 2) & "-" & FromDate.Substring(0, 2)
    ToDate = ToDate.Substring(6, 4) & "-" & ToDate.Substring(3, 2) & "-" & ToDate.Substring(0, 2)
    Dim VaultDB As String = "BOILER"
    Select Case Division
      Case "SMD"
        VaultDB = "SMD"
      Case "EPC"
        VaultDB = "EPC"
      Case "APC"
        VaultDB = "PC"
      Case "BOILER"
        VaultDB = "BOILER"
    End Select
    Dim Sql As String = ""
    Sql &= "    select sum(pp.DocumentCount) As DocumentCount, pp.MonthName, pp.YearName from ("
    Sql &= "		select count(dm.t_cprj) as DocumentCount,"
    Sql &= "		       Month(dm.t_adat) as MonthName,"
    Sql &= "		       Year(dm.t_adat) as YearName,"
    Sql &= "           dm.t_revn as RevisionNo "
    Sql &= "		  from tdmisg001200 as dm"
    Sql &= "		  where ((dm.t_adat >= '" & FromDate & "') AND (dm.t_adat < '" & ToDate & "'))"
    Sql &= "      and substring(dm.t_docn,17,3) not in ('VEN','SPC','POS','CCL','GPD','VSH','DOC','TDS','MIS','DCL','FNT','MTO') "
    Sql &= "        and dm.t_wfst = 5 "
    'Sql &= "        and dm.t_docn+dm.t_revn in (select isu.t_docn+isu.t_revi from tdmisg011200 as isu where month(isu.t_isdt) = month(dm.t_adat) and year(isu.t_isdt) = year(dm.t_adat)) "
    Sql &= "        and dm.t_revn > '00' "
    Sql &= "		    and upper(dm.t_name) = '" & VaultDB & "' "
    Sql &= "        and dm.t_type = 'DWG' "
    Sql &= "      group by dm.t_revn, Month(dm.t_adat),Year(dm.t_adat) "
    Sql &= "      ) as pp"
    Sql &= "      group by pp.MonthName, pp.YearName"
    Sql &= "      order by pp.MonthName, pp.YearName"

    Return GetReportClass(Sql)
  End Function
  Public Shared Function GetAllReleasedDocumentsListInLastMonth(ByVal FromDate As String, ByVal ToDate As String, ByVal Division As String) As List(Of ReportClass)
    'Convert From & TO Date yyyy-mm-dd
    'ToDate = Convert.ToDateTime(ToDate).AddDays(1)
    'FromDate = FromDate.Substring(6, 4) & "-" & FromDate.Substring(3, 2) & "-" & FromDate.Substring(0, 2)
    'ToDate = ToDate.Substring(6, 4) & "-" & ToDate.Substring(3, 2) & "-" & ToDate.Substring(0, 2)
    Dim VaultDB As String = "BOILER"
    Select Case Division
      Case "SMD"
        VaultDB = "SMD"
      Case "EPC"
        VaultDB = "EPC"
      Case "APC"
        VaultDB = "PC"
      Case "BOILER"
        VaultDB = "BOILER"
    End Select
    Dim Sql As String = ""
    Sql &= "  Select dm.t_cprj as ProjectID,"
    Sql &= "  dm.t_docn as DocumentID,"
    Sql &= "  dm.t_revn as RevisionNo,"
    Sql &= "  dm.t_adat as ReleaseDate, "
    Sql &= "		       Month(dm.t_adat) as MonthName,"
    Sql &= "		       Year(dm.t_adat) as YearName,"
    Sql &= "(select top 1 ltrim(t_resp) from tdmisg121200 where t_docn=dm.t_docn And t_revn=dm.t_revn) as Discipline "
    Sql &= "		  from tdmisg001200 as dm"
    Sql &= "  where ((Month(dm.t_adat) = Month(convert(datetime,'" & ToDate & "',103))) AND (Year(dm.t_adat) = Year(convert(datetime,'" & ToDate & "',103)))) "
		Sql &= "  and substring(dm.t_docn,17,3) not in ('VEN','SPC','POS','CCL','GPD','VSH','DOC','TDS','MIS','DCL','FNT','MTO') "
		Sql &= "        and dm.t_wfst = 5 "
		'Sql &= "        and dm.t_docn+dm.t_revn in (select isu.t_docn+isu.t_revi from tdmisg011200 as isu  where month(isu.t_isdt) = month(dm.t_adat) and year(isu.t_isdt) = year(dm.t_adat)) "
		Sql &= "		    and upper(dm.t_name) = '" & VaultDB & "' "
		Sql &= "        and dm.t_type = 'DWG' "
		Sql &= "      order by dm.t_cprj,dm.t_docn,dm.t_revn "
		Return GetReportClass(Sql)
	End Function
	Public Shared Function GetAllReleasedDocuments(ByVal FromDate As String, ByVal ToDate As String, ByVal Division As String) As List(Of ReportClass)
		'Convert From & TO Date yyyy-mm-dd
		ToDate = Convert.ToDateTime(ToDate).AddDays(1)
		FromDate = FromDate.Substring(6, 4) & "-" & FromDate.Substring(3, 2) & "-" & FromDate.Substring(0, 2)
		ToDate = ToDate.Substring(6, 4) & "-" & ToDate.Substring(3, 2) & "-" & ToDate.Substring(0, 2)
		Dim VaultDB As String = "BOILER"
		Select Case Division
			Case "SMD"
				VaultDB = "SMD"
			Case "EPC"
				VaultDB = "EPC"
			Case "APC"
				VaultDB = "PC"
			Case "BOILER"
				VaultDB = "BOILER"
		End Select
		Dim Sql As String = ""
		Sql &= "		select count(dm.t_cprj) as DocumentCount,"
		Sql &= "		       Month(dm.t_adat) as MonthName,"
		Sql &= "		       Year(dm.t_adat) as YearName "
		Sql &= "		  from tdmisg001200 as dm"
		Sql &= "		  where ((dm.t_adat >= '" & FromDate & "') AND (dm.t_adat < '" & ToDate & "'))"
		Sql &= "        and dm.t_wfst = 5 "
		'Sql &= "        and dm.t_docn+dm.t_revn in (select isu.t_docn+isu.t_revi from tdmisg011200 as isu  where month(isu.t_isdt) = month(dm.t_adat) and year(isu.t_isdt) = year(dm.t_adat)) "
		Sql &= "		    and upper(dm.t_name) = '" & VaultDB & "' "
		Sql &= "        and dm.t_type = 'DWG' "
		Sql &= "        and substring(dm.t_docn,17,3) not in ('VEN','SPC','POS','CCL','GPD','VSH','DOC','TDS','MIS','DCL','FNT','MTO') "
		Sql &= "      group by Month(dm.t_adat),Year(dm.t_adat) "
		Sql &= "      order by Month(dm.t_adat),Year(dm.t_adat) "

		Return GetReportClass(Sql)
	End Function
	Private Shared Function GetReportClass(ByVal Sql As String) As List(Of ReportClass)
		Dim Results As List(Of ReportClass) = Nothing
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = Sql
        Cmd.CommandTimeout = 1200
        Results = New List(Of ReportClass)
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        While (Reader.Read())
          Results.Add(New ReportClass(Reader))
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
