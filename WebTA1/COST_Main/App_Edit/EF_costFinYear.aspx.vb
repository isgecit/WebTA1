Partial Class EF_costFinYear
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
  Protected Sub ODScostFinYear_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODScostFinYear.Selected
    Dim tmp As SIS.COST.costFinYear = CType(e.ReturnValue, SIS.COST.costFinYear)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVcostFinYear_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostFinYear.Init
    DataClassName = "EcostFinYear"
    SetFormView = FVcostFinYear
  End Sub
  Protected Sub TBLcostFinYear_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostFinYear.Init
    SetToolBar = TBLcostFinYear
  End Sub
  Protected Sub FVcostFinYear_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostFinYear.PreRender
    TBLcostFinYear.EnableSave = Editable
    TBLcostFinYear.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Edit") & "/EF_costFinYear.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostFinYear") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostFinYear", mStr)
    End If
  End Sub

End Class
