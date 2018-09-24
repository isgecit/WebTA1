Imports System.Web.Script.Serialization
Partial Class EF_pakSiteIssReqH
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
  Protected Sub ODSpakSiteIssReqH_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakSiteIssReqH.Selected
    Dim tmp As SIS.PAK.pakSiteIssReqH = CType(e.ReturnValue, SIS.PAK.pakSiteIssReqH)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakSiteIssReqH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteIssReqH.Init
    DataClassName = "EpakSiteIssReqH"
    SetFormView = FVpakSiteIssReqH
  End Sub
  Protected Sub TBLpakSiteIssReqH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSiteIssReqH.Init
    SetToolBar = TBLpakSiteIssReqH
  End Sub
  Protected Sub FVpakSiteIssReqH_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteIssReqH.PreRender
    TBLpakSiteIssReqH.EnableSave = Editable
    TBLpakSiteIssReqH.EnableDelete = Deleteable
    TBLpakSiteIssRecD.EnableAdd = Editable
    TBLpakSiteIssReqH.PrintUrl &= Request.QueryString("ProjectID") & "|"
    TBLpakSiteIssReqH.PrintUrl &= Request.QueryString("IssueNo") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakSiteIssReqH.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSiteIssReqH") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSiteIssReqH", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpakSiteIssRecDCC As New gvBase
  Protected Sub GVpakSiteIssRecD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakSiteIssRecD.Init
    gvpakSiteIssRecDCC.DataClassName = "GpakSiteIssRecD"
    gvpakSiteIssRecDCC.SetGridView = GVpakSiteIssRecD
  End Sub
  Protected Sub TBLpakSiteIssRecD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSiteIssRecD.Init
    gvpakSiteIssRecDCC.SetToolBar = TBLpakSiteIssRecD
  End Sub
  Protected Sub GVpakSiteIssRecD_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakSiteIssRecD.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ProjectID As String = GVpakSiteIssRecD.DataKeys(e.CommandArgument).Values("ProjectID")  
        Dim IssueNo As Int32 = GVpakSiteIssRecD.DataKeys(e.CommandArgument).Values("IssueNo")  
        Dim IssueSrNo As Int32 = GVpakSiteIssRecD.DataKeys(e.CommandArgument).Values("IssueSrNo")  
        Dim RedirectUrl As String = TBLpakSiteIssRecD.EditUrl & "?ProjectID=" & ProjectID & "&IssueNo=" & IssueNo & "&IssueSrNo=" & IssueSrNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub TBLpakSiteIssRecD_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLpakSiteIssRecD.AddClicked
    Dim ProjectID As String = CType(FVpakSiteIssReqH.FindControl("F_ProjectID"),TextBox).Text
    Dim IssueNo As Int32 = CType(FVpakSiteIssReqH.FindControl("F_IssueNo"),TextBox).Text
    TBLpakSiteIssRecD.AddUrl &= "?ProjectID=" & ProjectID
    TBLpakSiteIssRecD.AddUrl &= "&IssueNo=" & IssueNo
  End Sub

End Class
