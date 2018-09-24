Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.WFDB
  Partial Public Class wfdbNotes
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function UZ_wfdbNotesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal IndexValue As String) As List(Of SIS.WFDB.wfdbNotes)
      Dim Results As List(Of SIS.WFDB.wfdbNotes) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spwfdb_LG_NotesSelectListSearch"
            Cmd.CommandText = "spwfdbNotesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spwfdb_LG_NotesSelectListFilteres"
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
    Public Shared Function UZ_wfdbNotesInsert(ByVal Record As SIS.WFDB.wfdbNotes) As SIS.WFDB.wfdbNotes
      Dim _Result As SIS.WFDB.wfdbNotes = wfdbNotesInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_wfdbNotesUpdate(ByVal Record As SIS.WFDB.wfdbNotes) As SIS.WFDB.wfdbNotes
      Dim _Result As SIS.WFDB.wfdbNotes = wfdbNotesUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_wfdbNotesDelete(ByVal Record As SIS.WFDB.wfdbNotes) As Integer
      Dim _Result as Integer = wfdbNotesDelete(Record)
      Return _Result
    End Function
    Public Shared Function UZ_wfdbNotesGetByID(ByVal IndexValue As String, ByVal NotesId As String) As SIS.WFDB.wfdbNotes
      Dim Results As SIS.WFDB.wfdbNotes = wfdbNotesGetByID(IndexValue, NotesId)
      Return Results
    End Function
    '  'Select By ID One Record Filtered Overloaded GetByID
    'Public Shared Function UZ_wfdbNotesGetByID(ByVal IndexValue As String, ByVal NotesId As String) As SIS.WFDB.wfdbNotes
    '  Return UZ_wfdbNotesGetByID(IndexValue, NotesId)
    'End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_IndexValue"), TextBox).Text = ""
        CType(.FindControl("F_Title"), TextBox).Text = ""
        CType(.FindControl("F_SendEmailTo"), TextBox).Text = ""
        CType(.FindControl("F_Description"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
