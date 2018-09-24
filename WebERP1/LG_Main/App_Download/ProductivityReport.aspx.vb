Imports System.Data
Imports System.Data.SqlClient
Imports OfficeOpenXml
Partial Class ProductivityReport
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
		'================
		Dim mLastScriptTimeout As Integer = HttpContext.Current.Server.ScriptTimeout
		HttpContext.Current.Server.ScriptTimeout = 1200
		'================

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
		'================
		HttpContext.Current.Server.ScriptTimeout = mLastScriptTimeout
		'===============
		Response.ClearContent()
    Response.AppendHeader("content-disposition", "attachment; filename=" & DWFile & ".xlsx")
    Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(IO.Path.GetFileName(FilePath))
		Response.WriteFile(FilePath)
		Response.End()
	End Sub
  Private Function CreateFile(ByVal FromDate As String, ByVal ToDate As String, ByVal Division As String) As String
    Dim FileName As String = Server.MapPath("~/..") & "App_Temp\" & Guid.NewGuid().ToString()
    IO.File.Copy(Server.MapPath("~/App_Templates") & "\ProductivityReportTemplate.xlsx", FileName)
    Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
    Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)
    Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("Report")


    Dim oDocs As List(Of ProductivityReportClass) = ProductivityReportClass.GetNewProductivityReport(FromDate, ToDate, Division)
    'Calculate Produnctivity
    Dim Productivity As Double = 0.0
    Dim TotHrs As Double = 0
    Dim TotDoc As Double = 0
    For Each doc As ProductivityReportClass In oDocs
      doc.Docs = ProductivityReportClass.GetDocsFromSheetSize(Right(doc.SheetSize, 1), Division)
      TotDoc = TotDoc + Convert.ToDouble(doc.Docs)
      TotHrs = TotHrs + Convert.ToDouble(doc.Hrs)
    Next
    If TotDoc <> 0 Then
      Productivity = TotHrs / TotDoc
    End If
    '====



    Dim r As Integer = 6
    Dim c As Integer = 1
    Dim tc As Integer = 7
    With xlWS
      .Cells(2, 2).Value = FromDate
      .Cells(2, 3).Value = ToDate
      .Cells(3, 2).Value = Division

      For Each doc As ProductivityReportClass In oDocs
        If r > 6 Then xlWS.InsertRow(r, 1, r + 1)
        ' .Cells(r + 1, 10).FormulaR1C1 = .Cells(r, 10).FormulaR1C1
        c = 1
        .Cells(r, c).Value = doc.DocumentID.Trim
        c += 1
        .Cells(r, c).Value = doc.RevisionNo
        c += 1
        .Cells(r, c).Value = doc.IssueDate
        c += 1
        .Cells(r, c).Value = doc.SheetSize
        c += 1
        Try
          .Cells(r, c).Value = Convert.ToDouble(doc.Docs)
        Catch ex As Exception
          .Cells(r, c).Value = "#Err"
        End Try
        c += 1
        .Cells(r, c).Value = Convert.ToDouble(doc.Hrs)
        c += 1
        .Cells(r, c).Value = doc.DesignGroup
        c += 1
        .Cells(r, c).Value = doc.Discipline
        c += 1
        'Inhouse = 2
        'Outsourced = 1
        .Cells(r, c).Value = IIf(doc.OutSourced = "2", "Inhouse", "Outsourced")
        c += 1


        If doc.DesignGroup = "ENGG001" Then
          .Cells(r, c).Value = "Mechanical"
        End If
        If doc.DesignGroup = "ENGG002" Then
          .Cells(r, c).Value = "Thermal & Process Group"
        End If
        If doc.DesignGroup = "ENGG003" Then
          .Cells(r, c).Value = "Standardisation Group"
        End If
        If doc.DesignGroup = "ENGG004" Then
          .Cells(r, c).Value = "PC Boiler Engineering"
        End If
        If doc.DesignGroup = "ENGG005" Then
          .Cells(r, c).Value = "Boiler Chennai Design centre"
        End If
        If doc.DesignGroup = "ENGG006" Then
          .Cells(r, c).Value = "Engg. Administration"
        End If
        If doc.DesignGroup = "ENGG007" Then
          .Cells(r, c).Value = "APCE-Design"
        End If
        If doc.DesignGroup = "ENGG008" Then
          .Cells(r, c).Value = "Boiler Proposal Chennai"
        End If
        If doc.DesignGroup = "ENGG009" Then
          .Cells(r, c).Value = "CFBC-Thermal and Process"
        End If
        If doc.DesignGroup = "ENGGA" Then
          .Cells(r, c).Value = "TG AND DG GROUP"
        End If
        If doc.DesignGroup = "ENGB" Then
          .Cells(r, c).Value = "AFBC GROUP"
        End If
        If doc.DesignGroup = "ENGGC" Then
          .Cells(r, c).Value = "CFBC GROUP"
        End If
        If doc.DesignGroup = "ENGGD" Then
          .Cells(r, c).Value = "PIPING & WATER TREATMENT GROUP"
        End If
        If doc.DesignGroup = "ENGGE" Then
          .Cells(r, c).Value = "STANDARDISATION GROUP"
        End If
        If doc.DesignGroup = "ENGGF" Then
          .Cells(r, c).Value = "STRUCTURAL GROUP"
        End If
        If doc.DesignGroup = "ENGGG" Then
          .Cells(r, c).Value = "ELECTRICAL GROUP"
        End If
        If doc.DesignGroup = "ENGGH" Then
          .Cells(r, c).Value = "CONTROL &INSTRUMENTATION GROUP"
        End If
        If doc.DesignGroup = "ENGGI" Then
          .Cells(r, c).Value = "SMD DESIGN GROUP"
        End If
        If doc.DesignGroup = "ENGGJ" Then
          .Cells(r, c).Value = "GEBD CHENNAI DESIGN CENTRE"
        End If
        If doc.DesignGroup = "ENGGK" Then
          .Cells(r, c).Value = "IBD CHENNAI DESIGN CENTRE"
        End If
        If doc.DesignGroup = "ENGGL" Then
          .Cells(r, c).Value = "OIL & GAS FIRED GROUP"
        End If
        If doc.DesignGroup = "ENGGM" Then
          .Cells(r, c).Value = "EPC CHENNAI DESIGN CENTRE"
        End If



        'c += 1
        '.Cells(r, c).Value = "=1+1"

        r += 1
      Next
      ' .Cells(r + 1, 5).Formula = "=SUM(E6:E" & r - 1 & ")"
      Dim tmp As Table.PivotTable.ExcelPivotTable = xlWS.PivotTables("PivotTable1")

    End With

    'Not Included in Productivity Report
    xlWS = xlPk.Workbook.Worksheets("NOT ISSUED")
    oDocs = ProductivityReportClass.GetDocumentNotIssued(FromDate, ToDate, Division)
    r = 5
    With xlWS
      For Each doc As ProductivityReportClass In oDocs
        If r > 5 Then xlWS.InsertRow(r, 1, r + 1)
        c = 1
        .Cells(r, c).Value = doc.ProjectID
        c += 1
        .Cells(r, c).Value = doc.DocumentID.Trim
        c += 1
        .Cells(r, c).Value = doc.RevisionNo
        c += 1
        .Cells(r, c).Value = doc.IssueDate
        c += 1
        .Cells(r, c).Value = doc.Discipline
        c += 1
        'Inhouse = 2
        'Outsourced = 1
        .Cells(r, c).Value = IIf(doc.OutSourced = "2", "Inhouse", "Outsourced")
        r += 1


      Next
    End With
    xlWS = xlPk.Workbook.Worksheets("NO HRS ENTRY")
    oDocs = ProductivityReportClass.GetDocumentNoHrsEntry(FromDate, ToDate, Division)
    r = 5
    With xlWS
      For Each doc As ProductivityReportClass In oDocs
        If r > 5 Then xlWS.InsertRow(r, 1, r + 1)
        c = 1
        .Cells(r, c).Value = doc.ProjectID
        c += 1
        .Cells(r, c).Value = doc.DocumentID.Trim
        c += 1
        .Cells(r, c).Value = doc.RevisionNo
        c += 1
        .Cells(r, c).Value = doc.IssueDate
        c += 1
        .Cells(r, c).Value = doc.Discipline
        c += 1
        'Inhouse = 2
        'Outsourced = 1
        .Cells(r, c).Value = IIf(doc.OutSourced = "2", "Inhouse", "Outsourced")
        r += 1

      Next
    End With


    'ISSUED-NO Hrs Entry
    xlWS = xlPk.Workbook.Worksheets("ISSUED-NO Hrs Entry")
    oDocs = ProductivityReportClass.GetDocumentIssuedButNoHRSEntry(FromDate, ToDate, Division)
    r = 6
    c = 1
    tc = 7
    With xlWS
      .Cells(2, 2).Value = FromDate
      .Cells(2, 3).Value = ToDate
      .Cells(3, 2).Value = Division

      For Each doc As ProductivityReportClass In oDocs
        If Convert.ToDouble(doc.Hrs) > 0 Then Continue For
        If r > 6 Then xlWS.InsertRow(r, 1, r + 1)
        c = 1
        .Cells(r, c).Value = doc.DocumentID.Trim
        c += 1
        .Cells(r, c).Value = doc.RevisionNo
        c += 1
        .Cells(r, c).Value = doc.IssueDate
        c += 1
        .Cells(r, c).Value = doc.SheetSize
        c += 1
        .Cells(r, c).Value = doc.Discipline
        c += 1
        'Inhouse = 2
        'Outsourced = 1
        .Cells(r, c).Value = IIf(doc.OutSourced = "2", "Inhouse", "Outsourced")
        r += 1


      Next
    End With


    xlPk.Save()
    xlPk.Dispose()

    Return FileName
  End Function



End Class
Public Class ProductivityReportClass
  Public ProjectID As String = ""
  Public DocumentID As String = ""
  Public RevisionNo As String = ""
  Public IssueDate As String = ""
  Public SheetSize As String = ""
  Public DesignGroup As String = ""
  Public Docs As String = ""
  Public Hrs As String = ""
  Public Discipline As String = ""
  Public OutSourced As String = ""

  Public Shared Function GetDocsFromSheetSize(ByVal SheetSize As String, ByVal Division As String) As String
    Dim mRet As String = "0"
    Try
      If SheetSize <> "" Then
        Dim D2 As Integer = Convert.ToInt32(SheetSize)
        Select Case Division
          Case "SMD"
            mRet = If(D2 = 0, 2, If(D2 = 1, 1, If(D2 = 2, 0.75, If(D2 = 3, 0.45, If(D2 = 4, 0.3, 0)))))
          Case Else
            mRet = If(D2 = 0, 2, If(D2 = 1, 1, If(D2 = 2, 0.5, If(D2 = 3, 0.25, If(D2 = 4, 0.125, 0)))))
        End Select
      End If
    Catch ex As Exception
    End Try
    Return mRet
  End Function

  'NO HRS ENTRY
  Public Shared Function GetDocumentNoHrsEntry(ByVal FromDate As String, ByVal ToDate As String, ByVal Division As String) As List(Of ProductivityReportClass)
    'Convert From & TO Date yyyy-mm-dd
    ToDate = Convert.ToDateTime(ToDate).AddDays(1)
    FromDate = FromDate.Substring(6, 4) & "-" & FromDate.Substring(3, 2) & "-" & FromDate.Substring(0, 2)
    ToDate = ToDate.Substring(6, 4) & "-" & ToDate.Substring(3, 2) & "-" & ToDate.Substring(0, 2)
    Dim FilterActivity As String = "(1,2,75,77)"
    Dim FilterGroup As String = "('ENGG001','ENGGC','ENGGD','ENGGF','ENGG005','ENGG002','ENGG003','ENGG004')"
    Dim VaultDB As String = "BOILER"
    Select Case Division
      Case "PUNE"
        FilterActivity = "(1,2)"
        FilterGroup = "('PUNE001')"
        VaultDB = "SMD"
      Case "SMD"
        FilterActivity = "(1,2)"
        FilterGroup = "('ENGGI')"
        VaultDB = "SMD"
      Case "CHENNAI"
        FilterActivity = "(1,2,75,77)"
        FilterGroup = "('ENGG005')"
        VaultDB = "BOILER"
      Case "EPC"
        VaultDB = "EPC"
        FilterActivity = "(1,2)"
        FilterGroup = "('ENGGM')"
      Case "APC"
        VaultDB = "PC"
        FilterActivity = "(1,2,75,77)"
        FilterGroup = "('ENGG007')"
      Case "BOILER"
        FilterActivity = "(1,2,75,77,10,19,57,61,76)"
        FilterGroup = "('ENGG001','ENGGA','ENGGB','ENGGC','ENGGD','ENGGE','ENGGF','ENGGG','ENGGH','ENGG005','ENGG002','ENGG003','ENGG004','ENGG005','ENGG006','ENGG007','ENGG008','ENGG009')"
        VaultDB = "BOILER"
    End Select
    Dim Sql As String = ""
    Sql &= "select dm.t_cprj as ProjectID,"
    Sql &= "       dm.t_docn as DocumentID,"
    Sql &= "       dm.t_revn as Revision,"
    Sql &= "       dm.t_adat as IssueDate,"


    Sql &= "(select top 1 ltrim(t_resp) from tdmisg121200 where t_docn=dm.t_docn and t_revn=dm.t_revn) as Discipline,"

    Sql &= "(select top 1 ltrim(t_oscd) from tdmisg140200 where t_docn=dm.t_docn and t_revn=dm.t_revn) as Outsourced"


    Sql &= "  from tdmisg001200 as dm"
    Sql &= "  where ((dm.t_adat >= '" & FromDate & "') AND (dm.t_adat < '" & ToDate & "'))"
    Sql &= "    and dm.t_revn = '00' "
    Sql &= "    and substring(dm.t_docn,17,3) not in ('VEN','SPC','POS','CCL','GPD','VSH','DOC','TDS','MIS','DCL','FNT','MTO') "
    Sql &= "    and upper(dm.t_name) = '" & VaultDB & "' "
    Sql &= "    and 1 not in "
    Sql &= "       (select 1 from ttiisg910200 as hrs "
    Sql &= "           where hrs.t_acid in " & FilterActivity
    Sql &= "              and substring(dm.t_docn,1,6) = ltrim(hrs.t_cprj)"
    Sql &= "              and substring(dm.t_docn,8,8) = ltrim(hrs.t_cspa)"
    Sql &= "              and substring(dm.t_docn,17,3) = ltrim(hrs.t_dcat) "
    Sql &= "              and ( substring('0000'+ltrim(substring(dm.t_docn,21,4)) ,len('0000'+ltrim(substring(dm.t_docn,21,4)))-3,4)"
    Sql &= "                    = substring('0000'+ltrim(hrs.t_dsno),len('0000'+ltrim(hrs.t_dsno))-3 ,4)   "
    Sql &= "                  )"
    Sql &= "              and hrs.t_tdat <= dm.t_adat  "
    Sql &= "              and hrs.t_grcd in " & FilterGroup
    Sql &= "                  )"
    Sql &= "  order by dm.t_cprj,dm.t_docn,dm.t_adat"


    Dim Results As List(Of ProductivityReportClass) = Nothing
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = Sql
        Cmd.CommandTimeout = 3600
        Results = New List(Of ProductivityReportClass)
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        While (Reader.Read())
          Results.Add(New ProductivityReportClass(Reader))
        End While
        Reader.Close()
      End Using
    End Using
    Return Results
  End Function

  'NOT ISSUED
  Public Shared Function GetDocumentNotIssued(ByVal FromDate As String, ByVal ToDate As String, ByVal Division As String) As List(Of ProductivityReportClass)
    'Convert From & TO Date yyyy-mm-dd
    ToDate = Convert.ToDateTime(ToDate).AddDays(1)
    FromDate = FromDate.Substring(6, 4) & "-" & FromDate.Substring(3, 2) & "-" & FromDate.Substring(0, 2)
    ToDate = ToDate.Substring(6, 4) & "-" & ToDate.Substring(3, 2) & "-" & ToDate.Substring(0, 2)
    Dim FilterActivity As String = "(1,2,75,77)"
    Dim FilterGroup As String = "('ENGG001','ENGGC','ENGGD','ENGGF','ENGG005','ENGG002','ENGG003','ENGG004')"
    Dim VaultDB As String = "BOILER"
    Select Case Division
      Case "PUNE"
        FilterActivity = "(1,2)"
        FilterGroup = "('PUNE001')"
        VaultDB = "SMD"
      Case "SMD"
        FilterActivity = "(1,2)"
        FilterGroup = "('ENGGI')"
        VaultDB = "SMD"
      Case "CHENNAI"
        FilterActivity = "(1,2,75,77)"
        FilterGroup = "('ENGG005')"
        VaultDB = "BOILER"
      Case "EPC"
        VaultDB = "EPC"
        FilterActivity = "(1,2)"
        FilterGroup = "('ENGGM')"
      Case "APC"
        VaultDB = "PC"
        FilterActivity = "(1,2,75,77)"
        FilterGroup = "('ENGG007')"
      Case "BOILER"
        FilterActivity = "(1,2,75,77,10,19,57,61,76)"
        FilterGroup = "('ENGG001','ENGGA','ENGGB','ENGGC','ENGGD','ENGGE','ENGGF','ENGGG','ENGGH','ENGG005','ENGG002','ENGG003','ENGG004','ENGG005','ENGG006','ENGG007','ENGG008','ENGG009')"
        VaultDB = "BOILER"
    End Select
    Dim Sql As String = ""
    Sql &= "select dm.t_cprj as ProjectID,"
    Sql &= "       dm.t_docn as DocumentID,"
    Sql &= "       dm.t_revn as Revision,"
    Sql &= "       dm.t_adat as IssueDate,"

    Sql &= "(select top 1 ltrim(t_resp) from tdmisg121200 where t_docn=dm.t_docn and t_revn=dm.t_revn) as Discipline,"

    Sql &= "(select top 1 ltrim(t_oscd) from tdmisg140200 where t_docn=dm.t_docn and t_revn=dm.t_revn) as Outsourced"


    Sql &= "  from tdmisg001200 as dm"
    Sql &= "  where ((dm.t_adat >= '" & FromDate & "') AND (dm.t_adat < '" & ToDate & "'))"
    Sql &= "    and dm.t_revn = '00' "
    Sql &= "    and substring(dm.t_docn,17,3) not in ('VEN','SPC','POS','CCL','GPD','VSH','DOC','TDS','MIS','DCL','FNT','MTO') "
    Sql &= "    and upper(dm.t_name) = '" & VaultDB & "' "
    Sql &= "    and dm.t_docn+dm.t_revn not in "
    Sql &= "       (select isu.t_docn+isu.t_revi from tdmisg011200 as isu "
    Sql &= "        where (isu.t_isdt >= '" & FromDate & "') AND (isu.t_isdt < '" & ToDate & "')"
    Sql &= "	      Union All "
    Sql &= "	      select "
    Sql &= "	      tl.t_docn+tl.t_revn  "
    Sql &= "	      from tdmisg132200 as tl inner join tdmisg131200 as th on tl.t_tran=th.t_tran "
    Sql &= "        where (th.t_isdt >= '" & FromDate & "') AND (th.t_isdt < '" & ToDate & "')"
    Sql &= "        )"
    Sql &= "  order by dm.t_cprj,dm.t_docn,dm.t_adat"

    Dim Results As List(Of ProductivityReportClass) = Nothing
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = Sql
        Cmd.CommandTimeout = 3600
        Results = New List(Of ProductivityReportClass)
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        While (Reader.Read())
          Results.Add(New ProductivityReportClass(Reader))
        End While
        Reader.Close()
      End Using
    End Using
    Return Results
  End Function
  'Report
  Public Shared Function GetNewProductivityReport(ByVal FromDate As String, ByVal ToDate As String, ByVal Division As String) As List(Of ProductivityReportClass)
    'Convert From & TO Date yyyy-mm-dd
    ToDate = Convert.ToDateTime(ToDate).AddDays(1)
    FromDate = FromDate.Substring(6, 4) & "-" & FromDate.Substring(3, 2) & "-" & FromDate.Substring(0, 2)
    ToDate = ToDate.Substring(6, 4) & "-" & ToDate.Substring(3, 2) & "-" & ToDate.Substring(0, 2)
    Dim FilterActivity As String = "(1,2,75,77,10,19,57,61,76)"
    Dim FilterGroup As String = "('ENGG001','ENGGC','ENGGD','ENGGF','ENGG005','ENGG002','ENGG003','ENGG004')"
    Dim VaultDB As String = "BOILER"
    Select Case Division
      Case "PUNE"
        FilterActivity = "(1,2,10,19,57,61,76)"
        FilterGroup = "('PUNE001')"
        VaultDB = "SMD"
      Case "SMD"
        FilterActivity = "(1,2,10,19,57,61,76)"
        FilterGroup = "('ENGGI')"
        VaultDB = "SMD"
      Case "CHENNAI"
        FilterActivity = "(1,2,75,77,10,19,57,61,76)"
        FilterGroup = "('ENGG005')"
        VaultDB = "BOILER"
      Case "EPC"
        VaultDB = "EPC"
        FilterActivity = "(1,2,10,19,57,61,76)"
        FilterGroup = "('ENGGM')"
      Case "APC"
        VaultDB = "PC"
        FilterActivity = "(1,2,75,77,10,19,57,61,76)"
        FilterGroup = "('ENGG007')"
      Case "BOILER"
        FilterActivity = "(1,2,75,77,10,19,57,61,76)"
        FilterGroup = "('ENGG001','ENGGA','ENGGB','ENGGC','ENGGD','ENGGE','ENGGF','ENGGG','ENGGH','ENGG005','ENGG002','ENGG003','ENGG004','ENGG005','ENGG006','ENGG007','ENGG008','ENGG009')"
        VaultDB = "BOILER"
    End Select
    Dim Sql As String = ""
    Sql = Sql & " select "
    Sql = Sql & "	aa.DocumentID, "
    Sql = Sql & "	aa.IssueDate, "
    Sql = Sql & "	aa.Revision, "
    Sql = Sql & "	aa.SheetSize, "
    Sql = Sql & "	(select top 1 ltrim(t_resp) from tdmisg121200 where t_docn=aa.DocumentID and t_revn=aa.Revision) as Discipline, "
    Sql = Sql & "	(select top 1 isnull(t_oscd,2) from tdmisg140200 where t_docn=aa.DocumentID and t_revn=aa.Revision) as Outsourced, "
    Sql = Sql & " (select top 1 ltrim(t_size) from tdmisg001200 where t_docn=aa.DocumentID and t_revn=aa.Revision) as dmSize, "
    Sql = Sql & "    (select sum(hh.t_hhrs)    "
    Sql = Sql & "       from ttiisg910200 hh "
    Sql = Sql & "       where hh.t_acid in " & FilterActivity
    Sql = Sql & "         and substring(aa.DocumentID,1,6) = ltrim(hh.t_cprj)"
    Sql = Sql & "         and substring(aa.DocumentID,8,8) = ltrim(hh.t_cspa)"
    Sql = Sql & "         and substring(aa.DocumentID,17,3) = ltrim(hh.t_dcat) "
    Sql = Sql & "         and ( substring('0000'+ltrim(substring(aa.DocumentID,21,4)) ,len('0000'+ltrim(substring(aa.DocumentID,21,4)))-3,4)"
    Sql = Sql & "           = substring('0000'+ltrim(hh.t_dsno),len('0000'+ltrim(hh.t_dsno))-3 ,4)   "
    Sql = Sql & "             )"
    Sql = Sql & "         and cast(hh.t_tdat as date)<=cast(dateadd(d,2,aa.IssueDate) as date)  "
    Sql = Sql & "         and hh.t_grcd in " & FilterGroup
    Sql = Sql & "         ) as Hours, "
    Sql = Sql & "        (select top 1 hh.t_grcd    "
    Sql = Sql & "            from ttiisg910200 hh "
    Sql = Sql & "		         where(substring(aa.DocumentID, 1, 6) = LTrim(hh.t_cprj))"
    Sql = Sql & "              and substring(aa.DocumentID,8,8) = ltrim(hh.t_cspa)"
    Sql = Sql & "              and substring(aa.DocumentID,17,3) = ltrim(hh.t_dcat) "
    Sql = Sql & "              and ( substring('0000'+ltrim(substring(aa.DocumentID,21,4)) ,len('0000'+ltrim(substring(aa.DocumentID,21,4)))-3,4)"
    Sql = Sql & "                    = substring('0000'+ltrim(hh.t_dsno),len('0000'+ltrim(hh.t_dsno))-3 ,4)   "
    Sql = Sql & "                  )"
    Sql = Sql & "              and hh.t_acid in " & FilterActivity
    Sql = Sql & "              and hh.t_grcd in " & FilterGroup
    Sql = Sql & "        ) as GroupID,"
    Sql = Sql & "        substring(aa.DocumentID,1,20)+ substring('0000'+ltrim(substring(aa.DocumentID,21,4)) ,len('0000'+ltrim(substring(aa.DocumentID,21,4)))-3,4) as IssDoc "
    Sql = Sql & "	From ( "
    Sql = Sql & "		select "
    Sql = Sql & "			iss.t_docn as DocumentID, "
    Sql = Sql & "			iss.t_isdt as IssueDate, "
    Sql = Sql & "			iss.t_revi as Revision, "
    Sql = Sql & "			iss.t_shsz as SheetSize "
    Sql = Sql & "	  from tdmisg011200 as iss  "
    Sql = Sql & "	  Union All "
    Sql = Sql & "	  select "
    Sql = Sql & "	    tl.t_docn as DocumentID, "
    Sql = Sql & "	    th.t_isdt as IssueDate, "
    Sql = Sql & "	    tl.t_revn as Revision, "
    Sql = Sql & "		  (select dl.t_size from tdmisg121200 as dl where dl.t_docn=tl.t_docn and dl.t_revn=tl.t_revn) as SheetSize "
    Sql = Sql & "	  from tdmisg132200 as tl inner join tdmisg131200 as th on tl.t_tran=th.t_tran "
    Sql = Sql & "	) as aa  "
    Sql = Sql & " where substring(aa.DocumentID,17,3) not in ('VEN','SPC','POS','CCL','GPD','VSH','DOC','TDS','MIS','DCL','FNT','MTO') "
    Sql = Sql & " and   substring(aa.DocumentID,1,20)+ substring('0000'+ltrim(substring(aa.DocumentID,21,4)) ,len('0000'+ltrim(substring(aa.DocumentID,21,4)))-3,4)   "
    Sql = Sql & "      in (select ltrim(hh.t_cprj)+'-'+ltrim(hh.t_cspa)+'-'+ltrim(hh.t_dcat)+'-'+substring('0000'+ltrim(hh.t_dsno),len('0000'+ltrim(hh.t_dsno))-3 ,4)    "
    Sql = Sql & "                    from ttiisg910200 hh "
    Sql = Sql & "                    where hh.t_acid in " & FilterActivity
    Sql = Sql & "                      and cast(hh.t_tdat as date)<=cast(dateadd(d,2,aa.IssueDate) as date)  "
    Sql = Sql & "                      and hh.t_grcd in " & FilterGroup & ") "
    Sql = Sql & "   and aa.Revision in ('0','00','000','R00')  "
    Sql = Sql & "   and ((aa.IssueDate >= '" & FromDate & "') AND (aa.IssueDate < '" & ToDate & "'))  "
    Sql = Sql & "   and (aa.IssueDate = (select min(cc.IssueDate) From ( "
    Sql = Sql & "      SELECT min(iss.t_isdt) as IssueDate from tdmisg011200 as iss where iss.t_docn = aa.DocumentID and iss.t_revi= aa.Revision  "
    Sql = Sql & "      UNION ALL  "
    Sql = Sql & "      select min(th.t_isdt) as IssueDate from tdmisg132200 as tl inner join tdmisg131200 as th on tl.t_tran=th.t_tran where tl.t_docn = aa.DocumentID and tl.t_revn= aa.Revision  "
    Sql = Sql & "                      ) as cc)) "
    Sql = Sql & " Order By aa.DocumentID, aa.IssueDate"
    Dim Results As List(Of ProductivityReportClass) = Nothing
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = Sql
        Cmd.CommandTimeout = 1200
        Results = New List(Of ProductivityReportClass)
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        While (Reader.Read())
          Results.Add(New ProductivityReportClass(Reader))
        End While
        Reader.Close()
      End Using
    End Using
    Return Results
  End Function


  'ISSUED-NO Hrs Entry
  Public Shared Function GetDocumentIssuedButNoHRSEntry(ByVal FromDate As String, ByVal ToDate As String, ByVal Division As String) As List(Of ProductivityReportClass)
    'Convert From & TO Date yyyy-mm-dd
    ToDate = Convert.ToDateTime(ToDate).AddDays(1)
    FromDate = FromDate.Substring(6, 4) & "-" & FromDate.Substring(3, 2) & "-" & FromDate.Substring(0, 2)
    ToDate = ToDate.Substring(6, 4) & "-" & ToDate.Substring(3, 2) & "-" & ToDate.Substring(0, 2)
    Dim FilterActivity As String = "(1,2,75,77)"
    Dim FilterGroup As String = "('ENGG001','ENGGC','ENGGD','ENGGF','ENGG005','ENGG002','ENGG003','ENGG004')"
    Dim VaultDB As String = "BOILER"
    Select Case Division
      Case "PUNE"
        FilterActivity = "(1,2)"
        FilterGroup = "('PUNE001')"
        VaultDB = "SMD"
      Case "SMD"
        FilterActivity = "(1,2)"
        FilterGroup = "('ENGGI')"
        VaultDB = "SMD"
      Case "CHENNAI"
        FilterActivity = "(1,2,75,77)"
        FilterGroup = "('ENGG005')"
        VaultDB = "BOILER"
      Case "EPC"
        VaultDB = "EPC"
        FilterActivity = "(1,2)"
        FilterGroup = "('ENGGM')"
      Case "APC"
        VaultDB = "PC"
        FilterActivity = "(1,2,75,77)"
        FilterGroup = "('ENGG007')"
      Case "BOILER"
        FilterActivity = "(1,2,75,77,10,19,57,61,76)"
        FilterGroup = "('ENGG001','ENGGA','ENGGB','ENGGC','ENGGD','ENGGE','ENGGF','ENGGG','ENGGH','ENGG005','ENGG002','ENGG003','ENGG004','ENGG005','ENGG006','ENGG007','ENGG008','ENGG009')"
        VaultDB = "BOILER"
    End Select
    Dim Sql As String = ""
    Sql = Sql & " select * from (select "
    Sql = Sql & "	aa.DocumentID, "
    Sql = Sql & "	aa.IssueDate, "
    Sql = Sql & "	aa.Revision, "
    Sql = Sql & "	aa.SheetSize, "
    Sql = Sql & " (select top 1 ltrim(t_size) from tdmisg001200 where t_docn=aa.DocumentID and t_revn=aa.Revision) as dmSize, "
    Sql = Sql & "	(select top 1 ltrim(t_resp) from tdmisg121200 where t_docn=aa.DocumentID and t_revn=aa.Revision) as Discipline, "
    Sql = Sql & "	(select top 1 isnull(t_oscd,2) from tdmisg140200 where t_docn=aa.DocumentID and t_revn=aa.Revision) as Outsourced, "
    Sql = Sql & "    (select sum(hh.t_hhrs)    "
    Sql = Sql & "       from ttiisg910200 hh "
    Sql = Sql & "       where hh.t_acid in " & FilterActivity
    Sql = Sql & "         and substring(aa.DocumentID,1,6) = ltrim(hh.t_cprj)"
    Sql = Sql & "         and substring(aa.DocumentID,8,8) = ltrim(hh.t_cspa)"
    Sql = Sql & "         and substring(aa.DocumentID,17,3) = ltrim(hh.t_dcat) "
    Sql = Sql & "         and ( substring('0000'+ltrim(substring(aa.DocumentID,21,4)) ,len('0000'+ltrim(substring(aa.DocumentID,21,4)))-3,4)"
    Sql = Sql & "           = substring('0000'+ltrim(hh.t_dsno),len('0000'+ltrim(hh.t_dsno))-3 ,4)   "
    Sql = Sql & "             )"
    Sql = Sql & "         and cast(hh.t_tdat as date)<=cast(dateadd(d,2,aa.IssueDate) as date)  "
    Sql = Sql & "         and hh.t_grcd in " & FilterGroup
    Sql = Sql & "         ) as Hours, "
    Sql = Sql & "        (select top 1 hh.t_grcd    "
    Sql = Sql & "            from ttiisg910200 hh "
    Sql = Sql & "		         where(substring(aa.DocumentID, 1, 6) = LTrim(hh.t_cprj))"
    Sql = Sql & "              and substring(aa.DocumentID,8,8) = ltrim(hh.t_cspa)"
    Sql = Sql & "              and substring(aa.DocumentID,17,3) = ltrim(hh.t_dcat) "
    Sql = Sql & "              and ( substring('0000'+ltrim(substring(aa.DocumentID,21,4)) ,len('0000'+ltrim(substring(aa.DocumentID,21,4)))-3,4)"
    Sql = Sql & "                    = substring('0000'+ltrim(hh.t_dsno),len('0000'+ltrim(hh.t_dsno))-3 ,4)   "
    Sql = Sql & "                  )"
    Sql = Sql & "              and hh.t_acid in " & FilterActivity
    Sql = Sql & "              and hh.t_grcd in " & FilterGroup
    Sql = Sql & "        ) as GroupID,"
    Sql = Sql & "        substring(aa.DocumentID,1,20)+ substring('0000'+ltrim(substring(aa.DocumentID,21,4)) ,len('0000'+ltrim(substring(aa.DocumentID,21,4)))-3,4) as IssDoc "
    Sql = Sql & "	From ( "
    Sql = Sql & "		select "
    Sql = Sql & "			iss.t_docn as DocumentID, "
    Sql = Sql & "			iss.t_isdt as IssueDate, "
    Sql = Sql & "			iss.t_revi as Revision, "
    Sql = Sql & "			iss.t_shsz as SheetSize "
    Sql = Sql & "	  from tdmisg011200 as iss  "
    Sql = Sql & "	  Union All "
    Sql = Sql & "	  select "
    Sql = Sql & "	    tl.t_docn as DocumentID, "
    Sql = Sql & "	    th.t_isdt as IssueDate, "
    Sql = Sql & "	    tl.t_revn as Revision, "
    Sql = Sql & "		  (select dl.t_size from tdmisg121200 as dl where dl.t_docn=tl.t_docn and dl.t_revn=tl.t_revn) as SheetSize "
    Sql = Sql & "	  from tdmisg132200 as tl inner join tdmisg131200 as th on tl.t_tran=th.t_tran "
    Sql = Sql & "	) as aa  "
    Sql = Sql & " inner join tdmisg001200 as dm on dm.t_docn = aa.DocumentID and dm.t_revn = aa.Revision "
    Sql = Sql & " where substring(aa.DocumentID,17,3) not in ('VEN','SPC','POS','CCL','GPD','VSH','DOC','TDS','MIS','DCL','FNT','MTO') "
    Sql = Sql & "   and upper(dm.t_name) = '" & VaultDB & "' "
    Sql = Sql & "   and aa.Revision in ('0','00','000','R00')  "
    Sql = Sql & "   and ((aa.IssueDate >= '" & FromDate & "') AND (aa.IssueDate < '" & ToDate & "'))  "
    Sql = Sql & "   and (aa.IssueDate = (select min(cc.IssueDate) From ( "
    Sql = Sql & "      SELECT min(iss.t_isdt) as IssueDate from tdmisg011200 as iss where iss.t_docn = aa.DocumentID and iss.t_revi= aa.Revision  "
    Sql = Sql & "      UNION ALL  "
    Sql = Sql & "      select min(th.t_isdt) as IssueDate from tdmisg132200 as tl inner join tdmisg131200 as th on tl.t_tran=th.t_tran where tl.t_docn = aa.DocumentID and tl.t_revn= aa.Revision  "
    Sql = Sql & "                      ) as cc)) ) as ll "
    Sql = Sql & " WHERE ll.Hours is null ORDER By ll.DocumentID,ll.IssueDate"




    Dim Results As List(Of ProductivityReportClass) = Nothing
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = Sql
        Cmd.CommandTimeout = 1200
        Results = New List(Of ProductivityReportClass)
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        While (Reader.Read())
          Results.Add(New ProductivityReportClass(Reader))
        End While
        Reader.Close()
      End Using
    End Using
    Return Results
  End Function
  Sub New()
    'dummy
  End Sub
  Sub New(ByVal Rd As SqlDataReader)
    Try
      Try
        ProjectID = Rd("ProjectID")
      Catch ex As Exception
      End Try
      DocumentID = Rd("DocumentID")
      Try
        IssueDate = Rd("IssueDate")
      Catch ex As Exception
      End Try
      Try
        RevisionNo = Rd("Revision")
      Catch ex As Exception
      End Try
      Try
        SheetSize = Rd("dmSize")
      Catch ex As Exception
      End Try
      Try
        Hrs = Rd("Hours")
      Catch ex As Exception
        Hrs = "0.00"
      End Try
      Try
        DesignGroup = Rd("GroupID")
      Catch ex As Exception
      End Try
      Try
        Discipline = Rd("Discipline")
      Catch ex As Exception
      End Try
      Try
        If Convert.IsDBNull(Rd("OutSourced")) Then
          OutSourced = "2"
        Else
          OutSourced = Rd("OutSourced")
        End If
      Catch ex As Exception
      End Try
    Catch ex As Exception
    End Try
  End Sub
End Class
