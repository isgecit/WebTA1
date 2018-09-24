Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taBillLast
    Private Shared _RecordCount As Integer
    Private _TABillNo As Int32 = 0
    Private _EmployeeID As String = ""
    Private _CompanyID As String = ""
    Private _DivisionID As String = ""
    Private _DepartmentID As String = ""
    Private _DesignationID As String = ""
    Private _TACategoryID As String = ""
    Private _Contractual As Boolean = False
    Private _NonTechnical As Boolean = False
    Private _TravelTypeID As Int32 = 0
    Private _PurposeOfJourney As String = ""
    Private _CityOfOrigin As String = ""
    Private _DestinationCity As String = ""
    Private _CostCenterID As String = ""
    Private _BillCurrencyID As String = ""
    Private _ProjectID As String = ""
    Private _TrainingProgram As Boolean = False
    Private _SameDayVisit As Boolean = False
    Private _Within25KM As Boolean = False
    Private _SiteToAnotherSite As Boolean = False
    Private _TaxiHired As Boolean = False
    Private _OwnVehicleUsed As Boolean = False
    Private _BillStatusID As Int32 = 0
    Private _StartDateTime As String = ""
    Private _EndDateTime As String = ""
    Private _SanctionedDA As Decimal = 0
    Private _SanctionedLodging As Decimal = 0
    Private _TotalClaimedAmount As Decimal = 0
    Private _TotalPassedAmount As Decimal = 0
    Private _TotalFinancedAmount As Decimal = 0
    Private _TotalPayableAmount As Decimal = 0
    Private _ConversionFactorINR As Decimal = 0
    Private _OOEBySystem As Boolean = False
    Private _OOEByAccounts As Boolean = False
    Private _OOEReasonID As String = ""
    Private _OOERemarks As String = ""
    Private _ApprovalWFTypeID As String = ""
    Private _ApprovedBy As String = ""
    Private _ApprovedOn As String = ""
    Private _ApprovalRemarks As String = ""
    Private _Setteled As Boolean = False
    Private _BriefTourReport As String = ""
    Private _ApprovedByCC As String = ""
    Private _ApprovedByCCOn As String = ""
    Private _CCRemarks As String = ""
    Private _ApprovedBySA As String = ""
    Private _ApprovedBySAOn As String = ""
    Private _SARemarks As String = ""
    Private _VerifiedBy As String = ""
    Private _VerifiedOn As String = ""
    Private _VerificationRemarks As String = ""
    Private _PostedBy As String = ""
    Private _PostedOn As String = ""
    Private _ERPBatchNo As String = ""
    Private _ERPDocumentNo As String = ""
    Private _ReportAttached As Boolean = False
    Private _SanctionAttached As Boolean = False
    Private _ApprovalAttached As Boolean = False
    Private _ReportFileName As String = ""
    Private _SanctionFileName As String = ""
    Private _ApprovalFileName As String = ""
    Private _ReportDiskFile As String = ""
    Private _SanctionDiskFile As String = ""
    Private _ApprovalDiskFile As String = ""
    Private _ForwardedOn As String = ""
    Private _ReceivedOn As String = ""
    Private _ComponentID As Int32 = 0
    Private _CalculationTypeID As String = ""
    Private _PrjCalcType As String = ""
    Private _HRM_Companies1_Description As String = ""
    Private _HRM_Departments2_Description As String = ""
    Private _HRM_Departments3_Description As String = ""
    Private _HRM_Designations4_Description As String = ""
    Private _HRM_Divisions5_Description As String = ""
    Private _HRM_Employees6_EmployeeName As String = ""
    Private _HRM_Employees7_EmployeeName As String = ""
    Private _HRM_Employees8_EmployeeName As String = ""
    Private _HRM_Employees9_EmployeeName As String = ""
    Private _HRM_Employees10_EmployeeName As String = ""
    Private _HRM_Employees11_EmployeeName As String = ""
    Private _IDM_Projects12_Description As String = ""
    Private _TA_ApprovalWFTypes13_WFTypeDescription As String = ""
    Private _TA_BillStates14_Description As String = ""
    Private _TA_CalcMethod15_CalculationDescription As String = ""
    Private _TA_Categories16_cmba As String = ""
    Private _TA_Cities17_CityName As String = ""
    Private _TA_Cities18_CityName As String = ""
    Private _TA_Components19_Description As String = ""
    Private _TA_Currencies20_CurrencyName As String = ""
    Private _TA_OOEReasons21_Description As String = ""
    Private _TA_PrjCalcMethod22_Description As String = ""
    Private _TA_TravelTypes23_TravelTypeDescription As String = ""
    Private _FK_TA_BillLast_CompanyID As SIS.QCM.qcmCompanies = Nothing
    Private _FK_TA_BillLast_CostCenterID As SIS.TA.taDepartments = Nothing
    Private _FK_TA_BillLast_DepartmentID As SIS.TA.taDepartments = Nothing
    Private _FK_TA_BillLast_DesignationID As SIS.QCM.qcmDesignations = Nothing
    Private _FK_TA_BillLast_DivisionID As SIS.TA.taDivisions = Nothing
    Private _FK_TA_BillLast_EmployeeID As SIS.TA.taEmployees = Nothing
    Private _FK_TA_BillLast_PostedBy As SIS.TA.taEmployees = Nothing
    Private _FK_TA_BillLast_ApprovedBy As SIS.TA.taEmployees = Nothing
    Private _FK_TA_BillLast_ApprovedByCC As SIS.TA.taEmployees = Nothing
    Private _FK_TA_BillLast_ApprovedBySA As SIS.TA.taEmployees = Nothing
    Private _FK_TA_BillLast_VerifiedBy As SIS.TA.taEmployees = Nothing
    Private _FK_TA_BillLast_ProjectID As SIS.QCM.qcmProjects = Nothing
    Private _FK_TA_BillLast_ApprovalWFTypeID As SIS.TA.taApprovalWFTypes = Nothing
    Private _FK_TA_BillLast_BillStatusID As SIS.TA.taBillStates = Nothing
    Private _FK_TA_BillLast_CalculationTypeID As SIS.TA.taCalcMethod = Nothing
    Private _FK_TA_BillLast_TACategoryID As SIS.TA.taCategories = Nothing
    Private _FK_TA_BillLast_DestinationCity As SIS.TA.taCities = Nothing
    Private _FK_TA_BillLast_CityOfOrigin As SIS.TA.taCities = Nothing
    Private _FK_TA_BillLast_ComponentID As SIS.TA.taComponents = Nothing
    Private _FK_TA_BillLast_CurrencyID As SIS.TA.taCurrencies = Nothing
    Private _FK_TA_BillLast_OOEReasonID As SIS.TA.taOOEReasons = Nothing
    Private _FK_TA_BillLast_PrjCalculationType As SIS.TA.taPrjCalcMethod = Nothing
    Private _FK_TA_BillLast_TravelTypeID As SIS.TA.taTravelTypes = Nothing
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
    Public Property EmployeeID() As String
      Get
        Return _EmployeeID
      End Get
      Set(ByVal value As String)
        _EmployeeID = value
      End Set
    End Property
    Public Property CompanyID() As String
      Get
        Return _CompanyID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CompanyID = ""
         Else
           _CompanyID = value
         End If
      End Set
    End Property
    Public Property DivisionID() As String
      Get
        Return _DivisionID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DivisionID = ""
         Else
           _DivisionID = value
         End If
      End Set
    End Property
    Public Property DepartmentID() As String
      Get
        Return _DepartmentID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DepartmentID = ""
         Else
           _DepartmentID = value
         End If
      End Set
    End Property
    Public Property DesignationID() As String
      Get
        Return _DesignationID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DesignationID = ""
         Else
           _DesignationID = value
         End If
      End Set
    End Property
    Public Property TACategoryID() As String
      Get
        Return _TACategoryID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TACategoryID = ""
         Else
           _TACategoryID = value
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
    Public Property NonTechnical() As Boolean
      Get
        Return _NonTechnical
      End Get
      Set(ByVal value As Boolean)
        _NonTechnical = value
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
    Public Property PurposeOfJourney() As String
      Get
        Return _PurposeOfJourney
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PurposeOfJourney = ""
         Else
           _PurposeOfJourney = value
         End If
      End Set
    End Property
    Public Property CityOfOrigin() As String
      Get
        Return _CityOfOrigin
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
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
         If Convert.IsDBNull(Value) Then
           _DestinationCity = ""
         Else
           _DestinationCity = value
         End If
      End Set
    End Property
    Public Property CostCenterID() As String
      Get
        Return _CostCenterID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CostCenterID = ""
         Else
           _CostCenterID = value
         End If
      End Set
    End Property
    Public Property BillCurrencyID() As String
      Get
        Return _BillCurrencyID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _BillCurrencyID = ""
         Else
           _BillCurrencyID = value
         End If
      End Set
    End Property
    Public Property ProjectID() As String
      Get
        Return _ProjectID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ProjectID = ""
         Else
           _ProjectID = value
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
    Public Property BillStatusID() As Int32
      Get
        Return _BillStatusID
      End Get
      Set(ByVal value As Int32)
        _BillStatusID = value
      End Set
    End Property
    Public Property StartDateTime() As String
      Get
        If Not _StartDateTime = String.Empty Then
          Return Convert.ToDateTime(_StartDateTime).ToString("dd/MM/yyyy")
        End If
        Return _StartDateTime
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _StartDateTime = ""
         Else
           _StartDateTime = value
         End If
      End Set
    End Property
    Public Property EndDateTime() As String
      Get
        If Not _EndDateTime = String.Empty Then
          Return Convert.ToDateTime(_EndDateTime).ToString("dd/MM/yyyy")
        End If
        Return _EndDateTime
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _EndDateTime = ""
         Else
           _EndDateTime = value
         End If
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
    Public Property SanctionedLodging() As Decimal
      Get
        Return _SanctionedLodging
      End Get
      Set(ByVal value As Decimal)
        _SanctionedLodging = value
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
    Public Property TotalPassedAmount() As Decimal
      Get
        Return _TotalPassedAmount
      End Get
      Set(ByVal value As Decimal)
        _TotalPassedAmount = value
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
    Public Property TotalPayableAmount() As Decimal
      Get
        Return _TotalPayableAmount
      End Get
      Set(ByVal value As Decimal)
        _TotalPayableAmount = value
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
         If Convert.IsDBNull(Value) Then
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
         If Convert.IsDBNull(Value) Then
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
         If Convert.IsDBNull(Value) Then
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
    Public Property ApprovalRemarks() As String
      Get
        Return _ApprovalRemarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
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
    Public Property BriefTourReport() As String
      Get
        Return _BriefTourReport
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _BriefTourReport = ""
         Else
           _BriefTourReport = value
         End If
      End Set
    End Property
    Public Property ApprovedByCC() As String
      Get
        Return _ApprovedByCC
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ApprovedByCC = ""
         Else
           _ApprovedByCC = value
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
         If Convert.IsDBNull(Value) Then
           _ApprovedByCCOn = ""
         Else
           _ApprovedByCCOn = value
         End If
      End Set
    End Property
    Public Property CCRemarks() As String
      Get
        Return _CCRemarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CCRemarks = ""
         Else
           _CCRemarks = value
         End If
      End Set
    End Property
    Public Property ApprovedBySA() As String
      Get
        Return _ApprovedBySA
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ApprovedBySA = ""
         Else
           _ApprovedBySA = value
         End If
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
         If Convert.IsDBNull(Value) Then
           _ApprovedBySAOn = ""
         Else
           _ApprovedBySAOn = value
         End If
      End Set
    End Property
    Public Property SARemarks() As String
      Get
        Return _SARemarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SARemarks = ""
         Else
           _SARemarks = value
         End If
      End Set
    End Property
    Public Property VerifiedBy() As String
      Get
        Return _VerifiedBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VerifiedBy = ""
         Else
           _VerifiedBy = value
         End If
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
         If Convert.IsDBNull(Value) Then
           _VerifiedOn = ""
         Else
           _VerifiedOn = value
         End If
      End Set
    End Property
    Public Property VerificationRemarks() As String
      Get
        Return _VerificationRemarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VerificationRemarks = ""
         Else
           _VerificationRemarks = value
         End If
      End Set
    End Property
    Public Property PostedBy() As String
      Get
        Return _PostedBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PostedBy = ""
         Else
           _PostedBy = value
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
         If Convert.IsDBNull(Value) Then
           _PostedOn = ""
         Else
           _PostedOn = value
         End If
      End Set
    End Property
    Public Property ERPBatchNo() As String
      Get
        Return _ERPBatchNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ERPBatchNo = ""
         Else
           _ERPBatchNo = value
         End If
      End Set
    End Property
    Public Property ERPDocumentNo() As String
      Get
        Return _ERPDocumentNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ERPDocumentNo = ""
         Else
           _ERPDocumentNo = value
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
    Public Property SanctionAttached() As Boolean
      Get
        Return _SanctionAttached
      End Get
      Set(ByVal value As Boolean)
        _SanctionAttached = value
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
    Public Property ReportFileName() As String
      Get
        Return _ReportFileName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ReportFileName = ""
         Else
           _ReportFileName = value
         End If
      End Set
    End Property
    Public Property SanctionFileName() As String
      Get
        Return _SanctionFileName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SanctionFileName = ""
         Else
           _SanctionFileName = value
         End If
      End Set
    End Property
    Public Property ApprovalFileName() As String
      Get
        Return _ApprovalFileName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ApprovalFileName = ""
         Else
           _ApprovalFileName = value
         End If
      End Set
    End Property
    Public Property ReportDiskFile() As String
      Get
        Return _ReportDiskFile
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ReportDiskFile = ""
         Else
           _ReportDiskFile = value
         End If
      End Set
    End Property
    Public Property SanctionDiskFile() As String
      Get
        Return _SanctionDiskFile
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SanctionDiskFile = ""
         Else
           _SanctionDiskFile = value
         End If
      End Set
    End Property
    Public Property ApprovalDiskFile() As String
      Get
        Return _ApprovalDiskFile
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ApprovalDiskFile = ""
         Else
           _ApprovalDiskFile = value
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
         If Convert.IsDBNull(Value) Then
           _ForwardedOn = ""
         Else
           _ForwardedOn = value
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
         If Convert.IsDBNull(Value) Then
           _ReceivedOn = ""
         Else
           _ReceivedOn = value
         End If
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
    Public Property CalculationTypeID() As String
      Get
        Return _CalculationTypeID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CalculationTypeID = ""
         Else
           _CalculationTypeID = value
         End If
      End Set
    End Property
    Public Property PrjCalcType() As String
      Get
        Return _PrjCalcType
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PrjCalcType = ""
         Else
           _PrjCalcType = value
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
    Public Property HRM_Departments3_Description() As String
      Get
        Return _HRM_Departments3_Description
      End Get
      Set(ByVal value As String)
        _HRM_Departments3_Description = value
      End Set
    End Property
    Public Property HRM_Designations4_Description() As String
      Get
        Return _HRM_Designations4_Description
      End Get
      Set(ByVal value As String)
        _HRM_Designations4_Description = value
      End Set
    End Property
    Public Property HRM_Divisions5_Description() As String
      Get
        Return _HRM_Divisions5_Description
      End Get
      Set(ByVal value As String)
        _HRM_Divisions5_Description = value
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
    Public Property HRM_Employees11_EmployeeName() As String
      Get
        Return _HRM_Employees11_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees11_EmployeeName = value
      End Set
    End Property
    Public Property IDM_Projects12_Description() As String
      Get
        Return _IDM_Projects12_Description
      End Get
      Set(ByVal value As String)
        _IDM_Projects12_Description = value
      End Set
    End Property
    Public Property TA_ApprovalWFTypes13_WFTypeDescription() As String
      Get
        Return _TA_ApprovalWFTypes13_WFTypeDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_ApprovalWFTypes13_WFTypeDescription = ""
         Else
           _TA_ApprovalWFTypes13_WFTypeDescription = value
         End If
      End Set
    End Property
    Public Property TA_BillStates14_Description() As String
      Get
        Return _TA_BillStates14_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_BillStates14_Description = ""
         Else
           _TA_BillStates14_Description = value
         End If
      End Set
    End Property
    Public Property TA_CalcMethod15_CalculationDescription() As String
      Get
        Return _TA_CalcMethod15_CalculationDescription
      End Get
      Set(ByVal value As String)
        _TA_CalcMethod15_CalculationDescription = value
      End Set
    End Property
    Public Property TA_Categories16_cmba() As String
      Get
        Return _TA_Categories16_cmba
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_Categories16_cmba = ""
         Else
           _TA_Categories16_cmba = value
         End If
      End Set
    End Property
    Public Property TA_Cities17_CityName() As String
      Get
        Return _TA_Cities17_CityName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_Cities17_CityName = ""
         Else
           _TA_Cities17_CityName = value
         End If
      End Set
    End Property
    Public Property TA_Cities18_CityName() As String
      Get
        Return _TA_Cities18_CityName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_Cities18_CityName = ""
         Else
           _TA_Cities18_CityName = value
         End If
      End Set
    End Property
    Public Property TA_Components19_Description() As String
      Get
        Return _TA_Components19_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_Components19_Description = ""
         Else
           _TA_Components19_Description = value
         End If
      End Set
    End Property
    Public Property TA_Currencies20_CurrencyName() As String
      Get
        Return _TA_Currencies20_CurrencyName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_Currencies20_CurrencyName = ""
         Else
           _TA_Currencies20_CurrencyName = value
         End If
      End Set
    End Property
    Public Property TA_OOEReasons21_Description() As String
      Get
        Return _TA_OOEReasons21_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_OOEReasons21_Description = ""
         Else
           _TA_OOEReasons21_Description = value
         End If
      End Set
    End Property
    Public Property TA_PrjCalcMethod22_Description() As String
      Get
        Return _TA_PrjCalcMethod22_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_PrjCalcMethod22_Description = ""
         Else
           _TA_PrjCalcMethod22_Description = value
         End If
      End Set
    End Property
    Public Property TA_TravelTypes23_TravelTypeDescription() As String
      Get
        Return _TA_TravelTypes23_TravelTypeDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_TravelTypes23_TravelTypeDescription = ""
         Else
           _TA_TravelTypes23_TravelTypeDescription = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
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
    Public Class PKtaBillLast
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
    Public ReadOnly Property FK_TA_BillLast_CompanyID() As SIS.QCM.qcmCompanies
      Get
        If _FK_TA_BillLast_CompanyID Is Nothing Then
          _FK_TA_BillLast_CompanyID = SIS.QCM.qcmCompanies.qcmCompaniesGetByID(_CompanyID)
        End If
        Return _FK_TA_BillLast_CompanyID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillLast_CostCenterID() As SIS.TA.taDepartments
      Get
        If _FK_TA_BillLast_CostCenterID Is Nothing Then
          _FK_TA_BillLast_CostCenterID = SIS.TA.taDepartments.taDepartmentsGetByID(_CostCenterID)
        End If
        Return _FK_TA_BillLast_CostCenterID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillLast_DepartmentID() As SIS.TA.taDepartments
      Get
        If _FK_TA_BillLast_DepartmentID Is Nothing Then
          _FK_TA_BillLast_DepartmentID = SIS.TA.taDepartments.taDepartmentsGetByID(_DepartmentID)
        End If
        Return _FK_TA_BillLast_DepartmentID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillLast_DesignationID() As SIS.QCM.qcmDesignations
      Get
        If _FK_TA_BillLast_DesignationID Is Nothing Then
          _FK_TA_BillLast_DesignationID = SIS.QCM.qcmDesignations.qcmDesignationsGetByID(_DesignationID)
        End If
        Return _FK_TA_BillLast_DesignationID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillLast_DivisionID() As SIS.TA.taDivisions
      Get
        If _FK_TA_BillLast_DivisionID Is Nothing Then
          _FK_TA_BillLast_DivisionID = SIS.TA.taDivisions.taDivisionsGetByID(_DivisionID)
        End If
        Return _FK_TA_BillLast_DivisionID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillLast_EmployeeID() As SIS.TA.taEmployees
      Get
        If _FK_TA_BillLast_EmployeeID Is Nothing Then
          _FK_TA_BillLast_EmployeeID = SIS.TA.taEmployees.taEmployeesGetByID(_EmployeeID)
        End If
        Return _FK_TA_BillLast_EmployeeID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillLast_PostedBy() As SIS.TA.taEmployees
      Get
        If _FK_TA_BillLast_PostedBy Is Nothing Then
          _FK_TA_BillLast_PostedBy = SIS.TA.taEmployees.taEmployeesGetByID(_PostedBy)
        End If
        Return _FK_TA_BillLast_PostedBy
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillLast_ApprovedBy() As SIS.TA.taEmployees
      Get
        If _FK_TA_BillLast_ApprovedBy Is Nothing Then
          _FK_TA_BillLast_ApprovedBy = SIS.TA.taEmployees.taEmployeesGetByID(_ApprovedBy)
        End If
        Return _FK_TA_BillLast_ApprovedBy
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillLast_ApprovedByCC() As SIS.TA.taEmployees
      Get
        If _FK_TA_BillLast_ApprovedByCC Is Nothing Then
          _FK_TA_BillLast_ApprovedByCC = SIS.TA.taEmployees.taEmployeesGetByID(_ApprovedByCC)
        End If
        Return _FK_TA_BillLast_ApprovedByCC
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillLast_ApprovedBySA() As SIS.TA.taEmployees
      Get
        If _FK_TA_BillLast_ApprovedBySA Is Nothing Then
          _FK_TA_BillLast_ApprovedBySA = SIS.TA.taEmployees.taEmployeesGetByID(_ApprovedBySA)
        End If
        Return _FK_TA_BillLast_ApprovedBySA
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillLast_VerifiedBy() As SIS.TA.taEmployees
      Get
        If _FK_TA_BillLast_VerifiedBy Is Nothing Then
          _FK_TA_BillLast_VerifiedBy = SIS.TA.taEmployees.taEmployeesGetByID(_VerifiedBy)
        End If
        Return _FK_TA_BillLast_VerifiedBy
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillLast_ProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_TA_BillLast_ProjectID Is Nothing Then
          _FK_TA_BillLast_ProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_ProjectID)
        End If
        Return _FK_TA_BillLast_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillLast_ApprovalWFTypeID() As SIS.TA.taApprovalWFTypes
      Get
        If _FK_TA_BillLast_ApprovalWFTypeID Is Nothing Then
          _FK_TA_BillLast_ApprovalWFTypeID = SIS.TA.taApprovalWFTypes.taApprovalWFTypesGetByID(_ApprovalWFTypeID)
        End If
        Return _FK_TA_BillLast_ApprovalWFTypeID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillLast_BillStatusID() As SIS.TA.taBillStates
      Get
        If _FK_TA_BillLast_BillStatusID Is Nothing Then
          _FK_TA_BillLast_BillStatusID = SIS.TA.taBillStates.taBillStatesGetByID(_BillStatusID)
        End If
        Return _FK_TA_BillLast_BillStatusID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillLast_CalculationTypeID() As SIS.TA.taCalcMethod
      Get
        If _FK_TA_BillLast_CalculationTypeID Is Nothing Then
          _FK_TA_BillLast_CalculationTypeID = SIS.TA.taCalcMethod.taCalcMethodGetByID(_CalculationTypeID)
        End If
        Return _FK_TA_BillLast_CalculationTypeID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillLast_TACategoryID() As SIS.TA.taCategories
      Get
        If _FK_TA_BillLast_TACategoryID Is Nothing Then
          _FK_TA_BillLast_TACategoryID = SIS.TA.taCategories.taCategoriesGetByID(_TACategoryID)
        End If
        Return _FK_TA_BillLast_TACategoryID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillLast_DestinationCity() As SIS.TA.taCities
      Get
        If _FK_TA_BillLast_DestinationCity Is Nothing Then
          _FK_TA_BillLast_DestinationCity = SIS.TA.taCities.taCitiesGetByID(_DestinationCity)
        End If
        Return _FK_TA_BillLast_DestinationCity
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillLast_CityOfOrigin() As SIS.TA.taCities
      Get
        If _FK_TA_BillLast_CityOfOrigin Is Nothing Then
          _FK_TA_BillLast_CityOfOrigin = SIS.TA.taCities.taCitiesGetByID(_CityOfOrigin)
        End If
        Return _FK_TA_BillLast_CityOfOrigin
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillLast_ComponentID() As SIS.TA.taComponents
      Get
        If _FK_TA_BillLast_ComponentID Is Nothing Then
          _FK_TA_BillLast_ComponentID = SIS.TA.taComponents.taComponentsGetByID(_ComponentID)
        End If
        Return _FK_TA_BillLast_ComponentID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillLast_CurrencyID() As SIS.TA.taCurrencies
      Get
        If _FK_TA_BillLast_CurrencyID Is Nothing Then
          _FK_TA_BillLast_CurrencyID = SIS.TA.taCurrencies.taCurrenciesGetByID(_BillCurrencyID)
        End If
        Return _FK_TA_BillLast_CurrencyID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillLast_OOEReasonID() As SIS.TA.taOOEReasons
      Get
        If _FK_TA_BillLast_OOEReasonID Is Nothing Then
          _FK_TA_BillLast_OOEReasonID = SIS.TA.taOOEReasons.taOOEReasonsGetByID(_OOEReasonID)
        End If
        Return _FK_TA_BillLast_OOEReasonID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillLast_PrjCalculationType() As SIS.TA.taPrjCalcMethod
      Get
        If _FK_TA_BillLast_PrjCalculationType Is Nothing Then
          _FK_TA_BillLast_PrjCalculationType = SIS.TA.taPrjCalcMethod.taPrjCalcMethodGetByID(_PrjCalcType)
        End If
        Return _FK_TA_BillLast_PrjCalculationType
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillLast_TravelTypeID() As SIS.TA.taTravelTypes
      Get
        If _FK_TA_BillLast_TravelTypeID Is Nothing Then
          _FK_TA_BillLast_TravelTypeID = SIS.TA.taTravelTypes.taTravelTypesGetByID(_TravelTypeID)
        End If
        Return _FK_TA_BillLast_TravelTypeID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBillLastGetNewRecord() As SIS.TA.taBillLast
      Return New SIS.TA.taBillLast()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBillLastGetByID(ByVal TABillNo As Int32) As SIS.TA.taBillLast
      Dim Results As SIS.TA.taBillLast = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBillLastSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TABillNo",SqlDbType.Int,TABillNo.ToString.Length, TABillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TA.taBillLast(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function taBillLastInsert(ByVal Record As SIS.TA.taBillLast) As SIS.TA.taBillLast
      Dim _Rec As SIS.TA.taBillLast = SIS.TA.taBillLast.taBillLastGetNewRecord()
      With _Rec
        .TABillNo = Record.TABillNo
        .EmployeeID = Record.EmployeeID
        .CompanyID = Record.CompanyID
        .DivisionID = Record.DivisionID
        .DepartmentID = Record.DepartmentID
        .DesignationID = Record.DesignationID
        .TACategoryID = Record.TACategoryID
        .Contractual = Record.Contractual
        .NonTechnical = Record.NonTechnical
        .TravelTypeID = Record.TravelTypeID
        .PurposeOfJourney = Record.PurposeOfJourney
        .CityOfOrigin = Record.CityOfOrigin
        .DestinationCity = Record.DestinationCity
        .CostCenterID = Record.CostCenterID
        .BillCurrencyID = Record.BillCurrencyID
        .ProjectID = Record.ProjectID
        .TrainingProgram = Record.TrainingProgram
        .SameDayVisit = Record.SameDayVisit
        .Within25KM = Record.Within25KM
        .SiteToAnotherSite = Record.SiteToAnotherSite
        .TaxiHired = Record.TaxiHired
        .OwnVehicleUsed = Record.OwnVehicleUsed
        .BillStatusID = Record.BillStatusID
        .StartDateTime = Record.StartDateTime
        .EndDateTime = Record.EndDateTime
        .SanctionedDA = Record.SanctionedDA
        .SanctionedLodging = Record.SanctionedLodging
        .TotalClaimedAmount = Record.TotalClaimedAmount
        .TotalPassedAmount = Record.TotalPassedAmount
        .TotalFinancedAmount = Record.TotalFinancedAmount
        .TotalPayableAmount = Record.TotalPayableAmount
        .ConversionFactorINR = Record.ConversionFactorINR
        .OOEBySystem = Record.OOEBySystem
        .OOEByAccounts = Record.OOEByAccounts
        .OOEReasonID = Record.OOEReasonID
        .OOERemarks = Record.OOERemarks
        .ApprovalWFTypeID = Record.ApprovalWFTypeID
        .ApprovedBy = Record.ApprovedBy
        .ApprovedOn = Record.ApprovedOn
        .ApprovalRemarks = Record.ApprovalRemarks
        .Setteled = Record.Setteled
        .BriefTourReport = Record.BriefTourReport
        .ApprovedByCC = Record.ApprovedByCC
        .ApprovedByCCOn = Record.ApprovedByCCOn
        .CCRemarks = Record.CCRemarks
        .ApprovedBySA = Record.ApprovedBySA
        .ApprovedBySAOn = Record.ApprovedBySAOn
        .SARemarks = Record.SARemarks
        .VerifiedBy = Record.VerifiedBy
        .VerifiedOn = Record.VerifiedOn
        .VerificationRemarks = Record.VerificationRemarks
        .PostedBy = Record.PostedBy
        .PostedOn = Record.PostedOn
        .ERPBatchNo = Record.ERPBatchNo
        .ERPDocumentNo = Record.ERPDocumentNo
        .ReportAttached = Record.ReportAttached
        .SanctionAttached = Record.SanctionAttached
        .ApprovalAttached = Record.ApprovalAttached
        .ReportFileName = Record.ReportFileName
        .SanctionFileName = Record.SanctionFileName
        .ApprovalFileName = Record.ApprovalFileName
        .ReportDiskFile = Record.ReportDiskFile
        .SanctionDiskFile = Record.SanctionDiskFile
        .ApprovalDiskFile = Record.ApprovalDiskFile
        .ForwardedOn = Record.ForwardedOn
        .ReceivedOn = Record.ReceivedOn
        .ComponentID = Record.ComponentID
        .CalculationTypeID = Record.CalculationTypeID
        .PrjCalcType = Record.PrjCalcType
      End With
      Return SIS.TA.taBillLast.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.TA.taBillLast) As SIS.TA.taBillLast
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBillLastInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TABillNo",SqlDbType.Int,11, Record.TABillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.NVarChar,9, Record.EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CompanyID",SqlDbType.NVarChar,7, Iif(Record.CompanyID= "" ,Convert.DBNull, Record.CompanyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.NVarChar,7, Iif(Record.DivisionID= "" ,Convert.DBNull, Record.DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentID",SqlDbType.NVarChar,7, Iif(Record.DepartmentID= "" ,Convert.DBNull, Record.DepartmentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DesignationID",SqlDbType.Int,11, Iif(Record.DesignationID= "" ,Convert.DBNull, Record.DesignationID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TACategoryID",SqlDbType.Int,11, Iif(Record.TACategoryID= "" ,Convert.DBNull, Record.TACategoryID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Contractual",SqlDbType.Bit,3, Record.Contractual)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NonTechnical",SqlDbType.Bit,3, Record.NonTechnical)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TravelTypeID",SqlDbType.Int,11, Record.TravelTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PurposeOfJourney",SqlDbType.NVarChar,501, Iif(Record.PurposeOfJourney= "" ,Convert.DBNull, Record.PurposeOfJourney))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CityOfOrigin",SqlDbType.NVarChar,31, Iif(Record.CityOfOrigin= "" ,Convert.DBNull, Record.CityOfOrigin))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DestinationCity",SqlDbType.NVarChar,31, Iif(Record.DestinationCity= "" ,Convert.DBNull, Record.DestinationCity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostCenterID",SqlDbType.NVarChar,7, Iif(Record.CostCenterID= "" ,Convert.DBNull, Record.CostCenterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillCurrencyID",SqlDbType.NVarChar,7, Iif(Record.BillCurrencyID= "" ,Convert.DBNull, Record.BillCurrencyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TrainingProgram",SqlDbType.Bit,3, Record.TrainingProgram)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SameDayVisit",SqlDbType.Bit,3, Record.SameDayVisit)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Within25KM",SqlDbType.Bit,3, Record.Within25KM)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteToAnotherSite",SqlDbType.Bit,3, Record.SiteToAnotherSite)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TaxiHired",SqlDbType.Bit,3, Record.TaxiHired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OwnVehicleUsed",SqlDbType.Bit,3, Record.OwnVehicleUsed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillStatusID",SqlDbType.Int,11, Record.BillStatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartDateTime",SqlDbType.DateTime,21, Iif(Record.StartDateTime= "" ,Convert.DBNull, Record.StartDateTime))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EndDateTime",SqlDbType.DateTime,21, Iif(Record.EndDateTime= "" ,Convert.DBNull, Record.EndDateTime))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionedDA",SqlDbType.Decimal,11, Record.SanctionedDA)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionedLodging",SqlDbType.Decimal,11, Record.SanctionedLodging)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalClaimedAmount",SqlDbType.Decimal,21, Record.TotalClaimedAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalPassedAmount",SqlDbType.Decimal,21, Record.TotalPassedAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalFinancedAmount",SqlDbType.Decimal,21, Record.TotalFinancedAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalPayableAmount",SqlDbType.Decimal,21, Record.TotalPayableAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConversionFactorINR",SqlDbType.Decimal,25, Record.ConversionFactorINR)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OOEBySystem",SqlDbType.Bit,3, Record.OOEBySystem)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OOEByAccounts",SqlDbType.Bit,3, Record.OOEByAccounts)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OOEReasonID",SqlDbType.Int,11, Iif(Record.OOEReasonID= "" ,Convert.DBNull, Record.OOEReasonID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OOERemarks",SqlDbType.NVarChar,501, Iif(Record.OOERemarks= "" ,Convert.DBNull, Record.OOERemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalWFTypeID",SqlDbType.Int,11, Iif(Record.ApprovalWFTypeID= "" ,Convert.DBNull, Record.ApprovalWFTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy",SqlDbType.NVarChar,9, Iif(Record.ApprovedBy= "" ,Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedOn",SqlDbType.DateTime,21, Iif(Record.ApprovedOn= "" ,Convert.DBNull, Record.ApprovedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalRemarks",SqlDbType.NVarChar,501, Iif(Record.ApprovalRemarks= "" ,Convert.DBNull, Record.ApprovalRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Setteled",SqlDbType.Bit,3, Record.Setteled)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BriefTourReport",SqlDbType.NVarChar,501, Iif(Record.BriefTourReport= "" ,Convert.DBNull, Record.BriefTourReport))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedByCC",SqlDbType.NVarChar,9, Iif(Record.ApprovedByCC= "" ,Convert.DBNull, Record.ApprovedByCC))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedByCCOn",SqlDbType.DateTime,21, Iif(Record.ApprovedByCCOn= "" ,Convert.DBNull, Record.ApprovedByCCOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CCRemarks",SqlDbType.NVarChar,251, Iif(Record.CCRemarks= "" ,Convert.DBNull, Record.CCRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBySA",SqlDbType.NVarChar,9, Iif(Record.ApprovedBySA= "" ,Convert.DBNull, Record.ApprovedBySA))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBySAOn",SqlDbType.DateTime,21, Iif(Record.ApprovedBySAOn= "" ,Convert.DBNull, Record.ApprovedBySAOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SARemarks",SqlDbType.NVarChar,251, Iif(Record.SARemarks= "" ,Convert.DBNull, Record.SARemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedBy",SqlDbType.NVarChar,9, Iif(Record.VerifiedBy= "" ,Convert.DBNull, Record.VerifiedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedOn",SqlDbType.DateTime,21, Iif(Record.VerifiedOn= "" ,Convert.DBNull, Record.VerifiedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerificationRemarks",SqlDbType.NVarChar,251, Iif(Record.VerificationRemarks= "" ,Convert.DBNull, Record.VerificationRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedBy",SqlDbType.NVarChar,9, Iif(Record.PostedBy= "" ,Convert.DBNull, Record.PostedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedOn",SqlDbType.DateTime,21, Iif(Record.PostedOn= "" ,Convert.DBNull, Record.PostedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ERPBatchNo",SqlDbType.NVarChar,11, Iif(Record.ERPBatchNo= "" ,Convert.DBNull, Record.ERPBatchNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ERPDocumentNo",SqlDbType.NVarChar,11, Iif(Record.ERPDocumentNo= "" ,Convert.DBNull, Record.ERPDocumentNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReportAttached",SqlDbType.Bit,3, Record.ReportAttached)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionAttached",SqlDbType.Bit,3, Record.SanctionAttached)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalAttached",SqlDbType.Bit,3, Record.ApprovalAttached)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReportFileName",SqlDbType.NVarChar,101, Iif(Record.ReportFileName= "" ,Convert.DBNull, Record.ReportFileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionFileName",SqlDbType.NVarChar,101, Iif(Record.SanctionFileName= "" ,Convert.DBNull, Record.SanctionFileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalFileName",SqlDbType.NVarChar,101, Iif(Record.ApprovalFileName= "" ,Convert.DBNull, Record.ApprovalFileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReportDiskFile",SqlDbType.NVarChar,251, Iif(Record.ReportDiskFile= "" ,Convert.DBNull, Record.ReportDiskFile))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionDiskFile",SqlDbType.NVarChar,251, Iif(Record.SanctionDiskFile= "" ,Convert.DBNull, Record.SanctionDiskFile))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalDiskFile",SqlDbType.NVarChar,251, Iif(Record.ApprovalDiskFile= "" ,Convert.DBNull, Record.ApprovalDiskFile))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ForwardedOn",SqlDbType.DateTime,21, Iif(Record.ForwardedOn= "" ,Convert.DBNull, Record.ForwardedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedOn",SqlDbType.DateTime,21, Iif(Record.ReceivedOn= "" ,Convert.DBNull, Record.ReceivedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ComponentID",SqlDbType.Int,11, Record.ComponentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CalculationTypeID",SqlDbType.NVarChar,11, Iif(Record.CalculationTypeID= "" ,Convert.DBNull, Record.CalculationTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PrjCalcType",SqlDbType.Int,11, Iif(Record.PrjCalcType= "" ,Convert.DBNull, Record.PrjCalcType))
          Cmd.Parameters.Add("@Return_TABillNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_TABillNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.TABillNo = Cmd.Parameters("@Return_TABillNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taBillLastUpdate(ByVal Record As SIS.TA.taBillLast) As SIS.TA.taBillLast
      Dim _Rec As SIS.TA.taBillLast = SIS.TA.taBillLast.taBillLastGetByID(Record.TABillNo)
      With _Rec
        .EmployeeID = Record.EmployeeID
        .CompanyID = Record.CompanyID
        .DivisionID = Record.DivisionID
        .DepartmentID = Record.DepartmentID
        .DesignationID = Record.DesignationID
        .TACategoryID = Record.TACategoryID
        .Contractual = Record.Contractual
        .NonTechnical = Record.NonTechnical
        .TravelTypeID = Record.TravelTypeID
        .PurposeOfJourney = Record.PurposeOfJourney
        .CityOfOrigin = Record.CityOfOrigin
        .DestinationCity = Record.DestinationCity
        .CostCenterID = Record.CostCenterID
        .BillCurrencyID = Record.BillCurrencyID
        .ProjectID = Record.ProjectID
        .TrainingProgram = Record.TrainingProgram
        .SameDayVisit = Record.SameDayVisit
        .Within25KM = Record.Within25KM
        .SiteToAnotherSite = Record.SiteToAnotherSite
        .TaxiHired = Record.TaxiHired
        .OwnVehicleUsed = Record.OwnVehicleUsed
        .BillStatusID = Record.BillStatusID
        .StartDateTime = Record.StartDateTime
        .EndDateTime = Record.EndDateTime
        .SanctionedDA = Record.SanctionedDA
        .SanctionedLodging = Record.SanctionedLodging
        .TotalClaimedAmount = Record.TotalClaimedAmount
        .TotalPassedAmount = Record.TotalPassedAmount
        .TotalFinancedAmount = Record.TotalFinancedAmount
        .TotalPayableAmount = Record.TotalPayableAmount
        .ConversionFactorINR = Record.ConversionFactorINR
        .OOEBySystem = Record.OOEBySystem
        .OOEByAccounts = Record.OOEByAccounts
        .OOEReasonID = Record.OOEReasonID
        .OOERemarks = Record.OOERemarks
        .ApprovalWFTypeID = Record.ApprovalWFTypeID
        .ApprovedBy = Record.ApprovedBy
        .ApprovedOn = Record.ApprovedOn
        .ApprovalRemarks = Record.ApprovalRemarks
        .Setteled = Record.Setteled
        .BriefTourReport = Record.BriefTourReport
        .ApprovedByCC = Record.ApprovedByCC
        .ApprovedByCCOn = Record.ApprovedByCCOn
        .CCRemarks = Record.CCRemarks
        .ApprovedBySA = Record.ApprovedBySA
        .ApprovedBySAOn = Record.ApprovedBySAOn
        .SARemarks = Record.SARemarks
        .VerifiedBy = Record.VerifiedBy
        .VerifiedOn = Record.VerifiedOn
        .VerificationRemarks = Record.VerificationRemarks
        .PostedBy = Record.PostedBy
        .PostedOn = Record.PostedOn
        .ERPBatchNo = Record.ERPBatchNo
        .ERPDocumentNo = Record.ERPDocumentNo
        .ReportAttached = Record.ReportAttached
        .SanctionAttached = Record.SanctionAttached
        .ApprovalAttached = Record.ApprovalAttached
        .ReportFileName = Record.ReportFileName
        .SanctionFileName = Record.SanctionFileName
        .ApprovalFileName = Record.ApprovalFileName
        .ReportDiskFile = Record.ReportDiskFile
        .SanctionDiskFile = Record.SanctionDiskFile
        .ApprovalDiskFile = Record.ApprovalDiskFile
        .ForwardedOn = Record.ForwardedOn
        .ReceivedOn = Record.ReceivedOn
        .ComponentID = Record.ComponentID
        .CalculationTypeID = Record.CalculationTypeID
        .PrjCalcType = Record.PrjCalcType
      End With
      Return SIS.TA.taBillLast.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.TA.taBillLast) As SIS.TA.taBillLast
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBillLastUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TABillNo",SqlDbType.Int,11, Record.TABillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TABillNo",SqlDbType.Int,11, Record.TABillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.NVarChar,9, Record.EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CompanyID",SqlDbType.NVarChar,7, Iif(Record.CompanyID= "" ,Convert.DBNull, Record.CompanyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.NVarChar,7, Iif(Record.DivisionID= "" ,Convert.DBNull, Record.DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentID",SqlDbType.NVarChar,7, Iif(Record.DepartmentID= "" ,Convert.DBNull, Record.DepartmentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DesignationID",SqlDbType.Int,11, Iif(Record.DesignationID= "" ,Convert.DBNull, Record.DesignationID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TACategoryID",SqlDbType.Int,11, Iif(Record.TACategoryID= "" ,Convert.DBNull, Record.TACategoryID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Contractual",SqlDbType.Bit,3, Record.Contractual)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NonTechnical",SqlDbType.Bit,3, Record.NonTechnical)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TravelTypeID",SqlDbType.Int,11, Record.TravelTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PurposeOfJourney",SqlDbType.NVarChar,501, Iif(Record.PurposeOfJourney= "" ,Convert.DBNull, Record.PurposeOfJourney))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CityOfOrigin",SqlDbType.NVarChar,31, Iif(Record.CityOfOrigin= "" ,Convert.DBNull, Record.CityOfOrigin))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DestinationCity",SqlDbType.NVarChar,31, Iif(Record.DestinationCity= "" ,Convert.DBNull, Record.DestinationCity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostCenterID",SqlDbType.NVarChar,7, Iif(Record.CostCenterID= "" ,Convert.DBNull, Record.CostCenterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillCurrencyID",SqlDbType.NVarChar,7, Iif(Record.BillCurrencyID= "" ,Convert.DBNull, Record.BillCurrencyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TrainingProgram",SqlDbType.Bit,3, Record.TrainingProgram)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SameDayVisit",SqlDbType.Bit,3, Record.SameDayVisit)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Within25KM",SqlDbType.Bit,3, Record.Within25KM)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteToAnotherSite",SqlDbType.Bit,3, Record.SiteToAnotherSite)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TaxiHired",SqlDbType.Bit,3, Record.TaxiHired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OwnVehicleUsed",SqlDbType.Bit,3, Record.OwnVehicleUsed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillStatusID",SqlDbType.Int,11, Record.BillStatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartDateTime",SqlDbType.DateTime,21, Iif(Record.StartDateTime= "" ,Convert.DBNull, Record.StartDateTime))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EndDateTime",SqlDbType.DateTime,21, Iif(Record.EndDateTime= "" ,Convert.DBNull, Record.EndDateTime))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionedDA",SqlDbType.Decimal,11, Record.SanctionedDA)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionedLodging",SqlDbType.Decimal,11, Record.SanctionedLodging)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalClaimedAmount",SqlDbType.Decimal,21, Record.TotalClaimedAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalPassedAmount",SqlDbType.Decimal,21, Record.TotalPassedAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalFinancedAmount",SqlDbType.Decimal,21, Record.TotalFinancedAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalPayableAmount",SqlDbType.Decimal,21, Record.TotalPayableAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConversionFactorINR",SqlDbType.Decimal,25, Record.ConversionFactorINR)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OOEBySystem",SqlDbType.Bit,3, Record.OOEBySystem)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OOEByAccounts",SqlDbType.Bit,3, Record.OOEByAccounts)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OOEReasonID",SqlDbType.Int,11, Iif(Record.OOEReasonID= "" ,Convert.DBNull, Record.OOEReasonID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OOERemarks",SqlDbType.NVarChar,501, Iif(Record.OOERemarks= "" ,Convert.DBNull, Record.OOERemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalWFTypeID",SqlDbType.Int,11, Iif(Record.ApprovalWFTypeID= "" ,Convert.DBNull, Record.ApprovalWFTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy",SqlDbType.NVarChar,9, Iif(Record.ApprovedBy= "" ,Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedOn",SqlDbType.DateTime,21, Iif(Record.ApprovedOn= "" ,Convert.DBNull, Record.ApprovedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalRemarks",SqlDbType.NVarChar,501, Iif(Record.ApprovalRemarks= "" ,Convert.DBNull, Record.ApprovalRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Setteled",SqlDbType.Bit,3, Record.Setteled)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BriefTourReport",SqlDbType.NVarChar,501, Iif(Record.BriefTourReport= "" ,Convert.DBNull, Record.BriefTourReport))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedByCC",SqlDbType.NVarChar,9, Iif(Record.ApprovedByCC= "" ,Convert.DBNull, Record.ApprovedByCC))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedByCCOn",SqlDbType.DateTime,21, Iif(Record.ApprovedByCCOn= "" ,Convert.DBNull, Record.ApprovedByCCOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CCRemarks",SqlDbType.NVarChar,251, Iif(Record.CCRemarks= "" ,Convert.DBNull, Record.CCRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBySA",SqlDbType.NVarChar,9, Iif(Record.ApprovedBySA= "" ,Convert.DBNull, Record.ApprovedBySA))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBySAOn",SqlDbType.DateTime,21, Iif(Record.ApprovedBySAOn= "" ,Convert.DBNull, Record.ApprovedBySAOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SARemarks",SqlDbType.NVarChar,251, Iif(Record.SARemarks= "" ,Convert.DBNull, Record.SARemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedBy",SqlDbType.NVarChar,9, Iif(Record.VerifiedBy= "" ,Convert.DBNull, Record.VerifiedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedOn",SqlDbType.DateTime,21, Iif(Record.VerifiedOn= "" ,Convert.DBNull, Record.VerifiedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerificationRemarks",SqlDbType.NVarChar,251, Iif(Record.VerificationRemarks= "" ,Convert.DBNull, Record.VerificationRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedBy",SqlDbType.NVarChar,9, Iif(Record.PostedBy= "" ,Convert.DBNull, Record.PostedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedOn",SqlDbType.DateTime,21, Iif(Record.PostedOn= "" ,Convert.DBNull, Record.PostedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ERPBatchNo",SqlDbType.NVarChar,11, Iif(Record.ERPBatchNo= "" ,Convert.DBNull, Record.ERPBatchNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ERPDocumentNo",SqlDbType.NVarChar,11, Iif(Record.ERPDocumentNo= "" ,Convert.DBNull, Record.ERPDocumentNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReportAttached",SqlDbType.Bit,3, Record.ReportAttached)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionAttached",SqlDbType.Bit,3, Record.SanctionAttached)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalAttached",SqlDbType.Bit,3, Record.ApprovalAttached)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReportFileName",SqlDbType.NVarChar,101, Iif(Record.ReportFileName= "" ,Convert.DBNull, Record.ReportFileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionFileName",SqlDbType.NVarChar,101, Iif(Record.SanctionFileName= "" ,Convert.DBNull, Record.SanctionFileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalFileName",SqlDbType.NVarChar,101, Iif(Record.ApprovalFileName= "" ,Convert.DBNull, Record.ApprovalFileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReportDiskFile",SqlDbType.NVarChar,251, Iif(Record.ReportDiskFile= "" ,Convert.DBNull, Record.ReportDiskFile))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionDiskFile",SqlDbType.NVarChar,251, Iif(Record.SanctionDiskFile= "" ,Convert.DBNull, Record.SanctionDiskFile))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalDiskFile",SqlDbType.NVarChar,251, Iif(Record.ApprovalDiskFile= "" ,Convert.DBNull, Record.ApprovalDiskFile))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ForwardedOn",SqlDbType.DateTime,21, Iif(Record.ForwardedOn= "" ,Convert.DBNull, Record.ForwardedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedOn",SqlDbType.DateTime,21, Iif(Record.ReceivedOn= "" ,Convert.DBNull, Record.ReceivedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ComponentID",SqlDbType.Int,11, Record.ComponentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CalculationTypeID",SqlDbType.NVarChar,11, Iif(Record.CalculationTypeID= "" ,Convert.DBNull, Record.CalculationTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PrjCalcType",SqlDbType.Int,11, Iif(Record.PrjCalcType= "" ,Convert.DBNull, Record.PrjCalcType))
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
    Public Shared Function taBillLastDelete(ByVal Record As SIS.TA.taBillLast) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBillLastDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TABillNo",SqlDbType.Int,Record.TABillNo.ToString.Length, Record.TABillNo)
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
    Public Sub New()
      MyBase.New
    End Sub
  End Class
End Namespace
