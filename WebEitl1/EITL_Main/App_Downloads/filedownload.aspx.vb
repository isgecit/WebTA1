
Partial Class filedownload
    Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Dim docPK As String = ""
    Dim filePK As String = ""
    Dim downloadType As Integer = 0
    '0=Template
    '1=Attachement
    Dim val() As String = Nothing
    If Request.QueryString("tmpl") IsNot Nothing Then
      val = Request.QueryString("tmpl").Split("|".ToCharArray)
      downloadType = 0
    ElseIf Request.QueryString("req") IsNot Nothing Then
      val = Request.QueryString("req").Split("|".ToCharArray)
      downloadType = 1
    End If
    Select Case downloadType
      Case 0
        Try
          Dim oFl As String = Server.MapPath("~/") & "App_Templates\ItemTemplate.xlsx"
          If IO.File.Exists(oFl) Then
            Response.Clear()
            Response.AppendHeader("content-disposition", "attachment; filename=" & "ItemTemplate.xlsx" & """")
            Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType("ItemTemplate.xlsx")
            Response.WriteFile(oFl)
            Response.End()
          End If
        Catch ex As Exception
        End Try
      Case 1
        Try
          Dim oFl As SIS.EITL.eitlPODocumentFile = SIS.EITL.eitlPODocumentFile.eitlPODocumentFileGetByID(val(0), val(1), val(2))
          If IO.File.Exists(oFl.DiskFile) Then
            Response.Clear()
            Response.AppendHeader("content-disposition", "attachment; filename=" & oFl.FileName & """")
            Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(oFl.FileName)
            Response.WriteFile(oFl.DiskFile)
            Response.End()
          End If
        Catch ex As Exception
        End Try
    End Select
  End Sub
End Class
