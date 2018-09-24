Partial Class EF_costGLNatures
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
  Protected Sub ODScostGLNatures_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODScostGLNatures.Selected
    Dim tmp As SIS.COST.costGLNatures = CType(e.ReturnValue, SIS.COST.costGLNatures)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVcostGLNatures_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostGLNatures.Init
    DataClassName = "EcostGLNatures"
    SetFormView = FVcostGLNatures
  End Sub
  Protected Sub TBLcostGLNatures_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostGLNatures.Init
    SetToolBar = TBLcostGLNatures
  End Sub
  Protected Sub FVcostGLNatures_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostGLNatures.PreRender
    TBLcostGLNatures.EnableSave = Editable
    TBLcostGLNatures.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Edit") & "/EF_costGLNatures.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostGLNatures") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostGLNatures", mStr)
    End If
  End Sub

End Class
