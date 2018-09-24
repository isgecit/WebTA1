Partial Class EF_costERPGLCodes
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
  Protected Sub ODScostERPGLCodes_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODScostERPGLCodes.Selected
    Dim tmp As SIS.COST.costERPGLCodes = CType(e.ReturnValue, SIS.COST.costERPGLCodes)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVcostERPGLCodes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostERPGLCodes.Init
    DataClassName = "EcostERPGLCodes"
    SetFormView = FVcostERPGLCodes
  End Sub
  Protected Sub TBLcostERPGLCodes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostERPGLCodes.Init
    SetToolBar = TBLcostERPGLCodes
  End Sub
  Protected Sub FVcostERPGLCodes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostERPGLCodes.PreRender
    TBLcostERPGLCodes.EnableSave = Editable
    TBLcostERPGLCodes.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Edit") & "/EF_costERPGLCodes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostERPGLCodes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostERPGLCodes", mStr)
    End If
  End Sub

End Class
