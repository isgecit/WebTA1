Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PSF
  <DataObject()> _
  Partial Public Class psfCreation
    Private Shared _RecordCount As Integer
    Private _SerialNo As Int32 = 0
    Private _PaymentRequestNo As String = ""
    Private _OurRefNo As String = ""
    Private _BankVoucherDate As String = ""
    Private _SupplierCode As String = ""
    Private _IRN As String = ""
    Private _InvoiceNumber As String = ""
    Private _InvoiceDate As String = ""
    Private _InvoiceAmount As Int32 = 0
    Private _TotalAmountDisbursed As Int32 = 0
    Private _InterestForDays As Int32 = 0
    Private _InterestAmount As Int32 = 0
    Private _PDNNo As String = ""
    Private _DueDate As String = ""
    Private _PaymentDateToBank As String = ""
    Private _ChequeNoPaidToBank As String = ""
    Private _AmountInWords As String = ""
    Private _TDSAmount As String = ""
    Private _ServiceTax As String = ""
    Private _HSBCToVendor As String = ""
    Private _HSBCInterestDays As String = ""
    Private _HSBCInterestAmountInStatement As String = ""
    Private _CreatedBy As String = ""
    Private _CreatedOn As String = ""
    Private _ApprovedBy As String = ""
    Private _ApprovedOn As String = ""
    Private _PSFStatus As Int32 = 0
    Private _ModifiedBy As String = ""
    Private _ModifiedOn As String = ""
    Private _HRM_Employees1_EmployeeName As String = ""
    Private _HRM_Employees2_EmployeeName As String = ""
    Private _HRM_Employees3_EmployeeName As String = ""
    Private _PSF_Status4_Description As String = ""
    Private _PSF_Supplier5_SupplierName As String = ""
    Private _FK_PSF_HSBCMain_CreatedBy As SIS.TA.taEmployees = Nothing
    Private _FK_PSF_HSBCMain_ApprovedBy As SIS.TA.taEmployees = Nothing
    Private _FK_PSF_HSBCMain_ModifiedBy As SIS.TA.taEmployees = Nothing
    Private _FK_PSF_HSBCMain_PSFStatusID As SIS.PSF.psfStatus = Nothing
    Private _FK_PSF_HSBCMain_SupplierID As SIS.PSF.psfSupplier = Nothing
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
    Public Property PaymentRequestNo() As String
      Get
        Return _PaymentRequestNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PaymentRequestNo = ""
         Else
           _PaymentRequestNo = value
         End If
      End Set
    End Property
    Public Property OurRefNo() As String
      Get
        Return _OurRefNo
      End Get
      Set(ByVal value As String)
        _OurRefNo = value
      End Set
    End Property
    Public Property BankVoucherDate() As String
      Get
        If Not _BankVoucherDate = String.Empty Then
          Return Convert.ToDateTime(_BankVoucherDate).ToString("dd/MM/yyyy")
        End If
        Return _BankVoucherDate
      End Get
      Set(ByVal value As String)
         _BankVoucherDate = value
      End Set
    End Property
    Public Property SupplierCode() As String
      Get
        Return _SupplierCode
      End Get
      Set(ByVal value As String)
        _SupplierCode = value
      End Set
    End Property
    Public Property IRN() As String
      Get
        Return _IRN
      End Get
      Set(ByVal value As String)
        _IRN = value
      End Set
    End Property
    Public Property InvoiceNumber() As String
      Get
        Return _InvoiceNumber
      End Get
      Set(ByVal value As String)
        _InvoiceNumber = value
      End Set
    End Property
    Public Property InvoiceDate() As String
      Get
        If Not _InvoiceDate = String.Empty Then
          Return Convert.ToDateTime(_InvoiceDate).ToString("dd/MM/yyyy")
        End If
        Return _InvoiceDate
      End Get
      Set(ByVal value As String)
         _InvoiceDate = value
      End Set
    End Property
    Public Property InvoiceAmount() As Int32
      Get
        Return _InvoiceAmount
      End Get
      Set(ByVal value As Int32)
        _InvoiceAmount = value
      End Set
    End Property
    Public Property TotalAmountDisbursed() As Int32
      Get
        Return _TotalAmountDisbursed
      End Get
      Set(ByVal value As Int32)
        _TotalAmountDisbursed = value
      End Set
    End Property
    Public Property InterestForDays() As Int32
      Get
        Return _InterestForDays
      End Get
      Set(ByVal value As Int32)
        _InterestForDays = value
      End Set
    End Property
    Public Property InterestAmount() As Int32
      Get
        Return _InterestAmount
      End Get
      Set(ByVal value As Int32)
        _InterestAmount = value
      End Set
    End Property
    Public Property PDNNo() As String
      Get
        Return _PDNNo
      End Get
      Set(ByVal value As String)
        _PDNNo = value
      End Set
    End Property
    Public Property DueDate() As String
      Get
        If Not _DueDate = String.Empty Then
          Return Convert.ToDateTime(_DueDate).ToString("dd/MM/yyyy")
        End If
        Return _DueDate
      End Get
      Set(ByVal value As String)
         _DueDate = value
      End Set
    End Property
    Public Property PaymentDateToBank() As String
      Get
        If Not _PaymentDateToBank = String.Empty Then
          Return Convert.ToDateTime(_PaymentDateToBank).ToString("dd/MM/yyyy")
        End If
        Return _PaymentDateToBank
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PaymentDateToBank = ""
         Else
           _PaymentDateToBank = value
         End If
      End Set
    End Property
    Public Property ChequeNoPaidToBank() As String
      Get
        Return _ChequeNoPaidToBank
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ChequeNoPaidToBank = ""
         Else
           _ChequeNoPaidToBank = value
         End If
      End Set
    End Property
    Public Property AmountInWords() As String
      Get
        Return _AmountInWords
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AmountInWords = ""
         Else
           _AmountInWords = value
         End If
      End Set
    End Property
    Public Property TDSAmount() As String
      Get
        Return _TDSAmount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TDSAmount = ""
         Else
           _TDSAmount = value
         End If
      End Set
    End Property
    Public Property ServiceTax() As String
      Get
        Return _ServiceTax
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ServiceTax = ""
         Else
           _ServiceTax = value
         End If
      End Set
    End Property
    Public Property HSBCToVendor() As String
      Get
        If Not _HSBCToVendor = String.Empty Then
          Return Convert.ToDateTime(_HSBCToVendor).ToString("dd/MM/yyyy")
        End If
        Return _HSBCToVendor
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _HSBCToVendor = ""
         Else
           _HSBCToVendor = value
         End If
      End Set
    End Property
    Public Property HSBCInterestDays() As String
      Get
        Return _HSBCInterestDays
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _HSBCInterestDays = ""
         Else
           _HSBCInterestDays = value
         End If
      End Set
    End Property
    Public Property HSBCInterestAmountInStatement() As String
      Get
        Return _HSBCInterestAmountInStatement
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _HSBCInterestAmountInStatement = ""
         Else
           _HSBCInterestAmountInStatement = value
         End If
      End Set
    End Property
    Public Property CreatedBy() As String
      Get
        Return _CreatedBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CreatedBy = ""
         Else
           _CreatedBy = value
         End If
      End Set
    End Property
    Public Property CreatedOn() As String
      Get
        If Not _CreatedOn = String.Empty Then
          Return Convert.ToDateTime(_CreatedOn).ToString("dd/MM/yyyy")
        End If
        Return _CreatedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CreatedOn = ""
         Else
           _CreatedOn = value
         End If
      End Set
    End Property
    Public Property ApprovedBy() As String
      Get
        Return _ApprovedBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ApprovedBy = ""
         Else
           _ApprovedBy = value
         End If
      End Set
    End Property
    Public Property ApprovedOn() As String
      Get
        If Not _ApprovedOn = String.Empty Then
          Return Convert.ToDateTime(_ApprovedOn).ToString("dd/MM/yyyy")
        End If
        Return _ApprovedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ApprovedOn = ""
         Else
           _ApprovedOn = value
         End If
      End Set
    End Property
    Public Property PSFStatus() As Int32
      Get
        Return _PSFStatus
      End Get
      Set(ByVal value As Int32)
        _PSFStatus = value
      End Set
    End Property
    Public Property ModifiedBy() As String
      Get
        Return _ModifiedBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ModifiedBy = ""
         Else
           _ModifiedBy = value
         End If
      End Set
    End Property
    Public Property ModifiedOn() As String
      Get
        If Not _ModifiedOn = String.Empty Then
          Return Convert.ToDateTime(_ModifiedOn).ToString("dd/MM/yyyy")
        End If
        Return _ModifiedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ModifiedOn = ""
         Else
           _ModifiedOn = value
         End If
      End Set
    End Property
    Public Property HRM_Employees1_EmployeeName() As String
      Get
        Return _HRM_Employees1_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees1_EmployeeName = value
      End Set
    End Property
    Public Property HRM_Employees2_EmployeeName() As String
      Get
        Return _HRM_Employees2_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees2_EmployeeName = value
      End Set
    End Property
    Public Property HRM_Employees3_EmployeeName() As String
      Get
        Return _HRM_Employees3_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees3_EmployeeName = value
      End Set
    End Property
    Public Property PSF_Status4_Description() As String
      Get
        Return _PSF_Status4_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PSF_Status4_Description = ""
         Else
           _PSF_Status4_Description = value
         End If
      End Set
    End Property
    Public Property PSF_Supplier5_SupplierName() As String
      Get
        Return _PSF_Supplier5_SupplierName
      End Get
      Set(ByVal value As String)
        _PSF_Supplier5_SupplierName = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
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
    Public Class PKpsfCreation
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
    Public ReadOnly Property FK_PSF_HSBCMain_CreatedBy() As SIS.TA.taEmployees
      Get
        If _FK_PSF_HSBCMain_CreatedBy Is Nothing Then
          _FK_PSF_HSBCMain_CreatedBy = SIS.TA.taEmployees.taEmployeesGetByID(_CreatedBy)
        End If
        Return _FK_PSF_HSBCMain_CreatedBy
      End Get
    End Property
    Public ReadOnly Property FK_PSF_HSBCMain_ApprovedBy() As SIS.TA.taEmployees
      Get
        If _FK_PSF_HSBCMain_ApprovedBy Is Nothing Then
          _FK_PSF_HSBCMain_ApprovedBy = SIS.TA.taEmployees.taEmployeesGetByID(_ApprovedBy)
        End If
        Return _FK_PSF_HSBCMain_ApprovedBy
      End Get
    End Property
    Public ReadOnly Property FK_PSF_HSBCMain_ModifiedBy() As SIS.TA.taEmployees
      Get
        If _FK_PSF_HSBCMain_ModifiedBy Is Nothing Then
          _FK_PSF_HSBCMain_ModifiedBy = SIS.TA.taEmployees.taEmployeesGetByID(_ModifiedBy)
        End If
        Return _FK_PSF_HSBCMain_ModifiedBy
      End Get
    End Property
    Public ReadOnly Property FK_PSF_HSBCMain_PSFStatusID() As SIS.PSF.psfStatus
      Get
        If _FK_PSF_HSBCMain_PSFStatusID Is Nothing Then
          _FK_PSF_HSBCMain_PSFStatusID = SIS.PSF.psfStatus.psfStatusGetByID(_PSFStatus)
        End If
        Return _FK_PSF_HSBCMain_PSFStatusID
      End Get
    End Property
    Public ReadOnly Property FK_PSF_HSBCMain_SupplierID() As SIS.PSF.psfSupplier
      Get
        If _FK_PSF_HSBCMain_SupplierID Is Nothing Then
          _FK_PSF_HSBCMain_SupplierID = SIS.PSF.psfSupplier.psfSupplierGetByID(_SupplierCode)
        End If
        Return _FK_PSF_HSBCMain_SupplierID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function psfCreationGetNewRecord() As SIS.PSF.psfCreation
      Return New SIS.PSF.psfCreation()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function psfCreationGetByID(ByVal SerialNo As Int32) As SIS.PSF.psfCreation
      Dim Results As SIS.PSF.psfCreation = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppsfCreationSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PSF.psfCreation(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function psfCreationSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal SupplierCode As String, ByVal PSFStatus As Int32) As List(Of SIS.PSF.psfCreation)
      Dim Results As List(Of SIS.PSF.psfCreation) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppsfCreationSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppsfCreationSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SupplierCode",SqlDbType.NVarChar,9, IIf(SupplierCode Is Nothing, String.Empty,SupplierCode))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PSFStatus",SqlDbType.Int,10, IIf(PSFStatus = Nothing, 0,PSFStatus))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PSF.psfCreation)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PSF.psfCreation(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function psfCreationSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal SupplierCode As String, ByVal PSFStatus As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function psfCreationGetByID(ByVal SerialNo As Int32, ByVal Filter_SerialNo As Int32, ByVal Filter_SupplierCode As String, ByVal Filter_PSFStatus As Int32) As SIS.PSF.psfCreation
      Return psfCreationGetByID(SerialNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function psfCreationInsert(ByVal Record As SIS.PSF.psfCreation) As SIS.PSF.psfCreation
      Dim _Rec As SIS.PSF.psfCreation = SIS.PSF.psfCreation.psfCreationGetNewRecord()
      With _Rec
        .PaymentRequestNo = Record.PaymentRequestNo
        .OurRefNo = Record.OurRefNo
        .BankVoucherDate = Record.BankVoucherDate
        .SupplierCode = Record.SupplierCode
        .IRN = Record.IRN
        .InvoiceNumber = Record.InvoiceNumber
        .InvoiceDate = Record.InvoiceDate
        .InvoiceAmount = Record.InvoiceAmount
        .TotalAmountDisbursed = Record.TotalAmountDisbursed
        .InterestForDays = Record.InterestForDays
        .InterestAmount = Record.InterestAmount
        .PDNNo = Record.PDNNo
        .DueDate = Record.DueDate
        .TDSAmount = Record.TDSAmount
        .ServiceTax = Record.ServiceTax
        .AmountInWords = Record.AmountInWords
        .CreatedBy =  Global.System.Web.HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
        .PSFStatus = "1"
      End With
      Return SIS.PSF.psfCreation.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PSF.psfCreation) As SIS.PSF.psfCreation
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppsfCreationInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PaymentRequestNo",SqlDbType.NVarChar,10, Iif(Record.PaymentRequestNo= "" ,Convert.DBNull, Record.PaymentRequestNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OurRefNo",SqlDbType.NVarChar,8, Record.OurRefNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BankVoucherDate",SqlDbType.DateTime,21, Record.BankVoucherDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierCode",SqlDbType.NVarChar,10, Record.SupplierCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRN",SqlDbType.NVarChar,11, Record.IRN)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InvoiceNumber",SqlDbType.NVarChar,31, Record.InvoiceNumber)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InvoiceDate",SqlDbType.DateTime,21, Record.InvoiceDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InvoiceAmount",SqlDbType.Int,11, Record.InvoiceAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalAmountDisbursed",SqlDbType.Int,11, Record.TotalAmountDisbursed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InterestForDays",SqlDbType.Int,11, Record.InterestForDays)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InterestAmount",SqlDbType.Int,11, Record.InterestAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PDNNo",SqlDbType.NVarChar,13, Record.PDNNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DueDate",SqlDbType.DateTime,21, Record.DueDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PaymentDateToBank",SqlDbType.DateTime,21, Iif(Record.PaymentDateToBank= "" ,Convert.DBNull, Record.PaymentDateToBank))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ChequeNoPaidToBank",SqlDbType.NVarChar,11, Iif(Record.ChequeNoPaidToBank= "" ,Convert.DBNull, Record.ChequeNoPaidToBank))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AmountInWords",SqlDbType.NVarChar,501, Iif(Record.AmountInWords= "" ,Convert.DBNull, Record.AmountInWords))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TDSAmount",SqlDbType.Int,11, Iif(Record.TDSAmount= "" ,Convert.DBNull, Record.TDSAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ServiceTax",SqlDbType.Int,11, Iif(Record.ServiceTax= "" ,Convert.DBNull, Record.ServiceTax))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HSBCToVendor",SqlDbType.DateTime,21, Iif(Record.HSBCToVendor= "" ,Convert.DBNull, Record.HSBCToVendor))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HSBCInterestDays",SqlDbType.Int,11, Iif(Record.HSBCInterestDays= "" ,Convert.DBNull, Record.HSBCInterestDays))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HSBCInterestAmountInStatement",SqlDbType.Int,11, Iif(Record.HSBCInterestAmountInStatement= "" ,Convert.DBNull, Record.HSBCInterestAmountInStatement))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy",SqlDbType.NVarChar,9, Iif(Record.ApprovedBy= "" ,Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedOn",SqlDbType.DateTime,21, Iif(Record.ApprovedOn= "" ,Convert.DBNull, Record.ApprovedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PSFStatus",SqlDbType.Int,11, Record.PSFStatus)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModifiedBy",SqlDbType.NVarChar,9, Iif(Record.ModifiedBy= "" ,Convert.DBNull, Record.ModifiedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModifiedOn",SqlDbType.DateTime,21, Iif(Record.ModifiedOn= "" ,Convert.DBNull, Record.ModifiedOn))
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
    Public Shared Function psfCreationUpdate(ByVal Record As SIS.PSF.psfCreation) As SIS.PSF.psfCreation
      Dim _Rec As SIS.PSF.psfCreation = SIS.PSF.psfCreation.psfCreationGetByID(Record.SerialNo)
      With _Rec
        .PaymentRequestNo = Record.PaymentRequestNo
        .OurRefNo = Record.OurRefNo
        .BankVoucherDate = Record.BankVoucherDate
        .SupplierCode = Record.SupplierCode
        .IRN = Record.IRN
        .InvoiceNumber = Record.InvoiceNumber
        .InvoiceDate = Record.InvoiceDate
        .InvoiceAmount = Record.InvoiceAmount
        .TotalAmountDisbursed = Record.TotalAmountDisbursed
        .InterestForDays = Record.InterestForDays
        .InterestAmount = Record.InterestAmount
        .PDNNo = Record.PDNNo
        .DueDate = Record.DueDate
        .TDSAmount = Record.TDSAmount
        .ServiceTax = Record.ServiceTax
        .AmountInWords = Record.AmountInWords
        .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
      End With
      Return SIS.PSF.psfCreation.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PSF.psfCreation) As SIS.PSF.psfCreation
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppsfCreationUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PaymentRequestNo",SqlDbType.NVarChar,10, Iif(Record.PaymentRequestNo= "" ,Convert.DBNull, Record.PaymentRequestNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OurRefNo",SqlDbType.NVarChar,8, Record.OurRefNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BankVoucherDate",SqlDbType.DateTime,21, Record.BankVoucherDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierCode",SqlDbType.NVarChar,10, Record.SupplierCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRN",SqlDbType.NVarChar,11, Record.IRN)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InvoiceNumber",SqlDbType.NVarChar,31, Record.InvoiceNumber)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InvoiceDate",SqlDbType.DateTime,21, Record.InvoiceDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InvoiceAmount",SqlDbType.Int,11, Record.InvoiceAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalAmountDisbursed",SqlDbType.Int,11, Record.TotalAmountDisbursed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InterestForDays",SqlDbType.Int,11, Record.InterestForDays)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InterestAmount",SqlDbType.Int,11, Record.InterestAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PDNNo",SqlDbType.NVarChar,13, Record.PDNNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DueDate",SqlDbType.DateTime,21, Record.DueDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PaymentDateToBank",SqlDbType.DateTime,21, Iif(Record.PaymentDateToBank= "" ,Convert.DBNull, Record.PaymentDateToBank))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ChequeNoPaidToBank",SqlDbType.NVarChar,11, Iif(Record.ChequeNoPaidToBank= "" ,Convert.DBNull, Record.ChequeNoPaidToBank))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AmountInWords",SqlDbType.NVarChar,501, Iif(Record.AmountInWords= "" ,Convert.DBNull, Record.AmountInWords))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TDSAmount",SqlDbType.Int,11, Iif(Record.TDSAmount= "" ,Convert.DBNull, Record.TDSAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ServiceTax",SqlDbType.Int,11, Iif(Record.ServiceTax= "" ,Convert.DBNull, Record.ServiceTax))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HSBCToVendor",SqlDbType.DateTime,21, Iif(Record.HSBCToVendor= "" ,Convert.DBNull, Record.HSBCToVendor))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HSBCInterestDays",SqlDbType.Int,11, Iif(Record.HSBCInterestDays= "" ,Convert.DBNull, Record.HSBCInterestDays))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HSBCInterestAmountInStatement",SqlDbType.Int,11, Iif(Record.HSBCInterestAmountInStatement= "" ,Convert.DBNull, Record.HSBCInterestAmountInStatement))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy",SqlDbType.NVarChar,9, Iif(Record.ApprovedBy= "" ,Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedOn",SqlDbType.DateTime,21, Iif(Record.ApprovedOn= "" ,Convert.DBNull, Record.ApprovedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PSFStatus",SqlDbType.Int,11, Record.PSFStatus)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModifiedBy",SqlDbType.NVarChar,9, Iif(Record.ModifiedBy= "" ,Convert.DBNull, Record.ModifiedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModifiedOn",SqlDbType.DateTime,21, Iif(Record.ModifiedOn= "" ,Convert.DBNull, Record.ModifiedOn))
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
    Public Shared Function psfCreationDelete(ByVal Record As SIS.PSF.psfCreation) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppsfCreationDelete"
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
