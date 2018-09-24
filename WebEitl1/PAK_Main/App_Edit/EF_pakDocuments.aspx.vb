Partial Class EF_pakDocuments
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
  Protected Sub ODSpakDocuments_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSpakDocuments.Selected
    Dim tmp As SIS.PAK.pakDocuments = CType(e.ReturnValue, SIS.PAK.pakDocuments)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVpakDocuments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakDocuments.Init
    DataClassName = "EpakDocuments"
    SetFormView = FVpakDocuments
  End Sub
  Protected Sub TBLpakDocuments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakDocuments.Init
    SetToolBar = TBLpakDocuments
  End Sub
  Protected Sub FVpakDocuments_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakDocuments.PreRender
    TBLpakDocuments.EnableSave = Editable
    TBLpakDocuments.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Edit") & "/EF_pakDocuments.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakDocuments") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakDocuments", mStr)
    End If
  End Sub

End Class
