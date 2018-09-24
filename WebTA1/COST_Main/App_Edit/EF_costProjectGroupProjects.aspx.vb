Partial Class EF_costProjectGroupProjects
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
  Protected Sub ODScostProjectGroupProjects_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODScostProjectGroupProjects.Selected
    Dim tmp As SIS.COST.costProjectGroupProjects = CType(e.ReturnValue, SIS.COST.costProjectGroupProjects)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVcostProjectGroupProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostProjectGroupProjects.Init
    DataClassName = "EcostProjectGroupProjects"
    SetFormView = FVcostProjectGroupProjects
  End Sub
  Protected Sub TBLcostProjectGroupProjects_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostProjectGroupProjects.Init
    SetToolBar = TBLcostProjectGroupProjects
  End Sub
  Protected Sub FVcostProjectGroupProjects_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostProjectGroupProjects.PreRender
    TBLcostProjectGroupProjects.EnableSave = Editable
    TBLcostProjectGroupProjects.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Edit") & "/EF_costProjectGroupProjects.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostProjectGroupProjects") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostProjectGroupProjects", mStr)
    End If
  End Sub

End Class
