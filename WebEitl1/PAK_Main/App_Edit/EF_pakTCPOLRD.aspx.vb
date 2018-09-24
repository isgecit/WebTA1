Imports System.Web.Script.Serialization
Partial Class EF_pakTCPOLRD
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
  Protected Sub ODSpakTCPOLRD_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakTCPOLRD.Selected
    Dim tmp As SIS.PAK.pakTCPOLRD = CType(e.ReturnValue, SIS.PAK.pakTCPOLRD)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakTCPOLRD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakTCPOLRD.Init
    DataClassName = "EpakTCPOLRD"
    SetFormView = FVpakTCPOLRD
  End Sub
  Protected Sub TBLpakTCPOLRD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakTCPOLRD.Init
    SetToolBar = TBLpakTCPOLRD
  End Sub
  Protected Sub FVpakTCPOLRD_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakTCPOLRD.PreRender
    TBLpakTCPOLRD.EnableSave = Editable
    TBLpakTCPOLRD.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakTCPOLRD.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakTCPOLRD") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakTCPOLRD", mStr)
    End If
  End Sub

End Class
