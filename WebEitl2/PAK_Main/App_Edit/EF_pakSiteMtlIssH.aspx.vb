Imports System.Web.Script.Serialization
Partial Class EF_pakSiteMtlIssH
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
  Protected Sub ODSpakSiteMtlIssH_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakSiteMtlIssH.Selected
    Dim tmp As SIS.PAK.pakSiteMtlIssH = CType(e.ReturnValue, SIS.PAK.pakSiteMtlIssH)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakSiteMtlIssH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteMtlIssH.Init
    DataClassName = "EpakSiteMtlIssH"
    SetFormView = FVpakSiteMtlIssH
  End Sub
  Protected Sub TBLpakSiteMtlIssH_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSiteMtlIssH.Init
    SetToolBar = TBLpakSiteMtlIssH
  End Sub
  Protected Sub FVpakSiteMtlIssH_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSiteMtlIssH.PreRender
    TBLpakSiteMtlIssH.EnableSave = Editable
    TBLpakSiteMtlIssH.EnableDelete = Deleteable
    TBLpakSiteMtlIssH.PrintUrl &= Request.QueryString("ProjectID") & "|"
    TBLpakSiteMtlIssH.PrintUrl &= Request.QueryString("IssueNo") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakSiteMtlIssH.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSiteMtlIssH") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSiteMtlIssH", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvpakSiteMtlIssDCC As New gvBase
  Protected Sub GVpakSiteMtlIssD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVpakSiteMtlIssD.Init
    gvpakSiteMtlIssDCC.DataClassName = "GpakSiteMtlIssD"
    gvpakSiteMtlIssDCC.SetGridView = GVpakSiteMtlIssD
  End Sub
  Protected Sub TBLpakSiteMtlIssD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSiteMtlIssD.Init
    gvpakSiteMtlIssDCC.SetToolBar = TBLpakSiteMtlIssD
  End Sub
  Protected Sub GVpakSiteMtlIssD_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVpakSiteMtlIssD.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ProjectID As String = GVpakSiteMtlIssD.DataKeys(e.CommandArgument).Values("ProjectID")  
        Dim IssueNo As Int32 = GVpakSiteMtlIssD.DataKeys(e.CommandArgument).Values("IssueNo")  
        Dim IssueSrNo As Int32 = GVpakSiteMtlIssD.DataKeys(e.CommandArgument).Values("IssueSrNo")  
        Dim RedirectUrl As String = TBLpakSiteMtlIssD.EditUrl & "?ProjectID=" & ProjectID & "&IssueNo=" & IssueNo & "&IssueSrNo=" & IssueSrNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "approvewf".ToLower Then
      Try
        Dim ProjectID As String = GVpakSiteMtlIssD.DataKeys(e.CommandArgument).Values("ProjectID")  
        Dim IssueNo As Int32 = GVpakSiteMtlIssD.DataKeys(e.CommandArgument).Values("IssueNo")  
        Dim IssueSrNo As Int32 = GVpakSiteMtlIssD.DataKeys(e.CommandArgument).Values("IssueSrNo")  
        SIS.PAK.pakSiteMtlIssD.ApproveWF(ProjectID, IssueNo, IssueSrNo)
        GVpakSiteMtlIssD.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub TBLpakSiteMtlIssD_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLpakSiteMtlIssD.AddClicked
    Dim ProjectID As String = CType(FVpakSiteMtlIssH.FindControl("F_ProjectID"),TextBox).Text
    Dim IssueNo As Int32 = CType(FVpakSiteMtlIssH.FindControl("F_IssueNo"),TextBox).Text
    TBLpakSiteMtlIssD.AddUrl &= "?ProjectID=" & ProjectID
    TBLpakSiteMtlIssD.AddUrl &= "&IssueNo=" & IssueNo
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function IssueToCardNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_SiteIssueH_IssueToCardNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim IssueToCardNo As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(IssueToCardNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
