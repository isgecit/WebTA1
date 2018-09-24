Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ELOG
  <DataObject()> _
  Partial Public Class elogIRBLDetails
    Private Shared _RecordCount As Integer
    Private _IRNo As Int32 = 0
    Private _SerialNo As Int32 = 0
    Private _StuffingTypeID As String = ""
    Private _StuffingPointID As String = ""
    Private _ICDCFSID As String = ""
    Private _OtherICDCFS As String = ""
    Private _BreakBulkID As String = ""
    Private _ChargeTypeID As String = ""
    Private _ChargeCategoryID As String = ""
    Private _ChargeCodeID As String = ""
    Private _Amount As String = "0.00"
    Private _Remarks As String = ""
    Private _ELOG_BreakbulkTypes1_Description As String = ""
    Private _ELOG_ChargeCategories2_Description As String = ""
    Private _ELOG_ChargeCodes3_Description As String = ""
    Private _ELOG_ChargeTypes4_Description As String = ""
    Private _ELOG_ICDCFSs5_Description As String = ""
    Private _ELOG_IRBL6_SupplierBillNo As String = ""
    Private _ELOG_StuffingPoints7_Description As String = ""
    Private _ELOG_StuffingTypes8_Description As String = ""
    Private _FK_ELOG_IRBLDetails_BreakbulkID As SIS.ELOG.elogBreakbulkTypes = Nothing
    Private _FK_ELOG_IRBLDetails_ChargeCategoryID As SIS.ELOG.elogChargeCategories = Nothing
    Private _FK_ELOG_IRBLDetails_ChargeCodeID As SIS.ELOG.elogChargeCodes = Nothing
    Private _FK_ELOG_IRBLDetails_ChargeTypeID As SIS.ELOG.elogChargeTypes = Nothing
    Private _FK_ELOG_IRBLDetails_ICDCFSID As SIS.ELOG.elogICDCFSs = Nothing
    Private _FK_ELOG_IRBLDetails_IRNo As SIS.ELOG.elogIRBL = Nothing
    Private _FK_ELOG_IRBLDetails_StuffingPointID As SIS.ELOG.elogStuffingPoints = Nothing
    Private _FK_ELOG_IRBLDetails_StuffingTypeID As SIS.ELOG.elogStuffingTypes = Nothing
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
    Public Property IRNo() As Int32
      Get
        Return _IRNo
      End Get
      Set(ByVal value As Int32)
        _IRNo = value
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
    Public Property ICDCFSID() As String
      Get
        Return _ICDCFSID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ICDCFSID = ""
         Else
           _ICDCFSID = value
         End If
      End Set
    End Property
    Public Property OtherICDCFS() As String
      Get
        Return _OtherICDCFS
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _OtherICDCFS = ""
         Else
           _OtherICDCFS = value
         End If
      End Set
    End Property
    Public Property BreakBulkID() As String
      Get
        Return _BreakBulkID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _BreakBulkID = ""
         Else
           _BreakBulkID = value
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
    Public Property ChargeCategoryID() As String
      Get
        Return _ChargeCategoryID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ChargeCategoryID = ""
         Else
           _ChargeCategoryID = value
         End If
      End Set
    End Property
    Public Property ChargeCodeID() As String
      Get
        Return _ChargeCodeID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ChargeCodeID = ""
         Else
           _ChargeCodeID = value
         End If
      End Set
    End Property
    Public Property Amount() As String
      Get
        Return _Amount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Amount = "0.00"
         Else
           _Amount = value
         End If
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
    Public Property ELOG_ChargeCategories2_Description() As String
      Get
        Return _ELOG_ChargeCategories2_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ELOG_ChargeCategories2_Description = ""
         Else
           _ELOG_ChargeCategories2_Description = value
         End If
      End Set
    End Property
    Public Property ELOG_ChargeCodes3_Description() As String
      Get
        Return _ELOG_ChargeCodes3_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ELOG_ChargeCodes3_Description = ""
         Else
           _ELOG_ChargeCodes3_Description = value
         End If
      End Set
    End Property
    Public Property ELOG_ChargeTypes4_Description() As String
      Get
        Return _ELOG_ChargeTypes4_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ELOG_ChargeTypes4_Description = ""
         Else
           _ELOG_ChargeTypes4_Description = value
         End If
      End Set
    End Property
    Public Property ELOG_ICDCFSs5_Description() As String
      Get
        Return _ELOG_ICDCFSs5_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ELOG_ICDCFSs5_Description = ""
         Else
           _ELOG_ICDCFSs5_Description = value
         End If
      End Set
    End Property
    Public Property ELOG_IRBL6_SupplierBillNo() As String
      Get
        Return _ELOG_IRBL6_SupplierBillNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ELOG_IRBL6_SupplierBillNo = ""
         Else
           _ELOG_IRBL6_SupplierBillNo = value
         End If
      End Set
    End Property
    Public Property ELOG_StuffingPoints7_Description() As String
      Get
        Return _ELOG_StuffingPoints7_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ELOG_StuffingPoints7_Description = ""
         Else
           _ELOG_StuffingPoints7_Description = value
         End If
      End Set
    End Property
    Public Property ELOG_StuffingTypes8_Description() As String
      Get
        Return _ELOG_StuffingTypes8_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ELOG_StuffingTypes8_Description = ""
         Else
           _ELOG_StuffingTypes8_Description = value
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
        Return _IRNo & "|" & _SerialNo
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
    Public Class PKelogIRBLDetails
      Private _IRNo As Int32 = 0
      Private _SerialNo As Int32 = 0
      Public Property IRNo() As Int32
        Get
          Return _IRNo
        End Get
        Set(ByVal value As Int32)
          _IRNo = value
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
    End Class
    Public ReadOnly Property FK_ELOG_IRBLDetails_BreakbulkID() As SIS.ELOG.elogBreakbulkTypes
      Get
        If _FK_ELOG_IRBLDetails_BreakbulkID Is Nothing Then
          _FK_ELOG_IRBLDetails_BreakbulkID = SIS.ELOG.elogBreakbulkTypes.elogBreakbulkTypesGetByID(_BreakBulkID)
        End If
        Return _FK_ELOG_IRBLDetails_BreakbulkID
      End Get
    End Property
    Public ReadOnly Property FK_ELOG_IRBLDetails_ChargeCategoryID() As SIS.ELOG.elogChargeCategories
      Get
        If _FK_ELOG_IRBLDetails_ChargeCategoryID Is Nothing Then
          _FK_ELOG_IRBLDetails_ChargeCategoryID = SIS.ELOG.elogChargeCategories.elogChargeCategoriesGetByID(_ChargeCategoryID)
        End If
        Return _FK_ELOG_IRBLDetails_ChargeCategoryID
      End Get
    End Property
    Public ReadOnly Property FK_ELOG_IRBLDetails_ChargeCodeID() As SIS.ELOG.elogChargeCodes
      Get
        If _FK_ELOG_IRBLDetails_ChargeCodeID Is Nothing Then
          _FK_ELOG_IRBLDetails_ChargeCodeID = SIS.ELOG.elogChargeCodes.elogChargeCodesGetByID(_ChargeCategoryID, _ChargeCodeID)
        End If
        Return _FK_ELOG_IRBLDetails_ChargeCodeID
      End Get
    End Property
    Public ReadOnly Property FK_ELOG_IRBLDetails_ChargeTypeID() As SIS.ELOG.elogChargeTypes
      Get
        If _FK_ELOG_IRBLDetails_ChargeTypeID Is Nothing Then
          _FK_ELOG_IRBLDetails_ChargeTypeID = SIS.ELOG.elogChargeTypes.elogChargeTypesGetByID(_ChargeTypeID)
        End If
        Return _FK_ELOG_IRBLDetails_ChargeTypeID
      End Get
    End Property
    Public ReadOnly Property FK_ELOG_IRBLDetails_ICDCFSID() As SIS.ELOG.elogICDCFSs
      Get
        If _FK_ELOG_IRBLDetails_ICDCFSID Is Nothing Then
          _FK_ELOG_IRBLDetails_ICDCFSID = SIS.ELOG.elogICDCFSs.elogICDCFSsGetByID(_ICDCFSID)
        End If
        Return _FK_ELOG_IRBLDetails_ICDCFSID
      End Get
    End Property
    Public ReadOnly Property FK_ELOG_IRBLDetails_IRNo() As SIS.ELOG.elogIRBL
      Get
        If _FK_ELOG_IRBLDetails_IRNo Is Nothing Then
          _FK_ELOG_IRBLDetails_IRNo = SIS.ELOG.elogIRBL.elogIRBLGetByID(_IRNo)
        End If
        Return _FK_ELOG_IRBLDetails_IRNo
      End Get
    End Property
    Public ReadOnly Property FK_ELOG_IRBLDetails_StuffingPointID() As SIS.ELOG.elogStuffingPoints
      Get
        If _FK_ELOG_IRBLDetails_StuffingPointID Is Nothing Then
          _FK_ELOG_IRBLDetails_StuffingPointID = SIS.ELOG.elogStuffingPoints.elogStuffingPointsGetByID(_StuffingPointID)
        End If
        Return _FK_ELOG_IRBLDetails_StuffingPointID
      End Get
    End Property
    Public ReadOnly Property FK_ELOG_IRBLDetails_StuffingTypeID() As SIS.ELOG.elogStuffingTypes
      Get
        If _FK_ELOG_IRBLDetails_StuffingTypeID Is Nothing Then
          _FK_ELOG_IRBLDetails_StuffingTypeID = SIS.ELOG.elogStuffingTypes.elogStuffingTypesGetByID(_StuffingTypeID)
        End If
        Return _FK_ELOG_IRBLDetails_StuffingTypeID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function elogIRBLDetailsGetNewRecord() As SIS.ELOG.elogIRBLDetails
      Return New SIS.ELOG.elogIRBLDetails()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function elogIRBLDetailsGetByID(ByVal IRNo As Int32, ByVal SerialNo As Int32) As SIS.ELOG.elogIRBLDetails
      Dim Results As SIS.ELOG.elogIRBLDetails = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogIRBLDetailsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRNo",SqlDbType.Int,IRNo.ToString.Length, IRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ELOG.elogIRBLDetails(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function elogIRBLDetailsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal IRNo As Int32) As List(Of SIS.ELOG.elogIRBLDetails)
      Dim Results As List(Of SIS.ELOG.elogIRBLDetails) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spelogIRBLDetailsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spelogIRBLDetailsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_IRNo",SqlDbType.Int,10, IIf(IRNo = Nothing, 0,IRNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ELOG.elogIRBLDetails)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ELOG.elogIRBLDetails(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function elogIRBLDetailsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal IRNo As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function elogIRBLDetailsGetByID(ByVal IRNo As Int32, ByVal SerialNo As Int32, ByVal Filter_IRNo As Int32) As SIS.ELOG.elogIRBLDetails
      Return elogIRBLDetailsGetByID(IRNo, SerialNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function elogIRBLDetailsInsert(ByVal Record As SIS.ELOG.elogIRBLDetails) As SIS.ELOG.elogIRBLDetails
      Dim _Rec As SIS.ELOG.elogIRBLDetails = SIS.ELOG.elogIRBLDetails.elogIRBLDetailsGetNewRecord()
      With _Rec
        .IRNo = Record.IRNo
        .StuffingTypeID = Record.StuffingTypeID
        .StuffingPointID = Record.StuffingPointID
        .ICDCFSID = Record.ICDCFSID
        .OtherICDCFS = Record.OtherICDCFS
        .BreakBulkID = Record.BreakBulkID
        .ChargeTypeID = Record.ChargeTypeID
        .ChargeCategoryID = Record.ChargeCategoryID
          Record.ChargeCodeID = Record.ChargeCodeID.Split("|".ToCharArray)(1)
        .ChargeCodeID = Record.ChargeCodeID
        .Amount = Record.Amount
        .Remarks = Record.Remarks
      End With
      Return SIS.ELOG.elogIRBLDetails.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.ELOG.elogIRBLDetails) As SIS.ELOG.elogIRBLDetails
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogIRBLDetailsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRNo",SqlDbType.Int,11, Record.IRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StuffingTypeID",SqlDbType.Int,11, Iif(Record.StuffingTypeID= "" ,Convert.DBNull, Record.StuffingTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StuffingPointID",SqlDbType.Int,11, Iif(Record.StuffingPointID= "" ,Convert.DBNull, Record.StuffingPointID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ICDCFSID",SqlDbType.Int,11, Iif(Record.ICDCFSID= "" ,Convert.DBNull, Record.ICDCFSID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OtherICDCFS",SqlDbType.NVarChar,101, Iif(Record.OtherICDCFS= "" ,Convert.DBNull, Record.OtherICDCFS))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BreakBulkID",SqlDbType.Int,11, Iif(Record.BreakBulkID= "" ,Convert.DBNull, Record.BreakBulkID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ChargeTypeID",SqlDbType.Int,11, Iif(Record.ChargeTypeID= "" ,Convert.DBNull, Record.ChargeTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ChargeCategoryID",SqlDbType.Int,11, Iif(Record.ChargeCategoryID= "" ,Convert.DBNull, Record.ChargeCategoryID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ChargeCodeID",SqlDbType.Int,11, Iif(Record.ChargeCodeID= "" ,Convert.DBNull, Record.ChargeCodeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Amount",SqlDbType.Decimal,21, Iif(Record.Amount= "" ,Convert.DBNull, Record.Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,501, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          Cmd.Parameters.Add("@Return_IRNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_IRNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.IRNo = Cmd.Parameters("@Return_IRNo").Value
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function elogIRBLDetailsUpdate(ByVal Record As SIS.ELOG.elogIRBLDetails) As SIS.ELOG.elogIRBLDetails
      Dim _Rec As SIS.ELOG.elogIRBLDetails = SIS.ELOG.elogIRBLDetails.elogIRBLDetailsGetByID(Record.IRNo, Record.SerialNo)
      With _Rec
        .StuffingTypeID = Record.StuffingTypeID
        .StuffingPointID = Record.StuffingPointID
        .ICDCFSID = Record.ICDCFSID
        .OtherICDCFS = Record.OtherICDCFS
        .BreakBulkID = Record.BreakBulkID
        .ChargeTypeID = Record.ChargeTypeID
        .ChargeCategoryID = Record.ChargeCategoryID
        Record.ChargeCodeID = Record.ChargeCodeID.Split("|".ToCharArray)(1)
        .ChargeCodeID = Record.ChargeCodeID
        .Amount = Record.Amount
        .Remarks = Record.Remarks
      End With
      Return SIS.ELOG.elogIRBLDetails.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.ELOG.elogIRBLDetails) As SIS.ELOG.elogIRBLDetails
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogIRBLDetailsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_IRNo",SqlDbType.Int,11, Record.IRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRNo",SqlDbType.Int,11, Record.IRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StuffingTypeID",SqlDbType.Int,11, Iif(Record.StuffingTypeID= "" ,Convert.DBNull, Record.StuffingTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StuffingPointID",SqlDbType.Int,11, Iif(Record.StuffingPointID= "" ,Convert.DBNull, Record.StuffingPointID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ICDCFSID",SqlDbType.Int,11, Iif(Record.ICDCFSID= "" ,Convert.DBNull, Record.ICDCFSID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OtherICDCFS",SqlDbType.NVarChar,101, Iif(Record.OtherICDCFS= "" ,Convert.DBNull, Record.OtherICDCFS))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BreakBulkID",SqlDbType.Int,11, Iif(Record.BreakBulkID= "" ,Convert.DBNull, Record.BreakBulkID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ChargeTypeID",SqlDbType.Int,11, Iif(Record.ChargeTypeID= "" ,Convert.DBNull, Record.ChargeTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ChargeCategoryID",SqlDbType.Int,11, Iif(Record.ChargeCategoryID= "" ,Convert.DBNull, Record.ChargeCategoryID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ChargeCodeID",SqlDbType.Int,11, Iif(Record.ChargeCodeID= "" ,Convert.DBNull, Record.ChargeCodeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Amount",SqlDbType.Decimal,21, Iif(Record.Amount= "" ,Convert.DBNull, Record.Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,501, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
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
    Public Shared Function elogIRBLDetailsDelete(ByVal Record As SIS.ELOG.elogIRBLDetails) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogIRBLDetailsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_IRNo",SqlDbType.Int,Record.IRNo.ToString.Length, Record.IRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,Record.SerialNo.ToString.Length, Record.SerialNo)
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
