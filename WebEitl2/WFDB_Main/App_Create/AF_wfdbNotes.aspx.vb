Partial Class AF_wfdbNotes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVwfdbNotes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVwfdbNotes.Init
    DataClassName = "AwfdbNotes"
    SetFormView = FVwfdbNotes
  End Sub
  Protected Sub TBLwfdbNotes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLwfdbNotes.Init
    SetToolBar = TBLwfdbNotes
  End Sub
  Protected Sub FVwfdbNotes_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVwfdbNotes.DataBound
    SIS.WFDB.wfdbNotes.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVwfdbNotes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVwfdbNotes.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/WFDB_Main/App_Create") & "/AF_wfdbNotes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptwfdbNotes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptwfdbNotes", mStr)
    End If
    If Request.QueryString("IndexValue") IsNot Nothing Then
      CType(FVwfdbNotes.FindControl("F_IndexValue"), TextBox).Text = Request.QueryString("IndexValue")
      CType(FVwfdbNotes.FindControl("F_IndexValue"), TextBox).Enabled = False
    End If
    If Request.QueryString("NotesId") IsNot Nothing Then
      CType(FVwfdbNotes.FindControl("F_NotesId"), TextBox).Text = Request.QueryString("NotesId")
      CType(FVwfdbNotes.FindControl("F_NotesId"), TextBox).Enabled = False
    End If
  End Sub

End Class
