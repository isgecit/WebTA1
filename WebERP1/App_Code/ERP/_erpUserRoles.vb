Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ERP
  <DataObject()> _
  Partial Public Class erpUserRoles
    Private Shared _RecordCount As Integer
    Private _SerialNo As Int32 = 0
    Private _RequesterID As String = ""
    Private _ApproverID As String = ""
    Private _RoleID As Int32 = 0
    Private _aspnet_Users1_UserFullName As String = ""
    Private _aspnet_Users2_UserFullName As String = ""
    Private _ERP_Roles3_Description As String = ""
    Private _FK_ERP_UserRoles_RequesterID As SIS.QCM.qcmUsers = Nothing
    Private _FK_ERP_UserRoles_ApproverID As SIS.QCM.qcmUsers = Nothing
    Private _FK_ERP_UserRoles_RoleID As SIS.ERP.erpRoles = Nothing
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
    Public Property RequesterID() As String
      Get
        Return _RequesterID
      End Get
      Set(ByVal value As String)
        _RequesterID = value
      End Set
    End Property
    Public Property ApproverID() As String
      Get
        Return _ApproverID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ApproverID = ""
				 Else
					 _ApproverID = value
			   End If
      End Set
    End Property
    Public Property RoleID() As Int32
      Get
        Return _RoleID
      End Get
      Set(ByVal value As Int32)
        _RoleID = value
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
    Public Property ERP_Roles3_Description() As String
      Get
        Return _ERP_Roles3_Description
      End Get
      Set(ByVal value As String)
        _ERP_Roles3_Description = value
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
    Public Class PKerpUserRoles
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
    Public ReadOnly Property FK_ERP_UserRoles_RequesterID() As SIS.QCM.qcmUsers
      Get
        If _FK_ERP_UserRoles_RequesterID Is Nothing Then
          _FK_ERP_UserRoles_RequesterID = SIS.QCM.qcmUsers.qcmUsersGetByID(_RequesterID)
        End If
        Return _FK_ERP_UserRoles_RequesterID
      End Get
    End Property
    Public ReadOnly Property FK_ERP_UserRoles_ApproverID() As SIS.QCM.qcmUsers
      Get
        If _FK_ERP_UserRoles_ApproverID Is Nothing Then
          _FK_ERP_UserRoles_ApproverID = SIS.QCM.qcmUsers.qcmUsersGetByID(_ApproverID)
        End If
        Return _FK_ERP_UserRoles_ApproverID
      End Get
    End Property
    Public ReadOnly Property FK_ERP_UserRoles_RoleID() As SIS.ERP.erpRoles
      Get
        If _FK_ERP_UserRoles_RoleID Is Nothing Then
          _FK_ERP_UserRoles_RoleID = SIS.ERP.erpRoles.erpRolesGetByID(_RoleID)
        End If
        Return _FK_ERP_UserRoles_RoleID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpUserRolesGetNewRecord() As SIS.ERP.erpUserRoles
      Return New SIS.ERP.erpUserRoles()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpUserRolesGetByID(ByVal SerialNo As Int32) As SIS.ERP.erpUserRoles
      Dim Results As SIS.ERP.erpUserRoles = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpUserRolesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.ERP.erpUserRoles(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpUserRolesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal RequesterID As String, ByVal ApproverID As String, ByVal RoleID As Int32) As List(Of SIS.ERP.erpUserRoles)
      Dim Results As List(Of SIS.ERP.erpUserRoles) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "sperpUserRolesSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "sperpUserRolesSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RequesterID",SqlDbType.NVarChar,8, IIf(RequesterID Is Nothing, String.Empty,RequesterID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ApproverID",SqlDbType.NVarChar,8, IIf(ApproverID Is Nothing, String.Empty,ApproverID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RoleID",SqlDbType.Int,10, IIf(RoleID = Nothing, 0,RoleID))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ERP.erpUserRoles)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ERP.erpUserRoles(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function erpUserRolesSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal RequesterID As String, ByVal ApproverID As String, ByVal RoleID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpUserRolesGetByID(ByVal SerialNo As Int32, ByVal Filter_RequesterID As String, ByVal Filter_ApproverID As String, ByVal Filter_RoleID As Int32) As SIS.ERP.erpUserRoles
      Return erpUserRolesGetByID(SerialNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function erpUserRolesInsert(ByVal Record As SIS.ERP.erpUserRoles) As SIS.ERP.erpUserRoles
      Dim _Rec As SIS.ERP.erpUserRoles = SIS.ERP.erpUserRoles.erpUserRolesGetNewRecord()
      With _Rec
        .RequesterID = Record.RequesterID
        .ApproverID = Record.ApproverID
        .RoleID = Record.RoleID
      End With
      Return SIS.ERP.erpUserRoles.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.ERP.erpUserRoles) As SIS.ERP.erpUserRoles
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpUserRolesInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequesterID",SqlDbType.NVarChar,9, Record.RequesterID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApproverID",SqlDbType.NVarChar,9, Iif(Record.ApproverID= "" ,Convert.DBNull, Record.ApproverID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RoleID",SqlDbType.Int,11, Record.RoleID)
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
    Public Shared Function erpUserRolesUpdate(ByVal Record As SIS.ERP.erpUserRoles) As SIS.ERP.erpUserRoles
      Dim _Rec As SIS.ERP.erpUserRoles = SIS.ERP.erpUserRoles.erpUserRolesGetByID(Record.SerialNo)
      With _Rec
        .RequesterID = Record.RequesterID
        .ApproverID = Record.ApproverID
        .RoleID = Record.RoleID
      End With
      Return SIS.ERP.erpUserRoles.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.ERP.erpUserRoles) As SIS.ERP.erpUserRoles
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpUserRolesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequesterID",SqlDbType.NVarChar,9, Record.RequesterID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApproverID",SqlDbType.NVarChar,9, Iif(Record.ApproverID= "" ,Convert.DBNull, Record.ApproverID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RoleID",SqlDbType.Int,11, Record.RoleID)
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
    Public Shared Function erpUserRolesDelete(ByVal Record As SIS.ERP.erpUserRoles) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpUserRolesDelete"
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
      _RequesterID = Ctype(Reader("RequesterID"),String)
      If Convert.IsDBNull(Reader("ApproverID")) Then
        _ApproverID = String.Empty
      Else
        _ApproverID = Ctype(Reader("ApproverID"), String)
      End If
      _RoleID = Ctype(Reader("RoleID"),Int32)
      _aspnet_Users1_UserFullName = Ctype(Reader("aspnet_Users1_UserFullName"),String)
      _aspnet_Users2_UserFullName = Ctype(Reader("aspnet_Users2_UserFullName"),String)
      _ERP_Roles3_Description = Ctype(Reader("ERP_Roles3_Description"),String)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
