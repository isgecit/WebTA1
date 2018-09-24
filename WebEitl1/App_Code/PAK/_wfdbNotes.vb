Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.WFDB
  <DataObject()> _
  Partial Public Class wfdbNotes
    Private Shared _RecordCount As Integer
    Private _IndexValue As String = ""
    Private _Title As String = ""
    Private _UserId As String = ""
    Private _Created_Date As String = ""
    Private _SendEmailTo As String = ""
    Private _NotesId As String = ""
    Private _Description As String = ""
    Private _Notes_RunningNo As Int32 = 0
    Private _NotesHandle As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _FK_Note_Notes_UserId As SIS.QCM.qcmUsers = Nothing
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
    Public Property IndexValue() As String
      Get
        Return _IndexValue
      End Get
      Set(ByVal value As String)
        _IndexValue = value
      End Set
    End Property
    Public Property Title() As String
      Get
        Return _Title
      End Get
      Set(ByVal value As String)
        _Title = value
      End Set
    End Property
    Public Property UserId() As String
      Get
        Return _UserId
      End Get
      Set(ByVal value As String)
        _UserId = value
      End Set
    End Property
    Public Property Created_Date() As String
      Get
        If Not _Created_Date = String.Empty Then
          Return Convert.ToDateTime(_Created_Date).ToString("dd/MM/yyyy")
        End If
        Return _Created_Date
      End Get
      Set(ByVal value As String)
         _Created_Date = value
      End Set
    End Property
    Public Property SendEmailTo() As String
      Get
        Return _SendEmailTo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SendEmailTo = ""
         Else
           _SendEmailTo = value
         End If
      End Set
    End Property
    Public Property NotesId() As String
      Get
        Return _NotesId
      End Get
      Set(ByVal value As String)
        _NotesId = value
      End Set
    End Property
    Public Property Description() As String
      Get
        Return _Description
      End Get
      Set(ByVal value As String)
        _Description = value
      End Set
    End Property
    Public Property Notes_RunningNo() As Int32
      Get
        Return _Notes_RunningNo
      End Get
      Set(ByVal value As Int32)
        _Notes_RunningNo = value
      End Set
    End Property
    Public Property NotesHandle() As String
      Get
        Return _NotesHandle
      End Get
      Set(ByVal value As String)
        _NotesHandle = value
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
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _IndexValue & "|" & _NotesId
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
    Public Class PKwfdbNotes
      Private _IndexValue As String = ""
      Private _NotesId As String = ""
      Public Property IndexValue() As String
        Get
          Return _IndexValue
        End Get
        Set(ByVal value As String)
          _IndexValue = value
        End Set
      End Property
      Public Property NotesId() As String
        Get
          Return _NotesId
        End Get
        Set(ByVal value As String)
          _NotesId = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_Note_Notes_UserId() As SIS.QCM.qcmUsers
      Get
        If _FK_Note_Notes_UserId Is Nothing Then
          _FK_Note_Notes_UserId = SIS.QCM.qcmUsers.qcmUsersGetByID(_UserId)
        End If
        Return _FK_Note_Notes_UserId
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfdbNotesGetNewRecord() As SIS.WFDB.wfdbNotes
      Return New SIS.WFDB.wfdbNotes()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfdbNotesGetByID(ByVal IndexValue As String, ByVal NotesId As String) As SIS.WFDB.wfdbNotes
      Dim Results As SIS.WFDB.wfdbNotes = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfdbNotesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndexValue",SqlDbType.VarChar,IndexValue.ToString.Length, IndexValue)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NotesId",SqlDbType.VarChar,NotesId.ToString.Length, NotesId)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.WFDB.wfdbNotes(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfdbNotesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal IndexValue As String) As List(Of SIS.WFDB.wfdbNotes)
      Dim Results As List(Of SIS.WFDB.wfdbNotes) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spwfdbNotesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spwfdbNotesSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_IndexValue",SqlDbType.VarChar,200, IIf(IndexValue Is Nothing, String.Empty,IndexValue))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.WFDB.wfdbNotes)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.WFDB.wfdbNotes(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function wfdbNotesSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal IndexValue As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfdbNotesGetByID(ByVal IndexValue As String, ByVal NotesId As String, ByVal Filter_IndexValue As String) As SIS.WFDB.wfdbNotes
      Return UZ_wfdbNotesGetByID(IndexValue, NotesId)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function wfdbNotesInsert(ByVal Record As SIS.WFDB.wfdbNotes) As SIS.WFDB.wfdbNotes
      Dim _Rec As SIS.WFDB.wfdbNotes = SIS.WFDB.wfdbNotes.wfdbNotesGetNewRecord()
      With _Rec
        .IndexValue = Record.IndexValue
        .Title = Record.Title
        .UserId = Record.UserId
        .Created_Date = Record.Created_Date
        .SendEmailTo = Record.SendEmailTo
        .NotesId = Record.NotesId
        .Description = Record.Description
        .Notes_RunningNo = Record.Notes_RunningNo
        .NotesHandle = Record.NotesHandle
      End With
      Return SIS.WFDB.wfdbNotes.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.WFDB.wfdbNotes) As SIS.WFDB.wfdbNotes
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfdbNotesInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndexValue",SqlDbType.VarChar,201, Record.IndexValue)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Title",SqlDbType.VarChar,4001, Record.Title)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserId",SqlDbType.VarChar,9, Record.UserId)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Created_Date",SqlDbType.DateTime,21, Record.Created_Date)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SendEmailTo",SqlDbType.VarChar,4001, Iif(Record.SendEmailTo= "" ,Convert.DBNull, Record.SendEmailTo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NotesId",SqlDbType.VarChar,201, Record.NotesId)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.VarChar,4001, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Notes_RunningNo",SqlDbType.Int,11, Record.Notes_RunningNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NotesHandle",SqlDbType.VarChar,201, Record.NotesHandle)
          Cmd.Parameters.Add("@Return_IndexValue", SqlDbType.VarChar, 201)
          Cmd.Parameters("@Return_IndexValue").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_NotesId", SqlDbType.VarChar, 201)
          Cmd.Parameters("@Return_NotesId").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.IndexValue = Cmd.Parameters("@Return_IndexValue").Value
          Record.NotesId = Cmd.Parameters("@Return_NotesId").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function wfdbNotesUpdate(ByVal Record As SIS.WFDB.wfdbNotes) As SIS.WFDB.wfdbNotes
      Dim _Rec As SIS.WFDB.wfdbNotes = SIS.WFDB.wfdbNotes.UZ_wfdbNotesGetByID(Record.IndexValue, Record.NotesId)
      With _Rec
        .Title = Record.Title
        .UserId = Record.UserId
        .Created_Date = Record.Created_Date
        .SendEmailTo = Record.SendEmailTo
        .Description = Record.Description
        .Notes_RunningNo = Record.Notes_RunningNo
        .NotesHandle = Record.NotesHandle
      End With
      Return SIS.WFDB.wfdbNotes.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.WFDB.wfdbNotes) As SIS.WFDB.wfdbNotes
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfdbNotesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_IndexValue",SqlDbType.VarChar,201, Record.IndexValue)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_NotesId",SqlDbType.VarChar,201, Record.NotesId)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndexValue",SqlDbType.VarChar,201, Record.IndexValue)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Title",SqlDbType.VarChar,4001, Record.Title)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserId",SqlDbType.VarChar,9, Record.UserId)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Created_Date",SqlDbType.DateTime,21, Record.Created_Date)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SendEmailTo",SqlDbType.VarChar,4001, Iif(Record.SendEmailTo= "" ,Convert.DBNull, Record.SendEmailTo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NotesId",SqlDbType.VarChar,201, Record.NotesId)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.VarChar,4001, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Notes_RunningNo",SqlDbType.Int,11, Record.Notes_RunningNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NotesHandle",SqlDbType.VarChar,201, Record.NotesHandle)
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
    Public Shared Function wfdbNotesDelete(ByVal Record As SIS.WFDB.wfdbNotes) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfdbNotesDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_IndexValue",SqlDbType.VarChar,Record.IndexValue.ToString.Length, Record.IndexValue)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_NotesId",SqlDbType.VarChar,Record.NotesId.ToString.Length, Record.NotesId)
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
