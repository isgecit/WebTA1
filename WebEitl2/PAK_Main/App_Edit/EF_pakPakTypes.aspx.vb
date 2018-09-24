Partial Class EF_pakPakTypes
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
  Protected Sub ODSpakPakTypes_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakPakTypes.Selected
    Dim tmp As SIS.PAK.pakPakTypes = CType(e.ReturnValue, SIS.PAK.pakPakTypes)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakPakTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPakTypes.Init
    DataClassName = "EpakPakTypes"
    SetFormView = FVpakPakTypes
  End Sub
  Protected Sub TBLpakPakTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakPakTypes.Init
    SetToolBar = TBLpakPakTypes
  End Sub
  Protected Sub FVpakPakTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPakTypes.PreRender
    TBLpakPakTypes.EnableSave = Editable
    TBLpakPakTypes.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakPakTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakPakTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakPakTypes", mStr)
    End If
  End Sub

End Class
