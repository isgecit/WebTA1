Imports System.Web.Script.Serialization
Partial Class EF_wfDBPreOrderHistory
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
  Protected Sub ODSwfDBPreOrderHistory_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSwfDBPreOrderHistory.Selected
    Dim tmp As SIS.WFDB.wfDBPreOrderHistory = CType(e.ReturnValue, SIS.WFDB.wfDBPreOrderHistory)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVwfDBPreOrderHistory_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVwfDBPreOrderHistory.Init
    DataClassName = "EwfDBPreOrderHistory"
    SetFormView = FVwfDBPreOrderHistory
  End Sub
  Protected Sub TBLwfDBPreOrderHistory_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLwfDBPreOrderHistory.Init
    SetToolBar = TBLwfDBPreOrderHistory
  End Sub
  Protected Sub FVwfDBPreOrderHistory_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVwfDBPreOrderHistory.PreRender
    TBLwfDBPreOrderHistory.EnableSave = Editable
    TBLwfDBPreOrderHistory.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/WFDB_Main/App_Edit") & "/EF_wfDBPreOrderHistory.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptwfDBPreOrderHistory") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptwfDBPreOrderHistory", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvwfdbNotesCC As New gvBase
  Protected Sub GVwfdbNotes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVwfdbNotes.Init
    gvwfdbNotesCC.DataClassName = "GwfdbNotes"
    gvwfdbNotesCC.SetGridView = GVwfdbNotes
  End Sub
  Protected Sub TBLwfdbNotes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLwfdbNotes.Init
    gvwfdbNotesCC.SetToolBar = TBLwfdbNotes
  End Sub
  Protected Sub GVwfdbNotes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVwfdbNotes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim IndexValue As String = GVwfdbNotes.DataKeys(e.CommandArgument).Values("IndexValue")  
        Dim NotesId As String = GVwfdbNotes.DataKeys(e.CommandArgument).Values("NotesId")  
        Dim RedirectUrl As String = TBLwfdbNotes.EditUrl & "?IndexValue=" & IndexValue & "&NotesId=" & NotesId
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Private WithEvents gvwfdbAttachmentsCC As New gvBase
  Protected Sub GVwfdbAttachments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVwfdbAttachments.Init
    gvwfdbAttachmentsCC.DataClassName = "GwfdbAttachments"
    gvwfdbAttachmentsCC.SetGridView = GVwfdbAttachments
  End Sub
  Protected Sub TBLwfdbAttachments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLwfdbAttachments.Init
    gvwfdbAttachmentsCC.SetToolBar = TBLwfdbAttachments
  End Sub
  Protected Sub GVwfdbAttachments_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVwfdbAttachments.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim t_indx As String = GVwfdbAttachments.DataKeys(e.CommandArgument).Values("t_indx")  
        Dim t_dcid As String = GVwfdbAttachments.DataKeys(e.CommandArgument).Values("t_dcid")  
        Dim RedirectUrl As String = TBLwfdbAttachments.EditUrl & "?t_indx=" & t_indx & "&t_dcid=" & t_dcid
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub

End Class
