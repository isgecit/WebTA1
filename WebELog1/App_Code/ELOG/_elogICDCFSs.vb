Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ELOG
  <DataObject()> _
  Partial Public Class elogICDCFSs
    Private Shared _RecordCount As Integer
    Private _ICDCFSID As Int32 = 0
    Private _StuffingPointID As String = ""
    Private _Description As String = ""
    Private _ELOG_StuffingPoints1_Description As String = ""
    Private _FK_ELOG_ICDCFSs_StuffingPointID As SIS.ELOG.elogStuffingPoints = Nothing
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
    Public Property ICDCFSID() As Int32
      Get
        Return _ICDCFSID
      End Get
      Set(ByVal value As Int32)
        _ICDCFSID = value
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
    Public Property ELOG_StuffingPoints1_Description() As String
      Get
        Return _ELOG_StuffingPoints1_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ELOG_StuffingPoints1_Description = ""
         Else
           _ELOG_StuffingPoints1_Description = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _Description.ToString.PadRight(100, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _ICDCFSID
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
    Public Class PKelogICDCFSs
      Private _ICDCFSID As Int32 = 0
      Public Property ICDCFSID() As Int32
        Get
          Return _ICDCFSID
        End Get
        Set(ByVal value As Int32)
          _ICDCFSID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_ELOG_ICDCFSs_StuffingPointID() As SIS.ELOG.elogStuffingPoints
      Get
        If _FK_ELOG_ICDCFSs_StuffingPointID Is Nothing Then
          _FK_ELOG_ICDCFSs_StuffingPointID = SIS.ELOG.elogStuffingPoints.elogStuffingPointsGetByID(_StuffingPointID)
        End If
        Return _FK_ELOG_ICDCFSs_StuffingPointID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function elogICDCFSsSelectList(ByVal OrderBy As String) As List(Of SIS.ELOG.elogICDCFSs)
      Dim Results As List(Of SIS.ELOG.elogICDCFSs) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogICDCFSsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ELOG.elogICDCFSs)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ELOG.elogICDCFSs(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function elogICDCFSsGetNewRecord() As SIS.ELOG.elogICDCFSs
      Return New SIS.ELOG.elogICDCFSs()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function elogICDCFSsGetByID(ByVal ICDCFSID As Int32) As SIS.ELOG.elogICDCFSs
      Dim Results As SIS.ELOG.elogICDCFSs = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogICDCFSsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ICDCFSID",SqlDbType.Int,ICDCFSID.ToString.Length, ICDCFSID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ELOG.elogICDCFSs(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function elogICDCFSsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal StuffingPointID As Int32) As List(Of SIS.ELOG.elogICDCFSs)
      Dim Results As List(Of SIS.ELOG.elogICDCFSs) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spelogICDCFSsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spelogICDCFSsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StuffingPointID",SqlDbType.Int,10, IIf(StuffingPointID = Nothing, 0,StuffingPointID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ELOG.elogICDCFSs)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ELOG.elogICDCFSs(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function elogICDCFSsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal StuffingPointID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function elogICDCFSsGetByID(ByVal ICDCFSID As Int32, ByVal Filter_StuffingPointID As Int32) As SIS.ELOG.elogICDCFSs
      Return elogICDCFSsGetByID(ICDCFSID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function elogICDCFSsInsert(ByVal Record As SIS.ELOG.elogICDCFSs) As SIS.ELOG.elogICDCFSs
      Dim _Rec As SIS.ELOG.elogICDCFSs = SIS.ELOG.elogICDCFSs.elogICDCFSsGetNewRecord()
      With _Rec
        .StuffingPointID = Record.StuffingPointID
        .Description = Record.Description
      End With
      Return SIS.ELOG.elogICDCFSs.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.ELOG.elogICDCFSs) As SIS.ELOG.elogICDCFSs
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogICDCFSsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StuffingPointID",SqlDbType.Int,11, Iif(Record.StuffingPointID= "" ,Convert.DBNull, Record.StuffingPointID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,101, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          Cmd.Parameters.Add("@Return_ICDCFSID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ICDCFSID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ICDCFSID = Cmd.Parameters("@Return_ICDCFSID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function elogICDCFSsUpdate(ByVal Record As SIS.ELOG.elogICDCFSs) As SIS.ELOG.elogICDCFSs
      Dim _Rec As SIS.ELOG.elogICDCFSs = SIS.ELOG.elogICDCFSs.elogICDCFSsGetByID(Record.ICDCFSID)
      With _Rec
        .StuffingPointID = Record.StuffingPointID
        .Description = Record.Description
      End With
      Return SIS.ELOG.elogICDCFSs.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.ELOG.elogICDCFSs) As SIS.ELOG.elogICDCFSs
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogICDCFSsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ICDCFSID",SqlDbType.Int,11, Record.ICDCFSID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StuffingPointID",SqlDbType.Int,11, Iif(Record.StuffingPointID= "" ,Convert.DBNull, Record.StuffingPointID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,101, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
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
    Public Shared Function elogICDCFSsDelete(ByVal Record As SIS.ELOG.elogICDCFSs) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogICDCFSsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ICDCFSID",SqlDbType.Int,Record.ICDCFSID.ToString.Length, Record.ICDCFSID)
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
    Public Shared Function SelectelogICDCFSsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogICDCFSsAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(100, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.ELOG.elogICDCFSs = New SIS.ELOG.elogICDCFSs(Reader)
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
