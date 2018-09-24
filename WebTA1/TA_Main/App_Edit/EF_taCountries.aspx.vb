Partial Class EF_taCountries
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
  Protected Sub ODStaCountries_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaCountries.Selected
    Dim tmp As SIS.TA.taCountries = CType(e.ReturnValue, SIS.TA.taCountries)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaCountries_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCountries.Init
    DataClassName = "EtaCountries"
    SetFormView = FVtaCountries
  End Sub
  Protected Sub TBLtaCountries_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaCountries.Init
    SetToolBar = TBLtaCountries
  End Sub
  Protected Sub FVtaCountries_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCountries.PreRender
    TBLtaCountries.EnableSave = Editable
    TBLtaCountries.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taCountries.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaCountries") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaCountries", mStr)
    End If
  End Sub

End Class
