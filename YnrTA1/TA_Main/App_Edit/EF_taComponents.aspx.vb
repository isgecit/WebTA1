Partial Class EF_taComponents
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
  Protected Sub ODStaComponents_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaComponents.Selected
    Dim tmp As SIS.TA.taComponents = CType(e.ReturnValue, SIS.TA.taComponents)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaComponents_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaComponents.Init
    DataClassName = "EtaComponents"
    SetFormView = FVtaComponents
  End Sub
  Protected Sub TBLtaComponents_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaComponents.Init
    SetToolBar = TBLtaComponents
  End Sub
  Protected Sub FVtaComponents_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaComponents.PreRender
    TBLtaComponents.EnableSave = Editable
    TBLtaComponents.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taComponents.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaComponents") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaComponents", mStr)
    End If
  End Sub

End Class
