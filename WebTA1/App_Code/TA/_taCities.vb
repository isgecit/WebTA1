Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taCities
    Private Shared _RecordCount As Integer
    Private _CityID As String = ""
    Private _CityName As String = ""
    Private _CityTypeForDA As String = ""
    Private _CityTypeForHotel As String = ""
    Private _CountryID As String = ""
    Private _RegionID As String = ""
    Private _CurrencyID As String = ""
    Private _RegionTypeID As String = ""
    Private _TA_CityTypes1_CityTypeName As String = ""
    Private _TA_CityTypes2_CityTypeName As String = ""
    Private _TA_Countries3_CountryName As String = ""
    Private _TA_Currencies4_CurrencyName As String = ""
    Private _TA_Regions5_RegionName As String = ""
    Private _TA_RegionTypes6_RegionTypeName As String = ""
    Private _FK_TA_Cities_CityTypeDA As SIS.TA.taCityTypes = Nothing
    Private _FK_TA_Cities_CityTypeHotel As SIS.TA.taCityTypes = Nothing
    Private _FK_TA_Cities_CountryID As SIS.TA.taCountries = Nothing
    Private _FK_TA_Cities_CurrencyID As SIS.TA.taCurrencies = Nothing
    Private _FK_TA_Cities_RegionID As SIS.TA.taRegions = Nothing
    Private _FK_TA_Cities_RegionTypeID As SIS.TA.taRegionTypes = Nothing
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
    Public Property CityID() As String
      Get
        Return _CityID
      End Get
      Set(ByVal value As String)
        _CityID = value
      End Set
    End Property
    Public Property CityName() As String
      Get
        Return _CityName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CityName = ""
         Else
           _CityName = value
         End If
      End Set
    End Property
    Public Property CityTypeForDA() As String
      Get
        Return _CityTypeForDA
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CityTypeForDA = ""
         Else
           _CityTypeForDA = value
         End If
      End Set
    End Property
    Public Property CityTypeForHotel() As String
      Get
        Return _CityTypeForHotel
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CityTypeForHotel = ""
         Else
           _CityTypeForHotel = value
         End If
      End Set
    End Property
    Public Property CountryID() As String
      Get
        Return _CountryID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CountryID = ""
         Else
           _CountryID = value
         End If
      End Set
    End Property
    Public Property RegionID() As String
      Get
        Return _RegionID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _RegionID = ""
         Else
           _RegionID = value
         End If
      End Set
    End Property
    Public Property CurrencyID() As String
      Get
        Return _CurrencyID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CurrencyID = ""
         Else
           _CurrencyID = value
         End If
      End Set
    End Property
    Public Property RegionTypeID() As String
      Get
        Return _RegionTypeID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _RegionTypeID = ""
         Else
           _RegionTypeID = value
         End If
      End Set
    End Property
    Public Property TA_CityTypes1_CityTypeName() As String
      Get
        Return _TA_CityTypes1_CityTypeName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_CityTypes1_CityTypeName = ""
         Else
           _TA_CityTypes1_CityTypeName = value
         End If
      End Set
    End Property
    Public Property TA_CityTypes2_CityTypeName() As String
      Get
        Return _TA_CityTypes2_CityTypeName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_CityTypes2_CityTypeName = ""
         Else
           _TA_CityTypes2_CityTypeName = value
         End If
      End Set
    End Property
    Public Property TA_Countries3_CountryName() As String
      Get
        Return _TA_Countries3_CountryName
      End Get
      Set(ByVal value As String)
        _TA_Countries3_CountryName = value
      End Set
    End Property
    Public Property TA_Currencies4_CurrencyName() As String
      Get
        Return _TA_Currencies4_CurrencyName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_Currencies4_CurrencyName = ""
         Else
           _TA_Currencies4_CurrencyName = value
         End If
      End Set
    End Property
    Public Property TA_Regions5_RegionName() As String
      Get
        Return _TA_Regions5_RegionName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_Regions5_RegionName = ""
         Else
           _TA_Regions5_RegionName = value
         End If
      End Set
    End Property
    Public Property TA_RegionTypes6_RegionTypeName() As String
      Get
        Return _TA_RegionTypes6_RegionTypeName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_RegionTypes6_RegionTypeName = ""
         Else
           _TA_RegionTypes6_RegionTypeName = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _CityName.ToString.PadRight(80, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _CityID
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
    Public Class PKtaCities
      Private _CityID As String = ""
      Public Property CityID() As String
        Get
          Return _CityID
        End Get
        Set(ByVal value As String)
          _CityID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_TA_Cities_CityTypeDA() As SIS.TA.taCityTypes
      Get
        If _FK_TA_Cities_CityTypeDA Is Nothing Then
          _FK_TA_Cities_CityTypeDA = SIS.TA.taCityTypes.taCityTypesGetByID(_CityTypeForDA)
        End If
        Return _FK_TA_Cities_CityTypeDA
      End Get
    End Property
    Public ReadOnly Property FK_TA_Cities_CityTypeHotel() As SIS.TA.taCityTypes
      Get
        If _FK_TA_Cities_CityTypeHotel Is Nothing Then
          _FK_TA_Cities_CityTypeHotel = SIS.TA.taCityTypes.taCityTypesGetByID(_CityTypeForHotel)
        End If
        Return _FK_TA_Cities_CityTypeHotel
      End Get
    End Property
    Public ReadOnly Property FK_TA_Cities_CountryID() As SIS.TA.taCountries
      Get
        If _FK_TA_Cities_CountryID Is Nothing Then
          _FK_TA_Cities_CountryID = SIS.TA.taCountries.taCountriesGetByID(_CountryID)
        End If
        Return _FK_TA_Cities_CountryID
      End Get
    End Property
    Public ReadOnly Property FK_TA_Cities_CurrencyID() As SIS.TA.taCurrencies
      Get
        If _FK_TA_Cities_CurrencyID Is Nothing Then
          _FK_TA_Cities_CurrencyID = SIS.TA.taCurrencies.taCurrenciesGetByID(_CurrencyID)
        End If
        Return _FK_TA_Cities_CurrencyID
      End Get
    End Property
    Public ReadOnly Property FK_TA_Cities_RegionID() As SIS.TA.taRegions
      Get
        If _FK_TA_Cities_RegionID Is Nothing Then
          _FK_TA_Cities_RegionID = SIS.TA.taRegions.taRegionsGetByID(_RegionID)
        End If
        Return _FK_TA_Cities_RegionID
      End Get
    End Property
    Public ReadOnly Property FK_TA_Cities_RegionTypeID() As SIS.TA.taRegionTypes
      Get
        If _FK_TA_Cities_RegionTypeID Is Nothing Then
          _FK_TA_Cities_RegionTypeID = SIS.TA.taRegionTypes.taRegionTypesGetByID(_RegionTypeID)
        End If
        Return _FK_TA_Cities_RegionTypeID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCitiesSelectList(ByVal OrderBy As String) As List(Of SIS.TA.taCities)
      Dim Results As List(Of SIS.TA.taCities) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaCitiesSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taCities)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taCities(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCitiesGetNewRecord() As SIS.TA.taCities
      Return New SIS.TA.taCities()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCitiesGetByID(ByVal CityID As String) As SIS.TA.taCities
      Dim Results As SIS.TA.taCities = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaCitiesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CityID",SqlDbType.NVarChar,CityID.ToString.Length, CityID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TA.taCities(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCitiesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CountryID As String, ByVal RegionID As String, ByVal CurrencyID As String, ByVal RegionTypeID As String) As List(Of SIS.TA.taCities)
      Dim Results As List(Of SIS.TA.taCities) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaCitiesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaCitiesSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CountryID",SqlDbType.NVarChar,30, IIf(CountryID Is Nothing, String.Empty,CountryID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RegionID",SqlDbType.NVarChar,10, IIf(RegionID Is Nothing, String.Empty,RegionID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CurrencyID",SqlDbType.NVarChar,6, IIf(CurrencyID Is Nothing, String.Empty,CurrencyID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RegionTypeID",SqlDbType.NVarChar,10, IIf(RegionTypeID Is Nothing, String.Empty,RegionTypeID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taCities)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taCities(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taCitiesSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CountryID As String, ByVal RegionID As String, ByVal CurrencyID As String, ByVal RegionTypeID As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCitiesGetByID(ByVal CityID As String, ByVal Filter_CountryID As String, ByVal Filter_RegionID As String, ByVal Filter_CurrencyID As String, ByVal Filter_RegionTypeID As String) As SIS.TA.taCities
      Return taCitiesGetByID(CityID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function taCitiesInsert(ByVal Record As SIS.TA.taCities) As SIS.TA.taCities
      Dim _Rec As SIS.TA.taCities = SIS.TA.taCities.taCitiesGetNewRecord()
      With _Rec
        .CityID = Record.CityID
        .CityName = Record.CityName
        .CityTypeForDA = Record.CityTypeForDA
        .CityTypeForHotel = Record.CityTypeForHotel
        .CountryID = Record.CountryID
        .RegionID = Record.RegionID
        .CurrencyID = Record.CurrencyID
        .RegionTypeID = Record.RegionTypeID
      End With
      Return SIS.TA.taCities.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.TA.taCities) As SIS.TA.taCities
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaCitiesInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CityID",SqlDbType.NVarChar,31, Record.CityID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CityName",SqlDbType.NVarChar,81, Iif(Record.CityName= "" ,Convert.DBNull, Record.CityName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CityTypeForDA",SqlDbType.NVarChar,7, Iif(Record.CityTypeForDA= "" ,Convert.DBNull, Record.CityTypeForDA))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CityTypeForHotel",SqlDbType.NVarChar,7, Iif(Record.CityTypeForHotel= "" ,Convert.DBNull, Record.CityTypeForHotel))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CountryID",SqlDbType.NVarChar,31, Iif(Record.CountryID= "" ,Convert.DBNull, Record.CountryID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RegionID",SqlDbType.NVarChar,11, Iif(Record.RegionID= "" ,Convert.DBNull, Record.RegionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyID",SqlDbType.NVarChar,7, Iif(Record.CurrencyID= "" ,Convert.DBNull, Record.CurrencyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RegionTypeID",SqlDbType.NVarChar,11, Iif(Record.RegionTypeID= "" ,Convert.DBNull, Record.RegionTypeID))
          Cmd.Parameters.Add("@Return_CityID", SqlDbType.NVarChar, 31)
          Cmd.Parameters("@Return_CityID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.CityID = Cmd.Parameters("@Return_CityID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taCitiesUpdate(ByVal Record As SIS.TA.taCities) As SIS.TA.taCities
      Dim _Rec As SIS.TA.taCities = SIS.TA.taCities.taCitiesGetByID(Record.CityID)
      With _Rec
        .CityName = Record.CityName
        .CityTypeForDA = Record.CityTypeForDA
        .CityTypeForHotel = Record.CityTypeForHotel
        .CountryID = Record.CountryID
        .RegionID = Record.RegionID
        .CurrencyID = Record.CurrencyID
        .RegionTypeID = Record.RegionTypeID
      End With
      Return SIS.TA.taCities.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.TA.taCities) As SIS.TA.taCities
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaCitiesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CityID",SqlDbType.NVarChar,31, Record.CityID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CityID",SqlDbType.NVarChar,31, Record.CityID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CityName",SqlDbType.NVarChar,81, Iif(Record.CityName= "" ,Convert.DBNull, Record.CityName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CityTypeForDA",SqlDbType.NVarChar,7, Iif(Record.CityTypeForDA= "" ,Convert.DBNull, Record.CityTypeForDA))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CityTypeForHotel",SqlDbType.NVarChar,7, Iif(Record.CityTypeForHotel= "" ,Convert.DBNull, Record.CityTypeForHotel))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CountryID",SqlDbType.NVarChar,31, Iif(Record.CountryID= "" ,Convert.DBNull, Record.CountryID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RegionID",SqlDbType.NVarChar,11, Iif(Record.RegionID= "" ,Convert.DBNull, Record.RegionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyID",SqlDbType.NVarChar,7, Iif(Record.CurrencyID= "" ,Convert.DBNull, Record.CurrencyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RegionTypeID",SqlDbType.NVarChar,11, Iif(Record.RegionTypeID= "" ,Convert.DBNull, Record.RegionTypeID))
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
    Public Shared Function taCitiesDelete(ByVal Record As SIS.TA.taCities) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaCitiesDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CityID",SqlDbType.NVarChar,Record.CityID.ToString.Length, Record.CityID)
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
    Public Shared Function SelecttaCitiesAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaCitiesAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(80, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.TA.taCities = New SIS.TA.taCities(Reader)
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results.ToArray
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _CityID = Ctype(Reader("CityID"),String)
      If Convert.IsDBNull(Reader("CityName")) Then
        _CityName = String.Empty
      Else
        _CityName = Ctype(Reader("CityName"), String)
      End If
      If Convert.IsDBNull(Reader("CityTypeForDA")) Then
        _CityTypeForDA = String.Empty
      Else
        _CityTypeForDA = Ctype(Reader("CityTypeForDA"), String)
      End If
      If Convert.IsDBNull(Reader("CityTypeForHotel")) Then
        _CityTypeForHotel = String.Empty
      Else
        _CityTypeForHotel = Ctype(Reader("CityTypeForHotel"), String)
      End If
      If Convert.IsDBNull(Reader("CountryID")) Then
        _CountryID = String.Empty
      Else
        _CountryID = Ctype(Reader("CountryID"), String)
      End If
      If Convert.IsDBNull(Reader("RegionID")) Then
        _RegionID = String.Empty
      Else
        _RegionID = Ctype(Reader("RegionID"), String)
      End If
      If Convert.IsDBNull(Reader("CurrencyID")) Then
        _CurrencyID = String.Empty
      Else
        _CurrencyID = Ctype(Reader("CurrencyID"), String)
      End If
      If Convert.IsDBNull(Reader("RegionTypeID")) Then
        _RegionTypeID = String.Empty
      Else
        _RegionTypeID = Ctype(Reader("RegionTypeID"), String)
      End If
      If Convert.IsDBNull(Reader("TA_CityTypes1_CityTypeName")) Then
        _TA_CityTypes1_CityTypeName = String.Empty
      Else
        _TA_CityTypes1_CityTypeName = Ctype(Reader("TA_CityTypes1_CityTypeName"), String)
      End If
      If Convert.IsDBNull(Reader("TA_CityTypes2_CityTypeName")) Then
        _TA_CityTypes2_CityTypeName = String.Empty
      Else
        _TA_CityTypes2_CityTypeName = Ctype(Reader("TA_CityTypes2_CityTypeName"), String)
      End If
      _TA_Countries3_CountryName = Ctype(Reader("TA_Countries3_CountryName"),String)
      If Convert.IsDBNull(Reader("TA_Currencies4_CurrencyName")) Then
        _TA_Currencies4_CurrencyName = String.Empty
      Else
        _TA_Currencies4_CurrencyName = Ctype(Reader("TA_Currencies4_CurrencyName"), String)
      End If
      If Convert.IsDBNull(Reader("TA_Regions5_RegionName")) Then
        _TA_Regions5_RegionName = String.Empty
      Else
        _TA_Regions5_RegionName = Ctype(Reader("TA_Regions5_RegionName"), String)
      End If
      If Convert.IsDBNull(Reader("TA_RegionTypes6_RegionTypeName")) Then
        _TA_RegionTypes6_RegionTypeName = String.Empty
      Else
        _TA_RegionTypes6_RegionTypeName = Ctype(Reader("TA_RegionTypes6_RegionTypeName"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
