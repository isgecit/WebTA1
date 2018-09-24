Partial Class EF_taTravelTypes
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
  Protected Sub ODStaTravelTypes_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaTravelTypes.Selected
    Dim tmp As SIS.TA.taTravelTypes = CType(e.ReturnValue, SIS.TA.taTravelTypes)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaTravelTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaTravelTypes.Init
    DataClassName = "EtaTravelTypes"
    SetFormView = FVtaTravelTypes
  End Sub
  Protected Sub TBLtaTravelTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaTravelTypes.Init
    SetToolBar = TBLtaTravelTypes
  End Sub
  Protected Sub FVtaTravelTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaTravelTypes.PreRender
    TBLtaTravelTypes.EnableSave = Editable
    TBLtaTravelTypes.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taTravelTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaTravelTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaTravelTypes", mStr)
    End If
  End Sub

End Class
