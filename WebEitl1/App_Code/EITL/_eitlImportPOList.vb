Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.EITL
  <DataObject()> _
  Partial Public Class eitlImportPOList
    Private Shared _RecordCount As Integer
    Private _SerialNo As Int32 = 0
    Private _PONumber As String = ""
    Private _PORevision As String = ""
    Private _PODate As String = ""
    Private _SupplierID As String = ""
    Private _ProjectID As String = ""
    Private _DivisionID As String = ""
    Private _BuyerID As String = ""
    Private _POStatusID As String = ""
    Private _IssuedBy As String = ""
    Private _IssuedOn As String = ""
    Private _ClosedBy As String = ""
    Private _ClosedOn As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _aspnet_Users2_UserFullName As String = ""
    Private _aspnet_Users3_UserFullName As String = ""
    Private _EITL_POStatus4_Description As String = ""
    Private _EITL_Suppliers5_SupplierName As String = ""
    Private _IDM_Projects6_Description As String = ""
    Private _FK_EITL_POList_BuyerID As SIS.QCM.qcmUsers = Nothing
    Private _FK_EITL_POList_ClosedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_EITL_POList_IssuedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_EITL_POList_POStatusID As SIS.EITL.eitlPOStatus = Nothing
    Private _FK_EITL_POList_SupplierID As SIS.EITL.eitlSuppliers = Nothing
    Private _FK_EITL_POList_ProjectID As SIS.QCM.qcmProjects = Nothing
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
    Public Property PONumber() As String
      Get
        Return _PONumber
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _PONumber = ""
				 Else
					 _PONumber = value
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
    Public Property PODate() As String
      Get
        If Not _PODate = String.Empty Then
          Return Convert.ToDateTime(_PODate).ToString("dd/MM/yyyy")
        End If
        Return _PODate
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _PODate = ""
				 Else
					 _PODate = value
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
    Public Property ProjectID() As String
      Get
        Return _ProjectID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ProjectID = ""
				 Else
					 _ProjectID = value
			   End If
      End Set
    End Property
    Public Property DivisionID() As String
      Get
        Return _DivisionID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _DivisionID = ""
				 Else
					 _DivisionID = value
			   End If
      End Set
    End Property
    Public Property BuyerID() As String
      Get
        Return _BuyerID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _BuyerID = ""
				 Else
					 _BuyerID = value
			   End If
      End Set
    End Property
    Public Property POStatusID() As String
      Get
        Return _POStatusID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _POStatusID = ""
				 Else
					 _POStatusID = value
			   End If
      End Set
    End Property
    Public Property IssuedBy() As String
      Get
        Return _IssuedBy
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _IssuedBy = ""
				 Else
					 _IssuedBy = value
			   End If
      End Set
    End Property
    Public Property IssuedOn() As String
      Get
        If Not _IssuedOn = String.Empty Then
          Return Convert.ToDateTime(_IssuedOn).ToString("dd/MM/yyyy")
        End If
        Return _IssuedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _IssuedOn = ""
				 Else
					 _IssuedOn = value
			   End If
      End Set
    End Property
    Public Property ClosedBy() As String
      Get
        Return _ClosedBy
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ClosedBy = ""
				 Else
					 _ClosedBy = value
			   End If
      End Set
    End Property
    Public Property ClosedOn() As String
      Get
        If Not _ClosedOn = String.Empty Then
          Return Convert.ToDateTime(_ClosedOn).ToString("dd/MM/yyyy")
        End If
        Return _ClosedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ClosedOn = ""
				 Else
					 _ClosedOn = value
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
    Public Property aspnet_Users2_UserFullName() As String
      Get
        Return _aspnet_Users2_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users2_UserFullName = value
      End Set
    End Property
    Public Property aspnet_Users3_UserFullName() As String
      Get
        Return _aspnet_Users3_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users3_UserFullName = value
      End Set
    End Property
    Public Property EITL_POStatus4_Description() As String
      Get
        Return _EITL_POStatus4_Description
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _EITL_POStatus4_Description = ""
				 Else
					 _EITL_POStatus4_Description = value
			   End If
      End Set
    End Property
    Public Property EITL_Suppliers5_SupplierName() As String
      Get
        Return _EITL_Suppliers5_SupplierName
      End Get
      Set(ByVal value As String)
        _EITL_Suppliers5_SupplierName = value
      End Set
    End Property
    Public Property IDM_Projects6_Description() As String
      Get
        Return _IDM_Projects6_Description
      End Get
      Set(ByVal value As String)
        _IDM_Projects6_Description = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _SerialNo
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
    Public Class PKeitlImportPOList
			Private _SerialNo As Int32 = 0
			Public Property SerialNo() As Int32
				Get
					Return _SerialNo
				End Get
				Set(ByVal value As Int32)
					_SerialNo = value
				End Set
			End Property
    End Class
    Public ReadOnly Property FK_EITL_POList_BuyerID() As SIS.QCM.qcmUsers
      Get
        If _FK_EITL_POList_BuyerID Is Nothing Then
          _FK_EITL_POList_BuyerID = SIS.QCM.qcmUsers.qcmUsersGetByID(_BuyerID)
        End If
        Return _FK_EITL_POList_BuyerID
      End Get
    End Property
    Public ReadOnly Property FK_EITL_POList_ClosedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_EITL_POList_ClosedBy Is Nothing Then
          _FK_EITL_POList_ClosedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_ClosedBy)
        End If
        Return _FK_EITL_POList_ClosedBy
      End Get
    End Property
    Public ReadOnly Property FK_EITL_POList_IssuedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_EITL_POList_IssuedBy Is Nothing Then
          _FK_EITL_POList_IssuedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_IssuedBy)
        End If
        Return _FK_EITL_POList_IssuedBy
      End Get
    End Property
    Public ReadOnly Property FK_EITL_POList_POStatusID() As SIS.EITL.eitlPOStatus
      Get
        If _FK_EITL_POList_POStatusID Is Nothing Then
          _FK_EITL_POList_POStatusID = SIS.EITL.eitlPOStatus.eitlPOStatusGetByID(_POStatusID)
        End If
        Return _FK_EITL_POList_POStatusID
      End Get
    End Property
    Public ReadOnly Property FK_EITL_POList_SupplierID() As SIS.EITL.eitlSuppliers
      Get
        If _FK_EITL_POList_SupplierID Is Nothing Then
          _FK_EITL_POList_SupplierID = SIS.EITL.eitlSuppliers.eitlSuppliersGetByID(_SupplierID)
        End If
        Return _FK_EITL_POList_SupplierID
      End Get
    End Property
    Public ReadOnly Property FK_EITL_POList_ProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_EITL_POList_ProjectID Is Nothing Then
          _FK_EITL_POList_ProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_ProjectID)
        End If
        Return _FK_EITL_POList_ProjectID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlImportPOListGetNewRecord() As SIS.EITL.eitlImportPOList
      Return New SIS.EITL.eitlImportPOList()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlImportPOListGetByID(ByVal SerialNo As Int32) As SIS.EITL.eitlImportPOList
      Dim Results As SIS.EITL.eitlImportPOList = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlImportPOListSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.EITL.eitlImportPOList(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlImportPOListSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.EITL.eitlImportPOList)
      Dim Results As List(Of SIS.EITL.eitlImportPOList) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "speitlImportPOListSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "speitlImportPOListSelectListFilteres"
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.EITL.eitlImportPOList)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.EITL.eitlImportPOList(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function eitlImportPOListSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function eitlImportPOListInsert(ByVal Record As SIS.EITL.eitlImportPOList) As SIS.EITL.eitlImportPOList
      Dim _Rec As SIS.EITL.eitlImportPOList = SIS.EITL.eitlImportPOList.eitlImportPOListGetNewRecord()
      With _Rec
        .PONumber = Record.PONumber
        .PORevision = Record.PORevision
        .PODate = Record.PODate
        .SupplierID = Record.SupplierID
        .ProjectID = Record.ProjectID
        .DivisionID = Record.DivisionID
        .BuyerID = Record.BuyerID
        .POStatusID = Record.POStatusID
        .IssuedBy = Record.IssuedBy
        .IssuedOn = Record.IssuedOn
        .ClosedBy = Record.ClosedBy
        .ClosedOn = Record.ClosedOn
      End With
      Return SIS.EITL.eitlImportPOList.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.EITL.eitlImportPOList) As SIS.EITL.eitlImportPOList
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlImportPOListInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PONumber",SqlDbType.NVarChar,11, Iif(Record.PONumber= "" ,Convert.DBNull, Record.PONumber))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PORevision",SqlDbType.NVarChar,11, Iif(Record.PORevision= "" ,Convert.DBNull, Record.PORevision))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PODate",SqlDbType.DateTime,21, Iif(Record.PODate= "" ,Convert.DBNull, Record.PODate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID",SqlDbType.NVarChar,10, Iif(Record.SupplierID= "" ,Convert.DBNull, Record.SupplierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.NVarChar,11, Iif(Record.DivisionID= "" ,Convert.DBNull, Record.DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerID",SqlDbType.NVarChar,9, Iif(Record.BuyerID= "" ,Convert.DBNull, Record.BuyerID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@POStatusID",SqlDbType.Int,11, Iif(Record.POStatusID= "" ,Convert.DBNull, Record.POStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssuedBy",SqlDbType.NVarChar,9, Iif(Record.IssuedBy= "" ,Convert.DBNull, Record.IssuedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssuedOn",SqlDbType.DateTime,21, Iif(Record.IssuedOn= "" ,Convert.DBNull, Record.IssuedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClosedBy",SqlDbType.NVarChar,9, Iif(Record.ClosedBy= "" ,Convert.DBNull, Record.ClosedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClosedOn",SqlDbType.DateTime,21, Iif(Record.ClosedOn= "" ,Convert.DBNull, Record.ClosedOn))
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function eitlImportPOListUpdate(ByVal Record As SIS.EITL.eitlImportPOList) As SIS.EITL.eitlImportPOList
      Dim _Rec As SIS.EITL.eitlImportPOList = SIS.EITL.eitlImportPOList.eitlImportPOListGetByID(Record.SerialNo)
      With _Rec
        .PONumber = Record.PONumber
        .PORevision = Record.PORevision
        .PODate = Record.PODate
        .SupplierID = Record.SupplierID
        .ProjectID = Record.ProjectID
        .DivisionID = Record.DivisionID
        .BuyerID = Record.BuyerID
        .POStatusID = Record.POStatusID
        .IssuedBy = Record.IssuedBy
        .IssuedOn = Record.IssuedOn
        .ClosedBy = Record.ClosedBy
        .ClosedOn = Record.ClosedOn
      End With
      Return SIS.EITL.eitlImportPOList.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.EITL.eitlImportPOList) As SIS.EITL.eitlImportPOList
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlImportPOListUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PONumber",SqlDbType.NVarChar,11, Iif(Record.PONumber= "" ,Convert.DBNull, Record.PONumber))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PORevision",SqlDbType.NVarChar,11, Iif(Record.PORevision= "" ,Convert.DBNull, Record.PORevision))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PODate",SqlDbType.DateTime,21, Iif(Record.PODate= "" ,Convert.DBNull, Record.PODate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID",SqlDbType.NVarChar,10, Iif(Record.SupplierID= "" ,Convert.DBNull, Record.SupplierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.NVarChar,11, Iif(Record.DivisionID= "" ,Convert.DBNull, Record.DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerID",SqlDbType.NVarChar,9, Iif(Record.BuyerID= "" ,Convert.DBNull, Record.BuyerID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@POStatusID",SqlDbType.Int,11, Iif(Record.POStatusID= "" ,Convert.DBNull, Record.POStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssuedBy",SqlDbType.NVarChar,9, Iif(Record.IssuedBy= "" ,Convert.DBNull, Record.IssuedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssuedOn",SqlDbType.DateTime,21, Iif(Record.IssuedOn= "" ,Convert.DBNull, Record.IssuedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClosedBy",SqlDbType.NVarChar,9, Iif(Record.ClosedBy= "" ,Convert.DBNull, Record.ClosedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClosedOn",SqlDbType.DateTime,21, Iif(Record.ClosedOn= "" ,Convert.DBNull, Record.ClosedOn))
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
    Public Shared Function eitlImportPOListDelete(ByVal Record As SIS.EITL.eitlImportPOList) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlImportPOListDelete"
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
      On Error Resume Next
      _SerialNo = Ctype(Reader("SerialNo"),Int32)
      If Convert.IsDBNull(Reader("PONumber")) Then
        _PONumber = String.Empty
      Else
        _PONumber = Ctype(Reader("PONumber"), String)
      End If
      If Convert.IsDBNull(Reader("PORevision")) Then
        _PORevision = String.Empty
      Else
        _PORevision = Ctype(Reader("PORevision"), String)
      End If
      If Convert.IsDBNull(Reader("PODate")) Then
        _PODate = String.Empty
      Else
        _PODate = Ctype(Reader("PODate"), String)
      End If
      If Convert.IsDBNull(Reader("SupplierID")) Then
        _SupplierID = String.Empty
      Else
        _SupplierID = Ctype(Reader("SupplierID"), String)
      End If
      If Convert.IsDBNull(Reader("ProjectID")) Then
        _ProjectID = String.Empty
      Else
        _ProjectID = Ctype(Reader("ProjectID"), String)
      End If
      If Convert.IsDBNull(Reader("DivisionID")) Then
        _DivisionID = String.Empty
      Else
        _DivisionID = Ctype(Reader("DivisionID"), String)
      End If
      If Convert.IsDBNull(Reader("BuyerID")) Then
        _BuyerID = String.Empty
      Else
        _BuyerID = Ctype(Reader("BuyerID"), String)
      End If
      If Convert.IsDBNull(Reader("POStatusID")) Then
        _POStatusID = String.Empty
      Else
        _POStatusID = Ctype(Reader("POStatusID"), String)
      End If
      If Convert.IsDBNull(Reader("IssuedBy")) Then
        _IssuedBy = String.Empty
      Else
        _IssuedBy = Ctype(Reader("IssuedBy"), String)
      End If
      If Convert.IsDBNull(Reader("IssuedOn")) Then
        _IssuedOn = String.Empty
      Else
        _IssuedOn = Ctype(Reader("IssuedOn"), String)
      End If
      If Convert.IsDBNull(Reader("ClosedBy")) Then
        _ClosedBy = String.Empty
      Else
        _ClosedBy = Ctype(Reader("ClosedBy"), String)
      End If
      If Convert.IsDBNull(Reader("ClosedOn")) Then
        _ClosedOn = String.Empty
      Else
        _ClosedOn = Ctype(Reader("ClosedOn"), String)
      End If
      _aspnet_Users1_UserFullName = Ctype(Reader("aspnet_Users1_UserFullName"),String)
      _aspnet_Users2_UserFullName = Ctype(Reader("aspnet_Users2_UserFullName"),String)
      _aspnet_Users3_UserFullName = Ctype(Reader("aspnet_Users3_UserFullName"),String)
      If Convert.IsDBNull(Reader("EITL_POStatus4_Description")) Then
        _EITL_POStatus4_Description = String.Empty
      Else
        _EITL_POStatus4_Description = Ctype(Reader("EITL_POStatus4_Description"), String)
      End If
      _EITL_Suppliers5_SupplierName = Ctype(Reader("EITL_Suppliers5_SupplierName"),String)
      _IDM_Projects6_Description = Ctype(Reader("IDM_Projects6_Description"),String)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
