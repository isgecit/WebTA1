
Partial Class filedownload
    Inherits System.Web.UI.Page
	Private Function GetDiskFileName(ByVal mStr As String) As String
		mStr = mStr.Replace("/", "_")
		mStr = mStr.Replace("\", "_")
		mStr = mStr.Replace(":", "_")
		mStr = mStr.Replace("*", "_")
		mStr = mStr.Replace("?", "_")
		mStr = mStr.Replace("""", "_")
		mStr = mStr.Replace(">", "_")
		mStr = mStr.Replace("<", "_")
		mStr = mStr.Replace("|", "_")
		mStr = mStr.Trim
		Return mStr
	End Function
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Dim docPK As String = ""
		Dim filePK As String = ""
		Dim FileType As String = ""
		Try
			docPK = Request.QueryString("id")
			FileType = Request.QueryString("typ")
			filePK = Request.QueryString("id1")
		Catch ex As Exception
			docPK = ""
			FileType = ""
			filePK = ""
		End Try
		Dim FileExists As Boolean = False
		Dim FilePath As String = "'"
		Select Case FileType.ToLower
			Case "epdocument"
				Dim oFl As List(Of SIS.LG.lgEPFile) = SIS.LG.lgEPFile.GetByDocPK(docPK, "")
				FilePath = oFl(0).DownloadedFileLocation.Replace("D:", "F:") & "\" & oFl(0).DownloadedFileName
				If IO.File.Exists(FilePath) Then
					FileExists = True
				Else
					FilePath = oFl(0).DownloadedFileLocation.Replace("F:", "D:") & "\" & oFl(0).DownloadedFileName
					If IO.File.Exists(FilePath) Then
						FileExists = True
					End If
				End If
				If FileExists Then
					Dim DiskFileName As String = GetDiskFileName(oFl(0).DiskFileName)
          Response.AppendHeader("content-disposition", "attachment; filename=" & DiskFileName)
          Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(DiskFileName)
					Response.WriteFile(FilePath)
					Response.Flush()
				End If
			Case "wtdocument"
				Dim oFl As List(Of SIS.LG.lgWTFile) = SIS.LG.lgWTFile.GetByDocPK(docPK, "")
				FilePath = oFl(0).DownloadedFileLocation.Replace("D:", "F:") & "\" & oFl(0).DownloadedFileName
				If IO.File.Exists(FilePath) Then
					FileExists = True
				Else
					FilePath = oFl(0).DownloadedFileLocation.Replace("F:", "D:") & "\" & oFl(0).DownloadedFileName
					If IO.File.Exists(FilePath) Then
						FileExists = True
					End If
				End If
				If FileExists Then
					Dim DiskFileName As String = GetDiskFileName(oFl(0).DiskFileName)
          Response.AppendHeader("content-disposition", "attachment; filename=" & DiskFileName)
          Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(DiskFileName)
					Response.WriteFile(FilePath)
					Response.Flush()
				End If
			Case "wtattachment"
				Dim oFl As SIS.LG.lgWTAttachment = SIS.LG.lgWTAttachment.lgWTAttachmentGetByID(docPK, filePK)
				FilePath = oFl.DownloadedFileLocation.Replace("D:", "F:") & "\" & oFl.DownloadedFileName
				If IO.File.Exists(FilePath) Then
					FileExists = True
				Else
					FilePath = oFl.DownloadedFileLocation.Replace("F:", "D:") & "\" & oFl.DownloadedFileName
					If IO.File.Exists(FilePath) Then
						FileExists = True
					End If
				End If
				If FileExists Then
					Dim DiskFileName As String = GetDiskFileName(oFl.DiskFileName)
          Response.AppendHeader("content-disposition", "attachment; filename=" & DiskFileName)
          Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(DiskFileName)
					Response.WriteFile(FilePath)
					Response.Flush()
				End If
		End Select
	End Sub
End Class
