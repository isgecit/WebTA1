Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakSiteIssReqH
    Private Shared _RecordCount As Integer
    Private _ProjectID As String = ""
    Private _IssueNo As Int32 = 0
    Private _IssueToName As String = ""
    Private _RequesterRemarks As String = ""
    Private _IssuedOn As String = ""
    Private _RequestedBy As String = ""
    Private _IssuedBy As String = ""
    Private _IssueStatusID As String = ""
    Private _IssueToCardNo As String = ""
    Private _IssueTypeID As String = ""
    Private _RequestedOn As String = ""
    Private _IssueRemarks As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _aspnet_Users2_UserFullName As String = ""
    Private _IDM_Projects3_Description As String = ""
    Private _PAK_IssueStatus4_Description As String = ""
    Private _PAK_IssueTypes5_Description As String = ""
    Private _aspnet_Users6_UserFullName As String = ""
    Private _FK_PAK_SiteIssueH_IssueToCardNo As SIS.QCM.qcmUsers = Nothing
    Private _FK_PAK_SiteIssueH_IssuedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_PAK_SiteIssueH_ProjectID As SIS.EITL.eitlProjects = Nothing
    Private _FK_PAK_SiteIssueH_IssueStatusID As SIS.PAK.pakIssueStatus = Nothing
    Private _FK_PAK_SiteIssueH_IssueTypeID As SIS.PAK.pakIssueTypes = Nothing
    Private _FK_PAK_SiteIssueH_RequestedBy As SIS.QCM.qcmUsers = Nothing
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
    Public Property ProjectID() As String
      Get
        Return _ProjectID
      End Get
      Set(ByVal value As String)
        _ProjectID = value
      End Set
    End Property
    Public Property IssueNo() As Int32
      Get
        Return _IssueNo
      End Get
      Set(ByVal value As Int32)
        _IssueNo = value
      End Set
    End Property
    Public Property IssueToName() As String
      Get
        Return _IssueToName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _IssueToName = ""
         Else
           _IssueToName = value
         End If
      End Set
    End Property
    Public Property RequesterRemarks() As String
      Get
        Return _RequesterRemarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _RequesterRemarks = ""
         Else
           _RequesterRemarks = value
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
    Public Property RequestedBy() As String
      Get
        Return _RequestedBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _RequestedBy = ""
         Else
           _RequestedBy = value
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
    Public Property IssueStatusID() As String
      Get
        Return _IssueStatusID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _IssueStatusID = ""
         Else
           _IssueStatusID = value
         End If
      End Set
    End Property
    Public Property IssueToCardNo() As String
      Get
        Return _IssueToCardNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _IssueToCardNo = ""
         Else
           _IssueToCardNo = value
         End If
      End Set
    End Property
    Public Property IssueTypeID() As String
      Get
        Return _IssueTypeID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _IssueTypeID = ""
         Else
           _IssueTypeID = value
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
    Public Property IssueRemarks() As String
      Get
        Return _IssueRemarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _IssueRemarks = ""
         Else
           _IssueRemarks = value
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
    Public Property IDM_Projects3_Description() As String
      Get
        Return _IDM_Projects3_Description
      End Get
      Set(ByVal value As String)
        _IDM_Projects3_Description = value
      End Set
    End Property
    Public Property PAK_IssueStatus4_Description() As String
      Get
        Return _PAK_IssueStatus4_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_IssueStatus4_Description = ""
         Else
           _PAK_IssueStatus4_Description = value
         End If
      End Set
    End Property
    Public Property PAK_IssueTypes5_Description() As String
      Get
        Return _PAK_IssueTypes5_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_IssueTypes5_Description = ""
         Else
           _PAK_IssueTypes5_Description = value
         End If
      End Set
    End Property
    Public Property aspnet_Users6_UserFullName() As String
      Get
        Return _aspnet_Users6_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users6_UserFullName = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _RequesterRemarks.ToString.PadRight(100, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _ProjectID & "|" & _IssueNo
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
    Public Class PKpakSiteIssReqH
      Private _ProjectID As String = ""
      Private _IssueNo As Int32 = 0
      Public Property ProjectID() As String
        Get
          Return _ProjectID
        End Get
        Set(ByVal value As String)
          _ProjectID = value
        End Set
      End Property
      Public Property IssueNo() As Int32
        Get
          Return _IssueNo
        End Get
        Set(ByVal value As Int32)
          _IssueNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PAK_SiteIssueH_IssueToCardNo() As SIS.QCM.qcmUsers
      Get
        If _FK_PAK_SiteIssueH_IssueToCardNo Is Nothing Then
          _FK_PAK_SiteIssueH_IssueToCardNo = SIS.QCM.qcmUsers.qcmUsersGetByID(_IssueToCardNo)
        End If
        Return _FK_PAK_SiteIssueH_IssueToCardNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SiteIssueH_IssuedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_PAK_SiteIssueH_IssuedBy Is Nothing Then
          _FK_PAK_SiteIssueH_IssuedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_IssuedBy)
        End If
        Return _FK_PAK_SiteIssueH_IssuedBy
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SiteIssueH_ProjectID() As SIS.EITL.eitlProjects
      Get
        If _FK_PAK_SiteIssueH_ProjectID Is Nothing Then
          _FK_PAK_SiteIssueH_ProjectID = SIS.EITL.eitlProjects.eitlProjectsGetByID(_ProjectID)
        End If
        Return _FK_PAK_SiteIssueH_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SiteIssueH_IssueStatusID() As SIS.PAK.pakIssueStatus
      Get
        If _FK_PAK_SiteIssueH_IssueStatusID Is Nothing Then
          _FK_PAK_SiteIssueH_IssueStatusID = SIS.PAK.pakIssueStatus.pakIssueStatusGetByID(_IssueStatusID)
        End If
        Return _FK_PAK_SiteIssueH_IssueStatusID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SiteIssueH_IssueTypeID() As SIS.PAK.pakIssueTypes
      Get
        If _FK_PAK_SiteIssueH_IssueTypeID Is Nothing Then
          _FK_PAK_SiteIssueH_IssueTypeID = SIS.PAK.pakIssueTypes.pakIssueTypesGetByID(_IssueTypeID)
        End If
        Return _FK_PAK_SiteIssueH_IssueTypeID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SiteIssueH_RequestedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_PAK_SiteIssueH_RequestedBy Is Nothing Then
          _FK_PAK_SiteIssueH_RequestedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_RequestedBy)
        End If
        Return _FK_PAK_SiteIssueH_RequestedBy
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSiteIssReqHSelectList(ByVal OrderBy As String) As List(Of SIS.PAK.pakSiteIssReqH)
      Dim Results As List(Of SIS.PAK.pakSiteIssReqH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSiteIssReqHSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakSiteIssReqH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSiteIssReqH(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSiteIssReqHGetNewRecord() As SIS.PAK.pakSiteIssReqH
      Return New SIS.PAK.pakSiteIssReqH()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSiteIssReqHGetByID(ByVal ProjectID As String, ByVal IssueNo As Int32) As SIS.PAK.pakSiteIssReqH
      Dim Results As SIS.PAK.pakSiteIssReqH = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSiteIssReqHSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,ProjectID.ToString.Length, ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssueNo",SqlDbType.Int,IssueNo.ToString.Length, IssueNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakSiteIssReqH(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSiteIssReqHSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String) As List(Of SIS.PAK.pakSiteIssReqH)
      Dim Results As List(Of SIS.PAK.pakSiteIssReqH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakSiteIssReqHSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakSiteIssReqHSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakSiteIssReqH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSiteIssReqH(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakSiteIssReqHSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSiteIssReqHGetByID(ByVal ProjectID As String, ByVal IssueNo As Int32, ByVal Filter_ProjectID As String) As SIS.PAK.pakSiteIssReqH
      Return pakSiteIssReqHGetByID(ProjectID, IssueNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function pakSiteIssReqHInsert(ByVal Record As SIS.PAK.pakSiteIssReqH) As SIS.PAK.pakSiteIssReqH
      Dim _Rec As SIS.PAK.pakSiteIssReqH = SIS.PAK.pakSiteIssReqH.pakSiteIssReqHGetNewRecord()
      With _Rec
        .ProjectID = Record.ProjectID
        .IssueToName = Record.IssueToName
        .RequesterRemarks = Record.RequesterRemarks
        .IssuedOn = Record.IssuedOn
        .RequestedBy =  Global.System.Web.HttpContext.Current.Session("LoginID")
        .IssuedBy = Record.IssuedBy
        .IssueStatusID = siteIssueStates.Free
        .IssueToCardNo = Record.IssueToCardNo
        .IssueTypeID = siteIssueTypes.Issue
        .RequestedOn = Now
        .IssueRemarks = Record.IssueRemarks
      End With
      Return SIS.PAK.pakSiteIssReqH.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PAK.pakSiteIssReqH) As SIS.PAK.pakSiteIssReqH
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSiteIssReqHInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssueToName",SqlDbType.NVarChar,51, Iif(Record.IssueToName= "" ,Convert.DBNull, Record.IssueToName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequesterRemarks",SqlDbType.NVarChar,101, Iif(Record.RequesterRemarks= "" ,Convert.DBNull, Record.RequesterRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssuedOn",SqlDbType.DateTime,21, Iif(Record.IssuedOn= "" ,Convert.DBNull, Record.IssuedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestedBy",SqlDbType.NVarChar,9, Iif(Record.RequestedBy= "" ,Convert.DBNull, Record.RequestedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssuedBy",SqlDbType.NVarChar,9, Iif(Record.IssuedBy= "" ,Convert.DBNull, Record.IssuedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssueStatusID",SqlDbType.Int,11, Iif(Record.IssueStatusID= "" ,Convert.DBNull, Record.IssueStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssueToCardNo",SqlDbType.NVarChar,9, Iif(Record.IssueToCardNo= "" ,Convert.DBNull, Record.IssueToCardNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssueTypeID",SqlDbType.Int,11, Iif(Record.IssueTypeID= "" ,Convert.DBNull, Record.IssueTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestedOn",SqlDbType.DateTime,21, Iif(Record.RequestedOn= "" ,Convert.DBNull, Record.RequestedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssueRemarks",SqlDbType.NVarChar,101, Iif(Record.IssueRemarks= "" ,Convert.DBNull, Record.IssueRemarks))
          Cmd.Parameters.Add("@Return_ProjectID", SqlDbType.NVarChar, 7)
          Cmd.Parameters("@Return_ProjectID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_IssueNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_IssueNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ProjectID = Cmd.Parameters("@Return_ProjectID").Value
          Record.IssueNo = Cmd.Parameters("@Return_IssueNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakSiteIssReqHUpdate(ByVal Record As SIS.PAK.pakSiteIssReqH) As SIS.PAK.pakSiteIssReqH
      Dim _Rec As SIS.PAK.pakSiteIssReqH = SIS.PAK.pakSiteIssReqH.pakSiteIssReqHGetByID(Record.ProjectID, Record.IssueNo)
      With _Rec
        .IssueToName = Record.IssueToName
        .RequesterRemarks = Record.RequesterRemarks
        .IssuedOn = Record.IssuedOn
        .RequestedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .IssuedBy = Record.IssuedBy
        .IssueStatusID = Record.IssueStatusID
        .IssueToCardNo = Record.IssueToCardNo
        .IssueTypeID = Record.IssueTypeID
        .RequestedOn = Now
        .IssueRemarks = Record.IssueRemarks
      End With
      Return SIS.PAK.pakSiteIssReqH.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PAK.pakSiteIssReqH) As SIS.PAK.pakSiteIssReqH
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSiteIssReqHUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_IssueNo",SqlDbType.Int,11, Record.IssueNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssueToName",SqlDbType.NVarChar,51, Iif(Record.IssueToName= "" ,Convert.DBNull, Record.IssueToName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequesterRemarks",SqlDbType.NVarChar,101, Iif(Record.RequesterRemarks= "" ,Convert.DBNull, Record.RequesterRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssuedOn",SqlDbType.DateTime,21, Iif(Record.IssuedOn= "" ,Convert.DBNull, Record.IssuedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestedBy",SqlDbType.NVarChar,9, Iif(Record.RequestedBy= "" ,Convert.DBNull, Record.RequestedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssuedBy",SqlDbType.NVarChar,9, Iif(Record.IssuedBy= "" ,Convert.DBNull, Record.IssuedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssueStatusID",SqlDbType.Int,11, Iif(Record.IssueStatusID= "" ,Convert.DBNull, Record.IssueStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssueToCardNo",SqlDbType.NVarChar,9, Iif(Record.IssueToCardNo= "" ,Convert.DBNull, Record.IssueToCardNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssueTypeID",SqlDbType.Int,11, Iif(Record.IssueTypeID= "" ,Convert.DBNull, Record.IssueTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestedOn",SqlDbType.DateTime,21, Iif(Record.RequestedOn= "" ,Convert.DBNull, Record.RequestedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssueRemarks",SqlDbType.NVarChar,101, Iif(Record.IssueRemarks= "" ,Convert.DBNull, Record.IssueRemarks))
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
    Public Shared Function pakSiteIssReqHDelete(ByVal Record As SIS.PAK.pakSiteIssReqH) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSiteIssReqHDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID",SqlDbType.NVarChar,Record.ProjectID.ToString.Length, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_IssueNo",SqlDbType.Int,Record.IssueNo.ToString.Length, Record.IssueNo)
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
    Public Shared Function SelectpakSiteIssReqHAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSiteIssReqHAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(100, " "),"" & "|" & ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.PAK.pakSiteIssReqH = New SIS.PAK.pakSiteIssReqH(Reader)
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
