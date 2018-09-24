Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ELOG
  <DataObject()> _
  Partial Public Class elogBLHeader
    Private Shared _RecordCount As Integer
    Private _BLID As String = ""
    Private _BLNumber As String = ""
    Private _BLDate As String = ""
    Private _PortOfLoading As String = ""
    Private _VesselOrFlightNo As String = ""
    Private _VoyageNo As String = ""
    Private _TransShipmentPortID As String = ""
    Private _PrepaidFlight As String = "0"
    Private _ShippingLine As String = ""
    Private _SOBDate As String = ""
    Private _MBLNo As String = ""
    Private _PreCarriageBy As String = ""
    Private _PlaceOfReceiptBy As String = ""
    Private _Air1Freight As String = ""
    Private _Air2Freight As String = ""
    Private _Air3Freight As String = ""
    Private _Air4Freight As String = ""
    Private _ELOG_Ports1_Description As String = ""
    Private _FK_ELOG_BLHeader_TransShipmentPortID As SIS.ELOG.elogPorts = Nothing
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
    Public Property BLID() As String
      Get
        Return _BLID
      End Get
      Set(ByVal value As String)
        _BLID = value
      End Set
    End Property
    Public Property BLNumber() As String
      Get
        Return _BLNumber
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _BLNumber = ""
         Else
           _BLNumber = value
         End If
      End Set
    End Property
    Public Property BLDate() As String
      Get
        If Not _BLDate = String.Empty Then
          Return Convert.ToDateTime(_BLDate).ToString("dd/MM/yyyy")
        End If
        Return _BLDate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _BLDate = ""
         Else
           _BLDate = value
         End If
      End Set
    End Property
    Public Property PortOfLoading() As String
      Get
        Return _PortOfLoading
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PortOfLoading = ""
         Else
           _PortOfLoading = value
         End If
      End Set
    End Property
    Public Property VesselOrFlightNo() As String
      Get
        Return _VesselOrFlightNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VesselOrFlightNo = ""
         Else
           _VesselOrFlightNo = value
         End If
      End Set
    End Property
    Public Property VoyageNo() As String
      Get
        Return _VoyageNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VoyageNo = ""
         Else
           _VoyageNo = value
         End If
      End Set
    End Property
    Public Property TransShipmentPortID() As String
      Get
        Return _TransShipmentPortID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TransShipmentPortID = ""
         Else
           _TransShipmentPortID = value
         End If
      End Set
    End Property
    Public Property PrepaidFlight() As String
      Get
        Return _PrepaidFlight
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
          _PrepaidFlight = "0"
        Else
           _PrepaidFlight = value
         End If
      End Set
    End Property
    Public Property ShippingLine() As String
      Get
        Return _ShippingLine
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ShippingLine = ""
         Else
           _ShippingLine = value
         End If
      End Set
    End Property
    Public Property SOBDate() As String
      Get
        If Not _SOBDate = String.Empty Then
          Return Convert.ToDateTime(_SOBDate).ToString("dd/MM/yyyy")
        End If
        Return _SOBDate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SOBDate = ""
         Else
           _SOBDate = value
         End If
      End Set
    End Property
    Public Property MBLNo() As String
      Get
        Return _MBLNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _MBLNo = ""
         Else
           _MBLNo = value
         End If
      End Set
    End Property
    Public Property PreCarriageBy() As String
      Get
        Return _PreCarriageBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PreCarriageBy = ""
         Else
           _PreCarriageBy = value
         End If
      End Set
    End Property
    Public Property PlaceOfReceiptBy() As String
      Get
        Return _PlaceOfReceiptBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PlaceOfReceiptBy = ""
         Else
           _PlaceOfReceiptBy = value
         End If
      End Set
    End Property
    Public Property Air1Freight() As String
      Get
        Return _Air1Freight
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Air1Freight = ""
         Else
           _Air1Freight = value
         End If
      End Set
    End Property
    Public Property Air2Freight() As String
      Get
        Return _Air2Freight
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Air2Freight = ""
         Else
           _Air2Freight = value
         End If
      End Set
    End Property
    Public Property Air3Freight() As String
      Get
        Return _Air3Freight
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Air3Freight = ""
         Else
           _Air3Freight = value
         End If
      End Set
    End Property
    Public Property Air4Freight() As String
      Get
        Return _Air4Freight
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Air4Freight = ""
         Else
           _Air4Freight = value
         End If
      End Set
    End Property
    Public Property ELOG_Ports1_Description() As String
      Get
        Return _ELOG_Ports1_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ELOG_Ports1_Description = ""
         Else
           _ELOG_Ports1_Description = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _BLNumber.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _BLID
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
    Public Class PKelogBLHeader
      Private _BLID As String = ""
      Public Property BLID() As String
        Get
          Return _BLID
        End Get
        Set(ByVal value As String)
          _BLID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_ELOG_BLHeader_TransShipmentPortID() As SIS.ELOG.elogPorts
      Get
        If _FK_ELOG_BLHeader_TransShipmentPortID Is Nothing Then
          _FK_ELOG_BLHeader_TransShipmentPortID = SIS.ELOG.elogPorts.elogPortsGetByID(_TransShipmentPortID)
        End If
        Return _FK_ELOG_BLHeader_TransShipmentPortID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function elogBLHeaderSelectList(ByVal OrderBy As String) As List(Of SIS.ELOG.elogBLHeader)
      Dim Results As List(Of SIS.ELOG.elogBLHeader) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogBLHeaderSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ELOG.elogBLHeader)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ELOG.elogBLHeader(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function elogBLHeaderGetNewRecord() As SIS.ELOG.elogBLHeader
      Return New SIS.ELOG.elogBLHeader()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function elogBLHeaderGetByID(ByVal BLID As String) As SIS.ELOG.elogBLHeader
      Dim Results As SIS.ELOG.elogBLHeader = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogBLHeaderSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BLID",SqlDbType.NVarChar,BLID.ToString.Length, BLID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ELOG.elogBLHeader(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function elogBLHeaderSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.ELOG.elogBLHeader)
      Dim Results As List(Of SIS.ELOG.elogBLHeader) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spelogBLHeaderSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spelogBLHeaderSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ELOG.elogBLHeader)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ELOG.elogBLHeader(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function elogBLHeaderSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function elogBLHeaderInsert(ByVal Record As SIS.ELOG.elogBLHeader) As SIS.ELOG.elogBLHeader
      Dim _Rec As SIS.ELOG.elogBLHeader = SIS.ELOG.elogBLHeader.elogBLHeaderGetNewRecord()
      With _Rec
        .BLID = Record.BLID
        .BLNumber = Record.BLNumber
        .BLDate = Record.BLDate
        .PortOfLoading = Record.PortOfLoading
        .VesselOrFlightNo = Record.VesselOrFlightNo
        .VoyageNo = Record.VoyageNo
        .TransShipmentPortID = Record.TransShipmentPortID
        .PrepaidFlight = Record.PrepaidFlight
        .ShippingLine = Record.ShippingLine
        .SOBDate = Record.SOBDate
        .MBLNo = Record.MBLNo
        .PreCarriageBy = Record.PreCarriageBy
        .PlaceOfReceiptBy = Record.PlaceOfReceiptBy
        .Air1Freight = Record.Air1Freight
        .Air2Freight = Record.Air2Freight
        .Air3Freight = Record.Air3Freight
        .Air4Freight = Record.Air4Freight
      End With
      Return SIS.ELOG.elogBLHeader.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.ELOG.elogBLHeader) As SIS.ELOG.elogBLHeader
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogBLHeaderInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BLID",SqlDbType.NVarChar,10, Record.BLID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BLNumber",SqlDbType.NVarChar,51, Iif(Record.BLNumber= "" ,Convert.DBNull, Record.BLNumber))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BLDate",SqlDbType.DateTime,21, Iif(Record.BLDate= "" ,Convert.DBNull, Record.BLDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PortOfLoading",SqlDbType.NVarChar,101, Iif(Record.PortOfLoading= "" ,Convert.DBNull, Record.PortOfLoading))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VesselOrFlightNo",SqlDbType.NVarChar,101, Iif(Record.VesselOrFlightNo= "" ,Convert.DBNull, Record.VesselOrFlightNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VoyageNo",SqlDbType.NVarChar,101, Iif(Record.VoyageNo= "" ,Convert.DBNull, Record.VoyageNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransShipmentPortID",SqlDbType.Int,11, Iif(Record.TransShipmentPortID= "" ,Convert.DBNull, Record.TransShipmentPortID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PrepaidFlight",SqlDbType.Bit,3, Iif(Record.PrepaidFlight= "" ,Convert.DBNull, Record.PrepaidFlight))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ShippingLine",SqlDbType.NVarChar,101, Iif(Record.ShippingLine= "" ,Convert.DBNull, Record.ShippingLine))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SOBDate",SqlDbType.DateTime,21, Iif(Record.SOBDate= "" ,Convert.DBNull, Record.SOBDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MBLNo",SqlDbType.NVarChar,51, Iif(Record.MBLNo= "" ,Convert.DBNull, Record.MBLNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PreCarriageBy",SqlDbType.NVarChar,101, Iif(Record.PreCarriageBy= "" ,Convert.DBNull, Record.PreCarriageBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PlaceOfReceiptBy",SqlDbType.NVarChar,101, Iif(Record.PlaceOfReceiptBy= "" ,Convert.DBNull, Record.PlaceOfReceiptBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Air1Freight",SqlDbType.NVarChar,101, Iif(Record.Air1Freight= "" ,Convert.DBNull, Record.Air1Freight))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Air2Freight",SqlDbType.NVarChar,101, Iif(Record.Air2Freight= "" ,Convert.DBNull, Record.Air2Freight))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Air3Freight",SqlDbType.NVarChar,101, Iif(Record.Air3Freight= "" ,Convert.DBNull, Record.Air3Freight))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Air4Freight",SqlDbType.NVarChar,101, Iif(Record.Air4Freight= "" ,Convert.DBNull, Record.Air4Freight))
          Cmd.Parameters.Add("@Return_BLID", SqlDbType.NVarChar, 10)
          Cmd.Parameters("@Return_BLID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.BLID = Cmd.Parameters("@Return_BLID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function elogBLHeaderUpdate(ByVal Record As SIS.ELOG.elogBLHeader) As SIS.ELOG.elogBLHeader
      Dim _Rec As SIS.ELOG.elogBLHeader = SIS.ELOG.elogBLHeader.elogBLHeaderGetByID(Record.BLID)
      With _Rec
        .BLNumber = Record.BLNumber
        .BLDate = Record.BLDate
        .PortOfLoading = Record.PortOfLoading
        .VesselOrFlightNo = Record.VesselOrFlightNo
        .VoyageNo = Record.VoyageNo
        .TransShipmentPortID = Record.TransShipmentPortID
        .PrepaidFlight = Record.PrepaidFlight
        .ShippingLine = Record.ShippingLine
        .SOBDate = Record.SOBDate
        .MBLNo = Record.MBLNo
        .PreCarriageBy = Record.PreCarriageBy
        .PlaceOfReceiptBy = Record.PlaceOfReceiptBy
        .Air1Freight = Record.Air1Freight
        .Air2Freight = Record.Air2Freight
        .Air3Freight = Record.Air3Freight
        .Air4Freight = Record.Air4Freight
      End With
      Return SIS.ELOG.elogBLHeader.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.ELOG.elogBLHeader) As SIS.ELOG.elogBLHeader
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogBLHeaderUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_BLID",SqlDbType.NVarChar,10, Record.BLID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BLID",SqlDbType.NVarChar,10, Record.BLID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BLNumber",SqlDbType.NVarChar,51, Iif(Record.BLNumber= "" ,Convert.DBNull, Record.BLNumber))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BLDate",SqlDbType.DateTime,21, Iif(Record.BLDate= "" ,Convert.DBNull, Record.BLDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PortOfLoading",SqlDbType.NVarChar,101, Iif(Record.PortOfLoading= "" ,Convert.DBNull, Record.PortOfLoading))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VesselOrFlightNo",SqlDbType.NVarChar,101, Iif(Record.VesselOrFlightNo= "" ,Convert.DBNull, Record.VesselOrFlightNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VoyageNo",SqlDbType.NVarChar,101, Iif(Record.VoyageNo= "" ,Convert.DBNull, Record.VoyageNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransShipmentPortID",SqlDbType.Int,11, Iif(Record.TransShipmentPortID= "" ,Convert.DBNull, Record.TransShipmentPortID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PrepaidFlight",SqlDbType.Bit,3, Iif(Record.PrepaidFlight= "" ,Convert.DBNull, Record.PrepaidFlight))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ShippingLine",SqlDbType.NVarChar,101, Iif(Record.ShippingLine= "" ,Convert.DBNull, Record.ShippingLine))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SOBDate",SqlDbType.DateTime,21, Iif(Record.SOBDate= "" ,Convert.DBNull, Record.SOBDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MBLNo",SqlDbType.NVarChar,51, Iif(Record.MBLNo= "" ,Convert.DBNull, Record.MBLNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PreCarriageBy",SqlDbType.NVarChar,101, Iif(Record.PreCarriageBy= "" ,Convert.DBNull, Record.PreCarriageBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PlaceOfReceiptBy",SqlDbType.NVarChar,101, Iif(Record.PlaceOfReceiptBy= "" ,Convert.DBNull, Record.PlaceOfReceiptBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Air1Freight",SqlDbType.NVarChar,101, Iif(Record.Air1Freight= "" ,Convert.DBNull, Record.Air1Freight))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Air2Freight",SqlDbType.NVarChar,101, Iif(Record.Air2Freight= "" ,Convert.DBNull, Record.Air2Freight))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Air3Freight",SqlDbType.NVarChar,101, Iif(Record.Air3Freight= "" ,Convert.DBNull, Record.Air3Freight))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Air4Freight",SqlDbType.NVarChar,101, Iif(Record.Air4Freight= "" ,Convert.DBNull, Record.Air4Freight))
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
    Public Shared Function elogBLHeaderDelete(ByVal Record As SIS.ELOG.elogBLHeader) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogBLHeaderDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_BLID",SqlDbType.NVarChar,Record.BLID.ToString.Length, Record.BLID)
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
    Public Shared Function SelectelogBLHeaderAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogBLHeaderAutoCompleteList"
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
            Dim Tmp As SIS.ELOG.elogBLHeader = New SIS.ELOG.elogBLHeader(Reader)
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
