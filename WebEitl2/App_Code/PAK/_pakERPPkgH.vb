Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()>
  Partial Public Class pakERPPkgH
    'tdisg017200
    Private Shared _RecordCount As Integer
    Private _t_orno As String = ""
    Private _t_pkno As Int32 = 0
    Private _t_srno As Int32 = 0
    Private _t_pkgn As Int32 = 0
    Private _t_rcno As String = ""
    Private _t_isup As String = ""
    Private _t_pkdt As String = ""
    Private _t_ntwt As Double = 0
    Private _t_grwt As Double = 0
    Private _t_tnam As String = ""
    Private _t_vhno As String = ""
    Private _t_lrno As String = ""
    Private _t_lrdt As String = ""
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
    Public Property t_srno() As Int32
      Get
        Return _t_srno
      End Get
      Set(ByVal value As Int32)
        _t_srno = value
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
    Public Property t_rcno() As String
      Get
        Return _t_rcno
      End Get
      Set(ByVal value As String)
        _t_rcno = value
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
    Public Property t_pkdt() As String
      Get
        If Not _t_pkdt = String.Empty Then
          Return Convert.ToDateTime(_t_pkdt).ToString("dd/MM/yyyy")
        End If
        Return _t_pkdt
      End Get
      Set(ByVal value As String)
        _t_pkdt = value
      End Set
    End Property
    Public Property t_ntwt() As Double
      Get
        Return _t_ntwt
      End Get
      Set(ByVal value As Double)
        _t_ntwt = value
      End Set
    End Property
    Public Property t_grwt() As Double
      Get
        Return _t_grwt
      End Get
      Set(ByVal value As Double)
        _t_grwt = value
      End Set
    End Property
    Public Property t_tnam() As String
      Get
        Return _t_tnam
      End Get
      Set(ByVal value As String)
        _t_tnam = value
      End Set
    End Property
    Public Property t_vhno() As String
      Get
        Return _t_vhno
      End Get
      Set(ByVal value As String)
        _t_vhno = value
      End Set
    End Property
    Public Property t_lrno() As String
      Get
        Return _t_lrno
      End Get
      Set(ByVal value As String)
        _t_lrno = value
      End Set
    End Property
    Public Property t_lrdt() As String
      Get
        If Not _t_lrdt = String.Empty Then
          Return Convert.ToDateTime(_t_lrdt).ToString("dd/MM/yyyy")
        End If
        Return _t_lrdt
      End Get
      Set(ByVal value As String)
        _t_lrdt = value
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
        Return _t_orno & "|" & _t_pkno
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
    Public Class PKpakERPPkgH
      Private _t_orno As String = ""
      Private _t_pkno As Int32 = 0
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
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function pakERPPkgHGetNewRecord() As SIS.PAK.pakERPPkgH
      Return New SIS.PAK.pakERPPkgH()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function pakERPPkgHGetByID(ByVal t_orno As String, ByVal t_pkno As Int32) As SIS.PAK.pakERPPkgH
      Dim Results As SIS.PAK.pakERPPkgH = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakERPPkgHSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_orno", SqlDbType.VarChar, t_orno.ToString.Length, t_orno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_pkno", SqlDbType.Int, t_pkno.ToString.Length, t_pkno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakERPPkgH(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function pakERPPkgHSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_orno As String) As List(Of SIS.PAK.pakERPPkgH)
      Dim Results As List(Of SIS.PAK.pakERPPkgH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakERPPkgHSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakERPPkgHSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_t_orno", SqlDbType.VarChar, 9, IIf(t_orno Is Nothing, String.Empty, t_orno))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
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
    Public Shared Function pakERPPkgHSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_orno As String) As Integer
      Return _RecordCount
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function pakERPPkgHGetByID(ByVal t_orno As String, ByVal t_pkno As Int32, ByVal Filter_t_orno As String) As SIS.PAK.pakERPPkgH
      Return pakERPPkgHGetByID(t_orno, t_pkno)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)>
    Public Shared Function pakERPPkgHInsert(ByVal Record As SIS.PAK.pakERPPkgH) As SIS.PAK.pakERPPkgH
      Dim _Rec As SIS.PAK.pakERPPkgH = SIS.PAK.pakERPPkgH.pakERPPkgHGetNewRecord()
      With _Rec
        .t_orno = Record.t_orno
        .t_pkno = Record.t_pkno
        .t_srno = Record.t_srno
        .t_pkgn = Record.t_pkgn
        .t_rcno = Record.t_rcno
        .t_isup = Record.t_isup
        .t_pkdt = Record.t_pkdt
        .t_ntwt = Record.t_ntwt
        .t_grwt = Record.t_grwt
        .t_tnam = Record.t_tnam
        .t_vhno = Record.t_vhno
        .t_lrno = Record.t_lrno
        .t_lrdt = Record.t_lrdt
        .t_Refcntd = Record.t_Refcntd
        .t_Refcntu = Record.t_Refcntu
      End With
      Return SIS.PAK.pakERPPkgH.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PAK.pakERPPkgH) As SIS.PAK.pakERPPkgH
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakERPPkgHInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_orno", SqlDbType.VarChar, 10, Record.t_orno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_pkno", SqlDbType.Int, 11, Record.t_pkno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_srno", SqlDbType.Int, 11, Record.t_srno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_pkgn", SqlDbType.Int, 11, Record.t_pkgn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rcno", SqlDbType.VarChar, 10, Record.t_rcno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_isup", SqlDbType.VarChar, 31, Record.t_isup)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_pkdt", SqlDbType.DateTime, 21, Record.t_pkdt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ntwt", SqlDbType.Float, 16, Record.t_ntwt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_grwt", SqlDbType.Float, 16, Record.t_grwt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_tnam", SqlDbType.VarChar, 36, Record.t_tnam)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_vhno", SqlDbType.VarChar, 16, Record.t_vhno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_lrno", SqlDbType.VarChar, 31, Record.t_lrno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_lrdt", SqlDbType.DateTime, 21, Record.t_lrdt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntd", SqlDbType.Int, 11, Record.t_Refcntd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntu", SqlDbType.Int, 11, Record.t_Refcntu)
          Cmd.Parameters.Add("@Return_t_orno", SqlDbType.VarChar, 10)
          Cmd.Parameters("@Return_t_orno").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_t_pkno", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_t_pkno").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.t_orno = Cmd.Parameters("@Return_t_orno").Value
          Record.t_pkno = Cmd.Parameters("@Return_t_pkno").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)>
    Public Shared Function pakERPPkgHUpdate(ByVal Record As SIS.PAK.pakERPPkgH) As SIS.PAK.pakERPPkgH
      Dim _Rec As SIS.PAK.pakERPPkgH = SIS.PAK.pakERPPkgH.pakERPPkgHGetByID(Record.t_orno, Record.t_pkno)
      With _Rec
        .t_srno = Record.t_srno
        .t_pkgn = Record.t_pkgn
        .t_rcno = Record.t_rcno
        .t_isup = Record.t_isup
        .t_pkdt = Record.t_pkdt
        .t_ntwt = Record.t_ntwt
        .t_grwt = Record.t_grwt
        .t_tnam = Record.t_tnam
        .t_vhno = Record.t_vhno
        .t_lrno = Record.t_lrno
        .t_lrdt = Record.t_lrdt
        .t_Refcntd = Record.t_Refcntd
        .t_Refcntu = Record.t_Refcntu
      End With
      Return SIS.PAK.pakERPPkgH.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PAK.pakERPPkgH) As SIS.PAK.pakERPPkgH
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakERPPkgHUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_orno", SqlDbType.VarChar, 10, Record.t_orno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_pkno", SqlDbType.Int, 11, Record.t_pkno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_orno", SqlDbType.VarChar, 10, Record.t_orno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_pkno", SqlDbType.Int, 11, Record.t_pkno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_srno", SqlDbType.Int, 11, Record.t_srno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_pkgn", SqlDbType.Int, 11, Record.t_pkgn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rcno", SqlDbType.VarChar, 10, Record.t_rcno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_isup", SqlDbType.VarChar, 31, Record.t_isup)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_pkdt", SqlDbType.DateTime, 21, Record.t_pkdt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_ntwt", SqlDbType.Float, 16, Record.t_ntwt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_grwt", SqlDbType.Float, 16, Record.t_grwt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_tnam", SqlDbType.VarChar, 36, Record.t_tnam)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_vhno", SqlDbType.VarChar, 16, Record.t_vhno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_lrno", SqlDbType.VarChar, 31, Record.t_lrno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_lrdt", SqlDbType.DateTime, 21, Record.t_lrdt)
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
    Public Shared Function pakERPPkgHDelete(ByVal Record As SIS.PAK.pakERPPkgH) As Int32
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakERPPkgHDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_orno", SqlDbType.VarChar, Record.t_orno.ToString.Length, Record.t_orno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_pkno", SqlDbType.Int, Record.t_pkno.ToString.Length, Record.t_pkno)
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
