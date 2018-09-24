Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.EITL
  <DataObject()> _
  Partial Public Class eitlPOItemList
    Private Shared _RecordCount As Integer
    Private _SerialNo As Int32 = 0
    Private _ItemLineNo As Int32 = 0
    Private _ItemCode As String = ""
    Private _Description As String = ""
    Private _UOM As String = ""
    Private _Quantity As String = ""
    Private _WeightInKG As String = ""
    Private _DocumentLineNo As String = ""
    Private _ReadyToDespatch As Boolean = False
    Private _Despatched As Boolean = False
    Private _VR_ExecutionNo As String = ""
    Private _DespatchDate As String = ""
    Private _QuantityReceipt As String = ""
    Private _WeightInKGReceipt As String = ""
    Private _MaterialStateID As String = ""
    Private _ReceivedBy As String = ""
    Private _ReceivedOn As String = ""
    Private _ItemStatusID As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _EITL_MaterialState2_Description As String = ""
    Private _EITL_PODocumentList3_DocumentID As String = ""
    Private _EITL_POItemStatus4_Description As String = ""
    Private _EITL_POList5_PONumber As String = ""
    Private _EITL_Units6_Description As String = ""
    Private _FK_EITL_POItemList_ReceivedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_EITL_POItemList_MaterialStateID As SIS.EITL.eitlMaterialState = Nothing
    Private _FK_EITL_POItemList_DocumentLineNo As SIS.EITL.eitlPODocumentList = Nothing
    Private _FK_EITL_POItemList_ItemStatusID As SIS.EITL.eitlPOItemStatus = Nothing
    Private _FK_EITL_POItemList_SerialNo As SIS.EITL.eitlPOList = Nothing
    Private _FK_EITL_POItemList_UOM As SIS.EITL.eitlUnits = Nothing
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
    Public Property ItemLineNo() As Int32
      Get
        Return _ItemLineNo
      End Get
      Set(ByVal value As Int32)
        _ItemLineNo = value
      End Set
    End Property
    Public Property ItemCode() As String
      Get
        Return _ItemCode
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ItemCode = ""
				 Else
					 _ItemCode = value
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
    Public Property UOM() As String
      Get
        Return _UOM
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _UOM = ""
				 Else
					 _UOM = value
			   End If
      End Set
    End Property
    Public Property Quantity() As String
      Get
        Return _Quantity
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Quantity = ""
				 Else
					 _Quantity = value
			   End If
      End Set
    End Property
    Public Property WeightInKG() As String
      Get
        Return _WeightInKG
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _WeightInKG = ""
				 Else
					 _WeightInKG = value
			   End If
      End Set
    End Property
    Public Property DocumentLineNo() As String
      Get
        Return _DocumentLineNo
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _DocumentLineNo = ""
				 Else
					 _DocumentLineNo = value
			   End If
      End Set
    End Property
    Public Property ReadyToDespatch() As Boolean
      Get
        Return _ReadyToDespatch
      End Get
      Set(ByVal value As Boolean)
        _ReadyToDespatch = value
      End Set
    End Property
    Public Property Despatched() As Boolean
      Get
        Return _Despatched
      End Get
      Set(ByVal value As Boolean)
        _Despatched = value
      End Set
    End Property
    Public Property VR_ExecutionNo() As String
      Get
        Return _VR_ExecutionNo
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _VR_ExecutionNo = ""
				 Else
					 _VR_ExecutionNo = value
			   End If
      End Set
    End Property
    Public Property DespatchDate() As String
      Get
        If Not _DespatchDate = String.Empty Then
          Return Convert.ToDateTime(_DespatchDate).ToString("dd/MM/yyyy")
        End If
        Return _DespatchDate
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _DespatchDate = ""
				 Else
					 _DespatchDate = value
			   End If
      End Set
    End Property
    Public Property QuantityReceipt() As String
      Get
        Return _QuantityReceipt
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _QuantityReceipt = ""
				 Else
					 _QuantityReceipt = value
			   End If
      End Set
    End Property
    Public Property WeightInKGReceipt() As String
      Get
        Return _WeightInKGReceipt
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _WeightInKGReceipt = ""
				 Else
					 _WeightInKGReceipt = value
			   End If
      End Set
    End Property
    Public Property MaterialStateID() As String
      Get
        Return _MaterialStateID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _MaterialStateID = ""
				 Else
					 _MaterialStateID = value
			   End If
      End Set
    End Property
    Public Property ReceivedBy() As String
      Get
        Return _ReceivedBy
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ReceivedBy = ""
				 Else
					 _ReceivedBy = value
			   End If
      End Set
    End Property
    Public Property ReceivedOn() As String
      Get
        If Not _ReceivedOn = String.Empty Then
          Return Convert.ToDateTime(_ReceivedOn).ToString("dd/MM/yyyy")
        End If
        Return _ReceivedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ReceivedOn = ""
				 Else
					 _ReceivedOn = value
			   End If
      End Set
    End Property
    Public Property ItemStatusID() As String
      Get
        Return _ItemStatusID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ItemStatusID = ""
				 Else
					 _ItemStatusID = value
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
    Public Property EITL_MaterialState2_Description() As String
      Get
        Return _EITL_MaterialState2_Description
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _EITL_MaterialState2_Description = ""
				 Else
					 _EITL_MaterialState2_Description = value
			   End If
      End Set
    End Property
    Public Property EITL_PODocumentList3_DocumentID() As String
      Get
        Return _EITL_PODocumentList3_DocumentID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _EITL_PODocumentList3_DocumentID = ""
				 Else
					 _EITL_PODocumentList3_DocumentID = value
			   End If
      End Set
    End Property
    Public Property EITL_POItemStatus4_Description() As String
      Get
        Return _EITL_POItemStatus4_Description
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _EITL_POItemStatus4_Description = ""
				 Else
					 _EITL_POItemStatus4_Description = value
			   End If
      End Set
    End Property
    Public Property EITL_POList5_PONumber() As String
      Get
        Return _EITL_POList5_PONumber
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _EITL_POList5_PONumber = ""
				 Else
					 _EITL_POList5_PONumber = value
			   End If
      End Set
    End Property
    Public Property EITL_Units6_Description() As String
      Get
        Return _EITL_Units6_Description
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _EITL_Units6_Description = ""
				 Else
					 _EITL_Units6_Description = value
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
        Return _SerialNo & "|" & _ItemLineNo
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
    Public Class PKeitlPOItemList
			Private _SerialNo As Int32 = 0
			Private _ItemLineNo As Int32 = 0
			Public Property SerialNo() As Int32
				Get
					Return _SerialNo
				End Get
				Set(ByVal value As Int32)
					_SerialNo = value
				End Set
			End Property
			Public Property ItemLineNo() As Int32
				Get
					Return _ItemLineNo
				End Get
				Set(ByVal value As Int32)
					_ItemLineNo = value
				End Set
			End Property
    End Class
    Public ReadOnly Property FK_EITL_POItemList_ReceivedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_EITL_POItemList_ReceivedBy Is Nothing Then
          _FK_EITL_POItemList_ReceivedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_ReceivedBy)
        End If
        Return _FK_EITL_POItemList_ReceivedBy
      End Get
    End Property
    Public ReadOnly Property FK_EITL_POItemList_MaterialStateID() As SIS.EITL.eitlMaterialState
      Get
        If _FK_EITL_POItemList_MaterialStateID Is Nothing Then
          _FK_EITL_POItemList_MaterialStateID = SIS.EITL.eitlMaterialState.eitlMaterialStateGetByID(_MaterialStateID)
        End If
        Return _FK_EITL_POItemList_MaterialStateID
      End Get
    End Property
    Public ReadOnly Property FK_EITL_POItemList_DocumentLineNo() As SIS.EITL.eitlPODocumentList
      Get
        If _FK_EITL_POItemList_DocumentLineNo Is Nothing Then
          _FK_EITL_POItemList_DocumentLineNo = SIS.EITL.eitlPODocumentList.eitlPODocumentListGetByID(_SerialNo, _DocumentLineNo)
        End If
        Return _FK_EITL_POItemList_DocumentLineNo
      End Get
    End Property
    Public ReadOnly Property FK_EITL_POItemList_ItemStatusID() As SIS.EITL.eitlPOItemStatus
      Get
        If _FK_EITL_POItemList_ItemStatusID Is Nothing Then
          _FK_EITL_POItemList_ItemStatusID = SIS.EITL.eitlPOItemStatus.eitlPOItemStatusGetByID(_ItemStatusID)
        End If
        Return _FK_EITL_POItemList_ItemStatusID
      End Get
    End Property
    Public ReadOnly Property FK_EITL_POItemList_SerialNo() As SIS.EITL.eitlPOList
      Get
        If _FK_EITL_POItemList_SerialNo Is Nothing Then
          _FK_EITL_POItemList_SerialNo = SIS.EITL.eitlPOList.eitlPOListGetByID(_SerialNo)
        End If
        Return _FK_EITL_POItemList_SerialNo
      End Get
    End Property
    Public ReadOnly Property FK_EITL_POItemList_UOM() As SIS.EITL.eitlUnits
      Get
        If _FK_EITL_POItemList_UOM Is Nothing Then
          _FK_EITL_POItemList_UOM = SIS.EITL.eitlUnits.eitlUnitsGetByID(_UOM)
        End If
        Return _FK_EITL_POItemList_UOM
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlPOItemListGetNewRecord() As SIS.EITL.eitlPOItemList
      Return New SIS.EITL.eitlPOItemList()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlPOItemListGetByID(ByVal SerialNo As Int32, ByVal ItemLineNo As Int32) As SIS.EITL.eitlPOItemList
      Dim Results As SIS.EITL.eitlPOItemList = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlPOItemListSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemLineNo",SqlDbType.Int,ItemLineNo.ToString.Length, ItemLineNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.EITL.eitlPOItemList(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlPOItemListSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32) As List(Of SIS.EITL.eitlPOItemList)
      Dim Results As List(Of SIS.EITL.eitlPOItemList) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "ItemLineNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "speitlPOItemListSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "speitlPOItemListSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.EITL.eitlPOItemList)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.EITL.eitlPOItemList(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function eitlPOItemListSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlPOItemListGetByID(ByVal SerialNo As Int32, ByVal ItemLineNo As Int32, ByVal Filter_SerialNo As Int32) As SIS.EITL.eitlPOItemList
      Return eitlPOItemListGetByID(SerialNo, ItemLineNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function eitlPOItemListInsert(ByVal Record As SIS.EITL.eitlPOItemList) As SIS.EITL.eitlPOItemList
      Dim _Rec As SIS.EITL.eitlPOItemList = SIS.EITL.eitlPOItemList.eitlPOItemListGetNewRecord()
      With _Rec
        .SerialNo = Record.SerialNo
        .ItemCode = Record.ItemCode
        .Description = Record.Description
        .UOM = Record.UOM
        .Quantity = Record.Quantity
        .WeightInKG = Record.WeightInKG
        .DocumentLineNo = Record.DocumentLineNo
        .ReadyToDespatch = Record.ReadyToDespatch
        .ItemStatusID = Record.ItemStatusID
      End With
      Return SIS.EITL.eitlPOItemList.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.EITL.eitlPOItemList) As SIS.EITL.eitlPOItemList
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlPOItemListInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCode",SqlDbType.NVarChar,51, Iif(Record.ItemCode= "" ,Convert.DBNull, Record.ItemCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,201, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOM",SqlDbType.NVarChar,4, Iif(Record.UOM= "" ,Convert.DBNull, Record.UOM))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quantity",SqlDbType.Int,11, Iif(Record.Quantity= "" ,Convert.DBNull, Record.Quantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WeightInKG",SqlDbType.Decimal,21, Iif(Record.WeightInKG= "" ,Convert.DBNull, Record.WeightInKG))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentLineNo",SqlDbType.Int,11, Iif(Record.DocumentLineNo= "" ,Convert.DBNull, Record.DocumentLineNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReadyToDespatch",SqlDbType.Bit,3, Record.ReadyToDespatch)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Despatched",SqlDbType.Bit,3, Record.Despatched)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VR_ExecutionNo",SqlDbType.Int,11, Iif(Record.VR_ExecutionNo= "" ,Convert.DBNull, Record.VR_ExecutionNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DespatchDate",SqlDbType.DateTime,21, Iif(Record.DespatchDate= "" ,Convert.DBNull, Record.DespatchDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QuantityReceipt",SqlDbType.Int,11, Iif(Record.QuantityReceipt= "" ,Convert.DBNull, Record.QuantityReceipt))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WeightInKGReceipt",SqlDbType.Decimal,21, Iif(Record.WeightInKGReceipt= "" ,Convert.DBNull, Record.WeightInKGReceipt))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaterialStateID",SqlDbType.Int,11, Iif(Record.MaterialStateID= "" ,Convert.DBNull, Record.MaterialStateID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedBy",SqlDbType.NVarChar,9, Iif(Record.ReceivedBy= "" ,Convert.DBNull, Record.ReceivedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedOn",SqlDbType.DateTime,21, Iif(Record.ReceivedOn= "" ,Convert.DBNull, Record.ReceivedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemStatusID",SqlDbType.Int,11, Iif(Record.ItemStatusID= "" ,Convert.DBNull, Record.ItemStatusID))
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_ItemLineNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ItemLineNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
          Record.ItemLineNo = Cmd.Parameters("@Return_ItemLineNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function eitlPOItemListUpdate(ByVal Record As SIS.EITL.eitlPOItemList) As SIS.EITL.eitlPOItemList
      Dim _Rec As SIS.EITL.eitlPOItemList = SIS.EITL.eitlPOItemList.eitlPOItemListGetByID(Record.SerialNo, Record.ItemLineNo)
      With _Rec
        .ItemCode = Record.ItemCode
        .Description = Record.Description
        .UOM = Record.UOM
        .Quantity = Record.Quantity
        .WeightInKG = Record.WeightInKG
        .DocumentLineNo = Record.DocumentLineNo
        .ReadyToDespatch = Record.ReadyToDespatch
        .ItemStatusID = Record.ItemStatusID
      End With
      Return SIS.EITL.eitlPOItemList.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.EITL.eitlPOItemList) As SIS.EITL.eitlPOItemList
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlPOItemListUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ItemLineNo",SqlDbType.Int,11, Record.ItemLineNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCode",SqlDbType.NVarChar,51, Iif(Record.ItemCode= "" ,Convert.DBNull, Record.ItemCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,201, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOM",SqlDbType.NVarChar,4, Iif(Record.UOM= "" ,Convert.DBNull, Record.UOM))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quantity",SqlDbType.Int,11, Iif(Record.Quantity= "" ,Convert.DBNull, Record.Quantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WeightInKG",SqlDbType.Decimal,21, Iif(Record.WeightInKG= "" ,Convert.DBNull, Record.WeightInKG))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentLineNo",SqlDbType.Int,11, Iif(Record.DocumentLineNo= "" ,Convert.DBNull, Record.DocumentLineNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReadyToDespatch",SqlDbType.Bit,3, Record.ReadyToDespatch)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Despatched",SqlDbType.Bit,3, Record.Despatched)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VR_ExecutionNo",SqlDbType.Int,11, Iif(Record.VR_ExecutionNo= "" ,Convert.DBNull, Record.VR_ExecutionNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DespatchDate",SqlDbType.DateTime,21, Iif(Record.DespatchDate= "" ,Convert.DBNull, Record.DespatchDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QuantityReceipt",SqlDbType.Int,11, Iif(Record.QuantityReceipt= "" ,Convert.DBNull, Record.QuantityReceipt))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WeightInKGReceipt",SqlDbType.Decimal,21, Iif(Record.WeightInKGReceipt= "" ,Convert.DBNull, Record.WeightInKGReceipt))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaterialStateID",SqlDbType.Int,11, Iif(Record.MaterialStateID= "" ,Convert.DBNull, Record.MaterialStateID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedBy",SqlDbType.NVarChar,9, Iif(Record.ReceivedBy= "" ,Convert.DBNull, Record.ReceivedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedOn",SqlDbType.DateTime,21, Iif(Record.ReceivedOn= "" ,Convert.DBNull, Record.ReceivedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemStatusID",SqlDbType.Int,11, Iif(Record.ItemStatusID= "" ,Convert.DBNull, Record.ItemStatusID))
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
    Public Shared Function eitlPOItemListDelete(ByVal Record As SIS.EITL.eitlPOItemList) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlPOItemListDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,Record.SerialNo.ToString.Length, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ItemLineNo",SqlDbType.Int,Record.ItemLineNo.ToString.Length, Record.ItemLineNo)
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
      On Error Resume Next
      _SerialNo = Ctype(Reader("SerialNo"),Int32)
      _ItemLineNo = Ctype(Reader("ItemLineNo"),Int32)
      If Convert.IsDBNull(Reader("ItemCode")) Then
        _ItemCode = String.Empty
      Else
        _ItemCode = Ctype(Reader("ItemCode"), String)
      End If
      If Convert.IsDBNull(Reader("Description")) Then
        _Description = String.Empty
      Else
        _Description = Ctype(Reader("Description"), String)
      End If
      If Convert.IsDBNull(Reader("UOM")) Then
        _UOM = String.Empty
      Else
        _UOM = Ctype(Reader("UOM"), String)
      End If
      If Convert.IsDBNull(Reader("Quantity")) Then
        _Quantity = String.Empty
      Else
        _Quantity = Ctype(Reader("Quantity"), String)
      End If
      If Convert.IsDBNull(Reader("WeightInKG")) Then
        _WeightInKG = String.Empty
      Else
        _WeightInKG = Ctype(Reader("WeightInKG"), String)
      End If
      If Convert.IsDBNull(Reader("DocumentLineNo")) Then
        _DocumentLineNo = String.Empty
      Else
        _DocumentLineNo = Ctype(Reader("DocumentLineNo"), String)
      End If
      _ReadyToDespatch = Ctype(Reader("ReadyToDespatch"),Boolean)
      _Despatched = Ctype(Reader("Despatched"),Boolean)
      If Convert.IsDBNull(Reader("VR_ExecutionNo")) Then
        _VR_ExecutionNo = String.Empty
      Else
        _VR_ExecutionNo = Ctype(Reader("VR_ExecutionNo"), String)
      End If
      If Convert.IsDBNull(Reader("DespatchDate")) Then
        _DespatchDate = String.Empty
      Else
        _DespatchDate = Ctype(Reader("DespatchDate"), String)
      End If
      If Convert.IsDBNull(Reader("QuantityReceipt")) Then
        _QuantityReceipt = String.Empty
      Else
        _QuantityReceipt = Ctype(Reader("QuantityReceipt"), String)
      End If
      If Convert.IsDBNull(Reader("WeightInKGReceipt")) Then
        _WeightInKGReceipt = String.Empty
      Else
        _WeightInKGReceipt = Ctype(Reader("WeightInKGReceipt"), String)
      End If
      If Convert.IsDBNull(Reader("MaterialStateID")) Then
        _MaterialStateID = String.Empty
      Else
        _MaterialStateID = Ctype(Reader("MaterialStateID"), String)
      End If
      If Convert.IsDBNull(Reader("ReceivedBy")) Then
        _ReceivedBy = String.Empty
      Else
        _ReceivedBy = Ctype(Reader("ReceivedBy"), String)
      End If
      If Convert.IsDBNull(Reader("ReceivedOn")) Then
        _ReceivedOn = String.Empty
      Else
        _ReceivedOn = Ctype(Reader("ReceivedOn"), String)
      End If
      If Convert.IsDBNull(Reader("ItemStatusID")) Then
        _ItemStatusID = String.Empty
      Else
        _ItemStatusID = Ctype(Reader("ItemStatusID"), String)
      End If
      _aspnet_Users1_UserFullName = Ctype(Reader("aspnet_Users1_UserFullName"),String)
      If Convert.IsDBNull(Reader("EITL_MaterialState2_Description")) Then
        _EITL_MaterialState2_Description = String.Empty
      Else
        _EITL_MaterialState2_Description = Ctype(Reader("EITL_MaterialState2_Description"), String)
      End If
      If Convert.IsDBNull(Reader("EITL_PODocumentList3_DocumentID")) Then
        _EITL_PODocumentList3_DocumentID = String.Empty
      Else
        _EITL_PODocumentList3_DocumentID = Ctype(Reader("EITL_PODocumentList3_DocumentID"), String)
      End If
      If Convert.IsDBNull(Reader("EITL_POItemStatus4_Description")) Then
        _EITL_POItemStatus4_Description = String.Empty
      Else
        _EITL_POItemStatus4_Description = Ctype(Reader("EITL_POItemStatus4_Description"), String)
      End If
      If Convert.IsDBNull(Reader("EITL_POList5_PONumber")) Then
        _EITL_POList5_PONumber = String.Empty
      Else
        _EITL_POList5_PONumber = Ctype(Reader("EITL_POList5_PONumber"), String)
      End If
      If Convert.IsDBNull(Reader("EITL_Units6_Description")) Then
        _EITL_Units6_Description = String.Empty
      Else
        _EITL_Units6_Description = Ctype(Reader("EITL_Units6_Description"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
