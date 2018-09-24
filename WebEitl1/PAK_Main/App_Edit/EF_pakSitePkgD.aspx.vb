Imports System.Web.Script.Serialization
Partial Class EF_pakSitePkgD
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
  Protected Sub ODSpakSitePkgD_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakSitePkgD.Selected
    Dim tmp As SIS.PAK.pakSitePkgD = CType(e.ReturnValue, SIS.PAK.pakSitePkgD)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakSitePkgD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSitePkgD.Init
    DataClassName = "EpakSitePkgD"
    SetFormView = FVpakSitePkgD
  End Sub
  Protected Sub TBLpakSitePkgD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSitePkgD.Init
    SetToolBar = TBLpakSitePkgD
  End Sub
  Protected Sub FVpakSitePkgD_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSitePkgD.PreRender
    TBLpakSitePkgD.EnableSave = Editable
    TBLpakSitePkgD.EnableDelete = Deleteable
    TBLpakSitePkgDLocation.EnableAdd = Editable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakSitePkgD.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSitePkgD") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSitePkgD", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpakSitePkgDLocationCC As New gvBase
  Protected Sub GVpakSitePkgDLocation_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakSitePkgDLocation.Init
    gvpakSitePkgDLocationCC.DataClassName = "GpakSitePkgDLocation"
    gvpakSitePkgDLocationCC.SetGridView = GVpakSitePkgDLocation
  End Sub
  Protected Sub TBLpakSitePkgDLocation_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSitePkgDLocation.Init
    gvpakSitePkgDLocationCC.SetToolBar = TBLpakSitePkgDLocation
  End Sub
  Protected Sub GVpakSitePkgDLocation_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakSitePkgDLocation.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ProjectID As String = GVpakSitePkgDLocation.DataKeys(e.CommandArgument).Values("ProjectID")  
        Dim RecNo As Int32 = GVpakSitePkgDLocation.DataKeys(e.CommandArgument).Values("RecNo")  
        Dim RecSrNo As Int32 = GVpakSitePkgDLocation.DataKeys(e.CommandArgument).Values("RecSrNo")  
        Dim RecSrLNo As Int32 = GVpakSitePkgDLocation.DataKeys(e.CommandArgument).Values("RecSrLNo")  
        Dim RedirectUrl As String = TBLpakSitePkgDLocation.EditUrl & "?ProjectID=" & ProjectID & "&RecNo=" & RecNo & "&RecSrNo=" & RecSrNo & "&RecSrLNo=" & RecSrLNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "approvewf".ToLower Then
      Try
        Dim LocationID As Int32 = CType(GVpakSitePkgDLocation.Rows(e.CommandArgument).FindControl("F_LocationID"), LC_pakSiteLocations).SelectedValue
        Dim Quantity As Decimal = CType(GVpakSitePkgDLocation.Rows(e.CommandArgument).FindControl("F_Quantity"),TextBox).Text
        Dim ProjectID As String = GVpakSitePkgDLocation.DataKeys(e.CommandArgument).Values("ProjectID")  
        Dim RecNo As Int32 = GVpakSitePkgDLocation.DataKeys(e.CommandArgument).Values("RecNo")  
        Dim RecSrNo As Int32 = GVpakSitePkgDLocation.DataKeys(e.CommandArgument).Values("RecSrNo")  
        Dim RecSrLNo As Int32 = GVpakSitePkgDLocation.DataKeys(e.CommandArgument).Values("RecSrLNo")
        SIS.PAK.pakSitePkgDLocation.ApproveWF(ProjectID, RecNo, RecSrNo, RecSrLNo, Quantity, LocationID)
        GVpakSitePkgDLocation.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub TBLpakSitePkgDLocation_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLpakSitePkgDLocation.AddClicked
    Dim ProjectID As String = CType(FVpakSitePkgD.FindControl("F_ProjectID"),TextBox).Text
    Dim RecNo As Int32 = CType(FVpakSitePkgD.FindControl("F_RecNo"),TextBox).Text
    Dim RecSrNo As Int32 = CType(FVpakSitePkgD.FindControl("F_RecSrNo"),TextBox).Text
    TBLpakSitePkgDLocation.AddUrl &= "?ProjectID=" & ProjectID
    TBLpakSitePkgDLocation.AddUrl &= "&RecNo=" & RecNo
    TBLpakSitePkgDLocation.AddUrl &= "&RecSrNo=" & RecSrNo
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SiteMarkNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakSiteItemMaster.SelectpakSiteItemMasterAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SitePkgD_SiteMarkNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1),String)
    Dim SiteMarkNo As String = CType(aVal(2),String)
    Dim oVar As SIS.PAK.pakSiteItemMaster = SIS.PAK.pakSiteItemMaster.pakSiteItemMasterGetByID(ProjectID,SiteMarkNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
