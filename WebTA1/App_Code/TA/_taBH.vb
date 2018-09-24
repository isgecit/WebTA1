Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()>
  Partial Public Class taBH
    Private Shared _RecordCount As Integer
    Private _TABillNo As Int32 = 0
    Private _OfficeID As String = ""
    Private _SiteName As String = ""
    Private _SiteTransfer As Boolean = False
    Private _CalculateDriverCharges As Boolean = False
    Private _DepartureFromIndia As String = ""
    Private _ArrivalToIndia As String = ""
    Private _DestinationName As String = ""
    Private _TravelTypeID As Int32 = 0
    Private _CityOfOrigin As String = ""
    Private _DestinationCity As String = ""
    Private _TrainingProgramResidential As Boolean = False
    Private _PartialTABill As Boolean = False
    Private _ProjectID As String = ""
    Private _TrainingProgram As Boolean = False
    Private _SameDayVisit As Boolean = False
    Private _Within25KM As Boolean = False
    Private _SiteToAnotherSite As Boolean = False
    Private _TaxiHired As Boolean = False
    Private _OwnVehicleUsed As Boolean = False
    Private _PurposeOfJourney As String = ""
    Private _BriefTourReport As String = ""
    Private _ReceivedOn As String = ""
    Private _ApprovalDiskFile As String = ""
    Private _SanctionDiskFile As String = ""
    Private _OOEByAccounts As Boolean = False
    Private _ApprovalFileName As String = ""
    Private _CCRemarks As String = ""
    Private _ERPBatchNo As String = ""
    Private _PostedOn As String = ""
    Private _ERPDocumentNo As String = ""
    Private _ApprovalAttached As Boolean = False
    Private _SARemarks As String = ""
    Private _EndDateTime As String = ""
    Private _CalculationTypeID As String = ""
    Private _ReportAttached As Boolean = False
    Private _BillCurrencyID As String = ""
    Private _SanctionFileName As String = ""
    Private _OOEBySystem As Boolean = False
    Private _CompanyID As String = ""
    Private _ConversionFactorINR As Decimal = 0
    Private _VerifiedOn As String = ""
    Private _ForwardedOn As String = ""
    Private _ReportDiskFile As String = ""
    Private _ReportFileName As String = ""
    Private _VerifiedBy As String = ""
    Private _ApprovalRemarks As String = ""
    Private _SanctionAttached As Boolean = False
    Private _VerificationRemarks As String = ""
    Private _ApprovedBy As String = ""
    Private _SanctionedLodging As Decimal = 0
    Private _SanctionedDA As Decimal = 0
    Private _ApprovedByCC As String = ""
    Private _ApprovedBySA As String = ""
    Private _ApprovedByCCOn As String = ""
    Private _ApprovedOn As String = ""
    Private _CostCenterID As String = ""
    Private _TACategoryID As String = ""
    Private _EmployeeID As String = ""
    Private _TotalClaimedAmount As Decimal = 0
    Private _TotalPayableAmount As Decimal = 0
    Private _TotalFinancedAmount As Decimal = 0
    Private _TotalPassedAmount As Decimal = 0
    Private _ApprovedBySAOn As String = ""
    Private _ComponentID As String = ""
    Private _PostedBy As String = ""
    Private _DivisionID As String = ""
    Private _NonTechnical As Boolean = False
    Private _StartDateTime As String = ""
    Private _OOEReasonID As String = ""
    Private _Setteled As Boolean = False
    Private _OOERemarks As String = ""
    Private _ApprovalWFTypeID As String = ""
    Private _BillStatusID As Int32 = 0
    Private _DepartmentID As String = ""
    Private _PrjCalcType As String = ""
    Private _Contractual As Boolean = False
    Private _DesignationID As String = ""
    Private _HRM_Companies1_Description As String = ""
    Private _HRM_Departments2_Description As String = ""
    Private _HRM_Designations3_Description As String = ""
    Private _HRM_Divisions4_Description As String = ""
    Private _HRM_Employees5_EmployeeName As String = ""
    Private _HRM_Employees6_EmployeeName As String = ""
    Private _HRM_Employees7_EmployeeName As String = ""
    Private _HRM_Employees8_EmployeeName As String = ""
    Private _HRM_Employees9_EmployeeName As String = ""
    Private _HRM_Employees10_EmployeeName As String = ""
    Private _IDM_Projects11_Description As String = ""
    Private _TA_ApprovalWFTypes12_WFTypeDescription As String = ""
    Private _TA_Categories13_cmba As String = ""
    Private _TA_Cities14_CityName As String = ""
    Private _TA_Currencies15_CurrencyName As String = ""
    Private _TA_BillStates16_Description As String = ""
    Private _TA_TravelTypes17_TravelTypeDescription As String = ""
    Private _TA_OOEReasons18_Description As String = ""
    Private _HRM_Departments1_Description As String = ""
    Private _TA_Components2_Description As String = ""
    Private _TA_CalcMethod1_CalculationDescription As String = ""
    Private _TA_PrjCalcMethod1_Description As String = ""
    Private _TA_Cities1_CityName As String = ""
    Private _FK_TA_Bills_CompanyID As SIS.QCM.qcmCompanies = Nothing
    Private _FK_TA_Bills_DepartmentID As SIS.TA.taDepartments = Nothing
    Private _FK_TA_Bills_DesignationID As SIS.QCM.qcmDesignations = Nothing
    Private _FK_TA_Bills_DivisionID As SIS.TA.taDivisions = Nothing
    Private _FK_TA_Bills_EmployeeID As SIS.TA.taEmployees = Nothing
    Private _FK_TA_Bills_PostedBy As SIS.TA.taEmployees = Nothing
    Private _FK_TA_Bills_ApprovedBy As SIS.TA.taEmployees = Nothing
    Private _FK_TA_Bills_ApprovedByCC As SIS.TA.taEmployees = Nothing
    Private _FK_TA_Bills_ApprovedBySA As SIS.TA.taEmployees = Nothing
    Private _FK_TA_Bills_VerifiedBy As SIS.TA.taEmployees = Nothing
    Private _FK_TA_Bills_ProjectID As SIS.QCM.qcmProjects = Nothing
    Private _FK_TA_Bills_ApprovalWFTypeID As SIS.TA.taApprovalWFTypes = Nothing
    Private _FK_TA_Bills_TACategoryID As SIS.TA.taCategories = Nothing
    Private _FK_TA_Bills_DestinationCity As SIS.TA.taCities = Nothing
    Private _FK_TA_Bills_CurrencyID As SIS.TA.taCurrencies = Nothing
    Private _FK_TA_Bills_BillStatusID As SIS.TA.taBillStates = Nothing
    Private _FK_TA_Bills_TravelTypeID As SIS.TA.taTravelTypes = Nothing
    Private _FK_TA_Bills_OOEReasonID As SIS.TA.taOOEReasons = Nothing
    Private _FK_TA_Bills_CostCenterID As SIS.TA.taDepartments = Nothing
    Private _FK_TA_Bills_ComponentID As SIS.TA.taComponents = Nothing
    Private _FK_TA_Bills_CalculationTypeID As SIS.TA.taCalcMethod = Nothing
    Private _FK_TA_Bills_PrjCalculationType As SIS.TA.taPrjCalcMethod = Nothing
    Private _FK_TA_Bills_CityOfOrigin As SIS.TA.taCities = Nothing
    Public Property VCHBy As String = ""
    Public Property VCHOn As String = ""
    Public Property VCHBatch As String = ""
    Public Property VCHDocument As String = ""
    Public Property VCHLine As String = ""
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
    Public Property OfficeID() As String
      Get
        Return _OfficeID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _OfficeID = ""
        Else
          _OfficeID = value
        End If
      End Set
    End Property
    Public Property SiteName() As String
      Get
        Return _SiteName
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _SiteName = ""
        Else
          _SiteName = value
        End If
      End Set
    End Property
    Public Property SiteTransfer() As Boolean
      Get
        Return _SiteTransfer
      End Get
      Set(ByVal value As Boolean)
        _SiteTransfer = value
      End Set
    End Property
    Public Property CalculateDriverCharges() As Boolean
      Get
        Return _CalculateDriverCharges
      End Get
      Set(ByVal value As Boolean)
        _CalculateDriverCharges = value
      End Set
    End Property
    Public Property DepartureFromIndia() As String
      Get
        If Not _DepartureFromIndia = String.Empty Then
          Return Convert.ToDateTime(_DepartureFromIndia).ToString("dd/MM/yyyy")
        End If
        Return _DepartureFromIndia
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _DepartureFromIndia = ""
        Else
          _DepartureFromIndia = value
        End If
      End Set
    End Property
    Public Property ArrivalToIndia() As String
      Get
        If Not _ArrivalToIndia = String.Empty Then
          Return Convert.ToDateTime(_ArrivalToIndia).ToString("dd/MM/yyyy")
        End If
        Return _ArrivalToIndia
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ArrivalToIndia = ""
        Else
          _ArrivalToIndia = value
        End If
      End Set
    End Property
    Public Property DestinationName() As String
      Get
        Return _DestinationName
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _DestinationName = ""
        Else
          _DestinationName = value
        End If
      End Set
    End Property
    Public Property TrainingProgramResidential() As Boolean
      Get
        Return _TrainingProgramResidential
      End Get
      Set(ByVal value As Boolean)
        _TrainingProgramResidential = value
      End Set
    End Property
    Public Property PartialTABill() As Boolean
      Get
        Return _PartialTABill
      End Get
      Set(ByVal value As Boolean)
        _PartialTABill = value
      End Set
    End Property
    Public Property TravelTypeID() As Int32
      Get
        Return _TravelTypeID
      End Get
      Set(ByVal value As Int32)
        _TravelTypeID = value
      End Set
    End Property
    Public Property CityOfOrigin() As String
      Get
        Return _CityOfOrigin
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _CityOfOrigin = ""
        Else
          _CityOfOrigin = value
        End If
      End Set
    End Property
    Public Property DestinationCity() As String
      Get
        Return _DestinationCity
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _DestinationCity = ""
        Else
          _DestinationCity = value
        End If
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
    Public Property TrainingProgram() As Boolean
      Get
        Return _TrainingProgram
      End Get
      Set(ByVal value As Boolean)
        _TrainingProgram = value
      End Set
    End Property
    Public Property SameDayVisit() As Boolean
      Get
        Return _SameDayVisit
      End Get
      Set(ByVal value As Boolean)
        _SameDayVisit = value
      End Set
    End Property
    Public Property Within25KM() As Boolean
      Get
        Return _Within25KM
      End Get
      Set(ByVal value As Boolean)
        _Within25KM = value
      End Set
    End Property
    Public Property SiteToAnotherSite() As Boolean
      Get
        Return _SiteToAnotherSite
      End Get
      Set(ByVal value As Boolean)
        _SiteToAnotherSite = value
      End Set
    End Property
    Public Property TaxiHired() As Boolean
      Get
        Return _TaxiHired
      End Get
      Set(ByVal value As Boolean)
        _TaxiHired = value
      End Set
    End Property
    Public Property OwnVehicleUsed() As Boolean
      Get
        Return _OwnVehicleUsed
      End Get
      Set(ByVal value As Boolean)
        _OwnVehicleUsed = value
      End Set
    End Property
    Public Property PurposeOfJourney() As String
      Get
        Return _PurposeOfJourney
      End Get
      Set(ByVal value As String)
        _PurposeOfJourney = value
      End Set
    End Property
    Public Property BriefTourReport() As String
      Get
        Return _BriefTourReport
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _BriefTourReport = ""
        Else
          _BriefTourReport = value
        End If
      End Set
    End Property
    Public Property ReceivedOn() As String
      Get
        If Not _ReceivedOn = String.Empty Then
          Return Convert.ToDateTime(_ReceivedOn).ToString("dd/MM/yyyy")
        End If
        Return _ReceivedOn
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ReceivedOn = ""
        Else
          _ReceivedOn = value
        End If
      End Set
    End Property
    Public Property ApprovalDiskFile() As String
      Get
        Return _ApprovalDiskFile
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ApprovalDiskFile = ""
        Else
          _ApprovalDiskFile = value
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
    Public Property OOEByAccounts() As Boolean
      Get
        Return _OOEByAccounts
      End Get
      Set(ByVal value As Boolean)
        _OOEByAccounts = value
      End Set
    End Property
    Public Property ApprovalFileName() As String
      Get
        Return _ApprovalFileName
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ApprovalFileName = ""
        Else
          _ApprovalFileName = value
        End If
      End Set
    End Property
    Public Property CCRemarks() As String
      Get
        Return _CCRemarks
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _CCRemarks = ""
        Else
          _CCRemarks = value
        End If
      End Set
    End Property
    Public Property ERPBatchNo() As String
      Get
        Return _ERPBatchNo
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ERPBatchNo = ""
        Else
          _ERPBatchNo = value
        End If
      End Set
    End Property
    Public Property PostedOn() As String
      Get
        If Not _PostedOn = String.Empty Then
          Return Convert.ToDateTime(_PostedOn).ToString("dd/MM/yyyy")
        End If
        Return _PostedOn
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _PostedOn = ""
        Else
          _PostedOn = value
        End If
      End Set
    End Property
    Public Property ERPDocumentNo() As String
      Get
        Return _ERPDocumentNo
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ERPDocumentNo = ""
        Else
          _ERPDocumentNo = value
        End If
      End Set
    End Property
    Public Property ApprovalAttached() As Boolean
      Get
        Return _ApprovalAttached
      End Get
      Set(ByVal value As Boolean)
        _ApprovalAttached = value
      End Set
    End Property
    Public Property SARemarks() As String
      Get
        Return _SARemarks
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _SARemarks = ""
        Else
          _SARemarks = value
        End If
      End Set
    End Property
    Public Property EndDateTime() As String
      Get
        If Not _EndDateTime = String.Empty Then
          Return Convert.ToDateTime(_EndDateTime).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _EndDateTime
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _EndDateTime = ""
        Else
          _EndDateTime = value
        End If
      End Set
    End Property
    Public Property CalculationTypeID() As String
      Get
        Return _CalculationTypeID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _CalculationTypeID = ""
        Else
          _CalculationTypeID = value
        End If
      End Set
    End Property
    Public Property ReportAttached() As Boolean
      Get
        Return _ReportAttached
      End Get
      Set(ByVal value As Boolean)
        _ReportAttached = value
      End Set
    End Property
    Public Property BillCurrencyID() As String
      Get
        Return _BillCurrencyID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _BillCurrencyID = ""
        Else
          _BillCurrencyID = value
        End If
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
    Public Property OOEBySystem() As Boolean
      Get
        Return _OOEBySystem
      End Get
      Set(ByVal value As Boolean)
        _OOEBySystem = value
      End Set
    End Property
    Public Property CompanyID() As String
      Get
        Return _CompanyID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _CompanyID = ""
        Else
          _CompanyID = value
        End If
      End Set
    End Property
    Public Property ConversionFactorINR() As Decimal
      Get
        Return _ConversionFactorINR
      End Get
      Set(ByVal value As Decimal)
        _ConversionFactorINR = value
      End Set
    End Property
    Public Property VerifiedOn() As String
      Get
        If Not _VerifiedOn = String.Empty Then
          Return Convert.ToDateTime(_VerifiedOn).ToString("dd/MM/yyyy")
        End If
        Return _VerifiedOn
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _VerifiedOn = ""
        Else
          _VerifiedOn = value
        End If
      End Set
    End Property
    Public Property ForwardedOn() As String
      Get
        If Not _ForwardedOn = String.Empty Then
          Return Convert.ToDateTime(_ForwardedOn).ToString("dd/MM/yyyy")
        End If
        Return _ForwardedOn
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ForwardedOn = ""
        Else
          _ForwardedOn = value
        End If
      End Set
    End Property
    Public Property ReportDiskFile() As String
      Get
        Return _ReportDiskFile
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ReportDiskFile = ""
        Else
          _ReportDiskFile = value
        End If
      End Set
    End Property
    Public Property ReportFileName() As String
      Get
        Return _ReportFileName
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ReportFileName = ""
        Else
          _ReportFileName = value
        End If
      End Set
    End Property
    Public Property VerifiedBy() As String
      Get
        Return _VerifiedBy
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _VerifiedBy = ""
        Else
          _VerifiedBy = value
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
    Public Property SanctionAttached() As Boolean
      Get
        Return _SanctionAttached
      End Get
      Set(ByVal value As Boolean)
        _SanctionAttached = value
      End Set
    End Property
    Public Property VerificationRemarks() As String
      Get
        Return _VerificationRemarks
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _VerificationRemarks = ""
        Else
          _VerificationRemarks = value
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
    Public Property SanctionedLodging() As Decimal
      Get
        Return _SanctionedLodging
      End Get
      Set(ByVal value As Decimal)
        _SanctionedLodging = value
      End Set
    End Property
    Public Property SanctionedDA() As Decimal
      Get
        Return _SanctionedDA
      End Get
      Set(ByVal value As Decimal)
        _SanctionedDA = value
      End Set
    End Property
    Public Property ApprovedByCC() As String
      Get
        Return _ApprovedByCC
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ApprovedByCC = ""
        Else
          _ApprovedByCC = value
        End If
      End Set
    End Property
    Public Property ApprovedBySA() As String
      Get
        Return _ApprovedBySA
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ApprovedBySA = ""
        Else
          _ApprovedBySA = value
        End If
      End Set
    End Property
    Public Property ApprovedByCCOn() As String
      Get
        If Not _ApprovedByCCOn = String.Empty Then
          Return Convert.ToDateTime(_ApprovedByCCOn).ToString("dd/MM/yyyy")
        End If
        Return _ApprovedByCCOn
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ApprovedByCCOn = ""
        Else
          _ApprovedByCCOn = value
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
    Public Property TACategoryID() As String
      Get
        Return _TACategoryID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TACategoryID = ""
        Else
          _TACategoryID = value
        End If
      End Set
    End Property
    Public Property EmployeeID() As String
      Get
        Return _EmployeeID
      End Get
      Set(ByVal value As String)
        _EmployeeID = value
      End Set
    End Property
    Public Property TotalClaimedAmount() As Decimal
      Get
        Return _TotalClaimedAmount
      End Get
      Set(ByVal value As Decimal)
        _TotalClaimedAmount = value
      End Set
    End Property
    Public Property TotalPayableAmount() As Decimal
      Get
        Return _TotalPayableAmount
      End Get
      Set(ByVal value As Decimal)
        _TotalPayableAmount = value
      End Set
    End Property
    Public Property TotalFinancedAmount() As Decimal
      Get
        Return _TotalFinancedAmount
      End Get
      Set(ByVal value As Decimal)
        _TotalFinancedAmount = value
      End Set
    End Property
    Public Property TotalPassedAmount() As Decimal
      Get
        Return _TotalPassedAmount
      End Get
      Set(ByVal value As Decimal)
        _TotalPassedAmount = value
      End Set
    End Property
    Public Property ApprovedBySAOn() As String
      Get
        If Not _ApprovedBySAOn = String.Empty Then
          Return Convert.ToDateTime(_ApprovedBySAOn).ToString("dd/MM/yyyy")
        End If
        Return _ApprovedBySAOn
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ApprovedBySAOn = ""
        Else
          _ApprovedBySAOn = value
        End If
      End Set
    End Property
    Public Property ComponentID() As String
      Get
        Return _ComponentID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ComponentID = ""
        Else
          _ComponentID = value
        End If
      End Set
    End Property
    Public Property PostedBy() As String
      Get
        Return _PostedBy
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _PostedBy = ""
        Else
          _PostedBy = value
        End If
      End Set
    End Property
    Public Property DivisionID() As String
      Get
        Return _DivisionID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _DivisionID = ""
        Else
          _DivisionID = value
        End If
      End Set
    End Property
    Public Property NonTechnical() As Boolean
      Get
        Return _NonTechnical
      End Get
      Set(ByVal value As Boolean)
        _NonTechnical = value
      End Set
    End Property
    Public Property StartDateTime() As String
      Get
        If Not _StartDateTime = String.Empty Then
          Return Convert.ToDateTime(_StartDateTime).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _StartDateTime
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _StartDateTime = ""
        Else
          _StartDateTime = value
        End If
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
    Public Property Setteled() As Boolean
      Get
        Return _Setteled
      End Get
      Set(ByVal value As Boolean)
        _Setteled = value
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
    Public Property BillStatusID() As Int32
      Get
        Return _BillStatusID
      End Get
      Set(ByVal value As Int32)
        _BillStatusID = value
      End Set
    End Property
    Public Property DepartmentID() As String
      Get
        Return _DepartmentID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _DepartmentID = ""
        Else
          _DepartmentID = value
        End If
      End Set
    End Property
    Public Property PrjCalcType() As String
      Get
        Return _PrjCalcType
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _PrjCalcType = ""
        Else
          _PrjCalcType = value
        End If
      End Set
    End Property
    Public Property Contractual() As Boolean
      Get
        Return _Contractual
      End Get
      Set(ByVal value As Boolean)
        _Contractual = value
      End Set
    End Property
    Public Property DesignationID() As String
      Get
        Return _DesignationID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _DesignationID = ""
        Else
          _DesignationID = value
        End If
      End Set
    End Property
    Public Property HRM_Companies1_Description() As String
      Get
        Return _HRM_Companies1_Description
      End Get
      Set(ByVal value As String)
        _HRM_Companies1_Description = value
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
    Public Property HRM_Designations3_Description() As String
      Get
        Return _HRM_Designations3_Description
      End Get
      Set(ByVal value As String)
        _HRM_Designations3_Description = value
      End Set
    End Property
    Public Property HRM_Divisions4_Description() As String
      Get
        Return _HRM_Divisions4_Description
      End Get
      Set(ByVal value As String)
        _HRM_Divisions4_Description = value
      End Set
    End Property
    Public Property HRM_Employees5_EmployeeName() As String
      Get
        Return _HRM_Employees5_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees5_EmployeeName = value
      End Set
    End Property
    Public Property HRM_Employees6_EmployeeName() As String
      Get
        Return _HRM_Employees6_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees6_EmployeeName = value
      End Set
    End Property
    Public Property HRM_Employees7_EmployeeName() As String
      Get
        Return _HRM_Employees7_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees7_EmployeeName = value
      End Set
    End Property
    Public Property HRM_Employees8_EmployeeName() As String
      Get
        Return _HRM_Employees8_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees8_EmployeeName = value
      End Set
    End Property
    Public Property HRM_Employees9_EmployeeName() As String
      Get
        Return _HRM_Employees9_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees9_EmployeeName = value
      End Set
    End Property
    Public Property HRM_Employees10_EmployeeName() As String
      Get
        Return _HRM_Employees10_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees10_EmployeeName = value
      End Set
    End Property
    Public Property IDM_Projects11_Description() As String
      Get
        Return _IDM_Projects11_Description
      End Get
      Set(ByVal value As String)
        _IDM_Projects11_Description = value
      End Set
    End Property
    Public Property TA_ApprovalWFTypes12_WFTypeDescription() As String
      Get
        Return _TA_ApprovalWFTypes12_WFTypeDescription
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TA_ApprovalWFTypes12_WFTypeDescription = ""
        Else
          _TA_ApprovalWFTypes12_WFTypeDescription = value
        End If
      End Set
    End Property
    Public Property TA_Categories13_cmba() As String
      Get
        Return _TA_Categories13_cmba
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TA_Categories13_cmba = ""
        Else
          _TA_Categories13_cmba = value
        End If
      End Set
    End Property
    Public Property TA_Cities14_CityName() As String
      Get
        Return _TA_Cities14_CityName
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TA_Cities14_CityName = ""
        Else
          _TA_Cities14_CityName = value
        End If
      End Set
    End Property
    Public Property TA_Currencies15_CurrencyName() As String
      Get
        Return _TA_Currencies15_CurrencyName
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TA_Currencies15_CurrencyName = ""
        Else
          _TA_Currencies15_CurrencyName = value
        End If
      End Set
    End Property
    Public Property TA_BillStates16_Description() As String
      Get
        Return _TA_BillStates16_Description
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TA_BillStates16_Description = ""
        Else
          _TA_BillStates16_Description = value
        End If
      End Set
    End Property
    Public Property TA_TravelTypes17_TravelTypeDescription() As String
      Get
        Return _TA_TravelTypes17_TravelTypeDescription
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TA_TravelTypes17_TravelTypeDescription = ""
        Else
          _TA_TravelTypes17_TravelTypeDescription = value
        End If
      End Set
    End Property
    Public Property TA_OOEReasons18_Description() As String
      Get
        Return _TA_OOEReasons18_Description
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TA_OOEReasons18_Description = ""
        Else
          _TA_OOEReasons18_Description = value
        End If
      End Set
    End Property
    Public Property HRM_Departments1_Description() As String
      Get
        Return _HRM_Departments1_Description
      End Get
      Set(ByVal value As String)
        _HRM_Departments1_Description = value
      End Set
    End Property
    Public Property TA_Components2_Description() As String
      Get
        Return _TA_Components2_Description
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TA_Components2_Description = ""
        Else
          _TA_Components2_Description = value
        End If
      End Set
    End Property
    Public Property TA_CalcMethod1_CalculationDescription() As String
      Get
        Return _TA_CalcMethod1_CalculationDescription
      End Get
      Set(ByVal value As String)
        _TA_CalcMethod1_CalculationDescription = value
      End Set
    End Property
    Public Property TA_PrjCalcMethod1_Description() As String
      Get
        Return _TA_PrjCalcMethod1_Description
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TA_PrjCalcMethod1_Description = ""
        Else
          _TA_PrjCalcMethod1_Description = value
        End If
      End Set
    End Property
    Public Property TA_Cities1_CityName() As String
      Get
        Return _TA_Cities1_CityName
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TA_Cities1_CityName = ""
        Else
          _TA_Cities1_CityName = value
        End If
      End Set
    End Property
    Public ReadOnly Property DisplayField() As String
      Get
        Return "" & _PurposeOfJourney.ToString.PadRight(500, " ")
      End Get
    End Property
    Public ReadOnly Property PrimaryKey() As String
      Get
        Return _TABillNo
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
    Public Class PKtaBH
      Private _TABillNo As Int32 = 0
      Public Property TABillNo() As Int32
        Get
          Return _TABillNo
        End Get
        Set(ByVal value As Int32)
          _TABillNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_TA_Bills_CompanyID() As SIS.QCM.qcmCompanies
      Get
        If _FK_TA_Bills_CompanyID Is Nothing Then
          _FK_TA_Bills_CompanyID = SIS.QCM.qcmCompanies.qcmCompaniesGetByID(_CompanyID)
        End If
        Return _FK_TA_Bills_CompanyID
      End Get
    End Property
    Public ReadOnly Property FK_TA_Bills_DepartmentID() As SIS.TA.taDepartments
      Get
        If _FK_TA_Bills_DepartmentID Is Nothing Then
          _FK_TA_Bills_DepartmentID = SIS.TA.taDepartments.taDepartmentsGetByID(_DepartmentID)
        End If
        Return _FK_TA_Bills_DepartmentID
      End Get
    End Property
    Public ReadOnly Property FK_TA_Bills_DesignationID() As SIS.QCM.qcmDesignations
      Get
        If _FK_TA_Bills_DesignationID Is Nothing Then
          _FK_TA_Bills_DesignationID = SIS.QCM.qcmDesignations.qcmDesignationsGetByID(_DesignationID)
        End If
        Return _FK_TA_Bills_DesignationID
      End Get
    End Property
    Public ReadOnly Property FK_TA_Bills_DivisionID() As SIS.TA.taDivisions
      Get
        If _FK_TA_Bills_DivisionID Is Nothing Then
          _FK_TA_Bills_DivisionID = SIS.TA.taDivisions.taDivisionsGetByID(_DivisionID)
        End If
        Return _FK_TA_Bills_DivisionID
      End Get
    End Property
    Public ReadOnly Property FK_TA_Bills_EmployeeID() As SIS.TA.taEmployees
      Get
        If _FK_TA_Bills_EmployeeID Is Nothing Then
          _FK_TA_Bills_EmployeeID = SIS.TA.taEmployees.taEmployeesGetByID(_EmployeeID)
        End If
        Return _FK_TA_Bills_EmployeeID
      End Get
    End Property
    Public ReadOnly Property FK_TA_Bills_PostedBy() As SIS.TA.taEmployees
      Get
        If _FK_TA_Bills_PostedBy Is Nothing Then
          _FK_TA_Bills_PostedBy = SIS.TA.taEmployees.taEmployeesGetByID(_PostedBy)
        End If
        Return _FK_TA_Bills_PostedBy
      End Get
    End Property
    Public ReadOnly Property FK_TA_Bills_ApprovedBy() As SIS.TA.taEmployees
      Get
        If _FK_TA_Bills_ApprovedBy Is Nothing Then
          _FK_TA_Bills_ApprovedBy = SIS.TA.taEmployees.taEmployeesGetByID(_ApprovedBy)
        End If
        Return _FK_TA_Bills_ApprovedBy
      End Get
    End Property
    Public ReadOnly Property FK_TA_Bills_ApprovedByCC() As SIS.TA.taEmployees
      Get
        If _FK_TA_Bills_ApprovedByCC Is Nothing Then
          _FK_TA_Bills_ApprovedByCC = SIS.TA.taEmployees.taEmployeesGetByID(_ApprovedByCC)
        End If
        Return _FK_TA_Bills_ApprovedByCC
      End Get
    End Property
    Public ReadOnly Property FK_TA_Bills_ApprovedBySA() As SIS.TA.taEmployees
      Get
        If _FK_TA_Bills_ApprovedBySA Is Nothing Then
          _FK_TA_Bills_ApprovedBySA = SIS.TA.taEmployees.taEmployeesGetByID(_ApprovedBySA)
        End If
        Return _FK_TA_Bills_ApprovedBySA
      End Get
    End Property
    Public ReadOnly Property FK_TA_Bills_VerifiedBy() As SIS.TA.taEmployees
      Get
        If _FK_TA_Bills_VerifiedBy Is Nothing Then
          _FK_TA_Bills_VerifiedBy = SIS.TA.taEmployees.taEmployeesGetByID(_VerifiedBy)
        End If
        Return _FK_TA_Bills_VerifiedBy
      End Get
    End Property
    Public ReadOnly Property FK_TA_Bills_ProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_TA_Bills_ProjectID Is Nothing Then
          _FK_TA_Bills_ProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_ProjectID)
        End If
        Return _FK_TA_Bills_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_TA_Bills_ApprovalWFTypeID() As SIS.TA.taApprovalWFTypes
      Get
        If _FK_TA_Bills_ApprovalWFTypeID Is Nothing Then
          _FK_TA_Bills_ApprovalWFTypeID = SIS.TA.taApprovalWFTypes.taApprovalWFTypesGetByID(_ApprovalWFTypeID)
        End If
        Return _FK_TA_Bills_ApprovalWFTypeID
      End Get
    End Property
    Public ReadOnly Property FK_TA_Bills_TACategoryID() As SIS.TA.taCategories
      Get
        If _FK_TA_Bills_TACategoryID Is Nothing Then
          _FK_TA_Bills_TACategoryID = SIS.TA.taCategories.taCategoriesGetByID(_TACategoryID)
        End If
        Return _FK_TA_Bills_TACategoryID
      End Get
    End Property
    Public ReadOnly Property FK_TA_Bills_DestinationCity() As SIS.TA.taCities
      Get
        If _FK_TA_Bills_DestinationCity Is Nothing Then
          _FK_TA_Bills_DestinationCity = SIS.TA.taCities.taCitiesGetByID(_DestinationCity)
        End If
        Return _FK_TA_Bills_DestinationCity
      End Get
    End Property
    Public ReadOnly Property FK_TA_Bills_CurrencyID() As SIS.TA.taCurrencies
      Get
        If _FK_TA_Bills_CurrencyID Is Nothing Then
          _FK_TA_Bills_CurrencyID = SIS.TA.taCurrencies.taCurrenciesGetByID(_BillCurrencyID)
        End If
        Return _FK_TA_Bills_CurrencyID
      End Get
    End Property
    Public ReadOnly Property FK_TA_Bills_BillStatusID() As SIS.TA.taBillStates
      Get
        If _FK_TA_Bills_BillStatusID Is Nothing Then
          _FK_TA_Bills_BillStatusID = SIS.TA.taBillStates.taBillStatesGetByID(_BillStatusID)
        End If
        Return _FK_TA_Bills_BillStatusID
      End Get
    End Property
    Public ReadOnly Property FK_TA_Bills_TravelTypeID() As SIS.TA.taTravelTypes
      Get
        If _FK_TA_Bills_TravelTypeID Is Nothing Then
          _FK_TA_Bills_TravelTypeID = SIS.TA.taTravelTypes.taTravelTypesGetByID(_TravelTypeID)
        End If
        Return _FK_TA_Bills_TravelTypeID
      End Get
    End Property
    Public ReadOnly Property FK_TA_Bills_OOEReasonID() As SIS.TA.taOOEReasons
      Get
        If _FK_TA_Bills_OOEReasonID Is Nothing Then
          _FK_TA_Bills_OOEReasonID = SIS.TA.taOOEReasons.taOOEReasonsGetByID(_OOEReasonID)
        End If
        Return _FK_TA_Bills_OOEReasonID
      End Get
    End Property
    Public ReadOnly Property FK_TA_Bills_CostCenterID() As SIS.TA.taDepartments
      Get
        If _FK_TA_Bills_CostCenterID Is Nothing Then
          _FK_TA_Bills_CostCenterID = SIS.TA.taDepartments.taDepartmentsGetByID(_CostCenterID)
        End If
        Return _FK_TA_Bills_CostCenterID
      End Get
    End Property
    Public ReadOnly Property FK_TA_Bills_ComponentID() As SIS.TA.taComponents
      Get
        If _FK_TA_Bills_ComponentID Is Nothing Then
          _FK_TA_Bills_ComponentID = SIS.TA.taComponents.taComponentsGetByID(_ComponentID)
        End If
        Return _FK_TA_Bills_ComponentID
      End Get
    End Property
    Public ReadOnly Property FK_TA_Bills_CalculationTypeID() As SIS.TA.taCalcMethod
      Get
        If _FK_TA_Bills_CalculationTypeID Is Nothing Then
          _FK_TA_Bills_CalculationTypeID = SIS.TA.taCalcMethod.taCalcMethodGetByID(_CalculationTypeID)
        End If
        Return _FK_TA_Bills_CalculationTypeID
      End Get
    End Property
    Public ReadOnly Property FK_TA_Bills_PrjCalculationType() As SIS.TA.taPrjCalcMethod
      Get
        If _FK_TA_Bills_PrjCalculationType Is Nothing Then
          _FK_TA_Bills_PrjCalculationType = SIS.TA.taPrjCalcMethod.taPrjCalcMethodGetByID(_PrjCalcType)
        End If
        Return _FK_TA_Bills_PrjCalculationType
      End Get
    End Property
    Public ReadOnly Property FK_TA_Bills_CityOfOrigin() As SIS.TA.taCities
      Get
        If _FK_TA_Bills_CityOfOrigin Is Nothing Then
          _FK_TA_Bills_CityOfOrigin = SIS.TA.taCities.taCitiesGetByID(_CityOfOrigin)
        End If
        Return _FK_TA_Bills_CityOfOrigin
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function taBHSelectList(ByVal OrderBy As String) As List(Of SIS.TA.taBH)
      Dim Results As List(Of SIS.TA.taBH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "TABillNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBHSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.NVarChar, 8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taBH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBH(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function taBHGetNewRecord() As SIS.TA.taBH
      Return New SIS.TA.taBH()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function taBHGetByID(ByVal TABillNo As Int32) As SIS.TA.taBH
      Dim Results As SIS.TA.taBH = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBHSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TABillNo", SqlDbType.Int, TABillNo.ToString.Length, TABillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TA.taBH(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function GetByTravelTypeID(ByVal TravelTypeID As Int32, ByVal OrderBy As String) As List(Of SIS.TA.taBH)
      Dim Results As List(Of SIS.TA.taBH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "TABillNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBHSelectByTravelTypeID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TravelTypeID", SqlDbType.Int, TravelTypeID.ToString.Length, TravelTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.NVarChar, 8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taBH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBH(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function GetByProjectID(ByVal ProjectID As String, ByVal OrderBy As String) As List(Of SIS.TA.taBH)
      Dim Results As List(Of SIS.TA.taBH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "TABillNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBHSelectByProjectID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, ProjectID.ToString.Length, ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.NVarChar, 8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taBH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBH(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function GetByTACategoryID(ByVal TACategoryID As Int32, ByVal OrderBy As String) As List(Of SIS.TA.taBH)
      Dim Results As List(Of SIS.TA.taBH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "TABillNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBHSelectByTACategoryID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TACategoryID", SqlDbType.Int, TACategoryID.ToString.Length, TACategoryID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.NVarChar, 8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taBH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBH(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function GetByEmployeeID(ByVal EmployeeID As String, ByVal OrderBy As String) As List(Of SIS.TA.taBH)
      Dim Results As List(Of SIS.TA.taBH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "TABillNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBHSelectByEmployeeID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.NVarChar, EmployeeID.ToString.Length, EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.NVarChar, 8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taBH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBH(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function GetByDivisionID(ByVal DivisionID As String, ByVal OrderBy As String) As List(Of SIS.TA.taBH)
      Dim Results As List(Of SIS.TA.taBH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "TABillNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBHSelectByDivisionID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID", SqlDbType.NVarChar, DivisionID.ToString.Length, DivisionID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.NVarChar, 8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taBH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBH(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function GetByOOEReasonID(ByVal OOEReasonID As Int32, ByVal OrderBy As String) As List(Of SIS.TA.taBH)
      Dim Results As List(Of SIS.TA.taBH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "TABillNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBHSelectByOOEReasonID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OOEReasonID", SqlDbType.Int, OOEReasonID.ToString.Length, OOEReasonID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.NVarChar, 8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taBH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBH(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function GetByApprovalWFTypeID(ByVal ApprovalWFTypeID As Int32, ByVal OrderBy As String) As List(Of SIS.TA.taBH)
      Dim Results As List(Of SIS.TA.taBH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "TABillNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBHSelectByApprovalWFTypeID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalWFTypeID", SqlDbType.Int, ApprovalWFTypeID.ToString.Length, ApprovalWFTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.NVarChar, 8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taBH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBH(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function GetByBillStatusID(ByVal BillStatusID As Int32, ByVal OrderBy As String) As List(Of SIS.TA.taBH)
      Dim Results As List(Of SIS.TA.taBH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "TABillNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBHSelectByBillStatusID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillStatusID", SqlDbType.Int, BillStatusID.ToString.Length, BillStatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.NVarChar, 8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taBH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBH(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function GetByDepartmentID(ByVal DepartmentID As String, ByVal OrderBy As String) As List(Of SIS.TA.taBH)
      Dim Results As List(Of SIS.TA.taBH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "TABillNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBHSelectByDepartmentID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentID", SqlDbType.NVarChar, DepartmentID.ToString.Length, DepartmentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.NVarChar, 8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taBH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBH(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function taBHSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TravelTypeID As Int32, ByVal DestinationCity As String, ByVal ProjectID As String, ByVal BillStatusID As Int32) As List(Of SIS.TA.taBH)
      Dim Results As List(Of SIS.TA.taBH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "TABillNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaBHSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaBHSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TravelTypeID", SqlDbType.Int, 10, IIf(TravelTypeID = Nothing, 0, TravelTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DestinationCity", SqlDbType.NVarChar, 30, IIf(DestinationCity Is Nothing, String.Empty, DestinationCity))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID", SqlDbType.NVarChar, 6, IIf(ProjectID Is Nothing, String.Empty, ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BillStatusID", SqlDbType.Int, 10, IIf(BillStatusID = Nothing, 0, BillStatusID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.NVarChar, 8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taBH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBH(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taBHSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TravelTypeID As Int32, ByVal DestinationCity As String, ByVal ProjectID As String, ByVal BillStatusID As Int32) As Integer
      Return _RecordCount
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function taBHGetByID(ByVal TABillNo As Int32, ByVal Filter_TravelTypeID As Int32, ByVal Filter_DestinationCity As String, ByVal Filter_ProjectID As String, ByVal Filter_BillStatusID As Int32) As SIS.TA.taBH
      Return taBHGetByID(TABillNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)>
    Public Shared Function taBHInsert(ByVal Record As SIS.TA.taBH) As SIS.TA.taBH
      Dim _Rec As SIS.TA.taBH = SIS.TA.taBH.taBHGetNewRecord()
      With _Rec
        .OfficeID = Record.OfficeID
        .SiteName = Record.SiteName
        .SiteTransfer = Record.SiteTransfer
        .CalculateDriverCharges = Record.CalculateDriverCharges
        .DepartureFromIndia = Record.DepartureFromIndia
        .ArrivalToIndia = Record.ArrivalToIndia
        .DestinationName = Record.DestinationName
        .TravelTypeID = Record.TravelTypeID
        .CityOfOrigin = Record.CityOfOrigin
        .DestinationCity = Record.DestinationCity
        .ProjectID = Record.ProjectID
        .TrainingProgram = Record.TrainingProgram
        .SameDayVisit = Record.SameDayVisit
        .Within25KM = Record.Within25KM
        .SiteToAnotherSite = Record.SiteToAnotherSite
        .TaxiHired = Record.TaxiHired
        .OwnVehicleUsed = Record.OwnVehicleUsed
        .PurposeOfJourney = Record.PurposeOfJourney
        .BriefTourReport = Record.BriefTourReport
        .ReceivedOn = Record.ReceivedOn
        .ApprovalDiskFile = Record.ApprovalDiskFile
        .SanctionDiskFile = Record.SanctionDiskFile
        .OOEByAccounts = Record.OOEByAccounts
        .ApprovalFileName = Record.ApprovalFileName
        .CCRemarks = Record.CCRemarks
        .ERPBatchNo = Record.ERPBatchNo
        .PostedOn = Record.PostedOn
        .ERPDocumentNo = Record.ERPDocumentNo
        .ApprovalAttached = Record.ApprovalAttached
        .SARemarks = Record.SARemarks
        .EndDateTime = Record.EndDateTime
        .CalculationTypeID = Record.CalculationTypeID
        .ReportAttached = Record.ReportAttached
        .BillCurrencyID = Record.BillCurrencyID
        .SanctionFileName = Record.SanctionFileName
        .OOEBySystem = Record.OOEBySystem
        .CompanyID = Record.CompanyID
        .ConversionFactorINR = Record.ConversionFactorINR
        .VerifiedOn = Record.VerifiedOn
        .ForwardedOn = Record.ForwardedOn
        .ReportDiskFile = Record.ReportDiskFile
        .ReportFileName = Record.ReportFileName
        .VerifiedBy = Record.VerifiedBy
        .ApprovalRemarks = Record.ApprovalRemarks
        .SanctionAttached = Record.SanctionAttached
        .VerificationRemarks = Record.VerificationRemarks
        .ApprovedBy = Record.ApprovedBy
        .SanctionedLodging = Record.SanctionedLodging
        .SanctionedDA = Record.SanctionedDA
        .ApprovedByCC = Record.ApprovedByCC
        .ApprovedBySA = Record.ApprovedBySA
        .ApprovedByCCOn = Record.ApprovedByCCOn
        .ApprovedOn = Record.ApprovedOn
        .CostCenterID = Record.CostCenterID
        .TACategoryID = Record.TACategoryID
        .EmployeeID = Global.System.Web.HttpContext.Current.Session("LoginID")
        .TotalClaimedAmount = Record.TotalClaimedAmount
        .TotalPayableAmount = Record.TotalPayableAmount
        .TotalFinancedAmount = Record.TotalFinancedAmount
        .TotalPassedAmount = Record.TotalPassedAmount
        .ApprovedBySAOn = Record.ApprovedBySAOn
        .ComponentID = "1"
        .PostedBy = Record.PostedBy
        .DivisionID = Record.DivisionID
        .NonTechnical = Record.NonTechnical
        .StartDateTime = Record.StartDateTime
        .OOEReasonID = Record.OOEReasonID
        .Setteled = Record.Setteled
        .OOERemarks = Record.OOERemarks
        .ApprovalWFTypeID = Record.ApprovalWFTypeID
        .BillStatusID = 1
        .DepartmentID = Record.DepartmentID
        .PrjCalcType = 2
        .Contractual = Record.Contractual
        .DesignationID = Record.DesignationID
      End With
      Return SIS.TA.taBH.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.TA.taBH) As SIS.TA.taBH
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBHInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TravelTypeID", SqlDbType.Int, 11, Record.TravelTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CityOfOrigin", SqlDbType.NVarChar, 31, IIf(Record.CityOfOrigin = "", Convert.DBNull, Record.CityOfOrigin))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DestinationCity", SqlDbType.NVarChar, 31, IIf(Record.DestinationCity = "", Convert.DBNull, Record.DestinationCity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, 7, IIf(Record.ProjectID = "", Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TrainingProgram", SqlDbType.Bit, 3, Record.TrainingProgram)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SameDayVisit", SqlDbType.Bit, 3, Record.SameDayVisit)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Within25KM", SqlDbType.Bit, 3, Record.Within25KM)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteToAnotherSite", SqlDbType.Bit, 3, Record.SiteToAnotherSite)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TaxiHired", SqlDbType.Bit, 3, Record.TaxiHired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OwnVehicleUsed", SqlDbType.Bit, 3, Record.OwnVehicleUsed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PurposeOfJourney", SqlDbType.NVarChar, 501, Record.PurposeOfJourney)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BriefTourReport", SqlDbType.NVarChar, 501, IIf(Record.BriefTourReport = "", Convert.DBNull, Record.BriefTourReport))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedOn", SqlDbType.DateTime, 21, IIf(Record.ReceivedOn = "", Convert.DBNull, Record.ReceivedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalDiskFile", SqlDbType.NVarChar, 251, IIf(Record.ApprovalDiskFile = "", Convert.DBNull, Record.ApprovalDiskFile))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionDiskFile", SqlDbType.NVarChar, 251, IIf(Record.SanctionDiskFile = "", Convert.DBNull, Record.SanctionDiskFile))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OOEByAccounts", SqlDbType.Bit, 3, Record.OOEByAccounts)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalFileName", SqlDbType.NVarChar, 101, IIf(Record.ApprovalFileName = "", Convert.DBNull, Record.ApprovalFileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CCRemarks", SqlDbType.NVarChar, 251, IIf(Record.CCRemarks = "", Convert.DBNull, Record.CCRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ERPBatchNo", SqlDbType.NVarChar, 11, IIf(Record.ERPBatchNo = "", Convert.DBNull, Record.ERPBatchNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedOn", SqlDbType.DateTime, 21, IIf(Record.PostedOn = "", Convert.DBNull, Record.PostedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ERPDocumentNo", SqlDbType.NVarChar, 11, IIf(Record.ERPDocumentNo = "", Convert.DBNull, Record.ERPDocumentNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalAttached", SqlDbType.Bit, 3, Record.ApprovalAttached)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SARemarks", SqlDbType.NVarChar, 251, IIf(Record.SARemarks = "", Convert.DBNull, Record.SARemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EndDateTime", SqlDbType.DateTime, 21, IIf(Record.EndDateTime = "", Convert.DBNull, Record.EndDateTime))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CalculationTypeID", SqlDbType.NVarChar, 11, IIf(Record.CalculationTypeID = "", Convert.DBNull, Record.CalculationTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReportAttached", SqlDbType.Bit, 3, Record.ReportAttached)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillCurrencyID", SqlDbType.NVarChar, 7, IIf(Record.BillCurrencyID = "", Convert.DBNull, Record.BillCurrencyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionFileName", SqlDbType.NVarChar, 101, IIf(Record.SanctionFileName = "", Convert.DBNull, Record.SanctionFileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OOEBySystem", SqlDbType.Bit, 3, Record.OOEBySystem)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CompanyID", SqlDbType.NVarChar, 7, IIf(Record.CompanyID = "", Convert.DBNull, Record.CompanyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConversionFactorINR", SqlDbType.Decimal, 21, Record.ConversionFactorINR)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedOn", SqlDbType.DateTime, 21, IIf(Record.VerifiedOn = "", Convert.DBNull, Record.VerifiedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ForwardedOn", SqlDbType.DateTime, 21, IIf(Record.ForwardedOn = "", Convert.DBNull, Record.ForwardedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReportDiskFile", SqlDbType.NVarChar, 251, IIf(Record.ReportDiskFile = "", Convert.DBNull, Record.ReportDiskFile))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReportFileName", SqlDbType.NVarChar, 101, IIf(Record.ReportFileName = "", Convert.DBNull, Record.ReportFileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedBy", SqlDbType.NVarChar, 9, IIf(Record.VerifiedBy = "", Convert.DBNull, Record.VerifiedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalRemarks", SqlDbType.NVarChar, 501, IIf(Record.ApprovalRemarks = "", Convert.DBNull, Record.ApprovalRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionAttached", SqlDbType.Bit, 3, Record.SanctionAttached)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerificationRemarks", SqlDbType.NVarChar, 251, IIf(Record.VerificationRemarks = "", Convert.DBNull, Record.VerificationRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy", SqlDbType.NVarChar, 9, IIf(Record.ApprovedBy = "", Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionedLodging", SqlDbType.Decimal, 11, Record.SanctionedLodging)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionedDA", SqlDbType.Decimal, 11, Record.SanctionedDA)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedByCC", SqlDbType.NVarChar, 9, IIf(Record.ApprovedByCC = "", Convert.DBNull, Record.ApprovedByCC))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBySA", SqlDbType.NVarChar, 9, IIf(Record.ApprovedBySA = "", Convert.DBNull, Record.ApprovedBySA))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedByCCOn", SqlDbType.DateTime, 21, IIf(Record.ApprovedByCCOn = "", Convert.DBNull, Record.ApprovedByCCOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedOn", SqlDbType.DateTime, 21, IIf(Record.ApprovedOn = "", Convert.DBNull, Record.ApprovedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostCenterID", SqlDbType.NVarChar, 7, IIf(Record.CostCenterID = "", Convert.DBNull, Record.CostCenterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TACategoryID", SqlDbType.Int, 11, IIf(Record.TACategoryID = "", Convert.DBNull, Record.TACategoryID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.NVarChar, 9, Record.EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalClaimedAmount", SqlDbType.Decimal, 21, Record.TotalClaimedAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalPayableAmount", SqlDbType.Decimal, 21, Record.TotalPayableAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalFinancedAmount", SqlDbType.Decimal, 21, Record.TotalFinancedAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalPassedAmount", SqlDbType.Decimal, 21, Record.TotalPassedAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBySAOn", SqlDbType.DateTime, 21, IIf(Record.ApprovedBySAOn = "", Convert.DBNull, Record.ApprovedBySAOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ComponentID", SqlDbType.Int, 11, IIf(Record.ComponentID = "", Convert.DBNull, Record.ComponentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedBy", SqlDbType.NVarChar, 9, IIf(Record.PostedBy = "", Convert.DBNull, Record.PostedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID", SqlDbType.NVarChar, 7, IIf(Record.DivisionID = "", Convert.DBNull, Record.DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NonTechnical", SqlDbType.Bit, 3, Record.NonTechnical)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartDateTime", SqlDbType.DateTime, 21, IIf(Record.StartDateTime = "", Convert.DBNull, Record.StartDateTime))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OOEReasonID", SqlDbType.Int, 11, IIf(Record.OOEReasonID = "", Convert.DBNull, Record.OOEReasonID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Setteled", SqlDbType.Bit, 3, Record.Setteled)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OOERemarks", SqlDbType.NVarChar, 501, IIf(Record.OOERemarks = "", Convert.DBNull, Record.OOERemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalWFTypeID", SqlDbType.Int, 11, IIf(Record.ApprovalWFTypeID = "", Convert.DBNull, Record.ApprovalWFTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillStatusID", SqlDbType.Int, 11, Record.BillStatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentID", SqlDbType.NVarChar, 7, IIf(Record.DepartmentID = "", Convert.DBNull, Record.DepartmentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PrjCalcType", SqlDbType.Int, 11, IIf(Record.PrjCalcType = "", Convert.DBNull, Record.PrjCalcType))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Contractual", SqlDbType.Bit, 3, Record.Contractual)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DesignationID", SqlDbType.Int, 11, IIf(Record.DesignationID = "", Convert.DBNull, Record.DesignationID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OfficeID", SqlDbType.Int, 11, IIf(Record.OfficeID = "", Convert.DBNull, Record.OfficeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteName", SqlDbType.NVarChar, 51, IIf(Record.SiteName = "", Convert.DBNull, Record.SiteName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteTransfer", SqlDbType.Bit, 3, Record.SiteTransfer)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CalculateDriverCharges", SqlDbType.Bit, 3, Record.CalculateDriverCharges)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartureFromIndia", SqlDbType.DateTime, 21, IIf(Record.DepartureFromIndia = "", Convert.DBNull, Record.DepartureFromIndia))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ArrivalToIndia", SqlDbType.DateTime, 21, IIf(Record.ArrivalToIndia = "", Convert.DBNull, Record.ArrivalToIndia))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DestinationName", SqlDbType.NVarChar, 51, IIf(Record.DestinationName = "", Convert.DBNull, Record.DestinationName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TrainingProgramResidential", SqlDbType.Bit, 3, Record.TrainingProgramResidential)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PartialTABill", SqlDbType.Bit, 3, Record.PartialTABill)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VCHOn", SqlDbType.DateTime, 21, IIf(Record.VCHOn = "", Convert.DBNull, Record.VCHOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VCHBy", SqlDbType.NVarChar, 9, IIf(Record.VCHBy = "", Convert.DBNull, Record.VCHBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VCHBatch", SqlDbType.NVarChar, 51, IIf(Record.VCHBatch = "", Convert.DBNull, Record.VCHBatch))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VCHDocument", SqlDbType.NVarChar, 51, IIf(Record.VCHDocument = "", Convert.DBNull, Record.VCHDocument))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VCHLine", SqlDbType.NVarChar, 51, IIf(Record.VCHLine = "", Convert.DBNull, Record.VCHLine))
          Cmd.Parameters.Add("@Return_TABillNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_TABillNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.TABillNo = Cmd.Parameters("@Return_TABillNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)>
    Public Shared Function taBHUpdate(ByVal Record As SIS.TA.taBH) As SIS.TA.taBH
      Dim _Rec As SIS.TA.taBH = SIS.TA.taBH.taBHGetByID(Record.TABillNo)
      With _Rec
        .OfficeID = Record.OfficeID
        .SiteName = Record.SiteName
        .SiteTransfer = Record.SiteTransfer
        .CalculateDriverCharges = Record.CalculateDriverCharges
        .DepartureFromIndia = Record.DepartureFromIndia
        .ArrivalToIndia = Record.ArrivalToIndia
        .DestinationName = Record.DestinationName
        .TravelTypeID = Record.TravelTypeID
        .CityOfOrigin = Record.CityOfOrigin
        .DestinationCity = Record.DestinationCity
        .ProjectID = Record.ProjectID
        .TrainingProgram = Record.TrainingProgram
        .SameDayVisit = Record.SameDayVisit
        .Within25KM = Record.Within25KM
        .SiteToAnotherSite = Record.SiteToAnotherSite
        .TaxiHired = Record.TaxiHired
        .OwnVehicleUsed = Record.OwnVehicleUsed
        .PurposeOfJourney = Record.PurposeOfJourney
        .BriefTourReport = Record.BriefTourReport
        .BillCurrencyID = Record.BillCurrencyID
        .ConversionFactorINR = Record.ConversionFactorINR
        .SanctionedLodging = Record.SanctionedLodging
        .SanctionedDA = Record.SanctionedDA
        .CostCenterID = Record.CostCenterID
        .BillStatusID = Record.BillStatusID
        .PrjCalcType = Record.PrjCalcType
      End With
      Return SIS.TA.taBH.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.TA.taBH) As SIS.TA.taBH
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBHUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TABillNo", SqlDbType.Int, 11, Record.TABillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TravelTypeID", SqlDbType.Int, 11, Record.TravelTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CityOfOrigin", SqlDbType.NVarChar, 31, IIf(Record.CityOfOrigin = "", Convert.DBNull, Record.CityOfOrigin))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DestinationCity", SqlDbType.NVarChar, 31, IIf(Record.DestinationCity = "", Convert.DBNull, Record.DestinationCity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, 7, IIf(Record.ProjectID = "", Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TrainingProgram", SqlDbType.Bit, 3, Record.TrainingProgram)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SameDayVisit", SqlDbType.Bit, 3, Record.SameDayVisit)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Within25KM", SqlDbType.Bit, 3, Record.Within25KM)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteToAnotherSite", SqlDbType.Bit, 3, Record.SiteToAnotherSite)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TaxiHired", SqlDbType.Bit, 3, Record.TaxiHired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OwnVehicleUsed", SqlDbType.Bit, 3, Record.OwnVehicleUsed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PurposeOfJourney", SqlDbType.NVarChar, 501, Record.PurposeOfJourney)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BriefTourReport", SqlDbType.NVarChar, 501, IIf(Record.BriefTourReport = "", Convert.DBNull, Record.BriefTourReport))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedOn", SqlDbType.DateTime, 21, IIf(Record.ReceivedOn = "", Convert.DBNull, Record.ReceivedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalDiskFile", SqlDbType.NVarChar, 251, IIf(Record.ApprovalDiskFile = "", Convert.DBNull, Record.ApprovalDiskFile))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionDiskFile", SqlDbType.NVarChar, 251, IIf(Record.SanctionDiskFile = "", Convert.DBNull, Record.SanctionDiskFile))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OOEByAccounts", SqlDbType.Bit, 3, Record.OOEByAccounts)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalFileName", SqlDbType.NVarChar, 101, IIf(Record.ApprovalFileName = "", Convert.DBNull, Record.ApprovalFileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CCRemarks", SqlDbType.NVarChar, 251, IIf(Record.CCRemarks = "", Convert.DBNull, Record.CCRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ERPBatchNo", SqlDbType.NVarChar, 11, IIf(Record.ERPBatchNo = "", Convert.DBNull, Record.ERPBatchNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedOn", SqlDbType.DateTime, 21, IIf(Record.PostedOn = "", Convert.DBNull, Record.PostedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ERPDocumentNo", SqlDbType.NVarChar, 11, IIf(Record.ERPDocumentNo = "", Convert.DBNull, Record.ERPDocumentNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalAttached", SqlDbType.Bit, 3, Record.ApprovalAttached)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SARemarks", SqlDbType.NVarChar, 251, IIf(Record.SARemarks = "", Convert.DBNull, Record.SARemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EndDateTime", SqlDbType.DateTime, 21, IIf(Record.EndDateTime = "", Convert.DBNull, Record.EndDateTime))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CalculationTypeID", SqlDbType.NVarChar, 11, IIf(Record.CalculationTypeID = "", Convert.DBNull, Record.CalculationTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReportAttached", SqlDbType.Bit, 3, Record.ReportAttached)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillCurrencyID", SqlDbType.NVarChar, 7, IIf(Record.BillCurrencyID = "", Convert.DBNull, Record.BillCurrencyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionFileName", SqlDbType.NVarChar, 101, IIf(Record.SanctionFileName = "", Convert.DBNull, Record.SanctionFileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OOEBySystem", SqlDbType.Bit, 3, Record.OOEBySystem)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CompanyID", SqlDbType.NVarChar, 7, IIf(Record.CompanyID = "", Convert.DBNull, Record.CompanyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConversionFactorINR", SqlDbType.Decimal, 21, Record.ConversionFactorINR)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedOn", SqlDbType.DateTime, 21, IIf(Record.VerifiedOn = "", Convert.DBNull, Record.VerifiedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ForwardedOn", SqlDbType.DateTime, 21, IIf(Record.ForwardedOn = "", Convert.DBNull, Record.ForwardedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReportDiskFile", SqlDbType.NVarChar, 251, IIf(Record.ReportDiskFile = "", Convert.DBNull, Record.ReportDiskFile))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReportFileName", SqlDbType.NVarChar, 101, IIf(Record.ReportFileName = "", Convert.DBNull, Record.ReportFileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedBy", SqlDbType.NVarChar, 9, IIf(Record.VerifiedBy = "", Convert.DBNull, Record.VerifiedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalRemarks", SqlDbType.NVarChar, 501, IIf(Record.ApprovalRemarks = "", Convert.DBNull, Record.ApprovalRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionAttached", SqlDbType.Bit, 3, Record.SanctionAttached)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerificationRemarks", SqlDbType.NVarChar, 251, IIf(Record.VerificationRemarks = "", Convert.DBNull, Record.VerificationRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy", SqlDbType.NVarChar, 9, IIf(Record.ApprovedBy = "", Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionedLodging", SqlDbType.Decimal, 11, Record.SanctionedLodging)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionedDA", SqlDbType.Decimal, 11, Record.SanctionedDA)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedByCC", SqlDbType.NVarChar, 9, IIf(Record.ApprovedByCC = "", Convert.DBNull, Record.ApprovedByCC))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBySA", SqlDbType.NVarChar, 9, IIf(Record.ApprovedBySA = "", Convert.DBNull, Record.ApprovedBySA))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedByCCOn", SqlDbType.DateTime, 21, IIf(Record.ApprovedByCCOn = "", Convert.DBNull, Record.ApprovedByCCOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedOn", SqlDbType.DateTime, 21, IIf(Record.ApprovedOn = "", Convert.DBNull, Record.ApprovedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostCenterID", SqlDbType.NVarChar, 7, IIf(Record.CostCenterID = "", Convert.DBNull, Record.CostCenterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TACategoryID", SqlDbType.Int, 11, IIf(Record.TACategoryID = "", Convert.DBNull, Record.TACategoryID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.NVarChar, 9, Record.EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalClaimedAmount", SqlDbType.Decimal, 21, Record.TotalClaimedAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalPayableAmount", SqlDbType.Decimal, 21, Record.TotalPayableAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalFinancedAmount", SqlDbType.Decimal, 21, Record.TotalFinancedAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalPassedAmount", SqlDbType.Decimal, 21, Record.TotalPassedAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBySAOn", SqlDbType.DateTime, 21, IIf(Record.ApprovedBySAOn = "", Convert.DBNull, Record.ApprovedBySAOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ComponentID", SqlDbType.Int, 11, IIf(Record.ComponentID = "", Convert.DBNull, Record.ComponentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedBy", SqlDbType.NVarChar, 9, IIf(Record.PostedBy = "", Convert.DBNull, Record.PostedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID", SqlDbType.NVarChar, 7, IIf(Record.DivisionID = "", Convert.DBNull, Record.DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NonTechnical", SqlDbType.Bit, 3, Record.NonTechnical)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartDateTime", SqlDbType.DateTime, 21, IIf(Record.StartDateTime = "", Convert.DBNull, Record.StartDateTime))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OOEReasonID", SqlDbType.Int, 11, IIf(Record.OOEReasonID = "", Convert.DBNull, Record.OOEReasonID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Setteled", SqlDbType.Bit, 3, Record.Setteled)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OOERemarks", SqlDbType.NVarChar, 501, IIf(Record.OOERemarks = "", Convert.DBNull, Record.OOERemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalWFTypeID", SqlDbType.Int, 11, IIf(Record.ApprovalWFTypeID = "", Convert.DBNull, Record.ApprovalWFTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillStatusID", SqlDbType.Int, 11, Record.BillStatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentID", SqlDbType.NVarChar, 7, IIf(Record.DepartmentID = "", Convert.DBNull, Record.DepartmentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PrjCalcType", SqlDbType.Int, 11, IIf(Record.PrjCalcType = "", Convert.DBNull, Record.PrjCalcType))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Contractual", SqlDbType.Bit, 3, Record.Contractual)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DesignationID", SqlDbType.Int, 11, IIf(Record.DesignationID = "", Convert.DBNull, Record.DesignationID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OfficeID", SqlDbType.Int, 11, IIf(Record.OfficeID = "", Convert.DBNull, Record.OfficeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteName", SqlDbType.NVarChar, 51, IIf(Record.SiteName = "", Convert.DBNull, Record.SiteName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteTransfer", SqlDbType.Bit, 3, Record.SiteTransfer)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CalculateDriverCharges", SqlDbType.Bit, 3, Record.CalculateDriverCharges)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartureFromIndia", SqlDbType.DateTime, 21, IIf(Record.DepartureFromIndia = "", Convert.DBNull, Record.DepartureFromIndia))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ArrivalToIndia", SqlDbType.DateTime, 21, IIf(Record.ArrivalToIndia = "", Convert.DBNull, Record.ArrivalToIndia))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DestinationName", SqlDbType.NVarChar, 51, IIf(Record.DestinationName = "", Convert.DBNull, Record.DestinationName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TrainingProgramResidential", SqlDbType.Bit, 3, Record.TrainingProgramResidential)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PartialTABill", SqlDbType.Bit, 3, Record.PartialTABill)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VCHOn", SqlDbType.DateTime, 21, IIf(Record.VCHOn = "", Convert.DBNull, Record.VCHOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VCHBy", SqlDbType.NVarChar, 9, IIf(Record.VCHBy = "", Convert.DBNull, Record.VCHBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VCHBatch", SqlDbType.NVarChar, 51, IIf(Record.VCHBatch = "", Convert.DBNull, Record.VCHBatch))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VCHDocument", SqlDbType.NVarChar, 51, IIf(Record.VCHDocument = "", Convert.DBNull, Record.VCHDocument))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VCHLine", SqlDbType.NVarChar, 51, IIf(Record.VCHLine = "", Convert.DBNull, Record.VCHLine))
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
    Public Shared Function taBHDelete(ByVal Record As SIS.TA.taBH) As Int32
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBHDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TABillNo", SqlDbType.Int, Record.TABillNo.ToString.Length, Record.TABillNo)
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
    Public Shared Function SelecttaBHAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBHAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.NVarChar, 8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(500, " "), ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.TA.taBH = New SIS.TA.taBH(Reader)
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
