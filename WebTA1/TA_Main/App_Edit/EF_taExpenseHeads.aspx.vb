Partial Class EF_taExpenseHeads
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
  Protected Sub ODStaExpenseHeads_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaExpenseHeads.Selected
    Dim tmp As SIS.TA.taExpenseHeads = CType(e.ReturnValue, SIS.TA.taExpenseHeads)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaExpenseHeads_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaExpenseHeads.Init
    DataClassName = "EtaExpenseHeads"
    SetFormView = FVtaExpenseHeads
  End Sub
  Protected Sub TBLtaExpenseHeads_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaExpenseHeads.Init
    SetToolBar = TBLtaExpenseHeads
  End Sub
  Protected Sub FVtaExpenseHeads_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaExpenseHeads.PreRender
    TBLtaExpenseHeads.EnableSave = Editable
    TBLtaExpenseHeads.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taExpenseHeads.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaExpenseHeads") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaExpenseHeads", mStr)
    End If
  End Sub

End Class
