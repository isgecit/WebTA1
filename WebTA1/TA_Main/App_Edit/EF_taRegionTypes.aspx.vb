Partial Class EF_taRegionTypes
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
  Protected Sub ODStaRegionTypes_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaRegionTypes.Selected
    Dim tmp As SIS.TA.taRegionTypes = CType(e.ReturnValue, SIS.TA.taRegionTypes)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaRegionTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaRegionTypes.Init
    DataClassName = "EtaRegionTypes"
    SetFormView = FVtaRegionTypes
  End Sub
  Protected Sub TBLtaRegionTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaRegionTypes.Init
    SetToolBar = TBLtaRegionTypes
  End Sub
  Protected Sub FVtaRegionTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaRegionTypes.PreRender
    TBLtaRegionTypes.EnableSave = Editable
    TBLtaRegionTypes.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taRegionTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaRegionTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaRegionTypes", mStr)
    End If
  End Sub
End Class
