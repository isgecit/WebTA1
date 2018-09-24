Imports System.Web.Script.Serialization
Partial Class EF_pakIQCListD
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
  Protected Sub ODSpakIQCListD_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakIQCListD.Selected
    Dim tmp As SIS.PAK.pakIQCListD = CType(e.ReturnValue, SIS.PAK.pakIQCListD)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakIQCListD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakIQCListD.Init
    DataClassName = "EpakIQCListD"
    SetFormView = FVpakIQCListD
  End Sub
  Protected Sub TBLpakIQCListD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakIQCListD.Init
    SetToolBar = TBLpakIQCListD
  End Sub
  Protected Sub FVpakIQCListD_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakIQCListD.PreRender
    TBLpakIQCListD.EnableSave = Editable
    TBLpakIQCListD.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakIQCListD.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakIQCListD") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakIQCListD", mStr)
    End If
  End Sub

End Class
