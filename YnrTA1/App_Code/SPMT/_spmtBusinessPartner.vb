Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.SPMT
  <DataObject()> _
  Partial Public Class spmtBusinessPartner
    Private Shared _RecordCount As Integer
    Private _BPID As String = ""
    Private _BPName As String = ""
    Private _Address1Line As String = ""
    Private _Address2Line As String = ""
    Private _City As String = ""
    Private _EMailID As String = ""
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
    Public Property BPID() As String
      Get
        Return _BPID
      End Get
      Set(ByVal value As String)
        _BPID = value
      End Set
    End Property
    Public Property BPName() As String
      Get
        Return _BPName
      End Get
      Set(ByVal value As String)
        _BPName = value
      End Set
    End Property
    Public Property Address1Line() As String
      Get
        Return _Address1Line
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Address1Line = ""
         Else
           _Address1Line = value
         End If
      End Set
    End Property
    Public Property Address2Line() As String
      Get
        Return _Address2Line
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Address2Line = ""
         Else
           _Address2Line = value
         End If
      End Set
    End Property
    Public Property City() As String
      Get
        Return _City
      End Get
      Set(ByVal value As String)
        _City = value
      End Set
    End Property
    Public Property EMailID() As String
      Get
        Return _EMailID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _EMailID = ""
         Else
           _EMailID = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _BPName.ToString.PadRight(100, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _BPID
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
    Public Class PKspmtBusinessPartner
      Private _BPID As String = ""
      Public Property BPID() As String
        Get
          Return _BPID
        End Get
        Set(ByVal value As String)
          _BPID = value
        End Set
      End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function spmtBusinessPartnerSelectList(ByVal OrderBy As String) As List(Of SIS.SPMT.spmtBusinessPartner)
      Dim Results As List(Of SIS.SPMT.spmtBusinessPartner) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spspmtBusinessPartnerSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.SPMT.spmtBusinessPartner)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.SPMT.spmtBusinessPartner(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function spmtBusinessPartnerGetNewRecord() As SIS.SPMT.spmtBusinessPartner
      Return New SIS.SPMT.spmtBusinessPartner()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function spmtBusinessPartnerGetByID(ByVal BPID As String) As SIS.SPMT.spmtBusinessPartner
      Dim Results As SIS.SPMT.spmtBusinessPartner = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spspmtBusinessPartnerSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BPID",SqlDbType.NVarChar,BPID.ToString.Length, BPID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.SPMT.spmtBusinessPartner(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function spmtBusinessPartnerSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.SPMT.spmtBusinessPartner)
      Dim Results As List(Of SIS.SPMT.spmtBusinessPartner) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spspmtBusinessPartnerSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spspmtBusinessPartnerSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.SPMT.spmtBusinessPartner)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.SPMT.spmtBusinessPartner(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function spmtBusinessPartnerSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function spmtBusinessPartnerInsert(ByVal Record As SIS.SPMT.spmtBusinessPartner) As SIS.SPMT.spmtBusinessPartner
      Dim _Rec As SIS.SPMT.spmtBusinessPartner = SIS.SPMT.spmtBusinessPartner.spmtBusinessPartnerGetNewRecord()
      With _Rec
        .BPID = Record.BPID
        .BPName = Record.BPName
        .Address1Line = Record.Address1Line
        .Address2Line = Record.Address2Line
        .City = Record.City
        .EMailID = Record.EMailID
      End With
      Return SIS.SPMT.spmtBusinessPartner.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.SPMT.spmtBusinessPartner) As SIS.SPMT.spmtBusinessPartner
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spspmtBusinessPartnerInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BPID",SqlDbType.NVarChar,10, Record.BPID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BPName",SqlDbType.NVarChar,101, Record.BPName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Address1Line",SqlDbType.NVarChar,101, Iif(Record.Address1Line= "" ,Convert.DBNull, Record.Address1Line))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Address2Line",SqlDbType.NVarChar,101, Iif(Record.Address2Line= "" ,Convert.DBNull, Record.Address2Line))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@City",SqlDbType.NVarChar,51, Record.City)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EMailID",SqlDbType.NVarChar,201, Iif(Record.EMailID= "" ,Convert.DBNull, Record.EMailID))
          Cmd.Parameters.Add("@Return_BPID", SqlDbType.NVarChar, 10)
          Cmd.Parameters("@Return_BPID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.BPID = Cmd.Parameters("@Return_BPID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function spmtBusinessPartnerUpdate(ByVal Record As SIS.SPMT.spmtBusinessPartner) As SIS.SPMT.spmtBusinessPartner
      Dim _Rec As SIS.SPMT.spmtBusinessPartner = SIS.SPMT.spmtBusinessPartner.spmtBusinessPartnerGetByID(Record.BPID)
      With _Rec
        .BPName = Record.BPName
        .Address1Line = Record.Address1Line
        .Address2Line = Record.Address2Line
        .City = Record.City
        .EMailID = Record.EMailID
      End With
      Return SIS.SPMT.spmtBusinessPartner.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.SPMT.spmtBusinessPartner) As SIS.SPMT.spmtBusinessPartner
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spspmtBusinessPartnerUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_BPID",SqlDbType.NVarChar,10, Record.BPID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BPID",SqlDbType.NVarChar,10, Record.BPID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BPName",SqlDbType.NVarChar,101, Record.BPName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Address1Line",SqlDbType.NVarChar,101, Iif(Record.Address1Line= "" ,Convert.DBNull, Record.Address1Line))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Address2Line",SqlDbType.NVarChar,101, Iif(Record.Address2Line= "" ,Convert.DBNull, Record.Address2Line))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@City",SqlDbType.NVarChar,51, Record.City)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EMailID",SqlDbType.NVarChar,201, Iif(Record.EMailID= "" ,Convert.DBNull, Record.EMailID))
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
    Public Shared Function spmtBusinessPartnerDelete(ByVal Record As SIS.SPMT.spmtBusinessPartner) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spspmtBusinessPartnerDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_BPID",SqlDbType.NVarChar,Record.BPID.ToString.Length, Record.BPID)
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
'    Autocomplete Method
    Public Shared Function SelectspmtBusinessPartnerAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spspmtBusinessPartnerAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(100, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.SPMT.spmtBusinessPartner = New SIS.SPMT.spmtBusinessPartner(Reader)
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
