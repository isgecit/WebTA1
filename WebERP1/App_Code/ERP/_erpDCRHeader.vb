Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ERP
  <DataObject()> _
  Partial Public Class erpDCRHeader
    Private Shared _RecordCount As Integer
    Private _DCRNo As String = ""
    Private _DCRDate As String = ""
    Private _DCRDescription As String = ""
    Private _CreatedBy As String = ""
    Private _CreatedName As String = ""
    Private _CreatedEMail As String = ""
    Private _ProjectID As String = ""
    Private _ProjectDescription As String = ""
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
    Public Property DCRNo() As String
      Get
        Return _DCRNo
      End Get
      Set(ByVal value As String)
        _DCRNo = value
      End Set
    End Property
    Public Property DCRDate() As String
      Get
        Return _DCRDate
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _DCRDate = ""
				 Else
					 _DCRDate = value
			   End If
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
    Public Property CreatedBy() As String
      Get
        Return _CreatedBy
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _CreatedBy = ""
				 Else
					 _CreatedBy = value
			   End If
      End Set
    End Property
    Public Property CreatedName() As String
      Get
        Return _CreatedName
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _CreatedName = ""
				 Else
					 _CreatedName = value
			   End If
      End Set
    End Property
    Public Property CreatedEMail() As String
      Get
        Return _CreatedEMail
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _CreatedEMail = ""
				 Else
					 _CreatedEMail = value
			   End If
      End Set
    End Property
    Public Property ProjectID() As String
      Get
        Return _ProjectID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ProjectID = ""
				 Else
					 _ProjectID = value
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
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _DCRDescription.ToString.PadRight(100, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _DCRNo
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
    Public Class PKerpDCRHeader
			Private _DCRNo As String = ""
			Public Property DCRNo() As String
				Get
					Return _DCRNo
				End Get
				Set(ByVal value As String)
					_DCRNo = value
				End Set
			End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpDCRHeaderSelectList(ByVal OrderBy As String) As List(Of SIS.ERP.erpDCRHeader)
      Dim Results As List(Of SIS.ERP.erpDCRHeader) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpDCRHeaderSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ERP.erpDCRHeader)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ERP.erpDCRHeader(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpDCRHeaderGetNewRecord() As SIS.ERP.erpDCRHeader
      Return New SIS.ERP.erpDCRHeader()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpDCRHeaderGetByID(ByVal DCRNo As String) As SIS.ERP.erpDCRHeader
      Dim Results As SIS.ERP.erpDCRHeader = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpDCRHeaderSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DCRNo",SqlDbType.NVarChar,DCRNo.ToString.Length, DCRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.ERP.erpDCRHeader(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpDCRHeaderSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.ERP.erpDCRHeader)
      Dim Results As List(Of SIS.ERP.erpDCRHeader) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "sperpDCRHeaderSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "sperpDCRHeaderSelectListFilteres"
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ERP.erpDCRHeader)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ERP.erpDCRHeader(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function erpDCRHeaderSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function erpDCRHeaderInsert(ByVal Record As SIS.ERP.erpDCRHeader) As SIS.ERP.erpDCRHeader
      Dim _Rec As SIS.ERP.erpDCRHeader = SIS.ERP.erpDCRHeader.erpDCRHeaderGetNewRecord()
      With _Rec
        .DCRNo = Record.DCRNo
        .DCRDate = Record.DCRDate
        .DCRDescription = Record.DCRDescription
        .CreatedBy = Record.CreatedBy
        .CreatedName = Record.CreatedName
        .CreatedEMail = Record.CreatedEMail
        .ProjectID = Record.ProjectID
        .ProjectDescription = Record.ProjectDescription
      End With
      Return SIS.ERP.erpDCRHeader.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.ERP.erpDCRHeader) As SIS.ERP.erpDCRHeader
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpDCRHeaderInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DCRNo",SqlDbType.NVarChar,11, Record.DCRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DCRDate",SqlDbType.NVarChar,21, Iif(Record.DCRDate= "" ,Convert.DBNull, Record.DCRDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DCRDescription",SqlDbType.NVarChar,101, Iif(Record.DCRDescription= "" ,Convert.DBNull, Record.DCRDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedName",SqlDbType.NVarChar,51, Iif(Record.CreatedName= "" ,Convert.DBNull, Record.CreatedName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedEMail",SqlDbType.NVarChar,51, Iif(Record.CreatedEMail= "" ,Convert.DBNull, Record.CreatedEMail))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectDescription",SqlDbType.NVarChar,101, Iif(Record.ProjectDescription= "" ,Convert.DBNull, Record.ProjectDescription))
          Cmd.Parameters.Add("@Return_DCRNo", SqlDbType.NVarChar, 11)
          Cmd.Parameters("@Return_DCRNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.DCRNo = Cmd.Parameters("@Return_DCRNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function erpDCRHeaderUpdate(ByVal Record As SIS.ERP.erpDCRHeader) As SIS.ERP.erpDCRHeader
      Dim _Rec As SIS.ERP.erpDCRHeader = SIS.ERP.erpDCRHeader.erpDCRHeaderGetByID(Record.DCRNo)
      With _Rec
        .DCRDate = Record.DCRDate
        .DCRDescription = Record.DCRDescription
        .CreatedBy = Record.CreatedBy
        .CreatedName = Record.CreatedName
        .CreatedEMail = Record.CreatedEMail
        .ProjectID = Record.ProjectID
        .ProjectDescription = Record.ProjectDescription
      End With
      Return SIS.ERP.erpDCRHeader.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.ERP.erpDCRHeader) As SIS.ERP.erpDCRHeader
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpDCRHeaderUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DCRNo",SqlDbType.NVarChar,11, Record.DCRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DCRNo",SqlDbType.NVarChar,11, Record.DCRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DCRDate",SqlDbType.NVarChar,21, Iif(Record.DCRDate= "" ,Convert.DBNull, Record.DCRDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DCRDescription",SqlDbType.NVarChar,101, Iif(Record.DCRDescription= "" ,Convert.DBNull, Record.DCRDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedName",SqlDbType.NVarChar,51, Iif(Record.CreatedName= "" ,Convert.DBNull, Record.CreatedName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedEMail",SqlDbType.NVarChar,51, Iif(Record.CreatedEMail= "" ,Convert.DBNull, Record.CreatedEMail))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectDescription",SqlDbType.NVarChar,101, Iif(Record.ProjectDescription= "" ,Convert.DBNull, Record.ProjectDescription))
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
    Public Shared Function erpDCRHeaderDelete(ByVal Record As SIS.ERP.erpDCRHeader) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpDCRHeaderDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DCRNo",SqlDbType.NVarChar,Record.DCRNo.ToString.Length, Record.DCRNo)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _RecordCount
    End Function
'		Autocomplete Method
		Public Shared Function SelecterpDCRHeaderAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "sperpDCRHeaderAutoCompleteList"
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
            Dim Tmp As SIS.ERP.erpDCRHeader = New SIS.ERP.erpDCRHeader(Reader)
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results.ToArray
		End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _DCRNo = Ctype(Reader("DCRNo"),String)
      If Convert.IsDBNull(Reader("DCRDate")) Then
        _DCRDate = String.Empty
      Else
        _DCRDate = Ctype(Reader("DCRDate"), String)
      End If
      If Convert.IsDBNull(Reader("DCRDescription")) Then
        _DCRDescription = String.Empty
      Else
        _DCRDescription = Ctype(Reader("DCRDescription"), String)
      End If
      If Convert.IsDBNull(Reader("CreatedBy")) Then
        _CreatedBy = String.Empty
      Else
        _CreatedBy = Ctype(Reader("CreatedBy"), String)
      End If
      If Convert.IsDBNull(Reader("CreatedName")) Then
        _CreatedName = String.Empty
      Else
        _CreatedName = Ctype(Reader("CreatedName"), String)
      End If
      If Convert.IsDBNull(Reader("CreatedEMail")) Then
        _CreatedEMail = String.Empty
      Else
        _CreatedEMail = Ctype(Reader("CreatedEMail"), String)
      End If
      If Convert.IsDBNull(Reader("ProjectID")) Then
        _ProjectID = String.Empty
      Else
        _ProjectID = Ctype(Reader("ProjectID"), String)
      End If
      If Convert.IsDBNull(Reader("ProjectDescription")) Then
        _ProjectDescription = String.Empty
      Else
        _ProjectDescription = Ctype(Reader("ProjectDescription"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
