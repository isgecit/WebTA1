Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakDocuments
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
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function UZ_pakDocumentsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.PAK.pakDocuments)
      Dim Results As List(Of SIS.PAK.pakDocuments) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_DocumentsSelectListSearch"
            Cmd.CommandText = "sppakDocumentsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_DocumentsSelectListFilteres"
            Cmd.CommandText = "sppakDocumentsSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakDocuments)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakDocuments(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakDocumentsInsert(ByVal Record As SIS.PAK.pakDocuments) As SIS.PAK.pakDocuments
      Dim _Result As SIS.PAK.pakDocuments = pakDocumentsInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakDocumentsUpdate(ByVal Record As SIS.PAK.pakDocuments) As SIS.PAK.pakDocuments
      Dim _Result As SIS.PAK.pakDocuments = pakDocumentsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakDocumentsDelete(ByVal Record As SIS.PAK.pakDocuments) As Integer
      Dim _Result as Integer = pakDocumentsDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_DocumentNo"), TextBox).Text = ""
        CType(.FindControl("F_DocumentID"), TextBox).Text = ""
        CType(.FindControl("F_DocumentRevision"), TextBox).Text = ""
        CType(.FindControl("F_Description"), TextBox).Text = ""
        CType(.FindControl("F_ExternalDocument"), CheckBox).Checked = False
        CType(.FindControl("F_Filename"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function pakDocumentsSelectByDocRevID(ByVal DocumentID As String, ByVal DocumentRevision As String) As SIS.PAK.pakDocuments
      Dim Results As SIS.PAK.pakDocuments = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppak_LG_DocumentsSelectByDocRevID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentID", SqlDbType.NVarChar, DocumentID.Length, DocumentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentRevision", SqlDbType.NVarChar, DocumentRevision.Length, DocumentRevision)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakDocuments(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakDocumentsSelectByDocID(ByVal DocumentID As String) As List(Of SIS.PAK.pakDocuments)
      Dim Results As List(Of SIS.PAK.pakDocuments) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppak_LG_DocumentsSelectByDocID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentID", SqlDbType.NVarChar, DocumentID.Length, DocumentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Results = New List(Of SIS.PAK.pakDocuments)
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakDocuments(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
  End Class
End Namespace
