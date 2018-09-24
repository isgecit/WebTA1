Partial Class EF_pakUnitSets
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
  Protected Sub ODSpakUnitSets_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakUnitSets.Selected
    Dim tmp As SIS.PAK.pakUnitSets = CType(e.ReturnValue, SIS.PAK.pakUnitSets)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakUnitSets_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakUnitSets.Init
    DataClassName = "EpakUnitSets"
    SetFormView = FVpakUnitSets
  End Sub
  Protected Sub TBLpakUnitSets_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakUnitSets.Init
    SetToolBar = TBLpakUnitSets
  End Sub
  Protected Sub FVpakUnitSets_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakUnitSets.PreRender
    TBLpakUnitSets.EnableSave = Editable
    TBLpakUnitSets.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakUnitSets.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakUnitSets") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakUnitSets", mStr)
    End If
  End Sub

End Class
