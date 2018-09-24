Partial Class EF_taCityTypes
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
  Protected Sub ODStaCityTypes_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaCityTypes.Selected
    Dim tmp As SIS.TA.taCityTypes = CType(e.ReturnValue, SIS.TA.taCityTypes)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaCityTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCityTypes.Init
    DataClassName = "EtaCityTypes"
    SetFormView = FVtaCityTypes
  End Sub
  Protected Sub TBLtaCityTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaCityTypes.Init
    SetToolBar = TBLtaCityTypes
  End Sub
  Protected Sub FVtaCityTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaCityTypes.PreRender
    TBLtaCityTypes.EnableSave = Editable
    TBLtaCityTypes.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taCityTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaCityTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaCityTypes", mStr)
    End If
  End Sub

End Class
