Partial Class EF_taLCModes
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
  Protected Sub ODStaLCModes_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaLCModes.Selected
    Dim tmp As SIS.TA.taLCModes = CType(e.ReturnValue, SIS.TA.taLCModes)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaLCModes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaLCModes.Init
    DataClassName = "EtaLCModes"
    SetFormView = FVtaLCModes
  End Sub
  Protected Sub TBLtaLCModes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaLCModes.Init
    SetToolBar = TBLtaLCModes
  End Sub
  Protected Sub FVtaLCModes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaLCModes.PreRender
    TBLtaLCModes.EnableSave = Editable
    TBLtaLCModes.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taLCModes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaLCModes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaLCModes", mStr)
    End If
  End Sub

End Class
