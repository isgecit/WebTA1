Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.Mail
Imports System.Net.Mail
Namespace SIS.TA
  Partial Public Class taCH
    'http://192.9.200.146/Attachment/Notes.aspx?handle=J_PREORDER_WORKFLOW&Index=119&user=0330&Em=hariharan.m@isgec.co.in&Hd=Specification for Inlet Gas&Tl=Specification for Inlet Gas
    Public ReadOnly Property GetHoldNotesLink() As String
      Get
        Dim mRet As String = HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority
        If HttpContext.Current.Request.Url.Authority.ToLower = "localhost" Then
          mRet = "http://192.9.200.146"
        End If
        mRet &= "/Attachment/Notes.aspx?handle=J_TABILL"
        Dim Index As String = TABillNo
        Dim User As String = HttpContext.Current.Session("LoginID")
        Dim EMailID As String = FK_TA_Bills_EmployeeID.EMailID
        Dim HD As String = "TA Bill is on HOLD by Accounts"
        Dim Tl As String = "TA Bill No-" & TABillNo & " Emp- " & FK_TA_Bills_EmployeeID.EmployeeName & " is on HOLD"
        Dim canEdit As String = "n"
        If Editable Then
          canEdit = "y"
        End If
        Return mRet & "&Index=" & Index & "&user=" & User & "&ed=" & canEdit & "&em=" & EMailID & "&HD=" & HD & "&Tl=" & Tl
      End Get
    End Property
    Public Shadows ReadOnly Property GetNotesLink() As String
      Get
        Dim mRet As String = HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority
        If HttpContext.Current.Request.Url.Authority.ToLower = "localhost" Then
          mRet = "http://192.9.200.146"
        End If
        mRet &= "/Attachment/Notes.aspx?handle=J_TABILL"
        Dim Index As String = TABillNo
        Dim User As String = HttpContext.Current.Session("LoginID")
        Dim canEdit As String = "y"
        Return mRet & "&Index=" & Index & "&user=" & User & "&ed=" & canEdit
      End Get
    End Property

    Public ReadOnly Property PostPnlVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case BillStatusID
            Case TAStates.UnderVCHPosting
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property PostWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case BillStatusID
            Case TAStates.BillVerified
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function PostWF(ByVal TABillNo As Int32) As SIS.TA.taCH
      Dim Results As SIS.TA.taCH = taCHGetByID(TABillNo)
      With Results
        .BillStatusID = TAStates.UnderVCHPosting
      End With
      SIS.TA.taCH.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function CancelPost(ByVal TABillNo As Int32) As SIS.TA.taCH
      Dim Results As SIS.TA.taCH = taCHGetByID(TABillNo)
      With Results
        .BillStatusID = TAStates.BillVerified
      End With
      SIS.TA.taCH.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function SavePost(ByVal TABillNo As Int32, ByVal VCHOn As String) As SIS.TA.taCH
      Dim vchR As SIS.TA.taPostVoucherResult = SIS.TA.taVoucher.PostVoucher(TABillNo, VCHOn)
      If vchR.IsError Then
        Throw New Exception(vchR.Message)
      Else
        Dim Results As SIS.TA.taCH = taCHGetByID(TABillNo)
        With Results
          .BillStatusID = TAStates.VCHPosted
          .VCHBatch = vchR.BatchNo
          .VCHDocument = vchR.DocumentNo
          .VCHLine = vchR.LineNo
          .VCHOn = VCHOn.Split(",".ToCharArray)(0)
          .VCHBy = HttpContext.Current.Session("LoginID")
          'Update Manual Fields
          .PostedBy = HttpContext.Current.Session("joginID")
          .PostedOn = .VCHOn
          .ERPBatchNo = vchR.VoucherType & "," & vchR.VoucherCompany
          .ERPDocumentNo = vchR.DocumentNo
        End With
        SIS.TA.taCH.UpdateData(Results)
        Return Results
      End If
      Return Nothing
    End Function

    Public Shadows ReadOnly Property Editable As Boolean
      Get
        Return EditableByAccounts
      End Get
    End Property
    Public ReadOnly Property HoldWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case BillStatusID
            Case TAStates.UnderProcessByAccounts
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ReminderVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case BillStatusID
            Case TAStates.ReturnedByAccounts
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property HoldWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function HoldWF(ByVal TABillNo As Int32) As SIS.TA.taCH
      Dim Results As SIS.TA.taCH = taCHGetByID(TABillNo)
      With Results
        .VerifiedBy = HttpContext.Current.Session("LoginID")
        .VerifiedOn = Now
        .VerificationRemarks = "Hold By Accounts"
        .BillStatusID = TAStates.UnderHoldByAccounts
      End With
      SIS.TA.taCH.UpdateData(Results)
      Return Results
    End Function
    Public ReadOnly Property UnlockWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case BillStatusID
            Case TAStates.UnderHoldByAccounts
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property UnlockWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function UnlockWF(ByVal TABillNo As Int32) As SIS.TA.taCH
      Dim Results As SIS.TA.taCH = taCHGetByID(TABillNo)
      With Results
        .VerifiedBy = HttpContext.Current.Session("LoginID")
        .VerifiedOn = Now
        .VerificationRemarks = "Unlocked For Processing"
        .BillStatusID = TAStates.UnderProcessByAccounts
      End With
      SIS.TA.taCH.UpdateData(Results)
      Return Results
    End Function
    'GST Voucher
    Public Property VoucherType As String = ""
    Public Property VoucherNo As String = ""
    Public Property VoucherCompany As String = ""
    Public ReadOnly Property UpdateEntryVisible As Boolean
      Get
        Dim mRet As Boolean = False
        If BillStatusID = TAStates.UnderVoucherUpdation Then
          mRet = True
        End If
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Select Case BillStatusID
          Case TAStates.BillVerified, TAStates.VoucherUpdated
            mRet = True
        End Select
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          mRet = True
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Shadows Function InitiateWF(ByVal TABillNo As Int32) As SIS.TA.taCH
      Dim Results As SIS.TA.taCH = taCHGetByID(TABillNo)
      With Results
        .BillStatusID = TAStates.UnderVoucherUpdation
      End With
      SIS.TA.taCH.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function SaveWF(ByVal TABillNo As Int32, ByVal value As String) As SIS.TA.taCH
      Dim Results As SIS.TA.taCH = taCHGetByID(TABillNo)
      Dim aVal() As String = value.Split("|".ToCharArray)
      With Results
        .BillStatusID = TAStates.VoucherUpdated
        .PostedBy = Web.HttpContext.Current.User.Identity.Name
        .PostedOn = Now
        .ERPBatchNo = aVal(0) & "," & aVal(2)
        .ERPDocumentNo = aVal(1)
      End With
      SIS.TA.taCH.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function CancelWF(ByVal TABillNo As Int32) As SIS.TA.taCH
      Dim Results As SIS.TA.taCH = taCHGetByID(TABillNo)
      With Results
        .BillStatusID = TAStates.BillVerified
      End With
      SIS.TA.taCH.UpdateData(Results)
      Return Results
    End Function
    Public ReadOnly Property LockWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        If BillStatusID = TAStates.VoucherUpdated OrElse BillStatusID = TAStates.VCHPosted Then
          mRet = True
        End If
        Return mRet
      End Get
    End Property
    Public Shared Function LockWF(ByVal TABillNo As Int32) As SIS.TA.taCH
      Dim Record As SIS.TA.taCH = taCHGetByID(TABillNo)
      With Record
        .BillStatusID = TAStates.GSTLocked
        .PostedBy = HttpContext.Current.User.Identity.Name
        .PostedOn = Now
      End With
      ''Update In ERP
      Dim oLdgs As List(Of SIS.TA.taBDLodging) = SIS.TA.taBDLodging.taBDLodgingSelectList(0, 9999, "", False, "", Record.TABillNo)
      For Each Rec As SIS.TA.taBDLodging In oLdgs
        Rec = SIS.TA.taBDLodging.UpdateGSTDataInBDL(Rec)
        If Convert.ToDecimal(Rec.TotalAmount) <= 0 Then
          Continue For
        End If
        Dim ERP As New SIS.SPMT.spmtUPDInERP
        With Rec
          ERP.t_sour = "TABILL"
          ERP.t_ninv = Rec.SerialNo
          ERP.t_irdt = Rec.Date2Time
          ERP.t_type = "HTL"
          ERP.t_isup = Rec.BillNumber
          ERP.t_idat = Rec.BillDate
          ERP.t_brmk = "HOTEL Charge"
          ERP.t_brac = ""
          ERP.t_payd = Rec.TABillNo
          Try
            ERP.t_hodc = Rec.FK_TA_BillDetails_TABillNo.ApprovedByCC
          Catch ex As Exception
          End Try
          ERP.t_cprj = Rec.ProjectID
          ERP.t_cspa = ""
          ERP.t_emno = Rec.FK_TA_BillDetails_TABillNo.EmployeeID
          ERP.t_cofc = ""
          ERP.t_dimx = ""
          Try
            ERP.t_gstn_c = SIS.SPMT.spmtIsgecGSTIN.spmtIsgecGSTINGetByID(Rec.IsgecGSTIN).Description
          Catch ex As Exception
          End Try
          ERP.t_nama = Rec.ModeText
          ERP.t_gstn_b = Rec.SupplierGSTINNo
          ERP.t_ifbp = ""  'Rec.BPID
          ERP.t_code = "996311"   'Rec.HSNSACCode
          ERP.t_unit = ""  'Rec.UOM
          ERP.t_ityp = 2
          Try
            ERP.t_sste = Rec.SupplierGSTINNo.Substring(0, 2)
          Catch ex As Exception
          End Try
          ERP.t_qnty = 0
          ERP.t_assv = Rec.AssessableValue
          ERP.t_vamt = Rec.TotalGST
          ERP.t_cess = Rec.CessRate
          ERP.t_cmnt = Rec.CessAmount
          ERP.t_tgst = Rec.TotalGST
          ERP.t_tamt = Rec.TotalAmount
          ERP.t_grmk = ""
          ERP.t_ccur = "INR"
          ERP.t_conv = 1
          ERP.t_tamh = Rec.TotalAmount
          ERP.t_ptyp = Rec.PurchaseType
          ERP.t_irat = Rec.IGSTRate
          ERP.t_iamt = Rec.IGSTAmount
          ERP.t_srat = Rec.SGSTRate
          ERP.t_samt = Rec.SGSTAmount
          ERP.t_crat = Rec.CGSTRate
          ERP.t_camt = Rec.CGSTAmount
          ERP.t_ttyp = Rec.FK_TA_BillDetails_TABillNo.ERPBatchNo.Split(",".ToCharArray)(0)
          ERP.t_docn = Rec.FK_TA_BillDetails_TABillNo.ERPDocumentNo
          Try
            ERP.t_comp = Rec.FK_TA_BillDetails_TABillNo.ERPBatchNo.Split(",".ToCharArray)(1)
          Catch ex As Exception
          End Try
          ERP.t_upby = Rec.FK_TA_BillDetails_TABillNo.PostedBy
          ERP.t_updt = Rec.FK_TA_BillDetails_TABillNo.PostedOn
          ERP.t_ucod = Rec.FK_TA_BillDetails_TABillNo.EmployeeID
          ERP.t_unam = Rec.FK_TA_BillDetails_TABillNo.FK_TA_Bills_EmployeeID.EmployeeName
          ERP.t_posu = ERP.t_sste

        End With
        Dim tmp As SIS.SPMT.spmtUPDInERP = SIS.SPMT.spmtUPDInERP.spmtUPDInERPGetByID(ERP.t_sour, ERP.t_ninv)
        If tmp IsNot Nothing Then
          SIS.SPMT.spmtUPDInERP.UpdateData(ERP)
        Else
          SIS.SPMT.spmtUPDInERP.InsertData(ERP)
        End If
      Next
      'Update Bill Status
      SIS.TA.taCH.UpdateData(Record)
      Return Record
    End Function
    Public ReadOnly Property CompleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          If BillStatusID = TAStates.UnderProcessByAccounts Then
            mRet = True
          End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property CompleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function CompleteWF(ByVal TABillNo As Int32) As SIS.TA.taCH
      Dim Results As SIS.TA.taCH = taCHGetByID(TABillNo)
      With Results
        .VerifiedBy = HttpContext.Current.Session("LoginID")
        .VerifiedOn = Now
        .VerificationRemarks = "Bill Verification completed"
        .BillStatusID = TAStates.BillVerified
      End With
      SIS.TA.taCH.UpdateData(Results)
      Try
        SendPassedMail(Results)
      Catch ex As Exception
      End Try

      Return Results
    End Function
    Public ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          If BillStatusID = TAStates.UnderReceiveByAccounts Then
            mRet = True
          End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ApproveWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function ApproveWF(ByVal TABillNo As Int32) As SIS.TA.taCH
      Dim Results As SIS.TA.taCH = taCHGetByID(TABillNo)
      'Create/Update Last
      Dim oLast As SIS.TA.taBillLast = Nothing
      oLast = SIS.TA.taBillLast.taBillLastGetByID(TABillNo)
      If oLast Is Nothing Then
        Try
          oLast = New SIS.TA.taBillLast(Results)
          SIS.TA.taBillLast.InsertData(oLast)
        Catch ex As Exception
        End Try
      Else
        Try
          oLast = New SIS.TA.taBillLast(Results)
          SIS.TA.taBillLast.UpdateData(oLast)
        Catch ex As Exception
        End Try
      End If
      '==================
      With Results
        .ReceivedOn = Now
        .VerifiedBy = HttpContext.Current.Session("LoginID")
        .VerifiedOn = Now
        .VerificationRemarks = "Received in Accounts"
        .BillStatusID = TAStates.UnderProcessByAccounts
      End With
      SIS.TA.taCH.UpdateData(Results)
      Return Results
    End Function
    Public ReadOnly Property RejectWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          If BillStatusID = TAStates.UnderProcessByAccounts Then
            mRet = True
          End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property RejectWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function RejectWF(ByVal TABillNo As Int32) As SIS.TA.taCH
      Dim Results As SIS.TA.taCH = taCHGetByID(TABillNo)
      With Results
        .VerifiedBy = HttpContext.Current.Session("LoginID")
        .VerifiedOn = Now
        .VerificationRemarks = "Returned by Accounts"
        .BillStatusID = TAStates.ReturnedByAccounts
      End With
      SIS.TA.taCH.UpdateData(Results)
      '=============
      SendReturnEMail(Results)
      '=============
      Return Results
    End Function
    Public Shared Function UZ_taCHSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TravelTypeID As Int32, ByVal DestinationCity As String, ByVal ProjectID As String, ByVal EmployeeID As String, ByVal BillStatusID As Int32, ByVal TABillNo As Int32) As List(Of SIS.TA.taCH)
      Dim Results As List(Of SIS.TA.taCH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "TABillNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spta_LG_CHSelectListSearch"
            Cmd.CommandText = "sptaCHSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spta_LG_CHSelectListFilteres"
            Cmd.CommandText = "sptaCHSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TravelTypeID", SqlDbType.Int, 10, IIf(TravelTypeID = Nothing, 0, TravelTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DestinationCity", SqlDbType.NVarChar, 30, IIf(DestinationCity Is Nothing, String.Empty, DestinationCity))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID", SqlDbType.NVarChar, 6, IIf(ProjectID Is Nothing, String.Empty, ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EmployeeID", SqlDbType.NVarChar, 8, IIf(EmployeeID Is Nothing, String.Empty, EmployeeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BillStatusID", SqlDbType.Int, 10, IIf(BillStatusID = Nothing, 0, BillStatusID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo", SqlDbType.Int, 10, IIf(TABillNo = Nothing, 0, TABillNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.TA.taCH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taCH(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taCHSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TravelTypeID As Int32, ByVal DestinationCity As String, ByVal ProjectID As String, ByVal EmployeeID As String, ByVal BillStatusID As Int32, ByVal TABillNo As Int32) As Integer
      Return RecordCount
    End Function
    Public Shared Function UZ_taCHUpdate(ByVal Record As SIS.TA.taCH) As SIS.TA.taCH
      Dim _Rec As SIS.TA.taCH = SIS.TA.taCH.taCHGetByID(Record.TABillNo)
      With _Rec
        .ProjectID = Record.ProjectID
        .BillCurrencyID = Record.BillCurrencyID
        .PrjCalcType = Record.PrjCalcType
        .SanctionedDA = Record.SanctionedDA
        .ApprovalWFTypeID = Record.ApprovalWFTypeID
        .CostCenterID = Record.CostCenterID
        .ConversionFactorINR = Record.ConversionFactorINR
        .SanctionedLodging = Record.SanctionedLodging
        .OOEReasonID = Record.OOEReasonID
        .Setteled = Record.Setteled
        .CalculationTypeID = Record.CalculationTypeID
        .OOEByAccounts = Record.OOEByAccounts
        .OOERemarks = Record.OOERemarks
      End With
      _Rec = SIS.TA.taCH.UpdateData(_Rec)
      ValidateBillPassing(Record.TABillNo)
      Return _Rec
    End Function
    Public Shared Function SendReturnEMail(ByVal oUC As SIS.TA.taCH) As String
      Dim mRet As String = ""
      Dim First As Boolean = True
      Dim Cnt As Integer = 0
      Dim mRecipients As New StringBuilder
      Dim maySend As Boolean = False

      Dim oClient As SmtpClient = New SmtpClient()
      Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
      Dim ad As MailAddress = Nothing
      'From EMail
      If oUC.FK_TA_Bills_VerifiedBy.EMailID <> String.Empty Then
        ad = New MailAddress(oUC.FK_TA_Bills_VerifiedBy.EMailID, oUC.FK_TA_Bills_VerifiedBy.EmployeeName)
        oMsg.From = ad
        oMsg.CC.Add(ad)
      End If
      If oUC.FK_TA_Bills_EmployeeID.EMailID <> String.Empty Then
        ad = New MailAddress(oUC.FK_TA_Bills_EmployeeID.EMailID, oUC.FK_TA_Bills_EmployeeID.EmployeeName)
        oMsg.To.Add(ad)
      End If
      oMsg.IsBodyHtml = True
      oMsg.Subject = "TA Bill RETURNED : " & oUC.TABillNo

      Dim sb As New StringBuilder
      With sb
        .AppendLine("<table style=""width:900px"" border=""1"" cellspacing=""1"" cellpadding=""1"">")
        .AppendLine("<tr><td colspan=""2"" style=""color:red"" align=""center""><h3><b>TA BILL RETURNED</b></h3></td></tr>")
        .AppendLine("<tr><td bgcolor=""lightgray""><b>Accounts Remarks</b></td>")
        .AppendLine("<td>" & oUC.OOERemarks & "</td></tr>")
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
    Public Shared Sub ValidateBillPassing(ByVal TaBillNo As Integer)
      Dim sBill As SIS.TA.taBH = SIS.TA.taBH.taBHGetByID(TaBillNo)
      '1. Bill Header
      With sBill
        .TotalClaimedAmount = 0
        .TotalFinancedAmount = 0
        .TotalPassedAmount = 0
        .TotalPayableAmount = 0
      End With
      '2. Project Amounts
      Dim pAmts As List(Of SIS.TA.taBillPrjAmounts) = SIS.TA.taBillPrjAmounts.taBillPrjAmountsSelectList(0, 999, "", False, "", TaBillNo)
      For Each pAmt As SIS.TA.taBillPrjAmounts In pAmts
        pAmt.TotalAmountinINR = 0
        SIS.TA.taBillPrjAmounts.UpdateData(pAmt)
      Next
      '3. Bill Amounts
      Dim sAmts As List(Of SIS.TA.taBillAmount) = SIS.TA.taBillAmount.taBillAmountSelectList(0, 999, "", False, "", TaBillNo)
      For Each sAmt As SIS.TA.taBillAmount In sAmts
        SIS.TA.taBillAmount.taBillAmountDelete(sAmt)
      Next
      '====================
      '====================
      '7. Update INR Value based on Calculation type & Header OOEBySystem
      Dim sTmps As List(Of SIS.TA.taBillDetails) = Nothing
      sTmps = SIS.TA.taBillDetails.taBillDetailsSelectList(0, 999, "", False, "", TaBillNo)
      For Each sTmp As SIS.TA.taBillDetails In sTmps
        If sBill.CalculationTypeID = TACalculationTypes.ConvertAtGrossLevel Then
          sTmp.AmountInINR = sTmp.AmountTotal * sBill.ConversionFactorINR
          sTmp.PassedAmountInINR = sTmp.PassedAmountTotal * sBill.ConversionFactorINR
        Else
          sTmp.AmountInINR = sTmp.AmountTotal * sTmp.ConversionFactorINR
          sTmp.PassedAmountInINR = sTmp.PassedAmountTotal * sTmp.ConversionFactorINR
        End If
        SIS.TA.taBillDetails.UpdateData(sTmp)
      Next
      '8-A. Update Project wise total as per actual
      Dim NetAccountsEntry As Decimal = 0
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
        Dim Fcur As String = ""
        Select Case sTmp.CurrencyID
          Case "INR", "USD", "EURO"
            Fcur = sTmp.CurrencyID
          Case Else
            Fcur = sTmp.CurrencyMain
        End Select

        Dim sAmt As SIS.TA.taBillAmount = SIS.TA.taBillAmount.taBillAmountGetByID(sTmp.TABillNo, sTmp.ComponentID, Fcur, sTmp.CostCenterID)
        If sAmt Is Nothing Then
          sAmt = New SIS.TA.taBillAmount
          With sTmp
            sAmt.TABillNo = .TABillNo
            sAmt.ComponentID = .ComponentID
            Dim cur As String = ""
            Select Case .CurrencyID
              Case "INR", "USD", "EURO"
                cur = .CurrencyID
              Case Else
                cur = .CurrencyMain
            End Select
            sAmt.CurrencyID = cur
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
        If sTmp.ComponentID = TAComponentTypes.Finance Then
          With sTmp
            If sBill.CalculationTypeID = TACalculationTypes.ConvertAtIndividualLevel Then
              sBill.TotalFinancedAmount += (.PassedAmountTotal * .ConversionFactorINR)
            Else
              sBill.TotalFinancedAmount += (.PassedAmountTotal * sBill.ConversionFactorINR)
            End If
            sBill.TotalPayableAmount = sBill.TotalPassedAmount '- sBill.TotalFinancedAmount
          End With
        ElseIf sTmp.ComponentID = TAComponentTypes.AccountsEntry Then
          With sTmp
            If sBill.CalculationTypeID = TACalculationTypes.ConvertAtIndividualLevel Then
              NetAccountsEntry += (.AmountTotal * .ConversionFactorINR)
            Else
              NetAccountsEntry += (.AmountTotal * sBill.ConversionFactorINR)
            End If
          End With
        Else
          With sTmp
            If sBill.CalculationTypeID = TACalculationTypes.ConvertAtIndividualLevel Then
              sBill.TotalClaimedAmount += (.AmountTotal * .ConversionFactorINR)
            Else
              sBill.TotalClaimedAmount += (.AmountTotal * sBill.ConversionFactorINR)
            End If
            sBill.TotalPassedAmount += (.PassedAmountInINR)
            sBill.TotalPayableAmount = sBill.TotalPassedAmount '- sBill.TotalFinancedAmount
          End With
        End If
      Next
      sBill.TotalPayableAmount += NetAccountsEntry
      sBill.TotalPassedAmount += NetAccountsEntry
      SIS.TA.taBH.UpdateData(sBill)
      '9. Project wise Distribute as per Distribution Method
      Try
        SIS.TA.taBH.UpdateProjectwiseDistribution(sBill)
      Catch ex As Exception
      End Try
      '10. Calculate TOTAL of Bill Amounts in TOTAL Record Line
      Try
        SIS.TA.taBH.UpdateBillAmountTotal(sBill)
      Catch ex As Exception
      End Try
    End Sub
    Public Shared Function SendReminderEMail(ByVal oUC As SIS.TA.taCH) As String
      Dim mRet As String = ""
      Dim First As Boolean = True
      Dim Cnt As Integer = 0
      Dim mRecipients As New StringBuilder
      Dim maySend As Boolean = False

      Dim oClient As SmtpClient = New SmtpClient()
      Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
      Dim ad As MailAddress = Nothing
      'From EMail
      If oUC.FK_TA_Bills_VerifiedBy.EMailID <> String.Empty Then
        ad = New MailAddress(oUC.FK_TA_Bills_VerifiedBy.EMailID, oUC.FK_TA_Bills_VerifiedBy.EmployeeName)
        oMsg.From = ad
        oMsg.CC.Add(ad)
      End If
      If oUC.FK_TA_Bills_EmployeeID.EMailID <> String.Empty Then
        ad = New MailAddress(oUC.FK_TA_Bills_EmployeeID.EMailID, oUC.FK_TA_Bills_EmployeeID.EmployeeName)
        oMsg.To.Add(ad)
      End If
      oMsg.IsBodyHtml = True
      oMsg.Subject = "Reminder to re-submit TA Bill : " & oUC.TABillNo

      Dim sb As New StringBuilder
      With sb
        .AppendLine("<table style=""width:900px"" border=""1"" cellspacing=""1"" cellpadding=""1"">")
        .AppendLine("<tr><td colspan=""2"" style=""color:green"" align=""center""><h3><b>RE-SUBMIT TA BILL</b></h3></td></tr>")
        .AppendLine("<tr><td bgcolor=""lightgray""><b>Accounts Remarks</b></td>")
        .AppendLine("<td>" & oUC.OOERemarks & "</td></tr>")
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
    Public Shared Shadows Function SendPassedMail(ByVal oTA As SIS.TA.taBH) As String
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
      End If
      oMsg.To.Add(fad)
      Subject = "TA Bill No. " & oTA.TABillNo & " Processing Completed by A/c, Dest.: " & oTA.DestinationCity
      oMsg.IsBodyHtml = True
      oMsg.Subject = Subject
      Try
        Header = ""
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
        Header = Header & RenderControlToHtml(SIS.TA.taBH.GetTABillPanel(oTA.TABillNo, True, False))
        Header = Header & "</body></html>"
        oMsg.Body = Header
        oClient.Send(oMsg)
      Catch ex As Exception
        mRet = ex.Message
      End Try
      Return mRet
    End Function
    Public Shared Function RenderControlToHtml(ByVal ControlToRender As Control) As String
      Dim sb As Text.StringBuilder = New Text.StringBuilder()
      Dim stWriter As IO.StringWriter = New IO.StringWriter(sb)
      Dim htmlWriter As System.Web.UI.HtmlTextWriter = New System.Web.UI.HtmlTextWriter(stWriter)
      ControlToRender.RenderControl(htmlWriter)
      Return sb.ToString()
    End Function
  End Class
End Namespace
