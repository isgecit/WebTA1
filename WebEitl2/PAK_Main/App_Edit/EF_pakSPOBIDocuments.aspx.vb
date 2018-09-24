Partial Class EF_pakSPOBIDocuments
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
  Protected Sub ODSpakSPOBIDocuments_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakSPOBIDocuments.Selected
    Dim tmp As SIS.PAK.pakSPOBIDocuments = CType(e.ReturnValue, SIS.PAK.pakSPOBIDocuments)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakSPOBIDocuments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSPOBIDocuments.Init
    DataClassName = "EpakSPOBIDocuments"
    SetFormView = FVpakSPOBIDocuments
  End Sub
  Protected Sub TBLpakSPOBIDocuments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakSPOBIDocuments.Init
    SetToolBar = TBLpakSPOBIDocuments
  End Sub
  Protected Sub FVpakSPOBIDocuments_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakSPOBIDocuments.PreRender
    TBLpakSPOBIDocuments.EnableSave = Editable
    TBLpakSPOBIDocuments.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakSPOBIDocuments.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakSPOBIDocuments") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakSPOBIDocuments", mStr)
    End If
  End Sub

End Class
