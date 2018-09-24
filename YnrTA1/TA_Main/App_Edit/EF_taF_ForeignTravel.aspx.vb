Partial Class EF_taF_ForeignTravel
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
  Protected Sub ODStaF_ForeignTravel_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaF_ForeignTravel.Selected
    Dim tmp As SIS.TA.taF_ForeignTravel = CType(e.ReturnValue, SIS.TA.taF_ForeignTravel)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaF_ForeignTravel_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaF_ForeignTravel.Init
    DataClassName = "EtaF_ForeignTravel"
    SetFormView = FVtaF_ForeignTravel
  End Sub
  Protected Sub TBLtaF_ForeignTravel_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaF_ForeignTravel.Init
    SetToolBar = TBLtaF_ForeignTravel
  End Sub
  Protected Sub FVtaF_ForeignTravel_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaF_ForeignTravel.PreRender
    TBLtaF_ForeignTravel.EnableSave = Editable
    TBLtaF_ForeignTravel.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taF_ForeignTravel.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaF_ForeignTravel") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaF_ForeignTravel", mStr)
    End If
  End Sub

End Class
