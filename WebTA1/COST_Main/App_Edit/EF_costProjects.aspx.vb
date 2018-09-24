Partial Class EF_costProjects
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
  Protected Sub ODScostProjects_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODScostProjects.Selected
    Dim tmp As SIS.COST.costProjects = CType(e.ReturnValue, SIS.COST.costProjects)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVcostProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostProjects.Init
    DataClassName = "EcostProjects"
    SetFormView = FVcostProjects
  End Sub
  Protected Sub TBLcostProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostProjects.Init
    SetToolBar = TBLcostProjects
  End Sub
  Protected Sub FVcostProjects_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostProjects.PreRender
    TBLcostProjects.EnableSave = Editable
    TBLcostProjects.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Edit") & "/EF_costProjects.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostProjects") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostProjects", mStr)
    End If
  End Sub

End Class
