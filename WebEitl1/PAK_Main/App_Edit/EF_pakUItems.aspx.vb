Partial Class EF_pakUItems
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
  Protected Sub ODSpakUItems_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakUItems.Selected
    Dim tmp As SIS.PAK.pakUItems = CType(e.ReturnValue, SIS.PAK.pakUItems)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakUItems_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakUItems.Init
    DataClassName = "EpakUItems"
    SetFormView = FVpakUItems
  End Sub
  Protected Sub TBLpakUItems_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakUItems.Init
    SetToolBar = TBLpakUItems
  End Sub
  Protected Sub FVpakUItems_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakUItems.PreRender
    TBLpakUItems.EnableSave = Editable
    TBLpakUItems.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakUItems.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakUItems") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakUItems", mStr)
    End If
  End Sub

End Class
