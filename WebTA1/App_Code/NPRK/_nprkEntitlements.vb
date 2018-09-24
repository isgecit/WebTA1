Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  <DataObject()> _
  Partial Public Class nprkEntitlements
    Private Shared _RecordCount As Integer
    Private _EntitlementID As Int32 = 0
    Private _EmployeeID As Int32 = 0
    Private _PerkID As Int32 = 0
    Private _EffectiveDate As String = ""
    Private _FinYear As Int32 = 0
    Private _Value As Decimal = 0
    Private _UOM As String = ""
    Private _CategoryID As Int32 = 0
    Private _PostedAt As String = ""
    Private _VehicleType As String = ""
    Private _Basic As Decimal = 0
    Private _ESI As Boolean = False
    Private _WithDriver As Boolean = False
    Private _Description As String = ""
    Public Property Selected As Boolean = False
    Public Property Paid As Boolean = False
    Private _PRK_Categories1_Description As String = ""
    Private _PRK_Employees2_EmployeeName As String = ""
    Private _PRK_FinYears3_Description As String = ""
    Private _PRK_Perks4_Description As String = ""
    Private _FK_PRK_Entitlements_PRK_Categories As SIS.NPRK.nprkCategories = Nothing
    Private _FK_PRK_Entitlements_PRK_Employees As SIS.NPRK.nprkEmployees = Nothing
    Private _FK_PRK_Entitlements_PRK_FinYears As SIS.NPRK.nprkFinYears = Nothing
    Private _FK_PRK_Entitlements_PRK_Perks As SIS.NPRK.nprkPerks = Nothing
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
    Public Property Description As String
      Get
        Return _Description
      End Get
      Set(value As String)
        _Description = value
      End Set
    End Property
    Public Property EntitlementID() As Int32
      Get
        Return _EntitlementID
      End Get
      Set(ByVal value As Int32)
        _EntitlementID = value
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
    Public Property PerkID() As Int32
      Get
        Return _PerkID
      End Get
      Set(ByVal value As Int32)
        _PerkID = value
      End Set
    End Property
    Public Property EffectiveDate() As String
      Get
        If Not _EffectiveDate = String.Empty Then
          Return Convert.ToDateTime(_EffectiveDate).ToString("dd/MM/yyyy")
        End If
        Return _EffectiveDate
      End Get
      Set(ByVal value As String)
         _EffectiveDate = value
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
    Public Property Value() As Decimal
      Get
        Return _Value
      End Get
      Set(ByVal value As Decimal)
        _Value = value
      End Set
    End Property
    Public Property UOM() As String
      Get
        Return _UOM
      End Get
      Set(ByVal value As String)
        _UOM = value
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
    Public Property Basic() As Decimal
      Get
        Return _Basic
      End Get
      Set(ByVal value As Decimal)
        _Basic = value
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
    Public Property PRK_Categories1_Description() As String
      Get
        Return _PRK_Categories1_Description
      End Get
      Set(ByVal value As String)
        _PRK_Categories1_Description = value
      End Set
    End Property
    Public Property PRK_Employees2_EmployeeName() As String
      Get
        Return _PRK_Employees2_EmployeeName
      End Get
      Set(ByVal value As String)
        _PRK_Employees2_EmployeeName = value
      End Set
    End Property
    Public Property PRK_FinYears3_Description() As String
      Get
        Return _PRK_FinYears3_Description
      End Get
      Set(ByVal value As String)
        _PRK_FinYears3_Description = value
      End Set
    End Property
    Public Property PRK_Perks4_Description() As String
      Get
        Return _PRK_Perks4_Description
      End Get
      Set(ByVal value As String)
        _PRK_Perks4_Description = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _EntitlementID
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
    Public Class PKnprkEntitlements
      Private _EntitlementID As Int32 = 0
      Public Property EntitlementID() As Int32
        Get
          Return _EntitlementID
        End Get
        Set(ByVal value As Int32)
          _EntitlementID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PRK_Entitlements_PRK_Categories() As SIS.NPRK.nprkCategories
      Get
        If _FK_PRK_Entitlements_PRK_Categories Is Nothing Then
          _FK_PRK_Entitlements_PRK_Categories = SIS.NPRK.nprkCategories.nprkCategoriesGetByID(_CategoryID)
        End If
        Return _FK_PRK_Entitlements_PRK_Categories
      End Get
    End Property
    Public ReadOnly Property FK_PRK_Entitlements_PRK_Employees() As SIS.NPRK.nprkEmployees
      Get
        If _FK_PRK_Entitlements_PRK_Employees Is Nothing Then
          _FK_PRK_Entitlements_PRK_Employees = SIS.NPRK.nprkEmployees.nprkEmployeesGetByID(_EmployeeID)
        End If
        Return _FK_PRK_Entitlements_PRK_Employees
      End Get
    End Property
    Public ReadOnly Property FK_PRK_Entitlements_PRK_FinYears() As SIS.NPRK.nprkFinYears
      Get
        If _FK_PRK_Entitlements_PRK_FinYears Is Nothing Then
          _FK_PRK_Entitlements_PRK_FinYears = SIS.NPRK.nprkFinYears.nprkFinYearsGetByID(_FinYear)
        End If
        Return _FK_PRK_Entitlements_PRK_FinYears
      End Get
    End Property
    Public ReadOnly Property FK_PRK_Entitlements_PRK_Perks() As SIS.NPRK.nprkPerks
      Get
        If _FK_PRK_Entitlements_PRK_Perks Is Nothing Then
          _FK_PRK_Entitlements_PRK_Perks = SIS.NPRK.nprkPerks.nprkPerksGetByID(_PerkID)
        End If
        Return _FK_PRK_Entitlements_PRK_Perks
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkEntitlementsGetNewRecord() As SIS.NPRK.nprkEntitlements
      Return New SIS.NPRK.nprkEntitlements()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkEntitlementsGetByID(ByVal EntitlementID As Int32) As SIS.NPRK.nprkEntitlements
      Dim Results As SIS.NPRK.nprkEntitlements = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkEntitlementsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EntitlementID",SqlDbType.Int,EntitlementID.ToString.Length, EntitlementID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.NPRK.nprkEntitlements(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByEmployeeID(ByVal EmployeeID As Int32, ByVal OrderBy as String) As List(Of SIS.NPRK.nprkEntitlements)
      Dim Results As List(Of SIS.NPRK.nprkEntitlements) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkEntitlementsSelectByEmployeeID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.Int,EmployeeID.ToString.Length, EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkEntitlements)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkEntitlements(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByPerkID(ByVal PerkID As Int32, ByVal OrderBy as String) As List(Of SIS.NPRK.nprkEntitlements)
      Dim Results As List(Of SIS.NPRK.nprkEntitlements) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkEntitlementsSelectByPerkID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PerkID",SqlDbType.Int,PerkID.ToString.Length, PerkID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkEntitlements)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkEntitlements(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByCategoryID(ByVal CategoryID As Int32, ByVal OrderBy as String) As List(Of SIS.NPRK.nprkEntitlements)
      Dim Results As List(Of SIS.NPRK.nprkEntitlements) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkEntitlementsSelectByCategoryID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryID",SqlDbType.Int,CategoryID.ToString.Length, CategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkEntitlements)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkEntitlements(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkEntitlementsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.NPRK.nprkEntitlements)
      Dim Results As List(Of SIS.NPRK.nprkEntitlements) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprkEntitlementsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprkEntitlementsSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkEntitlements)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkEntitlements(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function nprkEntitlementsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function nprkEntitlementsInsert(ByVal Record As SIS.NPRK.nprkEntitlements) As SIS.NPRK.nprkEntitlements
      Dim _Rec As SIS.NPRK.nprkEntitlements = SIS.NPRK.nprkEntitlements.nprkEntitlementsGetNewRecord()
      With _Rec
        .EmployeeID = Record.EmployeeID
        .PerkID = Record.PerkID
        .EffectiveDate = Record.EffectiveDate
        .FinYear = Record.FinYear
        .Value = Record.Value
        .UOM = Record.UOM
        .CategoryID = Record.CategoryID
        .PostedAt = Record.PostedAt
        .VehicleType = Record.VehicleType
        .Basic = Record.Basic
        .ESI = Record.ESI
        .WithDriver = Record.WithDriver
        .Description = Record.Description
        .Selected = Record.Selected
        .Paid = Record.Paid
      End With
      Return SIS.NPRK.nprkEntitlements.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.NPRK.nprkEntitlements) As SIS.NPRK.nprkEntitlements
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkEntitlementsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.Int,11, Record.EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PerkID",SqlDbType.Int,11, Record.PerkID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EffectiveDate",SqlDbType.DateTime,21, Record.EffectiveDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Value",SqlDbType.Decimal,13, Record.Value)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOM",SqlDbType.NVarChar,6, Record.UOM)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryID",SqlDbType.Int,11, Record.CategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedAt",SqlDbType.NVarChar,21, Record.PostedAt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleType",SqlDbType.NVarChar,21, Record.VehicleType)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Basic",SqlDbType.Decimal,13, Record.Basic)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ESI", SqlDbType.Bit, 3, Record.ESI)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WithDriver", SqlDbType.Bit, 3, Record.WithDriver)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description", SqlDbType.NVarChar, 100, IIf(Record.Description = "", Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Selected", SqlDbType.Bit, 3, Record.Selected)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Paid", SqlDbType.Bit, 3, Record.Paid)
          Cmd.Parameters.Add("@Return_EntitlementID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_EntitlementID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.EntitlementID = Cmd.Parameters("@Return_EntitlementID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function nprkEntitlementsUpdate(ByVal Record As SIS.NPRK.nprkEntitlements) As SIS.NPRK.nprkEntitlements
      Dim _Rec As SIS.NPRK.nprkEntitlements = SIS.NPRK.nprkEntitlements.nprkEntitlementsGetByID(Record.EntitlementID)
      With _Rec
        .EmployeeID = Record.EmployeeID
        .PerkID = Record.PerkID
        .EffectiveDate = Record.EffectiveDate
        .FinYear = Record.FinYear
        .Value = Record.Value
        .UOM = Record.UOM
        .CategoryID = Record.CategoryID
        .PostedAt = Record.PostedAt
        .VehicleType = Record.VehicleType
        .Basic = Record.Basic
        .ESI = Record.ESI
        .WithDriver = Record.WithDriver
        .Description = Record.Description
        .Selected = Record.Selected
        .Paid = Record.Paid
      End With
      Return SIS.NPRK.nprkEntitlements.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.NPRK.nprkEntitlements) As SIS.NPRK.nprkEntitlements
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkEntitlementsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_EntitlementID",SqlDbType.Int,11, Record.EntitlementID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.Int,11, Record.EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PerkID",SqlDbType.Int,11, Record.PerkID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EffectiveDate",SqlDbType.DateTime,21, Record.EffectiveDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Value",SqlDbType.Decimal,13, Record.Value)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOM",SqlDbType.NVarChar,6, Record.UOM)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryID",SqlDbType.Int,11, Record.CategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedAt",SqlDbType.NVarChar,21, Record.PostedAt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleType",SqlDbType.NVarChar,21, Record.VehicleType)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Basic",SqlDbType.Decimal,13, Record.Basic)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ESI",SqlDbType.Bit,3, Record.ESI)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WithDriver", SqlDbType.Bit, 3, Record.WithDriver)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description", SqlDbType.NVarChar, 100, IIf(Record.Description = "", Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Selected", SqlDbType.Bit, 3, Record.Selected)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Paid", SqlDbType.Bit, 3, Record.Paid)
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
    Public Shared Function nprkEntitlementsDelete(ByVal Record As SIS.NPRK.nprkEntitlements) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkEntitlementsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_EntitlementID",SqlDbType.Int,Record.EntitlementID.ToString.Length, Record.EntitlementID)
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
