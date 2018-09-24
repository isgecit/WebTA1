Partial Class EF_taCurrencies
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
  Protected Sub ODStaCurrencies_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaCurrencies.Selected
    Dim tmp As SIS.TA.taCurrencies = CType(e.ReturnValue, SIS.TA.taCurrencies)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaCurrencies_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCurrencies.Init
    DataClassName = "EtaCurrencies"
    SetFormView = FVtaCurrencies
  End Sub
  Protected Sub TBLtaCurrencies_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaCurrencies.Init
    SetToolBar = TBLtaCurrencies
  End Sub
  Protected Sub FVtaCurrencies_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCurrencies.PreRender
    TBLtaCurrencies.EnableSave = Editable
    TBLtaCurrencies.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taCurrencies.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaCurrencies") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaCurrencies", mStr)
    End If
  End Sub

End Class
