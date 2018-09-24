Partial Class EF_taD_GuestHouseDA
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
  Protected Sub ODStaD_GuestHouseDA_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaD_GuestHouseDA.Selected
    Dim tmp As SIS.TA.taD_GuestHouseDA = CType(e.ReturnValue, SIS.TA.taD_GuestHouseDA)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaD_GuestHouseDA_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_GuestHouseDA.Init
    DataClassName = "EtaD_GuestHouseDA"
    SetFormView = FVtaD_GuestHouseDA
  End Sub
  Protected Sub TBLtaD_GuestHouseDA_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaD_GuestHouseDA.Init
    SetToolBar = TBLtaD_GuestHouseDA
  End Sub
  Protected Sub FVtaD_GuestHouseDA_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_GuestHouseDA.PreRender
    TBLtaD_GuestHouseDA.EnableSave = Editable
    TBLtaD_GuestHouseDA.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taD_GuestHouseDA.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaD_GuestHouseDA") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaD_GuestHouseDA", mStr)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function CityIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.TA.taCities.SelecttaCitiesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_TA_D_GuestHouseDA_CityID(ByVal value As String) As String
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
