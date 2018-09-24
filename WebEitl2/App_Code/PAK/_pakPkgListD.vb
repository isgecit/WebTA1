Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakPkgListD
    Private Shared _RecordCount As Integer
    Private _ItemNo As Int32 = 0
    Private _UOMQuantity As String = ""
    Private _Quantity As Decimal = 0
    Private _UOMWeight As String = ""
    Private _WeightPerUnit As Decimal = 0
    Private _TotalWeight As Decimal = 0
    Private _UOMPack As String = ""
    Private _PackHeight As Decimal = 0
    Private _Remarks As String = ""
    Private _QuantityReceived As Decimal = 0
    Private _TotalWeightReceived As Decimal = 0
    Private _QuantityBalance As Decimal = 0
    Private _TotalWeightBalance As Decimal = 0
    Private _BOMNo As Int32 = 0
    Private _PkgNo As Int32 = 0
    Private _SerialNo As Int32 = 0
    Private _PackTypeID As String = ""
    Private _PackWidth As Decimal = 0
    Private _PackLength As Decimal = 0
    Private _PackingMark As String = ""
    Private _PAK_PakTypes1_Description As String = ""
    Private _PAK_PkgListH2_SupplierRefNo As String = ""
    Private _PAK_PO3_PODescription As String = ""
    Private _PAK_POBItems4_ItemDescription As String = ""
    Private _PAK_POBOM5_ItemDescription As String = ""
    Private _PAK_Units6_Description As String = ""
    Private _PAK_Units7_Description As String = ""
    Private _PAK_Units8_Description As String = ""
    Private _FK_PAK_PkgListD_PackTypeID As SIS.PAK.pakPakTypes = Nothing
    Private _FK_PAK_PkgListD_PkgNo As SIS.PAK.pakPkgListH = Nothing
    Private _FK_PAK_PkgListD_SerialNo As SIS.PAK.pakPO = Nothing
    Private _FK_PAK_PkgListD_ItemNo As SIS.PAK.pakPOBItems = Nothing
    Private _FK_PAK_PkgListD_BOMNo As SIS.PAK.pakPOBOM = Nothing
    Private _FK_PAK_PkgListD_UOMQuantity As SIS.PAK.pakUnits = Nothing
    Private _FK_PAK_PkgListD_UOMWeight As SIS.PAK.pakUnits = Nothing
    Private _FK_PAK_PkgListD_UOMPack As SIS.PAK.pakUnits = Nothing
    Public Property DocumentNo As String = ""
    Public Property DocumentRevision As String = ""
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
    Public Property ItemNo() As Int32
      Get
        Return _ItemNo
      End Get
      Set(ByVal value As Int32)
        _ItemNo = value
      End Set
    End Property
    Public Property UOMQuantity() As String
      Get
        Return _UOMQuantity
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _UOMQuantity = ""
         Else
           _UOMQuantity = value
         End If
      End Set
    End Property
    Public Property Quantity() As Decimal
      Get
        Return _Quantity
      End Get
      Set(ByVal value As Decimal)
        _Quantity = value
      End Set
    End Property
    Public Property UOMWeight() As String
      Get
        Return _UOMWeight
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _UOMWeight = ""
         Else
           _UOMWeight = value
         End If
      End Set
    End Property
    Public Property WeightPerUnit() As Decimal
      Get
        Return _WeightPerUnit
      End Get
      Set(ByVal value As Decimal)
        _WeightPerUnit = value
      End Set
    End Property
    Public Property TotalWeight() As Decimal
      Get
        Return _TotalWeight
      End Get
      Set(ByVal value As Decimal)
        _TotalWeight = value
      End Set
    End Property
    Public Property UOMPack() As String
      Get
        Return _UOMPack
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _UOMPack = ""
        Else
          _UOMPack = value
        End If
      End Set
    End Property
    Public Property PackHeight() As Decimal
      Get
        Return _PackHeight
      End Get
      Set(ByVal value As Decimal)
        _PackHeight = value
      End Set
    End Property
    Public Property Remarks() As String
      Get
        Return _Remarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Remarks = ""
         Else
           _Remarks = value
         End If
      End Set
    End Property
    Public Property QuantityReceived() As Decimal
      Get
        Return _QuantityReceived
      End Get
      Set(ByVal value As Decimal)
        _QuantityReceived = value
      End Set
    End Property
    Public Property TotalWeightReceived() As Decimal
      Get
        Return _TotalWeightReceived
      End Get
      Set(ByVal value As Decimal)
        _TotalWeightReceived = value
      End Set
    End Property
    Public Property QuantityBalance() As Decimal
      Get
        Return _QuantityBalance
      End Get
      Set(ByVal value As Decimal)
        _QuantityBalance = value
      End Set
    End Property
    Public Property TotalWeightBalance() As Decimal
      Get
        Return _TotalWeightBalance
      End Get
      Set(ByVal value As Decimal)
        _TotalWeightBalance = value
      End Set
    End Property
    Public Property BOMNo() As Int32
      Get
        Return _BOMNo
      End Get
      Set(ByVal value As Int32)
        _BOMNo = value
      End Set
    End Property
    Public Property PkgNo() As Int32
      Get
        Return _PkgNo
      End Get
      Set(ByVal value As Int32)
        _PkgNo = value
      End Set
    End Property
    Public Property SerialNo() As Int32
      Get
        Return _SerialNo
      End Get
      Set(ByVal value As Int32)
        _SerialNo = value
      End Set
    End Property
    Public Property PackTypeID() As String
      Get
        Return _PackTypeID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PackTypeID = ""
         Else
           _PackTypeID = value
         End If
      End Set
    End Property
    Public Property PackWidth() As Decimal
      Get
        Return _PackWidth
      End Get
      Set(ByVal value As Decimal)
        _PackWidth = value
      End Set
    End Property
    Public Property PackLength() As Decimal
      Get
        Return _PackLength
      End Get
      Set(ByVal value As Decimal)
        _PackLength = value
      End Set
    End Property
    Public Property PackingMark() As String
      Get
        Return _PackingMark
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PackingMark = ""
         Else
           _PackingMark = value
         End If
      End Set
    End Property
    Public Property PAK_PakTypes1_Description() As String
      Get
        Return _PAK_PakTypes1_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_PakTypes1_Description = ""
         Else
           _PAK_PakTypes1_Description = value
         End If
      End Set
    End Property
    Public Property PAK_PkgListH2_SupplierRefNo() As String
      Get
        Return _PAK_PkgListH2_SupplierRefNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_PkgListH2_SupplierRefNo = ""
         Else
           _PAK_PkgListH2_SupplierRefNo = value
         End If
      End Set
    End Property
    Public Property PAK_PO3_PODescription() As String
      Get
        Return _PAK_PO3_PODescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_PO3_PODescription = ""
         Else
           _PAK_PO3_PODescription = value
         End If
      End Set
    End Property
    Public Property PAK_POBItems4_ItemDescription() As String
      Get
        Return _PAK_POBItems4_ItemDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_POBItems4_ItemDescription = ""
         Else
           _PAK_POBItems4_ItemDescription = value
         End If
      End Set
    End Property
    Public Property PAK_POBOM5_ItemDescription() As String
      Get
        Return _PAK_POBOM5_ItemDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_POBOM5_ItemDescription = ""
         Else
           _PAK_POBOM5_ItemDescription = value
         End If
      End Set
    End Property
    Public Property PAK_Units6_Description() As String
      Get
        Return _PAK_Units6_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_Units6_Description = ""
         Else
           _PAK_Units6_Description = value
         End If
      End Set
    End Property
    Public Property PAK_Units7_Description() As String
      Get
        Return _PAK_Units7_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_Units7_Description = ""
         Else
           _PAK_Units7_Description = value
         End If
      End Set
    End Property
    Public Property PAK_Units8_Description() As String
      Get
        Return _PAK_Units8_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_Units8_Description = ""
         Else
           _PAK_Units8_Description = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _PackingMark.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _SerialNo & "|" & _PkgNo & "|" & _BOMNo & "|" & _ItemNo
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
    Public Class PKpakPkgListD
      Private _SerialNo As Int32 = 0
      Private _PkgNo As Int32 = 0
      Private _BOMNo As Int32 = 0
      Private _ItemNo As Int32 = 0
      Public Property SerialNo() As Int32
        Get
          Return _SerialNo
        End Get
        Set(ByVal value As Int32)
          _SerialNo = value
        End Set
      End Property
      Public Property PkgNo() As Int32
        Get
          Return _PkgNo
        End Get
        Set(ByVal value As Int32)
          _PkgNo = value
        End Set
      End Property
      Public Property BOMNo() As Int32
        Get
          Return _BOMNo
        End Get
        Set(ByVal value As Int32)
          _BOMNo = value
        End Set
      End Property
      Public Property ItemNo() As Int32
        Get
          Return _ItemNo
        End Get
        Set(ByVal value As Int32)
          _ItemNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PAK_PkgListD_PackTypeID() As SIS.PAK.pakPakTypes
      Get
        If _FK_PAK_PkgListD_PackTypeID Is Nothing Then
          _FK_PAK_PkgListD_PackTypeID = SIS.PAK.pakPakTypes.pakPakTypesGetByID(_PackTypeID)
        End If
        Return _FK_PAK_PkgListD_PackTypeID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_PkgListD_PkgNo() As SIS.PAK.pakPkgListH
      Get
        If _FK_PAK_PkgListD_PkgNo Is Nothing Then
          _FK_PAK_PkgListD_PkgNo = SIS.PAK.pakPkgListH.pakPkgPortHGetByID(_SerialNo, _PkgNo)
        End If
        Return _FK_PAK_PkgListD_PkgNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_PkgListD_SerialNo() As SIS.PAK.pakPO
      Get
        If _FK_PAK_PkgListD_SerialNo Is Nothing Then
          _FK_PAK_PkgListD_SerialNo = SIS.PAK.pakPO.pakPOGetByID(_SerialNo)
        End If
        Return _FK_PAK_PkgListD_SerialNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_PkgListD_ItemNo() As SIS.PAK.pakPOBItems
      Get
        If _FK_PAK_PkgListD_ItemNo Is Nothing Then
          _FK_PAK_PkgListD_ItemNo = SIS.PAK.pakPOBItems.pakPOBItemsGetByID(_SerialNo, _BOMNo, _ItemNo)
        End If
        Return _FK_PAK_PkgListD_ItemNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_PkgListD_BOMNo() As SIS.PAK.pakPOBOM
      Get
        If _FK_PAK_PkgListD_BOMNo Is Nothing Then
          _FK_PAK_PkgListD_BOMNo = SIS.PAK.pakPOBOM.pakPOBOMGetByID(_SerialNo, _BOMNo)
        End If
        Return _FK_PAK_PkgListD_BOMNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_PkgListD_UOMQuantity() As SIS.PAK.pakUnits
      Get
        If _FK_PAK_PkgListD_UOMQuantity Is Nothing Then
          _FK_PAK_PkgListD_UOMQuantity = SIS.PAK.pakUnits.pakUnitsGetByID(_UOMQuantity)
        End If
        Return _FK_PAK_PkgListD_UOMQuantity
      End Get
    End Property
    Public ReadOnly Property FK_PAK_PkgListD_UOMWeight() As SIS.PAK.pakUnits
      Get
        If _FK_PAK_PkgListD_UOMWeight Is Nothing Then
          _FK_PAK_PkgListD_UOMWeight = SIS.PAK.pakUnits.pakUnitsGetByID(_UOMWeight)
        End If
        Return _FK_PAK_PkgListD_UOMWeight
      End Get
    End Property
    Public ReadOnly Property FK_PAK_PkgListD_UOMPack() As SIS.PAK.pakUnits
      Get
        If _FK_PAK_PkgListD_UOMPack Is Nothing Then
          _FK_PAK_PkgListD_UOMPack = SIS.PAK.pakUnits.pakUnitsGetByID(_UOMPack)
        End If
        Return _FK_PAK_PkgListD_UOMPack
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakPkgListDSelectList(ByVal OrderBy As String) As List(Of SIS.PAK.pakPkgListD)
      Dim Results As List(Of SIS.PAK.pakPkgListD) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakPkgListDSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakPkgListD)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakPkgListD(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakPkgListDGetNewRecord() As SIS.PAK.pakPkgListD
      Return New SIS.PAK.pakPkgListD()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakPkgListDGetByID(ByVal SerialNo As Int32, ByVal PkgNo As Int32, ByVal BOMNo As Int32, ByVal ItemNo As Int32) As SIS.PAK.pakPkgListD
      Dim Results As SIS.PAK.pakPkgListD = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakPkgListDSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PkgNo",SqlDbType.Int,PkgNo.ToString.Length, PkgNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BOMNo",SqlDbType.Int,BOMNo.ToString.Length, BOMNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo",SqlDbType.Int,ItemNo.ToString.Length, ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakPkgListD(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakPkgListDSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PkgNo As Int32, ByVal SerialNo As Int32) As List(Of SIS.PAK.pakPkgListD)
      Dim Results As List(Of SIS.PAK.pakPkgListD) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakPkgListDSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakPkgListDSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PkgNo",SqlDbType.Int,10, IIf(PkgNo = Nothing, 0,PkgNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakPkgListD)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakPkgListD(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakPkgListDSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PkgNo As Int32, ByVal SerialNo As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakPkgListDGetByID(ByVal SerialNo As Int32, ByVal PkgNo As Int32, ByVal BOMNo As Int32, ByVal ItemNo As Int32, ByVal Filter_PkgNo As Int32, ByVal Filter_SerialNo As Int32) As SIS.PAK.pakPkgListD
      Return pakPkgListDGetByID(SerialNo, PkgNo, BOMNo, ItemNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function pakPkgListDInsert(ByVal Record As SIS.PAK.pakPkgListD) As SIS.PAK.pakPkgListD
      Dim _Rec As SIS.PAK.pakPkgListD = SIS.PAK.pakPkgListD.pakPkgListDGetNewRecord()
      With _Rec
        .ItemNo = Record.ItemNo
        .UOMQuantity = Record.UOMQuantity
        .Quantity = Record.Quantity
        .UOMWeight = Record.UOMWeight
        .WeightPerUnit = Record.WeightPerUnit
        .TotalWeight = Record.TotalWeight
        .UOMPack = Record.UOMPack
        .PackHeight = Record.PackHeight
        .Remarks = Record.Remarks
        .QuantityReceived = Record.QuantityReceived
        .TotalWeightReceived = Record.TotalWeightReceived
        .QuantityBalance = Record.QuantityBalance
        .TotalWeightBalance = Record.TotalWeightBalance
        .BOMNo = Record.BOMNo
        .PkgNo = Record.PkgNo
        .SerialNo = Record.SerialNo
        .PackTypeID = Record.PackTypeID
        .PackWidth = Record.PackWidth
        .PackLength = Record.PackLength
        .PackingMark = Record.PackingMark
        .DocumentNo = Record.DocumentNo
        .DocumentRevision = Record.DocumentRevision
      End With
      Return SIS.PAK.pakPkgListD.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PAK.pakPkgListD) As SIS.PAK.pakPkgListD
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakPkgListDInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo",SqlDbType.Int,11, Record.ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMQuantity",SqlDbType.Int,11, Iif(Record.UOMQuantity= "" ,Convert.DBNull, Record.UOMQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quantity",SqlDbType.Decimal,21, Record.Quantity)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMWeight",SqlDbType.Int,11, Iif(Record.UOMWeight= "" ,Convert.DBNull, Record.UOMWeight))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WeightPerUnit", SqlDbType.Decimal, 21, Record.WeightPerUnit)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalWeight", SqlDbType.Decimal, 21, Record.TotalWeight)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMPack", SqlDbType.Int, 11, IIf(Record.UOMPack = "", Convert.DBNull, Record.UOMPack))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PackHeight",SqlDbType.Decimal,21, Record.PackHeight)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,101, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QuantityReceived",SqlDbType.Decimal,21, Record.QuantityReceived)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalWeightReceived",SqlDbType.Decimal,21, Record.TotalWeightReceived)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QuantityBalance",SqlDbType.Decimal,21, Record.QuantityBalance)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalWeightBalance",SqlDbType.Decimal,21, Record.TotalWeightBalance)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BOMNo",SqlDbType.Int,11, Record.BOMNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PkgNo",SqlDbType.Int,11, Record.PkgNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PackTypeID",SqlDbType.Int,11, Iif(Record.PackTypeID= "" ,Convert.DBNull, Record.PackTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PackWidth",SqlDbType.Decimal,21, Record.PackWidth)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PackLength",SqlDbType.Decimal,21, Record.PackLength)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PackingMark", SqlDbType.NVarChar, 51, IIf(Record.PackingMark = "", Convert.DBNull, Record.PackingMark))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentNo", SqlDbType.NVarChar, 51, IIf(Record.DocumentNo = "", Convert.DBNull, Record.DocumentNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentRevision", SqlDbType.NVarChar, 11, IIf(Record.DocumentRevision = "", Convert.DBNull, Record.DocumentRevision))
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_PkgNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_PkgNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_BOMNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_BOMNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_ItemNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ItemNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
          Record.PkgNo = Cmd.Parameters("@Return_PkgNo").Value
          Record.BOMNo = Cmd.Parameters("@Return_BOMNo").Value
          Record.ItemNo = Cmd.Parameters("@Return_ItemNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakPkgListDUpdate(ByVal Record As SIS.PAK.pakPkgListD) As SIS.PAK.pakPkgListD
      Dim _Rec As SIS.PAK.pakPkgListD = SIS.PAK.pakPkgListD.pakPkgListDGetByID(Record.SerialNo, Record.PkgNo, Record.BOMNo, Record.ItemNo)
      With _Rec
        .UOMQuantity = Record.UOMQuantity
        .Quantity = Record.Quantity
        .UOMWeight = Record.UOMWeight
        .WeightPerUnit = Record.WeightPerUnit
        .TotalWeight = Record.TotalWeight
        .UOMPack = Record.UOMPack
        .PackHeight = Record.PackHeight
        .Remarks = Record.Remarks
        .QuantityReceived = Record.QuantityReceived
        .TotalWeightReceived = Record.TotalWeightReceived
        .QuantityBalance = Record.QuantityBalance
        .TotalWeightBalance = Record.TotalWeightBalance
        .PackTypeID = Record.PackTypeID
        .PackWidth = Record.PackWidth
        .PackLength = Record.PackLength
        .PackingMark = Record.PackingMark
        .DocumentNo = Record.DocumentNo
        .DocumentRevision = Record.DocumentRevision
      End With
      Return SIS.PAK.pakPkgListD.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PAK.pakPkgListD) As SIS.PAK.pakPkgListD
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakPkgListDUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ItemNo",SqlDbType.Int,11, Record.ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_BOMNo",SqlDbType.Int,11, Record.BOMNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_PkgNo",SqlDbType.Int,11, Record.PkgNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo",SqlDbType.Int,11, Record.ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMQuantity",SqlDbType.Int,11, Iif(Record.UOMQuantity= "" ,Convert.DBNull, Record.UOMQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quantity",SqlDbType.Decimal,21, Record.Quantity)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMWeight",SqlDbType.Int,11, Iif(Record.UOMWeight= "" ,Convert.DBNull, Record.UOMWeight))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WeightPerUnit",SqlDbType.Decimal,21, Record.WeightPerUnit)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalWeight", SqlDbType.Decimal, 21, Record.TotalWeight)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMPack", SqlDbType.Int, 11, IIf(Record.UOMPack = "", Convert.DBNull, Record.UOMPack))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PackHeight",SqlDbType.Decimal,21, Record.PackHeight)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,101, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QuantityReceived",SqlDbType.Decimal,21, Record.QuantityReceived)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalWeightReceived",SqlDbType.Decimal,21, Record.TotalWeightReceived)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QuantityBalance",SqlDbType.Decimal,21, Record.QuantityBalance)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalWeightBalance",SqlDbType.Decimal,21, Record.TotalWeightBalance)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BOMNo",SqlDbType.Int,11, Record.BOMNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PkgNo",SqlDbType.Int,11, Record.PkgNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PackTypeID",SqlDbType.Int,11, Iif(Record.PackTypeID= "" ,Convert.DBNull, Record.PackTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PackWidth",SqlDbType.Decimal,21, Record.PackWidth)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PackLength",SqlDbType.Decimal,21, Record.PackLength)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PackingMark",SqlDbType.NVarChar,51, Iif(Record.PackingMark= "" ,Convert.DBNull, Record.PackingMark))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentNo", SqlDbType.NVarChar, 51, IIf(Record.DocumentNo = "", Convert.DBNull, Record.DocumentNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentRevision", SqlDbType.NVarChar, 11, IIf(Record.DocumentRevision = "", Convert.DBNull, Record.DocumentRevision))
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
    Public Shared Function pakPkgListDDelete(ByVal Record As SIS.PAK.pakPkgListD) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakPkgListDDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,Record.SerialNo.ToString.Length, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_PkgNo",SqlDbType.Int,Record.PkgNo.ToString.Length, Record.PkgNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_BOMNo",SqlDbType.Int,Record.BOMNo.ToString.Length, Record.BOMNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ItemNo",SqlDbType.Int,Record.ItemNo.ToString.Length, Record.ItemNo)
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
    Public Shared Function SelectpakPkgListDAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakPkgListDAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),"" & "|" & "" & "|" & "" & "|" & ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.PAK.pakPkgListD = New SIS.PAK.pakPkgListD(Reader)
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
