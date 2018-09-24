Partial Class EF_costGLGroupGLs
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
  Protected Sub ODScostGLGroupGLs_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODScostGLGroupGLs.Selected
    Dim tmp As SIS.COST.costGLGroupGLs = CType(e.ReturnValue, SIS.COST.costGLGroupGLs)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVcostGLGroupGLs_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostGLGroupGLs.Init
    DataClassName = "EcostGLGroupGLs"
    SetFormView = FVcostGLGroupGLs
  End Sub
  Protected Sub TBLcostGLGroupGLs_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostGLGroupGLs.Init
    SetToolBar = TBLcostGLGroupGLs
  End Sub
  Protected Sub FVcostGLGroupGLs_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostGLGroupGLs.PreRender
    TBLcostGLGroupGLs.EnableSave = Editable
    TBLcostGLGroupGLs.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Edit") & "/EF_costGLGroupGLs.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostGLGroupGLs") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostGLGroupGLs", mStr)
    End If
  End Sub

End Class
