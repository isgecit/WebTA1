Imports System.Web.Script.Serialization
Partial Class EF_pakSiteMtlIssD
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
  Protected Sub ODSpakSiteMtlIssD_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakSiteMtlIssD.Selected
    Dim tmp As SIS.PAK.pakSiteMtlIssD = CType(e.ReturnValue, SIS.PAK.pakSiteMtlIssD)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakSiteMtlIssD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteMtlIssD.Init
    DataClassName = "EpakSiteMtlIssD"
    SetFormView = FVpakSiteMtlIssD
  End Sub
  Protected Sub TBLpakSiteMtlIssD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSiteMtlIssD.Init
    SetToolBar = TBLpakSiteMtlIssD
  End Sub
  Protected Sub FVpakSiteMtlIssD_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteMtlIssD.PreRender
    TBLpakSiteMtlIssD.EnableSave = Editable
    TBLpakSiteMtlIssD.EnableDelete = Deleteable
    TBLpakSiteMtlIssDL.EnableAdd = False
    CType(FVpakSiteMtlIssD.FindControl("cmdImport"), Button).Enabled = Editable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakSiteMtlIssD.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSiteMtlIssD") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSiteMtlIssD", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpakSiteMtlIssDLCC As New gvBase
  Protected Sub GVpakSiteMtlIssDL_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakSiteMtlIssDL.Init
    gvpakSiteMtlIssDLCC.DataClassName = "GpakSiteMtlIssDL"
    gvpakSiteMtlIssDLCC.SetGridView = GVpakSiteMtlIssDL
  End Sub
  Protected Sub TBLpakSiteMtlIssDL_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSiteMtlIssDL.Init
    gvpakSiteMtlIssDLCC.SetToolBar = TBLpakSiteMtlIssDL
  End Sub
  Protected Sub GVpakSiteMtlIssDL_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakSiteMtlIssDL.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ProjectID As String = GVpakSiteMtlIssDL.DataKeys(e.CommandArgument).Values("ProjectID")  
        Dim IssueNo As Int32 = GVpakSiteMtlIssDL.DataKeys(e.CommandArgument).Values("IssueNo")  
        Dim IssueSrNo As Int32 = GVpakSiteMtlIssDL.DataKeys(e.CommandArgument).Values("IssueSrNo")  
        Dim IssueSrLNo As Int32 = GVpakSiteMtlIssDL.DataKeys(e.CommandArgument).Values("IssueSrLNo")  
        Dim RedirectUrl As String = TBLpakSiteMtlIssDL.EditUrl & "?ProjectID=" & ProjectID & "&IssueNo=" & IssueNo & "&IssueSrNo=" & IssueSrNo & "&IssueSrLNo=" & IssueSrLNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub TBLpakSiteMtlIssDL_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLpakSiteMtlIssDL.AddClicked
    Dim ProjectID As String = CType(FVpakSiteMtlIssD.FindControl("F_ProjectID"), TextBox).Text
    Dim IssueNo As Int32 = CType(FVpakSiteMtlIssD.FindControl("F_IssueNo"), TextBox).Text
    Dim IssueSrNo As Int32 = CType(FVpakSiteMtlIssD.FindControl("F_IssueSrNo"), TextBox).Text
    TBLpakSiteMtlIssDL.AddUrl &= "?ProjectID=" & ProjectID
    TBLpakSiteMtlIssDL.AddUrl &= "&IssueNo=" & IssueNo
    TBLpakSiteMtlIssDL.AddUrl &= "&IssueSrNo=" & IssueSrNo
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SiteMarkNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakSiteItemMaster.SelectpakSiteItemMasterAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SiteIssueD_SiteMarkNo(ByVal value As String) As String
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

  Private Sub FVpakSiteMtlIssD_ItemCommand(sender As Object, e As FormViewCommandEventArgs) Handles FVpakSiteMtlIssD.ItemCommand
    If e.CommandName.ToString.ToLower = "ImportItemLocation".ToLower Then
      Dim aVal() As String = e.CommandArgument.ToString.Split("|".ToCharArray)
      Dim ProjectID As String = aVal(0)
      Dim IssueNo As Int32 = aVal(1)
      Dim IssueSrNo As Int32 = aVal(2)
      Dim tmp As SIS.PAK.pakSiteIssReqH = SIS.PAK.pakSiteIssReqH.pakSiteIssReqHGetByID(ProjectID, IssueNo)
      SIS.PAK.pakSiteIssReqH.InsertIssueLocation(tmp, IssueSrNo)
      GVpakSiteMtlIssDL.DataBind()
    End If
  End Sub
End Class
