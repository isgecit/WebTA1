Partial Class EF_costQProjects
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
  Protected Sub ODScostQProjects_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODScostQProjects.Selected
    Dim tmp As SIS.COST.costQProjects = CType(e.ReturnValue, SIS.COST.costQProjects)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVcostQProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostQProjects.Init
    DataClassName = "EcostQProjects"
    SetFormView = FVcostQProjects
  End Sub
  Protected Sub TBLcostQProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostQProjects.Init
    SetToolBar = TBLcostQProjects
  End Sub
  Protected Sub FVcostQProjects_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostQProjects.PreRender
    TBLcostQProjects.EnableSave = Editable
    TBLcostQProjects.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Edit") & "/EF_costQProjects.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostQProjects") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostQProjects", mStr)
    End If
  End Sub

End Class
