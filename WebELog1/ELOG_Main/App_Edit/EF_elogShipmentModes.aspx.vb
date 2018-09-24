Partial Class EF_elogShipmentModes
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
  Protected Sub ODSelogShipmentModes_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSelogShipmentModes.Selected
    Dim tmp As SIS.ELOG.elogShipmentModes = CType(e.ReturnValue, SIS.ELOG.elogShipmentModes)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVelogShipmentModes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogShipmentModes.Init
    DataClassName = "EelogShipmentModes"
    SetFormView = FVelogShipmentModes
  End Sub
  Protected Sub TBLelogShipmentModes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogShipmentModes.Init
    SetToolBar = TBLelogShipmentModes
  End Sub
  Protected Sub FVelogShipmentModes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogShipmentModes.PreRender
    TBLelogShipmentModes.EnableSave = Editable
    TBLelogShipmentModes.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Edit") & "/EF_elogShipmentModes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogShipmentModes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogShipmentModes", mStr)
    End If
  End Sub

End Class
