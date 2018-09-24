Imports Microsoft.VisualBasic

Public Enum TptBillStatus
	Cancelled = 1
	Free = 2
	UnderReceiveByAccounts = 3
	UnderReceiveByLogistics = 4
	UnderReSubmitbyLogistics = 5
	UnderPaymentProcessing = 6
	PaymentProcessed = 7
	Closed = 8
	PTRCreated = 9
End Enum

Public Enum erpRequestStates
  Cancelled = 1
  ReturnedForCorrection = 2
  Free = 3
  UnderApprovalByHOD = 4
  UnderEvaluationByIT = 5
  UnderEvaluationByESC = 6
  RejectedByESC = 7
  HoldByESC = 8
  AcceptedByESC = 9
  UnderEstimationByMSL = 10
  UnderDevelopmentByMSL = 11
  Delivered = 12
End Enum