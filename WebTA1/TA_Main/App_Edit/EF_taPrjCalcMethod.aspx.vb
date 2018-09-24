Partial Class EF_taPrjCalcMethod
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
  Protected Sub ODStaPrjCalcMethod_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaPrjCalcMethod.Selected
    Dim tmp As SIS.TA.taPrjCalcMethod = CType(e.ReturnValue, SIS.TA.taPrjCalcMethod)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaPrjCalcMethod_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaPrjCalcMethod.Init
    DataClassName = "EtaPrjCalcMethod"
    SetFormView = FVtaPrjCalcMethod
  End Sub
  Protected Sub TBLtaPrjCalcMethod_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaPrjCalcMethod.Init
    SetToolBar = TBLtaPrjCalcMethod
  End Sub
  Protected Sub FVtaPrjCalcMethod_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaPrjCalcMethod.PreRender
    TBLtaPrjCalcMethod.EnableSave = Editable
    TBLtaPrjCalcMethod.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taPrjCalcMethod.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaPrjCalcMethod") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaPrjCalcMethod", mStr)
    End If
  End Sub

End Class
