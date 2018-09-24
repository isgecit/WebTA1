Partial Class EF_nprkCashPayment
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
  Protected Sub ODSnprkCashPayment_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSnprkCashPayment.Selected
    Dim tmp As SIS.NPRK.nprkCashPayment = CType(e.ReturnValue, SIS.NPRK.nprkCashPayment)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVnprkCashPayment_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkCashPayment.Init
    DataClassName = "EnprkCashPayment"
    SetFormView = FVnprkCashPayment
  End Sub
  Protected Sub TBLnprkCashPayment_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkCashPayment.Init
    SetToolBar = TBLnprkCashPayment
  End Sub
  Protected Sub FVnprkCashPayment_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkCashPayment.PreRender
    TBLnprkCashPayment.EnableSave = True
    TBLnprkCashPayment.EnableDelete = False
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Edit") & "/EF_nprkCashPayment.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkCashPayment") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkCashPayment", mStr)
    End If
  End Sub

End Class
