Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  Partial Public Class nprkSiteAllowanceClaims
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      Select Case StatusID
        Case saClaimStates.Returned
          mRet = Drawing.Color.Red
        Case saClaimStates.Free
          mRet = Drawing.Color.Black
        Case saClaimStates.SubmittedToHO
          mRet = Drawing.Color.DarkGreen
        Case saClaimStates.ForwardedToAccounts, saClaimStates.UnderPaymentByAccounts, saClaimStates.Paid
          mRet = Drawing.Color.DarkGoldenrod
      End Select
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = False
      Select Case StatusID
        Case saClaimStates.Free, saClaimStates.Returned
          mRet = True
      End Select
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      Select Case StatusID
        Case saClaimStates.Free, saClaimStates.Returned
          mRet = True
      End Select
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case StatusID
            Case saClaimStates.Free, saClaimStates.Returned
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function InitiateWF(ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal EmployeeID As String) As SIS.NPRK.nprkSiteAllowanceClaims
      Dim Results As SIS.NPRK.nprkSiteAllowanceClaims = nprkSiteAllowanceClaimsGetByID(FinYear, Quarter, EmployeeID)
      With Results
        .ApproverRemarks = ""
        .StatusID = saClaimStates.SubmittedToHO
        .CreatedOn = Now
      End With
      Results = SIS.NPRK.nprkSiteAllowanceClaims.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function UZ_nprkSiteAllowanceClaimsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal FinYear As Int32, ByVal Quarter As Int32) As List(Of SIS.NPRK.nprkSiteAllowanceClaims)
      Dim Results As List(Of SIS.NPRK.nprkSiteAllowanceClaims) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprk_LG_SiteAllowanceClaimsSelectListSearch"
            Cmd.CommandText = "spnprkSiteAllowanceClaimsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprk_LG_SiteAllowanceClaimsSelectListFilteres"
            Cmd.CommandText = "spnprkSiteAllowanceClaimsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FinYear", SqlDbType.Int, 10, IIf(FinYear = Nothing, 0, FinYear))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_Quarter", SqlDbType.Int, 10, IIf(Quarter = Nothing, 0, Quarter))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.NVarChar, 8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkSiteAllowanceClaims)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkSiteAllowanceClaims(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UpdateEntitlementDaysAndAmounts(ByVal rec As SIS.NPRK.nprkSiteAllowanceClaims) As SIS.NPRK.nprkSiteAllowanceClaims
      Dim ci As System.Globalization.CultureInfo = SIS.SYS.Utilities.SessionManager.ci
      Dim oEmp As SIS.QCM.qcmEmployees = Nothing
      If rec.EmployeeID = String.Empty Then
        oEmp = SIS.QCM.qcmEmployees.qcmEmployeesGetByID(Global.System.Web.HttpContext.Current.Session("LoginID"))
        rec.EmployeeID = oEmp.CardNo
      Else
        oEmp = SIS.QCM.qcmEmployees.qcmEmployeesGetByID(rec.EmployeeID)
      End If
      If oEmp.C_OfficeID <> 6 Then Throw New Exception("You are NOT defined as Site Employee. Can NOT Claim Site Allowance.")
      If oEmp.CategoryID = "" Then Throw New Exception("TA Category not defined, Pl. get it defined first.")
      Dim Mon As Integer = IIf(rec.Quarter = 4, 0, rec.Quarter) * 3
      Dim Mon1 As Integer = Mon + 1
      Dim Mon2 As Integer = Mon + 2
      Dim Mon3 As Integer = Mon + 3
      Dim TDays1 As Integer = Date.DaysInMonth(rec.FinYear, Mon1)
      Dim TDays2 As Integer = Date.DaysInMonth(rec.FinYear, Mon2)
      Dim TDays3 As Integer = Date.DaysInMonth(rec.FinYear, Mon3)

      If oEmp.C_DateOfJoining = "" Then Throw New Exception("Date of Joining NOT Defined.")

      Dim Jdt As DateTime = Convert.ToDateTime(oEmp.C_DateOfJoining, ci)
      Dim sRdt As String = ""
      If oEmp.C_DateOfReleaving <> "" Then
        sRdt = oEmp.C_DateOfReleaving
      End If
      If sRdt = String.Empty Then
        Dim jYrMn As String = Jdt.Year.ToString & Jdt.Month.ToString.PadLeft(2, "0")
        Dim YrMn As String = ""

        YrMn = rec.FinYear & Mon1.ToString.PadLeft(2, "0")
        If YrMn < jYrMn Then
          rec.Entitled1Days = "0.00"
        ElseIf YrMn = jYrMn Then
          rec.Entitled1Days = TDays1 - Jdt.Day + 1
        Else
          rec.Entitled1Days = TDays1
        End If

        YrMn = rec.FinYear & Mon2.ToString.PadLeft(2, "0")
        If YrMn < jYrMn Then
          rec.Entitled2Days = "0.00"
        ElseIf YrMn = jYrMn Then
          rec.Entitled2Days = TDays2 - Jdt.Day + 1
        Else
          rec.Entitled2Days = TDays2
        End If

        YrMn = rec.FinYear & Mon3.ToString.PadLeft(2, "0")
        If YrMn < jYrMn Then
          rec.Entitled3Days = "0.00"
        ElseIf YrMn = jYrMn Then
          rec.Entitled3Days = TDays3 - Jdt.Day + 1
        Else
          rec.Entitled3Days = TDays3
        End If
      Else
        Dim Rdt As DateTime = Convert.ToDateTime(oEmp.C_DateOfReleaving, ci)

        Dim jYrMn As String = Jdt.Year.ToString & Jdt.Month.ToString.PadLeft(2, "0")
        Dim RYrMn As String = Rdt.Year.ToString & Rdt.Month.ToString.PadLeft(2, "0")
        Dim YrMn As String = ""

        YrMn = rec.FinYear & Mon1.ToString.PadLeft(2, "0")
        rec.Entitled1Days = "0.00"
        If YrMn = jYrMn And RYrMn > YrMn Then
          rec.Entitled1Days = TDays1 - Jdt.Day + 1
        ElseIf YrMn = jYrMn And RYrMn = YrMn Then
          rec.Entitled1Days = TDays1 - Jdt.Day + 1 - (TDays1 - Rdt.Day) + 1
        ElseIf YrMn > jYrMn And RYrMn > YrMn Then
          rec.Entitled1Days = TDays1
        ElseIf YrMn > jYrMn And RYrMn = YrMn Then
          rec.Entitled1Days = Rdt.Day
        End If

        YrMn = rec.FinYear & Mon2.ToString.PadLeft(2, "0")
        rec.Entitled2Days = "0.00"
        If YrMn = jYrMn And RYrMn > YrMn Then
          rec.Entitled2Days = TDays2 - Jdt.Day + 1
        ElseIf YrMn = jYrMn And RYrMn = YrMn Then
          rec.Entitled2Days = TDays2 - Jdt.Day + 1 - (TDays2 - Rdt.Day) + 1
        ElseIf YrMn > jYrMn And RYrMn > YrMn Then
          rec.Entitled2Days = TDays2
        ElseIf YrMn > jYrMn And RYrMn = YrMn Then
          rec.Entitled2Days = Rdt.Day
        End If

        YrMn = rec.FinYear & Mon3.ToString.PadLeft(2, "0")
        rec.Entitled3Days = "0.00"
        If YrMn = jYrMn And RYrMn > YrMn Then
          rec.Entitled3Days = TDays3 - Jdt.Day + 1
        ElseIf YrMn = jYrMn And RYrMn = YrMn Then
          rec.Entitled3Days = TDays3 - Jdt.Day + 1 - (TDays3 - Rdt.Day) + 1
        ElseIf YrMn > jYrMn And RYrMn > YrMn Then
          rec.Entitled3Days = TDays3
        ElseIf YrMn > jYrMn And RYrMn = YrMn Then
          rec.Entitled3Days = Rdt.Day
        End If
      End If
      With rec
        .Entitled1Days = Convert.ToDecimal(.Entitled1Days)
        .Entitled2Days = Convert.ToDecimal(.Entitled2Days)
        .Entitled3Days = Convert.ToDecimal(.Entitled3Days)
        'No Change in Applied Days as decided in meeting
        .Applied1Days = .Entitled1Days
        .Applied2Days = .Entitled2Days
        .Applied3Days = .Entitled3Days
        'No Change in Approved Days as decided in meeting
        .Approved1Days = .Entitled1Days
        .Approved2Days = .Entitled2Days
        .Approved3Days = .Entitled3Days

      End With
      '----Update Amounts
      Dim tmpAmount As String = ""

      tmpAmount = SIS.NPRK.nprkSiteAllowanceEntitlement.GetEntitlementByFinYearMonth(rec.FinYear, Mon1, oEmp.CategoryID).EntitlementAmount
      If tmpAmount = "" Then tmpAmount = "0.00"
      rec.Entitled1Amount = tmpAmount
      tmpAmount = SIS.NPRK.nprkSiteAllowanceEntitlement.GetEntitlementByFinYearMonth(rec.FinYear, Mon2, oEmp.CategoryID).EntitlementAmount
      If tmpAmount = "" Then tmpAmount = "0.00"
      rec.Entitled2Amount = tmpAmount
      tmpAmount = SIS.NPRK.nprkSiteAllowanceEntitlement.GetEntitlementByFinYearMonth(rec.FinYear, Mon3, oEmp.CategoryID).EntitlementAmount
      If tmpAmount = "" Then tmpAmount = "0.00"
      rec.Entitled3Amount = tmpAmount

      rec = UpdateAmounts(rec)

      With rec
        .TotalEntitledAmount = Convert.ToDecimal(.Entitled1Amount) + Convert.ToDecimal(.Entitled2Amount) + Convert.ToDecimal(.Entitled3Amount)
        .TotalAppliedAmount = Convert.ToDecimal(.Applied1Amount) + Convert.ToDecimal(.Applied2Amount) + Convert.ToDecimal(.Applied3Amount)
        .TotalApprovedAmount = Convert.ToDecimal(.Approved1Amount) + Convert.ToDecimal(.Approved2Amount) + Convert.ToDecimal(.Approved3Amount)
      End With

      Return rec
    End Function

    Public Shared Function UpdateAmounts(ByVal rec As SIS.NPRK.nprkSiteAllowanceClaims) As SIS.NPRK.nprkSiteAllowanceClaims
      Dim TDays1 As Integer = Date.DaysInMonth(rec.FinYear, (IIf(rec.Quarter = 4, 0, rec.Quarter) * 3) + 1)
      Dim TDays2 As Integer = Date.DaysInMonth(rec.FinYear, (IIf(rec.Quarter = 4, 0, rec.Quarter) * 3) + 2)
      Dim TDays3 As Integer = Date.DaysInMonth(rec.FinYear, (IIf(rec.Quarter = 4, 0, rec.Quarter) * 3) + 3)
      rec.Applied1Amount = (rec.Entitled1Amount / TDays1) * rec.Applied1Days
      rec.Applied2Amount = (rec.Entitled2Amount / TDays2) * rec.Applied2Days
      rec.Applied3Amount = (rec.Entitled3Amount / TDays3) * rec.Applied3Days
      rec.Approved1Amount = (rec.Entitled1Amount / TDays1) * rec.Approved1Days
      rec.Approved2Amount = (rec.Entitled2Amount / TDays2) * rec.Approved2Days
      rec.Approved3Amount = (rec.Entitled3Amount / TDays3) * rec.Approved3Days
      Return rec
    End Function

    Public Shared Function UZ_nprkSiteAllowanceClaimsInsert(ByVal Record As SIS.NPRK.nprkSiteAllowanceClaims) As SIS.NPRK.nprkSiteAllowanceClaims
      Record = UpdateEntitlementDaysAndAmounts(Record)
      With Record
        .CreatedOn = Now
        .Linked = False
        .CreatedBy = IIf(Record.EmployeeID = "", Global.System.Web.HttpContext.Current.Session("LoginID"), Record.EmployeeID)
        .StatusID = saClaimStates.Free
        .EmployeeID = IIf(Record.EmployeeID = "", Global.System.Web.HttpContext.Current.Session("LoginID"), Record.EmployeeID)
      End With
      Return SIS.NPRK.nprkSiteAllowanceClaims.InsertData(Record)
    End Function
    Public Shared Function UZ_nprkSiteAllowanceClaimsUpdate(ByVal Record As SIS.NPRK.nprkSiteAllowanceClaims) As SIS.NPRK.nprkSiteAllowanceClaims
      Record = UpdateEntitlementDaysAndAmounts(Record)
      Dim _Result As SIS.NPRK.nprkSiteAllowanceClaims = nprkSiteAllowanceClaimsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_nprkSiteAllowanceClaimsDelete(ByVal Record As SIS.NPRK.nprkSiteAllowanceClaims) As Integer
      Dim _Result as Integer = nprkSiteAllowanceClaimsDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_FinYear"), Object).SelectedValue = ""
          CType(.FindControl("F_Quarter"), Object).SelectedValue = ""
          CType(.FindControl("F_Entitled1Days"), TextBox).Text = "0.00"
          CType(.FindControl("F_Entitled2Days"), TextBox).Text = "0.00"
          CType(.FindControl("F_Entitled3Days"), TextBox).Text = "0.00"
          CType(.FindControl("F_Applied1Days"), TextBox).Text = "0.00"
          CType(.FindControl("F_Applied2Days"), TextBox).Text = "0.00"
          CType(.FindControl("F_Applied3Days"), TextBox).Text = "0.00"
          CType(.FindControl("F_UserRemarks"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
