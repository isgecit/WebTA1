Imports System.Web.Script.Serialization
Partial Class EF_pakSiteLocations
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
  Protected Sub ODSpakSiteLocations_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakSiteLocations.Selected
    Dim tmp As SIS.PAK.pakSiteLocations = CType(e.ReturnValue, SIS.PAK.pakSiteLocations)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakSiteLocations_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteLocations.Init
    DataClassName = "EpakSiteLocations"
    SetFormView = FVpakSiteLocations
  End Sub
  Protected Sub TBLpakSiteLocations_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSiteLocations.Init
    SetToolBar = TBLpakSiteLocations
  End Sub
  Protected Sub FVpakSiteLocations_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteLocations.PreRender
    TBLpakSiteLocations.EnableSave = Editable
    TBLpakSiteLocations.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakSiteLocations.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSiteLocations") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSiteLocations", mStr)
    End If
  End Sub

End Class
