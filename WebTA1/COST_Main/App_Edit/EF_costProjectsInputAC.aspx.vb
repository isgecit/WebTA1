Partial Class EF_costProjectsInputAC
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
  Protected Sub ODScostProjectsInputAC_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODScostProjectsInputAC.Selected
    Dim tmp As SIS.COST.costProjectsInputAC = CType(e.ReturnValue, SIS.COST.costProjectsInputAC)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVcostProjectsInputAC_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostProjectsInputAC.Init
    DataClassName = "EcostProjectsInputAC"
    SetFormView = FVcostProjectsInputAC
  End Sub
  Protected Sub TBLcostProjectsInputAC_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostProjectsInputAC.Init
    SetToolBar = TBLcostProjectsInputAC
  End Sub
  Protected Sub FVcostProjectsInputAC_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostProjectsInputAC.PreRender
    TBLcostProjectsInputAC.EnableSave = Editable
    TBLcostProjectsInputAC.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Edit") & "/EF_costProjectsInputAC.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostProjectsInputAC") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostProjectsInputAC", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvcostProjectInputFilesCC As New gvBase
  Protected Sub GVcostProjectInputFiles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVcostProjectInputFiles.Init
    gvcostProjectInputFilesCC.DataClassName = "GcostProjectInputFiles"
    gvcostProjectInputFilesCC.SetGridView = GVcostProjectInputFiles
  End Sub
  Protected Sub TBLcostProjectInputFiles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostProjectInputFiles.Init
    gvcostProjectInputFilesCC.SetToolBar = TBLcostProjectInputFiles
  End Sub
  Protected Sub GVcostProjectInputFiles_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVcostProjectInputFiles.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ProjectGroupID As Int32 = GVcostProjectInputFiles.DataKeys(e.CommandArgument).Values("ProjectGroupID")  
        Dim FinYear As Int32 = GVcostProjectInputFiles.DataKeys(e.CommandArgument).Values("FinYear")  
        Dim Quarter As Int32 = GVcostProjectInputFiles.DataKeys(e.CommandArgument).Values("Quarter")  
        Dim SerialNo As Int32 = GVcostProjectInputFiles.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLcostProjectInputFiles.EditUrl & "?ProjectGroupID=" & ProjectGroupID & "&FinYear=" & FinYear & "&Quarter=" & Quarter & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub

End Class
