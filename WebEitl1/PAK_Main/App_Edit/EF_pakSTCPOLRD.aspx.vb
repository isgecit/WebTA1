Imports System.Web.Script.Serialization
Partial Class EF_pakSTCPOLRD
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
  Protected Sub ODSpakSTCPOLRD_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakSTCPOLRD.Selected
    Dim tmp As SIS.PAK.pakSTCPOLRD = CType(e.ReturnValue, SIS.PAK.pakSTCPOLRD)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakSTCPOLRD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSTCPOLRD.Init
    DataClassName = "EpakSTCPOLRD"
    SetFormView = FVpakSTCPOLRD
  End Sub
  Protected Sub TBLpakSTCPOLRD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSTCPOLRD.Init
    SetToolBar = TBLpakSTCPOLRD
  End Sub
  Protected Sub FVpakSTCPOLRD_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSTCPOLRD.PreRender
    TBLpakSTCPOLRD.EnableSave = Editable
    TBLpakSTCPOLRD.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakSTCPOLRD.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSTCPOLRD") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSTCPOLRD", mStr)
    End If
  End Sub

End Class
