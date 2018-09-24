Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  Partial Public Class nprkEmployeesMonthlyBasic
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
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
      Dim mRet As Boolean = True
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
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function UZ_nprkEmployeesMonthlyBasicSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal EmployeeID As Int32) As List(Of SIS.NPRK.nprkEmployeesMonthlyBasic)
      Dim Results As List(Of SIS.NPRK.nprkEmployeesMonthlyBasic) = Nothing
      If OrderBy = String.Empty Then OrderBy = "FinYear DESC"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprk_LG_EmployeesMonthlyBasicSelectListSearch"
            Cmd.CommandText = "spnprkEmployeesMonthlyBasicSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprk_LG_EmployeesMonthlyBasicSelectListFilteres"
            Cmd.CommandText = "spnprkEmployeesMonthlyBasicSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EmployeeID", SqlDbType.Int, 10, IIf(EmployeeID = Nothing, 0, EmployeeID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkEmployeesMonthlyBasic)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkEmployeesMonthlyBasic(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_nprkEmployeesMonthlyBasicInsert(ByVal Record As SIS.NPRK.nprkEmployeesMonthlyBasic) As SIS.NPRK.nprkEmployeesMonthlyBasic
      Dim _Result As SIS.NPRK.nprkEmployeesMonthlyBasic = nprkEmployeesMonthlyBasicInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_nprkEmployeesMonthlyBasicUpdate(ByVal Record As SIS.NPRK.nprkEmployeesMonthlyBasic) As SIS.NPRK.nprkEmployeesMonthlyBasic
      Dim _Result As SIS.NPRK.nprkEmployeesMonthlyBasic = nprkEmployeesMonthlyBasicUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_nprkEmployeesMonthlyBasicDelete(ByVal Record As SIS.NPRK.nprkEmployeesMonthlyBasic) As Integer
      Dim _Result As Integer = nprkEmployeesMonthlyBasicDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_RecordID"), TextBox).Text = ""
          CType(.FindControl("F_EmployeeID"), TextBox).Text = ""
          CType(.FindControl("F_EmployeeID_Display"), Label).Text = ""
          CType(.FindControl("F_SalMonth"), TextBox).Text = 0
          CType(.FindControl("F_SalYear"), TextBox).Text = 0
          CType(.FindControl("F_NetBasic"), TextBox).Text = 0
          CType(.FindControl("F_FinYear"), TextBox).Text = 0
          CType(.FindControl("F_CategoryID"), TextBox).Text = 0
          CType(.FindControl("F_PostedAt"), TextBox).Text = ""
          CType(.FindControl("F_VehicleType"), TextBox).Text = ""
          CType(.FindControl("F_ESI"), CheckBox).Checked = False
          CType(.FindControl("F_ESIAmount"), TextBox).Text = 0
          CType(.FindControl("F_MaintenanceAllowed"), CheckBox).Checked = False
          CType(.FindControl("F_TWInSalary"), CheckBox).Checked = False
          CType(.FindControl("F_MobileLimit"), TextBox).Text = 0
          CType(.FindControl("F_MobileWithInternet"), CheckBox).Checked = False
          CType(.FindControl("F_MobileBillPlanID"), TextBox).Text = 0
          CType(.FindControl("F_LandlineLimit"), TextBox).Text = 0
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function GetByEMY(ByVal EmployeeID As Integer, ByVal ForMonth As Integer, ByVal ForYear As Integer) As SIS.NPRK.nprkEmployeesMonthlyBasic
      Dim Results As SIS.NPRK.nprkEmployeesMonthlyBasic = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprk_LG_EmployeesMonthlyBasicByEMY"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.Int, 10, EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ForMonth", SqlDbType.Int, 10, ForMonth)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ForYear", SqlDbType.Int, 10, ForYear)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.NPRK.nprkEmployeesMonthlyBasic(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UpdateFASBasic(ByVal ForMonth As Integer, Optional ByVal UpdateEmpInfo As Boolean = False) As Boolean
      Dim mLastScriptTimeout As Integer = HttpContext.Current.Server.ScriptTimeout
      HttpContext.Current.Server.ScriptTimeout = 600

      Dim oFinYear As SIS.NPRK.nprkFinYears = SIS.NPRK.nprkFinYears.nprkFinYearsGetByID(HttpContext.Current.Session("FinYear"))
      Dim ForYear As Integer = 4
      Dim dt As DateTime = oFinYear.StartDate
      Do While dt < oFinYear.EndDate
        If dt.Month = ForMonth Then
          ForYear = dt.Year
          Exit Do
        End If
        dt = dt.AddMonths(1)
      Loop
      Dim sql As String = ""
      sql &= "		SELECT s.fk_emp_code AS CardNo, "
      sql &= "    sum(s.paid_amount + isnull(s.arr_amt,0)) AS NetBasic, "
      sql &= "    so.esi as ESIC "
      sql &= "    FROM Salary as s "
      sql &= "    left outer join SalaryOtherDetails as so "
      sql &= "      on (so.fk_emp_code = s.fk_Emp_Code "
      sql &= "      and so.mm = s.curr_mm "
      sql &= "      and so.yyyy = s.curr_yy) "
      sql &= "    WHERE s.curr_mm = " & ForMonth & " AND s.curr_yy = '" & ForYear & "' "
      sql &= "    AND s.fk_pay_code in ('A00001','A00006') "
      sql &= "    group by s.fk_emp_code, so.esi"
      sql &= "    order by s.fk_emp_code"
      Dim Results As New List(Of wpEmp)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetWebPayConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = sql
          Try
            Con.Open()
          Catch ex As Exception
            HttpContext.Current.Server.ScriptTimeout = mLastScriptTimeout
            Return False
          End Try
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New wpEmp(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      ReSyncBasic(Results, ForMonth, ForYear, oFinYear.FinYear, UpdateEmpInfo)
      HttpContext.Current.Server.ScriptTimeout = mLastScriptTimeout
      Return True
    End Function
    Private Shared Sub ReSyncBasic(ByVal oRs As List(Of wpEmp), ByVal ForMonth As Integer, ByVal ForYear As Integer, ByVal FinYear As Integer, Optional ByVal UpdateEmpInfo As Boolean = False)
      If Not oRs Is Nothing Then
        For Each rs As wpEmp In oRs
          Dim EmployeeID As Integer = Convert.ToInt32(rs.CardNo)
          Dim oEmp As SIS.NPRK.nprkEmployees = SIS.NPRK.nprkEmployees.nprkEmployeesGetByID(EmployeeID)
          If oEmp Is Nothing Then
            Continue For
          End If
          Dim oBas As SIS.NPRK.nprkEmployeesMonthlyBasic = SIS.NPRK.nprkEmployeesMonthlyBasic.GetByEMY(EmployeeID, ForMonth, ForYear)
          If oBas Is Nothing Then
            oBas = New SIS.NPRK.nprkEmployeesMonthlyBasic
            With oBas
              .EmployeeID = EmployeeID
              .SalMonth = ForMonth
              .SalYear = ForYear
              .FinYear = FinYear
              .NetBasic = rs.NetBasic
              .ESIAmount = rs.ESIC
              'Other Values
              .CategoryID = oEmp.CategoryID
              .ESI = oEmp.ESI
              .MaintenanceAllowed = oEmp.MaintenanceAllowed
              .PostedAt = oEmp.PostedAt
              .VehicleType = oEmp.VehicleType
              .TWInSalary = oEmp.TWInSalary
              .MobileLimit = oEmp.MobileLimit
              .MobileWithInternet = oEmp.MobileWithInternet
              .MobileBillPlanID = oEmp.MobileBillPlanID
              .LandlineLimit = oEmp.LandlineLimit
            End With
            Try
              SIS.NPRK.nprkEmployeesMonthlyBasic.InsertData(oBas)
            Catch ex As Exception
            End Try
          Else
            With oBas
              .NetBasic = rs.NetBasic
              .ESIAmount = rs.ESIC
              'Other Values Remove after processing last Years And Current Years data
              If UpdateEmpInfo Then
                .CategoryID = oEmp.CategoryID
                .ESI = oEmp.ESI
                .MaintenanceAllowed = oEmp.MaintenanceAllowed
                .PostedAt = oEmp.PostedAt
                .VehicleType = oEmp.VehicleType
                .TWInSalary = oEmp.TWInSalary
                .MobileLimit = oEmp.MobileLimit
                .MobileWithInternet = oEmp.MobileWithInternet
                .MobileBillPlanID = oEmp.MobileBillPlanID
                .LandlineLimit = oEmp.LandlineLimit
              End If
            End With
            SIS.NPRK.nprkEmployeesMonthlyBasic.UpdateData(oBas)
          End If
        Next
      End If
    End Sub
    Private Class wpEmp
      Public Property CardNo As String = ""
      Public Property NetBasic As Decimal = 0
      Public Property ESIC As Decimal = 0
      Sub New()
        'dummy
      End Sub
      Public Sub New(ByVal Reader As SqlDataReader)
        Try
          For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
            If pi.MemberType = Reflection.MemberTypes.Property Then
              Try
                If Convert.IsDBNull(Reader(pi.Name)) Then
                  CallByName(Me, pi.Name, CallType.Let, String.Empty)
                Else
                  CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                End If
              Catch ex As Exception
              End Try
            End If
          Next
        Catch ex As Exception
        End Try
      End Sub
    End Class
  End Class
End Namespace
