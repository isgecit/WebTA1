Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  <DataObject()> _
  Partial Public Class nprkPetrolRate
    Private Shared _RecordCount As Integer
    Private _FinYear As Int32 = 0
    Private _MonthID As Int32 = 0
    Private _LocationID As Int32 = 0
    Private _PetrolRate As String = "0.00"
    Private _HRM_Locations1_Description As String = ""
    Private _PRK_FinYears2_Description As String = ""
    Private _PRK_Months3_MonthName As String = ""
    Private _FK_PRK_PetrolRate_LocationID As SIS.HRM.hrmLocations = Nothing
    Private _FK_PRK_PetrolRate_FinYear As SIS.NPRK.nprkFinYears = Nothing
    Private _FK_PRK_PetrolRate_MonthID As SIS.NPRK.nprkMonths = Nothing
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
    Public Property FinYear() As Int32
      Get
        Return _FinYear
      End Get
      Set(ByVal value As Int32)
        _FinYear = value
      End Set
    End Property
    Public Property MonthID() As Int32
      Get
        Return _MonthID
      End Get
      Set(ByVal value As Int32)
        _MonthID = value
      End Set
    End Property
    Public Property LocationID() As Int32
      Get
        Return _LocationID
      End Get
      Set(ByVal value As Int32)
        _LocationID = value
      End Set
    End Property
    Public Property PetrolRate() As String
      Get
        Return _PetrolRate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PetrolRate = "0.00"
         Else
           _PetrolRate = value
         End If
      End Set
    End Property
    Public Property HRM_Locations1_Description() As String
      Get
        Return _HRM_Locations1_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _HRM_Locations1_Description = ""
         Else
           _HRM_Locations1_Description = value
         End If
      End Set
    End Property
    Public Property PRK_FinYears2_Description() As String
      Get
        Return _PRK_FinYears2_Description
      End Get
      Set(ByVal value As String)
        _PRK_FinYears2_Description = value
      End Set
    End Property
    Public Property PRK_Months3_MonthName() As String
      Get
        Return _PRK_Months3_MonthName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PRK_Months3_MonthName = ""
         Else
           _PRK_Months3_MonthName = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _FinYear & "|" & _MonthID & "|" & _LocationID
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
    Public Class PKnprkPetrolRate
      Private _FinYear As Int32 = 0
      Private _MonthID As Int32 = 0
      Private _LocationID As Int32 = 0
      Public Property FinYear() As Int32
        Get
          Return _FinYear
        End Get
        Set(ByVal value As Int32)
          _FinYear = value
        End Set
      End Property
      Public Property MonthID() As Int32
        Get
          Return _MonthID
        End Get
        Set(ByVal value As Int32)
          _MonthID = value
        End Set
      End Property
      Public Property LocationID() As Int32
        Get
          Return _LocationID
        End Get
        Set(ByVal value As Int32)
          _LocationID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PRK_PetrolRate_LocationID() As SIS.HRM.hrmLocations
      Get
        If _FK_PRK_PetrolRate_LocationID Is Nothing Then
          _FK_PRK_PetrolRate_LocationID = SIS.HRM.hrmLocations.hrmLocationsGetByID(_LocationID)
        End If
        Return _FK_PRK_PetrolRate_LocationID
      End Get
    End Property
    Public ReadOnly Property FK_PRK_PetrolRate_FinYear() As SIS.NPRK.nprkFinYears
      Get
        If _FK_PRK_PetrolRate_FinYear Is Nothing Then
          _FK_PRK_PetrolRate_FinYear = SIS.NPRK.nprkFinYears.nprkFinYearsGetByID(_FinYear)
        End If
        Return _FK_PRK_PetrolRate_FinYear
      End Get
    End Property
    Public ReadOnly Property FK_PRK_PetrolRate_MonthID() As SIS.NPRK.nprkMonths
      Get
        If _FK_PRK_PetrolRate_MonthID Is Nothing Then
          _FK_PRK_PetrolRate_MonthID = SIS.NPRK.nprkMonths.nprkMonthsGetByID(_MonthID)
        End If
        Return _FK_PRK_PetrolRate_MonthID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkPetrolRateGetNewRecord() As SIS.NPRK.nprkPetrolRate
      Return New SIS.NPRK.nprkPetrolRate()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkPetrolRateGetByID(ByVal FinYear As Int32, ByVal MonthID As Int32, ByVal LocationID As Int32) As SIS.NPRK.nprkPetrolRate
      Dim Results As SIS.NPRK.nprkPetrolRate = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkPetrolRateSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,FinYear.ToString.Length, FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MonthID",SqlDbType.Int,MonthID.ToString.Length, MonthID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LocationID",SqlDbType.Int,LocationID.ToString.Length, LocationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.NPRK.nprkPetrolRate(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkPetrolRateSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal FinYear As Int32, ByVal MonthID As Int32, ByVal LocationID As Int32) As List(Of SIS.NPRK.nprkPetrolRate)
      Dim Results As List(Of SIS.NPRK.nprkPetrolRate) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprkPetrolRateSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprkPetrolRateSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FinYear",SqlDbType.Int,10, IIf(FinYear = Nothing, 0,FinYear))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_MonthID",SqlDbType.Int,10, IIf(MonthID = Nothing, 0,MonthID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_LocationID",SqlDbType.Int,10, IIf(LocationID = Nothing, 0,LocationID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkPetrolRate)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkPetrolRate(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function nprkPetrolRateSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal FinYear As Int32, ByVal MonthID As Int32, ByVal LocationID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkPetrolRateGetByID(ByVal FinYear As Int32, ByVal MonthID As Int32, ByVal LocationID As Int32, ByVal Filter_FinYear As Int32, ByVal Filter_MonthID As Int32, ByVal Filter_LocationID As Int32) As SIS.NPRK.nprkPetrolRate
      Return nprkPetrolRateGetByID(FinYear, MonthID, LocationID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function nprkPetrolRateInsert(ByVal Record As SIS.NPRK.nprkPetrolRate) As SIS.NPRK.nprkPetrolRate
      Dim _Rec As SIS.NPRK.nprkPetrolRate = SIS.NPRK.nprkPetrolRate.nprkPetrolRateGetNewRecord()
      With _Rec
        .FinYear = Record.FinYear
        .MonthID = Record.MonthID
        .LocationID = Record.LocationID
        .PetrolRate = Record.PetrolRate
      End With
      Return SIS.NPRK.nprkPetrolRate.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.NPRK.nprkPetrolRate) As SIS.NPRK.nprkPetrolRate
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkPetrolRateInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MonthID",SqlDbType.Int,11, Record.MonthID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LocationID",SqlDbType.Int,11, Record.LocationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PetrolRate",SqlDbType.Decimal,9, Iif(Record.PetrolRate= "" ,Convert.DBNull, Record.PetrolRate))
          Cmd.Parameters.Add("@Return_FinYear", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_FinYear").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_MonthID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_MonthID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_LocationID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_LocationID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.FinYear = Cmd.Parameters("@Return_FinYear").Value
          Record.MonthID = Cmd.Parameters("@Return_MonthID").Value
          Record.LocationID = Cmd.Parameters("@Return_LocationID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function nprkPetrolRateUpdate(ByVal Record As SIS.NPRK.nprkPetrolRate) As SIS.NPRK.nprkPetrolRate
      Dim _Rec As SIS.NPRK.nprkPetrolRate = SIS.NPRK.nprkPetrolRate.nprkPetrolRateGetByID(Record.FinYear, Record.MonthID, Record.LocationID)
      With _Rec
        .PetrolRate = Record.PetrolRate
      End With
      Return SIS.NPRK.nprkPetrolRate.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.NPRK.nprkPetrolRate) As SIS.NPRK.nprkPetrolRate
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkPetrolRateUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FinYear",SqlDbType.Int,11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_MonthID",SqlDbType.Int,11, Record.MonthID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_LocationID",SqlDbType.Int,11, Record.LocationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MonthID",SqlDbType.Int,11, Record.MonthID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LocationID",SqlDbType.Int,11, Record.LocationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PetrolRate",SqlDbType.Decimal,9, Iif(Record.PetrolRate= "" ,Convert.DBNull, Record.PetrolRate))
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
    Public Shared Function nprkPetrolRateDelete(ByVal Record As SIS.NPRK.nprkPetrolRate) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkPetrolRateDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FinYear",SqlDbType.Int,Record.FinYear.ToString.Length, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_MonthID",SqlDbType.Int,Record.MonthID.ToString.Length, Record.MonthID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_LocationID",SqlDbType.Int,Record.LocationID.ToString.Length, Record.LocationID)
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
