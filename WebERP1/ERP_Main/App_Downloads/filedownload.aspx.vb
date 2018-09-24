
Partial Class filedownload
    Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Dim docPK As String = ""
		Dim filePK As String = ""
		Dim FileType As String = ""
		Try
			docPK = Request.QueryString("id")
			filePK = Request.QueryString("id1")
			FileType = Request.QueryString("typ")
		Catch ex As Exception
			docPK = ""
			filePK = ""
			FileType = ""
		End Try
		Try
			Dim oFl As SIS.ERP.erpRequestAttachments = SIS.ERP.erpRequestAttachments.erpRequestAttachmentsGetByID(docPK, filePK, FileType)
			If IO.File.Exists(oFl.DiskFile) Then
				Response.Clear()
				Response.AppendHeader("content-disposition", "attachment; filename=" & oFl.FileName & """")
				Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(oFl.FileName)
				Response.WriteFile(oFl.DiskFile)
				Response.End()
			End If
		Catch ex As Exception
		End Try
	End Sub
End Class
