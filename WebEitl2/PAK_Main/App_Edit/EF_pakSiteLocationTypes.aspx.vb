Imports System.Web.Script.Serialization
Partial Class EF_pakSiteLocationTypes
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
  Protected Sub ODSpakSiteLocationTypes_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakSiteLocationTypes.Selected
    Dim tmp As SIS.PAK.pakSiteLocationTypes = CType(e.ReturnValue, SIS.PAK.pakSiteLocationTypes)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakSiteLocationTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteLocationTypes.Init
    DataClassName = "EpakSiteLocationTypes"
    SetFormView = FVpakSiteLocationTypes
  End Sub
  Protected Sub TBLpakSiteLocationTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSiteLocationTypes.Init
    SetToolBar = TBLpakSiteLocationTypes
  End Sub
  Protected Sub FVpakSiteLocationTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteLocationTypes.PreRender
    TBLpakSiteLocationTypes.EnableSave = Editable
    TBLpakSiteLocationTypes.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakSiteLocationTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSiteLocationTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSiteLocationTypes", mStr)
    End If
  End Sub

End Class
