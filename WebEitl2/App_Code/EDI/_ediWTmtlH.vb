Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.EDI
  <DataObject()> _
  Partial Public Class ediWTmtlH
    Private Shared _RecordCount As Integer
    Private _t_tran As String = ""
    Private _t_type As Int32 = 0
    Private _t_bpid As String = ""
    Private _t_cadr As String = ""
    Private _t_cprj As String = ""
    Private _t_logn As String = ""
    Private _t_subj As String = ""
    Private _t_remk As String = ""
    Private _t_issu As String = ""
    Private _t_stat As Int32 = 0
    Private _t_ofbp As String = ""
    Private _t_vadr As String = ""
    Private _t_padr As String = ""
    Private _t_dprj As String = ""
    Private _t_user As String = ""
    Private _t_date As String = ""
    Private _t_subt As Int32 = 0
    Private _t_refr As String = ""
    Private _t_appr As Int32 = 0
    Private _t_rejc As Int32 = 0
    Private _t_rekm As String = ""
    Private _t_apdt As String = ""
    Private _t_apsu As String = ""
    Private _t_irmk As String = ""
    Private _t_iisu As Int32 = 0
    Private _t_retn As Int32 = 0
    Private _t_smdt As String = ""
    Private _t_isby As String = ""
    Private _t_isdt As String = ""
    Private _t_Refcntd As Int32 = 0
    Private _t_Refcntu As Int32 = 0
    Private _t_edif As Int32 = 0
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
    Public Property t_type() As Int32
      Get
        Return _t_type
      End Get
      Set(ByVal value As Int32)
        _t_type = value
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
    Public Property t_cadr() As String
      Get
        Return _t_cadr
      End Get
      Set(ByVal value As String)
        _t_cadr = value
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
    Public Property t_logn() As String
      Get
        Return _t_logn
      End Get
      Set(ByVal value As String)
        _t_logn = value
      End Set
    End Property
    Public Property t_subj() As String
      Get
        Return _t_subj
      End Get
      Set(ByVal value As String)
        _t_subj = value
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
    Public Property t_issu() As String
      Get
        Return _t_issu
      End Get
      Set(ByVal value As String)
        _t_issu = value
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
    Public Property t_ofbp() As String
      Get
        Return _t_ofbp
      End Get
      Set(ByVal value As String)
        _t_ofbp = value
      End Set
    End Property
    Public Property t_vadr() As String
      Get
        Return _t_vadr
      End Get
      Set(ByVal value As String)
        _t_vadr = value
      End Set
    End Property
    Public Property t_padr() As String
      Get
        Return _t_padr
      End Get
      Set(ByVal value As String)
        _t_padr = value
      End Set
    End Property
    Public Property t_dprj() As String
      Get
        Return _t_dprj
      End Get
      Set(ByVal value As String)
        _t_dprj = value
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
    Public Property t_subt() As Int32
      Get
        Return _t_subt
      End Get
      Set(ByVal value As Int32)
        _t_subt = value
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
    Public Property t_appr() As Int32
      Get
        Return _t_appr
      End Get
      Set(ByVal value As Int32)
        _t_appr = value
      End Set
    End Property
    Public Property t_rejc() As Int32
      Get
        Return _t_rejc
      End Get
      Set(ByVal value As Int32)
        _t_rejc = value
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
    Public Property t_apdt() As String
      Get
        If Not _t_apdt = String.Empty Then
          Return Convert.ToDateTime(_t_apdt).ToString("dd/MM/yyyy")
        End If
        Return _t_apdt
      End Get
      Set(ByVal value As String)
         _t_apdt = value
      End Set
    End Property
    Public Property t_apsu() As String
      Get
        Return _t_apsu
      End Get
      Set(ByVal value As String)
        _t_apsu = value
      End Set
    End Property
    Public Property t_irmk() As String
      Get
        Return _t_irmk
      End Get
      Set(ByVal value As String)
        _t_irmk = value
      End Set
    End Property
    Public Property t_iisu() As Int32
      Get
        Return _t_iisu
      End Get
      Set(ByVal value As Int32)
        _t_iisu = value
      End Set
    End Property
    Public Property t_retn() As Int32
      Get
        Return _t_retn
      End Get
      Set(ByVal value As Int32)
        _t_retn = value
      End Set
    End Property
    Public Property t_smdt() As String
      Get
        If Not _t_smdt = String.Empty Then
          Return Convert.ToDateTime(_t_smdt).ToString("dd/MM/yyyy")
        End If
        Return _t_smdt
      End Get
      Set(ByVal value As String)
         _t_smdt = value
      End Set
    End Property
    Public Property t_isby() As String
      Get
        Return _t_isby
      End Get
      Set(ByVal value As String)
        _t_isby = value
      End Set
    End Property
    Public Property t_isdt() As String
      Get
        If Not _t_isdt = String.Empty Then
          Return Convert.ToDateTime(_t_isdt).ToString("dd/MM/yyyy")
        End If
        Return _t_isdt
      End Get
      Set(ByVal value As String)
         _t_isdt = value
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
    Public Property t_edif() As Int32
      Get
        Return _t_edif
      End Get
      Set(ByVal value As Int32)
        _t_edif = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _t_refr.ToString.PadRight(32, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _t_tran
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
    Public Class PKediWTmtlH
      Private _t_tran As String = ""
      Public Property t_tran() As String
        Get
          Return _t_tran
        End Get
        Set(ByVal value As String)
          _t_tran = value
        End Set
      End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function ediWTmtlHSelectList(ByVal OrderBy As String) As List(Of SIS.EDI.ediWTmtlH)
      Dim Results As List(Of SIS.EDI.ediWTmtlH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spediWTmtlHSelectList"
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
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function ediWTmtlHGetNewRecord() As SIS.EDI.ediWTmtlH
      Return New SIS.EDI.ediWTmtlH()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function ediWTmtlHGetByID(ByVal t_tran As String) As SIS.EDI.ediWTmtlH
      Dim Results As SIS.EDI.ediWTmtlH = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spediWTmtlHSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_tran", SqlDbType.VarChar, t_tran.ToString.Length, t_tran)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.EDI.ediWTmtlH(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function ediWTmtlHSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_tran As String) As List(Of SIS.EDI.ediWTmtlH)
      Dim Results As List(Of SIS.EDI.ediWTmtlH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spediWTmtlHSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
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
    Public Shared Function ediWTmtlHSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_tran As String) As Integer
      Return _RecordCount
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function ediWTmtlHGetByID(ByVal t_tran As String, ByVal Filter_t_tran As String) As SIS.EDI.ediWTmtlH
      Return ediWTmtlHGetByID(t_tran)
    End Function
    '    Autocomplete Method
    Public Shared Function SelectediWTmtlHAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spediWTmtlHAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, IIf(Prefix.ToLower = Prefix, 0, 1)))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(32, " "), ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.EDI.ediWTmtlH = New SIS.EDI.ediWTmtlH(Reader)
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results.ToArray
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
