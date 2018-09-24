Partial Class EF_eitlPODocumentList
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVeitlPODocumentList_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlPODocumentList.Init
    DataClassName = "EeitlPODocumentList"
    SetFormView = FVeitlPODocumentList
  End Sub
  Protected Sub TBLeitlPODocumentList_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlPODocumentList.Init
    SetToolBar = TBLeitlPODocumentList
  End Sub
  Protected Sub FVeitlPODocumentList_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlPODocumentList.PreRender
		TBLeitlPODocumentList.PrintUrl &= Request.QueryString("SerialNo") & "|"
		TBLeitlPODocumentList.PrintUrl &= Request.QueryString("DocumentLineNo") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/EITL_Main/App_Edit") & "/EF_eitlPODocumentList.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripteitlPODocumentList") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripteitlPODocumentList", mStr)
    End If
  End Sub
  Partial Class gvBase
		Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gveitlPODocumentFileCC As New gvBase
  Protected Sub GVeitlPODocumentFile_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVeitlPODocumentFile.Init
		gveitlPODocumentFileCC.DataClassName = "GeitlPODocumentFile"
		gveitlPODocumentFileCC.SetGridView = GVeitlPODocumentFile
  End Sub
  Protected Sub TBLeitlPODocumentFile_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlPODocumentFile.Init
		gveitlPODocumentFileCC.SetToolBar = TBLeitlPODocumentFile
  End Sub
  Public Property Editable() As Boolean
    Get
      If ViewState("Editable") IsNot Nothing Then
        Return ViewState("Editable")
      Else
        Return True
      End If
    End Get
    Set(ByVal value As Boolean)
      ViewState("Editable") = value
    End Set
  End Property
  Protected Sub cmdFileUpload_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles cmdFileUpload.Command
    If Not IsPostBack Then Exit Sub
    With F_FileUpload
      If .HasFile Then
        Dim tmpPath As String = ConfigurationManager.AppSettings("eitlPODocumentFile_Path")
        If Not IO.Directory.Exists(tmpPath) Then
          tmpPath = ConfigurationManager.AppSettings("eitlPODocumentFile_Path1")
        End If
        Dim tmpName As String = IO.Path.GetRandomFileName()
        .SaveAs(tmpPath & "\\" & tmpName)
        Dim SerialNo As Int32 = CType(FVeitlPODocumentList.FindControl("F_SerialNo"), TextBox).Text
        Dim DocumentLineNo As Int32 = CType(FVeitlPODocumentList.FindControl("F_DocumentLineNo"), TextBox).Text
        Dim oAtch As SIS.EITL.eitlPODocumentFile = New SIS.EITL.eitlPODocumentFile
        oAtch.SerialNo = SerialNo
        oAtch.DocumentLineNo = DocumentLineNo
        oAtch.Description = .FileName
        oAtch.FileName = .FileName
        oAtch.DiskFile = tmpPath & "\" & tmpName
        SIS.EITL.eitlPODocumentFile.InsertData(oAtch)
        GVeitlPODocumentFile.DataBind()
      End If
    End With
  End Sub
  Protected Sub GVeitlPODocumentFile_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVeitlPODocumentFile.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVeitlPODocumentFile.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim DocumentLineNo As Int32 = GVeitlPODocumentFile.DataKeys(e.CommandArgument).Values("DocumentLineNo")
        Dim FileNo As Int32 = GVeitlPODocumentFile.DataKeys(e.CommandArgument).Values("FileNo")
        Dim RedirectUrl As String = TBLeitlPODocumentFile.EditUrl & "?SerialNo=" & SerialNo & "&DocumentLineNo=" & DocumentLineNo & "&FileNo=" & FileNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub TBLeitlPODocumentFile_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLeitlPODocumentFile.AddClicked
		Dim SerialNo As Int32 = CType(FVeitlPODocumentList.FindControl("F_SerialNo"),TextBox).Text
		Dim DocumentLineNo As Int32 = CType(FVeitlPODocumentList.FindControl("F_DocumentLineNo"),TextBox).Text
		TBLeitlPODocumentFile.AddUrl &= "?SerialNo=" & SerialNo
		TBLeitlPODocumentFile.AddUrl &= "&DocumentLineNo=" & DocumentLineNo
  End Sub

End Class
