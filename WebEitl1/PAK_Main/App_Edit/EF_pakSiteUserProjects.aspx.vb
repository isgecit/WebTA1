Imports System.Web.Script.Serialization
Partial Class EF_pakSiteUserProjects
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
  Protected Sub ODSpakSiteUserProjects_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakSiteUserProjects.Selected
    Dim tmp As SIS.PAK.pakSiteUserProjects = CType(e.ReturnValue, SIS.PAK.pakSiteUserProjects)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakSiteUserProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteUserProjects.Init
    DataClassName = "EpakSiteUserProjects"
    SetFormView = FVpakSiteUserProjects
  End Sub
  Protected Sub TBLpakSiteUserProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSiteUserProjects.Init
    SetToolBar = TBLpakSiteUserProjects
  End Sub
  Protected Sub FVpakSiteUserProjects_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteUserProjects.PreRender
    TBLpakSiteUserProjects.EnableSave = Editable
    TBLpakSiteUserProjects.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakSiteUserProjects.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSiteUserProjects") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSiteUserProjects", mStr)
    End If
  End Sub

End Class
