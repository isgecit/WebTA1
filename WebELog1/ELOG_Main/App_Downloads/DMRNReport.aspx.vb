Imports System.Data
Imports System.Data.SqlClient
Imports OfficeOpenXml
Imports System.Drawing

Partial Class DMRNReport
  Inherits System.Web.UI.Page
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim mLastScriptTimeout As Integer = HttpContext.Current.Server.ScriptTimeout
    HttpContext.Current.Server.ScriptTimeout = 1200
    'Dim FromDate As String = ""
    'Dim ToDate As String = ""
    Dim Project As String = ""

    Try
      'FromDate = Request.QueryString("fd")
      'ToDate = Request.QueryString("td")
      Project = Request.QueryString("typ")
    Catch ex As Exception
      'FromDate = ""
      'ToDate = ""
      Project = ""
    End Try
    'If FromDate = String.Empty Then Return
    Dim DWFile As String = "Site Receipt Report"
    Dim FilePath As String = CreateFile(Project)
    HttpContext.Current.Server.ScriptTimeout = mLastScriptTimeout
    Response.ClearContent()
    Response.AppendHeader("content-disposition", "attachment; filename=" & DWFile & ".xlsx")
    Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(IO.Path.GetFileName(FilePath))
    Response.WriteFile(FilePath)
    Response.End()
  End Sub
  Private Function CreateFile(ByVal project As String) As String
    Dim FileName As String = Server.MapPath("~/..") & "App_Temp\" & Guid.NewGuid().ToString()
    IO.File.Copy(Server.MapPath("~/App_Templates") & "\Site_Receipt_Report.xlsx", FileName)
    Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
    Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)

    Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("Site_Receipt_Report")
    Dim oDocs As List(Of DMRNReportClass) = DMRNReportClass.GetData(project)
    Dim r As Integer = 5
    Dim c As Integer = 2
    Dim s As Integer = 1
    Dim identifier As String = ""
    'xlWS.Cells(2, 2).Value = Now
    xlWS.Cells(3, 2).Value = "Detention Bill Report For Project - " & project & "                                                        Generated At   " & Now
    With xlWS
      For Each doc As DMRNReportClass In oDocs
        If r > 5 Then
          xlWS.InsertRow(r, 1, r + 1)
        End If
        ' c = 2

        'If identifier <> doc.Projectno Then
        .Cells(r, 2).Value = s

        'xlWS.Cells(r, 2).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        'xlWS.Cells(r, 2).Style.Fill.BackgroundColor.SetColor(Color.Orange)
        s = s + 1
        'c = c + 1
        '  .Cells(r, 3).Value = doc.Description
        'xlWS.Cells(r, 3).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        'xlWS.Cells(r, 3).Style.Fill.BackgroundColor.SetColor(Color.Orange)
        '   .Cells(6, 6).Value = "It is working"

        .Cells(r, 3).Value = doc.GRNo
        .Cells(r, 4).Value = doc.GRDate
        .Cells(r, 5).Value = doc.IRNo
        .Cells(r, 6).Value = doc.IRDate
        .Cells(r, 7).Value = doc.SupplierID
        .Cells(r, 8).Value = doc.SupplierName
        .Cells(r, 9).Value = doc.SupplierBillNo
        .Cells(r, 10).Value = doc.SupplierBillDate
        .Cells(r, 11).Value = doc.BillAmount
        .Cells(r, 12).Value = doc.BillTypeDescription
        .Cells(r, 13).Value = doc.ProjectID
        .Cells(r, 14).Value = doc.ProjectName
        .Cells(r, 15).Value = doc.PONumber
        .Cells(r, 16).Value = doc.OtherBillType
        .Cells(r, 17).Value = doc.VehicleExeNo
        .Cells(r, 18).Value = doc.MRNNo
        .Cells(r, 19).Value = doc.CreatedByID
        .Cells(r, 20).Value = doc.CreatedOn
        .Cells(r, 21).Value = doc.Status
        .Cells(r, 22).Value = doc.CreatedByName

        '.Cells(r, 21).Calculate = "=VLOOKUP(G5;ERPLN_GR_IR_DATA!B$2:G$9999;5;FALSE)"

        '.SelectedRange(r, 21).Value = "=VLOOKUP(G5;ERPLN_GR_IR_DATA!B$2:G$9999;5;FALSE)"
        'identifier = doc.MRNNo
        r += 1
        xlPk.Workbook.Calculate
      Next
    End With




    'Dim xlWSB As ExcelWorksheet = xlPk.Workbook.Worksheets("ERPLN_GR_IR_DATA")
    'Dim oDocsb As List(Of MRNBReportClass) = MRNBReportClass.GetBaanData(FromDate, ToDate, project)
    'Dim rb As Integer = 2
    'Dim cb As Integer = 2
    'Dim sb As Integer = 1
    'Dim identifierb As String = ""
    'xlWS.Cells(2, 2).Value = Now
    'xlWSB.Cells(3, 2).Value = "MRN Report From " & FromDate & " TO " & ToDate
    'With xlWSB
    '  For Each docb As MRNBReportClass In oDocsb
    '    If rb > 2 Then
    '      xlWSB.InsertRow(rb, 1, rb + 1)
    '    End If
    '    cb = 2

    '    If identifier <> doc.Projectno Then
    '      .Cells(rb, 1).Value = sb

    '      xlWS.Cells(r, 2).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
    '      xlWS.Cells(r, 2).Style.Fill.BackgroundColor.SetColor(Color.Orange)
    '      sb = sb + 1
    '      c = c + 1
    '      .Cells(rb, 3).Value = docb.ProjectID
    '      xlWS.Cells(r, 3).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
    '      xlWS.Cells(r, 3).Style.Fill.BackgroundColor.SetColor(Color.Orange)

    '      .Cells(rb, 2).Value = docb.GRNO

    '      .Cells(rb, 3).Value = docb.GRDate

    '      .Cells(rb, 4).Value = docb.BPID

    '      .Cells(rb, 5).Value = docb.BPName

    '      .Cells(rb, 6).Value = docb.IRNO

    '      .Cells(rb, 7).Value = docb.IRDate

    '      identifierb = docb.GRNO
    '      rb += 1

    '  Next
    'End With

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
Public Class DMRNReportClass




  Private _GRNo As String = ""
  Public Property GRNo() As String
    Get
      Return _GRNo
    End Get
    Set(ByVal value As String)
      _GRNo = value
    End Set
  End Property


  Private _GRDate As String = ""
  Public Property GRDate() As String
    Get
      Return _GRDate
    End Get
    Set(ByVal value As String)
      _GRDate = value
    End Set
  End Property


  Private _IRNo As String = ""
  Public Property IRNo() As String
    Get
      Return _IRNo
    End Get
    Set(ByVal value As String)
      _IRNo = value
    End Set
  End Property




  Private _IRDate As String = ""
  Public Property IRDate() As String
    Get
      Return _IRDate
    End Get
    Set(ByVal value As String)
      _IRDate = value
    End Set
  End Property



  Private _SupplierID As String = ""
  Public Property SupplierID() As String
    Get
      Return _SupplierID
    End Get
    Set(ByVal value As String)
      _SupplierID = value
    End Set
  End Property






  Private _SupplierName As String = ""
  Public Property SupplierName() As String
    Get
      Return _SupplierName
    End Get
    Set(ByVal value As String)
      _SupplierName = value
    End Set
  End Property


  Private _SupplierBillNo As String = ""
  Public Property SupplierBillNo() As String
    Get
      Return _SupplierBillNo
    End Get
    Set(ByVal value As String)
      _SupplierBillNo = value
    End Set
  End Property

  Private _SupplierBillDate As String = ""
  Public Property SupplierBillDate() As String
    Get
      Return _SupplierBillDate
    End Get
    Set(ByVal value As String)
      _SupplierBillDate = value
    End Set
  End Property


  Private _BillAmount As String = ""
  Public Property BillAmount() As String
    Get
      Return _BillAmount
    End Get
    Set(ByVal value As String)
      _BillAmount = value
    End Set
  End Property

  Private _BillTypeDescription As String = ""
  Public Property BillTypeDescription() As String
    Get
      Return _BillTypeDescription
    End Get
    Set(ByVal value As String)
      _BillTypeDescription = value
    End Set
  End Property


  Private _ProjectID As String = ""
  Public Property ProjectID() As String
    Get
      Return _ProjectID
    End Get
    Set(ByVal value As String)
      _ProjectID = value
    End Set
  End Property


  Private _ProjectName As String = ""
  Public Property ProjectName() As String
    Get
      Return _ProjectName
    End Get
    Set(ByVal value As String)
      _ProjectName = value
    End Set
  End Property


  Private _PONumber As String = ""
  Public Property PONumber() As String
    Get
      Return _PONumber
    End Get
    Set(ByVal value As String)
      _PONumber = value
    End Set
  End Property



  Private _OtherBillType As String = ""
  Public Property OtherBillType() As String
    Get
      Return _OtherBillType
    End Get
    Set(ByVal value As String)
      _OtherBillType = value
    End Set
  End Property


  Private _VehicleExeNo As String = ""
  Public Property VehicleExeNo() As String
    Get
      Return _VehicleExeNo
    End Get
    Set(ByVal value As String)
      _VehicleExeNo = value
    End Set
  End Property




  Private _MRNNo As String = ""
  Public Property MRNNo() As String
    Get
      Return _MRNNo
    End Get
    Set(ByVal value As String)
      _MRNNo = value
    End Set
  End Property




  Private _CreatedByID As String = ""
  Public Property CreatedByID() As String
    Get
      Return _CreatedByID
    End Get
    Set(ByVal value As String)
      _CreatedByID = value
    End Set
  End Property

  Private _CreatedOn As String = ""
  Public Property CreatedOn() As String
    Get
      Return _CreatedOn
    End Get
    Set(ByVal value As String)
      _CreatedOn = value
    End Set
  End Property

  Private _Status As String = ""
  Public Property Status() As String
    Get
      Return _Status
    End Get
    Set(ByVal value As String)
      _Status = value
    End Set
  End Property

  Private _CreatedByName As String = ""
  Public Property CreatedByName() As String
    Get
      Return _CreatedByName
    End Get
    Set(ByVal value As String)
      _CreatedByName = value
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
  Public Shared Function GetData(ByVal project As String) As List(Of DMRNReportClass)

    Dim Sql As String = ""
    Sql &= "  SELECT "
    Sql &= "   * "
    Sql &= "   FROM ELOG_DetentionBill_Report"
    Sql &= "  WHERE"
    '  Sql &= "  ([MRNDate] >= convert(datetime,'" & FromDate & "', 103)  AND [MRNDate] <= convert(datetime,'" & ToDate & "', 103))"
    Sql &= " [ProjectID] = '" & project & "' "
    ' Sql &= "  ORDER BY [MRNNo]"

    Return GetDMRNReportClass(Sql)
  End Function

  Private Shared Function GetDMRNReportClass(ByVal Sql As String) As List(Of DMRNReportClass)
    Dim Results As List(Of DMRNReportClass) = Nothing
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = Sql
        Cmd.CommandTimeout = 1200
        Results = New List(Of DMRNReportClass)
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        While (Reader.Read())
          Results.Add(New DMRNReportClass(Reader))
        End While
        Reader.Close()
      End Using
    End Using
    Return Results

  End Function



End Class



'Public Class MRNBReportClass





'  Private _ProjectID As String = ""
'  Public Property ProjectID() As String
'    Get
'      Return _ProjectID
'    End Get
'    Set(ByVal value As String)
'      _ProjectID = value
'    End Set
'  End Property


'  Private _BPID As String = ""
'  Public Property BPID() As String
'    Get
'      Return _BPID
'    End Get
'    Set(ByVal value As String)
'      _BPID = value
'    End Set
'  End Property



'  Private _BPName As String = ""
'  Public Property BPName() As String
'    Get
'      Return _BPName
'    End Get
'    Set(ByVal value As String)
'      _BPName = value
'    End Set
'  End Property



'  Private _IRNO As String = ""
'  Public Property IRNO() As String
'    Get
'      Return _IRNO
'    End Get
'    Set(ByVal value As String)
'      _IRNO = value
'    End Set
'  End Property

'  Private _IRDate As String = ""
'  Public Property IRDate() As String
'    Get
'      Return _IRDate
'    End Get
'    Set(ByVal value As String)
'      _IRDate = value
'    End Set
'  End Property


'  Private _GRNO As String = ""
'  Public Property GRNO() As String
'    Get
'      Return _GRNO
'    End Get
'    Set(ByVal value As String)
'      _GRNO = value
'    End Set
'  End Property


'  Private _GRDate As String = ""
'  Public Property GRDate() As String
'    Get
'      Return _GRDate
'    End Get
'    Set(ByVal value As String)
'      _GRDate = value
'    End Set
'  End Property




'  Public Sub New(ByVal Reader As SqlDataReader)
'    Try
'      For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
'        If pi.MemberType = Reflection.MemberTypes.Property Then
'          Try
'            Dim Found As Boolean = False
'            For I As Integer = 0 To Reader.FieldCount - 1
'              If Reader.GetName(I).ToLower = pi.Name.ToLower Then
'                Found = True
'                Exit For
'              End If
'            Next
'            If Found Then
'              If Convert.IsDBNull(Reader(pi.Name)) Then
'                Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
'                  Case "decimal"
'                    CallByName(Me, pi.Name, CallType.Let, "0.00")
'                  Case "bit"
'                    CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
'                  Case Else
'                    CallByName(Me, pi.Name, CallType.Let, String.Empty)
'                End Select
'              Else
'                CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
'              End If
'            End If
'          Catch ex As Exception
'          End Try
'        End If
'      Next
'    Catch ex As Exception
'    End Try
'  End Sub
'  Public Sub New()
'  End Sub

'  Public Shared Function GetBaanData(ByVal FromDate As String, ByVal ToDate As String, ByVal project As String) As List(Of MRNBReportClass)

'    Dim Sqlb As String = ""
'    Sqlb &= "  SELECT "
'    Sqlb &= "   * "
'    Sqlb &= "   FROM HK_GRIRREPORT"
'    Sqlb &= "  WHERE"
'    'Sql1 &= "  ([MRNDate] >= convert(datetime,'" & FromDate & "', 103)  AND [MRNDate] <= convert(datetime,'" & ToDate & "', 103))"
'    Sqlb &= "  [ProjectID] = '" & project & "' "
'    ' Sql &= "  ORDER BY [MRNNo]"

'    Return GetMRNBReportClass(Sqlb)
'  End Function



'  Private Shared Function GetMRNBReportClass(ByVal Sqlb As String) As List(Of MRNBReportClass)
'    Dim Resultsb As List(Of MRNBReportClass) = Nothing
'    Using Conb As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
'      Using Cmdb As SqlCommand = Conb.CreateCommand()
'        Cmdb.CommandType = CommandType.Text
'        Cmdb.CommandText = Sqlb
'        Cmdb.CommandTimeout = 1200
'        Resultsb = New List(Of MRNBReportClass)
'        Conb.Open()
'        Dim Readerb As SqlDataReader = Cmdb.ExecuteReader()
'        While (Readerb.Read())
'          Resultsb.Add(New MRNBReportClass(Readerb))
'        End While
'        Readerb.Close()
'      End Using
'    End Using
'    Return Resultsb

'  End Function
'End Class
