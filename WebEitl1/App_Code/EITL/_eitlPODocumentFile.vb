Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.EITL
  <DataObject()> _
  Partial Public Class eitlPODocumentFile
    Private Shared _RecordCount As Integer
    Private _SerialNo As Int32 = 0
    Private _DocumentLineNo As Int32 = 0
    Private _FileNo As Int32 = 0
    Private _Description As String = ""
    Private _FileName As String = ""
    Private _DiskFile As String = ""
    Private _EITL_PODocumentList1_DocumentID As String = ""
    Private _EITL_POList2_PONumber As String = ""
    Private _FK_EITL_PODocumentFile_DocumentLine As SIS.EITL.eitlPODocumentList = Nothing
    Private _FK_EITL_PODocumentFile_SerialNo As SIS.EITL.eitlPOList = Nothing
    Public ReadOnly Property ForeColor() As System.Drawing.Color
      Get
        Dim mRet As System.Drawing.Color = Drawing.Color.Blue
        Try
					mRet = GetColor()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Visible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Enable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Property SerialNo() As Int32
      Get
        Return _SerialNo
      End Get
      Set(ByVal value As Int32)
        _SerialNo = value
      End Set
    End Property
    Public Property DocumentLineNo() As Int32
      Get
        Return _DocumentLineNo
      End Get
      Set(ByVal value As Int32)
        _DocumentLineNo = value
      End Set
    End Property
    Public Property FileNo() As Int32
      Get
        Return _FileNo
      End Get
      Set(ByVal value As Int32)
        _FileNo = value
      End Set
    End Property
    Public Property Description() As String
      Get
        Return _Description
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Description = ""
				 Else
					 _Description = value
			   End If
      End Set
    End Property
    Public Property FileName() As String
      Get
        Return _FileName
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _FileName = ""
				 Else
					 _FileName = value
			   End If
      End Set
    End Property
    Public Property DiskFile() As String
      Get
        Return _DiskFile
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _DiskFile = ""
				 Else
					 _DiskFile = value
			   End If
      End Set
    End Property
    Public Property EITL_PODocumentList1_DocumentID() As String
      Get
        Return _EITL_PODocumentList1_DocumentID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _EITL_PODocumentList1_DocumentID = ""
				 Else
					 _EITL_PODocumentList1_DocumentID = value
			   End If
      End Set
    End Property
    Public Property EITL_POList2_PONumber() As String
      Get
        Return _EITL_POList2_PONumber
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _EITL_POList2_PONumber = ""
				 Else
					 _EITL_POList2_PONumber = value
			   End If
      End Set
    End Property
    Public Readonly Property GetDownloadLink() As String
      Get
        Return "javascript:window.open('" & HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath & "/EITL_Main/App_Downloads/filedownload.aspx?req=" & PrimaryKey & "', 'win" & _SerialNo & "', 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1'); return false;"
      End Get
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _SerialNo & "|" & _DocumentLineNo & "|" & _FileNo
      End Get
    End Property
    Public Shared Property RecordCount() As Integer
      Get
        Return _RecordCount
      End Get
      Set(ByVal value As Integer)
        _RecordCount = value
      End Set
    End Property
    Public Class PKeitlPODocumentFile
			Private _SerialNo As Int32 = 0
			Private _DocumentLineNo As Int32 = 0
			Private _FileNo As Int32 = 0
			Public Property SerialNo() As Int32
				Get
					Return _SerialNo
				End Get
				Set(ByVal value As Int32)
					_SerialNo = value
				End Set
			End Property
			Public Property DocumentLineNo() As Int32
				Get
					Return _DocumentLineNo
				End Get
				Set(ByVal value As Int32)
					_DocumentLineNo = value
				End Set
			End Property
			Public Property FileNo() As Int32
				Get
					Return _FileNo
				End Get
				Set(ByVal value As Int32)
					_FileNo = value
				End Set
			End Property
    End Class
    Public ReadOnly Property FK_EITL_PODocumentFile_DocumentLine() As SIS.EITL.eitlPODocumentList
      Get
        If _FK_EITL_PODocumentFile_DocumentLine Is Nothing Then
          _FK_EITL_PODocumentFile_DocumentLine = SIS.EITL.eitlPODocumentList.eitlPODocumentListGetByID(_SerialNo, _DocumentLineNo)
        End If
        Return _FK_EITL_PODocumentFile_DocumentLine
      End Get
    End Property
    Public ReadOnly Property FK_EITL_PODocumentFile_SerialNo() As SIS.EITL.eitlPOList
      Get
        If _FK_EITL_PODocumentFile_SerialNo Is Nothing Then
          _FK_EITL_PODocumentFile_SerialNo = SIS.EITL.eitlPOList.eitlPOListGetByID(_SerialNo)
        End If
        Return _FK_EITL_PODocumentFile_SerialNo
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlPODocumentFileGetNewRecord() As SIS.EITL.eitlPODocumentFile
      Return New SIS.EITL.eitlPODocumentFile()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlPODocumentFileGetByID(ByVal SerialNo As Int32, ByVal DocumentLineNo As Int32, ByVal FileNo As Int32) As SIS.EITL.eitlPODocumentFile
      Dim Results As SIS.EITL.eitlPODocumentFile = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlPODocumentFileSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentLineNo",SqlDbType.Int,DocumentLineNo.ToString.Length, DocumentLineNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileNo",SqlDbType.Int,FileNo.ToString.Length, FileNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.EITL.eitlPODocumentFile(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlPODocumentFileSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal DocumentLineNo As Int32) As List(Of SIS.EITL.eitlPODocumentFile)
      Dim Results As List(Of SIS.EITL.eitlPODocumentFile) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "speitlPODocumentFileSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "speitlPODocumentFileSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DocumentLineNo",SqlDbType.Int,10, IIf(DocumentLineNo = Nothing, 0,DocumentLineNo))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.EITL.eitlPODocumentFile)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.EITL.eitlPODocumentFile(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function eitlPODocumentFileSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal DocumentLineNo As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlPODocumentFileGetByID(ByVal SerialNo As Int32, ByVal DocumentLineNo As Int32, ByVal FileNo As Int32, ByVal Filter_SerialNo As Int32, ByVal Filter_DocumentLineNo As Int32) As SIS.EITL.eitlPODocumentFile
      Return eitlPODocumentFileGetByID(SerialNo, DocumentLineNo, FileNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function eitlPODocumentFileInsert(ByVal Record As SIS.EITL.eitlPODocumentFile) As SIS.EITL.eitlPODocumentFile
      Dim _Rec As SIS.EITL.eitlPODocumentFile = SIS.EITL.eitlPODocumentFile.eitlPODocumentFileGetNewRecord()
      With _Rec
        .SerialNo = Record.SerialNo
        .DocumentLineNo = Record.DocumentLineNo
        .Description = Record.Description
        .FileName = Record.FileName
        .DiskFile = Record.DiskFile
      End With
      Return SIS.EITL.eitlPODocumentFile.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.EITL.eitlPODocumentFile) As SIS.EITL.eitlPODocumentFile
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlPODocumentFileInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentLineNo",SqlDbType.Int,11, Record.DocumentLineNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileName",SqlDbType.NVarChar,251, Iif(Record.FileName= "" ,Convert.DBNull, Record.FileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DiskFile",SqlDbType.NVarChar,251, Iif(Record.DiskFile= "" ,Convert.DBNull, Record.DiskFile))
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_DocumentLineNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_DocumentLineNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_FileNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_FileNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
          Record.DocumentLineNo = Cmd.Parameters("@Return_DocumentLineNo").Value
          Record.FileNo = Cmd.Parameters("@Return_FileNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function eitlPODocumentFileUpdate(ByVal Record As SIS.EITL.eitlPODocumentFile) As SIS.EITL.eitlPODocumentFile
      Dim _Rec As SIS.EITL.eitlPODocumentFile = SIS.EITL.eitlPODocumentFile.eitlPODocumentFileGetByID(Record.SerialNo, Record.DocumentLineNo, Record.FileNo)
      With _Rec
        .Description = Record.Description
        .FileName = Record.FileName
        .DiskFile = Record.DiskFile
      End With
      Return SIS.EITL.eitlPODocumentFile.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.EITL.eitlPODocumentFile) As SIS.EITL.eitlPODocumentFile
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlPODocumentFileUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DocumentLineNo",SqlDbType.Int,11, Record.DocumentLineNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FileNo",SqlDbType.Int,11, Record.FileNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentLineNo",SqlDbType.Int,11, Record.DocumentLineNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileName",SqlDbType.NVarChar,251, Iif(Record.FileName= "" ,Convert.DBNull, Record.FileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DiskFile",SqlDbType.NVarChar,251, Iif(Record.DiskFile= "" ,Convert.DBNull, Record.DiskFile))
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
    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    Public Shared Function eitlPODocumentFileDelete(ByVal Record As SIS.EITL.eitlPODocumentFile) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlPODocumentFileDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,Record.SerialNo.ToString.Length, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DocumentLineNo",SqlDbType.Int,Record.DocumentLineNo.ToString.Length, Record.DocumentLineNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FileNo",SqlDbType.Int,Record.FileNo.ToString.Length, Record.FileNo)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      'Delete DiskFile
      Try
        If IO.File.Exists(Record.DiskFile) Then
          IO.File.Delete(Record.DiskFile)
        End If
      Catch ex As Exception
      End Try
      Return _RecordCount
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _SerialNo = Ctype(Reader("SerialNo"),Int32)
      _DocumentLineNo = Ctype(Reader("DocumentLineNo"),Int32)
      _FileNo = Ctype(Reader("FileNo"),Int32)
      If Convert.IsDBNull(Reader("Description")) Then
        _Description = String.Empty
      Else
        _Description = Ctype(Reader("Description"), String)
      End If
      If Convert.IsDBNull(Reader("FileName")) Then
        _FileName = String.Empty
      Else
        _FileName = Ctype(Reader("FileName"), String)
      End If
      If Convert.IsDBNull(Reader("DiskFile")) Then
        _DiskFile = String.Empty
      Else
        _DiskFile = Ctype(Reader("DiskFile"), String)
      End If
      If Convert.IsDBNull(Reader("EITL_PODocumentList1_DocumentID")) Then
        _EITL_PODocumentList1_DocumentID = String.Empty
      Else
        _EITL_PODocumentList1_DocumentID = Ctype(Reader("EITL_PODocumentList1_DocumentID"), String)
      End If
      If Convert.IsDBNull(Reader("EITL_POList2_PONumber")) Then
        _EITL_POList2_PONumber = String.Empty
      Else
        _EITL_POList2_PONumber = Ctype(Reader("EITL_POList2_PONumber"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
