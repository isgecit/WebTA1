Imports System.Web.Script.Serialization
Partial Class EF_pakSiteItemMaster
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
  Protected Sub ODSpakSiteItemMaster_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakSiteItemMaster.Selected
    Dim tmp As SIS.PAK.pakSiteItemMaster = CType(e.ReturnValue, SIS.PAK.pakSiteItemMaster)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakSiteItemMaster_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteItemMaster.Init
    DataClassName = "EpakSiteItemMaster"
    SetFormView = FVpakSiteItemMaster
  End Sub
  Protected Sub TBLpakSiteItemMaster_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSiteItemMaster.Init
    SetToolBar = TBLpakSiteItemMaster
  End Sub
  Protected Sub FVpakSiteItemMaster_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteItemMaster.PreRender
    TBLpakSiteItemMaster.EnableSave = Editable
    TBLpakSiteItemMaster.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakSiteItemMaster.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSiteItemMaster") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSiteItemMaster", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpakSiteItemMasterLocationCC As New gvBase
  Protected Sub GVpakSiteItemMasterLocation_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakSiteItemMasterLocation.Init
    gvpakSiteItemMasterLocationCC.DataClassName = "GpakSiteItemMasterLocation"
    gvpakSiteItemMasterLocationCC.SetGridView = GVpakSiteItemMasterLocation
  End Sub
  Protected Sub TBLpakSiteItemMasterLocation_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSiteItemMasterLocation.Init
    gvpakSiteItemMasterLocationCC.SetToolBar = TBLpakSiteItemMasterLocation
  End Sub
  Protected Sub GVpakSiteItemMasterLocation_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakSiteItemMasterLocation.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ProjectID As String = GVpakSiteItemMasterLocation.DataKeys(e.CommandArgument).Values("ProjectID")  
        Dim SiteMarkNo As String = GVpakSiteItemMasterLocation.DataKeys(e.CommandArgument).Values("SiteMarkNo")  
        Dim LocationID As Int32 = GVpakSiteItemMasterLocation.DataKeys(e.CommandArgument).Values("LocationID")  
        Dim RedirectUrl As String = TBLpakSiteItemMasterLocation.EditUrl & "?ProjectID=" & ProjectID & "&SiteMarkNo=" & SiteMarkNo & "&LocationID=" & LocationID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub TBLpakSiteItemMasterLocation_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLpakSiteItemMasterLocation.AddClicked
    Dim ProjectID As String = CType(FVpakSiteItemMaster.FindControl("F_ProjectID"),TextBox).Text
    Dim SiteMarkNo As String = CType(FVpakSiteItemMaster.FindControl("F_SiteMarkNo"),TextBox).Text
    TBLpakSiteItemMasterLocation.AddUrl &= "?ProjectID=" & ProjectID
    TBLpakSiteItemMasterLocation.AddUrl &= "&SiteMarkNo=" & SiteMarkNo
  End Sub

End Class
