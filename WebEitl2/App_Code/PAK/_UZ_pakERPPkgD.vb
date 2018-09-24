Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakERPPkgD
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
    Public Shared Function UZ_pakERPPkgDSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_orno As String, ByVal t_pkno As Int32) As List(Of SIS.PAK.pakERPPkgD)
      Dim Results As List(Of SIS.PAK.pakERPPkgD) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_ERPPkgDSelectListSearch"
            Cmd.CommandText = "sppakERPPkgDSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_ERPPkgDSelectListFilteres"
            Cmd.CommandText = "sppakERPPkgDSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_t_orno",SqlDbType.VarChar,9, IIf(t_orno Is Nothing, String.Empty,t_orno))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_t_pkno",SqlDbType.Int,10, IIf(t_pkno = Nothing, 0,t_pkno))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakERPPkgD)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakERPPkgD(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakERPPkgDInsert(ByVal Record As SIS.PAK.pakERPPkgD) As SIS.PAK.pakERPPkgD
      Dim _Result As SIS.PAK.pakERPPkgD = pakERPPkgDInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakERPPkgDUpdate(ByVal Record As SIS.PAK.pakERPPkgD) As SIS.PAK.pakERPPkgD
      Dim _Result As SIS.PAK.pakERPPkgD = pakERPPkgDUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakERPPkgDDelete(ByVal Record As SIS.PAK.pakERPPkgD) As Integer
      Dim _Result as Integer = pakERPPkgDDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_t_orno"), TextBox).Text = ""
        CType(.FindControl("F_t_pkno"), TextBox).Text = 0
        CType(.FindControl("F_t_rcln"), TextBox).Text = 0
        CType(.FindControl("F_t_citm"), TextBox).Text = ""
        CType(.FindControl("F_t_pkgn"), TextBox).Text = 0
        CType(.FindControl("F_t_bomn"), TextBox).Text = 0
        CType(.FindControl("F_t_cuni"), TextBox).Text = ""
        CType(.FindControl("F_t_itmn"), TextBox).Text = 0
        CType(.FindControl("F_t_qnty"), TextBox).Text = 0
        CType(.FindControl("F_t_uwgt"), TextBox).Text = 0
        CType(.FindControl("F_t_twgt"), TextBox).Text = 0
        CType(.FindControl("F_t_docn"), TextBox).Text = ""
        CType(.FindControl("F_t_revn"), TextBox).Text = ""
        CType(.FindControl("F_t_ptyp"), TextBox).Text = ""
        CType(.FindControl("F_t_pmrk"), TextBox).Text = ""
        CType(.FindControl("F_t_leng"), TextBox).Text = 0
        CType(.FindControl("F_t_widt"), TextBox).Text = 0
        CType(.FindControl("F_t_hght"), TextBox).Text = 0
        CType(.FindControl("F_t_unit"), TextBox).Text = ""
        CType(.FindControl("F_t_rcno"), TextBox).Text = ""
        CType(.FindControl("F_t_srno"), TextBox).Text = 0
        CType(.FindControl("F_t_Refcntd"), TextBox).Text = 0
        CType(.FindControl("F_t_Refcntu"), TextBox).Text = 0
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
