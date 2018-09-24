Partial Class EF_nprkChequePayment
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
  Protected Sub ODSnprkChequePayment_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSnprkChequePayment.Selected
    Dim tmp As SIS.NPRK.nprkChequePayment = CType(e.ReturnValue, SIS.NPRK.nprkChequePayment)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVnprkChequePayment_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkChequePayment.Init
    DataClassName = "EnprkChequePayment"
    SetFormView = FVnprkChequePayment
  End Sub
  Protected Sub TBLnprkChequePayment_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkChequePayment.Init
    SetToolBar = TBLnprkChequePayment
  End Sub
  Protected Sub FVnprkChequePayment_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkChequePayment.PreRender
    TBLnprkChequePayment.EnableSave = True
    TBLnprkChequePayment.EnableDelete = False
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Edit") & "/EF_nprkChequePayment.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkChequePayment") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkChequePayment", mStr)
    End If
  End Sub

End Class
