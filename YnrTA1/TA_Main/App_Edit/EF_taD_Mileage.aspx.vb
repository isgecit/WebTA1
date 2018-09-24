Partial Class EF_taD_Mileage
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
  Protected Sub ODStaD_Mileage_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaD_Mileage.Selected
    Dim tmp As SIS.TA.taD_Mileage = CType(e.ReturnValue, SIS.TA.taD_Mileage)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaD_Mileage_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_Mileage.Init
    DataClassName = "EtaD_Mileage"
    SetFormView = FVtaD_Mileage
  End Sub
  Protected Sub TBLtaD_Mileage_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaD_Mileage.Init
    SetToolBar = TBLtaD_Mileage
  End Sub
  Protected Sub FVtaD_Mileage_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_Mileage.PreRender
    TBLtaD_Mileage.EnableSave = Editable
    TBLtaD_Mileage.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taD_Mileage.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaD_Mileage") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaD_Mileage", mStr)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function CityIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taCities.SelecttaCitiesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_TA_D_Mileage_CityID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim CityID As String = CType(aVal(1),String)
    Dim oVar As SIS.TA.taCities = SIS.TA.taCities.taCitiesGetByID(CityID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
