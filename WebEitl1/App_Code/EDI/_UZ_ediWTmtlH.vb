Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.EDI
  Partial Public Class ediWTmtlH
    Public ReadOnly Property GetSDownloadAllLink() As String
      Get
        Return "javascript:window.open('" & HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath & "/download.aspx?stmtl=" & PrimaryKey & "', 'win" & PrimaryKey & "', 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1'); return false;"
      End Get
    End Property
    Public ReadOnly Property GetDownloadAllLink() As String
      Get
        Return "javascript:window.open('" & HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath & "/download.aspx?tmtl=" & PrimaryKey & "', 'win" & PrimaryKey & "', 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1'); return false;"
      End Get
    End Property
    Public Shadows ReadOnly Property GetPrintLink() As String
      Get
        Return "javascript:window.open('" & HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath & "/ediWRTmtlH.aspx?pk=" & PrimaryKey & "', 'win" & PrimaryKey & "', 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1'); return false;"
      End Get
    End Property
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
      Dim mRet As Boolean = False
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
    Public Shared Function UZ_ediWTmtlHSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_tran As String) As List(Of SIS.EDI.ediWTmtlH)
      Dim Results As List(Of SIS.EDI.ediWTmtlH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spedi_LG_WTmtlHSelectListSearch"
            Cmd.CommandText = "spediWTmtlHSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spedi_LG_WTmtlHSelectListFilteres"
            Cmd.CommandText = "spediWTmtlHSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_t_tran", SqlDbType.VarChar, 9, IIf(t_tran Is Nothing, String.Empty, t_tran))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.EDI.ediWTmtlH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.EDI.ediWTmtlH(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function GetByReceiptNoRevisionNo(ByVal ReceiptNo As String, ByVal RevisionNo As String) As SIS.EDI.ediWTmtlH
      Dim Ret As SIS.EDI.ediWTmtlH = Nothing
      Dim Sql As String = ""
      Sql &= "  select * "
      Sql &= "  from tdmisg134200  "
      Sql &= "  where t_rcno ='" & ReceiptNo & "'"
      Sql &= "  and t_revn ='" & RevisionNo & "'"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If (Reader.Read()) Then
            Ret = New SIS.EDI.ediWTmtlH(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Ret
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_t_tran"), TextBox).Text = ""
          CType(.FindControl("F_t_type"), TextBox).Text = 0
          CType(.FindControl("F_t_bpid"), TextBox).Text = ""
          CType(.FindControl("F_t_cadr"), TextBox).Text = ""
          CType(.FindControl("F_t_cprj"), TextBox).Text = ""
          CType(.FindControl("F_t_logn"), TextBox).Text = ""
          CType(.FindControl("F_t_subj"), TextBox).Text = ""
          CType(.FindControl("F_t_remk"), TextBox).Text = ""
          CType(.FindControl("F_t_issu"), TextBox).Text = ""
          CType(.FindControl("F_t_stat"), TextBox).Text = 0
          CType(.FindControl("F_t_ofbp"), TextBox).Text = ""
          CType(.FindControl("F_t_vadr"), TextBox).Text = ""
          CType(.FindControl("F_t_padr"), TextBox).Text = ""
          CType(.FindControl("F_t_dprj"), TextBox).Text = ""
          CType(.FindControl("F_t_user"), TextBox).Text = ""
          CType(.FindControl("F_t_date"), TextBox).Text = ""
          CType(.FindControl("F_t_subt"), TextBox).Text = 0
          CType(.FindControl("F_t_refr"), TextBox).Text = ""
          CType(.FindControl("F_t_appr"), TextBox).Text = 0
          CType(.FindControl("F_t_rejc"), TextBox).Text = 0
          CType(.FindControl("F_t_rekm"), TextBox).Text = ""
          CType(.FindControl("F_t_apdt"), TextBox).Text = ""
          CType(.FindControl("F_t_apsu"), TextBox).Text = ""
          CType(.FindControl("F_t_irmk"), TextBox).Text = ""
          CType(.FindControl("F_t_iisu"), TextBox).Text = 0
          CType(.FindControl("F_t_retn"), TextBox).Text = 0
          CType(.FindControl("F_t_smdt"), TextBox).Text = ""
          CType(.FindControl("F_t_isby"), TextBox).Text = ""
          CType(.FindControl("F_t_isdt"), TextBox).Text = ""
          CType(.FindControl("F_t_Refcntd"), TextBox).Text = 0
          CType(.FindControl("F_t_Refcntu"), TextBox).Text = 0
          CType(.FindControl("F_t_edif"), TextBox).Text = 0
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
