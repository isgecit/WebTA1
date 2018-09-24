Partial Class AF_taBDFare
  Inherits SIS.SYS.GridBase
  Public Property dtMaskType As String
    Get
      If ViewState("dtMaskType") IsNot Nothing Then
        Return Convert.ToString(ViewState("dtMaskType"))
      End If
      Return "DateTime"
    End Get
    Set(value As String)
      ViewState.Add("dtMaskType", value)
    End Set
  End Property

  Public Property dtMask As String
    Get
      If ViewState("dtMask") IsNot Nothing Then
        Return Convert.ToString(ViewState("dtMask"))
      End If
      Return "99/99/9999 99:99"
    End Get
    Set(value As String)
      ViewState.Add("dtMask", value)
    End Set
  End Property

  Public Property dtFormat As String
    Get
      If ViewState("dtFormat") IsNot Nothing Then
        Return Convert.ToString(ViewState("dtFormat"))
      End If
      Return "dd/MM/yyyy HH:mm"
    End Get
    Set(value As String)
      ViewState.Add("dtFormat", value)
    End Set
  End Property

  Public Property ShowAllColumns As Boolean
    Get
      If ViewState("ShowAllColumns") IsNot Nothing Then
        Return Convert.ToBoolean(ViewState("ShowAllColumns"))
      End If
      Return False
    End Get
    Set(value As Boolean)
      ViewState.Add("ShowAllColumns", value)
    End Set
  End Property
  Public Property dCssClass As String
    Get
      If ViewState("dCssClass") IsNot Nothing Then
        Return Convert.ToString(ViewState("dCssClass"))
      End If
      Return "dmytxt"
    End Get
    Set(value As String)
      ViewState.Add("dCssClass", value)
    End Set
  End Property
  Protected Sub GVtaBDFare_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaBDFare.Init
    DataClassName = "GtaBDFare"
    SetGridView = GVtaBDFare
  End Sub
  Protected Sub TBLtaBDFare_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaBDFare.Init
    SetToolBar = TBLtaBDFare
  End Sub
  Private Sub AF_taBDFare_Init(sender As Object, e As EventArgs) Handles Me.Init
    If Request.QueryString("TABillNo") IsNot Nothing Then
      F_TABillNo.Text = Request.QueryString("TABillNo")
      Dim otabh As SIS.TA.taBH = SIS.TA.taBH.taBHGetByID(Request.QueryString("TABillNo"))
      If otabh.TravelTypeID <> TATravelTypeValues.Domestic Then
        ShowAllColumns = True
        dCssClass = "mytxt"
        dtFormat = "dd/MM/yyyy"
        dtMask = "99/99/9999"
        dtMaskType = "Date"
      Else
        ShowAllColumns = False
        dCssClass = "dmytxt"
        dtFormat = "dd/MM/yyyy HH:mm"
        dtMask = "99/99/9999 99:99"
        dtMaskType = "DateTime"
      End If
    End If
  End Sub
  Private Sub AF_taBDFare_Load(sender As Object, e As EventArgs) Handles Me.Load
    Dim otabh As SIS.TA.taBH = SIS.TA.taBH.taBHGetByID(Request.QueryString("TABillNo"))
    If otabh.TravelTypeID <> TATravelTypeValues.Domestic Then
      ShowAllColumns = True
      dCssClass = "mytxt"
      dtFormat = "dd/MM/yyyy"
      dtMask = "99/99/9999"
      dtMaskType = "Date"
    Else
      ShowAllColumns = False
      dCssClass = "dmytxt"
      dtFormat = "dd/MM/yyyy HH:mm"
      dtMask = "99/99/9999 99:99"
      dtMaskType = "DateTime"
    End If
  End Sub
  Private Sub GVtaBDFare_PreRender(sender As Object, e As EventArgs) Handles GVtaBDFare.PreRender
    If Not ShowAllColumns Then
      With GVtaBDFare
        .Columns(7).Visible = False
        .Columns(9).Visible = False
      End With
    End If
  End Sub
  Private Sub GVtaBDFare_RowCreated(sender As Object, e As GridViewRowEventArgs) Handles GVtaBDFare.RowCreated
    If e.Row.RowType = DataControlRowType.DataRow Then
      If ShowAllColumns Then
        'Dim ce1 As AjaxControlToolkit.CalendarExtender = e.Row.FindControl("CEDate1Time")
        'Dim ce2 As AjaxControlToolkit.CalendarExtender = e.Row.FindControl("CEDate2Time")
        'Dim me1 As AjaxControlToolkit.MaskedEditExtender = e.Row.FindControl("MEEDate1Time")
        'Dim me2 As AjaxControlToolkit.MaskedEditExtender = e.Row.FindControl("MEEDate2Time")
        'ce1.Format = "dd/MM/yyyy"
        'me1.Mask = "99/99/9999"
        'me1.MaskType = AjaxControlToolkit.MaskedEditType.Date
        'ce2.Format = "dd/MM/yyyy"
        'me2.Mask = "99/99/9999"
        'me2.MaskType = AjaxControlToolkit.MaskedEditType.Date
      End If
    End If
  End Sub

  Private Sub TBLtaBDFare_SaveClicked(sender As Object, e As ImageClickEventArgs) Handles TBLtaBDFare.SaveClicked
    Dim OK As Boolean = True
    Dim AnySaved As Boolean = False
    Dim sTmps As New List(Of SIS.TA.taBDFare)
    With GVtaBDFare
      For Each r As GridViewRow In .Rows
        If Convert.ToBoolean(CType(r.FindControl("F_Saved"), Label).Text) Then Continue For
        CType(r.FindControl("errMsg"), Label).Text = ""
        Dim x As SIS.TA.taBDFare = GetObjectFromRow(r)
        If x.City1ID = String.Empty Then
          If ShowAllColumns Then
            If x.City1Text = String.Empty Or x.Country1ID = String.Empty Then
              Continue For
            End If
          Else
            If x.City1Text = String.Empty Then
              Continue For
            End If
          End If
        End If
        If x.City2ID = String.Empty Then
          If ShowAllColumns Then
            If x.City2Text = String.Empty Or x.Country2ID = String.Empty Then
              Continue For
            End If
          Else
            If x.City2Text = String.Empty Then
              Continue For
            End If
          End If
        End If
        If x.Date1Time = String.Empty Then Continue For
        If x.Date2Time = String.Empty Then Continue For
        If x.ConversionFactorOU <= 0 Then x.ConversionFactorOU = 1
        x.TABillNo = F_TABillNo.Text
        sTmps.Add(x)
      Next
      For Each x As SIS.TA.taBDFare In sTmps
        Try
          SIS.TA.taBDFare.ValidateFare(x)
        Catch ex As Exception
          CType(.Rows(x.SerialNo - 1).FindControl("errMsg"), Label).Text = ex.Message
          OK = False
        End Try
      Next
      For Each x As SIS.TA.taBDFare In sTmps
        Try
          If ValidateTmpFare(x, sTmps) Then
            Dim L As Label = CType(.Rows(x.SerialNo - 1).FindControl("errMsg"), Label)
            If L.Text = String.Empty Then
              L.Text = "***RECORD IS OK*** [Pl. make correction in other records.]"
              L.ForeColor = Drawing.Color.DarkGreen
            End If
          End If
        Catch ex As Exception
          Dim L As Label = CType(.Rows(x.SerialNo - 1).FindControl("errMsg"), Label)
          If L.Text = String.Empty Then
            L.Text = ex.Message
          End If
          OK = False
        End Try
      Next
      If OK Then
        Dim i As Integer = 0
        For Each x As SIS.TA.taBDFare In sTmps
          i = x.SerialNo - 1
          x.SerialNo = 0
          Try
            x = SIS.TA.taBDFare.UZ_taBDFareInsert(x)
            CType(.Rows(i).FindControl("F_Saved"), Label).Text = True
            CType(.Rows(i).FindControl("F_SerialNo"), Label).Text = x.SerialNo
            Dim L As Label = CType(.Rows(i).FindControl("errMsg"), Label)
            L.Text = "***SAVED***"
            L.ForeColor = Drawing.Color.DarkGreen
          Catch ex As Exception
            CType(.Rows(i).FindControl("errMsg"), Label).Text = ex.Message
            OK = False
          End Try
        Next
      End If
      If OK Then
        SIS.TA.taBH.ValidateTABill(F_TABillNo.Text)
        MyBase.Saved()
      End If
    End With
  End Sub
  Private Function ValidateTmpFare(ByVal tmp As SIS.TA.taBDFare, ByVal sTmps As List(Of SIS.TA.taBDFare)) As Boolean
    Dim mRet As Boolean = True
    Dim ci As System.Globalization.CultureInfo = SIS.SYS.Utilities.SessionManager.ci
    If Convert.ToDateTime(tmp.Date1Time, ci) > Convert.ToDateTime(tmp.Date2Time, ci) Then
      Throw New Exception("Journey End Date-Time CAN NOT be less than Start Date-Time")
      mRet = False
      Return mRet
    End If
    'Check existing Journey Records
    'Check all overlapping Date Time Records
    For Each sTmp As SIS.TA.taBDFare In sTmps
      If sTmp.SerialNo = tmp.SerialNo Then Continue For
      If (Convert.ToDateTime(tmp.Date1Time, ci) >= Convert.ToDateTime(sTmp.Date1Time, ci) And Convert.ToDateTime(tmp.Date1Time, ci) <= Convert.ToDateTime(sTmp.Date2Time, ci)) Then
        Throw New Exception("Departure Date-Time is conflicting with " & sTmp.TA_Components9_Description & " Record No.: " & sTmp.SerialNo)
      End If
      If (Convert.ToDateTime(sTmp.Date1Time, ci) >= Convert.ToDateTime(tmp.Date1Time, ci) And Convert.ToDateTime(sTmp.Date1Time, ci) <= Convert.ToDateTime(tmp.Date2Time, ci)) Then
        Throw New Exception("Arrival Date-Time is conflicting with " & sTmp.TA_Components9_Description & " Record No.: " & sTmp.SerialNo)
      End If
      If (Convert.ToDateTime(tmp.Date2Time, ci) >= Convert.ToDateTime(sTmp.Date1Time, ci) And Convert.ToDateTime(tmp.Date2Time, ci) <= Convert.ToDateTime(sTmp.Date2Time, ci)) Then
        Throw New Exception("Arrival Date-Time is conflicting with " & sTmp.TA_Components9_Description & " Record No.: " & sTmp.SerialNo)
      End If
      If (Convert.ToDateTime(sTmp.Date2Time, ci) >= Convert.ToDateTime(tmp.Date1Time, ci) And Convert.ToDateTime(sTmp.Date2Time, ci) <= Convert.ToDateTime(tmp.Date2Time, ci)) Then
        Throw New Exception("Departure Date-Time is conflicting with " & sTmp.TA_Components9_Description & " Record No.: " & sTmp.SerialNo)
      End If
    Next
    Return mRet
  End Function

  Private Function GetObjectFromRow(ByVal r As GridViewRow) As SIS.TA.taBDFare
    On Error Resume Next
    Dim tmp As New SIS.TA.taBDFare
    tmp.TABillNo = CType(r.FindControl("F_TABillNo"), TextBox).Text
    tmp.SerialNo = CType(r.FindControl("F_SerialNo"), Label).Text
    tmp.CurrencyID = CType(r.FindControl("F_CurrencyID"), LC_taCurrencies).SelectedValue
    tmp.City1ID = CType(r.FindControl("F_City1ID"), TextBox).Text
    tmp.City1Text = CType(r.FindControl("F_City1Text"), TextBox).Text
    tmp.City2ID = CType(r.FindControl("F_City2ID"), TextBox).Text
    tmp.City2Text = CType(r.FindControl("F_City2Text"), TextBox).Text
    tmp.Country1ID = CType(r.FindControl("F_Country1ID"), TextBox).Text
    tmp.Country2ID = CType(r.FindControl("F_Country2ID"), TextBox).Text
    tmp.Date1Time = CType(r.FindControl("F_Date1Time"), TextBox).Text
    tmp.Date2Time = CType(r.FindControl("F_Date2Time"), TextBox).Text
    tmp.ModeTravelID = CType(r.FindControl("F_ModeTravelID"), LC_taTravelModes).SelectedValue
    tmp.ModeText = CType(r.FindControl("F_ModeText"), TextBox).Text
    tmp.Remarks = CType(r.FindControl("F_Remarks"), TextBox).Text
    tmp.AmountRateOU = CType(r.FindControl("F_AmountRateOU"), TextBox).Text
    tmp.ConversionFactorOU = CType(r.FindControl("F_ConversionFactorOU"), TextBox).Text
    tmp.CurrencyMain = CType(r.FindControl("F_CurrencyMain"), TextBox).Text
    Return tmp
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
  Public Shared Function City1IDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taCities.SelecttaCitiesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function City2IDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taCities.SelecttaCitiesAutoCompleteList(prefixText, count, contextKey)
  End Function

  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_TA_BillDetails_City2ID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim City2ID As String = CType(aVal(1), String)
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
