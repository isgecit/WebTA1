Imports Microsoft.VisualBasic
Public Enum TAValueChanged
  Fresh = 0
  ValueNotChanged = 1
  ValueChanged = 2
End Enum
Public Enum TAStates
  Free = 1
  UnderReceiveByAccounts = 2
  UnderProcessByAccounts = 3
  ReturnedByAccounts = 4
  BillVerified = 5
  UnderApproval = 6
  ReturnedByApprover = 7
  UnderSpecialSanction = 8
  ReturnedBySanctioningAuthority = 9
  UnderVerification = 10
  UnderVoucherUpdation = 11
  VoucherUpdated = 12
  UnderHoldByAccounts = 13
  ReturnedByVerifier = 14
  GSTLocked = 15
  UnderVCHPosting = 16
  VCHPosted = 17
End Enum
Public Enum TAComponentTypes
  Total = 1
  Fare = 2
  Lodging = 3
  DA = 4
  LC = 5
  Expense = 6
  Finance = 7
  Mileage = 8
  Driver = 9
  AccountsEntry = 10
End Enum
Public Enum TATravelTypeValues
  Domestic = 1
  ForeignTravel = 2
  ForeignSiteVisit = 3
  HomeVisit = 4
End Enum
Public Enum TACalculationTypes
  ConvertAtGrossLevel = 1
  ConvertAtIndividualLevel = 2
End Enum
Public Enum TAPrjCalcType
  Actual = 1
  EqualizedDistribution = 2
  AsPerDefinedPercentage = 3
End Enum
Public Enum TARequestStates
  ReturnedFromMD = 1
  ReturnedFromBH = 2
  ReturnedFromApprover = 3
  ReturnedFromProjectManager = 4
  Free = 5
  UnderBudgetChecking = 6
  UnderApproval = 7
  UnderApprovalByBH = 8
  UnderMDApproval = 9
  Approved = 10
  CompleteView = 20
End Enum
'CityTypeID	CityTypeName
'DELHI	DELHI
'METRO	METRO
'MUMBAI	MUMBAI
'OTHERS	OTHERS
'SPECIF	SPECIFIED
