Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  <DataObject()> _
  Partial Public Class nprkEmployees
    Private Shared _RecordCount As Integer
    Private _EmployeeID As Int32 = 0
    Private _CardNo As String = ""
    Private _EmployeeName As String = ""
    Private _CategoryID As Int32 = 0
    Private _Basic As Decimal = 0
    Private _DOJ As String = ""
    Private _DOR As String = ""
    Private _PostedAt As String = ""
    Private _VehicleType As String = ""
    Private _MaintenanceAllowed As Boolean = False
    Private _TWInSalary As Boolean = False
    Private _ESI As Boolean = False
    Private _Department As String = ""
    Private _Company As String = ""
    Private _MobileLimit As String = "0.00"
    Private _MobileWithInternet As Boolean = False
    Private _MobileBillPlanID As String = ""
    Private _LandlineLimit As String = "0.00"
    Private _VehicleOwnedByEmployee As Boolean = False
    Private _WithDriver As Boolean = False
    Private _Active As Boolean = False
    Private _PRK_Categories1_Description As String = ""
    Private _PRK_MobileBillPlans2_Description As String = ""
    Private _FK_PRK_Employees_CategoryID As SIS.NPRK.nprkCategories = Nothing
    Private _FK_PRK_Employees_MobileBillPlanID As SIS.NPRK.nprkMobileBillPlans = Nothing
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
    Public Property Active As Boolean
      Get
        Return _Active
      End Get
      Set(value As Boolean)
        _Active = value
      End Set
    End Property
    Public Property WithDriver As Boolean
      Get
        Return _WithDriver
      End Get
      Set(value As Boolean)
        _WithDriver = value
      End Set
    End Property
    Public Property VehicleOwnedByEmployee As Boolean
      Get
        Return _VehicleOwnedByEmployee
      End Get
      Set(value As Boolean)
        _VehicleOwnedByEmployee = value
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
    Public Property CardNo() As String
      Get
        Return _CardNo
      End Get
      Set(ByVal value As String)
        _CardNo = value
      End Set
    End Property
    Public Property EmployeeName() As String
      Get
        Return _EmployeeName
      End Get
      Set(ByVal value As String)
        _EmployeeName = value
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
    Public Property Basic() As Decimal
      Get
        Return _Basic
      End Get
      Set(ByVal value As Decimal)
        _Basic = value
      End Set
    End Property
    Public Property DOJ() As String
      Get
        If Not _DOJ = String.Empty Then
          Return Convert.ToDateTime(_DOJ).ToString("dd/MM/yyyy")
        End If
        Return _DOJ
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DOJ = ""
         Else
           _DOJ = value
         End If
      End Set
    End Property
    Public Property DOR() As String
      Get
        If Not _DOR = String.Empty Then
          Return Convert.ToDateTime(_DOR).ToString("dd/MM/yyyy")
        End If
        Return _DOR
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DOR = ""
         Else
           _DOR = value
         End If
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
    Public Property ESI() As Boolean
      Get
        Return _ESI
      End Get
      Set(ByVal value As Boolean)
        _ESI = value
      End Set
    End Property
    Public Property Department() As String
      Get
        Return _Department
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Department = ""
         Else
           _Department = value
         End If
      End Set
    End Property
    Public Property Company() As String
      Get
        Return _Company
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Company = ""
         Else
           _Company = value
         End If
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
    Public Property PRK_Categories1_Description() As String
      Get
        Return _PRK_Categories1_Description
      End Get
      Set(ByVal value As String)
        _PRK_Categories1_Description = value
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
        Return "" & _EmployeeName.ToString.PadRight(40, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _EmployeeID
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
    Public Class PKnprkEmployees
      Private _EmployeeID As Int32 = 0
      Public Property EmployeeID() As Int32
        Get
          Return _EmployeeID
        End Get
        Set(ByVal value As Int32)
          _EmployeeID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PRK_Employees_CategoryID() As SIS.NPRK.nprkCategories
      Get
        If _FK_PRK_Employees_CategoryID Is Nothing Then
          _FK_PRK_Employees_CategoryID = SIS.NPRK.nprkCategories.nprkCategoriesGetByID(_CategoryID)
        End If
        Return _FK_PRK_Employees_CategoryID
      End Get
    End Property
    Public ReadOnly Property FK_PRK_Employees_MobileBillPlanID() As SIS.NPRK.nprkMobileBillPlans
      Get
        If _FK_PRK_Employees_MobileBillPlanID Is Nothing Then
          _FK_PRK_Employees_MobileBillPlanID = SIS.NPRK.nprkMobileBillPlans.nprkMobileBillPlansGetByID(_MobileBillPlanID)
        End If
        Return _FK_PRK_Employees_MobileBillPlanID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkEmployeesSelectList(ByVal OrderBy As String) As List(Of SIS.NPRK.nprkEmployees)
      Dim Results As List(Of SIS.NPRK.nprkEmployees) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkEmployeesSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkEmployees)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkEmployees(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkEmployeesGetNewRecord() As SIS.NPRK.nprkEmployees
      Return New SIS.NPRK.nprkEmployees()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkEmployeesGetByID(ByVal EmployeeID As Int32) As SIS.NPRK.nprkEmployees
      Dim Results As SIS.NPRK.nprkEmployees = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkEmployeesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.Int,EmployeeID.ToString.Length, EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.NPRK.nprkEmployees(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkEmployeesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal EmployeeID As Int32) As List(Of SIS.NPRK.nprkEmployees)
      Dim Results As List(Of SIS.NPRK.nprkEmployees) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprkEmployeesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprkEmployeesSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EmployeeID",SqlDbType.Int,10, IIf(EmployeeID = Nothing, 0,EmployeeID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkEmployees)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkEmployees(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function nprkEmployeesSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal EmployeeID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkEmployeesGetByID(ByVal EmployeeID As Int32, ByVal Filter_EmployeeID As Int32) As SIS.NPRK.nprkEmployees
      Return nprkEmployeesGetByID(EmployeeID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function nprkEmployeesInsert(ByVal Record As SIS.NPRK.nprkEmployees) As SIS.NPRK.nprkEmployees
      Dim _Rec As SIS.NPRK.nprkEmployees = SIS.NPRK.nprkEmployees.nprkEmployeesGetNewRecord()
      With _Rec
        .EmployeeID = Record.EmployeeID
        .CardNo = Record.CardNo
        .EmployeeName = Record.EmployeeName
        .CategoryID = Record.CategoryID
        .Basic = Record.Basic
        .DOJ = Record.DOJ
        .DOR = Record.DOR
        .PostedAt = Record.PostedAt
        .VehicleType = Record.VehicleType
        .MaintenanceAllowed = Record.MaintenanceAllowed
        .TWInSalary = Record.TWInSalary
        .ESI = Record.ESI
        .Department = Record.Department
        .Company = Record.Company
        .MobileLimit = Record.MobileLimit
        .MobileWithInternet = Record.MobileWithInternet
        .MobileBillPlanID = Record.MobileBillPlanID
        .LandlineLimit = Record.LandlineLimit
        .VehicleOwnedByEmployee = Record.VehicleOwnedByEmployee
        .WithDriver = Record.WithDriver
        .Active = Record.Active
      End With
      Return SIS.NPRK.nprkEmployees.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.NPRK.nprkEmployees) As SIS.NPRK.nprkEmployees
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkEmployeesInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.Int,11, Record.EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeName",SqlDbType.NVarChar,41, Record.EmployeeName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryID",SqlDbType.Int,11, Record.CategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Basic",SqlDbType.Decimal,13, Record.Basic)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DOJ",SqlDbType.DateTime,21, Iif(Record.DOJ= "" ,Convert.DBNull, Record.DOJ))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DOR",SqlDbType.DateTime,21, Iif(Record.DOR= "" ,Convert.DBNull, Record.DOR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedAt",SqlDbType.NVarChar,21, Record.PostedAt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleType",SqlDbType.NVarChar,21, Record.VehicleType)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaintenanceAllowed",SqlDbType.Bit,3, Record.MaintenanceAllowed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TWInSalary",SqlDbType.Bit,3, Record.TWInSalary)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ESI",SqlDbType.Bit,3, Record.ESI)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Department",SqlDbType.NVarChar,31, Iif(Record.Department= "" ,Convert.DBNull, Record.Department))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Company",SqlDbType.NVarChar,51, Iif(Record.Company= "" ,Convert.DBNull, Record.Company))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MobileLimit",SqlDbType.Decimal,9, Iif(Record.MobileLimit= "" ,Convert.DBNull, Record.MobileLimit))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MobileWithInternet",SqlDbType.Bit,3, Record.MobileWithInternet)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MobileBillPlanID",SqlDbType.Int,11, Iif(Record.MobileBillPlanID= "" ,Convert.DBNull, Record.MobileBillPlanID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LandlineLimit",SqlDbType.Decimal,9, Iif(Record.LandlineLimit= "" ,Convert.DBNull, Record.LandlineLimit))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleOwnedByEmployee", SqlDbType.Bit, 3, Record.VehicleOwnedByEmployee)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WithDriver", SqlDbType.Bit, 3, Record.WithDriver)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active", SqlDbType.Bit, 3, Record.Active)
          Cmd.Parameters.Add("@Return_EmployeeID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_EmployeeID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.EmployeeID = Cmd.Parameters("@Return_EmployeeID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function nprkEmployeesUpdate(ByVal Record As SIS.NPRK.nprkEmployees) As SIS.NPRK.nprkEmployees
      Dim _Rec As SIS.NPRK.nprkEmployees = SIS.NPRK.nprkEmployees.nprkEmployeesGetByID(Record.EmployeeID)
      With _Rec
        .CardNo = Record.CardNo
        .EmployeeName = Record.EmployeeName
        .CategoryID = Record.CategoryID
        .Basic = Record.Basic
        .DOJ = Record.DOJ
        .DOR = Record.DOR
        .PostedAt = Record.PostedAt
        .VehicleType = Record.VehicleType
        .MaintenanceAllowed = Record.MaintenanceAllowed
        .TWInSalary = Record.TWInSalary
        .ESI = Record.ESI
        .Department = Record.Department
        .Company = Record.Company
        .MobileLimit = Record.MobileLimit
        .MobileWithInternet = Record.MobileWithInternet
        .MobileBillPlanID = Record.MobileBillPlanID
        .LandlineLimit = Record.LandlineLimit
        .VehicleOwnedByEmployee = Record.VehicleOwnedByEmployee
        .WithDriver = Record.WithDriver
        .Active = Record.Active
      End With
      Return SIS.NPRK.nprkEmployees.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.NPRK.nprkEmployees) As SIS.NPRK.nprkEmployees
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkEmployeesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_EmployeeID",SqlDbType.Int,11, Record.EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.Int,11, Record.EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeName",SqlDbType.NVarChar,41, Record.EmployeeName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryID",SqlDbType.Int,11, Record.CategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Basic",SqlDbType.Decimal,13, Record.Basic)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DOJ",SqlDbType.DateTime,21, Iif(Record.DOJ= "" ,Convert.DBNull, Record.DOJ))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DOR",SqlDbType.DateTime,21, Iif(Record.DOR= "" ,Convert.DBNull, Record.DOR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedAt",SqlDbType.NVarChar,21, Record.PostedAt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleType",SqlDbType.NVarChar,21, Record.VehicleType)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaintenanceAllowed",SqlDbType.Bit,3, Record.MaintenanceAllowed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TWInSalary",SqlDbType.Bit,3, Record.TWInSalary)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ESI",SqlDbType.Bit,3, Record.ESI)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Department",SqlDbType.NVarChar,31, Iif(Record.Department= "" ,Convert.DBNull, Record.Department))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Company",SqlDbType.NVarChar,51, Iif(Record.Company= "" ,Convert.DBNull, Record.Company))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MobileLimit",SqlDbType.Decimal,9, Iif(Record.MobileLimit= "" ,Convert.DBNull, Record.MobileLimit))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MobileWithInternet",SqlDbType.Bit,3, Record.MobileWithInternet)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MobileBillPlanID",SqlDbType.Int,11, Iif(Record.MobileBillPlanID= "" ,Convert.DBNull, Record.MobileBillPlanID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LandlineLimit",SqlDbType.Decimal,9, Iif(Record.LandlineLimit= "" ,Convert.DBNull, Record.LandlineLimit))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleOwnedByEmployee", SqlDbType.Bit, 3, Record.VehicleOwnedByEmployee)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WithDriver", SqlDbType.Bit, 3, Record.WithDriver)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active", SqlDbType.Bit, 3, Record.Active)
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
    Public Shared Function nprkEmployeesDelete(ByVal Record As SIS.NPRK.nprkEmployees) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkEmployeesDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_EmployeeID",SqlDbType.Int,Record.EmployeeID.ToString.Length, Record.EmployeeID)
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
'    Autocomplete Method
    Public Shared Function SelectnprkEmployeesAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkEmployeesAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(40, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.NPRK.nprkEmployees = New SIS.NPRK.nprkEmployees(Reader)
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.CardNo))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results.ToArray
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
