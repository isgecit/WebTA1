Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.SPMT
  <DataObject()> _
  Partial Public Class spmtUPDInERP
    Private Shared _RecordCount As Integer
    Private _t_sour As String = ""
    Private _t_ninv As Int32 = 0
    Private _t_irdt As String = ""
    Private _t_type As String = ""
    Private _t_isup As String = ""
    Private _t_idat As String = ""
    Private _t_brmk As String = ""
    Private _t_brac As String = ""
    Private _t_payd As Int32 = 0
    Private _t_hodc As String = ""
    Private _t_cprj As String = ""
    Private _t_cspa As String = ""
    Private _t_emno As String = ""
    Private _t_cofc As String = ""
    Private _t_dimx As String = ""
    Private _t_gstn_c As String = ""
    Private _t_gstn_b As String = ""
    Private _t_ifbp As String = ""
    Private _t_code As String = ""
    Private _t_unit As String = ""
    Private _t_ityp As Int32 = 0
    Private _t_sste As String = ""
    Private _t_qnty As Double = 0
    Private _t_assv As Double = 0
    Private _t_vamt As Double = 0
    Private _t_cess As Double = 0
    Private _t_cmnt As Double = 0
    Private _t_tgst As Double = 0
    Private _t_tamt As Double = 0
    Private _t_grmk As String = ""
    Private _t_ccur As String = ""
    Private _t_conv As Double = 0
    Private _t_tamh As Double = 0
    Private _t_ptyp As String = ""
    Private _t_irat As Double = 0
    Private _t_iamt As Double = 0
    Private _t_srat As Double = 0
    Private _t_samt As Double = 0
    Private _t_crat As Double = 0
    Private _t_camt As Double = 0
    Private _t_ttyp As String = ""
    Private _t_docn As Int32 = 0
    Private _t_comp As Int32 = 0
    Private _t_upby As String = ""
    Private _t_updt As String = ""
    Private _t_Refcntd As Int32 = 0
    Private _t_Refcntu As Int32 = 0
    Public Property t_nama As String = ""
    Public Property t_ucod As String = ""
    Public Property t_unam As String = ""
    Public Property t_posu As String = ""
    Public ReadOnly Property ForeColor() As System.Drawing.Color
      Get
        Dim mRet As System.Drawing.Color = Drawing.Color.Blue
        Try
          mRet = GetColor()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Visible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Enable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Property t_sour() As String
      Get
        Return _t_sour
      End Get
      Set(ByVal value As String)
        _t_sour = value
      End Set
    End Property
    Public Property t_ninv() As Int32
      Get
        Return _t_ninv
      End Get
      Set(ByVal value As Int32)
        _t_ninv = value
      End Set
    End Property
    Public Property t_irdt() As String
      Get
        If Not _t_irdt = String.Empty Then
          Return Convert.ToDateTime(_t_irdt).ToString("dd/MM/yyyy")
        End If
        Return _t_irdt
      End Get
      Set(ByVal value As String)
        If value = String.Empty Then
          value = "01/01/1985"
        End If
        _t_irdt = value
      End Set
    End Property
    Public Property t_type() As String
      Get
        Return _t_type
      End Get
      Set(ByVal value As String)
        _t_type = value
      End Set
    End Property
    Public Property t_isup() As String
      Get
        Return _t_isup
      End Get
      Set(ByVal value As String)
        _t_isup = value
      End Set
    End Property
    Public Property t_idat() As String
      Get
        If Not _t_idat = String.Empty Then
          Return Convert.ToDateTime(_t_idat).ToString("dd/MM/yyyy")
        End If
        Return _t_idat
      End Get
      Set(ByVal value As String)
        If value = String.Empty Then
          value = "01/01/1985"
        End If
        _t_idat = value
      End Set
    End Property
    Public Property t_brmk() As String
      Get
        Return _t_brmk
      End Get
      Set(ByVal value As String)
        _t_brmk = value
      End Set
    End Property
    Public Property t_brac() As String
      Get
        Return _t_brac
      End Get
      Set(ByVal value As String)
        _t_brac = value
      End Set
    End Property
    Public Property t_payd() As Int32
      Get
        Return _t_payd
      End Get
      Set(ByVal value As Int32)
        _t_payd = value
      End Set
    End Property
    Public Property t_hodc() As String
      Get
        Return _t_hodc
      End Get
      Set(ByVal value As String)
        _t_hodc = value
      End Set
    End Property
    Public Property t_cprj() As String
      Get
        Return _t_cprj
      End Get
      Set(ByVal value As String)
        _t_cprj = value
      End Set
    End Property
    Public Property t_cspa() As String
      Get
        Return _t_cspa
      End Get
      Set(ByVal value As String)
        _t_cspa = value
      End Set
    End Property
    Public Property t_emno() As String
      Get
        Return _t_emno
      End Get
      Set(ByVal value As String)
        _t_emno = value
      End Set
    End Property
    Public Property t_cofc() As String
      Get
        Return _t_cofc
      End Get
      Set(ByVal value As String)
        _t_cofc = value
      End Set
    End Property
    Public Property t_dimx() As String
      Get
        Return _t_dimx
      End Get
      Set(ByVal value As String)
        _t_dimx = value
      End Set
    End Property
    Public Property t_gstn_c() As String
      Get
        Return _t_gstn_c
      End Get
      Set(ByVal value As String)
        _t_gstn_c = value
      End Set
    End Property
    Public Property t_gstn_b() As String
      Get
        Return _t_gstn_b
      End Get
      Set(ByVal value As String)
        _t_gstn_b = value
      End Set
    End Property
    Public Property t_ifbp() As String
      Get
        Return _t_ifbp
      End Get
      Set(ByVal value As String)
        _t_ifbp = value
      End Set
    End Property
    Public Property t_code() As String
      Get
        Return _t_code
      End Get
      Set(ByVal value As String)
        _t_code = value
      End Set
    End Property
    Public Property t_unit() As String
      Get
        Return _t_unit
      End Get
      Set(ByVal value As String)
        _t_unit = value
      End Set
    End Property
    Public Property t_ityp() As Int32
      Get
        Return _t_ityp
      End Get
      Set(ByVal value As Int32)
        _t_ityp = value
      End Set
    End Property
    Public Property t_sste() As String
      Get
        Return _t_sste
      End Get
      Set(ByVal value As String)
        _t_sste = value
      End Set
    End Property
    Public Property t_qnty() As Double
      Get
        Return _t_qnty
      End Get
      Set(ByVal value As Double)
        _t_qnty = value
      End Set
    End Property
    Public Property t_assv() As Double
      Get
        Return _t_assv
      End Get
      Set(ByVal value As Double)
        _t_assv = value
      End Set
    End Property
    Public Property t_vamt() As Double
      Get
        Return _t_vamt
      End Get
      Set(ByVal value As Double)
        _t_vamt = value
      End Set
    End Property
    Public Property t_cess() As Double
      Get
        Return _t_cess
      End Get
      Set(ByVal value As Double)
        _t_cess = value
      End Set
    End Property
    Public Property t_cmnt() As Double
      Get
        Return _t_cmnt
      End Get
      Set(ByVal value As Double)
        _t_cmnt = value
      End Set
    End Property
    Public Property t_tgst() As Double
      Get
        Return _t_tgst
      End Get
      Set(ByVal value As Double)
        _t_tgst = value
      End Set
    End Property
    Public Property t_tamt() As Double
      Get
        Return _t_tamt
      End Get
      Set(ByVal value As Double)
        _t_tamt = value
      End Set
    End Property
    Public Property t_grmk() As String
      Get
        Return _t_grmk
      End Get
      Set(ByVal value As String)
        _t_grmk = value
      End Set
    End Property
    Public Property t_ccur() As String
      Get
        Return _t_ccur
      End Get
      Set(ByVal value As String)
        _t_ccur = value
      End Set
    End Property
    Public Property t_conv() As Double
      Get
        Return _t_conv
      End Get
      Set(ByVal value As Double)
        _t_conv = value
      End Set
    End Property
    Public Property t_tamh() As Double
      Get
        Return _t_tamh
      End Get
      Set(ByVal value As Double)
        _t_tamh = value
      End Set
    End Property
    Public Property t_ptyp() As String
      Get
        Return _t_ptyp
      End Get
      Set(ByVal value As String)
        _t_ptyp = value
      End Set
    End Property
    Public Property t_irat() As Double
      Get
        Return _t_irat
      End Get
      Set(ByVal value As Double)
        _t_irat = value
      End Set
    End Property
    Public Property t_iamt() As Double
      Get
        Return _t_iamt
      End Get
      Set(ByVal value As Double)
        _t_iamt = value
      End Set
    End Property
    Public Property t_srat() As Double
      Get
        Return _t_srat
      End Get
      Set(ByVal value As Double)
        _t_srat = value
      End Set
    End Property
    Public Property t_samt() As Double
      Get
        Return _t_samt
      End Get
      Set(ByVal value As Double)
        _t_samt = value
      End Set
    End Property
    Public Property t_crat() As Double
      Get
        Return _t_crat
      End Get
      Set(ByVal value As Double)
        _t_crat = value
      End Set
    End Property
    Public Property t_camt() As Double
      Get
        Return _t_camt
      End Get
      Set(ByVal value As Double)
        _t_camt = value
      End Set
    End Property
    Public Property t_ttyp() As String
      Get
        Return _t_ttyp
      End Get
      Set(ByVal value As String)
        _t_ttyp = value
      End Set
    End Property
    Public Property t_docn() As Int32
      Get
        Return _t_docn
      End Get
      Set(ByVal value As Int32)
        _t_docn = value
      End Set
    End Property
    Public Property t_comp() As Int32
      Get
        Return _t_comp
      End Get
      Set(ByVal value As Int32)
        _t_comp = value
      End Set
    End Property
    Public Property t_upby() As String
      Get
        Return _t_upby
      End Get
      Set(ByVal value As String)
        _t_upby = value
      End Set
    End Property
    Public Property t_updt() As String
      Get
        If Not _t_updt = String.Empty Then
          Return Convert.ToDateTime(_t_updt).ToString("dd/MM/yyyy")
        End If
        Return _t_updt
      End Get
      Set(ByVal value As String)
        If value = String.Empty Then
          value = "01/01/1985"
        End If
        _t_updt = value
      End Set
    End Property
    Public Property t_Refcntd() As Int32
      Get
        Return _t_Refcntd
      End Get
      Set(ByVal value As Int32)
        _t_Refcntd = value
      End Set
    End Property
    Public Property t_Refcntu() As Int32
      Get
        Return _t_Refcntu
      End Get
      Set(ByVal value As Int32)
        _t_Refcntu = value
      End Set
    End Property
    Public ReadOnly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public ReadOnly Property PrimaryKey() As String
      Get
        Return _t_sour & "|" & _t_ninv
      End Get
    End Property
    Public Shared Property RecordCount() As Integer
      Get
        Return _RecordCount
      End Get
      Set(ByVal value As Integer)
        _RecordCount = value
      End Set
    End Property
    Public Class PKspmtUPDInERP
      Private _t_sour As String = ""
      Private _t_ninv As Int32 = 0
      Public Property t_sour() As String
        Get
          Return _t_sour
        End Get
        Set(ByVal value As String)
          _t_sour = value
        End Set
      End Property
      Public Property t_ninv() As Int32
        Get
          Return _t_ninv
        End Get
        Set(ByVal value As Int32)
          _t_ninv = value
        End Set
      End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function spmtUPDInERPGetNewRecord() As SIS.SPMT.spmtUPDInERP
      Return New SIS.SPMT.spmtUPDInERP()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function spmtUPDInERPGetByID(ByVal t_sour As String, ByVal t_ninv As Int32) As SIS.SPMT.spmtUPDInERP
      Dim Results As SIS.SPMT.spmtUPDInERP = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNTAConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spspmtUPDInERPSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sour", SqlDbType.VarChar, t_sour.ToString.Length, t_sour)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ninv", SqlDbType.Int, t_ninv.ToString.Length, t_ninv)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.SPMT.spmtUPDInERP(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function spmtUPDInERPSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.SPMT.spmtUPDInERP)
      Dim Results As List(Of SIS.SPMT.spmtUPDInERP) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spspmtUPDInERPSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spspmtUPDInERPSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
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
    Public Shared Function spmtUPDInERPSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)>
    Public Shared Function spmtUPDInERPInsert(ByVal Record As SIS.SPMT.spmtUPDInERP) As SIS.SPMT.spmtUPDInERP
      Dim _Rec As SIS.SPMT.spmtUPDInERP = SIS.SPMT.spmtUPDInERP.spmtUPDInERPGetNewRecord()
      With _Rec
        .t_sour = Record.t_sour
        .t_ninv = Record.t_ninv
        .t_irdt = Record.t_irdt
        .t_type = Record.t_type
        .t_isup = Record.t_isup
        .t_idat = Record.t_idat
        .t_brmk = Record.t_brmk
        .t_brac = Record.t_brac
        .t_payd = Record.t_payd
        .t_hodc = Record.t_hodc
        .t_cprj = Record.t_cprj
        .t_cspa = Record.t_cspa
        .t_emno = Record.t_emno
        .t_cofc = Record.t_cofc
        .t_dimx = Record.t_dimx
        .t_gstn_c = Record.t_gstn_c
        .t_gstn_b = Record.t_gstn_b
        .t_ifbp = Record.t_ifbp
        .t_code = Record.t_code
        .t_unit = Record.t_unit
        .t_ityp = Record.t_ityp
        .t_sste = Record.t_sste
        .t_qnty = Record.t_qnty
        .t_assv = Record.t_assv
        .t_vamt = Record.t_vamt
        .t_cess = Record.t_cess
        .t_cmnt = Record.t_cmnt
        .t_tgst = Record.t_tgst
        .t_tamt = Record.t_tamt
        .t_grmk = Record.t_grmk
        .t_ccur = Record.t_ccur
        .t_conv = Record.t_conv
        .t_tamh = Record.t_tamh
        .t_ptyp = Record.t_ptyp
        .t_irat = Record.t_irat
        .t_iamt = Record.t_iamt
        .t_srat = Record.t_srat
        .t_samt = Record.t_samt
        .t_crat = Record.t_crat
        .t_camt = Record.t_camt
        .t_ttyp = Record.t_ttyp
        .t_docn = Record.t_docn
        .t_comp = Record.t_comp
        .t_upby = Record.t_upby
        .t_updt = Record.t_updt
        .t_Refcntd = Record.t_Refcntd
        .t_Refcntu = Record.t_Refcntu
        .t_nama = Record.t_nama
        .t_ucod = Record.t_ucod
        .t_unam = Record.t_unam
        .t_posu = Record.t_posu
      End With
      Return SIS.SPMT.spmtUPDInERP.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.SPMT.spmtUPDInERP) As SIS.SPMT.spmtUPDInERP
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNTAConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spspmtUPDInERPInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sour", SqlDbType.VarChar, 11, Record.t_sour)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ninv", SqlDbType.Int, 11, Record.t_ninv)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_irdt", SqlDbType.DateTime, 21, Record.t_irdt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_type", SqlDbType.VarChar, 4, Record.t_type)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_isup", SqlDbType.VarChar, 31, Record.t_isup)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_idat", SqlDbType.DateTime, 21, Record.t_idat)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_brmk", SqlDbType.VarChar, 216, Record.t_brmk)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_brac", SqlDbType.VarChar, 216, Record.t_brac)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_payd", SqlDbType.Int, 11, Record.t_payd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_hodc", SqlDbType.VarChar, 10, Record.t_hodc)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj", SqlDbType.VarChar, 10, Record.t_cprj)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cspa", SqlDbType.VarChar, 9, Record.t_cspa)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_emno", SqlDbType.VarChar, 10, Record.t_emno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cofc", SqlDbType.VarChar, 7, Record.t_cofc)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_dimx", SqlDbType.VarChar, 10, Record.t_dimx)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_gstn_c", SqlDbType.NVarChar, Record.t_gstn_c.Length, Record.t_gstn_c)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_gstn_b", SqlDbType.NVarChar, Record.t_gstn_b.Length, Record.t_gstn_b)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ifbp", SqlDbType.VarChar, 10, Record.t_ifbp)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_code", SqlDbType.VarChar, 20, Record.t_code)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_unit", SqlDbType.VarChar, 4, Record.t_unit)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ityp", SqlDbType.Int, 11, Record.t_ityp)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sste", SqlDbType.VarChar, 3, Record.t_sste)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_qnty", SqlDbType.Float, 16, Record.t_qnty)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_assv", SqlDbType.Float, 16, Record.t_assv)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_vamt", SqlDbType.Float, 16, Record.t_vamt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cess", SqlDbType.Float, 16, Record.t_cess)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cmnt", SqlDbType.Float, 16, Record.t_cmnt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_tgst", SqlDbType.Float, 16, Record.t_tgst)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_tamt", SqlDbType.Float, 16, Record.t_tamt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_grmk", SqlDbType.VarChar, 216, Record.t_grmk)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ccur", SqlDbType.VarChar, 4, Record.t_ccur)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_conv", SqlDbType.Float, 16, Record.t_conv)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_tamh", SqlDbType.Float, 16, Record.t_tamh)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ptyp", SqlDbType.VarChar, 51, Record.t_ptyp)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_irat", SqlDbType.Float, 16, Record.t_irat)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_iamt", SqlDbType.Float, 16, Record.t_iamt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_srat", SqlDbType.Float, 16, Record.t_srat)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_samt", SqlDbType.Float, 16, Record.t_samt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_crat", SqlDbType.Float, 16, Record.t_crat)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_camt", SqlDbType.Float, 16, Record.t_camt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ttyp", SqlDbType.VarChar, 4, Record.t_ttyp)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_docn", SqlDbType.Int, 11, Record.t_docn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_comp", SqlDbType.Int, 11, Record.t_comp)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_upby", SqlDbType.VarChar, 17, Record.t_upby)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_updt", SqlDbType.DateTime, 21, Record.t_updt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntd", SqlDbType.Int, 11, Record.t_Refcntd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntu", SqlDbType.Int, 11, Record.t_Refcntu)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ucod", SqlDbType.VarChar, 8, Record.t_ucod)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_unam", SqlDbType.VarChar, 35, Record.t_unam)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_nama", SqlDbType.VarChar, 100, Record.t_nama)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_posu", SqlDbType.VarChar, 3, Record.t_posu)
          Cmd.Parameters.Add("@Return_t_sour", SqlDbType.VarChar, 11)
          Cmd.Parameters("@Return_t_sour").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_t_ninv", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_t_ninv").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.t_sour = Cmd.Parameters("@Return_t_sour").Value
          Record.t_ninv = Cmd.Parameters("@Return_t_ninv").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)>
    Public Shared Function spmtUPDInERPUpdate(ByVal Record As SIS.SPMT.spmtUPDInERP) As SIS.SPMT.spmtUPDInERP
      Dim _Rec As SIS.SPMT.spmtUPDInERP = SIS.SPMT.spmtUPDInERP.spmtUPDInERPGetByID(Record.t_sour, Record.t_ninv)
      With _Rec
        .t_irdt = Record.t_irdt
        .t_type = Record.t_type
        .t_isup = Record.t_isup
        .t_idat = Record.t_idat
        .t_brmk = Record.t_brmk
        .t_brac = Record.t_brac
        .t_payd = Record.t_payd
        .t_hodc = Record.t_hodc
        .t_cprj = Record.t_cprj
        .t_cspa = Record.t_cspa
        .t_emno = Record.t_emno
        .t_cofc = Record.t_cofc
        .t_dimx = Record.t_dimx
        .t_gstn_c = Record.t_gstn_c
        .t_gstn_b = Record.t_gstn_b
        .t_ifbp = Record.t_ifbp
        .t_code = Record.t_code
        .t_unit = Record.t_unit
        .t_ityp = Record.t_ityp
        .t_sste = Record.t_sste
        .t_qnty = Record.t_qnty
        .t_assv = Record.t_assv
        .t_vamt = Record.t_vamt
        .t_cess = Record.t_cess
        .t_cmnt = Record.t_cmnt
        .t_tgst = Record.t_tgst
        .t_tamt = Record.t_tamt
        .t_grmk = Record.t_grmk
        .t_ccur = Record.t_ccur
        .t_conv = Record.t_conv
        .t_tamh = Record.t_tamh
        .t_ptyp = Record.t_ptyp
        .t_irat = Record.t_irat
        .t_iamt = Record.t_iamt
        .t_srat = Record.t_srat
        .t_samt = Record.t_samt
        .t_crat = Record.t_crat
        .t_camt = Record.t_camt
        .t_ttyp = Record.t_ttyp
        .t_docn = Record.t_docn
        .t_comp = Record.t_comp
        .t_upby = Record.t_upby
        .t_updt = Record.t_updt
        .t_Refcntd = Record.t_Refcntd
        .t_Refcntu = Record.t_Refcntu
        .t_nama = Record.t_nama
        .t_ucod = Record.t_ucod
        .t_unam = Record.t_unam
        .t_posu = Record.t_posu
      End With
      Return SIS.SPMT.spmtUPDInERP.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.SPMT.spmtUPDInERP) As SIS.SPMT.spmtUPDInERP
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNTAConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spspmtUPDInERPUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_sour", SqlDbType.VarChar, 11, Record.t_sour)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_ninv", SqlDbType.Int, 11, Record.t_ninv)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sour", SqlDbType.VarChar, 11, Record.t_sour)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ninv", SqlDbType.Int, 11, Record.t_ninv)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_irdt", SqlDbType.DateTime, 21, Record.t_irdt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_type", SqlDbType.VarChar, 4, Record.t_type)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_isup", SqlDbType.VarChar, 31, Record.t_isup)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_idat", SqlDbType.DateTime, 21, Record.t_idat)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_brmk", SqlDbType.VarChar, 216, Record.t_brmk)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_brac", SqlDbType.VarChar, 216, Record.t_brac)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_payd", SqlDbType.Int, 11, Record.t_payd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_hodc", SqlDbType.VarChar, 10, Record.t_hodc)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj", SqlDbType.VarChar, 10, Record.t_cprj)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cspa", SqlDbType.VarChar, 9, Record.t_cspa)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_emno", SqlDbType.VarChar, 10, Record.t_emno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cofc", SqlDbType.VarChar, 7, Record.t_cofc)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_dimx", SqlDbType.VarChar, 10, Record.t_dimx)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_gstn_c", SqlDbType.NVarChar, Record.t_gstn_c.Length, Record.t_gstn_c)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_gstn_b", SqlDbType.NVarChar, Record.t_gstn_b.Length, Record.t_gstn_b)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ifbp", SqlDbType.VarChar, 10, Record.t_ifbp)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_code", SqlDbType.VarChar, 20, Record.t_code)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_unit", SqlDbType.VarChar, 4, Record.t_unit)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ityp", SqlDbType.Int, 11, Record.t_ityp)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sste", SqlDbType.VarChar, 3, Record.t_sste)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_qnty", SqlDbType.Float, 16, Record.t_qnty)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_assv", SqlDbType.Float, 16, Record.t_assv)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_vamt", SqlDbType.Float, 16, Record.t_vamt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cess", SqlDbType.Float, 16, Record.t_cess)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cmnt", SqlDbType.Float, 16, Record.t_cmnt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_tgst", SqlDbType.Float, 16, Record.t_tgst)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_tamt", SqlDbType.Float, 16, Record.t_tamt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_grmk", SqlDbType.VarChar, 216, Record.t_grmk)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ccur", SqlDbType.VarChar, 4, Record.t_ccur)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_conv", SqlDbType.Float, 16, Record.t_conv)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_tamh", SqlDbType.Float, 16, Record.t_tamh)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ptyp", SqlDbType.VarChar, 51, Record.t_ptyp)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_irat", SqlDbType.Float, 16, Record.t_irat)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_iamt", SqlDbType.Float, 16, Record.t_iamt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_srat", SqlDbType.Float, 16, Record.t_srat)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_samt", SqlDbType.Float, 16, Record.t_samt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_crat", SqlDbType.Float, 16, Record.t_crat)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_camt", SqlDbType.Float, 16, Record.t_camt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ttyp", SqlDbType.VarChar, 4, Record.t_ttyp)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_docn", SqlDbType.Int, 11, Record.t_docn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_comp", SqlDbType.Int, 11, Record.t_comp)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_upby", SqlDbType.VarChar, 17, Record.t_upby)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_updt", SqlDbType.DateTime, 21, Record.t_updt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntd", SqlDbType.Int, 11, Record.t_Refcntd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntu", SqlDbType.Int, 11, Record.t_Refcntu)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ucod", SqlDbType.VarChar, 8, Record.t_ucod)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_unam", SqlDbType.VarChar, 35, Record.t_unam)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_nama", SqlDbType.VarChar, 100, Record.t_nama)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_posu", SqlDbType.VarChar, 3, Record.t_posu)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Delete, True)>
    Public Shared Function spmtUPDInERPDelete(ByVal Record As SIS.SPMT.spmtUPDInERP) As Int32
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNTAConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spspmtUPDInERPDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_sour", SqlDbType.VarChar, Record.t_sour.ToString.Length, Record.t_sour)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_ninv", SqlDbType.Int, Record.t_ninv.ToString.Length, Record.t_ninv)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _RecordCount
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              If Convert.IsDBNull(Reader(pi.Name)) Then
                CallByName(Me, pi.Name, CallType.Let, String.Empty)
              Else
                CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
