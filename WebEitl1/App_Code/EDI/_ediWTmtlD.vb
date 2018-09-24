Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.EDI
  <DataObject()> _
  Partial Public Class ediWTmtlD
    Private Shared _RecordCount As Integer
    Private _t_tran As String = ""
    Private _t_docn As String = ""
    Private _t_revn As String = ""
    Private _t_remk As String = ""
    Private _t_recv As String = ""
    Private _t_pono As Int32 = 0
    Private _t_refr As String = ""
    Private _t_redt As String = ""
    Private _t_rekm As String = ""
    Private _t_issu As Int32 = 0
    Private _t_lock As Int32 = 0
    Private _t_revd As Int32 = 0
    Private _t_stid As String = ""
    Private _t_Refcntd As Int32 = 0
    Private _t_Refcntu As Int32 = 0
    Private _t_recc As Int32 = 0
    Private _tdmisg1312001_t_refr As String = ""
    Private _FK_EDI_TmtlD_t_tran As SIS.EDI.ediWTmtlH = Nothing
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
    Public Property t_tran() As String
      Get
        Return _t_tran
      End Get
      Set(ByVal value As String)
        _t_tran = value
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
    Public Property t_remk() As String
      Get
        Return _t_remk
      End Get
      Set(ByVal value As String)
        _t_remk = value
      End Set
    End Property
    Public Property t_recv() As String
      Get
        Return _t_recv
      End Get
      Set(ByVal value As String)
        _t_recv = value
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
    Public Property t_refr() As String
      Get
        Return _t_refr
      End Get
      Set(ByVal value As String)
        _t_refr = value
      End Set
    End Property
    Public Property t_redt() As String
      Get
        If Not _t_redt = String.Empty Then
          Return Convert.ToDateTime(_t_redt).ToString("dd/MM/yyyy")
        End If
        Return _t_redt
      End Get
      Set(ByVal value As String)
         _t_redt = value
      End Set
    End Property
    Public Property t_rekm() As String
      Get
        Return _t_rekm
      End Get
      Set(ByVal value As String)
        _t_rekm = value
      End Set
    End Property
    Public Property t_issu() As Int32
      Get
        Return _t_issu
      End Get
      Set(ByVal value As Int32)
        _t_issu = value
      End Set
    End Property
    Public Property t_lock() As Int32
      Get
        Return _t_lock
      End Get
      Set(ByVal value As Int32)
        _t_lock = value
      End Set
    End Property
    Public Property t_revd() As Int32
      Get
        Return _t_revd
      End Get
      Set(ByVal value As Int32)
        _t_revd = value
      End Set
    End Property
    Public Property t_stid() As String
      Get
        Return _t_stid
      End Get
      Set(ByVal value As String)
        _t_stid = value
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
    Public Property t_recc() As Int32
      Get
        Return _t_recc
      End Get
      Set(ByVal value As Int32)
        _t_recc = value
      End Set
    End Property
    Public Property tdmisg1312001_t_refr() As String
      Get
        Return _tdmisg1312001_t_refr
      End Get
      Set(ByVal value As String)
        _tdmisg1312001_t_refr = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _t_tran & "|" & _t_docn & "|" & _t_revn
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
    Public Class PKediWTmtlD
      Private _t_tran As String = ""
      Private _t_docn As String = ""
      Private _t_revn As String = ""
      Public Property t_tran() As String
        Get
          Return _t_tran
        End Get
        Set(ByVal value As String)
          _t_tran = value
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
    End Class
    Public ReadOnly Property FK_EDI_TmtlD_t_tran() As SIS.EDI.ediWTmtlH
      Get
        If _FK_EDI_TmtlD_t_tran Is Nothing Then
          _FK_EDI_TmtlD_t_tran = SIS.EDI.ediWTmtlH.ediWTmtlHGetByID(_t_tran)
        End If
        Return _FK_EDI_TmtlD_t_tran
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function ediWTmtlDGetNewRecord() As SIS.EDI.ediWTmtlD
      Return New SIS.EDI.ediWTmtlD()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function ediWTmtlDGetByID(ByVal t_tran As String, ByVal t_docn As String, ByVal t_revn As String) As SIS.EDI.ediWTmtlD
      Dim Results As SIS.EDI.ediWTmtlD = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spediWTmtlDSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_tran", SqlDbType.VarChar, t_tran.ToString.Length, t_tran)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_docn", SqlDbType.VarChar, t_docn.ToString.Length, t_docn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_revn", SqlDbType.VarChar, t_revn.ToString.Length, t_revn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.EDI.ediWTmtlD(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function ediWTmtlDSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_tran As String) As List(Of SIS.EDI.ediWTmtlD)
      Dim Results As List(Of SIS.EDI.ediWTmtlD) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spediWTmtlDSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spediWTmtlDSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_t_tran", SqlDbType.VarChar, 9, IIf(t_tran Is Nothing, String.Empty, t_tran))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.EDI.ediWTmtlD)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.EDI.ediWTmtlD(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function ediWTmtlDSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_tran As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function ediWTmtlDGetByID(ByVal t_tran As String, ByVal t_docn As String, ByVal t_revn As String, ByVal Filter_t_tran As String) As SIS.EDI.ediWTmtlD
      Return ediWTmtlDGetByID(t_tran, t_docn, t_revn)
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
