Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()>
  Partial Public Class taBillDetails
    Private Shared _RecordCount As Integer
    Private _TABillNo As Int32 = 0
    Private _SerialNo As Int32 = 0
    Private _ComponentID As Int32 = 0
    Private _AutoCalculated As Boolean = False
    Private _TourExtended As Boolean = False
    Private _ProjectID As String = ""
    Private _CostCenterID As String = ""
    Private _CurrencyID As String = ""
    Private _CurrencyMain As String = ""
    Private _ConversionFactorINR As Decimal = 0.000000
    Private _ConversionFactorOU As Decimal = 0.000000
    Private _City1ID As String = ""
    Private _City1Text As String = ""
    Private _City2ID As String = ""
    Private _City2Text As String = ""
    Private _Country1ID As String = ""
    Private _Date1Time As String = ""
    Private _Country2ID As String = ""
    Private _Date2Time As String = ""
    Private _ModeTravelID As String = ""
    Private _ModeLCID As String = ""
    Private _ModeExpenseID As String = ""
    Private _ModeFinanceID As String = ""
    Private _CityTypeID As String = ""
    Private _ModeText As String = ""
    Private _BoardingProvided As Boolean = False
    Private _LodgingProvided As Boolean = False
    Private _StayedWithRelative As Boolean = False
    Private _StayedInGuestHouse As Boolean = False
    Private _StayedAtSite As Boolean = False
    Private _StayedInHotel As Boolean = False
    Private _NotStayedAnyWhere As Boolean = False
    Private _AirportToHotel As Boolean = False
    Private _HotelToAirport As Boolean = False
    Private _AirportToClientLocation As Boolean = False
    Private _AmountFactor As Decimal = 0.00
    Private _AmountRate As Decimal = 0.00
    Private _AmountRateOU As Decimal = 0.00
    Private _AmountBasic As Decimal = 0.00
    Private _AmountTax As Decimal = 0.00
    Private _AmountTaxOU As Decimal = 0.00
    Private _AmountTotal As Decimal = 0.00
    Private _AmountInINR As Decimal = 0.00
    Private _Remarks As String = ""
    Private _PassedAmountFactor As Decimal = 0.00
    Private _PassedAmountRate As Decimal = 0.00
    Private _PassedAmountBasic As Decimal = 0.00
    Private _PassedAmountTax As Decimal = 0.00
    Private _PassedAmountTotal As Decimal = 0.00
    Private _PassedAmountInINR As Decimal = 0.00
    Private _AccountsRemarks As String = ""
    Private _OOEBySystem As Boolean = False
    Private _OOEByAccounts As Boolean = False
    Private _OOEReasonID As String = ""
    Private _OOERemarks As String = ""
    Private _ApprovalWFTypeID As String = ""
    Private _ApprovedBy As String = ""
    Private _ApprovedOn As String = ""
    Private _ApprovalRemarks As String = ""
    Private _Setteled As Boolean = False
    Private _BillAttached As Boolean = False
    Private _BillFileName As String = ""
    Private _BillDiskFile As String = ""
    Private _SanctionAttached As Boolean = False
    Private _SanctionFileName As String = ""
    Private _SanctionDiskFile As String = ""
    Private _SystemText As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _HRM_Departments2_Description As String = ""
    Private _IDM_Projects3_Description As String = ""
    Private _TA_ApprovalWFTypes4_WFTypeDescription As String = ""
    Private _TA_Bills5_PurposeOfJourney As String = ""
    Private _TA_Cities6_CityName As String = ""
    Private _TA_Cities7_CityName As String = ""
    Private _TA_CityTypes8_CityTypeName As String = ""
    Private _TA_Components9_Description As String = ""
    Private _TA_Currencies10_CurrencyName As String = ""
    Private _TA_ExpenseHeads11_Description As String = ""
    Private _TA_FinanceHeads12_Description As String = ""
    Private _TA_LCModes13_ModeName As String = ""
    Private _TA_OOEReasons14_Description As String = ""
    Private _TA_TravelModes15_ModeName As String = ""
    Private _TA_Countries16_CountryName As String = ""
    Private _TA_Countries17_CountryName As String = ""
    Private _FK_TA_BillDetails_ApprovedBy As SIS.TA.taWebUsers = Nothing
    Private _FK_TA_BillDetails_CostCenterID As SIS.TA.taDepartments = Nothing
    Private _FK_TA_BillDetails_ProjectID As SIS.QCM.qcmProjects = Nothing
    Private _FK_TA_BillDetails_ApprovalWFTypeID As SIS.TA.taApprovalWFTypes = Nothing
    Private _FK_TA_BillDetails_TABillNo As SIS.TA.taBH = Nothing
    Private _FK_TA_BillDetails_City1ID As SIS.TA.taCities = Nothing
    Private _FK_TA_BillDetails_City2ID As SIS.TA.taCities = Nothing
    Private _FK_TA_BillDetails_CityTypeID As SIS.TA.taCityTypes = Nothing
    Private _FK_TA_BillDetails_ComponentID As SIS.TA.taComponents = Nothing
    Private _FK_TA_BillDetails_CurrencyID As SIS.TA.taCurrencies = Nothing
    Private _FK_TA_BillDetails_ModeExpenseID As SIS.TA.taExpenseHeads = Nothing
    Private _FK_TA_BillDetails_ModeFinanceID As SIS.TA.taFinanceHeads = Nothing
    Private _FK_TA_BillDetails_ModeLCID As SIS.TA.taLCModes = Nothing
    Private _FK_TA_BillDetails_OOEReasonID As SIS.TA.taOOEReasons = Nothing
    Private _FK_TA_BillDetails_ModeTravelID As SIS.TA.taTravelModes = Nothing
    Private _FK_TA_BillDetails_Country1ID As SIS.TA.taCountries = Nothing
    Private _FK_TA_BillDetails_Country2ID As SIS.TA.taCountries = Nothing
#Region "  BILL GST  "

    Private _IsgecGSTIN As String = ""
    Private _BillNumber As String = ""
    Private _BillDate As String = ""
    Private _BPID As String = ""
    Private _SupplierGSTIN As String = ""
    Private _SupplierGSTINNo As String = ""
    Private _StateID As String = ""
    Private _BillType As String = ""
    Private _HSNSACCode As String = ""
    Private _AssessableValue As String = "0.00"
    Private _IGSTRate As String = "0.00"
    Private _IGSTAmount As String = "0.00"
    Private _SGSTRate As String = "0.00"
    Private _SGSTAmount As String = "0.00"
    Private _CGSTRate As String = "0.00"
    Private _CGSTAmount As String = "0.00"
    Private _CessRate As String = "0.00"
    Private _CessAmount As String = "0.00"
    Private _TotalGST As String = "0.00"
    Private _TotalAmount As String = "0.00"
    Private _SPMT_BillTypes1_Description As String = ""
    Private _SPMT_ERPStates2_Description As String = ""
    Private _SPMT_HSNSACCodes3_HSNSACCode As String = ""
    Private _SPMT_IsgecGSTIN4_Description As String = ""
    Private _TA_Bills6_PurposeOfJourney As String = ""
    Private _VR_BPGSTIN7_Description As String = ""
    Private _VR_BusinessPartner8_BPName As String = ""
    Private _FK_TA_BillGST_BillType As SIS.SPMT.spmtBillTypes = Nothing
    Private _FK_TA_BillGST_StateID As SIS.SPMT.spmtERPStates = Nothing
    Private _FK_TA_BillGST_HSNSACCode As SIS.SPMT.spmtHSNSACCodes = Nothing
    Private _FK_TA_BillGST_IsgecGSTIN As SIS.SPMT.spmtIsgecGSTIN = Nothing
    Private _FK_TA_BillGST_SerialNo As SIS.TA.taBillDetails = Nothing
    Private _FK_TA_BillGST_TABillNo As SIS.TA.taBH = Nothing
    Private _FK_TA_BillGST_SupplierGSTIN As SIS.SPMT.spmtBPGSTIN = Nothing
    Private _FK_TA_BillGST_BPID As SIS.SPMT.spmtBusinessPartner = Nothing
    Public Property PurchaseType As String = ""
    Public Property IsgecGSTIN() As String
      Get
        Return _IsgecGSTIN
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _IsgecGSTIN = ""
        Else
          _IsgecGSTIN = value
        End If
      End Set
    End Property
    Public Property BillNumber() As String
      Get
        Return _BillNumber
      End Get
      Set(ByVal value As String)
        _BillNumber = value
      End Set
    End Property
    Public Property BillDate() As String
      Get
        If Not _BillDate = String.Empty Then
          Return Convert.ToDateTime(_BillDate).ToString("dd/MM/yyyy")
        End If
        Return _BillDate
      End Get
      Set(ByVal value As String)
        _BillDate = value
      End Set
    End Property
    Public Property BPID() As String
      Get
        Return _BPID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _BPID = ""
        Else
          _BPID = value
        End If
      End Set
    End Property
    Public Property SupplierGSTIN() As String
      Get
        Return _SupplierGSTIN
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _SupplierGSTIN = ""
        Else
          _SupplierGSTIN = value
        End If
      End Set
    End Property
    Public Property SupplierGSTINNo() As String
      Get
        Return _SupplierGSTINNo
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _SupplierGSTINNo = ""
        Else
          _SupplierGSTINNo = value
        End If
      End Set
    End Property
    Public Property StateID() As String
      Get
        Return _StateID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _StateID = ""
        Else
          _StateID = value
        End If
      End Set
    End Property
    Public Property BillType() As String
      Get
        Return _BillType
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _BillType = ""
        Else
          _BillType = value
        End If
      End Set
    End Property
    Public Property HSNSACCode() As String
      Get
        Return _HSNSACCode
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _HSNSACCode = ""
        Else
          _HSNSACCode = value
        End If
      End Set
    End Property
    Public Property AssessableValue() As String
      Get
        Return _AssessableValue
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _AssessableValue = "0.00"
        Else
          _AssessableValue = value
        End If
      End Set
    End Property
    Public Property IGSTRate() As String
      Get
        Return _IGSTRate
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _IGSTRate = "0.00"
        Else
          _IGSTRate = value
        End If
      End Set
    End Property
    Public Property IGSTAmount() As String
      Get
        Return _IGSTAmount
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _IGSTAmount = "0.00"
        Else
          _IGSTAmount = value
        End If
      End Set
    End Property
    Public Property SGSTRate() As String
      Get
        Return _SGSTRate
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _SGSTRate = "0.00"
        Else
          _SGSTRate = value
        End If
      End Set
    End Property
    Public Property SGSTAmount() As String
      Get
        Return _SGSTAmount
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _SGSTAmount = "0.00"
        Else
          _SGSTAmount = value
        End If
      End Set
    End Property
    Public Property CGSTRate() As String
      Get
        Return _CGSTRate
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _CGSTRate = "0.00"
        Else
          _CGSTRate = value
        End If
      End Set
    End Property
    Public Property CGSTAmount() As String
      Get
        Return _CGSTAmount
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _CGSTAmount = "0.00"
        Else
          _CGSTAmount = value
        End If
      End Set
    End Property
    Public Property CessRate() As String
      Get
        Return _CessRate
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _CessRate = "0.00"
        Else
          _CessRate = value
        End If
      End Set
    End Property
    Public Property CessAmount() As String
      Get
        Return _CessAmount
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _CessAmount = "0.00"
        Else
          _CessAmount = value
        End If
      End Set
    End Property
    Public Property TotalGST() As String
      Get
        Return _TotalGST
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TotalGST = "0.00"
        Else
          _TotalGST = value
        End If
      End Set
    End Property
    Public Property TotalAmount() As String
      Get
        Return _TotalAmount
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TotalAmount = "0.00"
        Else
          _TotalAmount = value
        End If
      End Set
    End Property
    Public Property SPMT_BillTypes1_Description() As String
      Get
        Return _SPMT_BillTypes1_Description
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _SPMT_BillTypes1_Description = ""
        Else
          _SPMT_BillTypes1_Description = value
        End If
      End Set
    End Property
    Public Property SPMT_ERPStates2_Description() As String
      Get
        Return _SPMT_ERPStates2_Description
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _SPMT_ERPStates2_Description = ""
        Else
          _SPMT_ERPStates2_Description = value
        End If
      End Set
    End Property
    Public Property SPMT_HSNSACCodes3_HSNSACCode() As String
      Get
        Return _SPMT_HSNSACCodes3_HSNSACCode
      End Get
      Set(ByVal value As String)
        _SPMT_HSNSACCodes3_HSNSACCode = value
      End Set
    End Property
    Public Property SPMT_IsgecGSTIN4_Description() As String
      Get
        Return _SPMT_IsgecGSTIN4_Description
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _SPMT_IsgecGSTIN4_Description = ""
        Else
          _SPMT_IsgecGSTIN4_Description = value
        End If
      End Set
    End Property
    Public Property TA_Bills6_PurposeOfJourney() As String
      Get
        Return _TA_Bills6_PurposeOfJourney
      End Get
      Set(ByVal value As String)
        _TA_Bills6_PurposeOfJourney = value
      End Set
    End Property
    Public Property VR_BPGSTIN7_Description() As String
      Get
        Return _VR_BPGSTIN7_Description
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _VR_BPGSTIN7_Description = ""
        Else
          _VR_BPGSTIN7_Description = value
        End If
      End Set
    End Property
    Public Property VR_BusinessPartner8_BPName() As String
      Get
        Return _VR_BusinessPartner8_BPName
      End Get
      Set(ByVal value As String)
        _VR_BusinessPartner8_BPName = value
      End Set
    End Property
    Public ReadOnly Property FK_TA_BillGST_BillType() As SIS.SPMT.spmtBillTypes
      Get
        If _FK_TA_BillGST_BillType Is Nothing Then
          _FK_TA_BillGST_BillType = SIS.SPMT.spmtBillTypes.spmtBillTypesGetByID(_BillType)
        End If
        Return _FK_TA_BillGST_BillType
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillGST_StateID() As SIS.SPMT.spmtERPStates
      Get
        If _FK_TA_BillGST_StateID Is Nothing Then
          _FK_TA_BillGST_StateID = SIS.SPMT.spmtERPStates.spmtERPStatesGetByID(_StateID)
        End If
        Return _FK_TA_BillGST_StateID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillGST_HSNSACCode() As SIS.SPMT.spmtHSNSACCodes
      Get
        If _FK_TA_BillGST_HSNSACCode Is Nothing Then
          _FK_TA_BillGST_HSNSACCode = SIS.SPMT.spmtHSNSACCodes.spmtHSNSACCodesGetByID(_BillType, _HSNSACCode)
        End If
        Return _FK_TA_BillGST_HSNSACCode
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillGST_IsgecGSTIN() As SIS.SPMT.spmtIsgecGSTIN
      Get
        If _FK_TA_BillGST_IsgecGSTIN Is Nothing Then
          _FK_TA_BillGST_IsgecGSTIN = SIS.SPMT.spmtIsgecGSTIN.spmtIsgecGSTINGetByID(_IsgecGSTIN)
        End If
        Return _FK_TA_BillGST_IsgecGSTIN
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillGST_SerialNo() As SIS.TA.taBillDetails
      Get
        If _FK_TA_BillGST_SerialNo Is Nothing Then
          _FK_TA_BillGST_SerialNo = SIS.TA.taBillDetails.taBillDetailsGetByID(_TABillNo, _SerialNo)
        End If
        Return _FK_TA_BillGST_SerialNo
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillGST_TABillNo() As SIS.TA.taBH
      Get
        If _FK_TA_BillGST_TABillNo Is Nothing Then
          _FK_TA_BillGST_TABillNo = SIS.TA.taBH.taBHGetByID(_TABillNo)
        End If
        Return _FK_TA_BillGST_TABillNo
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillGST_SupplierGSTIN() As SIS.SPMT.spmtBPGSTIN
      Get
        If _FK_TA_BillGST_SupplierGSTIN Is Nothing Then
          _FK_TA_BillGST_SupplierGSTIN = SIS.SPMT.spmtBPGSTIN.spmtBPGSTINGetByID(_BPID, _SupplierGSTIN)
        End If
        Return _FK_TA_BillGST_SupplierGSTIN
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillGST_BPID() As SIS.SPMT.spmtBusinessPartner
      Get
        If _FK_TA_BillGST_BPID Is Nothing Then
          _FK_TA_BillGST_BPID = SIS.SPMT.spmtBusinessPartner.spmtBusinessPartnerGetByID(_BPID)
        End If
        Return _FK_TA_BillGST_BPID
      End Get
    End Property
#End Region
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
    Public Property TABillNo() As Int32
      Get
        Return _TABillNo
      End Get
      Set(ByVal value As Int32)
        _TABillNo = value
      End Set
    End Property
    Public Property SerialNo() As Int32
      Get
        Return _SerialNo
      End Get
      Set(ByVal value As Int32)
        _SerialNo = value
      End Set
    End Property
    Public Property ComponentID() As Int32
      Get
        Return _ComponentID
      End Get
      Set(ByVal value As Int32)
        _ComponentID = value
      End Set
    End Property
    Public Property AutoCalculated() As Boolean
      Get
        Return _AutoCalculated
      End Get
      Set(ByVal value As Boolean)
        _AutoCalculated = value
      End Set
    End Property
    Public Property TourExtended() As Boolean
      Get
        Return _TourExtended
      End Get
      Set(ByVal value As Boolean)
        _TourExtended = value
      End Set
    End Property
    Public Property ProjectID() As String
      Get
        Return _ProjectID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ProjectID = ""
        Else
          _ProjectID = value.ToUpper
        End If
      End Set
    End Property
    Public Property CostCenterID() As String
      Get
        Return _CostCenterID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _CostCenterID = ""
        Else
          _CostCenterID = value
        End If
      End Set
    End Property
    Public Property CurrencyID() As String
      Get
        Return _CurrencyID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _CurrencyID = ""
        Else
          _CurrencyID = value
        End If
      End Set
    End Property
    Public Property CurrencyMain() As String
      Get
        Return _CurrencyMain
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _CurrencyMain = ""
        Else
          _CurrencyMain = value
        End If
      End Set
    End Property
    Public Property ConversionFactorINR() As Decimal
      Get
        If _ConversionFactorINR > 0 Then
          Return _ConversionFactorINR
        Else
          Return "0.000000"
        End If
      End Get
      Set(ByVal value As Decimal)
        _ConversionFactorINR = value
      End Set
    End Property
    Public Property ConversionFactorOU() As Decimal
      Get
        If _ConversionFactorOU > 0 Then
          Return _ConversionFactorOU
        Else
          Return "0.000000"
        End If
      End Get
      Set(ByVal value As Decimal)
        _ConversionFactorOU = value
      End Set
    End Property
    Public Property City1ID() As String
      Get
        Return _City1ID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _City1ID = ""
        Else
          _City1ID = value
        End If
      End Set
    End Property
    Public Property City1Text() As String
      Get
        Return _City1Text
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _City1Text = ""
        Else
          _City1Text = value
        End If
      End Set
    End Property
    Public Property City2ID() As String
      Get
        Return _City2ID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _City2ID = ""
        Else
          _City2ID = value
        End If
      End Set
    End Property
    Public Property City2Text() As String
      Get
        Return _City2Text
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _City2Text = ""
        Else
          _City2Text = value
        End If
      End Set
    End Property
    Public Property Country1ID() As String
      Get
        Return _Country1ID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _Country1ID = ""
        Else
          _Country1ID = value
        End If
      End Set
    End Property
    Public Property Date1Time() As String
      Get
        If Not _Date1Time = String.Empty Then
          Return Convert.ToDateTime(_Date1Time).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _Date1Time
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _Date1Time = ""
        Else
          _Date1Time = value
        End If
      End Set
    End Property
    Public Property Country2ID() As String
      Get
        Return _Country2ID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _Country2ID = ""
        Else
          _Country2ID = value
        End If
      End Set
    End Property
    Public Property Date2Time() As String
      Get
        If Not _Date2Time = String.Empty Then
          Return Convert.ToDateTime(_Date2Time).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _Date2Time
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _Date2Time = ""
        Else
          _Date2Time = value
        End If
      End Set
    End Property
    Public Property ModeTravelID() As String
      Get
        Return _ModeTravelID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ModeTravelID = ""
        Else
          _ModeTravelID = value
        End If
      End Set
    End Property
    Public Property ModeLCID() As String
      Get
        Return _ModeLCID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ModeLCID = ""
        Else
          _ModeLCID = value
        End If
      End Set
    End Property
    Public Property ModeExpenseID() As String
      Get
        Return _ModeExpenseID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ModeExpenseID = ""
        Else
          _ModeExpenseID = value
        End If
      End Set
    End Property
    Public Property ModeFinanceID() As String
      Get
        Return _ModeFinanceID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ModeFinanceID = ""
        Else
          _ModeFinanceID = value
        End If
      End Set
    End Property
    Public Property CityTypeID() As String
      Get
        Return _CityTypeID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _CityTypeID = ""
        Else
          _CityTypeID = value
        End If
      End Set
    End Property
    Public Property ModeText() As String
      Get
        Return _ModeText
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ModeText = ""
        Else
          _ModeText = value
        End If
      End Set
    End Property
    Public Property BoardingProvided() As Boolean
      Get
        Return _BoardingProvided
      End Get
      Set(ByVal value As Boolean)
        _BoardingProvided = value
      End Set
    End Property
    Public Property LodgingProvided() As Boolean
      Get
        Return _LodgingProvided
      End Get
      Set(ByVal value As Boolean)
        _LodgingProvided = value
      End Set
    End Property
    Public Property StayedWithRelative() As Boolean
      Get
        Return _StayedWithRelative
      End Get
      Set(ByVal value As Boolean)
        _StayedWithRelative = value
      End Set
    End Property
    Public Property StayedInGuestHouse() As Boolean
      Get
        Return _StayedInGuestHouse
      End Get
      Set(ByVal value As Boolean)
        _StayedInGuestHouse = value
      End Set
    End Property
    Public Property StayedAtSite() As Boolean
      Get
        Return _StayedAtSite
      End Get
      Set(ByVal value As Boolean)
        _StayedAtSite = value
      End Set
    End Property
    Public Property StayedInHotel() As Boolean
      Get
        Return _StayedInHotel
      End Get
      Set(ByVal value As Boolean)
        _StayedInHotel = value
      End Set
    End Property
    Public Property NotStayedAnyWhere() As Boolean
      Get
        Return _NotStayedAnyWhere
      End Get
      Set(ByVal value As Boolean)
        _NotStayedAnyWhere = value
      End Set
    End Property
    Public Property AirportToHotel() As Boolean
      Get
        Return _AirportToHotel
      End Get
      Set(ByVal value As Boolean)
        _AirportToHotel = value
      End Set
    End Property
    Public Property HotelToAirport() As Boolean
      Get
        Return _HotelToAirport
      End Get
      Set(ByVal value As Boolean)
        _HotelToAirport = value
      End Set
    End Property
    Public Property AirportToClientLocation() As Boolean
      Get
        Return _AirportToClientLocation
      End Get
      Set(ByVal value As Boolean)
        _AirportToClientLocation = value
      End Set
    End Property
    Public Property AmountFactor() As Decimal
      Get
        Return _AmountFactor
      End Get
      Set(ByVal value As Decimal)
        _AmountFactor = value
      End Set
    End Property
    Public Property AmountRate() As Decimal
      Get
        Return _AmountRate
      End Get
      Set(ByVal value As Decimal)
        _AmountRate = value
      End Set
    End Property
    Public Property AmountRateOU() As Decimal
      Get
        ' If _AmountRateOU > 0 Then
        Return _AmountRateOU
        'Else
        'Return "0.00"
        'End If
      End Get
      Set(ByVal value As Decimal)
        _AmountRateOU = value
      End Set
    End Property
    Public Property AmountBasic() As Decimal
      Get
        Return _AmountBasic
      End Get
      Set(ByVal value As Decimal)
        _AmountBasic = value
      End Set
    End Property
    Public Property AmountTax() As Decimal
      Get
        Return _AmountTax
      End Get
      Set(ByVal value As Decimal)
        _AmountTax = value
      End Set
    End Property
    Public Property AmountTaxOU() As Decimal
      Get
        Return _AmountTaxOU
      End Get
      Set(ByVal value As Decimal)
        _AmountTaxOU = value
      End Set
    End Property
    Public Property AmountTotal() As Decimal
      Get
        Return _AmountTotal
      End Get
      Set(ByVal value As Decimal)
        _AmountTotal = value
      End Set
    End Property
    Public Property AmountInINR() As Decimal
      Get
        Return _AmountInINR
      End Get
      Set(ByVal value As Decimal)
        _AmountInINR = value
      End Set
    End Property
    Public Property Remarks() As String
      Get
        Return _Remarks
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _Remarks = ""
        Else
          _Remarks = value
        End If
      End Set
    End Property
    Public Property PassedAmountFactor() As Decimal
      Get
        Return _PassedAmountFactor
      End Get
      Set(ByVal value As Decimal)
        _PassedAmountFactor = value
      End Set
    End Property
    Public Property PassedAmountRate() As Decimal
      Get
        Return _PassedAmountRate
      End Get
      Set(ByVal value As Decimal)
        _PassedAmountRate = value
      End Set
    End Property
    Public Property PassedAmountBasic() As Decimal
      Get
        Return _PassedAmountBasic
      End Get
      Set(ByVal value As Decimal)
        _PassedAmountBasic = value
      End Set
    End Property
    Public Property PassedAmountTax() As Decimal
      Get
        Return _PassedAmountTax
      End Get
      Set(ByVal value As Decimal)
        _PassedAmountTax = value
      End Set
    End Property
    Public Property PassedAmountTotal() As Decimal
      Get
        Return _PassedAmountTotal
      End Get
      Set(ByVal value As Decimal)
        _PassedAmountTotal = value
      End Set
    End Property
    Public Property PassedAmountInINR() As Decimal
      Get
        Return _PassedAmountInINR
      End Get
      Set(ByVal value As Decimal)
        _PassedAmountInINR = value
      End Set
    End Property
    Public Property AccountsRemarks() As String
      Get
        Return _AccountsRemarks
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _AccountsRemarks = ""
        Else
          _AccountsRemarks = value
        End If
      End Set
    End Property
    Public Property OOEBySystem() As Boolean
      Get
        Return _OOEBySystem
      End Get
      Set(ByVal value As Boolean)
        _OOEBySystem = value
      End Set
    End Property
    Public Property OOEByAccounts() As Boolean
      Get
        Return _OOEByAccounts
      End Get
      Set(ByVal value As Boolean)
        _OOEByAccounts = value
      End Set
    End Property
    Public Property OOEReasonID() As String
      Get
        Return _OOEReasonID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _OOEReasonID = ""
        Else
          _OOEReasonID = value
        End If
      End Set
    End Property
    Public Property OOERemarks() As String
      Get
        Return _OOERemarks
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _OOERemarks = ""
        Else
          _OOERemarks = value
        End If
      End Set
    End Property
    Public Property ApprovalWFTypeID() As String
      Get
        Return _ApprovalWFTypeID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ApprovalWFTypeID = ""
        Else
          _ApprovalWFTypeID = value
        End If
      End Set
    End Property
    Public Property ApprovedBy() As String
      Get
        Return _ApprovedBy
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
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
        If Convert.IsDBNull(value) Then
          _ApprovedOn = ""
        Else
          _ApprovedOn = value
        End If
      End Set
    End Property
    Public Property ApprovalRemarks() As String
      Get
        Return _ApprovalRemarks
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ApprovalRemarks = ""
        Else
          _ApprovalRemarks = value
        End If
      End Set
    End Property
    Public Property Setteled() As Boolean
      Get
        Return _Setteled
      End Get
      Set(ByVal value As Boolean)
        _Setteled = value
      End Set
    End Property
    Public Property BillAttached() As Boolean
      Get
        Return _BillAttached
      End Get
      Set(ByVal value As Boolean)
        _BillAttached = value
      End Set
    End Property
    Public Property BillFileName() As String
      Get
        Return _BillFileName
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _BillFileName = ""
        Else
          _BillFileName = value
        End If
      End Set
    End Property
    Public Property BillDiskFile() As String
      Get
        Return _BillDiskFile
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _BillDiskFile = ""
        Else
          _BillDiskFile = value
        End If
      End Set
    End Property
    Public Property SanctionAttached() As Boolean
      Get
        Return _SanctionAttached
      End Get
      Set(ByVal value As Boolean)
        _SanctionAttached = value
      End Set
    End Property
    Public Property SanctionFileName() As String
      Get
        Return _SanctionFileName
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _SanctionFileName = ""
        Else
          _SanctionFileName = value
        End If
      End Set
    End Property
    Public Property SanctionDiskFile() As String
      Get
        Return _SanctionDiskFile
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _SanctionDiskFile = ""
        Else
          _SanctionDiskFile = value
        End If
      End Set
    End Property
    Public Property SystemText() As String
      Get
        Return _SystemText
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _SystemText = ""
        Else
          _SystemText = value
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
    Public Property HRM_Departments2_Description() As String
      Get
        Return _HRM_Departments2_Description
      End Get
      Set(ByVal value As String)
        _HRM_Departments2_Description = value
      End Set
    End Property
    Public Property IDM_Projects3_Description() As String
      Get
        Return _IDM_Projects3_Description
      End Get
      Set(ByVal value As String)
        _IDM_Projects3_Description = value
      End Set
    End Property
    Public Property TA_ApprovalWFTypes4_WFTypeDescription() As String
      Get
        Return _TA_ApprovalWFTypes4_WFTypeDescription
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TA_ApprovalWFTypes4_WFTypeDescription = ""
        Else
          _TA_ApprovalWFTypes4_WFTypeDescription = value
        End If
      End Set
    End Property
    Public Property TA_Bills5_PurposeOfJourney() As String
      Get
        Return _TA_Bills5_PurposeOfJourney
      End Get
      Set(ByVal value As String)
        _TA_Bills5_PurposeOfJourney = value
      End Set
    End Property
    Public Property TA_Cities6_CityName() As String
      Get
        Return _TA_Cities6_CityName
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TA_Cities6_CityName = ""
        Else
          _TA_Cities6_CityName = value
        End If
      End Set
    End Property
    Public Property TA_Cities7_CityName() As String
      Get
        Return _TA_Cities7_CityName
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TA_Cities7_CityName = ""
        Else
          _TA_Cities7_CityName = value
        End If
      End Set
    End Property
    Public Property TA_CityTypes8_CityTypeName() As String
      Get
        Return _TA_CityTypes8_CityTypeName
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TA_CityTypes8_CityTypeName = ""
        Else
          _TA_CityTypes8_CityTypeName = value
        End If
      End Set
    End Property
    Public Property TA_Components9_Description() As String
      Get
        Return _TA_Components9_Description
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TA_Components9_Description = ""
        Else
          _TA_Components9_Description = value
        End If
      End Set
    End Property
    Public Property TA_Currencies10_CurrencyName() As String
      Get
        Return _TA_Currencies10_CurrencyName
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TA_Currencies10_CurrencyName = ""
        Else
          _TA_Currencies10_CurrencyName = value
        End If
      End Set
    End Property
    Public Property TA_ExpenseHeads11_Description() As String
      Get
        Return _TA_ExpenseHeads11_Description
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TA_ExpenseHeads11_Description = ""
        Else
          _TA_ExpenseHeads11_Description = value
        End If
      End Set
    End Property
    Public Property TA_FinanceHeads12_Description() As String
      Get
        Return _TA_FinanceHeads12_Description
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TA_FinanceHeads12_Description = ""
        Else
          _TA_FinanceHeads12_Description = value
        End If
      End Set
    End Property
    Public Property TA_LCModes13_ModeName() As String
      Get
        Return _TA_LCModes13_ModeName
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TA_LCModes13_ModeName = ""
        Else
          _TA_LCModes13_ModeName = value
        End If
      End Set
    End Property
    Public Property TA_OOEReasons14_Description() As String
      Get
        Return _TA_OOEReasons14_Description
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TA_OOEReasons14_Description = ""
        Else
          _TA_OOEReasons14_Description = value
        End If
      End Set
    End Property
    Public Property TA_TravelModes15_ModeName() As String
      Get
        Return _TA_TravelModes15_ModeName
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TA_TravelModes15_ModeName = ""
        Else
          _TA_TravelModes15_ModeName = value
        End If
      End Set
    End Property
    Public Property TA_Countries16_CountryName() As String
      Get
        Return _TA_Countries16_CountryName
      End Get
      Set(ByVal value As String)
        _TA_Countries16_CountryName = value
      End Set
    End Property
    Public Property TA_Countries17_CountryName() As String
      Get
        Return _TA_Countries17_CountryName
      End Get
      Set(ByVal value As String)
        _TA_Countries17_CountryName = value
      End Set
    End Property
    Public ReadOnly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public ReadOnly Property PrimaryKey() As String
      Get
        Return _TABillNo & "|" & _SerialNo
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
    Public Class PKtaBillDetails
      Private _TABillNo As Int32 = 0
      Private _SerialNo As Int32 = 0
      Public Property TABillNo() As Int32
        Get
          Return _TABillNo
        End Get
        Set(ByVal value As Int32)
          _TABillNo = value
        End Set
      End Property
      Public Property SerialNo() As Int32
        Get
          Return _SerialNo
        End Get
        Set(ByVal value As Int32)
          _SerialNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_TA_BillDetails_ApprovedBy() As SIS.TA.taWebUsers
      Get
        If _FK_TA_BillDetails_ApprovedBy Is Nothing Then
          _FK_TA_BillDetails_ApprovedBy = SIS.TA.taWebUsers.taWebUsersGetByID(_ApprovedBy)
        End If
        Return _FK_TA_BillDetails_ApprovedBy
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillDetails_CostCenterID() As SIS.TA.taDepartments
      Get
        If _FK_TA_BillDetails_CostCenterID Is Nothing Then
          _FK_TA_BillDetails_CostCenterID = SIS.TA.taDepartments.taDepartmentsGetByID(_CostCenterID)
        End If
        Return _FK_TA_BillDetails_CostCenterID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillDetails_ProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_TA_BillDetails_ProjectID Is Nothing Then
          _FK_TA_BillDetails_ProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_ProjectID)
        End If
        Return _FK_TA_BillDetails_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillDetails_ApprovalWFTypeID() As SIS.TA.taApprovalWFTypes
      Get
        If _FK_TA_BillDetails_ApprovalWFTypeID Is Nothing Then
          _FK_TA_BillDetails_ApprovalWFTypeID = SIS.TA.taApprovalWFTypes.taApprovalWFTypesGetByID(_ApprovalWFTypeID)
        End If
        Return _FK_TA_BillDetails_ApprovalWFTypeID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillDetails_TABillNo() As SIS.TA.taBH
      Get
        If _FK_TA_BillDetails_TABillNo Is Nothing Then
          _FK_TA_BillDetails_TABillNo = SIS.TA.taBH.taBHGetByID(_TABillNo)
        End If
        Return _FK_TA_BillDetails_TABillNo
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillDetails_City1ID() As SIS.TA.taCities
      Get
        If _FK_TA_BillDetails_City1ID Is Nothing Then
          _FK_TA_BillDetails_City1ID = SIS.TA.taCities.taCitiesGetByID(_City1ID)
        End If
        Return _FK_TA_BillDetails_City1ID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillDetails_City2ID() As SIS.TA.taCities
      Get
        If _FK_TA_BillDetails_City2ID Is Nothing Then
          _FK_TA_BillDetails_City2ID = SIS.TA.taCities.taCitiesGetByID(_City2ID)
        End If
        Return _FK_TA_BillDetails_City2ID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillDetails_CityTypeID() As SIS.TA.taCityTypes
      Get
        If _FK_TA_BillDetails_CityTypeID Is Nothing Then
          _FK_TA_BillDetails_CityTypeID = SIS.TA.taCityTypes.taCityTypesGetByID(_CityTypeID)
        End If
        Return _FK_TA_BillDetails_CityTypeID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillDetails_ComponentID() As SIS.TA.taComponents
      Get
        If _FK_TA_BillDetails_ComponentID Is Nothing Then
          _FK_TA_BillDetails_ComponentID = SIS.TA.taComponents.taComponentsGetByID(_ComponentID)
        End If
        Return _FK_TA_BillDetails_ComponentID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillDetails_CurrencyID() As SIS.TA.taCurrencies
      Get
        If _FK_TA_BillDetails_CurrencyID Is Nothing Then
          _FK_TA_BillDetails_CurrencyID = SIS.TA.taCurrencies.taCurrenciesGetByID(_CurrencyID)
        End If
        Return _FK_TA_BillDetails_CurrencyID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillDetails_ModeExpenseID() As SIS.TA.taExpenseHeads
      Get
        If _FK_TA_BillDetails_ModeExpenseID Is Nothing Then
          _FK_TA_BillDetails_ModeExpenseID = SIS.TA.taExpenseHeads.taExpenseHeadsGetByID(_ModeExpenseID)
        End If
        Return _FK_TA_BillDetails_ModeExpenseID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillDetails_ModeFinanceID() As SIS.TA.taFinanceHeads
      Get
        If _FK_TA_BillDetails_ModeFinanceID Is Nothing Then
          _FK_TA_BillDetails_ModeFinanceID = SIS.TA.taFinanceHeads.taFinanceHeadsGetByID(_ModeFinanceID)
        End If
        Return _FK_TA_BillDetails_ModeFinanceID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillDetails_ModeLCID() As SIS.TA.taLCModes
      Get
        If _FK_TA_BillDetails_ModeLCID Is Nothing Then
          _FK_TA_BillDetails_ModeLCID = SIS.TA.taLCModes.taLCModesGetByID(_ModeLCID)
        End If
        Return _FK_TA_BillDetails_ModeLCID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillDetails_OOEReasonID() As SIS.TA.taOOEReasons
      Get
        If _FK_TA_BillDetails_OOEReasonID Is Nothing Then
          _FK_TA_BillDetails_OOEReasonID = SIS.TA.taOOEReasons.taOOEReasonsGetByID(_OOEReasonID)
        End If
        Return _FK_TA_BillDetails_OOEReasonID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillDetails_ModeTravelID() As SIS.TA.taTravelModes
      Get
        If _FK_TA_BillDetails_ModeTravelID Is Nothing Then
          _FK_TA_BillDetails_ModeTravelID = SIS.TA.taTravelModes.taTravelModesGetByID(_ModeTravelID)
        End If
        Return _FK_TA_BillDetails_ModeTravelID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillDetails_Country1ID() As SIS.TA.taCountries
      Get
        If _FK_TA_BillDetails_Country1ID Is Nothing Then
          _FK_TA_BillDetails_Country1ID = SIS.TA.taCountries.taCountriesGetByID(_Country1ID)
        End If
        Return _FK_TA_BillDetails_Country1ID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillDetails_Country2ID() As SIS.TA.taCountries
      Get
        If _FK_TA_BillDetails_Country2ID Is Nothing Then
          _FK_TA_BillDetails_Country2ID = SIS.TA.taCountries.taCountriesGetByID(_Country2ID)
        End If
        Return _FK_TA_BillDetails_Country2ID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function taBillDetailsGetNewRecord() As SIS.TA.taBillDetails
      Return New SIS.TA.taBillDetails()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function taBillDetailsGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32) As SIS.TA.taBillDetails
      Dim Results As SIS.TA.taBillDetails = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBillDetailsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TABillNo", SqlDbType.Int, TABillNo.ToString.Length, TABillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo", SqlDbType.Int, SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TA.taBillDetails(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function taBillDetailsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taBillDetails)
      Dim Results As List(Of SIS.TA.taBillDetails) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaBillDetailsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaBillDetailsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo", SqlDbType.Int, 10, IIf(TABillNo = Nothing, 0, TABillNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taBillDetails)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBillDetails(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taBillDetailsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As Integer
      Return _RecordCount
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function taBillDetailsGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32, ByVal Filter_TABillNo As Int32) As SIS.TA.taBillDetails
      Return taBillDetailsGetByID(TABillNo, SerialNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)>
    Public Shared Function taBillDetailsInsert(ByVal Record As SIS.TA.taBillDetails) As SIS.TA.taBillDetails
      Dim _Rec As SIS.TA.taBillDetails = SIS.TA.taBillDetails.taBillDetailsGetNewRecord()
      With _Rec
        .TABillNo = Record.TABillNo
        .ComponentID = Record.ComponentID
        .AutoCalculated = Record.AutoCalculated
        .TourExtended = Record.TourExtended
        .ProjectID = Record.ProjectID
        .CostCenterID = Record.CostCenterID
        .CurrencyID = Record.CurrencyID
        .CurrencyMain = Record.CurrencyMain
        .ConversionFactorINR = Record.ConversionFactorINR
        .ConversionFactorOU = Record.ConversionFactorOU
        .City1ID = Record.City1ID
        .City1Text = Record.City1Text
        .City2ID = Record.City2ID
        .City2Text = Record.City2Text
        .Country1ID = Record.Country1ID
        .Date1Time = Record.Date1Time
        .Country2ID = Record.Country2ID
        .Date2Time = Record.Date2Time
        .ModeTravelID = Record.ModeTravelID
        .ModeLCID = Record.ModeLCID
        .ModeExpenseID = Record.ModeExpenseID
        .ModeFinanceID = Record.ModeFinanceID
        .CityTypeID = Record.CityTypeID
        .ModeText = Record.ModeText
        .BoardingProvided = Record.BoardingProvided
        .LodgingProvided = Record.LodgingProvided
        .StayedWithRelative = Record.StayedWithRelative
        .StayedInGuestHouse = Record.StayedInGuestHouse
        .StayedAtSite = Record.StayedAtSite
        .StayedInHotel = Record.StayedInHotel
        .NotStayedAnyWhere = Record.NotStayedAnyWhere
        .AirportToHotel = Record.AirportToHotel
        .HotelToAirport = Record.HotelToAirport
        .AirportToClientLocation = Record.AirportToClientLocation
        .AmountFactor = Record.AmountFactor
        .AmountRate = Record.AmountRate
        .AmountRateOU = Record.AmountRateOU
        .AmountBasic = Record.AmountBasic
        .AmountTax = Record.AmountTax
        .AmountTaxOU = Record.AmountTaxOU
        .AmountTotal = Record.AmountTotal
        .AmountInINR = Record.AmountInINR
        .Remarks = Record.Remarks
        .PassedAmountFactor = Record.PassedAmountFactor
        .PassedAmountRate = Record.PassedAmountRate
        .PassedAmountBasic = Record.PassedAmountBasic
        .PassedAmountTax = Record.PassedAmountTax
        .PassedAmountTotal = Record.PassedAmountTotal
        .PassedAmountInINR = Record.PassedAmountInINR
        .AccountsRemarks = Record.AccountsRemarks
        .OOEBySystem = Record.OOEBySystem
        .OOEByAccounts = Record.OOEByAccounts
        .OOEReasonID = Record.OOEReasonID
        .OOERemarks = Record.OOERemarks
        .ApprovalWFTypeID = Record.ApprovalWFTypeID
        .ApprovedBy = Record.ApprovedBy
        .ApprovedOn = Record.ApprovedOn
        .ApprovalRemarks = Record.ApprovalRemarks
        .Setteled = Record.Setteled
        .BillAttached = Record.BillAttached
        .BillFileName = Record.BillFileName
        .BillDiskFile = Record.BillDiskFile
        .SanctionAttached = Record.SanctionAttached
        .SanctionFileName = Record.SanctionFileName
        .SanctionDiskFile = Record.SanctionDiskFile
        .SystemText = Record.SystemText
      End With
      Return SIS.TA.taBillDetails.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.TA.taBillDetails) As SIS.TA.taBillDetails
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBillDetailsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TABillNo", SqlDbType.Int, 11, Record.TABillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ComponentID", SqlDbType.Int, 11, Record.ComponentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AutoCalculated", SqlDbType.Bit, 3, Record.AutoCalculated)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TourExtended", SqlDbType.Bit, 3, Record.TourExtended)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, 7, IIf(Record.ProjectID = "", Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostCenterID", SqlDbType.NVarChar, 7, IIf(Record.CostCenterID = "", Convert.DBNull, Record.CostCenterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyID", SqlDbType.NVarChar, 7, IIf(Record.CurrencyID = "", Convert.DBNull, Record.CurrencyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConversionFactorINR", SqlDbType.Decimal, 21, Record.ConversionFactorINR)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyMain", SqlDbType.NVarChar, 7, IIf(Record.CurrencyMain = "", Convert.DBNull, Record.CurrencyMain))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConversionFactorOU", SqlDbType.Decimal, 21, Record.ConversionFactorOU)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@City1ID", SqlDbType.NVarChar, 31, IIf(Record.City1ID = "", Convert.DBNull, Record.City1ID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@City1Text", SqlDbType.NVarChar, 101, IIf(Record.City1Text = "", Convert.DBNull, Record.City1Text))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@City2ID", SqlDbType.NVarChar, 31, IIf(Record.City2ID = "", Convert.DBNull, Record.City2ID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@City2Text", SqlDbType.NVarChar, 101, IIf(Record.City2Text = "", Convert.DBNull, Record.City2Text))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Country1ID", SqlDbType.NVarChar, 31, IIf(Record.Country1ID = "", Convert.DBNull, Record.Country1ID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Date1Time", SqlDbType.DateTime, 21, IIf(Record.Date1Time = "", Convert.DBNull, Record.Date1Time))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Country2ID", SqlDbType.NVarChar, 31, IIf(Record.Country2ID = "", Convert.DBNull, Record.Country2ID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Date2Time", SqlDbType.DateTime, 21, IIf(Record.Date2Time = "", Convert.DBNull, Record.Date2Time))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModeTravelID", SqlDbType.Int, 11, IIf(Record.ModeTravelID = "", Convert.DBNull, Record.ModeTravelID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModeLCID", SqlDbType.Int, 11, IIf(Record.ModeLCID = "", Convert.DBNull, Record.ModeLCID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModeExpenseID", SqlDbType.Int, 11, IIf(Record.ModeExpenseID = "", Convert.DBNull, Record.ModeExpenseID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModeFinanceID", SqlDbType.Int, 11, IIf(Record.ModeFinanceID = "", Convert.DBNull, Record.ModeFinanceID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CityTypeID", SqlDbType.NVarChar, 7, IIf(Record.CityTypeID = "", Convert.DBNull, Record.CityTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModeText", SqlDbType.NVarChar, 101, IIf(Record.ModeText = "", Convert.DBNull, Record.ModeText))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BoardingProvided", SqlDbType.Bit, 3, Record.BoardingProvided)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LodgingProvided", SqlDbType.Bit, 3, Record.LodgingProvided)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StayedWithRelative", SqlDbType.Bit, 3, Record.StayedWithRelative)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StayedInGuestHouse", SqlDbType.Bit, 3, Record.StayedInGuestHouse)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StayedAtSite", SqlDbType.Bit, 3, Record.StayedAtSite)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StayedInHotel", SqlDbType.Bit, 3, Record.StayedInHotel)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NotStayedAnyWhere", SqlDbType.Bit, 3, Record.NotStayedAnyWhere)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AirportToHotel", SqlDbType.Bit, 3, Record.AirportToHotel)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HotelToAirport", SqlDbType.Bit, 3, Record.HotelToAirport)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AirportToClientLocation", SqlDbType.Bit, 3, Record.AirportToClientLocation)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AmountFactor", SqlDbType.Decimal, 21, Record.AmountFactor)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AmountRate", SqlDbType.Decimal, 21, Record.AmountRate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AmountRateOU", SqlDbType.Decimal, 21, Record.AmountRateOU)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AmountBasic", SqlDbType.Decimal, 21, Record.AmountBasic)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AmountTax", SqlDbType.Decimal, 21, Record.AmountTax)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AmountTaxOU", SqlDbType.Decimal, 21, Record.AmountTaxOU)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AmountTotal", SqlDbType.Decimal, 21, Record.AmountTotal)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AmountInINR", SqlDbType.Decimal, 21, Record.AmountInINR)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks", SqlDbType.NVarChar, 501, IIf(Record.Remarks = "", Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PassedAmountFactor", SqlDbType.Decimal, 21, Record.PassedAmountFactor)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PassedAmountRate", SqlDbType.Decimal, 21, Record.PassedAmountRate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PassedAmountBasic", SqlDbType.Decimal, 21, Record.PassedAmountBasic)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PassedAmountTax", SqlDbType.Decimal, 21, Record.PassedAmountTax)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PassedAmountTotal", SqlDbType.Decimal, 21, Record.PassedAmountTotal)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PassedAmountInINR", SqlDbType.Decimal, 21, Record.PassedAmountInINR)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AccountsRemarks", SqlDbType.NVarChar, 501, IIf(Record.AccountsRemarks = "", Convert.DBNull, Record.AccountsRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OOEBySystem", SqlDbType.Bit, 3, Record.OOEBySystem)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OOEByAccounts", SqlDbType.Bit, 3, Record.OOEByAccounts)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OOEReasonID", SqlDbType.Int, 11, IIf(Record.OOEReasonID = "", Convert.DBNull, Record.OOEReasonID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OOERemarks", SqlDbType.NVarChar, 501, IIf(Record.OOERemarks = "", Convert.DBNull, Record.OOERemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalWFTypeID", SqlDbType.Int, 11, IIf(Record.ApprovalWFTypeID = "", Convert.DBNull, Record.ApprovalWFTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy", SqlDbType.NVarChar, 9, IIf(Record.ApprovedBy = "", Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedOn", SqlDbType.DateTime, 21, IIf(Record.ApprovedOn = "", Convert.DBNull, Record.ApprovedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalRemarks", SqlDbType.NVarChar, 501, IIf(Record.ApprovalRemarks = "", Convert.DBNull, Record.ApprovalRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Setteled", SqlDbType.Bit, 3, Record.Setteled)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillAttached", SqlDbType.Bit, 3, Record.BillAttached)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillFileName", SqlDbType.NVarChar, 101, IIf(Record.BillFileName = "", Convert.DBNull, Record.BillFileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillDiskFile", SqlDbType.NVarChar, 251, IIf(Record.BillDiskFile = "", Convert.DBNull, Record.BillDiskFile))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionAttached", SqlDbType.Bit, 3, Record.SanctionAttached)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionFileName", SqlDbType.NVarChar, 101, IIf(Record.SanctionFileName = "", Convert.DBNull, Record.SanctionFileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionDiskFile", SqlDbType.NVarChar, 251, IIf(Record.SanctionDiskFile = "", Convert.DBNull, Record.SanctionDiskFile))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SystemText", SqlDbType.NVarChar, 251, IIf(Record.SystemText = "", Convert.DBNull, Record.SystemText))
          Cmd.Parameters.Add("@Return_TABillNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_TABillNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.TABillNo = Cmd.Parameters("@Return_TABillNo").Value
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)>
    Public Shared Function taBillDetailsUpdate(ByVal Record As SIS.TA.taBillDetails) As SIS.TA.taBillDetails
      Dim _Rec As SIS.TA.taBillDetails = SIS.TA.taBillDetails.taBillDetailsGetByID(Record.TABillNo, Record.SerialNo)
      With _Rec
        .ComponentID = Record.ComponentID
        .AutoCalculated = Record.AutoCalculated
        .TourExtended = Record.TourExtended
        .ProjectID = Record.ProjectID
        .CostCenterID = Record.CostCenterID
        .CurrencyID = Record.CurrencyID
        .CurrencyMain = Record.CurrencyMain
        .ConversionFactorINR = Record.ConversionFactorINR
        .ConversionFactorOU = Record.ConversionFactorOU
        .City1ID = Record.City1ID
        .City1Text = Record.City1Text
        .City2ID = Record.City2ID
        .City2Text = Record.City2Text
        .Country1ID = Record.Country1ID
        .Date1Time = Record.Date1Time
        .Country2ID = Record.Country2ID
        .Date2Time = Record.Date2Time
        .ModeTravelID = Record.ModeTravelID
        .ModeLCID = Record.ModeLCID
        .ModeExpenseID = Record.ModeExpenseID
        .ModeFinanceID = Record.ModeFinanceID
        .CityTypeID = Record.CityTypeID
        .ModeText = Record.ModeText
        .BoardingProvided = Record.BoardingProvided
        .LodgingProvided = Record.LodgingProvided
        .StayedWithRelative = Record.StayedWithRelative
        .StayedInGuestHouse = Record.StayedInGuestHouse
        .StayedAtSite = Record.StayedAtSite
        .StayedInHotel = Record.StayedInHotel
        .NotStayedAnyWhere = Record.NotStayedAnyWhere
        .AirportToHotel = Record.AirportToHotel
        .HotelToAirport = Record.HotelToAirport
        .AirportToClientLocation = Record.AirportToClientLocation
        .AmountFactor = Record.AmountFactor
        .AmountRate = Record.AmountRate
        .AmountRateOU = Record.AmountRateOU
        .AmountBasic = Record.AmountBasic
        .AmountTax = Record.AmountTax
        .AmountTaxOU = Record.AmountTaxOU
        .AmountTotal = Record.AmountTotal
        .AmountInINR = Record.AmountInINR
        .Remarks = Record.Remarks
        .PassedAmountFactor = Record.PassedAmountFactor
        .PassedAmountRate = Record.PassedAmountRate
        .PassedAmountBasic = Record.PassedAmountBasic
        .PassedAmountTax = Record.PassedAmountTax
        .PassedAmountTotal = Record.PassedAmountTotal
        .PassedAmountInINR = Record.PassedAmountInINR
        .AccountsRemarks = Record.AccountsRemarks
        .OOEBySystem = Record.OOEBySystem
        .OOEByAccounts = Record.OOEByAccounts
        .OOEReasonID = Record.OOEReasonID
        .OOERemarks = Record.OOERemarks
        .ApprovalWFTypeID = Record.ApprovalWFTypeID
        .ApprovedBy = Record.ApprovedBy
        .ApprovedOn = Record.ApprovedOn
        .ApprovalRemarks = Record.ApprovalRemarks
        .Setteled = Record.Setteled
        .BillAttached = Record.BillAttached
        .BillFileName = Record.BillFileName
        .BillDiskFile = Record.BillDiskFile
        .SanctionAttached = Record.SanctionAttached
        .SanctionFileName = Record.SanctionFileName
        .SanctionDiskFile = Record.SanctionDiskFile
        .SystemText = Record.SystemText
      End With
      Return SIS.TA.taBillDetails.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.TA.taBillDetails) As SIS.TA.taBillDetails
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBillDetailsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TABillNo", SqlDbType.Int, 11, Record.TABillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo", SqlDbType.Int, 11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TABillNo", SqlDbType.Int, 11, Record.TABillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ComponentID", SqlDbType.Int, 11, Record.ComponentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AutoCalculated", SqlDbType.Bit, 3, Record.AutoCalculated)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TourExtended", SqlDbType.Bit, 3, Record.TourExtended)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, 7, IIf(Record.ProjectID = "", Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostCenterID", SqlDbType.NVarChar, 7, IIf(Record.CostCenterID = "", Convert.DBNull, Record.CostCenterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyID", SqlDbType.NVarChar, 7, IIf(Record.CurrencyID = "", Convert.DBNull, Record.CurrencyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConversionFactorINR", SqlDbType.Decimal, 21, Record.ConversionFactorINR)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyMain", SqlDbType.NVarChar, 7, IIf(Record.CurrencyMain = "", Convert.DBNull, Record.CurrencyMain))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConversionFactorOU", SqlDbType.Decimal, 21, Record.ConversionFactorOU)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@City1ID", SqlDbType.NVarChar, 31, IIf(Record.City1ID = "", Convert.DBNull, Record.City1ID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@City1Text", SqlDbType.NVarChar, 101, IIf(Record.City1Text = "", Convert.DBNull, Record.City1Text))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@City2ID", SqlDbType.NVarChar, 31, IIf(Record.City2ID = "", Convert.DBNull, Record.City2ID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@City2Text", SqlDbType.NVarChar, 101, IIf(Record.City2Text = "", Convert.DBNull, Record.City2Text))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Country1ID", SqlDbType.NVarChar, 31, IIf(Record.Country1ID = "", Convert.DBNull, Record.Country1ID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Date1Time", SqlDbType.DateTime, 21, IIf(Record.Date1Time = "", Convert.DBNull, Record.Date1Time))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Country2ID", SqlDbType.NVarChar, 31, IIf(Record.Country2ID = "", Convert.DBNull, Record.Country2ID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Date2Time", SqlDbType.DateTime, 21, IIf(Record.Date2Time = "", Convert.DBNull, Record.Date2Time))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModeTravelID", SqlDbType.Int, 11, IIf(Record.ModeTravelID = "", Convert.DBNull, Record.ModeTravelID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModeLCID", SqlDbType.Int, 11, IIf(Record.ModeLCID = "", Convert.DBNull, Record.ModeLCID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModeExpenseID", SqlDbType.Int, 11, IIf(Record.ModeExpenseID = "", Convert.DBNull, Record.ModeExpenseID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModeFinanceID", SqlDbType.Int, 11, IIf(Record.ModeFinanceID = "", Convert.DBNull, Record.ModeFinanceID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CityTypeID", SqlDbType.NVarChar, 7, IIf(Record.CityTypeID = "", Convert.DBNull, Record.CityTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ModeText", SqlDbType.NVarChar, 101, IIf(Record.ModeText = "", Convert.DBNull, Record.ModeText))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BoardingProvided", SqlDbType.Bit, 3, Record.BoardingProvided)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LodgingProvided", SqlDbType.Bit, 3, Record.LodgingProvided)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StayedWithRelative", SqlDbType.Bit, 3, Record.StayedWithRelative)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StayedInGuestHouse", SqlDbType.Bit, 3, Record.StayedInGuestHouse)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StayedAtSite", SqlDbType.Bit, 3, Record.StayedAtSite)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StayedInHotel", SqlDbType.Bit, 3, Record.StayedInHotel)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NotStayedAnyWhere", SqlDbType.Bit, 3, Record.NotStayedAnyWhere)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AirportToHotel", SqlDbType.Bit, 3, Record.AirportToHotel)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HotelToAirport", SqlDbType.Bit, 3, Record.HotelToAirport)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AirportToClientLocation", SqlDbType.Bit, 3, Record.AirportToClientLocation)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AmountFactor", SqlDbType.Decimal, 21, Record.AmountFactor)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AmountRate", SqlDbType.Decimal, 21, Record.AmountRate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AmountRateOU", SqlDbType.Decimal, 21, Record.AmountRateOU)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AmountBasic", SqlDbType.Decimal, 21, Record.AmountBasic)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AmountTax", SqlDbType.Decimal, 21, Record.AmountTax)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AmountTaxOU", SqlDbType.Decimal, 21, Record.AmountTaxOU)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AmountTotal", SqlDbType.Decimal, 21, Record.AmountTotal)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AmountInINR", SqlDbType.Decimal, 21, Record.AmountInINR)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks", SqlDbType.NVarChar, 501, IIf(Record.Remarks = "", Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PassedAmountFactor", SqlDbType.Decimal, 21, Record.PassedAmountFactor)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PassedAmountRate", SqlDbType.Decimal, 21, Record.PassedAmountRate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PassedAmountBasic", SqlDbType.Decimal, 21, Record.PassedAmountBasic)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PassedAmountTax", SqlDbType.Decimal, 21, Record.PassedAmountTax)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PassedAmountTotal", SqlDbType.Decimal, 21, Record.PassedAmountTotal)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PassedAmountInINR", SqlDbType.Decimal, 21, Record.PassedAmountInINR)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AccountsRemarks", SqlDbType.NVarChar, 501, IIf(Record.AccountsRemarks = "", Convert.DBNull, Record.AccountsRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OOEBySystem", SqlDbType.Bit, 3, Record.OOEBySystem)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OOEByAccounts", SqlDbType.Bit, 3, Record.OOEByAccounts)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OOEReasonID", SqlDbType.Int, 11, IIf(Record.OOEReasonID = "", Convert.DBNull, Record.OOEReasonID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OOERemarks", SqlDbType.NVarChar, 501, IIf(Record.OOERemarks = "", Convert.DBNull, Record.OOERemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalWFTypeID", SqlDbType.Int, 11, IIf(Record.ApprovalWFTypeID = "", Convert.DBNull, Record.ApprovalWFTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy", SqlDbType.NVarChar, 9, IIf(Record.ApprovedBy = "", Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedOn", SqlDbType.DateTime, 21, IIf(Record.ApprovedOn = "", Convert.DBNull, Record.ApprovedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalRemarks", SqlDbType.NVarChar, 501, IIf(Record.ApprovalRemarks = "", Convert.DBNull, Record.ApprovalRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Setteled", SqlDbType.Bit, 3, Record.Setteled)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillAttached", SqlDbType.Bit, 3, Record.BillAttached)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillFileName", SqlDbType.NVarChar, 101, IIf(Record.BillFileName = "", Convert.DBNull, Record.BillFileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillDiskFile", SqlDbType.NVarChar, 251, IIf(Record.BillDiskFile = "", Convert.DBNull, Record.BillDiskFile))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionAttached", SqlDbType.Bit, 3, Record.SanctionAttached)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionFileName", SqlDbType.NVarChar, 101, IIf(Record.SanctionFileName = "", Convert.DBNull, Record.SanctionFileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionDiskFile", SqlDbType.NVarChar, 251, IIf(Record.SanctionDiskFile = "", Convert.DBNull, Record.SanctionDiskFile))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SystemText", SqlDbType.NVarChar, 251, IIf(Record.SystemText = "", Convert.DBNull, Record.SystemText))
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
    Public Shared Function taBillDetailsDelete(ByVal Record As SIS.TA.taBillDetails) As Int32
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBillDetailsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TABillNo", SqlDbType.Int, Record.TABillNo.ToString.Length, Record.TABillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo", SqlDbType.Int, Record.SerialNo.ToString.Length, Record.SerialNo)
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
