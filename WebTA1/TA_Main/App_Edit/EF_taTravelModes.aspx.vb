Partial Class EF_taTravelModes
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
  Protected Sub ODStaTravelModes_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaTravelModes.Selected
    Dim tmp As SIS.TA.taTravelModes = CType(e.ReturnValue, SIS.TA.taTravelModes)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaTravelModes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaTravelModes.Init
    DataClassName = "EtaTravelModes"
    SetFormView = FVtaTravelModes
  End Sub
  Protected Sub TBLtaTravelModes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaTravelModes.Init
    SetToolBar = TBLtaTravelModes
  End Sub
  Protected Sub FVtaTravelModes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaTravelModes.PreRender
    TBLtaTravelModes.EnableSave = Editable
    TBLtaTravelModes.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taTravelModes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaTravelModes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaTravelModes", mStr)
    End If
  End Sub

End Class
