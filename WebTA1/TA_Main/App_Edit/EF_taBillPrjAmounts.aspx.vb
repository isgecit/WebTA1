Partial Class EF_taBillPrjAmounts
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
  Protected Sub ODStaBillPrjAmounts_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaBillPrjAmounts.Selected
    Dim tmp As SIS.TA.taBillPrjAmounts = CType(e.ReturnValue, SIS.TA.taBillPrjAmounts)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaBillPrjAmounts_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBillPrjAmounts.Init
    DataClassName = "EtaBillPrjAmounts"
    SetFormView = FVtaBillPrjAmounts
  End Sub
  Protected Sub TBLtaBillPrjAmounts_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaBillPrjAmounts.Init
    SetToolBar = TBLtaBillPrjAmounts
  End Sub
  Protected Sub FVtaBillPrjAmounts_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBillPrjAmounts.PreRender
    TBLtaBillPrjAmounts.EnableSave = Editable
    TBLtaBillPrjAmounts.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taBillPrjAmounts.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaBillPrjAmounts") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaBillPrjAmounts", mStr)
    End If
  End Sub

End Class
