Partial Class AF_pakDocuments
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakDocuments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakDocuments.Init
    DataClassName = "ApakDocuments"
    SetFormView = FVpakDocuments
  End Sub
  Protected Sub TBLpakDocuments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakDocuments.Init
    SetToolBar = TBLpakDocuments
  End Sub
  Protected Sub FVpakDocuments_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakDocuments.DataBound
    SIS.PAK.pakDocuments.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakDocuments_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakDocuments.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakDocuments.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakDocuments") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakDocuments", mStr)
    End If
    If Request.QueryString("DocumentNo") IsNot Nothing Then
      CType(FVpakDocuments.FindControl("F_DocumentNo"), TextBox).Text = Request.QueryString("DocumentNo")
      CType(FVpakDocuments.FindControl("F_DocumentNo"), TextBox).Enabled = False
    End If
  End Sub

End Class
