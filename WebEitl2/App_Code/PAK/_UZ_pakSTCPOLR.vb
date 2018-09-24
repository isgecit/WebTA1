Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Net

Namespace SIS.PAK
  Partial Public Class pakSTCPOLR
    Private _FK_PAK_POLineRec_pakERPRecH As SIS.PAK.pakERPRecH = Nothing
    Public ReadOnly Property FK_PAK_POLineRec_pakERPRecH As SIS.PAK.pakERPRecH
      Get
        If _FK_PAK_POLineRec_pakERPRecH Is Nothing Then
          If ReceiptNo <> "" And RevisionNo <> "" Then
            _FK_PAK_POLineRec_pakERPRecH = SIS.PAK.pakERPRecH.pakERPRecHGetByID(ReceiptNo, RevisionNo)
          End If
        End If
        Return _FK_PAK_POLineRec_pakERPRecH
      End Get
    End Property

    Public ReadOnly Property GetCommentsLink() As String
      Get
        If TransmittalNo = "" Then
          Return ""
        Else
          Return "javascript:window.open('" & HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath & "/ediWSTmtlH.aspx?s_tran=" & TransmittalNo & "', 'win" & UploadNo & "', 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1'); return false;"
        End If
      End Get
    End Property
    Public ReadOnly Property TransmittalNo As String
      Get
        Dim mRet As String = ""
        If FK_PAK_POLineRec_pakERPRecH IsNot Nothing Then mRet = FK_PAK_POLineRec_pakERPRecH.t_trno
        Return mRet
      End Get
    End Property
    Public ReadOnly Property GetAttachLink() As String
      Get
        Dim UrlAuthority As String = HttpContext.Current.Request.Url.Authority
        If UrlAuthority.ToLower <> "cloud.isgec.co.in" Then
          UrlAuthority = "192.9.200.146"
        End If
        Dim mRet As String = HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & UrlAuthority
        mRet &= "/Attachment/Attachment.aspx?AthHandle=J_IDMSPOSTORDERREC"
        Dim Index As String = SerialNo & "_" & ItemNo & "_" & UploadNo & "_" & SDocSerialNo
        Dim User As String = HttpContext.Current.Session("LoginID")
        'User = 1
        Dim canEdit As String = "n"
        If Editable Then
          canEdit = "y"
        End If
        mRet &= "&Index=" & Index & "&AttachedBy=" & User & "&ed=" & canEdit
        mRet = "javascript:window.open('" & mRet & "', 'win" & UploadNo & "', 'left=20,top=20,width=1100,height=600,toolbar=1,resizable=1,scrollbars=1'); return false;"
        Return mRet
      End Get
    End Property

    Public ReadOnly Property ReviseVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case UploadStatusID
            Case pakTCUploadStates.CommentSubmitted
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property AttachVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case UploadStatusID
            Case pakTCUploadStates.Free
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property CommentsVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case UploadStatusID
            Case pakTCUploadStates.CommentSubmitted, pakTCUploadStates.Superseded
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ShowERPStatus As String
      Get
        Dim mRet As String = PAK_POLineRecStatus5_Description
        'Dim NewStatus As pakTCUploadStates = UploadStatusID
        'If UploadStatusID = pakTCUploadStates.Uploaded Then
        '  Dim erpStatus As String = "3"
        '  If FK_PAK_POLineRec_pakERPRecH IsNot Nothing Then erpStatus = IIf(FK_PAK_POLineRec_pakERPRecH.t_stat = "0", 3, FK_PAK_POLineRec_pakERPRecH.t_stat)
        '  Select Case erpStatus
        '    Case "4"
        '      NewStatus = pakTCUploadStates.CommentSubmitted
        '    Case "5"
        '      NewStatus = pakTCUploadStates.TechnicallyCleared
        '    Case "8"
        '      NewStatus = pakTCUploadStates.Closed
        '  End Select
        'End If
        'If NewStatus <> UploadStatusID AndAlso UploadStatusID = pakTCUploadStates.Uploaded Then
        '  'If there is change in status in ERP, Update status in Joomla
        '  Dim tmp As SIS.PAK.pakTCPOLR = SIS.PAK.pakTCPOLR.pakTCPOLRGetByID(SerialNo, ItemNo, UploadNo)
        '  tmp.UploadStatusID = NewStatus
        '  SIS.PAK.pakTCPOLR.UpdateData(tmp)
        '  tmp = SIS.PAK.pakTCPOLR.pakTCPOLRGetByID(SerialNo, ItemNo, UploadNo)
        '  mRet = tmp.PAK_POLineRecStatus5_Description
        '  UploadStatusID = tmp.UploadStatusID
        'End If
        Return mRet
      End Get
    End Property
    Public ReadOnly Property IsAdmin As Boolean
      Get
        Return IIf(HttpContext.Current.Session("LoginID") = "0340", True, False)
      End Get
    End Property
    Public ReadOnly Property GetDownloadLink() As String
      Get
        Return "javascript:window.open('" & HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath & "/PAK_Main/App_Downloads/filedownload.aspx?stcpolr=" & PrimaryKey & "', 'win" & ItemNo & "', 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1'); return false;"
      End Get
    End Property
    Public Shadows Function GetEditable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Shadows Function GetDeleteable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Shadows ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case UploadStatusID
            Case pakTCUploadStates.Free
              mRet = True
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
    Public Shared Function ReviseWF(ByVal SerialNo As Int32, ByVal ItemNo As Int32, ByVal UploadNo As Int32) As SIS.PAK.pakSTCPOLR
      Dim tmpS As SIS.PAK.pakSTCPOLR = pakSTCPOLRGetByID(SerialNo, ItemNo, UploadNo)
      If tmpS.UploadStatusID = pakTCUploadStates.CommentSubmitted Then
        '1. Update to Superseded
        tmpS.UploadStatusID = pakTCUploadStates.Superseded
        tmpS = SIS.PAK.pakSTCPOLR.UpdateData(tmpS)
        '2. Create New Receipt with FREE Status
        With tmpS
          .UploadNo = 0
          .UploadStatusID = pakTCUploadStates.Free
          .RevisionNo = Convert.ToString(Convert.ToInt32(.RevisionNo) + 1).PadLeft(2, "0")
          .UploadRemarks = ""
        End With
        tmpS = SIS.PAK.pakSTCPOLR.InsertData(tmpS)
      End If
      Return tmpS
    End Function
    Public Shared Function InitiateWF(ByVal SerialNo As Int32, ByVal ItemNo As Int32, ByVal UploadNo As Int32) As SIS.PAK.pakSTCPOLR
      Dim tmpRec As SIS.PAK.pakSTCPOLR = pakSTCPOLRGetByID(SerialNo, ItemNo, UploadNo)
      Dim IsERPReceiptNoFound As Boolean = False
      Dim IsReceiptExistInERP As Boolean = False
      '1.Check ERP Receipt Created
      If tmpRec.ReceiptNo <> "" AndAlso tmpRec.RevisionNo <> "" Then
        IsERPReceiptNoFound = True
      End If
      Dim NextRecNo As String = tmpRec.ReceiptNo
      Dim DefaultRevisionNo As String = tmpRec.RevisionNo
      If Not IsERPReceiptNoFound Then
        NextRecNo = GetNextRecNo()
        NextRecNo = "REP" & NextRecNo.ToString.PadLeft(6, "0")
        DefaultRevisionNo = "00"
      End If
      With tmpRec
        .ReceiptNo = NextRecNo
        .RevisionNo = DefaultRevisionNo
        .UploadStatusID = pakTCUploadStates.UnderEvaluation
        .CreatedBy = HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
      End With
      '2. Get ERP Object of Receipt Header
      Dim ERPRecH As SIS.PAK.pakERPRecH = SIS.PAK.pakSTCPOLR.GetERPRecH(tmpRec)
      '3. Check Whether Already Exists in ERP
      Dim tmpRH As SIS.PAK.pakERPRecH = SIS.PAK.pakERPRecH.pakERPRecHGetByID(ERPRecH.t_rcno, ERPRecH.t_revn)
      If tmpRH IsNot Nothing Then
        IsReceiptExistInERP = True
      End If
      If IsReceiptExistInERP Then
        'As per logic it will never executed
        'Untill we give permission to Re-Submit, NOT Commented it, to be safe in case of error
        ERPRecH = SIS.PAK.pakERPRecH.UpdateData(ERPRecH)
      Else
        ERPRecH = SIS.PAK.pakERPRecH.InsertData(ERPRecH)
      End If
      '4. Handle Insert/Update of document line
      Dim tmpDocs As List(Of SIS.PAK.pakSTCPOLRD) = SIS.PAK.pakSTCPOLRD.pakSTCPOLRDSelectList(0, 9999, "", False, "", SerialNo, ItemNo, UploadNo)
      '====================================================
      'Pending To write, to be safe in case of error & Update
      'Here Code to Delete ERP Line with attached documents
      'For all tmpDocs
      '====================================================
      Dim I As Integer = 1
      For Each td As SIS.PAK.pakSTCPOLRD In tmpDocs
        '4.1 Update document Line Status in Joomla
        With td
          .ReceiptNo = tmpRec.ReceiptNo
          .RevisionNo = tmpRec.RevisionNo
          .ERPDocSerialNo = I
        End With
        td = SIS.PAK.pakSTCPOLRD.UpdateData(td)
        '4.2 Get Source Index value from Joomla Document
        Dim IndexS As String = td.SerialNo & "_" & td.ItemNo & "_" & td.UploadNo & "_" & td.DocSerialNo
        '4.3 Get ERP Line Object from Joomla Line
        Dim ERPRecD As SIS.PAK.pakERPRecD = SIS.PAK.pakSTCPOLRD.GetERPRecD(td)
        ERPRecD = SIS.PAK.pakERPRecD.InsertData(ERPRecD)
        Dim IndexT As String = td.ReceiptNo & "_" & td.RevisionNo & "_" & td.ERPDocSerialNo
        '4.4 Copy Attachment
        Try
          CopyAttachment(IndexS, IndexT)
        Catch ex As Exception
        End Try
        I += 1
      Next
      tmpRec = SIS.PAK.pakSTCPOLR.UpdateData(tmpRec)
      '5. Update Item Status
      Dim tmpPOL As SIS.PAK.pakSTCPOL = SIS.PAK.pakSTCPOL.pakSTCPOLGetByID(tmpRec.SerialNo, tmpRec.ItemNo)
      tmpPOL.ItemStatusID = pakTCPOLineStates.TCSubmitted
      SIS.PAK.pakSTCPOL.UpdateData(tmpPOL)
      '6. Distribute in ERP
      Try
        DistributeInERP(tmpRec.ReceiptNo, tmpRec.RevisionNo)
      Catch ex As Exception
      End Try
      '7. Send TC Alert E-Mail
      Try
        SIS.PAK.Alerts.TCAlert(SerialNo, pakAlertEvents.DocumentsDespatched, ItemNo, UploadNo)
      Catch ex As Exception
      End Try
      Return tmpRec
    End Function
    Public Shared Function ReCopy(ByVal SerialNo As Int32, ByVal ItemNo As Int32, ByVal UploadNo As Int32) As SIS.PAK.pakSTCPOLR
      'Dim tmpRec As SIS.PAK.pakSTCPOLR = pakSTCPOLRGetByID(SerialNo, ItemNo, UploadNo)
      Dim tmpDocs As List(Of SIS.PAK.pakSTCPOLRD) = SIS.PAK.pakSTCPOLRD.pakSTCPOLRDSelectList(0, 9999, "", False, "", SerialNo, ItemNo, UploadNo)
      For Each td As SIS.PAK.pakSTCPOLRD In tmpDocs
        Dim IndexS As String = td.SerialNo & "_" & td.ItemNo & "_" & td.UploadNo & "_" & td.DocSerialNo
        Dim IndexT As String = td.ReceiptNo & "_" & td.RevisionNo & "_" & td.ERPDocSerialNo
        '======Copy Attachment===========
        CopyAttachment(IndexS, IndexT)
        '======End Copy Attachment=======
      Next
      Return Nothing
    End Function
    Private Shared Sub CopyAttachment(ByVal IndexS As String, ByVal IndexT As String)
      Dim xUrl As String = SIS.PAK.pakSTCPOLR.GetCopyLink()
      xUrl = xUrl & "/" & IndexS & "/" & IndexT
      Dim rq As HttpWebRequest = WebRequest.Create(New Uri(xUrl))
      rq.Method = "GET"
      rq.ContentType = "application/json"
      'rq.ContentLength = 0
      'rq.ContentLength = Data.length
      'Dim rw As IO.StreamWriter = New IO.StreamWriter(rq.GetRequestStream(), System.Text.Encoding.ASCII)
      'rw.Write(Data)
      'rw.Close()
      Try
        Dim rs As WebResponse = rq.GetResponse()
        Dim st As IO.Stream = rs.GetResponseStream
        Dim sr As IO.StreamReader = New IO.StreamReader(st)
        Dim strResponse As String = sr.ReadToEnd
        sr.Close()
      Catch ex As Exception
        Dim err As String = ex.Message
      End Try
    End Sub
    Private Shared Sub DistributeInERP(ByVal ReceiptNo As String, ByVal RevisionNo As String)
      Dim CardNo As String = Convert.ToInt32(HttpContext.Current.Session("LoginID"))

      Dim mFileName As String = "REC" & CardNo & "_" & Now.ToString.Replace("/", "").Replace(":", "").Replace(" ", "") & ".xml"

      Dim tmpDir As String = HttpContext.Current.Server.MapPath("~/..") & "App_Temp\TABill"
      If Not IO.Directory.Exists(tmpDir) Then
        IO.Directory.CreateDirectory(tmpDir)
        IO.Directory.CreateDirectory(tmpDir & "\s")
        IO.Directory.CreateDirectory(tmpDir & "\t")
      Else
        If Not IO.Directory.Exists(tmpDir & "\s") Then
          IO.Directory.CreateDirectory(tmpDir & "\s")
        End If
        If Not IO.Directory.Exists(tmpDir & "\t") Then
          IO.Directory.CreateDirectory(tmpDir & "\t")
        End If
      End If

      Dim oTW As IO.StreamWriter = New IO.StreamWriter(tmpDir & "\s\" & mFileName)
      oTW.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")
      oTW.WriteLine("<ERPFunctions>")
      oTW.WriteLine("  <Function dll=""odmisgdll0100"" fun=""dmisgdll0100.forward.receipt.to.departments"" >" & ReceiptNo & "," & RevisionNo & ",</Function>")
      oTW.WriteLine("</ERPFunctions>")
      oTW.Close()

    End Sub
    Public Shared Function UZ_pakSTCPOLRSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal ItemNo As Int32) As List(Of SIS.PAK.pakSTCPOLR)
      Dim Results As List(Of SIS.PAK.pakSTCPOLR) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_STCPOLRSelectListSearch"
            Cmd.CommandText = "sppakSTCPOLRSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_STCPOLRSelectListFilteres"
            Cmd.CommandText = "sppakSTCPOLRSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo", SqlDbType.Int, 10, IIf(SerialNo = Nothing, 0, SerialNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ItemNo", SqlDbType.Int, 10, IIf(ItemNo = Nothing, 0, ItemNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PAK.pakSTCPOLR)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSTCPOLR(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakSTCPOLRInsert(ByVal Record As SIS.PAK.pakSTCPOLR) As SIS.PAK.pakSTCPOLR
      Dim _Result As SIS.PAK.pakSTCPOLR = pakSTCPOLRInsert(Record)
      '======Update Item Status=====
      Dim tmpPOL As SIS.PAK.pakSTCPOL = SIS.PAK.pakSTCPOL.pakSTCPOLGetByID(Record.SerialNo, Record.ItemNo)
      tmpPOL.ItemStatusID = pakTCPOLineStates.TCCreated
      SIS.PAK.pakTCPOL.UpdateData(tmpPOL)
      '=====End Update Item Status===
      Return _Result
    End Function
    Public Shared Function UZ_pakSTCPOLRUpdate(ByVal Record As SIS.PAK.pakSTCPOLR) As SIS.PAK.pakSTCPOLR
      Dim _Result As SIS.PAK.pakSTCPOLR = pakSTCPOLRUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakSTCPOLRDelete(ByVal Record As SIS.PAK.pakSTCPOLR) As Int32
      Dim _Result As Integer = pakTCPOLRDelete(Record)
      Return _Result
    End Function
    Public Shared Function GetERPRecH(ByVal STCPOLR As SIS.PAK.pakSTCPOLR) As SIS.PAK.pakERPRecH
      Dim tmp As New SIS.PAK.pakERPRecH
      With tmp
        .t_rcno = STCPOLR.ReceiptNo
        .t_revn = STCPOLR.RevisionNo
        .t_cprj = STCPOLR.FK_PAK_POLineRec_SerialNo.ProjectID
        .t_item = STCPOLR.FK_PAK_POLineRec_ItemNo.ItemCode
        .t_bpid = STCPOLR.FK_PAK_POLineRec_SerialNo.SupplierID
        .t_stat = 1 'submitted
        .t_user = "SUPPLIER"
        .t_date = Now.ToString("dd/MM/yyyy")
        .t_orno = STCPOLR.FK_PAK_POLineRec_SerialNo.PONumber
        .t_pono = STCPOLR.FK_PAK_POLineRec_ItemNo.ItemNo
        .t_docn = STCPOLR.PAK_POLineRecCategory4_Description.Substring(0, 3)
        Dim eunt As String = ""
        Select Case STCPOLR.FK_PAK_POLineRec_SerialNo.PONumber.Substring(0, 4)
          Case "P101"
            eunt = "EU200"
          Case "P201"
            eunt = "EU230"
          Case "P301"
            eunt = "EU210"
          Case "P401"
            eunt = "EU220"
          Case "P501"
            eunt = "EU240"
        End Select
        .t_eunt = eunt
        'Default Values
        '==============
        .t_nama = ""
        .t_sent_1 = 2 'No
        .t_sent_2 = 2
        .t_sent_3 = 2
        .t_sent_4 = 2
        .t_sent_5 = 2
        .t_sent_6 = 2
        .t_sent_7 = 2
        .t_rece_1 = 2
        .t_rece_2 = 2
        .t_rece_3 = 2
        .t_rece_4 = 2
        .t_rece_5 = 2
        .t_rece_6 = 2
        .t_rece_7 = 2
        .t_suer = ""
        .t_sdat = "01/01/1970"
        .t_appr = ""
        .t_adat = "01/01/1970"
        .t_subm_1 = 2
        .t_subm_2 = 2
        .t_subm_3 = 2
        .t_subm_4 = 2
        .t_subm_5 = 2
        .t_subm_6 = 2
        .t_subm_7 = 2
        .t_trno = ""
        .t_Refcntd = 0
        .t_Refcntu = 0
      End With
      Return tmp
    End Function
    Public Shared Function GetNextRecNo() As String
      Dim NextNo As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select t_ffno from ttcmcs050200 where t_nrgr='VEN' and t_seri='REP'"
          Con.Open()
          NextNo = Cmd.ExecuteScalar
        End Using
        Using Cmd As SqlCommand = Con.CreateCommand()
          Dim tmp As Integer = Convert.ToInt32(NextNo) + 1
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "update ttcmcs050200 set t_ffno = " & tmp & " where t_nrgr='VEN' and t_seri='REP'"
          Cmd.ExecuteNonQuery()
        End Using
      End Using
      Return NextNo
    End Function
    Public Shared Function AddRequestFiles(ByVal Request As HttpRequest, ByVal PrimaryKey As String) As Boolean
      Dim L_ScriptTimeOut As Integer = 0
      Dim L_SessionTimeOut As Integer = HttpContext.Current.Session.Timeout
      HttpContext.Current.Session.Timeout = 60
      L_ScriptTimeOut = HttpContext.Current.Server.ScriptTimeout
      HttpContext.Current.Server.ScriptTimeout = 3600
      Dim aVal() As String = PrimaryKey.Split("|".ToCharArray)
      Dim SerialNo As String = aVal(0)
      Dim ItemNo As String = aVal(1)
      Dim UploadNo As String = aVal(2)
      Try
        Dim tmpPath As String = ConfigurationManager.AppSettings("TCPath")
        If Not IO.Directory.Exists(tmpPath) Then
          tmpPath = ConfigurationManager.AppSettings("TCPath1")
        End If
        Dim oFiles As HttpFileCollection = Request.Files
        For i As Integer = 0 To Request.Files.Count - 1
          Dim pfile As HttpPostedFile
          pfile = Request.Files.Item(i)
          If pfile.ContentLength <= 0 Then Continue For
          Dim tmpName As String = IO.Path.GetRandomFileName()
          Dim tmpFile As String = tmpPath & "\\" & tmpName
          pfile.SaveAs(tmpFile)
          Try
            Dim tmpDoc As SIS.PAK.pakSTCPOLRD = Nothing
            tmpDoc = SIS.PAK.pakSTCPOLRD.GetByFileName(SerialNo, ItemNo, UploadNo, IO.Path.GetFileName(pfile.FileName))
            If tmpDoc IsNot Nothing Then
              tmpDoc.DiskFileName = tmpFile
              tmpDoc = SIS.PAK.pakSTCPOLRD.UpdateData(tmpDoc)
            Else
              'Create document & attach file
              tmpDoc = New SIS.PAK.pakSTCPOLRD
              With tmpDoc
                .SerialNo = SerialNo
                .ItemNo = ItemNo
                .UploadNo = UploadNo
                .DocSerialNo = 0
                .DocumentID = IO.Path.GetFileNameWithoutExtension(pfile.FileName).ToUpper
                .DocumentDescription = IO.Path.GetFileNameWithoutExtension(pfile.FileName)
                .DocumentRev = "00"
                .FileName = IO.Path.GetFileName(pfile.FileName)
                .DiskFileName = tmpFile
              End With
              tmpDoc = SIS.PAK.pakSTCPOLRD.InsertData(tmpDoc)
            End If
          Catch ex As Exception
            IO.File.Delete(tmpFile)
          End Try
        Next
      Catch ex As Exception
        HttpContext.Current.Session.Timeout = L_SessionTimeOut
        HttpContext.Current.Server.ScriptTimeout = L_ScriptTimeOut
        Throw New Exception(ex.Message)
      End Try
      HttpContext.Current.Session.Timeout = L_SessionTimeOut
      HttpContext.Current.Server.ScriptTimeout = L_ScriptTimeOut
      Return True
    End Function
  End Class
End Namespace
