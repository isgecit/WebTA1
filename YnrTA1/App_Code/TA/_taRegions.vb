Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taRegions
    Private Shared _RecordCount As Integer
    Private _RegionID As String = ""
    Private _RegionName As String = ""
    Private _RegionTypeID As String = ""
    Private _CurrencyID As String = ""
    Private _TA_Currencies1_CurrencyName As String = ""
    Private _TA_RegionTypes2_RegionTypeName As String = ""
    Private _FK_TA_Regions_Currency As SIS.TA.taCurrencies = Nothing
    Private _FK_TA_Regions_RegionTypeID As SIS.TA.taRegionTypes = Nothing
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
    Public Property RegionID() As String
      Get
        Return _RegionID
      End Get
      Set(ByVal value As String)
        _RegionID = value
      End Set
    End Property
    Public Property RegionName() As String
      Get
        Return _RegionName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _RegionName = ""
         Else
           _RegionName = value
         End If
      End Set
    End Property
    Public Property RegionTypeID() As String
      Get
        Return _RegionTypeID
      End Get
      Set(ByVal value As String)
        _RegionTypeID = value
      End Set
    End Property
    Public Property CurrencyID() As String
      Get
        Return _CurrencyID
      End Get
      Set(ByVal value As String)
        _CurrencyID = value
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
    Public Property TA_RegionTypes2_RegionTypeName() As String
      Get
        Return _TA_RegionTypes2_RegionTypeName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_RegionTypes2_RegionTypeName = ""
         Else
           _TA_RegionTypes2_RegionTypeName = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _RegionName.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _RegionID
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
    Public Class PKtaRegions
      Private _RegionID As String = ""
      Public Property RegionID() As String
        Get
          Return _RegionID
        End Get
        Set(ByVal value As String)
          _RegionID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_TA_Regions_Currency() As SIS.TA.taCurrencies
      Get
        If _FK_TA_Regions_Currency Is Nothing Then
          _FK_TA_Regions_Currency = SIS.TA.taCurrencies.taCurrenciesGetByID(_CurrencyID)
        End If
        Return _FK_TA_Regions_Currency
      End Get
    End Property
    Public ReadOnly Property FK_TA_Regions_RegionTypeID() As SIS.TA.taRegionTypes
      Get
        If _FK_TA_Regions_RegionTypeID Is Nothing Then
          _FK_TA_Regions_RegionTypeID = SIS.TA.taRegionTypes.taRegionTypesGetByID(_RegionTypeID)
        End If
        Return _FK_TA_Regions_RegionTypeID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taRegionsSelectList(ByVal OrderBy As String) As List(Of SIS.TA.taRegions)
      Dim Results As List(Of SIS.TA.taRegions) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaRegionsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taRegions)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taRegions(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taRegionsGetNewRecord() As SIS.TA.taRegions
      Return New SIS.TA.taRegions()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taRegionsGetByID(ByVal RegionID As String) As SIS.TA.taRegions
      Dim Results As SIS.TA.taRegions = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaRegionsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RegionID",SqlDbType.NVarChar,RegionID.ToString.Length, RegionID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TA.taRegions(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taRegionsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal RegionTypeID As String, ByVal CurrencyID As String) As List(Of SIS.TA.taRegions)
      Dim Results As List(Of SIS.TA.taRegions) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaRegionsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaRegionsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RegionTypeID",SqlDbType.NVarChar,10, IIf(RegionTypeID Is Nothing, String.Empty,RegionTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CurrencyID",SqlDbType.NVarChar,6, IIf(CurrencyID Is Nothing, String.Empty,CurrencyID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taRegions)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taRegions(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taRegionsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal RegionTypeID As String, ByVal CurrencyID As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taRegionsGetByID(ByVal RegionID As String, ByVal Filter_RegionTypeID As String, ByVal Filter_CurrencyID As String) As SIS.TA.taRegions
      Return taRegionsGetByID(RegionID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function taRegionsInsert(ByVal Record As SIS.TA.taRegions) As SIS.TA.taRegions
      Dim _Rec As SIS.TA.taRegions = SIS.TA.taRegions.taRegionsGetNewRecord()
      With _Rec
        .RegionID = Record.RegionID
        .RegionName = Record.RegionName
        .RegionTypeID = Record.RegionTypeID
        .CurrencyID = Record.CurrencyID
      End With
      Return SIS.TA.taRegions.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.TA.taRegions) As SIS.TA.taRegions
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaRegionsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RegionID",SqlDbType.NVarChar,11, Record.RegionID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RegionName",SqlDbType.NVarChar,51, Iif(Record.RegionName= "" ,Convert.DBNull, Record.RegionName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RegionTypeID",SqlDbType.NVarChar,11, Record.RegionTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyID",SqlDbType.NVarChar,7, Record.CurrencyID)
          Cmd.Parameters.Add("@Return_RegionID", SqlDbType.NVarChar, 11)
          Cmd.Parameters("@Return_RegionID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.RegionID = Cmd.Parameters("@Return_RegionID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taRegionsUpdate(ByVal Record As SIS.TA.taRegions) As SIS.TA.taRegions
      Dim _Rec As SIS.TA.taRegions = SIS.TA.taRegions.taRegionsGetByID(Record.RegionID)
      With _Rec
        .RegionName = Record.RegionName
        .RegionTypeID = Record.RegionTypeID
        .CurrencyID = Record.CurrencyID
      End With
      Return SIS.TA.taRegions.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.TA.taRegions) As SIS.TA.taRegions
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaRegionsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RegionID",SqlDbType.NVarChar,11, Record.RegionID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RegionID",SqlDbType.NVarChar,11, Record.RegionID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RegionName",SqlDbType.NVarChar,51, Iif(Record.RegionName= "" ,Convert.DBNull, Record.RegionName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RegionTypeID",SqlDbType.NVarChar,11, Record.RegionTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyID",SqlDbType.NVarChar,7, Record.CurrencyID)
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
    Public Shared Function taRegionsDelete(ByVal Record As SIS.TA.taRegions) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaRegionsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RegionID",SqlDbType.NVarChar,Record.RegionID.ToString.Length, Record.RegionID)
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
    Public Shared Function SelecttaRegionsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaRegionsAutoCompleteList"
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
            Dim Tmp As SIS.TA.taRegions = New SIS.TA.taRegions(Reader)
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results.ToArray
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _RegionID = Ctype(Reader("RegionID"),String)
      If Convert.IsDBNull(Reader("RegionName")) Then
        _RegionName = String.Empty
      Else
        _RegionName = Ctype(Reader("RegionName"), String)
      End If
      _RegionTypeID = Ctype(Reader("RegionTypeID"),String)
      _CurrencyID = Ctype(Reader("CurrencyID"),String)
      If Convert.IsDBNull(Reader("TA_Currencies1_CurrencyName")) Then
        _TA_Currencies1_CurrencyName = String.Empty
      Else
        _TA_Currencies1_CurrencyName = Ctype(Reader("TA_Currencies1_CurrencyName"), String)
      End If
      If Convert.IsDBNull(Reader("TA_RegionTypes2_RegionTypeName")) Then
        _TA_RegionTypes2_RegionTypeName = String.Empty
      Else
        _TA_RegionTypes2_RegionTypeName = Ctype(Reader("TA_RegionTypes2_RegionTypeName"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
