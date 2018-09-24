Imports System.Web.Script.Serialization
Partial Class EF_pakSiteItemMasterLocation
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
  Protected Sub ODSpakSiteItemMasterLocation_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakSiteItemMasterLocation.Selected
    Dim tmp As SIS.PAK.pakSiteItemMasterLocation = CType(e.ReturnValue, SIS.PAK.pakSiteItemMasterLocation)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakSiteItemMasterLocation_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteItemMasterLocation.Init
    DataClassName = "EpakSiteItemMasterLocation"
    SetFormView = FVpakSiteItemMasterLocation
  End Sub
  Protected Sub TBLpakSiteItemMasterLocation_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSiteItemMasterLocation.Init
    SetToolBar = TBLpakSiteItemMasterLocation
  End Sub
  Protected Sub FVpakSiteItemMasterLocation_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteItemMasterLocation.PreRender
    TBLpakSiteItemMasterLocation.EnableSave = Editable
    TBLpakSiteItemMasterLocation.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakSiteItemMasterLocation.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSiteItemMasterLocation") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSiteItemMasterLocation", mStr)
    End If
  End Sub

End Class
