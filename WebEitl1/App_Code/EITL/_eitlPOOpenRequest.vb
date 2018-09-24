Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.EITL
  <DataObject()> _
  Partial Public Class eitlPOOpenRequest
    Private Shared _RecordCount As Integer
    Private _RequestNo As Int32 = 0
    Private _SerialNo As String = ""
    Private _PORevision As String = ""
    Private _SupplierID As String = ""
    Private _Remarks As String = ""
    Private _RequestedOn As String = ""
    Private _ExecutedBy As String = ""
    Private _ExecutedOn As String = ""
    Private _ExecuterRemarks As String = ""
    Private _ExecutedToOpen As Boolean = False
    Private _aspnet_Users1_UserFullName As String = ""
    Private _EITL_POList2_PONumber As String = ""
    Private _EITL_Suppliers3_SupplierName As String = ""
    Private _FK_EITL_POOpenRequest_ExecutedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_EITL_POOpenRequest_SerialNo As SIS.EITL.eitlPOList = Nothing
    Private _FK_EITL_POOpenRequest_SupplierID As SIS.EITL.eitlSuppliers = Nothing
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
    Public Property RequestNo() As Int32
      Get
        Return _RequestNo
      End Get
      Set(ByVal value As Int32)
        _RequestNo = value
      End Set
    End Property
    Public Property SerialNo() As String
      Get
        Return _SerialNo
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _SerialNo = ""
				 Else
					 _SerialNo = value
			   End If
      End Set
    End Property
    Public Property PORevision() As String
      Get
        Return _PORevision
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _PORevision = ""
				 Else
					 _PORevision = value
			   End If
      End Set
    End Property
    Public Property SupplierID() As String
      Get
        Return _SupplierID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _SupplierID = ""
				 Else
					 _SupplierID = value
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
    Public Property RequestedOn() As String
      Get
        If Not _RequestedOn = String.Empty Then
          Return Convert.ToDateTime(_RequestedOn).ToString("dd/MM/yyyy")
        End If
        Return _RequestedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _RequestedOn = ""
				 Else
					 _RequestedOn = value
			   End If
      End Set
    End Property
    Public Property ExecutedBy() As String
      Get
        Return _ExecutedBy
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ExecutedBy = ""
				 Else
					 _ExecutedBy = value
			   End If
      End Set
    End Property
    Public Property ExecutedOn() As String
      Get
        If Not _ExecutedOn = String.Empty Then
          Return Convert.ToDateTime(_ExecutedOn).ToString("dd/MM/yyyy")
        End If
        Return _ExecutedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ExecutedOn = ""
				 Else
					 _ExecutedOn = value
			   End If
      End Set
    End Property
    Public Property ExecuterRemarks() As String
      Get
        Return _ExecuterRemarks
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ExecuterRemarks = ""
				 Else
					 _ExecuterRemarks = value
			   End If
      End Set
    End Property
    Public Property ExecutedToOpen() As Boolean
      Get
        Return _ExecutedToOpen
      End Get
      Set(ByVal value As Boolean)
        _ExecutedToOpen = value
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
    Public Property EITL_POList2_PONumber() As String
      Get
        Return _EITL_POList2_PONumber
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _EITL_POList2_PONumber = ""
				 Else
					 _EITL_POList2_PONumber = value
			   End If
      End Set
    End Property
    Public Property EITL_Suppliers3_SupplierName() As String
      Get
        Return _EITL_Suppliers3_SupplierName
      End Get
      Set(ByVal value As String)
        _EITL_Suppliers3_SupplierName = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _RequestNo
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
    Public Class PKeitlPOOpenRequest
			Private _RequestNo As Int32 = 0
			Public Property RequestNo() As Int32
				Get
					Return _RequestNo
				End Get
				Set(ByVal value As Int32)
					_RequestNo = value
				End Set
			End Property
    End Class
    Public ReadOnly Property FK_EITL_POOpenRequest_ExecutedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_EITL_POOpenRequest_ExecutedBy Is Nothing Then
          _FK_EITL_POOpenRequest_ExecutedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_ExecutedBy)
        End If
        Return _FK_EITL_POOpenRequest_ExecutedBy
      End Get
    End Property
    Public ReadOnly Property FK_EITL_POOpenRequest_SerialNo() As SIS.EITL.eitlPOList
      Get
        If _FK_EITL_POOpenRequest_SerialNo Is Nothing Then
          _FK_EITL_POOpenRequest_SerialNo = SIS.EITL.eitlPOList.eitlPOListGetByID(_SerialNo)
        End If
        Return _FK_EITL_POOpenRequest_SerialNo
      End Get
    End Property
    Public ReadOnly Property FK_EITL_POOpenRequest_SupplierID() As SIS.EITL.eitlSuppliers
      Get
        If _FK_EITL_POOpenRequest_SupplierID Is Nothing Then
          _FK_EITL_POOpenRequest_SupplierID = SIS.EITL.eitlSuppliers.eitlSuppliersGetByID(_SupplierID)
        End If
        Return _FK_EITL_POOpenRequest_SupplierID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlPOOpenRequestGetNewRecord() As SIS.EITL.eitlPOOpenRequest
      Return New SIS.EITL.eitlPOOpenRequest()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlPOOpenRequestGetByID(ByVal RequestNo As Int32) As SIS.EITL.eitlPOOpenRequest
      Dim Results As SIS.EITL.eitlPOOpenRequest = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlPOOpenRequestSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestNo",SqlDbType.Int,RequestNo.ToString.Length, RequestNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.EITL.eitlPOOpenRequest(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlPOOpenRequestSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal SupplierID As String) As List(Of SIS.EITL.eitlPOOpenRequest)
      Dim Results As List(Of SIS.EITL.eitlPOOpenRequest) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "RequestNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "speitlPOOpenRequestSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "speitlPOOpenRequestSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SupplierID",SqlDbType.NVarChar,9, IIf(SupplierID Is Nothing, String.Empty,SupplierID))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.EITL.eitlPOOpenRequest)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.EITL.eitlPOOpenRequest(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function eitlPOOpenRequestSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal SupplierID As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlPOOpenRequestGetByID(ByVal RequestNo As Int32, ByVal Filter_SerialNo As Int32, ByVal Filter_SupplierID As String) As SIS.EITL.eitlPOOpenRequest
      Return eitlPOOpenRequestGetByID(RequestNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function eitlPOOpenRequestInsert(ByVal Record As SIS.EITL.eitlPOOpenRequest) As SIS.EITL.eitlPOOpenRequest
      Dim _Rec As SIS.EITL.eitlPOOpenRequest = SIS.EITL.eitlPOOpenRequest.eitlPOOpenRequestGetNewRecord()
      With _Rec
        .SerialNo = Record.SerialNo
        .PORevision = Record.PORevision
        .SupplierID = Record.SupplierID
        .Remarks = Record.Remarks
        .RequestedOn = Record.RequestedOn
      End With
      Return SIS.EITL.eitlPOOpenRequest.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.EITL.eitlPOOpenRequest) As SIS.EITL.eitlPOOpenRequest
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlPOOpenRequestInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Iif(Record.SerialNo= "" ,Convert.DBNull, Record.SerialNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PORevision",SqlDbType.NVarChar,11, Iif(Record.PORevision= "" ,Convert.DBNull, Record.PORevision))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID",SqlDbType.NVarChar,10, Iif(Record.SupplierID= "" ,Convert.DBNull, Record.SupplierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,501, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestedOn",SqlDbType.DateTime,21, Iif(Record.RequestedOn= "" ,Convert.DBNull, Record.RequestedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExecutedBy",SqlDbType.NVarChar,9, Iif(Record.ExecutedBy= "" ,Convert.DBNull, Record.ExecutedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExecutedOn",SqlDbType.DateTime,21, Iif(Record.ExecutedOn= "" ,Convert.DBNull, Record.ExecutedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExecuterRemarks",SqlDbType.NVarChar,501, Iif(Record.ExecuterRemarks= "" ,Convert.DBNull, Record.ExecuterRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExecutedToOpen",SqlDbType.Bit,3, Record.ExecutedToOpen)
          Cmd.Parameters.Add("@Return_RequestNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_RequestNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.RequestNo = Cmd.Parameters("@Return_RequestNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function eitlPOOpenRequestUpdate(ByVal Record As SIS.EITL.eitlPOOpenRequest) As SIS.EITL.eitlPOOpenRequest
      Dim _Rec As SIS.EITL.eitlPOOpenRequest = SIS.EITL.eitlPOOpenRequest.eitlPOOpenRequestGetByID(Record.RequestNo)
      With _Rec
        .ExecutedBy = Record.ExecutedBy
        .ExecutedOn = Record.ExecutedOn
        .ExecuterRemarks = Record.ExecuterRemarks
        .ExecutedToOpen = Record.ExecutedToOpen
      End With
      Return SIS.EITL.eitlPOOpenRequest.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.EITL.eitlPOOpenRequest) As SIS.EITL.eitlPOOpenRequest
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlPOOpenRequestUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RequestNo",SqlDbType.Int,11, Record.RequestNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Iif(Record.SerialNo= "" ,Convert.DBNull, Record.SerialNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PORevision",SqlDbType.NVarChar,11, Iif(Record.PORevision= "" ,Convert.DBNull, Record.PORevision))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID",SqlDbType.NVarChar,10, Iif(Record.SupplierID= "" ,Convert.DBNull, Record.SupplierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,501, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestedOn",SqlDbType.DateTime,21, Iif(Record.RequestedOn= "" ,Convert.DBNull, Record.RequestedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExecutedBy",SqlDbType.NVarChar,9, Iif(Record.ExecutedBy= "" ,Convert.DBNull, Record.ExecutedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExecutedOn",SqlDbType.DateTime,21, Iif(Record.ExecutedOn= "" ,Convert.DBNull, Record.ExecutedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExecuterRemarks",SqlDbType.NVarChar,501, Iif(Record.ExecuterRemarks= "" ,Convert.DBNull, Record.ExecuterRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExecutedToOpen",SqlDbType.Bit,3, Record.ExecutedToOpen)
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
    Public Shared Function eitlPOOpenRequestDelete(ByVal Record As SIS.EITL.eitlPOOpenRequest) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlPOOpenRequestDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RequestNo",SqlDbType.Int,Record.RequestNo.ToString.Length, Record.RequestNo)
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
      _RequestNo = Ctype(Reader("RequestNo"),Int32)
      If Convert.IsDBNull(Reader("SerialNo")) Then
        _SerialNo = String.Empty
      Else
        _SerialNo = Ctype(Reader("SerialNo"), String)
      End If
      If Convert.IsDBNull(Reader("PORevision")) Then
        _PORevision = String.Empty
      Else
        _PORevision = Ctype(Reader("PORevision"), String)
      End If
      If Convert.IsDBNull(Reader("SupplierID")) Then
        _SupplierID = String.Empty
      Else
        _SupplierID = Ctype(Reader("SupplierID"), String)
      End If
      If Convert.IsDBNull(Reader("Remarks")) Then
        _Remarks = String.Empty
      Else
        _Remarks = Ctype(Reader("Remarks"), String)
      End If
      If Convert.IsDBNull(Reader("RequestedOn")) Then
        _RequestedOn = String.Empty
      Else
        _RequestedOn = Ctype(Reader("RequestedOn"), String)
      End If
      If Convert.IsDBNull(Reader("ExecutedBy")) Then
        _ExecutedBy = String.Empty
      Else
        _ExecutedBy = Ctype(Reader("ExecutedBy"), String)
      End If
      If Convert.IsDBNull(Reader("ExecutedOn")) Then
        _ExecutedOn = String.Empty
      Else
        _ExecutedOn = Ctype(Reader("ExecutedOn"), String)
      End If
      If Convert.IsDBNull(Reader("ExecuterRemarks")) Then
        _ExecuterRemarks = String.Empty
      Else
        _ExecuterRemarks = Ctype(Reader("ExecuterRemarks"), String)
      End If
      _ExecutedToOpen = Ctype(Reader("ExecutedToOpen"),Boolean)
      _aspnet_Users1_UserFullName = Ctype(Reader("aspnet_Users1_UserFullName"),String)
      If Convert.IsDBNull(Reader("EITL_POList2_PONumber")) Then
        _EITL_POList2_PONumber = String.Empty
      Else
        _EITL_POList2_PONumber = Ctype(Reader("EITL_POList2_PONumber"), String)
      End If
      _EITL_Suppliers3_SupplierName = Ctype(Reader("EITL_Suppliers3_SupplierName"),String)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
