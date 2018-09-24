Imports System.Web.Script.Serialization
Partial Class EF_pakPkgListD
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
  Protected Sub ODSpakPkgListD_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakPkgListD.Selected
    Dim tmp As SIS.PAK.pakPkgListD = CType(e.ReturnValue, SIS.PAK.pakPkgListD)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakPkgListD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPkgListD.Init
    DataClassName = "EpakPkgListD"
    SetFormView = FVpakPkgListD
  End Sub
  Protected Sub TBLpakPkgListD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakPkgListD.Init
    SetToolBar = TBLpakPkgListD
  End Sub
  Protected Sub FVpakPkgListD_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPkgListD.PreRender
    TBLpakPkgListD.EnableSave = Editable
    TBLpakPkgListD.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakPkgListD.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakPkgListD") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakPkgListD", mStr)
    End If
  End Sub

End Class
