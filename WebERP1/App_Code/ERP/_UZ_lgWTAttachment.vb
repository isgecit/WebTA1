Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.LG
  Partial Public Class lgWTAttachment
		Public ReadOnly Property GetLink() As String
			Get
				Return "return script_download('" & _DocPK & "','wtattachment','" & _FilePK & "');"
			End Get
		End Property
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
    Public Shared Function UZ_lgWTAttachmentSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal DocPK As Int64) As List(Of SIS.LG.lgWTAttachment)
      Dim Results As List(Of SIS.LG.lgWTAttachment) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
            Cmd.CommandText = "splg_LG_WTAttachmentSelectListSearch"
            Cmd.CommandText = "splgWTAttachmentSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
            Cmd.CommandText = "splg_LG_WTAttachmentSelectListFilteres"
            Cmd.CommandText = "splgWTAttachmentSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DocPK", SqlDbType.BigInt, 19, IIf(DocPK = Nothing, 0, DocPK))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.LG.lgWTAttachment)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.LG.lgWTAttachment(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
		Public Shared Function lgWTAttachmentGetByIDFromWindChill(ByVal DocPK As Int64, ByVal FilePK As Int64) As SIS.LG.lgWTAttachment
			Dim Results As SIS.LG.lgWTAttachment = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetWindChillConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "splgWTAttachmentSelectByID"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocPK", SqlDbType.BigInt, DocPK.ToString.Length, DocPK)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FilePK", SqlDbType.BigInt, FilePK.ToString.Length, FilePK)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.LG.lgWTAttachment(Reader)
					End If
					Reader.Close()
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function UpdateDownloadedData(ByVal Record As SIS.LG.lgWTAttachment) As SIS.LG.lgWTAttachment
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "splg_LG_WTAttachmentUpdate"
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
	End Class
End Namespace
