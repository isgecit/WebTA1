Partial Class EF_pakPOTypes
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
  Protected Sub ODSpakPOTypes_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakPOTypes.Selected
    Dim tmp As SIS.PAK.pakPOTypes = CType(e.ReturnValue, SIS.PAK.pakPOTypes)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakPOTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPOTypes.Init
    DataClassName = "EpakPOTypes"
    SetFormView = FVpakPOTypes
  End Sub
  Protected Sub TBLpakPOTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakPOTypes.Init
    SetToolBar = TBLpakPOTypes
  End Sub
  Protected Sub FVpakPOTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPOTypes.PreRender
    TBLpakPOTypes.EnableSave = Editable
    TBLpakPOTypes.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakPOTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakPOTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakPOTypes", mStr)
    End If
  End Sub

End Class
