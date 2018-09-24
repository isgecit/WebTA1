Partial Class EF_costCSDWOnGLGr
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
  Protected Sub ODScostCSDWOnGLGr_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODScostCSDWOnGLGr.Selected
    Dim tmp As SIS.COST.costCSDWOnGLGr = CType(e.ReturnValue, SIS.COST.costCSDWOnGLGr)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVcostCSDWOnGLGr_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostCSDWOnGLGr.Init
    DataClassName = "EcostCSDWOnGLGr"
    SetFormView = FVcostCSDWOnGLGr
  End Sub
  Protected Sub TBLcostCSDWOnGLGr_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostCSDWOnGLGr.Init
    SetToolBar = TBLcostCSDWOnGLGr
  End Sub
  Protected Sub FVcostCSDWOnGLGr_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostCSDWOnGLGr.PreRender
    TBLcostCSDWOnGLGr.EnableSave = Editable
    TBLcostCSDWOnGLGr.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Edit") & "/EF_costCSDWOnGLGr.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostCSDWOnGLGr") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostCSDWOnGLGr", mStr)
    End If
  End Sub

End Class
