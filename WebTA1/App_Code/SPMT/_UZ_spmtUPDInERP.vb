Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.SPMT
  Partial Public Class spmtUPDInERP
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
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property RejectWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property RejectWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function InitiateWF(ByVal t_sour As String, ByVal t_ninv As Int32) As SIS.SPMT.spmtUPDInERP
      Dim Results As SIS.SPMT.spmtUPDInERP = spmtUPDInERPGetByID(t_sour, t_ninv)
      Return Results
    End Function
    Public Shared Function RejectWF(ByVal t_sour As String, ByVal t_ninv As Int32) As SIS.SPMT.spmtUPDInERP
      Dim Results As SIS.SPMT.spmtUPDInERP = spmtUPDInERPGetByID(t_sour, t_ninv)
      Return Results
    End Function
    Public Shared Function UZ_spmtUPDInERPSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.SPMT.spmtUPDInERP)
      Dim Results As List(Of SIS.SPMT.spmtUPDInERP) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spspmt_LG_UPDInERPSelectListSearch"
            Cmd.CommandText = "spspmtUPDInERPSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spspmt_LG_UPDInERPSelectListFilteres"
            Cmd.CommandText = "spspmtUPDInERPSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.SPMT.spmtUPDInERP)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.SPMT.spmtUPDInERP(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_t_sour"), TextBox).Text = ""
        CType(.FindControl("F_t_ninv"), TextBox).Text = 0
        CType(.FindControl("F_t_irdt"), TextBox).Text = ""
        CType(.FindControl("F_t_type"), TextBox).Text = ""
        CType(.FindControl("F_t_isup"), TextBox).Text = ""
        CType(.FindControl("F_t_idat"), TextBox).Text = ""
        CType(.FindControl("F_t_brmk"), TextBox).Text = ""
        CType(.FindControl("F_t_brac"), TextBox).Text = ""
        CType(.FindControl("F_t_payd"), TextBox).Text = 0
        CType(.FindControl("F_t_hodc"), TextBox).Text = ""
        CType(.FindControl("F_t_cprj"), TextBox).Text = ""
        CType(.FindControl("F_t_cspa"), TextBox).Text = ""
        CType(.FindControl("F_t_emno"), TextBox).Text = ""
        CType(.FindControl("F_t_cofc"), TextBox).Text = ""
        CType(.FindControl("F_t_dimx"), TextBox).Text = ""
        CType(.FindControl("F_t_gstn_c"), TextBox).Text = 0
        CType(.FindControl("F_t_gstn_b"), TextBox).Text = 0
        CType(.FindControl("F_t_ifbp"), TextBox).Text = ""
        CType(.FindControl("F_t_code"), TextBox).Text = ""
        CType(.FindControl("F_t_unit"), TextBox).Text = ""
        CType(.FindControl("F_t_ityp"), TextBox).Text = 0
        CType(.FindControl("F_t_sste"), TextBox).Text = ""
        CType(.FindControl("F_t_qnty"), TextBox).Text = 0
        CType(.FindControl("F_t_assv"), TextBox).Text = 0
        CType(.FindControl("F_t_vamt"), TextBox).Text = 0
        CType(.FindControl("F_t_cess"), TextBox).Text = 0
        CType(.FindControl("F_t_cmnt"), TextBox).Text = 0
        CType(.FindControl("F_t_tgst"), TextBox).Text = 0
        CType(.FindControl("F_t_tamt"), TextBox).Text = 0
        CType(.FindControl("F_t_grmk"), TextBox).Text = ""
        CType(.FindControl("F_t_ccur"), TextBox).Text = ""
        CType(.FindControl("F_t_conv"), TextBox).Text = 0
        CType(.FindControl("F_t_tamh"), TextBox).Text = 0
        CType(.FindControl("F_t_ptyp"), TextBox).Text = ""
        CType(.FindControl("F_t_irat"), TextBox).Text = 0
        CType(.FindControl("F_t_iamt"), TextBox).Text = 0
        CType(.FindControl("F_t_srat"), TextBox).Text = 0
        CType(.FindControl("F_t_samt"), TextBox).Text = 0
        CType(.FindControl("F_t_crat"), TextBox).Text = 0
        CType(.FindControl("F_t_camt"), TextBox).Text = 0
        CType(.FindControl("F_t_ttyp"), TextBox).Text = ""
        CType(.FindControl("F_t_docn"), TextBox).Text = 0
        CType(.FindControl("F_t_comp"), TextBox).Text = 0
        CType(.FindControl("F_t_upby"), TextBox).Text = ""
        CType(.FindControl("F_t_updt"), TextBox).Text = ""
        CType(.FindControl("F_t_Refcntd"), TextBox).Text = 0
        CType(.FindControl("F_t_Refcntu"), TextBox).Text = 0
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
