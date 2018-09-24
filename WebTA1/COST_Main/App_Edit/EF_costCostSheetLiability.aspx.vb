Partial Class EF_costCostSheetLiability
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
  Protected Sub ODScostCostSheetLiability_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODScostCostSheetLiability.Selected
    Dim tmp As SIS.COST.costCostSheetLiability = CType(e.ReturnValue, SIS.COST.costCostSheetLiability)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVcostCostSheetLiability_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostCostSheetLiability.Init
    DataClassName = "EcostCostSheetLiability"
    SetFormView = FVcostCostSheetLiability
  End Sub
  Protected Sub TBLcostCostSheetLiability_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostCostSheetLiability.Init
    SetToolBar = TBLcostCostSheetLiability
  End Sub
  Protected Sub FVcostCostSheetLiability_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostCostSheetLiability.PreRender
    TBLcostCostSheetLiability.EnableSave = Editable
    TBLcostCostSheetLiability.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Edit") & "/EF_costCostSheetLiability.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostCostSheetLiability") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostCostSheetLiability", mStr)
    End If
  End Sub

End Class
