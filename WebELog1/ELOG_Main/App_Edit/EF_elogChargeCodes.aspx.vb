Partial Class EF_elogChargeCodes
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
  Protected Sub ODSelogChargeCodes_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSelogChargeCodes.Selected
    Dim tmp As SIS.ELOG.elogChargeCodes = CType(e.ReturnValue, SIS.ELOG.elogChargeCodes)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVelogChargeCodes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogChargeCodes.Init
    DataClassName = "EelogChargeCodes"
    SetFormView = FVelogChargeCodes
  End Sub
  Protected Sub TBLelogChargeCodes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogChargeCodes.Init
    SetToolBar = TBLelogChargeCodes
  End Sub
  Protected Sub FVelogChargeCodes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogChargeCodes.PreRender
    TBLelogChargeCodes.EnableSave = Editable
    TBLelogChargeCodes.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Edit") & "/EF_elogChargeCodes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogChargeCodes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogChargeCodes", mStr)
    End If
  End Sub

End Class
