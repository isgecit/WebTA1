Imports System.Web.Script.Serialization
Partial Class EF_pakDPending
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
  Protected Sub ODSpakDPending_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakDPending.Selected
    Dim tmp As SIS.PAK.pakDPending = CType(e.ReturnValue, SIS.PAK.pakDPending)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakDPending_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakDPending.Init
    DataClassName = "EpakDPending"
    SetFormView = FVpakDPending
  End Sub
  Protected Sub TBLpakDPending_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakDPending.Init
    SetToolBar = TBLpakDPending
  End Sub
  Protected Sub FVpakDPending_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakDPending.PreRender
    TBLpakDPending.EnableSave = Editable
    TBLpakDPending.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakDPending.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakDPending") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakDPending", mStr)
    End If
  End Sub

End Class
