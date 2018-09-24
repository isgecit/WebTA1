Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.LG
  <DataObject()> _
  Partial Public Class lgWTDCR
    Private Shared _RecordCount As Integer
    Private _DocPK As Int64 = 0
    Private _DCRID As String = ""
    Private _DCRLine As Int32 = 0
    Private _DocumentID As String = ""
    Private _Revision As String = ""
    Private _Iteration As String = ""
    Private _Status As String = ""
    Private _ProjectID As String = ""
    Private _DCRDescription As String = ""
    Private _DCRCreatedOn As String = ""
    Private _DCRCategory As String = ""
    Private _RequestPriority As String = ""
    Private _ApprovalRequiredDate As String = ""
    Private _DCRState As String = ""
    Private _LG_Projects1_ProjectDescription As String = ""
    Private _LG_WTDocument2_DocumentID As String = ""
    Private _FK_LG_WTDCR_ProjectID As SIS.LG.lgProjects = Nothing
    Private _FK_LG_WTDCR_DocPK As SIS.LG.lgWTDocument = Nothing
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
    Public Property DCRID() As String
      Get
        Return _DCRID
      End Get
      Set(ByVal value As String)
        _DCRID = value
      End Set
    End Property
    Public Property DCRLine() As Int32
      Get
        Return _DCRLine
      End Get
      Set(ByVal value As Int32)
        _DCRLine = value
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
    Public Property ProjectID() As String
      Get
        Return _ProjectID
      End Get
      Set(ByVal value As String)
        _ProjectID = value
      End Set
    End Property
    Public Property DCRDescription() As String
      Get
        Return _DCRDescription
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _DCRDescription = ""
				 Else
					 _DCRDescription = value
			   End If
      End Set
    End Property
    Public Property DCRCreatedOn() As String
      Get
        If Not _DCRCreatedOn = String.Empty Then
          Return Convert.ToDateTime(_DCRCreatedOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _DCRCreatedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _DCRCreatedOn = ""
				 Else
					 _DCRCreatedOn = value
			   End If
      End Set
    End Property
    Public Property DCRCategory() As String
      Get
        Return _DCRCategory
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _DCRCategory = ""
				 Else
					 _DCRCategory = value
			   End If
      End Set
    End Property
    Public Property RequestPriority() As String
      Get
        Return _RequestPriority
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _RequestPriority = ""
				 Else
					 _RequestPriority = value
			   End If
      End Set
    End Property
    Public Property ApprovalRequiredDate() As String
      Get
        If Not _ApprovalRequiredDate = String.Empty Then
          Return Convert.ToDateTime(_ApprovalRequiredDate).ToString("dd/MM/yyyy")
        End If
        Return _ApprovalRequiredDate
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ApprovalRequiredDate = ""
				 Else
					 _ApprovalRequiredDate = value
			   End If
      End Set
    End Property
    Public Property DCRState() As String
      Get
        Return _DCRState
      End Get
      Set(ByVal value As String)
        _DCRState = value
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
    Public Property LG_WTDocument2_DocumentID() As String
      Get
        Return _LG_WTDocument2_DocumentID
      End Get
      Set(ByVal value As String)
        _LG_WTDocument2_DocumentID = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _DCRDescription.ToString.PadRight(70, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _DocPK & "|" & _DCRID & "|" & _DCRLine
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
    Public Class PKlgWTDCR
			Private _DocPK As Int64 = 0
			Private _DCRID As String = ""
			Private _DCRLine As Int32 = 0
			Public Property DocPK() As Int64
				Get
					Return _DocPK
				End Get
				Set(ByVal value As Int64)
					_DocPK = value
				End Set
			End Property
			Public Property DCRID() As String
				Get
					Return _DCRID
				End Get
				Set(ByVal value As String)
					_DCRID = value
				End Set
			End Property
			Public Property DCRLine() As Int32
				Get
					Return _DCRLine
				End Get
				Set(ByVal value As Int32)
					_DCRLine = value
				End Set
			End Property
    End Class
    Public ReadOnly Property FK_LG_WTDCR_ProjectID() As SIS.LG.lgProjects
      Get
        If _FK_LG_WTDCR_ProjectID Is Nothing Then
          _FK_LG_WTDCR_ProjectID = SIS.LG.lgProjects.lgProjectsGetByID(_ProjectID)
        End If
        Return _FK_LG_WTDCR_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_LG_WTDCR_DocPK() As SIS.LG.lgWTDocument
      Get
        If _FK_LG_WTDCR_DocPK Is Nothing Then
          _FK_LG_WTDCR_DocPK = SIS.LG.lgWTDocument.lgWTDocumentGetByID(_DocPK)
        End If
        Return _FK_LG_WTDCR_DocPK
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function lgWTDCRSelectList(ByVal OrderBy As String) As List(Of SIS.LG.lgWTDCR)
      Dim Results As List(Of SIS.LG.lgWTDCR) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "splgWTDCRSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.LG.lgWTDCR)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.LG.lgWTDCR(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function lgWTDCRGetNewRecord() As SIS.LG.lgWTDCR
      Return New SIS.LG.lgWTDCR()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function lgWTDCRGetByID(ByVal DocPK As Int64, ByVal DCRID As String, ByVal DCRLine As Int32) As SIS.LG.lgWTDCR
      Dim Results As SIS.LG.lgWTDCR = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "splgWTDCRSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocPK",SqlDbType.BigInt,DocPK.ToString.Length, DocPK)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DCRID",SqlDbType.NVarChar,DCRID.ToString.Length, DCRID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DCRLine",SqlDbType.Int,DCRLine.ToString.Length, DCRLine)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.LG.lgWTDCR(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByDocPK(ByVal DocPK As Int64, ByVal OrderBy as String) As List(Of SIS.LG.lgWTDCR)
      Dim Results As List(Of SIS.LG.lgWTDCR) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "splgWTDCRSelectByDocPK"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocPK",SqlDbType.BigInt,DocPK.ToString.Length, DocPK)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.LG.lgWTDCR)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.LG.lgWTDCR(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByProjectID(ByVal ProjectID As String, ByVal OrderBy as String) As List(Of SIS.LG.lgWTDCR)
      Dim Results As List(Of SIS.LG.lgWTDCR) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "splgWTDCRSelectByProjectID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,ProjectID.ToString.Length, ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.LG.lgWTDCR)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.LG.lgWTDCR(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function lgWTDCRSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal DocPK As Int64) As List(Of SIS.LG.lgWTDCR)
      Dim Results As List(Of SIS.LG.lgWTDCR) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "splgWTDCRSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "splgWTDCRSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DocPK",SqlDbType.BigInt,19, IIf(DocPK = Nothing, 0,DocPK))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.LG.lgWTDCR)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.LG.lgWTDCR(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function lgWTDCRSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal DocPK As Int64) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function lgWTDCRGetByID(ByVal DocPK As Int64, ByVal DCRID As String, ByVal DCRLine As Int32, ByVal Filter_DocPK As Int64) As SIS.LG.lgWTDCR
      Return lgWTDCRGetByID(DocPK, DCRID, DCRLine)
    End Function
'		Autocomplete Method
		Public Shared Function SelectlgWTDCRAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "splgWTDCRAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
					Results = New List(Of String)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Not Reader.HasRows Then
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(70, " "),"" & "|" & "" & "|" & ""))
					End If
					While (Reader.Read())
            Dim Tmp As SIS.LG.lgWTDCR = New SIS.LG.lgWTDCR(Reader)
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
      _DCRID = Ctype(Reader("DCRID"),String)
      _DCRLine = Ctype(Reader("DCRLine"),Int32)
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
      _ProjectID = Ctype(Reader("ProjectID"),String)
      If Convert.IsDBNull(Reader("DCRDescription")) Then
        _DCRDescription = String.Empty
      Else
        _DCRDescription = Ctype(Reader("DCRDescription"), String)
      End If
      If Convert.IsDBNull(Reader("DCRCreatedOn")) Then
        _DCRCreatedOn = String.Empty
      Else
        _DCRCreatedOn = Ctype(Reader("DCRCreatedOn"), String)
      End If
      If Convert.IsDBNull(Reader("DCRCategory")) Then
        _DCRCategory = String.Empty
      Else
        _DCRCategory = Ctype(Reader("DCRCategory"), String)
      End If
      If Convert.IsDBNull(Reader("RequestPriority")) Then
        _RequestPriority = String.Empty
      Else
        _RequestPriority = Ctype(Reader("RequestPriority"), String)
      End If
      If Convert.IsDBNull(Reader("ApprovalRequiredDate")) Then
        _ApprovalRequiredDate = String.Empty
      Else
        _ApprovalRequiredDate = Ctype(Reader("ApprovalRequiredDate"), String)
      End If
      _DCRState = Ctype(Reader("DCRState"),String)
      If Convert.IsDBNull(Reader("LG_Projects1_ProjectDescription")) Then
        _LG_Projects1_ProjectDescription = String.Empty
      Else
        _LG_Projects1_ProjectDescription = Ctype(Reader("LG_Projects1_ProjectDescription"), String)
      End If
      _LG_WTDocument2_DocumentID = Ctype(Reader("LG_WTDocument2_DocumentID"),String)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
