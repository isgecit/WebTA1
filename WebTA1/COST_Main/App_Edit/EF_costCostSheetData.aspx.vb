Partial Class EF_costCostSheetData
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
  Protected Sub ODScostCostSheetData_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODScostCostSheetData.Selected
    Dim tmp As SIS.COST.costCostSheetData = CType(e.ReturnValue, SIS.COST.costCostSheetData)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVcostCostSheetData_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostCostSheetData.Init
    DataClassName = "EcostCostSheetData"
    SetFormView = FVcostCostSheetData
  End Sub
  Protected Sub TBLcostCostSheetData_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostCostSheetData.Init
    SetToolBar = TBLcostCostSheetData
  End Sub
  Protected Sub FVcostCostSheetData_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostCostSheetData.PreRender
    TBLcostCostSheetData.EnableSave = Editable
    TBLcostCostSheetData.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Edit") & "/EF_costCostSheetData.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostCostSheetData") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostCostSheetData", mStr)
    End If
  End Sub

End Class
