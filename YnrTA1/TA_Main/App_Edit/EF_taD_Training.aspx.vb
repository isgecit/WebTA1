Partial Class EF_taD_Training
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
  Protected Sub ODStaD_Training_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODStaD_Training.Selected
    Dim tmp As SIS.TA.taD_Training = CType(e.ReturnValue, SIS.TA.taD_Training)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVtaD_Training_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_Training.Init
    DataClassName = "EtaD_Training"
    SetFormView = FVtaD_Training
  End Sub
  Protected Sub TBLtaD_Training_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaD_Training.Init
    SetToolBar = TBLtaD_Training
  End Sub
  Protected Sub FVtaD_Training_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_Training.PreRender
    TBLtaD_Training.EnableSave = Editable
    TBLtaD_Training.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Edit") & "/EF_taD_Training.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaD_Training") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaD_Training", mStr)
    End If
  End Sub

End Class
