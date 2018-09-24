Imports System.Web.Script.Serialization
Partial Class EF_wfdbAttachments
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
  Protected Sub ODSwfdbAttachments_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSwfdbAttachments.Selected
    Dim tmp As SIS.WFDB.wfdbAttachments = CType(e.ReturnValue, SIS.WFDB.wfdbAttachments)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVwfdbAttachments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVwfdbAttachments.Init
    DataClassName = "EwfdbAttachments"
    SetFormView = FVwfdbAttachments
  End Sub
  Protected Sub TBLwfdbAttachments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLwfdbAttachments.Init
    SetToolBar = TBLwfdbAttachments
  End Sub
  Protected Sub FVwfdbAttachments_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVwfdbAttachments.PreRender
    TBLwfdbAttachments.EnableSave = Editable
    TBLwfdbAttachments.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/WFDB_Main/App_Edit") & "/EF_wfdbAttachments.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptwfdbAttachments") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptwfdbAttachments", mStr)
    End If
  End Sub

End Class
