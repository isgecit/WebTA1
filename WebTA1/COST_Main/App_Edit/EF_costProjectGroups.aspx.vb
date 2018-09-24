Partial Class EF_costProjectGroups
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
  Protected Sub ODScostProjectGroups_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODScostProjectGroups.Selected
    Dim tmp As SIS.COST.costProjectGroups = CType(e.ReturnValue, SIS.COST.costProjectGroups)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVcostProjectGroups_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostProjectGroups.Init
    DataClassName = "EcostProjectGroups"
    SetFormView = FVcostProjectGroups
  End Sub
  Protected Sub TBLcostProjectGroups_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostProjectGroups.Init
    SetToolBar = TBLcostProjectGroups
  End Sub
  Protected Sub FVcostProjectGroups_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostProjectGroups.PreRender
    TBLcostProjectGroups.EnableSave = Editable
    TBLcostProjectGroups.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Edit") & "/EF_costProjectGroups.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostProjectGroups") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostProjectGroups", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvcostProjectGroupProjectsCC As New gvBase
  Protected Sub GVcostProjectGroupProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVcostProjectGroupProjects.Init
    gvcostProjectGroupProjectsCC.DataClassName = "GcostProjectGroupProjects"
    gvcostProjectGroupProjectsCC.SetGridView = GVcostProjectGroupProjects
  End Sub
  Protected Sub TBLcostProjectGroupProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostProjectGroupProjects.Init
    gvcostProjectGroupProjectsCC.SetToolBar = TBLcostProjectGroupProjects
  End Sub
  Protected Sub GVcostProjectGroupProjects_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVcostProjectGroupProjects.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ProjectGroupID As Int32 = GVcostProjectGroupProjects.DataKeys(e.CommandArgument).Values("ProjectGroupID")  
        Dim ProjectID As String = GVcostProjectGroupProjects.DataKeys(e.CommandArgument).Values("ProjectID")  
        Dim RedirectUrl As String = TBLcostProjectGroupProjects.EditUrl & "?ProjectGroupID=" & ProjectGroupID & "&ProjectID=" & ProjectID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub TBLcostProjectGroupProjects_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLcostProjectGroupProjects.AddClicked
    Dim ProjectGroupID As Int32 = CType(FVcostProjectGroups.FindControl("F_ProjectGroupID"),TextBox).Text
    TBLcostProjectGroupProjects.AddUrl &= "?ProjectGroupID=" & ProjectGroupID
  End Sub
  Private WithEvents gvcostCostSheetCC As New gvBase
  Protected Sub GVcostCostSheet_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVcostCostSheet.Init
    gvcostCostSheetCC.DataClassName = "GcostCostSheet"
    gvcostCostSheetCC.SetGridView = GVcostCostSheet
  End Sub
  Protected Sub TBLcostCostSheet_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostCostSheet.Init
    gvcostCostSheetCC.SetToolBar = TBLcostCostSheet
  End Sub
  Protected Sub GVcostCostSheet_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVcostCostSheet.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ProjectGroupID As Int32 = GVcostCostSheet.DataKeys(e.CommandArgument).Values("ProjectGroupID")  
        Dim FinYear As Int32 = GVcostCostSheet.DataKeys(e.CommandArgument).Values("FinYear")  
        Dim Quarter As Int32 = GVcostCostSheet.DataKeys(e.CommandArgument).Values("Quarter")  
        Dim Revision As Int32 = GVcostCostSheet.DataKeys(e.CommandArgument).Values("Revision")  
        Dim RedirectUrl As String = TBLcostCostSheet.EditUrl & "?ProjectGroupID=" & ProjectGroupID & "&FinYear=" & FinYear & "&Quarter=" & Quarter & "&Revision=" & Revision
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "Downloadwf".ToLower Then
      Try
        Dim ProjectGroupID As Int32 = GVcostCostSheet.DataKeys(e.CommandArgument).Values("ProjectGroupID")  
        Dim FinYear As Int32 = GVcostCostSheet.DataKeys(e.CommandArgument).Values("FinYear")  
        Dim Quarter As Int32 = GVcostCostSheet.DataKeys(e.CommandArgument).Values("Quarter")  
        Dim Revision As Int32 = GVcostCostSheet.DataKeys(e.CommandArgument).Values("Revision")  
        SIS.COST.costCostSheet.DownloadWF(ProjectGroupID, FinYear, Quarter, Revision)
        GVcostCostSheet.DataBind()
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "Updatewf".ToLower Then
      Try
        Dim ProjectGroupID As Int32 = GVcostCostSheet.DataKeys(e.CommandArgument).Values("ProjectGroupID")  
        Dim FinYear As Int32 = GVcostCostSheet.DataKeys(e.CommandArgument).Values("FinYear")  
        Dim Quarter As Int32 = GVcostCostSheet.DataKeys(e.CommandArgument).Values("Quarter")  
        Dim Revision As Int32 = GVcostCostSheet.DataKeys(e.CommandArgument).Values("Revision")  
        SIS.COST.costCostSheet.UpdateWF(ProjectGroupID, FinYear, Quarter, Revision)
        GVcostCostSheet.DataBind()
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim ProjectGroupID As Int32 = GVcostCostSheet.DataKeys(e.CommandArgument).Values("ProjectGroupID")  
        Dim FinYear As Int32 = GVcostCostSheet.DataKeys(e.CommandArgument).Values("FinYear")  
        Dim Quarter As Int32 = GVcostCostSheet.DataKeys(e.CommandArgument).Values("Quarter")  
        Dim Revision As Int32 = GVcostCostSheet.DataKeys(e.CommandArgument).Values("Revision")  
        SIS.COST.costCostSheet.InitiateWF(ProjectGroupID, FinYear, Quarter, Revision)
        GVcostCostSheet.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub

End Class
