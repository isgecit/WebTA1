Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  Partial Public Class nprkBillDetails
    Private _Saved As Boolean = False
    Public Property Saved As Boolean
      Get
        Return _Saved
      End Get
      Set(value As Boolean)
        _Saved = value
      End Set
    End Property
    Public Property ClaimRefNo As String
      Get
        Return FK_PRK_BillDetails_ClaimID.ClaimRefNo
      End Get
      Set(value As String)

      End Set
    End Property
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
      Return mRet
    End Function
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
      mRet = FK_PRK_BillDetails_ClaimID.Editable
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
    Public ReadOnly Property DeleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DeleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function DeleteWF(ByVal ClaimID As Int32, ByVal ApplicationID As Int32, ByVal AttachmentID As Int32, ByVal BillNo As String, ByVal BillDate As DateTime, ByVal FromDate As DateTime, ByVal ToDate As DateTime, ByVal Particulars As String, ByVal Quantity As Decimal, ByVal Amount As Decimal) As SIS.NPRK.nprkBillDetails
      Dim Results As SIS.NPRK.nprkBillDetails = nprkBillDetailsGetByID(ClaimID, ApplicationID, AttachmentID)
      Return Results
    End Function
    Public Shared Function UZ_nprkBillDetailsSelectListForNew(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ClaimID As Int32, ByVal ApplicationID As Int32) As List(Of SIS.NPRK.nprkBillDetails)
      Dim Results As List(Of SIS.NPRK.nprkBillDetails) = Nothing
      Results = New List(Of SIS.NPRK.nprkBillDetails)()
      Dim tmp As SIS.NPRK.nprkApplications = SIS.NPRK.nprkApplications.nprkApplicationsGetByID(ClaimID, ApplicationID)
      For i As Integer = 1 To 10
        Dim x As New SIS.NPRK.nprkBillDetails
        With x
          .ClaimID = ClaimID
          .ApplicationID = ApplicationID
          .SerialNo = i
          .ClaimRefNo = tmp.ClaimRefNo
          .Quantity = 0.00
          .Amount = 0.00
        End With
        Results.Add(x)
      Next
      RecordCount = 10
      Return Results
    End Function
    Public Shared Function UZ_DriverBillsByClaimID(ByVal ClaimID As String) As List(Of SIS.NPRK.nprkBillDetails)
      Dim tmpApls As List(Of SIS.NPRK.nprkApplications) = SIS.NPRK.nprkApplications.UZ_nprkApplicationsSelectList(0, 999, "", False, "", ClaimID)
      Dim ApplicationID As String = ""
      For Each tmp As SIS.NPRK.nprkApplications In tmpApls
        If tmp.PerkID = prkPerk.DriverCharges Then
          ApplicationID = tmp.ApplicationID
          Exit For
        End If
      Next
      Dim Results As List(Of SIS.NPRK.nprkBillDetails) = Nothing
      If ApplicationID <> String.Empty Then
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "select * from PRK_BillDetails where ClaimID=" & ClaimID & " and ApplicationID=" & ApplicationID
            Results = New List(Of SIS.NPRK.nprkBillDetails)()
            Con.Open()
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            While (Reader.Read())
              Results.Add(New SIS.NPRK.nprkBillDetails(Reader))
            End While
            Reader.Close()
          End Using
        End Using
      End If
      Return Results
    End Function


    Public Shared Function UZ_nprkBillDetailsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ClaimID As Int32, ByVal ApplicationID As Int32) As List(Of SIS.NPRK.nprkBillDetails)
      Dim Results As List(Of SIS.NPRK.nprkBillDetails) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprk_LG_BillDetailsSelectListSearch"
            Cmd.CommandText = "spnprkBillDetailsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprk_LG_BillDetailsSelectListFilteres"
            Cmd.CommandText = "spnprkBillDetailsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ClaimID", SqlDbType.Int, 10, IIf(ClaimID = Nothing, 0, ClaimID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ApplicationID", SqlDbType.Int, 10, IIf(ApplicationID = Nothing, 0, ApplicationID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkBillDetails)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkBillDetails(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_nprkBillDetailsInsert(ByVal Record As SIS.NPRK.nprkBillDetails) As SIS.NPRK.nprkBillDetails
      Record = SetBillDetails(Record)
      Dim _Result As SIS.NPRK.nprkBillDetails = nprkBillDetailsInsert(Record)
      Return _Result
    End Function
    Public Shared Sub UZ_nprkBillDetailsVerifiedByAdmin(ByVal ClaimID As Integer, ByVal ApplicationID As Integer, ByVal AttachmentID As Integer, ByVal Verified As String)
      Dim Rec As SIS.NPRK.nprkBillDetails = SIS.NPRK.nprkBillDetails.nprkBillDetailsGetByID(ClaimID, ApplicationID, AttachmentID)
      If Rec.WithDriver Then
        If Verified <> "YES" Then
          Dim apl As SIS.NPRK.nprkApplications = SIS.NPRK.nprkApplications.nprkApplicationsGetByID(ClaimID, ApplicationID)
          apl.VerifiedValue -= 1500
          apl.VerifiedAmt -= 1500
          apl.ApprovedAmt -= 1500
          apl.ApprovedValue -= 1500
          SIS.NPRK.nprkApplications.UpdateData(apl)
          Dim clm As SIS.NPRK.nprkUserClaims = SIS.NPRK.nprkUserClaims.nprkUserClaimsGetByID(ClaimID)
          clm.PassedAmount -= 1500
          SIS.NPRK.nprkUserClaims.UpdateData(clm)
        End If
      End If
      Rec.VerifiedByAdmin = IIf(Verified = "YES", True, False)
      SIS.NPRK.nprkBillDetails.UpdateData(Rec)
    End Sub
    Public Shared Function UZ_nprkBillDetailsUpdate(ByVal Record As SIS.NPRK.nprkBillDetails) As SIS.NPRK.nprkBillDetails
      Record = SetBillDetails(Record)
      Dim _Rec As SIS.NPRK.nprkBillDetails = SIS.NPRK.nprkBillDetails.nprkBillDetailsGetByID(Record.ClaimID, Record.ApplicationID, Record.AttachmentID)
      With _Rec
        .BillNo = Record.BillNo
        .BillDate = Record.BillDate
        .FromDate = Record.FromDate
        .ToDate = Record.ToDate
        .Description = Record.Description
        .Particulars = Record.Particulars
        Select Case _Rec.FK_PRK_BillDetails_PRK_Applications.PerkID
          Case prkPerk.DriverCharges, prkPerk.EntertainmentExp
            .Quantity = Record.Amount
            .Amount = Record.Amount
          Case prkPerk.Mediclaim, prkPerk.CarInsurance, prkPerk.VehicleRepairAndRunningExpense, prkPerk.Uniform, prkPerk.NewspaperMagazine, prkPerk.BalanceMedical
            .Quantity = Record.Quantity
            .Amount = Record.Quantity
          Case prkPerk.Telephone, prkPerk.Mobile
            .Quantity = Record.Quantity
            .Amount = Record.Amount
          Case Else
            .Quantity = Record.Quantity
            .Amount = Record.Amount
        End Select
        .SerialNo = 0
      End With
      If _Rec.FK_PRK_BillDetails_PRK_Applications.PerkID = prkPerk.DriverCharges Then
        If _Rec.EntitlementID <> String.Empty Then
          Dim tmpEnt As SIS.NPRK.nprkEntitlements = SIS.NPRK.nprkEntitlements.nprkEntitlementsGetByID(_Rec.EntitlementID)

          If _Rec.WithDriver = Record.WithDriver Then
          ElseIf Not _Rec.WithDriver And Record.WithDriver Then
            _Rec.Quantity += 1500
            _Rec.Amount += 1500
            _Rec.WithDriver = True
            tmpEnt.Value += 1500
            tmpEnt.WithDriver = True
            SIS.NPRK.nprkEntitlements.UpdateData(tmpEnt)
          ElseIf _Rec.WithDriver And Not Record.WithDriver Then
            _Rec.Quantity -= 1500
            _Rec.Amount -= 1500
            _Rec.WithDriver = False
            tmpEnt.Value -= 1500
            tmpEnt.WithDriver = False
            SIS.NPRK.nprkEntitlements.UpdateData(tmpEnt)
          End If
        End If
      End If
      Record = SIS.NPRK.nprkBillDetails.UpdateData(_Rec)
      SIS.NPRK.nprkUserClaims.ValidateClaim(Record.ClaimID)
      Return Record
    End Function
    Public Shared Function SetBillDetails(ByVal Record As SIS.NPRK.nprkBillDetails) As SIS.NPRK.nprkBillDetails
      Dim oPrk As SIS.NPRK.nprkPerks = Record.FK_PRK_BillDetails_PRK_Applications.FK_PRK_Applications_PRK_Perks
      Select Case oPrk.PerkID
        Case prkPerk.DriverCharges
          Record.Description = oPrk.Description & " for the period, from " & Record.FromDate & " to " & Record.ToDate
          Record.Particulars = Record.Description
        Case prkPerk.Mediclaim
          Record.Description = oPrk.Description & " for the policy period, from " & Record.FromDate & " to " & Record.ToDate
        Case prkPerk.NewspaperMagazine, prkPerk.Uniform, prkPerk.Petrol, prkPerk.CarMaintenance, prkPerk.TwoWheelerMaint, prkPerk.MedicalBenifit
          Record.Description = oPrk.Description
        Case prkPerk.Telephone, prkPerk.Mobile
          Record.Description = oPrk.Description & " for the period, from " & Record.FromDate & " to " & Record.ToDate & " Bill Amount " & Record.Quantity
      End Select
      Return Record
    End Function
    Public Shared Function UZ_nprkBillDetailsDelete(ByVal Record As SIS.NPRK.nprkBillDetails) As Integer
      Record = SIS.NPRK.nprkBillDetails.nprkBillDetailsGetByID(Record.ClaimID, Record.ApplicationID, Record.AttachmentID)
      Dim _Result As Integer = nprkBillDetailsDelete(Record)
      Select Case Record.FK_PRK_BillDetails_PRK_Applications.PerkID
        Case prkPerk.DriverCharges
          Try
            Dim tmp As SIS.NPRK.nprkEntitlements = SIS.NPRK.nprkEntitlements.nprkEntitlementsGetByID(Record.EntitlementID)
            tmp.Selected = False
            SIS.NPRK.nprkEntitlements.UpdateData(tmp)
          Catch ex As Exception
          End Try
      End Select
      SIS.NPRK.nprkUserClaims.ValidateClaim(Record.ClaimID)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      On Error Resume Next
      With sender
        CType(.FindControl("F_ClaimID"), TextBox).Text = ""
        CType(.FindControl("F_ClaimID_Display"), Label).Text = ""
        CType(.FindControl("F_ApplicationID"), TextBox).Text = ""
        CType(.FindControl("F_ApplicationID_Display"), Label).Text = ""
        CType(.FindControl("F_AttachmentID"), TextBox).Text = ""
        CType(.FindControl("F_SerialNo"), TextBox).Text = 0
        CType(.FindControl("F_BillNo"), TextBox).Text = ""
        CType(.FindControl("F_BillDate"), TextBox).Text = ""
        CType(.FindControl("F_FromDate"), TextBox).Text = ""
        CType(.FindControl("F_ToDate"), TextBox).Text = ""
        CType(.FindControl("F_Particulars"), TextBox).Text = ""
        CType(.FindControl("F_Quantity"), TextBox).Text = 0
        CType(.FindControl("F_Amount"), TextBox).Text = 0
      End With
      Return sender
    End Function
    Public Shared Sub ValidateData(ByVal FV As FormView, ByVal Sender As Object)
      Dim ci As System.Globalization.CultureInfo = SIS.SYS.Utilities.SessionManager.ci
      Dim fy As SIS.NPRK.nprkFinYears = SIS.NPRK.nprkFinYears.nprkFinYearsGetByID(HttpContext.Current.Session("FinYear"))
      Dim DateErr As String = ""
      Dim oApl As SIS.NPRK.nprkApplications = SIS.NPRK.nprkApplications.nprkApplicationsGetByID(CType(FV.FindControl("F_ClaimID"), TextBox).Text, CType(FV.FindControl("F_ApplicationID"), TextBox).Text)
      Dim oPRK As SIS.NPRK.nprkPerks = oApl.FK_PRK_Applications_PRK_Perks
      Try
        Dim fdt As TextBox = Nothing
        Dim tdt As TextBox = Nothing
        Dim tmp As TextBox = CType(Sender, TextBox)
        If tmp.ID = "F_FromDate" Then
          tdt = CType(FV.FindControl("F_ToDate"), TextBox)
          fdt = tmp
        Else
          tdt = tmp
          fdt = CType(FV.FindControl("F_FromDate"), TextBox)
        End If
        If fdt.Text = "__/__/____" Then fdt.Text = ""
        If tdt.Text = "__/__/____" Then tdt.Text = ""
        If fdt.Text <> String.Empty And tdt.Text <> String.Empty Then
          If Convert.ToDateTime(fdt.Text, ci) > Convert.ToDateTime(tdt.Text, ci) Then
            DateErr = "Inalid Period- FROM Date is greater than TO Date."
            tmp.Text = ""
          ElseIf oPRK.PerkID = prkPerk.Uniform Then
            Dim bDt As TextBox = CType(FV.FindControl("F_BillDate"), TextBox)
            If bDt.Text = "__/__/____" Then bDt.Text = ""
            If bDt.Text <> String.Empty Then
              If Convert.ToDateTime(bDt.Text, ci) < Convert.ToDateTime(fy.StartDate, ci) Or Convert.ToDateTime(bDt.Text, ci) > Convert.ToDateTime(fy.EndDate, ci) Then
                DateErr = "Bill Date is not in financial year."
              End If
            End If
          End If
        ElseIf fdt.Text <> String.Empty And tdt.Text = String.Empty Then
          Dim dt As DateTime = Convert.ToDateTime(fdt.Text, ci)
          Select Case oPRK.PerkID
            Case prkPerk.Mediclaim
              tdt.Text = dt.AddYears(1).AddDays(-1).ToString("dd/MM/yyyy")
            Case prkPerk.DriverCharges, prkPerk.NewspaperMagazine
              Select Case dt.Month
                Case 1, 2, 3
                  tdt.Text = dt.AddMonths(4 - dt.Month).AddDays(-1).ToString("dd/MM/yyyy")
                Case 4, 5, 6
                  tdt.Text = dt.AddMonths(7 - dt.Month).AddDays(-1).ToString("dd/MM/yyyy")
                Case 7, 8, 9
                  tdt.Text = dt.AddMonths(10 - dt.Month).AddDays(-1).ToString("dd/MM/yyyy")
                Case 10, 11, 12
                  tdt.Text = dt.AddMonths(13 - dt.Month).AddDays(-1).ToString("dd/MM/yyyy")
                Case Else
                  tdt.Text = fdt.Text
              End Select
            Case prkPerk.Uniform
              tdt.Text = dt.AddMonths(7).AddDays(-1).ToString("dd/MM/yyyy")
            Case prkPerk.Telephone, prkPerk.Mobile
              tdt.Text = dt.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy")
          End Select
        ElseIf fdt.Text = String.Empty And tdt.Text <> String.Empty Then
          fdt.Text = tdt.Text
        End If
      Catch ex As Exception
        DateErr = ex.Message
      End Try
      If DateErr <> String.Empty Then
        Dim ex As New Exception
        ex.Data("ExtraInfo") = DateErr
        Throw ex
      End If
    End Sub
    Public Shared Sub CustomizeView(ByVal FV As FormView, ByVal Claimid As Integer, ByVal ApplicationID As Integer)
      Dim oApl As SIS.NPRK.nprkApplications = SIS.NPRK.nprkApplications.nprkApplicationsGetByID(Claimid, ApplicationID)
      Dim oPRK As SIS.NPRK.nprkPerks = oApl.FK_PRK_Applications_PRK_Perks
      Dim lblDeclaration As Label = CType(FV.FindControl("lblDeclaration"), Label)
      Dim rowBillNo As HtmlTableRow = CType(FV.FindControl("rowBillNo"), HtmlTableRow)
      Dim rowFromDate As HtmlTableRow = CType(FV.FindControl("rowFromDate"), HtmlTableRow)
      Dim rowParticulars As HtmlTableRow = CType(FV.FindControl("rowParticulars"), HtmlTableRow)
      Dim rowBillAmount As HtmlTableRow = CType(FV.FindControl("rowBillAmount"), HtmlTableRow)
      Dim rowClaimedAmount As HtmlTableRow = CType(FV.FindControl("rowClaimedAmount"), HtmlTableRow)
      Dim rowWithDriver As HtmlTableRow = CType(FV.FindControl("rowWithDriver"), HtmlTableRow)
      Dim lblPerk As Label = CType(FV.FindControl("Lbl_Perk"), Label)
      lblPerk.Text = oPRK.Description
      rowWithDriver.Visible = False
      Select Case oPRK.PerkID
        Case prkPerk.DriverCharges
          lblDeclaration.Text = "Please pay me driver charges for the period mentioned below.<br/> I declarae that I have engaged a Personal Driver."
          rowBillNo.Visible = False
          rowParticulars.Visible = False
          rowBillAmount.Visible = False
          rowWithDriver.Visible = True
        Case prkPerk.Mediclaim
          lblDeclaration.Text = "I request reimbursement of expense towards Medical Insurance (Mediclaim).<br/> As per company policy."
          CType(FV.FindControl("L_BillNo"), Label).Text = "Policy No.: "
          CType(FV.FindControl("L_BillDate"), Label).Text = "Policy Issue Date.: "
          CType(FV.FindControl("L_FromDate"), Label).Text = "Policy Period From Date.: "
          CType(FV.FindControl("L_Quantity"), Label).Text = "Policy Premium : "
          rowClaimedAmount.Visible = False
        Case prkPerk.CarInsurance
          lblDeclaration.Text = "I request reimbursement of expense towards Car Insurance.<br/> As per company policy."
          CType(FV.FindControl("L_BillNo"), Label).Text = "Policy No.: "
          CType(FV.FindControl("L_BillDate"), Label).Text = "Policy Issue Date.: "
          CType(FV.FindControl("L_FromDate"), Label).Text = "Policy Period From Date.: "
          CType(FV.FindControl("L_Quantity"), Label).Text = "Policy Premium : "
          rowClaimedAmount.Visible = False
        Case prkPerk.VehicleRepairAndRunningExpense
          lblDeclaration.Text = "I request reimbursement of expense towards running & maintenance of my vehicle,<br/> while I was on official duty."
          rowClaimedAmount.Visible = False
          rowFromDate.Visible = False
        Case prkPerk.Uniform
          lblDeclaration.Text = "I request reimbursement of expense towards purchase of Uniform.<br/> As per Dress Code mentioned in Organization Office Order JMD No. 263."
          CType(FV.FindControl("L_Particulars"), Label).Text = "Item & Shop Details : "
          rowFromDate.Visible = False
          rowClaimedAmount.Visible = False
        Case prkPerk.NewspaperMagazine
          lblDeclaration.Text = "I request reimbursement of expense towards purchase of Newspaper,<br/> Magazine & Professional Books."
          CType(FV.FindControl("L_Particulars"), Label).Text = "Magazine/Book & Vendor Details : "
          rowFromDate.Visible = False
          rowClaimedAmount.Visible = False
        Case prkPerk.BalanceMedical
          lblDeclaration.Text = "I request reimbursement of medical expense under Company's scheme."
          CType(FV.FindControl("L_Particulars"), Label).Text = "Doctor / Shop Details : "
          rowClaimedAmount.Visible = False
          rowFromDate.Visible = False
        Case prkPerk.Telephone, prkPerk.Mobile
          lblDeclaration.Text = "I request reimbursement of Landline/Mobile expense. <br/>As per allowed limit."
          CType(FV.FindControl("L_Particulars"), Label).Text = "Subscriber / Plan Details : "
          CType(FV.FindControl("L_FromDate"), Label).Text = "Bill Period From Date.: "
        Case prkPerk.EntertainmentExp
          lblDeclaration.Text = "I request reimbursement of Entertainment expense. <br/>As per allowed limit."
          CType(FV.FindControl("L_Particulars"), Label).Text = "Expense Details : "
          rowBillNo.Visible = False
          rowBillAmount.Visible = False
          rowFromDate.Visible = False
      End Select
    End Sub
    Public Shared Function GetDeclaration(ByVal PerkID As Integer) As String
      Select Case PerkID
        Case prkPerk.DriverCharges
          Return "Please pay me driver charges for the period mentioned below.<br/> I declarae that I have engaged a Personal Driver."
        Case prkPerk.VehicleRepairAndRunningExpense
          Return "I request reimbursement of expense towards running & maintenance of my vehicle,<br/> while I was on official duty."
        Case prkPerk.Telephone, prkPerk.Mobile
          Return "I request reimbursement of Landline/Mobile expense. <br/>As per allowed limit."
        Case prkPerk.BalanceMedical, prkPerk.MedicalBenifit
          Return "I request reimbursement of medical expense under Company's scheme."
        Case prkPerk.Mediclaim
          Return "I request reimbursement of expense towards Medical Insurance (Mediclaim).<br/> As per company policy."
        Case prkPerk.CarInsurance
          Return "I request reimbursement of expense towards Car Insurance.<br/> As per company policy."
        Case prkPerk.Uniform
          Return "I request reimbursement of expense towards purchase of Uniform.<br/> As per Dress Code mentioned in Organization Office Order JMD No. 263."
        Case prkPerk.NewspaperMagazine
          Return "I request reimbursement of expense towards purchase of Newspaper,<br/> Magazine & Professional Books."
        Case prkPerk.EntertainmentExp
          Return "I request reimbursement of Entertainment expense. <br/>As per allowed limit."
      End Select
      Return ""
    End Function
    Public Shared Sub FormatGrid(ByVal GV As GridView, ByVal PerkID As Integer)
      With GV
        Select Case PerkID
          Case prkPerk.DriverCharges
            .Columns(4).HeaderText = "PERIOD FROM"
            .Columns(1).Visible = False
            .Columns(2).Visible = False
            .Columns(3).Visible = False
            .Columns(6).Visible = False
          Case prkPerk.VehicleRepairAndRunningExpense
            .Columns(4).Visible = False
            .Columns(5).Visible = False
            .Columns(7).Visible = False
          Case prkPerk.Telephone, prkPerk.Mobile
            .Columns(3).HeaderText = "SUBSCRIBER / PLAN DETAILS"
            .Columns(4).HeaderText = "PERIOD FROM"
          Case prkPerk.BalanceMedical, prkPerk.MedicalBenifit
            .Columns(3).HeaderText = "Doctor / Shop Details"
            .Columns(4).Visible = False
            .Columns(5).Visible = False
            .Columns(7).Visible = False
          Case prkPerk.Mediclaim
            .Columns(1).HeaderText = "POLICY No."
            .Columns(2).HeaderText = "ISSUE DATE"
            .Columns(3).HeaderText = "POLICY COMPANY"
            .Columns(4).HeaderText = "PERIOD FROM"
            .Columns(6).HeaderText = "PREMIUM PAID"
            .Columns(7).Visible = False
          Case prkPerk.CarInsurance
            .Columns(1).HeaderText = "POLICY No."
            .Columns(2).HeaderText = "ISSUE DATE"
            .Columns(3).HeaderText = "POLICY COMPANY"
            .Columns(4).HeaderText = "PERIOD FROM"
            .Columns(6).HeaderText = "PREMIUM PAID"
            .Columns(7).Visible = False
          Case prkPerk.Uniform
            .Columns(3).HeaderText = "ITEM & SHOP DETAILS"
            .Columns(4).Visible = False
            .Columns(5).Visible = False
            .Columns(7).Visible = False
          Case prkPerk.NewspaperMagazine
            .Columns(3).HeaderText = "MAGAZINE/BOOK & VENDOR DETAILS"
            .Columns(4).Visible = False
            .Columns(5).Visible = False
            .Columns(7).Visible = False
          Case prkPerk.EntertainmentExp
            .Columns(3).HeaderText = "EXPENSE DETAILS"
            .Columns(1).Visible = False
            .Columns(2).Visible = False
            .Columns(4).Visible = False
            .Columns(5).Visible = False
            .Columns(6).Visible = False
        End Select
      End With

    End Sub
  End Class

End Namespace
