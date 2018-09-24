Partial Class EF_costProjectTypes
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
  Protected Sub ODScostProjectTypes_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODScostProjectTypes.Selected
    Dim tmp As SIS.COST.costProjectTypes = CType(e.ReturnValue, SIS.COST.costProjectTypes)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVcostProjectTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostProjectTypes.Init
    DataClassName = "EcostProjectTypes"
    SetFormView = FVcostProjectTypes
  End Sub
  Protected Sub TBLcostProjectTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcostProjectTypes.Init
    SetToolBar = TBLcostProjectTypes
  End Sub
  Protected Sub FVcostProjectTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcostProjectTypes.PreRender
    TBLcostProjectTypes.EnableSave = Editable
    TBLcostProjectTypes.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/COST_Main/App_Edit") & "/EF_costProjectTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcostProjectTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcostProjectTypes", mStr)
    End If
  End Sub

End Class
