Partial Class EF_costCSDataWOnGLGroup
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
  Protected Sub ODScostCSDataWOnGLGroup_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODScostCSDataWOnGLGroup.Selected
    Dim tmp As SIS.COST.costCSDataWOnGLGroup = CType(e.ReturnValue, SIS.COST.costCSDataWOnGLGroup)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVcostCSDataWOnGLGroup_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostCSDataWOnGLGroup.Init
    DataClassName = "EcostCSDataWOnGLGroup"
    SetFormView = FVcostCSDataWOnGLGroup
  End Sub
  Protected Sub TBLcostCSDataWOnGLGroup_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostCSDataWOnGLGroup.Init
    SetToolBar = TBLcostCSDataWOnGLGroup
  End Sub
  Protected Sub FVcostCSDataWOnGLGroup_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostCSDataWOnGLGroup.PreRender
    TBLcostCSDataWOnGLGroup.EnableSave = Editable
    TBLcostCSDataWOnGLGroup.EnableDelete = Deleteable
    TBLcostCSDataWOnGLGroup.PrintUrl &= Request.QueryString("ProjectGroupID") & "|"
    TBLcostCSDataWOnGLGroup.PrintUrl &= Request.QueryString("FinYear") & "|"
    TBLcostCSDataWOnGLGroup.PrintUrl &= Request.QueryString("Quarter") & "|"
    TBLcostCSDataWOnGLGroup.PrintUrl &= Request.QueryString("Revision") & "|"
    TBLcostCSDataWOnGLGroup.PrintUrl &= Request.QueryString("WorkOrderTypeID") & "|"
    TBLcostCSDataWOnGLGroup.PrintUrl &= Request.QueryString("GLGroupID") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Edit") & "/EF_costCSDataWOnGLGroup.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostCSDataWOnGLGroup") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostCSDataWOnGLGroup", mStr)
    End If
  End Sub

End Class
