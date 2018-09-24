Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.LG
  <DataObject()> _
  Partial Public Class lgEPDocument
    Private Shared _RecordCount As Integer
    Private _DocPK As Int64 = 0
    Private _DocumentID As String = ""
    Private _Revision As String = ""
    Private _Iteration As String = ""
    Private _Status As String = ""
    Private _Title As String = ""
    Private _CreatedOn As String = ""
    Private _UpdatedOn As String = ""
    Private _DocType As String = ""
    Private _ProjectID As String = ""
    Private _ElementID As String = ""
    Private _ProjectDescription As String = ""
    Private _ElementDescription As String = ""
    Private _DiskFileName As String = ""
    Private _LG_Projects1_ProjectDescription As String = ""
    Private _FK_LG_EPDocument_ProjectID As SIS.LG.lgProjects = Nothing
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
    Public Property DocPK() As Int64
      Get
        Return _DocPK
      End Get
      Set(ByVal value As Int64)
        _DocPK = value
      End Set
    End Property
    Public Property DocumentID() As String
      Get
        Return _DocumentID
      End Get
      Set(ByVal value As String)
        _DocumentID = value
      End Set
    End Property
    Public Property Revision() As String
      Get
        Return _Revision
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Revision = ""
				 Else
					 _Revision = value
			   End If
      End Set
    End Property
    Public Property Iteration() As String
      Get
        Return _Iteration
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Iteration = ""
				 Else
					 _Iteration = value
			   End If
      End Set
    End Property
    Public Property Status() As String
      Get
        Return _Status
      End Get
      Set(ByVal value As String)
        _Status = value
      End Set
    End Property
    Public Property Title() As String
      Get
        Return _Title
      End Get
      Set(ByVal value As String)
        _Title = value
      End Set
    End Property
    Public Property CreatedOn() As String
      Get
        If Not _CreatedOn = String.Empty Then
          Return Convert.ToDateTime(_CreatedOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _CreatedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _CreatedOn = ""
				 Else
					 _CreatedOn = value
			   End If
      End Set
    End Property
    Public Property UpdatedOn() As String
      Get
        If Not _UpdatedOn = String.Empty Then
          Return Convert.ToDateTime(_UpdatedOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _UpdatedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _UpdatedOn = ""
				 Else
					 _UpdatedOn = value
			   End If
      End Set
    End Property
    Public Property DocType() As String
      Get
        Return _DocType
      End Get
      Set(ByVal value As String)
        _DocType = value
      End Set
    End Property
    Public Property ProjectID() As String
      Get
        Return _ProjectID
      End Get
      Set(ByVal value As String)
        _ProjectID = value
      End Set
    End Property
    Public Property ElementID() As String
      Get
        Return _ElementID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ElementID = ""
				 Else
					 _ElementID = value
			   End If
      End Set
    End Property
    Public Property ProjectDescription() As String
      Get
        Return _ProjectDescription
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ProjectDescription = ""
				 Else
					 _ProjectDescription = value
			   End If
      End Set
    End Property
    Public Property ElementDescription() As String
      Get
        Return _ElementDescription
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ElementDescription = ""
				 Else
					 _ElementDescription = value
			   End If
      End Set
    End Property
    Public Property DiskFileName() As String
      Get
        Return _DiskFileName
      End Get
      Set(ByVal value As String)
        _DiskFileName = value
      End Set
    End Property
    Public Property LG_Projects1_ProjectDescription() As String
      Get
        Return _LG_Projects1_ProjectDescription
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _LG_Projects1_ProjectDescription = ""
				 Else
					 _LG_Projects1_ProjectDescription = value
			   End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _DocumentID.ToString.PadRight(100, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _DocPK
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
    Public Class PKlgEPDocument
			Private _DocPK As Int64 = 0
			Public Property DocPK() As Int64
				Get
					Return _DocPK
				End Get
				Set(ByVal value As Int64)
					_DocPK = value
				End Set
			End Property
    End Class
    Public ReadOnly Property FK_LG_EPDocument_ProjectID() As SIS.LG.lgProjects
      Get
        If _FK_LG_EPDocument_ProjectID Is Nothing Then
          _FK_LG_EPDocument_ProjectID = SIS.LG.lgProjects.lgProjectsGetByID(_ProjectID)
        End If
        Return _FK_LG_EPDocument_ProjectID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function lgEPDocumentSelectList(ByVal OrderBy As String) As List(Of SIS.LG.lgEPDocument)
      Dim Results As List(Of SIS.LG.lgEPDocument) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "splgEPDocumentSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.LG.lgEPDocument)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.LG.lgEPDocument(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function lgEPDocumentGetNewRecord() As SIS.LG.lgEPDocument
      Return New SIS.LG.lgEPDocument()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function lgEPDocumentGetByID(ByVal DocPK As Int64) As SIS.LG.lgEPDocument
      Dim Results As SIS.LG.lgEPDocument = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "splgEPDocumentSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocPK",SqlDbType.BigInt,DocPK.ToString.Length, DocPK)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.LG.lgEPDocument(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByProjectID(ByVal ProjectID As String, ByVal OrderBy as String) As List(Of SIS.LG.lgEPDocument)
      Dim Results As List(Of SIS.LG.lgEPDocument) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "splgEPDocumentSelectByProjectID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,ProjectID.ToString.Length, ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.LG.lgEPDocument)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.LG.lgEPDocument(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function lgEPDocumentSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String) As List(Of SIS.LG.lgEPDocument)
      Dim Results As List(Of SIS.LG.lgEPDocument) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "splgEPDocumentSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "splgEPDocumentSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,20, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.LG.lgEPDocument)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.LG.lgEPDocument(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function lgEPDocumentSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function lgEPDocumentGetByID(ByVal DocPK As Int64, ByVal Filter_ProjectID As String) As SIS.LG.lgEPDocument
      Return lgEPDocumentGetByID(DocPK)
    End Function
'		Autocomplete Method
		Public Shared Function SelectlgEPDocumentAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "splgEPDocumentAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
					Results = New List(Of String)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Not Reader.HasRows Then
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(100, " "),""))
					End If
					While (Reader.Read())
            Dim Tmp As SIS.LG.lgEPDocument = New SIS.LG.lgEPDocument(Reader)
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results.ToArray
		End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _DocPK = Ctype(Reader("DocPK"),Int64)
      _DocumentID = Ctype(Reader("DocumentID"),String)
      If Convert.IsDBNull(Reader("Revision")) Then
        _Revision = String.Empty
      Else
        _Revision = Ctype(Reader("Revision"), String)
      End If
      If Convert.IsDBNull(Reader("Iteration")) Then
        _Iteration = String.Empty
      Else
        _Iteration = Ctype(Reader("Iteration"), String)
      End If
      _Status = Ctype(Reader("Status"),String)
      _Title = Ctype(Reader("Title"),String)
      If Convert.IsDBNull(Reader("CreatedOn")) Then
        _CreatedOn = String.Empty
      Else
        _CreatedOn = Ctype(Reader("CreatedOn"), String)
      End If
      If Convert.IsDBNull(Reader("UpdatedOn")) Then
        _UpdatedOn = String.Empty
      Else
        _UpdatedOn = Ctype(Reader("UpdatedOn"), String)
      End If
      _DocType = Ctype(Reader("DocType"),String)
      _ProjectID = Ctype(Reader("ProjectID"),String)
      If Convert.IsDBNull(Reader("ElementID")) Then
        _ElementID = String.Empty
      Else
        _ElementID = Ctype(Reader("ElementID"), String)
      End If
      If Convert.IsDBNull(Reader("ProjectDescription")) Then
        _ProjectDescription = String.Empty
      Else
        _ProjectDescription = Ctype(Reader("ProjectDescription"), String)
      End If
      If Convert.IsDBNull(Reader("ElementDescription")) Then
        _ElementDescription = String.Empty
      Else
        _ElementDescription = Ctype(Reader("ElementDescription"), String)
      End If
      _DiskFileName = Ctype(Reader("DiskFileName"),String)
      If Convert.IsDBNull(Reader("LG_Projects1_ProjectDescription")) Then
        _LG_Projects1_ProjectDescription = String.Empty
      Else
        _LG_Projects1_ProjectDescription = Ctype(Reader("LG_Projects1_ProjectDescription"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
