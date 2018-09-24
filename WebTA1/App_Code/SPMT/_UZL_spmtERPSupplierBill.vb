Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.SPMT

  Public Class spmtERPSupplierBill
    'Public Property SourceApplication As String = ""
    Public Property IRNo As Int32 = 0
    Public Property IRReceivedOn As String = ""
    Public Property TranTypeID As String = ""
    Public Property BillNumber As String = ""
    Public Property BillDate As String = ""
    Public Property BillRemarks As String = ""
    Public Property RemarksAC As String = ""
    Public Property AdviceNo As Int32 = 0
    Public Property ConcernedHOD As String = ""
    Public Property ProjectID As String = ""
    Public Property ElementID As String = ""
    Public Property EmployeeID As String = ""
    Public Property DepartmentID As String = ""
    Public Property CostCenterID As String = ""
    Public Property IsgecGSTIN As Int32 = 0
    Public Property SupplierGSTIN As Int32 = 0
    Public Property BPID As String = ""
    Public Property HSNSACCode As String = ""
    Public Property UOM As String = ""
    Public Property BillType As Int32 = 0
    Public Property ShipToState As String = ""
    Public Property Quantity As Double = 0
    Public Property AssessableValue As Double = 0
    Public Property TaxAmount As Double = 0
    Public Property CessRate As Double = 0
    Public Property CessAmount As Double = 0
    Public Property TotalGST As Double = 0
    Public Property TotalAmount As Double = 0
    Public Property RemarksGST As String = ""
    Public Property Currency As String = ""
    Public Property ConversionFactorINR As Double = 0
    Public Property TotalAmountINR As Double = 0
    Public Property PurchaseType As String = ""
    Public Property IGSTRate As Double = 0
    Public Property IGSTAmount As Double = 0
    Public Property SGSTRate As Double = 0
    Public Property SGSTAmount As Double = 0
    Public Property CGSTRate As Double = 0
    Public Property CGSTAmount As Double = 0
    Public Property DocumentNo As String = ""
    Public Property BaaNCompany As Int32 = 0
    Public Property BaaNLedger As Int32 = 0
    Public Property UploadedBy As String = ""
    Public Property UploadedOn As String = ""
    Public Property DocNo As String = ""
    Public Property SupplierName As String = ""
    Public Property SupplierGSTINNumber As String = ""
    Public Property AdvanceRate As String = "0.00"
    Public Property AdvanceAmount As String = "0.00"
    Public Property RetensionRate As String = "0.00"
    Public Property RetensionAmount As String = "0.00"
    Public Property BillStatusUser As String = ""
    Public Property aspnet_Users1_UserFullName As String = ""
    Public Property temp_ShipToState As String = ""

    'Public Shared Function GetSupplierBill(ByVal Source As SIS.SPMT.spmtERPSupplierBill, ByVal Target As SIS.SPMT.spmtSupplierBill) As SIS.SPMT.spmtSupplierBill
    '  Try
    '    For Each pi As System.Reflection.PropertyInfo In Target.GetType.GetProperties
    '      If pi.MemberType = Reflection.MemberTypes.Property Then
    '        Try
    '          CallByName(Target, pi.Name, CallType.Let, CallByName(Source, pi.Name, CallType.Get))
    '        Catch ex As Exception
    '        End Try
    '      End If
    '    Next
    '  Catch ex As Exception
    '  End Try
    '  Return Target
    'End Function

    'Public Shared Function GetPaymentAdvice(ByVal Source As SIS.SPMT.spmtERPSupplierBill, ByVal Target As SIS.SPMT.spmtPaymentAdvice) As SIS.SPMT.spmtPaymentAdvice
    '  Try
    '    For Each pi As System.Reflection.PropertyInfo In Target.GetType.GetProperties
    '      If pi.MemberType = Reflection.MemberTypes.Property Then
    '        Try
    '          CallByName(Target, pi.Name, CallType.Let, CallByName(Source, pi.Name, CallType.Get))
    '        Catch ex As Exception
    '        End Try
    '      End If
    '    Next
    '  Catch ex As Exception
    '  End Try
    '  Return Target
    'End Function

    'Public Shared Function GetERPBill(ByVal Source As SIS.SPMT.spmtPaymentAdvice, ByVal Target As SIS.SPMT.spmtERPSupplierBill) As SIS.SPMT.spmtERPSupplierBill
    '  Try
    '    For Each pi As System.Reflection.PropertyInfo In Target.GetType.GetProperties
    '      If pi.MemberType = Reflection.MemberTypes.Property Then
    '        Try
    '          Dim si As System.Reflection.PropertyInfo = Source.GetType.GetProperty(pi.Name)
    '          Dim _tskip As SIS.SYS.Utilities.lgSkipAttribute = Attribute.GetCustomAttribute(si, GetType(SIS.SYS.Utilities.lgSkipAttribute))
    '          If _tskip IsNot Nothing Then Continue For
    '          CallByName(Target, pi.Name, CallType.Let, CallByName(Source, pi.Name, CallType.Get))
    '        Catch ex As Exception
    '        End Try
    '      End If
    '    Next
    '  Catch ex As Exception
    '    Dim aa As String = ex.Message
    '  End Try
    '  Return Target
    'End Function

    'Public Shared Function GetERPBill(ByVal Source As SIS.SPMT.spmtSupplierBill, ByVal Target As SIS.SPMT.spmtERPSupplierBill) As SIS.SPMT.spmtERPSupplierBill
    '  Try
    '    For Each pi As System.Reflection.PropertyInfo In Target.GetType.GetProperties
    '      If pi.MemberType = Reflection.MemberTypes.Property Then
    '        Try
    '          Dim si As System.Reflection.PropertyInfo = Source.GetType.GetProperty(pi.Name)
    '          Dim _tskip As SIS.SYS.Utilities.lgSkipAttribute = Attribute.GetCustomAttribute(si, GetType(SIS.SYS.Utilities.lgSkipAttribute))
    '          If _tskip IsNot Nothing Then Continue For
    '          CallByName(Target, pi.Name, CallType.Let, CallByName(Source, pi.Name, CallType.Get))
    '        Catch ex As Exception
    '        End Try
    '      End If
    '    Next
    '    Try
    '      If Source.TranTypeID <> "HTL" Then
    '        Target.ShipToState = Source.SPMT_IsgecGSTIN13_Description.Substring(0, 2)
    '      Else
    '        If Source.VR_BPGSTIN17_Description <> "" Then
    '          Target.ShipToState = Source.VR_BPGSTIN17_Description.Substring(0, 2)
    '        Else
    '          Target.ShipToState = Source.SupplierGSTINNumber.Substring(0, 2)
    '        End If
    '      End If
    '    Catch exx As Exception
    '    End Try
    '    Try
    '      If Source.SupplierName = String.Empty Then
    '        Target.SupplierName = Source.VR_BusinessPartner18_BPName
    '      End If
    '    Catch ex As Exception
    '    End Try
    '  Catch ex As Exception
    '    Dim aa As String = ex.Message
    '  End Try
    '  Return Target
    'End Function
    Public Shared Function GetUPDInERP(ByVal Rec As SIS.SPMT.spmtERPSupplierBill) As SIS.SPMT.spmtUPDInERP
      Dim ERP As New SIS.SPMT.spmtUPDInERP
      ERP.t_sour = Rec.DocNo
      ERP.t_ninv = Rec.IRNo
      ERP.t_irdt = Rec.IRReceivedOn
      ERP.t_type = Rec.TranTypeID
      ERP.t_isup = Rec.BillNumber
      ERP.t_idat = Rec.BillDate
      ERP.t_brmk = Rec.BillRemarks
      ERP.t_brac = Rec.RemarksAC
      ERP.t_payd = Rec.AdviceNo
      ERP.t_hodc = Rec.ConcernedHOD
      ERP.t_cprj = Rec.ProjectID
      ERP.t_cspa = Rec.ElementID
      ERP.t_emno = Rec.EmployeeID
      ERP.t_cofc = Rec.DepartmentID
      ERP.t_dimx = Rec.CostCenterID
      Try
        ERP.t_gstn_c = SIS.SPMT.spmtIsgecGSTIN.spmtIsgecGSTINGetByID(Rec.IsgecGSTIN).Description
      Catch ex As Exception
      End Try
      ERP.t_nama = Rec.SupplierName
      Try
        If Rec.BPID <> String.Empty Then
          ERP.t_gstn_b = SIS.SPMT.spmtBPGSTIN.spmtBPGSTINGetByID(Rec.BPID, Rec.SupplierGSTIN).Description
        Else
          ERP.t_gstn_b = Rec.SupplierGSTINNumber
        End If
      Catch ex As Exception
      End Try
      ERP.t_ifbp = Rec.BPID
      ERP.t_code = Rec.HSNSACCode
      ERP.t_unit = Rec.UOM
      ERP.t_ityp = Rec.BillType
      ERP.t_sste = Rec.temp_ShipToState
      ERP.t_qnty = Rec.Quantity
      ERP.t_assv = Rec.AssessableValue
      ERP.t_vamt = Rec.TaxAmount
      ERP.t_cess = Rec.CessRate
      ERP.t_cmnt = Rec.CessAmount
      ERP.t_tgst = Rec.TotalGST
      ERP.t_tamt = Rec.TotalAmount
      ERP.t_grmk = Rec.RemarksGST
      ERP.t_ccur = Rec.Currency
      ERP.t_conv = Rec.ConversionFactorINR
      ERP.t_tamh = Rec.TotalAmountINR
      ERP.t_ptyp = Rec.PurchaseType
      ERP.t_irat = Rec.IGSTRate
      ERP.t_iamt = Rec.IGSTAmount
      ERP.t_srat = Rec.SGSTRate
      ERP.t_samt = Rec.SGSTAmount
      ERP.t_crat = Rec.CGSTRate
      ERP.t_camt = Rec.CGSTAmount
      ERP.t_ttyp = Rec.DocumentNo
      ERP.t_docn = Rec.BaaNCompany
      ERP.t_comp = Rec.BaaNLedger
      ERP.t_upby = Rec.UploadedBy
      ERP.t_updt = Rec.UploadedOn
      ERP.t_ucod = Rec.BillStatusUser
      ERP.t_unam = Rec.aspnet_Users1_UserFullName
      ERP.t_posu = Rec.ShipToState
      Return ERP
    End Function

    Public Shared Function GetERPBill(ByVal ERP As SIS.SPMT.spmtUPDInERP) As SIS.SPMT.spmtERPSupplierBill
      Dim Rec As New SIS.SPMT.spmtERPSupplierBill
      Rec.DocNo = ERP.t_sour
      Rec.IRNo = ERP.t_ninv
      Rec.IRReceivedOn = ERP.t_irdt
      Rec.TranTypeID = ERP.t_type
      Rec.BillNumber = ERP.t_isup
      Rec.BillDate = ERP.t_idat
      Rec.BillRemarks = ERP.t_brmk
      Rec.RemarksAC = ERP.t_brac
      Rec.AdviceNo = ERP.t_payd
      Rec.ConcernedHOD = ERP.t_hodc
      Rec.ProjectID = ERP.t_cprj
      Rec.ElementID = ERP.t_cspa
      Rec.EmployeeID = ERP.t_emno
      Rec.DepartmentID = ERP.t_cofc
      Rec.CostCenterID = ERP.t_dimx
      Try
        Rec.IsgecGSTIN = SIS.SPMT.spmtIsgecGSTIN.spmtIsgecGSTINGetByGSTIN(ERP.t_gstn_c).GSTID
      Catch ex As Exception
      End Try
      Try
        If ERP.t_ifbp <> "" Then
          Rec.SupplierGSTIN = SIS.SPMT.spmtBPGSTIN.spmtBPGSTINGetByGSTIN(ERP.t_gstn_b).GSTIN
        Else
          Rec.SupplierGSTINNumber = ERP.t_gstn_b
        End If
      Catch ex As Exception
      End Try
      Rec.BPID = ERP.t_ifbp
      Rec.HSNSACCode = ERP.t_code
      Rec.UOM = ERP.t_unit
      Rec.BillType = ERP.t_ityp
      Rec.ShipToState = ERP.t_posu
      Rec.Quantity = ERP.t_qnty
      Rec.AssessableValue = ERP.t_assv
      Rec.TaxAmount = ERP.t_vamt
      Rec.CessRate = ERP.t_cess
      Rec.CessAmount = ERP.t_cmnt
      Rec.TotalGST = ERP.t_tgst
      Rec.TotalAmount = ERP.t_tamt
      Rec.RemarksGST = ERP.t_grmk
      Rec.Currency = ERP.t_ccur
      Rec.ConversionFactorINR = ERP.t_conv
      Rec.TotalAmountINR = ERP.t_tamh
      Rec.PurchaseType = ERP.t_ptyp
      Rec.IGSTRate = ERP.t_irat
      Rec.IGSTAmount = ERP.t_iamt
      Rec.SGSTRate = ERP.t_srat
      Rec.SGSTAmount = ERP.t_samt
      Rec.CGSTRate = ERP.t_crat
      Rec.CGSTAmount = ERP.t_camt
      Rec.DocumentNo = ERP.t_ttyp
      Rec.BaaNCompany = ERP.t_docn
      Rec.BaaNLedger = ERP.t_comp
      Rec.UploadedBy = ERP.t_upby
      Rec.UploadedOn = ERP.t_updt
      Rec.BillStatusUser = ERP.t_ucod
      Rec.aspnet_Users1_UserFullName = ERP.t_unam
      Return Rec
    End Function

    Sub New()
      'dummy
    End Sub
  End Class
End Namespace