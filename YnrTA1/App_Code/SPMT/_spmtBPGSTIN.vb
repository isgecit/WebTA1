Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.SPMT
  <DataObject()> _
  Partial Public Class spmtBPGSTIN
    Private Shared _RecordCount As Integer
    Private _BPID As String = ""
    Private _GSTIN As Int32 = 0
    Private _Description As String = ""
    Private _VR_BusinessPartner1_BPName As String = ""
    Private _FK_VR_BPGSTIN_BPID As SIS.SPMT.spmtBusinessPartner = Nothing
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
    Public Property GSTIN() As Int32
      Get
        Return _GSTIN
      End Get
      Set(ByVal value As Int32)
        _GSTIN = value
      End Set
    End Property
    Public Property Description() As String
      Get
        Return _Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Description = ""
         Else
           _Description = value
         End If
      End Set
    End Property
    Public Property VR_BusinessPartner1_BPName() As String
      Get
        Return _VR_BusinessPartner1_BPName
      End Get
      Set(ByVal value As String)
        _VR_BusinessPartner1_BPName = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _Description.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _BPID & "|" & _GSTIN
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
    Public Class PKspmtBPGSTIN
      Private _BPID As String = ""
      Private _GSTIN As Int32 = 0
      Public Property BPID() As String
        Get
          Return _BPID
        End Get
        Set(ByVal value As String)
          _BPID = value
        End Set
      End Property
      Public Property GSTIN() As Int32
        Get
          Return _GSTIN
        End Get
        Set(ByVal value As Int32)
          _GSTIN = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_VR_BPGSTIN_BPID() As SIS.SPMT.spmtBusinessPartner
      Get
        If _FK_VR_BPGSTIN_BPID Is Nothing Then
          _FK_VR_BPGSTIN_BPID = SIS.SPMT.spmtBusinessPartner.spmtBusinessPartnerGetByID(_BPID)
        End If
        Return _FK_VR_BPGSTIN_BPID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function spmtBPGSTINSelectList(ByVal OrderBy As String) As List(Of SIS.SPMT.spmtBPGSTIN)
      Dim Results As List(Of SIS.SPMT.spmtBPGSTIN) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spspmtBPGSTINSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.SPMT.spmtBPGSTIN)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.SPMT.spmtBPGSTIN(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function spmtBPGSTINGetNewRecord() As SIS.SPMT.spmtBPGSTIN
      Return New SIS.SPMT.spmtBPGSTIN()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function spmtBPGSTINGetByID(ByVal BPID As String, ByVal GSTIN As Int32) As SIS.SPMT.spmtBPGSTIN
      Dim Results As SIS.SPMT.spmtBPGSTIN = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spspmtBPGSTINSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BPID",SqlDbType.NVarChar,BPID.ToString.Length, BPID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GSTIN",SqlDbType.Int,GSTIN.ToString.Length, GSTIN)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.SPMT.spmtBPGSTIN(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByBPID(ByVal BPID As String, ByVal OrderBy as String) As List(Of SIS.SPMT.spmtBPGSTIN)
      Dim Results As List(Of SIS.SPMT.spmtBPGSTIN) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spspmtBPGSTINSelectByBPID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BPID",SqlDbType.NVarChar,BPID.ToString.Length, BPID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.SPMT.spmtBPGSTIN)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.SPMT.spmtBPGSTIN(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function spmtBPGSTINSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal BPID As String) As List(Of SIS.SPMT.spmtBPGSTIN)
      Dim Results As List(Of SIS.SPMT.spmtBPGSTIN) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spspmtBPGSTINSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spspmtBPGSTINSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BPID",SqlDbType.NVarChar,9, IIf(BPID Is Nothing, String.Empty,BPID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.SPMT.spmtBPGSTIN)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.SPMT.spmtBPGSTIN(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function spmtBPGSTINSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal BPID As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function spmtBPGSTINGetByID(ByVal BPID As String, ByVal GSTIN As Int32, ByVal Filter_BPID As String) As SIS.SPMT.spmtBPGSTIN
      Return spmtBPGSTINGetByID(BPID, GSTIN)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function spmtBPGSTINInsert(ByVal Record As SIS.SPMT.spmtBPGSTIN) As SIS.SPMT.spmtBPGSTIN
      Dim _Rec As SIS.SPMT.spmtBPGSTIN = SIS.SPMT.spmtBPGSTIN.spmtBPGSTINGetNewRecord()
      With _Rec
        .BPID = Record.BPID
        .GSTIN = Record.GSTIN
        .Description = Record.Description
      End With
      Return SIS.SPMT.spmtBPGSTIN.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.SPMT.spmtBPGSTIN) As SIS.SPMT.spmtBPGSTIN
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spspmtBPGSTINInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BPID",SqlDbType.NVarChar,10, Record.BPID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GSTIN",SqlDbType.Int,11, Record.GSTIN)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          Cmd.Parameters.Add("@Return_BPID", SqlDbType.NVarChar, 10)
          Cmd.Parameters("@Return_BPID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_GSTIN", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_GSTIN").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.BPID = Cmd.Parameters("@Return_BPID").Value
          Record.GSTIN = Cmd.Parameters("@Return_GSTIN").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function spmtBPGSTINUpdate(ByVal Record As SIS.SPMT.spmtBPGSTIN) As SIS.SPMT.spmtBPGSTIN
      Dim _Rec As SIS.SPMT.spmtBPGSTIN = SIS.SPMT.spmtBPGSTIN.spmtBPGSTINGetByID(Record.BPID, Record.GSTIN)
      With _Rec
        .Description = Record.Description
      End With
      Return SIS.SPMT.spmtBPGSTIN.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.SPMT.spmtBPGSTIN) As SIS.SPMT.spmtBPGSTIN
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spspmtBPGSTINUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_BPID",SqlDbType.NVarChar,10, Record.BPID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_GSTIN",SqlDbType.Int,11, Record.GSTIN)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BPID",SqlDbType.NVarChar,10, Record.BPID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GSTIN",SqlDbType.Int,11, Record.GSTIN)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
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
    Public Shared Function spmtBPGSTINDelete(ByVal Record As SIS.SPMT.spmtBPGSTIN) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spspmtBPGSTINDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_BPID",SqlDbType.NVarChar,Record.BPID.ToString.Length, Record.BPID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_GSTIN",SqlDbType.Int,Record.GSTIN.ToString.Length, Record.GSTIN)
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
    Public Shared Function SelectspmtBPGSTINAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spspmtBPGSTINAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),"" & "|" & ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.SPMT.spmtBPGSTIN = New SIS.SPMT.spmtBPGSTIN(Reader)
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
