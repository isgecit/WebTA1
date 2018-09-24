Partial Class EF_taBillStates
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
  Protected Sub ODStaBillStates_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaBillStates.Selected
    Dim tmp As SIS.TA.taBillStates = CType(e.ReturnValue, SIS.TA.taBillStates)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaBillStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBillStates.Init
    DataClassName = "EtaBillStates"
    SetFormView = FVtaBillStates
  End Sub
  Protected Sub TBLtaBillStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaBillStates.Init
    SetToolBar = TBLtaBillStates
  End Sub
  Protected Sub FVtaBillStates_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaBillStates.PreRender
    TBLtaBillStates.EnableSave = Editable
    TBLtaBillStates.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taBillStates.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaBillStates") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaBillStates", mStr)
    End If
  End Sub

End Class
