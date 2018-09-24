Imports Microsoft.VisualBasic

Public Enum InputStates
    free = 1
    UnderApproval = 2
    SubmittedToAccounts = 3
    FreezedForCostSheet = 4
    Returned = 5
End Enum
Public Enum CostSheetStates
  Free = 2
  Released = 5
  Returned = 1
  Superseded = 6
  UnderApproval = 4
  Checked = 3
End Enum
