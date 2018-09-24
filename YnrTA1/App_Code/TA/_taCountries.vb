Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taCountries
    Private Shared _RecordCount As Integer
    Private _CountryID As String = ""
    Private _CountryName As String = ""
    Private _RegionID As String = ""
    Private _CurrencyID As String = ""
    Private _RegionTypeID As String = ""
    Private _ContingencyAmount As Int32 = 0
    Private _TA_Currencies1_CurrencyName As String = ""
    Private _TA_Regions2_RegionName As String = ""
    Private _TA_RegionTypes3_RegionTypeName As String = ""
    Private _FK_TA_Countries_CurrencyID As SIS.TA.taCurrencies = Nothing
    Private _FK_TA_Countries_RegionID As SIS.TA.taRegions = Nothing
    Private _FK_TA_Countries_RegionTypeID As SIS.TA.taRegionTypes = Nothing
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
    Public Property CountryID() As String
      Get
        Return _CountryID
      End Get
      Set(ByVal value As String)
        _CountryID = value
      End Set
    End Property
    Public Property CountryName() As String
      Get
        Return _CountryName
      End Get
      Set(ByVal value As String)
        _CountryName = value
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
    Public Property ContingencyAmount() As Int32
      Get
        Return _ContingencyAmount
      End Get
      Set(ByVal value As Int32)
        _ContingencyAmount = value
      End Set
    End Property
    Public Property TA_Currencies1_CurrencyName() As String
      Get
        Return _TA_Currencies1_CurrencyName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_Currencies1_CurrencyName = ""
         Else
           _TA_Currencies1_CurrencyName = value
         End If
      End Set
    End Property
    Public Property TA_Regions2_RegionName() As String
      Get
        Return _TA_Regions2_RegionName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_Regions2_RegionName = ""
         Else
           _TA_Regions2_RegionName = value
         End If
      End Set
    End Property
    Public Property TA_RegionTypes3_RegionTypeName() As String
      Get
        Return _TA_RegionTypes3_RegionTypeName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_RegionTypes3_RegionTypeName = ""
         Else
           _TA_RegionTypes3_RegionTypeName = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _CountryName.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _CountryID
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
    Public Class PKtaCountries
      Private _CountryID As String = ""
      Public Property CountryID() As String
        Get
          Return _CountryID
        End Get
        Set(ByVal value As String)
          _CountryID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_TA_Countries_CurrencyID() As SIS.TA.taCurrencies
      Get
        If _FK_TA_Countries_CurrencyID Is Nothing Then
          _FK_TA_Countries_CurrencyID = SIS.TA.taCurrencies.taCurrenciesGetByID(_CurrencyID)
        End If
        Return _FK_TA_Countries_CurrencyID
      End Get
    End Property
    Public ReadOnly Property FK_TA_Countries_RegionID() As SIS.TA.taRegions
      Get
        If _FK_TA_Countries_RegionID Is Nothing Then
          _FK_TA_Countries_RegionID = SIS.TA.taRegions.taRegionsGetByID(_RegionID)
        End If
        Return _FK_TA_Countries_RegionID
      End Get
    End Property
    Public ReadOnly Property FK_TA_Countries_RegionTypeID() As SIS.TA.taRegionTypes
      Get
        If _FK_TA_Countries_RegionTypeID Is Nothing Then
          _FK_TA_Countries_RegionTypeID = SIS.TA.taRegionTypes.taRegionTypesGetByID(_RegionTypeID)
        End If
        Return _FK_TA_Countries_RegionTypeID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCountriesSelectList(ByVal OrderBy As String) As List(Of SIS.TA.taCountries)
      Dim Results As List(Of SIS.TA.taCountries) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaCountriesSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taCountries)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taCountries(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCountriesGetNewRecord() As SIS.TA.taCountries
      Return New SIS.TA.taCountries()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCountriesGetByID(ByVal CountryID As String) As SIS.TA.taCountries
      Dim Results As SIS.TA.taCountries = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaCountriesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CountryID",SqlDbType.NVarChar,CountryID.ToString.Length, CountryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TA.taCountries(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCountriesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.TA.taCountries)
      Dim Results As List(Of SIS.TA.taCountries) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaCountriesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaCountriesSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taCountries)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taCountries(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taCountriesSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function taCountriesInsert(ByVal Record As SIS.TA.taCountries) As SIS.TA.taCountries
      Dim _Rec As SIS.TA.taCountries = SIS.TA.taCountries.taCountriesGetNewRecord()
      With _Rec
        .CountryID = Record.CountryID
        .CountryName = Record.CountryName
        .RegionID = Record.RegionID
        .CurrencyID = Record.CurrencyID
        .RegionTypeID = Record.RegionTypeID
        .ContingencyAmount = Record.ContingencyAmount
      End With
      Return SIS.TA.taCountries.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.TA.taCountries) As SIS.TA.taCountries
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaCountriesInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CountryID",SqlDbType.NVarChar,31, Record.CountryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CountryName",SqlDbType.NVarChar,51, Record.CountryName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RegionID",SqlDbType.NVarChar,11, Iif(Record.RegionID= "" ,Convert.DBNull, Record.RegionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyID",SqlDbType.NVarChar,7, Iif(Record.CurrencyID= "" ,Convert.DBNull, Record.CurrencyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RegionTypeID",SqlDbType.NVarChar,11, Iif(Record.RegionTypeID= "" ,Convert.DBNull, Record.RegionTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ContingencyAmount",SqlDbType.Int,11, Record.ContingencyAmount)
          Cmd.Parameters.Add("@Return_CountryID", SqlDbType.NVarChar, 31)
          Cmd.Parameters("@Return_CountryID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.CountryID = Cmd.Parameters("@Return_CountryID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taCountriesUpdate(ByVal Record As SIS.TA.taCountries) As SIS.TA.taCountries
      Dim _Rec As SIS.TA.taCountries = SIS.TA.taCountries.taCountriesGetByID(Record.CountryID)
      With _Rec
        .CountryName = Record.CountryName
        .RegionID = Record.RegionID
        .CurrencyID = Record.CurrencyID
        .RegionTypeID = Record.RegionTypeID
        .ContingencyAmount = Record.ContingencyAmount
      End With
      Return SIS.TA.taCountries.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.TA.taCountries) As SIS.TA.taCountries
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaCountriesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CountryID",SqlDbType.NVarChar,31, Record.CountryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CountryID",SqlDbType.NVarChar,31, Record.CountryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CountryName",SqlDbType.NVarChar,51, Record.CountryName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RegionID",SqlDbType.NVarChar,11, Iif(Record.RegionID= "" ,Convert.DBNull, Record.RegionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyID",SqlDbType.NVarChar,7, Iif(Record.CurrencyID= "" ,Convert.DBNull, Record.CurrencyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RegionTypeID",SqlDbType.NVarChar,11, Iif(Record.RegionTypeID= "" ,Convert.DBNull, Record.RegionTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ContingencyAmount",SqlDbType.Int,11, Record.ContingencyAmount)
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
    Public Shared Function taCountriesDelete(ByVal Record As SIS.TA.taCountries) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaCountriesDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CountryID",SqlDbType.NVarChar,Record.CountryID.ToString.Length, Record.CountryID)
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
    Public Shared Function SelecttaCountriesAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaCountriesAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.TA.taCountries = New SIS.TA.taCountries(Reader)
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results.ToArray
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _CountryID = Ctype(Reader("CountryID"),String)
      _CountryName = Ctype(Reader("CountryName"),String)
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
      _ContingencyAmount = Ctype(Reader("ContingencyAmount"),Int32)
      If Convert.IsDBNull(Reader("TA_Currencies1_CurrencyName")) Then
        _TA_Currencies1_CurrencyName = String.Empty
      Else
        _TA_Currencies1_CurrencyName = Ctype(Reader("TA_Currencies1_CurrencyName"), String)
      End If
      If Convert.IsDBNull(Reader("TA_Regions2_RegionName")) Then
        _TA_Regions2_RegionName = String.Empty
      Else
        _TA_Regions2_RegionName = Ctype(Reader("TA_Regions2_RegionName"), String)
      End If
      If Convert.IsDBNull(Reader("TA_RegionTypes3_RegionTypeName")) Then
        _TA_RegionTypes3_RegionTypeName = String.Empty
      Else
        _TA_RegionTypes3_RegionTypeName = Ctype(Reader("TA_RegionTypes3_RegionTypeName"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
