Partial Class EF_eitlPODocumentFile
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVeitlPODocumentFile_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlPODocumentFile.Init
    DataClassName = "EeitlPODocumentFile"
    SetFormView = FVeitlPODocumentFile
  End Sub
  Protected Sub TBLeitlPODocumentFile_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLeitlPODocumentFile.Init
    SetToolBar = TBLeitlPODocumentFile
  End Sub
  Protected Sub FVeitlPODocumentFile_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVeitlPODocumentFile.PreRender
		TBLeitlPODocumentFile.PrintUrl &= Request.QueryString("SerialNo") & "|"
		TBLeitlPODocumentFile.PrintUrl &= Request.QueryString("DocumentLineNo") & "|"
		TBLeitlPODocumentFile.PrintUrl &= Request.QueryString("FileNo") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/EITL_Main/App_Edit") & "/EF_eitlPODocumentFile.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripteitlPODocumentFile") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripteitlPODocumentFile", mStr)
    End If
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
        Dim SerialNo As Int32 = CType(FVeitlPODocumentFile.FindControl("F_SerialNo"), TextBox).Text
        Dim DocumentLineNo As Int32 = CType(FVeitlPODocumentFile.FindControl("F_DocumentLineNo"), TextBox).Text
        Dim FileNo As Int32 = CType(FVeitlPODocumentFile.FindControl("F_FileNo"), TextBox).Text
        Dim oAtch As SIS.EITL.eitlPODocumentFile = SIS.EITL.eitlPODocumentFile.eitlPODocumentFileGetByID(SerialNo, DocumentLineNo, FileNo)
        oAtch.FileName = .FileName
        oAtch.DiskFile = tmpPath & "\" & tmpName
        SIS.EITL.eitlPODocumentFile.UpdateData(oAtch)
        FVeitlPODocumentFile.DataBind()
      End If
    End With
  End Sub

End Class
