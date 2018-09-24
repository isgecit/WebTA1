Partial Class AF_taBDLC
  Inherits SIS.SYS.GridBase
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
  Protected Sub GVtaBDLC_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVtaBDLC.Init
    DataClassName = "GtaBDLC"
    SetGridView = GVtaBDLC
  End Sub
  Protected Sub TBLtaBDLC_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaBDLC.Init
    SetToolBar = TBLtaBDLC
  End Sub
  Private Sub AF_taBDLC_Init(sender As Object, e As EventArgs) Handles Me.Init
    If Request.QueryString("TABillNo") IsNot Nothing Then
      F_TABillNo.Text = Request.QueryString("TABillNo")
      Dim otabh As SIS.TA.taBH = SIS.TA.taBH.taBHGetByID(Request.QueryString("TABillNo"))
      If otabh.TravelTypeID <> TATravelTypeValues.Domestic Then
        ShowAllColumns = True
        dCssClass = "mytxt"
      Else
        ShowAllColumns = False
        dCssClass = "dmytxt"
      End If
    End If
  End Sub
  Private Sub AF_taBDLC_Load(sender As Object, e As EventArgs) Handles Me.Load
    Dim otabh As SIS.TA.taBH = SIS.TA.taBH.taBHGetByID(Request.QueryString("TABillNo"))
    If otabh.TravelTypeID <> TATravelTypeValues.Domestic Then
      ShowAllColumns = True
      dCssClass = "mytxt"
    Else
      ShowAllColumns = False
      dCssClass = "dmytxt"
    End If
  End Sub

  Private Sub GVtaBDLC_PreRender(sender As Object, e As EventArgs) Handles GVtaBDLC.PreRender
    If Not ShowAllColumns Then
      With GVtaBDLC
        .Columns(6).HeaderText = "Airport Pick & Drop"
        .Columns(7).Visible = False
        .Columns(8).Visible = False
        .Columns(10).Visible = False
        .Columns(12).Visible = False
      End With

    End If
  End Sub
  'Private Sub GVtaBDLC_RowCreated(sender As Object, e As GridViewRowEventArgs) Handles GVtaBDLC.RowCreated
  '  If Not ShowAllColumns Then
  '    If e.Row.RowType = DataControlRowType.DataRow Then
  '    End If
  '  End If
  'End Sub

  Private Sub TBLtaBDLC_SaveClicked(sender As Object, e As ImageClickEventArgs) Handles TBLtaBDLC.SaveClicked
    With GVtaBDLC
      For Each r As GridViewRow In .Rows
        Dim x As SIS.TA.taBDLC = GetObjectFromRow(r)
        If x.City1Text <> String.Empty And x.City2Text <> String.Empty And x.Date1Time <> String.Empty Then
          If x.ConversionFactorOU <= 0 Then x.ConversionFactorOU = 1
          x.TABillNo = F_TABillNo.Text
          x.SerialNo = 0
          SIS.TA.taBDLC.UZ_taBDLCInsert(x)
        End If
      Next
      SIS.TA.taBH.ValidateTABill(F_TABillNo.Text)
    End With
    MyBase.Saved()
  End Sub
  Private Function GetObjectFromRow(ByVal r As GridViewRow) As SIS.TA.taBDLC
    On Error Resume Next
    Dim tmp As New SIS.TA.taBDLC
    tmp.TABillNo = CType(r.FindControl("F_TABillNo"), TextBox).Text
    tmp.SerialNo = CType(r.FindControl("F_SerialNo"), TextBox).Text
    tmp.CurrencyID = CType(r.FindControl("F_CurrencyID"), LC_taCurrencies).SelectedValue
    tmp.City1Text = CType(r.FindControl("F_City1Text"), TextBox).Text
    tmp.City2Text = CType(r.FindControl("F_City2Text"), TextBox).Text
    tmp.Date1Time = CType(r.FindControl("F_Date1Time"), TextBox).Text
    tmp.ModeLCID = CType(r.FindControl("F_ModeLCID"), LC_taLCModes).SelectedValue
    tmp.ModeText = CType(r.FindControl("F_ModeText"), TextBox).Text
    tmp.AirportToHotel = CType(r.FindControl("F_AirportToHotel"), TextBox).Text
    tmp.HotelToAirport = CType(r.FindControl("F_HotelToAirport"), TextBox).Text
    tmp.AirportToClientLocation = CType(r.FindControl("F_AirportToClientLocation"), TextBox).Text
    tmp.Remarks = CType(r.FindControl("F_Remarks"), TextBox).Text
    tmp.AmountRateOU = CType(r.FindControl("F_AmountRateOU"), TextBox).Text
    tmp.ConversionFactorOU = CType(r.FindControl("F_ConversionFactorOU"), TextBox).Text
    Return tmp
  End Function

End Class
