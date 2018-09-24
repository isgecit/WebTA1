Partial Class EF_taD_TravelModes
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
  Protected Sub ODStaD_TravelModes_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaD_TravelModes.Selected
    Dim tmp As SIS.TA.taD_TravelModes = CType(e.ReturnValue, SIS.TA.taD_TravelModes)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaD_TravelModes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_TravelModes.Init
    DataClassName = "EtaD_TravelModes"
    SetFormView = FVtaD_TravelModes
  End Sub
  Protected Sub TBLtaD_TravelModes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaD_TravelModes.Init
    SetToolBar = TBLtaD_TravelModes
  End Sub
  Protected Sub FVtaD_TravelModes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_TravelModes.PreRender
    TBLtaD_TravelModes.EnableSave = Editable
    TBLtaD_TravelModes.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taD_TravelModes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaD_TravelModes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaD_TravelModes", mStr)
    End If
  End Sub

End Class
