Imports System.Collections.Generic
Imports System.Xml
Partial Class PostBaaNVoucher
  Inherits SIS.SYS.GridBase
  Protected Sub DataDate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataDate.TextChanged
    Session("DataDate") = DataDate.Text
    VoucherDate.Text = DataDate.Text
  End Sub
  Protected Sub GridView1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Init
    DataClassName = "GnprkPostBaaNVoucher"
    SetGridView = GridView1
  End Sub
  Private Sub ToolBar0_1_Init(sender As Object, e As EventArgs) Handles ToolBar0_1.Init
    SetToolBar = ToolBar0_1
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    Dim oFYr As SIS.NPRK.nprkFinYears = SIS.NPRK.nprkFinYears.nprkFinYearsGetByID(HttpContext.Current.Session("FinYear"))
    MaskedEditValidatorDataDate.MinimumValue = Convert.ToDateTime(oFYr.StartDate).ToString("dd/MM/yyyy")
    If Now > Convert.ToDateTime(oFYr.EndDate) Then
      MaskedEditValidatorDataDate.MaximumValue = oFYr.EndDate
    Else
      MaskedEditValidatorDataDate.MaximumValue = Convert.ToDateTime(Session("Today")).ToString("dd/MM/yyyy")
    End If
    If Not Session("DataDate") Is Nothing Then
      DataDate.Text = Session("DataDate").ToString
    Else
      DataDate.Text = Convert.ToDateTime(Session("Today")).ToString("dd/MM/yyyy")
    End If
    Me.MaskedEditValidatorVoucherDate.MinimumValue = Me.MaskedEditValidatorDataDate.MinimumValue
    Me.MaskedEditValidatorVoucherDate.MaximumValue = Me.MaskedEditValidatorDataDate.MaximumValue
    Me.VoucherDate.Text = Me.DataDate.Text
  End Sub
  'Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound
  '  ShowTotals()
  'End Sub
  Private Sub ShowTotals()
    Dim AmtTot As Decimal = 0
    If GridView1.Rows.Count > 0 Then
      For Each oItm As GridViewRow In GridView1.Rows
        If IsNumeric(CType(oItm.Cells(7).Controls(1), Label).Text) Then
          AmtTot += Convert.ToDecimal(CType(oItm.Cells(7).Controls(1), Label).Text)
        End If
      Next
      Dim oFt As GridViewRow = GridView1.FooterRow
      oFt.Cells(1).Text = "TOTAL"
      oFt.Cells(7).Text = AmtTot.ToString
      oFt.Cells(7).CssClass = "alignright"

    End If
  End Sub
  Protected Sub CmdPost_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    Dim oLgrs As List(Of SIS.NPRK.nprkLedger) = SIS.NPRK.nprkLedger.GetLedgerToBePosted(0, 99999, "TranType", DataDate.Text)
    'Filter by User Choice

    For I As Integer = oLgrs.Count - 1 To 0 Step -1
      Dim oLgr As SIS.NPRK.nprkLedger = oLgrs(I)
      Select Case oLgr.TranType
        Case "CSH"
          If Not Me.chkCash24.Checked Then
            oLgrs.RemoveAt(I)
          End If
        Case "CS1"
          If Not Me.chkCash63.Checked Then
            oLgrs.RemoveAt(I)
          End If
        Case "JVR"
          If Not Me.chkCheque.Checked Then
            oLgrs.RemoveAt(I)
          End If
        Case "IMP"
          If Not Me.chkImprest.Checked Then
            oLgrs.RemoveAt(I)
          End If
      End Select
    Next
    If oLgrs.Count > 0 Then
      If ValidateData(oLgrs) Then
        'ProcessData(oLgrs)
        ProcessDataInforLN(oLgrs)
      End If
    End If
  End Sub
  Private Sub AddErr(ByVal mStr As String)
    Dim oRow As New TableRow
    Dim oCol As New TableCell
    oCol.Text = "* " & mStr
    oRow.Cells.Add(oCol)
    oRow.ForeColor = Drawing.Color.Red
    tblErr.Rows.Add(oRow)
  End Sub
  Private Function ValidateData(ByVal oLgrs As List(Of SIS.NPRK.nprkLedger)) As Boolean
    Dim tmpComp As String = ""
    If TextBoxReference.Text = String.Empty Then
      AddErr("Reference is empty.")
      Return False
    End If
    If oLgrs.Count <= 0 Then
      AddErr("No data found to be posted.")
      Return False
    End If

    Dim ErrorsFound As Boolean = False
    For Each oLgr As SIS.NPRK.nprkLedger In oLgrs
      Dim tmpEmp As SIS.NPRK.nprkEmployees = SIS.NPRK.nprkEmployees.nprkEmployeesGetByID(oLgr.EmployeeID)
      If tmpEmp.Company = "" Then
        ErrorsFound = True
        AddErr("Employee : " & oLgr.EmployeeID.ToString & " [" & tmpEmp.EmployeeName & "] Company is not defined.")
        Continue For
      End If
      If tmpEmp.Department = Nothing Then
        ErrorsFound = True
        AddErr("Employee : " & oLgr.EmployeeID.ToString & " [" & tmpEmp.EmployeeName & "] Department is not defined.")
        Continue For
      End If
      If oLgr.FK_PRK_Ledger_PRK_Perks.BaaNGL = "" Then
        ErrorsFound = True
        AddErr("Perk : " & oLgr.FK_PRK_Ledger_PRK_Perks.Description & " GL Code is not defined.")
        Continue For
      End If
    Next
    If ErrorsFound Then
      AddErr("There are Errors in some records. Do you still want to Post valid records ?")
      CmdCancel.Visible = True
      Me.CmdPost.Enabled = False
      Me.VoucherDate.Enabled = False
      Me.TextBoxVoucherSeries.Enabled = False
      Me.TextBoxReference.Enabled = False
      Me.DataDate.Enabled = False
      Return False
    End If
    Return True
  End Function
  Private Sub ProcessDataInforLN(ByVal oLgrs As List(Of SIS.NPRK.nprkLedger))

    Dim CardNo As String = Convert.ToInt32(HttpContext.Current.Session("LoginID").ToString)


    Dim mFileName As String = CardNo & "_" & Now.ToString.Replace("/", "").Replace(":", "").Replace(" ", "") & ".xml"

    Dim tmpDir As String = HttpContext.Current.Server.MapPath("~/..") & "App_Temp\TABill"
    If Not IO.Directory.Exists(tmpDir) Then
      IO.Directory.CreateDirectory(tmpDir)
      IO.Directory.CreateDirectory(tmpDir & "\s")
      IO.Directory.CreateDirectory(tmpDir & "\t")
    Else
      If Not IO.Directory.Exists(tmpDir & "\s") Then
        IO.Directory.CreateDirectory(tmpDir & "\s")
      End If
      If Not IO.Directory.Exists(tmpDir & "\t") Then
        IO.Directory.CreateDirectory(tmpDir & "\t")
      End If
    End If

    Dim oTW As IO.StreamWriter = New IO.StreamWriter((tmpDir & "\s\" & mFileName))
    oTW.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")
    Dim CreditAmount As Double = 0
    Dim CreditGL As String = ""
    Dim Company As String = ""
    Dim LineCount As Integer = 0
    '=========
    'CASH Vouchers
    If chkCash24.Checked Or chkCash63.Checked Then
      Dim VchType As String = oLgrs(0).TranType
      CreditGL = IIf(chkCash24.Checked, oLgrs(0).FK_PRK_Ledger_PRK_Perks.CreditGLForCash24, oLgrs(0).FK_PRK_Ledger_PRK_Perks.CreditGLForCash63)
      Company = "200"
      CreditAmount = 0
      oTW.WriteLine("<Companies>")
      oTW.WriteLine("  <Company name=""" & Company & """>")
      oTW.WriteLine("    <Lines>")
      For Each oLgr As SIS.NPRK.nprkLedger In oLgrs
        Dim Department As String = oLgr.FK_PRK_Ledger_PRK_Employees.Department.Replace("&", "&amp;")
        oTW.WriteLine("	     <Line PrkLedgerID=""" & oLgr.DocumentID & """  ProcessID="""" SerialNo="""" BatchNo="""" DocumentNo="""" LineNo="""" GetBatchDocument=""" & Company & "," & "20" & "," & VoucherDate.Text & "," & "[ProcessID]" & "," & "[SerialNo]" & """>" & Company & "," & oLgr.FK_PRK_Ledger_PRK_Employees.Company & "," & "20" & "," & VoucherDate.Text & "," & "[ProcessID]" & "," & "" & "," & "" & "," & oLgr.TranType & "," & "" & "," & oLgr.FK_PRK_Ledger_PRK_Perks.BaaNGL & "," & "" & "," & Department & "," & oLgr.EmployeeID & "," & "" & "," & "UP" & "," & "INR" & "," & (oLgr.Amount) * -1 & "," & "1" & "," & oLgr.Remarks & "," & CardNo & "," & "1.00" & "</Line>")
        CreditAmount += oLgr.Amount
      Next
      oTW.WriteLine("	     <CreditLine>" & Company & "," & Company & "," & "20" & "," & VoucherDate.Text & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VchType & "," & "" & "," & CreditGL & "," & "" & "," & "OTHERS" & "," & "9999" & "," & "" & "," & "UP" & "," & "INR" & "," & (CreditAmount) * -1 & "," & "2" & "," & "by system" & "," & CardNo & "," & "1.00" & "</CreditLine>")
      oTW.WriteLine("    </Lines>")
      oTW.WriteLine("    <Batch>" & Company & "," & "20" & "," & VoucherDate.Text & "," & "[ProcessID]" & "," & oLgrs(0).TranType & "</Batch>")
      oTW.WriteLine("    <Errors><Error></Error></Errors>")
      oTW.WriteLine("  </Company>")
      oTW.WriteLine("</Companies>")
      '==========
      'JVR Vouchers
    ElseIf chkCheque.Checked Or chkImprest.Checked Then
      Dim aCompanies() As String = ConfigurationManager.AppSettings.GetValues("IsgecCompanies")(0).ToString.Split(",".ToCharArray)
      oTW.WriteLine("<Companies>")
      For Each Company In aCompanies
        LineCount = 0
        For Each oLgr As SIS.NPRK.nprkLedger In oLgrs
          If oLgr.FK_PRK_Ledger_PRK_Employees.Company <> Company Then Continue For
          LineCount += 1
        Next
        If LineCount <= 0 Then Continue For
        oTW.WriteLine("  <Company name=""" & Company & """>")
        CreditAmount = 0
        CreditGL = IIf(chkCheque.Checked, oLgrs(0).FK_PRK_Ledger_PRK_Perks.CreditGLForCheque, oLgrs(0).FK_PRK_Ledger_PRK_Perks.CreditGLForImprest)
        oTW.WriteLine("		<Lines>")
        For Each oLgr As SIS.NPRK.nprkLedger In oLgrs
          If oLgr.FK_PRK_Ledger_PRK_Employees.Company <> Company Then Continue For
          Dim Department As String = oLgr.FK_PRK_Ledger_PRK_Employees.Department.Replace("&", "&amp;")
          oTW.WriteLine("      <Line PrkLedgerID=""" & oLgr.DocumentID & """  ProcessID="""" SerialNo="""" BatchNo="""" DocumentNo="""" LineNo="""" GetBatchDocument=""" & Company & "," & "20" & "," & VoucherDate.Text & "," & "[ProcessID]" & "," & "[SerialNo]" & """>" & Company & "," & Company & "," & "20" & "," & VoucherDate.Text & "," & "[ProcessID]" & "," & "" & "," & "" & "," & "JVR" & "," & "" & "," & oLgr.FK_PRK_Ledger_PRK_Perks.BaaNGL & "," & "" & "," & Department & "," & oLgr.EmployeeID & "," & "" & "," & "UP" & "," & "INR" & "," & (oLgr.Amount) * -1 & "," & "1" & "," & oLgr.Remarks & "," & CardNo & "," & "1.00" & "</Line>")
          CreditAmount += oLgr.Amount
          LineCount += 1
        Next
        'Insert Credit Line
        oTW.WriteLine("      <CreditLine>" & Company & "," & Company & "," & "20" & "," & VoucherDate.Text & "," & "[ProcessID]" & "," & "" & "," & "" & "," & "JVR" & "," & "" & "," & CreditGL & "," & "" & "," & "OTHERS" & "," & "9999" & "," & "" & "," & "UP" & "," & "INR" & "," & (CreditAmount) * -1 & "," & "2" & "," & "by system" & "," & CardNo & "," & "1.00" & "</CreditLine>")
        oTW.WriteLine("    </Lines>")
        oTW.WriteLine("    <Batch>" & Company & "," & "20" & "," & VoucherDate.Text & "," & "[ProcessID]" & "," & oLgrs(0).TranType & "</Batch>")
        oTW.WriteLine("    <Errors><Error></Error></Errors>")
        oTW.WriteLine("  </Company>")
      Next '
      oTW.WriteLine("</Companies>")
    End If 'Cheque.Checked
    oTW.Close()
    Dim oTR As XmlDocument = New XmlDocument
    Dim TryCount As Integer = 0
    Dim ErrFound As Boolean = False
    Dim TryLimit As Integer = 150
    Do While True
      Try
        oTR.Load(tmpDir & "\t\P_" & mFileName)
        Exit Do
      Catch ex As Exception
        TryCount += 1
        Threading.Thread.Sleep(2000)
      End Try
      If TryCount >= TryLimit Then
        Exit Do
      End If
    Loop
    If TryCount < TryLimit Then
      'First check no error in xml
      For Each cmp As XmlNode In oTR.ChildNodes(1)
        Dim oErr As XmlNode = cmp.ChildNodes(2)
        For Each errchild As XmlNode In oErr.ChildNodes
          If errchild.InnerText <> String.Empty Then
            AddErr(errchild.InnerText)
            ErrFound = True
          End If
        Next
      Next
      If ErrFound Then
        'CmdContinue.Visible = True
        CmdCancel.Visible = True
        Me.CmdPost.Enabled = False
        Me.VoucherDate.Enabled = False
        Me.TextBoxVoucherSeries.Enabled = False
        Me.TextBoxReference.Enabled = False
        Me.DataDate.Enabled = False
      Else
        For Each cmp As XmlNode In oTR.ChildNodes(1)
          'Process for each company
          Dim oLines As XmlNode = cmp.ChildNodes(0)
          Dim oBatch As XmlNode = cmp.ChildNodes(1)
          Dim oErr As XmlNode = cmp.ChildNodes(2)
          For Each cmpChild As XmlNode In cmp.ChildNodes
            If cmpChild.Name.ToLower = "lines" Then
              For Each line As XmlNode In cmpChild.ChildNodes
                If line.Name.ToLower <> "creditline" Then
                  Dim PrkLedgerID As String = line.Attributes("PrkLedgerID").Value
                  For Each oLgr As SIS.NPRK.nprkLedger In oLgrs
                    If oLgr.DocumentID.ToString = PrkLedgerID Then
                      oLgr.BatchNo = line.Attributes("BatchNo").Value
                      oLgr.VoucherNo = line.Attributes("DocumentNo").Value
                      oLgr.VoucherLineNo = line.Attributes("LineNo").Value
                      oLgr.PostedInBaaN = True
                      oLgr.PostedOn = VoucherDate.Text
                      oLgr.PostedBy = CardNo
                      SIS.NPRK.nprkLedger.UpdateBaaNPosting(oLgr)
                      Exit For
                    End If
                  Next
                End If
              Next
              Exit For
            End If
          Next
        Next
        'Try
        '  UpdateBatchUser(mRet.BatchNo, UserId, VoucherDate, VoucherType)
        'Catch ex As Exception
        'End Try
      End If
      CmdCancel_Click(Nothing, Nothing)
      ObjectDataSource1.Select()
      GridView1.DataBind()
    End If

  End Sub
  'Private Shared Sub UpdateBatchUser(ByVal BatchNo As String, ByVal UserID As String, ByVal VchDate As String, ByVal VchType As String)
  '  Dim rYear As String = ""
  '  Dim Sql As String = ""
  '  Sql = " Select "
  '  Sql &= " t_year As BatchYear "
  '  Sql &= " From ttfgld100200 "
  '  Sql &= " Where t_btno = " & BatchNo
  '  Sql &= " and t_user = '0340'"
  '  Sql &= " and t_tedt = convert(datetime,'" & VchDate & "',103)"
  '  Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString)
  '    Using Cmd As SqlCommand = Con.CreateCommand()
  '      Cmd.CommandType = CommandType.Text
  '      Cmd.CommandText = Sql
  '      Con.Open()
  '      rYear = Cmd.ExecuteScalar
  '    End Using
  '    Sql = " update "
  '    Sql &= " ttfgld100200 "
  '    Sql &= " set t_user = '" & UserID & "'"
  '    Sql &= " Where t_btno = " & BatchNo
  '    Sql &= " and t_user = '0340'"
  '    Sql &= " and t_tedt = convert(datetime,'" & VchDate & "',103)"
  '    Using Cmd As SqlCommand = Con.CreateCommand()
  '      Cmd.CommandType = CommandType.Text
  '      Cmd.CommandText = Sql
  '      Cmd.ExecuteNonQuery()
  '    End Using
  '    Sql = " update "
  '    Sql &= " ttfgld101200 "
  '    Sql &= " set t_user = '" & UserID & "'"
  '    Sql &= " Where t_btno = " & BatchNo
  '    Sql &= " and t_user = '0340'"
  '    Sql &= " and t_year = " & rYear
  '    Sql &= " and t_ttyp = '" & VchType & "'"
  '    Using Cmd As SqlCommand = Con.CreateCommand()
  '      Cmd.CommandType = CommandType.Text
  '      Cmd.CommandText = Sql
  '      Cmd.ExecuteNonQuery()
  '    End Using
  '  End Using
  'End Sub
  Private Structure BaaNValues
    Dim BatchNo As String
    Dim TranType As String
    Dim DocNo As String
    Dim LineNo As String
  End Structure
  Private Function GetBaaNvalue(ByVal mStr As String) As BaaNValues
    Dim oBNVal As New BaaNValues
    Dim aStr() As String = mStr.Split("|".ToCharArray)
    With oBNVal
      Try
        .BatchNo = aStr(0)
        .TranType = aStr(1)
        .DocNo = aStr(2)
        .LineNo = aStr(3)
      Catch ex As Exception

      End Try
    End With
    Return oBNVal
  End Function
  Protected Sub CmdContinue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdContinue.Click
    Dim oLgrs As List(Of SIS.NPRK.nprkLedger) = SIS.NPRK.nprkLedger.GetLedgerToBePosted(0, 99999, "TranType", DataDate.Text)
    'ProcessDataInforLN(oLgrs)
    CmdCancel_Click(sender, e)
  End Sub
  Protected Sub CmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdCancel.Click
    tblErr.Rows.Clear()
    Me.CmdCancel.Visible = False
    Me.CmdContinue.Visible = False
    Me.CmdPost.Enabled = True
    Me.VoucherDate.Enabled = True
    Me.TextBoxVoucherSeries.Enabled = True
    Me.TextBoxReference.Enabled = True
    Me.DataDate.Enabled = True
  End Sub

  Private Sub GridView1_PreRender(sender As Object, e As EventArgs) Handles GridView1.PreRender
    ShowTotals()
  End Sub

  '  Private Sub ConvertSalaryData()

  '    Dim CardNo As String = HttpContext.Current.Session("LoginID").ToString

  '    Dim aSourceFiles() As String = IO.Directory.GetFiles(HttpContext.Current.Server.MapPath("~/App_Data/Source/"), "*.lst")
  '    Dim oVchs As New List(Of Vouchers)
  '    Dim FileNo As Integer = 0
  '    Dim SplitXML As Boolean = False
  '    Dim SplitStart As Integer = 0
  '    Dim SplitEnd As Integer = 2000
  '    For Each sFile As String In aSourceFiles
  '      If IO.Path.GetFileName(sFile).ToLower.StartsWith("ijt") Then
  '        SplitXML = True
  '      End If
  'ExecuteSplit:
  '      oVchs = New List(Of Vouchers)
  '      FileNo += 1
  '      Dim oTS As IO.StreamReader = New IO.StreamReader(sFile)
  '      Try
  '        Dim rStr As String = oTS.ReadLine
  '        Do While rStr IsNot Nothing
  '          If SplitXML Then
  '            If Convert.ToInt32(rStr.Substring(46, 6).Trim) < SplitStart Or Convert.ToInt32(rStr.Substring(46, 6).Trim) > SplitEnd Then
  '              rStr = oTS.ReadLine
  '              Continue Do
  '            End If
  '          End If
  '          Dim oVch As New Vouchers
  '          With oVch
  '            .BatchCompany = rStr.Substring(25, 3)
  '            .TargetCompany = rStr.Substring(25, 3)
  '            .ForSoftware = "10"
  '            .VoucherDate = rStr.Substring(109, 2) & "/" & rStr.Substring(111, 2) & "/20" & rStr.Substring(113, 2)
  '            .ProcessID = ""
  '            .SerialNo = rStr.Substring(19, 6)
  '            .BusinessPartner = ""
  '            .TranType = "JVN"
  '            .Series = ""
  '            .LedgerAc = rStr.Substring(28, 12)
  '            .Dim1 = ""
  '            .Dim2 = rStr.Substring(40, 6).ToUpper
  '            .Dim3 = rStr.Substring(46, 6).Trim
  '            Try
  '              .Dim4 = rStr.Substring(126, 6)
  '            Catch ex As Exception
  '            End Try
  '            .Dim5 = ""
  '            .Currency = "INR"
  '            .Amount = rStr.Substring(52, 20)
  '            .DrCr = IIf(rStr.Substring(72, 1) = "C", 2, 1)
  '            .Remarks = rStr.Substring(73, 30).Replace(",", " ")
  '            .CreatedBy = CardNo
  '            .BatchNo = ""
  '            .DocumentNo = ""
  '            .LineNo = ""
  '            .DocumentID = ""
  '          End With
  '          oVchs.Add(oVch)
  '          rStr = oTS.ReadLine
  '        Loop
  '      Catch ex As Exception
  '      End Try
  '      oTS.Close()
  '      If oVchs.Count > 0 Then
  '        WriteSalaryXML(oVchs, FileNo, IO.Path.GetFileNameWithoutExtension(sFile))
  '      End If
  '      If SplitXML Then
  '        SplitStart = SplitEnd + 1
  '        SplitEnd += 7999
  '        If SplitEnd > 10000 Then
  '          Continue For
  '        End If
  '        GoTo ExecuteSplit
  '      End If
  '    Next
  '  End Sub
  '  Private Sub WriteSalaryXML(ByVal oVchs As List(Of Vouchers), ByVal FileNo As String, ByVal FName As String)
  '    Dim mFileName As String = "Salary_" & FileNo & "_" & FName.ToUpper & ".xml"
  '    Dim oTW As IO.StreamWriter = New IO.StreamWriter(HttpContext.Current.Server.MapPath("~/App_Data/Source/") & mFileName)
  '    oTW.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")

  '    oTW.WriteLine("<Companies>")
  '    oTW.WriteLine("  <Company name=""" & oVchs(0).BatchCompany & """>")
  '    oTW.WriteLine("  <Lines>")
  '    For Each oVch As Vouchers In oVchs
  '      oTW.WriteLine("      <Line PrkLedgerID=""" & oVch.DocumentID & """  ProcessID="""" SerialNo="""" BatchNo="""" DocumentNo="""" LineNo="""" GetBatchDocument=""" & oVch.BatchCompany & "," & oVch.ForSoftware & "," & oVch.VoucherDate & "," & "[ProcessID]" & "," & "[SerialNo]" & """>" & oVch.BatchCompany & "," & oVch.TargetCompany & "," & oVch.ForSoftware & "," & oVch.VoucherDate & "," & "[ProcessID]" & "," & oVch.SerialNo & "," & oVch.BusinessPartner & "," & oVch.TranType & "," & oVch.Series & "," & oVch.LedgerAc & "," & oVch.Dim1 & "," & oVch.Dim2 & "," & oVch.Dim3 & "," & oVch.Dim4 & "," & oVch.Dim5 & "," & oVch.Currency & "," & (oVch.Amount) & "," & oVch.DrCr & "," & oVch.Remarks & "," & oVch.CreatedBy & "</Line>")
  '    Next
  '    oTW.WriteLine("    </Lines>")
  '    oTW.WriteLine("    <Batch>" & oVchs(0).BatchCompany & "," & oVchs(0).ForSoftware & "," & oVchs(0).VoucherDate & "," & "[ProcessID]" & "," & oVchs(0).TranType & "</Batch>")
  '    oTW.WriteLine("    <Errors><Error></Error></Errors>")
  '    oTW.WriteLine("  </Company>")
  '    oTW.WriteLine("</Companies>")
  '    oTW.Close()

  '    'Update Back
  '    'Dim oTR As XmlDocument = New XmlDocument
  '    'Dim TryCount As Integer = 0
  '    'Do While True
  '    '	Try
  '    '		oTR.Load(HttpContext.Current.Server.MapPath("~/App_Data/Target/P_") & mFileName)
  '    '		Exit Do
  '    '	Catch ex As Exception
  '    '		TryCount += 1
  '    '		Threading.Thread.Sleep(2000)
  '    '	End Try
  '    '	If TryCount >= 20 Then
  '    '		Exit Do
  '    '	End If
  '    'Loop
  '    'If TryCount < 20 Then
  '    '	'First check no error in xml
  '    '	Dim ErrFound As Boolean = False
  '    '	For Each cmp As XmlNode In oTR.ChildNodes(1)
  '    '		Dim oErr As XmlNode = cmp.ChildNodes(2)
  '    '		For Each errchild As XmlNode In oErr.ChildNodes
  '    '			If errchild.InnerText <> String.Empty Then
  '    '				AddErr(errchild.InnerText)
  '    '				ErrFound = True
  '    '			End If
  '    '		Next
  '    '	Next
  '    '	If ErrFound Then
  '    '		'CmdContinue.Visible = True
  '    '		CmdCancel.Visible = True
  '    '		Me.CmdPost.Enabled = False
  '    '		Me.VoucherDate.Enabled = False
  '    '		Me.TextBoxVoucherSeries.Enabled = False
  '    '		Me.TextBoxReference.Enabled = False
  '    '		Me.DataDate.Enabled = False
  '    '	Else
  '    '		For Each cmp As XmlNode In oTR.ChildNodes(1)
  '    '			'Process for each company
  '    '			Dim oLines As XmlNode = cmp.ChildNodes(0)
  '    '			Dim oBatch As XmlNode = cmp.ChildNodes(1)
  '    '			Dim oErr As XmlNode = cmp.ChildNodes(2)
  '    '			For Each cmpChild As XmlNode In cmp.ChildNodes
  '    '				If cmpChild.Name.ToLower = "lines" Then
  '    '					For Each line As XmlNode In cmpChild.ChildNodes
  '    '						If line.Name.ToLower <> "creditline" Then
  '    '							Dim PrkLedgerID As String = line.Attributes("PrkLedgerID").Value
  '    '							For Each oLgr As SIS.PRK.PrkLedger In oLgrs
  '    '								If oLgr.DocumentID.ToString = PrkLedgerID Then
  '    '									oLgr.BatchNo = line.Attributes("BatchNo").Value
  '    '									oLgr.VoucherNo = line.Attributes("DocumentNo").Value
  '    '									oLgr.VoucherLineNo = line.Attributes("LineNo").Value
  '    '									oLgr.PostedInBaaN = True
  '    '									oLgr.PostedOn = VoucherDate.Text
  '    '									oLgr.PostedBy = CardNo
  '    '									SIS.PRK.PrkLedger.UpdateBaaNPosting(oLgr)
  '    '									Exit For
  '    '								End If
  '    '							Next
  '    '						End If
  '    '					Next
  '    '					Exit For
  '    '				End If
  '    '			Next
  '    '		Next
  '    '	End If
  '    '	CmdCancel_Click(Nothing, Nothing)
  '    '	ObjectDataSource1.Select()
  '    '	GridView1.DataBind()
  '    'End If

  '  End Sub

  'Private Sub ConvertSalaryData(ByVal FinYear As String, ByVal mMonth As String)

  '	Dim CardNo As String = HttpContext.Current.Session("LoginID").ToString

  '	Dim aSourceFiles() As String = IO.Directory.GetFiles(HttpContext.Current.Server.MapPath("~/App_Data/Source/"), ".lst")
  '	Dim oVchs As New List(Of Vouchers)
  '	For Each sFile As String In aSourceFiles
  '		'Assumed there will be only one file at a time, otherwise output xml file name should be different
  '		Dim mTFileName As String = mMonth & "_" & Now.ToString.Replace("/", "").Replace(":", "").Replace(" ", "") & ".xml"
  '		Dim oTS As IO.StreamReader = New IO.StreamReader(sFile)
  '		Dim rStr As String = oTS.ReadLine
  '		Do While rStr IsNot Nothing
  '			Dim oVch As New Vouchers
  '			With oVch
  '				.BatchCompany = rStr.Substring(25, 3)
  '				.ForSoftware = "10"
  '				.ProcessID = ""
  '				.VoucherDate = rStr.Substring(109, 2) & "/" & rStr.Substring(111, 2) & "/20" & rStr.Substring(113, 2)
  '				.SerialNo = rStr.Substring(19, 6)
  '				.LedgerAc = rStr.Substring(28, 12)
  '				.Dim1 = ""
  '				.Dim2 = rStr.Substring(40, 6)
  '				.Dim3 = rStr.Substring(46, 6).Trim.PadLeft(4, "0")
  '				.Dim4 = ""
  '				.Dim5 = ""
  '				.Currency = "INR"
  '				.Amount = rStr.Substring(52, 20)
  '				.DrCr = IIf(rStr.Substring(72, 1) = "C", 2, 1)
  '				.TargetCompany = rStr.Substring(25, 3)
  '				.Remarks = rStr.Substring(73, 30)
  '				.TranType = "JVN"
  '				.Series = ""
  '				.CreatedBy = CardNo
  '				.BatchNo = ""
  '				.DocumentNo = ""
  '				.LineNo = ""
  '				.DocumentID = ""
  '			End With
  '			oVchs.Add(oVch)
  '		Loop
  '	Next

  '	Dim aCompanies() As String = "200,400".Split(",".ToCharArray)
  '	oTW.WriteLine("<Companies>")
  '	For Each Company In aCompanies
  '		LineCount = 0
  '		For Each oLgr As SIS.PRK.PrkLedger In oLgrs
  '			If oLgr.EmployeeIDPRK_Employees.Company <> Company Then Continue For
  '			LineCount += 1
  '		Next
  '		If LineCount <= 0 Then Continue For
  '		oTW.WriteLine("  <Company name=""" & Company & """>")
  '		CreditAmount = 0
  '		CreditGL = IIf(chkCheque.Checked, oLgrs(0).PerkIDPRK_Perks.CreditGLForCheque, oLgrs(0).PerkIDPRK_Perks.CreditGLForImprest)
  '		oTW.WriteLine("		<Lines>")
  '		For Each oLgr As SIS.PRK.PrkLedger In oLgrs
  '			If oLgr.EmployeeIDPRK_Employees.Company <> Company Then Continue For
  '			oTW.WriteLine("      <Line PrkLedgerID=""" & oLgr.DocumentID & """  ProcessID="""" SerialNo="""" BatchNo="""" DocumentNo="""" LineNo="""" GetBatchDocument=""" & Company & "," & "20" & "," & VoucherDate.Text & "," & "[ProcessID]" & "," & "[SerialNo]" & """>" & Company & "," & Company & "," & "20" & "," & VoucherDate.Text & "," & "[ProcessID]" & "," & "" & "," & "" & "," & "JVR" & "," & "" & "," & oLgr.PerkIDPRK_Perks.BaaNGL & "," & "" & "," & oLgr.EmployeeIDPRK_Employees.Department & "," & oLgr.EmployeeID & "," & "" & "," & "" & "," & "INR" & "," & (oLgr.Amount) * -1 & "," & "1" & "," & oLgr.Remarks & "," & CardNo & "</Line>")
  '			CreditAmount += oLgr.Amount
  '			LineCount += 1
  '		Next
  '		'Insert Credit Line
  '		oTW.WriteLine("      <CreditLine>" & Company & "," & Company & "," & "20" & "," & VoucherDate.Text & "," & "[ProcessID]" & "," & "" & "," & "" & "," & "JVR" & "," & "" & "," & CreditGL & "," & "" & "," & "OTHERS" & "," & "9999" & "," & "" & "," & "" & "," & "INR" & "," & (CreditAmount) * -1 & "," & "2" & "," & "by system" & "," & CardNo & "</CreditLine>")
  '		oTW.WriteLine("    </Lines>")
  '		oTW.WriteLine("    <Batch>" & Company & "," & "20" & "," & VoucherDate.Text & "," & "[ProcessID]" & "," & oLgrs(0).TranType & "</Batch>")
  '		oTW.WriteLine("    <Errors><Error></Error></Errors>")
  '		oTW.WriteLine("  </Company>")
  '	Next '
  '	oTW.WriteLine("</Companies>")

  '	oTW.Close()
  '	Dim oTR As XmlDocument = New XmlDocument
  '	Dim TryCount As Integer = 0
  '	Do While True
  '		Try
  '			oTR.Load(HttpContext.Current.Server.MapPath("~/App_Data/Target/P_") & mFileName)
  '			Exit Do
  '		Catch ex As Exception
  '			TryCount += 1
  '			Threading.Thread.Sleep(2000)
  '		End Try
  '		If TryCount >= 20 Then
  '			Exit Do
  '		End If
  '	Loop
  '	If TryCount < 20 Then
  '		'First check no error in xml
  '		Dim ErrFound As Boolean = False
  '		For Each cmp As XmlNode In oTR.ChildNodes(1)
  '			Dim oErr As XmlNode = cmp.ChildNodes(2)
  '			For Each errchild As XmlNode In oErr.ChildNodes
  '				If errchild.InnerText <> String.Empty Then
  '					AddErr(errchild.InnerText)
  '					ErrFound = True
  '				End If
  '			Next
  '		Next
  '		If ErrFound Then
  '			'CmdContinue.Visible = True
  '			CmdCancel.Visible = True
  '			Me.CmdPost.Enabled = False
  '			Me.VoucherDate.Enabled = False
  '			Me.TextBoxVoucherSeries.Enabled = False
  '			Me.TextBoxReference.Enabled = False
  '			Me.DataDate.Enabled = False
  '		Else
  '			For Each cmp As XmlNode In oTR.ChildNodes(1)
  '				'Process for each company
  '				Dim oLines As XmlNode = cmp.ChildNodes(0)
  '				Dim oBatch As XmlNode = cmp.ChildNodes(1)
  '				Dim oErr As XmlNode = cmp.ChildNodes(2)
  '				For Each cmpChild As XmlNode In cmp.ChildNodes
  '					If cmpChild.Name.ToLower = "lines" Then
  '						For Each line As XmlNode In cmpChild.ChildNodes
  '							If line.Name.ToLower <> "creditline" Then
  '								Dim PrkLedgerID As String = line.Attributes("PrkLedgerID").Value
  '								For Each oLgr As SIS.PRK.PrkLedger In oLgrs
  '									If oLgr.DocumentID.ToString = PrkLedgerID Then
  '										oLgr.BatchNo = line.Attributes("BatchNo").Value
  '										oLgr.VoucherNo = line.Attributes("DocumentNo").Value
  '										oLgr.VoucherLineNo = line.Attributes("LineNo").Value
  '										oLgr.PostedInBaaN = True
  '										oLgr.PostedOn = VoucherDate.Text
  '										oLgr.PostedBy = CardNo
  '										SIS.PRK.PrkLedger.UpdateBaaNPosting(oLgr)
  '										Exit For
  '									End If
  '								Next
  '							End If
  '						Next
  '						Exit For
  '					End If
  '				Next
  '			Next
  '		End If
  '		CmdCancel_Click(Nothing, Nothing)
  '		ObjectDataSource1.Select()
  '		GridView1.DataBind()
  '	End If

  'End Sub
  Private Class Vouchers
    Public BatchCompany As String
    Public ForSoftware As String
    Public ProcessID As String  ' Unique Number will be returned from BaaN, to use in subsiquent line
    Public VoucherDate As String
    Public SerialNo As String ' Will be returned from BaaN
    Public BusinessPartner As String
    Public LedgerAc As String
    Public Dim1 As String
    Public Dim2 As String
    Public Dim3 As String
    Public Dim4 As String
    Public Dim5 As String
    Public Currency As String 'INR
    Public Amount As String
    Public DrCr As String '1-Debit, 2-Credit
    Public TargetCompany As String 'Employees Company in case of Cash Vch
    Public Remarks As String '32 Chars
    Public TranType As String 'JVR,CSH,CS1, IMprest
    Public Series As String 'Blank to use default series from BaaN else specify to use series
    Public CreatedBy As String 'LoginID of voucher posting user
    Public BatchNo As String 'Will be returned from BaaN
    Public DocumentNo As String 'Will be returned from BaaN
    Public LineNo As String 'Will be returned from BaaN
    Public ConversionFactor As Decimal = 1.0
    'Added Fields
    Public DocumentID As String

  End Class

  'Protected Sub cmdSalaryPosting_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSalaryPosting.Click
  '  ConvertSalaryData()
  'End Sub

End Class
