Partial Class EF_costQuarters
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
  Protected Sub ODScostQuarters_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODScostQuarters.Selected
    Dim tmp As SIS.COST.costQuarters = CType(e.ReturnValue, SIS.COST.costQuarters)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVcostQuarters_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostQuarters.Init
    DataClassName = "EcostQuarters"
    SetFormView = FVcostQuarters
  End Sub
  Protected Sub TBLcostQuarters_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostQuarters.Init
    SetToolBar = TBLcostQuarters
  End Sub
  Protected Sub FVcostQuarters_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostQuarters.PreRender
    TBLcostQuarters.EnableSave = Editable
    TBLcostQuarters.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Edit") & "/EF_costQuarters.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostQuarters") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostQuarters", mStr)
    End If
  End Sub

End Class
