Imports System.Web.Script.Serialization
Partial Class AF_taBDLodging
  Inherits SIS.SYS.InsertBase
  Public Property TravelType As String
    Get
      If ViewState("TravelType") IsNot Nothing Then
        Return Convert.ToString(ViewState("TravelType"))
      End If
      Return ""
    End Get
    Set(value As String)
      ViewState.Add("TravelType", value)
    End Set
  End Property
  Protected Sub FVtaBDLodging_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBDLodging.Init
    DataClassName = "AtaBDLodging"
    SetFormView = FVtaBDLodging
  End Sub
  Protected Sub TBLtaBDLodging_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaBDLodging.Init
    SetToolBar = TBLtaBDLodging
  End Sub
  Protected Sub FVtaBDLodging_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBDLodging.DataBound
    SIS.TA.taBDLodging.SetDefaultValues(sender, e)
    CType(FVtaBDLodging.FindControl("F_AssessableValue"), TextBox).Text = "0.00"
    CType(FVtaBDLodging.FindControl("F_CessRate"), TextBox).Text = "0.00"
    CType(FVtaBDLodging.FindControl("F_CessAmount"), TextBox).Text = "0.00"
    CType(FVtaBDLodging.FindControl("F_TotalGST"), TextBox).Text = "0.00"
    CType(FVtaBDLodging.FindControl("F_TotalAmount"), TextBox).Text = "0.00"
    CType(FVtaBDLodging.FindControl("F_IGSTRate"), TextBox).Text = "0.00"
    CType(FVtaBDLodging.FindControl("F_IGSTAmount"), TextBox).Text = "0.00"
    CType(FVtaBDLodging.FindControl("F_SGSTRate"), TextBox).Text = "0.00"
    CType(FVtaBDLodging.FindControl("F_SGSTAmount"), TextBox).Text = "0.00"
    CType(FVtaBDLodging.FindControl("F_CGSTRate"), TextBox).Text = "0.00"
    CType(FVtaBDLodging.FindControl("F_CGSTAmount"), TextBox).Text = "0.00"
  End Sub
  Protected Sub FVtaBDLodging_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBDLodging.PreRender
    Dim oF_TABillNo_Display As Label = FVtaBDLodging.FindControl("F_TABillNo_Display")
    oF_TABillNo_Display.Text = String.Empty
    If Not Session("F_TABillNo_Display") Is Nothing Then
      If Session("F_TABillNo_Display") <> String.Empty Then
        oF_TABillNo_Display.Text = Session("F_TABillNo_Display")
      End If
    End If
    Dim oF_TABillNo As TextBox = FVtaBDLodging.FindControl("F_TABillNo")
    oF_TABillNo.Enabled = True
    oF_TABillNo.Text = String.Empty
    If Not Session("F_TABillNo") Is Nothing Then
      If Session("F_TABillNo") <> String.Empty Then
        oF_TABillNo.Text = Session("F_TABillNo")
      End If
    End If
    Dim oF_City1ID_Display As Label = FVtaBDLodging.FindControl("F_City1ID_Display")
    Dim oF_City1ID As TextBox = FVtaBDLodging.FindControl("F_City1ID")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taBDLodging.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaBDLodging") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaBDLodging", mStr)
    End If
    If Request.QueryString("TABillNo") IsNot Nothing Then
      CType(FVtaBDLodging.FindControl("F_TABillNo"), TextBox).Text = Request.QueryString("TABillNo")
      CType(FVtaBDLodging.FindControl("F_TABillNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVtaBDLodging.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVtaBDLodging.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
    Try
      Dim tmp As SIS.TA.taBH = SIS.TA.taBH.taBHGetByID(Request.QueryString("TABillNo"))
      Dim tmp1 As LC_taCurrencies = CType(FVtaBDLodging.FindControl("F_CurrencyID"), LC_taCurrencies)
      Dim tmp2 As Label = CType(FVtaBDLodging.FindControl("F_CurrencyMain"), Label)
      tmp1.SelectedValue = tmp.BillCurrencyID
      tmp2.Text = tmp.BillCurrencyID

      TravelType = tmp.TravelTypeID
      If tmp.TravelTypeID = TATravelTypeValues.Domestic Then
        Dim tmp3 As Label = CType(FVtaBDLodging.FindControl("L_CurrencyID"), Label)
        Dim tmp4 As HtmlTableRow = CType(FVtaBDLodging.FindControl("ouc"), HtmlTableRow)
        Dim tmp5 As TextBox = CType(FVtaBDLodging.FindControl("F_ConversionFactorINR"), TextBox)
        tmp1.Enabled = False
        tmp3.Attributes.Add("style", "display:none")
        tmp4.Attributes.Add("style", "display:none")
        tmp5.Enabled = False
      End If
    Catch ex As Exception

    End Try
  End Sub
  Protected Sub StayedInHotel_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Dim x As CheckBox = CType(sender, CheckBox)
    CType(FVtaBDLodging.FindControl("pnlGST"), Panel).Visible = False
    If x.Checked Then
      If TravelType = TATravelTypeValues.Domestic Then
        CType(FVtaBDLodging.FindControl("pnlGST"), Panel).Visible = True
      End If
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function TABillNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taBH.SelecttaBHAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function City1IDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taCities.SelecttaCitiesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_TA_BillDetails_TABillNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim TABillNo As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.TA.taBH = SIS.TA.taBH.taBHGetByID(TABillNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_TA_BillDetails_City1ID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim City1ID As String = CType(aVal(1), String)
    Dim oVar As SIS.TA.taCities = SIS.TA.taCities.taCitiesGetByID(City1ID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function BPIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.SPMT.spmtBusinessPartner.SelectspmtBusinessPartnerAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function SupplierGSTINCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.SPMT.spmtBPGSTIN.SelectspmtBPGSTINAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function HSNSACCodeCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.SPMT.spmtHSNSACCodes.SelectspmtHSNSACCodesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_TA_BillGST_HSNSACCode(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim BillType As Int32 = CType(aVal(1), Int32)
    Dim HSNSACCode As String = CType(aVal(2), String)
    Dim oVar As SIS.SPMT.spmtHSNSACCodes = SIS.SPMT.spmtHSNSACCodes.spmtHSNSACCodesGetByID(BillType, HSNSACCode)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_TA_BillGST_SupplierGSTIN(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim BPID As String = CType(aVal(1), String)
    Dim SupplierGSTIN As Int32 = CType(aVal(2), Int32)
    Dim oVar As SIS.SPMT.spmtBPGSTIN = SIS.SPMT.spmtBPGSTIN.spmtBPGSTINGetByID(BPID, SupplierGSTIN)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_TA_BillGST_BPID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim BPID As String = CType(aVal(1), String)
    Dim oVar As SIS.SPMT.spmtBusinessPartner = SIS.SPMT.spmtBusinessPartner.spmtBusinessPartnerGetByID(BPID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function Country1IDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taCountries.SelecttaCountriesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_TA_BillDetails_Country1ID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim Country1ID As String = CType(aVal(1), String)
    Dim oVar As SIS.TA.taCountries = SIS.TA.taCountries.taCountriesGetByID(Country1ID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
End Class
