Partial Class EF_costWorkOrderTypes
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
  Protected Sub ODScostWorkOrderTypes_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODScostWorkOrderTypes.Selected
    Dim tmp As SIS.COST.costWorkOrderTypes = CType(e.ReturnValue, SIS.COST.costWorkOrderTypes)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVcostWorkOrderTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostWorkOrderTypes.Init
    DataClassName = "EcostWorkOrderTypes"
    SetFormView = FVcostWorkOrderTypes
  End Sub
  Protected Sub TBLcostWorkOrderTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostWorkOrderTypes.Init
    SetToolBar = TBLcostWorkOrderTypes
  End Sub
  Protected Sub FVcostWorkOrderTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostWorkOrderTypes.PreRender
    TBLcostWorkOrderTypes.EnableSave = Editable
    TBLcostWorkOrderTypes.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Edit") & "/EF_costWorkOrderTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostWorkOrderTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostWorkOrderTypes", mStr)
    End If
  End Sub

End Class
