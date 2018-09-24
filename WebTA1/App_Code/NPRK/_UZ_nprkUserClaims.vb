Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  Partial Public Class nprkUserClaims
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      Select Case ClaimStatusID
        Case prkClaimStates.SubmittedToAccounts
          mRet = Drawing.Color.Green
        Case prkClaimStates.ReturnedByAccounts
          mRet = Drawing.Color.Red
        Case prkClaimStates.ReceivedInAccounts
          mRet = Drawing.Color.DarkGoldenrod
        Case prkClaimStates.UnderProcessInAccounts
          mRet = Drawing.Color.DarkOrchid
        Case prkClaimStates.Paid, prkClaimStates.PartiallyPaid
          mRet = Drawing.Color.SteelBlue
      End Select
      Return mRet
    End Function
    Public ReadOnly Property Notification() As String
      Get
        Dim mRet As String = ""
        If ClaimStatusID = prkClaimStates.ReturnedByAccounts Then
          mRet = "<img alt='warning' src='../../images/Error.gif' style='height:14px; width:14px' /><b>" & AccountsRemarks & "</b>"
        End If
        Return mRet
      End Get
    End Property
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = False
      Select Case ClaimStatusID
        Case prkClaimStates.Free, prkClaimStates.ReturnedByAccounts
          mRet = True
      End Select
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function DeleteWF(ByVal ClaimID As Int32) As Integer
      Dim tmpClm As SIS.NPRK.nprkUserClaims = SIS.NPRK.nprkUserClaims.nprkUserClaimsGetByID(ClaimID)
      Select Case tmpClm.ClaimStatusID
        Case prkClaimStates.Free, prkClaimStates.ReturnedByAccounts
          Dim tmpApl As List(Of SIS.NPRK.nprkApplications) = SIS.NPRK.nprkApplications.nprkApplicationsSelectList(0, 9999, "", False, "", ClaimID)
          For Each tmpA As SIS.NPRK.nprkApplications In tmpApl
            Dim tmpBil As List(Of SIS.NPRK.nprkBillDetails) = SIS.NPRK.nprkBillDetails.nprkBillDetailsSelectList(0, 9999, "", False, "", tmpA.ApplicationID, tmpA.ClaimID)
            For Each tmpB As SIS.NPRK.nprkBillDetails In tmpBil
              SIS.NPRK.nprkBillDetails.nprkBillDetailsDelete(tmpB)
            Next
            If tmpA.ReportAttached Then
              Try
                IO.File.Delete(tmpA.ReportDiskFile)
              Catch ex As Exception
              End Try
            End If
            SIS.NPRK.nprkApplications.nprkApplicationsDelete(tmpA)
          Next
          SIS.NPRK.nprkUserClaims.nprkUserClaimsDelete(tmpClm)
      End Select
      Return 0
    End Function
    Public ReadOnly Property DeleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Select Case ClaimStatusID
          Case prkClaimStates.Free, prkClaimStates.ReturnedByAccounts
            mRet = True
        End Select
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Select Case ClaimStatusID
          Case prkClaimStates.Free, prkClaimStates.ReturnedByAccounts
            If TotalAmount > 0 Then
              mRet = True
            End If
        End Select
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function InitiateWF(ByVal ClaimID As Int32) As SIS.NPRK.nprkUserClaims
      Dim Results As SIS.NPRK.nprkUserClaims = nprkUserClaimsGetByID(ClaimID)
      Dim mCount As Integer = 0
      Dim sDt As String = ""
      Dim eDt As String = ""
      Select Case Now.Month
        Case 1, 2, 3
          sDt = "01/01/" & Now.Year
          eDt = "01/04/" & Now.Year
        Case 4, 5, 6
          sDt = "01/04/" & Now.Year
          eDt = "01/07/" & Now.Year
        Case 7, 8, 9
          'sDt = "01/07/" & Now.Year
          sDt = "25/08/" & Now.Year
          eDt = "01/10/" & Now.Year
        Case 10, 11, 12
          sDt = "01/10/" & Now.Year
          eDt = "01/01/" & Now.Year + 1
      End Select
      Dim Sql As String = ""
      Sql &= "Select count(ClaimID) as cnt from PRK_UserClaims where SubmittedOn >=Convert(DateTime,'" & sDt & "',103) AND SubmittedOn < Convert(DateTime,'" & eDt & "',103) AND CardNo ='" & Results.CardNo & "' AND ClaimStatusID IN (3,4,5,6)"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          mCount = Cmd.ExecuteScalar
        End Using
      End Using
      If mCount >= 3 Then
        Throw New Exception("Only 3 Claims can be submitted in a Quarter.")
      End If
      Dim LogBookRequired As Boolean = False
      Dim oEmp As SIS.NPRK.nprkEmployees = SIS.NPRK.nprkEmployees.GetByCardNo(Results.CardNo)
      If oEmp.VehicleOwnedByEmployee Then
        LogBookRequired = True
      End If
      Dim oClaimApplications As List(Of SIS.NPRK.nprkApplications) = SIS.NPRK.nprkApplications.UZ_nprkApplicationsSelectList(0, 99, "", False, "", ClaimID)
      'Route through Admin
      Dim VerifyDriverCharges As Boolean = False
      Dim LogBookAttached As Boolean = False
      Dim VehicleClaimed As Boolean = False
      For Each tmp As SIS.NPRK.nprkApplications In oClaimApplications
        If tmp.PerkID = prkPerk.DriverCharges Then
          Dim oBills As List(Of SIS.NPRK.nprkBillDetails) = SIS.NPRK.nprkBillDetails.nprkBillDetailsSelectList(0, 999, "", False, "", tmp.ApplicationID, tmp.ClaimID)
          For Each tmpBill As SIS.NPRK.nprkBillDetails In oBills
            If tmpBill.WithDriver Then
              VerifyDriverCharges = True
            End If
          Next
        End If
        If tmp.PerkID = prkPerk.VehicleRepairAndRunningExpense Then
          VehicleClaimed = True
          If tmp.ReportAttached Then
            LogBookAttached = True
          End If
        End If
      Next
      '-----
      If VehicleClaimed Then
        If LogBookRequired Then
          If Not LogBookAttached Then
            Throw New Exception("Pl. attach log book in Vehicle Repair and Running Expense, then forward.")
          End If
        End If
      End If
      With Results
        If VerifyDriverCharges Then
          .ClaimStatusID = prkClaimStates.UnderVerificationByAdmin
        Else
          .ClaimStatusID = prkClaimStates.SubmittedToAccounts
        End If
        .SubmittedOn = HttpContext.Current.Session("Today")
      End With
      SIS.NPRK.nprkUserClaims.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function UZ_nprkUserClaimsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ClaimStatusID As Int32) As List(Of SIS.NPRK.nprkUserClaims)
      Dim Results As List(Of SIS.NPRK.nprkUserClaims) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "ClaimID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprk_LG_UserClaimsSelectListSearch"
            Cmd.CommandText = "spnprkUserClaimsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprk_LG_UserClaimsSelectListFilteres"
            Cmd.CommandText = "spnprkUserClaimsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ClaimStatusID",SqlDbType.Int,10, IIf(ClaimStatusID = Nothing, 0,ClaimStatusID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.Int, 10, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkUserClaims)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkUserClaims(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_nprkUserClaimsInsert(ByVal Record As SIS.NPRK.nprkUserClaims) As SIS.NPRK.nprkUserClaims
      Record.forRef = GetRefNo()
      Record.ClaimRefNo = HttpContext.Current.Session("LoginID") & "/" & Record.forRef
      Record = nprkUserClaimsInsert(Record)
      Return Record
    End Function
    Public Shared Function UZ_nprkUserClaimsUpdate(ByVal Record As SIS.NPRK.nprkUserClaims) As SIS.NPRK.nprkUserClaims
      Dim _Result As SIS.NPRK.nprkUserClaims = nprkUserClaimsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_nprkUserClaimsDelete(ByVal Record As SIS.NPRK.nprkUserClaims) As Integer
      Dim _Result as Integer = nprkUserClaimsDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_ClaimID"), TextBox).Text = ""
          CType(.FindControl("F_Description"), TextBox).Text = ""
          CType(.FindControl("F_CardNo"), TextBox).Text = ""
          CType(.FindControl("F_CardNo_Display"), Label).Text = ""
          CType(.FindControl("F_PassedAmount"), TextBox).Text = 0
          CType(.FindControl("F_TotalAmount"), TextBox).Text = 0
          CType(.FindControl("F_DeclarationAccepted"), CheckBox).Checked = False
          CType(.FindControl("F_SubmittedOn"), TextBox).Text = ""
          CType(.FindControl("F_ReceivedOn"), TextBox).Text = ""
          CType(.FindControl("F_ReceivedBy"), TextBox).Text = ""
          CType(.FindControl("F_ReceivedBy_Display"), Label).Text = ""
          CType(.FindControl("F_ReturnedOn"), TextBox).Text = ""
          CType(.FindControl("F_ReturnedBy"), TextBox).Text = ""
          CType(.FindControl("F_ReturnedBy_Display"), Label).Text = ""
          CType(.FindControl("F_CompletedOn"), TextBox).Text = ""
          CType(.FindControl("F_AccountsRemarks"), TextBox).Text = ""
          CType(.FindControl("F_ClaimStatusID"), Object).SelectedValue = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function GetRefNo(Optional ByVal CardNo As String = "", Optional ByVal FinYear As Integer = 0) As String
      Dim tmp As Integer = 0
      If CardNo = String.Empty Then
        CardNo = HttpContext.Current.Session("LoginID")
      End If
      If FinYear = 0 Then
        FinYear = HttpContext.Current.Session("FinYear")
      End If
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Dim mSql As String = "SELECT MAX(ISNULL(forRef,0)) FROM [PRK_UserClaims] WHERE CardNo = '" & CardNo & "' and FinYear=" & FinYear
          Cmd.CommandType = System.Data.CommandType.Text
          Cmd.CommandText = mSql
          Con.Open()
          Try
            tmp = Cmd.ExecuteScalar()
            tmp += 1
          Catch ex As Exception
            tmp = 1
          End Try
        End Using
      End Using
      Return tmp
    End Function
    Public Shared Function UpdatePaid(ByVal ClaimID As Integer) As Boolean
      Dim mRet As Boolean = True
      Dim AllProcessed As Boolean = True
      Dim AnyRejected As Boolean = False
      Dim oClaim As SIS.NPRK.nprkUserClaims = SIS.NPRK.nprkUserClaims.nprkUserClaimsGetByID(ClaimID)
      Dim oClaimApplications As List(Of SIS.NPRK.nprkApplications) = SIS.NPRK.nprkApplications.UZ_nprkApplicationsSelectList(0, 99, "", False, "", ClaimID)
      For Each tmp As SIS.NPRK.nprkApplications In oClaimApplications
        Select Case tmp.StatusID
          Case prkPerkStates.UnderApproval, prkPerkStates.UnderPayment, prkPerkStates.UnderVerification
            AllProcessed = False
          Case prkPerkStates.Expired, prkPerkStates.Rejected
            AnyRejected = True
        End Select
      Next
      If AllProcessed Then
        If AnyRejected Then
          oClaim.ClaimStatusID = prkClaimStates.PartiallyPaid
        Else
          oClaim.ClaimStatusID = prkClaimStates.Paid
        End If
        SIS.NPRK.nprkUserClaims.UpdateData(oClaim)
      End If
      Return mRet
    End Function

    Public Shared Function ValidateClaim(ByVal ClaimID As Integer) As Boolean
      Dim mRet As Boolean = True
      Dim oClaim As SIS.NPRK.nprkUserClaims = SIS.NPRK.nprkUserClaims.nprkUserClaimsGetByID(ClaimID)
      Dim oClaimApplications As List(Of SIS.NPRK.nprkApplications) = SIS.NPRK.nprkApplications.UZ_nprkApplicationsSelectList(0, 99, "", False, "", ClaimID)
      '1. Initialize Claim
      With oClaim
        .TotalAmount = 0
        .PassedAmount = 0
        .Description = ""
      End With
      '2. Initialize Claim Application
      For Each tmp As SIS.NPRK.nprkApplications In oClaimApplications
        With tmp
          .Value = 0
          .VerifiedValue = 0
          .VerifiedAmt = 0
          .ApprovedValue = 0
          .ApprovedAmt = 0
          .ExcessClaimed = False
        End With
      Next
      '3. Update Bill Values in Application
      For Each tmp As SIS.NPRK.nprkApplications In oClaimApplications
        Dim oBills As List(Of SIS.NPRK.nprkBillDetails) = SIS.NPRK.nprkBillDetails.UZ_nprkBillDetailsSelectList(0, 9999, "", False, "", tmp.ClaimID, tmp.ApplicationID)
        For Each tm As SIS.NPRK.nprkBillDetails In oBills
          With tmp
            .Value += tm.Amount
            .VerifiedValue += tm.Quantity
            .VerifiedAmt += tm.Amount
            .ApprovedValue += tm.Quantity
            .ApprovedAmt += tm.Amount
          End With
          Select Case tmp.PerkID
            Case prkPerk.Mobile, prkPerk.Telephone
              If tmp.PerkID = prkPerk.Mobile Then
                If tm.Amount > tmp.FK_PRK_Applications_PRK_Employees.MobileLimit Then
                  tmp.ExcessClaimed = True
                End If
              ElseIf tmp.PerkID = prkPerk.Telephone Then
                If tm.Amount > tmp.FK_PRK_Applications_PRK_Employees.LandlineLimit Then
                  tmp.ExcessClaimed = True
                End If
              End If
          End Select
        Next
        '4. Check Balance and update 
        Select Case tmp.PerkID
          Case prkPerk.Mobile, prkPerk.Telephone  'Driver Charges will be validated against Ent, prkPerk.DriverCharges   ', prkPerk.EntertainmentExp
            'Do Nothing
          Case Else
            'Get Ledger Balance
            Dim eAmt As Decimal = SIS.NPRK.nprkEntitlements.GetNetValue(tmp.EmployeeID, tmp.PerkID, HttpContext.Current.Session("FinYear"))
            Dim pAmt As Decimal = SIS.NPRK.nprkLedger.GetNetValue(tmp.EmployeeID, tmp.PerkID, HttpContext.Current.Session("FinYear"))
            Dim tAmt As Decimal = eAmt + pAmt
            If tmp.Value > tAmt Then
              tmp.Value = tAmt
              tmp.VerifiedAmt = tAmt
              tmp.ApprovedAmt = tAmt
            End If
        End Select
        SIS.NPRK.nprkApplications.UpdateData(tmp)
      Next
      '4. Update Claim Values
      For Each tmp As SIS.NPRK.nprkApplications In oClaimApplications
        With oClaim
          .TotalAmount += tmp.Value
          .PassedAmount += tmp.ApprovedAmt
          If .Description = String.Empty Then
            .Description = tmp.FK_PRK_Applications_PRK_Perks.Description
          Else
            .Description &= ", " & tmp.FK_PRK_Applications_PRK_Perks.Description
          End If
        End With
      Next
      SIS.NPRK.nprkUserClaims.UpdateData(oClaim)
      Return mRet
    End Function
  End Class
End Namespace
