Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.SPMT
  <DataObject()> _
  Partial Public Class spmtHSNSACCodes
    Private Shared _RecordCount As Integer
    Private _BillType As Int32 = 0
    Private _HSNSACCode As String = ""
    Private _Description As String = ""
    Private _TaxRate As String = "0.00"
    Private _SPMT_BillTypes1_Description As String = ""
    Private _FK_SPMT_HSNSACCodes_BillType As SIS.SPMT.spmtBillTypes = Nothing
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
    Public Property BillType() As Int32
      Get
        Return _BillType
      End Get
      Set(ByVal value As Int32)
        _BillType = value
      End Set
    End Property
    Public Property HSNSACCode() As String
      Get
        Return _HSNSACCode
      End Get
      Set(ByVal value As String)
        _HSNSACCode = value
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
    Public Property TaxRate() As String
      Get
        Return _TaxRate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TaxRate = "0.00"
         Else
           _TaxRate = value
         End If
      End Set
    End Property
    Public Property SPMT_BillTypes1_Description() As String
      Get
        Return _SPMT_BillTypes1_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SPMT_BillTypes1_Description = ""
         Else
           _SPMT_BillTypes1_Description = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _HSNSACCode.ToString.PadRight(20, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _BillType & "|" & _HSNSACCode
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
    Public Class PKspmtHSNSACCodes
      Private _BillType As Int32 = 0
      Private _HSNSACCode As String = ""
      Public Property BillType() As Int32
        Get
          Return _BillType
        End Get
        Set(ByVal value As Int32)
          _BillType = value
        End Set
      End Property
      Public Property HSNSACCode() As String
        Get
          Return _HSNSACCode
        End Get
        Set(ByVal value As String)
          _HSNSACCode = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_SPMT_HSNSACCodes_BillType() As SIS.SPMT.spmtBillTypes
      Get
        If _FK_SPMT_HSNSACCodes_BillType Is Nothing Then
          _FK_SPMT_HSNSACCodes_BillType = SIS.SPMT.spmtBillTypes.spmtBillTypesGetByID(_BillType)
        End If
        Return _FK_SPMT_HSNSACCodes_BillType
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function spmtHSNSACCodesSelectList(ByVal OrderBy As String) As List(Of SIS.SPMT.spmtHSNSACCodes)
      Dim Results As List(Of SIS.SPMT.spmtHSNSACCodes) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spspmtHSNSACCodesSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.SPMT.spmtHSNSACCodes)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.SPMT.spmtHSNSACCodes(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function spmtHSNSACCodesGetNewRecord() As SIS.SPMT.spmtHSNSACCodes
      Return New SIS.SPMT.spmtHSNSACCodes()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function spmtHSNSACCodesGetByID(ByVal BillType As Int32, ByVal HSNSACCode As String) As SIS.SPMT.spmtHSNSACCodes
      Dim Results As SIS.SPMT.spmtHSNSACCodes = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spspmtHSNSACCodesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillType",SqlDbType.Int,BillType.ToString.Length, BillType)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HSNSACCode",SqlDbType.NVarChar,HSNSACCode.ToString.Length, HSNSACCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.SPMT.spmtHSNSACCodes(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByBillType(ByVal BillType As Int32, ByVal OrderBy as String) As List(Of SIS.SPMT.spmtHSNSACCodes)
      Dim Results As List(Of SIS.SPMT.spmtHSNSACCodes) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spspmtHSNSACCodesSelectByBillType"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillType",SqlDbType.Int,BillType.ToString.Length, BillType)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.SPMT.spmtHSNSACCodes)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.SPMT.spmtHSNSACCodes(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function spmtHSNSACCodesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal BillType As Int32) As List(Of SIS.SPMT.spmtHSNSACCodes)
      Dim Results As List(Of SIS.SPMT.spmtHSNSACCodes) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spspmtHSNSACCodesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spspmtHSNSACCodesSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BillType",SqlDbType.Int,10, IIf(BillType = Nothing, 0,BillType))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.SPMT.spmtHSNSACCodes)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.SPMT.spmtHSNSACCodes(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function spmtHSNSACCodesSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal BillType As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function spmtHSNSACCodesGetByID(ByVal BillType As Int32, ByVal HSNSACCode As String, ByVal Filter_BillType As Int32) As SIS.SPMT.spmtHSNSACCodes
      Return spmtHSNSACCodesGetByID(BillType, HSNSACCode)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function spmtHSNSACCodesInsert(ByVal Record As SIS.SPMT.spmtHSNSACCodes) As SIS.SPMT.spmtHSNSACCodes
      Dim _Rec As SIS.SPMT.spmtHSNSACCodes = SIS.SPMT.spmtHSNSACCodes.spmtHSNSACCodesGetNewRecord()
      With _Rec
        .BillType = Record.BillType
        .HSNSACCode = Record.HSNSACCode
        .Description = Record.Description
        .TaxRate = Record.TaxRate
      End With
      Return SIS.SPMT.spmtHSNSACCodes.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.SPMT.spmtHSNSACCodes) As SIS.SPMT.spmtHSNSACCodes
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spspmtHSNSACCodesInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillType",SqlDbType.Int,11, Record.BillType)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HSNSACCode",SqlDbType.NVarChar,21, Record.HSNSACCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,501, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TaxRate",SqlDbType.Decimal,25, Iif(Record.TaxRate= "" ,Convert.DBNull, Record.TaxRate))
          Cmd.Parameters.Add("@Return_BillType", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_BillType").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_HSNSACCode", SqlDbType.NVarChar, 21)
          Cmd.Parameters("@Return_HSNSACCode").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.BillType = Cmd.Parameters("@Return_BillType").Value
          Record.HSNSACCode = Cmd.Parameters("@Return_HSNSACCode").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function spmtHSNSACCodesUpdate(ByVal Record As SIS.SPMT.spmtHSNSACCodes) As SIS.SPMT.spmtHSNSACCodes
      Dim _Rec As SIS.SPMT.spmtHSNSACCodes = SIS.SPMT.spmtHSNSACCodes.spmtHSNSACCodesGetByID(Record.BillType, Record.HSNSACCode)
      With _Rec
        .Description = Record.Description
        .TaxRate = Record.TaxRate
      End With
      Return SIS.SPMT.spmtHSNSACCodes.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.SPMT.spmtHSNSACCodes) As SIS.SPMT.spmtHSNSACCodes
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spspmtHSNSACCodesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_BillType",SqlDbType.Int,11, Record.BillType)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_HSNSACCode",SqlDbType.NVarChar,21, Record.HSNSACCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillType",SqlDbType.Int,11, Record.BillType)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HSNSACCode",SqlDbType.NVarChar,21, Record.HSNSACCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,501, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TaxRate",SqlDbType.Decimal,25, Iif(Record.TaxRate= "" ,Convert.DBNull, Record.TaxRate))
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
    Public Shared Function spmtHSNSACCodesDelete(ByVal Record As SIS.SPMT.spmtHSNSACCodes) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spspmtHSNSACCodesDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_BillType",SqlDbType.Int,Record.BillType.ToString.Length, Record.BillType)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_HSNSACCode",SqlDbType.NVarChar,Record.HSNSACCode.ToString.Length, Record.HSNSACCode)
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
    Public Shared Function SelectspmtHSNSACCodesAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spspmtHSNSACCodesAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(20, " "),"" & "|" & ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.SPMT.spmtHSNSACCodes = New SIS.SPMT.spmtHSNSACCodes(Reader)
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
