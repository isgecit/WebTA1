Partial Class EF_pakPOBIDocuments
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
  Protected Sub ODSpakPOBIDocuments_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakPOBIDocuments.Selected
    Dim tmp As SIS.PAK.pakPOBIDocuments = CType(e.ReturnValue, SIS.PAK.pakPOBIDocuments)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakPOBIDocuments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPOBIDocuments.Init
    DataClassName = "EpakPOBIDocuments"
    SetFormView = FVpakPOBIDocuments
  End Sub
  Protected Sub TBLpakPOBIDocuments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakPOBIDocuments.Init
    SetToolBar = TBLpakPOBIDocuments
  End Sub
  Protected Sub FVpakPOBIDocuments_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakPOBIDocuments.PreRender
    TBLpakPOBIDocuments.EnableSave = Editable
    TBLpakPOBIDocuments.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakPOBIDocuments.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakPOBIDocuments") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakPOBIDocuments", mStr)
    End If
  End Sub

End Class
