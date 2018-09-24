Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.CT
  Public Class ctUpdates
    Public Shared Sub CT_POAccepted(ByVal pp As SIS.PAK.pakPO)
      Dim errMsg As String = ""
      Dim hndl As String = "CT_POISSUED"
      '1. Insert In tpisg229
      Dim ct229 As New SIS.TPISG.tpisg229
      With ct229
        .t_trdt = Now.ToString("dd/MM/yyyy HH:mm:ss")
        .t_bohd = hndl
        .t_indv = pp.SerialNo & "_" & pp.PONumber
        .t_srno = 1
        .t_proj = pp.ProjectID
        .t_elem = ""
        .t_user = HttpContext.Current.Session("LoginID")
        .t_stat = ""
        .t_Refcntd = 0
        .t_Refcntu = 0
      End With
      ct229 = SIS.TPISG.tpisg229.InsertData(ct229)
      '2. Insert In tpisg230
      Dim DSrn As Integer = 0
      Dim PODocs As List(Of SIS.DOCS.Document) = SIS.DOCS.Document.DocumentsSelectList(pp.PONumber)
      If PODocs.Count > 0 Then
        For Each PODoc As SIS.DOCS.Document In PODocs
          DSrn += 1
          Dim ct230 As New SIS.TPISG.tpisg230
          With ct230
            .t_trdt = ct229.t_trdt
            .t_bohd = hndl
            .t_indv = pp.SerialNo & "_" & pp.PONumber
            .t_srno = 1
            .t_dsno = DSrn
            .t_dwno = PODoc.t_docn
            .t_elem = ""
            .t_proj = pp.ProjectID
            .t_wght = 0
            .t_pitc = 0
            .t_stat = ""
            .t_atcd = ""
            .t_scup = 0
            .t_acdt = "01/01/1753"
            .t_acfh = "01/01/1753"
            .t_pper = 0
            .t_lupd = "01/01/1753"
            .t_Refcntd = 0
            .t_Refcntu = 0
            .t_numo = 0
            .t_numq = 0
            .t_numt = 0
            .t_numv = 0
            .t_nutc = 0
            .t_cuni = ""
            .t_iref = ""
            .t_quan = 0
            .t_iuom = ""
          End With
          ct230 = SIS.TPISG.tpisg230.InsertData(ct230)
          '3. Update Issue Date in dmisg140 'PMDL
          SIS.DMISG.dmisg140.UpdatePOAD(PODoc.t_docn)
        Next
      End If
      '4. Calculate Progress %
      Dim tmp208 As SIS.TPISG.tpisg208 = SIS.TPISG.tpisg208.tpisg208GetByID(pp.SerialNo)
      If tmp208 IsNot Nothing Then
        With tmp208
          .t_accp = 1 'YES
          .t_accd = ct229.t_trdt
          .t_acby = HttpContext.Current.Session("LoginID")
          .t_Refcntd = 0
          .t_Refcntu = 0
        End With
        SIS.TPISG.tpisg208.UpdateData(tmp208)
      Else
        Throw New Exception("CT-PO Issue record Not found.")
      End If
    End Sub

    Public Shared Sub CT_POIssued(ByVal pp As SIS.PAK.pakPO)
      Dim errMsg As String = ""
      Dim hndl As String = "CT_POISSUED"
      '1. Insert In tpisg229
      Dim ct229 As New SIS.TPISG.tpisg229
      With ct229
        .t_trdt = Now.ToString("dd/MM/yyyy HH:mm:ss")
        .t_bohd = hndl
        .t_indv = pp.SerialNo & "_" & pp.PONumber
        .t_srno = 1
        .t_proj = pp.ProjectID
        .t_elem = ""
        .t_user = pp.IssuedBy
        .t_stat = ""
        .t_Refcntd = 0
        .t_Refcntu = 0
      End With
      ct229 = SIS.TPISG.tpisg229.InsertData(ct229)
      '2. Insert In tpisg230
      Dim DSrn As Integer = 0
      Dim PODocs As List(Of SIS.DOCS.Document) = SIS.DOCS.Document.DocumentsSelectList(pp.PONumber)
      If PODocs.Count > 0 Then
        For Each PODoc As SIS.DOCS.Document In PODocs
          DSrn += 1
          Dim ct230 As New SIS.TPISG.tpisg230
          With ct230
            .t_trdt = ct229.t_trdt
            .t_bohd = hndl
            .t_indv = pp.SerialNo & "_" & pp.PONumber
            .t_srno = 1
            .t_dsno = DSrn
            .t_dwno = PODoc.t_docn
            .t_elem = ""
            .t_proj = pp.ProjectID
            .t_wght = 0
            .t_pitc = 0
            .t_stat = ""
            .t_atcd = ""
            .t_scup = 0
            .t_acdt = "01/01/1753"
            .t_acfh = "01/01/1753"
            .t_pper = 0
            .t_lupd = "01/01/1753"
            .t_Refcntd = 0
            .t_Refcntu = 0
            .t_numo = 0
            .t_numq = 0
            .t_numt = 0
            .t_numv = 0
            .t_nutc = 0
            .t_cuni = ""
            .t_iref = ""
            .t_quan = 0
            .t_iuom = ""
          End With
          ct230 = SIS.TPISG.tpisg230.InsertData(ct230)
          '3. Update Issue Date in dmisg140 'PMDL
          SIS.DMISG.dmisg140.UpdatePOIS(PODoc.t_docn)
        Next
      End If
      '4. 
      '4.1 Get PO IREFs
      Dim Found As Boolean = True
      Dim tmp208 As SIS.TPISG.tpisg208 = SIS.TPISG.tpisg208.tpisg208GetByID(pp.SerialNo)
      If tmp208 Is Nothing Then
        tmp208 = New SIS.TPISG.tpisg208
        Found = False
      End If
      With tmp208
        .t_idno = pp.SerialNo
        .t_pono = pp.PONumber
        .t_issu = 1 'YES
        .t_issd = ct229.t_trdt
        .t_isby = HttpContext.Current.Session("LoginID")
        .t_accp = 2 'NO
        .t_accd = "01/01/1753"
        .t_acby = ""
        .t_cprj = pp.ProjectID
        .t_Refcntd = 0
        .t_Refcntu = 0
      End With
      If Found Then
        SIS.TPISG.tpisg208.UpdateData(tmp208)
      Else
        SIS.TPISG.tpisg208.InsertData(tmp208)
      End If
      If errMsg <> "" Then
        Throw New Exception(errMsg)
      End If
    End Sub

    Public Shared Sub CT_QCOffered(ByVal pp As SIS.PAK.pakQCListH)
      Dim errMsg As String = ""
      Dim ppPO As SIS.PAK.pakPO = pp.FK_PAK_QCListH_SerialNo
      Dim hndl As String = "CT_INSPECTIONCALLRAISED"
      '1. Insert In tpisg229
      Dim ct229 As New SIS.TPISG.tpisg229
      With ct229
        .t_trdt = Now.ToString("dd/MM/yyyy HH:mm:ss")
        .t_bohd = hndl
        .t_indv = ppPO.SerialNo & "_" & ppPO.PONumber
        .t_srno = 1
        .t_proj = ppPO.ProjectID
        .t_elem = ""
        .t_user = pp.CreatedBy
        .t_stat = ""
        .t_Refcntd = 0
        .t_Refcntu = 0
      End With
      ct229 = SIS.TPISG.tpisg229.InsertData(ct229)
      '2. Insert In tpisg230
      Dim DSrn As Integer = 0
      Dim PODocs As List(Of SIS.DOCS.Document) = SIS.DOCS.Document.DocumentsSelectList(ppPO.PONumber)
      If PODocs.Count > 0 Then
        For Each PODoc As SIS.DOCS.Document In PODocs
          DSrn += 1
          Dim ct230 As New SIS.TPISG.tpisg230
          With ct230
            .t_trdt = ct229.t_trdt
            .t_bohd = hndl
            .t_indv = ppPO.SerialNo & "_" & ppPO.PONumber
            .t_srno = 1
            .t_dsno = DSrn
            .t_dwno = PODoc.t_docn
            .t_elem = ""
            .t_proj = ppPO.ProjectID
            .t_wght = 0
            .t_pitc = 0
            .t_stat = ""
            .t_atcd = ""
            .t_scup = 0
            .t_acdt = "01/01/1753"
            .t_acfh = "01/01/1753"
            .t_pper = 0
            .t_lupd = "01/01/1753"
            .t_Refcntd = 0
            .t_Refcntu = 0
            .t_numo = 0
            .t_numq = 0
            .t_numt = 0
            .t_numv = 0
            .t_nutc = 0
            .t_cuni = ""
            .t_iref = ""
            .t_quan = 0
            .t_iuom = ""
          End With
          ct230 = SIS.TPISG.tpisg230.InsertData(ct230)
        Next
      End If
      '4. Get Final Stage Items & IRef

      Dim qcDs As List(Of SIS.PAK.pakQCListDIRef) = SIS.PAK.pakQCListDIRef.GetOfferedQCListDIref(pp)
      'update pmdl
      For Each qcD As SIS.PAK.pakQCListDIRef In qcDs
        Dim tmp207 As New SIS.TPISG.tpisg207
        With tmp207
          .t_bohd = hndl
          .t_date = ct229.t_trdt
          If pp.QCRequestNo = "" Then
            .t_inid = pp.QCLNo
          Else
            .t_inid = pp.QCRequestNo
          End If
          .t_iref = qcD.ItemReference
          .t_mode = 2  '=>Manual, 2=>Packing List
          .t_pono = pp.FK_PAK_QCListH_SerialNo.PONumber
          .t_prpo = qcD.ProgressPercent
          .t_powt = qcD.TotalWeight
          .t_Refcntd = 0
          .t_Refcntu = 0
          .t_cprj = pp.FK_PAK_QCListH_SerialNo.ProjectID
          .t_sitm = qcD.SubItem
        End With
        SIS.TPISG.tpisg207.InsertData(tmp207)
      Next
      If errMsg <> "" Then
        Throw New Exception(errMsg)
      End If
    End Sub

    Public Shared Sub CT_QCCleared(ByVal pp As SIS.PAK.pakQCListH)
      Dim errMsg As String = ""
      Dim ppPO As SIS.PAK.pakPO = pp.FK_PAK_QCListH_SerialNo
      Dim hndl As String = "CT_FINALMICN"
      '1. Insert In tpisg229
      Dim ct229 As New SIS.TPISG.tpisg229
      With ct229
        .t_trdt = Now.ToString("dd/MM/yyyy HH:mm:ss")
        .t_bohd = hndl
        .t_indv = ppPO.SerialNo & "_" & ppPO.PONumber
        .t_srno = 1
        .t_proj = ppPO.ProjectID
        .t_elem = ""
        .t_user = pp.CreatedBy
        .t_stat = ""
        .t_Refcntd = 0
        .t_Refcntu = 0
      End With
      ct229 = SIS.TPISG.tpisg229.InsertData(ct229)
      '2. Insert In tpisg230
      Dim DSrn As Integer = 0
      Dim PODocs As List(Of SIS.DOCS.Document) = SIS.DOCS.Document.DocumentsSelectList(ppPO.PONumber)
      If PODocs.Count > 0 Then
        For Each PODoc As SIS.DOCS.Document In PODocs
          DSrn += 1
          Dim ct230 As New SIS.TPISG.tpisg230
          With ct230
            .t_trdt = ct229.t_trdt
            .t_bohd = hndl
            .t_indv = ppPO.SerialNo & "_" & ppPO.PONumber
            .t_srno = 1
            .t_dsno = DSrn
            .t_dwno = PODoc.t_docn
            .t_elem = ""
            .t_proj = ppPO.ProjectID
            .t_wght = 0
            .t_pitc = 0
            .t_stat = ""
            .t_atcd = ""
            .t_scup = 0
            .t_acdt = "01/01/1753"
            .t_acfh = "01/01/1753"
            .t_pper = 0
            .t_lupd = "01/01/1753"
            .t_Refcntd = 0
            .t_Refcntu = 0
            .t_numo = 0
            .t_numq = 0
            .t_numt = 0
            .t_numv = 0
            .t_nutc = 0
            .t_cuni = ""
            .t_iref = ""
            .t_quan = 0
            .t_iuom = ""
          End With
          ct230 = SIS.TPISG.tpisg230.InsertData(ct230)
        Next
      End If
      '4. Get Final Stage Items & IRef

      Dim qcDs As List(Of SIS.PAK.pakQCListDIRef) = SIS.PAK.pakQCListDIRef.GetClearedQCListDIref(pp)
      'update pmdl
      For Each qcD As SIS.PAK.pakQCListDIRef In qcDs
        Dim tmp207 As New SIS.TPISG.tpisg207
        With tmp207
          .t_bohd = hndl
          .t_date = ct229.t_trdt
          If pp.QCRequestNo = "" Then
            .t_inid = pp.QCLNo
          Else
            .t_inid = pp.QCRequestNo
          End If
          .t_iref = qcD.ItemReference
          .t_mode = 2  '=>Manual, 2=>Packing List
          .t_pono = pp.FK_PAK_QCListH_SerialNo.PONumber
          .t_prpo = qcD.ProgressPercent
          .t_powt = qcD.TotalWeight
          .t_Refcntd = 0
          .t_Refcntu = 0
          .t_cprj = pp.FK_PAK_QCListH_SerialNo.ProjectID
          .t_sitm = qcD.SubItem
        End With
        SIS.TPISG.tpisg207.InsertData(tmp207)
      Next
      If errMsg <> "" Then
        Throw New Exception(errMsg)
      End If
    End Sub

    Public Shared Sub CT_Despatched(ByVal pp As SIS.PAK.pakPkgListH)
      Dim errMsg As String = ""
      Dim ppPO As SIS.PAK.pakPO = pp.FK_PAK_PkgListH_SerialNo
      Dim hndl As String = "CT_MATERIALDISPATCHED"
      '1. Insert In tpisg229
      Dim ct229 As New SIS.TPISG.tpisg229
      With ct229
        .t_trdt = Now.ToString("dd/MM/yyyy HH:mm:ss")
        .t_bohd = hndl
        .t_indv = ppPO.SerialNo & "_" & ppPO.PONumber
        .t_srno = 1
        .t_proj = ppPO.ProjectID
        .t_elem = ""
        .t_user = pp.CreatedBy
        .t_stat = ""
        .t_Refcntd = 0
        .t_Refcntu = 0
      End With
      ct229 = SIS.TPISG.tpisg229.InsertData(ct229)
      '2. Insert In tpisg230
      Dim DSrn As Integer = 0
      Dim PODocs As List(Of SIS.DOCS.Document) = SIS.DOCS.Document.DocumentsSelectList(ppPO.PONumber)
      If PODocs.Count > 0 Then
        For Each PODoc As SIS.DOCS.Document In PODocs
          DSrn += 1
          Dim ct230 As New SIS.TPISG.tpisg230
          With ct230
            .t_trdt = ct229.t_trdt
            .t_bohd = hndl
            .t_indv = ppPO.SerialNo & "_" & ppPO.PONumber
            .t_srno = 1
            .t_dsno = DSrn
            .t_dwno = PODoc.t_docn
            .t_elem = ""
            .t_proj = ppPO.ProjectID
            .t_wght = 0
            .t_pitc = 0
            .t_stat = ""
            .t_atcd = ""
            .t_scup = 0
            .t_acdt = "01/01/1753"
            .t_acfh = "01/01/1753"
            .t_pper = 0
            .t_lupd = "01/01/1753"
            .t_Refcntd = 0
            .t_Refcntu = 0
            .t_numo = 0
            .t_numq = 0
            .t_numt = 0
            .t_numv = 0
            .t_nutc = 0
            .t_cuni = ""
            .t_iref = ""
            .t_quan = 0
            .t_iuom = ""
          End With
          ct230 = SIS.TPISG.tpisg230.InsertData(ct230)
        Next
      End If
      '4. Get Final Stage Items & IRef

      Dim pkgDs As List(Of SIS.PAK.pakPKGListDIRef) = SIS.PAK.pakPKGListDIRef.GetDespatchedPKGListDIref(pp)
      'update pmdl
      For Each pkgD As SIS.PAK.pakPKGListDIRef In pkgDs
        Dim tmp207 As New SIS.TPISG.tpisg207
        With tmp207
          .t_bohd = hndl
          .t_date = ct229.t_trdt
          .t_inid = pp.PkgNo
          .t_iref = pkgD.ItemReference
          .t_mode = 2  '=>Manual, 2=>Packing List
          .t_pono = pp.FK_PAK_PkgListH_SerialNo.PONumber
          .t_prpo = pkgD.ProgressPercent
          .t_powt = pkgD.TotalWeight
          .t_Refcntd = 0
          .t_Refcntu = 0
          .t_cprj = pp.FK_PAK_PkgListH_SerialNo.ProjectID
          .t_sitm = pkgD.SubItem
        End With
        SIS.TPISG.tpisg207.InsertData(tmp207)
      Next
      If errMsg <> "" Then
        Throw New Exception(errMsg)
      End If
    End Sub

    Public Shared Sub CT_ReceivedAtPort(ByVal pp As SIS.PAK.pakHPending)
      Dim errMsg As String = ""
      Dim ppPO As SIS.PAK.pakPO = pp.FK_PAK_PkgListH_SerialNo
      Dim hndl As String = "CT_RECEIPTATPORT"
      '1. Insert In tpisg229
      Dim ct229 As New SIS.TPISG.tpisg229
      With ct229
        .t_trdt = Now.ToString("dd/MM/yyyy HH:mm:ss")
        .t_bohd = hndl
        .t_indv = ppPO.SerialNo & "_" & ppPO.PONumber
        .t_srno = 1
        .t_proj = ppPO.ProjectID
        .t_elem = ""
        .t_user = pp.CreatedBy
        .t_stat = ""
        .t_Refcntd = 0
        .t_Refcntu = 0
      End With
      ct229 = SIS.TPISG.tpisg229.InsertData(ct229)
      '2. Insert In tpisg230
      Dim DSrn As Integer = 0
      Dim PODocs As List(Of SIS.DOCS.Document) = SIS.DOCS.Document.DocumentsSelectList(ppPO.PONumber)
      If PODocs.Count > 0 Then
        For Each PODoc As SIS.DOCS.Document In PODocs
          DSrn += 1
          Dim ct230 As New SIS.TPISG.tpisg230
          With ct230
            .t_trdt = ct229.t_trdt
            .t_bohd = hndl
            .t_indv = ppPO.SerialNo & "_" & ppPO.PONumber
            .t_srno = 1
            .t_dsno = DSrn
            .t_dwno = PODoc.t_docn
            .t_elem = ""
            .t_proj = ppPO.ProjectID
            .t_wght = 0
            .t_pitc = 0
            .t_stat = ""
            .t_atcd = ""
            .t_scup = 0
            .t_acdt = "01/01/1753"
            .t_acfh = "01/01/1753"
            .t_pper = 0
            .t_lupd = "01/01/1753"
            .t_Refcntd = 0
            .t_Refcntu = 0
            .t_numo = 0
            .t_numq = 0
            .t_numt = 0
            .t_numv = 0
            .t_nutc = 0
            .t_cuni = ""
            .t_iref = ""
            .t_quan = 0
            .t_iuom = ""
          End With
          ct230 = SIS.TPISG.tpisg230.InsertData(ct230)
        Next
      End If
      '4. Get Final Stage Items & IRef

      Dim pkgDs As List(Of SIS.PAK.pakPKGListDIRef) = SIS.PAK.pakPKGListDIRef.GetDespatchedPKGListDIref(pp)
      'update pmdl
      For Each pkgD As SIS.PAK.pakPKGListDIRef In pkgDs
        Dim tmp207 As New SIS.TPISG.tpisg207
        With tmp207
          .t_bohd = hndl
          .t_date = ct229.t_trdt
          .t_inid = pp.PkgNo
          .t_iref = pkgD.ItemReference
          .t_mode = 2  '=>Manual, 2=>Packing List
          .t_pono = pp.FK_PAK_PkgListH_SerialNo.PONumber
          .t_prpo = pkgD.ProgressPercent
          .t_powt = pkgD.TotalWeight
          .t_Refcntd = 0
          .t_Refcntu = 0
          .t_cprj = pp.FK_PAK_PkgListH_SerialNo.ProjectID
          .t_sitm = pkgD.SubItem
        End With
        SIS.TPISG.tpisg207.InsertData(tmp207)
      Next
      If errMsg <> "" Then
        Throw New Exception(errMsg)
      End If
    End Sub
    Public Shared Sub CT_Shipped(ByVal pp As SIS.PAK.pakPkgListH)
      Dim errMsg As String = ""
      Dim hndl As String = "CT_SHIPMENT"
      Dim trdt As String = Now.ToString("dd/MM/yyyy HH:mm:ss")
      Dim pkgDs As List(Of SIS.PAK.pakPKGListDIRef) = SIS.PAK.pakPKGListDIRef.GetDespatchedPKGPortDIref(pp.PkgNo)
      For Each pkgD As SIS.PAK.pakPKGListDIRef In pkgDs
        Dim tmp207 As New SIS.TPISG.tpisg207
        With tmp207
          .t_bohd = hndl
          .t_date = trdt
          .t_inid = pkgD.SerialNo & "_" & pkgD.PKGNo
          .t_iref = pkgD.ItemReference
          .t_mode = 2  '=>Manual, 2=>Packing List
          .t_pono = SIS.PAK.pakPO.pakPOGetByID(pkgD.SerialNo).PONumber
          .t_prpo = pkgD.ProgressPercent
          .t_powt = pkgD.TotalWeight
          .t_Refcntd = 0
          .t_Refcntu = 0
          .t_cprj = SIS.PAK.pakPO.pakPOGetByID(pkgD.SerialNo).ProjectID
          .t_sitm = pkgD.SubItem
        End With
        Try
          SIS.TPISG.tpisg207.InsertData(tmp207)
        Catch ex As Exception
          Throw New Exception(ex.Message)
        End Try
      Next
    End Sub

    Public Shared Sub CT_ReceivedAtSite(ByVal pp As SIS.PAK.pakSitePkgH)
      Dim errMsg As String = ""
      Dim hndl As String = "CT_RECEIPTATSITE"
      Dim trdt As String = Now.ToString("dd/MM/yyyy HH:mm:ss")
      Dim pkgDs As List(Of SIS.PAK.pakPKGListDIRef) = SIS.PAK.pakPKGListDIRef.GetReceivedPKGSiteDIref(pp.PkgNo)
      For Each pkgD As SIS.PAK.pakPKGListDIRef In pkgDs
        Dim tmp207 As New SIS.TPISG.tpisg207
        With tmp207
          .t_bohd = hndl
          .t_date = trdt
          .t_inid = pkgD.SerialNo & "_" & pkgD.PKGNo
          .t_iref = pkgD.ItemReference
          .t_mode = 2  '=>Manual, 2=>Packing List
          .t_pono = SIS.PAK.pakPO.pakPOGetByID(pkgD.SerialNo).PONumber
          .t_prpo = pkgD.ProgressPercent
          .t_powt = pkgD.TotalWeight
          .t_Refcntd = 0
          .t_Refcntu = 0
          .t_cprj = SIS.PAK.pakPO.pakPOGetByID(pkgD.SerialNo).ProjectID
          .t_sitm = pkgD.SubItem
        End With
        Try
          SIS.TPISG.tpisg207.InsertData(tmp207)
        Catch ex As Exception
          Throw New Exception(ex.Message)
        End Try
      Next
    End Sub

  End Class
End Namespace

'Dim POs As List(Of SIS.PAK.pakPkgListD) = SIS.PAK.pakPkgListD.PortDespatchedPO(pp.PkgNo)
'For Each po As SIS.PAK.pakPkgListD In POs
'  Dim ppPO As SIS.PAK.pakPO = po.FK_PAK_PkgListD_SerialNo
'  '1. Insert In tpisg229
'  Dim ct229 As New SIS.TPISG.tpisg229
'  With ct229
'    .t_trdt = trdt
'    .t_bohd = hndl
'    .t_indv = ppPO.SerialNo & "_" & ppPO.PONumber
'    .t_srno = 1
'    .t_proj = ppPO.ProjectID
'    .t_elem = ""
'    .t_user = pp.CreatedBy
'    .t_stat = ""
'    .t_Refcntd = 0
'    .t_Refcntu = 0
'  End With
'  ct229 = SIS.TPISG.tpisg229.InsertData(ct229)
'  '2. Insert In tpisg230
'  Dim DSrn As Integer = 0
'  Dim PODocs As List(Of SIS.DOCS.Document) = SIS.DOCS.Document.DocumentsSelectList(ppPO.PONumber)
'  If PODocs.Count > 0 Then
'    For Each PODoc As SIS.DOCS.Document In PODocs
'      DSrn += 1
'      Dim ct230 As New SIS.TPISG.tpisg230
'      With ct230
'        .t_trdt = ct229.t_trdt
'        .t_bohd = hndl
'        .t_indv = ppPO.SerialNo & "_" & ppPO.PONumber
'        .t_srno = 1
'        .t_dsno = DSrn
'        .t_dwno = PODoc.t_docn
'        .t_elem = ""
'        .t_proj = ppPO.ProjectID
'        .t_wght = 0
'        .t_pitc = 0
'        .t_stat = ""
'        .t_atcd = ""
'        .t_scup = 0
'        .t_acdt = "01/01/1753"
'        .t_acfh = "01/01/1753"
'        .t_pper = 0
'        .t_lupd = "01/01/1753"
'        .t_Refcntd = 0
'        .t_Refcntu = 0
'        .t_numo = 0
'        .t_numq = 0
'        .t_numt = 0
'        .t_numv = 0
'        .t_nutc = 0
'        .t_cuni = ""
'        .t_iref = ""
'        .t_quan = 0
'        .t_iuom = ""
'      End With
'      ct230 = SIS.TPISG.tpisg230.InsertData(ct230)
'    Next
'  End If
'Next
