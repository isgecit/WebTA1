Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakERPRecD
    Private Shared _RecordCount As Integer
    Private _t_rcno As String = ""
    Private _t_revn As String = ""
    Private _t_srno As Int32 = 0
    Private _t_docn As String = ""
    Private _t_revi As String = ""
    Private _t_dsca As String = ""
    Private _t_idoc As String = ""
    Private _t_irev As String = ""
    Private _t_date As String = ""
    Private _t_remk As String = ""
    Private _t_proc As Int32 = 0
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
    Public Property t_srno() As Int32
      Get
        Return _t_srno
      End Get
      Set(ByVal value As Int32)
        _t_srno = value
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
    Public Property t_revi() As String
      Get
        Return _t_revi
      End Get
      Set(ByVal value As String)
        _t_revi = value
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
    Public Property t_idoc() As String
      Get
        Return _t_idoc
      End Get
      Set(ByVal value As String)
        _t_idoc = value
      End Set
    End Property
    Public Property t_irev() As String
      Get
        Return _t_irev
      End Get
      Set(ByVal value As String)
        _t_irev = value
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
    Public Property t_remk() As String
      Get
        Return _t_remk
      End Get
      Set(ByVal value As String)
        _t_remk = value
      End Set
    End Property
    Public Property t_proc() As Int32
      Get
        Return _t_proc
      End Get
      Set(ByVal value As Int32)
        _t_proc = value
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
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _t_rcno & "|" & _t_revn & "|" & _t_srno
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
    Public Class PKpakERPRecD
      Private _t_rcno As String = ""
      Private _t_revn As String = ""
      Private _t_srno As Int32 = 0
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
      Public Property t_srno() As Int32
        Get
          Return _t_srno
        End Get
        Set(ByVal value As Int32)
          _t_srno = value
        End Set
      End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakERPRecDGetNewRecord() As SIS.PAK.pakERPRecD
      Return New SIS.PAK.pakERPRecD()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakERPRecDGetByID(ByVal t_rcno As String, ByVal t_revn As String, ByVal t_srno As Int32) As SIS.PAK.pakERPRecD
      Dim Results As SIS.PAK.pakERPRecD = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakERPRecDSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rcno",SqlDbType.VarChar,t_rcno.ToString.Length, t_rcno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_revn",SqlDbType.VarChar,t_revn.ToString.Length, t_revn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_srno",SqlDbType.Int,t_srno.ToString.Length, t_srno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakERPRecD(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakERPRecDSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_rcno As String, ByVal t_revn As String) As List(Of SIS.PAK.pakERPRecD)
      Dim Results As List(Of SIS.PAK.pakERPRecD) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakERPRecDSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakERPRecDSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_t_rcno",SqlDbType.VarChar,9, IIf(t_rcno Is Nothing, String.Empty,t_rcno))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_t_revn",SqlDbType.VarChar,20, IIf(t_revn Is Nothing, String.Empty,t_revn))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakERPRecD)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakERPRecD(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakERPRecDSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_rcno As String, ByVal t_revn As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakERPRecDGetByID(ByVal t_rcno As String, ByVal t_revn As String, ByVal t_srno As Int32, ByVal Filter_t_rcno As String, ByVal Filter_t_revn As String) As SIS.PAK.pakERPRecD
      Return pakERPRecDGetByID(t_rcno, t_revn, t_srno)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function pakERPRecDInsert(ByVal Record As SIS.PAK.pakERPRecD) As SIS.PAK.pakERPRecD
      Dim _Rec As SIS.PAK.pakERPRecD = SIS.PAK.pakERPRecD.pakERPRecDGetNewRecord()
      With _Rec
        .t_rcno = Record.t_rcno
        .t_revn = Record.t_revn
        .t_srno = Record.t_srno
        .t_docn = Record.t_docn
        .t_revi = Record.t_revi
        .t_dsca = Record.t_dsca
        .t_idoc = Record.t_idoc
        .t_irev = Record.t_irev
        .t_date = Record.t_date
        .t_remk = Record.t_remk
        .t_proc = Record.t_proc
        .t_Refcntd = Record.t_Refcntd
        .t_Refcntu = Record.t_Refcntu
      End With
      Return SIS.PAK.pakERPRecD.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PAK.pakERPRecD) As SIS.PAK.pakERPRecD
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakERPRecDInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rcno", SqlDbType.VarChar, 10, Record.t_rcno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_revn", SqlDbType.VarChar, 21, Record.t_revn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_srno", SqlDbType.Int, 11, Record.t_srno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_docn", SqlDbType.VarChar, 33, Record.t_docn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_revi", SqlDbType.VarChar, 21, Record.t_revi)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_dsca", SqlDbType.VarChar, 101, Record.t_dsca)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_idoc", SqlDbType.VarChar, 33, Record.t_idoc)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_irev", SqlDbType.VarChar, 21, Record.t_irev)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_date", SqlDbType.DateTime, 21, Record.t_date)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_remk", SqlDbType.VarChar, 101, Record.t_remk)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_proc", SqlDbType.Int, 11, Record.t_proc)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntd", SqlDbType.Int, 11, Record.t_Refcntd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntu", SqlDbType.Int, 11, Record.t_Refcntu)
          Cmd.Parameters.Add("@Return_t_rcno", SqlDbType.VarChar, 10)
          Cmd.Parameters("@Return_t_rcno").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_t_revn", SqlDbType.VarChar, 21)
          Cmd.Parameters("@Return_t_revn").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_t_srno", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_t_srno").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.t_rcno = Cmd.Parameters("@Return_t_rcno").Value
          Record.t_revn = Cmd.Parameters("@Return_t_revn").Value
          Record.t_srno = Cmd.Parameters("@Return_t_srno").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakERPRecDUpdate(ByVal Record As SIS.PAK.pakERPRecD) As SIS.PAK.pakERPRecD
      Dim _Rec As SIS.PAK.pakERPRecD = SIS.PAK.pakERPRecD.pakERPRecDGetByID(Record.t_rcno, Record.t_revn, Record.t_srno)
      With _Rec
        .t_docn = Record.t_docn
        .t_revi = Record.t_revi
        .t_dsca = Record.t_dsca
        .t_idoc = Record.t_idoc
        .t_irev = Record.t_irev
        .t_date = Record.t_date
        .t_remk = Record.t_remk
        .t_proc = Record.t_proc
        .t_Refcntd = Record.t_Refcntd
        .t_Refcntu = Record.t_Refcntu
      End With
      Return SIS.PAK.pakERPRecD.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PAK.pakERPRecD) As SIS.PAK.pakERPRecD
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakERPRecDUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_rcno",SqlDbType.VarChar,10, Record.t_rcno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_revn",SqlDbType.VarChar,21, Record.t_revn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_srno",SqlDbType.Int,11, Record.t_srno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_rcno",SqlDbType.VarChar,10, Record.t_rcno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_revn",SqlDbType.VarChar,21, Record.t_revn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_srno",SqlDbType.Int,11, Record.t_srno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_docn",SqlDbType.VarChar,33, Record.t_docn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_revi",SqlDbType.VarChar,21, Record.t_revi)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_dsca",SqlDbType.VarChar,101, Record.t_dsca)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_idoc",SqlDbType.VarChar,33, Record.t_idoc)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_irev",SqlDbType.VarChar,21, Record.t_irev)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_date",SqlDbType.DateTime,21, Record.t_date)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_remk",SqlDbType.VarChar,101, Record.t_remk)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_proc",SqlDbType.Int,11, Record.t_proc)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntd",SqlDbType.Int,11, Record.t_Refcntd)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_Refcntu",SqlDbType.Int,11, Record.t_Refcntu)
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
    Public Shared Function pakERPRecDDelete(ByVal Record As SIS.PAK.pakERPRecD) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakERPRecDDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_rcno",SqlDbType.VarChar,Record.t_rcno.ToString.Length, Record.t_rcno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_revn",SqlDbType.VarChar,Record.t_revn.ToString.Length, Record.t_revn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_t_srno",SqlDbType.Int,Record.t_srno.ToString.Length, Record.t_srno)
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
