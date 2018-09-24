Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TAR
  <DataObject()> _
  Partial Public Class tarTravelRequest
    Private Shared _RecordCount As Integer
    Private _RequestID As Int32 = 0
    Private _AdditionalCurrency As String = "0.00"
    Private _Add1AmountDescription As String = ""
    Private _Add1Amount As String = "0.00"
    Private _Add2AmountDescription As String = ""
    Private _Add2Amount As String = "0.00"
    Private _Add3AmountDescription As String = ""
    Private _Add3Amount As String = "0.00"
    Private _Add4AmountDescription As String = ""
    Private _Add4Amount As String = "0.00"
    Private _Add5AmountDescription As String = ""
    Private _Add5Amount As String = "0.00"
    Private _TravelStartDate As String = ""
    Private _TravelFinishDate As String = ""
    Private _RequestedFor As String = ""
    Private _RequestedForEmployees As String = ""
    Private _TravelTypeID As String = ""
    Private _ProjectID As String = ""
    Private _ProjectManagerID As String = ""
    Private _CostCenterID As String = ""
    Private _TravelItinerary As String = ""
    Private _Purpose As String = ""
    Private _TotalRequestedAmount As String = "0.00"
    Private _RequestedCurrencyID As String = ""
    Private _RequestedConversionFactor As String = "0.00"
    Private _MDLodgingAmount As String = "0.00"
    Private _MDCurrencyID As String = ""
    Private _RequestKey As String = ""
    Private _ApprovedBy As String = ""
    Private _StatusID As String = ""
    Private _ProjectManagerRemarks As String = ""
    Private _MDApprovalOn As String = ""
    Private _MDConversionFactor As String = "0.00"
    Private _MDDAAmount As String = "0.00"
    Private _MDDAAmountINR As String = "0.00"
    Private _TotalRequestedAmountINR As String = "0.00"
    Private _CreatedOn As String = ""
    Private _BudgetCheckedOn As String = ""
    Private _BHApprovalBy As String = ""
    Private _BudgetCheckedBy As String = ""
    Private _CreatedBy As String = ""
    Private _BalanceBudgetWhenSubmitted As String = "0.00"
    Private _MDRemarks As String = ""
    Private _FileAttached As String = ""
    Private _MDApprovalBy As String = ""
    Private _BHRemarks As String = ""
    Private _ApprovedOn As String = ""
    Private _MDLodgingAmountINR As String = "0.00"
    Private _BHApprovalOn As String = ""
    Private _ApproverRemarks As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _aspnet_Users2_UserFullName As String = ""
    Private _aspnet_Users3_UserFullName As String = ""
    Private _aspnet_Users4_UserFullName As String = ""
    Private _aspnet_Users5_UserFullName As String = ""
    Private _aspnet_Users6_UserFullName As String = ""
    Private _aspnet_Users7_UserFullName As String = ""
    Private _HRM_Departments8_Description As String = ""
    Private _IDM_Projects9_Description As String = ""
    Private _TA_Currencies10_CurrencyName As String = ""
    Private _TA_Currencies11_CurrencyName As String = ""
    Private _TA_TravelRequestStatus12_Description As String = ""
    Private _TA_TravelTypes13_TravelTypeDescription As String = ""
    Private _FK_TA_TravelRequest_RequestedFor As SIS.TA.taWebUsers = Nothing
    Private _FK_TA_TravelRequest_CreatedBy As SIS.TA.taWebUsers = Nothing
    Private _FK_TA_TravelRequest_BudgetCheckedBy As SIS.TA.taWebUsers = Nothing
    Private _FK_TA_TravelRequest_ApprovedBy As SIS.TA.taWebUsers = Nothing
    Private _FK_TA_TravelRequest_BHApprovedBy As SIS.TA.taWebUsers = Nothing
    Private _FK_TA_TravelRequest_MDApprovedBy As SIS.TA.taWebUsers = Nothing
    Private _FK_TA_TravelRequest_ProjectManagerID As SIS.TA.taWebUsers = Nothing
    Private _FK_TA_TravelRequest_CostCenterID As SIS.TA.taDepartments = Nothing
    Private _FK_TA_TravelRequest_ProjectID As SIS.QCM.qcmProjects = Nothing
    Private _FK_TA_TravelRequest_RequestedCurrencyID As SIS.TA.taCurrencies = Nothing
    Private _FK_TA_TravelRequest_MDCurrencyID As SIS.TA.taCurrencies = Nothing
    Private _FK_TA_TravelRequest_StatusID As SIS.TAR.tarTravelRequestStatus = Nothing
    Private _FK_TA_TravelRequest_TravelTypeID As SIS.TA.taTravelTypes = Nothing
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
    Public Property RequestID() As Int32
      Get
        Return _RequestID
      End Get
      Set(ByVal value As Int32)
        _RequestID = value
      End Set
    End Property
    Public Property AdditionalCurrency() As String
      Get
        Return _AdditionalCurrency
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AdditionalCurrency = "0.00"
         Else
           _AdditionalCurrency = value
         End If
      End Set
    End Property
    Public Property Add1AmountDescription() As String
      Get
        Return _Add1AmountDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Add1AmountDescription = ""
         Else
           _Add1AmountDescription = value
         End If
      End Set
    End Property
    Public Property Add1Amount() As String
      Get
        Return _Add1Amount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Add1Amount = "0.00"
         Else
           _Add1Amount = value
         End If
      End Set
    End Property
    Public Property Add2AmountDescription() As String
      Get
        Return _Add2AmountDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Add2AmountDescription = ""
         Else
           _Add2AmountDescription = value
         End If
      End Set
    End Property
    Public Property Add2Amount() As String
      Get
        Return _Add2Amount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Add2Amount = "0.00"
         Else
           _Add2Amount = value
         End If
      End Set
    End Property
    Public Property Add3AmountDescription() As String
      Get
        Return _Add3AmountDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Add3AmountDescription = ""
         Else
           _Add3AmountDescription = value
         End If
      End Set
    End Property
    Public Property Add3Amount() As String
      Get
        Return _Add3Amount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Add3Amount = "0.00"
         Else
           _Add3Amount = value
         End If
      End Set
    End Property
    Public Property Add4AmountDescription() As String
      Get
        Return _Add4AmountDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Add4AmountDescription = ""
         Else
           _Add4AmountDescription = value
         End If
      End Set
    End Property
    Public Property Add4Amount() As String
      Get
        Return _Add4Amount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Add4Amount = "0.00"
         Else
           _Add4Amount = value
         End If
      End Set
    End Property
    Public Property Add5AmountDescription() As String
      Get
        Return _Add5AmountDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Add5AmountDescription = ""
         Else
           _Add5AmountDescription = value
         End If
      End Set
    End Property
    Public Property Add5Amount() As String
      Get
        Return _Add5Amount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Add5Amount = "0.00"
         Else
           _Add5Amount = value
         End If
      End Set
    End Property
    Public Property TravelStartDate() As String
      Get
        If Not _TravelStartDate = String.Empty Then
          Return Convert.ToDateTime(_TravelStartDate).ToString("dd/MM/yyyy")
        End If
        Return _TravelStartDate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TravelStartDate = ""
         Else
           _TravelStartDate = value
         End If
      End Set
    End Property
    Public Property TravelFinishDate() As String
      Get
        If Not _TravelFinishDate = String.Empty Then
          Return Convert.ToDateTime(_TravelFinishDate).ToString("dd/MM/yyyy")
        End If
        Return _TravelFinishDate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TravelFinishDate = ""
         Else
           _TravelFinishDate = value
         End If
      End Set
    End Property
    Public Property RequestedFor() As String
      Get
        Return _RequestedFor
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _RequestedFor = ""
         Else
           _RequestedFor = value
         End If
      End Set
    End Property
    Public Property RequestedForEmployees() As String
      Get
        Return _RequestedForEmployees
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _RequestedForEmployees = ""
         Else
           _RequestedForEmployees = value
         End If
      End Set
    End Property
    Public Property TravelTypeID() As String
      Get
        Return _TravelTypeID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TravelTypeID = ""
         Else
           _TravelTypeID = value
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
    Public Property ProjectManagerID() As String
      Get
        Return _ProjectManagerID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ProjectManagerID = ""
         Else
           _ProjectManagerID = value
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
    Public Property TravelItinerary() As String
      Get
        Return _TravelItinerary
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TravelItinerary = ""
         Else
           _TravelItinerary = value
         End If
      End Set
    End Property
    Public Property Purpose() As String
      Get
        Return _Purpose
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Purpose = ""
         Else
           _Purpose = value
         End If
      End Set
    End Property
    Public Property TotalRequestedAmount() As String
      Get
        Return _TotalRequestedAmount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TotalRequestedAmount = "0.00"
         Else
           _TotalRequestedAmount = value
         End If
      End Set
    End Property
    Public Property RequestedCurrencyID() As String
      Get
        Return _RequestedCurrencyID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _RequestedCurrencyID = ""
         Else
           _RequestedCurrencyID = value
         End If
      End Set
    End Property
    Public Property RequestedConversionFactor() As String
      Get
        Return _RequestedConversionFactor
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _RequestedConversionFactor = "0.00"
         Else
           _RequestedConversionFactor = value
         End If
      End Set
    End Property
    Public Property MDLodgingAmount() As String
      Get
        Return _MDLodgingAmount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _MDLodgingAmount = "0.00"
         Else
           _MDLodgingAmount = value
         End If
      End Set
    End Property
    Public Property MDCurrencyID() As String
      Get
        Return _MDCurrencyID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _MDCurrencyID = ""
         Else
           _MDCurrencyID = value
         End If
      End Set
    End Property
    Public Property RequestKey() As String
      Get
        Return _RequestKey
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _RequestKey = ""
         Else
           _RequestKey = value
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
    Public Property StatusID() As String
      Get
        Return _StatusID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _StatusID = ""
         Else
           _StatusID = value
         End If
      End Set
    End Property
    Public Property ProjectManagerRemarks() As String
      Get
        Return _ProjectManagerRemarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ProjectManagerRemarks = ""
         Else
           _ProjectManagerRemarks = value
         End If
      End Set
    End Property
    Public Property MDApprovalOn() As String
      Get
        If Not _MDApprovalOn = String.Empty Then
          Return Convert.ToDateTime(_MDApprovalOn).ToString("dd/MM/yyyy")
        End If
        Return _MDApprovalOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _MDApprovalOn = ""
         Else
           _MDApprovalOn = value
         End If
      End Set
    End Property
    Public Property MDConversionFactor() As String
      Get
        Return _MDConversionFactor
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _MDConversionFactor = "0.00"
         Else
           _MDConversionFactor = value
         End If
      End Set
    End Property
    Public Property MDDAAmount() As String
      Get
        Return _MDDAAmount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _MDDAAmount = "0.00"
         Else
           _MDDAAmount = value
         End If
      End Set
    End Property
    Public Property MDDAAmountINR() As String
      Get
        Return _MDDAAmountINR
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _MDDAAmountINR = "0.00"
         Else
           _MDDAAmountINR = value
         End If
      End Set
    End Property
    Public Property TotalRequestedAmountINR() As String
      Get
        Return _TotalRequestedAmountINR
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TotalRequestedAmountINR = "0.00"
         Else
           _TotalRequestedAmountINR = value
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
    Public Property BudgetCheckedOn() As String
      Get
        If Not _BudgetCheckedOn = String.Empty Then
          Return Convert.ToDateTime(_BudgetCheckedOn).ToString("dd/MM/yyyy")
        End If
        Return _BudgetCheckedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _BudgetCheckedOn = ""
         Else
           _BudgetCheckedOn = value
         End If
      End Set
    End Property
    Public Property BHApprovalBy() As String
      Get
        Return _BHApprovalBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _BHApprovalBy = ""
         Else
           _BHApprovalBy = value
         End If
      End Set
    End Property
    Public Property BudgetCheckedBy() As String
      Get
        Return _BudgetCheckedBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _BudgetCheckedBy = ""
         Else
           _BudgetCheckedBy = value
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
    Public Property BalanceBudgetWhenSubmitted() As String
      Get
        Return _BalanceBudgetWhenSubmitted
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _BalanceBudgetWhenSubmitted = "0.00"
         Else
           _BalanceBudgetWhenSubmitted = value
         End If
      End Set
    End Property
    Public Property MDRemarks() As String
      Get
        Return _MDRemarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _MDRemarks = ""
         Else
           _MDRemarks = value
         End If
      End Set
    End Property
    Public Property FileAttached() As String
      Get
        Return _FileAttached
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _FileAttached = ""
         Else
           _FileAttached = value
         End If
      End Set
    End Property
    Public Property MDApprovalBy() As String
      Get
        Return _MDApprovalBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _MDApprovalBy = ""
         Else
           _MDApprovalBy = value
         End If
      End Set
    End Property
    Public Property BHRemarks() As String
      Get
        Return _BHRemarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _BHRemarks = ""
         Else
           _BHRemarks = value
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
    Public Property MDLodgingAmountINR() As String
      Get
        Return _MDLodgingAmountINR
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _MDLodgingAmountINR = "0.00"
         Else
           _MDLodgingAmountINR = value
         End If
      End Set
    End Property
    Public Property BHApprovalOn() As String
      Get
        If Not _BHApprovalOn = String.Empty Then
          Return Convert.ToDateTime(_BHApprovalOn).ToString("dd/MM/yyyy")
        End If
        Return _BHApprovalOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _BHApprovalOn = ""
         Else
           _BHApprovalOn = value
         End If
      End Set
    End Property
    Public Property ApproverRemarks() As String
      Get
        Return _ApproverRemarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ApproverRemarks = ""
         Else
           _ApproverRemarks = value
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
    Public Property aspnet_Users2_UserFullName() As String
      Get
        Return _aspnet_Users2_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users2_UserFullName = value
      End Set
    End Property
    Public Property aspnet_Users3_UserFullName() As String
      Get
        Return _aspnet_Users3_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users3_UserFullName = value
      End Set
    End Property
    Public Property aspnet_Users4_UserFullName() As String
      Get
        Return _aspnet_Users4_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users4_UserFullName = value
      End Set
    End Property
    Public Property aspnet_Users5_UserFullName() As String
      Get
        Return _aspnet_Users5_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users5_UserFullName = value
      End Set
    End Property
    Public Property aspnet_Users6_UserFullName() As String
      Get
        Return _aspnet_Users6_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users6_UserFullName = value
      End Set
    End Property
    Public Property aspnet_Users7_UserFullName() As String
      Get
        Return _aspnet_Users7_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users7_UserFullName = value
      End Set
    End Property
    Public Property HRM_Departments8_Description() As String
      Get
        Return _HRM_Departments8_Description
      End Get
      Set(ByVal value As String)
        _HRM_Departments8_Description = value
      End Set
    End Property
    Public Property IDM_Projects9_Description() As String
      Get
        Return _IDM_Projects9_Description
      End Get
      Set(ByVal value As String)
        _IDM_Projects9_Description = value
      End Set
    End Property
    Public Property TA_Currencies10_CurrencyName() As String
      Get
        Return _TA_Currencies10_CurrencyName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_Currencies10_CurrencyName = ""
         Else
           _TA_Currencies10_CurrencyName = value
         End If
      End Set
    End Property
    Public Property TA_Currencies11_CurrencyName() As String
      Get
        Return _TA_Currencies11_CurrencyName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_Currencies11_CurrencyName = ""
         Else
           _TA_Currencies11_CurrencyName = value
         End If
      End Set
    End Property
    Public Property TA_TravelRequestStatus12_Description() As String
      Get
        Return _TA_TravelRequestStatus12_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_TravelRequestStatus12_Description = ""
         Else
           _TA_TravelRequestStatus12_Description = value
         End If
      End Set
    End Property
    Public Property TA_TravelTypes13_TravelTypeDescription() As String
      Get
        Return _TA_TravelTypes13_TravelTypeDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_TravelTypes13_TravelTypeDescription = ""
         Else
           _TA_TravelTypes13_TravelTypeDescription = value
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
        Return _RequestID
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
    Public Class PKtarTravelRequest
      Private _RequestID As Int32 = 0
      Public Property RequestID() As Int32
        Get
          Return _RequestID
        End Get
        Set(ByVal value As Int32)
          _RequestID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_TA_TravelRequest_RequestedFor() As SIS.TA.taWebUsers
      Get
        If _FK_TA_TravelRequest_RequestedFor Is Nothing Then
          _FK_TA_TravelRequest_RequestedFor = SIS.TA.taWebUsers.taWebUsersGetByID(_RequestedFor)
        End If
        Return _FK_TA_TravelRequest_RequestedFor
      End Get
    End Property
    Public ReadOnly Property FK_TA_TravelRequest_CreatedBy() As SIS.TA.taWebUsers
      Get
        If _FK_TA_TravelRequest_CreatedBy Is Nothing Then
          _FK_TA_TravelRequest_CreatedBy = SIS.TA.taWebUsers.taWebUsersGetByID(_CreatedBy)
        End If
        Return _FK_TA_TravelRequest_CreatedBy
      End Get
    End Property
    Public ReadOnly Property FK_TA_TravelRequest_BudgetCheckedBy() As SIS.TA.taWebUsers
      Get
        If _FK_TA_TravelRequest_BudgetCheckedBy Is Nothing Then
          _FK_TA_TravelRequest_BudgetCheckedBy = SIS.TA.taWebUsers.taWebUsersGetByID(_BudgetCheckedBy)
        End If
        Return _FK_TA_TravelRequest_BudgetCheckedBy
      End Get
    End Property
    Public ReadOnly Property FK_TA_TravelRequest_ApprovedBy() As SIS.TA.taWebUsers
      Get
        If _FK_TA_TravelRequest_ApprovedBy Is Nothing Then
          _FK_TA_TravelRequest_ApprovedBy = SIS.TA.taWebUsers.taWebUsersGetByID(_ApprovedBy)
        End If
        Return _FK_TA_TravelRequest_ApprovedBy
      End Get
    End Property
    Public ReadOnly Property FK_TA_TravelRequest_BHApprovedBy() As SIS.TA.taWebUsers
      Get
        If _FK_TA_TravelRequest_BHApprovedBy Is Nothing Then
          _FK_TA_TravelRequest_BHApprovedBy = SIS.TA.taWebUsers.taWebUsersGetByID(_BHApprovalBy)
        End If
        Return _FK_TA_TravelRequest_BHApprovedBy
      End Get
    End Property
    Public ReadOnly Property FK_TA_TravelRequest_MDApprovedBy() As SIS.TA.taWebUsers
      Get
        If _FK_TA_TravelRequest_MDApprovedBy Is Nothing Then
          _FK_TA_TravelRequest_MDApprovedBy = SIS.TA.taWebUsers.taWebUsersGetByID(_MDApprovalBy)
        End If
        Return _FK_TA_TravelRequest_MDApprovedBy
      End Get
    End Property
    Public ReadOnly Property FK_TA_TravelRequest_ProjectManagerID() As SIS.TA.taWebUsers
      Get
        If _FK_TA_TravelRequest_ProjectManagerID Is Nothing Then
          _FK_TA_TravelRequest_ProjectManagerID = SIS.TA.taWebUsers.taWebUsersGetByID(_ProjectManagerID)
        End If
        Return _FK_TA_TravelRequest_ProjectManagerID
      End Get
    End Property
    Public ReadOnly Property FK_TA_TravelRequest_CostCenterID() As SIS.TA.taDepartments
      Get
        If _FK_TA_TravelRequest_CostCenterID Is Nothing Then
          _FK_TA_TravelRequest_CostCenterID = SIS.TA.taDepartments.taDepartmentsGetByID(_CostCenterID)
        End If
        Return _FK_TA_TravelRequest_CostCenterID
      End Get
    End Property
    Public ReadOnly Property FK_TA_TravelRequest_ProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_TA_TravelRequest_ProjectID Is Nothing Then
          _FK_TA_TravelRequest_ProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_ProjectID)
        End If
        Return _FK_TA_TravelRequest_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_TA_TravelRequest_RequestedCurrencyID() As SIS.TA.taCurrencies
      Get
        If _FK_TA_TravelRequest_RequestedCurrencyID Is Nothing Then
          _FK_TA_TravelRequest_RequestedCurrencyID = SIS.TA.taCurrencies.taCurrenciesGetByID(_RequestedCurrencyID)
        End If
        Return _FK_TA_TravelRequest_RequestedCurrencyID
      End Get
    End Property
    Public ReadOnly Property FK_TA_TravelRequest_MDCurrencyID() As SIS.TA.taCurrencies
      Get
        If _FK_TA_TravelRequest_MDCurrencyID Is Nothing Then
          _FK_TA_TravelRequest_MDCurrencyID = SIS.TA.taCurrencies.taCurrenciesGetByID(_MDCurrencyID)
        End If
        Return _FK_TA_TravelRequest_MDCurrencyID
      End Get
    End Property
    Public ReadOnly Property FK_TA_TravelRequest_StatusID() As SIS.TAR.tarTravelRequestStatus
      Get
        If _FK_TA_TravelRequest_StatusID Is Nothing Then
          _FK_TA_TravelRequest_StatusID = SIS.TAR.tarTravelRequestStatus.tarTravelRequestStatusGetByID(_StatusID)
        End If
        Return _FK_TA_TravelRequest_StatusID
      End Get
    End Property
    Public ReadOnly Property FK_TA_TravelRequest_TravelTypeID() As SIS.TA.taTravelTypes
      Get
        If _FK_TA_TravelRequest_TravelTypeID Is Nothing Then
          _FK_TA_TravelRequest_TravelTypeID = SIS.TA.taTravelTypes.taTravelTypesGetByID(_TravelTypeID)
        End If
        Return _FK_TA_TravelRequest_TravelTypeID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tarTravelRequestGetNewRecord() As SIS.TAR.tarTravelRequest
      Return New SIS.TAR.tarTravelRequest()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tarTravelRequestGetByID(ByVal RequestID As Int32) As SIS.TAR.tarTravelRequest
      Dim Results As SIS.TAR.tarTravelRequest = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptarTravelRequestSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestID",SqlDbType.Int,RequestID.ToString.Length, RequestID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TAR.tarTravelRequest(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function tarTravelRequestSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.TAR.tarTravelRequest)
      Dim Results As List(Of SIS.TAR.tarTravelRequest) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "RequestID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptarTravelRequestSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptarTravelRequestSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TAR.tarTravelRequest)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TAR.tarTravelRequest(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function tarTravelRequestSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function tarTravelRequestInsert(ByVal Record As SIS.TAR.tarTravelRequest) As SIS.TAR.tarTravelRequest
      Dim _Rec As SIS.TAR.tarTravelRequest = SIS.TAR.tarTravelRequest.tarTravelRequestGetNewRecord()
      With _Rec
        .AdditionalCurrency = Record.AdditionalCurrency
        .Add1AmountDescription = Record.Add1AmountDescription
        .Add1Amount = Record.Add1Amount
        .Add2AmountDescription = Record.Add2AmountDescription
        .Add2Amount = Record.Add2Amount
        .Add3AmountDescription = Record.Add3AmountDescription
        .Add3Amount = Record.Add3Amount
        .Add4AmountDescription = Record.Add4AmountDescription
        .Add4Amount = Record.Add4Amount
        .Add5AmountDescription = Record.Add5AmountDescription
        .Add5Amount = Record.Add5Amount
        .TravelStartDate = Record.TravelStartDate
        .TravelFinishDate = Record.TravelFinishDate
        .RequestedFor = Record.RequestedFor
        .RequestedForEmployees = Record.RequestedForEmployees
        .TravelTypeID = Record.TravelTypeID
        .ProjectID = Record.ProjectID
        .ProjectManagerID = Record.ProjectManagerID
        .CostCenterID = Record.CostCenterID
        .TravelItinerary = Record.TravelItinerary
        .Purpose = Record.Purpose
        .TotalRequestedAmount = Record.TotalRequestedAmount
        .RequestedCurrencyID = Record.RequestedCurrencyID
        .RequestedConversionFactor = Record.RequestedConversionFactor
        .MDLodgingAmount = Record.MDLodgingAmount
        .MDCurrencyID = Record.MDCurrencyID
        .RequestKey = Record.RequestKey
        .ApprovedBy = Record.ApprovedBy
        .StatusID = TARequestStates.Free
        .ProjectManagerRemarks = Record.ProjectManagerRemarks
        .MDApprovalOn = Record.MDApprovalOn
        .MDConversionFactor = Record.MDConversionFactor
        .MDDAAmount = Record.MDDAAmount
        .MDDAAmountINR = Record.MDDAAmountINR
        .TotalRequestedAmountINR = Record.TotalRequestedAmountINR
        .CreatedOn = Now
        .BudgetCheckedOn = Record.BudgetCheckedOn
        .BHApprovalBy = Record.BHApprovalBy
        .BudgetCheckedBy = Record.BudgetCheckedBy
        .CreatedBy =  Global.System.Web.HttpContext.Current.Session("LoginID")
        .BalanceBudgetWhenSubmitted = Record.BalanceBudgetWhenSubmitted
        .MDRemarks = Record.MDRemarks
        .FileAttached = Record.FileAttached
        .MDApprovalBy = Record.MDApprovalBy
        .BHRemarks = Record.BHRemarks
        .ApprovedOn = Record.ApprovedOn
        .MDLodgingAmountINR = Record.MDLodgingAmountINR
        .BHApprovalOn = Record.BHApprovalOn
        .ApproverRemarks = Record.ApproverRemarks
      End With
      Return SIS.TAR.tarTravelRequest.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.TAR.tarTravelRequest) As SIS.TAR.tarTravelRequest
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptarTravelRequestInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdditionalCurrency",SqlDbType.Decimal,21, Iif(Record.AdditionalCurrency= "" ,Convert.DBNull, Record.AdditionalCurrency))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Add1AmountDescription",SqlDbType.NVarChar,151, Iif(Record.Add1AmountDescription= "" ,Convert.DBNull, Record.Add1AmountDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Add1Amount",SqlDbType.Decimal,21, Iif(Record.Add1Amount= "" ,Convert.DBNull, Record.Add1Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Add2AmountDescription",SqlDbType.NVarChar,151, Iif(Record.Add2AmountDescription= "" ,Convert.DBNull, Record.Add2AmountDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Add2Amount",SqlDbType.Decimal,21, Iif(Record.Add2Amount= "" ,Convert.DBNull, Record.Add2Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Add3AmountDescription",SqlDbType.NVarChar,151, Iif(Record.Add3AmountDescription= "" ,Convert.DBNull, Record.Add3AmountDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Add3Amount",SqlDbType.Decimal,21, Iif(Record.Add3Amount= "" ,Convert.DBNull, Record.Add3Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Add4AmountDescription",SqlDbType.NVarChar,151, Iif(Record.Add4AmountDescription= "" ,Convert.DBNull, Record.Add4AmountDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Add4Amount",SqlDbType.Decimal,21, Iif(Record.Add4Amount= "" ,Convert.DBNull, Record.Add4Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Add5AmountDescription",SqlDbType.NVarChar,151, Iif(Record.Add5AmountDescription= "" ,Convert.DBNull, Record.Add5AmountDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Add5Amount",SqlDbType.Decimal,21, Iif(Record.Add5Amount= "" ,Convert.DBNull, Record.Add5Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TravelStartDate",SqlDbType.DateTime,21, Iif(Record.TravelStartDate= "" ,Convert.DBNull, Record.TravelStartDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TravelFinishDate",SqlDbType.DateTime,21, Iif(Record.TravelFinishDate= "" ,Convert.DBNull, Record.TravelFinishDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestedFor",SqlDbType.NVarChar,9, Iif(Record.RequestedFor= "" ,Convert.DBNull, Record.RequestedFor))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestedForEmployees",SqlDbType.NVarChar,251, Iif(Record.RequestedForEmployees= "" ,Convert.DBNull, Record.RequestedForEmployees))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TravelTypeID",SqlDbType.Int,11, Iif(Record.TravelTypeID= "" ,Convert.DBNull, Record.TravelTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectManagerID",SqlDbType.NVarChar,9, Iif(Record.ProjectManagerID= "" ,Convert.DBNull, Record.ProjectManagerID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostCenterID",SqlDbType.NVarChar,7, Iif(Record.CostCenterID= "" ,Convert.DBNull, Record.CostCenterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TravelItinerary",SqlDbType.NVarChar,501, Iif(Record.TravelItinerary= "" ,Convert.DBNull, Record.TravelItinerary))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Purpose",SqlDbType.NVarChar,501, Iif(Record.Purpose= "" ,Convert.DBNull, Record.Purpose))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalRequestedAmount",SqlDbType.Decimal,21, Iif(Record.TotalRequestedAmount= "" ,Convert.DBNull, Record.TotalRequestedAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestedCurrencyID",SqlDbType.NVarChar,7, Iif(Record.RequestedCurrencyID= "" ,Convert.DBNull, Record.RequestedCurrencyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestedConversionFactor",SqlDbType.Decimal,25, Iif(Record.RequestedConversionFactor= "" ,Convert.DBNull, Record.RequestedConversionFactor))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MDLodgingAmount",SqlDbType.Decimal,21, Iif(Record.MDLodgingAmount= "" ,Convert.DBNull, Record.MDLodgingAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MDCurrencyID",SqlDbType.NVarChar,7, Iif(Record.MDCurrencyID= "" ,Convert.DBNull, Record.MDCurrencyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestKey",SqlDbType.NVarChar,9, Iif(Record.RequestKey= "" ,Convert.DBNull, Record.RequestKey))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy",SqlDbType.NVarChar,9, Iif(Record.ApprovedBy= "" ,Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectManagerRemarks",SqlDbType.NVarChar,251, Iif(Record.ProjectManagerRemarks= "" ,Convert.DBNull, Record.ProjectManagerRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MDApprovalOn",SqlDbType.DateTime,21, Iif(Record.MDApprovalOn= "" ,Convert.DBNull, Record.MDApprovalOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MDConversionFactor",SqlDbType.Decimal,25, Iif(Record.MDConversionFactor= "" ,Convert.DBNull, Record.MDConversionFactor))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MDDAAmount",SqlDbType.Decimal,21, Iif(Record.MDDAAmount= "" ,Convert.DBNull, Record.MDDAAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MDDAAmountINR",SqlDbType.Decimal,21, Iif(Record.MDDAAmountINR= "" ,Convert.DBNull, Record.MDDAAmountINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalRequestedAmountINR",SqlDbType.Decimal,21, Iif(Record.TotalRequestedAmountINR= "" ,Convert.DBNull, Record.TotalRequestedAmountINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BudgetCheckedOn",SqlDbType.DateTime,21, Iif(Record.BudgetCheckedOn= "" ,Convert.DBNull, Record.BudgetCheckedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BHApprovalBy",SqlDbType.NVarChar,9, Iif(Record.BHApprovalBy= "" ,Convert.DBNull, Record.BHApprovalBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BudgetCheckedBy",SqlDbType.NVarChar,9, Iif(Record.BudgetCheckedBy= "" ,Convert.DBNull, Record.BudgetCheckedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BalanceBudgetWhenSubmitted",SqlDbType.Decimal,21, Iif(Record.BalanceBudgetWhenSubmitted= "" ,Convert.DBNull, Record.BalanceBudgetWhenSubmitted))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MDRemarks",SqlDbType.NVarChar,251, Iif(Record.MDRemarks= "" ,Convert.DBNull, Record.MDRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileAttached",SqlDbType.Bit,3, Iif(Record.FileAttached= "" ,Convert.DBNull, Record.FileAttached))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MDApprovalBy",SqlDbType.NVarChar,9, Iif(Record.MDApprovalBy= "" ,Convert.DBNull, Record.MDApprovalBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BHRemarks",SqlDbType.NVarChar,251, Iif(Record.BHRemarks= "" ,Convert.DBNull, Record.BHRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedOn",SqlDbType.DateTime,21, Iif(Record.ApprovedOn= "" ,Convert.DBNull, Record.ApprovedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MDLodgingAmountINR",SqlDbType.Decimal,21, Iif(Record.MDLodgingAmountINR= "" ,Convert.DBNull, Record.MDLodgingAmountINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BHApprovalOn",SqlDbType.DateTime,21, Iif(Record.BHApprovalOn= "" ,Convert.DBNull, Record.BHApprovalOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApproverRemarks",SqlDbType.NVarChar,251, Iif(Record.ApproverRemarks= "" ,Convert.DBNull, Record.ApproverRemarks))
          Cmd.Parameters.Add("@Return_RequestID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_RequestID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.RequestID = Cmd.Parameters("@Return_RequestID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function tarTravelRequestUpdate(ByVal Record As SIS.TAR.tarTravelRequest) As SIS.TAR.tarTravelRequest
      Dim _Rec As SIS.TAR.tarTravelRequest = SIS.TAR.tarTravelRequest.tarTravelRequestGetByID(Record.RequestID)
      With _Rec
        .AdditionalCurrency = Record.AdditionalCurrency
        .Add1AmountDescription = Record.Add1AmountDescription
        .Add1Amount = Record.Add1Amount
        .Add2AmountDescription = Record.Add2AmountDescription
        .Add2Amount = Record.Add2Amount
        .Add3AmountDescription = Record.Add3AmountDescription
        .Add3Amount = Record.Add3Amount
        .Add4AmountDescription = Record.Add4AmountDescription
        .Add4Amount = Record.Add4Amount
        .Add5AmountDescription = Record.Add5AmountDescription
        .Add5Amount = Record.Add5Amount
        .TravelStartDate = Record.TravelStartDate
        .TravelFinishDate = Record.TravelFinishDate
        .RequestedFor = Record.RequestedFor
        .RequestedForEmployees = Record.RequestedForEmployees
        .TravelTypeID = Record.TravelTypeID
        .ProjectID = Record.ProjectID
        .ProjectManagerID = Record.ProjectManagerID
        .CostCenterID = Record.CostCenterID
        .TravelItinerary = Record.TravelItinerary
        .Purpose = Record.Purpose
        .TotalRequestedAmount = Record.TotalRequestedAmount
        .RequestedCurrencyID = Record.RequestedCurrencyID
        .RequestedConversionFactor = Record.RequestedConversionFactor
        .MDLodgingAmount = Record.MDLodgingAmount
        .MDCurrencyID = Record.MDCurrencyID
        .RequestKey = Record.RequestKey
        .ApprovedBy = Record.ApprovedBy
        .StatusID = Record.StatusID
        .ProjectManagerRemarks = Record.ProjectManagerRemarks
        .MDApprovalOn = Record.MDApprovalOn
        .MDConversionFactor = Record.MDConversionFactor
        .MDDAAmount = Record.MDDAAmount
        .MDDAAmountINR = Record.MDDAAmountINR
        .TotalRequestedAmountINR = Record.TotalRequestedAmountINR
        .CreatedOn = Now
        .BudgetCheckedOn = Record.BudgetCheckedOn
        .BHApprovalBy = Record.BHApprovalBy
        .BudgetCheckedBy = Record.BudgetCheckedBy
        .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .BalanceBudgetWhenSubmitted = Record.BalanceBudgetWhenSubmitted
        .MDRemarks = Record.MDRemarks
        .FileAttached = Record.FileAttached
        .MDApprovalBy = Record.MDApprovalBy
        .BHRemarks = Record.BHRemarks
        .ApprovedOn = Record.ApprovedOn
        .MDLodgingAmountINR = Record.MDLodgingAmountINR
        .BHApprovalOn = Record.BHApprovalOn
        .ApproverRemarks = Record.ApproverRemarks
      End With
      Return SIS.TAR.tarTravelRequest.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.TAR.tarTravelRequest) As SIS.TAR.tarTravelRequest
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptarTravelRequestUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RequestID",SqlDbType.Int,11, Record.RequestID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdditionalCurrency",SqlDbType.Decimal,21, Iif(Record.AdditionalCurrency= "" ,Convert.DBNull, Record.AdditionalCurrency))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Add1AmountDescription",SqlDbType.NVarChar,151, Iif(Record.Add1AmountDescription= "" ,Convert.DBNull, Record.Add1AmountDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Add1Amount",SqlDbType.Decimal,21, Iif(Record.Add1Amount= "" ,Convert.DBNull, Record.Add1Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Add2AmountDescription",SqlDbType.NVarChar,151, Iif(Record.Add2AmountDescription= "" ,Convert.DBNull, Record.Add2AmountDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Add2Amount",SqlDbType.Decimal,21, Iif(Record.Add2Amount= "" ,Convert.DBNull, Record.Add2Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Add3AmountDescription",SqlDbType.NVarChar,151, Iif(Record.Add3AmountDescription= "" ,Convert.DBNull, Record.Add3AmountDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Add3Amount",SqlDbType.Decimal,21, Iif(Record.Add3Amount= "" ,Convert.DBNull, Record.Add3Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Add4AmountDescription",SqlDbType.NVarChar,151, Iif(Record.Add4AmountDescription= "" ,Convert.DBNull, Record.Add4AmountDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Add4Amount",SqlDbType.Decimal,21, Iif(Record.Add4Amount= "" ,Convert.DBNull, Record.Add4Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Add5AmountDescription",SqlDbType.NVarChar,151, Iif(Record.Add5AmountDescription= "" ,Convert.DBNull, Record.Add5AmountDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Add5Amount",SqlDbType.Decimal,21, Iif(Record.Add5Amount= "" ,Convert.DBNull, Record.Add5Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TravelStartDate",SqlDbType.DateTime,21, Iif(Record.TravelStartDate= "" ,Convert.DBNull, Record.TravelStartDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TravelFinishDate",SqlDbType.DateTime,21, Iif(Record.TravelFinishDate= "" ,Convert.DBNull, Record.TravelFinishDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestedFor",SqlDbType.NVarChar,9, Iif(Record.RequestedFor= "" ,Convert.DBNull, Record.RequestedFor))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestedForEmployees",SqlDbType.NVarChar,251, Iif(Record.RequestedForEmployees= "" ,Convert.DBNull, Record.RequestedForEmployees))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TravelTypeID",SqlDbType.Int,11, Iif(Record.TravelTypeID= "" ,Convert.DBNull, Record.TravelTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectManagerID",SqlDbType.NVarChar,9, Iif(Record.ProjectManagerID= "" ,Convert.DBNull, Record.ProjectManagerID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostCenterID",SqlDbType.NVarChar,7, Iif(Record.CostCenterID= "" ,Convert.DBNull, Record.CostCenterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TravelItinerary",SqlDbType.NVarChar,501, Iif(Record.TravelItinerary= "" ,Convert.DBNull, Record.TravelItinerary))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Purpose",SqlDbType.NVarChar,501, Iif(Record.Purpose= "" ,Convert.DBNull, Record.Purpose))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalRequestedAmount",SqlDbType.Decimal,21, Iif(Record.TotalRequestedAmount= "" ,Convert.DBNull, Record.TotalRequestedAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestedCurrencyID",SqlDbType.NVarChar,7, Iif(Record.RequestedCurrencyID= "" ,Convert.DBNull, Record.RequestedCurrencyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestedConversionFactor",SqlDbType.Decimal,25, Iif(Record.RequestedConversionFactor= "" ,Convert.DBNull, Record.RequestedConversionFactor))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MDLodgingAmount",SqlDbType.Decimal,21, Iif(Record.MDLodgingAmount= "" ,Convert.DBNull, Record.MDLodgingAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MDCurrencyID",SqlDbType.NVarChar,7, Iif(Record.MDCurrencyID= "" ,Convert.DBNull, Record.MDCurrencyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestKey",SqlDbType.NVarChar,9, Iif(Record.RequestKey= "" ,Convert.DBNull, Record.RequestKey))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy",SqlDbType.NVarChar,9, Iif(Record.ApprovedBy= "" ,Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectManagerRemarks",SqlDbType.NVarChar,251, Iif(Record.ProjectManagerRemarks= "" ,Convert.DBNull, Record.ProjectManagerRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MDApprovalOn",SqlDbType.DateTime,21, Iif(Record.MDApprovalOn= "" ,Convert.DBNull, Record.MDApprovalOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MDConversionFactor",SqlDbType.Decimal,25, Iif(Record.MDConversionFactor= "" ,Convert.DBNull, Record.MDConversionFactor))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MDDAAmount",SqlDbType.Decimal,21, Iif(Record.MDDAAmount= "" ,Convert.DBNull, Record.MDDAAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MDDAAmountINR",SqlDbType.Decimal,21, Iif(Record.MDDAAmountINR= "" ,Convert.DBNull, Record.MDDAAmountINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalRequestedAmountINR",SqlDbType.Decimal,21, Iif(Record.TotalRequestedAmountINR= "" ,Convert.DBNull, Record.TotalRequestedAmountINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BudgetCheckedOn",SqlDbType.DateTime,21, Iif(Record.BudgetCheckedOn= "" ,Convert.DBNull, Record.BudgetCheckedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BHApprovalBy",SqlDbType.NVarChar,9, Iif(Record.BHApprovalBy= "" ,Convert.DBNull, Record.BHApprovalBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BudgetCheckedBy",SqlDbType.NVarChar,9, Iif(Record.BudgetCheckedBy= "" ,Convert.DBNull, Record.BudgetCheckedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BalanceBudgetWhenSubmitted",SqlDbType.Decimal,21, Iif(Record.BalanceBudgetWhenSubmitted= "" ,Convert.DBNull, Record.BalanceBudgetWhenSubmitted))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MDRemarks",SqlDbType.NVarChar,251, Iif(Record.MDRemarks= "" ,Convert.DBNull, Record.MDRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileAttached",SqlDbType.Bit,3, Iif(Record.FileAttached= "" ,Convert.DBNull, Record.FileAttached))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MDApprovalBy",SqlDbType.NVarChar,9, Iif(Record.MDApprovalBy= "" ,Convert.DBNull, Record.MDApprovalBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BHRemarks",SqlDbType.NVarChar,251, Iif(Record.BHRemarks= "" ,Convert.DBNull, Record.BHRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedOn",SqlDbType.DateTime,21, Iif(Record.ApprovedOn= "" ,Convert.DBNull, Record.ApprovedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MDLodgingAmountINR",SqlDbType.Decimal,21, Iif(Record.MDLodgingAmountINR= "" ,Convert.DBNull, Record.MDLodgingAmountINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BHApprovalOn",SqlDbType.DateTime,21, Iif(Record.BHApprovalOn= "" ,Convert.DBNull, Record.BHApprovalOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApproverRemarks",SqlDbType.NVarChar,251, Iif(Record.ApproverRemarks= "" ,Convert.DBNull, Record.ApproverRemarks))
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
    Public Shared Function tarTravelRequestDelete(ByVal Record As SIS.TAR.tarTravelRequest) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptarTravelRequestDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RequestID",SqlDbType.Int,Record.RequestID.ToString.Length, Record.RequestID)
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
