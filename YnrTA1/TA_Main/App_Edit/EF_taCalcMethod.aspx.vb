Partial Class EF_taCalcMethod
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
  Protected Sub ODStaCalcMethod_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaCalcMethod.Selected
    Dim tmp As SIS.TA.taCalcMethod = CType(e.ReturnValue, SIS.TA.taCalcMethod)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaCalcMethod_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCalcMethod.Init
    DataClassName = "EtaCalcMethod"
    SetFormView = FVtaCalcMethod
  End Sub
  Protected Sub TBLtaCalcMethod_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaCalcMethod.Init
    SetToolBar = TBLtaCalcMethod
  End Sub
  Protected Sub FVtaCalcMethod_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCalcMethod.PreRender
    TBLtaCalcMethod.EnableSave = Editable
    TBLtaCalcMethod.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taCalcMethod.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaCalcMethod") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaCalcMethod", mStr)
    End If
  End Sub

End Class
