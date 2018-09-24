Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ERP
  <DataObject()> _
  Partial Public Class erpCreateTPTBill
    Private Shared _RecordCount As Integer
    Private _SerialNo As Int32 = 0
    Private _TPTBillNo As String = ""
    Private _TPTBillDate As String = ""
    Private _TPTBillReceivedOn As String = ""
    Private _CreatedBy As String = ""
    Private _CreatedOn As String = ""
    Private _GRNos As String = ""
    Private _TPTCode As String = ""
    Private _PONumber As String = ""
    Private _ProjectID As String = ""
    Private _TPTBillAmount As String = ""
    Private _BasicFreightValue As String = ""
    Private _BasicFvODC As String = ""
    Private _DetentionatLP As String = ""
    Private _DetentionatULP As String = ""
    Private _ODCChargesInContract As String = ""
    Private _ODCChargesOutOfContract As String = ""
    Private _EmptyReturnCharges As String = ""
    Private _RTOChallanAmount As String = ""
    Private _OtherAmount As String = ""
    Private _ServiceTax As String = ""
    Private _TotalBillPassedAmount As String = ""
    Private _DiscReturnedToByAC As String = ""
    Private _ChequeNo As String = ""
    Private _LgstRemarks As String = ""
    Private _BillStatus As String = ""
    Private _FWDToAccountsOn As String = ""
    Private _FWDToAccountsBy As String = ""
    Private _RECDByAccountsOn As String = ""
    Private _RECDinAccountsBy As String = ""
    Private _DiscReturnedByACOn As String = ""
    Private _DiscReturnedinAcBy As String = ""
    Private _DiscRecdInLgstBy As String = ""
    Private _DiscRecdInLgstOn As String = ""
    Private _ReFwdToAcBy As String = ""
    Private _ReFwdToACOn As String = ""
    Private _PTRNo As String = ""
    Private _PTRAmount As String = ""
    Private _PTRDate As String = ""
    Private _BankVCHNo As String = ""
    Private _BankVCHAmount As String = ""
    Private _BankVCHDate As String = ""
    Private _AccountsRemarks As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _aspnet_Users2_UserFullName As String = ""
    Private _aspnet_Users3_UserFullName As String = ""
    Private _aspnet_Users4_UserFullName As String = ""
    Private _aspnet_Users5_UserFullName As String = ""
    Private _aspnet_Users6_UserFullName As String = ""
    Private _aspnet_Users7_UserFullName As String = ""
    Private _ERP_TPTBillStatus8_Description As String = ""
    Private _IDM_Projects9_Description As String = ""
    Private _VR_Transporters10_TransporterName As String = ""
    Private _FK_ERP_TransporterBill_FWDToAccountsBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_ERP_TransporterBill_RecdInAccountsBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_ERP_TransporterBill_DiscReturnedInAcBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_ERP_TransporterBill_DiscReturnedToByAc As SIS.QCM.qcmUsers = Nothing
    Private _FK_ERP_TransporterBill_DiscRecdInLgstBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_ERP_TransporterBill_ReFwdToAcBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_ERP_TransporterBill_CreatedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_ERP_TransporterBill_BillStatus As SIS.ERP.erpTPTBillStatus = Nothing
    Private _FK_ERP_TransporterBill_ProjectID As SIS.QCM.qcmProjects = Nothing
    Private _FK_ERP_TransporterBill_TPTCode As SIS.VR.vrTransporters = Nothing
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
    Public Property TPTBillNo() As String
      Get
        Return _TPTBillNo
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _TPTBillNo = ""
				 Else
					 _TPTBillNo = value
			   End If
      End Set
    End Property
    Public Property TPTBillDate() As String
      Get
        If Not _TPTBillDate = String.Empty Then
          Return Convert.ToDateTime(_TPTBillDate).ToString("dd/MM/yyyy")
        End If
        Return _TPTBillDate
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _TPTBillDate = ""
				 Else
					 _TPTBillDate = value
			   End If
      End Set
    End Property
    Public Property TPTBillReceivedOn() As String
      Get
        If Not _TPTBillReceivedOn = String.Empty Then
          Return Convert.ToDateTime(_TPTBillReceivedOn).ToString("dd/MM/yyyy")
        End If
        Return _TPTBillReceivedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _TPTBillReceivedOn = ""
				 Else
					 _TPTBillReceivedOn = value
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
    Public Property GRNos() As String
      Get
        Return _GRNos
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _GRNos = ""
				 Else
					 _GRNos = value
			   End If
      End Set
    End Property
    Public Property TPTCode() As String
      Get
        Return _TPTCode
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _TPTCode = ""
				 Else
					 _TPTCode = value
			   End If
      End Set
    End Property
    Public Property PONumber() As String
      Get
        Return _PONumber
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _PONumber = ""
				 Else
					 _PONumber = value
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
    Public Property TPTBillAmount() As String
      Get
        Return _TPTBillAmount
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _TPTBillAmount = ""
				 Else
					 _TPTBillAmount = value
			   End If
      End Set
    End Property
    Public Property BasicFreightValue() As String
      Get
        Return _BasicFreightValue
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _BasicFreightValue = ""
				 Else
					 _BasicFreightValue = value
			   End If
      End Set
    End Property
    Public Property BasicFvODC() As String
      Get
        Return _BasicFvODC
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _BasicFvODC = ""
				 Else
					 _BasicFvODC = value
			   End If
      End Set
    End Property
    Public Property DetentionatLP() As String
      Get
        Return _DetentionatLP
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _DetentionatLP = ""
				 Else
					 _DetentionatLP = value
			   End If
      End Set
    End Property
    Public Property DetentionatULP() As String
      Get
        Return _DetentionatULP
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _DetentionatULP = ""
				 Else
					 _DetentionatULP = value
			   End If
      End Set
    End Property
    Public Property ODCChargesInContract() As String
      Get
        Return _ODCChargesInContract
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ODCChargesInContract = ""
				 Else
					 _ODCChargesInContract = value
			   End If
      End Set
    End Property
    Public Property ODCChargesOutOfContract() As String
      Get
        Return _ODCChargesOutOfContract
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ODCChargesOutOfContract = ""
				 Else
					 _ODCChargesOutOfContract = value
			   End If
      End Set
    End Property
    Public Property EmptyReturnCharges() As String
      Get
        Return _EmptyReturnCharges
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _EmptyReturnCharges = ""
				 Else
					 _EmptyReturnCharges = value
			   End If
      End Set
    End Property
    Public Property RTOChallanAmount() As String
      Get
        Return _RTOChallanAmount
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _RTOChallanAmount = ""
				 Else
					 _RTOChallanAmount = value
			   End If
      End Set
    End Property
    Public Property OtherAmount() As String
      Get
        Return _OtherAmount
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _OtherAmount = ""
				 Else
					 _OtherAmount = value
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
    Public Property TotalBillPassedAmount() As String
			Get
				If _BasicFreightValue = String.Empty Then _BasicFreightValue = 0
				If _BasicFvODC = String.Empty Then _BasicFvODC = 0
				If _DetentionatLP = String.Empty Then _DetentionatLP = 0
				If _DetentionatULP = String.Empty Then _DetentionatULP = 0
				If _ODCChargesInContract = String.Empty Then _ODCChargesInContract = 0
				If _ODCChargesOutOfContract = String.Empty Then _ODCChargesOutOfContract = 0
				If _EmptyReturnCharges = String.Empty Then _EmptyReturnCharges = 0
				If _RTOChallanAmount = String.Empty Then _RTOChallanAmount = 0
				If _OtherAmount = String.Empty Then _OtherAmount = 0
				If _ServiceTax = String.Empty Then _ServiceTax = 0
				_TotalBillPassedAmount = Convert.ToDecimal(_BasicFreightValue) + Convert.ToDecimal(_BasicFvODC) + Convert.ToDecimal(_DetentionatLP) + Convert.ToDecimal(_DetentionatULP) + Convert.ToDecimal(_ODCChargesInContract) + Convert.ToDecimal(_ODCChargesOutOfContract) + Convert.ToDecimal(_EmptyReturnCharges) + Convert.ToDecimal(_RTOChallanAmount) + Convert.ToDecimal(_OtherAmount) + Convert.ToDecimal(_ServiceTax)
				Return _TotalBillPassedAmount
			End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _TotalBillPassedAmount = ""
				 Else
					 _TotalBillPassedAmount = value
			   End If
      End Set
    End Property
    Public Property DiscReturnedToByAC() As String
      Get
        Return _DiscReturnedToByAC
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _DiscReturnedToByAC = ""
				 Else
					 _DiscReturnedToByAC = value
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
    Public Property LgstRemarks() As String
      Get
        Return _LgstRemarks
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _LgstRemarks = ""
				 Else
					 _LgstRemarks = value
			   End If
      End Set
    End Property
    Public Property BillStatus() As String
      Get
        Return _BillStatus
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _BillStatus = ""
				 Else
					 _BillStatus = value
			   End If
      End Set
    End Property
    Public Property FWDToAccountsOn() As String
      Get
        If Not _FWDToAccountsOn = String.Empty Then
          Return Convert.ToDateTime(_FWDToAccountsOn).ToString("dd/MM/yyyy")
        End If
        Return _FWDToAccountsOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _FWDToAccountsOn = ""
				 Else
					 _FWDToAccountsOn = value
			   End If
      End Set
    End Property
    Public Property FWDToAccountsBy() As String
      Get
        Return _FWDToAccountsBy
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _FWDToAccountsBy = ""
				 Else
					 _FWDToAccountsBy = value
			   End If
      End Set
    End Property
    Public Property RECDByAccountsOn() As String
      Get
        If Not _RECDByAccountsOn = String.Empty Then
          Return Convert.ToDateTime(_RECDByAccountsOn).ToString("dd/MM/yyyy")
        End If
        Return _RECDByAccountsOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _RECDByAccountsOn = ""
				 Else
					 _RECDByAccountsOn = value
			   End If
      End Set
    End Property
    Public Property RECDinAccountsBy() As String
      Get
        Return _RECDinAccountsBy
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _RECDinAccountsBy = ""
				 Else
					 _RECDinAccountsBy = value
			   End If
      End Set
    End Property
    Public Property DiscReturnedByACOn() As String
      Get
        If Not _DiscReturnedByACOn = String.Empty Then
          Return Convert.ToDateTime(_DiscReturnedByACOn).ToString("dd/MM/yyyy")
        End If
        Return _DiscReturnedByACOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _DiscReturnedByACOn = ""
				 Else
					 _DiscReturnedByACOn = value
			   End If
      End Set
    End Property
    Public Property DiscReturnedinAcBy() As String
      Get
        Return _DiscReturnedinAcBy
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _DiscReturnedinAcBy = ""
				 Else
					 _DiscReturnedinAcBy = value
			   End If
      End Set
    End Property
    Public Property DiscRecdInLgstBy() As String
      Get
        Return _DiscRecdInLgstBy
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _DiscRecdInLgstBy = ""
				 Else
					 _DiscRecdInLgstBy = value
			   End If
      End Set
    End Property
    Public Property DiscRecdInLgstOn() As String
      Get
        If Not _DiscRecdInLgstOn = String.Empty Then
          Return Convert.ToDateTime(_DiscRecdInLgstOn).ToString("dd/MM/yyyy")
        End If
        Return _DiscRecdInLgstOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _DiscRecdInLgstOn = ""
				 Else
					 _DiscRecdInLgstOn = value
			   End If
      End Set
    End Property
    Public Property ReFwdToAcBy() As String
      Get
        Return _ReFwdToAcBy
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ReFwdToAcBy = ""
				 Else
					 _ReFwdToAcBy = value
			   End If
      End Set
    End Property
    Public Property ReFwdToACOn() As String
      Get
        If Not _ReFwdToACOn = String.Empty Then
          Return Convert.ToDateTime(_ReFwdToACOn).ToString("dd/MM/yyyy")
        End If
        Return _ReFwdToACOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ReFwdToACOn = ""
				 Else
					 _ReFwdToACOn = value
			   End If
      End Set
    End Property
    Public Property PTRNo() As String
      Get
        Return _PTRNo
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _PTRNo = ""
				 Else
					 _PTRNo = value
			   End If
      End Set
    End Property
    Public Property PTRAmount() As String
      Get
        Return _PTRAmount
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _PTRAmount = ""
				 Else
					 _PTRAmount = value
			   End If
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
				 If Convert.IsDBNull(Value) Then
					 _PTRDate = ""
				 Else
					 _PTRDate = value
			   End If
      End Set
    End Property
    Public Property BankVCHNo() As String
      Get
        Return _BankVCHNo
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _BankVCHNo = ""
				 Else
					 _BankVCHNo = value
			   End If
      End Set
    End Property
    Public Property BankVCHAmount() As String
      Get
        Return _BankVCHAmount
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _BankVCHAmount = ""
				 Else
					 _BankVCHAmount = value
			   End If
      End Set
    End Property
    Public Property BankVCHDate() As String
      Get
        If Not _BankVCHDate = String.Empty Then
          Return Convert.ToDateTime(_BankVCHDate).ToString("dd/MM/yyyy")
        End If
        Return _BankVCHDate
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _BankVCHDate = ""
				 Else
					 _BankVCHDate = value
			   End If
      End Set
    End Property
    Public Property AccountsRemarks() As String
      Get
        Return _AccountsRemarks
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _AccountsRemarks = ""
				 Else
					 _AccountsRemarks = value
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
    Public Property ERP_TPTBillStatus8_Description() As String
      Get
        Return _ERP_TPTBillStatus8_Description
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ERP_TPTBillStatus8_Description = ""
				 Else
					 _ERP_TPTBillStatus8_Description = value
			   End If
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
    Public Property VR_Transporters10_TransporterName() As String
      Get
        Return _VR_Transporters10_TransporterName
      End Get
      Set(ByVal value As String)
        _VR_Transporters10_TransporterName = value
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
    Public Class PKerpCreateTPTBill
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
    Public ReadOnly Property FK_ERP_TransporterBill_FWDToAccountsBy() As SIS.QCM.qcmUsers
      Get
        If _FK_ERP_TransporterBill_FWDToAccountsBy Is Nothing Then
          _FK_ERP_TransporterBill_FWDToAccountsBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_FWDToAccountsBy)
        End If
        Return _FK_ERP_TransporterBill_FWDToAccountsBy
      End Get
    End Property
    Public ReadOnly Property FK_ERP_TransporterBill_RecdInAccountsBy() As SIS.QCM.qcmUsers
      Get
        If _FK_ERP_TransporterBill_RecdInAccountsBy Is Nothing Then
          _FK_ERP_TransporterBill_RecdInAccountsBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_RECDinAccountsBy)
        End If
        Return _FK_ERP_TransporterBill_RecdInAccountsBy
      End Get
    End Property
    Public ReadOnly Property FK_ERP_TransporterBill_DiscReturnedInAcBy() As SIS.QCM.qcmUsers
      Get
        If _FK_ERP_TransporterBill_DiscReturnedInAcBy Is Nothing Then
          _FK_ERP_TransporterBill_DiscReturnedInAcBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_DiscReturnedinAcBy)
        End If
        Return _FK_ERP_TransporterBill_DiscReturnedInAcBy
      End Get
    End Property
    Public ReadOnly Property FK_ERP_TransporterBill_DiscReturnedToByAc() As SIS.QCM.qcmUsers
      Get
        If _FK_ERP_TransporterBill_DiscReturnedToByAc Is Nothing Then
          _FK_ERP_TransporterBill_DiscReturnedToByAc = SIS.QCM.qcmUsers.qcmUsersGetByID(_DiscReturnedToByAC)
        End If
        Return _FK_ERP_TransporterBill_DiscReturnedToByAc
      End Get
    End Property
    Public ReadOnly Property FK_ERP_TransporterBill_DiscRecdInLgstBy() As SIS.QCM.qcmUsers
      Get
        If _FK_ERP_TransporterBill_DiscRecdInLgstBy Is Nothing Then
          _FK_ERP_TransporterBill_DiscRecdInLgstBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_DiscRecdInLgstBy)
        End If
        Return _FK_ERP_TransporterBill_DiscRecdInLgstBy
      End Get
    End Property
    Public ReadOnly Property FK_ERP_TransporterBill_ReFwdToAcBy() As SIS.QCM.qcmUsers
      Get
        If _FK_ERP_TransporterBill_ReFwdToAcBy Is Nothing Then
          _FK_ERP_TransporterBill_ReFwdToAcBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_ReFwdToAcBy)
        End If
        Return _FK_ERP_TransporterBill_ReFwdToAcBy
      End Get
    End Property
    Public ReadOnly Property FK_ERP_TransporterBill_CreatedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_ERP_TransporterBill_CreatedBy Is Nothing Then
          _FK_ERP_TransporterBill_CreatedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_CreatedBy)
        End If
        Return _FK_ERP_TransporterBill_CreatedBy
      End Get
    End Property
    Public ReadOnly Property FK_ERP_TransporterBill_BillStatus() As SIS.ERP.erpTPTBillStatus
      Get
        If _FK_ERP_TransporterBill_BillStatus Is Nothing Then
          _FK_ERP_TransporterBill_BillStatus = SIS.ERP.erpTPTBillStatus.erpTPTBillStatusGetByID(_BillStatus)
        End If
        Return _FK_ERP_TransporterBill_BillStatus
      End Get
    End Property
    Public ReadOnly Property FK_ERP_TransporterBill_ProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_ERP_TransporterBill_ProjectID Is Nothing Then
          _FK_ERP_TransporterBill_ProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_ProjectID)
        End If
        Return _FK_ERP_TransporterBill_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_ERP_TransporterBill_TPTCode() As SIS.VR.vrTransporters
      Get
        If _FK_ERP_TransporterBill_TPTCode Is Nothing Then
          _FK_ERP_TransporterBill_TPTCode = SIS.VR.vrTransporters.vrTransportersGetByID(_TPTCode)
        End If
        Return _FK_ERP_TransporterBill_TPTCode
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpCreateTPTBillGetNewRecord() As SIS.ERP.erpCreateTPTBill
      Return New SIS.ERP.erpCreateTPTBill()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpCreateTPTBillGetByID(ByVal SerialNo As Int32) As SIS.ERP.erpCreateTPTBill
      Dim Results As SIS.ERP.erpCreateTPTBill = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpCreateTPTBillSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.ERP.erpCreateTPTBill(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpCreateTPTBillSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TPTCode As String, ByVal ProjectID As String, ByVal BillStatus As Int32) As List(Of SIS.ERP.erpCreateTPTBill)
      Dim Results As List(Of SIS.ERP.erpCreateTPTBill) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "sperpCreateTPTBillSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "sperpCreateTPTBillSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TPTCode",SqlDbType.NVarChar,9, IIf(TPTCode Is Nothing, String.Empty,TPTCode))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BillStatus",SqlDbType.Int,10, IIf(BillStatus = Nothing, 0,BillStatus))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ERP.erpCreateTPTBill)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ERP.erpCreateTPTBill(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function erpCreateTPTBillSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TPTCode As String, ByVal ProjectID As String, ByVal BillStatus As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpCreateTPTBillGetByID(ByVal SerialNo As Int32, ByVal Filter_TPTCode As String, ByVal Filter_ProjectID As String, ByVal Filter_BillStatus As Int32) As SIS.ERP.erpCreateTPTBill
      Return erpCreateTPTBillGetByID(SerialNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function erpCreateTPTBillInsert(ByVal Record As SIS.ERP.erpCreateTPTBill) As SIS.ERP.erpCreateTPTBill
      Dim _Rec As SIS.ERP.erpCreateTPTBill = SIS.ERP.erpCreateTPTBill.erpCreateTPTBillGetNewRecord()
			With _Rec
				.IRNumber = Record.IRNumber
				.TPTBillNo = Record.TPTBillNo
				.TPTBillDate = Record.TPTBillDate
				.TPTBillReceivedOn = Record.TPTBillReceivedOn
				.CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
				.CreatedOn = Now
				.GRNos = Record.GRNos
				.TPTCode = Record.TPTCode
				.PONumber = Record.PONumber
				.ProjectID = Record.ProjectID
				.TPTBillAmount = Record.TPTBillAmount
				.BasicFreightValue = Record.BasicFreightValue
				.BasicFvODC = Record.BasicFvODC
				.DetentionatLP = Record.DetentionatLP
				.DetentionatDaysLP = Record.DetentionatDaysLP
				.LPisISGECWorks = Record.LPisISGECWorks
				.DetentionatULP = Record.DetentionatULP
				.DetentionatDaysULP = Record.DetentionatDaysULP
				.ULPisICDCFSPort = Record.ULPisICDCFSPort
				.ODCChargesInContract = Record.ODCChargesInContract
				.ODCChargesOutOfContract = Record.ODCChargesOutOfContract
				.BackToTownCharges = Record.BackToTownCharges
				.TarpaulinCharges = Record.TarpaulinCharges
				.WoodenSleeperCharges = Record.WoodenSleeperCharges
				.EmptyReturnCharges = Record.EmptyReturnCharges
				.RTOChallanAmount = Record.RTOChallanAmount
				.OtherAmount = Record.OtherAmount
				.ServiceTax = Record.ServiceTax
				.TotalBillPassedAmount = Record.TotalBillPassedAmount
				.DiscReturnedToByAC = Record.DiscReturnedToByAC
				.LgstRemarks = Record.LgstRemarks
				.BillStatus = Record.BillStatus
			End With
      Return SIS.ERP.erpCreateTPTBill.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.ERP.erpCreateTPTBill) As SIS.ERP.erpCreateTPTBill
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpCreateTPTBillInsert"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRNumber", SqlDbType.NVarChar, 11, IIf(Record.IRNumber = "", Convert.DBNull, Record.IRNumber))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TPTBillNo", SqlDbType.NVarChar, 31, IIf(Record.TPTBillNo = "", Convert.DBNull, Record.TPTBillNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TPTBillDate",SqlDbType.DateTime,21, Iif(Record.TPTBillDate= "" ,Convert.DBNull, Record.TPTBillDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TPTBillReceivedOn",SqlDbType.DateTime,21, Iif(Record.TPTBillReceivedOn= "" ,Convert.DBNull, Record.TPTBillReceivedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GRNos",SqlDbType.NVarChar,501, Iif(Record.GRNos= "" ,Convert.DBNull, Record.GRNos))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TPTCode",SqlDbType.NVarChar,10, Iif(Record.TPTCode= "" ,Convert.DBNull, Record.TPTCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PONumber",SqlDbType.NVarChar,10, Iif(Record.PONumber= "" ,Convert.DBNull, Record.PONumber))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TPTBillAmount",SqlDbType.Decimal,21, Iif(Record.TPTBillAmount= "" ,Convert.DBNull, Record.TPTBillAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BasicFreightValue",SqlDbType.Decimal,21, Iif(Record.BasicFreightValue= "" ,Convert.DBNull, Record.BasicFreightValue))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BasicFvODC",SqlDbType.Decimal,21, Iif(Record.BasicFvODC= "" ,Convert.DBNull, Record.BasicFvODC))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DetentionatLP", SqlDbType.Decimal, 21, IIf(Record.DetentionatLP = "", Convert.DBNull, Record.DetentionatLP))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DetentionatULP", SqlDbType.Decimal, 21, IIf(Record.DetentionatULP = "", Convert.DBNull, Record.DetentionatULP))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ODCChargesInContract",SqlDbType.Decimal,21, Iif(Record.ODCChargesInContract= "" ,Convert.DBNull, Record.ODCChargesInContract))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ODCChargesOutOfContract",SqlDbType.Decimal,21, Iif(Record.ODCChargesOutOfContract= "" ,Convert.DBNull, Record.ODCChargesOutOfContract))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmptyReturnCharges",SqlDbType.Decimal,21, Iif(Record.EmptyReturnCharges= "" ,Convert.DBNull, Record.EmptyReturnCharges))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RTOChallanAmount",SqlDbType.Decimal,21, Iif(Record.RTOChallanAmount= "" ,Convert.DBNull, Record.RTOChallanAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OtherAmount",SqlDbType.Decimal,21, Iif(Record.OtherAmount= "" ,Convert.DBNull, Record.OtherAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ServiceTax",SqlDbType.Decimal,21, Iif(Record.ServiceTax= "" ,Convert.DBNull, Record.ServiceTax))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalBillPassedAmount",SqlDbType.Decimal,21, Iif(Record.TotalBillPassedAmount= "" ,Convert.DBNull, Record.TotalBillPassedAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DiscReturnedToByAC",SqlDbType.NVarChar,9, Iif(Record.DiscReturnedToByAC= "" ,Convert.DBNull, Record.DiscReturnedToByAC))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ChequeNo",SqlDbType.NVarChar,21, Iif(Record.ChequeNo= "" ,Convert.DBNull, Record.ChequeNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LgstRemarks",SqlDbType.NVarChar,501, Iif(Record.LgstRemarks= "" ,Convert.DBNull, Record.LgstRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillStatus",SqlDbType.Int,11, Iif(Record.BillStatus= "" ,Convert.DBNull, Record.BillStatus))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FWDToAccountsOn",SqlDbType.DateTime,21, Iif(Record.FWDToAccountsOn= "" ,Convert.DBNull, Record.FWDToAccountsOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FWDToAccountsBy",SqlDbType.NVarChar,9, Iif(Record.FWDToAccountsBy= "" ,Convert.DBNull, Record.FWDToAccountsBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RECDByAccountsOn",SqlDbType.DateTime,21, Iif(Record.RECDByAccountsOn= "" ,Convert.DBNull, Record.RECDByAccountsOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RECDinAccountsBy",SqlDbType.NVarChar,9, Iif(Record.RECDinAccountsBy= "" ,Convert.DBNull, Record.RECDinAccountsBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DiscReturnedByACOn",SqlDbType.DateTime,21, Iif(Record.DiscReturnedByACOn= "" ,Convert.DBNull, Record.DiscReturnedByACOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DiscReturnedinAcBy",SqlDbType.NVarChar,9, Iif(Record.DiscReturnedinAcBy= "" ,Convert.DBNull, Record.DiscReturnedinAcBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DiscRecdInLgstBy",SqlDbType.NVarChar,9, Iif(Record.DiscRecdInLgstBy= "" ,Convert.DBNull, Record.DiscRecdInLgstBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DiscRecdInLgstOn",SqlDbType.DateTime,21, Iif(Record.DiscRecdInLgstOn= "" ,Convert.DBNull, Record.DiscRecdInLgstOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReFwdToAcBy",SqlDbType.NVarChar,9, Iif(Record.ReFwdToAcBy= "" ,Convert.DBNull, Record.ReFwdToAcBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReFwdToACOn",SqlDbType.DateTime,21, Iif(Record.ReFwdToACOn= "" ,Convert.DBNull, Record.ReFwdToACOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PTRNo",SqlDbType.NVarChar,11, Iif(Record.PTRNo= "" ,Convert.DBNull, Record.PTRNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PTRAmount",SqlDbType.Decimal,21, Iif(Record.PTRAmount= "" ,Convert.DBNull, Record.PTRAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PTRDate",SqlDbType.DateTime,21, Iif(Record.PTRDate= "" ,Convert.DBNull, Record.PTRDate))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BankVCHNo", SqlDbType.NVarChar, 16, IIf(Record.BankVCHNo = "", Convert.DBNull, Record.BankVCHNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BankVCHAmount",SqlDbType.Decimal,21, Iif(Record.BankVCHAmount= "" ,Convert.DBNull, Record.BankVCHAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BankVCHDate",SqlDbType.DateTime,21, Iif(Record.BankVCHDate= "" ,Convert.DBNull, Record.BankVCHDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AccountsRemarks",SqlDbType.NVarChar,501, Iif(Record.AccountsRemarks= "" ,Convert.DBNull, Record.AccountsRemarks))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReasonID", SqlDbType.Int, 10, IIf(Record.ReasonID = "", Convert.DBNull, Record.ReasonID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DetentionatDaysLP", SqlDbType.Decimal, 11, IIf(Record.DetentionatDaysLP = "", Convert.DBNull, Record.DetentionatDaysLP))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LPisISGECWorks", SqlDbType.Bit, 1, Record.LPisISGECWorks)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DetentionatDaysULP", SqlDbType.Decimal, 11, IIf(Record.DetentionatDaysULP = "", Convert.DBNull, Record.DetentionatDaysULP))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ULPisICDCFSPort", SqlDbType.Bit, 1, Record.ULPisICDCFSPort)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BackToTownCharges", SqlDbType.Decimal, 21, IIf(Record.BackToTownCharges = "", Convert.DBNull, Record.BackToTownCharges))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TarpaulinCharges", SqlDbType.Decimal, 21, IIf(Record.TarpaulinCharges = "", Convert.DBNull, Record.TarpaulinCharges))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WoodenSleeperCharges", SqlDbType.Decimal, 21, IIf(Record.WoodenSleeperCharges = "", Convert.DBNull, Record.WoodenSleeperCharges))
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
    Public Shared Function erpCreateTPTBillUpdate(ByVal Record As SIS.ERP.erpCreateTPTBill) As SIS.ERP.erpCreateTPTBill
      Dim _Rec As SIS.ERP.erpCreateTPTBill = SIS.ERP.erpCreateTPTBill.erpCreateTPTBillGetByID(Record.SerialNo)
			With _Rec
				.TPTBillNo = Record.TPTBillNo
				.TPTBillDate = Record.TPTBillDate
				.TPTBillReceivedOn = Record.TPTBillReceivedOn
				.CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
				.CreatedOn = Now
				.GRNos = Record.GRNos
				.TPTCode = Record.TPTCode
				.PONumber = Record.PONumber
				.ProjectID = Record.ProjectID
				.TPTBillAmount = Record.TPTBillAmount
				.BasicFreightValue = Record.BasicFreightValue
				.BasicFvODC = Record.BasicFvODC
				.DetentionatLP = Record.DetentionatLP
				.DetentionatDaysLP = Record.DetentionatDaysLP
				.LPisISGECWorks = Record.LPisISGECWorks
				.DetentionatULP = Record.DetentionatULP
				.DetentionatDaysULP = Record.DetentionatDaysULP
				.ULPisICDCFSPort = Record.ULPisICDCFSPort
				.ODCChargesInContract = Record.ODCChargesInContract
				.ODCChargesOutOfContract = Record.ODCChargesOutOfContract
				.BackToTownCharges = Record.BackToTownCharges
				.TarpaulinCharges = Record.TarpaulinCharges
				.WoodenSleeperCharges = Record.WoodenSleeperCharges
				.EmptyReturnCharges = Record.EmptyReturnCharges
				.RTOChallanAmount = Record.RTOChallanAmount
				.OtherAmount = Record.OtherAmount
				.ServiceTax = Record.ServiceTax
				.TotalBillPassedAmount = Record.TotalBillPassedAmount
				.DiscReturnedToByAC = Record.DiscReturnedToByAC
				.ChequeNo = Record.ChequeNo
				.LgstRemarks = Record.LgstRemarks
				.BillStatus = Record.BillStatus
				.ReasonID = Record.ReasonID
			End With
      Return SIS.ERP.erpCreateTPTBill.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.ERP.erpCreateTPTBill) As SIS.ERP.erpCreateTPTBill
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpCreateTPTBillUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRNumber", SqlDbType.NVarChar, 11, IIf(Record.IRNumber = "", Convert.DBNull, Record.IRNumber))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TPTBillNo", SqlDbType.NVarChar, 31, IIf(Record.TPTBillNo = "", Convert.DBNull, Record.TPTBillNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TPTBillDate",SqlDbType.DateTime,21, Iif(Record.TPTBillDate= "" ,Convert.DBNull, Record.TPTBillDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TPTBillReceivedOn",SqlDbType.DateTime,21, Iif(Record.TPTBillReceivedOn= "" ,Convert.DBNull, Record.TPTBillReceivedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GRNos",SqlDbType.NVarChar,501, Iif(Record.GRNos= "" ,Convert.DBNull, Record.GRNos))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TPTCode",SqlDbType.NVarChar,10, Iif(Record.TPTCode= "" ,Convert.DBNull, Record.TPTCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PONumber",SqlDbType.NVarChar,10, Iif(Record.PONumber= "" ,Convert.DBNull, Record.PONumber))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TPTBillAmount",SqlDbType.Decimal,21, Iif(Record.TPTBillAmount= "" ,Convert.DBNull, Record.TPTBillAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BasicFreightValue",SqlDbType.Decimal,21, Iif(Record.BasicFreightValue= "" ,Convert.DBNull, Record.BasicFreightValue))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BasicFvODC",SqlDbType.Decimal,21, Iif(Record.BasicFvODC= "" ,Convert.DBNull, Record.BasicFvODC))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DetentionatLP",SqlDbType.Decimal,21, Iif(Record.DetentionatLP= "" ,Convert.DBNull, Record.DetentionatLP))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DetentionatULP",SqlDbType.Decimal,21, Iif(Record.DetentionatULP= "" ,Convert.DBNull, Record.DetentionatULP))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ODCChargesInContract",SqlDbType.Decimal,21, Iif(Record.ODCChargesInContract= "" ,Convert.DBNull, Record.ODCChargesInContract))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ODCChargesOutOfContract",SqlDbType.Decimal,21, Iif(Record.ODCChargesOutOfContract= "" ,Convert.DBNull, Record.ODCChargesOutOfContract))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmptyReturnCharges",SqlDbType.Decimal,21, Iif(Record.EmptyReturnCharges= "" ,Convert.DBNull, Record.EmptyReturnCharges))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RTOChallanAmount",SqlDbType.Decimal,21, Iif(Record.RTOChallanAmount= "" ,Convert.DBNull, Record.RTOChallanAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OtherAmount",SqlDbType.Decimal,21, Iif(Record.OtherAmount= "" ,Convert.DBNull, Record.OtherAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ServiceTax",SqlDbType.Decimal,21, Iif(Record.ServiceTax= "" ,Convert.DBNull, Record.ServiceTax))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalBillPassedAmount",SqlDbType.Decimal,21, Iif(Record.TotalBillPassedAmount= "" ,Convert.DBNull, Record.TotalBillPassedAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DiscReturnedToByAC",SqlDbType.NVarChar,9, Iif(Record.DiscReturnedToByAC= "" ,Convert.DBNull, Record.DiscReturnedToByAC))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ChequeNo",SqlDbType.NVarChar,21, Iif(Record.ChequeNo= "" ,Convert.DBNull, Record.ChequeNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LgstRemarks",SqlDbType.NVarChar,501, Iif(Record.LgstRemarks= "" ,Convert.DBNull, Record.LgstRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillStatus",SqlDbType.Int,11, Iif(Record.BillStatus= "" ,Convert.DBNull, Record.BillStatus))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FWDToAccountsOn",SqlDbType.DateTime,21, Iif(Record.FWDToAccountsOn= "" ,Convert.DBNull, Record.FWDToAccountsOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FWDToAccountsBy",SqlDbType.NVarChar,9, Iif(Record.FWDToAccountsBy= "" ,Convert.DBNull, Record.FWDToAccountsBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RECDByAccountsOn",SqlDbType.DateTime,21, Iif(Record.RECDByAccountsOn= "" ,Convert.DBNull, Record.RECDByAccountsOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RECDinAccountsBy",SqlDbType.NVarChar,9, Iif(Record.RECDinAccountsBy= "" ,Convert.DBNull, Record.RECDinAccountsBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DiscReturnedByACOn",SqlDbType.DateTime,21, Iif(Record.DiscReturnedByACOn= "" ,Convert.DBNull, Record.DiscReturnedByACOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DiscReturnedinAcBy",SqlDbType.NVarChar,9, Iif(Record.DiscReturnedinAcBy= "" ,Convert.DBNull, Record.DiscReturnedinAcBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DiscRecdInLgstBy",SqlDbType.NVarChar,9, Iif(Record.DiscRecdInLgstBy= "" ,Convert.DBNull, Record.DiscRecdInLgstBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DiscRecdInLgstOn",SqlDbType.DateTime,21, Iif(Record.DiscRecdInLgstOn= "" ,Convert.DBNull, Record.DiscRecdInLgstOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReFwdToAcBy",SqlDbType.NVarChar,9, Iif(Record.ReFwdToAcBy= "" ,Convert.DBNull, Record.ReFwdToAcBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReFwdToACOn",SqlDbType.DateTime,21, Iif(Record.ReFwdToACOn= "" ,Convert.DBNull, Record.ReFwdToACOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PTRNo",SqlDbType.NVarChar,11, Iif(Record.PTRNo= "" ,Convert.DBNull, Record.PTRNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PTRAmount",SqlDbType.Decimal,21, Iif(Record.PTRAmount= "" ,Convert.DBNull, Record.PTRAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PTRDate",SqlDbType.DateTime,21, Iif(Record.PTRDate= "" ,Convert.DBNull, Record.PTRDate))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BankVCHNo", SqlDbType.NVarChar, 16, IIf(Record.BankVCHNo = "", Convert.DBNull, Record.BankVCHNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BankVCHAmount",SqlDbType.Decimal,21, Iif(Record.BankVCHAmount= "" ,Convert.DBNull, Record.BankVCHAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BankVCHDate",SqlDbType.DateTime,21, Iif(Record.BankVCHDate= "" ,Convert.DBNull, Record.BankVCHDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AccountsRemarks",SqlDbType.NVarChar,501, Iif(Record.AccountsRemarks= "" ,Convert.DBNull, Record.AccountsRemarks))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReasonID", SqlDbType.Int, 10, IIf(Record.ReasonID = "", Convert.DBNull, Record.ReasonID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DetentionatDaysLP", SqlDbType.Decimal, 11, IIf(Record.DetentionatDaysLP = "", Convert.DBNull, Record.DetentionatDaysLP))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LPisISGECWorks", SqlDbType.Bit, 1, Record.LPisISGECWorks)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DetentionatDaysULP", SqlDbType.Decimal, 11, IIf(Record.DetentionatDaysULP = "", Convert.DBNull, Record.DetentionatDaysULP))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ULPisICDCFSPort", SqlDbType.Bit, 1, Record.ULPisICDCFSPort)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BackToTownCharges", SqlDbType.Decimal, 21, IIf(Record.BackToTownCharges = "", Convert.DBNull, Record.BackToTownCharges))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TarpaulinCharges", SqlDbType.Decimal, 21, IIf(Record.TarpaulinCharges = "", Convert.DBNull, Record.TarpaulinCharges))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WoodenSleeperCharges", SqlDbType.Decimal, 21, IIf(Record.WoodenSleeperCharges = "", Convert.DBNull, Record.WoodenSleeperCharges))
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
    Public Shared Function erpCreateTPTBillDelete(ByVal Record As SIS.ERP.erpCreateTPTBill) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpCreateTPTBillDelete"
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
    'Public Sub New(ByVal Reader As SqlDataReader)
    '	On Error Resume Next
    '	_SerialNo = CType(Reader("SerialNo"), Int32)
    '	If Convert.IsDBNull(Reader("TPTBillNo")) Then
    '		_TPTBillNo = String.Empty
    '	Else
    '		_TPTBillNo = CType(Reader("TPTBillNo"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("TPTBillDate")) Then
    '		_TPTBillDate = String.Empty
    '	Else
    '		_TPTBillDate = CType(Reader("TPTBillDate"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("TPTBillReceivedOn")) Then
    '		_TPTBillReceivedOn = String.Empty
    '	Else
    '		_TPTBillReceivedOn = CType(Reader("TPTBillReceivedOn"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("CreatedBy")) Then
    '		_CreatedBy = String.Empty
    '	Else
    '		_CreatedBy = CType(Reader("CreatedBy"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("CreatedOn")) Then
    '		_CreatedOn = String.Empty
    '	Else
    '		_CreatedOn = CType(Reader("CreatedOn"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("GRNos")) Then
    '		_GRNos = String.Empty
    '	Else
    '		_GRNos = CType(Reader("GRNos"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("TPTCode")) Then
    '		_TPTCode = String.Empty
    '	Else
    '		_TPTCode = CType(Reader("TPTCode"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("PONumber")) Then
    '		_PONumber = String.Empty
    '	Else
    '		_PONumber = CType(Reader("PONumber"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("ProjectID")) Then
    '		_ProjectID = String.Empty
    '	Else
    '		_ProjectID = CType(Reader("ProjectID"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("TPTBillAmount")) Then
    '		_TPTBillAmount = String.Empty
    '	Else
    '		_TPTBillAmount = CType(Reader("TPTBillAmount"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("BasicFreightValue")) Then
    '		_BasicFreightValue = String.Empty
    '	Else
    '		_BasicFreightValue = CType(Reader("BasicFreightValue"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("BasicFvODC")) Then
    '		_BasicFvODC = String.Empty
    '	Else
    '		_BasicFvODC = CType(Reader("BasicFvODC"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("DetentionatLP")) Then
    '		_DetentionatLP = String.Empty
    '	Else
    '		_DetentionatLP = CType(Reader("DetentionatLP"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("DetentionatULP")) Then
    '		_DetentionatULP = String.Empty
    '	Else
    '		_DetentionatULP = CType(Reader("DetentionatULP"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("ODCChargesInContract")) Then
    '		_ODCChargesInContract = String.Empty
    '	Else
    '		_ODCChargesInContract = CType(Reader("ODCChargesInContract"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("ODCChargesOutOfContract")) Then
    '		_ODCChargesOutOfContract = String.Empty
    '	Else
    '		_ODCChargesOutOfContract = CType(Reader("ODCChargesOutOfContract"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("EmptyReturnCharges")) Then
    '		_EmptyReturnCharges = String.Empty
    '	Else
    '		_EmptyReturnCharges = CType(Reader("EmptyReturnCharges"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("RTOChallanAmount")) Then
    '		_RTOChallanAmount = String.Empty
    '	Else
    '		_RTOChallanAmount = CType(Reader("RTOChallanAmount"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("OtherAmount")) Then
    '		_OtherAmount = String.Empty
    '	Else
    '		_OtherAmount = CType(Reader("OtherAmount"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("ServiceTax")) Then
    '		_ServiceTax = String.Empty
    '	Else
    '		_ServiceTax = CType(Reader("ServiceTax"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("TotalBillPassedAmount")) Then
    '		_TotalBillPassedAmount = String.Empty
    '	Else
    '		_TotalBillPassedAmount = CType(Reader("TotalBillPassedAmount"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("DiscReturnedToByAC")) Then
    '		_DiscReturnedToByAC = String.Empty
    '	Else
    '		_DiscReturnedToByAC = CType(Reader("DiscReturnedToByAC"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("ChequeNo")) Then
    '		_ChequeNo = String.Empty
    '	Else
    '		_ChequeNo = CType(Reader("ChequeNo"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("LgstRemarks")) Then
    '		_LgstRemarks = String.Empty
    '	Else
    '		_LgstRemarks = CType(Reader("LgstRemarks"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("BillStatus")) Then
    '		_BillStatus = String.Empty
    '	Else
    '		_BillStatus = CType(Reader("BillStatus"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("FWDToAccountsOn")) Then
    '		_FWDToAccountsOn = String.Empty
    '	Else
    '		_FWDToAccountsOn = CType(Reader("FWDToAccountsOn"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("FWDToAccountsBy")) Then
    '		_FWDToAccountsBy = String.Empty
    '	Else
    '		_FWDToAccountsBy = CType(Reader("FWDToAccountsBy"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("RECDByAccountsOn")) Then
    '		_RECDByAccountsOn = String.Empty
    '	Else
    '		_RECDByAccountsOn = CType(Reader("RECDByAccountsOn"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("RECDinAccountsBy")) Then
    '		_RECDinAccountsBy = String.Empty
    '	Else
    '		_RECDinAccountsBy = CType(Reader("RECDinAccountsBy"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("DiscReturnedByACOn")) Then
    '		_DiscReturnedByACOn = String.Empty
    '	Else
    '		_DiscReturnedByACOn = CType(Reader("DiscReturnedByACOn"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("DiscReturnedinAcBy")) Then
    '		_DiscReturnedinAcBy = String.Empty
    '	Else
    '		_DiscReturnedinAcBy = CType(Reader("DiscReturnedinAcBy"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("DiscRecdInLgstBy")) Then
    '		_DiscRecdInLgstBy = String.Empty
    '	Else
    '		_DiscRecdInLgstBy = CType(Reader("DiscRecdInLgstBy"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("DiscRecdInLgstOn")) Then
    '		_DiscRecdInLgstOn = String.Empty
    '	Else
    '		_DiscRecdInLgstOn = CType(Reader("DiscRecdInLgstOn"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("ReFwdToAcBy")) Then
    '		_ReFwdToAcBy = String.Empty
    '	Else
    '		_ReFwdToAcBy = CType(Reader("ReFwdToAcBy"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("ReFwdToACOn")) Then
    '		_ReFwdToACOn = String.Empty
    '	Else
    '		_ReFwdToACOn = CType(Reader("ReFwdToACOn"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("PTRNo")) Then
    '		_PTRNo = String.Empty
    '	Else
    '		_PTRNo = CType(Reader("PTRNo"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("PTRAmount")) Then
    '		_PTRAmount = String.Empty
    '	Else
    '		_PTRAmount = CType(Reader("PTRAmount"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("PTRDate")) Then
    '		_PTRDate = String.Empty
    '	Else
    '		_PTRDate = CType(Reader("PTRDate"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("BankVCHNo")) Then
    '		_BankVCHNo = String.Empty
    '	Else
    '		_BankVCHNo = CType(Reader("BankVCHNo"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("BankVCHAmount")) Then
    '		_BankVCHAmount = String.Empty
    '	Else
    '		_BankVCHAmount = CType(Reader("BankVCHAmount"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("BankVCHDate")) Then
    '		_BankVCHDate = String.Empty
    '	Else
    '		_BankVCHDate = CType(Reader("BankVCHDate"), String)
    '	End If
    '	If Convert.IsDBNull(Reader("AccountsRemarks")) Then
    '		_AccountsRemarks = String.Empty
    '	Else
    '		_AccountsRemarks = CType(Reader("AccountsRemarks"), String)
    '	End If
    '	_aspnet_Users1_UserFullName = CType(Reader("aspnet_Users1_UserFullName"), String)
    '	_aspnet_Users2_UserFullName = CType(Reader("aspnet_Users2_UserFullName"), String)
    '	_aspnet_Users3_UserFullName = CType(Reader("aspnet_Users3_UserFullName"), String)
    '	_aspnet_Users4_UserFullName = CType(Reader("aspnet_Users4_UserFullName"), String)
    '	_aspnet_Users5_UserFullName = CType(Reader("aspnet_Users5_UserFullName"), String)
    '	_aspnet_Users6_UserFullName = CType(Reader("aspnet_Users6_UserFullName"), String)
    '	_aspnet_Users7_UserFullName = CType(Reader("aspnet_Users7_UserFullName"), String)
    '	If Convert.IsDBNull(Reader("ERP_TPTBillStatus8_Description")) Then
    '		_ERP_TPTBillStatus8_Description = String.Empty
    '	Else
    '		_ERP_TPTBillStatus8_Description = CType(Reader("ERP_TPTBillStatus8_Description"), String)
    '	End If
    '	_IDM_Projects9_Description = CType(Reader("IDM_Projects9_Description"), String)
    '	_VR_Transporters10_TransporterName = CType(Reader("VR_Transporters10_TransporterName"), String)
    'End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
