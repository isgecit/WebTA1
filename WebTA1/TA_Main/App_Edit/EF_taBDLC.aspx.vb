Partial Class EF_taBDLC
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
  Private oTABH As SIS.TA.taBH = Nothing
  Protected Sub ODStaBDLC_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaBDLC.Selected
    Dim tmp As SIS.TA.taBDLC = CType(e.ReturnValue, SIS.TA.taBDLC)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
    oTABH = tmp.FK_TA_BillDetails_TABillNo
  End Sub
  Protected Sub FVtaBDLC_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBDLC.Init
    DataClassName = "EtaBDLC"
    SetFormView = FVtaBDLC
  End Sub
  Protected Sub TBLtaBDLC_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaBDLC.Init
    SetToolBar = TBLtaBDLC
  End Sub

  Protected Sub FVtaBDLC_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBDLC.PreRender
    TBLtaBDLC.EnableSave = Editable
    TBLtaBDLC.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taBDLC.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaBDLC") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaBDLC", mStr)
    End If
    If oTABH.TravelTypeID <> TATravelTypeValues.Domestic Then
      CType(FVtaBDLC.FindControl("opt1"), HtmlTableRow).Style("display") = ""
      CType(FVtaBDLC.FindControl("opt2"), HtmlTableRow).Style("display") = ""
      CType(FVtaBDLC.FindControl("opt3"), HtmlTableRow).Style("display") = ""
    Else
      'CType(FVtaBDLC.FindControl("opt1"), HtmlTableRow).Style("display") = "none"
      CType(FVtaBDLC.FindControl("L_AirportToHotel"), Label).Text = "Airport Pick & Drop :"
      CType(FVtaBDLC.FindControl("opt2"), HtmlTableRow).Style("display") = "none"
      CType(FVtaBDLC.FindControl("opt3"), HtmlTableRow).Style("display") = "none"
    End If
    Try
      Dim tmp As SIS.TA.taBH = oTABH
      Dim tmp1 As LC_taCurrencies = CType(FVtaBDLC.FindControl("F_CurrencyID"), LC_taCurrencies)
      Dim tmp2 As Label = CType(FVtaBDLC.FindControl("F_CurrencyMain"), Label)
      'tmp1.SelectedValue = tmp.BillCurrencyID
      tmp2.Text = tmp.BillCurrencyID
      If tmp.TravelTypeID = TATravelTypeValues.Domestic Then
        Dim tmp3 As Label = CType(FVtaBDLC.FindControl("L_CurrencyID"), Label)
        Dim tmp4 As HtmlTableRow = CType(FVtaBDLC.FindControl("ouc"), HtmlTableRow)
        Dim tmp5 As TextBox = CType(FVtaBDLC.FindControl("F_ConversionFactorINR"), TextBox)
        tmp1.Enabled = False
        tmp3.Attributes.Add("style", "display:none")
        tmp4.Attributes.Add("style", "display:none")
        tmp5.Enabled = False
      End If
    Catch ex As Exception

    End Try

  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_TA_BillDetails_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1), String)
    Dim oVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function

End Class
