Partial Class EF_pakPkgIStatus
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
  Protected Sub ODSpakPkgIStatus_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakPkgIStatus.Selected
    Dim tmp As SIS.PAK.pakPkgIStatus = CType(e.ReturnValue, SIS.PAK.pakPkgIStatus)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakPkgIStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPkgIStatus.Init
    DataClassName = "EpakPkgIStatus"
    SetFormView = FVpakPkgIStatus
  End Sub
  Protected Sub TBLpakPkgIStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakPkgIStatus.Init
    SetToolBar = TBLpakPkgIStatus
  End Sub
  Protected Sub FVpakPkgIStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPkgIStatus.PreRender
    TBLpakPkgIStatus.EnableSave = Editable
    TBLpakPkgIStatus.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakPkgIStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakPkgIStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakPkgIStatus", mStr)
    End If
  End Sub

End Class
