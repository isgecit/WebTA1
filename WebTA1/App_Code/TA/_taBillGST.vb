Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taBillGST
    Private Shared _RecordCount As Integer
    Private _TABillNo As Int32 = 0
    Private _SerialNo As Int32 = 0
    Private _IsgecGSTIN As String = ""
    Private _BillNumber As String = ""
    Private _BillDate As String = ""
    Private _BPID As String = ""
    Private _SupplierGSTIN As String = ""
    Private _SupplierGSTINNo As String = ""
    Private _StateID As String = ""
    Private _BillType As String = ""
    Private _HSNSACCode As String = ""
    Private _AssessableValue As String = "0.00"
    Private _IGSTRate As String = "0.00"
    Private _IGSTAmount As String = "0.00"
    Private _SGSTRate As String = "0.00"
    Private _SGSTAmount As String = "0.00"
    Private _CGSTRate As String = "0.00"
    Private _CGSTAmount As String = "0.00"
    Private _CessRate As String = "0.00"
    Private _CessAmount As String = "0.00"
    Private _TotalGST As String = "0.00"
    Private _TotalAmount As String = "0.00"
    Private _SPMT_BillTypes1_Description As String = ""
    Private _SPMT_ERPStates2_Description As String = ""
    Private _SPMT_HSNSACCodes3_HSNSACCode As String = ""
    Private _SPMT_IsgecGSTIN4_Description As String = ""
    Private _TA_Bills6_PurposeOfJourney As String = ""
    Private _VR_BPGSTIN7_Description As String = ""
    Private _VR_BusinessPartner8_BPName As String = ""
    Private _FK_TA_BillGST_BillType As SIS.SPMT.spmtBillTypes = Nothing
    Private _FK_TA_BillGST_StateID As SIS.SPMT.spmtERPStates = Nothing
    Private _FK_TA_BillGST_HSNSACCode As SIS.SPMT.spmtHSNSACCodes = Nothing
    Private _FK_TA_BillGST_IsgecGSTIN As SIS.SPMT.spmtIsgecGSTIN = Nothing
    Private _FK_TA_BillGST_SerialNo As SIS.TA.taBillDetails = Nothing
    Private _FK_TA_BillGST_TABillNo As SIS.TA.taBH = Nothing
    Private _FK_TA_BillGST_SupplierGSTIN As SIS.SPMT.spmtBPGSTIN = Nothing
    Private _FK_TA_BillGST_BPID As SIS.SPMT.spmtBusinessPartner = Nothing
    Public Property PurchaseType As String = ""
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
    <SYS.Utilities.lgSkip()>
    Public Property TABillNo() As Int32
      Get
        Return _TABillNo
      End Get
      Set(ByVal value As Int32)
        _TABillNo = value
      End Set
    End Property
    <SYS.Utilities.lgSkip()>
    Public Property SerialNo() As Int32
      Get
        Return _SerialNo
      End Get
      Set(ByVal value As Int32)
        _SerialNo = value
      End Set
    End Property
    Public Property IsgecGSTIN() As String
      Get
        Return _IsgecGSTIN
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _IsgecGSTIN = ""
         Else
           _IsgecGSTIN = value
         End If
      End Set
    End Property
    Public Property BillNumber() As String
      Get
        Return _BillNumber
      End Get
      Set(ByVal value As String)
        _BillNumber = value
      End Set
    End Property
    Public Property BillDate() As String
      Get
        If Not _BillDate = String.Empty Then
          Return Convert.ToDateTime(_BillDate).ToString("dd/MM/yyyy")
        End If
        Return _BillDate
      End Get
      Set(ByVal value As String)
         _BillDate = value
      End Set
    End Property
    Public Property BPID() As String
      Get
        Return _BPID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _BPID = ""
         Else
           _BPID = value
         End If
      End Set
    End Property
    Public Property SupplierGSTIN() As String
      Get
        Return _SupplierGSTIN
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SupplierGSTIN = ""
         Else
           _SupplierGSTIN = value
         End If
      End Set
    End Property
    Public Property SupplierGSTINNo() As String
      Get
        Return _SupplierGSTINNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SupplierGSTINNo = ""
         Else
           _SupplierGSTINNo = value
         End If
      End Set
    End Property
    Public Property StateID() As String
      Get
        Return _StateID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _StateID = ""
         Else
           _StateID = value
         End If
      End Set
    End Property
    Public Property BillType() As String
      Get
        Return _BillType
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _BillType = ""
         Else
           _BillType = value
         End If
      End Set
    End Property
    Public Property HSNSACCode() As String
      Get
        Return _HSNSACCode
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _HSNSACCode = ""
         Else
           _HSNSACCode = value
         End If
      End Set
    End Property
    Public Property AssessableValue() As String
      Get
        Return _AssessableValue
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AssessableValue = "0.00"
         Else
           _AssessableValue = value
         End If
      End Set
    End Property
    Public Property IGSTRate() As String
      Get
        Return _IGSTRate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _IGSTRate = "0.00"
         Else
           _IGSTRate = value
         End If
      End Set
    End Property
    Public Property IGSTAmount() As String
      Get
        Return _IGSTAmount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _IGSTAmount = "0.00"
         Else
           _IGSTAmount = value
         End If
      End Set
    End Property
    Public Property SGSTRate() As String
      Get
        Return _SGSTRate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SGSTRate = "0.00"
         Else
           _SGSTRate = value
         End If
      End Set
    End Property
    Public Property SGSTAmount() As String
      Get
        Return _SGSTAmount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SGSTAmount = "0.00"
         Else
           _SGSTAmount = value
         End If
      End Set
    End Property
    Public Property CGSTRate() As String
      Get
        Return _CGSTRate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CGSTRate = "0.00"
         Else
           _CGSTRate = value
         End If
      End Set
    End Property
    Public Property CGSTAmount() As String
      Get
        Return _CGSTAmount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CGSTAmount = "0.00"
         Else
           _CGSTAmount = value
         End If
      End Set
    End Property
    Public Property CessRate() As String
      Get
        Return _CessRate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CessRate = "0.00"
         Else
           _CessRate = value
         End If
      End Set
    End Property
    Public Property CessAmount() As String
      Get
        Return _CessAmount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CessAmount = "0.00"
         Else
           _CessAmount = value
         End If
      End Set
    End Property
    Public Property TotalGST() As String
      Get
        Return _TotalGST
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TotalGST = "0.00"
         Else
           _TotalGST = value
         End If
      End Set
    End Property
    Public Property TotalAmount() As String
      Get
        Return _TotalAmount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TotalAmount = "0.00"
         Else
           _TotalAmount = value
         End If
      End Set
    End Property
    Public Property SPMT_BillTypes1_Description() As String
      Get
        Return _SPMT_BillTypes1_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SPMT_BillTypes1_Description = ""
         Else
           _SPMT_BillTypes1_Description = value
         End If
      End Set
    End Property
    Public Property SPMT_ERPStates2_Description() As String
      Get
        Return _SPMT_ERPStates2_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SPMT_ERPStates2_Description = ""
         Else
           _SPMT_ERPStates2_Description = value
         End If
      End Set
    End Property
    Public Property SPMT_HSNSACCodes3_HSNSACCode() As String
      Get
        Return _SPMT_HSNSACCodes3_HSNSACCode
      End Get
      Set(ByVal value As String)
        _SPMT_HSNSACCodes3_HSNSACCode = value
      End Set
    End Property
    Public Property SPMT_IsgecGSTIN4_Description() As String
      Get
        Return _SPMT_IsgecGSTIN4_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SPMT_IsgecGSTIN4_Description = ""
         Else
           _SPMT_IsgecGSTIN4_Description = value
         End If
      End Set
    End Property
    Public Property TA_Bills6_PurposeOfJourney() As String
      Get
        Return _TA_Bills6_PurposeOfJourney
      End Get
      Set(ByVal value As String)
        _TA_Bills6_PurposeOfJourney = value
      End Set
    End Property
    Public Property VR_BPGSTIN7_Description() As String
      Get
        Return _VR_BPGSTIN7_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VR_BPGSTIN7_Description = ""
         Else
           _VR_BPGSTIN7_Description = value
         End If
      End Set
    End Property
    Public Property VR_BusinessPartner8_BPName() As String
      Get
        Return _VR_BusinessPartner8_BPName
      End Get
      Set(ByVal value As String)
        _VR_BusinessPartner8_BPName = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _IsgecGSTIN.ToString.PadRight(10, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _TABillNo & "|" & _SerialNo
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
    Public Class PKtaBillGST
      Private _TABillNo As Int32 = 0
      Private _SerialNo As Int32 = 0
      Public Property TABillNo() As Int32
        Get
          Return _TABillNo
        End Get
        Set(ByVal value As Int32)
          _TABillNo = value
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
    Public ReadOnly Property FK_TA_BillGST_BillType() As SIS.SPMT.spmtBillTypes
      Get
        If _FK_TA_BillGST_BillType Is Nothing Then
          Try
            _FK_TA_BillGST_BillType = SIS.SPMT.spmtBillTypes.spmtBillTypesGetByID(_BillType)
          Catch ex As Exception
          End Try
        End If
        Return _FK_TA_BillGST_BillType
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillGST_StateID() As SIS.SPMT.spmtERPStates
      Get
        If _FK_TA_BillGST_StateID Is Nothing Then
          _FK_TA_BillGST_StateID = SIS.SPMT.spmtERPStates.spmtERPStatesGetByID(_StateID)
        End If
        Return _FK_TA_BillGST_StateID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillGST_HSNSACCode() As SIS.SPMT.spmtHSNSACCodes
      Get
        If _FK_TA_BillGST_HSNSACCode Is Nothing Then
          Try
            _FK_TA_BillGST_HSNSACCode = SIS.SPMT.spmtHSNSACCodes.spmtHSNSACCodesGetByID(_BillType, _HSNSACCode)
          Catch ex As Exception
          End Try
        End If
        Return _FK_TA_BillGST_HSNSACCode
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillGST_IsgecGSTIN() As SIS.SPMT.spmtIsgecGSTIN
      Get
        If _FK_TA_BillGST_IsgecGSTIN Is Nothing Then
          Try
            _FK_TA_BillGST_IsgecGSTIN = SIS.SPMT.spmtIsgecGSTIN.spmtIsgecGSTINGetByID(_IsgecGSTIN)
          Catch ex As Exception
          End Try
        End If
        Return _FK_TA_BillGST_IsgecGSTIN
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillGST_SerialNo() As SIS.TA.taBillDetails
      Get
        If _FK_TA_BillGST_SerialNo Is Nothing Then
          _FK_TA_BillGST_SerialNo = SIS.TA.taBillDetails.taBillDetailsGetByID(_TABillNo, _SerialNo)
        End If
        Return _FK_TA_BillGST_SerialNo
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillGST_TABillNo() As SIS.TA.taBH
      Get
        If _FK_TA_BillGST_TABillNo Is Nothing Then
          _FK_TA_BillGST_TABillNo = SIS.TA.taBH.taBHGetByID(_TABillNo)
        End If
        Return _FK_TA_BillGST_TABillNo
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillGST_SupplierGSTIN() As SIS.SPMT.spmtBPGSTIN
      Get
        If _FK_TA_BillGST_SupplierGSTIN Is Nothing Then
          _FK_TA_BillGST_SupplierGSTIN = SIS.SPMT.spmtBPGSTIN.spmtBPGSTINGetByID(_BPID, _SupplierGSTIN)
        End If
        Return _FK_TA_BillGST_SupplierGSTIN
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillGST_BPID() As SIS.SPMT.spmtBusinessPartner
      Get
        If _FK_TA_BillGST_BPID Is Nothing Then
          _FK_TA_BillGST_BPID = SIS.SPMT.spmtBusinessPartner.spmtBusinessPartnerGetByID(_BPID)
        End If
        Return _FK_TA_BillGST_BPID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBillGSTSelectList(ByVal OrderBy As String) As List(Of SIS.TA.taBillGST)
      Dim Results As List(Of SIS.TA.taBillGST) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBillGSTSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taBillGST)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBillGST(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBillGSTGetNewRecord() As SIS.TA.taBillGST
      Return New SIS.TA.taBillGST()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBillGSTGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32) As SIS.TA.taBillGST
      Dim Results As SIS.TA.taBillGST = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBillGSTSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TABillNo",SqlDbType.Int,TABillNo.ToString.Length, TABillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TA.taBillGST(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBillGSTSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.TA.taBillGST)
      Dim Results As List(Of SIS.TA.taBillGST) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaBillGSTSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaBillGSTSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taBillGST)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBillGST(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taBillGSTSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function taBillGSTInsert(ByVal Record As SIS.TA.taBillGST) As SIS.TA.taBillGST
      Dim _Rec As SIS.TA.taBillGST = SIS.TA.taBillGST.taBillGSTGetNewRecord()
      With _Rec
        .TABillNo = Record.TABillNo
        .SerialNo = Record.SerialNo
        .PurchaseType = Record.PurchaseType
        .IsgecGSTIN = Record.IsgecGSTIN
        .BillNumber = Record.BillNumber
        .BillDate = Record.BillDate
        .BPID = Record.BPID
        .SupplierGSTIN = Record.SupplierGSTIN
        .SupplierGSTINNo = Record.SupplierGSTINNo
        .StateID = Record.StateID
        .BillType = 2
        .HSNSACCode = "996311"   'Record.HSNSACCode
        .AssessableValue = Record.AssessableValue
        .IGSTRate = Record.IGSTRate
        If Convert.ToDecimal(.IGSTRate) > 0 Then
          .IGSTAmount = (Convert.ToDecimal(.AssessableValue) * Convert.ToDecimal(.IGSTRate)) / 100
        Else
          .IGSTAmount = Record.IGSTAmount
        End If
        .SGSTRate = Record.SGSTRate
        If Convert.ToDecimal(.SGSTRate) > 0 Then
          .SGSTAmount = (Convert.ToDecimal(.AssessableValue) * Convert.ToDecimal(.SGSTRate)) / 100
        Else
          .SGSTAmount = Record.SGSTAmount
        End If
        .CGSTRate = Record.CGSTRate
        If Convert.ToDecimal(.CGSTRate) > 0 Then
          .CGSTAmount = (Convert.ToDecimal(.AssessableValue) * Convert.ToDecimal(.CGSTRate)) / 100
        Else
          .CGSTAmount = Record.CGSTAmount
        End If
        .CessRate = Record.CessRate
        If Convert.ToDecimal(.CessRate) > 0 Then
          .CessAmount = (Convert.ToDecimal(.AssessableValue) * Convert.ToDecimal(.CessRate)) / 100
        Else
          .CessAmount = Record.CessAmount
        End If
        .TotalGST = .IGSTAmount + .SGSTAmount + .CGSTAmount
        .TotalAmount = .TotalGST + .AssessableValue
      End With
      Return SIS.TA.taBillGST.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.TA.taBillGST) As SIS.TA.taBillGST
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBillGSTInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TABillNo",SqlDbType.Int,11, Record.TABillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsgecGSTIN",SqlDbType.Int,11, Iif(Record.IsgecGSTIN= "" ,Convert.DBNull, Record.IsgecGSTIN))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillNumber",SqlDbType.NVarChar,51, Record.BillNumber)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillDate",SqlDbType.DateTime,21, Record.BillDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BPID",SqlDbType.NVarChar,10, Iif(Record.BPID= "" ,Convert.DBNull, Record.BPID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierGSTIN",SqlDbType.Int,11, Iif(Record.SupplierGSTIN= "" ,Convert.DBNull, Record.SupplierGSTIN))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierGSTINNo",SqlDbType.NVarChar,51, Iif(Record.SupplierGSTINNo= "" ,Convert.DBNull, Record.SupplierGSTINNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StateID",SqlDbType.NVarChar,3, Iif(Record.StateID= "" ,Convert.DBNull, Record.StateID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillType",SqlDbType.Int,11, Iif(Record.BillType= "" ,Convert.DBNull, Record.BillType))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HSNSACCode",SqlDbType.NVarChar,21, Iif(Record.HSNSACCode= "" ,Convert.DBNull, Record.HSNSACCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AssessableValue",SqlDbType.Decimal,21, Iif(Record.AssessableValue= "" ,Convert.DBNull, Record.AssessableValue))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IGSTRate",SqlDbType.Decimal,21, Iif(Record.IGSTRate= "" ,Convert.DBNull, Record.IGSTRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IGSTAmount",SqlDbType.Decimal,21, Iif(Record.IGSTAmount= "" ,Convert.DBNull, Record.IGSTAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SGSTRate",SqlDbType.Decimal,21, Iif(Record.SGSTRate= "" ,Convert.DBNull, Record.SGSTRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SGSTAmount",SqlDbType.Decimal,21, Iif(Record.SGSTAmount= "" ,Convert.DBNull, Record.SGSTAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CGSTRate",SqlDbType.Decimal,21, Iif(Record.CGSTRate= "" ,Convert.DBNull, Record.CGSTRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CGSTAmount",SqlDbType.Decimal,21, Iif(Record.CGSTAmount= "" ,Convert.DBNull, Record.CGSTAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CessRate",SqlDbType.Decimal,21, Iif(Record.CessRate= "" ,Convert.DBNull, Record.CessRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CessAmount",SqlDbType.Decimal,21, Iif(Record.CessAmount= "" ,Convert.DBNull, Record.CessAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalGST",SqlDbType.Decimal,21, Iif(Record.TotalGST= "" ,Convert.DBNull, Record.TotalGST))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalAmount",SqlDbType.Decimal,21, Iif(Record.TotalAmount= "" ,Convert.DBNull, Record.TotalAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PurchaseType", SqlDbType.NVarChar, 51, IIf(Record.PurchaseType = "", Convert.DBNull, Record.PurchaseType))
          Cmd.Parameters.Add("@Return_TABillNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_TABillNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.TABillNo = Cmd.Parameters("@Return_TABillNo").Value
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taBillGSTUpdate(ByVal Record As SIS.TA.taBillGST) As SIS.TA.taBillGST
      Dim _Rec As SIS.TA.taBillGST = SIS.TA.taBillGST.taBillGSTGetByID(Record.TABillNo, Record.SerialNo)
      With _Rec
        .PurchaseType = Record.PurchaseType
        .IsgecGSTIN = Record.IsgecGSTIN
        .BillNumber = Record.BillNumber
        .BillDate = Record.BillDate
        .BPID = Record.BPID
        .SupplierGSTIN = Record.SupplierGSTIN
        .SupplierGSTINNo = Record.SupplierGSTINNo
        .StateID = Record.StateID
        .BillType = 2 'Record.BillType
        .HSNSACCode = "996311"  'Record.HSNSACCode
        .AssessableValue = Record.AssessableValue
        .IGSTRate = Record.IGSTRate
        If Convert.ToDecimal(.IGSTRate) > 0 Then
          .IGSTAmount = (Convert.ToDecimal(.AssessableValue) * Convert.ToDecimal(.IGSTRate)) / 100
        Else
          .IGSTAmount = Record.IGSTAmount
        End If
        .SGSTRate = Record.SGSTRate
        If Convert.ToDecimal(.SGSTRate) > 0 Then
          .SGSTAmount = (Convert.ToDecimal(.AssessableValue) * Convert.ToDecimal(.SGSTRate)) / 100
        Else
          .SGSTAmount = Record.SGSTAmount
        End If
        .CGSTRate = Record.CGSTRate
        If Convert.ToDecimal(.CGSTRate) > 0 Then
          .CGSTAmount = (Convert.ToDecimal(.AssessableValue) * Convert.ToDecimal(.CGSTRate)) / 100
        Else
          .CGSTAmount = Record.CGSTAmount
        End If
        .CessRate = Record.CessRate
        If Convert.ToDecimal(.CessRate) > 0 Then
          .CessAmount = (Convert.ToDecimal(.AssessableValue) * Convert.ToDecimal(.CessRate)) / 100
        Else
          .CessAmount = Record.CessAmount
        End If
        .TotalGST = .IGSTAmount + .SGSTAmount + .CGSTAmount
        .TotalAmount = .TotalGST + .AssessableValue
      End With
      Return SIS.TA.taBillGST.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.TA.taBillGST) As SIS.TA.taBillGST
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBillGSTUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TABillNo",SqlDbType.Int,11, Record.TABillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TABillNo",SqlDbType.Int,11, Record.TABillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsgecGSTIN",SqlDbType.Int,11, Iif(Record.IsgecGSTIN= "" ,Convert.DBNull, Record.IsgecGSTIN))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillNumber",SqlDbType.NVarChar,51, Record.BillNumber)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillDate",SqlDbType.DateTime,21, Record.BillDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BPID",SqlDbType.NVarChar,10, Iif(Record.BPID= "" ,Convert.DBNull, Record.BPID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierGSTIN",SqlDbType.Int,11, Iif(Record.SupplierGSTIN= "" ,Convert.DBNull, Record.SupplierGSTIN))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierGSTINNo",SqlDbType.NVarChar,51, Iif(Record.SupplierGSTINNo= "" ,Convert.DBNull, Record.SupplierGSTINNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StateID",SqlDbType.NVarChar,3, Iif(Record.StateID= "" ,Convert.DBNull, Record.StateID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillType",SqlDbType.Int,11, Iif(Record.BillType= "" ,Convert.DBNull, Record.BillType))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HSNSACCode",SqlDbType.NVarChar,21, Iif(Record.HSNSACCode= "" ,Convert.DBNull, Record.HSNSACCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AssessableValue",SqlDbType.Decimal,21, Iif(Record.AssessableValue= "" ,Convert.DBNull, Record.AssessableValue))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IGSTRate",SqlDbType.Decimal,21, Iif(Record.IGSTRate= "" ,Convert.DBNull, Record.IGSTRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IGSTAmount",SqlDbType.Decimal,21, Iif(Record.IGSTAmount= "" ,Convert.DBNull, Record.IGSTAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SGSTRate",SqlDbType.Decimal,21, Iif(Record.SGSTRate= "" ,Convert.DBNull, Record.SGSTRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SGSTAmount",SqlDbType.Decimal,21, Iif(Record.SGSTAmount= "" ,Convert.DBNull, Record.SGSTAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CGSTRate",SqlDbType.Decimal,21, Iif(Record.CGSTRate= "" ,Convert.DBNull, Record.CGSTRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CGSTAmount",SqlDbType.Decimal,21, Iif(Record.CGSTAmount= "" ,Convert.DBNull, Record.CGSTAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CessRate",SqlDbType.Decimal,21, Iif(Record.CessRate= "" ,Convert.DBNull, Record.CessRate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CessAmount",SqlDbType.Decimal,21, Iif(Record.CessAmount= "" ,Convert.DBNull, Record.CessAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalGST",SqlDbType.Decimal,21, Iif(Record.TotalGST= "" ,Convert.DBNull, Record.TotalGST))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalAmount",SqlDbType.Decimal,21, Iif(Record.TotalAmount= "" ,Convert.DBNull, Record.TotalAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PurchaseType", SqlDbType.NVarChar, 51, IIf(Record.PurchaseType = "", Convert.DBNull, Record.PurchaseType))
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
    Public Shared Function taBillGSTDelete(ByVal Record As SIS.TA.taBillGST) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBillGSTDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TABillNo",SqlDbType.Int,Record.TABillNo.ToString.Length, Record.TABillNo)
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
'    Autocomplete Method
    Public Shared Function SelecttaBillGSTAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBillGSTAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(10, " "),"" & "|" & ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.TA.taBillGST = New SIS.TA.taBillGST(Reader)
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
