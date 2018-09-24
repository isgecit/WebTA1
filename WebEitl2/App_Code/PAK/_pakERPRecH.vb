Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakERPRecH
    Private Shared _RecordCount As Integer
    Private _t_rcno As String = ""
    Private _t_revn As String = ""
    Private _t_cprj As String = ""
    Private _t_item As String = ""
    Private _t_bpid As String = ""
    Private _t_nama As String = ""
    Private _t_stat As Int32 = 0
    Private _t_user As String = ""
    Private _t_date As String = ""
    Private _t_sent_1 As Int32 = 0
    Private _t_sent_2 As Int32 = 0
    Private _t_sent_3 As Int32 = 0
    Private _t_sent_4 As Int32 = 0
    Private _t_sent_5 As Int32 = 0
    Private _t_sent_6 As Int32 = 0
    Private _t_sent_7 As Int32 = 0
    Private _t_rece_1 As Int32 = 0
    Private _t_rece_2 As Int32 = 0
    Private _t_rece_3 As Int32 = 0
    Private _t_rece_4 As Int32 = 0
    Private _t_rece_5 As Int32 = 0
    Private _t_rece_6 As Int32 = 0
    Private _t_rece_7 As Int32 = 0
    Private _t_suer As String = ""
    Private _t_sdat As String = ""
    Private _t_appr As String = ""
    Private _t_adat As String = ""
    Private _t_subm_1 As Int32 = 0
    Private _t_subm_2 As Int32 = 0
    Private _t_subm_3 As Int32 = 0
    Private _t_subm_4 As Int32 = 0
    Private _t_subm_5 As Int32 = 0
    Private _t_subm_6 As Int32 = 0
    Private _t_subm_7 As Int32 = 0
    Private _t_orno As String = ""
    Private _t_pono As Int32 = 0
    Private _t_trno As String = ""
    Private _t_Refcntd As Int32 = 0
    Private _t_Refcntu As Int32 = 0
    Private _t_docn As String = ""
    Private _t_eunt As String = ""
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
    Public Property t_rcno() As String
      Get
        Return _t_rcno
      End Get
      Set(ByVal value As String)
        _t_rcno = value
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
    Public Property t_cprj() As String
      Get
        Return _t_cprj
      End Get
      Set(ByVal value As String)
        _t_cprj = value
      End Set
    End Property
    Public Property t_item() As String
      Get
        Return _t_item
      End Get
      Set(ByVal value As String)
        _t_item = value
      End Set
    End Property
    Public Property t_bpid() As String
      Get
        Return _t_bpid
      End Get
      Set(ByVal value As String)
        _t_bpid = value
      End Set
    End Property
    Public Property t_nama() As String
      Get
        Return _t_nama
      End Get
      Set(ByVal value As String)
        _t_nama = value
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
    Public Property t_user() As String
      Get
        Return _t_user
      End Get
      Set(ByVal value As String)
        _t_user = value
      End Set
    End Property
    Public Property t_date() As String
      Get
        If Not _t_date = String.Empty Then
          Return Convert.ToDateTime(_t_date).ToString("dd/MM/yyyy")
        End If
        Return _t_date
      End Get
      Set(ByVal value As String)
         _t_date = value
      End Set
    End Property
    Public Property t_sent_1() As Int32
      Get
        Return _t_sent_1
      End Get
      Set(ByVal value As Int32)
        _t_sent_1 = value
      End Set
    End Property
    Public Property t_sent_2() As Int32
      Get
        Return _t_sent_2
      End Get
      Set(ByVal value As Int32)
        _t_sent_2 = value
      End Set
    End Property
    Public Property t_sent_3() As Int32
      Get
        Return _t_sent_3
      End Get
      Set(ByVal value As Int32)
        _t_sent_3 = value
      End Set
    End Property
    Public Property t_sent_4() As Int32
      Get
        Return _t_sent_4
      End Get
      Set(ByVal value As Int32)
        _t_sent_4 = value
      End Set
    End Property
    Public Property t_sent_5() As Int32
      Get
        Return _t_sent_5
      End Get
      Set(ByVal value As Int32)
        _t_sent_5 = value
      End Set
    End Property
    Public Property t_sent_6() As Int32
      Get
        Return _t_sent_6
      End Get
      Set(ByVal value As Int32)
        _t_sent_6 = value
      End Set
    End Property
    Public Property t_sent_7() As Int32
      Get
        Return _t_sent_7
      End Get
      Set(ByVal value As Int32)
        _t_sent_7 = value
      End Set
    End Property
    Public Property t_rece_1() As Int32
      Get
        Return _t_rece_1
      End Get
      Set(ByVal value As Int32)
        _t_rece_1 = value
      End Set
    End Property
    Public Property t_rece_2() As Int32
      Get
        Return _t_rece_2
      End Get
      Set(ByVal value As Int32)
        _t_rece_2 = value
      End Set
    End Property
    Public Property t_rece_3() As Int32
      Get
        Return _t_rece_3
      End Get
      Set(ByVal value As Int32)
        _t_rece_3 = value
      End Set
    End Property
    Public Property t_rece_4() As Int32
      Get
        Return _t_rece_4
      End Get
      Set(ByVal value As Int32)
        _t_rece_4 = value
      End Set
    End Property
    Public Property t_rece_5() As Int32
      Get
        Return _t_rece_5
      End Get
      Set(ByVal value As Int32)
        _t_rece_5 = value
      End Set
    End Property
    Public Property t_rece_6() As Int32
      Get
        Return _t_rece_6
      End Get
      Set(ByVal value As Int32)
        _t_rece_6 = value
      End Set
    End Property
    Public Property t_rece_7() As Int32
      Get
        Return _t_rece_7
      End Get
      Set(ByVal value As Int32)
        _t_rece_7 = value
      End Set
    End Property
    Public Property t_suer() As String
      Get
        Return _t_suer
      End Get
      Set(ByVal value As String)
        _t_suer = value
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
    Public Property t_appr() As String
      Get
        Return _t_appr
      End Get
      Set(ByVal value As String)
        _t_appr = value
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
    Public Property t_subm_1() As Int32
      Get
        Return _t_subm_1
      End Get
      Set(ByVal value As Int32)
        _t_subm_1 = value
      End Set
    End Property
    Public Property t_subm_2() As Int32
      Get
        Return _t_subm_2
      End Get
      Set(ByVal value As Int32)
        _t_subm_2 = value
      End Set
    End Property
    Public Property t_subm_3() As Int32
      Get
        Return _t_subm_3
      End Get
      Set(ByVal value As Int32)
        _t_subm_3 = value
      End Set
    End Property
    Public Property t_subm_4() As Int32
      Get
        Return _t_subm_4
      End Get
      Set(ByVal value As Int32)
        _t_subm_4 = value
      End Set
    End Property
    Public Property t_subm_5() As Int32
      Get
        Return _t_subm_5
      End Get
      Set(ByVal value As Int32)
        _t_subm_5 = value
      End Set
    End Property
    Public Property t_subm_6() As Int32
      Get
        Return _t_subm_6
      End Get
      Set(ByVal value As Int32)
        _t_subm_6 = value
      End Set
    End Property
    Public Property t_subm_7() As Int32
      Get
        Return _t_subm_7
      End Get
      Set(ByVal value As Int32)
        _t_subm_7 = value
      End Set
    End Property
    Public Property t_orno() As String
      Get
        Return _t_orno
      End Get
      Set(ByVal value As String)
        _t_orno = value
      End Set
    End Property
    Public Property t_pono() As Int32
      Get
        Return _t_pono
      End Get
      Set(ByVal value As Int32)
        _t_pono = value
      End Set
    End Property
    Public Property t_trno() As String
      Get
        Return _t_trno
      End Get
      Set(ByVal value As String)
        _t_trno = value
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
    Public Property t_docn() As String
      Get
        Return _t_docn
      End Get
      Set(ByVal value As String)
        _t_docn = value
      End Set
    End Property
    Public Property t_eunt() As String
      Get
        Return _t_eunt
      End Get
      Set(ByVal value As String)
        _t_eunt = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _t_rcno & "|" & _t_revn
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
    Public Class PKpakERPRecH
      Private _t_rcno As String = ""
      Private _t_revn As String = ""
      Public Property t_rcno() As String
        Get
          Return _t_rcno
        End Get
        Set(ByVal value As String)
          _t_rcno = value
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
    Public Shared Function pakERPRecHGetNewRecord() As SIS.PAK.pakERPRecH
      Return New SIS.PAK.pakERPRecH()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakERPRecHGetByID(ByVal t_rcno As String, ByVal t_revn As String) As SIS.PAK.pakERPRecH
      Dim Results As SIS.PAK.pakERPRecH = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakERPRecHSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rcno", SqlDbType.VarChar, t_rcno.ToString.Length, t_rcno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_revn", SqlDbType.VarChar, t_revn.ToString.Length, t_revn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakERPRecH(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakERPRecHSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.PAK.pakERPRecH)
      Dim Results As List(Of SIS.PAK.pakERPRecH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakERPRecHSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakERPRecHSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
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
    Public Shared Function pakERPRecHSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function pakERPRecHInsert(ByVal Record As SIS.PAK.pakERPRecH) As SIS.PAK.pakERPRecH
      Dim _Rec As SIS.PAK.pakERPRecH = SIS.PAK.pakERPRecH.pakERPRecHGetNewRecord()
      With _Rec
        .t_rcno = Record.t_rcno
        .t_revn = Record.t_revn
        .t_cprj = Record.t_cprj
        .t_item = Record.t_item
        .t_bpid = Record.t_bpid
        .t_nama = Record.t_nama
        .t_stat = Record.t_stat
        .t_user = Record.t_user
        .t_date = Record.t_date
        .t_sent_1 = Record.t_sent_1
        .t_sent_2 = Record.t_sent_2
        .t_sent_3 = Record.t_sent_3
        .t_sent_4 = Record.t_sent_4
        .t_sent_5 = Record.t_sent_5
        .t_sent_6 = Record.t_sent_6
        .t_sent_7 = Record.t_sent_7
        .t_rece_1 = Record.t_rece_1
        .t_rece_2 = Record.t_rece_2
        .t_rece_3 = Record.t_rece_3
        .t_rece_4 = Record.t_rece_4
        .t_rece_5 = Record.t_rece_5
        .t_rece_6 = Record.t_rece_6
        .t_rece_7 = Record.t_rece_7
        .t_suer = Record.t_suer
        .t_sdat = Record.t_sdat
        .t_appr = Record.t_appr
        .t_adat = Record.t_adat
        .t_subm_1 = Record.t_subm_1
        .t_subm_2 = Record.t_subm_2
        .t_subm_3 = Record.t_subm_3
        .t_subm_4 = Record.t_subm_4
        .t_subm_5 = Record.t_subm_5
        .t_subm_6 = Record.t_subm_6
        .t_subm_7 = Record.t_subm_7
        .t_orno = Record.t_orno
        .t_pono = Record.t_pono
        .t_trno = Record.t_trno
        .t_Refcntd = Record.t_Refcntd
        .t_Refcntu = Record.t_Refcntu
        .t_docn = Record.t_docn
        .t_eunt = Record.t_eunt
      End With
      Return SIS.PAK.pakERPRecH.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PAK.pakERPRecH) As SIS.PAK.pakERPRecH
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakERPRecHInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rcno", SqlDbType.VarChar, 10, Record.t_rcno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_revn", SqlDbType.VarChar, 21, Record.t_revn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj", SqlDbType.VarChar, 10, Record.t_cprj)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_item", SqlDbType.VarChar, 48, Record.t_item)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_bpid", SqlDbType.VarChar, 10, Record.t_bpid)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_nama", SqlDbType.VarChar, 36, Record.t_nama)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_stat", SqlDbType.Int, 11, Record.t_stat)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_user", SqlDbType.VarChar, 17, Record.t_user)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_date", SqlDbType.DateTime, 21, Record.t_date)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sent_1", SqlDbType.Int, 11, Record.t_sent_1)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sent_2", SqlDbType.Int, 11, Record.t_sent_2)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sent_3", SqlDbType.Int, 11, Record.t_sent_3)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sent_4", SqlDbType.Int, 11, Record.t_sent_4)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sent_5", SqlDbType.Int, 11, Record.t_sent_5)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sent_6", SqlDbType.Int, 11, Record.t_sent_6)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sent_7", SqlDbType.Int, 11, Record.t_sent_7)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rece_1", SqlDbType.Int, 11, Record.t_rece_1)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rece_2", SqlDbType.Int, 11, Record.t_rece_2)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rece_3", SqlDbType.Int, 11, Record.t_rece_3)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rece_4", SqlDbType.Int, 11, Record.t_rece_4)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rece_5", SqlDbType.Int, 11, Record.t_rece_5)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rece_6", SqlDbType.Int, 11, Record.t_rece_6)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rece_7", SqlDbType.Int, 11, Record.t_rece_7)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_suer", SqlDbType.VarChar, 17, Record.t_suer)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sdat", SqlDbType.DateTime, 21, Record.t_sdat)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_appr", SqlDbType.VarChar, 17, Record.t_appr)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_adat", SqlDbType.DateTime, 21, Record.t_adat)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_subm_1", SqlDbType.Int, 11, Record.t_subm_1)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_subm_2", SqlDbType.Int, 11, Record.t_subm_2)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_subm_3", SqlDbType.Int, 11, Record.t_subm_3)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_subm_4", SqlDbType.Int, 11, Record.t_subm_4)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_subm_5", SqlDbType.Int, 11, Record.t_subm_5)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_subm_6", SqlDbType.Int, 11, Record.t_subm_6)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_subm_7", SqlDbType.Int, 11, Record.t_subm_7)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_orno", SqlDbType.VarChar, 10, Record.t_orno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_pono", SqlDbType.Int, 11, Record.t_pono)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_trno", SqlDbType.VarChar, 10, Record.t_trno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntd", SqlDbType.Int, 11, Record.t_Refcntd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntu", SqlDbType.Int, 11, Record.t_Refcntu)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_docn", SqlDbType.VarChar, 4, Record.t_docn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_eunt", SqlDbType.VarChar, 7, Record.t_eunt)
          Cmd.Parameters.Add("@Return_t_rcno", SqlDbType.VarChar, 10)
          Cmd.Parameters("@Return_t_rcno").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_t_revn", SqlDbType.VarChar, 21)
          Cmd.Parameters("@Return_t_revn").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.t_rcno = Cmd.Parameters("@Return_t_rcno").Value
          Record.t_revn = Cmd.Parameters("@Return_t_revn").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakERPRecHUpdate(ByVal Record As SIS.PAK.pakERPRecH) As SIS.PAK.pakERPRecH
      Dim _Rec As SIS.PAK.pakERPRecH = SIS.PAK.pakERPRecH.pakERPRecHGetByID(Record.t_rcno, Record.t_revn)
      With _Rec
        .t_cprj = Record.t_cprj
        .t_item = Record.t_item
        .t_bpid = Record.t_bpid
        .t_nama = Record.t_nama
        .t_stat = Record.t_stat
        .t_user = Record.t_user
        .t_date = Record.t_date
        .t_sent_1 = Record.t_sent_1
        .t_sent_2 = Record.t_sent_2
        .t_sent_3 = Record.t_sent_3
        .t_sent_4 = Record.t_sent_4
        .t_sent_5 = Record.t_sent_5
        .t_sent_6 = Record.t_sent_6
        .t_sent_7 = Record.t_sent_7
        .t_rece_1 = Record.t_rece_1
        .t_rece_2 = Record.t_rece_2
        .t_rece_3 = Record.t_rece_3
        .t_rece_4 = Record.t_rece_4
        .t_rece_5 = Record.t_rece_5
        .t_rece_6 = Record.t_rece_6
        .t_rece_7 = Record.t_rece_7
        .t_suer = Record.t_suer
        .t_sdat = Record.t_sdat
        .t_appr = Record.t_appr
        .t_adat = Record.t_adat
        .t_subm_1 = Record.t_subm_1
        .t_subm_2 = Record.t_subm_2
        .t_subm_3 = Record.t_subm_3
        .t_subm_4 = Record.t_subm_4
        .t_subm_5 = Record.t_subm_5
        .t_subm_6 = Record.t_subm_6
        .t_subm_7 = Record.t_subm_7
        .t_orno = Record.t_orno
        .t_pono = Record.t_pono
        .t_trno = Record.t_trno
        .t_Refcntd = Record.t_Refcntd
        .t_Refcntu = Record.t_Refcntu
        .t_docn = Record.t_docn
        .t_eunt = Record.t_eunt
      End With
      Return SIS.PAK.pakERPRecH.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PAK.pakERPRecH) As SIS.PAK.pakERPRecH
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakERPRecHUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_rcno",SqlDbType.VarChar,10, Record.t_rcno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_revn",SqlDbType.VarChar,21, Record.t_revn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rcno",SqlDbType.VarChar,10, Record.t_rcno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_revn",SqlDbType.VarChar,21, Record.t_revn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cprj",SqlDbType.VarChar,10, Record.t_cprj)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_item",SqlDbType.VarChar,48, Record.t_item)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_bpid",SqlDbType.VarChar,10, Record.t_bpid)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_nama",SqlDbType.VarChar,36, Record.t_nama)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_stat",SqlDbType.Int,11, Record.t_stat)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_user",SqlDbType.VarChar,17, Record.t_user)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_date",SqlDbType.DateTime,21, Record.t_date)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sent_1",SqlDbType.Int,11, Record.t_sent_1)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sent_2",SqlDbType.Int,11, Record.t_sent_2)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sent_3",SqlDbType.Int,11, Record.t_sent_3)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sent_4",SqlDbType.Int,11, Record.t_sent_4)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sent_5",SqlDbType.Int,11, Record.t_sent_5)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sent_6",SqlDbType.Int,11, Record.t_sent_6)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sent_7",SqlDbType.Int,11, Record.t_sent_7)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rece_1",SqlDbType.Int,11, Record.t_rece_1)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rece_2",SqlDbType.Int,11, Record.t_rece_2)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rece_3",SqlDbType.Int,11, Record.t_rece_3)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rece_4",SqlDbType.Int,11, Record.t_rece_4)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rece_5",SqlDbType.Int,11, Record.t_rece_5)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rece_6",SqlDbType.Int,11, Record.t_rece_6)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rece_7",SqlDbType.Int,11, Record.t_rece_7)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_suer",SqlDbType.VarChar,17, Record.t_suer)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_sdat",SqlDbType.DateTime,21, Record.t_sdat)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_appr",SqlDbType.VarChar,17, Record.t_appr)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_adat",SqlDbType.DateTime,21, Record.t_adat)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_subm_1",SqlDbType.Int,11, Record.t_subm_1)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_subm_2",SqlDbType.Int,11, Record.t_subm_2)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_subm_3",SqlDbType.Int,11, Record.t_subm_3)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_subm_4",SqlDbType.Int,11, Record.t_subm_4)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_subm_5",SqlDbType.Int,11, Record.t_subm_5)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_subm_6",SqlDbType.Int,11, Record.t_subm_6)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_subm_7",SqlDbType.Int,11, Record.t_subm_7)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_orno",SqlDbType.VarChar,10, Record.t_orno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_pono",SqlDbType.Int,11, Record.t_pono)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_trno",SqlDbType.VarChar,10, Record.t_trno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntd",SqlDbType.Int,11, Record.t_Refcntd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntu",SqlDbType.Int,11, Record.t_Refcntu)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_docn",SqlDbType.VarChar,4, Record.t_docn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_eunt",SqlDbType.VarChar,7, Record.t_eunt)
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
    Public Shared Function pakERPRecHDelete(ByVal Record As SIS.PAK.pakERPRecH) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakERPRecHDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_rcno",SqlDbType.VarChar,Record.t_rcno.ToString.Length, Record.t_rcno)
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
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              Dim Found As Boolean = False
              For I As Integer = 0 To Reader.FieldCount - 1
                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                  Found = True
                  Exit For
                End If
              Next
              If Found Then
                If Convert.IsDBNull(Reader(pi.Name)) Then
                  Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                    Case "decimal"
                      CallByName(Me, pi.Name, CallType.Let, "0.00")
                    Case "bit"
                      CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                    Case Else
                      CallByName(Me, pi.Name, CallType.Let, String.Empty)
                  End Select
                Else
                  CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                End If
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
