Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports OfficeOpenXml
Namespace SIS.NPRK.Utilities
  Public Class GenerateEntitlements

    Public Function Generate(ByVal F_CardNo As String, ByVal T_CardNo As String, ByVal F_Date As String, ByVal T_Date As String, Optional ByVal PerkID As Integer = 0) As System.String
      Dim mLastScriptTimeout As Integer = HttpContext.Current.Server.ScriptTimeout
      HttpContext.Current.Server.ScriptTimeout = 36000

      Dim Cards As New List(Of clsCard)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          'Active = 1 => Do Not Generate Entitlement
          Dim mSql As String = ""
          If F_CardNo = "" And T_CardNo = "" Then
            mSql = "SELECT CARDNO FROM PRK_Employees WHERE  Active = 0"
          Else
            mSql = "SELECT CARDNO FROM PRK_Employees WHERE CardNo BETWEEN '" & F_CardNo & "' AND '" & T_CardNo & "' AND Active = 0"
          End If
          Cmd.CommandType = System.Data.CommandType.Text
          Cmd.CommandText = mSql
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Cards.Add(New clsCard(Reader))
          End While
          Reader.Close()
        End Using
      End Using

      Dim oFinYear As SIS.NPRK.nprkFinYears
      oFinYear = SIS.NPRK.nprkFinYears.nprkFinYearsGetByID(HttpContext.Current.Session("FinYear"))
      For Each tmp As clsCard In Cards
        Try
          DoGenerate(tmp.CardNo, F_Date, T_Date, PerkID, oFinYear)
        Catch ex As Exception
          HttpContext.Current.Server.ScriptTimeout = mLastScriptTimeout
          Throw New Exception(tmp.CardNo & " : " & ex.Message)
        End Try
      Next

      HttpContext.Current.Server.ScriptTimeout = mLastScriptTimeout
      Return "Over"
    End Function
    Public Sub DoGenerate(ByVal CardNo As String, ByVal FDate As String, ByVal TDate As String, ByVal PerkID As Integer, ByVal oFinYear As SIS.NPRK.nprkFinYears)

      Dim fDt As DateTime = Convert.ToDateTime(FDate)
      Dim tDt As DateTime = Convert.ToDateTime(TDate)

      'Return if invalid Date Range
      If tDt < fDt Then
        'Error
        Exit Sub
      End If
      If fDt < oFinYear.StartDate Or fDt > Convert.ToDateTime(oFinYear.EndDate) Then
        'Error
        Exit Sub
      End If
      If tDt < oFinYear.StartDate Or tDt > Convert.ToDateTime(oFinYear.EndDate) Then
        'Error
        Exit Sub
      End If

      'Do NOT Generate Entitlements If resigned
      Dim ResignedCase As Boolean = False

      'Get The Employee Record
      Dim oEmp As SIS.NPRK.nprkEmployees = SIS.NPRK.nprkEmployees.GetByCardNo(CardNo)
      If oEmp Is Nothing Then Exit Sub

      Dim oEmpBasic As Double = oEmp.Basic

      'Re-Set Date Range if Required on the basis of DOJ / DOR
      'Also set Resigned case
      'Assumed if DOJ or DOR is empty, then Valid Employee 
      'and DOJ or DOR donot have effect on current processing

      'Check Employee DOJ and DOR for their validity
      If (oEmp.DOJ <> String.Empty) And (oEmp.DOR <> String.Empty) Then
        If Convert.ToDateTime(oEmp.DOJ) > Convert.ToDateTime(oEmp.DOR) Then
          'Error
          Exit Sub
        End If
      End If
      'End of Emp Dates checking

      If oEmp.DOJ <> String.Empty Then
        'If DOJ is after Tdt exit
        If Convert.ToDateTime(oEmp.DOJ) > tDt Then
          GoTo CleanUp
          Exit Sub
        End If

        If Convert.ToDateTime(oEmp.DOJ) > fDt Then
          fDt = Convert.ToDateTime(oEmp.DOJ)
        End If
      End If
      If oEmp.DOR <> String.Empty Then
        'If DOR is before Fdt then exit
        If Convert.ToDateTime(oEmp.DOR) < fDt Then
          GoTo CleanUp
          Exit Sub
        End If

        If Convert.ToDateTime(oEmp.DOR) < tDt Then
          tDt = Convert.ToDateTime(oEmp.DOR)
          ResignedCase = True
        End If
      End If

      'Get EmpID for further processings
      Dim EmpID As Int32 = oEmp.EmployeeID
      Dim oPrks As List(Of SIS.NPRK.nprkPerks) = SIS.NPRK.nprkPerks.nprkPerksSelectList("PerkID")
      '====================================================
      'Dim prkList As New List(Of SIS.NPRK.nprkEntitlements)
      '====================================================
      Dim oEnt As SIS.NPRK.nprkEntitlements = Nothing
      For Each oPrk As SIS.NPRK.nprkPerks In oPrks
        If Not oPrk.Active Then Continue For
        Select Case oPrk.PerkID
          Case prkPerk.VehicleRepairAndRunningExpense, prkPerk.MiscellaneousReimbursement, prkPerk.BalanceMedical
            Continue For
        End Select
        If PerkID > 0 Then If oPrk.PerkID <> PerkID Then Continue For
        DeletePerks(EmpID, fDt, oFinYear.EndDate, oPrk.PerkID)
        Dim oRngs As List(Of SIS.NPRK.Utilities.ProcessRange) = SIS.NPRK.Utilities.ProcessRange.GetProcessRange(oEmp, fDt, tDt, oPrk.PerkID, oFinYear)
        For Each oRng As ProcessRange In oRngs
          '====ProtoType of Next Logic
          'If Not oRng.LastRecord Then
          'Else 'Last Record
          '  If Not oRng.AdvanceMonths Then
          '  Else 'AdvanceMonths
          '    If Not oPrk.AdvanceApplicable Then
          '    Else 'Advance Applicable
          '      If oPrk.LockedMonths = 0 Then  'Zero Locked Months
          '      Else 'There are locked Months
          '      End If 'Zero Locked Months
          '    End If 'Not Adv Appli
          '  End If 'Not AdvanceMonth
          'End If 'Not LastRecordd

          If Not oRng.RuleFound Then Continue For

          oEnt = New SIS.NPRK.nprkEntitlements
          With oEnt
            .EmployeeID = oEmp.EmployeeID
            .FinYear = HttpContext.Current.Session("FinYear")
            .PerkID = oPrk.PerkID
            .UOM = oPrk.UOM

            .EffectiveDate = oRng.LastDate
            .Basic = oRng.Basic
            .CategoryID = oRng.CategoryID
            .ESI = oRng.ESI
            .PostedAt = oRng.PostedAt
            .VehicleType = oRng.VehicleType
            .Value = oRng.PerkValue
          End With
          If Not oRng.LastRecord Then
            oEnt = SIS.NPRK.nprkEntitlements.InsertData(oEnt)
          Else 'If Last Record
            If Not oRng.AdvanceMonths Then
              oEnt = SIS.NPRK.nprkEntitlements.InsertData(oEnt)
            Else 'Not Partially ending month and Adv can be generated
              If Not oPrk.AdvanceApplicable Then
                oEnt = SIS.NPRK.nprkEntitlements.InsertData(oEnt)
              Else 'If Advance Applicable
                If oPrk.LockedMonths = 0 Then
                  If ResignedCase Then
                    oEnt = SIS.NPRK.nprkEntitlements.InsertData(oEnt)
                  Else ' If Not resigned case
                    'Get LastDate of Adv. Months
                    Dim LAdvDt As DateTime = oRng.LastDate.AddMonths(oPrk.AdvanceMonths - 1)
                    LAdvDt = LAdvDt.AddDays(DateTime.DaysInMonth(LAdvDt.Year, LAdvDt.Month) - LAdvDt.Day)
                    'Validate LastDate of Advance Months against DOR and FinYear
                    If LAdvDt > oFinYear.EndDate Then
                      LAdvDt = oFinYear.EndDate
                    End If
                    If oEmp.DOR <> String.Empty Then
                      If LAdvDt > Convert.ToDateTime(oEmp.DOR) Then
                        LAdvDt = Convert.ToDateTime(oEmp.DOR)
                      End If
                    End If
                    Dim oAdvRngs As List(Of SIS.NPRK.Utilities.ProcessRange) = SIS.NPRK.Utilities.ProcessRange.GetProcessRange(oEmp, oRng.StartDate, LAdvDt, oPrk.PerkID, oFinYear)
                    For Each oaRng As SIS.NPRK.Utilities.ProcessRange In oAdvRngs
                      If Not oaRng.RuleFound Then Continue For
                      Dim osEnt As SIS.NPRK.nprkEntitlements = New SIS.NPRK.nprkEntitlements
                      With osEnt
                        .EmployeeID = oEmp.EmployeeID
                        .FinYear = HttpContext.Current.Session("FinYear")
                        .PerkID = oPrk.PerkID
                        .UOM = oPrk.UOM

                        .EffectiveDate = oaRng.LastDate
                        .Basic = oaRng.Basic
                        .CategoryID = oaRng.CategoryID
                        .ESI = oaRng.ESI
                        .PostedAt = oaRng.PostedAt
                        .VehicleType = oaRng.VehicleType
                        .Value = oaRng.PerkValue
                      End With
                      osEnt = SIS.NPRK.nprkEntitlements.InsertData(osEnt)
                    Next
                  End If
                Else 'If Locked Months are there
                  If ResignedCase Then
                    oEnt = SIS.NPRK.nprkEntitlements.InsertData(oEnt)
                  Else ' If Not resigned case
                    Dim AdvMonth As Integer = oPrk.LockedMonths - Convert.ToInt32(DateDiff(DateInterval.Month, Convert.ToDateTime(oFinYear.StartDate), oRng.StartDate) Mod oPrk.LockedMonths)
                    Dim LAdvDt As DateTime = oRng.StartDate.AddMonths(AdvMonth - 1)
                    LAdvDt = LAdvDt.AddDays(DateTime.DaysInMonth(LAdvDt.Year, LAdvDt.Month) - LAdvDt.Day)

                    'Validate LastDate of Advance Months against DOR and FinYear
                    If LAdvDt > oFinYear.EndDate Then
                      LAdvDt = oFinYear.EndDate
                    End If
                    If oEmp.DOR <> String.Empty Then
                      If LAdvDt > Convert.ToDateTime(oEmp.DOR) Then
                        LAdvDt = Convert.ToDateTime(oEmp.DOR)
                      End If
                    End If
                    Dim oAdvRngs As List(Of SIS.NPRK.Utilities.ProcessRange) = SIS.NPRK.Utilities.ProcessRange.GetProcessRange(oEmp, oRng.StartDate, LAdvDt, oPrk.PerkID, oFinYear)
                    For Each oaRng As SIS.NPRK.Utilities.ProcessRange In oAdvRngs
                      If Not oaRng.RuleFound Then Continue For
                      Dim osEnt As SIS.NPRK.nprkEntitlements = New SIS.NPRK.nprkEntitlements
                      With osEnt
                        .EmployeeID = oEmp.EmployeeID
                        .FinYear = HttpContext.Current.Session("FinYear")
                        .PerkID = oPrk.PerkID
                        .UOM = oPrk.UOM

                        .EffectiveDate = oaRng.LastDate
                        .Basic = oaRng.Basic
                        .CategoryID = oaRng.CategoryID
                        .ESI = oaRng.ESI
                        .PostedAt = oaRng.PostedAt
                        .VehicleType = oaRng.VehicleType
                        .Value = oaRng.PerkValue
                      End With
                      osEnt = SIS.NPRK.nprkEntitlements.InsertData(osEnt)
                    Next
                  End If 'End of Resigned case with in Locked Months
                End If 'End of Locked Months
              End If 'End of Advance Applicable
            End If 'Advance can be given by oRng
          End If 'End of Last record
        Next
      Next
      'Sum Entitlement of grouping Heads 
      '=================================
      '1. Total Amount
      DeletePerks(EmpID, fDt, oFinYear.EndDate, prkPerk.VehicleRepairAndRunningExpense)
      'Get Total Medical Generated
      Dim TotalMedical As Decimal = SIS.NPRK.nprkPerks.GetNetPayable(oEmp.EmployeeID, prkPerk.MedicalBenifit, HttpContext.Current.Session("FinYear"))
      'Subtract OBP Created in 19 from Total Payable
      Dim tmp As Decimal = 0
      'Get Paid in MedicalBenefit + OPB Created in Medical Balance
      tmp = SIS.NPRK.nprkLedger.GetPaidMedBenfitWithADJinBalMed(oEmp.EmployeeID)
      TotalMedical = TotalMedical - tmp
      If oEmp.VehicleType <> "None" Then
        Dim TotOthers As Decimal = 0
        Dim TotVH As Decimal = 0

        TotOthers = SIS.NPRK.nprkPerks.GetNetPayable(oEmp.EmployeeID, prkPerk.CarMaintenance, HttpContext.Current.Session("FinYear"))
        TotOthers += SIS.NPRK.nprkPerks.GetNetPayable(oEmp.EmployeeID, prkPerk.Petrol, HttpContext.Current.Session("FinYear"))
        TotOthers += SIS.NPRK.nprkPerks.GetNetPayable(oEmp.EmployeeID, prkPerk.TwoWheelerMaint, HttpContext.Current.Session("FinYear"))
        TotOthers += SIS.NPRK.nprkPerks.GetNetPayable(oEmp.EmployeeID, prkPerk.NewspaperMagazine, HttpContext.Current.Session("FinYear"))
        TotOthers += SIS.NPRK.nprkPerks.GetNetPayable(oEmp.EmployeeID, prkPerk.Uniform, HttpContext.Current.Session("FinYear"))
        TotOthers += SIS.NPRK.nprkPerks.GetNetPayable(oEmp.EmployeeID, prkPerk.ClubSubscription, HttpContext.Current.Session("FinYear"))
        'Allready Generated Entitlements in 17
        TotVH = SIS.NPRK.nprkEntitlements.GetNetValue(oEmp.EmployeeID, 17, HttpContext.Current.Session("FinYear"))
        Dim VHToCredit As Decimal = 0
        VHToCredit = TotOthers + TotalMedical - TotVH

        '2. Insert Either Veh or Misc Record
        oEnt = New SIS.NPRK.nprkEntitlements
        With oEnt
          .EmployeeID = oEmp.EmployeeID
          .FinYear = HttpContext.Current.Session("FinYear")
          .PerkID = prkPerk.VehicleRepairAndRunningExpense
          .UOM = .FK_PRK_Entitlements_PRK_Perks.UOM


          .Description = "For Qtr. starting from " & fDt
          .EffectiveDate = fDt
          .Basic = oEmp.Basic
          .CategoryID = oEmp.CategoryID
          .ESI = oEmp.ESI
          .PostedAt = oEmp.PostedAt
          .VehicleType = oEmp.VehicleType
          .Value = VHToCredit
        End With
        oEnt = SIS.NPRK.nprkEntitlements.InsertData(oEnt)
      End If

      '=========End Of Grouping=========
CleanUp:
      'Run Cleanup process
      If oEmp.DOJ <> String.Empty Then
        DeletePerksBeforeDOJ(oEmp.EmployeeID, oEmp.DOJ)
      End If
      If oEmp.DOR <> String.Empty Then
        DeletePerksAfterDOR(oEmp.EmployeeID, oEmp.DOR)
      End If
    End Sub
    Public Shared Function GetSQLVal(ByVal SQL As String) As Decimal
      Dim tmp As Decimal = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = System.Data.CommandType.Text
          Cmd.CommandText = SQL
          Con.Open()
          Try
            tmp = Cmd.ExecuteScalar()
          Catch ex As Exception
          End Try
        End Using
      End Using
      Return tmp
    End Function
    Private Sub DeletePerksBeforeDOJ(ByVal EmpID As Integer, ByVal DOJ As DateTime)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Dim mSql As String = "delete prk_entitlements where employeeid=" & EmpID & " and effectivedate < convert(datetime,'" & DOJ.ToString("dd/MM/yyyy") & "',103)"
          Cmd.CommandType = System.Data.CommandType.Text
          Cmd.CommandText = mSql
          Con.Open()
          Try
            Cmd.ExecuteNonQuery()
          Catch ex As Exception
          End Try
        End Using
      End Using

      'Dim oEnts As List(Of SIS.NPRK.nprkEntitlements) = SIS.NPRK.nprkEntitlements.GetByEmployeeID(EmpID, "PerkID")
      'For Each oEnt As SIS.NPRK.nprkEntitlements In oEnts
      '  If Convert.ToDateTime(oEnt.EffectiveDate) < DOJ Then
      '    SIS.NPRK.nprkEntitlements.nprkEntitlementsDelete(oEnt)
      '  End If
      'Next
    End Sub
    Private Sub DeletePerksAfterDOR(ByVal EmpID As Integer, ByVal DOR As DateTime)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Dim mSql As String = "delete prk_entitlements where employeeid=" & EmpID & " and effectivedate > convert(datetime,'" & DOR.ToString("dd/MM/yyyy") & "',103)"
          Cmd.CommandType = System.Data.CommandType.Text
          Cmd.CommandText = mSql
          Con.Open()
          Try
            Cmd.ExecuteNonQuery()
          Catch ex As Exception
          End Try
        End Using
      End Using
      'Dim oEnts As List(Of SIS.NPRK.nprkEntitlements) = SIS.NPRK.nprkEntitlements.GetByEmployeeID(EmpID, "PerkID")
      'For Each oEnt As SIS.NPRK.nprkEntitlements In oEnts
      '  If Convert.ToDateTime(oEnt.EffectiveDate) > DOR Then
      '    SIS.NPRK.nprkEntitlements.nprkEntitlementsDelete(oEnt)
      '  End If
      'Next
    End Sub
    Private Sub DeletePerks(ByVal EmpID As Integer, ByVal fDt As DateTime, ByVal tDt As DateTime)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Dim mSql As String = "delete prk_entitlements where employeeid=" & EmpID & " and effectivedate >= convert(datetime,'" & fDt.ToString("dd/MM/yyyy") & "',103) and effectivedate <= convert(datetime,'" & tDt.ToString("dd/MM/yyyy") & "',103)"
          Cmd.CommandType = System.Data.CommandType.Text
          Cmd.CommandText = mSql
          Con.Open()
          Try
            Cmd.ExecuteNonQuery()
          Catch ex As Exception
          End Try
        End Using
      End Using
      'Dim oEnts As List(Of SIS.NPRK.nprkEntitlements) = SIS.NPRK.nprkEntitlements.GetByEmployeeID(EmpID, "PerkID")
      'For Each oEnt As SIS.NPRK.nprkEntitlements In oEnts
      '  If Convert.ToDateTime(oEnt.EffectiveDate) >= fDt And Convert.ToDateTime(oEnt.EffectiveDate) <= tDt Then
      '    SIS.NPRK.nprkEntitlements.nprkEntitlementsDelete(oEnt)
      '  End If
      'Next
    End Sub
    Private Sub DeletePerks(ByVal EmpID As Integer, ByVal fDt As DateTime, ByVal tDt As DateTime, ByVal PerkID As Integer)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Dim mSql As String = "delete prk_entitlements where employeeid=" & EmpID & " and perkid=" & PerkID & " and effectivedate >= convert(datetime,'" & fDt.ToString("dd/MM/yyyy") & "',103) and effectivedate <= convert(datetime,'" & tDt.ToString("dd/MM/yyyy") & "',103)"
          Cmd.CommandType = System.Data.CommandType.Text
          Cmd.CommandText = mSql
          Con.Open()
          Try
            Cmd.ExecuteNonQuery()
          Catch ex As Exception
          End Try
        End Using
      End Using
      'Dim oEnts As List(Of SIS.NPRK.nprkEntitlements) = SIS.NPRK.nprkEntitlements.GetByEmployeeIDPerkID(EmpID, PerkID)
      'For Each oEnt As SIS.NPRK.nprkEntitlements In oEnts
      '  If Convert.ToDateTime(oEnt.EffectiveDate) >= fDt And Convert.ToDateTime(oEnt.EffectiveDate) <= tDt Then
      '    SIS.NPRK.nprkEntitlements.nprkEntitlementsDelete(oEnt)
      '  End If
      'Next
    End Sub
  End Class
  Public Class ProcessRange
    Private _DaysBasis As Boolean = False
    Private _Days As Integer = 0
    Private _DaysInMonth As Integer = 0
    Private _StartDate As DateTime
    Private _AdvanceMonths As Boolean = False
    Private _LastRecord As Boolean = False
    Private _Lastdate As DateTime
    Private _ForMonth As Integer = 0
    Private _ForYear As Integer = 0
    Private _ForPerk As Integer = 0
    Private _Basic As Decimal = 0
    Private _PostedAt As String = ""
    Private _VehicleType As String = ""
    Private _ESI As Boolean = False
    Private _ESIAmount As Decimal = 0
    Private _MaintenanceAllowed As Boolean = False
    Private _CategoryID As Integer = 0
    Private _PerkValue As Decimal = 0
    Private _RuleFound As Boolean = False
    Private _RuleID As Integer = 0
    Private _IsFASBasic As Boolean = False
    Private _TWInSalary As Boolean = False
    Public Property CardNo As String = ""
    Public Property OfficeID As Integer = 0
    Public Property LocationID As Integer = 0
    Public Property FinYear As Integer = 0
    Public Property PetrolRate As Decimal = 1.0
    Public Property WithDriver As Boolean = False
    Public Shared Function GetProcessRange(ByVal oEmp As SIS.NPRK.nprkEmployees, ByVal FDt As DateTime, ByVal TDt As DateTime, ByVal PerkID As Integer, ByVal oFinYear As SIS.NPRK.nprkFinYears) As List(Of ProcessRange)
      Dim aPRng As List(Of ProcessRange) = New List(Of ProcessRange)
      Dim taEmp As SIS.TA.taEmployees = SIS.TA.taEmployees.taEmployeesGetByID(oEmp.CardNo)
      'first get the months
      Dim tmpDt As DateTime = FDt
      Dim oRng As ProcessRange = Nothing
      Do While ((tmpDt.Month <= TDt.Month And tmpDt.Year = TDt.Year) Or (tmpDt.Year < TDt.Year))
        oRng = New ProcessRange
        With oRng
          .PerkID = PerkID
          .Month = tmpDt.Month
          .Year = GetForYear(tmpDt.Month, oFinYear)
          .StartDate = Convert.ToDateTime("01/" & tmpDt.Month.ToString & "/" & tmpDt.Year)
          .DaysBasis = False
          .Days = DateTime.DaysInMonth(tmpDt.Year, tmpDt.Month)
          .DaysInMonth = oRng.Days
          .LastDate = oRng.StartDate.AddDays(oRng.DaysInMonth - 1)
          .AdvanceMonths = True
          .LastRecord = False
          .TWInSalary = oEmp.TWInSalary
          .CardNo = taEmp.CardNo
          .OfficeID = taEmp.C_OfficeID
          .WithDriver = oEmp.WithDriver
          Try
            .LocationID = SIS.HRM.hrmOfficeLocation.hrmOfficeLocationGetByOfficeID(taEmp.C_OfficeID)
          Catch ex As Exception
          End Try
          .FinYear = oFinYear.FinYear
        End With
        aPRng.Add(oRng)
        tmpDt = tmpDt.AddMonths(1)
      Loop
      'check first and last date for partial months
      'First
      oRng = aPRng(0)
      oRng.StartDate = FDt
      If FDt.Day > 1 Then
        oRng.DaysBasis = True
        oRng.Days = oRng.Days - FDt.Day + 1
      End If
      aPRng(0) = oRng
      'Last date
      oRng = aPRng(aPRng.Count - 1)
      oRng.LastRecord = True
      oRng.LastDate = TDt
      If TDt.Day < DateTime.DaysInMonth(TDt.Year, TDt.Month) Then
        oRng.DaysBasis = True
        oRng.Days = DateDiff(DateInterval.Day, oRng.StartDate, TDt) + 1
        oRng.AdvanceMonths = False
      End If
      aPRng(aPRng.Count - 1) = oRng

      '=======
      For Each oEC As ProcessRange In aPRng
        oEC = GetFASorEMPCriteria(oEmp, oEC)
      Next
      '=======

      '=======
      For Each oEC As ProcessRange In aPRng
        oEC = GetPerkRule(oEC)
      Next
      '=======

      Return aPRng
    End Function
    Private Shared Function GetForYear(ByVal ForMonth As Integer, ByVal oFinYear As SIS.NPRK.nprkFinYears) As Integer
      Dim ForYear As Integer = 4
      Dim dt As DateTime = oFinYear.StartDate
      Do While dt < oFinYear.EndDate
        If dt.Month = ForMonth Then
          ForYear = dt.Year
          Exit Do
        End If
        dt = dt.AddMonths(1)
      Loop
      Return ForYear
    End Function
    Private Shared Function GetPerkRule(ByVal oRng As ProcessRange) As ProcessRange
      Dim oRules As List(Of SIS.NPRK.nprkRules) = SIS.NPRK.nprkRules.GetLatestRulesByCategoryIDPerkID(oRng.CategoryID, oRng.PerkID, oRng.StartDate)
      For Each oRul As SIS.NPRK.nprkRules In oRules
        If oRul.PostedAt = "None" And oRul.VehicleType <> "None" Then
          If oRng.VehicleType <> oRul.VehicleType Then
            Continue For
          End If
        ElseIf oRul.PostedAt <> "None" And oRul.VehicleType = "None" Then
          If oRng.PostedAt <> oRul.PostedAt Then
            Continue For
          End If
        ElseIf oRul.PostedAt <> "None" And oRul.VehicleType <> "None" Then
          If oRng.PostedAt <> oRul.PostedAt Or oRng.VehicleType <> oRul.VehicleType Then
            Continue For
          End If
        End If
        If oRul.PerkID = prkPerk.DriverCharges Then
          If oRul.WithDriver <> oRng.WithDriver Then
            Continue For
          End If
        End If
        'PERK Is Two wheelar Maintenance
        'In order to maintain only one rule is valid
        If oRul.PerkID = prkPerk.TwoWheelerMaint Then
          If oRng.TWInSalary <> oRul.InSalary Then
            Continue For
          End If
        End If
        'end of TW Maint

        'Per Perk only One rule is valid - 01-01-2007
        oRng.RuleFound = True
        oRng.RuleID = oRul.RuleID
        'Derive Range value
        Dim mValue As Double = 0
        Dim mDayValue As Double = 0
        If oRul.PercentageOfBasic Then
          mValue = (oRng.Basic * oRul.Percentage) / 100
          If oRng.DaysBasis Then
            If Not oRng.IsFASBasic Then
              mDayValue = mValue / oRng.DaysInMonth
              oRng.PerkValue = oRng.Days * mDayValue
            Else
              oRng.PerkValue = mValue
            End If
          Else
            oRng.PerkValue = mValue
          End If
        Else
          mValue = oRul.FixedValue
          If oRng.DaysBasis Then
            mDayValue = mValue / oRng.DaysInMonth
            oRng.PerkValue = oRng.Days * mDayValue
          Else
            oRng.PerkValue = mValue
          End If
        End If
        'If ESI is there then, Medical Benefit will be zero, irrrespective of Emp category
        If oRng.PerkID = 1 Then  'Medical Benefit
          If oRng.ESIAmount > 0 Then
            oRng.PerkValue = 0
          End If
        End If
        'End of ESI Check
        'If HttpContext.Current.Session("FinYear") > "2017" Then
        If oRng.PerkID = prkPerk.Petrol Then
            'Get Employee's Location Wise Rate
            Try
              oRng.PetrolRate = SIS.NPRK.nprkPetrolRate.nprkPetrolRateGetByID(oRng.FinYear, oRng.Month, oRng.LocationID).PetrolRate
            Catch ex As Exception
            End Try
            oRng.PerkValue = oRng.PerkValue * oRng.PetrolRate
          End If
        'End If
        'Now Exit rule is found
        Exit For
      Next
      Return oRng
    End Function
    Private Shared Function GetFASorEMPCriteria(ByVal oEmp As SIS.NPRK.nprkEmployees, ByVal oEC As ProcessRange) As ProcessRange
      Dim oFas As SIS.NPRK.nprkEmployeesMonthlyBasic = SIS.NPRK.nprkEmployeesMonthlyBasic.GetByEMY(oEmp.CardNo, oEC.Month, oEC.Year)
      If Not oFas Is Nothing Then
        With oEC
          .CategoryID = oFas.CategoryID
          .Basic = oFas.NetBasic
          .ESI = oFas.ESI
          .ESIAmount = oFas.ESIAmount
          .MaintenanceAllowed = oFas.MaintenanceAllowed
          .PostedAt = oFas.PostedAt
          .VehicleType = oFas.VehicleType
          .PerkValue = 0
          .IsFASBasic = True
          .TWInSalary = oFas.TWInSalary
        End With
      Else
        With oEC
          .CategoryID = oEmp.CategoryID
          .Basic = oEmp.Basic
          .ESI = oEmp.ESI
          .ESIAmount = 0
          .MaintenanceAllowed = oEmp.MaintenanceAllowed
          .PostedAt = oEmp.PostedAt
          .VehicleType = oEmp.VehicleType
          .PerkValue = 0
          .IsFASBasic = False
          .TWInSalary = oEmp.TWInSalary
        End With
      End If
      Return oEC
    End Function
    Public Property TWInSalary() As Boolean
      Get
        Return _TWInSalary
      End Get
      Set(ByVal value As Boolean)
        _TWInSalary = value
      End Set
    End Property
    Public Property IsFASBasic() As Boolean
      Get
        Return _IsFASBasic
      End Get
      Set(ByVal value As Boolean)
        _IsFASBasic = value
      End Set
    End Property
    Public Property RuleID() As Integer
      Get
        Return _RuleID
      End Get
      Set(ByVal value As Integer)
        _RuleID = value
      End Set
    End Property
    Public Property RuleFound() As Boolean
      Get
        Return _RuleFound
      End Get
      Set(ByVal value As Boolean)
        _RuleFound = value
      End Set
    End Property
    Public Property DaysBasis() As Boolean
      Get
        Return _DaysBasis
      End Get
      Set(ByVal value As Boolean)
        _DaysBasis = value
      End Set
    End Property
    Public Property Days() As Integer
      Get
        Return _Days
      End Get
      Set(ByVal value As Integer)
        _Days = value
      End Set
    End Property
    Public Property DaysInMonth() As Integer
      Get
        Return _DaysInMonth
      End Get
      Set(ByVal value As Integer)
        _DaysInMonth = value
      End Set
    End Property
    Public Property StartDate() As DateTime
      Get
        Return _StartDate
      End Get
      Set(ByVal value As DateTime)
        _StartDate = value
      End Set
    End Property
    Public Property AdvanceMonths() As Boolean
      Get
        Return _AdvanceMonths
      End Get
      Set(ByVal value As Boolean)
        _AdvanceMonths = value
      End Set
    End Property
    Public Property LastRecord() As Boolean
      Get
        Return _LastRecord
      End Get
      Set(ByVal value As Boolean)
        _LastRecord = value
      End Set
    End Property
    Public Property LastDate() As DateTime
      Get
        Return _Lastdate
      End Get
      Set(ByVal value As DateTime)
        _Lastdate = value
      End Set
    End Property
    Public Property PerkValue() As Decimal
      Get
        Return _PerkValue
      End Get
      Set(ByVal value As Decimal)
        _PerkValue = value
      End Set
    End Property
    Public Property CategoryID() As Integer
      Get
        Return _CategoryID
      End Get
      Set(ByVal value As Integer)
        _CategoryID = value
      End Set
    End Property
    Public Property MaintenanceAllowed() As Boolean
      Get
        Return _MaintenanceAllowed
      End Get
      Set(ByVal value As Boolean)
        _MaintenanceAllowed = value
      End Set
    End Property
    Public Property ESIAmount() As Decimal
      Get
        Return _ESIAmount
      End Get
      Set(ByVal value As Decimal)
        _ESIAmount = value
      End Set
    End Property
    Public Property ESI() As Boolean
      Get
        Return _ESI
      End Get
      Set(ByVal value As Boolean)
        _ESI = value
      End Set
    End Property
    Public Property VehicleType() As String
      Get
        Return _VehicleType
      End Get
      Set(ByVal value As String)
        _VehicleType = value
      End Set
    End Property
    Public Property PostedAt() As String
      Get
        Return _PostedAt
      End Get
      Set(ByVal value As String)
        _PostedAt = value
      End Set
    End Property
    Public Property Basic() As Decimal
      Get
        Return _Basic
      End Get
      Set(ByVal value As Decimal)
        _Basic = value
      End Set
    End Property
    Public Property PerkID() As Integer
      Get
        Return _ForPerk
      End Get
      Set(ByVal value As Integer)
        _ForPerk = value
      End Set
    End Property
    Public Property Year() As Integer
      Get
        Return _ForYear
      End Get
      Set(ByVal value As Integer)
        _ForYear = value
      End Set
    End Property
    Public Property Month() As Integer
      Get
        Return _ForMonth
      End Get
      Set(ByVal value As Integer)
        _ForMonth = value
      End Set
    End Property
  End Class
  Public Class ClosingBalance
    Public Shared Sub DeleteClosingRecord(ByVal F_CardNo As String)
      Dim T_CardNo As String = "99999"
      If F_CardNo = "" Then
        F_CardNo = "0000"
      Else
        T_CardNo = F_CardNo
      End If
      Dim aEmp As New List(Of String)
      Dim mLastScriptTimeout As Integer = HttpContext.Current.Server.ScriptTimeout
      HttpContext.Current.Server.ScriptTimeout = 600
      Dim TargetFY As Integer = HttpContext.Current.Session("FinYear")
      Dim oFinYear As SIS.NPRK.nprkFinYears = SIS.NPRK.nprkFinYears.nprkFinYearsGetByID(TargetFY)
      Dim EndDate As DateTime = oFinYear.EndDate
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Dim mSql As String = "SELECT CARDNO FROM PRK_Employees WHERE CardNo BETWEEN '" & F_CardNo & "' AND '" & T_CardNo & "'"
          Cmd.CommandType = System.Data.CommandType.Text
          Cmd.CommandText = mSql
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            aEmp.Add(Reader("CardNo"))
          End While
          Reader.Close()
        End Using
      End Using
      Dim xStr As String = "'2458',	'2940',	'2079',	'2079',	'3110',	'3049',	'3083',	'2543',	'1865',	'1654',	'3035',	'2905',	'0586',	'2103',	'2739',	'2454',	'2167',	'3098',	'3082',	'2410',	'2288',	'1652',	'2919',	'5001',	'5009',"
      Dim oPrks As List(Of SIS.NPRK.nprkPerks) = SIS.NPRK.nprkPerks.nprkPerksSelectList("PerkID")
      'Prepare XL 
      Dim FileName As String = HttpContext.Current.Server.MapPath("~/..") & "App_Temp\" & Guid.NewGuid().ToString()
      IO.File.Copy(HttpContext.Current.Server.MapPath("~/App_Templates") & "\PerkClosingPayable.xlsx", FileName)
      Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
      Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)
      Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("Data")

      Dim r As Integer = 5
      Dim c As Integer = 8

      xlWS.Cells(3, 3).Value = TargetFY

      'Write Heading
      For Each oPrk As SIS.NPRK.nprkPerks In oPrks
        If Not oPrk.Active Then Continue For
        With xlWS
          .Cells(r, c).Value = oPrk.Description
          c = c + 1
        End With
      Next
      xlWS.Cells(r, c).Value = "NET PAYABLE"
      'End Heading
      r = 6

      For Each emp As String In aEmp
        If xStr.IndexOf(emp) >= 0 Then Continue For
        'skip Resigned case
        Dim oEmp As SIS.NPRK.nprkEmployees = SIS.NPRK.nprkEmployees.GetByCardNo(emp)
        If oEmp.DOR <> String.Empty Then
          If Convert.ToDateTime(oEmp.DOR) < Convert.ToDateTime(oFinYear.StartDate) Then
            Continue For
          End If
        End If
        'Resigned case
        c = 1
        With xlWS
          .Cells(r, c).Value = oEmp.EmployeeID
          c = c + 1
          .Cells(r, c).Value = oEmp.EmployeeName
          c = c + 1
          .Cells(r, c).Value = oEmp.Department
          c = c + 1
          Try
            .Cells(r, c).Value = SIS.QCM.qcmEmployees.qcmEmployeesGetByID(IIf(oEmp.EmployeeID.ToString.Length < 5, Right("0000" & oEmp.EmployeeID, 4), oEmp.EmployeeID)).HRM_Designations3_Description
          Catch ex As Exception
          End Try
          c = c + 1
          .Cells(r, c).Value = oEmp.DOJ
          c = c + 1
          .Cells(r, c).Value = oEmp.VehicleType
          c = c + 1
          .Cells(r, c).Value = IIf(oEmp.VehicleOwnedByEmployee, "YES", "NO")
        End With
        For Each oPrk As SIS.NPRK.nprkPerks In oPrks
          If Not oPrk.Active Then Continue For
          'Delete generated closing Balance Record
          Dim oLgr As SIS.NPRK.nprkLedger = SIS.NPRK.nprkLedger.GetClosingLedger(emp, oPrk.PerkID, TargetFY)
          If oLgr IsNot Nothing Then
            SIS.NPRK.nprkLedger.nprkLedgerDelete(oLgr)
          End If
        Next
        r = r + 1
      Next
      xlPk.Save()
      xlPk.Dispose()

      HttpContext.Current.Server.ScriptTimeout = mLastScriptTimeout
      'Download XL
      Dim DWFile As String = "DeletedClosing_" & TargetFY
      HttpContext.Current.Response.ClearContent()
      HttpContext.Current.Response.AppendHeader("content-disposition", "attachment; filename=" & DWFile & ".xlsx")
      HttpContext.Current.Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(IO.Path.GetFileName(FileName))
      HttpContext.Current.Response.WriteFile(FileName)
      HttpContext.Current.Response.End()
    End Sub

    Public Shared Sub UpdateClosingBalance(ByVal F_CardNo As String)
      Dim T_CardNo As String = "99999"
      If F_CardNo = "" Then
        F_CardNo = "0000"
      Else
        T_CardNo = F_CardNo
      End If
      Dim aEmp As New List(Of String)
      Dim mLastScriptTimeout As Integer = HttpContext.Current.Server.ScriptTimeout
      HttpContext.Current.Server.ScriptTimeout = 600
      Dim TargetFY As Integer = HttpContext.Current.Session("FinYear")
      Dim oFinYear As SIS.NPRK.nprkFinYears = SIS.NPRK.nprkFinYears.nprkFinYearsGetByID(TargetFY)
      Dim EndDate As DateTime = oFinYear.EndDate
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Dim mSql As String = "SELECT CARDNO FROM PRK_Employees WHERE CardNo BETWEEN '" & F_CardNo & "' AND '" & T_CardNo & "'"
          Cmd.CommandType = System.Data.CommandType.Text
          Cmd.CommandText = mSql
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            aEmp.Add(Reader("CardNo"))
          End While
          Reader.Close()
        End Using
      End Using
      Dim xStr As String = "'2458',	'2940',	'2079',	'2079',	'3110',	'3049',	'3083',	'2543',	'1865',	'1654',	'3035',	'2905',	'0586',	'2103',	'2739',	'2454',	'2167',	'3098',	'3082',	'2410',	'2288',	'1652',	'2919',	'5001',	'5009',"
      Dim oPrks As List(Of SIS.NPRK.nprkPerks) = SIS.NPRK.nprkPerks.nprkPerksSelectList("PerkID")
      'Prepare XL 
      Dim FileName As String = HttpContext.Current.Server.MapPath("~/..") & "App_Temp\" & Guid.NewGuid().ToString()
      IO.File.Copy(HttpContext.Current.Server.MapPath("~/App_Templates") & "\PerkClosingPayable.xlsx", FileName)
      Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
      Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)
      Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("Data")

      Dim r As Integer = 5
      Dim c As Integer = 8

      xlWS.Cells(3, 3).Value = TargetFY

      'Write Heading
      For Each oPrk As SIS.NPRK.nprkPerks In oPrks
        If Not oPrk.Active Then Continue For
        With xlWS
          .Cells(r, c).Value = oPrk.Description
          c = c + 1
        End With
      Next
      xlWS.Cells(r, c).Value = "NET PAYABLE"
      'End Heading
      r = 6
      For Each emp As String In aEmp
        If xStr.IndexOf(emp) >= 0 Then Continue For
        'skip Resigned case
        Dim oEmp As SIS.NPRK.nprkEmployees = SIS.NPRK.nprkEmployees.GetByCardNo(emp)
        If oEmp.DOR <> String.Empty Then
          If Convert.ToDateTime(oEmp.DOR) < Convert.ToDateTime(oFinYear.StartDate) Then
            Continue For
          End If
        End If
        'Resigned case
        DoTransfer(emp, TargetFY, EndDate, oEmp.PostedAt, oPrks, r, xlWS, oEmp)
        r = r + 1
      Next
      xlPk.Save()
      xlPk.Dispose()

      HttpContext.Current.Server.ScriptTimeout = mLastScriptTimeout
      'Download XL
      Dim DWFile As String = "PerkClosing_" & TargetFY
      HttpContext.Current.Response.ClearContent()
      HttpContext.Current.Response.AppendHeader("content-disposition", "attachment; filename=" & DWFile & ".xlsx")
      HttpContext.Current.Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(IO.Path.GetFileName(FileName))
      HttpContext.Current.Response.WriteFile(FileName)
      HttpContext.Current.Response.End()
    End Sub
    Private Shared Sub DoTransfer(ByVal CardNo As String, ByVal tFY As Integer, ByVal EndDate As DateTime, ByVal PostedAt As String, ByVal oPrks As List(Of SIS.NPRK.nprkPerks), ByVal r As Integer, ByVal xlWs As ExcelWorksheet, ByVal oEmp As SIS.NPRK.nprkEmployees)
      Dim c As Integer = 1
      Dim tmpPayable As Double = 0
      With xlWs
        .Cells(r, c).Value = oEmp.EmployeeID
        c = c + 1
        .Cells(r, c).Value = oEmp.EmployeeName
        c = c + 1
        .Cells(r, c).Value = oEmp.Department
        c = c + 1
        Try
          .Cells(r, c).Value = SIS.QCM.qcmEmployees.qcmEmployeesGetByID(IIf(oEmp.EmployeeID.ToString.Length < 5, Right("0000" & oEmp.EmployeeID, 4), oEmp.EmployeeID)).HRM_Designations3_Description
        Catch ex As Exception
        End Try
        c = c + 1
        .Cells(r, c).Value = oEmp.DOJ
        c = c + 1
        .Cells(r, c).Value = oEmp.VehicleType
        c = c + 1
        .Cells(r, c).Value = IIf(oEmp.VehicleOwnedByEmployee, "YES", "NO")
      End With
      For Each oPrk As SIS.NPRK.nprkPerks In oPrks
        If Not oPrk.Active Then Continue For
        c = c + 1
        'Delete generated closing Balance Record
        Dim oLgr As SIS.NPRK.nprkLedger = SIS.NPRK.nprkLedger.GetClosingLedger(CardNo, oPrk.PerkID, tFY)
        If oLgr IsNot Nothing Then
          SIS.NPRK.nprkLedger.nprkLedgerDelete(oLgr)
        End If

        Dim eAmt As Decimal = SIS.NPRK.nprkEntitlements.GetNetValue(CardNo, oPrk.PerkID, tFY)
        Dim pAmt As Decimal = SIS.NPRK.nprkLedger.GetNetValue(CardNo, oPrk.PerkID, tFY)
        Dim tAmt As Decimal = eAmt + pAmt

        If Math.Abs(tAmt) < 1 Then
          tAmt = 0
        End If
        If PostedAt = "Site" And oPrk.PerkID = prkPerk.TwoWheelerMaint Then
          tAmt = 0
        End If

        If tAmt <> 0 Then
          oLgr = New SIS.NPRK.nprkLedger
          With oLgr
            .EmployeeID = CardNo
            .FinYear = tFY
            .Remarks = "Auto Generated Closing"
            .PerkID = oPrk.PerkID
            .TranDate = EndDate
            .TranType = "ADJ"
            .UOM = oPrk.UOM
            .Value = -1 * tAmt
            .ApplicationID = 0
            .Amount = -1 * tAmt
            .CreatedBy = Convert.ToInt32(HttpContext.Current.Session("LoginID"))
          End With
          SIS.NPRK.nprkLedger.InsertData(oLgr)
        End If
        'write in Excel
        If oEmp.VehicleType <> "None" Then
          Select Case oPrk.PerkID
            Case prkPerk.MedicalBenifit, prkPerk.CarMaintenance, prkPerk.TwoWheelerMaint, prkPerk.Petrol, prkPerk.Uniform, prkPerk.NewspaperMagazine, prkPerk.ClubSubscription
            Case Else
              tmpPayable += tAmt
              xlWs.Cells(r, c).Value = tAmt
          End Select
        Else
          tmpPayable += tAmt
          xlWs.Cells(r, c).Value = tAmt
        End If
      Next
      c = c + 1
      xlWs.Cells(r, c).Value = tmpPayable
    End Sub
  End Class
End Namespace
Public Class clsCard
  Public Property CardNo As String = ""
  Sub New(ByVal rd As SqlDataReader)
    CardNo = rd("CardNo")
  End Sub
  Sub New()
    'dummy
  End Sub
End Class