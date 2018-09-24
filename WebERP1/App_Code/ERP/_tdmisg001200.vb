Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.DM
  <DataObject()> _
  Partial Public Class tdmisg001200
    Private Shared _RecordCount As Integer
    Private _t_docn As String = ""
    Private _t_revn As String = ""
    Private _t_dcid As String = ""
    Private _t_dsca As String = ""
    Private _t_dttl As String = ""
    Private _t_cspa As String = ""
    Private _t_erec As Int32 = 0
    Private _t_prod As Int32 = 0
    Private _t_info As Int32 = 0
    Private _t_appr As Int32 = 0
    Private _t_resp As String = ""
    Private _t_date As String = ""
    Private _t_appb As String = ""
    Private _t_chkb As String = ""
    Private _t_drwb As String = ""
    Private _t_wght As Double = 0
    Private _t_scal As String = ""
    Private _t_size As String = ""
    Private _t_pdfn As String = ""
    Private _t_cprj As String = ""
    Private _t_grup As String = ""
    Private _t_clnt As String = ""
    Private _t_cnsl As String = ""
    Private _t_year As String = ""
    Private _t_iwtn As String = ""
    Private _t_ser2 As String = ""
    Private _t_ser1 As String = ""
    Private _t_stat As Int32 = 0
    Private _t_name As String = ""
    Private _t_user As String = ""
    Private _t_mach As String = ""
    Private _t_sdat As String = ""
    Private _t_sorc As String = ""
    Private _t_crtp As Int32 = 0
    Private _t_Refcntd As Int32 = 0
    Private _t_Refcntu As Int32 = 0
    Private _t_drdt As String = ""
    Private _t_drur As String = ""
    Private _t_aact As Int32 = 0
    Private _t_aact_1 As Int32 = 0
    Private _t_aact_2 As Int32 = 0
    Private _t_aact_3 As Int32 = 0
    Private _t_adat As String = ""
    Private _t_apre As String = ""
    Private _t_atxt As Int32 = 0
    Private _t_ausr As String = ""
    Private _t_dcrr As Int32 = 0
    Private _t_docs As Int32 = 0
    Private _t_drwd As String = ""
    Private _t_link As Int32 = 0
    Private _t_pdfd As String = ""
    Private _t_ract As Int32 = 0
    Private _t_ract_1 As Int32 = 0
    Private _t_ract_2 As Int32 = 0
    Private _t_rdat As String = ""
    Private _t_rere As String = ""
    Private _t_rtxt As Int32 = 0
    Private _t_rusr As String = ""
    Private _t_sudt As String = ""
    Private _t_type As String = ""
    Private _t_wfst As Int32 = 0
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
    Public Property t_docn() As String
      Get
        Return _t_docn
      End Get
      Set(ByVal value As String)
        _t_docn = value
      End Set
    End Property
    Public Property t_revn() As String
      Get
        Return _t_revn
      End Get
      Set(ByVal value As String)
        _t_revn = value
      End Set
    End Property
    Public Property t_dcid() As String
      Get
        Return _t_dcid
      End Get
      Set(ByVal value As String)
        _t_dcid = value
      End Set
    End Property
    Public Property t_dsca() As String
      Get
        Return _t_dsca
      End Get
      Set(ByVal value As String)
        _t_dsca = value
      End Set
    End Property
    Public Property t_dttl() As String
      Get
        Return _t_dttl
      End Get
      Set(ByVal value As String)
        _t_dttl = value
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
    Public Property t_erec() As Int32
      Get
        Return _t_erec
      End Get
      Set(ByVal value As Int32)
        _t_erec = value
      End Set
    End Property
    Public Property t_prod() As Int32
      Get
        Return _t_prod
      End Get
      Set(ByVal value As Int32)
        _t_prod = value
      End Set
    End Property
    Public Property t_info() As Int32
      Get
        Return _t_info
      End Get
      Set(ByVal value As Int32)
        _t_info = value
      End Set
    End Property
    Public Property t_appr() As Int32
      Get
        Return _t_appr
      End Get
      Set(ByVal value As Int32)
        _t_appr = value
      End Set
    End Property
    Public Property t_resp() As String
      Get
        Return _t_resp
      End Get
      Set(ByVal value As String)
        _t_resp = value
      End Set
    End Property
    Public Property t_date() As String
      Get
        Return _t_date
      End Get
      Set(ByVal value As String)
        _t_date = value
      End Set
    End Property
    Public Property t_appb() As String
      Get
        Return _t_appb
      End Get
      Set(ByVal value As String)
        _t_appb = value
      End Set
    End Property
    Public Property t_chkb() As String
      Get
        Return _t_chkb
      End Get
      Set(ByVal value As String)
        _t_chkb = value
      End Set
    End Property
    Public Property t_drwb() As String
      Get
        Return _t_drwb
      End Get
      Set(ByVal value As String)
        _t_drwb = value
      End Set
    End Property
    Public Property t_wght() As Double
      Get
        Return _t_wght
      End Get
      Set(ByVal value As Double)
        _t_wght = value
      End Set
    End Property
    Public Property t_scal() As String
      Get
        Return _t_scal
      End Get
      Set(ByVal value As String)
        _t_scal = value
      End Set
    End Property
    Public Property t_size() As String
      Get
        Return _t_size
      End Get
      Set(ByVal value As String)
        _t_size = value
      End Set
    End Property
    Public Property t_pdfn() As String
      Get
        Return _t_pdfn
      End Get
      Set(ByVal value As String)
        _t_pdfn = value
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
    Public Property t_grup() As String
      Get
        Return _t_grup
      End Get
      Set(ByVal value As String)
        _t_grup = value
      End Set
    End Property
    Public Property t_clnt() As String
      Get
        Return _t_clnt
      End Get
      Set(ByVal value As String)
        _t_clnt = value
      End Set
    End Property
    Public Property t_cnsl() As String
      Get
        Return _t_cnsl
      End Get
      Set(ByVal value As String)
        _t_cnsl = value
      End Set
    End Property
    Public Property t_year() As String
      Get
        Return _t_year
      End Get
      Set(ByVal value As String)
        _t_year = value
      End Set
    End Property
    Public Property t_iwtn() As String
      Get
        Return _t_iwtn
      End Get
      Set(ByVal value As String)
        _t_iwtn = value
      End Set
    End Property
    Public Property t_ser2() As String
      Get
        Return _t_ser2
      End Get
      Set(ByVal value As String)
        _t_ser2 = value
      End Set
    End Property
    Public Property t_ser1() As String
      Get
        Return _t_ser1
      End Get
      Set(ByVal value As String)
        _t_ser1 = value
      End Set
    End Property
    Public Property t_stat() As Int32
      Get
        Return _t_stat
      End Get
      Set(ByVal value As Int32)
        _t_stat = value
      End Set
    End Property
    Public Property t_name() As String
      Get
        Return _t_name
      End Get
      Set(ByVal value As String)
        _t_name = value
      End Set
    End Property
    Public Property t_user() As String
      Get
        Return _t_user
      End Get
      Set(ByVal value As String)
        _t_user = value
      End Set
    End Property
    Public Property t_mach() As String
      Get
        Return _t_mach
      End Get
      Set(ByVal value As String)
        _t_mach = value
      End Set
    End Property
    Public Property t_sdat() As String
      Get
        If Not _t_sdat = String.Empty Then
          Return Convert.ToDateTime(_t_sdat).ToString("dd/MM/yyyy")
        End If
        Return _t_sdat
      End Get
      Set(ByVal value As String)
			   _t_sdat = value
      End Set
    End Property
    Public Property t_sorc() As String
      Get
        Return _t_sorc
      End Get
      Set(ByVal value As String)
        _t_sorc = value
      End Set
    End Property
    Public Property t_crtp() As Int32
      Get
        Return _t_crtp
      End Get
      Set(ByVal value As Int32)
        _t_crtp = value
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
    Public Property t_drdt() As String
      Get
        If Not _t_drdt = String.Empty Then
          Return Convert.ToDateTime(_t_drdt).ToString("dd/MM/yyyy")
        End If
        Return _t_drdt
      End Get
      Set(ByVal value As String)
			   _t_drdt = value
      End Set
    End Property
    Public Property t_drur() As String
      Get
        Return _t_drur
      End Get
      Set(ByVal value As String)
        _t_drur = value
      End Set
    End Property
    Public Property t_aact() As Int32
      Get
        Return _t_aact
      End Get
      Set(ByVal value As Int32)
        _t_aact = value
      End Set
    End Property
    Public Property t_aact_1() As Int32
      Get
        Return _t_aact_1
      End Get
      Set(ByVal value As Int32)
        _t_aact_1 = value
      End Set
    End Property
    Public Property t_aact_2() As Int32
      Get
        Return _t_aact_2
      End Get
      Set(ByVal value As Int32)
        _t_aact_2 = value
      End Set
    End Property
    Public Property t_aact_3() As Int32
      Get
        Return _t_aact_3
      End Get
      Set(ByVal value As Int32)
        _t_aact_3 = value
      End Set
    End Property
    Public Property t_adat() As String
      Get
        If Not _t_adat = String.Empty Then
          Return Convert.ToDateTime(_t_adat).ToString("dd/MM/yyyy")
        End If
        Return _t_adat
      End Get
      Set(ByVal value As String)
			   _t_adat = value
      End Set
    End Property
    Public Property t_apre() As String
      Get
        Return _t_apre
      End Get
      Set(ByVal value As String)
        _t_apre = value
      End Set
    End Property
    Public Property t_atxt() As Int32
      Get
        Return _t_atxt
      End Get
      Set(ByVal value As Int32)
        _t_atxt = value
      End Set
    End Property
    Public Property t_ausr() As String
      Get
        Return _t_ausr
      End Get
      Set(ByVal value As String)
        _t_ausr = value
      End Set
    End Property
    Public Property t_dcrr() As Int32
      Get
        Return _t_dcrr
      End Get
      Set(ByVal value As Int32)
        _t_dcrr = value
      End Set
    End Property
    Public Property t_docs() As Int32
      Get
        Return _t_docs
      End Get
      Set(ByVal value As Int32)
        _t_docs = value
      End Set
    End Property
    Public Property t_drwd() As String
      Get
        Return _t_drwd
      End Get
      Set(ByVal value As String)
        _t_drwd = value
      End Set
    End Property
    Public Property t_link() As Int32
      Get
        Return _t_link
      End Get
      Set(ByVal value As Int32)
        _t_link = value
      End Set
    End Property
    Public Property t_pdfd() As String
      Get
        Return _t_pdfd
      End Get
      Set(ByVal value As String)
        _t_pdfd = value
      End Set
    End Property
    Public Property t_ract() As Int32
      Get
        Return _t_ract
      End Get
      Set(ByVal value As Int32)
        _t_ract = value
      End Set
    End Property
    Public Property t_ract_1() As Int32
      Get
        Return _t_ract_1
      End Get
      Set(ByVal value As Int32)
        _t_ract_1 = value
      End Set
    End Property
    Public Property t_ract_2() As Int32
      Get
        Return _t_ract_2
      End Get
      Set(ByVal value As Int32)
        _t_ract_2 = value
      End Set
    End Property
    Public Property t_rdat() As String
      Get
        If Not _t_rdat = String.Empty Then
          Return Convert.ToDateTime(_t_rdat).ToString("dd/MM/yyyy")
        End If
        Return _t_rdat
      End Get
      Set(ByVal value As String)
			   _t_rdat = value
      End Set
    End Property
    Public Property t_rere() As String
      Get
        Return _t_rere
      End Get
      Set(ByVal value As String)
        _t_rere = value
      End Set
    End Property
    Public Property t_rtxt() As Int32
      Get
        Return _t_rtxt
      End Get
      Set(ByVal value As Int32)
        _t_rtxt = value
      End Set
    End Property
    Public Property t_rusr() As String
      Get
        Return _t_rusr
      End Get
      Set(ByVal value As String)
        _t_rusr = value
      End Set
    End Property
    Public Property t_sudt() As String
      Get
        If Not _t_sudt = String.Empty Then
          Return Convert.ToDateTime(_t_sudt).ToString("dd/MM/yyyy")
        End If
        Return _t_sudt
      End Get
      Set(ByVal value As String)
			   _t_sudt = value
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
    Public Property t_wfst() As Int32
      Get
        Return _t_wfst
      End Get
      Set(ByVal value As Int32)
        _t_wfst = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _t_docn & "|" & _t_revn
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
    Public Class PKtdmisg001200
			Private _t_docn As String = ""
			Private _t_revn As String = ""
			Public Property t_docn() As String
				Get
					Return _t_docn
				End Get
				Set(ByVal value As String)
					_t_docn = value
				End Set
			End Property
			Public Property t_revn() As String
				Get
					Return _t_revn
				End Get
				Set(ByVal value As String)
					_t_revn = value
				End Set
			End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tdmisg001200GetNewRecord() As SIS.DM.tdmisg001200
      Return New SIS.DM.tdmisg001200()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tdmisg001200GetByID(ByVal t_docn As String, ByVal t_revn As String) As SIS.DM.tdmisg001200
      Dim Results As SIS.DM.tdmisg001200 = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptdmisg001200SelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_docn",SqlDbType.VarChar,t_docn.ToString.Length, t_docn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_revn",SqlDbType.VarChar,t_revn.ToString.Length, t_revn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.DM.tdmisg001200(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tdmisg001200SelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.DM.tdmisg001200)
      Dim Results As List(Of SIS.DM.tdmisg001200) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "sptdmisg001200SelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "sptdmisg001200SelectListFilteres"
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.DM.tdmisg001200)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.DM.tdmisg001200(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function tdmisg001200SelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function tdmisg001200Insert(ByVal Record As SIS.DM.tdmisg001200) As SIS.DM.tdmisg001200
      Dim _Rec As SIS.DM.tdmisg001200 = SIS.DM.tdmisg001200.tdmisg001200GetNewRecord()
      With _Rec
        .t_docn = Record.t_docn
        .t_revn = Record.t_revn
        .t_dcid = Record.t_dcid
        .t_dsca = Record.t_dsca
        .t_dttl = Record.t_dttl
        .t_cspa = Record.t_cspa
        .t_erec = Record.t_erec
        .t_prod = Record.t_prod
        .t_info = Record.t_info
        .t_appr = Record.t_appr
        .t_resp = Record.t_resp
        .t_date = Record.t_date
        .t_appb = Record.t_appb
        .t_chkb = Record.t_chkb
        .t_drwb = Record.t_drwb
        .t_wght = Record.t_wght
        .t_scal = Record.t_scal
        .t_size = Record.t_size
        .t_pdfn = Record.t_pdfn
        .t_cprj = Record.t_cprj
        .t_grup = Record.t_grup
        .t_clnt = Record.t_clnt
        .t_cnsl = Record.t_cnsl
        .t_year = Record.t_year
        .t_iwtn = Record.t_iwtn
        .t_ser2 = Record.t_ser2
        .t_ser1 = Record.t_ser1
        .t_stat = Record.t_stat
        .t_name = Record.t_name
        .t_user = Record.t_user
        .t_mach = Record.t_mach
        .t_sdat = Record.t_sdat
        .t_sorc = Record.t_sorc
        .t_crtp = Record.t_crtp
        .t_Refcntd = Record.t_Refcntd
        .t_Refcntu = Record.t_Refcntu
        .t_drdt = Record.t_drdt
        .t_drur = Record.t_drur
        .t_aact = Record.t_aact
        .t_aact_1 = Record.t_aact_1
        .t_aact_2 = Record.t_aact_2
        .t_aact_3 = Record.t_aact_3
        .t_adat = Record.t_adat
        .t_apre = Record.t_apre
        .t_atxt = Record.t_atxt
        .t_ausr = Record.t_ausr
        .t_dcrr = Record.t_dcrr
        .t_docs = Record.t_docs
        .t_drwd = Record.t_drwd
        .t_link = Record.t_link
        .t_pdfd = Record.t_pdfd
        .t_ract = Record.t_ract
        .t_ract_1 = Record.t_ract_1
        .t_ract_2 = Record.t_ract_2
        .t_rdat = Record.t_rdat
        .t_rere = Record.t_rere
        .t_rtxt = Record.t_rtxt
        .t_rusr = Record.t_rusr
        .t_sudt = Record.t_sudt
        .t_type = Record.t_type
        .t_wfst = Record.t_wfst
      End With
      Return SIS.DM.tdmisg001200.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.DM.tdmisg001200) As SIS.DM.tdmisg001200
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptdmisg001200Insert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_docn",SqlDbType.VarChar,33, Record.t_docn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_revn",SqlDbType.VarChar,21, Record.t_revn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_dcid",SqlDbType.VarChar,33, Record.t_dcid)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_dsca",SqlDbType.VarChar,101, Record.t_dsca)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_dttl",SqlDbType.VarChar,101, Record.t_dttl)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cspa",SqlDbType.VarChar,9, Record.t_cspa)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_erec",SqlDbType.Int,11, Record.t_erec)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_prod",SqlDbType.Int,11, Record.t_prod)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_info",SqlDbType.Int,11, Record.t_info)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_appr",SqlDbType.Int,11, Record.t_appr)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_resp",SqlDbType.VarChar,51, Record.t_resp)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_date",SqlDbType.VarChar,21, Record.t_date)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_appb",SqlDbType.VarChar,21, Record.t_appb)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_chkb",SqlDbType.VarChar,51, Record.t_chkb)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_drwb",SqlDbType.VarChar,51, Record.t_drwb)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_wght",SqlDbType.Float,16, Record.t_wght)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_scal",SqlDbType.VarChar,21, Record.t_scal)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_size",SqlDbType.VarChar,51, Record.t_size)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_pdfn",SqlDbType.VarChar,101, Record.t_pdfn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj",SqlDbType.VarChar,10, Record.t_cprj)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_grup",SqlDbType.VarChar,21, Record.t_grup)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_clnt",SqlDbType.VarChar,101, Record.t_clnt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cnsl",SqlDbType.VarChar,101, Record.t_cnsl)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_year",SqlDbType.VarChar,5, Record.t_year)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_iwtn",SqlDbType.VarChar,11, Record.t_iwtn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ser2",SqlDbType.VarChar,101, Record.t_ser2)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ser1",SqlDbType.VarChar,101, Record.t_ser1)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_stat",SqlDbType.Int,11, Record.t_stat)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_name",SqlDbType.VarChar,36, Record.t_name)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_user",SqlDbType.VarChar,36, Record.t_user)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_mach",SqlDbType.VarChar,36, Record.t_mach)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sdat",SqlDbType.DateTime,21, Record.t_sdat)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sorc",SqlDbType.VarChar,51, Record.t_sorc)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_crtp",SqlDbType.Int,11, Record.t_crtp)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntd",SqlDbType.Int,11, Record.t_Refcntd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntu",SqlDbType.Int,11, Record.t_Refcntu)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_drdt",SqlDbType.DateTime,21, Record.t_drdt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_drur",SqlDbType.VarChar,17, Record.t_drur)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_aact",SqlDbType.Int,11, Record.t_aact)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_aact_1",SqlDbType.Int,11, Record.t_aact_1)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_aact_2",SqlDbType.Int,11, Record.t_aact_2)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_aact_3",SqlDbType.Int,11, Record.t_aact_3)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_adat",SqlDbType.DateTime,21, Record.t_adat)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_apre",SqlDbType.VarChar,51, Record.t_apre)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_atxt",SqlDbType.Int,11, Record.t_atxt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ausr",SqlDbType.VarChar,10, Record.t_ausr)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_dcrr",SqlDbType.Int,11, Record.t_dcrr)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_docs",SqlDbType.Int,11, Record.t_docs)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_drwd",SqlDbType.VarChar,33, Record.t_drwd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_link",SqlDbType.Int,11, Record.t_link)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_pdfd",SqlDbType.VarChar,33, Record.t_pdfd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ract",SqlDbType.Int,11, Record.t_ract)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ract_1",SqlDbType.Int,11, Record.t_ract_1)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ract_2",SqlDbType.Int,11, Record.t_ract_2)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rdat",SqlDbType.DateTime,21, Record.t_rdat)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rere",SqlDbType.VarChar,51, Record.t_rere)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rtxt",SqlDbType.Int,11, Record.t_rtxt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rusr",SqlDbType.VarChar,10, Record.t_rusr)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sudt",SqlDbType.DateTime,21, Record.t_sudt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_type",SqlDbType.VarChar,8, Record.t_type)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_wfst",SqlDbType.Int,11, Record.t_wfst)
          Cmd.Parameters.Add("@Return_t_docn", SqlDbType.VarChar, 33)
          Cmd.Parameters("@Return_t_docn").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_t_revn", SqlDbType.VarChar, 21)
          Cmd.Parameters("@Return_t_revn").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.t_docn = Cmd.Parameters("@Return_t_docn").Value
          Record.t_revn = Cmd.Parameters("@Return_t_revn").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function tdmisg001200Update(ByVal Record As SIS.DM.tdmisg001200) As SIS.DM.tdmisg001200
      Dim _Rec As SIS.DM.tdmisg001200 = SIS.DM.tdmisg001200.tdmisg001200GetByID(Record.t_docn, Record.t_revn)
      With _Rec
        .t_dcid = Record.t_dcid
        .t_dsca = Record.t_dsca
        .t_dttl = Record.t_dttl
        .t_cspa = Record.t_cspa
        .t_erec = Record.t_erec
        .t_prod = Record.t_prod
        .t_info = Record.t_info
        .t_appr = Record.t_appr
        .t_resp = Record.t_resp
        .t_date = Record.t_date
        .t_appb = Record.t_appb
        .t_chkb = Record.t_chkb
        .t_drwb = Record.t_drwb
        .t_wght = Record.t_wght
        .t_scal = Record.t_scal
        .t_size = Record.t_size
        .t_pdfn = Record.t_pdfn
        .t_cprj = Record.t_cprj
        .t_grup = Record.t_grup
        .t_clnt = Record.t_clnt
        .t_cnsl = Record.t_cnsl
        .t_year = Record.t_year
        .t_iwtn = Record.t_iwtn
        .t_ser2 = Record.t_ser2
        .t_ser1 = Record.t_ser1
        .t_stat = Record.t_stat
        .t_name = Record.t_name
        .t_user = Record.t_user
        .t_mach = Record.t_mach
        .t_sdat = Record.t_sdat
        .t_sorc = Record.t_sorc
        .t_crtp = Record.t_crtp
        .t_Refcntd = Record.t_Refcntd
        .t_Refcntu = Record.t_Refcntu
        .t_drdt = Record.t_drdt
        .t_drur = Record.t_drur
        .t_aact = Record.t_aact
        .t_aact_1 = Record.t_aact_1
        .t_aact_2 = Record.t_aact_2
        .t_aact_3 = Record.t_aact_3
        .t_adat = Record.t_adat
        .t_apre = Record.t_apre
        .t_atxt = Record.t_atxt
        .t_ausr = Record.t_ausr
        .t_dcrr = Record.t_dcrr
        .t_docs = Record.t_docs
        .t_drwd = Record.t_drwd
        .t_link = Record.t_link
        .t_pdfd = Record.t_pdfd
        .t_ract = Record.t_ract
        .t_ract_1 = Record.t_ract_1
        .t_ract_2 = Record.t_ract_2
        .t_rdat = Record.t_rdat
        .t_rere = Record.t_rere
        .t_rtxt = Record.t_rtxt
        .t_rusr = Record.t_rusr
        .t_sudt = Record.t_sudt
        .t_type = Record.t_type
        .t_wfst = Record.t_wfst
      End With
      Return SIS.DM.tdmisg001200.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.DM.tdmisg001200) As SIS.DM.tdmisg001200
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptdmisg001200Update"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_docn",SqlDbType.VarChar,33, Record.t_docn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_revn",SqlDbType.VarChar,21, Record.t_revn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_docn",SqlDbType.VarChar,33, Record.t_docn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_revn",SqlDbType.VarChar,21, Record.t_revn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_dcid",SqlDbType.VarChar,33, Record.t_dcid)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_dsca",SqlDbType.VarChar,101, Record.t_dsca)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_dttl",SqlDbType.VarChar,101, Record.t_dttl)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cspa",SqlDbType.VarChar,9, Record.t_cspa)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_erec",SqlDbType.Int,11, Record.t_erec)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_prod",SqlDbType.Int,11, Record.t_prod)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_info",SqlDbType.Int,11, Record.t_info)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_appr",SqlDbType.Int,11, Record.t_appr)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_resp",SqlDbType.VarChar,51, Record.t_resp)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_date",SqlDbType.VarChar,21, Record.t_date)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_appb",SqlDbType.VarChar,21, Record.t_appb)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_chkb",SqlDbType.VarChar,51, Record.t_chkb)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_drwb",SqlDbType.VarChar,51, Record.t_drwb)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_wght",SqlDbType.Float,16, Record.t_wght)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_scal",SqlDbType.VarChar,21, Record.t_scal)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_size",SqlDbType.VarChar,51, Record.t_size)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_pdfn",SqlDbType.VarChar,101, Record.t_pdfn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj",SqlDbType.VarChar,10, Record.t_cprj)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_grup",SqlDbType.VarChar,21, Record.t_grup)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_clnt",SqlDbType.VarChar,101, Record.t_clnt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cnsl",SqlDbType.VarChar,101, Record.t_cnsl)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_year",SqlDbType.VarChar,5, Record.t_year)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_iwtn",SqlDbType.VarChar,11, Record.t_iwtn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ser2",SqlDbType.VarChar,101, Record.t_ser2)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ser1",SqlDbType.VarChar,101, Record.t_ser1)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_stat",SqlDbType.Int,11, Record.t_stat)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_name",SqlDbType.VarChar,36, Record.t_name)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_user",SqlDbType.VarChar,36, Record.t_user)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_mach",SqlDbType.VarChar,36, Record.t_mach)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sdat",SqlDbType.DateTime,21, Record.t_sdat)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sorc",SqlDbType.VarChar,51, Record.t_sorc)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_crtp",SqlDbType.Int,11, Record.t_crtp)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntd",SqlDbType.Int,11, Record.t_Refcntd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntu",SqlDbType.Int,11, Record.t_Refcntu)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_drdt",SqlDbType.DateTime,21, Record.t_drdt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_drur",SqlDbType.VarChar,17, Record.t_drur)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_aact",SqlDbType.Int,11, Record.t_aact)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_aact_1",SqlDbType.Int,11, Record.t_aact_1)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_aact_2",SqlDbType.Int,11, Record.t_aact_2)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_aact_3",SqlDbType.Int,11, Record.t_aact_3)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_adat",SqlDbType.DateTime,21, Record.t_adat)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_apre",SqlDbType.VarChar,51, Record.t_apre)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_atxt",SqlDbType.Int,11, Record.t_atxt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ausr",SqlDbType.VarChar,10, Record.t_ausr)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_dcrr",SqlDbType.Int,11, Record.t_dcrr)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_docs",SqlDbType.Int,11, Record.t_docs)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_drwd",SqlDbType.VarChar,33, Record.t_drwd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_link",SqlDbType.Int,11, Record.t_link)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_pdfd",SqlDbType.VarChar,33, Record.t_pdfd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ract",SqlDbType.Int,11, Record.t_ract)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ract_1",SqlDbType.Int,11, Record.t_ract_1)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ract_2",SqlDbType.Int,11, Record.t_ract_2)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rdat",SqlDbType.DateTime,21, Record.t_rdat)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rere",SqlDbType.VarChar,51, Record.t_rere)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rtxt",SqlDbType.Int,11, Record.t_rtxt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rusr",SqlDbType.VarChar,10, Record.t_rusr)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sudt",SqlDbType.DateTime,21, Record.t_sudt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_type",SqlDbType.VarChar,8, Record.t_type)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_wfst",SqlDbType.Int,11, Record.t_wfst)
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
    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    Public Shared Function tdmisg001200Delete(ByVal Record As SIS.DM.tdmisg001200) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptdmisg001200Delete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_docn",SqlDbType.VarChar,Record.t_docn.ToString.Length, Record.t_docn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_revn",SqlDbType.VarChar,Record.t_revn.ToString.Length, Record.t_revn)
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
      On Error Resume Next
      _t_docn = Ctype(Reader("t_docn"),String)
      _t_revn = Ctype(Reader("t_revn"),String)
      _t_dcid = Ctype(Reader("t_dcid"),String)
      _t_dsca = Ctype(Reader("t_dsca"),String)
      _t_dttl = Ctype(Reader("t_dttl"),String)
      _t_cspa = Ctype(Reader("t_cspa"),String)
      _t_erec = Ctype(Reader("t_erec"),Int32)
      _t_prod = Ctype(Reader("t_prod"),Int32)
      _t_info = Ctype(Reader("t_info"),Int32)
      _t_appr = Ctype(Reader("t_appr"),Int32)
      _t_resp = Ctype(Reader("t_resp"),String)
      _t_date = Ctype(Reader("t_date"),String)
      _t_appb = Ctype(Reader("t_appb"),String)
      _t_chkb = Ctype(Reader("t_chkb"),String)
      _t_drwb = Ctype(Reader("t_drwb"),String)
      _t_wght = Ctype(Reader("t_wght"),Double)
      _t_scal = Ctype(Reader("t_scal"),String)
      _t_size = Ctype(Reader("t_size"),String)
      _t_pdfn = Ctype(Reader("t_pdfn"),String)
      _t_cprj = Ctype(Reader("t_cprj"),String)
      _t_grup = Ctype(Reader("t_grup"),String)
      _t_clnt = Ctype(Reader("t_clnt"),String)
      _t_cnsl = Ctype(Reader("t_cnsl"),String)
      _t_year = Ctype(Reader("t_year"),String)
      _t_iwtn = Ctype(Reader("t_iwtn"),String)
      _t_ser2 = Ctype(Reader("t_ser2"),String)
      _t_ser1 = Ctype(Reader("t_ser1"),String)
      _t_stat = Ctype(Reader("t_stat"),Int32)
      _t_name = Ctype(Reader("t_name"),String)
      _t_user = Ctype(Reader("t_user"),String)
      _t_mach = Ctype(Reader("t_mach"),String)
      _t_sdat = Ctype(Reader("t_sdat"),DateTime)
      _t_sorc = Ctype(Reader("t_sorc"),String)
      _t_crtp = Ctype(Reader("t_crtp"),Int32)
      _t_Refcntd = Ctype(Reader("t_Refcntd"),Int32)
      _t_Refcntu = Ctype(Reader("t_Refcntu"),Int32)
      _t_drdt = Ctype(Reader("t_drdt"),DateTime)
      _t_drur = Ctype(Reader("t_drur"),String)
      _t_aact = Ctype(Reader("t_aact"),Int32)
      _t_aact_1 = Ctype(Reader("t_aact_1"),Int32)
      _t_aact_2 = Ctype(Reader("t_aact_2"),Int32)
      _t_aact_3 = Ctype(Reader("t_aact_3"),Int32)
      _t_adat = Ctype(Reader("t_adat"),DateTime)
      _t_apre = Ctype(Reader("t_apre"),String)
      _t_atxt = Ctype(Reader("t_atxt"),Int32)
      _t_ausr = Ctype(Reader("t_ausr"),String)
      _t_dcrr = Ctype(Reader("t_dcrr"),Int32)
      _t_docs = Ctype(Reader("t_docs"),Int32)
      _t_drwd = Ctype(Reader("t_drwd"),String)
      _t_link = Ctype(Reader("t_link"),Int32)
      _t_pdfd = Ctype(Reader("t_pdfd"),String)
      _t_ract = Ctype(Reader("t_ract"),Int32)
      _t_ract_1 = Ctype(Reader("t_ract_1"),Int32)
      _t_ract_2 = Ctype(Reader("t_ract_2"),Int32)
      _t_rdat = Ctype(Reader("t_rdat"),DateTime)
      _t_rere = Ctype(Reader("t_rere"),String)
      _t_rtxt = Ctype(Reader("t_rtxt"),Int32)
      _t_rusr = Ctype(Reader("t_rusr"),String)
      _t_sudt = Ctype(Reader("t_sudt"),DateTime)
      _t_type = Ctype(Reader("t_type"),String)
      _t_wfst = Ctype(Reader("t_wfst"),Int32)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
