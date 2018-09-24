Partial Class EF_taOOEReasons
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
  Protected Sub ODStaOOEReasons_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaOOEReasons.Selected
    Dim tmp As SIS.TA.taOOEReasons = CType(e.ReturnValue, SIS.TA.taOOEReasons)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaOOEReasons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaOOEReasons.Init
    DataClassName = "EtaOOEReasons"
    SetFormView = FVtaOOEReasons
  End Sub
  Protected Sub TBLtaOOEReasons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaOOEReasons.Init
    SetToolBar = TBLtaOOEReasons
  End Sub
  Protected Sub FVtaOOEReasons_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaOOEReasons.PreRender
    TBLtaOOEReasons.EnableSave = Editable
    TBLtaOOEReasons.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taOOEReasons.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaOOEReasons") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaOOEReasons", mStr)
    End If
  End Sub

End Class
