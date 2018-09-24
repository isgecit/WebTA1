Partial Class EF_taF_LodgDA
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
  Protected Sub ODStaF_LodgDA_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaF_LodgDA.Selected
    Dim tmp As SIS.TA.taF_LodgDA = CType(e.ReturnValue, SIS.TA.taF_LodgDA)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaF_LodgDA_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaF_LodgDA.Init
    DataClassName = "EtaF_LodgDA"
    SetFormView = FVtaF_LodgDA
  End Sub
  Protected Sub TBLtaF_LodgDA_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaF_LodgDA.Init
    SetToolBar = TBLtaF_LodgDA
  End Sub
  Protected Sub FVtaF_LodgDA_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaF_LodgDA.PreRender
    TBLtaF_LodgDA.EnableSave = Editable
    TBLtaF_LodgDA.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taF_LodgDA.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaF_LodgDA") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaF_LodgDA", mStr)
    End If
  End Sub

End Class
