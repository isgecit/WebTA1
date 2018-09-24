Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.WFDB
  Partial Public Class wfdbAttachments
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
    Public Shared Function UZ_wfdbAttachmentsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.WFDB.wfdbAttachments)
      Dim Results As List(Of SIS.WFDB.wfdbAttachments) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spwfdb_LG_AttachmentsSelectListSearch"
            Cmd.CommandText = "spwfdbAttachmentsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spwfdb_LG_AttachmentsSelectListFilteres"
            Cmd.CommandText = "spwfdbAttachmentsSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.WFDB.wfdbAttachments)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.WFDB.wfdbAttachments(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_wfdbAttachmentsInsert(ByVal Record As SIS.WFDB.wfdbAttachments) As SIS.WFDB.wfdbAttachments
      Dim _Result As SIS.WFDB.wfdbAttachments = wfdbAttachmentsInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_wfdbAttachmentsUpdate(ByVal Record As SIS.WFDB.wfdbAttachments) As SIS.WFDB.wfdbAttachments
      Dim _Result As SIS.WFDB.wfdbAttachments = wfdbAttachmentsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_wfdbAttachmentsDelete(ByVal Record As SIS.WFDB.wfdbAttachments) As Integer
      Dim _Result as Integer = wfdbAttachmentsDelete(Record)
      Return _Result
    End Function
    Public Shared Function UZ_wfdbAttachmentsGetByID(ByVal t_indx As String, ByVal t_dcid As String) As SIS.WFDB.wfdbAttachments
      Dim Results As SIS.WFDB.wfdbAttachments = wfdbAttachmentsGetByID(t_indx, t_dcid)
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_t_indx"), TextBox).Text = ""
        CType(.FindControl("F_t_prcd"), TextBox).Text = ""
        CType(.FindControl("F_t_fnam"), TextBox).Text = ""
        CType(.FindControl("F_t_lbcd"), TextBox).Text = ""
        CType(.FindControl("F_t_atby"), TextBox).Text = ""
        CType(.FindControl("F_t_aton"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
