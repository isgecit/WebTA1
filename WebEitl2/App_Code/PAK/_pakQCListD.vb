Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakQCListD
    Private Shared _RecordCount As Integer
    Private _SerialNo As Int32 = 0
    Private _TotalWeight As Decimal = 0
    Private _QualityClearedWt As Decimal = 0
    Private _InspectionStageID As String = ""
    Private _QCLNo As Int32 = 0
    Private _BOMNo As Int32 = 0
    Private _ItemNo As Int32 = 0
    Private _UOMQuantity As String = ""
    Private _Quantity As Decimal = 0
    Private _ClearedOn As String = ""
    Private _WeightPerUnit As Decimal = 0
    Private _QualityClearedQty As String = "0.0000"
    Private _UOMWeight As String = ""
    Private _ClearedBy As String = ""
    Private _Remarks As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _PAK_PO2_PODescription As String = ""
    Private _PAK_POBItems3_ItemDescription As String = ""
    Private _PAK_POBOM4_ItemDescription As String = ""
    Private _PAK_QCListH5_SupplierRef As String = ""
    Private _PAK_Units6_Description As String = ""
    Private _PAK_Units7_Description As String = ""
    Private _QCM_InspectionStages8_Description As String = ""
    Private _FK_PAK_QCListD_CreatedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_PAK_QCListD_SerialNo As SIS.PAK.pakPO = Nothing
    Private _FK_PAK_QCListD_ItemNo As SIS.PAK.pakPOBItems = Nothing
    Private _FK_PAK_QCListD_BOMNo As SIS.PAK.pakPOBOM = Nothing
    Private _FK_PAK_QCListD_QCLNo As SIS.PAK.pakQCListH = Nothing
    Private _FK_PAK_QCListD_UOMQuantity As SIS.PAK.pakUnits = Nothing
    Private _FK_PAK_QCListD_UOMWeight As SIS.PAK.pakUnits = Nothing
    Private _FK_PAK_QCListD_InspectionStageID As SIS.QCM.qcmInspectionStages = Nothing
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
    Public Property SerialNo() As Int32
      Get
        Return _SerialNo
      End Get
      Set(ByVal value As Int32)
        _SerialNo = value
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
    Public Property QualityClearedWt() As Decimal
      Get
        Return _QualityClearedWt
      End Get
      Set(ByVal value As Decimal)
        _QualityClearedWt = value
      End Set
    End Property
    Public Property InspectionStageID() As String
      Get
        Return _InspectionStageID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _InspectionStageID = ""
        Else
          _InspectionStageID = value
        End If
      End Set
    End Property
    Public Property QCLNo() As Int32
      Get
        Return _QCLNo
      End Get
      Set(ByVal value As Int32)
        _QCLNo = value
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
    Public Property UOMQuantity() As String
      Get
        Return _UOMQuantity
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
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
    Public Property ClearedOn() As String
      Get
        If Not _ClearedOn = String.Empty Then
          Return Convert.ToDateTime(_ClearedOn).ToString("dd/MM/yyyy")
        End If
        Return _ClearedOn
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ClearedOn = ""
        Else
          _ClearedOn = value
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
    Public Property QualityClearedQty() As String
      Get
        Return _QualityClearedQty
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _QualityClearedQty = "0.0000"
        Else
          _QualityClearedQty = value
        End If
      End Set
    End Property
    Public Property UOMWeight() As String
      Get
        Return _UOMWeight
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _UOMWeight = ""
        Else
          _UOMWeight = value
        End If
      End Set
    End Property
    Public Property ClearedBy() As String
      Get
        Return _ClearedBy
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ClearedBy = ""
        Else
          _ClearedBy = value
        End If
      End Set
    End Property
    Public Property Remarks() As String
      Get
        Return _Remarks
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _Remarks = ""
        Else
          _Remarks = value
        End If
      End Set
    End Property
    Public Property aspnet_Users1_UserFullName() As String
      Get
        Return _aspnet_Users1_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users1_UserFullName = value
      End Set
    End Property
    Public Property PAK_PO2_PODescription() As String
      Get
        Return _PAK_PO2_PODescription
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _PAK_PO2_PODescription = ""
        Else
          _PAK_PO2_PODescription = value
        End If
      End Set
    End Property
    Public Property PAK_POBItems3_ItemDescription() As String
      Get
        Return _PAK_POBItems3_ItemDescription
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _PAK_POBItems3_ItemDescription = ""
        Else
          _PAK_POBItems3_ItemDescription = value
        End If
      End Set
    End Property
    Public Property PAK_POBOM4_ItemDescription() As String
      Get
        Return _PAK_POBOM4_ItemDescription
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _PAK_POBOM4_ItemDescription = ""
        Else
          _PAK_POBOM4_ItemDescription = value
        End If
      End Set
    End Property
    Public Property PAK_QCListH5_SupplierRef() As String
      Get
        Return _PAK_QCListH5_SupplierRef
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _PAK_QCListH5_SupplierRef = ""
        Else
          _PAK_QCListH5_SupplierRef = value
        End If
      End Set
    End Property
    Public Property PAK_Units6_Description() As String
      Get
        Return _PAK_Units6_Description
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
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
        If Convert.IsDBNull(value) Then
          _PAK_Units7_Description = ""
        Else
          _PAK_Units7_Description = value
        End If
      End Set
    End Property
    Public Property QCM_InspectionStages8_Description() As String
      Get
        Return _QCM_InspectionStages8_Description
      End Get
      Set(ByVal value As String)
        _QCM_InspectionStages8_Description = value
      End Set
    End Property
    Public ReadOnly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public ReadOnly Property PrimaryKey() As String
      Get
        Return _SerialNo & "|" & _QCLNo & "|" & _BOMNo & "|" & _ItemNo
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
    Public Class PKpakQCListD
      Private _SerialNo As Int32 = 0
      Private _QCLNo As Int32 = 0
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
      Public Property QCLNo() As Int32
        Get
          Return _QCLNo
        End Get
        Set(ByVal value As Int32)
          _QCLNo = value
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
    Public ReadOnly Property FK_PAK_QCListD_CreatedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_PAK_QCListD_CreatedBy Is Nothing Then
          _FK_PAK_QCListD_CreatedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_ClearedBy)
        End If
        Return _FK_PAK_QCListD_CreatedBy
      End Get
    End Property
    Public ReadOnly Property FK_PAK_QCListD_SerialNo() As SIS.PAK.pakPO
      Get
        If _FK_PAK_QCListD_SerialNo Is Nothing Then
          _FK_PAK_QCListD_SerialNo = SIS.PAK.pakPO.pakPOGetByID(_SerialNo)
        End If
        Return _FK_PAK_QCListD_SerialNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_QCListD_ItemNo() As SIS.PAK.pakPOBItems
      Get
        If _FK_PAK_QCListD_ItemNo Is Nothing Then
          _FK_PAK_QCListD_ItemNo = SIS.PAK.pakPOBItems.pakPOBItemsGetByID(_SerialNo, _BOMNo, _ItemNo)
        End If
        Return _FK_PAK_QCListD_ItemNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_QCListD_BOMNo() As SIS.PAK.pakPOBOM
      Get
        If _FK_PAK_QCListD_BOMNo Is Nothing Then
          _FK_PAK_QCListD_BOMNo = SIS.PAK.pakPOBOM.pakPOBOMGetByID(_SerialNo, _BOMNo)
        End If
        Return _FK_PAK_QCListD_BOMNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_QCListD_QCLNo() As SIS.PAK.pakQCListH
      Get
        If _FK_PAK_QCListD_QCLNo Is Nothing Then
          _FK_PAK_QCListD_QCLNo = SIS.PAK.pakQCListH.pakQCListHGetByID(_SerialNo, _QCLNo)
        End If
        Return _FK_PAK_QCListD_QCLNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_QCListD_UOMQuantity() As SIS.PAK.pakUnits
      Get
        If _FK_PAK_QCListD_UOMQuantity Is Nothing Then
          _FK_PAK_QCListD_UOMQuantity = SIS.PAK.pakUnits.pakUnitsGetByID(_UOMQuantity)
        End If
        Return _FK_PAK_QCListD_UOMQuantity
      End Get
    End Property
    Public ReadOnly Property FK_PAK_QCListD_UOMWeight() As SIS.PAK.pakUnits
      Get
        If _FK_PAK_QCListD_UOMWeight Is Nothing Then
          _FK_PAK_QCListD_UOMWeight = SIS.PAK.pakUnits.pakUnitsGetByID(_UOMWeight)
        End If
        Return _FK_PAK_QCListD_UOMWeight
      End Get
    End Property
    Public ReadOnly Property FK_PAK_QCListD_InspectionStageID() As SIS.QCM.qcmInspectionStages
      Get
        If _FK_PAK_QCListD_InspectionStageID Is Nothing Then
          _FK_PAK_QCListD_InspectionStageID = SIS.QCM.qcmInspectionStages.qcmInspectionStagesGetByID(_InspectionStageID)
        End If
        Return _FK_PAK_QCListD_InspectionStageID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function pakQCListDGetNewRecord() As SIS.PAK.pakQCListD
      Return New SIS.PAK.pakQCListD()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function pakQCListDGetByID(ByVal SerialNo As Int32, ByVal QCLNo As Int32, ByVal BOMNo As Int32, ByVal ItemNo As Int32) As SIS.PAK.pakQCListD
      Dim Results As SIS.PAK.pakQCListD = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakQCListDSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo", SqlDbType.Int, SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QCLNo", SqlDbType.Int, QCLNo.ToString.Length, QCLNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BOMNo", SqlDbType.Int, BOMNo.ToString.Length, BOMNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo", SqlDbType.Int, ItemNo.ToString.Length, ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakQCListD(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function pakQCListDSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal QCLNo As Int32) As List(Of SIS.PAK.pakQCListD)
      Dim Results As List(Of SIS.PAK.pakQCListD) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakQCListDSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakQCListDSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo", SqlDbType.Int, 10, IIf(SerialNo = Nothing, 0, SerialNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_QCLNo", SqlDbType.Int, 10, IIf(QCLNo = Nothing, 0, QCLNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakQCListD)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakQCListD(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakQCListDSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal QCLNo As Int32) As Integer
      Return _RecordCount
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function pakQCListDGetByID(ByVal SerialNo As Int32, ByVal QCLNo As Int32, ByVal BOMNo As Int32, ByVal ItemNo As Int32, ByVal Filter_SerialNo As Int32, ByVal Filter_QCLNo As Int32) As SIS.PAK.pakQCListD
      Return pakQCListDGetByID(SerialNo, QCLNo, BOMNo, ItemNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)>
    Public Shared Function pakQCListDInsert(ByVal Record As SIS.PAK.pakQCListD) As SIS.PAK.pakQCListD
      Dim _Rec As SIS.PAK.pakQCListD = SIS.PAK.pakQCListD.pakQCListDGetNewRecord()
      With _Rec
        .SerialNo = Record.SerialNo
        .TotalWeight = Record.TotalWeight
        .QualityClearedWt = Record.QualityClearedWt
        .InspectionStageID = Record.InspectionStageID
        .QCLNo = Record.QCLNo
        .BOMNo = Record.BOMNo
        .ItemNo = Record.ItemNo
        .UOMQuantity = Record.UOMQuantity
        .Quantity = Record.Quantity
        .ClearedOn = Now
        .WeightPerUnit = Record.WeightPerUnit
        .QualityClearedQty = Record.QualityClearedQty
        .UOMWeight = Record.UOMWeight
        .ClearedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .Remarks = Record.Remarks
      End With
      Return SIS.PAK.pakQCListD.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PAK.pakQCListD) As SIS.PAK.pakQCListD
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakQCListDInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo", SqlDbType.Int, 11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalWeight", SqlDbType.Decimal, 23, Record.TotalWeight)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QualityClearedWt", SqlDbType.Decimal, 23, Record.QualityClearedWt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InspectionStageID", SqlDbType.Int, 11, IIf(Record.InspectionStageID = "", Convert.DBNull, Record.InspectionStageID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QCLNo", SqlDbType.Int, 11, Record.QCLNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BOMNo", SqlDbType.Int, 11, Record.BOMNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo", SqlDbType.Int, 11, Record.ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMQuantity", SqlDbType.Int, 11, IIf(Record.UOMQuantity = "", Convert.DBNull, Record.UOMQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quantity", SqlDbType.Decimal, 23, Record.Quantity)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClearedOn", SqlDbType.DateTime, 21, IIf(Record.ClearedOn = "", Convert.DBNull, Record.ClearedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WeightPerUnit", SqlDbType.Decimal, 23, Record.WeightPerUnit)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QualityClearedQty", SqlDbType.Decimal, 23, IIf(Record.QualityClearedQty = "", Convert.DBNull, Record.QualityClearedQty))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMWeight", SqlDbType.Int, 11, IIf(Record.UOMWeight = "", Convert.DBNull, Record.UOMWeight))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClearedBy", SqlDbType.NVarChar, 9, IIf(Record.ClearedBy = "", Convert.DBNull, Record.ClearedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks", SqlDbType.NVarChar, 501, IIf(Record.Remarks = "", Convert.DBNull, Record.Remarks))
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_QCLNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_QCLNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_BOMNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_BOMNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_ItemNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ItemNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
          Record.QCLNo = Cmd.Parameters("@Return_QCLNo").Value
          Record.BOMNo = Cmd.Parameters("@Return_BOMNo").Value
          Record.ItemNo = Cmd.Parameters("@Return_ItemNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)>
    Public Shared Function pakQCListDUpdate(ByVal Record As SIS.PAK.pakQCListD) As SIS.PAK.pakQCListD
      Dim _Rec As SIS.PAK.pakQCListD = SIS.PAK.pakQCListD.pakQCListDGetByID(Record.SerialNo, Record.QCLNo, Record.BOMNo, Record.ItemNo)
      With _Rec
        .TotalWeight = Record.TotalWeight
        .QualityClearedWt = Record.QualityClearedWt
        .InspectionStageID = Record.InspectionStageID
        .UOMQuantity = Record.UOMQuantity
        .Quantity = Record.Quantity
        .ClearedOn = Now
        .WeightPerUnit = Record.WeightPerUnit
        .QualityClearedQty = Record.QualityClearedQty
        .UOMWeight = Record.UOMWeight
        .ClearedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .Remarks = Record.Remarks
      End With
      Return SIS.PAK.pakQCListD.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PAK.pakQCListD) As SIS.PAK.pakQCListD
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakQCListDUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo", SqlDbType.Int, 11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_QCLNo", SqlDbType.Int, 11, Record.QCLNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_BOMNo", SqlDbType.Int, 11, Record.BOMNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ItemNo", SqlDbType.Int, 11, Record.ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo", SqlDbType.Int, 11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalWeight", SqlDbType.Decimal, 23, Record.TotalWeight)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QualityClearedWt", SqlDbType.Decimal, 23, Record.QualityClearedWt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InspectionStageID", SqlDbType.Int, 11, IIf(Record.InspectionStageID = "", Convert.DBNull, Record.InspectionStageID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QCLNo", SqlDbType.Int, 11, Record.QCLNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BOMNo", SqlDbType.Int, 11, Record.BOMNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo", SqlDbType.Int, 11, Record.ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMQuantity", SqlDbType.Int, 11, IIf(Record.UOMQuantity = "", Convert.DBNull, Record.UOMQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quantity", SqlDbType.Decimal, 23, Record.Quantity)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClearedOn", SqlDbType.DateTime, 21, IIf(Record.ClearedOn = "", Convert.DBNull, Record.ClearedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WeightPerUnit", SqlDbType.Decimal, 23, Record.WeightPerUnit)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QualityClearedQty", SqlDbType.Decimal, 23, IIf(Record.QualityClearedQty = "", Convert.DBNull, Record.QualityClearedQty))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMWeight", SqlDbType.Int, 11, IIf(Record.UOMWeight = "", Convert.DBNull, Record.UOMWeight))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClearedBy", SqlDbType.NVarChar, 9, IIf(Record.ClearedBy = "", Convert.DBNull, Record.ClearedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks", SqlDbType.NVarChar, 501, IIf(Record.Remarks = "", Convert.DBNull, Record.Remarks))
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
    <DataObjectMethod(DataObjectMethodType.Delete, True)>
    Public Shared Function pakQCListDDelete(ByVal Record As SIS.PAK.pakQCListD) As Int32
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakQCListDDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo", SqlDbType.Int, Record.SerialNo.ToString.Length, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_QCLNo", SqlDbType.Int, Record.QCLNo.ToString.Length, Record.QCLNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_BOMNo", SqlDbType.Int, Record.BOMNo.ToString.Length, Record.BOMNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ItemNo", SqlDbType.Int, Record.ItemNo.ToString.Length, Record.ItemNo)
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
