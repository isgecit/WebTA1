Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakERPRecH
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
    Public Shared Function UZ_pakERPRecHSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.PAK.pakERPRecH)
      Dim Results As List(Of SIS.PAK.pakERPRecH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_ERPRecHSelectListSearch"
            Cmd.CommandText = "sppakERPRecHSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_ERPRecHSelectListFilteres"
            Cmd.CommandText = "sppakERPRecHSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakERPRecH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakERPRecH(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakERPRecHInsert(ByVal Record As SIS.PAK.pakERPRecH) As SIS.PAK.pakERPRecH
      Dim _Result As SIS.PAK.pakERPRecH = pakERPRecHInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakERPRecHUpdate(ByVal Record As SIS.PAK.pakERPRecH) As SIS.PAK.pakERPRecH
      Dim _Result As SIS.PAK.pakERPRecH = pakERPRecHUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakERPRecHDelete(ByVal Record As SIS.PAK.pakERPRecH) As Integer
      Dim _Result as Integer = pakERPRecHDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_t_rcno"), TextBox).Text = ""
        CType(.FindControl("F_t_revn"), TextBox).Text = ""
        CType(.FindControl("F_t_cprj"), TextBox).Text = ""
        CType(.FindControl("F_t_item"), TextBox).Text = ""
        CType(.FindControl("F_t_bpid"), TextBox).Text = ""
        CType(.FindControl("F_t_nama"), TextBox).Text = ""
        CType(.FindControl("F_t_stat"), TextBox).Text = 0
        CType(.FindControl("F_t_user"), TextBox).Text = ""
        CType(.FindControl("F_t_date"), TextBox).Text = ""
        CType(.FindControl("F_t_sent_1"), TextBox).Text = 0
        CType(.FindControl("F_t_sent_2"), TextBox).Text = 0
        CType(.FindControl("F_t_sent_3"), TextBox).Text = 0
        CType(.FindControl("F_t_sent_4"), TextBox).Text = 0
        CType(.FindControl("F_t_sent_5"), TextBox).Text = 0
        CType(.FindControl("F_t_sent_6"), TextBox).Text = 0
        CType(.FindControl("F_t_sent_7"), TextBox).Text = 0
        CType(.FindControl("F_t_rece_1"), TextBox).Text = 0
        CType(.FindControl("F_t_rece_2"), TextBox).Text = 0
        CType(.FindControl("F_t_rece_3"), TextBox).Text = 0
        CType(.FindControl("F_t_rece_4"), TextBox).Text = 0
        CType(.FindControl("F_t_rece_5"), TextBox).Text = 0
        CType(.FindControl("F_t_rece_6"), TextBox).Text = 0
        CType(.FindControl("F_t_rece_7"), TextBox).Text = 0
        CType(.FindControl("F_t_suer"), TextBox).Text = ""
        CType(.FindControl("F_t_sdat"), TextBox).Text = ""
        CType(.FindControl("F_t_appr"), TextBox).Text = ""
        CType(.FindControl("F_t_adat"), TextBox).Text = ""
        CType(.FindControl("F_t_subm_1"), TextBox).Text = 0
        CType(.FindControl("F_t_subm_2"), TextBox).Text = 0
        CType(.FindControl("F_t_subm_3"), TextBox).Text = 0
        CType(.FindControl("F_t_subm_4"), TextBox).Text = 0
        CType(.FindControl("F_t_subm_5"), TextBox).Text = 0
        CType(.FindControl("F_t_subm_6"), TextBox).Text = 0
        CType(.FindControl("F_t_subm_7"), TextBox).Text = 0
        CType(.FindControl("F_t_orno"), TextBox).Text = ""
        CType(.FindControl("F_t_pono"), TextBox).Text = 0
        CType(.FindControl("F_t_trno"), TextBox).Text = ""
        CType(.FindControl("F_t_Refcntd"), TextBox).Text = 0
        CType(.FindControl("F_t_Refcntu"), TextBox).Text = 0
        CType(.FindControl("F_t_docn"), TextBox).Text = ""
        CType(.FindControl("F_t_eunt"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
