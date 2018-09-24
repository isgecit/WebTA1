Partial Class EF_taCategories
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
  Protected Sub ODStaCategories_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaCategories.Selected
    Dim tmp As SIS.TA.taCategories = CType(e.ReturnValue, SIS.TA.taCategories)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaCategories_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCategories.Init
    DataClassName = "EtaCategories"
    SetFormView = FVtaCategories
  End Sub
  Protected Sub TBLtaCategories_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaCategories.Init
    SetToolBar = TBLtaCategories
  End Sub
  Protected Sub FVtaCategories_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCategories.PreRender
    TBLtaCategories.EnableSave = Editable
    TBLtaCategories.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taCategories.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaCategories") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaCategories", mStr)
    End If
  End Sub

End Class
