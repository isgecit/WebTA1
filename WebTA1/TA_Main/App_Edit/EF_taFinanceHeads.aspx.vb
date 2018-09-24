Partial Class EF_taFinanceHeads
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
  Protected Sub ODStaFinanceHeads_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaFinanceHeads.Selected
    Dim tmp As SIS.TA.taFinanceHeads = CType(e.ReturnValue, SIS.TA.taFinanceHeads)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaFinanceHeads_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaFinanceHeads.Init
    DataClassName = "EtaFinanceHeads"
    SetFormView = FVtaFinanceHeads
  End Sub
  Protected Sub TBLtaFinanceHeads_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaFinanceHeads.Init
    SetToolBar = TBLtaFinanceHeads
  End Sub
  Protected Sub FVtaFinanceHeads_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaFinanceHeads.PreRender
    TBLtaFinanceHeads.EnableSave = Editable
    TBLtaFinanceHeads.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taFinanceHeads.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaFinanceHeads") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaFinanceHeads", mStr)
    End If
  End Sub

End Class
