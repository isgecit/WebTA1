Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.EITL
  <DataObject()> _
  Partial Public Class eitlProjectWiseUser
    Private Shared _RecordCount As Integer
    Private _SerialNo As Int64 = 0
    Private _UserID As String = ""
    Private _ProjectID As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _IDM_Projects2_Description As String = ""
    Private _FK_EITL_ProjectWiseUser_UserID As SIS.QCM.qcmUsers = Nothing
    Private _FK_EITL_ProjectWiseUser_ProjectID As SIS.EITL.eitlProjects = Nothing
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
    Public Property SerialNo() As Int64
      Get
        Return _SerialNo
      End Get
      Set(ByVal value As Int64)
        _SerialNo = value
      End Set
    End Property
    Public Property UserID() As String
      Get
        Return _UserID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _UserID = ""
				 Else
					 _UserID = value
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
    Public Property aspnet_Users1_UserFullName() As String
      Get
        Return _aspnet_Users1_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users1_UserFullName = value
      End Set
    End Property
    Public Property IDM_Projects2_Description() As String
      Get
        Return _IDM_Projects2_Description
      End Get
      Set(ByVal value As String)
        _IDM_Projects2_Description = value
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
    Public Class PKeitlProjectWiseUser
			Private _SerialNo As Int64 = 0
			Public Property SerialNo() As Int64
				Get
					Return _SerialNo
				End Get
				Set(ByVal value As Int64)
					_SerialNo = value
				End Set
			End Property
    End Class
    Public ReadOnly Property FK_EITL_ProjectWiseUser_UserID() As SIS.QCM.qcmUsers
      Get
        If _FK_EITL_ProjectWiseUser_UserID Is Nothing Then
          _FK_EITL_ProjectWiseUser_UserID = SIS.QCM.qcmUsers.qcmUsersGetByID(_UserID)
        End If
        Return _FK_EITL_ProjectWiseUser_UserID
      End Get
    End Property
    Public ReadOnly Property FK_EITL_ProjectWiseUser_ProjectID() As SIS.EITL.eitlProjects
      Get
        If _FK_EITL_ProjectWiseUser_ProjectID Is Nothing Then
          _FK_EITL_ProjectWiseUser_ProjectID = SIS.EITL.eitlProjects.eitlProjectsGetByID(_ProjectID)
        End If
        Return _FK_EITL_ProjectWiseUser_ProjectID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlProjectWiseUserGetNewRecord() As SIS.EITL.eitlProjectWiseUser
      Return New SIS.EITL.eitlProjectWiseUser()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlProjectWiseUserGetByID(ByVal SerialNo As Int64) As SIS.EITL.eitlProjectWiseUser
      Dim Results As SIS.EITL.eitlProjectWiseUser = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlProjectWiseUserSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.BigInt,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.EITL.eitlProjectWiseUser(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByUserID(ByVal UserID As String, ByVal OrderBy as String) As List(Of SIS.EITL.eitlProjectWiseUser)
      Dim Results As List(Of SIS.EITL.eitlProjectWiseUser) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlProjectWiseUserSelectByUserID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,UserID.ToString.Length, UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.EITL.eitlProjectWiseUser)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.EITL.eitlProjectWiseUser(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByProjectID(ByVal ProjectID As String, ByVal OrderBy as String) As List(Of SIS.EITL.eitlProjectWiseUser)
      Dim Results As List(Of SIS.EITL.eitlProjectWiseUser) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlProjectWiseUserSelectByProjectID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,ProjectID.ToString.Length, ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.EITL.eitlProjectWiseUser)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.EITL.eitlProjectWiseUser(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlProjectWiseUserSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal UserID As String, ByVal ProjectID As String) As List(Of SIS.EITL.eitlProjectWiseUser)
      Dim Results As List(Of SIS.EITL.eitlProjectWiseUser) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "speitlProjectWiseUserSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "speitlProjectWiseUserSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_UserID",SqlDbType.NVarChar,8, IIf(UserID Is Nothing, String.Empty,UserID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.EITL.eitlProjectWiseUser)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.EITL.eitlProjectWiseUser(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function eitlProjectWiseUserSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal UserID As String, ByVal ProjectID As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlProjectWiseUserGetByID(ByVal SerialNo As Int64, ByVal Filter_UserID As String, ByVal Filter_ProjectID As String) As SIS.EITL.eitlProjectWiseUser
      Return eitlProjectWiseUserGetByID(SerialNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function eitlProjectWiseUserInsert(ByVal Record As SIS.EITL.eitlProjectWiseUser) As SIS.EITL.eitlProjectWiseUser
      Dim _Rec As SIS.EITL.eitlProjectWiseUser = SIS.EITL.eitlProjectWiseUser.eitlProjectWiseUserGetNewRecord()
      With _Rec
        .UserID = Record.UserID
        .ProjectID = Record.ProjectID
      End With
      Return SIS.EITL.eitlProjectWiseUser.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.EITL.eitlProjectWiseUser) As SIS.EITL.eitlProjectWiseUser
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlProjectWiseUserInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,9, Iif(Record.UserID= "" ,Convert.DBNull, Record.UserID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.BigInt, 20)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function eitlProjectWiseUserUpdate(ByVal Record As SIS.EITL.eitlProjectWiseUser) As SIS.EITL.eitlProjectWiseUser
      Dim _Rec As SIS.EITL.eitlProjectWiseUser = SIS.EITL.eitlProjectWiseUser.eitlProjectWiseUserGetByID(Record.SerialNo)
      With _Rec
        .UserID = Record.UserID
        .ProjectID = Record.ProjectID
      End With
      Return SIS.EITL.eitlProjectWiseUser.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.EITL.eitlProjectWiseUser) As SIS.EITL.eitlProjectWiseUser
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlProjectWiseUserUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.BigInt,20, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,9, Iif(Record.UserID= "" ,Convert.DBNull, Record.UserID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
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
    Public Shared Function eitlProjectWiseUserDelete(ByVal Record As SIS.EITL.eitlProjectWiseUser) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlProjectWiseUserDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.BigInt,Record.SerialNo.ToString.Length, Record.SerialNo)
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
      _SerialNo = Ctype(Reader("SerialNo"),Int64)
      If Convert.IsDBNull(Reader("UserID")) Then
        _UserID = String.Empty
      Else
        _UserID = Ctype(Reader("UserID"), String)
      End If
      If Convert.IsDBNull(Reader("ProjectID")) Then
        _ProjectID = String.Empty
      Else
        _ProjectID = Ctype(Reader("ProjectID"), String)
      End If
      _aspnet_Users1_UserFullName = Ctype(Reader("aspnet_Users1_UserFullName"),String)
      _IDM_Projects2_Description = Ctype(Reader("IDM_Projects2_Description"),String)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
