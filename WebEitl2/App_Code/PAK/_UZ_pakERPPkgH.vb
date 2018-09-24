Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakERPPkgH
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
    Public Shared Function UZ_pakERPPkgHSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_orno As String) As List(Of SIS.PAK.pakERPPkgH)
      Dim Results As List(Of SIS.PAK.pakERPPkgH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_ERPPkgHSelectListSearch"
            Cmd.CommandText = "sppakERPPkgHSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_ERPPkgHSelectListFilteres"
            Cmd.CommandText = "sppakERPPkgHSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_t_orno",SqlDbType.VarChar,9, IIf(t_orno Is Nothing, String.Empty,t_orno))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakERPPkgH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakERPPkgH(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakERPPkgHInsert(ByVal Record As SIS.PAK.pakERPPkgH) As SIS.PAK.pakERPPkgH
      Dim _Result As SIS.PAK.pakERPPkgH = pakERPPkgHInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakERPPkgHUpdate(ByVal Record As SIS.PAK.pakERPPkgH) As SIS.PAK.pakERPPkgH
      Dim _Result As SIS.PAK.pakERPPkgH = pakERPPkgHUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakERPPkgHDelete(ByVal Record As SIS.PAK.pakERPPkgH) As Integer
      Dim _Result as Integer = pakERPPkgHDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_t_orno"), TextBox).Text = ""
        CType(.FindControl("F_t_pkno"), TextBox).Text = 0
        CType(.FindControl("F_t_srno"), TextBox).Text = 0
        CType(.FindControl("F_t_pkgn"), TextBox).Text = 0
        CType(.FindControl("F_t_rcno"), TextBox).Text = ""
        CType(.FindControl("F_t_isup"), TextBox).Text = ""
        CType(.FindControl("F_t_pkdt"), TextBox).Text = ""
        CType(.FindControl("F_t_ntwt"), TextBox).Text = 0
        CType(.FindControl("F_t_grwt"), TextBox).Text = 0
        CType(.FindControl("F_t_tnam"), TextBox).Text = ""
        CType(.FindControl("F_t_vhno"), TextBox).Text = ""
        CType(.FindControl("F_t_lrno"), TextBox).Text = ""
        CType(.FindControl("F_t_lrdt"), TextBox).Text = ""
        CType(.FindControl("F_t_Refcntd"), TextBox).Text = 0
        CType(.FindControl("F_t_Refcntu"), TextBox).Text = 0
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
