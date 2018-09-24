Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakERPRecD
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
    Public Shared Function UZ_pakERPRecDSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_rcno As String, ByVal t_revn As String) As List(Of SIS.PAK.pakERPRecD)
      Dim Results As List(Of SIS.PAK.pakERPRecD) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_ERPRecDSelectListSearch"
            Cmd.CommandText = "sppakERPRecDSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_ERPRecDSelectListFilteres"
            Cmd.CommandText = "sppakERPRecDSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_t_rcno",SqlDbType.VarChar,9, IIf(t_rcno Is Nothing, String.Empty,t_rcno))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_t_revn",SqlDbType.VarChar,20, IIf(t_revn Is Nothing, String.Empty,t_revn))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakERPRecD)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakERPRecD(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakERPRecDInsert(ByVal Record As SIS.PAK.pakERPRecD) As SIS.PAK.pakERPRecD
      Dim _Result As SIS.PAK.pakERPRecD = pakERPRecDInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakERPRecDUpdate(ByVal Record As SIS.PAK.pakERPRecD) As SIS.PAK.pakERPRecD
      Dim _Result As SIS.PAK.pakERPRecD = pakERPRecDUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakERPRecDDelete(ByVal Record As SIS.PAK.pakERPRecD) As Integer
      Dim _Result as Integer = pakERPRecDDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_t_rcno"), TextBox).Text = ""
        CType(.FindControl("F_t_revn"), TextBox).Text = ""
        CType(.FindControl("F_t_srno"), TextBox).Text = 0
        CType(.FindControl("F_t_docn"), TextBox).Text = ""
        CType(.FindControl("F_t_revi"), TextBox).Text = ""
        CType(.FindControl("F_t_dsca"), TextBox).Text = ""
        CType(.FindControl("F_t_idoc"), TextBox).Text = ""
        CType(.FindControl("F_t_irev"), TextBox).Text = ""
        CType(.FindControl("F_t_date"), TextBox).Text = ""
        CType(.FindControl("F_t_remk"), TextBox).Text = ""
        CType(.FindControl("F_t_proc"), TextBox).Text = 0
        CType(.FindControl("F_t_Refcntd"), TextBox).Text = 0
        CType(.FindControl("F_t_Refcntu"), TextBox).Text = 0
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
