Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel

Namespace SIS.NPRK
  <DataObject()> _
  Partial Public Class nprkEmployeesMonthlyBasic
    Private Shared _RecordCount As Integer
    Private _RecordID As Int32 = 0
    Private _EmployeeID As Int32 = 0
    Private _SalMonth As Int32 = 0
    Private _SalYear As Int32 = 0
    Private _NetBasic As Decimal = 0
    Private _FinYear As Int32 = 0
    Private _CategoryID As Int32 = 0
    Private _PostedAt As String = ""
    Private _VehicleType As String = ""
    Private _ESI As Boolean = False
    Private _ESIAmount As Decimal = 0
    Private _MaintenanceAllowed As Boolean = False
    Private _TWInSalary As Boolean = False
    Private _MobileLimit As String = "0.00"
    Private _MobileWithInternet As Boolean = False
    Private _MobileBillPlanID As String = ""
    Private _LandlineLimit As String = "0.00"
    Private _WithDriver As Boolean = False
    Private _PRK_Employees1_EmployeeName As String = ""
    Private _PRK_MobileBillPlans2_Description As String = ""
    Private _FK_PRK_EmployeesMonthlyBasic_PRK_Employees As SIS.NPRK.nprkEmployees = Nothing
    Private _FK_PRK_EmployeesMonthlyBasic_MobileBillPlanID As SIS.NPRK.nprkMobileBillPlans = Nothing
    Public ReadOnly Property ForeColor() As System.Drawing.Color
      Get
        Dim mRet As System.Drawing.Color = Drawing.Color.Blue
        Try
          mRet = GetColor()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Visible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Enable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Property WithDriver As Boolean
      Get
        Return _WithDriver
      End Get
      Set(value As Boolean)
        _WithDriver = value
      End Set
    End Property
    Public Property RecordID() As Int32
      Get
        Return _RecordID
      End Get
      Set(ByVal value As Int32)
        _RecordID = value
      End Set
    End Property
    Public Property EmployeeID() As Int32
      Get
        Return _EmployeeID
      End Get
      Set(ByVal value As Int32)
        _EmployeeID = value
      End Set
    End Property
    Public Property SalMonth() As Int32
      Get
        Return _SalMonth
      End Get
      Set(ByVal value As Int32)
        _SalMonth = value
      End Set
    End Property
    Public Property SalYear() As Int32
      Get
        Return _SalYear
      End Get
      Set(ByVal value As Int32)
        _SalYear = value
      End Set
    End Property
    Public Property NetBasic() As Decimal
      Get
        Return _NetBasic
      End Get
      Set(ByVal value As Decimal)
        _NetBasic = value
      End Set
    End Property
    Public Property FinYear() As Int32
      Get
        Return _FinYear
      End Get
      Set(ByVal value As Int32)
        _FinYear = value
      End Set
    End Property
    Public Property CategoryID() As Int32
      Get
        Return _CategoryID
      End Get
      Set(ByVal value As Int32)
        _CategoryID = value
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
    Public Property VehicleType() As String
      Get
        Return _VehicleType
      End Get
      Set(ByVal value As String)
        _VehicleType = value
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
    Public Property ESIAmount() As Decimal
      Get
        Return _ESIAmount
      End Get
      Set(ByVal value As Decimal)
        _ESIAmount = value
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
    Public Property TWInSalary() As Boolean
      Get
        Return _TWInSalary
      End Get
      Set(ByVal value As Boolean)
        _TWInSalary = value
      End Set
    End Property
    Public Property MobileLimit() As String
      Get
        Return _MobileLimit
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _MobileLimit = "0.00"
         Else
           _MobileLimit = value
         End If
      End Set
    End Property
    Public Property MobileWithInternet() As Boolean
      Get
        Return _MobileWithInternet
      End Get
      Set(ByVal value As Boolean)
        _MobileWithInternet = value
      End Set
    End Property
    Public Property MobileBillPlanID() As String
      Get
        Return _MobileBillPlanID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _MobileBillPlanID = ""
         Else
           _MobileBillPlanID = value
         End If
      End Set
    End Property
    Public Property LandlineLimit() As String
      Get
        Return _LandlineLimit
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _LandlineLimit = "0.00"
         Else
           _LandlineLimit = value
         End If
      End Set
    End Property
    Public Property PRK_Employees1_EmployeeName() As String
      Get
        Return _PRK_Employees1_EmployeeName
      End Get
      Set(ByVal value As String)
        _PRK_Employees1_EmployeeName = value
      End Set
    End Property
    Public Property PRK_MobileBillPlans2_Description() As String
      Get
        Return _PRK_MobileBillPlans2_Description
      End Get
      Set(ByVal value As String)
        _PRK_MobileBillPlans2_Description = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _RecordID
      End Get
    End Property
    Public Shared Property RecordCount() As Integer
      Get
        Return _RecordCount
      End Get
      Set(ByVal value As Integer)
        _RecordCount = value
      End Set
    End Property
    Public Class PKnprkEmployeesMonthlyBasic
      Private _RecordID As Int32 = 0
      Public Property RecordID() As Int32
        Get
          Return _RecordID
        End Get
        Set(ByVal value As Int32)
          _RecordID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PRK_EmployeesMonthlyBasic_PRK_Employees() As SIS.NPRK.nprkEmployees
      Get
        If _FK_PRK_EmployeesMonthlyBasic_PRK_Employees Is Nothing Then
          _FK_PRK_EmployeesMonthlyBasic_PRK_Employees = SIS.NPRK.nprkEmployees.nprkEmployeesGetByID(_EmployeeID)
        End If
        Return _FK_PRK_EmployeesMonthlyBasic_PRK_Employees
      End Get
    End Property
    Public ReadOnly Property FK_PRK_EmployeesMonthlyBasic_MobileBillPlanID() As SIS.NPRK.nprkMobileBillPlans
      Get
        If _FK_PRK_EmployeesMonthlyBasic_MobileBillPlanID Is Nothing Then
          _FK_PRK_EmployeesMonthlyBasic_MobileBillPlanID = SIS.NPRK.nprkMobileBillPlans.nprkMobileBillPlansGetByID(_MobileBillPlanID)
        End If
        Return _FK_PRK_EmployeesMonthlyBasic_MobileBillPlanID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkEmployeesMonthlyBasicGetNewRecord() As SIS.NPRK.nprkEmployeesMonthlyBasic
      Return New SIS.NPRK.nprkEmployeesMonthlyBasic()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkEmployeesMonthlyBasicGetByID(ByVal RecordID As Int32) As SIS.NPRK.nprkEmployeesMonthlyBasic
      Dim Results As SIS.NPRK.nprkEmployeesMonthlyBasic = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkEmployeesMonthlyBasicSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RecordID",SqlDbType.Int,RecordID.ToString.Length, RecordID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
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
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByEmployeeID(ByVal EmployeeID As Int32, ByVal OrderBy as String) As List(Of SIS.NPRK.nprkEmployeesMonthlyBasic)
      Dim Results As List(Of SIS.NPRK.nprkEmployeesMonthlyBasic) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkEmployeesMonthlyBasicSelectByEmployeeID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.Int,EmployeeID.ToString.Length, EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
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
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkEmployeesMonthlyBasicSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal EmployeeID As Int32) As List(Of SIS.NPRK.nprkEmployeesMonthlyBasic)
      Dim Results As List(Of SIS.NPRK.nprkEmployeesMonthlyBasic) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprkEmployeesMonthlyBasicSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprkEmployeesMonthlyBasicSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EmployeeID",SqlDbType.Int,10, IIf(EmployeeID = Nothing, 0,EmployeeID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
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
    Public Shared Function nprkEmployeesMonthlyBasicSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal EmployeeID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkEmployeesMonthlyBasicGetByID(ByVal RecordID As Int32, ByVal Filter_EmployeeID As Int32) As SIS.NPRK.nprkEmployeesMonthlyBasic
      Return nprkEmployeesMonthlyBasicGetByID(RecordID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function nprkEmployeesMonthlyBasicInsert(ByVal Record As SIS.NPRK.nprkEmployeesMonthlyBasic) As SIS.NPRK.nprkEmployeesMonthlyBasic
      Dim _Rec As SIS.NPRK.nprkEmployeesMonthlyBasic = SIS.NPRK.nprkEmployeesMonthlyBasic.nprkEmployeesMonthlyBasicGetNewRecord()
      With _Rec
        .EmployeeID = Record.EmployeeID
        .SalMonth = Record.SalMonth
        .SalYear = Record.SalYear
        .NetBasic = Record.NetBasic
        .FinYear = Record.FinYear
        .CategoryID = Record.CategoryID
        .PostedAt = Record.PostedAt
        .VehicleType = Record.VehicleType
        .ESI = Record.ESI
        .ESIAmount = Record.ESIAmount
        .MaintenanceAllowed = Record.MaintenanceAllowed
        .TWInSalary = Record.TWInSalary
        .MobileLimit = Record.MobileLimit
        .MobileWithInternet = Record.MobileWithInternet
        .MobileBillPlanID = Record.MobileBillPlanID
        .LandlineLimit = Record.LandlineLimit
        .WithDriver = Record.WithDriver
      End With
      Return SIS.NPRK.nprkEmployeesMonthlyBasic.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.NPRK.nprkEmployeesMonthlyBasic) As SIS.NPRK.nprkEmployeesMonthlyBasic
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkEmployeesMonthlyBasicInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.Int,11, Record.EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SalMonth",SqlDbType.Int,11, Record.SalMonth)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SalYear",SqlDbType.Int,11, Record.SalYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NetBasic",SqlDbType.Decimal,13, Record.NetBasic)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryID",SqlDbType.Int,11, Record.CategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedAt",SqlDbType.NVarChar,21, Record.PostedAt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleType",SqlDbType.NVarChar,21, Record.VehicleType)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ESI",SqlDbType.Bit,3, Record.ESI)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ESIAmount",SqlDbType.Decimal,13, Record.ESIAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaintenanceAllowed",SqlDbType.Bit,3, Record.MaintenanceAllowed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TWInSalary",SqlDbType.Bit,3, Record.TWInSalary)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MobileLimit",SqlDbType.Decimal,9, Iif(Record.MobileLimit= "" ,Convert.DBNull, Record.MobileLimit))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MobileWithInternet",SqlDbType.Bit,3, Record.MobileWithInternet)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MobileBillPlanID",SqlDbType.Int,11, Iif(Record.MobileBillPlanID= "" ,Convert.DBNull, Record.MobileBillPlanID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LandlineLimit",SqlDbType.Decimal,9, Iif(Record.LandlineLimit= "" ,Convert.DBNull, Record.LandlineLimit))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WithDriver", SqlDbType.Bit, 3, Record.WithDriver)
          Cmd.Parameters.Add("@Return_RecordID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_RecordID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.RecordID = Cmd.Parameters("@Return_RecordID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function nprkEmployeesMonthlyBasicUpdate(ByVal Record As SIS.NPRK.nprkEmployeesMonthlyBasic) As SIS.NPRK.nprkEmployeesMonthlyBasic
      Dim _Rec As SIS.NPRK.nprkEmployeesMonthlyBasic = SIS.NPRK.nprkEmployeesMonthlyBasic.nprkEmployeesMonthlyBasicGetByID(Record.RecordID)
      With _Rec
        .EmployeeID = Record.EmployeeID
        .SalMonth = Record.SalMonth
        .SalYear = Record.SalYear
        .NetBasic = Record.NetBasic
        .FinYear = Record.FinYear
        .CategoryID = Record.CategoryID
        .PostedAt = Record.PostedAt
        .VehicleType = Record.VehicleType
        .ESI = Record.ESI
        .ESIAmount = Record.ESIAmount
        .MaintenanceAllowed = Record.MaintenanceAllowed
        .TWInSalary = Record.TWInSalary
        .MobileLimit = Record.MobileLimit
        .MobileWithInternet = Record.MobileWithInternet
        .MobileBillPlanID = Record.MobileBillPlanID
        .LandlineLimit = Record.LandlineLimit
        .WithDriver = Record.WithDriver
      End With
      Return SIS.NPRK.nprkEmployeesMonthlyBasic.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.NPRK.nprkEmployeesMonthlyBasic) As SIS.NPRK.nprkEmployeesMonthlyBasic
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkEmployeesMonthlyBasicUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RecordID",SqlDbType.Int,11, Record.RecordID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.Int,11, Record.EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SalMonth",SqlDbType.Int,11, Record.SalMonth)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SalYear",SqlDbType.Int,11, Record.SalYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NetBasic",SqlDbType.Decimal,13, Record.NetBasic)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryID",SqlDbType.Int,11, Record.CategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedAt",SqlDbType.NVarChar,21, Record.PostedAt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleType",SqlDbType.NVarChar,21, Record.VehicleType)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ESI",SqlDbType.Bit,3, Record.ESI)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ESIAmount",SqlDbType.Decimal,13, Record.ESIAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaintenanceAllowed",SqlDbType.Bit,3, Record.MaintenanceAllowed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TWInSalary",SqlDbType.Bit,3, Record.TWInSalary)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MobileLimit",SqlDbType.Decimal,9, Iif(Record.MobileLimit= "" ,Convert.DBNull, Record.MobileLimit))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MobileWithInternet",SqlDbType.Bit,3, Record.MobileWithInternet)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MobileBillPlanID",SqlDbType.Int,11, Iif(Record.MobileBillPlanID= "" ,Convert.DBNull, Record.MobileBillPlanID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LandlineLimit",SqlDbType.Decimal,9, Iif(Record.LandlineLimit= "" ,Convert.DBNull, Record.LandlineLimit))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WithDriver", SqlDbType.Bit, 3, Record.WithDriver)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    Public Shared Function nprkEmployeesMonthlyBasicDelete(ByVal Record As SIS.NPRK.nprkEmployeesMonthlyBasic) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkEmployeesMonthlyBasicDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RecordID",SqlDbType.Int,Record.RecordID.ToString.Length, Record.RecordID)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _RecordCount
    End Function
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
  End Class
End Namespace
