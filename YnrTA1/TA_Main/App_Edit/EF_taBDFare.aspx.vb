Partial Class EF_taBDFare
  Inherits SIS.SYS.UpdateBase
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
  Protected Sub ODStaBDFare_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaBDFare.Selected
    Dim tmp As SIS.TA.taBDFare = CType(e.ReturnValue, SIS.TA.taBDFare)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaBDFare_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBDFare.Init
    DataClassName = "EtaBDFare"
    SetFormView = FVtaBDFare
  End Sub
  Protected Sub TBLtaBDFare_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaBDFare.Init
    SetToolBar = TBLtaBDFare
  End Sub
  Protected Sub FVtaBDFare_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBDFare.PreRender
    TBLtaBDFare.EnableSave = Editable
    TBLtaBDFare.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taBDFare.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaBDFare") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaBDFare", mStr)
    End If
    Try
      Dim tmp As SIS.TA.taBH = SIS.TA.taBH.taBHGetByID(Request.QueryString("TABillNo"))
      Dim tmp1 As LC_taCurrencies = CType(FVtaBDFare.FindControl("F_CurrencyID"), LC_taCurrencies)
      Dim tmp2 As Label = CType(FVtaBDFare.FindControl("F_CurrencyMain"), Label)
      'tmp1.SelectedValue = tmp.BillCurrencyID
      tmp2.Text = tmp.BillCurrencyID
      If tmp.TravelTypeID = TATravelTypeValues.Domestic Then
        Dim tmp3 As Label = CType(FVtaBDFare.FindControl("L_CurrencyID"), Label)
        Dim tmp4 As HtmlTableRow = CType(FVtaBDFare.FindControl("ouc"), HtmlTableRow)
        Dim tmp5 As TextBox = CType(FVtaBDFare.FindControl("F_ConversionFactorINR"), TextBox)
        tmp1.Enabled = False
        tmp3.Attributes.Add("style", "display:none")
        tmp4.Attributes.Add("style", "display:none")
        tmp5.Enabled = False
      End If
    Catch ex As Exception

    End Try
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function City1IDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taCities.SelecttaCitiesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function City2IDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
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
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_TA_BillDetails_City2ID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim City2ID As String = CType(aVal(1),String)
    Dim oVar As SIS.TA.taCities = SIS.TA.taCities.taCitiesGetByID(City2ID)
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
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_TA_BillDetails_Country2ID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim Country2ID As String = CType(aVal(1), String)
    Dim oVar As SIS.TA.taCountries = SIS.TA.taCountries.taCountriesGetByID(Country2ID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function Country2IDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taCountries.SelecttaCountriesAutoCompleteList(prefixText, count, contextKey)
  End Function

End Class
