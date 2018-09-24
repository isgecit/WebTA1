Partial Class EF_taBDLodging
  Inherits SIS.SYS.UpdateBase
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
  Public Property Editable() As Boolean
    Get
      If ViewState("Editable") IsNot Nothing Then
        Return CType(ViewState("Editable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Editable", value)
    End Set
  End Property
  Public Property Deleteable() As Boolean
    Get
      If ViewState("Deleteable") IsNot Nothing Then
        Return CType(ViewState("Deleteable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Deleteable", value)
    End Set
  End Property
  Public Property PrimaryKey() As String
    Get
      If ViewState("PrimaryKey") IsNot Nothing Then
        Return CType(ViewState("PrimaryKey"), String)
      End If
      Return True
    End Get
    Set(ByVal value As String)
      ViewState.Add("PrimaryKey", value)
    End Set
  End Property
  Protected Sub ODStaBDLodging_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaBDLodging.Selected
    Dim tmp As SIS.TA.taBDLodging = CType(e.ReturnValue, SIS.TA.taBDLodging)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaBDLodging_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBDLodging.Init
    DataClassName = "EtaBDLodging"
    SetFormView = FVtaBDLodging
  End Sub
  Protected Sub TBLtaBDLodging_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaBDLodging.Init
    SetToolBar = TBLtaBDLodging
  End Sub
  Protected Sub FVtaBDLodging_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBDLodging.PreRender
    TBLtaBDLodging.EnableSave = Editable
    TBLtaBDLodging.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taBDLodging.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaBDLodging") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaBDLodging", mStr)
    End If
    Try
      Dim tmp As SIS.TA.taBH = SIS.TA.taBH.taBHGetByID(Request.QueryString("TABillNo"))
      Dim tmp1 As LC_taCurrencies = CType(FVtaBDLodging.FindControl("F_CurrencyID"), LC_taCurrencies)
      Dim tmp2 As Label = CType(FVtaBDLodging.FindControl("F_CurrencyMain"), Label)
      'tmp1.SelectedValue = tmp.BillCurrencyID
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
        Dim StayedInHotel As CheckBox = CType(FVtaBDLodging.FindControl("F_StayedInHotel"), CheckBox)
        If StayedInHotel.Checked Then
          CType(FVtaBDLodging.FindControl("pnlGST"), Panel).Visible = True
        End If
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
  Public Shared Function City1IDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taCities.SelecttaCitiesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_TA_BillDetails_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_TA_BillDetails_City1ID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim City1ID As String = CType(aVal(1),String)
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
