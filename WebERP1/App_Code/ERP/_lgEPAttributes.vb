Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.LG
  <DataObject()> _
  Partial Public Class lgEPAttributes
    Private Shared _RecordCount As Integer
    Private _DocPK As Int64 = 0
    Private _displayName As String = ""
    Private _DocumentID As String = ""
    Private _Revision As String = ""
    Private _Iteration As String = ""
    Private _Status As String = ""
    Private _value As String = ""
    Private _LG_EPDocument1_DocumentID As String = ""
    Private _FK_LG_EPAttributes_DocPK As SIS.LG.lgEPDocument = Nothing
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
    Public Property displayName() As String
      Get
        Return _displayName
      End Get
      Set(ByVal value As String)
        _displayName = value
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
    Public Property value() As String
      Get
        Return _value
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _value = ""
				 Else
					 _value = value
			   End If
      End Set
    End Property
    Public Property LG_EPDocument1_DocumentID() As String
      Get
        Return _LG_EPDocument1_DocumentID
      End Get
      Set(ByVal value As String)
        _LG_EPDocument1_DocumentID = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _displayName.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _DocPK & "|" & _displayName
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
    Public Class PKlgEPAttributes
			Private _DocPK As Int64 = 0
			Private _displayName As String = ""
			Public Property DocPK() As Int64
				Get
					Return _DocPK
				End Get
				Set(ByVal value As Int64)
					_DocPK = value
				End Set
			End Property
			Public Property displayName() As String
				Get
					Return _displayName
				End Get
				Set(ByVal value As String)
					_displayName = value
				End Set
			End Property
    End Class
    Public ReadOnly Property FK_LG_EPAttributes_DocPK() As SIS.LG.lgEPDocument
      Get
        If _FK_LG_EPAttributes_DocPK Is Nothing Then
          _FK_LG_EPAttributes_DocPK = SIS.LG.lgEPDocument.lgEPDocumentGetByID(_DocPK)
        End If
        Return _FK_LG_EPAttributes_DocPK
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function lgEPAttributesSelectList(ByVal OrderBy As String) As List(Of SIS.LG.lgEPAttributes)
      Dim Results As List(Of SIS.LG.lgEPAttributes) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "splgEPAttributesSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.LG.lgEPAttributes)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.LG.lgEPAttributes(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function lgEPAttributesGetNewRecord() As SIS.LG.lgEPAttributes
      Return New SIS.LG.lgEPAttributes()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function lgEPAttributesGetByID(ByVal DocPK As Int64, ByVal displayName As String) As SIS.LG.lgEPAttributes
      Dim Results As SIS.LG.lgEPAttributes = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "splgEPAttributesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocPK",SqlDbType.BigInt,DocPK.ToString.Length, DocPK)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@displayName",SqlDbType.NVarChar,displayName.ToString.Length, displayName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.LG.lgEPAttributes(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByDocPK(ByVal DocPK As Int64, ByVal OrderBy as String) As List(Of SIS.LG.lgEPAttributes)
      Dim Results As List(Of SIS.LG.lgEPAttributes) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "splgEPAttributesSelectByDocPK"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocPK",SqlDbType.BigInt,DocPK.ToString.Length, DocPK)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.LG.lgEPAttributes)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.LG.lgEPAttributes(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function lgEPAttributesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal DocPK As Int64) As List(Of SIS.LG.lgEPAttributes)
      Dim Results As List(Of SIS.LG.lgEPAttributes) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "splgEPAttributesSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "splgEPAttributesSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DocPK",SqlDbType.BigInt,19, IIf(DocPK = Nothing, 0,DocPK))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.LG.lgEPAttributes)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.LG.lgEPAttributes(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function lgEPAttributesSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal DocPK As Int64) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function lgEPAttributesGetByID(ByVal DocPK As Int64, ByVal displayName As String, ByVal Filter_DocPK As Int64) As SIS.LG.lgEPAttributes
      Return lgEPAttributesGetByID(DocPK, displayName)
    End Function
'		Autocomplete Method
		Public Shared Function SelectlgEPAttributesAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "splgEPAttributesAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
					Results = New List(Of String)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Not Reader.HasRows Then
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),"" & "|" & ""))
					End If
					While (Reader.Read())
            Dim Tmp As SIS.LG.lgEPAttributes = New SIS.LG.lgEPAttributes(Reader)
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
      _displayName = Ctype(Reader("displayName"),String)
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
      If Convert.IsDBNull(Reader("value")) Then
        _value = String.Empty
      Else
        _value = Ctype(Reader("value"), String)
      End If
      _LG_EPDocument1_DocumentID = Ctype(Reader("LG_EPDocument1_DocumentID"),String)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
