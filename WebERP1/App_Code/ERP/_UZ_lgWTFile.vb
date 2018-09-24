Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.LG
  Partial Public Class lgWTFile
		Public Function GetColor() As System.Drawing.Color
			Dim mRet As System.Drawing.Color = Drawing.Color.Blue
			Return mRet
		End Function
		Public Function GetVisible() As Boolean
			Dim mRet As Boolean = True
			Return mRet
		End Function
		Public Function GetEnable() As Boolean
			Dim mRet As Boolean = True
			Return mRet
		End Function
    Public Shared Function UZ_lgWTFileSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal DocPK As Int64) As List(Of SIS.LG.lgWTFile)
      Dim Results As List(Of SIS.LG.lgWTFile) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
            Cmd.CommandText = "splg_LG_WTFileSelectListSearch"
            Cmd.CommandText = "splgWTFileSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
            Cmd.CommandText = "splg_LG_WTFileSelectListFilteres"
            Cmd.CommandText = "splgWTFileSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DocPK", SqlDbType.BigInt, 19, IIf(DocPK = Nothing, 0, DocPK))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.LG.lgWTFile)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.LG.lgWTFile(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
		Public Shared Function lgWTFileGetByIDFromWindChill(ByVal DocPK As Int64, ByVal FilePK As Int64) As SIS.LG.lgWTFile
			Dim Results As SIS.LG.lgWTFile = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetWindChillConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "splgWTFileSelectByID"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocPK", SqlDbType.BigInt, DocPK.ToString.Length, DocPK)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FilePK", SqlDbType.BigInt, FilePK.ToString.Length, FilePK)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.LG.lgWTFile(Reader)
					End If
					Reader.Close()
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function UpdateDownloadedData(ByVal Record As SIS.LG.lgWTFile) As SIS.LG.lgWTFile
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "splg_LG_WTFileUpdate"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DocPK", SqlDbType.BigInt, 20, Record.DocPK)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FilePK", SqlDbType.BigInt, 20, Record.FilePK)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DownloadedFileLocation", SqlDbType.NVarChar, 1001, IIf(Record.DownloadedFileLocation = "", Convert.DBNull, Record.DownloadedFileLocation))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DownloadedFileName", SqlDbType.NVarChar, 201, IIf(Record.DownloadedFileName = "", Convert.DBNull, Record.DownloadedFileName))
					Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
					Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Con.Open()
					Cmd.ExecuteNonQuery()
					_RecordCount = Cmd.Parameters("@RowCount").Value
				End Using
			End Using
			Return Record
		End Function
    Public Shared Sub UpdateDownloadedFileNameLocationFromWindChill()
      Dim mPage As Integer = 0
      Dim mSize As Integer = 100
      '1. Update WTFile
      mPage = 0
      Dim oWTs As List(Of SIS.LG.lgWTFile) = SIS.LG.lgWTFile.lgWTFileSelectList(mPage, mSize, "", False, "", 0)
      Do While oWTs.Count > 0
        For Each oWT As SIS.LG.lgWTFile In oWTs
          Dim wt As SIS.LG.lgWTFile = SIS.LG.lgWTFile.lgWTFileGetByIDFromWindChill(oWT.DocPK, oWT.FilePK)
          If wt IsNot Nothing Then
            SIS.LG.lgWTFile.UpdateDownloadedData(wt)
          End If
        Next
        mPage = mPage + mSize
        oWTs = SIS.LG.lgWTFile.lgWTFileSelectList(mPage, mSize, "", False, "", 0)
      Loop
      '2. Update WTAttachment
      mPage = 0
      Dim oWTAs As List(Of SIS.LG.lgWTAttachment) = SIS.LG.lgWTAttachment.lgWTAttachmentSelectList(mPage, mSize, "", False, "", 0)
      Do While oWTAs.Count > 0
        For Each oWTa As SIS.LG.lgWTAttachment In oWTAs
          Dim wt As SIS.LG.lgWTAttachment = SIS.LG.lgWTAttachment.lgWTAttachmentGetByIDFromWindChill(oWTa.DocPK, oWTa.FilePK)
          If wt IsNot Nothing Then
            SIS.LG.lgWTAttachment.UpdateDownloadedData(wt)
          End If
        Next
        mPage = mPage + mSize
        oWTAs = SIS.LG.lgWTAttachment.lgWTAttachmentSelectList(mPage, mSize, "", False, "", 0)
      Loop
      '3. Update EPFile
      mPage = 0
      Dim oEPs As List(Of SIS.LG.lgEPFile) = SIS.LG.lgEPFile.lgEPFileSelectList(mPage, mSize, "", False, "", 0)
      Do While oEPs.Count > 0
        For Each oEP As SIS.LG.lgEPFile In oEPs
          Dim EP As SIS.LG.lgEPFile = SIS.LG.lgEPFile.lgEPFileGetByIDFromWindChill(oEP.DocPK, oEP.FilePK)
          If EP IsNot Nothing Then
            SIS.LG.lgEPFile.UpdateDownloadedData(EP)
          End If
        Next
        mPage = mPage + mSize
        oEPs = SIS.LG.lgEPFile.lgEPFileSelectList(mPage, mSize, "", False, "", 0)
      Loop
      '4. Update EPAttachment
      mPage = 0
      Dim oEPAs As List(Of SIS.LG.lgEPAttachment) = SIS.LG.lgEPAttachment.lgEPAttachmentSelectList(mPage, mSize, "", False, "", 0)
      Do While oEPAs.Count > 0
        For Each oEPa As SIS.LG.lgEPAttachment In oEPAs
          Dim EP As SIS.LG.lgEPAttachment = SIS.LG.lgEPAttachment.lgEPAttachmentGetByIDFromWindChill(oEPa.DocPK, oEPa.FilePK)
          If EP IsNot Nothing Then
            SIS.LG.lgEPAttachment.UpdateDownloadedData(EP)
          End If
        Next
        mPage = mPage + mSize
        oEPAs = SIS.LG.lgEPAttachment.lgEPAttachmentSelectList(mPage, mSize, "", False, "", 0)
      Loop
    End Sub
  End Class
End Namespace
