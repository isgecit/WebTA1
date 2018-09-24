Partial Class EF_taBillAmount
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
  Protected Sub ODStaBillAmount_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaBillAmount.Selected
    Dim tmp As SIS.TA.taBillAmount = CType(e.ReturnValue, SIS.TA.taBillAmount)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaBillAmount_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBillAmount.Init
    DataClassName = "EtaBillAmount"
    SetFormView = FVtaBillAmount
  End Sub
  Protected Sub TBLtaBillAmount_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaBillAmount.Init
    SetToolBar = TBLtaBillAmount
  End Sub
  Protected Sub FVtaBillAmount_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBillAmount.PreRender
    TBLtaBillAmount.EnableSave = Editable
    TBLtaBillAmount.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taBillAmount.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaBillAmount") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaBillAmount", mStr)
    End If
  End Sub

End Class
