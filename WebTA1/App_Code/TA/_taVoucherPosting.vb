Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Xml
Namespace SIS.TA
  Public Class taPostVoucherResult
    Public Property IsError As Boolean = False
    Public Property Message As String = ""
    Public Property BatchNo As String = ""
    Public Property DocumentNo As String = ""
    Public Property LineNo As String = ""
    Public Property VoucherType As String = ""
    Public Property VoucherCompany As String = ""
  End Class
  Public Class prjCmpActERP
    Public Property ProjectID As String = ""
    Public Property Company As String = ""
    Public Property Activity As String = ""
    Public Property Element As String = "99080500"
    Public Property SubContracting As String = "DPOH"
  End Class
  Public Class taVoucher
    Private Shared Sub UpdateBatchUser(ByVal BatchNo As String, ByVal UserID As String, ByVal VchDate As String, ByVal VchType As String)
      Dim rYear As String = ""
      Dim Sql As String = ""
      Sql = " Select "
      Sql &= " t_year As BatchYear "
      Sql &= " From ttfgld100200 "
      Sql &= " Where t_btno = " & BatchNo
      Sql &= " and t_user = '0340'"
      Sql &= " and t_tedt = convert(datetime,'" & VchDate & "',103)"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          rYear = Cmd.ExecuteScalar
        End Using
        Sql = " update "
        Sql &= " ttfgld100200 "
        Sql &= " set t_user = '" & UserID & "'"
        Sql &= " Where t_btno = " & BatchNo
        Sql &= " and t_user = '0340'"
        Sql &= " and t_tedt = convert(datetime,'" & VchDate & "',103)"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.ExecuteNonQuery()
        End Using
        Sql = " update "
        Sql &= " ttfgld101200 "
        Sql &= " set t_user = '" & UserID & "'"
        Sql &= " Where t_btno = " & BatchNo
        Sql &= " and t_user = '0340'"
        Sql &= " and t_year = " & rYear
        Sql &= " and t_ttyp = '" & VchType & "'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Cmd.ExecuteNonQuery()
        End Using
      End Using
    End Sub

    Private Shared Function GetProjectCompanyFromERP(ByVal ProjectID As String) As prjCmpActERP
      Dim mRet As SIS.TA.prjCmpActERP = Nothing
      Dim Sql As String = ""
      Sql = " Select "
      Sql &= " t_ncmp As Company "
      Sql &= " ,t_rsac As Activity "
      Sql &= " From ttppdm600200 "
      Sql &= " Where t_cprj = '" & ProjectID & "'"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim rd As SqlDataReader = Cmd.ExecuteReader
          If rd.Read Then
            mRet = New prjCmpActERP
            mRet.ProjectID = ProjectID
            mRet.Company = rd("Company")
            mRet.Activity = rd("Activity")
          End If
        End Using
      End Using
      Return mRet
    End Function
    Public Shared Function PostVoucher(ByVal BillNo As Integer, ByVal VCHOn As String) As taPostVoucherResult
      Dim UserId As String = HttpContext.Current.Session("LoginID")
      Dim aVal() As String = VCHOn.Split(",".ToCharArray)
      Dim Element As String = "99080500"
      VCHOn = aVal(0)
      Dim mRet As New taPostVoucherResult
      Dim VoucherDate As String = ""
      Dim VoucherType As String = ""
      Try
        Dim sTA As SIS.TA.taBH = SIS.TA.taBH.taBHGetByID(BillNo)
        'Default Values
        With sTA
          If aVal(1) <> String.Empty Then
            .DepartmentID = aVal(1)
          End If
          If aVal(2) <> String.Empty Then
            .CostCenterID = aVal(2)
          End If
        End With
        If aVal(3) <> String.Empty Then
          Element = aVal(3)
        End If
        'check state the create
        Dim sBil As List(Of SIS.TA.taBillDetails) = SIS.TA.taBillDetails.taBillDetailsSelectList(0, 9999, "", False, "", BillNo)
        Dim sPrj As List(Of SIS.TA.taBillPrjAmounts) = SIS.TA.taBillPrjAmounts.taBillPrjAmountsSelectList(0, 9999, "", False, "", BillNo)
        Dim sAmt As List(Of SIS.TA.taBillAmount) = SIS.TA.taBillAmount.taBillAmountSelectList(0, 9999, "", False, "", BillNo)

        Dim CardNo As String = Convert.ToInt32(HttpContext.Current.Session("LoginID"))

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

        Dim oTW As IO.StreamWriter = New IO.StreamWriter(tmpDir & "\s\" & mFileName)
        oTW.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")
        Dim CreditGL As String = ""
        Dim DebitGL As String = ""
        Dim GSTGL As String = ""
        Dim Company As String = "200"
        Dim LineCount As Integer = 0
        'Dim sn As Integer = 0
        Dim Remarks As String = ""
        VoucherDate = IIf(VCHOn = "", Now.Date, VCHOn)
        VoucherType = "JVN"
        Dim IsProject As Boolean = IIf(sPrj.Count > 0, True, False)
        CreditGL = "1550263" 'Imprest
        GSTGL = "1550648"
        '==============Remarks================
        Dim RemarksFound As Boolean = False
        Dim FromCity As String = ""
        Dim ToCity As String = ""
        Dim TravelSpan As String = ""
        '1. Check Fare Record
        For Each tmp As SIS.TA.taBillDetails In sBil
          Select Case tmp.ComponentID
            Case TAComponentTypes.Fare
              RemarksFound = True
              If tmp.City1ID <> String.Empty Then
                FromCity = Left(tmp.City1ID, 3) & Right(tmp.City1ID, 2)
              Else
                FromCity = Left(tmp.City1Text, 3) & "--"
              End If
              If tmp.City2ID <> String.Empty Then
                ToCity = Left(tmp.City2ID, 3) & Right(tmp.City2ID, 2)
              Else
                ToCity = Left(tmp.City2Text, 3) & "--"
              End If
              Exit For
          End Select
        Next
        If Not RemarksFound Then
          For Each tmp As SIS.TA.taBillDetails In sBil
            Select Case tmp.ComponentID
              Case TAComponentTypes.Mileage
                RemarksFound = True
                If tmp.City1ID <> String.Empty Then
                  FromCity = Left(tmp.City1ID, 3) & Right(tmp.City1ID, 2)
                Else
                  FromCity = Left(tmp.City1Text, 3) & "--"
                End If
                If tmp.City2ID <> String.Empty Then
                  ToCity = Left(tmp.City2ID, 3) & Right(tmp.City2ID, 2)
                Else
                  ToCity = Left(tmp.City2Text, 3) & "--"
                End If
                Exit For
            End Select
          Next
        End If
        If Not RemarksFound Then
          For Each tmp As SIS.TA.taBillDetails In sBil
            Select Case tmp.ComponentID
              Case TAComponentTypes.Lodging
                RemarksFound = True
                If tmp.City1ID <> String.Empty Then
                  FromCity = Left(tmp.City1ID, 3) & Right(tmp.City1ID, 2)
                Else
                  FromCity = Left(tmp.City1Text, 3) & "--"
                End If
                Exit For
            End Select
          Next
        End If
        TravelSpan = Convert.ToDateTime(sTA.StartDateTime).ToString("dd/MM") & "-" & Convert.ToDateTime(sTA.EndDateTime).ToString("dd/MM/yy")
        Remarks = "TA/" & FromCity & "/" & ToCity & "/" & TravelSpan
        Select Case sTA.TravelTypeID
          Case TATravelTypeValues.Domestic, TATravelTypeValues.HomeVisit
            VoucherType = "JVN"
            If IsProject Then
              DebitGL = "6150411"
            Else
              DebitGL = "6515721"
            End If
          Case Else
            VoucherType = "JVF"
            If IsProject Then
              DebitGL = "6150424"
            Else
              DebitGL = "6515738"
            End If
        End Select
        '=============VCHPosting===================
        Dim xmlDepartment As String = sTA.DepartmentID.Replace("&", "&amp;")
        Dim xmlCostCenter As String = sTA.CostCenterID.Replace("&", "&amp;")
        '==========================================================
        If IsProject Then
          oTW.WriteLine("<Companies>")
          oTW.WriteLine("  <Company name=""" & Company & """  IsProject=""" & IIf(IsProject, "True", "False") & """>")
          oTW.WriteLine("		<Lines>")
          Select Case sTA.TravelTypeID
            Case TATravelTypeValues.ForeignTravel, TATravelTypeValues.ForeignSiteVisit
              For Each tmp As SIS.TA.taBillAmount In sAmt
                If tmp.ComponentID = TAComponentTypes.Total AndAlso tmp.CurrencyID <> "INR" Then
                  'insert Debit Line IN FC Project Wise
                  For Each ptmp As SIS.TA.taBillPrjAmounts In sPrj
                    Dim prjCA As SIS.TA.prjCmpActERP = GetProjectCompanyFromERP(ptmp.ProjectID)
                    Dim prjAmtInCur As Decimal = (tmp.TotalInCurrency * ptmp.Percentage) / 100
                    oTW.WriteLine("      <Line PrkLedgerID=""" & sTA.TABillNo & """  ProcessID="""" SerialNo="""" BatchNo="""" DocumentNo="""" LineNo="""" GetBatchDocument=""" & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "[SerialNo]" & """>" & Company & "," & prjCA.Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & DebitGL & "," & ptmp.ProjectID & "," & xmlDepartment & "," & Convert.ToInt32(sTA.EmployeeID) & "," & "" & "," & "UP" & "," & tmp.CurrencyID & "," & (prjAmtInCur) & "," & "1" & "," & Remarks & "," & CardNo & "," & ptmp.ProjectID & "," & Element & "," & prjCA.Activity & "," & prjCA.SubContracting & "," & sTA.ConversionFactorINR & "</Line>")
                    LineCount += 1
                  Next
                  'Insert Credit Line in FC
                  oTW.WriteLine("      <CreditLine>" & Company & "," & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & CreditGL & "," & "" & "," & xmlDepartment & "," & Convert.ToInt32(sTA.EmployeeID) & "," & "" & "," & "" & "," & tmp.CurrencyID & "," & tmp.TotalInCurrency & "," & "2" & "," & Remarks & "," & CardNo & "," & "" & "," & "" & "," & "" & "," & "" & "," & sTA.ConversionFactorINR & "</CreditLine>")
                  LineCount += 1
                ElseIf tmp.ComponentID = TAComponentTypes.Total AndAlso tmp.CurrencyID = "INR" Then
                  'insert Debit Line IN FC Project Wise
                  For Each ptmp As SIS.TA.taBillPrjAmounts In sPrj
                    Dim prjCA As SIS.TA.prjCmpActERP = GetProjectCompanyFromERP(ptmp.ProjectID)
                    Dim prjAmtInCur As Decimal = (tmp.TotalInCurrency * ptmp.Percentage) / 100
                    oTW.WriteLine("      <Line PrkLedgerID=""" & sTA.TABillNo & """  ProcessID="""" SerialNo="""" BatchNo="""" DocumentNo="""" LineNo="""" GetBatchDocument=""" & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "[SerialNo]" & """>" & Company & "," & prjCA.Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & DebitGL & "," & ptmp.ProjectID & "," & xmlDepartment & "," & Convert.ToInt32(sTA.EmployeeID) & "," & "" & "," & "UP" & "," & tmp.CurrencyID & "," & (prjAmtInCur) & "," & "1" & "," & Remarks & "," & CardNo & "," & ptmp.ProjectID & "," & Element & "," & prjCA.Activity & "," & prjCA.SubContracting & "," & "1.00" & "</Line>")
                    LineCount += 1
                  Next
                  'Insert Credit Line in FC
                  oTW.WriteLine("      <CreditLine>" & Company & "," & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & CreditGL & "," & "" & "," & xmlDepartment & "," & Convert.ToInt32(sTA.EmployeeID) & "," & "" & "," & "" & "," & tmp.CurrencyID & "," & tmp.TotalInCurrency & "," & "2" & "," & Remarks & "," & CardNo & "," & "" & "," & "" & "," & "" & "," & "" & "," & "1.00" & "</CreditLine>")
                  LineCount += 1
                End If
              Next
            Case Else 'Domestic
              Dim TotalLodgingAmount As Decimal = 0
              For Each tmp As SIS.TA.taBillDetails In sBil
                If tmp.ComponentID = TAComponentTypes.Lodging Then
                  tmp = SIS.TA.taBDLodging.UpdateGSTDataInBDL(tmp)
                  If tmp.PurchaseType = "Purchase from Registered Dealer" Then
                    'insert Debit Line GST
                    If tmp.ProjectID = "" Then tmp.ProjectID = sTA.ProjectID
                    Dim prjCA As SIS.TA.prjCmpActERP = GetProjectCompanyFromERP(tmp.ProjectID)
                    Dim IsgecGSTINState As String = Left(tmp.SPMT_IsgecGSTIN4_Description, 2)
                    Dim erpState As SIS.SPMT.spmtERPStates = SIS.SPMT.spmtERPStates.spmtERPStatesGetByID(IsgecGSTINState)
                    Dim cgstGL As String = erpState.ISGECCentralGSTGL
                    Dim sgstGL As String = erpState.ISGECStateGSTGL
                    Dim gst1Amt As Decimal = tmp.TotalGST * 0.5
                    Dim gst2Amt As Decimal = tmp.TotalGST - gst1Amt
                    'oTW.WriteLine("      <Line PrkLedgerID=""" & sTA.TABillNo & """  ProcessID="""" SerialNo="""" BatchNo="""" DocumentNo="""" LineNo="""" GetBatchDocument=""" & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "[SerialNo]" & """>" & Company & "," & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & GSTGL & "," & "" & "," & xmlDepartment & "," & Convert.ToInt32(sTA.EmployeeID) & "," & "" & "," & tmp.FK_TA_BillGST_IsgecGSTIN.State.Substring(0, 2) & "," & "INR" & "," & (tmp.TotalGST) & "," & "1" & "," & Remarks & "," & CardNo & "," & "" & "," & "" & "," & "" & "," & "" & "," & "1.00" & "</Line>")
                    'LineCount += 1
                    oTW.WriteLine("      <Line PrkLedgerID=""" & sTA.TABillNo & """  ProcessID="""" SerialNo="""" BatchNo="""" DocumentNo="""" LineNo="""" GetBatchDocument=""" & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "[SerialNo]" & """>" & Company & "," & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & cgstGL & "," & "" & "," & xmlDepartment & "," & Convert.ToInt32(sTA.EmployeeID) & "," & "" & "," & tmp.FK_TA_BillGST_IsgecGSTIN.State.Substring(0, 2) & "," & "INR" & "," & (gst1Amt) & "," & "1" & "," & Remarks & "," & CardNo & "," & "" & "," & "" & "," & "" & "," & "" & "," & "1.00" & "</Line>")
                    LineCount += 1
                    oTW.WriteLine("      <Line PrkLedgerID=""" & sTA.TABillNo & """  ProcessID="""" SerialNo="""" BatchNo="""" DocumentNo="""" LineNo="""" GetBatchDocument=""" & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "[SerialNo]" & """>" & Company & "," & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & sgstGL & "," & "" & "," & xmlDepartment & "," & Convert.ToInt32(sTA.EmployeeID) & "," & "" & "," & tmp.FK_TA_BillGST_IsgecGSTIN.State.Substring(0, 2) & "," & "INR" & "," & (gst2Amt) & "," & "1" & "," & Remarks & "," & CardNo & "," & "" & "," & "" & "," & "" & "," & "" & "," & "1.00" & "</Line>")
                    LineCount += 1
                    'insert Debit Line Hotel Charges Passed Amount - TotalGST
                    oTW.WriteLine("      <Line PrkLedgerID=""" & sTA.TABillNo & """  ProcessID="""" SerialNo="""" BatchNo="""" DocumentNo="""" LineNo="""" GetBatchDocument=""" & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "[SerialNo]" & """>" & Company & "," & prjCA.Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & DebitGL & "," & tmp.ProjectID & "," & xmlDepartment & "," & Convert.ToInt32(sTA.EmployeeID) & "," & "" & "," & tmp.FK_TA_BillGST_IsgecGSTIN.State.Substring(0, 2) & "," & "INR" & "," & (tmp.PassedAmountInINR - tmp.TotalGST) & "," & "1" & "," & Remarks & "," & CardNo & "," & tmp.ProjectID & "," & Element & "," & prjCA.Activity & "," & prjCA.SubContracting & "," & "1.00" & "</Line>")
                    LineCount += 1
                    TotalLodgingAmount += tmp.PassedAmountInINR
                  End If
                End If
              Next
              'Get Project******
              Dim BalanceTAAmont As Decimal = 0
              BalanceTAAmont = sTA.TotalPassedAmount - TotalLodgingAmount
              'insert Debit Line
              For Each tmp As SIS.TA.taBillPrjAmounts In sPrj
                Dim prjCA As SIS.TA.prjCmpActERP = GetProjectCompanyFromERP(tmp.ProjectID)
                Dim xAmt As Decimal = 0
                xAmt = BalanceTAAmont * tmp.Percentage / 100
                oTW.WriteLine("      <Line PrkLedgerID=""" & sTA.TABillNo & """  ProcessID="""" SerialNo="""" BatchNo="""" DocumentNo="""" LineNo="""" GetBatchDocument=""" & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "[SerialNo]" & """>" & Company & "," & prjCA.Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & DebitGL & "," & tmp.ProjectID & "," & xmlDepartment & "," & Convert.ToInt32(sTA.EmployeeID) & "," & "" & "," & "UP" & "," & "INR" & "," & (xAmt) & "," & "1" & "," & Remarks & "," & CardNo & "," & tmp.ProjectID & "," & Element & "," & prjCA.Activity & "," & prjCA.SubContracting & "," & "1.00" & "</Line>")
                LineCount += 1
              Next
              'Insert Credit Line
              oTW.WriteLine("      <CreditLine>" & Company & "," & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & CreditGL & "," & "" & "," & xmlDepartment & "," & Convert.ToInt32(sTA.EmployeeID) & "," & "" & "," & "" & "," & "INR" & "," & sTA.TotalPassedAmount & "," & "2" & "," & Remarks & "," & CardNo & "," & "" & "," & "" & "," & "" & "," & "" & "," & "1.00" & "</CreditLine>")
              LineCount += 1
          End Select
          oTW.WriteLine("    </Lines>")
          oTW.WriteLine("    <Batch>" & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & VoucherType & "</Batch>")
          oTW.WriteLine("    <Errors><Error></Error></Errors>")
          oTW.WriteLine("  </Company>")
          oTW.WriteLine("</Companies>")
          oTW.Close()
        Else 'NON PROJECT
          oTW.WriteLine("<Companies>")
          oTW.WriteLine("  <Company name=""" & Company & """>")
          oTW.WriteLine("		<Lines>")
          Select Case sTA.TravelTypeID
            Case TATravelTypeValues.ForeignTravel, TATravelTypeValues.ForeignSiteVisit

              For Each tmp As SIS.TA.taBillAmount In sAmt
                If tmp.ComponentID = TAComponentTypes.Total AndAlso tmp.CurrencyID <> "INR" Then
                  'insert Debit Line In FC
                  oTW.WriteLine("      <Line PrkLedgerID=""" & sTA.TABillNo & """  ProcessID="""" SerialNo="""" BatchNo="""" DocumentNo="""" LineNo="""" GetBatchDocument=""" & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "[SerialNo]" & """>" & Company & "," & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & DebitGL & "," & "" & "," & xmlCostCenter & "," & Convert.ToInt32(sTA.EmployeeID) & "," & "" & "," & "UP" & "," & tmp.CurrencyID & "," & tmp.TotalInCurrency & "," & "1" & "," & Remarks & "," & CardNo & "," & sTA.ConversionFactorINR & "</Line>")
                  LineCount += 1
                  'Insert Credit Line In FC
                  oTW.WriteLine("      <CreditLine>" & Company & "," & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & CreditGL & "," & "" & "," & xmlDepartment & "," & Convert.ToInt32(sTA.EmployeeID) & "," & "" & "," & "" & "," & tmp.CurrencyID & "," & tmp.TotalInCurrency & "," & "2" & "," & Remarks & "," & CardNo & "," & sTA.ConversionFactorINR & "</CreditLine>")
                  LineCount += 1
                ElseIf tmp.ComponentID = TAComponentTypes.Total AndAlso tmp.CurrencyID = "INR" Then
                  'insert Debit Line In FC
                  oTW.WriteLine("      <Line PrkLedgerID=""" & sTA.TABillNo & """  ProcessID="""" SerialNo="""" BatchNo="""" DocumentNo="""" LineNo="""" GetBatchDocument=""" & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "[SerialNo]" & """>" & Company & "," & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & DebitGL & "," & "" & "," & xmlCostCenter & "," & Convert.ToInt32(sTA.EmployeeID) & "," & "" & "," & "UP" & "," & tmp.CurrencyID & "," & tmp.TotalInCurrency & "," & "1" & "," & Remarks & "," & CardNo & "," & "1.00" & "</Line>")
                  LineCount += 1
                  'Insert Credit Line In FC
                  oTW.WriteLine("      <CreditLine>" & Company & "," & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & CreditGL & "," & "" & "," & xmlDepartment & "," & Convert.ToInt32(sTA.EmployeeID) & "," & "" & "," & "" & "," & tmp.CurrencyID & "," & tmp.TotalInCurrency & "," & "2" & "," & Remarks & "," & CardNo & "," & "1.00" & "</CreditLine>")
                  LineCount += 1

                End If
              Next
            Case Else 'Domestic
              Dim TotalLodgingAmount As Decimal = 0
              For Each tmp As SIS.TA.taBillDetails In sBil
                If tmp.ComponentID = TAComponentTypes.Lodging Then
                  tmp = SIS.TA.taBDLodging.UpdateGSTDataInBDL(tmp)
                  If tmp.PurchaseType = "Purchase from Registered Dealer" Then
                    Dim IsgecGSTINState As String = Left(tmp.SPMT_IsgecGSTIN4_Description, 2)
                    Dim erpState As SIS.SPMT.spmtERPStates = SIS.SPMT.spmtERPStates.spmtERPStatesGetByID(IsgecGSTINState)
                    Dim cgstGL As String = erpState.ISGECCentralGSTGL
                    Dim sgstGL As String = erpState.ISGECStateGSTGL
                    Dim gst1Amt As Decimal = tmp.TotalGST * 0.5
                    Dim gst2Amt As Decimal = tmp.TotalGST - gst1Amt
                    'insert Debit Line GST
                    'oTW.WriteLine("      <Line PrkLedgerID=""" & sTA.TABillNo & """  ProcessID="""" SerialNo="""" BatchNo="""" DocumentNo="""" LineNo="""" GetBatchDocument=""" & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "[SerialNo]" & """>" & Company & "," & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & GSTGL & "," & "" & "," & xmlCostCenter & "," & Convert.ToInt32(sTA.EmployeeID) & "," & "" & "," & tmp.FK_TA_BillGST_IsgecGSTIN.State.Substring(0, 2) & "," & "INR" & "," & (tmp.TotalGST) & "," & "1" & "," & Remarks & "," & CardNo & "," & "1.00" & "</Line>")
                    'LineCount += 1
                    oTW.WriteLine("      <Line PrkLedgerID=""" & sTA.TABillNo & """  ProcessID="""" SerialNo="""" BatchNo="""" DocumentNo="""" LineNo="""" GetBatchDocument=""" & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "[SerialNo]" & """>" & Company & "," & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & cgstGL & "," & "" & "," & xmlCostCenter & "," & Convert.ToInt32(sTA.EmployeeID) & "," & "" & "," & tmp.FK_TA_BillGST_IsgecGSTIN.State.Substring(0, 2) & "," & "INR" & "," & (gst1Amt) & "," & "1" & "," & Remarks & "," & CardNo & "," & "1.00" & "</Line>")
                    LineCount += 1
                    oTW.WriteLine("      <Line PrkLedgerID=""" & sTA.TABillNo & """  ProcessID="""" SerialNo="""" BatchNo="""" DocumentNo="""" LineNo="""" GetBatchDocument=""" & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "[SerialNo]" & """>" & Company & "," & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & sgstGL & "," & "" & "," & xmlCostCenter & "," & Convert.ToInt32(sTA.EmployeeID) & "," & "" & "," & tmp.FK_TA_BillGST_IsgecGSTIN.State.Substring(0, 2) & "," & "INR" & "," & (gst2Amt) & "," & "1" & "," & Remarks & "," & CardNo & "," & "1.00" & "</Line>")
                    LineCount += 1
                    'insert Debit Line Hotel Charges Passed Amount - TotalGST
                    oTW.WriteLine("      <Line PrkLedgerID=""" & sTA.TABillNo & """  ProcessID="""" SerialNo="""" BatchNo="""" DocumentNo="""" LineNo="""" GetBatchDocument=""" & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "[SerialNo]" & """>" & Company & "," & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & DebitGL & "," & "" & "," & xmlCostCenter & "," & Convert.ToInt32(sTA.EmployeeID) & "," & "" & "," & tmp.FK_TA_BillGST_IsgecGSTIN.State.Substring(0, 2) & "," & "INR" & "," & (tmp.PassedAmountInINR - tmp.TotalGST) & "," & "1" & "," & Remarks & "," & CardNo & "," & "1.00" & "</Line>")
                    LineCount += 1
                    TotalLodgingAmount += tmp.PassedAmountInINR
                  End If
                End If
              Next
              'insert Debit Line Total Passed Amount - TotalLodging
              oTW.WriteLine("      <Line PrkLedgerID=""" & sTA.TABillNo & """  ProcessID="""" SerialNo="""" BatchNo="""" DocumentNo="""" LineNo="""" GetBatchDocument=""" & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "[SerialNo]" & """>" & Company & "," & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & DebitGL & "," & "" & "," & xmlCostCenter & "," & Convert.ToInt32(sTA.EmployeeID) & "," & "" & "," & "UP" & "," & "INR" & "," & (sTA.TotalPassedAmount - TotalLodgingAmount) & "," & "1" & "," & Remarks & "," & CardNo & "," & "1.00" & "</Line>")
              LineCount += 1
              'Insert Credit Line :Total Passed Amount
              oTW.WriteLine("      <CreditLine>" & Company & "," & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & "" & "," & "" & "," & VoucherType & "," & "" & "," & CreditGL & "," & "" & "," & xmlDepartment & "," & Convert.ToInt32(sTA.EmployeeID) & "," & "" & "," & "" & "," & "INR" & "," & sTA.TotalPassedAmount & "," & "2" & "," & Remarks & "," & CardNo & "," & "1.00" & "</CreditLine>")
              LineCount += 1
          End Select

          oTW.WriteLine("    </Lines>")
          oTW.WriteLine("    <Batch>" & Company & "," & "20" & "," & VoucherDate & "," & "[ProcessID]" & "," & VoucherType & "</Batch>")
          oTW.WriteLine("    <Errors><Error></Error></Errors>")
          oTW.WriteLine("  </Company>")
          oTW.WriteLine("</Companies>")
          oTW.Close()
        End If
        '============End VCH Posting=================
        mRet.VoucherType = VoucherType
        mRet.VoucherCompany = "200"
        '================Read===================
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
                mRet.IsError = True
                mRet.Message = errchild.InnerText
                ErrFound = True
                Exit For
              End If
            Next
          Next
          If Not ErrFound Then
            For Each cmp As XmlNode In oTR.ChildNodes(1)
              Dim oLines As XmlNode = cmp.ChildNodes(0)
              Dim oBatch As XmlNode = cmp.ChildNodes(1)
              Dim oErr As XmlNode = cmp.ChildNodes(2)
              For Each cmpChild As XmlNode In cmp.ChildNodes
                If cmpChild.Name.ToLower = "lines" Then
                  For Each line As XmlNode In cmpChild.ChildNodes
                    If line.Name.ToLower <> "creditline" Then
                      Dim PrkLedgerID As String = line.Attributes("PrkLedgerID").Value
                      If sTA.TABillNo.ToString = PrkLedgerID Then
                        mRet.BatchNo = line.Attributes("BatchNo").Value
                        mRet.DocumentNo = line.Attributes("DocumentNo").Value
                        mRet.LineNo = line.Attributes("LineNo").Value
                      End If
                    End If
                  Next
                  Exit For
                End If
              Next
            Next
          End If
        Else
          mRet.IsError = True
          mRet.Message = "XML Not Processed"
        End If
      Catch ex As Exception
        mRet.IsError = True
        mRet.Message = ex.Message
      End Try
      If Not mRet.IsError Then
        Try
          UpdateBatchUser(mRet.BatchNo, UserId, VoucherDate, VoucherType)
        Catch ex As Exception
        End Try
      End If
      Return mRet
    End Function
  End Class
End Namespace
