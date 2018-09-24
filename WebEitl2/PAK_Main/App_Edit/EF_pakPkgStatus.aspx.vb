Partial Class EF_pakPkgStatus
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
  Protected Sub ODSpakPkgStatus_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakPkgStatus.Selected
    Dim tmp As SIS.PAK.pakPkgStatus = CType(e.ReturnValue, SIS.PAK.pakPkgStatus)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakPkgStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPkgStatus.Init
    DataClassName = "EpakPkgStatus"
    SetFormView = FVpakPkgStatus
  End Sub
  Protected Sub TBLpakPkgStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakPkgStatus.Init
    SetToolBar = TBLpakPkgStatus
  End Sub
  Protected Sub FVpakPkgStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPkgStatus.PreRender
    TBLpakPkgStatus.EnableSave = Editable
    TBLpakPkgStatus.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakPkgStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakPkgStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakPkgStatus", mStr)
    End If
  End Sub

End Class
