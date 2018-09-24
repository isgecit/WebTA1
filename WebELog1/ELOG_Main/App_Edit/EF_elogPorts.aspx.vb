Partial Class EF_elogPorts
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
  Protected Sub ODSelogPorts_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSelogPorts.Selected
    Dim tmp As SIS.ELOG.elogPorts = CType(e.ReturnValue, SIS.ELOG.elogPorts)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVelogPorts_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogPorts.Init
    DataClassName = "EelogPorts"
    SetFormView = FVelogPorts
  End Sub
  Protected Sub TBLelogPorts_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogPorts.Init
    SetToolBar = TBLelogPorts
  End Sub
  Protected Sub FVelogPorts_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogPorts.PreRender
    TBLelogPorts.EnableSave = Editable
    TBLelogPorts.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Edit") & "/EF_elogPorts.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogPorts") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogPorts", mStr)
    End If
  End Sub

End Class
