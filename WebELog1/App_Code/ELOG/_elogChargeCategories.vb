Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ELOG
  <DataObject()> _
  Partial Public Class elogChargeCategories
    Private Shared _RecordCount As Integer
    Private _ChargeCategoryID As Int32 = 0
    Private _ShipmentModeID As String = ""
    Private _LocationCountryID As String = ""
    Private _CargoTypeID As String = ""
    Private _StuffingTypeID As String = ""
    Private _StuffingPointID As String = ""
    Private _BreakbulkTypeID As String = ""
    Private _ChargeTypeID As String = ""
    Private _Description As String = ""
    Private _ELOG_BreakbulkTypes1_Description As String = ""
    Private _ELOG_CargoTypes2_Description As String = ""
    Private _ELOG_ChargeTypes3_Description As String = ""
    Private _ELOG_LocationCountries4_Description As String = ""
    Private _ELOG_ShipmentModes5_Description As String = ""
    Private _ELOG_StuffingPoints6_Description As String = ""
    Private _ELOG_StuffingTypes7_Description As String = ""
    Private _FK_ELOG_ChargeCategories_BreakbulkTypeID As SIS.ELOG.elogBreakbulkTypes = Nothing
    Private _FK_ELOG_ChargeCategories_CargoTypeID As SIS.ELOG.elogCargoTypes = Nothing
    Private _FK_ELOG_ChargeCategories_ChargeTypeID As SIS.ELOG.elogChargeTypes = Nothing
    Private _FK_ELOG_ChargeCategories_LocationCountryID As SIS.ELOG.elogLocationCountries = Nothing
    Private _FK_ELOG_ChargeCategories_ShipmentModeID As SIS.ELOG.elogShipmentModes = Nothing
    Private _FK_ELOG_ChargeCategories_StuffingPointID As SIS.ELOG.elogStuffingPoints = Nothing
    Private _FK_ELOG_ChargeCategories_StuffingTypeID As SIS.ELOG.elogStuffingTypes = Nothing
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
    Public Property ChargeCategoryID() As Int32
      Get
        Return _ChargeCategoryID
      End Get
      Set(ByVal value As Int32)
        _ChargeCategoryID = value
      End Set
    End Property
    Public Property ShipmentModeID() As String
      Get
        Return _ShipmentModeID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ShipmentModeID = ""
         Else
           _ShipmentModeID = value
         End If
      End Set
    End Property
    Public Property LocationCountryID() As String
      Get
        Return _LocationCountryID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _LocationCountryID = ""
         Else
           _LocationCountryID = value
         End If
      End Set
    End Property
    Public Property CargoTypeID() As String
      Get
        Return _CargoTypeID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CargoTypeID = ""
         Else
           _CargoTypeID = value
         End If
      End Set
    End Property
    Public Property StuffingTypeID() As String
      Get
        Return _StuffingTypeID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _StuffingTypeID = ""
         Else
           _StuffingTypeID = value
         End If
      End Set
    End Property
    Public Property StuffingPointID() As String
      Get
        Return _StuffingPointID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _StuffingPointID = ""
         Else
           _StuffingPointID = value
         End If
      End Set
    End Property
    Public Property BreakbulkTypeID() As String
      Get
        Return _BreakbulkTypeID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _BreakbulkTypeID = ""
         Else
           _BreakbulkTypeID = value
         End If
      End Set
    End Property
    Public Property ChargeTypeID() As String
      Get
        Return _ChargeTypeID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ChargeTypeID = ""
         Else
           _ChargeTypeID = value
         End If
      End Set
    End Property
    Public Property Description() As String
      Get
        Return _Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Description = ""
         Else
           _Description = value
         End If
      End Set
    End Property
    Public Property ELOG_BreakbulkTypes1_Description() As String
      Get
        Return _ELOG_BreakbulkTypes1_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ELOG_BreakbulkTypes1_Description = ""
         Else
           _ELOG_BreakbulkTypes1_Description = value
         End If
      End Set
    End Property
    Public Property ELOG_CargoTypes2_Description() As String
      Get
        Return _ELOG_CargoTypes2_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ELOG_CargoTypes2_Description = ""
         Else
           _ELOG_CargoTypes2_Description = value
         End If
      End Set
    End Property
    Public Property ELOG_ChargeTypes3_Description() As String
      Get
        Return _ELOG_ChargeTypes3_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ELOG_ChargeTypes3_Description = ""
         Else
           _ELOG_ChargeTypes3_Description = value
         End If
      End Set
    End Property
    Public Property ELOG_LocationCountries4_Description() As String
      Get
        Return _ELOG_LocationCountries4_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ELOG_LocationCountries4_Description = ""
         Else
           _ELOG_LocationCountries4_Description = value
         End If
      End Set
    End Property
    Public Property ELOG_ShipmentModes5_Description() As String
      Get
        Return _ELOG_ShipmentModes5_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ELOG_ShipmentModes5_Description = ""
         Else
           _ELOG_ShipmentModes5_Description = value
         End If
      End Set
    End Property
    Public Property ELOG_StuffingPoints6_Description() As String
      Get
        Return _ELOG_StuffingPoints6_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ELOG_StuffingPoints6_Description = ""
         Else
           _ELOG_StuffingPoints6_Description = value
         End If
      End Set
    End Property
    Public Property ELOG_StuffingTypes7_Description() As String
      Get
        Return _ELOG_StuffingTypes7_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ELOG_StuffingTypes7_Description = ""
         Else
           _ELOG_StuffingTypes7_Description = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _Description.ToString.PadRight(100, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _ChargeCategoryID
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
    Public Class PKelogChargeCategories
      Private _ChargeCategoryID As Int32 = 0
      Public Property ChargeCategoryID() As Int32
        Get
          Return _ChargeCategoryID
        End Get
        Set(ByVal value As Int32)
          _ChargeCategoryID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_ELOG_ChargeCategories_BreakbulkTypeID() As SIS.ELOG.elogBreakbulkTypes
      Get
        If _FK_ELOG_ChargeCategories_BreakbulkTypeID Is Nothing Then
          _FK_ELOG_ChargeCategories_BreakbulkTypeID = SIS.ELOG.elogBreakbulkTypes.elogBreakbulkTypesGetByID(_BreakbulkTypeID)
        End If
        Return _FK_ELOG_ChargeCategories_BreakbulkTypeID
      End Get
    End Property
    Public ReadOnly Property FK_ELOG_ChargeCategories_CargoTypeID() As SIS.ELOG.elogCargoTypes
      Get
        If _FK_ELOG_ChargeCategories_CargoTypeID Is Nothing Then
          _FK_ELOG_ChargeCategories_CargoTypeID = SIS.ELOG.elogCargoTypes.elogCargoTypesGetByID(_CargoTypeID)
        End If
        Return _FK_ELOG_ChargeCategories_CargoTypeID
      End Get
    End Property
    Public ReadOnly Property FK_ELOG_ChargeCategories_ChargeTypeID() As SIS.ELOG.elogChargeTypes
      Get
        If _FK_ELOG_ChargeCategories_ChargeTypeID Is Nothing Then
          _FK_ELOG_ChargeCategories_ChargeTypeID = SIS.ELOG.elogChargeTypes.elogChargeTypesGetByID(_ChargeTypeID)
        End If
        Return _FK_ELOG_ChargeCategories_ChargeTypeID
      End Get
    End Property
    Public ReadOnly Property FK_ELOG_ChargeCategories_LocationCountryID() As SIS.ELOG.elogLocationCountries
      Get
        If _FK_ELOG_ChargeCategories_LocationCountryID Is Nothing Then
          _FK_ELOG_ChargeCategories_LocationCountryID = SIS.ELOG.elogLocationCountries.elogLocationCountriesGetByID(_LocationCountryID)
        End If
        Return _FK_ELOG_ChargeCategories_LocationCountryID
      End Get
    End Property
    Public ReadOnly Property FK_ELOG_ChargeCategories_ShipmentModeID() As SIS.ELOG.elogShipmentModes
      Get
        If _FK_ELOG_ChargeCategories_ShipmentModeID Is Nothing Then
          _FK_ELOG_ChargeCategories_ShipmentModeID = SIS.ELOG.elogShipmentModes.elogShipmentModesGetByID(_ShipmentModeID)
        End If
        Return _FK_ELOG_ChargeCategories_ShipmentModeID
      End Get
    End Property
    Public ReadOnly Property FK_ELOG_ChargeCategories_StuffingPointID() As SIS.ELOG.elogStuffingPoints
      Get
        If _FK_ELOG_ChargeCategories_StuffingPointID Is Nothing Then
          _FK_ELOG_ChargeCategories_StuffingPointID = SIS.ELOG.elogStuffingPoints.elogStuffingPointsGetByID(_StuffingPointID)
        End If
        Return _FK_ELOG_ChargeCategories_StuffingPointID
      End Get
    End Property
    Public ReadOnly Property FK_ELOG_ChargeCategories_StuffingTypeID() As SIS.ELOG.elogStuffingTypes
      Get
        If _FK_ELOG_ChargeCategories_StuffingTypeID Is Nothing Then
          _FK_ELOG_ChargeCategories_StuffingTypeID = SIS.ELOG.elogStuffingTypes.elogStuffingTypesGetByID(_StuffingTypeID)
        End If
        Return _FK_ELOG_ChargeCategories_StuffingTypeID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function elogChargeCategoriesSelectList(ByVal OrderBy As String) As List(Of SIS.ELOG.elogChargeCategories)
      Dim Results As List(Of SIS.ELOG.elogChargeCategories) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogChargeCategoriesSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ELOG.elogChargeCategories)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ELOG.elogChargeCategories(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function elogChargeCategoriesGetNewRecord() As SIS.ELOG.elogChargeCategories
      Return New SIS.ELOG.elogChargeCategories()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function elogChargeCategoriesGetByID(ByVal ChargeCategoryID As Int32) As SIS.ELOG.elogChargeCategories
      Dim Results As SIS.ELOG.elogChargeCategories = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogChargeCategoriesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ChargeCategoryID",SqlDbType.Int,ChargeCategoryID.ToString.Length, ChargeCategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ELOG.elogChargeCategories(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function elogChargeCategoriesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ShipmentModeID As Int32, ByVal LocationCountryID As Int32, ByVal CargoTypeID As Int32, ByVal StuffingTypeID As Int32, ByVal StuffingPointID As Int32, ByVal BreakbulkTypeID As Int32, ByVal ChargeTypeID As Int32) As List(Of SIS.ELOG.elogChargeCategories)
      Dim Results As List(Of SIS.ELOG.elogChargeCategories) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spelogChargeCategoriesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spelogChargeCategoriesSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ShipmentModeID",SqlDbType.Int,10, IIf(ShipmentModeID = Nothing, 0,ShipmentModeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_LocationCountryID",SqlDbType.Int,10, IIf(LocationCountryID = Nothing, 0,LocationCountryID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CargoTypeID",SqlDbType.Int,10, IIf(CargoTypeID = Nothing, 0,CargoTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StuffingTypeID",SqlDbType.Int,10, IIf(StuffingTypeID = Nothing, 0,StuffingTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StuffingPointID",SqlDbType.Int,10, IIf(StuffingPointID = Nothing, 0,StuffingPointID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BreakbulkTypeID",SqlDbType.Int,10, IIf(BreakbulkTypeID = Nothing, 0,BreakbulkTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ChargeTypeID",SqlDbType.Int,10, IIf(ChargeTypeID = Nothing, 0,ChargeTypeID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ELOG.elogChargeCategories)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ELOG.elogChargeCategories(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function elogChargeCategoriesSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ShipmentModeID As Int32, ByVal LocationCountryID As Int32, ByVal CargoTypeID As Int32, ByVal StuffingTypeID As Int32, ByVal StuffingPointID As Int32, ByVal BreakbulkTypeID As Int32, ByVal ChargeTypeID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function elogChargeCategoriesGetByID(ByVal ChargeCategoryID As Int32, ByVal Filter_ShipmentModeID As Int32, ByVal Filter_LocationCountryID As Int32, ByVal Filter_CargoTypeID As Int32, ByVal Filter_StuffingTypeID As Int32, ByVal Filter_StuffingPointID As Int32, ByVal Filter_BreakbulkTypeID As Int32, ByVal Filter_ChargeTypeID As Int32) As SIS.ELOG.elogChargeCategories
      Return elogChargeCategoriesGetByID(ChargeCategoryID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function elogChargeCategoriesInsert(ByVal Record As SIS.ELOG.elogChargeCategories) As SIS.ELOG.elogChargeCategories
      Dim _Rec As SIS.ELOG.elogChargeCategories = SIS.ELOG.elogChargeCategories.elogChargeCategoriesGetNewRecord()
      With _Rec
        .ShipmentModeID = Record.ShipmentModeID
        .LocationCountryID = Record.LocationCountryID
        .CargoTypeID = Record.CargoTypeID
        .StuffingTypeID = Record.StuffingTypeID
        .StuffingPointID = Record.StuffingPointID
        .BreakbulkTypeID = Record.BreakbulkTypeID
        .ChargeTypeID = Record.ChargeTypeID
        .Description = Record.Description
      End With
      Return SIS.ELOG.elogChargeCategories.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.ELOG.elogChargeCategories) As SIS.ELOG.elogChargeCategories
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogChargeCategoriesInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ShipmentModeID",SqlDbType.Int,11, Iif(Record.ShipmentModeID= "" ,Convert.DBNull, Record.ShipmentModeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LocationCountryID",SqlDbType.Int,11, Iif(Record.LocationCountryID= "" ,Convert.DBNull, Record.LocationCountryID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CargoTypeID",SqlDbType.Int,11, Iif(Record.CargoTypeID= "" ,Convert.DBNull, Record.CargoTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StuffingTypeID",SqlDbType.Int,11, Iif(Record.StuffingTypeID= "" ,Convert.DBNull, Record.StuffingTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StuffingPointID",SqlDbType.Int,11, Iif(Record.StuffingPointID= "" ,Convert.DBNull, Record.StuffingPointID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BreakbulkTypeID",SqlDbType.Int,11, Iif(Record.BreakbulkTypeID= "" ,Convert.DBNull, Record.BreakbulkTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ChargeTypeID",SqlDbType.Int,11, Iif(Record.ChargeTypeID= "" ,Convert.DBNull, Record.ChargeTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,101, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          Cmd.Parameters.Add("@Return_ChargeCategoryID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ChargeCategoryID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ChargeCategoryID = Cmd.Parameters("@Return_ChargeCategoryID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function elogChargeCategoriesUpdate(ByVal Record As SIS.ELOG.elogChargeCategories) As SIS.ELOG.elogChargeCategories
      Dim _Rec As SIS.ELOG.elogChargeCategories = SIS.ELOG.elogChargeCategories.elogChargeCategoriesGetByID(Record.ChargeCategoryID)
      With _Rec
        .ShipmentModeID = Record.ShipmentModeID
        .LocationCountryID = Record.LocationCountryID
        .CargoTypeID = Record.CargoTypeID
        .StuffingTypeID = Record.StuffingTypeID
        .StuffingPointID = Record.StuffingPointID
        .BreakbulkTypeID = Record.BreakbulkTypeID
        .ChargeTypeID = Record.ChargeTypeID
        .Description = Record.Description
      End With
      Return SIS.ELOG.elogChargeCategories.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.ELOG.elogChargeCategories) As SIS.ELOG.elogChargeCategories
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogChargeCategoriesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ChargeCategoryID",SqlDbType.Int,11, Record.ChargeCategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ShipmentModeID",SqlDbType.Int,11, Iif(Record.ShipmentModeID= "" ,Convert.DBNull, Record.ShipmentModeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LocationCountryID",SqlDbType.Int,11, Iif(Record.LocationCountryID= "" ,Convert.DBNull, Record.LocationCountryID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CargoTypeID",SqlDbType.Int,11, Iif(Record.CargoTypeID= "" ,Convert.DBNull, Record.CargoTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StuffingTypeID",SqlDbType.Int,11, Iif(Record.StuffingTypeID= "" ,Convert.DBNull, Record.StuffingTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StuffingPointID",SqlDbType.Int,11, Iif(Record.StuffingPointID= "" ,Convert.DBNull, Record.StuffingPointID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BreakbulkTypeID",SqlDbType.Int,11, Iif(Record.BreakbulkTypeID= "" ,Convert.DBNull, Record.BreakbulkTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ChargeTypeID",SqlDbType.Int,11, Iif(Record.ChargeTypeID= "" ,Convert.DBNull, Record.ChargeTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,101, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
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
    Public Shared Function elogChargeCategoriesDelete(ByVal Record As SIS.ELOG.elogChargeCategories) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogChargeCategoriesDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ChargeCategoryID",SqlDbType.Int,Record.ChargeCategoryID.ToString.Length, Record.ChargeCategoryID)
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
    Public Shared Function SelectelogChargeCategoriesAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogChargeCategoriesAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(100, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.ELOG.elogChargeCategories = New SIS.ELOG.elogChargeCategories(Reader)
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
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
    Public Sub New()
    End Sub
  End Class
End Namespace
