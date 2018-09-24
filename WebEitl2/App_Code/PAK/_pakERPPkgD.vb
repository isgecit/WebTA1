Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()>
  Partial Public Class pakERPPkgD
    'tdisg018200
    Private Shared _RecordCount As Integer
    Private _t_orno As String = ""
    Private _t_pkno As Int32 = 0
    Private _t_rcln As Int32 = 0
    Private _t_citm As String = ""
    Private _t_pkgn As Int32 = 0
    Private _t_bomn As Int32 = 0
    Private _t_cuni As String = ""
    Private _t_itmn As Int32 = 0
    Private _t_qnty As Double = 0
    Private _t_uwgt As Double = 0
    Private _t_twgt As Double = 0
    Private _t_docn As String = ""
    Private _t_revn As String = ""
    Private _t_ptyp As String = ""
    Private _t_pmrk As String = ""
    Private _t_leng As Double = 0
    Private _t_widt As Double = 0
    Private _t_hght As Double = 0
    Private _t_unit As String = ""
    Private _t_rcno As String = ""
    Private _t_srno As Int32 = 0
    Private _t_Refcntd As Int32 = 0
    Private _t_Refcntu As Int32 = 0
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
    Public Property t_orno() As String
      Get
        Return _t_orno
      End Get
      Set(ByVal value As String)
        _t_orno = value
      End Set
    End Property
    Public Property t_pkno() As Int32
      Get
        Return _t_pkno
      End Get
      Set(ByVal value As Int32)
        _t_pkno = value
      End Set
    End Property
    Public Property t_rcln() As Int32
      Get
        Return _t_rcln
      End Get
      Set(ByVal value As Int32)
        _t_rcln = value
      End Set
    End Property
    Public Property t_citm() As String
      Get
        Return _t_citm
      End Get
      Set(ByVal value As String)
        _t_citm = value
      End Set
    End Property
    Public Property t_pkgn() As Int32
      Get
        Return _t_pkgn
      End Get
      Set(ByVal value As Int32)
        _t_pkgn = value
      End Set
    End Property
    Public Property t_bomn() As Int32
      Get
        Return _t_bomn
      End Get
      Set(ByVal value As Int32)
        _t_bomn = value
      End Set
    End Property
    Public Property t_cuni() As String
      Get
        Return _t_cuni
      End Get
      Set(ByVal value As String)
        _t_cuni = value
      End Set
    End Property
    Public Property t_itmn() As Int32
      Get
        Return _t_itmn
      End Get
      Set(ByVal value As Int32)
        _t_itmn = value
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
    Public Property t_uwgt() As Double
      Get
        Return _t_uwgt
      End Get
      Set(ByVal value As Double)
        _t_uwgt = value
      End Set
    End Property
    Public Property t_twgt() As Double
      Get
        Return _t_twgt
      End Get
      Set(ByVal value As Double)
        _t_twgt = value
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
    Public Property t_revn() As String
      Get
        Return _t_revn
      End Get
      Set(ByVal value As String)
        _t_revn = value
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
    Public Property t_pmrk() As String
      Get
        Return _t_pmrk
      End Get
      Set(ByVal value As String)
        _t_pmrk = value
      End Set
    End Property
    Public Property t_leng() As Double
      Get
        Return _t_leng
      End Get
      Set(ByVal value As Double)
        _t_leng = value
      End Set
    End Property
    Public Property t_widt() As Double
      Get
        Return _t_widt
      End Get
      Set(ByVal value As Double)
        _t_widt = value
      End Set
    End Property
    Public Property t_hght() As Double
      Get
        Return _t_hght
      End Get
      Set(ByVal value As Double)
        _t_hght = value
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
    Public Property t_rcno() As String
      Get
        Return _t_rcno
      End Get
      Set(ByVal value As String)
        _t_rcno = value
      End Set
    End Property
    Public Property t_srno() As Int32
      Get
        Return _t_srno
      End Get
      Set(ByVal value As Int32)
        _t_srno = value
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
        Return _t_orno & "|" & _t_pkno & "|" & _t_rcln
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
    Public Class PKpakERPPkgD
      Private _t_orno As String = ""
      Private _t_pkno As Int32 = 0
      Private _t_rcln As Int32 = 0
      Public Property t_orno() As String
        Get
          Return _t_orno
        End Get
        Set(ByVal value As String)
          _t_orno = value
        End Set
      End Property
      Public Property t_pkno() As Int32
        Get
          Return _t_pkno
        End Get
        Set(ByVal value As Int32)
          _t_pkno = value
        End Set
      End Property
      Public Property t_rcln() As Int32
        Get
          Return _t_rcln
        End Get
        Set(ByVal value As Int32)
          _t_rcln = value
        End Set
      End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function pakERPPkgDGetNewRecord() As SIS.PAK.pakERPPkgD
      Return New SIS.PAK.pakERPPkgD()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function pakERPPkgDGetByID(ByVal t_orno As String, ByVal t_pkno As Int32, ByVal t_rcln As Int32) As SIS.PAK.pakERPPkgD
      Dim Results As SIS.PAK.pakERPPkgD = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakERPPkgDSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_orno", SqlDbType.VarChar, t_orno.ToString.Length, t_orno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_pkno", SqlDbType.Int, t_pkno.ToString.Length, t_pkno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rcln", SqlDbType.Int, t_rcln.ToString.Length, t_rcln)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakERPPkgD(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function pakERPPkgDSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_orno As String, ByVal t_pkno As Int32) As List(Of SIS.PAK.pakERPPkgD)
      Dim Results As List(Of SIS.PAK.pakERPPkgD) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakERPPkgDSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakERPPkgDSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_t_orno", SqlDbType.VarChar, 9, IIf(t_orno Is Nothing, String.Empty, t_orno))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_t_pkno", SqlDbType.Int, 10, IIf(t_pkno = Nothing, 0, t_pkno))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
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
    Public Shared Function pakERPPkgDSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_orno As String, ByVal t_pkno As Int32) As Integer
      Return _RecordCount
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function pakERPPkgDGetByID(ByVal t_orno As String, ByVal t_pkno As Int32, ByVal t_rcln As Int32, ByVal Filter_t_orno As String, ByVal Filter_t_pkno As Int32) As SIS.PAK.pakERPPkgD
      Return pakERPPkgDGetByID(t_orno, t_pkno, t_rcln)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)>
    Public Shared Function pakERPPkgDInsert(ByVal Record As SIS.PAK.pakERPPkgD) As SIS.PAK.pakERPPkgD
      Dim _Rec As SIS.PAK.pakERPPkgD = SIS.PAK.pakERPPkgD.pakERPPkgDGetNewRecord()
      With _Rec
        .t_orno = Record.t_orno
        .t_pkno = Record.t_pkno
        .t_rcln = Record.t_rcln
        .t_citm = Record.t_citm
        .t_pkgn = Record.t_pkgn
        .t_bomn = Record.t_bomn
        .t_cuni = Record.t_cuni
        .t_itmn = Record.t_itmn
        .t_qnty = Record.t_qnty
        .t_uwgt = Record.t_uwgt
        .t_twgt = Record.t_twgt
        .t_docn = Record.t_docn
        .t_revn = Record.t_revn
        .t_ptyp = Record.t_ptyp
        .t_pmrk = Record.t_pmrk
        .t_leng = Record.t_leng
        .t_widt = Record.t_widt
        .t_hght = Record.t_hght
        .t_unit = Record.t_unit
        .t_rcno = Record.t_rcno
        .t_srno = Record.t_srno
        .t_Refcntd = Record.t_Refcntd
        .t_Refcntu = Record.t_Refcntu
      End With
      Return SIS.PAK.pakERPPkgD.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PAK.pakERPPkgD) As SIS.PAK.pakERPPkgD
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakERPPkgDInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_orno", SqlDbType.VarChar, 10, Record.t_orno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_pkno", SqlDbType.Int, 11, Record.t_pkno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rcln", SqlDbType.Int, 11, Record.t_rcln)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_citm", SqlDbType.VarChar, 48, Record.t_citm)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_pkgn", SqlDbType.Int, 11, Record.t_pkgn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_bomn", SqlDbType.Int, 11, Record.t_bomn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cuni", SqlDbType.VarChar, 4, Record.t_cuni)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_itmn", SqlDbType.Int, 11, Record.t_itmn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_qnty", SqlDbType.Float, 16, Record.t_qnty)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_uwgt", SqlDbType.Float, 16, Record.t_uwgt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_twgt", SqlDbType.Float, 16, Record.t_twgt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_docn", SqlDbType.VarChar, 33, Record.t_docn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_revn", SqlDbType.VarChar, 33, Record.t_revn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ptyp", SqlDbType.VarChar, 31, Record.t_ptyp)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_pmrk", SqlDbType.VarChar, 101, Record.t_pmrk)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_leng", SqlDbType.Float, 16, Record.t_leng)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_widt", SqlDbType.Float, 16, Record.t_widt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_hght", SqlDbType.Float, 16, Record.t_hght)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_unit", SqlDbType.VarChar, 4, Record.t_unit)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rcno", SqlDbType.VarChar, 10, Record.t_rcno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_srno", SqlDbType.Int, 11, Record.t_srno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntd", SqlDbType.Int, 11, Record.t_Refcntd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntu", SqlDbType.Int, 11, Record.t_Refcntu)
          Cmd.Parameters.Add("@Return_t_orno", SqlDbType.VarChar, 10)
          Cmd.Parameters("@Return_t_orno").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_t_pkno", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_t_pkno").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_t_rcln", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_t_rcln").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.t_orno = Cmd.Parameters("@Return_t_orno").Value
          Record.t_pkno = Cmd.Parameters("@Return_t_pkno").Value
          Record.t_rcln = Cmd.Parameters("@Return_t_rcln").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)>
    Public Shared Function pakERPPkgDUpdate(ByVal Record As SIS.PAK.pakERPPkgD) As SIS.PAK.pakERPPkgD
      Dim _Rec As SIS.PAK.pakERPPkgD = SIS.PAK.pakERPPkgD.pakERPPkgDGetByID(Record.t_orno, Record.t_pkno, Record.t_rcln)
      With _Rec
        .t_citm = Record.t_citm
        .t_pkgn = Record.t_pkgn
        .t_bomn = Record.t_bomn
        .t_cuni = Record.t_cuni
        .t_itmn = Record.t_itmn
        .t_qnty = Record.t_qnty
        .t_uwgt = Record.t_uwgt
        .t_twgt = Record.t_twgt
        .t_docn = Record.t_docn
        .t_revn = Record.t_revn
        .t_ptyp = Record.t_ptyp
        .t_pmrk = Record.t_pmrk
        .t_leng = Record.t_leng
        .t_widt = Record.t_widt
        .t_hght = Record.t_hght
        .t_unit = Record.t_unit
        .t_rcno = Record.t_rcno
        .t_srno = Record.t_srno
        .t_Refcntd = Record.t_Refcntd
        .t_Refcntu = Record.t_Refcntu
      End With
      Return SIS.PAK.pakERPPkgD.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PAK.pakERPPkgD) As SIS.PAK.pakERPPkgD
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakERPPkgDUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_orno", SqlDbType.VarChar, 10, Record.t_orno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_pkno", SqlDbType.Int, 11, Record.t_pkno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_rcln", SqlDbType.Int, 11, Record.t_rcln)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_orno", SqlDbType.VarChar, 10, Record.t_orno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_pkno", SqlDbType.Int, 11, Record.t_pkno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rcln", SqlDbType.Int, 11, Record.t_rcln)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_citm", SqlDbType.VarChar, 48, Record.t_citm)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_pkgn", SqlDbType.Int, 11, Record.t_pkgn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_bomn", SqlDbType.Int, 11, Record.t_bomn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_cuni", SqlDbType.VarChar, 4, Record.t_cuni)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_itmn", SqlDbType.Int, 11, Record.t_itmn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_qnty", SqlDbType.Float, 16, Record.t_qnty)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_uwgt", SqlDbType.Float, 16, Record.t_uwgt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_twgt", SqlDbType.Float, 16, Record.t_twgt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_docn", SqlDbType.VarChar, 33, Record.t_docn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_revn", SqlDbType.VarChar, 33, Record.t_revn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ptyp", SqlDbType.VarChar, 31, Record.t_ptyp)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_pmrk", SqlDbType.VarChar, 101, Record.t_pmrk)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_leng", SqlDbType.Float, 16, Record.t_leng)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_widt", SqlDbType.Float, 16, Record.t_widt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_hght", SqlDbType.Float, 16, Record.t_hght)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_unit", SqlDbType.VarChar, 4, Record.t_unit)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rcno", SqlDbType.VarChar, 10, Record.t_rcno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_srno", SqlDbType.Int, 11, Record.t_srno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntd", SqlDbType.Int, 11, Record.t_Refcntd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntu", SqlDbType.Int, 11, Record.t_Refcntu)
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
    Public Shared Function pakERPPkgDDelete(ByVal Record As SIS.PAK.pakERPPkgD) As Int32
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakERPPkgDDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_orno", SqlDbType.VarChar, Record.t_orno.ToString.Length, Record.t_orno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_pkno", SqlDbType.Int, Record.t_pkno.ToString.Length, Record.t_pkno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_rcln", SqlDbType.Int, Record.t_rcln.ToString.Length, Record.t_rcln)
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
