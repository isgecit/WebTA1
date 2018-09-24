Partial Class EF_costFinYearProjects
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
  Protected Sub ODScostFinYearProjects_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODScostFinYearProjects.Selected
    Dim tmp As SIS.COST.costFinYearProjects = CType(e.ReturnValue, SIS.COST.costFinYearProjects)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVcostFinYearProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostFinYearProjects.Init
    DataClassName = "EcostFinYearProjects"
    SetFormView = FVcostFinYearProjects
  End Sub
  Protected Sub TBLcostFinYearProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostFinYearProjects.Init
    SetToolBar = TBLcostFinYearProjects
  End Sub
  Protected Sub FVcostFinYearProjects_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostFinYearProjects.PreRender
    TBLcostFinYearProjects.EnableSave = Editable
    TBLcostFinYearProjects.EnableDelete = Deleteable
    TBLcostFinYearProjects.PrintUrl &= Request.QueryString("FinYear") & "|"
    TBLcostFinYearProjects.PrintUrl &= Request.QueryString("Quarter") & "|"
    TBLcostFinYearProjects.PrintUrl &= Request.QueryString("ProjectID") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Edit") & "/EF_costFinYearProjects.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostFinYearProjects") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostFinYearProjects", mStr)
    End If
  End Sub

End Class
