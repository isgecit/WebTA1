Partial Class EF_costCostSheet
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
  Protected Sub ODScostCostSheet_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODScostCostSheet.Selected
    Dim tmp As SIS.COST.costCostSheet = CType(e.ReturnValue, SIS.COST.costCostSheet)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVcostCostSheet_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostCostSheet.Init
    DataClassName = "EcostCostSheet"
    SetFormView = FVcostCostSheet
  End Sub
  Protected Sub TBLcostCostSheet_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostCostSheet.Init
    SetToolBar = TBLcostCostSheet
  End Sub
  Protected Sub FVcostCostSheet_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostCostSheet.PreRender
    TBLcostCostSheet.EnableSave = Editable
    TBLcostCostSheet.EnableDelete = Deleteable
    TBLcostCostSheet.PrintUrl &= Request.QueryString("ProjectGroupID") & "|"
    TBLcostCostSheet.PrintUrl &= Request.QueryString("FinYear") & "|"
    TBLcostCostSheet.PrintUrl &= Request.QueryString("Quarter") & "|"
    TBLcostCostSheet.PrintUrl &= Request.QueryString("Revision") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Edit") & "/EF_costCostSheet.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostCostSheet") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostCostSheet", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvcostProjectsInputACCC As New gvBase
  Protected Sub GVcostProjectsInputAC_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVcostProjectsInputAC.Init
    gvcostProjectsInputACCC.DataClassName = "GcostProjectsInputAC"
    gvcostProjectsInputACCC.SetGridView = GVcostProjectsInputAC
  End Sub
  Protected Sub TBLcostProjectsInputAC_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostProjectsInputAC.Init
    gvcostProjectsInputACCC.SetToolBar = TBLcostProjectsInputAC
  End Sub
  Protected Sub GVcostProjectsInputAC_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVcostProjectsInputAC.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ProjectGroupID As Int32 = GVcostProjectsInputAC.DataKeys(e.CommandArgument).Values("ProjectGroupID")  
        Dim FinYear As Int32 = GVcostProjectsInputAC.DataKeys(e.CommandArgument).Values("FinYear")  
        Dim Quarter As Int32 = GVcostProjectsInputAC.DataKeys(e.CommandArgument).Values("Quarter")  
        Dim RedirectUrl As String = TBLcostProjectsInputAC.EditUrl & "?ProjectGroupID=" & ProjectGroupID & "&FinYear=" & FinYear & "&Quarter=" & Quarter
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Private WithEvents gvcostAdjustmentEntryCC As New gvBase
  Protected Sub GVcostAdjustmentEntry_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVcostAdjustmentEntry.Init
    gvcostAdjustmentEntryCC.DataClassName = "GcostAdjustmentEntry"
    gvcostAdjustmentEntryCC.SetGridView = GVcostAdjustmentEntry
  End Sub
  Protected Sub TBLcostAdjustmentEntry_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostAdjustmentEntry.Init
    gvcostAdjustmentEntryCC.SetToolBar = TBLcostAdjustmentEntry
  End Sub
  Protected Sub GVcostAdjustmentEntry_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVcostAdjustmentEntry.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ProjectGroupID As Int32 = GVcostAdjustmentEntry.DataKeys(e.CommandArgument).Values("ProjectGroupID")  
        Dim FinYear As Int32 = GVcostAdjustmentEntry.DataKeys(e.CommandArgument).Values("FinYear")  
        Dim Quarter As Int32 = GVcostAdjustmentEntry.DataKeys(e.CommandArgument).Values("Quarter")  
        Dim Revision As Int32 = GVcostAdjustmentEntry.DataKeys(e.CommandArgument).Values("Revision")  
        Dim AdjustmentSerialNo As Int32 = GVcostAdjustmentEntry.DataKeys(e.CommandArgument).Values("AdjustmentSerialNo")  
        Dim RedirectUrl As String = TBLcostAdjustmentEntry.EditUrl & "?ProjectGroupID=" & ProjectGroupID & "&FinYear=" & FinYear & "&Quarter=" & Quarter & "&Revision=" & Revision & "&AdjustmentSerialNo=" & AdjustmentSerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub TBLcostAdjustmentEntry_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLcostAdjustmentEntry.AddClicked
    Dim ProjectGroupID As Int32 = CType(FVcostCostSheet.FindControl("F_ProjectGroupID"),TextBox).Text
    Dim FinYear As Int32 = CType(FVcostCostSheet.FindControl("F_FinYear"),TextBox).Text
    Dim Quarter As Int32 = CType(FVcostCostSheet.FindControl("F_Quarter"),TextBox).Text
    Dim Revision As Int32 = CType(FVcostCostSheet.FindControl("F_Revision"),TextBox).Text
    TBLcostAdjustmentEntry.AddUrl &= "?ProjectGroupID=" & ProjectGroupID
    TBLcostAdjustmentEntry.AddUrl &= "&FinYear=" & FinYear
    TBLcostAdjustmentEntry.AddUrl &= "&Quarter=" & Quarter
    TBLcostAdjustmentEntry.AddUrl &= "&Revision=" & Revision
  End Sub
  Private WithEvents gvcostCSDWOnGLGrCC As New gvBase
  Protected Sub GVcostCSDWOnGLGr_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVcostCSDWOnGLGr.Init
    gvcostCSDWOnGLGrCC.DataClassName = "GcostCSDWOnGLGr"
    gvcostCSDWOnGLGrCC.SetGridView = GVcostCSDWOnGLGr
  End Sub
  Protected Sub TBLcostCSDWOnGLGr_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostCSDWOnGLGr.Init
    gvcostCSDWOnGLGrCC.SetToolBar = TBLcostCSDWOnGLGr
  End Sub
  Protected Sub GVcostCSDWOnGLGr_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVcostCSDWOnGLGr.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ProjectGroupID As Int32 = GVcostCSDWOnGLGr.DataKeys(e.CommandArgument).Values("ProjectGroupID")  
        Dim FinYear As Int32 = GVcostCSDWOnGLGr.DataKeys(e.CommandArgument).Values("FinYear")  
        Dim Quarter As Int32 = GVcostCSDWOnGLGr.DataKeys(e.CommandArgument).Values("Quarter")  
        Dim Revision As Int32 = GVcostCSDWOnGLGr.DataKeys(e.CommandArgument).Values("Revision")  
        Dim WorkOrderTypeID As Int32 = GVcostCSDWOnGLGr.DataKeys(e.CommandArgument).Values("WorkOrderTypeID")  
        Dim GLGroupID As Int32 = GVcostCSDWOnGLGr.DataKeys(e.CommandArgument).Values("GLGroupID")  
        Dim RedirectUrl As String = TBLcostCSDWOnGLGr.EditUrl & "?ProjectGroupID=" & ProjectGroupID & "&FinYear=" & FinYear & "&Quarter=" & Quarter & "&Revision=" & Revision & "&WorkOrderTypeID=" & WorkOrderTypeID & "&GLGroupID=" & GLGroupID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Private WithEvents gvcostCostSheetDataCC As New gvBase
  Protected Sub GVcostCostSheetData_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVcostCostSheetData.Init
    gvcostCostSheetDataCC.DataClassName = "GcostCostSheetData"
    gvcostCostSheetDataCC.SetGridView = GVcostCostSheetData
  End Sub
  Protected Sub TBLcostCostSheetData_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostCostSheetData.Init
    gvcostCostSheetDataCC.SetToolBar = TBLcostCostSheetData
  End Sub
  Protected Sub GVcostCostSheetData_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVcostCostSheetData.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ProjectGroupID As Int32 = GVcostCostSheetData.DataKeys(e.CommandArgument).Values("ProjectGroupID")  
        Dim FinYear As Int32 = GVcostCostSheetData.DataKeys(e.CommandArgument).Values("FinYear")  
        Dim Quarter As Int32 = GVcostCostSheetData.DataKeys(e.CommandArgument).Values("Quarter")  
        Dim Revision As Int32 = GVcostCostSheetData.DataKeys(e.CommandArgument).Values("Revision")  
        Dim ProjectID As String = GVcostCostSheetData.DataKeys(e.CommandArgument).Values("ProjectID")  
        Dim GLCode As String = GVcostCostSheetData.DataKeys(e.CommandArgument).Values("GLCode")  
        Dim AdjustmentSerialNo As Int32 = GVcostCostSheetData.DataKeys(e.CommandArgument).Values("AdjustmentSerialNo")  
        Dim AdjustmentCredit As Boolean = GVcostCostSheetData.DataKeys(e.CommandArgument).Values("AdjustmentCredit")  
        Dim RedirectUrl As String = TBLcostCostSheetData.EditUrl & "?ProjectGroupID=" & ProjectGroupID & "&FinYear=" & FinYear & "&Quarter=" & Quarter & "&Revision=" & Revision & "&ProjectID=" & ProjectID & "&GLCode=" & GLCode & "&AdjustmentSerialNo=" & AdjustmentSerialNo & "&AdjustmentCredit=" & AdjustmentCredit
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub

End Class
