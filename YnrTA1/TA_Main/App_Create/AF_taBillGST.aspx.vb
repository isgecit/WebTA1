Partial Class AF_taBillGST
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaBillGST_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBillGST.Init
    DataClassName = "AtaBillGST"
    SetFormView = FVtaBillGST
  End Sub
  Protected Sub TBLtaBillGST_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaBillGST.Init
    SetToolBar = TBLtaBillGST
  End Sub
  Protected Sub FVtaBillGST_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBillGST.DataBound
    SIS.TA.taBillGST.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaBillGST_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBillGST.PreRender
    Dim oF_TABillNo_Display As Label  = FVtaBillGST.FindControl("F_TABillNo_Display")
    Dim oF_TABillNo As TextBox  = FVtaBillGST.FindControl("F_TABillNo")
    Dim oF_SerialNo_Display As Label  = FVtaBillGST.FindControl("F_SerialNo_Display")
    Dim oF_SerialNo As TextBox  = FVtaBillGST.FindControl("F_SerialNo")
    Dim oF_BPID_Display As Label  = FVtaBillGST.FindControl("F_BPID_Display")
    Dim oF_BPID As TextBox  = FVtaBillGST.FindControl("F_BPID")
    Dim oF_SupplierGSTIN_Display As Label  = FVtaBillGST.FindControl("F_SupplierGSTIN_Display")
    Dim oF_SupplierGSTIN As TextBox  = FVtaBillGST.FindControl("F_SupplierGSTIN")
    Dim oF_HSNSACCode_Display As Label  = FVtaBillGST.FindControl("F_HSNSACCode_Display")
    Dim oF_HSNSACCode As TextBox  = FVtaBillGST.FindControl("F_HSNSACCode")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taBillGST.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaBillGST") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaBillGST", mStr)
    End If
    If Request.QueryString("TABillNo") IsNot Nothing Then
      CType(FVtaBillGST.FindControl("F_TABillNo"), TextBox).Text = Request.QueryString("TABillNo")
      CType(FVtaBillGST.FindControl("F_TABillNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVtaBillGST.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVtaBillGST.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function TABillNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taBH.SelecttaBHAutoCompleteList(prefixText, count, contextKey)
  End Function
  '<System.Web.Services.WebMethod()> _
  '<System.Web.Script.Services.ScriptMethod()> _
  'Public Shared Function SerialNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
  '  Return SIS.TA.taBillDetails.SelecttaBillDetailsAutoCompleteList(prefixText, count, contextKey)
  'End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function BPIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.SPMT.spmtBusinessPartner.SelectspmtBusinessPartnerAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SupplierGSTINCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.SPMT.spmtBPGSTIN.SelectspmtBPGSTINAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function HSNSACCodeCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.SPMT.spmtHSNSACCodes.SelectspmtHSNSACCodesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_TA_BillGST_HSNSACCode(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim BillType As Int32 = CType(aVal(1),Int32)
    Dim HSNSACCode As String = CType(aVal(2),String)
    Dim oVar As SIS.SPMT.spmtHSNSACCodes = SIS.SPMT.spmtHSNSACCodes.spmtHSNSACCodesGetByID(BillType,HSNSACCode)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_TA_BillGST_SerialNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim TABillNo As Int32 = CType(aVal(1),Int32)
    Dim SerialNo As Int32 = CType(aVal(2),Int32)
    Dim oVar As SIS.TA.taBillDetails = SIS.TA.taBillDetails.taBillDetailsGetByID(TABillNo,SerialNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_TA_BillGST_TABillNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim TABillNo As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.TA.taBH = SIS.TA.taBH.taBHGetByID(TABillNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_TA_BillGST_SupplierGSTIN(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim BPID As String = CType(aVal(1),String)
    Dim SupplierGSTIN As Int32 = CType(aVal(2),Int32)
    Dim oVar As SIS.SPMT.spmtBPGSTIN = SIS.SPMT.spmtBPGSTIN.spmtBPGSTINGetByID(BPID,SupplierGSTIN)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_TA_BillGST_BPID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim BPID As String = CType(aVal(1),String)
    Dim oVar As SIS.SPMT.spmtBusinessPartner = SIS.SPMT.spmtBusinessPartner.spmtBusinessPartnerGetByID(BPID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
