Partial Class EF_pakBusinessPartner
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
  Protected Sub ODSpakBusinessPartner_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakBusinessPartner.Selected
    Dim tmp As SIS.PAK.pakBusinessPartner = CType(e.ReturnValue, SIS.PAK.pakBusinessPartner)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakBusinessPartner_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakBusinessPartner.Init
    DataClassName = "EpakBusinessPartner"
    SetFormView = FVpakBusinessPartner
  End Sub
  Protected Sub TBLpakBusinessPartner_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakBusinessPartner.Init
    SetToolBar = TBLpakBusinessPartner
  End Sub
  Protected Sub FVpakBusinessPartner_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakBusinessPartner.PreRender
    TBLpakBusinessPartner.EnableSave = Editable
    TBLpakBusinessPartner.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakBusinessPartner.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakBusinessPartner") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakBusinessPartner", mStr)
    End If
  End Sub

End Class
