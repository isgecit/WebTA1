Imports System.Web.Script.Serialization
Partial Class EF_wfdbNotes
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
  Protected Sub ODSwfdbNotes_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSwfdbNotes.Selected
    Dim tmp As SIS.WFDB.wfdbNotes = CType(e.ReturnValue, SIS.WFDB.wfdbNotes)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVwfdbNotes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVwfdbNotes.Init
    DataClassName = "EwfdbNotes"
    SetFormView = FVwfdbNotes
  End Sub
  Protected Sub TBLwfdbNotes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLwfdbNotes.Init
    SetToolBar = TBLwfdbNotes
  End Sub
  Protected Sub FVwfdbNotes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVwfdbNotes.PreRender
    TBLwfdbNotes.EnableSave = Editable
    TBLwfdbNotes.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/WFDB_Main/App_Edit") & "/EF_wfdbNotes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptwfdbNotes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptwfdbNotes", mStr)
    End If
  End Sub

End Class
