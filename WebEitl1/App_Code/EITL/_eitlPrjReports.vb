Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.EITL
  <DataObject()> _
  Partial Public Class eitlPrjReports
    Private Shared _RecordCount As Integer
    Private _SerialNo As Int32 = 0
    Private _ProjectID As String = ""
    Private _SupplierID As String = ""
    Private _BuyerID As String = ""
    Private _POStatusID As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _EITL_POStatus4_Description As String = ""
    Private _EITL_Suppliers5_SupplierName As String = ""
    Private _IDM_Projects6_Description As String = ""
    Private _FK_EITL_POList_BuyerID As SIS.QCM.qcmUsers = Nothing
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
    Public Property aspnet_Users1_UserFullName() As String
      Get
        Return _aspnet_Users1_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users1_UserFullName = value
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
    Public Class PKeitlPrjReports
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
    Public Shared Function eitlPrjReportsGetNewRecord() As SIS.EITL.eitlPrjReports
      Return New SIS.EITL.eitlPrjReports()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlPrjReportsGetByID(ByVal SerialNo As Int32) As SIS.EITL.eitlPrjReports
      Dim Results As SIS.EITL.eitlPrjReports = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlPrjReportsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.EITL.eitlPrjReports(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlPrjReportsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String, ByVal SupplierID As String, ByVal BuyerID As String, ByVal POStatusID As Int32) As List(Of SIS.EITL.eitlPrjReports)
      Dim Results As List(Of SIS.EITL.eitlPrjReports) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "speitlPrjReportsSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "speitlPrjReportsSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SupplierID",SqlDbType.NVarChar,9, IIf(SupplierID Is Nothing, String.Empty,SupplierID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BuyerID",SqlDbType.NVarChar,8, IIf(BuyerID Is Nothing, String.Empty,BuyerID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_POStatusID",SqlDbType.Int,10, IIf(POStatusID = Nothing, 0,POStatusID))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.EITL.eitlPrjReports)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.EITL.eitlPrjReports(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function eitlPrjReportsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String, ByVal SupplierID As String, ByVal BuyerID As String, ByVal POStatusID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlPrjReportsGetByID(ByVal SerialNo As Int32, ByVal Filter_ProjectID As String, ByVal Filter_SupplierID As String, ByVal Filter_BuyerID As String, ByVal Filter_POStatusID As Int32) As SIS.EITL.eitlPrjReports
      Return eitlPrjReportsGetByID(SerialNo)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _SerialNo = Ctype(Reader("SerialNo"),Int32)
      If Convert.IsDBNull(Reader("ProjectID")) Then
        _ProjectID = String.Empty
      Else
        _ProjectID = Ctype(Reader("ProjectID"), String)
      End If
      If Convert.IsDBNull(Reader("SupplierID")) Then
        _SupplierID = String.Empty
      Else
        _SupplierID = Ctype(Reader("SupplierID"), String)
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
      _aspnet_Users1_UserFullName = Ctype(Reader("aspnet_Users1_UserFullName"),String)
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
