Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.Mail
Imports System.Net.Mail
Namespace SIS.TA
  Partial Public Class taBH
    Public ReadOnly Property GetAttachLink() As String
      Get
        Dim mRet As String = HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority
        If HttpContext.Current.Request.Url.Authority.ToLower = "localhost" Then
          mRet = "http://192.9.200.146"
        End If
        mRet &= "/Attachment/Attachment.aspx?AthHandle=J_TABILL"
        Dim Index As String = TABillNo
        Dim User As String = HttpContext.Current.Session("LoginID")
        User = 1
        Dim canEdit As String = "n"
        If Editable Then
          canEdit = "y"
        End If
        Return mRet & "&Index=" & Index & "&AttachedBy=" & User & "&ed=" & canEdit
      End Get
    End Property
    Public ReadOnly Property GetNotesLink() As String
      Get
        Dim mRet As String = HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority
        If HttpContext.Current.Request.Url.Authority.ToLower = "localhost" Then
          mRet = "http://192.9.200.146"
        End If
        mRet &= "/Attachment/Notes.aspx?handle=J_TABILL"
        Dim Index As String = TABillNo
        Dim User As String = EmployeeID
        Dim canEdit As String = "y"
        Return mRet & "&Index=" & Index & "&user=" & User & "&ed=" & canEdit
      End Get
    End Property
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      Select Case BillStatusID
        Case TAStates.ReturnedByAccounts, TAStates.ReturnedByApprover, TAStates.ReturnedBySanctioningAuthority, TAStates.ReturnedByVerifier
          mRet = Drawing.Color.Red
        Case TAStates.UnderReceiveByAccounts
          mRet = Drawing.Color.DarkOrange
        Case TAStates.UnderProcessByAccounts
          mRet = Drawing.Color.Green
        Case TAStates.UnderApproval, TAStates.UnderSpecialSanction
          mRet = Drawing.Color.DarkOrchid
        Case TAStates.BillVerified, TAStates.UnderVoucherUpdation
          mRet = Drawing.Color.Blue
        Case TAStates.UnderVerification
          mRet = Drawing.Color.DarkMagenta
        Case TAStates.VoucherUpdated
          mRet = Drawing.Color.DarkGoldenrod
        Case TAStates.UnderHoldByAccounts
          mRet = Drawing.Color.DarkViolet
      End Select
      Return mRet
    End Function
    Public ReadOnly Property Notification() As String
      Get
        Dim mRet As String = ""
        Dim mMsg As String = ""
        Select Case BillStatusID
          Case TAStates.ReturnedByAccounts, TAStates.ReturnedByApprover, TAStates.ReturnedBySanctioningAuthority, TAStates.ReturnedByVerifier
            If BillStatusID = TAStates.ReturnedByAccounts Then
              mMsg = OOERemarks
            ElseIf BillStatusID = TAStates.ReturnedByVerifier Then
            ElseIf BillStatusID = TAStates.ReturnedByApprover Then
            ElseIf BillStatusID = TAStates.ReturnedBySanctioningAuthority Then
            End If
            mRet = "<img alt='warning' src='../../images/Error.gif' style='height:14px; width:14px' /><b>" & mMsg & "</b>"
        End Select
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
      Select Case BillStatusID
        Case TAStates.ReturnedByAccounts, TAStates.ReturnedByApprover, TAStates.ReturnedBySanctioningAuthority, TAStates.Free, TAStates.ReturnedByVerifier
          mRet = True
      End Select
      Return mRet
    End Function
    Public ReadOnly Property HeaderEditable As Boolean
      Get
        Dim mRet As Boolean = True
        If TotalClaimedAmount > 0 Then
          mRet = False
        End If
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property EditableByAccounts As Boolean
      Get
        Dim mRet As Boolean = False
        Select Case BillStatusID
          Case TAStates.UnderProcessByAccounts
            mRet = True
        End Select
        Return mRet
      End Get
    End Property

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

    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case BillStatusID
            Case TAStates.Free, TAStates.ReturnedByAccounts, TAStates.ReturnedByApprover, TAStates.ReturnedBySanctioningAuthority, TAStates.ReturnedByVerifier
              If TotalClaimedAmount > 0 Then
                mRet = True
              End If
          End Select
        Catch ex As Exception
        End Try
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
    Private Shared Function GetElementID(ByVal ProjectID As String) As String
      Dim mRet As String = "99250100"
      Dim Sql As String = ""
      Sql = " Select "
      Sql &= " ISNULL(ElementID,'') as Element "
      Sql &= " From TA_ProjectElement "
      Sql &= " Where ProjectID = '" & ProjectID & "'"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Dim tmp As String = ""
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          tmp = Cmd.ExecuteScalar
          If tmp IsNot Nothing Then
            If tmp <> String.Empty Then
              mRet = tmp
            End If
          End If
        End Using
      End Using
      Return mRet
    End Function
    Public Shared Function GetAvailableSanctionInERP(ByVal ProjectID As String, Optional ByRef Element As String = "") As Double
      Dim mRet As Double = 0
      Dim ElementID As String = GetElementID(ProjectID)
      Element = ElementID
      Dim Sql As String = ""
      Sql = " Select "
      Sql &= " (ISNULL(t_totl,0) - ISNuLL(t_exha,0) - ISNULL(t_smnt,0)) As BalAmt "
      Sql &= " From ttpisg012200 "
      Sql &= " Where t_cprj = '" & ProjectID & "'"
      Sql &= " and t_elem = '" & ElementID & "'"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          mRet = Cmd.ExecuteScalar
        End Using
      End Using
      Return mRet
    End Function
    Public Shared Function SanctionAvailable(ByVal TABillNo As Integer) As Boolean
      Dim mRet As Boolean = True
      Dim pAmts As List(Of SIS.TA.taBillPrjAmounts) = SIS.TA.taBillPrjAmounts.taBillPrjAmountsSelectList(0, 999, "", False, "", TABillNo)
      For Each pAmt As SIS.TA.taBillPrjAmounts In pAmts
        Dim tmpSamt As Double = GetAvailableSanctionInERP(pAmt.ProjectID)
        If tmpSamt < 0 Then
          mRet = False
          Exit For
        ElseIf tmpSamt - pAmt.TotalAmountinINR < 0 Then
          mRet = False
          Exit For
        End If
      Next
      Return mRet
    End Function
    Public Shared Function SanctionAvailableHTML(ByVal TABillNo As Integer) As String
      Dim mRet As String = "<table style='margin:20px auto auto auto;' cellspacing='1' cellpadding='1' border='1'>"
      mRet &= "<thead><tr><th>Project</th><th>Element</th><th>Available Budget</th><th>Required in TA Bill</th><th>Balance<br/>[After this Bill]</th></tr></thead>"
      Dim pAmts As List(Of SIS.TA.taBillPrjAmounts) = SIS.TA.taBillPrjAmounts.taBillPrjAmountsSelectList(0, 999, "", False, "", TABillNo)
      If pAmts.Count <= 0 Then
        mRet &= "<tr><td colspan='5' style='color:green;text-align:center;'>This TA Bill does not require Project Budget.</td></tr>"
      End If
      For Each pAmt As SIS.TA.taBillPrjAmounts In pAmts
        Dim Element As String = ""
        Dim tmpSamt As Double = GetAvailableSanctionInERP(pAmt.ProjectID, Element)
        mRet &= "<tr><td>" & pAmt.ProjectID & "</td><td style='text-align:center'>" & Element & "</td><td style='text-align:center'>" & tmpSamt.ToString("n") & "</td><td style='text-align:center'>" & pAmt.TotalAmountinINR.ToString("n") & "</td><td style='text-align:center'>" & (tmpSamt - pAmt.TotalAmountinINR).ToString("n") & "</td></tr>"
      Next
      If pAmts.Count > 0 Then
        mRet &= "<tr><td colspan='5' style='color:red;'>NOTE:=&gt;TA Bill will NOT be submitted, if balance is negative in (any) project.<br/>Contact Project Manager to enter budget if required.</td></tr>"
      End If
      mRet &= "</table>"
      Return mRet
    End Function

    Public Shared Function InitiateWF(ByVal TABillNo As Int32) As SIS.TA.taBH
      Dim Results As SIS.TA.taBH = taBHGetByID(TABillNo)
      If Results.FK_TA_Bills_EmployeeID.TASelfApproval = False Then
        If Results.FK_TA_Bills_EmployeeID.TAApprover = "" Then
          Throw New Exception("Approver of TA Bill NOT Defined, can not forward. Pl. get it defined it first.")
        End If
        If Results.OOEBySystem Then
          If Results.FK_TA_Bills_EmployeeID.TASanctioningAuthority = "" Then
            If Not Results.SanctionAttached Then
              Throw New Exception("This TA Bill requires special sanction and Sanctioning Authority is not defined, can not forward.")
            End If
          End If
        End If
      End If
      'In Foreign Travel, It is mandatory to Enter Finance Source
      If Results.TravelTypeID <> TATravelTypeValues.Domestic AndAlso Results.TravelTypeID <> TATravelTypeValues.HomeVisit Then
        Dim sTmps As List(Of SIS.TA.taBDFinance) = SIS.TA.taBDFinance.taBDFinanceSelectList(0, 999, "", False, "", Results.TABillNo)
        If sTmps.Count <= 0 Then
          Throw New Exception("Source of Finance entry NOT found. Can NOT forward. Pl. enter it first.")
        End If
      End If
      'Sanction Check
      If Not SanctionAvailable(TABillNo) Then
        Throw New Exception("Budget NOT Available, Pl. check the budget status and contact project managet to put extra budget in Project/Element.")
      End If
      'Duplicate Check
      Dim DuplicateBillNo As Integer = 0
      If DuplicateTABill(Results, DuplicateBillNo) Then
        Throw New Exception("TA Bill has already been submitted for the period mentioned in this bill. " & DuplicateBillNo)
      End If
      'Older Than 2 Year
      If Convert.ToDateTime(Results.EndDateTime) < Now.AddYears(-2) Then
        Throw New Exception("TA Bill older than 2 Years is NOT allowed to be submitted online, Contact A/c Department for settlement.")
      End If
      '============
      Dim selfApproval As Boolean = Results.FK_TA_Bills_EmployeeID.TASelfApproval
      Dim sendMail As Boolean = False
      'Check Values in Last Approved TA Bill
      Dim IsValueChanged As Integer = TAValueChanged.Fresh
      '0=Last Submitted TA Bill Not Found
      '1=No Change In TA Bill
      '2=Value Changed in TA Bill
      Dim oLast As SIS.TA.taBillLast = SIS.TA.taBillLast.taBillLastGetByID(TABillNo)
      If oLast IsNot Nothing Then
        If oLast.TotalClaimedAmount = Results.TotalClaimedAmount AndAlso oLast.TotalFinancedAmount = Results.TotalFinancedAmount _
          AndAlso oLast.OOEBySystem = Results.OOEBySystem AndAlso oLast.OOEBySystem = False Then
          IsValueChanged = TAValueChanged.ValueNotChanged
        Else
          IsValueChanged = TAValueChanged.ValueChanged
        End If
      End If
      With Results
        .ForwardedOn = Now
        Select Case IsValueChanged
          Case TAValueChanged.Fresh, TAValueChanged.ValueChanged
            If selfApproval Then
              .BillStatusID = TAStates.UnderReceiveByAccounts
            ElseIf .FK_TA_Bills_EmployeeID.TAVerifier <> String.Empty Then
              .BillStatusID = TAStates.UnderVerification
              sendMail = True
            ElseIf .FK_TA_Bills_EmployeeID.TAApprover <> String.Empty Then
              .BillStatusID = TAStates.UnderApproval
              sendMail = True
            Else
              If Results.OOEBySystem Then
                If Results.SanctionAttached Then
                  .BillStatusID = TAStates.UnderReceiveByAccounts
                Else
                  .BillStatusID = TAStates.UnderSpecialSanction
                  sendMail = True
                End If
              Else
                .BillStatusID = TAStates.UnderReceiveByAccounts
              End If
            End If
            .ApprovedBy = ""
            .ApprovedOn = ""
            .ApprovalRemarks = ""
            .ApprovedByCC = ""
            .ApprovedByCCOn = ""
            .CCRemarks = ""
            .ApprovedBySA = ""
            .ApprovedBySAOn = ""
            .SARemarks = ""
          Case TAValueChanged.ValueNotChanged
            'Earlier it has NOT been approved and reached to Accounts
            If .VerifiedBy = String.Empty Then 'Verified/Received In Accounts
              If selfApproval Then
                .BillStatusID = TAStates.UnderReceiveByAccounts
              ElseIf .FK_TA_Bills_EmployeeID.TAVerifier <> String.Empty Then
                .BillStatusID = TAStates.UnderVerification
                sendMail = True
              ElseIf .FK_TA_Bills_EmployeeID.TAApprover <> String.Empty Then
                .BillStatusID = TAStates.UnderApproval
                sendMail = True
              Else
                If Results.OOEBySystem Then
                  If Results.SanctionAttached Then
                    .BillStatusID = TAStates.UnderReceiveByAccounts
                  Else
                    .BillStatusID = TAStates.UnderSpecialSanction
                    sendMail = True
                  End If
                Else
                  .BillStatusID = TAStates.UnderReceiveByAccounts
                End If
              End If
              .ApprovedBy = ""
              .ApprovedOn = ""
              .ApprovalRemarks = ""
              .ApprovedByCC = ""
              .ApprovedByCCOn = ""
              .CCRemarks = ""
              .ApprovedBySA = ""
              .ApprovedBySAOn = ""
              .SARemarks = ""
            Else
              .BillStatusID = TAStates.UnderReceiveByAccounts
            End If
        End Select
      End With
      '=====================================
      Results = SIS.TA.taBH.UpdateData(Results)
      '======Send EMail=========
      If sendMail Then
        SendEMail(Results)
      End If
      '=========================
      Return Results
    End Function
    Public Shared Function DuplicateTABill(ByVal tmp As SIS.TA.taBH, Optional ByRef DuplicateBillNo As Integer = 0) As Boolean
      Dim GraceHrs As Double = 1
      Dim DuplicateFound As Boolean = False
      Dim ci As System.Globalization.CultureInfo = SIS.SYS.Utilities.SessionManager.ci
      Dim tsDt As DateTime = Convert.ToDateTime(tmp.StartDateTime).AddHours(GraceHrs)
      Dim teDt As DateTime = Convert.ToDateTime(tmp.EndDateTime).AddHours(-1 * GraceHrs)
      Dim sTmps As List(Of SIS.TA.taBH) = SIS.TA.taBH.UZ_taBHSelectListForEmployee(0, 999, "", False, "", 0, "", "", 0, tmp.EmployeeID)
      For Each sTmp As SIS.TA.taBH In sTmps
        If sTmp.TABillNo = tmp.TABillNo Then Continue For
        Select Case sTmp.BillStatusID
          Case TAStates.Free,
               TAStates.ReturnedByAccounts,
               TAStates.ReturnedByApprover,
               TAStates.ReturnedByVerifier,
               TAStates.ReturnedBySanctioningAuthority
            Continue For
        End Select
        If sTmp.StartDateTime = "" Or sTmp.EndDateTime = "" Then Continue For
        Dim ssDt As DateTime = Convert.ToDateTime(sTmp.StartDateTime)
        Dim seDt As DateTime = Convert.ToDateTime(sTmp.EndDateTime)
        If (tsDt >= ssDt And tsDt <= seDt) Then
          DuplicateFound = True
          DuplicateBillNo = sTmp.TABillNo
        End If
        If (teDt >= ssDt And teDt <= seDt) Then
          DuplicateFound = True
          DuplicateBillNo = sTmp.TABillNo
        End If
        If (ssDt >= tsDt And ssDt <= teDt) Then
          DuplicateFound = True
          DuplicateBillNo = sTmp.TABillNo
        End If
        If (seDt >= tsDt And seDt <= teDt) Then
          DuplicateFound = True
          DuplicateBillNo = sTmp.TABillNo
        End If
        If DuplicateFound Then
          Exit For
        End If
      Next
      Return DuplicateFound
    End Function
    Public Shared Function UZ_taBHAllSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TravelTypeID As Int32, ByVal DestinationCity As String, ByVal ProjectID As String, ByVal BillStatusID As Int32, ByVal TABillNo As Int32) As List(Of SIS.TA.taBH)
      Dim Results As List(Of SIS.TA.taBH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "TABillNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spta_LG_BHSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spta_LG_BHSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TravelTypeID", SqlDbType.Int, 10, IIf(TravelTypeID = Nothing, 0, TravelTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DestinationCity", SqlDbType.NVarChar, 30, IIf(DestinationCity Is Nothing, String.Empty, DestinationCity))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID", SqlDbType.NVarChar, 6, IIf(ProjectID Is Nothing, String.Empty, ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BillStatusID", SqlDbType.Int, 10, IIf(BillStatusID = Nothing, 0, BillStatusID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo", SqlDbType.Int, 10, IIf(TABillNo = Nothing, 0, TABillNo))
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
    Public Shared Function taBHAllSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TravelTypeID As Int32, ByVal DestinationCity As String, ByVal ProjectID As String, ByVal BillStatusID As Int32, ByVal TABillNo As Int32) As Integer
      Return _RecordCount
    End Function
    Public Shared Function UZ_taBHSelectListForEmployee(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TravelTypeID As Int32, ByVal DestinationCity As String, ByVal ProjectID As String, ByVal BillStatusID As Int32, ByVal EmployeeID As String) As List(Of SIS.TA.taBH)
      Dim Results As List(Of SIS.TA.taBH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "TABillNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spta_LG_BHSelectListSearch"
            Cmd.CommandText = "sptaBHSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spta_LG_BHSelectListFilteres"
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
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.NVarChar, 8, EmployeeID)
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
    Public Shared Function UZ_taBHSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TravelTypeID As Int32, ByVal DestinationCity As String, ByVal ProjectID As String, ByVal BillStatusID As Int32) As List(Of SIS.TA.taBH)
      Dim Results As List(Of SIS.TA.taBH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "TABillNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spta_LG_BHSelectListSearch"
            Cmd.CommandText = "sptaBHSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spta_LG_BHSelectListFilteres"
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
    Public Shared Function UZ_taBHInsert(ByVal Record As SIS.TA.taBH) As SIS.TA.taBH
      With Record
        .EmployeeID = HttpContext.Current.Session("LoginID")
        .CompanyID = .FK_TA_Bills_EmployeeID.C_CompanyID
        .DivisionID = .FK_TA_Bills_EmployeeID.C_DivisionID
        .DepartmentID = .FK_TA_Bills_EmployeeID.C_DepartmentID
        .DesignationID = .FK_TA_Bills_EmployeeID.C_DesignationID
        .TACategoryID = .FK_TA_Bills_EmployeeID.CategoryID
        .Contractual = .FK_TA_Bills_EmployeeID.Contractual
        .NonTechnical = .FK_TA_Bills_EmployeeID.NonTechnical
        .CostCenterID = .FK_TA_Bills_EmployeeID.C_DepartmentID
        .OfficeID = .FK_TA_Bills_EmployeeID.C_OfficeID
        .SiteName = Record.SiteName
        .SiteTransfer = Record.SiteTransfer
        .CalculateDriverCharges = Record.CalculateDriverCharges
        .DestinationName = Record.DestinationName
        .TrainingProgramResidential = Record.TrainingProgramResidential
        .PartialTABill = Record.PartialTABill
        .DepartureFromIndia = Now
        .ArrivalToIndia = Now
        .StartDateTime = Now
        .EndDateTime = Now
        .SanctionAttached = Record.SanctionAttached
        'Set Currency
        If .TravelTypeID = TATravelTypeValues.Domestic Or .TravelTypeID = TATravelTypeValues.HomeVisit Then
          .BillCurrencyID = "INR"
          'Default Conversion Factor is 1
          .ConversionFactorINR = 1
        Else
          .BillCurrencyID = "USD"
          If .DestinationCity <> String.Empty Then
            If .FK_TA_Bills_DestinationCity.CurrencyID <> String.Empty Then
              .BillCurrencyID = .FK_TA_Bills_DestinationCity.CurrencyID
            End If
          End If
        End If
        'Set MultiCurrency Calculation Method
        .CalculationTypeID = TACalculationTypes.ConvertAtIndividualLevel
        .PrjCalcType = 2
        .ComponentID = TAComponentTypes.Total
        .BillStatusID = TAStates.Free
      End With
      Dim _Result As SIS.TA.taBH = taBHInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_taBHUpdate(ByVal Record As SIS.TA.taBH) As SIS.TA.taBH
      Dim _Rec As SIS.TA.taBH = SIS.TA.taBH.taBHGetByID(Record.TABillNo)
      With _Rec
        If .HeaderEditable Then
          .TravelTypeID = Record.TravelTypeID
          .SameDayVisit = Record.SameDayVisit
          .Within25KM = Record.Within25KM
          .OwnVehicleUsed = Record.OwnVehicleUsed
        End If
        .SiteName = Record.SiteName
        .TrainingProgram = Record.TrainingProgram 'Training Program [NON-Residential]
        .TaxiHired = Record.TaxiHired 'Training Program [Residential]
        .SiteTransfer = Record.SiteTransfer
        .CalculateDriverCharges = Record.CalculateDriverCharges
        .DestinationName = Record.DestinationName
        .TrainingProgramResidential = Record.TrainingProgramResidential
        .PartialTABill = Record.PartialTABill
        .SiteToAnotherSite = Record.SiteToAnotherSite
        .ConversionFactorINR = Record.ConversionFactorINR
        .DestinationCity = Record.DestinationCity
        .CityOfOrigin = Record.CityOfOrigin
        .SanctionedDA = Record.SanctionedDA
        .SanctionedLodging = Record.SanctionedLodging
        .BillCurrencyID = Record.BillCurrencyID
        .ProjectID = Record.ProjectID
        .CostCenterID = Record.CostCenterID
        .PrjCalcType = Record.PrjCalcType
        .PurposeOfJourney = Record.PurposeOfJourney
        .BriefTourReport = Record.BriefTourReport
        .BillStatusID = TAStates.Free
        .SanctionAttached = Record.SanctionAttached
      End With
      _Rec = SIS.TA.taBH.UpdateData(_Rec)
      ValidateTABill(Record.TABillNo)
      Return _Rec
    End Function
    Public Shared Function UZ_taBHDelete(ByVal Record As SIS.TA.taBH) As Integer
      Dim _Result As Integer = taBHDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_TABillNo"), TextBox).Text = ""
          CType(.FindControl("F_TravelTypeID"), Object).SelectedValue = ""
          CType(.FindControl("F_CityOfOrigin"), TextBox).Text = ""
          CType(.FindControl("F_CityOfOrigin_Display"), Label).Text = ""
          CType(.FindControl("F_DestinationCity"), TextBox).Text = ""
          CType(.FindControl("F_DestinationCity_Display"), Label).Text = ""
          CType(.FindControl("F_ProjectID"), TextBox).Text = ""
          CType(.FindControl("F_ProjectID_Display"), Label).Text = ""
          CType(.FindControl("F_TrainingProgram"), CheckBox).Checked = False
          CType(.FindControl("F_SameDayVisit"), CheckBox).Checked = False
          CType(.FindControl("F_Within25KM"), CheckBox).Checked = False
          CType(.FindControl("F_SiteToAnotherSite"), CheckBox).Checked = False
          CType(.FindControl("F_TaxiHired"), CheckBox).Checked = False
          CType(.FindControl("F_OwnVehicleUsed"), CheckBox).Checked = False
          CType(.FindControl("F_PurposeOfJourney"), TextBox).Text = ""
          CType(.FindControl("F_BriefTourReport"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function

#Region "    Supporting Procedures -ValidateTABill "
    Public ReadOnly Property TotalTravelDays As Decimal
      Get
        Dim mRet As Decimal = 0
        Dim stDT As String = ""
        Dim enDT As String = ""
        Dim ci As System.Globalization.CultureInfo = SIS.SYS.Utilities.SessionManager.ci
        If TravelTypeID = TATravelTypeValues.Domestic Then
          Try
            Dim tmpHrs As Integer = DateDiff(DateInterval.Hour, Convert.ToDateTime(StartDateTime, ci), Convert.ToDateTime(EndDateTime, ci))
            Dim tmpDays As Integer = tmpHrs \ 24
            Dim tmpBalHrs As Integer = tmpHrs Mod 24
            Dim tmpHalfDay As Decimal = 0
            If tmpBalHrs >= 8 Then
              tmpDays += 1
            ElseIf tmpBalHrs >= 4 Then
              tmpHalfDay = 0.5
            End If
            mRet = tmpDays + tmpHalfDay
          Catch ex As Exception
          End Try
        ElseIf TravelTypeID = TATravelTypeValues.ForeignTravel Then
          Try
            Dim tmpDays As Integer = DateDiff(DateInterval.Day, Convert.ToDateTime(DepartureFromIndia, ci), Convert.ToDateTime(ArrivalToIndia, ci))
            'Include Both Days
            tmpDays += 1
            '---End Include Both Days
            If Not SiteToAnotherSite Then ' It is a Partial Ta Bill, do not subtract 1 day
              tmpDays = tmpDays - 1
            End If
            If tmpDays = 0 Then
              tmpDays = 1
            End If
            mRet = tmpDays
          Catch ex As Exception
          End Try
        ElseIf TravelTypeID = TATravelTypeValues.ForeignSiteVisit Then
          Try
            Dim tmpDays As Integer = DateDiff(DateInterval.Day, Convert.ToDateTime(DepartureFromIndia, ci), Convert.ToDateTime(ArrivalToIndia, ci))
            'Include Both Days
            tmpDays += 1
            '---End Include Both Days
            If Not SiteToAnotherSite Then ' It is a Partial Ta Bill, do not subtract 1 day
              tmpDays = tmpDays - 1
            End If
            If tmpDays = 0 Then
              tmpDays = 1
            End If
            mRet = tmpDays
          Catch ex As Exception
          End Try
        End If
        Return mRet
      End Get
    End Property
    Private Shared Sub InitializeTABill(ByVal TABillNo As Integer)
      Dim ci As System.Globalization.CultureInfo = SIS.SYS.Utilities.SessionManager.ci
      Dim sBill As SIS.TA.taBH = SIS.TA.taBH.taBHGetByID(TABillNo)
      '1. Bill Header
      With sBill
        '.OOERemarks = ""
        .OOEBySystem = False
        .StartDateTime = ""
        .EndDateTime = ""
        .DepartureFromIndia = ""
        .ArrivalToIndia = ""
        .TotalClaimedAmount = 0
        .TotalFinancedAmount = 0
        .TotalPassedAmount = 0
        .TotalPayableAmount = 0
      End With
      '2. Project Amounts
      Dim pAmts As List(Of SIS.TA.taBillPrjAmounts) = SIS.TA.taBillPrjAmounts.taBillPrjAmountsSelectList(0, 999, "", False, "", TABillNo)
      For Each pAmt As SIS.TA.taBillPrjAmounts In pAmts
        pAmt.TotalAmountinINR = 0
        SIS.TA.taBillPrjAmounts.UpdateData(pAmt)
      Next
      '3. Bill Amounts
      Dim sAmts As List(Of SIS.TA.taBillAmount) = SIS.TA.taBillAmount.taBillAmountSelectList(0, 999, "", False, "", TABillNo)
      For Each sAmt As SIS.TA.taBillAmount In sAmts
        SIS.TA.taBillAmount.taBillAmountDelete(sAmt)
      Next
      '4. Bill Details
      Dim sTmps As List(Of SIS.TA.taBillDetails) = SIS.TA.taBillDetails.taBillDetailsSelectList(0, 999, "", False, "", TABillNo)
      For Each sTmp As SIS.TA.taBillDetails In sTmps
        Select Case sTmp.ComponentID
          Case TAComponentTypes.DA, TAComponentTypes.Driver, TAComponentTypes.Expense, TAComponentTypes.Finance
            If sTmp.AutoCalculated Then
              SIS.TA.taBillDetails.taBillDetailsDelete(sTmp)
            End If
        End Select
      Next
      '5. Update Journey Period 
      For Each sTmp As SIS.TA.taBillDetails In sTmps
        Select Case sTmp.ComponentID
          Case TAComponentTypes.Fare, TAComponentTypes.Mileage, TAComponentTypes.Lodging
            If sBill.StartDateTime <> String.Empty Then
              If Convert.ToDateTime(sBill.StartDateTime, ci) > Convert.ToDateTime(sTmp.Date1Time, ci) Then
                sBill.StartDateTime = sTmp.Date1Time
                sBill.DepartureFromIndia = sTmp.Date1Time
              End If
            Else
              sBill.StartDateTime = sTmp.Date1Time
              sBill.DepartureFromIndia = sTmp.Date1Time
            End If
            If sBill.EndDateTime <> String.Empty Then
              If Convert.ToDateTime(sBill.EndDateTime, ci) < Convert.ToDateTime(sTmp.Date2Time, ci) Then
                sBill.EndDateTime = sTmp.Date2Time
                sBill.ArrivalToIndia = sTmp.Date2Time
              End If
            Else
              sBill.EndDateTime = sTmp.Date2Time
              sBill.ArrivalToIndia = sTmp.Date2Time
            End If
        End Select
        If sBill.TravelTypeID <> TATravelTypeValues.Domestic AndAlso sBill.TravelTypeID <> TATravelTypeValues.HomeVisit Then
          Select Case sTmp.ComponentID
            Case TAComponentTypes.Fare, TAComponentTypes.Lodging
              If sTmp.Country1ID = "India" And sTmp.Country2ID <> "India" Then
                If sBill.DepartureFromIndia <> String.Empty Then
                  If Convert.ToDateTime(sBill.DepartureFromIndia, ci) > Convert.ToDateTime(sTmp.Date1Time, ci) Then
                    sBill.DepartureFromIndia = sTmp.Date1Time
                  End If
                Else
                  sBill.DepartureFromIndia = sTmp.Date1Time
                End If
                If sBill.ArrivalToIndia <> String.Empty Then
                  If Convert.ToDateTime(sBill.ArrivalToIndia, ci) < Convert.ToDateTime(sTmp.Date1Time, ci) Then
                    sBill.ArrivalToIndia = sTmp.Date1Time
                  End If
                Else
                  sBill.ArrivalToIndia = sTmp.Date1Time
                End If
              End If
              If sTmp.Country2ID = "India" And sTmp.Country1ID <> "India" Then
                If sBill.DepartureFromIndia <> String.Empty Then
                  If Convert.ToDateTime(sBill.DepartureFromIndia, ci) > Convert.ToDateTime(sTmp.Date2Time, ci) Then
                    sBill.DepartureFromIndia = sTmp.Date2Time
                  End If
                Else
                  sBill.DepartureFromIndia = sTmp.Date2Time
                End If
                If sBill.ArrivalToIndia <> String.Empty Then
                  If Convert.ToDateTime(sBill.ArrivalToIndia, ci) < Convert.ToDateTime(sTmp.Date2Time, ci) Then
                    sBill.ArrivalToIndia = sTmp.Date2Time
                  End If
                Else
                  sBill.ArrivalToIndia = sTmp.Date2Time
                End If
              End If
              If sTmp.Country2ID <> "India" And sTmp.Country1ID <> "India" Then
                If sBill.DepartureFromIndia <> String.Empty Then
                  If Convert.ToDateTime(sBill.DepartureFromIndia, ci) > Convert.ToDateTime(sTmp.Date2Time, ci) Then
                    sBill.DepartureFromIndia = sTmp.Date2Time
                  End If
                Else
                  sBill.DepartureFromIndia = sTmp.Date2Time
                End If
                If sBill.ArrivalToIndia <> String.Empty Then
                  If Convert.ToDateTime(sBill.ArrivalToIndia, ci) < Convert.ToDateTime(sTmp.Date2Time, ci) Then
                    sBill.ArrivalToIndia = sTmp.Date2Time
                  End If
                Else
                  sBill.ArrivalToIndia = sTmp.Date2Time
                End If
              End If
          End Select
        End If
      Next
      sBill.SameDayVisit = False
      If sBill.TravelTypeID = TATravelTypeValues.Domestic Then
        'Calculate Same Day Visit As Logic Given By NK
        '=============================================
        Dim tmpInitialized As Boolean = False
        Dim sDt As DateTime = Nothing
        Dim eDt As DateTime = Nothing
        sTmps.Sort(Function(x, y) Convert.ToDateTime(IIf(x.Date1Time = String.Empty, Convert.ToDateTime("01/01/2000"), x.Date1Time), ci).CompareTo(Convert.ToDateTime(IIf(y.Date1Time = String.Empty, Convert.ToDateTime("01/01/2000"), y.Date1Time), ci)))
        For Each sTmp As SIS.TA.taBillDetails In sTmps
          Select Case sTmp.ComponentID
            Case TAComponentTypes.Fare, TAComponentTypes.Mileage
              If Not tmpInitialized Then
                sDt = sTmp.Date1Time
                eDt = sTmp.Date2Time
                tmpInitialized = True
              Else
                'Consider Returning Start Time for same day visit
                eDt = sTmp.Date1Time
              End If
            Case TAComponentTypes.Lodging
              If Not tmpInitialized Then
                sDt = sTmp.Date1Time
                eDt = sTmp.Date2Time
                tmpInitialized = True
              Else
                If sDt > sTmp.Date1Time Then sDt = sTmp.Date1Time
                If eDt < sTmp.Date2Time Then eDt = sTmp.Date2Time
              End If
          End Select
        Next
        If DateDiff(DateInterval.Hour, sDt, eDt) <= 24 Then
          sBill.SameDayVisit = True
        End If
        'On Complete TA Bill Basis
        '==========================
        '  Try
        '    If DateDiff(DateInterval.Hour, Convert.ToDateTime(sBill.StartDateTime), Convert.ToDateTime(sBill.EndDateTime)) <= 24 Then
        '      sBill.SameDayVisit = True
        '    End If
        '  Catch ex As Exception
        '  End Try
      End If
      SIS.TA.taBH.UpdateData(sBill)
    End Sub
    Private Shared Sub ValidateFare(ByVal sBill As SIS.TA.taBH, ByVal sTmps As List(Of SIS.TA.taBillDetails))
      Dim ci As System.Globalization.CultureInfo = SIS.SYS.Utilities.SessionManager.ci
      For Each sTmp As SIS.TA.taBillDetails In sTmps
        Select Case sTmp.ComponentID
          Case TAComponentTypes.Fare
            With sTmp
              .OOEBySystem = False
              .OOERemarks = ""
            End With
            If sTmp.ModeTravelID <> String.Empty Then
              If sBill.TravelTypeID = TATravelTypeValues.Domestic Or sTmp.IsDomestic Or sBill.TravelTypeID = TATravelTypeValues.HomeVisit Then
                Dim tmp As SIS.TA.taD_TravelModes = SIS.TA.taD_TravelModes.GetByCategoryID(Convert.ToInt32(sBill.TACategoryID), Convert.ToDateTime(sTmp.Date1Time, ci))
                If tmp IsNot Nothing Then
                  Try
                    Select Case sTmp.ModeTravelID
                      Case "9", "15" 'Taxi, OwnCar
                        If sTmp.AmountInINR > 0 Then
                          If sTmp.ModeTravelID = "9" Then
                            With sTmp
                              .OOEBySystem = True
                              .OOERemarks = "Taxi requires Special Approval."
                            End With
                          Else
                            If sBill.TACategoryID > 7 Then 'Below Manager
                              With sTmp
                                If .AmountInINR > 0 Then
                                  .OOEBySystem = True
                                  .OOERemarks = "Own Car requires Special Approval."
                                End If
                              End With
                            End If
                          End If
                        End If
                      Case Else
                        If Convert.ToInt32(sTmp.FK_TA_BillDetails_ModeTravelID.Sequence) < Convert.ToInt32(tmp.FK_TA_D_TravelModes_TravelModeID.Sequence) Then
                          If sTmp.AmountInINR > 0 Then
                            With sTmp
                              .OOEBySystem = True
                              .OOERemarks = "Travel Mode is OVER entitlement [" & tmp.FK_TA_D_TravelModes_TravelModeID.ModeName & "]."
                            End With
                          End If
                        End If
                    End Select
                  Catch ex As Exception
                    With sTmp
                      .OOEBySystem = False
                      .OOERemarks = "Other travel mode selected."
                    End With
                  End Try
                Else
                  If sTmp.AmountInINR > 0 Then
                    With sTmp
                      .OOEBySystem = True
                      .OOERemarks = "Domestic Travel Mode Entitlement NOT Found."
                    End With
                  End If
                End If
              Else
                Dim tmp As SIS.TA.taF_TravelModes = SIS.TA.taF_TravelModes.GetByCategoryID(Convert.ToInt32(sBill.TACategoryID), Convert.ToDateTime(sTmp.Date1Time, ci))
                If tmp IsNot Nothing Then
                  If Convert.ToInt32(sTmp.FK_TA_BillDetails_ModeTravelID.Sequence) < Convert.ToInt32(tmp.FK_TA_F_TravelModes_TravelModeID.Sequence) Then
                    If sTmp.AmountInINR > 0 Then
                      With sTmp
                        'NO Over Entitlement in case of Foreign Visit
                        '.OOEBySystem = True
                        '.OOERemarks = "Travel Mode is OVER entitlement [" & tmp.FK_TA_F_TravelModes_TravelModeID.ModeName & "]."
                      End With
                    End If
                  End If
                Else
                  If sTmp.AmountInINR > 0 Then
                    With sTmp
                      .OOEBySystem = True
                      .OOERemarks = "Foreign Travel Mode Entitlement NOT Found."
                    End With
                  End If
                End If
              End If
            Else
              If sTmp.AmountInINR > 0 Then
                With sTmp
                  .OOEBySystem = True
                  .OOERemarks = "Other Travel Mode requires Special Approval."
                End With
              End If
            End If
            SIS.TA.taBillDetails.UpdateData(sTmp)
        End Select
      Next
    End Sub
    Private Shared Sub ValidateLodging(ByVal sBill As SIS.TA.taBH, ByVal sTmps As List(Of SIS.TA.taBillDetails))
      Dim ci As System.Globalization.CultureInfo = SIS.SYS.Utilities.SessionManager.ci
      For Each sTmp As SIS.TA.taBillDetails In sTmps
        Select Case sTmp.ComponentID
          Case TAComponentTypes.Lodging
            Dim CityTypeForHotel As String = ""
            If sTmp.City1ID = String.Empty Then
              CityTypeForHotel = "OTHERS"
            Else
              CityTypeForHotel = sTmp.FK_TA_BillDetails_City1ID.CityTypeForHotel
            End If
            Dim RegionID As String = ""
            If sTmp.City1ID = String.Empty Then
              RegionID = "Others"
            Else
              RegionID = sTmp.FK_TA_BillDetails_City1ID.RegionID
            End If
            With sTmp
              .OOEBySystem = False
              .OOERemarks = ""
            End With
            If sBill.TravelTypeID = TATravelTypeValues.Domestic Or sTmp.IsDomestic Then
              If sTmp.StayedInHotel Then
                Dim tmp As SIS.TA.taD_Lodging = SIS.TA.taD_Lodging.GetByCategoryID(sBill.TACategoryID, CityTypeForHotel, Convert.ToDateTime(sTmp.Date1Time, ci))
                If tmp IsNot Nothing Then
                  tmp.LodgingAmount = IIf(sBill.SanctionedLodging = 0, tmp.LodgingAmount, sBill.SanctionedLodging)
                  If sTmp.AmountRate > tmp.LodgingAmount Then
                    If sTmp.AmountInINR > 0 Then
                      With sTmp
                        .OOEBySystem = True
                        .OOERemarks = "Lodging exceeds Entitlement " & tmp.LodgingAmount & ", requires Business Head Approval"
                      End With
                    End If
                  End If
                Else
                  With sTmp
                    .PassedAmountRate = 0
                    .PassedAmountTax = 0
                    .OOEBySystem = True
                    .OOERemarks = "City Type Wise Hotel Entitlement NOT Found."
                  End With
                End If
              Else
                With sTmp
                  If .AmountRate + .AmountTax > 0 Then
                    .PassedAmountRate = 0
                    .PassedAmountTax = 0
                    .OOEBySystem = True
                    .OOERemarks = "Lodging  Amount should be ZERO, if NOT Stayed in Hotel."
                  End If
                End With
              End If
            Else
              If sBill.TravelTypeID = TATravelTypeValues.ForeignTravel Then
                If sTmp.StayedInHotel Then
                  Dim tmp As SIS.TA.taF_LodgDA = SIS.TA.taF_LodgDA.GetByCategoryID(sBill.TACategoryID, RegionID, Convert.ToDateTime(sTmp.Date1Time, ci))
                  If tmp IsNot Nothing Then
                    tmp.Lodging = IIf(sBill.SanctionedLodging = 0, tmp.Lodging, sBill.SanctionedLodging)
                    If sTmp.AmountRate > tmp.Lodging Then
                      'If sTmp.AmountInINR > 0 Then
                      With sTmp
                        .OOEBySystem = True
                        .OOERemarks = "Lodging exceeds Entitlement: " & tmp.Lodging & " requires MD Approval"
                      End With
                      'End If
                    End If
                  Else
                    With sTmp
                      .PassedAmountRate = 0
                      .PassedAmountTax = 0
                      .OOEBySystem = True
                      .OOERemarks = "Region Wise Hotel Entitlement NOT Found."
                    End With
                  End If
                Else
                  With sTmp
                    If .AmountRate + .AmountTax > 0 Then
                      .PassedAmountRate = 0
                      .PassedAmountTax = 0
                      .OOEBySystem = True
                      .OOERemarks = "Lodging  Amount should be ZERO, if NOT Stayed in Hotel."
                    End If
                  End With
                End If
              Else 'Foreign Site Visit
                With sTmp
                  If sBill.SanctionedLodging > 0 Then
                    If sTmp.AmountRate > sBill.SanctionedLodging Then
                      With sTmp
                        .OOEBySystem = True
                        .OOERemarks = "Lodging exceeds Entitlement: " & sBill.SanctionedLodging & " requires MD Approval"
                      End With
                    End If
                  Else
                    If .AmountRate + .AmountTax > 0 Then
                      .OOEBySystem = True
                      .OOERemarks = "Foreign Site Visit: Lodging is NOT allowed, requires MD Approval"
                    End If
                  End If
                End With
              End If
            End If
            SIS.TA.taBillDetails.UpdateData(sTmp)
        End Select
      Next
    End Sub
#Region "    Calculate DA  "
    Private Class StayedDestination
      Public Property bd1 As SIS.TA.taBillDetails = Nothing
      Public Property bd2 As SIS.TA.taBillDetails = Nothing
      Public Property bd3 As SIS.TA.taBillDetails = Nothing
      Public ReadOnly Property INCityID As String
        Get
          Dim mRet As String = ""
          If bd1 IsNot Nothing And bd3 IsNot Nothing And bd2 Is Nothing Then
            If bd1.City2ID = bd3.City1ID Then
              mRet = bd1.City2ID
            End If
          End If
          Return mRet
        End Get
      End Property
      Public Shared Function GetStayedDestinations(ByVal sTmps As List(Of SIS.TA.taBillDetails)) As List(Of StayedDestination)
        Dim ci As System.Globalization.CultureInfo = SIS.SYS.Utilities.SessionManager.ci
        sTmps.Sort(Function(x, y) Convert.ToDateTime(IIf(x.Date1Time = String.Empty, Now.ToString, x.Date1Time), ci).CompareTo(Convert.ToDateTime(IIf(y.Date1Time = String.Empty, Now.ToString, y.Date1Time), ci)))
        Dim Tmps As New List(Of StayedDestination)
        Dim tmp As New StayedDestination
        For Each sTmp As SIS.TA.taBillDetails In sTmps
          Select Case sTmp.ComponentID
            Case TAComponentTypes.Fare, TAComponentTypes.Mileage
              If tmp.bd1 Is Nothing And tmp.bd2 Is Nothing And tmp.bd3 Is Nothing Then
                If sTmp.City2ID <> String.Empty Then
                  tmp.bd1 = sTmp
                End If
              ElseIf tmp.bd1 IsNot Nothing And tmp.bd2 Is Nothing And tmp.bd3 Is Nothing Then
                If tmp.bd1.City2ID = sTmp.City1ID Then
                  tmp.bd3 = sTmp
                  Tmps.Add(tmp)
                  tmp = New StayedDestination
                Else
                  If sTmp.City2ID <> String.Empty Then
                    tmp.bd1 = sTmp
                  End If
                End If
              ElseIf tmp.bd1 IsNot Nothing And tmp.bd2 IsNot Nothing And tmp.bd3 Is Nothing Then
                If tmp.bd1.City2ID = sTmp.City1ID Then
                  tmp.bd3 = sTmp
                  Tmps.Add(tmp)
                  tmp = New StayedDestination
                Else
                  Tmps.Add(tmp)
                  tmp = New StayedDestination
                  If sTmp.City2ID <> String.Empty Then
                    tmp.bd1 = sTmp
                  End If
                End If
              ElseIf tmp.bd1 Is Nothing And tmp.bd2 IsNot Nothing And tmp.bd3 Is Nothing Then
                If tmp.bd2.City1ID = sTmp.City1ID Then
                  tmp.bd3 = sTmp
                  Tmps.Add(tmp)
                  tmp = New StayedDestination
                Else
                  Tmps.Add(tmp)
                  tmp = New StayedDestination
                  If sTmp.City2ID <> String.Empty Then
                    tmp.bd1 = sTmp
                  End If
                End If
              End If
            Case TAComponentTypes.Lodging
              If tmp.bd1 Is Nothing And tmp.bd2 Is Nothing And tmp.bd3 Is Nothing Then
                tmp.bd2 = sTmp
              ElseIf tmp.bd1 IsNot Nothing And tmp.bd2 Is Nothing And tmp.bd3 Is Nothing Then
                If tmp.bd1.City2ID = sTmp.City1ID Then
                  tmp.bd2 = sTmp
                Else
                  tmp.bd2 = sTmp
                  tmp.bd1 = Nothing
                End If
              ElseIf tmp.bd1 IsNot Nothing And tmp.bd2 IsNot Nothing And tmp.bd3 Is Nothing Then
                Tmps.Add(tmp)
                tmp = New StayedDestination
                tmp.bd2 = sTmp
              ElseIf tmp.bd1 Is Nothing And tmp.bd2 IsNot Nothing And tmp.bd3 Is Nothing Then
                Tmps.Add(tmp)
                tmp = New StayedDestination
                tmp.bd2 = sTmp
              End If
          End Select
        Next
        If tmp.bd2 IsNot Nothing Or (tmp.bd1 IsNot Nothing And tmp.bd3 IsNot Nothing) Then
          Tmps.Add(tmp)
        End If
        Return Tmps
      End Function

      Public Sub New()
        'dummy
      End Sub
    End Class
    Private Shared Sub CalculateDA(ByVal sBill As SIS.TA.taBH, ByVal sTmps As List(Of SIS.TA.taBillDetails))
      'If sBill.SameDayVisit Then
      '  SameDayVisitDA(sBill, sTmps)
      'Else
      If sBill.Within25KM Then
        'No DA
      ElseIf sBill.TrainingProgram Then 'NON Residential
        TrainingProgramDA(sBill)
      ElseIf sBill.TaxiHired Then 'Training Program Residential
        TrainingProgramDA(sBill)
      Else   'Normal DA
        If sBill.TravelTypeID = TATravelTypeValues.Domestic Then
          If sBill.FK_TA_Bills_EmployeeID.C_OfficeID = "6" Then
            If sBill.SiteTransfer Then
              Dim LimitDays As Decimal = 15 'Limit DA days for domestic site employee 
              'On site transfer case onlt, other wise they are paid site allowance
              Dim oSDs As List(Of StayedDestination) = StayedDestination.GetStayedDestinations(sTmps)
              If sBill.TotalTravelDays < LimitDays Then
                Dim PaidDays As Decimal = CreateDARecords(oSDs, sBill, LimitDays)
                Dim OtherDADays As Decimal = sBill.TotalTravelDays - PaidDays
                If OtherDADays > 0 Then
                  CreateOtherDARecord(sBill, OtherDADays)
                End If
              Else
                Dim PaidDays As Decimal = CreateDARecords(oSDs, sBill, LimitDays)
                Dim OtherDADays As Decimal = LimitDays - PaidDays
                If OtherDADays > 0 Then
                  CreateOtherDARecord(sBill, OtherDADays)
                End If
              End If
            End If
          Else
            Dim oSDs As List(Of StayedDestination) = StayedDestination.GetStayedDestinations(sTmps)
            Dim OtherDADays As Decimal = sBill.TotalTravelDays - CreateDARecords(oSDs, sBill, sBill.TotalTravelDays)
            If OtherDADays > 0 Then
              CreateOtherDARecord(sBill, OtherDADays)
            End If
          End If
        Else
          Dim oSDs As List(Of StayedDestination) = StayedDestination.GetStayedDestinations(sTmps)
          Dim OtherDADays As Decimal = sBill.TotalTravelDays - CreateDARecords(oSDs, sBill, sBill.TotalTravelDays)
          If OtherDADays > 0 Then
            CreateOtherDARecord(sBill, OtherDADays)
          End If
        End If
      End If
    End Sub
    Private Shared Sub CreateOtherDARecord(ByVal sBill As SIS.TA.taBH, ByVal daDays As Decimal)
      Dim ci As System.Globalization.CultureInfo = SIS.SYS.Utilities.SessionManager.ci
      Dim sTmp As New SIS.TA.taBillDetails
      With sTmp
        .TABillNo = sBill.TABillNo
        .AutoCalculated = True
        .SerialNo = 0
        .ProjectID = .FK_TA_BillDetails_TABillNo.ProjectID
        .CostCenterID = .FK_TA_BillDetails_TABillNo.CostCenterID
        .CurrencyID = .FK_TA_BillDetails_TABillNo.BillCurrencyID
        .ConversionFactorINR = .FK_TA_BillDetails_TABillNo.ConversionFactorINR
        .CityTypeID = "OTHERS"
        .NotStayedAnyWhere = True
        .Date1Time = sBill.StartDateTime
        .Date2Time = sBill.EndDateTime
        .ComponentID = TAComponentTypes.DA
        .AmountFactor = daDays
        .AmountTax = 0
        .AmountRate = 0
      End With
      If sBill.SanctionedDA > 0 Then
        sTmp.AmountRate = sBill.SanctionedDA
        sTmp.SystemText = "Sanctioned DA, for Travel duration " & sTmp.AmountFactor & " day(s) @ " & sTmp.AmountRate & " Duration " & sTmp.Date1Time & " - " & sTmp.Date2Time
      Else
        Dim CityTypeForDA As String = "OTHERS"
        Dim RegionID As String = "Others"
        If sBill.TravelTypeID = TATravelTypeValues.Domestic Or sTmp.IsDomestic Then
          Dim tmp As SIS.TA.taD_SwrDA = SIS.TA.taD_SwrDA.GetByCategoryID(Convert.ToInt32(sBill.TACategoryID), CityTypeForDA, Convert.ToDateTime(sBill.StartDateTime, ci))
          If tmp IsNot Nothing Then
            sTmp.AmountRate = tmp.HotelStayDA
          Else
            With sTmp
              .AmountRate = 0
              .OOERemarks = "Entitlement for DA NOT found."
            End With
          End If
          sTmp.SystemText = CityTypeForDA & " City DA, for Travel duration " & sTmp.AmountFactor & " day(s) @ " & sTmp.AmountRate & " Duration " & sTmp.Date1Time & " - " & sTmp.Date2Time
        ElseIf sBill.TravelTypeID = TATravelTypeValues.ForeignTravel Then
          Dim tmp As SIS.TA.taF_LodgDA = SIS.TA.taF_LodgDA.GetByCategoryID(sBill.TACategoryID, RegionID, Convert.ToDateTime(sBill.StartDateTime, ci))
          If tmp IsNot Nothing Then
            If sTmp.BoardingProvided Then
              'TO DO Get Configuration Value From [TA_F_ForeignTravel] =50%
              sTmp.AmountRate = tmp.DA / 2
            Else
              sTmp.AmountRate = tmp.DA
            End If
          Else
            With sTmp
              .AmountRate = 0
              .OOERemarks = "Foreign Region Wise DA Entitlement NOT Found."
            End With
          End If
          sTmp.SystemText = RegionID & " region DA, for Travel duration " & sTmp.AmountFactor & " day(s) @ " & sTmp.AmountRate & " Duration " & sTmp.Date1Time & " - " & sTmp.Date2Time
        Else 'Foreign Site Visit
          'As per NKA, Travel Time DA will be Boarding Provided DA
          Dim tmp As SIS.TA.taF_SiteDA = SIS.TA.taF_SiteDA.GetByCategoryID(Convert.ToInt32(sBill.TACategoryID), Convert.ToDateTime(sBill.StartDateTime, ci))
          If tmp IsNot Nothing Then
            If sBill.FK_TA_Bills_EmployeeID.Contractual Then
              If sBill.FK_TA_Bills_EmployeeID.NonTechnical Then
                If sTmp.BoardingProvided Then
                  sTmp.AmountRate = tmp.Cont_NonT_Bord_DA
                Else
                  'As per NKA, Travel Time DA will be Boarding Provided DA
                  sTmp.AmountRate = tmp.Cont_NonT_DA
                  'sTmp.AmountRate = tmp.Cont_NonT_Bord_DA
                End If
              Else
                If sTmp.BoardingProvided Then
                  sTmp.AmountRate = tmp.Cont_Tech_Bord_DA
                Else
                  'As per NKA, Travel Time DA will be Boarding Provided DA
                  sTmp.AmountRate = tmp.Cont_Tech_DA
                  'sTmp.AmountRate = tmp.Cont_Tech_Bord_DA
                End If
              End If
            Else
              If sTmp.BoardingProvided Then
                sTmp.AmountRate = tmp.Perm_Bord_DA
              Else
                'As per NKA, Travel Time DA will be Boarding Provided DA
                sTmp.AmountRate = tmp.Perm_DA
                'sTmp.AmountRate = tmp.Perm_Bord_DA
              End If
            End If
          Else
            With sTmp
              .AmountRate = 0
              .OOERemarks = "Foreign Site Visit DA Entitlement NOT Found."
            End With
          End If
          sTmp.SystemText = "Site Visit DA, for Travel duration " & sTmp.AmountFactor & " day(s) @ " & sTmp.AmountRate & " Duration " & sTmp.Date1Time & " - " & sTmp.Date2Time
        End If
      End If
      SIS.TA.taBillDetails.UZ_taBillDetailsInsert(sTmp)
    End Sub
    Private Shared Function CreateDARecords(ByVal oSDs As List(Of StayedDestination), ByVal sBill As SIS.TA.taBH, Optional ByVal LimitDays As Decimal = 0) As Decimal
      Dim ByLodging As Boolean = False
      Dim ci As System.Globalization.CultureInfo = SIS.SYS.Utilities.SessionManager.ci
      Dim TotalDADays As Double = 0
      Try
        For Each oSD As StayedDestination In oSDs
          Dim sTmp As SIS.TA.taBillDetails = Nothing
          If oSD.bd2 IsNot Nothing Then
            sTmp = oSD.bd2.Clone
            With sTmp
              .OOEBySystem = False
              .OOERemarks = ""
              .ComponentID = TAComponentTypes.DA
              .Remarks = ""
            End With
            ByLodging = True
          Else
            ByLodging = False
            sTmp = New SIS.TA.taBillDetails
            With sTmp
              .TABillNo = sBill.TABillNo
              .CurrencyID = sBill.BillCurrencyID
              .ConversionFactorINR = sBill.ConversionFactorINR
              .ProjectID = sBill.ProjectID
              .CostCenterID = sBill.CostCenterID
              .ComponentID = TAComponentTypes.DA
              '======
              .City1ID = oSD.INCityID
              '======
            End With
            With sTmp
              .NotStayedAnyWhere = True
            End With
          End If
          If oSD.bd1 IsNot Nothing Then
            sTmp.Date1Time = oSD.bd1.Date2Time
          End If
          If oSD.bd3 IsNot Nothing Then
            sTmp.Date2Time = oSD.bd3.Date1Time
          End If
          Dim tmpM As Long = DateDiff(DateInterval.Minute, Convert.ToDateTime(sTmp.Date1Time, ci), Convert.ToDateTime(sTmp.Date2Time, ci))
          Dim tmpH As Integer = tmpM \ 60
          Dim tmpD As Integer = tmpH \ 24
          Dim tmpHBal As Integer = tmpH Mod 24
          Dim tmpDHalf As Decimal = 0
          If tmpHBal >= 8 Then
            tmpD = tmpD + 1
          ElseIf tmpHBal >= 4 Then
            tmpDHalf = 0.5
          End If
          Dim tmp_daDays As Decimal = (tmpD + tmpDHalf)
          If tmp_daDays > 0 Then
            'Check Doestic Site Employee DA days Limit
            If LimitDays > 0 Then
              Dim _tmpTotDays As Decimal = TotalDADays + tmp_daDays
              If _tmpTotDays > LimitDays Then
                tmp_daDays = LimitDays - TotalDADays
              End If
            End If
            'End Check Domestic Site Employee DA days Limit
          End If
          TotalDADays += tmp_daDays
          'Create DA Record
          'If tmp_daDays > 0 Then
          With sTmp
            .AutoCalculated = True
            .SerialNo = 0
            .ProjectID = .FK_TA_BillDetails_TABillNo.ProjectID
            .CostCenterID = .FK_TA_BillDetails_TABillNo.CostCenterID
            .CurrencyID = .FK_TA_BillDetails_TABillNo.BillCurrencyID
            .ConversionFactorINR = .FK_TA_BillDetails_TABillNo.ConversionFactorINR
            .ComponentID = TAComponentTypes.DA
            .AmountFactor = tmp_daDays
            .AmountRate = 1
            .AmountTax = 0
          End With
          'End If
          If sBill.SanctionedDA > 0 Then
            sTmp.AmountRate = sBill.SanctionedDA
            sTmp.SystemText = "Sanctioned DA, stay in city " & sTmp.City1Text & " for " & sTmp.AmountFactor & " day(s) @ " & sTmp.AmountRate & " Duration " & sTmp.Date1Time & " - " & sTmp.Date2Time
          Else
            Dim CityTypeForDA As String = ""
            If sTmp.City1ID = String.Empty Then
              CityTypeForDA = "OTHERS"
            Else
              CityTypeForDA = sTmp.FK_TA_BillDetails_City1ID.CityTypeForDA
            End If
            If sBill.SameDayVisit Then
              If CityTypeForDA = "METRO" Then
                CityTypeForDA = "SPECIF"
              End If
            End If
            Dim RegionID As String = ""
            If sTmp.City1ID = String.Empty Then
              RegionID = "Others"
            Else
              RegionID = sTmp.FK_TA_BillDetails_City1ID.RegionID
            End If
            If sBill.TravelTypeID = TATravelTypeValues.Domestic Or sTmp.IsDomestic Then
              If sTmp.StayedInHotel Then
                Dim tmp As SIS.TA.taD_SwrDA = SIS.TA.taD_SwrDA.GetByCategoryID(Convert.ToInt32(sBill.TACategoryID), CityTypeForDA, Convert.ToDateTime(sBill.StartDateTime, ci))
                If tmp IsNot Nothing Then
                  sTmp.AmountRate = tmp.HotelStayDA
                Else
                  With sTmp
                    .AmountRate = 0
                    .OOERemarks = "Entitlement for DA NOT found."
                  End With
                End If
                sTmp.SystemText = CityTypeForDA & " City DA, stay in city " & sTmp.City1Text & " for " & sTmp.AmountFactor & " day(s) @ " & sTmp.AmountRate & " Duration " & sTmp.Date1Time & " - " & sTmp.Date2Time
              ElseIf sTmp.StayedInGuestHouse Or sTmp.LodgingProvided Or sTmp.StayedAtSite Then
                If sTmp.City1ID <> String.Empty Then
                  Dim tmp As SIS.TA.taD_GuestHouseDA = SIS.TA.taD_GuestHouseDA.GetByCategoryID(sBill.TACategoryID, sTmp.City1ID, sBill.StartDateTime)
                  If tmp IsNot Nothing Then
                    sTmp.AmountRate = tmp.DA
                  Else
                    tmp = SIS.TA.taD_GuestHouseDA.GetByCategoryIDForOtherCityType(sBill.TACategoryID, sBill.StartDateTime)
                    If tmp IsNot Nothing Then
                      sTmp.AmountRate = tmp.DA
                    Else
                      With sTmp
                        .AmountRate = 0
                        .OOERemarks = "Entitlement for guest house DA in Other City NOT Found."
                      End With
                    End If
                  End If
                Else
                  Dim tmp As SIS.TA.taD_GuestHouseDA = SIS.TA.taD_GuestHouseDA.GetByCategoryIDForOtherCityType(sBill.TACategoryID, sBill.StartDateTime)
                  If tmp IsNot Nothing Then
                    sTmp.AmountRate = tmp.DA
                  Else
                    With sTmp
                      .AmountRate = 0
                      .OOERemarks = "Entitlement for guest house DA in Other City NOT Found."
                    End With
                  End If
                End If
                sTmp.SystemText = CityTypeForDA & " City DA, stay in city " & sTmp.City1Text & " for " & sTmp.AmountFactor & " day(s) @ " & sTmp.AmountRate & " Duration " & sTmp.Date1Time & " - " & sTmp.Date2Time
              ElseIf sTmp.NotStayedAnyWhere Then
                'If CityTypeForDA = "OTHERS" And sBill.SameDayVisit = False Then
                '  CityTypeForDA = "SPECIF"
                'End If
                Dim tmp As SIS.TA.taD_SwrDA = SIS.TA.taD_SwrDA.GetByCategoryID(Convert.ToInt32(sBill.TACategoryID), CityTypeForDA, Convert.ToDateTime(sBill.StartDateTime, ci))
                If tmp IsNot Nothing Then
                  sTmp.AmountRate = tmp.HotelStayDA
                Else
                  With sTmp
                    .AmountRate = 0
                    .OOERemarks = "Entitlement for domestic DA when NOT STAYED ANY WHERE, NOT found."
                  End With
                End If
                sTmp.SystemText = CityTypeForDA & " City DA, stay in city " & sTmp.City1Text & " for " & sTmp.AmountFactor & " day(s) @ " & sTmp.AmountRate & " Duration " & sTmp.Date1Time & " - " & sTmp.Date2Time
              ElseIf sTmp.StayedWithRelative Then
                'Only when there is Night Stay occurs
                Dim NightStayOccured As Boolean = False
                Dim tmpHrs As Integer = DateDiff(DateInterval.Hour, Convert.ToDateTime(sTmp.Date1Time, ci), Convert.ToDateTime(sTmp.Date2Time, ci))
                If tmpHrs >= 24 Then
                  NightStayOccured = True
                Else
                  Dim MidNight As DateTime = DateValue(Convert.ToDateTime(sTmp.Date1Time, ci).AddDays(1))
                  If Convert.ToDateTime(sTmp.Date1Time, ci) <= MidNight And Convert.ToDateTime(sTmp.Date2Time, ci) >= MidNight Then
                    NightStayOccured = True
                  End If
                End If
                If Not NightStayOccured Then
                  'If CityTypeForDA = "OTHERS" And sBill.SameDayVisit = False Then
                  '  CityTypeForDA = "SPECIF"
                  'End If
                  Dim tmp As SIS.TA.taD_SwrDA = SIS.TA.taD_SwrDA.GetByCategoryID(Convert.ToInt32(sBill.TACategoryID), CityTypeForDA, Convert.ToDateTime(sBill.StartDateTime, ci))
                  If tmp IsNot Nothing Then
                    sTmp.AmountRate = tmp.HotelStayDA
                    sTmp.OOERemarks = "Not eligible for SWR, calculated on NOT stayed any where."
                  Else
                    With sTmp
                      .AmountRate = 0
                      .OOERemarks = "NO SWR-Entitlement for domestic DA when NOT STAYED ANY WHERE, NOT found."
                    End With
                  End If
                Else
                  Dim tmp As SIS.TA.taD_SwrDA = SIS.TA.taD_SwrDA.GetByCategoryID(Convert.ToInt32(sBill.TACategoryID), CityTypeForDA, Convert.ToDateTime(sBill.StartDateTime))
                  If tmp IsNot Nothing Then
                    sTmp.AmountRate = tmp.SwrDA
                  Else
                    With sTmp
                      .AmountRate = 0
                      .OOERemarks = "Entitlement for SWR for city type NOT Found."
                    End With
                  End If
                End If
                sTmp.SystemText = CityTypeForDA & " City DA, SWR in city " & sTmp.City1Text & " for " & sTmp.AmountFactor & " day(s) @ " & sTmp.AmountRate & " Duration " & sTmp.Date1Time & " - " & sTmp.Date2Time
              End If
            ElseIf sBill.TravelTypeID = TATravelTypeValues.ForeignTravel Then
              Dim tmp As SIS.TA.taF_LodgDA = SIS.TA.taF_LodgDA.GetByCategoryID(sBill.TACategoryID, RegionID, Convert.ToDateTime(sBill.StartDateTime, ci))
              If tmp IsNot Nothing Then
                If sTmp.BoardingProvided Then
                  'TO DO Get Configuration Value From [TA_F_ForeignTravel] =50%
                  sTmp.AmountRate = tmp.DA / 2
                Else
                  sTmp.AmountRate = tmp.DA
                End If
              Else
                With sTmp
                  .AmountRate = 0
                  .OOERemarks = "Foreign Region Wise DA Entitlement NOT Found."
                End With
              End If
              sTmp.SystemText = RegionID & " region DA, stay in city " & sTmp.City1Text & " for " & sTmp.AmountFactor & " day(s) @ " & sTmp.AmountRate & " Duration " & sTmp.Date1Time & " - " & sTmp.Date2Time
            Else 'Foreign Site Visit
              Dim tmp As SIS.TA.taF_SiteDA = SIS.TA.taF_SiteDA.GetByCategoryID(Convert.ToInt32(sBill.TACategoryID), Convert.ToDateTime(sBill.StartDateTime, ci))
              If tmp IsNot Nothing Then
                If sBill.FK_TA_Bills_EmployeeID.Contractual Then
                  If sBill.FK_TA_Bills_EmployeeID.NonTechnical Then
                    If sTmp.BoardingProvided Then
                      sTmp.AmountRate = tmp.Cont_NonT_Bord_DA
                    Else
                      sTmp.AmountRate = tmp.Cont_NonT_DA
                    End If
                  Else
                    If sTmp.BoardingProvided Then
                      sTmp.AmountRate = tmp.Cont_Tech_Bord_DA
                    Else
                      sTmp.AmountRate = tmp.Cont_Tech_DA
                    End If
                  End If
                Else
                  If sTmp.BoardingProvided Then
                    sTmp.AmountRate = tmp.Perm_Bord_DA
                  Else
                    sTmp.AmountRate = tmp.Perm_DA
                  End If
                End If
              Else
                With sTmp
                  .AmountRate = 0
                  .OOERemarks = "Foreign Site Visit DA Entitlement NOT Found."
                End With
              End If
              sTmp.SystemText = "Site Visit DA, stay at site for " & sTmp.AmountFactor & " day(s) @ " & sTmp.AmountRate & " Duration " & sTmp.Date1Time & " - " & sTmp.Date2Time
            End If
          End If
          If sTmp.AmountFactor > 0 Then
            SIS.TA.taBillDetails.UZ_taBillDetailsInsert(sTmp)
          End If
          If LimitDays > 0 Then
            If TotalDADays >= LimitDays Then
              Return TotalDADays
            End If
          End If
        Next
      Catch ex As Exception
        Dim aa As String = ""
      End Try
      Return TotalDADays
    End Function

#End Region
    Private Shared Sub ValidateLC(ByVal sBill As SIS.TA.taBH, ByVal sTmps As List(Of SIS.TA.taBillDetails))
      Dim ci As System.Globalization.CultureInfo = SIS.SYS.Utilities.SessionManager.ci
      For Each sTmp As SIS.TA.taBillDetails In sTmps
        Select Case sTmp.ComponentID
          Case TAComponentTypes.LC
            With sTmp
              .OOEBySystem = False
              .OOERemarks = ""
            End With
            If sBill.TravelTypeID = TATravelTypeValues.Domestic Or sTmp.IsDomestic Then
              If sTmp.ModeLCID <> String.Empty Then
                Dim tmp As SIS.TA.taD_LCModes = SIS.TA.taD_LCModes.GetByCategoryID(Convert.ToInt32(sBill.TACategoryID), Convert.ToDateTime(sTmp.Date1Time, ci))
                If tmp IsNot Nothing Then
                  If Convert.ToInt32(sTmp.FK_TA_BillDetails_ModeLCID.Sequence) < Convert.ToInt32(tmp.FK_TA_D_LCModes_LCModeID.Sequence) Then
                    'Hard Coded DM/AM Allowed Taxi for airport pick n drop
                    If (sBill.TACategoryID = 8 And tmp.LCModeID = 3 And sTmp.AirportToHotel) Or (sBill.TACategoryID = 8 And tmp.LCModeID > 3) Then
                    Else
                      If sTmp.AmountInINR > 0 Then
                        With sTmp
                          .OOEBySystem = True
                          .OOERemarks = "Local Conveyance Mode is OVER entitlement [" & tmp.FK_TA_D_LCModes_LCModeID.ModeName & "]."
                        End With
                      End If
                    End If
                  End If
                Else
                  With sTmp
                    .OOEBySystem = True
                    .OOERemarks = "Local Conveyance Entitlement NOT Found."
                  End With
                End If
              Else
                With sTmp
                  .OOEBySystem = True
                  .OOERemarks = ""
                End With
              End If
              If sTmp.AmountInINR > 750 Then
                If Not sTmp.OOEBySystem Then
                  sTmp.OOERemarks = "Bill is required."
                End If
              End If
            Else
              'Validation for Foreign Travel
              If sTmp.CurrencyID <> "INR" Then
                If Not sTmp.HotelToAirport And Not sTmp.AirportToHotel And Not sTmp.AirportToClientLocation Then
                  If sTmp.AmountInINR > 0 Then
                    With sTmp
                      .OOEBySystem = True
                      .OOERemarks = "Requires Special MD Sanction to be attached."
                    End With
                  End If
                End If
              End If
            End If
            SIS.TA.taBillDetails.UpdateData(sTmp)
        End Select
      Next
      '20% LC Clause in Foreign Travel To be written
      '=======New Logic=============
      If sBill.TravelTypeID <> TATravelTypeValues.Domestic AndAlso sBill.TravelTypeID <> TATravelTypeValues.HomeVisit Then
        Dim TotalLC As Decimal = 0
        Dim L_Date As String = ""
        For Each sTmp As SIS.TA.taBillDetails In sTmps
          Select Case sTmp.ComponentID
            Case TAComponentTypes.LC
              'Consider only FC records
              If sTmp.CurrencyID = "INR" Then Continue For
              'Consider Only Foreign LC, Excluding Allowed Types
              If Not sTmp.HotelToAirport And Not sTmp.AirportToHotel And Not sTmp.AirportToClientLocation Then Continue For
              If L_Date = "" Then
                L_Date = sTmp.Date1Time
                TotalLC = sTmp.AmountTotal
              ElseIf L_Date = sTmp.Date1Time Then
                TotalLC += sTmp.AmountTotal
              Else
                If TotalLC > 0 Then
                  ValidateLCDeduction(L_Date, TotalLC, sTmps)
                End If
                L_Date = sTmp.Date1Time
                TotalLC = sTmp.AmountTotal
              End If
          End Select
        Next
        If TotalLC > 0 Then
          ValidateLCDeduction(L_Date, TotalLC, sTmps)
        End If
      End If
      '=======End of New Logic======
      '=======Old Logic=============
      ''If sBill.TravelTypeID <> TATravelTypeValues.Domestic Then
      ''  Dim TotalDA As Decimal = 0
      ''  Dim TotalLC As Decimal = 0
      ''  For Each sTmp As SIS.TA.taBillDetails In sTmps
      ''    Select Case sTmp.ComponentID
      ''      Case TAComponentTypes.DA
      ''        TotalDA += sTmp.PassedAmountTotal
      ''      Case TAComponentTypes.LC
      ''        If sTmp.CurrencyID <> "INR" Then
      ''          'Consider Only Foreign LC, Excluding Allowed Types
      ''          If Not sTmp.HotelToAirport And Not sTmp.AirportToHotel And Not sTmp.AirportToClientLocation Then
      ''            TotalLC += sTmp.PassedAmountTotal
      ''          End If
      ''        End If
      ''    End Select
      ''  Next
      ''  'TO DO Get Configuration Value From [TA_F_ForeignTravel] =20%
      ''  'Create LC Adjustment Record 
      ''  Dim LCPercent As Decimal = 0
      ''  Try
      ''    LCPercent = (TotalLC / TotalDA) * 100
      ''  Catch ex As Exception
      ''  End Try
      ''  If LCPercent <= 20 Then
      ''    'Create LC Adjustment Record in Finance Sources
      ''    If TotalLC > 0 Then
      ''      Dim Tmp As New SIS.TA.taBillDetails
      ''      With Tmp
      ''        .TABillNo = sBill.TABillNo
      ''        .AutoCalculated = True
      ''        .SerialNo = 0
      ''        .ProjectID = .FK_TA_BillDetails_TABillNo.ProjectID
      ''        .CostCenterID = .FK_TA_BillDetails_TABillNo.CostCenterID
      ''        .CurrencyID = .FK_TA_BillDetails_TABillNo.BillCurrencyID
      ''        .ConversionFactorINR = .FK_TA_BillDetails_TABillNo.ConversionFactorINR
      ''        .Date1Time = sBill.StartDateTime
      ''        .Date2Time = sBill.EndDateTime
      ''        .ComponentID = TAComponentTypes.Expense
      ''        .ModeExpenseID = 1 'Foreign Travel LC Adjustment
      ''        .AmountFactor = TotalLC
      ''        .AmountTax = 0
      ''        .AmountRate = 0
      ''        .SystemText = "Foreign Travel Local Conveyance NOT Paid if less than 20%."
      ''      End With
      ''      SIS.TA.taBillDetails.UZ_taBillDetailsInsert(Tmp)
      ''    End If
      ''  Else
      ''    'Deduct 20% from DA
      ''    Dim DADeducted As Decimal = 0
      ''    DADeducted = TotalDA * 0.2
      ''    If DADeducted > 0 Then
      ''      Dim Tmp As New SIS.TA.taBillDetails
      ''      With Tmp
      ''        .TABillNo = sBill.TABillNo
      ''        .AutoCalculated = True
      ''        .SerialNo = 0
      ''        .ProjectID = .FK_TA_BillDetails_TABillNo.ProjectID
      ''        .CostCenterID = .FK_TA_BillDetails_TABillNo.CostCenterID
      ''        .CurrencyID = .FK_TA_BillDetails_TABillNo.BillCurrencyID
      ''        .ConversionFactorINR = .FK_TA_BillDetails_TABillNo.ConversionFactorINR
      ''        .Date1Time = sBill.StartDateTime
      ''        .Date2Time = sBill.EndDateTime
      ''        .ComponentID = TAComponentTypes.Expense
      ''        .ModeExpenseID = 1 'Foreign Travel LC Adjustment
      ''        .AmountFactor = DADeducted
      ''        .AmountTax = 0
      ''        .AmountRate = 0
      ''        .SystemText = "Foreign Travel DA Deducted by 20%, if Local conveyance is > 20%."
      ''      End With
      ''      SIS.TA.taBillDetails.UZ_taBillDetailsInsert(Tmp)
      ''    End If
      ''  End If
      ''End If
      '========Old Logic============
    End Sub
    Private Shared Sub ValidateLCDeduction(ByVal tmpDate As String, ByVal TotalLC As Decimal, ByVal sTmps As List(Of SIS.TA.taBillDetails))
      'TO DO Get Configuration Value From [TA_F_ForeignTravel] =20%
      Dim LCPercent As Decimal = 20
      Dim DAForTheDay As Decimal = 0
      Dim DARecord As SIS.TA.taBillDetails = GetDAForTheDate(tmpDate, sTmps)
      'If NO DA Record found, then deduction is to be done.
      If DARecord IsNot Nothing Then
        DAForTheDay = DARecord.AmountRate
        Dim LCAmount As Decimal = DAForTheDay * LCPercent / 100
        If TotalLC > LCAmount Then
          'Create DA Deduction Record
          With DARecord
            .AutoCalculated = True
            .SerialNo = 0
            .Date1Time = tmpDate
            .Date2Time = ""
            .AmountFactor = 1
            .AmountTax = 0
            .AmountRate = -1 * LCAmount
            .SystemText = "Foreign Travel DA Deducted by " & LCPercent & "%, if Local conveyance is > " & LCPercent & "%."
          End With
          SIS.TA.taBillDetails.UZ_taBillDetailsInsert(DARecord)
        End If
      End If
    End Sub
    Private Shared Function GetDAForTheDate(ByVal tmpDate As String, ByVal sTmps As List(Of SIS.TA.taBillDetails)) As SIS.TA.taBillDetails
      Dim mRet As SIS.TA.taBillDetails = Nothing
      Dim ci As System.Globalization.CultureInfo = SIS.SYS.Utilities.SessionManager.ci
      For Each sTmp As SIS.TA.taBillDetails In sTmps
        Select Case sTmp.ComponentID
          Case TAComponentTypes.DA
            mRet = sTmp
            Try
              If Convert.ToDateTime(tmpDate, ci) >= Convert.ToDateTime(sTmp.Date1Time, ci) And Convert.ToDateTime(tmpDate, ci) <= Convert.ToDateTime(sTmp.Date2Time, ci) Then
                'If No DA Record found for Asked Date then Last DA Record will be returned
                'Try Block skips the -ve DA Deduction record due to LC, as Date2Time is blank in such record.
                Exit For
              End If
            Catch ex As Exception
            End Try
        End Select
      Next
      Return mRet
    End Function
    Private Shared Sub CreateDriverChargesRecord(ByVal sBill As SIS.TA.taBH, ByVal sTmps As List(Of SIS.TA.taBillDetails))
      Dim ci As System.Globalization.CultureInfo = SIS.SYS.Utilities.SessionManager.ci
      Dim TotalMileageHrs As Long = 0
      Dim tmp_sDt As DateTime = Now
      Dim tmp_eDT As DateTime = Now
      Dim First As Boolean = True
      For Each sTmp As SIS.TA.taBillDetails In sTmps
        If sTmp.ComponentID = TAComponentTypes.Mileage Then
          If First Then
            First = False
            tmp_sDt = Convert.ToDateTime(sTmp.Date1Time, ci)
            tmp_eDT = Convert.ToDateTime(sTmp.Date2Time, ci)
          Else
            If Convert.ToDateTime(sTmp.Date1Time, ci) < tmp_sDt Then
              tmp_sDt = Convert.ToDateTime(sTmp.Date1Time, ci)
            End If
            If Convert.ToDateTime(sTmp.Date2Time, ci) > tmp_eDT Then
              tmp_eDT = Convert.ToDateTime(sTmp.Date2Time, ci)
            End If
          End If
        End If
      Next
      TotalMileageHrs = DateDiff(DateInterval.Hour, tmp_sDt, tmp_eDT)
      Dim TotalMileageDays As Integer = TotalMileageHrs \ 24
      Dim TotalMileageBalanceHrs As Integer = TotalMileageHrs Mod 24
      Dim TotalMileageHalfDay As Integer = 0
      If TotalMileageBalanceHrs >= 8 Then
        TotalMileageDays += 1
      ElseIf TotalMileageBalanceHrs >= 4 Then
        TotalMileageHalfDay = 1
      End If
      Dim TotalMileageActualDays As Decimal = TotalMileageDays
      If TotalMileageHalfDay > 0 Then
        TotalMileageActualDays += 0.5
      End If
      'Insert Driver Charges Record
      If TotalMileageActualDays > 0 Then
        Dim tmpCate As Integer = sBill.TACategoryID
        If tmpCate = 5 Then 'GM/DGM
          Try
            If sBill.FK_TA_Bills_EmployeeID.C_DesignationID = 7 Then 'DGM
              tmpCate = 6 'AGM
            End If
          Catch ex As Exception
          End Try
        End If
        Dim tmp As SIS.TA.taD_Driver = SIS.TA.taD_Driver.GetByCategoryID(tmpCate, tmp_sDt)
        If tmp IsNot Nothing Then
          'Employee is entitled for Driver
          Dim tmp_BD As New SIS.TA.taBillDetails
          With tmp_BD
            .TABillNo = sBill.TABillNo
            .AutoCalculated = True
            .ProjectID = .FK_TA_BillDetails_TABillNo.ProjectID
            .CostCenterID = .FK_TA_BillDetails_TABillNo.CostCenterID
            .CurrencyID = .FK_TA_BillDetails_TABillNo.BillCurrencyID
            .ConversionFactorINR = .FK_TA_BillDetails_TABillNo.ConversionFactorINR
            .SerialNo = 0
            .ComponentID = TAComponentTypes.Driver
            .Date1Time = tmp_sDt
            .Date2Time = tmp_eDT
            .ModeText = "Driver Charges"
            .AmountFactor = TotalMileageActualDays
            .AmountRate = tmp.DriverAmount
            .AmountTax = 0
            .SystemText = "Driver Charges for " & .AmountFactor & " day(s) @ " & .AmountRate
            If TotalMileageActualDays > 3 Then
              .OOEBySystem = True
              .OOERemarks = "More than 3 days of driver charges requires Special Sanction."
            Else
              .OOERemarks = ""
              .OOEBySystem = False
            End If
          End With
          SIS.TA.taBillDetails.UZ_taBillDetailsInsert(tmp_BD)
        End If
      End If
    End Sub
    Private Shared Sub SameDayVisitDA_Old(ByVal sBill As SIS.TA.taBH, ByVal sTmps As List(Of SIS.TA.taBillDetails))

      Dim sTmp As New SIS.TA.taBillDetails
      With sTmp
        .TABillNo = sBill.TABillNo
        .AutoCalculated = True
        .SerialNo = 0
        .ProjectID = .FK_TA_BillDetails_TABillNo.ProjectID
        .CostCenterID = .FK_TA_BillDetails_TABillNo.CostCenterID
        .CurrencyID = .FK_TA_BillDetails_TABillNo.BillCurrencyID
        .ConversionFactorINR = .FK_TA_BillDetails_TABillNo.ConversionFactorINR
        .CityTypeID = sBill.FK_TA_Bills_DestinationCity.CityTypeForDA
        .Date1Time = sBill.StartDateTime
        .Date2Time = sBill.EndDateTime
        .ComponentID = TAComponentTypes.DA
        .AmountFactor = 1
        .AmountRate = 0
        If .CityTypeID <> "OTHERS" Then
          .CityTypeID = "SPECIF"
        End If
        Dim tmp As SIS.TA.taD_SwrDA = SIS.TA.taD_SwrDA.GetByCategoryID(Convert.ToInt32(sBill.TACategoryID), sTmp.CityTypeID, Convert.ToDateTime(sBill.StartDateTime))
        If tmp IsNot Nothing Then
          .AmountRate = tmp.HotelStayDA
        End If
        .AmountTax = 0
      End With
      sTmp.SystemText = "Same day visit DA for " & sTmp.CityTypeID
      SIS.TA.taBillDetails.UZ_taBillDetailsInsert(sTmp)
    End Sub
    Private Shared Sub TrainingProgramDA(ByVal sBill As SIS.TA.taBH)
      Dim sTmp As New SIS.TA.taBillDetails
      With sTmp
        .TABillNo = sBill.TABillNo
        .AutoCalculated = True
        .SerialNo = 0
        .ProjectID = .FK_TA_BillDetails_TABillNo.ProjectID
        .CostCenterID = .FK_TA_BillDetails_TABillNo.CostCenterID
        .CurrencyID = .FK_TA_BillDetails_TABillNo.BillCurrencyID
        .ConversionFactorINR = .FK_TA_BillDetails_TABillNo.ConversionFactorINR
        .CityTypeID = sBill.FK_TA_Bills_DestinationCity.CityTypeForDA
        .Date1Time = sBill.StartDateTime
        .Date2Time = sBill.EndDateTime
        .ComponentID = TAComponentTypes.DA
        .AmountFactor = sBill.TotalTravelDays
        .AmountRate = 0
        Dim tmp As SIS.TA.taD_SwrDA = SIS.TA.taD_SwrDA.GetByCategoryID(Convert.ToInt32(sBill.TACategoryID), sTmp.CityTypeID, Convert.ToDateTime(sBill.StartDateTime))
        If tmp IsNot Nothing Then
          If sBill.TrainingProgram Then 'NON Residential
            .AmountRate = tmp.HotelStayDA * 0.65
            sTmp.SystemText = "NON Residential Training Program DA 65% of actual DA " & tmp.HotelStayDA
          ElseIf sBill.TaxiHired Then 'Residential  
            .AmountRate = tmp.HotelStayDA * 0.3
            sTmp.SystemText = "Residential Training Program DA 30% of actual DA " & tmp.HotelStayDA
          End If
        End If
        .AmountTax = 0
      End With
      SIS.TA.taBillDetails.UZ_taBillDetailsInsert(sTmp)
    End Sub

    Private Shared Sub AddContingencyAllowance(ByVal sBill As SIS.TA.taBH)
      Dim sTmp As New SIS.TA.taBillDetails
      With sTmp
        .TABillNo = sBill.TABillNo
        .AutoCalculated = True
        .SerialNo = 0
        .ProjectID = .FK_TA_BillDetails_TABillNo.ProjectID
        .CostCenterID = .FK_TA_BillDetails_TABillNo.CostCenterID
        .CurrencyID = .FK_TA_BillDetails_TABillNo.BillCurrencyID
        .ConversionFactorINR = .FK_TA_BillDetails_TABillNo.ConversionFactorINR
        .CityTypeID = "SPECIF"
        .Date1Time = sBill.StartDateTime
        .Date2Time = sBill.EndDateTime
        .ModeExpenseID = 1 ' Contingency
        .ModeText = "Contingency Allowance Foreign Travel"
        .ComponentID = TAComponentTypes.Expense
        .AmountFactor = 50
        .AmountRate = 1
        'Pick contingency DA
        'Dim tmp As SIS.TA.taD_SwrDA = SIS.TA.taD_SwrDA.GetByCategoryID(Convert.ToInt32(sBill.TACategoryID), sTmp.CityTypeID, Convert.ToDateTime(sBill.StartDateTime))
        'If tmp IsNot Nothing Then
        '  .AmountRate = tmp.HotelStayDA
        'End If
        .AmountTax = 0
      End With
      sTmp.SystemText = "Contingency Allowance Foreign Travel " & sTmp.AmountRate
      SIS.TA.taBillDetails.UZ_taBillDetailsInsert(sTmp)
    End Sub
    Public Shared Sub UpdateProjectwiseDistribution(ByVal sBill As SIS.TA.taBH)
      Dim pAmts As List(Of SIS.TA.taBillPrjAmounts) = SIS.TA.taBillPrjAmounts.taBillPrjAmountsSelectList(0, 999, "", False, "", sBill.TABillNo)
      If pAmts.Count > 0 Then
        For Each pAmt As SIS.TA.taBillPrjAmounts In pAmts
          If pAmt.TotalAmountinINR = 0 Then
            SIS.TA.taBillPrjAmounts.taBillPrjAmountsDelete(pAmt)
          End If
        Next
        pAmts = SIS.TA.taBillPrjAmounts.taBillPrjAmountsSelectList(0, 999, "", False, "", sBill.TABillNo)
        'If sBill.PrjCalcType = TAPrjCalcType.Actual Then Do Nothing
        If sBill.PrjCalcType = TAPrjCalcType.EqualizedDistribution Then
          Dim cntTmp As Integer = pAmts.Count
          Dim prcnt As Integer = 0
          Try
            prcnt = 100 / cntTmp
          Catch ex As Exception
          End Try
          Dim factor As Integer = 0
          Dim totFactor As Decimal = 0
          If prcnt * cntTmp <> 100 Then
            factor = 100 - (prcnt * cntTmp)
          End If
          For Each pAmt As SIS.TA.taBillPrjAmounts In pAmts
            pAmt.Percentage = prcnt + factor
            pAmt.TotalAmountinINR = sBill.TotalPayableAmount * (pAmt.Percentage / 100)
            totFactor += pAmt.TotalAmountinINR
            SIS.TA.taBillPrjAmounts.UpdateData(pAmt)
            factor = 0
          Next
          totFactor = sBill.TotalPayableAmount - totFactor
          If totFactor <> 0 Then
            If pAmts.Count > 0 Then
              pAmts(0).TotalAmountinINR = pAmts(0).TotalAmountinINR + totFactor
              SIS.TA.taBillPrjAmounts.UpdateData(pAmts(0))
            End If
          End If
        ElseIf sBill.PrjCalcType = TAPrjCalcType.AsPerDefinedPercentage Then
          Dim prcnt As Integer = 0
          Dim factor As Integer = 0
          Dim totFactor As Decimal = 0
          For Each pAmt As SIS.TA.taBillPrjAmounts In pAmts
            prcnt += pAmt.Percentage
          Next
          factor = 100 - prcnt
          For Each pAmt As SIS.TA.taBillPrjAmounts In pAmts
            pAmt.Percentage = pAmt.Percentage + factor
            pAmt.TotalAmountinINR = sBill.TotalPayableAmount * (pAmt.Percentage / 100)
            totFactor += pAmt.TotalAmountinINR
            SIS.TA.taBillPrjAmounts.UpdateData(pAmt)
            factor = 0
          Next
          totFactor = sBill.TotalPayableAmount - totFactor
          If totFactor <> 0 Then
            If pAmts.Count > 0 Then
              pAmts(0).TotalAmountinINR = pAmts(0).TotalAmountinINR + totFactor
              SIS.TA.taBillPrjAmounts.UpdateData(pAmts(0))
            End If
          End If
        End If
      End If
      'End Project wise distribution
    End Sub
    Public Shared Sub UpdateBillAmountTotal(ByVal sBill As SIS.TA.taBH)
      Dim sAmts As List(Of SIS.TA.taBillAmount) = SIS.TA.taBillAmount.UZ_taBillAmountSelectList(0, 999, "", False, "", sBill.TABillNo)
      For Each sAmt As SIS.TA.taBillAmount In sAmts
        Dim tmp As SIS.TA.taBillAmount = SIS.TA.taBillAmount.taBillAmountGetByID(sAmt.TABillNo, TAComponentTypes.Total, sAmt.CurrencyID, sAmt.CostCenterID)
        If tmp Is Nothing Then
          If sAmt.ComponentID <> TAComponentTypes.Finance Then
            tmp = New SIS.TA.taBillAmount
            With tmp
              .TABillNo = sAmt.TABillNo
              .ComponentID = TAComponentTypes.Total
              .CurrencyID = sAmt.CurrencyID
              .CostCenterID = sAmt.CostCenterID
              .TotalInCurrency = sAmt.TotalInCurrency
              .TotalInINR = sAmt.TotalInINR
            End With
            SIS.TA.taBillAmount.InsertData(tmp)
          End If
        Else
          If sAmt.ComponentID <> TAComponentTypes.Finance Then
            With tmp
              .TotalInCurrency += sAmt.TotalInCurrency
              .TotalInINR += sAmt.TotalInINR
            End With
            SIS.TA.taBillAmount.UpdateData(tmp)
          End If
        End If
      Next
    End Sub

#End Region
#Region " VALIDATE TA BILL MAIN FUNCTION "
    Public Shared Sub ValidateTABill(ByVal TABillNo As Integer)
      InitializeTABill(TABillNo)
      Dim ci As System.Globalization.CultureInfo = SIS.SYS.Utilities.SessionManager.ci
      Dim sBill As SIS.TA.taBH = SIS.TA.taBH.taBHGetByID(TABillNo)
      Dim sTmps As List(Of SIS.TA.taBillDetails) = SIS.TA.taBillDetails.taBillDetailsSelectList(0, 999, "", False, "", TABillNo)
      '1. Validate Fare Record for Travel Mode. NO Dependancy
      ValidateFare(sBill, sTmps)
      '2. Validate Lodging before DA Calculation
      ValidateLodging(sBill, sTmps)
      '3. Calculate DA before LC Mode [Domestic]-No dependancy, Foreign LC-Dependancy on TOTAL DA's 20%
      If sBill.TravelTypeID <> TATravelTypeValues.HomeVisit Then
        CalculateDA(sBill, sTmps)
      End If
      '4. Validate LC
      sTmps = SIS.TA.taBillDetails.taBillDetailsSelectList(0, 999, "", False, "", TABillNo)
      ValidateLC(sBill, sTmps)
      '5. Create Driver Charges Record based on Mileage
      If sBill.CalculateDriverCharges Then
        CreateDriverChargesRecord(sBill, sTmps)
      End If
      '6. Create Contingency Allowance Record for Foreign
      If sBill.TravelTypeID <> TATravelTypeValues.Domestic AndAlso sBill.TravelTypeID <> TATravelTypeValues.HomeVisit Then
        If Not sBill.SiteToAnotherSite Then 'This is not Partial TA Bill
          Dim IsBangladesh As Boolean = True
          Dim CountryID As String = ""
          If sBill.DestinationCity <> String.Empty Then
            CountryID = sBill.FK_TA_Bills_DestinationCity.CountryID
          End If
          If Not CountryID = "Bangladesh" Then
            AddContingencyAllowance(sBill)
          End If
        End If
      End If
      '7. Update INR Value based on Calculation type & Header OOEBySystem
      sBill.OOEBySystem = False
      sTmps = SIS.TA.taBillDetails.taBillDetailsSelectList(0, 999, "", False, "", TABillNo)
      For Each sTmp As SIS.TA.taBillDetails In sTmps
        If sBill.CalculationTypeID = TACalculationTypes.ConvertAtGrossLevel Then
          sTmp.AmountInINR = sTmp.AmountTotal * sBill.ConversionFactorINR
          sTmp.PassedAmountInINR = sTmp.PassedAmountTotal * sBill.ConversionFactorINR
        Else
          sTmp.AmountInINR = sTmp.AmountTotal * sTmp.ConversionFactorINR
          sTmp.PassedAmountInINR = sTmp.PassedAmountTotal * sTmp.ConversionFactorINR
        End If
        SIS.TA.taBillDetails.UpdateData(sTmp)
        '====Update Business Head/MD Approval Required
        If sTmp.OOEBySystem Then
          sBill.OOEBySystem = True
        End If
        '=============================================
      Next
      '8-A. Update Project wise total as per actual
      For Each sTmp As SIS.TA.taBillDetails In sTmps
        If sTmp.ProjectID <> String.Empty Then
          Dim pAmt As SIS.TA.taBillPrjAmounts = SIS.TA.taBillPrjAmounts.taBillPrjAmountsGetByID(sTmp.TABillNo, sTmp.ProjectID)
          If pAmt Is Nothing Then
            pAmt = New SIS.TA.taBillPrjAmounts
            With sTmp
              pAmt.TABillNo = .TABillNo
              pAmt.ProjectID = .ProjectID
              pAmt.TotalAmountinINR = .PassedAmountInINR
            End With
            SIS.TA.taBillPrjAmounts.InsertData(pAmt)
          Else
            pAmt.TotalAmountinINR += sTmp.PassedAmountInINR
            SIS.TA.taBillPrjAmounts.UpdateData(pAmt)
          End If
        End If
        '8-B. Bill Amounts
        Dim CurrencyID As String = sTmp.CurrencyID
        If sTmp.CurrencyID = "OTH" Then
          CurrencyID = sTmp.FK_TA_BillDetails_TABillNo.BillCurrencyID
        End If
        Dim sAmt As SIS.TA.taBillAmount = SIS.TA.taBillAmount.taBillAmountGetByID(sTmp.TABillNo, sTmp.ComponentID, CurrencyID, sTmp.CostCenterID)
        If sAmt Is Nothing Then
          sAmt = New SIS.TA.taBillAmount
          With sTmp
            sAmt.TABillNo = .TABillNo
            sAmt.ComponentID = .ComponentID
            sAmt.CurrencyID = CurrencyID
            sAmt.CostCenterID = .CostCenterID
            sAmt.TotalInCurrency = .PassedAmountTotal
            sAmt.TotalInINR = .PassedAmountInINR
            sAmt.CalculationTypeID = sBill.CalculationTypeID
            If sBill.CalculationTypeID = TACalculationTypes.ConvertAtGrossLevel Then
              sAmt.ConversionFactorINR = .ConversionFactorINR
            End If
          End With
          SIS.TA.taBillAmount.InsertData(sAmt)
        Else
          With sTmp
            sAmt.TotalInCurrency += .PassedAmountTotal
            sAmt.TotalInINR += .PassedAmountInINR
            sAmt.CalculationTypeID = sBill.CalculationTypeID
            If sBill.CalculationTypeID = TACalculationTypes.ConvertAtGrossLevel Then
              sAmt.ConversionFactorINR = .ConversionFactorINR
            End If
          End With
          SIS.TA.taBillAmount.UpdateData(sAmt)
        End If
        '8-C. Update Bill Header
        If sTmp.ComponentID <> TAComponentTypes.Finance Then
          With sTmp
            If sBill.CalculationTypeID = TACalculationTypes.ConvertAtIndividualLevel Then
              sBill.TotalClaimedAmount += (.AmountTotal * .ConversionFactorINR)
            Else
              sBill.TotalClaimedAmount += (.AmountTotal * sBill.ConversionFactorINR)
            End If
            sBill.TotalPassedAmount += (.PassedAmountInINR)
            sBill.TotalPayableAmount = sBill.TotalPassedAmount '- sBill.TotalFinancedAmount
          End With
        Else
          With sTmp
            If sBill.CalculationTypeID = TACalculationTypes.ConvertAtIndividualLevel Then
              sBill.TotalFinancedAmount += (.PassedAmountTotal * .ConversionFactorINR)
            Else
              sBill.TotalFinancedAmount += (.PassedAmountTotal * sBill.ConversionFactorINR)
            End If
            sBill.TotalPayableAmount = sBill.TotalPassedAmount '- sBill.TotalFinancedAmount
          End With
        End If
      Next
      SIS.TA.taBH.UpdateData(sBill)
      '9. Project wise Distribute as per Distribution Method
      Try
        UpdateProjectwiseDistribution(sBill)
      Catch ex As Exception
      End Try
      '10. Calculate TOTAL of Bill Amounts in TOTAL Record Line
      Try
        UpdateBillAmountTotal(sBill)
      Catch ex As Exception
      End Try
    End Sub

#End Region

    Public Shared Shadows Function SendEMail(ByVal oTA As SIS.TA.taBH) As String
      Dim mRet As String = ""
      Dim First As Boolean = True
      Dim Cnt As Integer = 0
      Dim mRecipients As New StringBuilder
      Dim maySend As Boolean = False

      Dim oClient As SmtpClient = New SmtpClient()
      Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
      Dim oEmp As SIS.TA.taEmployees = oTA.FK_TA_Bills_EmployeeID
      Dim oTmp As SIS.TA.taEmployees = Nothing
      Dim ad As MailAddress = Nothing
      Dim fad As MailAddress = Nothing
      Dim Subject As String = ""
      Dim Header As String = ""
      Dim LastLine As String = ""


      'From EMail
      If oEmp.EMailID <> String.Empty Then
        fad = New MailAddress(oEmp.EMailID, oEmp.EmployeeName)
        oMsg.From = fad
        oMsg.CC.Add(fad)
      End If
      If oTA.BillStatusID = TAStates.UnderVerification Then
        oTmp = SIS.TA.taEmployees.taEmployeesGetByID(oEmp.TAVerifier)
        If oTmp.EMailID <> String.Empty Then
          ad = New MailAddress(oTmp.EMailID, oTmp.EmployeeName)
          oMsg.To.Add(ad)
          Subject = "Verify TA Bill of " & oEmp.EmployeeName
          Header = "TA BILL VERIFICATION NOTIFICATION"
          LastLine = "TA is submitted to you for verification. Please Log in online TA Bill System to verify the same."
        End If
      ElseIf oTA.BillStatusID = TAStates.UnderApproval Then
        oTmp = SIS.TA.taEmployees.taEmployeesGetByID(oEmp.TAApprover)
        If oTmp.EMailID <> String.Empty Then
          ad = New MailAddress(oTmp.EMailID, oTmp.EmployeeName)
          oMsg.To.Add(ad)
          Subject = "Approve TA Bill of " & oEmp.EmployeeName
          Header = "TA BILL APPROVAL NOTIFICATION"
          LastLine = "TA is submitted to you for approval. Please Log in online TA Bill System to approve the same."
        End If
      ElseIf oTA.BillStatusID = TAStates.UnderSpecialSanction Then
        oTmp = SIS.TA.taEmployees.taEmployeesGetByID(oEmp.TASanctioningAuthority)
        If oTmp.EMailID <> String.Empty Then
          ad = New MailAddress(oTmp.EMailID, oTmp.EmployeeName)
          oMsg.To.Add(ad)
          Subject = "Sanction TA Bill of " & oEmp.EmployeeName
          Header = "TA BILL SPL. SANCTION NOTIFICATION"
          LastLine = "TA is submitted to you for spl. sanction. Please Log in online TA Bill System to sanction the same."
        End If
      ElseIf oTA.BillStatusID = TAStates.UnderReceiveByAccounts Then
        oMsg.To.Add(fad)
        oMsg.CC.Clear()
        Subject = "TA Bill No. " & oTA.TABillNo & " Submitted to A/c, Dest.: " & oTA.DestinationCity
        Header = "TA BILL SUBMITTED TO ACCOUNTS"
        LastLine = "TA is submitted to Accounts for processing, Now, You may take Print of TA Bill and submit to A/c with required bills/sanction."
      End If
      oMsg.IsBodyHtml = True
      oMsg.Subject = Subject
      Dim sb As New StringBuilder
      With sb
        .AppendLine("<table style=""width:900px"" border=""1"" cellspacing=""1"" cellpadding=""1"">")
        .AppendLine("<tr><td colspan=""2"" align=""center""><h3><b>" & Header & "</b></h3></td></tr>")
        .AppendLine("<tr><td bgcolor=""lightgray""><b>TA Bill No.</b></td>")
        .AppendLine("<td>" & oTA.TABillNo & "</td></tr>")
        .AppendLine("<tr><td bgcolor=""lightgray""><b>TA Period</b></td>")
        .AppendLine("<td>" & "From : " & oTA.StartDateTime & " To : " & oTA.EndDateTime & "</td></tr>")
        .AppendLine("<tr><td bgcolor=""lightgray""><b>Purpose</b></td>")
        .AppendLine("<td>" & oTA.PurposeOfJourney & "</td></tr>")
        .AppendLine("<tr><td bgcolor=""lightgray""><b>Total Claimed Amt.</b></td>")
        .AppendLine("<td>" & oTA.TotalClaimedAmount & "</td></tr>")
        .AppendLine("<tr><td colspan=""2"">" & LastLine & "</td>")
        .AppendLine("</table>")
        .AppendLine("<br/><br/>")
        'Select Case oTA.BillStatusID
        '  Case TAStates.UnderSpecialSanction
        '    .AppendLine("<table style=""width:900px"" border=""1"" cellspacing=""1"" cellpadding=""1"">")
        '    .AppendLine("<tr><td colspan=""2""><b>Use links below, if approving from Smart Phones / Blackberry.</b></td>")
        '    .AppendLine("<tr><td bgcolor=""green"" style=""text-align:center;height:30px;color:white;""><a style='color:white;' href=""http://cloud.isgec.co.in/WebTA1/taOnline.aspx?ataBillNo=" & oTA.TABillNo & """><b>Approve</b></a></td>")
        '    .AppendLine("<td bgcolor=""red"" style=""text-align:center;color:white;""><a style='color:white;' href=""http://cloud.isgec.co.in/WebTA1/taOnline.aspx?rtaBillNo=" & oTA.TABillNo & """><b>Reject</b></a></td></tr>")
        '    .AppendLine("<tr><td colspan=""2""><b>Use links below, if approving from within office premise using office Network.</b></td>")
        '    .AppendLine("<tr><td bgcolor=""green"" style=""text-align:center;height:30px;color:white;""><a style='color:white;' href=""http://192.9.200.146/WebTA1/taOnline.aspx?ataBillNo=" & oTA.TABillNo & """><b>Approve</b></a></td>")
        '    .AppendLine("<td bgcolor=""red"" style=""text-align:center;color:white;""><a style='color:white;' href=""http://192.9.200.146/WebTA1/taOnline.aspx?rtaBillNo=" & oTA.TABillNo & """><b>Reject</b></a></td></tr>")
        '    .AppendLine("</table>")
        '    .AppendLine("<br/><br/>")
        'End Select
      End With
      Try
        Header = ""
        Header = Header & "<html xmlns=""http://www.w3.org/1999/xhtml"">"
        Header = Header & "<head>"
        Header = Header & "<title></title>"
        Header = Header & "<meta charset=""utf-8""/>"
        Header = Header & "<meta name=""viewport"" content=""width=device-width, initial-scale=1"" />"
        Header = Header & "<style>"
        Header = Header & "table{"

        Header = Header & "border: solid 1pt black;"
        Header = Header & "border-collapse:collapse;"
        Header = Header & "font-family: Tahoma;}"

        Header = Header & "td{"
        Header = Header & "border: solid 1pt black;"
        Header = Header & "font-family: Tahoma;"
        Header = Header & "font-size: 100%;"
        Header = Header & "vertical-align:top;}"

        Header = Header & "</style>"
        Header = Header & "</head>"
        Header = Header & "<body>"
        Header = Header & sb.ToString
        'Select Case oTA.BillStatusID
        '  Case TAStates.UnderSpecialSanction
        '    Header = Header & SIS.TA.taCH.RenderControlToHtml(SIS.TA.taBH.GetTABillPanel(oTA.TABillNo, True, False))
        'End Select
        Header = Header & "</body></html>"
        oMsg.Body = Header
        oClient.Send(oMsg)
      Catch ex As Exception
        mRet = ex.Message
      End Try
      Return mRet
    End Function
    Public Shared Shadows Function SendLinkEMail(ByVal oTA As SIS.TA.taBH) As String
      Dim mMailID As String = SIS.SYS.Utilities.ApplicationSpacific.NextMailNo
      Dim mLinkID As String = ""
      Dim mRet As String = ""
      Dim First As Boolean = True
      Dim Cnt As Integer = 0
      Dim mRecipients As New StringBuilder
      Dim maySend As Boolean = False

      Dim oClient As SmtpClient = New SmtpClient()
      Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
      Dim oEmp As SIS.TA.taEmployees = oTA.FK_TA_Bills_EmployeeID
      Dim oTmp As SIS.TA.taEmployees = Nothing
      Dim ad As MailAddress = Nothing
      Dim fad As MailAddress = Nothing
      Dim Subject As String = ""
      Dim Header As String = ""
      Dim LastLine As String = ""

      'From EMail
      If oEmp.EMailID <> String.Empty Then
        fad = New MailAddress(oEmp.EMailID, oEmp.EmployeeName)
        oMsg.From = fad
        'oMsg.CC.Add(fad)
      End If
      If oTA.BillStatusID = TAStates.UnderVerification Then
        oTmp = SIS.TA.taEmployees.taEmployeesGetByID(oEmp.TAVerifier)
        If oTmp.EMailID <> String.Empty Then
          ad = New MailAddress(oTmp.EMailID, oTmp.EmployeeName)
          oMsg.To.Add(ad)
          Subject = "Verify TA Bill of " & oEmp.EmployeeName
          Header = "TA BILL VERIFICATION NOTIFICATION"
          LastLine = "TA is submitted to you for verification. Please Log in online TA Bill System to verify the same."
        End If
      ElseIf oTA.BillStatusID = TAStates.UnderApproval Then
        oTmp = SIS.TA.taEmployees.taEmployeesGetByID(oEmp.TAApprover)
        If oTmp.EMailID <> String.Empty Then
          ad = New MailAddress(oTmp.EMailID, oTmp.EmployeeName)
          oMsg.To.Add(ad)
          Subject = "Approve TA Bill of " & oEmp.EmployeeName
          Header = "TA BILL APPROVAL NOTIFICATION"
          LastLine = "TA is submitted to you for approval. Please Log in online TA Bill System to approve the same."
        End If
      ElseIf oTA.BillStatusID = TAStates.UnderSpecialSanction Then
        oTmp = SIS.TA.taEmployees.taEmployeesGetByID(oEmp.TASanctioningAuthority)
        If oTmp.EMailID <> String.Empty Then
          ad = New MailAddress(oTmp.EMailID, oTmp.EmployeeName)
          oMsg.To.Add(ad)
          Subject = "Sanction TA Bill of " & oEmp.EmployeeName
          Header = "TA BILL SPL. SANCTION NOTIFICATION"
          LastLine = "TA is submitted to you for spl. sanction. Please Log in online TA Bill System to sanction the same."
        End If
      ElseIf oTA.BillStatusID = TAStates.UnderReceiveByAccounts Then
        oMsg.To.Add(fad)
        oMsg.CC.Clear()
        Subject = "TA Bill No. " & oTA.TABillNo & " Submitted to A/c, Dest.: " & oTA.DestinationCity
        Header = "TA BILL SUBMITTED TO ACCOUNTS"
        LastLine = "TA is submitted to Accounts for processing, Now, You may take Print of TA Bill and submit to A/c with required bills/sanction."
      End If
      oMsg.IsBodyHtml = True
      oMsg.Subject = Subject
      Dim sb As New StringBuilder
      With sb
        .AppendLine("<table style=""width:900px"" border=""1"" cellspacing=""1"" cellpadding=""1"">")
        .AppendLine("<tr><td colspan=""2"" align=""center""><h3><b>" & Header & "</b></h3></td></tr>")
        .AppendLine("<tr><td bgcolor=""lightgray""><b>TA Bill No.</b></td>")
        .AppendLine("<td>" & oTA.TABillNo & "</td></tr>")
        .AppendLine("<tr><td bgcolor=""lightgray""><b>TA Period</b></td>")
        .AppendLine("<td>" & "From : " & oTA.StartDateTime & " To : " & oTA.EndDateTime & "</td></tr>")
        .AppendLine("<tr><td bgcolor=""lightgray""><b>Purpose</b></td>")
        .AppendLine("<td>" & oTA.PurposeOfJourney & "</td></tr>")
        .AppendLine("<tr><td bgcolor=""lightgray""><b>Total Claimed Amt.</b></td>")
        .AppendLine("<td>" & oTA.TotalClaimedAmount & "</td></tr>")
        .AppendLine("<tr><td colspan=""2"">" & LastLine & "</td>")
        .AppendLine("</table>")
        .AppendLine("<br/><br/>")
        Select Case oTA.BillStatusID
          Case TAStates.UnderSpecialSanction
            .AppendLine("<table style=""width:900px"" border=""1"" cellspacing=""1"" cellpadding=""1"">")
            .AppendLine("<tr><td colspan=""2""><b>Use links below, if approving from Smart Phones / Blackberry.</b></td>")
            mLinkID = SIS.SYS.Utilities.ApplicationSpacific.NextLinkNo
            .AppendLine("<tr><td bgcolor=""green"" style=""text-align:center;height:30px;color:white;""><a style='color:white;' href=""http://cloud.isgec.co.in/WebTA1/taOnline.aspx?ataBillNo=" & oTA.TABillNo & "&MailID=" & mMailID & "&LinkID=" & mLinkID & """><b>Approve</b></a></td>")
            mLinkID = SIS.SYS.Utilities.ApplicationSpacific.NextLinkNo
            .AppendLine("<td bgcolor=""red"" style=""text-align:center;color:white;""><a style='color:white;' href=""http://cloud.isgec.co.in/WebTA1/taOnline.aspx?rtaBillNo=" & oTA.TABillNo & "&MailID=" & mMailID & "&LinkID=" & mLinkID & """><b>Reject</b></a></td></tr>")
            .AppendLine("<tr><td colspan=""2""><b>Use links below, if approving from within office premise using office Network.</b></td>")
            mLinkID = SIS.SYS.Utilities.ApplicationSpacific.NextLinkNo
            .AppendLine("<tr><td bgcolor=""green"" style=""text-align:center;height:30px;color:white;""><a style='color:white;' href=""http://192.9.200.146/WebTA1/taOnline.aspx?ataBillNo=" & oTA.TABillNo & "&MailID=" & mMailID & "&LinkID=" & mLinkID & """><b>Approve</b></a></td>")
            mLinkID = SIS.SYS.Utilities.ApplicationSpacific.NextLinkNo
            .AppendLine("<td bgcolor=""red"" style=""text-align:center;color:white;""><a style='color:white;' href=""http://192.9.200.146/WebTA1/taOnline.aspx?rtaBillNo=" & oTA.TABillNo & "&MailID=" & mMailID & "&LinkID=" & mLinkID & """><b>Reject</b></a></td></tr>")
            .AppendLine("</table>")
            .AppendLine("<br/><br/>")
        End Select
      End With
      Try
        Header = ""
        Header = Header & "<html xmlns=""http://www.w3.org/1999/xhtml"">"
        Header = Header & "<head>"
        Header = Header & "<title></title>"
        Header = Header & "<meta charset=""utf-8""/>"
        Header = Header & "<meta name=""viewport"" content=""width=device-width, initial-scale=1"" />"
        Header = Header & "<style>"
        Header = Header & "table{"

        Header = Header & "border: solid 1pt black;"
        Header = Header & "border-collapse:collapse;"
        Header = Header & "font-family: Tahoma;}"

        Header = Header & "td{"
        Header = Header & "border: solid 1pt black;"
        Header = Header & "font-family: Tahoma;"
        Header = Header & "font-size: 100%;"
        Header = Header & "vertical-align:top;}"

        Header = Header & "</style>"
        Header = Header & "</head>"
        Header = Header & "<body>"
        Header = Header & sb.ToString
        Select Case oTA.BillStatusID
          Case TAStates.UnderSpecialSanction
            Header = Header & SIS.TA.taCH.RenderControlToHtml(SIS.TA.taBH.GetTABillPanel(oTA.TABillNo, True, False))
        End Select
        Header = Header & "<br/>Mail-ID: " & mMailID
        Header = Header & "</body></html>"
        oMsg.Body = Header
        oClient.Send(oMsg)
        Dim mSql As String = " INSERT TA_Log "
        mSql &= " ("
        mSql &= " UserID,"
        mSql &= " Action,"
        mSql &= " RequestID,"
        mSql &= " LoggedOn,"
        mSql &= " RequestProp,"
        mSql &= " RequestHeader,"
        mSql &= " MailSrNo,"
        mSql &= " LinkSrNo"
        mSql &= " )"
        mSql &= " VALUES ("
        mSql &= "'" & oTA.EmployeeID & "',"
        mSql &= "'SANCTION',"
        mSql &= oTA.TABillNo & ",GetDate()"
        mSql &= ",'Delivered at : " & oMsg.To(0).Address & "',"
        mSql &= "'',"
        mSql &= mMailID & ","
        mSql &= 0
        mSql &= ")"
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = mSql
            Con.Open()
            Cmd.ExecuteNonQuery()
          End Using
        End Using
      Catch ex As Exception
        mRet = ex.Message
      End Try
      Return mRet
    End Function


    Public Shared Shadows Function SendRequestEMail() As String

      Dim mRet As String = ""
      Dim First As Boolean = True
      Dim Cnt As Integer = 0
      Dim mRecipients As New StringBuilder
      Dim maySend As Boolean = False

      Dim oClient As SmtpClient = New SmtpClient()
      Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
      Dim oEmp As SIS.TA.taEmployees = SIS.TA.taEmployees.taEmployeesGetByID(HttpContext.Current.Session("LoginID"))
      Dim oTmp As SIS.TA.taEmployees = Nothing
      Dim ad As MailAddress = Nothing

      'From EMail
      If oEmp.EMailID <> String.Empty Then
        ad = New MailAddress(oEmp.EMailID, oEmp.EmployeeName)
        oMsg.From = ad
        oMsg.CC.Add(ad)
      Else
        ad = New MailAddress("joomlasupport@isgec.co.in", oEmp.EmployeeName)
        oMsg.From = ad
      End If
      oMsg.To.Add(New MailAddress("joomlasupport@isgec.co.in"))
      oMsg.IsBodyHtml = True
      oMsg.Subject = "Update Emp. Info : " & oEmp.EmployeeName
      Dim sb As New StringBuilder
      With sb
        .AppendLine("<table style=""width:900px"" border=""1"" cellspacing=""1"" cellpadding=""1"">")
        .AppendLine("<tr><td colspan=""2"" align=""center""><h3><b>EMPLOYEE INFO</b></h3></td></tr>")
        .AppendLine("<tr><td bgcolor=""lightgray""><b>CARD NO.</b></td>")
        .AppendLine("<td>" & oEmp.CardNo & "</td></tr>")
        .AppendLine("<tr><td bgcolor=""lightgray""><b>NAME</b></td>")
        .AppendLine("<td>" & oEmp.EmployeeName & "</td></tr>")
        .AppendLine("<tr><td bgcolor=""lightgray""><b>TA BILL VERIFIER</b></td>")
        .AppendLine("<td>" & oEmp.TAVerifier)
        Try
          .AppendLine(" " & oEmp.FK_HRM_Employees_TAVerifier.EmployeeName)
        Catch ex As Exception
        End Try
        .AppendLine("</td></tr>")
        .AppendLine("<tr><td bgcolor=""lightgray""><b>TA BILL APPROVER</b></td>")
        .AppendLine("<td>" & oEmp.TAApprover)
        Try
          .AppendLine(" " & oEmp.FK_HRM_Employees_TAApprover.EmployeeName)
        Catch ex As Exception
        End Try
        .AppendLine("</td></tr>")
        .AppendLine("<tr><td bgcolor=""lightgray""><b>TA BILL SANCTIONING AUTHORITY</b></td>")
        .AppendLine("<td>" & oEmp.TASanctioningAuthority)
        Try
          .AppendLine(" " & oEmp.FK_HRM_Employees_TASanctioningAuthority.EmployeeName)
        Catch ex As Exception
        End Try
        .AppendLine("</td></tr>")
        .AppendLine("<tr><td bgcolor=""lightgray""><b>E-MAIL ID</b></td>")
        .AppendLine("<td>" & oEmp.EMailID & "</td></tr>")
        .AppendLine("<tr><td bgcolor=""lightgray""><b>DEPARTMENT</b></td>")
        .AppendLine("<td>" & oEmp.HRM_Departments2_Description & "</td></tr>")
        .AppendLine("<tr><td bgcolor=""lightgray""><b>DESIGNATION</b></td>")
        .AppendLine("<td>" & oEmp.HRM_Designations3_Description & "</td></tr>")
        .AppendLine("<tr><td bgcolor=""lightgray""><b>DIVISION</b></td>")
        .AppendLine("<td>" & oEmp.HRM_Divisions5_Description & "</td></tr>")
        .AppendLine("</table>")
      End With
      Try
        Dim Header As String = ""
        Header = Header & "<html xmlns=""http://www.w3.org/1999/xhtml"">"
        Header = Header & "<head>"
        Header = Header & "<title></title>"
        Header = Header & "<style>"
        Header = Header & "table{"

        Header = Header & "border: solid 1pt black;"
        Header = Header & "border-collapse:collapse;"
        Header = Header & "font-family: Tahoma;}"

        Header = Header & "td{"
        Header = Header & "border: solid 1pt black;"
        Header = Header & "font-family: Tahoma;"
        Header = Header & "font-size: 12px;"
        Header = Header & "vertical-align:top;}"

        Header = Header & "</style>"
        Header = Header & "</head>"
        Header = Header & "<body>"
        Header = Header & sb.ToString
        Header = Header & "</body></html>"
        oMsg.Body = Header
        oClient.Send(oMsg)
      Catch ex As Exception
        mRet = ex.Message
      End Try
      Return mRet
    End Function

#Region "  PRINT TA BILL  "
    Public Shared Function GetTABillPanel(ByVal TABillNo As Integer, ByVal ShowWarning As Boolean, Optional CheckDuplicate As Boolean = True) As Panel
      Dim pnl1 As New Panel

      Dim oVar As SIS.TA.taBH = SIS.TA.taBH.taBHGetByID(TABillNo)
      Try
        If CheckDuplicate Then
          Dim DuplicateBillNo As Integer = 0
          If DuplicateTABill(oVar, DuplicateBillNo) Then
            Dim tmp As New TextBox
            tmp.Width = 1000
            tmp.Text = "TA Bill for same period already exist, you can not take print untill " & DuplicateBillNo & " TA Bill is deleted."
            pnl1.Controls.Add(tmp)
            Return pnl1
          End If
        End If
      Catch ex As Exception
      End Try
      Dim sn As Integer = 0
      Dim tmpTbl As New Table
      With tmpTbl
        .Width = 1000
        .BorderStyle = BorderStyle.None
        .Style.Add("margin-top", "15px")
        .Style.Add("margin-left", "10px")
      End With
      Dim tmpRow As New TableRow
      Dim tmpCol As New TableCell
      With tmpCol
        Select Case oVar.TravelTypeID
          Case TATravelTypeValues.Domestic
            .Text = "TRAVEL EXPENSE STATEMENT"
          Case TATravelTypeValues.ForeignTravel
            .Text = "FOREIGN TRAVEL EXPENSE STATEMENT"
          Case TATravelTypeValues.ForeignSiteVisit
            .Text = "FOREIGN SITE VISIT EXPENSE STATEMENT"
          Case TATravelTypeValues.HomeVisit
            .Text = "HOME VISIT EXPENSE STATEMENT"
        End Select
        .Style.Add("text-align", "center")
        .Font.Size = FontUnit.Point(14)
        If Not oVar.FK_TA_Bills_EmployeeID.TASelfApproval Then
          Select Case oVar.BillStatusID
            Case 2, 3, 4, 5, 11, 12, 13, 15
            Case Else
              If oVar.OOEBySystem And oVar.ApprovedBySA = "" Then
                .Text = "PROVISIONAL BILL -Print it after Approval by Sanctioning Authority"
                .Font.Size = FontUnit.Point(12)
              ElseIf oVar.ApprovedByCC = "" Then
                .Text = "PROVISIONAL BILL -Print it after Approval."
                .Font.Size = FontUnit.Point(12)
              End If
          End Select
        End If
        .Font.Bold = True
      End With
      tmpRow.Cells.Add(tmpCol)
      tmpTbl.Rows.Add(tmpRow)
      pnl1.Controls.Add(tmpTbl)

      Dim oTbl As Table
      Dim oCol As TableCell = Nothing
      Dim oRow As TableRow = Nothing
      Dim ClaimTot As Decimal = 0
      Dim PassTot As Decimal = 0


      Dim oTbltaBH As New Table
      oTbltaBH.Width = 1000
      oTbltaBH.GridLines = GridLines.Both
      oTbltaBH.Style.Add("margin-top", "15px")
      oTbltaBH.Style.Add("margin-left", "10px")
      Dim oColtaBH As TableCell = Nothing
      Dim oRowtaBH As TableRow = Nothing
      oRowtaBH = New TableRow
      oColtaBH = New TableCell
      oColtaBH.Text = "TA Bill No"
      oColtaBH.Font.Bold = True
      oColtaBH.Width = 150
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = oVar.TABillNo
      oColtaBH.Style.Add("text-align", "left")
      oColtaBH.ColumnSpan = "1"
      oColtaBH.Font.Size = "14"
      oColtaBH.Font.Bold = True
      oRowtaBH.Cells.Add(oColtaBH)

      oColtaBH = New TableCell
      Select Case oVar.BillStatusID
        Case 15, 17
          oColtaBH.Text = "AUTO POSTING   Finance Co.: 200  Batch No.: " & oVar.VCHBatch
        Case Else
          oColtaBH.Text = ""
      End Select
      oColtaBH.Style.Add("text-align", "right")
      oColtaBH.ColumnSpan = "4"
      oColtaBH.Font.Size = "14"
      oColtaBH.Font.Bold = True
      oRowtaBH.Cells.Add(oColtaBH)

      oTbltaBH.Rows.Add(oRowtaBH)
      oRowtaBH = New TableRow
      oRowtaBH.BackColor = Drawing.Color.Gainsboro
      oColtaBH = New TableCell
      oColtaBH.Text = "Employee ID"
      oColtaBH.Font.Bold = True
      oColtaBH.Width = 150
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = oVar.EmployeeID
      oColtaBH.Style.Add("text-align", "left")
      oColtaBH.Width = 100
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = oVar.HRM_Employees5_EmployeeName
      oColtaBH.Style.Add("text-align", "left")
      oColtaBH.Width = 250
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = "TA Category ID"
      oColtaBH.Font.Bold = True
      oColtaBH.Width = 150
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = oVar.TA_Categories13_cmba
      oColtaBH.Style.Add("text-align", "right")
      oColtaBH.ColumnSpan = "2"
      oColtaBH.Width = 350
      oRowtaBH.Cells.Add(oColtaBH)
      oTbltaBH.Rows.Add(oRowtaBH)
      oRowtaBH = New TableRow
      oRowtaBH.BackColor = Drawing.Color.Gainsboro
      oColtaBH = New TableCell
      oColtaBH.Text = "CostCenterID"
      oColtaBH.Font.Bold = True
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = oVar.CostCenterID
      oColtaBH.Style.Add("text-align", "left")
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = oVar.HRM_Departments1_Description
      oColtaBH.Style.Add("text-align", "left")
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = "Project ID"
      oColtaBH.Font.Bold = True
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = oVar.ProjectID
      oColtaBH.Style.Add("text-align", "left")
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = oVar.IDM_Projects11_Description
      oColtaBH.Style.Add("text-align", "left")
      oRowtaBH.Cells.Add(oColtaBH)
      oTbltaBH.Rows.Add(oRowtaBH)

      oRowtaBH = New TableRow
      oRowtaBH.BackColor = Drawing.Color.Gainsboro
      oColtaBH = New TableCell
      oColtaBH.Text = "Department"
      oColtaBH.Font.Bold = True
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      Try
        oColtaBH.Text = oVar.FK_TA_Bills_DepartmentID.Description
      Catch ex As Exception
        oColtaBH.Text = ""
      End Try
      oColtaBH.Style.Add("text-align", "left")
      oColtaBH.ColumnSpan = "2"
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = "Designation"
      oColtaBH.Font.Bold = True
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      Try
        oColtaBH.Text = oVar.FK_TA_Bills_DesignationID.Description
      Catch ex As Exception
        oColtaBH.Text = ""
      End Try
      oColtaBH.ColumnSpan = "2"
      oColtaBH.Style.Add("text-align", "left")
      oRowtaBH.Cells.Add(oColtaBH)
      oTbltaBH.Rows.Add(oRowtaBH)

      oRowtaBH = New TableRow
      oRowtaBH.BackColor = Drawing.Color.Gainsboro
      oColtaBH = New TableCell
      oColtaBH.Text = "Purpose Of Journey"
      oColtaBH.Font.Bold = True
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = oVar.PurposeOfJourney
      oColtaBH.Style.Add("text-align", "left")
      oColtaBH.ColumnSpan = "5"
      oRowtaBH.Cells.Add(oColtaBH)
      oTbltaBH.Rows.Add(oRowtaBH)
      oRowtaBH = New TableRow
      oColtaBH = New TableCell
      oColtaBH.Text = "Total Claimed Amount"
      oColtaBH.Font.Bold = True
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = oVar.TotalClaimedAmount
      oColtaBH.Style.Add("text-align", "right")
      oColtaBH.ColumnSpan = "2"
      oColtaBH.ForeColor = Drawing.Color.Green
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = "Total Passed Amount"
      oColtaBH.Font.Bold = True
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = oVar.TotalPassedAmount
      oColtaBH.Style.Add("text-align", "right")
      oColtaBH.ColumnSpan = "2"
      oRowtaBH.Cells.Add(oColtaBH)
      oTbltaBH.Rows.Add(oRowtaBH)
      oRowtaBH = New TableRow
      oColtaBH = New TableCell
      oColtaBH.Text = "Total Financed Amount"
      oColtaBH.Font.Bold = True
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = oVar.TotalFinancedAmount
      oColtaBH.Style.Add("text-align", "right")
      oColtaBH.ColumnSpan = "2"
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = "Total Payable Amount"
      oColtaBH.Font.Bold = True
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = oVar.TotalPayableAmount
      oColtaBH.Style.Add("text-align", "right")
      oColtaBH.ColumnSpan = "2"
      oColtaBH.ForeColor = Drawing.Color.Green
      oRowtaBH.Cells.Add(oColtaBH)
      oTbltaBH.Rows.Add(oRowtaBH)
      oRowtaBH = New TableRow
      oColtaBH = New TableCell
      oColtaBH.Text = "Sanctioned DA [Per Day, If any]"
      oColtaBH.Font.Bold = True
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = oVar.SanctionedDA
      oColtaBH.Style.Add("text-align", "right")
      oColtaBH.ColumnSpan = "2"
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = "Sanctioned Lodging [Per Day, If any]"
      oColtaBH.Font.Bold = True
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = oVar.SanctionedLodging
      oColtaBH.Style.Add("text-align", "right")
      oColtaBH.ColumnSpan = "2"
      oRowtaBH.Cells.Add(oColtaBH)
      oTbltaBH.Rows.Add(oRowtaBH)
      oRowtaBH = New TableRow
      oRowtaBH.BackColor = Drawing.Color.Gainsboro
      oColtaBH = New TableCell
      oColtaBH.Text = "Verified By"
      oColtaBH.Font.Bold = True
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = oVar.HRM_Employees7_EmployeeName
      oColtaBH.Style.Add("text-align", "left")
      oColtaBH.ColumnSpan = "2"
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = "Approved By"
      oColtaBH.Font.Bold = True
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = oVar.HRM_Employees8_EmployeeName
      oColtaBH.Style.Add("text-align", "left")
      oColtaBH.ColumnSpan = "2"
      oRowtaBH.Cells.Add(oColtaBH)
      oTbltaBH.Rows.Add(oRowtaBH)
      'Remarks
      oRowtaBH = New TableRow
      oRowtaBH.BackColor = Drawing.Color.Gainsboro
      oColtaBH = New TableCell
      oColtaBH.Text = "Verifier Remarks"
      oColtaBH.Font.Bold = True
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = oVar.VerificationRemarks
      oColtaBH.Style.Add("text-align", "left")
      oColtaBH.ColumnSpan = "2"
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = "Approver Remarks"
      oColtaBH.Font.Bold = True
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = oVar.ApprovalRemarks
      oColtaBH.Style.Add("text-align", "left")
      oColtaBH.ColumnSpan = "2"
      oRowtaBH.Cells.Add(oColtaBH)
      oTbltaBH.Rows.Add(oRowtaBH)
      'End Remarks
      oRowtaBH = New TableRow
      oRowtaBH.BackColor = Drawing.Color.Gainsboro
      oColtaBH = New TableCell
      oColtaBH.Text = "Verified On"
      oColtaBH.Font.Bold = True
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = oVar.ApprovedOn
      oColtaBH.Style.Add("text-align", "center")
      oColtaBH.ColumnSpan = "2"
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = "Approved On "
      oColtaBH.Font.Bold = True
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = oVar.ApprovedByCCOn
      oColtaBH.Style.Add("text-align", "center")
      oColtaBH.ColumnSpan = "2"
      oRowtaBH.Cells.Add(oColtaBH)
      oTbltaBH.Rows.Add(oRowtaBH)
      oRowtaBH = New TableRow
      oRowtaBH.BackColor = Drawing.Color.Gainsboro
      oColtaBH = New TableCell
      oColtaBH.Text = "Special Approval By Sanctioning Authority"
      oColtaBH.Font.Bold = True
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = oVar.ApprovedBySA
      oColtaBH.Style.Add("text-align", "left")
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = oVar.HRM_Employees9_EmployeeName
      oColtaBH.Style.Add("text-align", "left")
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = "Special Approval On"
      oColtaBH.Font.Bold = True
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = oVar.ApprovedBySAOn
      oColtaBH.Style.Add("text-align", "center")
      oColtaBH.ColumnSpan = "2"
      oRowtaBH.Cells.Add(oColtaBH)
      oTbltaBH.Rows.Add(oRowtaBH)
      oRowtaBH = New TableRow
      oRowtaBH.BackColor = Drawing.Color.Gainsboro
      oColtaBH = New TableCell
      oColtaBH.Text = "Bill Status"
      oColtaBH.Font.Bold = True
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = oVar.TA_BillStates16_Description
      oColtaBH.Style.Add("text-align", "left")
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = "Posted On : " & oVar.PostedOn
      oColtaBH.Style.Add("text-align", "left")
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = "Posted at Site"
      oColtaBH.Font.Bold = True
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      Try
        oColtaBH.Text = oVar.SiteName
      Catch ex As Exception
        oColtaBH.Text = ""
      End Try
      oColtaBH.Style.Add("text-align", "right")
      oColtaBH.ColumnSpan = "2"
      oRowtaBH.Cells.Add(oColtaBH)
      oTbltaBH.Rows.Add(oRowtaBH)
      oRowtaBH = New TableRow
      oColtaBH = New TableCell
      oColtaBH.Text = "OOE Remarks"
      oColtaBH.Font.Bold = True
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = oVar.OOERemarks
      oColtaBH.Style.Add("text-align", "left")
      oColtaBH.ColumnSpan = "2"
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = "MD Sanction Attached"
      oColtaBH.Font.Bold = True
      oRowtaBH.Cells.Add(oColtaBH)
      oColtaBH = New TableCell
      oColtaBH.Text = IIf(oVar.SanctionAttached, "YES", "NO")
      oColtaBH.Style.Add("text-align", "left")
      oColtaBH.ColumnSpan = "2"
      oRowtaBH.Cells.Add(oColtaBH)
      oTbltaBH.Rows.Add(oRowtaBH)
      pnl1.Controls.Add(oTbltaBH)

      ' Table For Foreign Travel 
      If oVar.TravelTypeID <> TATravelTypeValues.Domestic AndAlso oVar.TravelTypeID <> TATravelTypeValues.HomeVisit Then
        oTbl = New Table
        oTbl.Width = 1000
        oTbl.GridLines = GridLines.None
        oTbl.Style.Add("margin-top", "15px")
        oTbl.Style.Add("margin-left", "10px")
        oRow = New TableRow
        oCol = New TableCell
        oCol.Text = "DEPARTUE FROM INDIA:"
        oCol.CssClass = "alignright"
        oCol.Font.Bold = True
        oRow.Cells.Add(oCol)
        oCol = New TableCell
        oCol.Text = oVar.DepartureFromIndia
        oCol.Font.Bold = True
        oCol.Width = Unit.Percentage(50)
        oRow.Cells.Add(oCol)
        oTbl.Rows.Add(oRow)

        oRow = New TableRow
        oCol = New TableCell
        oCol.Text = "ARRIVAL IN INDIA:"
        oCol.CssClass = "alignright"
        oCol.Font.Bold = True
        oRow.Cells.Add(oCol)
        oCol = New TableCell
        oCol.Text = oVar.ArrivalToIndia
        oCol.Font.Bold = True
        oRow.Cells.Add(oCol)
        oTbl.Rows.Add(oRow)

        oRow = New TableRow
        oCol = New TableCell
        oCol.Text = "TOTAL DA DAYS:"
        oCol.CssClass = "alignright"
        oCol.Font.Bold = True
        oRow.Cells.Add(oCol)
        oCol = New TableCell
        oCol.Text = oVar.TotalTravelDays
        oCol.Font.Bold = True
        oRow.Cells.Add(oCol)
        oTbl.Rows.Add(oRow)

        pnl1.Controls.Add(oTbl)

      End If
      '---------


      If ShowWarning Then

        Dim tblTmp As Table = Nothing
        Dim rowTmp As TableRow = Nothing
        Dim colTmp As TableCell = Nothing
        Dim tbDs As List(Of SIS.TA.taBillDetails) = SIS.TA.taBillDetails.UZ_taBillDetailsSelectList(0, 9999, "ComponentID", False, "", TABillNo)
        Dim Found As Boolean = False
        For Each tbd As SIS.TA.taBillDetails In tbDs
          If tbd.OOEBySystem = True Then
            Found = True
            Exit For
          End If
        Next
        If Found Then
          tblTmp = New Table
          With tblTmp
            .Width = 1000
            .Style.Add("margin-top", "15px")
            .Style.Add("margin-left", "10px")
            .Style.Add("margin-right", "10px")
          End With
          rowTmp = New TableRow
          colTmp = New TableCell
          With colTmp
            .Text = "Sanction required for the following expenses of TA Bill"
            .Font.Bold = True
            .ColumnSpan = 7
            .Style.Add("text-align", "left")
            .ForeColor = Drawing.Color.Red
          End With
          rowTmp.Cells.Add(colTmp)
          tblTmp.Rows.Add(rowTmp)

          rowTmp = New TableRow
          rowTmp.BackColor = Drawing.Color.LightPink
          colTmp = New TableCell
          With colTmp
            .Text = "S.N."
            .Font.Bold = True
            .CssClass = "colHD"
            .Width = 40
            .Style.Add("text-align", "center")
          End With
          rowTmp.Cells.Add(colTmp)
          colTmp = New TableCell
          With colTmp
            .Text = "Component ID"
            .Font.Bold = True
            .CssClass = "colHD"
            .Width = 100
            .Style.Add("text-align", "left")
          End With
          rowTmp.Cells.Add(colTmp)
          colTmp = New TableCell
          With colTmp
            .Text = "Description"
            .Font.Bold = True
            .CssClass = "colHD"
            .Width = 300
            .Style.Add("text-align", "left")
          End With
          rowTmp.Cells.Add(colTmp)
          colTmp = New TableCell
          With colTmp
            .Text = "Currency"
            .Font.Bold = True
            .CssClass = "colHD"
            .Width = 60
            .Style.Add("text-align", "center")
          End With
          rowTmp.Cells.Add(colTmp)
          colTmp = New TableCell
          With colTmp
            .Text = "Claimed Amount"
            .Font.Bold = True
            .CssClass = "colHD"
            .Width = 100
            .Style.Add("text-align", "right")
          End With
          rowTmp.Cells.Add(colTmp)
          colTmp = New TableCell
          With colTmp
            .Text = "Out of Entitlement"
            .Font.Bold = True
            .CssClass = "colHD"
            .Width = 200
            .Style.Add("text-align", "left")
          End With
          rowTmp.Cells.Add(colTmp)
          colTmp = New TableCell
          With colTmp
            .Text = "Remarks/Justification"
            .Font.Bold = True
            .CssClass = "colHD"
            .Width = 200
            .Style.Add("text-align", "left")
          End With
          rowTmp.Cells.Add(colTmp)
          tblTmp.Rows.Add(rowTmp)
          sn = 0
          For Each tbd As SIS.TA.taBillDetails In tbDs
            If Not tbd.OOEBySystem Then Continue For
            sn += 1
            rowTmp = New TableRow
            rowTmp.BackColor = Drawing.Color.LightPink
            colTmp = New TableCell
            With colTmp
              .CssClass = "rowHD"
              .Text = sn
              .Style.Add("text-align", "center")
            End With
            rowTmp.Cells.Add(colTmp)
            colTmp = New TableCell
            With colTmp
              .CssClass = "rowHD"
              .Text = tbd.TA_Components9_Description
              .Style.Add("text-align", "left")
            End With
            rowTmp.Cells.Add(colTmp)
            colTmp = New TableCell
            With colTmp
              .CssClass = "rowHD"
              .Text = tbd.SystemText
              .Style.Add("text-align", "left")
            End With
            rowTmp.Cells.Add(colTmp)
            colTmp = New TableCell
            Dim cur As String = ""
            Select Case tbd.CurrencyID
              Case "INR", "USD", "EURO"
                cur = tbd.CurrencyID
              Case Else
                cur = tbd.CurrencyMain
            End Select
            With colTmp
              .CssClass = "rowHD"
              .Text = cur
              .Style.Add("text-align", "center")
            End With
            rowTmp.Cells.Add(colTmp)
            colTmp = New TableCell
            With colTmp
              .CssClass = "rowHD"
              .Text = tbd.AmountTotal
              .Style.Add("text-align", "right")
            End With
            rowTmp.Cells.Add(colTmp)
            colTmp = New TableCell
            With colTmp
              .CssClass = "rowHD"
              .Text = tbd.OOERemarks
              .Style.Add("text-align", "left")
            End With
            rowTmp.Cells.Add(colTmp)
            colTmp = New TableCell
            With colTmp
              .CssClass = "rowHD"
              .Text = tbd.Remarks
              .Style.Add("text-align", "left")
            End With
            rowTmp.Cells.Add(colTmp)
            tblTmp.Rows.Add(rowTmp)
          Next
          pnl1.Controls.Add(tblTmp)
        End If
      End If
      'End of ShowWarning

      Dim oTbltaBDFare As Table = Nothing
      Dim oRowtaBDFare As TableRow = Nothing
      Dim oColtaBDFare As TableCell = Nothing
      Dim otaBDFares As List(Of SIS.TA.taBDFare) = SIS.TA.taBDFare.UZ_taBDFareSelectList(0, 999, "", False, "", oVar.TABillNo)
      If otaBDFares.Count > 0 Then
        Dim oTblhtaBDFare As Table = New Table
        oTblhtaBDFare.Width = 1000
        oTblhtaBDFare.Style.Add("margin-top", "15px")
        oTblhtaBDFare.Style.Add("margin-left", "10px")
        oTblhtaBDFare.Style.Add("margin-right", "10px")
        Dim oRowhtaBDFare As TableRow = New TableRow
        Dim oColhtaBDFare As TableCell = New TableCell
        oColhtaBDFare.Font.Bold = True
        oColhtaBDFare.Font.Underline = True
        oColhtaBDFare.Font.Size = 10
        oColhtaBDFare.CssClass = "grpHD"
        oColhtaBDFare.Text = "Fare"
        oRowhtaBDFare.Cells.Add(oColhtaBDFare)
        oTblhtaBDFare.Rows.Add(oRowhtaBDFare)
        pnl1.Controls.Add(oTblhtaBDFare)
        oTbltaBDFare = New Table
        oTbltaBDFare.Width = 1000
        oTbltaBDFare.GridLines = GridLines.Both
        oTbltaBDFare.Style.Add("margin-left", "10px")
        oTbltaBDFare.Style.Add("margin-right", "10px")
        oRowtaBDFare = New TableRow
        oColtaBDFare = New TableCell
        oColtaBDFare.Text = "S.N."
        oColtaBDFare.Width = 40
        oColtaBDFare.Font.Bold = True
        oColtaBDFare.CssClass = "colHD"
        oColtaBDFare.Style.Add("text-align", "center")
        oRowtaBDFare.Cells.Add(oColtaBDFare)
        oColtaBDFare = New TableCell
        oColtaBDFare.Text = "Description"
        oColtaBDFare.Font.Bold = True
        oColtaBDFare.CssClass = "colHD"
        oColtaBDFare.Width = 400
        oColtaBDFare.Style.Add("text-align", "left")
        oColtaBDFare.Width = 400
        oRowtaBDFare.Cells.Add(oColtaBDFare)
        If oVar.TravelTypeID <> TATravelTypeValues.Domestic AndAlso oVar.TravelTypeID <> TATravelTypeValues.HomeVisit Then
          oColtaBDFare = New TableCell
          oColtaBDFare.Text = "Currency"
          oColtaBDFare.Font.Bold = True
          oColtaBDFare.CssClass = "colHD"
          oColtaBDFare.Width = 60
          oColtaBDFare.Style.Add("text-align", "center")
          oRowtaBDFare.Cells.Add(oColtaBDFare)
        End If
        oColtaBDFare = New TableCell
        oColtaBDFare.Text = "Claimed Amount"
        oColtaBDFare.Font.Bold = True
        oColtaBDFare.CssClass = "colHD"
        oColtaBDFare.Width = 100
        oColtaBDFare.Style.Add("text-align", "right")
        oRowtaBDFare.Cells.Add(oColtaBDFare)
        oColtaBDFare = New TableCell
        oColtaBDFare.Text = "Passed Amount"
        oColtaBDFare.Font.Bold = True
        oColtaBDFare.CssClass = "colHD"
        oColtaBDFare.Width = 100
        oColtaBDFare.Style.Add("text-align", "right")
        oRowtaBDFare.Cells.Add(oColtaBDFare)
        oColtaBDFare = New TableCell
        oColtaBDFare.Text = "Remarks"
        oColtaBDFare.Font.Bold = True
        oColtaBDFare.CssClass = "colHD"
        oColtaBDFare.Style.Add("text-align", "left")
        oRowtaBDFare.Cells.Add(oColtaBDFare)
        oTbltaBDFare.Rows.Add(oRowtaBDFare)
        ClaimTot = 0
        PassTot = 0
        sn = 0
        For Each otaBDFare As SIS.TA.taBDFare In otaBDFares
          sn += 1
          oRowtaBDFare = New TableRow
          oColtaBDFare = New TableCell
          oColtaBDFare.CssClass = "rowHD"
          oColtaBDFare.Text = sn 'otaBDFare.SerialNo
          oColtaBDFare.Style.Add("text-align", "center")
          oRowtaBDFare.Cells.Add(oColtaBDFare)
          oColtaBDFare = New TableCell
          oColtaBDFare.CssClass = "rowHD"
          oColtaBDFare.Text = otaBDFare.SystemText
          oColtaBDFare.Style.Add("text-align", "left")
          oRowtaBDFare.Cells.Add(oColtaBDFare)
          If oVar.TravelTypeID <> TATravelTypeValues.Domestic AndAlso oVar.TravelTypeID <> TATravelTypeValues.HomeVisit Then
            Dim cur As String = ""
            With otaBDFare
              Select Case .CurrencyID
                Case "INR", "USD", "EURO"
                  cur = .CurrencyID
                Case Else
                  cur = .CurrencyMain
              End Select
            End With
            oColtaBDFare = New TableCell
            oColtaBDFare.CssClass = "rowHD"
            oColtaBDFare.Text = cur
            oColtaBDFare.Style.Add("text-align", "center")
            oRowtaBDFare.Cells.Add(oColtaBDFare)
          End If
          oColtaBDFare = New TableCell
          oColtaBDFare.CssClass = "rowHD"
          oColtaBDFare.Text = otaBDFare.AmountTotal
          oColtaBDFare.Style.Add("text-align", "right")
          If otaBDFare.OOEBySystem Then
            oColtaBDFare.ForeColor = Drawing.Color.Red
          End If
          oRowtaBDFare.Cells.Add(oColtaBDFare)
          oColtaBDFare = New TableCell
          oColtaBDFare.CssClass = "rowHD"
          oColtaBDFare.Text = otaBDFare.PassedAmountTotal
          oColtaBDFare.Style.Add("text-align", "right")
          oRowtaBDFare.Cells.Add(oColtaBDFare)
          oColtaBDFare = New TableCell
          oColtaBDFare.CssClass = "rowHD"
          Dim remTbl As New Table
          Dim remrow As New TableRow
          Dim remaRow As New TableRow
          Dim remcol As New TableCell
          remTbl.BorderStyle = BorderStyle.None
          remcol.Text = otaBDFare.Remarks
          remrow.Cells.Add(remcol)
          remTbl.Rows.Add(remrow)
          remrow = New TableRow
          remcol = New TableCell
          remcol.Text = otaBDFare.AccountsRemarks
          remcol.ForeColor = Drawing.Color.Red
          remrow.Cells.Add(remcol)
          remTbl.Rows.Add(remrow)
          oColtaBDFare.Controls.Add(remTbl)
          oColtaBDFare.Style.Add("text-align", "left")
          oRowtaBDFare.Cells.Add(oColtaBDFare)
          oTbltaBDFare.Rows.Add(oRowtaBDFare)

          ClaimTot += otaBDFare.AmountTotal
          PassTot += otaBDFare.PassedAmountTotal
        Next
        If sn > 1 Then
          oRow = New TableRow
          oCol = New TableCell
          With oCol
            If oVar.TravelTypeID <> TATravelTypeValues.Domestic AndAlso oVar.TravelTypeID <> TATravelTypeValues.HomeVisit Then
              .ColumnSpan = 3
            Else
              .ColumnSpan = 2
            End If
            .Text = "TOTAL"
            .Style.Add("text-align", "right")
          End With
          oRow.Cells.Add(oCol)
          oCol = New TableCell
          With oCol
            .Text = ClaimTot.ToString("n")
            .Style.Add("text-align", "right")
          End With
          oRow.Cells.Add(oCol)
          oCol = New TableCell
          With oCol
            .Text = PassTot.ToString("n")
            .Style.Add("text-align", "right")
          End With
          oRow.Cells.Add(oCol)
          oCol = New TableCell
          oRow.Cells.Add(oCol)
          oTbltaBDFare.Rows.Add(oRow)
        End If
        pnl1.Controls.Add(oTbltaBDFare)
      End If
      Dim oTbltaBDLC As Table = Nothing
      Dim oRowtaBDLC As TableRow = Nothing
      Dim oColtaBDLC As TableCell = Nothing
      Dim otaBDLCs As List(Of SIS.TA.taBDLC) = SIS.TA.taBDLC.UZ_taBDLCSelectList(0, 999, "", False, "", oVar.TABillNo)
      If otaBDLCs.Count > 0 Then
        Dim oTblhtaBDLC As Table = New Table
        oTblhtaBDLC.Width = 1000
        oTblhtaBDLC.Style.Add("margin-top", "15px")
        oTblhtaBDLC.Style.Add("margin-left", "10px")
        oTblhtaBDLC.Style.Add("margin-right", "10px")
        Dim oRowhtaBDLC As TableRow = New TableRow
        Dim oColhtaBDLC As TableCell = New TableCell
        oColhtaBDLC.Font.Bold = True
        oColhtaBDLC.Font.Underline = True
        oColhtaBDLC.Font.Size = 10
        oColhtaBDLC.CssClass = "grpHD"
        oColhtaBDLC.Text = "Conveyance Expenses"
        oRowhtaBDLC.Cells.Add(oColhtaBDLC)
        oTblhtaBDLC.Rows.Add(oRowhtaBDLC)
        pnl1.Controls.Add(oTblhtaBDLC)
        oTbltaBDLC = New Table
        oTbltaBDLC.Width = 1000
        oTbltaBDLC.GridLines = GridLines.Both
        oTbltaBDLC.Style.Add("margin-left", "10px")
        oTbltaBDLC.Style.Add("margin-right", "10px")
        oRowtaBDLC = New TableRow
        oColtaBDLC = New TableCell
        oColtaBDLC.Text = "S.N."
        oColtaBDLC.Width = 40
        oColtaBDLC.Font.Bold = True
        oColtaBDLC.CssClass = "colHD"
        oColtaBDLC.Style.Add("text-align", "center")
        oRowtaBDLC.Cells.Add(oColtaBDLC)
        oColtaBDLC = New TableCell
        oColtaBDLC.Text = "Description"
        oColtaBDLC.Font.Bold = True
        oColtaBDLC.CssClass = "colHD"
        oColtaBDLC.Width = 400
        oColtaBDLC.Style.Add("text-align", "left")
        oRowtaBDLC.Cells.Add(oColtaBDLC)
        If oVar.TravelTypeID <> TATravelTypeValues.Domestic AndAlso oVar.TravelTypeID <> TATravelTypeValues.HomeVisit Then
          oColtaBDLC = New TableCell
          oColtaBDLC.Text = "Currency"
          oColtaBDLC.Font.Bold = True
          oColtaBDLC.CssClass = "colHD"
          oColtaBDLC.Width = 60
          oColtaBDLC.Style.Add("text-align", "center")
          oRowtaBDLC.Cells.Add(oColtaBDLC)
        End If
        oColtaBDLC = New TableCell
        oColtaBDLC.Text = "Claimed Amount"
        oColtaBDLC.Font.Bold = True
        oColtaBDLC.CssClass = "colHD"
        oColtaBDLC.Width = 100
        oColtaBDLC.Style.Add("text-align", "right")
        oRowtaBDLC.Cells.Add(oColtaBDLC)
        oColtaBDLC = New TableCell
        oColtaBDLC.Text = "Passed Amount"
        oColtaBDLC.Font.Bold = True
        oColtaBDLC.CssClass = "colHD"
        oColtaBDLC.Width = 100
        oColtaBDLC.Style.Add("text-align", "right")
        oRowtaBDLC.Cells.Add(oColtaBDLC)
        oColtaBDLC = New TableCell
        oColtaBDLC.Text = "Remarks"
        oColtaBDLC.Font.Bold = True
        oColtaBDLC.CssClass = "colHD"
        oColtaBDLC.Style.Add("text-align", "left")
        oRowtaBDLC.Cells.Add(oColtaBDLC)
        oTbltaBDLC.Rows.Add(oRowtaBDLC)
        sn = 0
        ClaimTot = 0
        PassTot = 0
        For Each otaBDLC As SIS.TA.taBDLC In otaBDLCs
          sn = sn + 1
          oRowtaBDLC = New TableRow
          oColtaBDLC = New TableCell
          oColtaBDLC.CssClass = "rowHD"
          oColtaBDLC.Text = sn  ' otaBDLC.SerialNo
          oColtaBDLC.Style.Add("text-align", "center")
          oRowtaBDLC.Cells.Add(oColtaBDLC)
          oColtaBDLC = New TableCell
          oColtaBDLC.CssClass = "rowHD"
          oColtaBDLC.Text = otaBDLC.SystemText
          oColtaBDLC.Style.Add("text-align", "left")
          oRowtaBDLC.Cells.Add(oColtaBDLC)
          If oVar.TravelTypeID <> TATravelTypeValues.Domestic AndAlso oVar.TravelTypeID <> TATravelTypeValues.HomeVisit Then
            Dim cur As String = ""
            With otaBDLC
              Select Case .CurrencyID
                Case "INR", "USD", "EURO"
                  cur = .CurrencyID
                Case Else
                  cur = .CurrencyMain
              End Select
            End With
            oColtaBDLC = New TableCell
            oColtaBDLC.CssClass = "rowHD"
            oColtaBDLC.Text = cur
            oColtaBDLC.Style.Add("text-align", "center")
            oRowtaBDLC.Cells.Add(oColtaBDLC)
          End If
          oColtaBDLC = New TableCell
          oColtaBDLC.CssClass = "rowHD"
          oColtaBDLC.Text = otaBDLC.AmountTotal
          oColtaBDLC.Style.Add("text-align", "right")
          If otaBDLC.OOEBySystem Then
            oColtaBDLC.ForeColor = Drawing.Color.Red
          End If
          oRowtaBDLC.Cells.Add(oColtaBDLC)
          oColtaBDLC = New TableCell
          oColtaBDLC.CssClass = "rowHD"
          oColtaBDLC.Text = otaBDLC.PassedAmountTotal
          oColtaBDLC.Style.Add("text-align", "right")
          oRowtaBDLC.Cells.Add(oColtaBDLC)
          oColtaBDLC = New TableCell
          oColtaBDLC.CssClass = "rowHD"
          Dim remTbl As New Table
          Dim remrow As New TableRow
          Dim remaRow As New TableRow
          Dim remcol As New TableCell
          remTbl.BorderStyle = BorderStyle.None
          remcol.Text = otaBDLC.Remarks
          remrow.Cells.Add(remcol)
          remTbl.Rows.Add(remrow)
          remrow = New TableRow
          remcol = New TableCell
          remcol.Text = otaBDLC.AccountsRemarks
          remcol.ForeColor = Drawing.Color.Red
          remrow.Cells.Add(remcol)
          remTbl.Rows.Add(remrow)
          oColtaBDLC.Controls.Add(remTbl)
          oColtaBDLC.Style.Add("text-align", "left")
          oRowtaBDLC.Cells.Add(oColtaBDLC)
          oTbltaBDLC.Rows.Add(oRowtaBDLC)

          ClaimTot += otaBDLC.AmountTotal
          PassTot += otaBDLC.PassedAmountTotal
        Next
        If sn > 1 Then
          oRow = New TableRow
          oCol = New TableCell
          With oCol
            If oVar.TravelTypeID <> TATravelTypeValues.Domestic AndAlso oVar.TravelTypeID <> TATravelTypeValues.HomeVisit Then
              .ColumnSpan = 3
            Else
              .ColumnSpan = 2
            End If
            .Text = "TOTAL"
            .Style.Add("text-align", "right")
          End With
          oRow.Cells.Add(oCol)
          oCol = New TableCell
          With oCol
            .Text = ClaimTot.ToString("n")
            .Style.Add("text-align", "right")
          End With
          oRow.Cells.Add(oCol)
          oCol = New TableCell
          With oCol
            .Text = PassTot.ToString("n")
            .Style.Add("text-align", "right")
          End With
          oRow.Cells.Add(oCol)
          oCol = New TableCell
          oRow.Cells.Add(oCol)
          oTbltaBDLC.Rows.Add(oRow)
        End If
        pnl1.Controls.Add(oTbltaBDLC)
      End If
      Dim oTbltaBDLodging As Table = Nothing
      Dim oRowtaBDLodging As TableRow = Nothing
      Dim oColtaBDLodging As TableCell = Nothing
      Dim otaBDLodgings As List(Of SIS.TA.taBDLodging) = SIS.TA.taBDLodging.UZ_taBDLodgingSelectList(0, 999, "", False, "", oVar.TABillNo)
      If otaBDLodgings.Count > 0 Then
        Dim oTblhtaBDLodging As Table = New Table
        oTblhtaBDLodging.Width = 1000
        oTblhtaBDLodging.Style.Add("margin-top", "15px")
        oTblhtaBDLodging.Style.Add("margin-left", "10px")
        oTblhtaBDLodging.Style.Add("margin-right", "10px")
        Dim oRowhtaBDLodging As TableRow = New TableRow
        Dim oColhtaBDLodging As TableCell = New TableCell
        oColhtaBDLodging.Font.Bold = True
        oColhtaBDLodging.Font.Underline = True
        oColhtaBDLodging.Font.Size = 10
        oColhtaBDLodging.CssClass = "grpHD"
        oColhtaBDLodging.Text = "Lodging Charges"
        oRowhtaBDLodging.Cells.Add(oColhtaBDLodging)
        oTblhtaBDLodging.Rows.Add(oRowhtaBDLodging)
        pnl1.Controls.Add(oTblhtaBDLodging)
        oTbltaBDLodging = New Table
        oTbltaBDLodging.Width = 1000
        oTbltaBDLodging.GridLines = GridLines.Both
        oTbltaBDLodging.Style.Add("margin-left", "10px")
        oTbltaBDLodging.Style.Add("margin-right", "10px")
        oRowtaBDLodging = New TableRow
        oColtaBDLodging = New TableCell
        oColtaBDLodging.Text = "IR"
        oColtaBDLodging.Width = 40
        oColtaBDLodging.Font.Bold = True
        oColtaBDLodging.CssClass = "colHD"
        oColtaBDLodging.Style.Add("text-align", "center")
        oRowtaBDLodging.Cells.Add(oColtaBDLodging)
        oColtaBDLodging = New TableCell
        oColtaBDLodging.Text = "Description"
        oColtaBDLodging.Font.Bold = True
        oColtaBDLodging.CssClass = "colHD"
        oColtaBDLodging.Width = 400
        oColtaBDLodging.Style.Add("text-align", "left")
        oRowtaBDLodging.Cells.Add(oColtaBDLodging)
        If oVar.TravelTypeID <> TATravelTypeValues.Domestic AndAlso oVar.TravelTypeID <> TATravelTypeValues.HomeVisit Then
          oColtaBDLodging = New TableCell
          oColtaBDLodging.Text = "Currency"
          oColtaBDLodging.Font.Bold = True
          oColtaBDLodging.CssClass = "colHD"
          oColtaBDLodging.Width = 60
          oColtaBDLodging.Style.Add("text-align", "center")
          oRowtaBDLodging.Cells.Add(oColtaBDLodging)
        End If
        oColtaBDLodging = New TableCell
        oColtaBDLodging.Text = "Claimed Amount"
        oColtaBDLodging.Font.Bold = True
        oColtaBDLodging.CssClass = "colHD"
        oColtaBDLodging.Width = 100
        oColtaBDLodging.Style.Add("text-align", "right")
        oRowtaBDLodging.Cells.Add(oColtaBDLodging)
        oColtaBDLodging = New TableCell
        oColtaBDLodging.Text = "Passed Amount"
        oColtaBDLodging.Font.Bold = True
        oColtaBDLodging.CssClass = "colHD"
        oColtaBDLodging.Width = 100
        oColtaBDLodging.Style.Add("text-align", "right")
        oRowtaBDLodging.Cells.Add(oColtaBDLodging)
        oColtaBDLodging = New TableCell
        oColtaBDLodging.Text = "Remarks"
        oColtaBDLodging.Font.Bold = True
        oColtaBDLodging.CssClass = "colHD"
        oColtaBDLodging.Style.Add("text-align", "left")
        oRowtaBDLodging.Cells.Add(oColtaBDLodging)
        oTbltaBDLodging.Rows.Add(oRowtaBDLodging)
        sn = 0
        ClaimTot = 0
        PassTot = 0
        For Each otaBDLodging As SIS.TA.taBDLodging In otaBDLodgings
          sn += 1
          oRowtaBDLodging = New TableRow
          oColtaBDLodging = New TableCell
          oColtaBDLodging.CssClass = "rowHD"
          Try
            If Convert.ToDecimal(otaBDLodging.AssessableValue) > 0 Then
              oColtaBDLodging.Text = "*" & otaBDLodging.SerialNo
            Else
              oColtaBDLodging.Text = otaBDLodging.SerialNo
            End If
          Catch ex As Exception
          End Try
          oColtaBDLodging.Style.Add("text-align", "center")
          oRowtaBDLodging.Cells.Add(oColtaBDLodging)
          oColtaBDLodging = New TableCell
          oColtaBDLodging.CssClass = "rowHD"
          oColtaBDLodging.Text = otaBDLodging.SystemText
          oColtaBDLodging.Style.Add("text-align", "left")
          oRowtaBDLodging.Cells.Add(oColtaBDLodging)
          If oVar.TravelTypeID <> TATravelTypeValues.Domestic AndAlso oVar.TravelTypeID <> TATravelTypeValues.HomeVisit Then
            Dim cur As String = ""
            With otaBDLodging
              Select Case .CurrencyID
                Case "INR", "USD", "EURO"
                  cur = .CurrencyID
                Case Else
                  cur = .CurrencyMain
              End Select
            End With
            oColtaBDLodging = New TableCell
            oColtaBDLodging.CssClass = "rowHD"
            oColtaBDLodging.Text = cur
            oColtaBDLodging.Style.Add("text-align", "center")
            oRowtaBDLodging.Cells.Add(oColtaBDLodging)
          End If
          oColtaBDLodging = New TableCell
          oColtaBDLodging.CssClass = "rowHD"
          oColtaBDLodging.Text = otaBDLodging.AmountTotal
          oColtaBDLodging.Style.Add("text-align", "right")
          If otaBDLodging.OOEBySystem Then
            oColtaBDLodging.ForeColor = Drawing.Color.Red
          End If
          oRowtaBDLodging.Cells.Add(oColtaBDLodging)
          oColtaBDLodging = New TableCell
          oColtaBDLodging.CssClass = "rowHD"
          oColtaBDLodging.Text = otaBDLodging.PassedAmountTotal
          oColtaBDLodging.Style.Add("text-align", "right")
          oRowtaBDLodging.Cells.Add(oColtaBDLodging)
          oColtaBDLodging = New TableCell
          oColtaBDLodging.CssClass = "rowHD"
          Dim remTbl As New Table
          Dim remrow As New TableRow
          Dim remaRow As New TableRow
          Dim remcol As New TableCell
          remTbl.BorderStyle = BorderStyle.None
          remcol.Text = otaBDLodging.Remarks
          remrow.Cells.Add(remcol)
          remTbl.Rows.Add(remrow)
          remrow = New TableRow
          remcol = New TableCell
          remcol.Text = otaBDLodging.AccountsRemarks
          remcol.ForeColor = Drawing.Color.Red
          remrow.Cells.Add(remcol)
          remTbl.Rows.Add(remrow)
          oColtaBDLodging.Controls.Add(remTbl)
          oColtaBDLodging.Style.Add("text-align", "left")
          oRowtaBDLodging.Cells.Add(oColtaBDLodging)
          oTbltaBDLodging.Rows.Add(oRowtaBDLodging)
          'GST Details
          If oVar.TravelTypeID = TATravelTypeValues.Domestic Then
            If otaBDLodging.StayedInHotel Then
              otaBDLodging = SIS.TA.taBDLodging.UpdateGSTDataInBDL(otaBDLodging)
              oTbl = New Table
              oTbl.Width = 945
              oTbl.GridLines = GridLines.None
              oTbl.Style.Add("margin-top", "2px")
              oTbl.Style.Add("margin-left", "2px")

              oRow = New TableRow
              oCol = New TableCell
              oCol.Text = "Hotel Name:"
              oCol.Font.Bold = True
              oRow.Cells.Add(oCol)
              oCol = New TableCell
              oCol.Text = otaBDLodging.ModeText
              oRow.Cells.Add(oCol)
              oCol = New TableCell
              oCol.Text = "Type:"
              oCol.Font.Bold = True
              oRow.Cells.Add(oCol)
              oCol = New TableCell
              oCol.Text = otaBDLodging.PurchaseType
              oRow.Cells.Add(oCol)
              oCol = New TableCell
              oCol.Text = "Isgec GSTIN:"
              oCol.Font.Bold = True
              oRow.Cells.Add(oCol)
              oCol = New TableCell
              oCol.Text = otaBDLodging.SPMT_IsgecGSTIN4_Description
              oRow.Cells.Add(oCol)
              oTbl.Rows.Add(oRow)

              oRow = New TableRow
              oCol = New TableCell
              oCol.Text = "Hotel GSTIN:"
              oCol.Font.Bold = True
              oRow.Cells.Add(oCol)
              oCol = New TableCell
              oCol.Text = IIf(otaBDLodging.VR_BPGSTIN7_Description = "", otaBDLodging.SupplierGSTINNo, otaBDLodging.VR_BPGSTIN7_Description)
              oRow.Cells.Add(oCol)
              oCol = New TableCell
              oCol.Text = "Bill Number:"
              oCol.Font.Bold = True
              oRow.Cells.Add(oCol)
              oCol = New TableCell
              oCol.Text = otaBDLodging.BillNumber
              oRow.Cells.Add(oCol)
              oCol = New TableCell
              oCol.Text = "Bill Date:"
              oCol.Font.Bold = True
              oRow.Cells.Add(oCol)
              oCol = New TableCell
              oCol.Text = otaBDLodging.BillDate
              oRow.Cells.Add(oCol)
              oTbl.Rows.Add(oRow)

              oRow = New TableRow
              oCol = New TableCell
              oCol.Text = "Assessable Value:"
              oCol.Font.Bold = True
              oRow.Cells.Add(oCol)
              oCol = New TableCell
              oCol.Text = otaBDLodging.AssessableValue
              oRow.Cells.Add(oCol)
              oCol = New TableCell
              oCol.Text = "Total GST:"
              oCol.Font.Bold = True
              oRow.Cells.Add(oCol)
              oCol = New TableCell
              oCol.Text = otaBDLodging.TotalGST
              oRow.Cells.Add(oCol)
              oCol = New TableCell
              oCol.Text = "Total Amount:"
              oCol.Font.Bold = True
              oRow.Cells.Add(oCol)
              oCol = New TableCell
              oCol.Text = otaBDLodging.TotalAmount
              oRow.Cells.Add(oCol)
              oTbl.Rows.Add(oRow)


              oRowtaBDLodging = New TableRow
              oColtaBDLodging = New TableCell
              oRowtaBDLodging.Cells.Add(oColtaBDLodging)
              oColtaBDLodging = New TableCell
              oColtaBDLodging.ColumnSpan = "4"
              oColtaBDLodging.Controls.Add(oTbl)
              oRowtaBDLodging.Cells.Add(oColtaBDLodging)
              oTbltaBDLodging.Rows.Add(oRowtaBDLodging)
            End If
          End If
          'End GST Details
          ClaimTot += otaBDLodging.AmountTotal
          PassTot += otaBDLodging.PassedAmountTotal
        Next
        If sn > 1 Then
          oRow = New TableRow
          oCol = New TableCell
          With oCol
            If oVar.TravelTypeID <> TATravelTypeValues.Domestic AndAlso oVar.TravelTypeID <> TATravelTypeValues.HomeVisit Then
              .ColumnSpan = 3
            Else
              .ColumnSpan = 2
            End If
            .Text = "TOTAL"
            .Style.Add("text-align", "right")
          End With
          oRow.Cells.Add(oCol)
          oCol = New TableCell
          With oCol
            .Text = ClaimTot.ToString("n")
            .Style.Add("text-align", "right")
          End With
          oRow.Cells.Add(oCol)
          oCol = New TableCell
          With oCol
            .Text = PassTot.ToString("n")
            .Style.Add("text-align", "right")
          End With
          oRow.Cells.Add(oCol)
          oCol = New TableCell
          oRow.Cells.Add(oCol)
          oTbltaBDLodging.Rows.Add(oRow)
        End If
        pnl1.Controls.Add(oTbltaBDLodging)
      End If
      Dim oTbltaBDExpense As Table = Nothing
      Dim oRowtaBDExpense As TableRow = Nothing
      Dim oColtaBDExpense As TableCell = Nothing
      Dim otaBDExpenses As List(Of SIS.TA.taBDExpense) = SIS.TA.taBDExpense.UZ_taBDExpenseSelectList(0, 999, "", False, "", oVar.TABillNo)
      If otaBDExpenses.Count > 0 Then
        Dim oTblhtaBDExpense As Table = New Table
        oTblhtaBDExpense.Width = 1000
        oTblhtaBDExpense.Style.Add("margin-top", "15px")
        oTblhtaBDExpense.Style.Add("margin-left", "10px")
        oTblhtaBDExpense.Style.Add("margin-right", "10px")
        Dim oRowhtaBDExpense As TableRow = New TableRow
        Dim oColhtaBDExpense As TableCell = New TableCell
        oColhtaBDExpense.Font.Bold = True
        oColhtaBDExpense.Font.Underline = True
        oColhtaBDExpense.Font.Size = 10
        oColhtaBDExpense.CssClass = "grpHD"
        If oVar.TravelTypeID = TATravelTypeValues.Domestic Then
          oColhtaBDExpense.Text = "Other Expenses"
        Else
          oColhtaBDExpense.Text = "Other Expenses [Only with MD Sanction]"
        End If
        oRowhtaBDExpense.Cells.Add(oColhtaBDExpense)
        oTblhtaBDExpense.Rows.Add(oRowhtaBDExpense)
        pnl1.Controls.Add(oTblhtaBDExpense)
        oTbltaBDExpense = New Table
        oTbltaBDExpense.Width = 1000
        oTbltaBDExpense.GridLines = GridLines.Both
        oTbltaBDExpense.Style.Add("margin-left", "10px")
        oTbltaBDExpense.Style.Add("margin-right", "10px")
        oRowtaBDExpense = New TableRow
        oColtaBDExpense = New TableCell
        oColtaBDExpense.Text = "S.N."
        oColtaBDExpense.Width = 40
        oColtaBDExpense.Font.Bold = True
        oColtaBDExpense.CssClass = "colHD"
        oColtaBDExpense.Style.Add("text-align", "center")
        oRowtaBDExpense.Cells.Add(oColtaBDExpense)
        oColtaBDExpense = New TableCell
        oColtaBDExpense.Text = "Description"
        oColtaBDExpense.Font.Bold = True
        oColtaBDExpense.CssClass = "colHD"
        oColtaBDExpense.Width = 400
        oColtaBDExpense.Style.Add("text-align", "left")
        oRowtaBDExpense.Cells.Add(oColtaBDExpense)
        If oVar.TravelTypeID <> TATravelTypeValues.Domestic AndAlso oVar.TravelTypeID <> TATravelTypeValues.HomeVisit Then
          oColtaBDExpense = New TableCell
          oColtaBDExpense.Text = "Currency"
          oColtaBDExpense.Font.Bold = True
          oColtaBDExpense.CssClass = "colHD"
          oColtaBDExpense.Width = 60
          oColtaBDExpense.Style.Add("text-align", "center")
          oRowtaBDExpense.Cells.Add(oColtaBDExpense)
        End If
        oColtaBDExpense = New TableCell
        oColtaBDExpense.Text = "Claimed Amount"
        oColtaBDExpense.Font.Bold = True
        oColtaBDExpense.CssClass = "colHD"
        oColtaBDExpense.Width = 100
        oColtaBDExpense.Style.Add("text-align", "right")
        oRowtaBDExpense.Cells.Add(oColtaBDExpense)
        oColtaBDExpense = New TableCell
        oColtaBDExpense.Text = "Passed Amount"
        oColtaBDExpense.Font.Bold = True
        oColtaBDExpense.CssClass = "colHD"
        oColtaBDExpense.Width = 100
        oColtaBDExpense.Style.Add("text-align", "right")
        oRowtaBDExpense.Cells.Add(oColtaBDExpense)
        oColtaBDExpense = New TableCell
        oColtaBDExpense.Text = "Remarks"
        oColtaBDExpense.Font.Bold = True
        oColtaBDExpense.CssClass = "colHD"
        oColtaBDExpense.Style.Add("text-align", "left")
        oRowtaBDExpense.Cells.Add(oColtaBDExpense)
        oTbltaBDExpense.Rows.Add(oRowtaBDExpense)
        sn = 0
        ClaimTot = 0
        PassTot = 0
        For Each otaBDExpense As SIS.TA.taBDExpense In otaBDExpenses
          sn += 1
          oRowtaBDExpense = New TableRow
          oColtaBDExpense = New TableCell
          oColtaBDExpense.CssClass = "rowHD"
          oColtaBDExpense.Text = sn ' otaBDExpense.SerialNo
          oColtaBDExpense.Style.Add("text-align", "center")
          oRowtaBDExpense.Cells.Add(oColtaBDExpense)
          oColtaBDExpense = New TableCell
          oColtaBDExpense.CssClass = "rowHD"
          oColtaBDExpense.Text = otaBDExpense.SystemText
          oColtaBDExpense.Style.Add("text-align", "left")
          oRowtaBDExpense.Cells.Add(oColtaBDExpense)
          If oVar.TravelTypeID <> TATravelTypeValues.Domestic AndAlso oVar.TravelTypeID <> TATravelTypeValues.HomeVisit Then
            Dim cur As String = ""
            With otaBDExpense
              Select Case .CurrencyID
                Case "INR", "USD", "EURO"
                  cur = .CurrencyID
                Case Else
                  cur = .CurrencyMain
              End Select
            End With
            oColtaBDExpense = New TableCell
            oColtaBDExpense.CssClass = "rowHD"
            oColtaBDExpense.Text = cur
            oColtaBDExpense.Style.Add("text-align", "center")
            oRowtaBDExpense.Cells.Add(oColtaBDExpense)
          End If
          oColtaBDExpense = New TableCell
          oColtaBDExpense.CssClass = "rowHD"
          oColtaBDExpense.Text = otaBDExpense.AmountTotal
          oColtaBDExpense.Style.Add("text-align", "right")
          If otaBDExpense.OOEBySystem Then
            oColtaBDExpense.ForeColor = Drawing.Color.Red
          End If
          oRowtaBDExpense.Cells.Add(oColtaBDExpense)
          oColtaBDExpense = New TableCell
          oColtaBDExpense.CssClass = "rowHD"
          oColtaBDExpense.Text = otaBDExpense.PassedAmountTotal
          oColtaBDExpense.Style.Add("text-align", "right")
          oRowtaBDExpense.Cells.Add(oColtaBDExpense)
          oColtaBDExpense = New TableCell
          oColtaBDExpense.CssClass = "rowHD"
          Dim remTbl As New Table
          Dim remrow As New TableRow
          Dim remaRow As New TableRow
          Dim remcol As New TableCell
          remTbl.BorderStyle = BorderStyle.None
          remcol.Text = otaBDExpense.Remarks
          remrow.Cells.Add(remcol)
          remTbl.Rows.Add(remrow)
          remrow = New TableRow
          remcol = New TableCell
          remcol.Text = otaBDExpense.AccountsRemarks
          remcol.ForeColor = Drawing.Color.Red
          remrow.Cells.Add(remcol)
          remTbl.Rows.Add(remrow)
          oColtaBDExpense.Controls.Add(remTbl)
          oColtaBDExpense.Style.Add("text-align", "left")
          oRowtaBDExpense.Cells.Add(oColtaBDExpense)
          oTbltaBDExpense.Rows.Add(oRowtaBDExpense)
          ClaimTot += otaBDExpense.AmountTotal
          PassTot += otaBDExpense.PassedAmountTotal
        Next
        If sn > 1 Then
          oRow = New TableRow
          oCol = New TableCell
          With oCol
            If oVar.TravelTypeID <> TATravelTypeValues.Domestic AndAlso oVar.TravelTypeID <> TATravelTypeValues.HomeVisit Then
              .ColumnSpan = 3
            Else
              .ColumnSpan = 2
            End If
            .Text = "TOTAL"
            .Style.Add("text-align", "right")
          End With
          oRow.Cells.Add(oCol)
          oCol = New TableCell
          With oCol
            .Text = ClaimTot.ToString("n")
            .Style.Add("text-align", "right")
          End With
          oRow.Cells.Add(oCol)
          oCol = New TableCell
          With oCol
            .Text = PassTot.ToString("n")
            .Style.Add("text-align", "right")
          End With
          oRow.Cells.Add(oCol)
          oCol = New TableCell
          oRow.Cells.Add(oCol)
          oTbltaBDExpense.Rows.Add(oRow)
        End If
        pnl1.Controls.Add(oTbltaBDExpense)
      End If
      Dim oTbltaBDFinance As Table = Nothing
      Dim oRowtaBDFinance As TableRow = Nothing
      Dim oColtaBDFinance As TableCell = Nothing
      Dim otaBDFinances As List(Of SIS.TA.taBDFinance) = SIS.TA.taBDFinance.UZ_taBDFinanceSelectList(0, 999, "", False, "", oVar.TABillNo)
      If otaBDFinances.Count > 0 Then
        Dim oTblhtaBDFinance As Table = New Table
        oTblhtaBDFinance.Width = 1000
        oTblhtaBDFinance.Style.Add("margin-top", "15px")
        oTblhtaBDFinance.Style.Add("margin-left", "10px")
        oTblhtaBDFinance.Style.Add("margin-right", "10px")
        Dim oRowhtaBDFinance As TableRow = New TableRow
        Dim oColhtaBDFinance As TableCell = New TableCell
        oColhtaBDFinance.Font.Bold = True
        oColhtaBDFinance.Font.Underline = True
        oColhtaBDFinance.Font.Size = 10
        oColhtaBDFinance.CssClass = "grpHD"
        oColhtaBDFinance.Text = "Source of Finance"
        oRowhtaBDFinance.Cells.Add(oColhtaBDFinance)
        oTblhtaBDFinance.Rows.Add(oRowhtaBDFinance)
        pnl1.Controls.Add(oTblhtaBDFinance)
        oTbltaBDFinance = New Table
        oTbltaBDFinance.Width = 1000
        oTbltaBDFinance.GridLines = GridLines.Both
        oTbltaBDFinance.Style.Add("margin-left", "10px")
        oTbltaBDFinance.Style.Add("margin-right", "10px")
        oRowtaBDFinance = New TableRow
        oColtaBDFinance = New TableCell
        oColtaBDFinance.Text = "S.N."
        oColtaBDFinance.Width = 40
        oColtaBDFinance.Font.Bold = True
        oColtaBDFinance.CssClass = "colHD"
        oColtaBDFinance.Style.Add("text-align", "center")
        oRowtaBDFinance.Cells.Add(oColtaBDFinance)
        oColtaBDFinance = New TableCell
        oColtaBDFinance.Text = "Description"
        oColtaBDFinance.Font.Bold = True
        oColtaBDFinance.CssClass = "colHD"
        oColtaBDFinance.Width = 400
        oColtaBDFinance.Style.Add("text-align", "left")
        oRowtaBDFinance.Cells.Add(oColtaBDFinance)
        If oVar.TravelTypeID <> TATravelTypeValues.Domestic AndAlso oVar.TravelTypeID <> TATravelTypeValues.HomeVisit Then
          oColtaBDFinance = New TableCell
          oColtaBDFinance.Text = "Currency"
          oColtaBDFinance.Font.Bold = True
          oColtaBDFinance.CssClass = "colHD"
          oColtaBDFinance.Width = 60
          oColtaBDFinance.Style.Add("text-align", "center")
          oRowtaBDFinance.Cells.Add(oColtaBDFinance)
        End If
        oColtaBDFinance = New TableCell
        oColtaBDFinance.Text = "Financed Amount"
        oColtaBDFinance.Font.Bold = True
        oColtaBDFinance.CssClass = "colHD"
        oColtaBDFinance.Width = 100
        oColtaBDFinance.Style.Add("text-align", "right")
        oRowtaBDFinance.Cells.Add(oColtaBDFinance)
        oColtaBDFinance = New TableCell
        oColtaBDFinance.Text = "Acknowledged Amount"
        oColtaBDFinance.Font.Bold = True
        oColtaBDFinance.CssClass = "colHD"
        oColtaBDFinance.Width = 100
        oColtaBDFinance.Style.Add("text-align", "right")
        oRowtaBDFinance.Cells.Add(oColtaBDFinance)
        oColtaBDFinance = New TableCell
        oColtaBDFinance.Text = "Remarks"
        oColtaBDFinance.Font.Bold = True
        oColtaBDFinance.CssClass = "colHD"
        oColtaBDFinance.Style.Add("text-align", "left")
        oRowtaBDFinance.Cells.Add(oColtaBDFinance)
        oTbltaBDFinance.Rows.Add(oRowtaBDFinance)
        sn = 0
        ClaimTot = 0
        PassTot = 0
        For Each otaBDFinance As SIS.TA.taBDFinance In otaBDFinances
          sn += 1
          oRowtaBDFinance = New TableRow
          oColtaBDFinance = New TableCell
          oColtaBDFinance.CssClass = "rowHD"
          oColtaBDFinance.Text = sn 'otaBDFinance.SerialNo
          oColtaBDFinance.Style.Add("text-align", "center")
          oRowtaBDFinance.Cells.Add(oColtaBDFinance)
          oColtaBDFinance = New TableCell
          oColtaBDFinance.CssClass = "rowHD"
          oColtaBDFinance.Text = otaBDFinance.SystemText
          oColtaBDFinance.Style.Add("text-align", "left")
          oRowtaBDFinance.Cells.Add(oColtaBDFinance)
          If oVar.TravelTypeID <> TATravelTypeValues.Domestic AndAlso oVar.TravelTypeID <> TATravelTypeValues.HomeVisit Then
            Dim cur As String = ""
            With otaBDFinance
              Select Case .CurrencyID
                Case "INR", "USD", "EURO"
                  cur = .CurrencyID
                Case Else
                  cur = .CurrencyMain
              End Select
            End With
            oColtaBDFinance = New TableCell
            oColtaBDFinance.CssClass = "rowHD"
            oColtaBDFinance.Text = cur
            oColtaBDFinance.Style.Add("text-align", "center")
            oRowtaBDFinance.Cells.Add(oColtaBDFinance)
          End If
          oColtaBDFinance = New TableCell
          oColtaBDFinance.CssClass = "rowHD"
          oColtaBDFinance.Text = otaBDFinance.AmountTotal
          oColtaBDFinance.Style.Add("text-align", "right")
          If otaBDFinance.OOEBySystem Then
            oColtaBDFinance.ForeColor = Drawing.Color.Red
          End If
          oRowtaBDFinance.Cells.Add(oColtaBDFinance)
          oColtaBDFinance = New TableCell
          oColtaBDFinance.CssClass = "rowHD"
          oColtaBDFinance.Text = otaBDFinance.PassedAmountTotal
          oColtaBDFinance.Style.Add("text-align", "right")
          oRowtaBDFinance.Cells.Add(oColtaBDFinance)
          oColtaBDFinance = New TableCell
          oColtaBDFinance.CssClass = "rowHD"
          Dim remTbl As New Table
          Dim remrow As New TableRow
          Dim remaRow As New TableRow
          Dim remcol As New TableCell
          remTbl.BorderStyle = BorderStyle.None
          remcol.Text = otaBDFinance.Remarks
          remrow.Cells.Add(remcol)
          remTbl.Rows.Add(remrow)
          remrow = New TableRow
          remcol = New TableCell
          remcol.Text = otaBDFinance.AccountsRemarks
          remcol.ForeColor = Drawing.Color.Red
          remrow.Cells.Add(remcol)
          remTbl.Rows.Add(remrow)
          oColtaBDFinance.Controls.Add(remTbl)
          oColtaBDFinance.Style.Add("text-align", "left")
          oRowtaBDFinance.Cells.Add(oColtaBDFinance)
          oTbltaBDFinance.Rows.Add(oRowtaBDFinance)
          ClaimTot += otaBDFinance.AmountTotal
          PassTot += otaBDFinance.PassedAmountTotal
        Next
        If sn > 1 Then
          oRow = New TableRow
          oCol = New TableCell
          With oCol
            If oVar.TravelTypeID <> TATravelTypeValues.Domestic AndAlso oVar.TravelTypeID <> TATravelTypeValues.HomeVisit Then
              .ColumnSpan = 3
            Else
              .ColumnSpan = 2
            End If
            .Text = "TOTAL"
            .Style.Add("text-align", "right")
          End With
          oRow.Cells.Add(oCol)
          oCol = New TableCell
          With oCol
            .Text = ClaimTot.ToString("n")
            .Style.Add("text-align", "right")
          End With
          oRow.Cells.Add(oCol)
          oCol = New TableCell
          With oCol
            .Text = PassTot.ToString("n")
            .Style.Add("text-align", "right")
          End With
          oRow.Cells.Add(oCol)
          oCol = New TableCell
          oRow.Cells.Add(oCol)
          oTbltaBDFinance.Rows.Add(oRow)
        End If
        pnl1.Controls.Add(oTbltaBDFinance)
      End If
      Dim oTbltaBDMileage As Table = Nothing
      Dim oRowtaBDMileage As TableRow = Nothing
      Dim oColtaBDMileage As TableCell = Nothing
      Dim otaBDMileages As List(Of SIS.TA.taBDMileage) = SIS.TA.taBDMileage.UZ_taBDMileageSelectList(0, 999, "", False, "", oVar.TABillNo)
      If otaBDMileages.Count > 0 Then
        Dim oTblhtaBDMileage As Table = New Table
        oTblhtaBDMileage.Width = 1000
        oTblhtaBDMileage.Style.Add("margin-top", "15px")
        oTblhtaBDMileage.Style.Add("margin-left", "10px")
        oTblhtaBDMileage.Style.Add("margin-right", "10px")
        Dim oRowhtaBDMileage As TableRow = New TableRow
        Dim oColhtaBDMileage As TableCell = New TableCell
        oColhtaBDMileage.Font.Bold = True
        oColhtaBDMileage.Font.Underline = True
        oColhtaBDMileage.Font.Size = 10
        oColhtaBDMileage.CssClass = "grpHD"
        oColhtaBDMileage.Text = "Mileage Claim"
        oRowhtaBDMileage.Cells.Add(oColhtaBDMileage)
        oTblhtaBDMileage.Rows.Add(oRowhtaBDMileage)
        pnl1.Controls.Add(oTblhtaBDMileage)
        oTbltaBDMileage = New Table
        oTbltaBDMileage.Width = 1000
        oTbltaBDMileage.GridLines = GridLines.Both
        oTbltaBDMileage.Style.Add("margin-left", "10px")
        oTbltaBDMileage.Style.Add("margin-right", "10px")
        oRowtaBDMileage = New TableRow
        oColtaBDMileage = New TableCell
        oColtaBDMileage.Text = "S.N."
        oColtaBDMileage.Width = 40
        oColtaBDMileage.Font.Bold = True
        oColtaBDMileage.CssClass = "colHD"
        oColtaBDMileage.Style.Add("text-align", "center")
        oRowtaBDMileage.Cells.Add(oColtaBDMileage)
        oColtaBDMileage = New TableCell
        oColtaBDMileage.Text = "Description"
        oColtaBDMileage.Font.Bold = True
        oColtaBDMileage.CssClass = "colHD"
        oColtaBDMileage.Width = 400
        oColtaBDMileage.Style.Add("text-align", "left")
        oRowtaBDMileage.Cells.Add(oColtaBDMileage)
        oColtaBDMileage = New TableCell
        oColtaBDMileage.Text = "Claimed Amount"
        oColtaBDMileage.Font.Bold = True
        oColtaBDMileage.CssClass = "colHD"
        oColtaBDMileage.Width = 100
        oColtaBDMileage.Style.Add("text-align", "right")
        oRowtaBDMileage.Cells.Add(oColtaBDMileage)
        oColtaBDMileage = New TableCell
        oColtaBDMileage.Text = "Passed Amount"
        oColtaBDMileage.Font.Bold = True
        oColtaBDMileage.CssClass = "colHD"
        oColtaBDMileage.Width = 100
        oColtaBDMileage.Style.Add("text-align", "right")
        oRowtaBDMileage.Cells.Add(oColtaBDMileage)
        oColtaBDMileage = New TableCell
        oColtaBDMileage.Text = "Remarks"
        oColtaBDMileage.Font.Bold = True
        oColtaBDMileage.CssClass = "colHD"
        oColtaBDMileage.Style.Add("text-align", "left")
        oRowtaBDMileage.Cells.Add(oColtaBDMileage)
        oTbltaBDMileage.Rows.Add(oRowtaBDMileage)
        sn = 0
        ClaimTot = 0
        PassTot = 0
        For Each otaBDMileage As SIS.TA.taBDMileage In otaBDMileages
          sn += 1
          oRowtaBDMileage = New TableRow
          oColtaBDMileage = New TableCell
          oColtaBDMileage.CssClass = "rowHD"
          oColtaBDMileage.Text = sn ' otaBDMileage.SerialNo
          oColtaBDMileage.Style.Add("text-align", "center")
          oRowtaBDMileage.Cells.Add(oColtaBDMileage)
          oColtaBDMileage = New TableCell
          oColtaBDMileage.CssClass = "rowHD"
          oColtaBDMileage.Text = otaBDMileage.SystemText
          oColtaBDMileage.Style.Add("text-align", "left")
          oRowtaBDMileage.Cells.Add(oColtaBDMileage)
          oColtaBDMileage = New TableCell
          oColtaBDMileage.CssClass = "rowHD"
          oColtaBDMileage.Text = otaBDMileage.AmountTotal
          oColtaBDMileage.Style.Add("text-align", "right")
          If otaBDMileage.OOEBySystem Then
            oColtaBDMileage.ForeColor = Drawing.Color.Red
          End If
          oRowtaBDMileage.Cells.Add(oColtaBDMileage)
          oColtaBDMileage = New TableCell
          oColtaBDMileage.CssClass = "rowHD"
          oColtaBDMileage.Text = otaBDMileage.PassedAmountTotal
          oColtaBDMileage.Style.Add("text-align", "right")
          oRowtaBDMileage.Cells.Add(oColtaBDMileage)
          oColtaBDMileage = New TableCell
          oColtaBDMileage.CssClass = "rowHD"
          Dim remTbl As New Table
          Dim remrow As New TableRow
          Dim remaRow As New TableRow
          Dim remcol As New TableCell
          remTbl.BorderStyle = BorderStyle.None
          remcol.Text = otaBDMileage.Remarks
          remrow.Cells.Add(remcol)
          remTbl.Rows.Add(remrow)
          remrow = New TableRow
          remcol = New TableCell
          remcol.Text = otaBDMileage.AccountsRemarks
          remcol.ForeColor = Drawing.Color.Red
          remrow.Cells.Add(remcol)
          remTbl.Rows.Add(remrow)
          oColtaBDMileage.Controls.Add(remTbl)
          oColtaBDMileage.Style.Add("text-align", "left")
          oRowtaBDMileage.Cells.Add(oColtaBDMileage)
          oTbltaBDMileage.Rows.Add(oRowtaBDMileage)
          ClaimTot += otaBDMileage.AmountTotal
          PassTot += otaBDMileage.PassedAmountTotal
        Next
        If sn > 1 Then
          oRow = New TableRow
          oCol = New TableCell
          With oCol
            If oVar.TravelTypeID <> TATravelTypeValues.Domestic AndAlso oVar.TravelTypeID <> TATravelTypeValues.HomeVisit Then
              .ColumnSpan = 3
            Else
              .ColumnSpan = 2
            End If
            .Text = "TOTAL"
            .Style.Add("text-align", "right")
          End With
          oRow.Cells.Add(oCol)
          oCol = New TableCell
          With oCol
            .Text = ClaimTot.ToString("n")
            .Style.Add("text-align", "right")
          End With
          oRow.Cells.Add(oCol)
          oCol = New TableCell
          With oCol
            .Text = PassTot.ToString("n")
            .Style.Add("text-align", "right")
          End With
          oRow.Cells.Add(oCol)
          oCol = New TableCell
          oRow.Cells.Add(oCol)
          oTbltaBDMileage.Rows.Add(oRow)
        End If
        pnl1.Controls.Add(oTbltaBDMileage)
      End If
      Dim oTbltaBDDriver As Table = Nothing
      Dim oRowtaBDDriver As TableRow = Nothing
      Dim oColtaBDDriver As TableCell = Nothing
      Dim otaBDDrivers As List(Of SIS.TA.taBDDriver) = SIS.TA.taBDDriver.UZ_taBDDriverSelectList(0, 999, "", False, "", oVar.TABillNo)
      If otaBDDrivers.Count > 0 Then
        Dim oTblhtaBDDriver As Table = New Table
        oTblhtaBDDriver.Width = 1000
        oTblhtaBDDriver.Style.Add("margin-top", "15px")
        oTblhtaBDDriver.Style.Add("margin-left", "10px")
        oTblhtaBDDriver.Style.Add("margin-right", "10px")
        Dim oRowhtaBDDriver As TableRow = New TableRow
        Dim oColhtaBDDriver As TableCell = New TableCell
        oColhtaBDDriver.Font.Bold = True
        oColhtaBDDriver.Font.Underline = True
        oColhtaBDDriver.Font.Size = 10
        oColhtaBDDriver.CssClass = "grpHD"
        oColhtaBDDriver.Text = "Driver Charges"
        oRowhtaBDDriver.Cells.Add(oColhtaBDDriver)
        oTblhtaBDDriver.Rows.Add(oRowhtaBDDriver)
        pnl1.Controls.Add(oTblhtaBDDriver)
        oTbltaBDDriver = New Table
        oTbltaBDDriver.Width = 1000
        oTbltaBDDriver.GridLines = GridLines.Both
        oTbltaBDDriver.Style.Add("margin-left", "10px")
        oTbltaBDDriver.Style.Add("margin-right", "10px")
        oRowtaBDDriver = New TableRow
        oColtaBDDriver = New TableCell
        oColtaBDDriver.Text = "S.N."
        oColhtaBDDriver.Width = 40
        oColtaBDDriver.Font.Bold = True
        oColtaBDDriver.CssClass = "colHD"
        oColtaBDDriver.Style.Add("text-align", "center")
        oRowtaBDDriver.Cells.Add(oColtaBDDriver)
        oColtaBDDriver = New TableCell
        oColtaBDDriver.Text = "Description"
        oColtaBDDriver.Font.Bold = True
        oColtaBDDriver.CssClass = "colHD"
        oColtaBDDriver.Width = 400
        oColtaBDDriver.Style.Add("text-align", "left")
        oRowtaBDDriver.Cells.Add(oColtaBDDriver)
        oColtaBDDriver = New TableCell
        oColtaBDDriver.Text = "Claimed Amount"
        oColtaBDDriver.Font.Bold = True
        oColtaBDDriver.CssClass = "colHD"
        oColtaBDDriver.Width = 100
        oColtaBDDriver.Style.Add("text-align", "right")
        oRowtaBDDriver.Cells.Add(oColtaBDDriver)
        oColtaBDDriver = New TableCell
        oColtaBDDriver.Text = "Passed Amount"
        oColtaBDDriver.Font.Bold = True
        oColtaBDDriver.CssClass = "colHD"
        oColtaBDDriver.Width = 100
        oColtaBDDriver.Style.Add("text-align", "right")
        oRowtaBDDriver.Cells.Add(oColtaBDDriver)
        oColtaBDDriver = New TableCell
        oColtaBDDriver.Text = "Remarks"
        oColtaBDDriver.Font.Bold = True
        oColtaBDDriver.CssClass = "colHD"
        oColtaBDDriver.Style.Add("text-align", "left")
        oRowtaBDDriver.Cells.Add(oColtaBDDriver)
        oTbltaBDDriver.Rows.Add(oRowtaBDDriver)
        sn = 0
        ClaimTot = 0
        PassTot = 0
        For Each otaBDDriver As SIS.TA.taBDDriver In otaBDDrivers
          sn += 1
          oRowtaBDDriver = New TableRow
          oColtaBDDriver = New TableCell
          oColtaBDDriver.CssClass = "rowHD"
          oColtaBDDriver.Text = sn 'otaBDDriver.SerialNo
          oColtaBDDriver.Style.Add("text-align", "center")
          oRowtaBDDriver.Cells.Add(oColtaBDDriver)
          oColtaBDDriver = New TableCell
          oColtaBDDriver.CssClass = "rowHD"
          oColtaBDDriver.Text = otaBDDriver.SystemText
          oColtaBDDriver.Style.Add("text-align", "left")
          oRowtaBDDriver.Cells.Add(oColtaBDDriver)
          oColtaBDDriver = New TableCell
          oColtaBDDriver.CssClass = "rowHD"
          oColtaBDDriver.Text = otaBDDriver.AmountTotal
          oColtaBDDriver.Style.Add("text-align", "right")
          If otaBDDriver.OOEBySystem Then
            oColtaBDDriver.ForeColor = Drawing.Color.Red
          End If
          oRowtaBDDriver.Cells.Add(oColtaBDDriver)
          oColtaBDDriver = New TableCell
          oColtaBDDriver.CssClass = "rowHD"
          oColtaBDDriver.Text = otaBDDriver.PassedAmountTotal
          oColtaBDDriver.Style.Add("text-align", "right")
          oRowtaBDDriver.Cells.Add(oColtaBDDriver)
          oColtaBDDriver = New TableCell
          oColtaBDDriver.CssClass = "rowHD"
          Dim remTbl As New Table
          Dim remrow As New TableRow
          Dim remaRow As New TableRow
          Dim remcol As New TableCell
          remTbl.BorderStyle = BorderStyle.None
          remcol.Text = otaBDDriver.Remarks
          remrow.Cells.Add(remcol)
          remTbl.Rows.Add(remrow)
          remrow = New TableRow
          remcol = New TableCell
          remcol.Text = otaBDDriver.AccountsRemarks
          remcol.ForeColor = Drawing.Color.Red
          remrow.Cells.Add(remcol)
          remTbl.Rows.Add(remrow)
          oColtaBDDriver.Controls.Add(remTbl)
          oColtaBDDriver.Style.Add("text-align", "left")
          oRowtaBDDriver.Cells.Add(oColtaBDDriver)
          oTbltaBDDriver.Rows.Add(oRowtaBDDriver)
          ClaimTot += otaBDDriver.AmountTotal
          PassTot += otaBDDriver.PassedAmountTotal
        Next
        If sn > 1 Then
          oRow = New TableRow
          oCol = New TableCell
          With oCol
            If oVar.TravelTypeID <> TATravelTypeValues.Domestic AndAlso oVar.TravelTypeID <> TATravelTypeValues.HomeVisit Then
              .ColumnSpan = 3
            Else
              .ColumnSpan = 2
            End If
            .Text = "TOTAL"
            .Style.Add("text-align", "right")
          End With
          oRow.Cells.Add(oCol)
          oCol = New TableCell
          With oCol
            .Text = ClaimTot.ToString("n")
            .Style.Add("text-align", "right")
          End With
          oRow.Cells.Add(oCol)
          oCol = New TableCell
          With oCol
            .Text = PassTot.ToString("n")
            .Style.Add("text-align", "right")
          End With
          oRow.Cells.Add(oCol)
          oCol = New TableCell
          oRow.Cells.Add(oCol)
          oTbltaBDDriver.Rows.Add(oRow)
        End If
        pnl1.Controls.Add(oTbltaBDDriver)
      End If
      Dim oTbltaBDDA As Table = Nothing
      Dim oRowtaBDDA As TableRow = Nothing
      Dim oColtaBDDA As TableCell = Nothing
      Dim otaBDDAs As List(Of SIS.TA.taBDDA) = SIS.TA.taBDDA.UZ_taBDDASelectList(0, 999, "", False, "", oVar.TABillNo)
      If otaBDDAs.Count > 0 Then
        Dim oTblhtaBDDA As Table = New Table
        oTblhtaBDDA.Width = 1000
        oTblhtaBDDA.Style.Add("margin-top", "15px")
        oTblhtaBDDA.Style.Add("margin-left", "10px")
        oTblhtaBDDA.Style.Add("margin-right", "10px")
        Dim oRowhtaBDDA As TableRow = New TableRow
        Dim oColhtaBDDA As TableCell = New TableCell
        oColhtaBDDA.Font.Bold = True
        oColhtaBDDA.Font.Underline = True
        oColhtaBDDA.Font.Size = 10
        oColhtaBDDA.CssClass = "grpHD"
        oColhtaBDDA.Text = "Daily Allowance"
        oRowhtaBDDA.Cells.Add(oColhtaBDDA)
        oTblhtaBDDA.Rows.Add(oRowhtaBDDA)
        pnl1.Controls.Add(oTblhtaBDDA)
        oTbltaBDDA = New Table
        oTbltaBDDA.Width = 1000
        oTbltaBDDA.GridLines = GridLines.Both
        oTbltaBDDA.Style.Add("margin-left", "10px")
        oTbltaBDDA.Style.Add("margin-right", "10px")
        oRowtaBDDA = New TableRow
        oColtaBDDA = New TableCell
        oColtaBDDA.Text = "S.N."
        oColtaBDDA.Width = 40
        oColtaBDDA.Font.Bold = True
        oColtaBDDA.CssClass = "colHD"
        oColtaBDDA.Style.Add("text-align", "center")
        oRowtaBDDA.Cells.Add(oColtaBDDA)
        oColtaBDDA = New TableCell
        oColtaBDDA.Text = "Description"
        oColtaBDDA.Font.Bold = True
        oColtaBDDA.CssClass = "colHD"
        oColtaBDDA.Width = 400
        oColtaBDDA.Style.Add("text-align", "left")
        oRowtaBDDA.Cells.Add(oColtaBDDA)
        If oVar.TravelTypeID <> TATravelTypeValues.Domestic AndAlso oVar.TravelTypeID <> TATravelTypeValues.HomeVisit Then
          oColtaBDDA = New TableCell
          oColtaBDDA.Text = "Currency"
          oColtaBDDA.Font.Bold = True
          oColtaBDDA.CssClass = "colHD"
          oColtaBDDA.Width = 60
          oColtaBDDA.Style.Add("text-align", "center")
          oRowtaBDDA.Cells.Add(oColtaBDDA)
        End If
        oColtaBDDA = New TableCell
        oColtaBDDA.Text = "Claimed Amount"
        oColtaBDDA.Font.Bold = True
        oColtaBDDA.CssClass = "colHD"
        oColtaBDDA.Width = 100
        oColtaBDDA.Style.Add("text-align", "right")
        oRowtaBDDA.Cells.Add(oColtaBDDA)
        oColtaBDDA = New TableCell
        oColtaBDDA.Text = "Passed Amount"
        oColtaBDDA.Font.Bold = True
        oColtaBDDA.CssClass = "colHD"
        oColtaBDDA.Width = 100
        oColtaBDDA.Style.Add("text-align", "right")
        oRowtaBDDA.Cells.Add(oColtaBDDA)
        oColtaBDDA = New TableCell
        oColtaBDDA.Text = "Remarks"
        oColtaBDDA.Font.Bold = True
        oColtaBDDA.CssClass = "colHD"
        oColtaBDDA.Style.Add("text-align", "left")
        oRowtaBDDA.Cells.Add(oColtaBDDA)
        oTbltaBDDA.Rows.Add(oRowtaBDDA)
        sn = 0
        ClaimTot = 0
        PassTot = 0
        For Each otaBDDA As SIS.TA.taBDDA In otaBDDAs
          sn += 1
          oRowtaBDDA = New TableRow
          oColtaBDDA = New TableCell
          oColtaBDDA.CssClass = "rowHD"
          oColtaBDDA.Text = sn 'otaBDDA.SerialNo
          oColtaBDDA.Style.Add("text-align", "center")
          oRowtaBDDA.Cells.Add(oColtaBDDA)
          oColtaBDDA = New TableCell
          oColtaBDDA.CssClass = "rowHD"
          oColtaBDDA.Text = otaBDDA.SystemText
          oColtaBDDA.Style.Add("text-align", "left")
          oRowtaBDDA.Cells.Add(oColtaBDDA)
          If oVar.TravelTypeID <> TATravelTypeValues.Domestic AndAlso oVar.TravelTypeID <> TATravelTypeValues.HomeVisit Then
            oColtaBDDA = New TableCell
            oColtaBDDA.CssClass = "rowHD"
            oColtaBDDA.Text = otaBDDA.CurrencyID
            oColtaBDDA.Style.Add("text-align", "center")
            oRowtaBDDA.Cells.Add(oColtaBDDA)
          End If
          oColtaBDDA = New TableCell
          oColtaBDDA.CssClass = "rowHD"
          oColtaBDDA.Text = otaBDDA.AmountTotal
          oColtaBDDA.Style.Add("text-align", "right")
          If otaBDDA.OOEBySystem Then
            oColtaBDDA.ForeColor = Drawing.Color.Red
          End If
          oRowtaBDDA.Cells.Add(oColtaBDDA)
          oColtaBDDA = New TableCell
          oColtaBDDA.CssClass = "rowHD"
          oColtaBDDA.Text = otaBDDA.PassedAmountTotal
          oColtaBDDA.Style.Add("text-align", "right")
          oRowtaBDDA.Cells.Add(oColtaBDDA)
          oColtaBDDA = New TableCell
          oColtaBDDA.CssClass = "rowHD"
          Dim remTbl As New Table
          Dim remrow As New TableRow
          Dim remaRow As New TableRow
          Dim remcol As New TableCell
          remTbl.BorderStyle = BorderStyle.None
          remcol.Text = otaBDDA.Remarks
          remrow.Cells.Add(remcol)
          remTbl.Rows.Add(remrow)
          remrow = New TableRow
          remcol = New TableCell
          remcol.Text = otaBDDA.AccountsRemarks
          remcol.ForeColor = Drawing.Color.Red
          remrow.Cells.Add(remcol)
          remTbl.Rows.Add(remrow)
          oColtaBDDA.Controls.Add(remTbl)
          oColtaBDDA.Style.Add("text-align", "left")
          oRowtaBDDA.Cells.Add(oColtaBDDA)
          oTbltaBDDA.Rows.Add(oRowtaBDDA)
          ClaimTot += otaBDDA.AmountTotal
          PassTot += otaBDDA.PassedAmountTotal
        Next
        If sn > 1 Then
          oRow = New TableRow
          oCol = New TableCell
          With oCol
            If oVar.TravelTypeID <> TATravelTypeValues.Domestic AndAlso oVar.TravelTypeID <> TATravelTypeValues.HomeVisit Then
              .ColumnSpan = 3
            Else
              .ColumnSpan = 2
            End If
            .Text = "TOTAL"
            .Style.Add("text-align", "right")
          End With
          oRow.Cells.Add(oCol)
          oCol = New TableCell
          With oCol
            .Text = ClaimTot.ToString("n")
            .Style.Add("text-align", "right")
          End With
          oRow.Cells.Add(oCol)
          oCol = New TableCell
          With oCol
            .Text = PassTot.ToString("n")
            .Style.Add("text-align", "right")
          End With
          oRow.Cells.Add(oCol)
          oCol = New TableCell
          oRow.Cells.Add(oCol)
          oTbltaBDDA.Rows.Add(oRow)
        End If
        pnl1.Controls.Add(oTbltaBDDA)
      End If

      'Accounts
      Dim oTbltaCDAccounts As Table = Nothing
      Dim oRowtaCDAccounts As TableRow = Nothing
      Dim oColtaCDAccounts As TableCell = Nothing
      Dim otaCDAccountss As List(Of SIS.TA.taCDAccounts) = SIS.TA.taCDAccounts.UZ_taCDAccountsSelectList(0, 999, "", False, "", oVar.TABillNo)
      If otaCDAccountss.Count > 0 Then
        Dim oTblhtaCDAccounts As Table = New Table
        oTblhtaCDAccounts.Width = 1000
        oTblhtaCDAccounts.Style.Add("margin-top", "15px")
        oTblhtaCDAccounts.Style.Add("margin-left", "10px")
        oTblhtaCDAccounts.Style.Add("margin-right", "10px")
        Dim oRowhtaCDAccounts As TableRow = New TableRow
        Dim oColhtaCDAccounts As TableCell = New TableCell
        oColhtaCDAccounts.Font.Bold = True
        oColhtaCDAccounts.Font.Underline = True
        oColhtaCDAccounts.Font.Size = 10
        oColhtaCDAccounts.CssClass = "grpHD"
        oColhtaCDAccounts.Text = "Debit / Credit by Accounts"
        oRowhtaCDAccounts.Cells.Add(oColhtaCDAccounts)
        oTblhtaCDAccounts.Rows.Add(oRowhtaCDAccounts)
        pnl1.Controls.Add(oTblhtaCDAccounts)
        oTbltaCDAccounts = New Table
        oTbltaCDAccounts.Width = 1000
        oTbltaCDAccounts.GridLines = GridLines.Both
        oTbltaCDAccounts.Style.Add("margin-left", "10px")
        oTbltaCDAccounts.Style.Add("margin-right", "10px")
        oRowtaCDAccounts = New TableRow
        oColtaCDAccounts = New TableCell
        oColtaCDAccounts.Text = "S.N."
        oColtaCDAccounts.Width = 40
        oColtaCDAccounts.Font.Bold = True
        oColtaCDAccounts.CssClass = "colHD"
        oColtaCDAccounts.Style.Add("text-align", "center")
        oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
        oColtaCDAccounts = New TableCell
        oColtaCDAccounts.Text = "Description"
        oColtaCDAccounts.Font.Bold = True
        oColtaCDAccounts.CssClass = "colHD"
        oColtaCDAccounts.Width = 400
        oColtaCDAccounts.Style.Add("text-align", "left")
        oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
        If oVar.TravelTypeID <> TATravelTypeValues.Domestic AndAlso oVar.TravelTypeID <> TATravelTypeValues.HomeVisit Then
          oColtaCDAccounts = New TableCell
          oColtaCDAccounts.Text = "Currency"
          oColtaCDAccounts.Font.Bold = True
          oColtaCDAccounts.CssClass = "colHD"
          oColtaCDAccounts.Width = 60
          oColtaCDAccounts.Style.Add("text-align", "center")
          oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
        End If
        oColtaCDAccounts = New TableCell
        oColtaCDAccounts.Text = "Debit Amount"
        oColtaCDAccounts.Font.Bold = True
        oColtaCDAccounts.CssClass = "colHD"
        oColtaCDAccounts.Width = 100
        oColtaCDAccounts.Style.Add("text-align", "right")
        oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
        oColtaCDAccounts = New TableCell
        oColtaCDAccounts.Text = "Credit Amount"
        oColtaCDAccounts.Font.Bold = True
        oColtaCDAccounts.CssClass = "colHD"
        oColtaCDAccounts.Width = 100
        oColtaCDAccounts.Style.Add("text-align", "right")
        oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
        oColtaCDAccounts = New TableCell
        oColtaCDAccounts.Text = "Remarks"
        oColtaCDAccounts.Font.Bold = True
        oColtaCDAccounts.CssClass = "colHD"
        oColtaCDAccounts.Style.Add("text-align", "left")
        oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
        oTbltaCDAccounts.Rows.Add(oRowtaCDAccounts)
        sn = 0
        ClaimTot = 0
        PassTot = 0
        For Each otaCDAccounts As SIS.TA.taCDAccounts In otaCDAccountss
          sn += 1
          oRowtaCDAccounts = New TableRow
          oColtaCDAccounts = New TableCell
          oColtaCDAccounts.CssClass = "rowHD"
          oColtaCDAccounts.Text = sn
          oColtaCDAccounts.Style.Add("text-align", "center")
          oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
          oColtaCDAccounts = New TableCell
          oColtaCDAccounts.CssClass = "rowHD"
          oColtaCDAccounts.Text = otaCDAccounts.Remarks
          oColtaCDAccounts.Style.Add("text-align", "left")
          oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
          If oVar.TravelTypeID <> TATravelTypeValues.Domestic AndAlso oVar.TravelTypeID <> TATravelTypeValues.HomeVisit Then
            Dim cur As String = ""
            With otaCDAccounts
              Select Case .CurrencyID
                Case "INR", "USD", "EURO"
                  cur = .CurrencyID
                Case Else
                  cur = .CurrencyMain
              End Select
            End With
            oColtaCDAccounts = New TableCell
            oColtaCDAccounts.CssClass = "rowHD"
            oColtaCDAccounts.Text = cur
            oColtaCDAccounts.Style.Add("text-align", "center")
            oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
          End If
          oColtaCDAccounts = New TableCell
          oColtaCDAccounts.CssClass = "rowHD"
          oColtaCDAccounts.Text = IIf(otaCDAccounts.AmountTotal < 0, otaCDAccounts.AmountTotal, "")
          oColtaCDAccounts.Style.Add("text-align", "right")
          oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
          oColtaCDAccounts = New TableCell
          oColtaCDAccounts.CssClass = "rowHD"
          oColtaCDAccounts.Text = IIf(otaCDAccounts.AmountTotal > 0, otaCDAccounts.AmountTotal, "")
          oColtaCDAccounts.Style.Add("text-align", "right")
          oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
          oColtaCDAccounts = New TableCell
          oColtaCDAccounts.CssClass = "rowHD"
          Dim remTbl As New Table
          Dim remrow As New TableRow
          Dim remaRow As New TableRow
          Dim remcol As New TableCell
          remTbl.BorderStyle = BorderStyle.None
          remcol.Text = ""
          remrow.Cells.Add(remcol)
          remTbl.Rows.Add(remrow)
          remrow = New TableRow
          remcol = New TableCell
          remcol.Text = ""
          remcol.ForeColor = Drawing.Color.Red
          remrow.Cells.Add(remcol)
          remTbl.Rows.Add(remrow)
          oColtaCDAccounts.Controls.Add(remTbl)
          oColtaCDAccounts.Style.Add("text-align", "left")
          oRowtaCDAccounts.Cells.Add(oColtaCDAccounts)
          oTbltaCDAccounts.Rows.Add(oRowtaCDAccounts)
          ClaimTot += otaCDAccounts.AmountTotal
          PassTot += otaCDAccounts.PassedAmountTotal
        Next
        If sn > 1 Then
          oRow = New TableRow
          oCol = New TableCell
          With oCol
            If oVar.TravelTypeID <> TATravelTypeValues.Domestic AndAlso oVar.TravelTypeID <> TATravelTypeValues.HomeVisit Then
              .ColumnSpan = 3
            Else
              .ColumnSpan = 2
            End If
            .Text = "TOTAL"
            .Style.Add("text-align", "right")
          End With
          oRow.Cells.Add(oCol)
          oCol = New TableCell
          With oCol
            .Text = ClaimTot.ToString("n")
            .Style.Add("text-align", "right")
          End With
          oRow.Cells.Add(oCol)
          oCol = New TableCell
          With oCol
            .Text = PassTot.ToString("n")
            .Style.Add("text-align", "right")
          End With
          oRow.Cells.Add(oCol)
          oCol = New TableCell
          oRow.Cells.Add(oCol)
          oTbltaCDAccounts.Rows.Add(oRow)
        End If
        pnl1.Controls.Add(oTbltaCDAccounts)
      End If
      '========End Accounts============
      Dim oTbltaBillPrjAmounts As Table = Nothing
      Dim oRowtaBillPrjAmounts As TableRow = Nothing
      Dim oColtaBillPrjAmounts As TableCell = Nothing
      Dim otaBillPrjAmountss As List(Of SIS.TA.taBillPrjAmounts) = SIS.TA.taBillPrjAmounts.UZ_taBillPrjAmountsSelectList(0, 999, "", False, "", oVar.TABillNo)
      If otaBillPrjAmountss.Count > 0 Then
        Dim oTblhtaBillPrjAmounts As Table = New Table
        oTblhtaBillPrjAmounts.Width = 1000
        oTblhtaBillPrjAmounts.Style.Add("margin-top", "15px")
        oTblhtaBillPrjAmounts.Style.Add("margin-left", "10px")
        oTblhtaBillPrjAmounts.Style.Add("margin-right", "10px")
        Dim oRowhtaBillPrjAmounts As TableRow = New TableRow
        Dim oColhtaBillPrjAmounts As TableCell = New TableCell
        oColhtaBillPrjAmounts.Font.Bold = True
        oColhtaBillPrjAmounts.Font.Underline = True
        oColhtaBillPrjAmounts.Font.Size = 10
        oColhtaBillPrjAmounts.CssClass = "grpHD"
        oColhtaBillPrjAmounts.Text = "Bill Project wise total"
        oRowhtaBillPrjAmounts.Cells.Add(oColhtaBillPrjAmounts)
        oTblhtaBillPrjAmounts.Rows.Add(oRowhtaBillPrjAmounts)
        pnl1.Controls.Add(oTblhtaBillPrjAmounts)
        oTbltaBillPrjAmounts = New Table
        oTbltaBillPrjAmounts.Width = 1000
        oTbltaBillPrjAmounts.GridLines = GridLines.Both
        oTbltaBillPrjAmounts.Style.Add("margin-left", "10px")
        oTbltaBillPrjAmounts.Style.Add("margin-right", "10px")
        oRowtaBillPrjAmounts = New TableRow
        oColtaBillPrjAmounts = New TableCell
        oColtaBillPrjAmounts.Text = "Project ID"
        oColtaBillPrjAmounts.Font.Bold = True
        oColtaBillPrjAmounts.CssClass = "colHD"
        oColtaBillPrjAmounts.Style.Add("text-align", "left")
        oRowtaBillPrjAmounts.Cells.Add(oColtaBillPrjAmounts)
        oColtaBillPrjAmounts = New TableCell
        oColtaBillPrjAmounts.Text = "Project Description"
        oColtaBillPrjAmounts.Font.Bold = True
        oColtaBillPrjAmounts.CssClass = "colHD"
        oColtaBillPrjAmounts.Style.Add("text-align", "left")
        oRowtaBillPrjAmounts.Cells.Add(oColtaBillPrjAmounts)
        oColtaBillPrjAmounts = New TableCell
        oColtaBillPrjAmounts.Text = "Percentage"
        oColtaBillPrjAmounts.Font.Bold = True
        oColtaBillPrjAmounts.CssClass = "colHD"
        oColtaBillPrjAmounts.Style.Add("text-align", "right")
        oRowtaBillPrjAmounts.Cells.Add(oColtaBillPrjAmounts)
        oColtaBillPrjAmounts = New TableCell
        oColtaBillPrjAmounts.Text = "Total Amount [INR]"
        oColtaBillPrjAmounts.Font.Bold = True
        oColtaBillPrjAmounts.CssClass = "colHD"
        oColtaBillPrjAmounts.Style.Add("text-align", "right")
        oRowtaBillPrjAmounts.Cells.Add(oColtaBillPrjAmounts)
        oTbltaBillPrjAmounts.Rows.Add(oRowtaBillPrjAmounts)
        For Each otaBillPrjAmounts As SIS.TA.taBillPrjAmounts In otaBillPrjAmountss
          oRowtaBillPrjAmounts = New TableRow
          oColtaBillPrjAmounts = New TableCell
          oColtaBillPrjAmounts.Text = otaBillPrjAmounts.ProjectID
          oColtaBillPrjAmounts.CssClass = "rowHD"
          oColtaBillPrjAmounts.Style.Add("text-align", "left")
          oRowtaBillPrjAmounts.Cells.Add(oColtaBillPrjAmounts)
          oColtaBillPrjAmounts = New TableCell
          oColtaBillPrjAmounts.Text = otaBillPrjAmounts.IDM_Projects1_Description
          oColtaBillPrjAmounts.CssClass = "rowHD"
          oColtaBillPrjAmounts.Style.Add("text-align", "left")
          oRowtaBillPrjAmounts.Cells.Add(oColtaBillPrjAmounts)
          oColtaBillPrjAmounts = New TableCell
          oColtaBillPrjAmounts.CssClass = "rowHD"
          oColtaBillPrjAmounts.Text = otaBillPrjAmounts.Percentage
          oColtaBillPrjAmounts.Style.Add("text-align", "right")
          oRowtaBillPrjAmounts.Cells.Add(oColtaBillPrjAmounts)
          oColtaBillPrjAmounts = New TableCell
          oColtaBillPrjAmounts.CssClass = "rowHD"
          oColtaBillPrjAmounts.Text = otaBillPrjAmounts.TotalAmountinINR
          oColtaBillPrjAmounts.Style.Add("text-align", "right")
          oRowtaBillPrjAmounts.Cells.Add(oColtaBillPrjAmounts)
          oTbltaBillPrjAmounts.Rows.Add(oRowtaBillPrjAmounts)
        Next
        pnl1.Controls.Add(oTbltaBillPrjAmounts)
      End If
      Dim oTbltaBillAmount As Table = Nothing
      Dim oRowtaBillAmount As TableRow = Nothing
      Dim oColtaBillAmount As TableCell = Nothing
      Dim otaBillAmounts As List(Of SIS.TA.taBillAmount) = SIS.TA.taBillAmount.UZ_taBillAmountSelectList(0, 999, "", False, "", oVar.TABillNo)
      If otaBillAmounts.Count > 0 Then
        Dim oTblhtaBillAmount As Table = New Table
        oTblhtaBillAmount.Width = 1000
        oTblhtaBillAmount.Style.Add("margin-top", "15px")
        oTblhtaBillAmount.Style.Add("margin-left", "10px")
        oTblhtaBillAmount.Style.Add("margin-right", "10px")
        Dim oRowhtaBillAmount As TableRow = New TableRow
        Dim oColhtaBillAmount As TableCell = New TableCell
        oColhtaBillAmount.Font.Bold = True
        oColhtaBillAmount.Font.Underline = True
        oColhtaBillAmount.Font.Size = 10
        oColhtaBillAmount.CssClass = "grpHD"
        oColhtaBillAmount.Text = "Bill Amounts"
        oRowhtaBillAmount.Cells.Add(oColhtaBillAmount)
        oTblhtaBillAmount.Rows.Add(oRowhtaBillAmount)
        pnl1.Controls.Add(oTblhtaBillAmount)
        oTbltaBillAmount = New Table
        oTbltaBillAmount.Width = 1000
        oTbltaBillAmount.GridLines = GridLines.Both
        oTbltaBillAmount.Style.Add("margin-left", "10px")
        oTbltaBillAmount.Style.Add("margin-right", "10px")
        oRowtaBillAmount = New TableRow
        oColtaBillAmount = New TableCell
        oColtaBillAmount.Text = "COMPONENT"
        oColtaBillAmount.Font.Bold = True
        oColtaBillAmount.CssClass = "colHD"
        oColtaBillAmount.Style.Add("text-align", "left")
        oRowtaBillAmount.Cells.Add(oColtaBillAmount)
        oColtaBillAmount = New TableCell
        oColtaBillAmount.Text = "CURRENCY"
        oColtaBillAmount.Font.Bold = True
        oColtaBillAmount.CssClass = "colHD"
        oColtaBillAmount.Style.Add("text-align", "center")
        oRowtaBillAmount.Cells.Add(oColtaBillAmount)
        oColtaBillAmount = New TableCell
        oColtaBillAmount.Text = "COST CENTER"
        oColtaBillAmount.Font.Bold = True
        oColtaBillAmount.CssClass = "colHD"
        oColtaBillAmount.Style.Add("text-align", "left")
        oRowtaBillAmount.Cells.Add(oColtaBillAmount)
        oColtaBillAmount = New TableCell
        oColtaBillAmount.Text = "TOTAL"
        oColtaBillAmount.Font.Bold = True
        oColtaBillAmount.CssClass = "colHD"
        oColtaBillAmount.Style.Add("text-align", "right")
        oRowtaBillAmount.Cells.Add(oColtaBillAmount)
        oColtaBillAmount = New TableCell
        oColtaBillAmount.Text = "Avg. C.F. INR"
        oColtaBillAmount.Font.Bold = True
        oColtaBillAmount.CssClass = "colHD"
        oColtaBillAmount.Style.Add("text-align", "center")
        oRowtaBillAmount.Cells.Add(oColtaBillAmount)
        oColtaBillAmount = New TableCell
        oColtaBillAmount.Text = "TOTAL [INR]"
        oColtaBillAmount.Font.Bold = True
        oColtaBillAmount.CssClass = "colHD"
        oColtaBillAmount.Style.Add("text-align", "right")
        oRowtaBillAmount.Cells.Add(oColtaBillAmount)
        oTbltaBillAmount.Rows.Add(oRowtaBillAmount)
        Dim gTot As Decimal = 0
        For Each otaBillAmount As SIS.TA.taBillAmount In otaBillAmounts
          Dim cur As String = ""
          With otaBillAmount
            Select Case .CurrencyID
              Case "INR", "USD", "EURO"
                cur = .CurrencyID
              Case Else
                cur = oVar.BillCurrencyID
            End Select
          End With
          If otaBillAmount.ComponentID = TAComponentTypes.Total Then
            gTot += otaBillAmount.TotalInINR
          End If
          oRowtaBillAmount = New TableRow
          oColtaBillAmount = New TableCell
          oColtaBillAmount.Text = otaBillAmount.TA_Components4_Description
          oColtaBillAmount.CssClass = "rowHD"
          oColtaBillAmount.Style.Add("text-align", "left")
          oRowtaBillAmount.Cells.Add(oColtaBillAmount)
          oColtaBillAmount = New TableCell
          oColtaBillAmount.Text = cur   'otaBillAmount.TA_Currencies5_CurrencyName
          oColtaBillAmount.CssClass = "rowHD"
          oColtaBillAmount.Style.Add("text-align", "center")
          oRowtaBillAmount.Cells.Add(oColtaBillAmount)
          oColtaBillAmount = New TableCell
          oColtaBillAmount.Text = otaBillAmount.HRM_Departments1_Description
          oColtaBillAmount.CssClass = "rowHD"
          oColtaBillAmount.Style.Add("text-align", "left")
          oRowtaBillAmount.Cells.Add(oColtaBillAmount)
          oColtaBillAmount = New TableCell
          oColtaBillAmount.CssClass = "rowHD"
          oColtaBillAmount.Text = otaBillAmount.TotalInCurrency
          oColtaBillAmount.Style.Add("text-align", "right")
          oRowtaBillAmount.Cells.Add(oColtaBillAmount)
          oColtaBillAmount = New TableCell
          oColtaBillAmount.CssClass = "rowHD"
          Try
            oColtaBillAmount.Text = (otaBillAmount.TotalInINR / otaBillAmount.TotalInCurrency).ToString("n")
          Catch ex As Exception
            oColtaBillAmount.Text = "1.00"
          End Try
          oColtaBillAmount.Style.Add("text-align", "center")
          oRowtaBillAmount.Cells.Add(oColtaBillAmount)
          oColtaBillAmount = New TableCell
          oColtaBillAmount.CssClass = "rowHD"
          oColtaBillAmount.Text = otaBillAmount.TotalInINR
          oColtaBillAmount.Style.Add("text-align", "right")
          oRowtaBillAmount.Cells.Add(oColtaBillAmount)
          oTbltaBillAmount.Rows.Add(oRowtaBillAmount)
        Next
        oRowtaBillAmount = New TableRow
        oColtaBillAmount = New TableCell
        oColtaBillAmount.Text = "GRAND TOTAL IN INR"
        oColtaBillAmount.Font.Bold = True
        oColtaBillAmount.CssClass = "colHD"
        oColtaBillAmount.Style.Add("text-align", "center")
        oColtaBillAmount.ColumnSpan = 5
        oRowtaBillAmount.Cells.Add(oColtaBillAmount)
        oColtaBillAmount = New TableCell
        oColtaBillAmount.Text = gTot
        oColtaBillAmount.Font.Bold = True
        oColtaBillAmount.CssClass = "colHD"
        oColtaBillAmount.Style.Add("text-align", "right")
        oRowtaBillAmount.Cells.Add(oColtaBillAmount)
        oTbltaBillAmount.Rows.Add(oRowtaBillAmount)

        pnl1.Controls.Add(oTbltaBillAmount)
      End If
      'Brief Tour Report
      Dim oTblbtr As Table = Nothing
      Dim oRowbtr As TableRow = Nothing
      Dim oColbtr As TableCell = Nothing
      Dim oTblhbtr As Table = New Table
      oTblhbtr.Width = 1000
      oTblhbtr.Style.Add("margin-top", "15px")
      oTblhbtr.Style.Add("margin-left", "10px")
      oTblhbtr.Style.Add("margin-right", "10px")
      Dim oRowhbtr As TableRow = New TableRow
      Dim oColhbtr As TableCell = New TableCell
      oColhbtr.Font.Bold = True
      oColhbtr.Font.Underline = True
      oColhbtr.Font.Size = 10
      oColhbtr.CssClass = "grpHD"
      oColhbtr.Text = "Brief Tour Report"
      oRowhbtr.Cells.Add(oColhbtr)
      oTblhbtr.Rows.Add(oRowhbtr)
      pnl1.Controls.Add(oTblhbtr)
      oTblbtr = New Table
      oTblbtr.Width = 1000
      oTblbtr.GridLines = GridLines.Both
      oTblbtr.Style.Add("margin-left", "10px")
      oTblbtr.Style.Add("margin-right", "10px")
      oRowbtr = New TableRow
      oColbtr = New TableCell
      oColbtr.Text = oVar.BriefTourReport
      oColbtr.CssClass = "rowHD"
      oColbtr.Style.Add("text-align", "left")
      oRowbtr.Cells.Add(oColbtr)
      oTblbtr.Rows.Add(oRowbtr)
      pnl1.Controls.Add(oTblbtr)
      '=================
      oTbl = New Table
      oTbl.Width = 1000
      oTbl.GridLines = GridLines.None
      oTbl.BorderStyle = BorderStyle.None
      oTbl.Style.Add("margin-top", "15px")
      oTbl.Style.Add("margin-left", "10px")

      oRow = New TableRow
      oCol = New TableCell
      oCol.HorizontalAlign = HorizontalAlign.Right
      oCol.Text = "&nbsp;"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
      oRow = New TableRow
      oCol = New TableCell
      oCol.HorizontalAlign = HorizontalAlign.Right
      oCol.Text = "&nbsp;"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)


      oRow = New TableRow
      oCol = New TableCell
      oCol.HorizontalAlign = HorizontalAlign.Right
      oCol.Text = "&nbsp;"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
      oRow = New TableRow
      oCol = New TableCell
      oCol.CssClass = "alignright"
      oCol.Text = "Signature"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)

      oRow = New TableRow
      oCol = New TableCell
      oCol.CssClass = "alignright"
      oCol.Text = "(" & oVar.FK_TA_Bills_EmployeeID.EmployeeName & ")"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)

      pnl1.Controls.Add(oTbl)
      '=================
      oTbl = New Table
      oTbl.Width = 1000
      oTbl.GridLines = GridLines.None
      oTbl.BorderStyle = BorderStyle.None
      oTbl.Style.Add("margin-top", "15px")
      oTbl.Style.Add("margin-left", "10px")
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = "=>THIS CARRIES ELECTRONIC APPROVAL OF TRAVEL EXPENSE BY REQUISITE AUTHORITY."
      oCol.Font.Bold = True
      oCol.Font.Italic = True
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
      pnl1.Controls.Add(oTbl)


      Return pnl1
    End Function

#End Region

  End Class

End Namespace
