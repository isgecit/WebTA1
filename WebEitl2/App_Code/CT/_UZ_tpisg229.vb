Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TPISG
  Partial Public Class tpisg229
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
    Public Shared Function UZ_tpisg229SelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.TPISG.tpisg229)
      Dim Results As List(Of SIS.TPISG.tpisg229) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptpisg_LG_229SelectListSearch"
            Cmd.CommandText = "sptpisg229SelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptpisg_LG_229SelectListFilteres"
            Cmd.CommandText = "sptpisg229SelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TPISG.tpisg229)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TPISG.tpisg229(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_tpisg229Insert(ByVal Record As SIS.TPISG.tpisg229) As SIS.TPISG.tpisg229
      Dim _Result As SIS.TPISG.tpisg229 = tpisg229Insert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_tpisg229Update(ByVal Record As SIS.TPISG.tpisg229) As SIS.TPISG.tpisg229
      Dim _Result As SIS.TPISG.tpisg229 = tpisg229Update(Record)
      Return _Result
    End Function
    Public Shared Function UZ_tpisg229Delete(ByVal Record As SIS.TPISG.tpisg229) As Integer
      Dim _Result As Integer = tpisg229Delete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_t_trdt"), TextBox).Text = ""
          CType(.FindControl("F_t_bohd"), TextBox).Text = ""
          CType(.FindControl("F_t_indv"), TextBox).Text = ""
          CType(.FindControl("F_t_srno"), TextBox).Text = 0
          CType(.FindControl("F_t_stat"), TextBox).Text = ""
          CType(.FindControl("F_t_proj"), TextBox).Text = ""
          CType(.FindControl("F_t_elem"), TextBox).Text = ""
          CType(.FindControl("F_t_user"), TextBox).Text = ""
          CType(.FindControl("F_t_Refcntd"), TextBox).Text = 0
          CType(.FindControl("F_t_Refcntu"), TextBox).Text = 0
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
