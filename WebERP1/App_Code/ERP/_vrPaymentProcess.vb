Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  <DataObject()> _
  Partial Public Class vrPaymentProcess
    Private Shared _RecordCount As Integer
    Private _SerialNo As Int32 = 0
    Private _PTRNo As String = ""
    Private _PTRDate As String = ""
    Private _PTRAmount As Decimal = 0
    Private _PaymentReference As String = ""
    Private _ChequeNo As String = ""
    Private _ChequeDate As String = ""
    Private _ChequeAmount As Decimal = 0
    Private _PaymentDescription As String = ""
    Private _ProcessedBy As String = ""
    Private _ProcessedOn As String = ""
    Private _Freezed As Boolean = False
    Private _IRNo As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _FK_VR_PaymentProcess_ProcessedBy As SIS.QCM.qcmUsers = Nothing
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
    Public Property SerialNo() As Int32
      Get
        Return _SerialNo
      End Get
      Set(ByVal value As Int32)
        _SerialNo = value
      End Set
    End Property
    Public Property PTRNo() As String
      Get
        Return _PTRNo
      End Get
      Set(ByVal value As String)
        _PTRNo = value
      End Set
    End Property
    Public Property PTRDate() As String
      Get
        If Not _PTRDate = String.Empty Then
          Return Convert.ToDateTime(_PTRDate).ToString("dd/MM/yyyy")
        End If
        Return _PTRDate
      End Get
      Set(ByVal value As String)
			   _PTRDate = value
      End Set
    End Property
    Public Property PTRAmount() As Decimal
      Get
        Return _PTRAmount
      End Get
      Set(ByVal value As Decimal)
        _PTRAmount = value
      End Set
    End Property
    Public Property PaymentReference() As String
      Get
        Return _PaymentReference
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _PaymentReference = ""
				 Else
					 _PaymentReference = value
			   End If
      End Set
    End Property
    Public Property ChequeNo() As String
      Get
        Return _ChequeNo
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ChequeNo = ""
				 Else
					 _ChequeNo = value
			   End If
      End Set
    End Property
    Public Property ChequeDate() As String
      Get
        If Not _ChequeDate = String.Empty Then
          Return Convert.ToDateTime(_ChequeDate).ToString("dd/MM/yyyy")
        End If
        Return _ChequeDate
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ChequeDate = ""
				 Else
					 _ChequeDate = value
			   End If
      End Set
    End Property
    Public Property ChequeAmount() As Decimal
      Get
        Return _ChequeAmount
      End Get
      Set(ByVal value As Decimal)
        _ChequeAmount = value
      End Set
    End Property
    Public Property PaymentDescription() As String
      Get
        Return _PaymentDescription
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _PaymentDescription = ""
				 Else
					 _PaymentDescription = value
			   End If
      End Set
    End Property
    Public Property ProcessedBy() As String
      Get
        Return _ProcessedBy
      End Get
      Set(ByVal value As String)
        _ProcessedBy = value
      End Set
    End Property
    Public Property ProcessedOn() As String
      Get
        If Not _ProcessedOn = String.Empty Then
          Return Convert.ToDateTime(_ProcessedOn).ToString("dd/MM/yyyy")
        End If
        Return _ProcessedOn
      End Get
      Set(ByVal value As String)
			   _ProcessedOn = value
      End Set
    End Property
    Public Property Freezed() As Boolean
      Get
        Return _Freezed
      End Get
      Set(ByVal value As Boolean)
        _Freezed = value
      End Set
    End Property
    Public Property IRNo() As String
      Get
        Return _IRNo
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _IRNo = ""
				 Else
					 _IRNo = value
			   End If
      End Set
    End Property
    Public Property aspnet_Users1_UserFullName() As String
      Get
        Return _aspnet_Users1_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users1_UserFullName = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _PaymentDescription.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _SerialNo
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
    Public Class PKvrPaymentProcess
			Private _SerialNo As Int32 = 0
			Public Property SerialNo() As Int32
				Get
					Return _SerialNo
				End Get
				Set(ByVal value As Int32)
					_SerialNo = value
				End Set
			End Property
    End Class
    Public ReadOnly Property FK_VR_PaymentProcess_ProcessedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_VR_PaymentProcess_ProcessedBy Is Nothing Then
          _FK_VR_PaymentProcess_ProcessedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_ProcessedBy)
        End If
        Return _FK_VR_PaymentProcess_ProcessedBy
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrPaymentProcessSelectList(ByVal OrderBy As String) As List(Of SIS.VR.vrPaymentProcess)
      Dim Results As List(Of SIS.VR.vrPaymentProcess) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrPaymentProcessSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrPaymentProcess)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrPaymentProcess(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrPaymentProcessGetNewRecord() As SIS.VR.vrPaymentProcess
      Return New SIS.VR.vrPaymentProcess()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrPaymentProcessGetByID(ByVal SerialNo As Int32) As SIS.VR.vrPaymentProcess
      Dim Results As SIS.VR.vrPaymentProcess = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrPaymentProcessSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.VR.vrPaymentProcess(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrPaymentProcessSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProcessedBy As String) As List(Of SIS.VR.vrPaymentProcess)
      Dim Results As List(Of SIS.VR.vrPaymentProcess) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spvrPaymentProcessSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spvrPaymentProcessSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProcessedBy",SqlDbType.NVarChar,8, IIf(ProcessedBy Is Nothing, String.Empty,ProcessedBy))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrPaymentProcess)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrPaymentProcess(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function vrPaymentProcessSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProcessedBy As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrPaymentProcessGetByID(ByVal SerialNo As Int32, ByVal Filter_ProcessedBy As String) As SIS.VR.vrPaymentProcess
      Return vrPaymentProcessGetByID(SerialNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function vrPaymentProcessInsert(ByVal Record As SIS.VR.vrPaymentProcess) As SIS.VR.vrPaymentProcess
      Dim _Rec As SIS.VR.vrPaymentProcess = SIS.VR.vrPaymentProcess.vrPaymentProcessGetNewRecord()
      With _Rec
        .PTRNo = Record.PTRNo
        .PTRDate = Record.PTRDate
        .PTRAmount = Record.PTRAmount
        .PaymentReference = Record.PaymentReference
        .ChequeNo = Record.ChequeNo
        .ChequeDate = Record.ChequeDate
        .ChequeAmount = Record.ChequeAmount
        .PaymentDescription = Record.PaymentDescription
        .ProcessedBy = Record.ProcessedBy
        .ProcessedOn = Record.ProcessedOn
        .Freezed = Record.Freezed
        .IRNo = Record.IRNo
      End With
      Return SIS.VR.vrPaymentProcess.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.VR.vrPaymentProcess) As SIS.VR.vrPaymentProcess
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrPaymentProcessInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PTRNo",SqlDbType.NVarChar,11, Record.PTRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PTRDate",SqlDbType.DateTime,21, Record.PTRDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PTRAmount",SqlDbType.Decimal,21, Record.PTRAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PaymentReference",SqlDbType.NVarChar,51, Iif(Record.PaymentReference= "" ,Convert.DBNull, Record.PaymentReference))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ChequeNo",SqlDbType.NVarChar,11, Iif(Record.ChequeNo= "" ,Convert.DBNull, Record.ChequeNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ChequeDate",SqlDbType.DateTime,21, Iif(Record.ChequeDate= "" ,Convert.DBNull, Record.ChequeDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ChequeAmount",SqlDbType.Decimal,21, Record.ChequeAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PaymentDescription",SqlDbType.NVarChar,51, Iif(Record.PaymentDescription= "" ,Convert.DBNull, Record.PaymentDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProcessedBy",SqlDbType.NVarChar,9, Record.ProcessedBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProcessedOn",SqlDbType.DateTime,21, Record.ProcessedOn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Freezed",SqlDbType.Bit,3, Record.Freezed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRNo",SqlDbType.Int,11, Iif(Record.IRNo= "" ,Convert.DBNull, Record.IRNo))
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function vrPaymentProcessUpdate(ByVal Record As SIS.VR.vrPaymentProcess) As SIS.VR.vrPaymentProcess
      Dim _Rec As SIS.VR.vrPaymentProcess = SIS.VR.vrPaymentProcess.vrPaymentProcessGetByID(Record.SerialNo)
      With _Rec
        .PTRNo = Record.PTRNo
        .PTRDate = Record.PTRDate
        .PTRAmount = Record.PTRAmount
        .PaymentReference = Record.PaymentReference
        .ChequeNo = Record.ChequeNo
        .ChequeDate = Record.ChequeDate
        .ChequeAmount = Record.ChequeAmount
        .PaymentDescription = Record.PaymentDescription
        .ProcessedBy = Record.ProcessedBy
        .ProcessedOn = Record.ProcessedOn
        .Freezed = Record.Freezed
        .IRNo = Record.IRNo
      End With
      Return SIS.VR.vrPaymentProcess.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.VR.vrPaymentProcess) As SIS.VR.vrPaymentProcess
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrPaymentProcessUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PTRNo",SqlDbType.NVarChar,11, Record.PTRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PTRDate",SqlDbType.DateTime,21, Record.PTRDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PTRAmount",SqlDbType.Decimal,21, Record.PTRAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PaymentReference",SqlDbType.NVarChar,51, Iif(Record.PaymentReference= "" ,Convert.DBNull, Record.PaymentReference))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ChequeNo",SqlDbType.NVarChar,11, Iif(Record.ChequeNo= "" ,Convert.DBNull, Record.ChequeNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ChequeDate",SqlDbType.DateTime,21, Iif(Record.ChequeDate= "" ,Convert.DBNull, Record.ChequeDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ChequeAmount",SqlDbType.Decimal,21, Record.ChequeAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PaymentDescription",SqlDbType.NVarChar,51, Iif(Record.PaymentDescription= "" ,Convert.DBNull, Record.PaymentDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProcessedBy",SqlDbType.NVarChar,9, Record.ProcessedBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProcessedOn",SqlDbType.DateTime,21, Record.ProcessedOn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Freezed",SqlDbType.Bit,3, Record.Freezed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRNo",SqlDbType.Int,11, Iif(Record.IRNo= "" ,Convert.DBNull, Record.IRNo))
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
    Public Shared Function vrPaymentProcessDelete(ByVal Record As SIS.VR.vrPaymentProcess) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrPaymentProcessDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,Record.SerialNo.ToString.Length, Record.SerialNo)
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
'		Autocomplete Method
		Public Shared Function SelectvrPaymentProcessAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spvrPaymentProcessAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
					Results = New List(Of String)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Not Reader.HasRows Then
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),""))
					End If
					While (Reader.Read())
            Dim Tmp As SIS.VR.vrPaymentProcess = New SIS.VR.vrPaymentProcess(Reader)
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results.ToArray
		End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _SerialNo = Ctype(Reader("SerialNo"),Int32)
      _PTRNo = Ctype(Reader("PTRNo"),String)
      _PTRDate = Ctype(Reader("PTRDate"),DateTime)
      _PTRAmount = Ctype(Reader("PTRAmount"),Decimal)
      If Convert.IsDBNull(Reader("PaymentReference")) Then
        _PaymentReference = String.Empty
      Else
        _PaymentReference = Ctype(Reader("PaymentReference"), String)
      End If
      If Convert.IsDBNull(Reader("ChequeNo")) Then
        _ChequeNo = String.Empty
      Else
        _ChequeNo = Ctype(Reader("ChequeNo"), String)
      End If
      If Convert.IsDBNull(Reader("ChequeDate")) Then
        _ChequeDate = String.Empty
      Else
        _ChequeDate = Ctype(Reader("ChequeDate"), String)
      End If
      _ChequeAmount = Ctype(Reader("ChequeAmount"),Decimal)
      If Convert.IsDBNull(Reader("PaymentDescription")) Then
        _PaymentDescription = String.Empty
      Else
        _PaymentDescription = Ctype(Reader("PaymentDescription"), String)
      End If
      _ProcessedBy = Ctype(Reader("ProcessedBy"),String)
      _ProcessedOn = Ctype(Reader("ProcessedOn"),DateTime)
      _Freezed = Ctype(Reader("Freezed"),Boolean)
      If Convert.IsDBNull(Reader("IRNo")) Then
        _IRNo = String.Empty
      Else
        _IRNo = Ctype(Reader("IRNo"), String)
      End If
      _aspnet_Users1_UserFullName = Ctype(Reader("aspnet_Users1_UserFullName"),String)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
