Partial Class EF_pakReasons
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
  Protected Sub ODSpakReasons_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakReasons.Selected
    Dim tmp As SIS.PAK.pakReasons = CType(e.ReturnValue, SIS.PAK.pakReasons)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakReasons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakReasons.Init
    DataClassName = "EpakReasons"
    SetFormView = FVpakReasons
  End Sub
  Protected Sub TBLpakReasons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakReasons.Init
    SetToolBar = TBLpakReasons
  End Sub
  Protected Sub FVpakReasons_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakReasons.PreRender
    TBLpakReasons.EnableSave = Editable
    TBLpakReasons.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakReasons.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakReasons") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakReasons", mStr)
    End If
  End Sub

End Class
