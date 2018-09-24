Partial Class EF_costGLGroups
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
  Protected Sub ODScostGLGroups_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODScostGLGroups.Selected
    Dim tmp As SIS.COST.costGLGroups = CType(e.ReturnValue, SIS.COST.costGLGroups)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVcostGLGroups_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostGLGroups.Init
    DataClassName = "EcostGLGroups"
    SetFormView = FVcostGLGroups
  End Sub
  Protected Sub TBLcostGLGroups_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostGLGroups.Init
    SetToolBar = TBLcostGLGroups
  End Sub
  Protected Sub FVcostGLGroups_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostGLGroups.PreRender
    TBLcostGLGroups.EnableSave = Editable
    TBLcostGLGroups.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Edit") & "/EF_costGLGroups.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostGLGroups") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostGLGroups", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvcostGLGroupGLsCC As New gvBase
  Protected Sub GVcostGLGroupGLs_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVcostGLGroupGLs.Init
    gvcostGLGroupGLsCC.DataClassName = "GcostGLGroupGLs"
    gvcostGLGroupGLsCC.SetGridView = GVcostGLGroupGLs
  End Sub
  Protected Sub TBLcostGLGroupGLs_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostGLGroupGLs.Init
    gvcostGLGroupGLsCC.SetToolBar = TBLcostGLGroupGLs
  End Sub
  Protected Sub GVcostGLGroupGLs_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVcostGLGroupGLs.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim GLGroupID As Int32 = GVcostGLGroupGLs.DataKeys(e.CommandArgument).Values("GLGroupID")  
        Dim GLCode As String = GVcostGLGroupGLs.DataKeys(e.CommandArgument).Values("GLCode")  
        Dim RedirectUrl As String = TBLcostGLGroupGLs.EditUrl & "?GLGroupID=" & GLGroupID & "&GLCode=" & GLCode
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub TBLcostGLGroupGLs_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLcostGLGroupGLs.AddClicked
    Dim GLGroupID As Int32 = CType(FVcostGLGroups.FindControl("F_GLGroupID"),TextBox).Text
    TBLcostGLGroupGLs.AddUrl &= "?GLGroupID=" & GLGroupID
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function CostGLGroupIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.COST.costvGLGroups.SelectcostvGLGroupsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_COST_GLGroups_CostGLGroupID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim CostGLGroupID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.COST.costvGLGroups = SIS.COST.costvGLGroups.costvGLGroupsGetByID(CostGLGroupID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
