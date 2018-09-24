Imports Microsoft.VisualBasic

Public Enum prkClaimStates
  ReturnedByAccounts = 1
  Free = 2
  SubmittedToAccounts = 3
  ReceivedInAccounts = 4
  UnderProcessInAccounts = 5
  Paid = 6
  PartiallyPaid = 7
  UnderVerificationByAdmin = 8
End Enum
Public Enum prkPerkStates
  UnderVerification = 1
  UnderApproval = 2
  UnderPayment = 3
  Paid = 4
  Rejected = 5
  Expired = 6
  Free = 7
End Enum
Public Enum prkPerk
  MedicalBenifit = 1
  CarMaintenance = 2
  TwoWheelerMaint = 3
  Petrol = 4
  Telephone = 5
  NewspaperMagazine = 6
  CarInsurance = 7
  Uniform = 8
  Mediclaim = 9
  DriverCharges = 10
  ClubSubscription = 11
  Mobile = 12
  EntertainmentExp = 15
  LTC = 16
  VehicleRepairAndRunningExpense = 17
  MiscellaneousReimbursement = 18
  BalanceMedical = 19
End Enum

Public Enum saClaimStates
  Returned = 1
  Free = 2
  SubmittedToHO = 3
  LinkedInAdvice = 4
  ForwardedToAccounts = 5
  UnderPaymentByAccounts = 6
  Paid = 7
End Enum
Public Enum saAdviceStates
  Returned = 1
  Free = 2
  ClaimsLinked = 3
  UnderReceiveByAccounts = 4
  ReceivedInAccounts = 5
  UnderVoucherUpdation = 6
  VoucherUpdated = 7
  Paid = 8
End Enum