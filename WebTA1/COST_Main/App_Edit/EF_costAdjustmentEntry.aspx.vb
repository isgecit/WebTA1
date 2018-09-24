Partial Class EF_costAdjustmentEntry
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
  Protected Sub ODScostAdjustmentEntry_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODScostAdjustmentEntry.Selected
    Dim tmp As SIS.COST.costAdjustmentEntry = CType(e.ReturnValue, SIS.COST.costAdjustmentEntry)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVcostAdjustmentEntry_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostAdjustmentEntry.Init
    DataClassName = "EcostAdjustmentEntry"
    SetFormView = FVcostAdjustmentEntry
  End Sub
  Protected Sub TBLcostAdjustmentEntry_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostAdjustmentEntry.Init
    SetToolBar = TBLcostAdjustmentEntry
  End Sub
  Protected Sub FVcostAdjustmentEntry_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostAdjustmentEntry.PreRender
    TBLcostAdjustmentEntry.EnableSave = Editable
    TBLcostAdjustmentEntry.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Edit") & "/EF_costAdjustmentEntry.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostAdjustmentEntry") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostAdjustmentEntry", mStr)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.COST.costProjects.SelectcostProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function CrGLCodeCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.COST.costERPGLCodes.SelectcostERPGLCodesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function DrGLCodeCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.COST.costERPGLCodes.SelectcostERPGLCodesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_COST_AdjustmentEntry_CrGLCode(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim CrGLCode As String = CType(aVal(1),String)
    Dim oVar As SIS.COST.costERPGLCodes = SIS.COST.costERPGLCodes.costERPGLCodesGetByID(CrGLCode)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_COST_AdjustmentEntry_DrGLCode(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim DrGLCode As String = CType(aVal(1),String)
    Dim oVar As SIS.COST.costERPGLCodes = SIS.COST.costERPGLCodes.costERPGLCodesGetByID(DrGLCode)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_COST_AdjustmentEntry_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1),String)
    Dim oVar As SIS.COST.costProjects = SIS.COST.costProjects.costProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
