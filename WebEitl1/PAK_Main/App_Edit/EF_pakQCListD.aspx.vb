Imports System.Web.Script.Serialization
Partial Class EF_pakQCListD
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
  Protected Sub ODSpakQCListD_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakQCListD.Selected
    Dim tmp As SIS.PAK.pakQCListD = CType(e.ReturnValue, SIS.PAK.pakQCListD)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakQCListD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakQCListD.Init
    DataClassName = "EpakQCListD"
    SetFormView = FVpakQCListD
  End Sub
  Protected Sub TBLpakQCListD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakQCListD.Init
    SetToolBar = TBLpakQCListD
  End Sub
  Protected Sub FVpakQCListD_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakQCListD.PreRender
    TBLpakQCListD.EnableSave = Editable
    TBLpakQCListD.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakQCListD.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakQCListD") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakQCListD", mStr)
    End If
  End Sub

End Class
