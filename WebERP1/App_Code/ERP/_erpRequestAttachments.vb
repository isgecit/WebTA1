Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ERP
  <DataObject()> _
  Partial Public Class erpRequestAttachments
    Private Shared _RecordCount As Integer
    Private _ApplID As Int32 = 0
    Private _RequestID As Int32 = 0
    Private _SerialNo As Int32 = 0
    Private _Description As String = ""
    Private _FileName As String = ""
    Private _DiskFile As String = ""
    Private _ERP_Applications1_ApplName As String = ""
    Private _ERP_ChaneRequest2_ChangeSubject As String = ""
    Private _FK_ERP_RequestAttachments_ApplID As SIS.ERP.erpApplications = Nothing
    Private _FK_ERP_RequestAttachments_ApplID_RequestID As SIS.ERP.erpChaneRequest = Nothing
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
    Public Property ApplID() As Int32
      Get
        Return _ApplID
      End Get
      Set(ByVal value As Int32)
        _ApplID = value
      End Set
    End Property
    Public Property RequestID() As Int32
      Get
        Return _RequestID
      End Get
      Set(ByVal value As Int32)
        _RequestID = value
      End Set
    End Property
    Public Property SerialNo() As Int32
      Get
        Return _SerialNo
      End Get
      Set(ByVal value As Int32)
        _SerialNo = value
      End Set
    End Property
    Public Property Description() As String
      Get
        Return _Description
      End Get
      Set(ByVal value As String)
        _Description = value
      End Set
    End Property
    Public Property FileName() As String
      Get
        Return _FileName
      End Get
      Set(ByVal value As String)
        _FileName = value
      End Set
    End Property
    Public Property DiskFile() As String
      Get
        Return _DiskFile
      End Get
      Set(ByVal value As String)
        _DiskFile = value
      End Set
    End Property
    Public Property ERP_Applications1_ApplName() As String
      Get
        Return _ERP_Applications1_ApplName
      End Get
      Set(ByVal value As String)
        _ERP_Applications1_ApplName = value
      End Set
    End Property
    Public Property ERP_ChaneRequest2_ChangeSubject() As String
      Get
        Return _ERP_ChaneRequest2_ChangeSubject
      End Get
      Set(ByVal value As String)
        _ERP_ChaneRequest2_ChangeSubject = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _Description.ToString.PadRight(100, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _ApplID & "|" & _RequestID & "|" & _SerialNo
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
    Public Class PKerpRequestAttachments
			Private _ApplID As Int32 = 0
			Private _RequestID As Int32 = 0
			Private _SerialNo As Int32 = 0
			Public Property ApplID() As Int32
				Get
					Return _ApplID
				End Get
				Set(ByVal value As Int32)
					_ApplID = value
				End Set
			End Property
			Public Property RequestID() As Int32
				Get
					Return _RequestID
				End Get
				Set(ByVal value As Int32)
					_RequestID = value
				End Set
			End Property
			Public Property SerialNo() As Int32
				Get
					Return _SerialNo
				End Get
				Set(ByVal value As Int32)
					_SerialNo = value
				End Set
			End Property
    End Class
    Public ReadOnly Property FK_ERP_RequestAttachments_ApplID() As SIS.ERP.erpApplications
      Get
        If _FK_ERP_RequestAttachments_ApplID Is Nothing Then
          _FK_ERP_RequestAttachments_ApplID = SIS.ERP.erpApplications.erpApplicationsGetByID(_ApplID)
        End If
        Return _FK_ERP_RequestAttachments_ApplID
      End Get
    End Property
    Public ReadOnly Property FK_ERP_RequestAttachments_ApplID_RequestID() As SIS.ERP.erpChaneRequest
      Get
        If _FK_ERP_RequestAttachments_ApplID_RequestID Is Nothing Then
          _FK_ERP_RequestAttachments_ApplID_RequestID = SIS.ERP.erpChaneRequest.erpChaneRequestGetByID(_ApplID, _RequestID)
        End If
        Return _FK_ERP_RequestAttachments_ApplID_RequestID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpRequestAttachmentsSelectList(ByVal OrderBy As String) As List(Of SIS.ERP.erpRequestAttachments)
      Dim Results As List(Of SIS.ERP.erpRequestAttachments) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpRequestAttachmentsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ERP.erpRequestAttachments)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ERP.erpRequestAttachments(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpRequestAttachmentsGetNewRecord() As SIS.ERP.erpRequestAttachments
      Return New SIS.ERP.erpRequestAttachments()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpRequestAttachmentsGetByID(ByVal ApplID As Int32, ByVal RequestID As Int32, ByVal SerialNo As Int32) As SIS.ERP.erpRequestAttachments
      Dim Results As SIS.ERP.erpRequestAttachments = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpRequestAttachmentsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplID",SqlDbType.Int,ApplID.ToString.Length, ApplID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestID",SqlDbType.Int,RequestID.ToString.Length, RequestID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.ERP.erpRequestAttachments(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpRequestAttachmentsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ApplID As Int32, ByVal RequestID As Int32) As List(Of SIS.ERP.erpRequestAttachments)
      Dim Results As List(Of SIS.ERP.erpRequestAttachments) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "sperpRequestAttachmentsSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "sperpRequestAttachmentsSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ApplID",SqlDbType.Int,10, IIf(ApplID = Nothing, 0,ApplID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RequestID",SqlDbType.Int,10, IIf(RequestID = Nothing, 0,RequestID))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ERP.erpRequestAttachments)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ERP.erpRequestAttachments(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function erpRequestAttachmentsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ApplID As Int32, ByVal RequestID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpRequestAttachmentsGetByID(ByVal ApplID As Int32, ByVal RequestID As Int32, ByVal SerialNo As Int32, ByVal Filter_ApplID As Int32, ByVal Filter_RequestID As Int32) As SIS.ERP.erpRequestAttachments
      Return erpRequestAttachmentsGetByID(ApplID, RequestID, SerialNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function erpRequestAttachmentsInsert(ByVal Record As SIS.ERP.erpRequestAttachments) As SIS.ERP.erpRequestAttachments
      Dim _Rec As SIS.ERP.erpRequestAttachments = SIS.ERP.erpRequestAttachments.erpRequestAttachmentsGetNewRecord()
      With _Rec
        .ApplID = Record.ApplID
        .RequestID = Record.RequestID
        .Description = Record.Description
        .FileName = Record.FileName
        .DiskFile = Record.DiskFile
      End With
      Return SIS.ERP.erpRequestAttachments.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.ERP.erpRequestAttachments) As SIS.ERP.erpRequestAttachments
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpRequestAttachmentsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplID",SqlDbType.Int,11, Record.ApplID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestID",SqlDbType.Int,11, Record.RequestID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,101, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileName",SqlDbType.NVarChar,251, Record.FileName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DiskFile",SqlDbType.NVarChar,251, Record.DiskFile)
          Cmd.Parameters.Add("@Return_ApplID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ApplID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_RequestID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_RequestID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ApplID = Cmd.Parameters("@Return_ApplID").Value
          Record.RequestID = Cmd.Parameters("@Return_RequestID").Value
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function erpRequestAttachmentsUpdate(ByVal Record As SIS.ERP.erpRequestAttachments) As SIS.ERP.erpRequestAttachments
      Dim _Rec As SIS.ERP.erpRequestAttachments = SIS.ERP.erpRequestAttachments.erpRequestAttachmentsGetByID(Record.ApplID, Record.RequestID, Record.SerialNo)
      With _Rec
        .Description = Record.Description
        .FileName = Record.FileName
        .DiskFile = Record.DiskFile
      End With
      Return SIS.ERP.erpRequestAttachments.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.ERP.erpRequestAttachments) As SIS.ERP.erpRequestAttachments
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpRequestAttachmentsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ApplID",SqlDbType.Int,11, Record.ApplID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RequestID",SqlDbType.Int,11, Record.RequestID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplID",SqlDbType.Int,11, Record.ApplID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestID",SqlDbType.Int,11, Record.RequestID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,101, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileName",SqlDbType.NVarChar,251, Record.FileName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DiskFile",SqlDbType.NVarChar,251, Record.DiskFile)
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
    Public Shared Function erpRequestAttachmentsDelete(ByVal Record As SIS.ERP.erpRequestAttachments) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpRequestAttachmentsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ApplID",SqlDbType.Int,Record.ApplID.ToString.Length, Record.ApplID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RequestID",SqlDbType.Int,Record.RequestID.ToString.Length, Record.RequestID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,Record.SerialNo.ToString.Length, Record.SerialNo)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
			End Using
			If _RecordCount > 0 Then
				Dim tmpPath As String = ConfigurationManager.AppSettings("RequestAttachmentPath")
				Try
					IO.File.Delete(tmpPath & "\" & Record.DiskFile)
				Catch ex As Exception
				End Try
			End If
			Return _RecordCount
    End Function
'		Autocomplete Method
		Public Shared Function SelecterpRequestAttachmentsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "sperpRequestAttachmentsAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
					Results = New List(Of String)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Not Reader.HasRows Then
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(100, " "),"" & "|" & "" & "|" & ""))
					End If
					While (Reader.Read())
            Dim Tmp As SIS.ERP.erpRequestAttachments = New SIS.ERP.erpRequestAttachments(Reader)
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results.ToArray
		End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _ApplID = Ctype(Reader("ApplID"),Int32)
      _RequestID = Ctype(Reader("RequestID"),Int32)
      _SerialNo = Ctype(Reader("SerialNo"),Int32)
      _Description = Ctype(Reader("Description"),String)
      _FileName = Ctype(Reader("FileName"),String)
      _DiskFile = Ctype(Reader("DiskFile"),String)
      _ERP_Applications1_ApplName = Ctype(Reader("ERP_Applications1_ApplName"),String)
      _ERP_ChaneRequest2_ChangeSubject = Ctype(Reader("ERP_ChaneRequest2_ChangeSubject"),String)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
