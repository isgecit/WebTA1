Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.EITL
  <DataObject()> _
  Partial Public Class eitlProjects
    Private Shared _RecordCount As Integer
    Private _ProjectID As String = ""
    Private _Description As String = ""
    Private _CustomerOrderReference As String = ""
    Private _ContactPerson As String = ""
    Private _EmailID As String = ""
    Private _ContactNo As String = ""
    Private _Address1 As String = ""
    Private _Address2 As String = ""
    Private _Address3 As String = ""
    Private _Address4 As String = ""
    Private _ToEMailID As String = ""
    Private _CCEmailID As String = ""
    Private _ProjectSiteEMailID As String = ""
    Private _ProjectSiteEMailPassword As String = ""
    Private _LastNumber As String = ""
    Private _BusinessPartnerID As String = ""
    Private _EITL_Suppliers1_SupplierName As String = ""
    Private _FK_IDM_Projects_BusinessPartnerID As SIS.EITL.eitlSuppliers = Nothing
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
    Public Property ProjectID() As String
      Get
        Return _ProjectID
      End Get
      Set(ByVal value As String)
        _ProjectID = value
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
    Public Property CustomerOrderReference() As String
      Get
        Return _CustomerOrderReference
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _CustomerOrderReference = ""
				 Else
					 _CustomerOrderReference = value
			   End If
      End Set
    End Property
    Public Property ContactPerson() As String
      Get
        Return _ContactPerson
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ContactPerson = ""
				 Else
					 _ContactPerson = value
			   End If
      End Set
    End Property
    Public Property EmailID() As String
      Get
        Return _EmailID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _EmailID = ""
				 Else
					 _EmailID = value
			   End If
      End Set
    End Property
    Public Property ContactNo() As String
      Get
        Return _ContactNo
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ContactNo = ""
				 Else
					 _ContactNo = value
			   End If
      End Set
    End Property
    Public Property Address1() As String
      Get
        Return _Address1
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Address1 = ""
				 Else
					 _Address1 = value
			   End If
      End Set
    End Property
    Public Property Address2() As String
      Get
        Return _Address2
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Address2 = ""
				 Else
					 _Address2 = value
			   End If
      End Set
    End Property
    Public Property Address3() As String
      Get
        Return _Address3
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Address3 = ""
				 Else
					 _Address3 = value
			   End If
      End Set
    End Property
    Public Property Address4() As String
      Get
        Return _Address4
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Address4 = ""
				 Else
					 _Address4 = value
			   End If
      End Set
    End Property
    Public Property ToEMailID() As String
      Get
        Return _ToEMailID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ToEMailID = ""
				 Else
					 _ToEMailID = value
			   End If
      End Set
    End Property
    Public Property CCEmailID() As String
      Get
        Return _CCEmailID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _CCEmailID = ""
				 Else
					 _CCEmailID = value
			   End If
      End Set
    End Property
    Public Property ProjectSiteEMailID() As String
      Get
        Return _ProjectSiteEMailID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ProjectSiteEMailID = ""
				 Else
					 _ProjectSiteEMailID = value
			   End If
      End Set
    End Property
    Public Property ProjectSiteEMailPassword() As String
      Get
        Return _ProjectSiteEMailPassword
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ProjectSiteEMailPassword = ""
				 Else
					 _ProjectSiteEMailPassword = value
			   End If
      End Set
    End Property
    Public Property LastNumber() As String
      Get
        Return _LastNumber
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _LastNumber = ""
				 Else
					 _LastNumber = value
			   End If
      End Set
    End Property
    Public Property BusinessPartnerID() As String
      Get
        Return _BusinessPartnerID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _BusinessPartnerID = ""
				 Else
					 _BusinessPartnerID = value
			   End If
      End Set
    End Property
    Public Property EITL_Suppliers1_SupplierName() As String
      Get
        Return _EITL_Suppliers1_SupplierName
      End Get
      Set(ByVal value As String)
        _EITL_Suppliers1_SupplierName = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _Description.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _ProjectID
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
    Public Class PKeitlProjects
			Private _ProjectID As String = ""
			Public Property ProjectID() As String
				Get
					Return _ProjectID
				End Get
				Set(ByVal value As String)
					_ProjectID = value
				End Set
			End Property
    End Class
    Public ReadOnly Property FK_IDM_Projects_BusinessPartnerID() As SIS.EITL.eitlSuppliers
      Get
        If _FK_IDM_Projects_BusinessPartnerID Is Nothing Then
          _FK_IDM_Projects_BusinessPartnerID = SIS.EITL.eitlSuppliers.eitlSuppliersGetByID(_BusinessPartnerID)
        End If
        Return _FK_IDM_Projects_BusinessPartnerID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlProjectsSelectList(ByVal OrderBy As String) As List(Of SIS.EITL.eitlProjects)
      Dim Results As List(Of SIS.EITL.eitlProjects) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlProjectsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.EITL.eitlProjects)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.EITL.eitlProjects(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlProjectsGetNewRecord() As SIS.EITL.eitlProjects
      Return New SIS.EITL.eitlProjects()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlProjectsGetByID(ByVal ProjectID As String) As SIS.EITL.eitlProjects
      Dim Results As SIS.EITL.eitlProjects = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlProjectsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,ProjectID.ToString.Length, ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.EITL.eitlProjects(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByBusinessPartnerID(ByVal BusinessPartnerID As String, ByVal OrderBy as String) As List(Of SIS.EITL.eitlProjects)
      Dim Results As List(Of SIS.EITL.eitlProjects) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlProjectsSelectByBusinessPartnerID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BusinessPartnerID",SqlDbType.NVarChar,BusinessPartnerID.ToString.Length, BusinessPartnerID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.EITL.eitlProjects)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.EITL.eitlProjects(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlProjectsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.EITL.eitlProjects)
      Dim Results As List(Of SIS.EITL.eitlProjects) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "speitlProjectsSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "speitlProjectsSelectListFilteres"
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.EITL.eitlProjects)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.EITL.eitlProjects(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function eitlProjectsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function eitlProjectsInsert(ByVal Record As SIS.EITL.eitlProjects) As SIS.EITL.eitlProjects
      Dim _Rec As SIS.EITL.eitlProjects = SIS.EITL.eitlProjects.eitlProjectsGetNewRecord()
      With _Rec
        .ProjectID = Record.ProjectID
        .Description = Record.Description
        .CustomerOrderReference = Record.CustomerOrderReference
        .ContactPerson = Record.ContactPerson
        .EmailID = Record.EmailID
        .ContactNo = Record.ContactNo
        .Address1 = Record.Address1
        .Address2 = Record.Address2
        .Address3 = Record.Address3
        .Address4 = Record.Address4
        .ToEMailID = Record.ToEMailID
        .CCEmailID = Record.CCEmailID
        .ProjectSiteEMailID = Record.ProjectSiteEMailID
        .ProjectSiteEMailPassword = Record.ProjectSiteEMailPassword
        .LastNumber = Record.LastNumber
        .BusinessPartnerID = Record.BusinessPartnerID
      End With
      Return SIS.EITL.eitlProjects.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.EITL.eitlProjects) As SIS.EITL.eitlProjects
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlProjectsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CustomerOrderReference",SqlDbType.NVarChar,51, Iif(Record.CustomerOrderReference= "" ,Convert.DBNull, Record.CustomerOrderReference))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ContactPerson",SqlDbType.NVarChar,51, Iif(Record.ContactPerson= "" ,Convert.DBNull, Record.ContactPerson))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmailID",SqlDbType.NVarChar,51, Iif(Record.EmailID= "" ,Convert.DBNull, Record.EmailID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ContactNo",SqlDbType.NVarChar,21, Iif(Record.ContactNo= "" ,Convert.DBNull, Record.ContactNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Address1",SqlDbType.NVarChar,61, Iif(Record.Address1= "" ,Convert.DBNull, Record.Address1))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Address2",SqlDbType.NVarChar,61, Iif(Record.Address2= "" ,Convert.DBNull, Record.Address2))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Address3",SqlDbType.NVarChar,61, Iif(Record.Address3= "" ,Convert.DBNull, Record.Address3))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Address4",SqlDbType.NVarChar,61, Iif(Record.Address4= "" ,Convert.DBNull, Record.Address4))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ToEMailID",SqlDbType.NVarChar,251, Iif(Record.ToEMailID= "" ,Convert.DBNull, Record.ToEMailID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CCEmailID",SqlDbType.NVarChar,251, Iif(Record.CCEmailID= "" ,Convert.DBNull, Record.CCEmailID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectSiteEMailID",SqlDbType.NVarChar,251, Iif(Record.ProjectSiteEMailID= "" ,Convert.DBNull, Record.ProjectSiteEMailID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectSiteEMailPassword",SqlDbType.NVarChar,51, Iif(Record.ProjectSiteEMailPassword= "" ,Convert.DBNull, Record.ProjectSiteEMailPassword))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LastNumber",SqlDbType.Int,11, Iif(Record.LastNumber= "" ,Convert.DBNull, Record.LastNumber))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BusinessPartnerID",SqlDbType.NVarChar,10, Iif(Record.BusinessPartnerID= "" ,Convert.DBNull, Record.BusinessPartnerID))
          Cmd.Parameters.Add("@Return_ProjectID", SqlDbType.NVarChar, 7)
          Cmd.Parameters("@Return_ProjectID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ProjectID = Cmd.Parameters("@Return_ProjectID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function eitlProjectsUpdate(ByVal Record As SIS.EITL.eitlProjects) As SIS.EITL.eitlProjects
      Dim _Rec As SIS.EITL.eitlProjects = SIS.EITL.eitlProjects.eitlProjectsGetByID(Record.ProjectID)
      With _Rec
        .Description = Record.Description
        .CustomerOrderReference = Record.CustomerOrderReference
        .ContactPerson = Record.ContactPerson
        .EmailID = Record.EmailID
        .ContactNo = Record.ContactNo
        .Address1 = Record.Address1
        .Address2 = Record.Address2
        .Address3 = Record.Address3
        .Address4 = Record.Address4
        .ToEMailID = Record.ToEMailID
        .CCEmailID = Record.CCEmailID
        .ProjectSiteEMailID = Record.ProjectSiteEMailID
        .ProjectSiteEMailPassword = Record.ProjectSiteEMailPassword
        .LastNumber = Record.LastNumber
        .BusinessPartnerID = Record.BusinessPartnerID
      End With
      Return SIS.EITL.eitlProjects.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.EITL.eitlProjects) As SIS.EITL.eitlProjects
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlProjectsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CustomerOrderReference",SqlDbType.NVarChar,51, Iif(Record.CustomerOrderReference= "" ,Convert.DBNull, Record.CustomerOrderReference))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ContactPerson",SqlDbType.NVarChar,51, Iif(Record.ContactPerson= "" ,Convert.DBNull, Record.ContactPerson))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmailID",SqlDbType.NVarChar,51, Iif(Record.EmailID= "" ,Convert.DBNull, Record.EmailID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ContactNo",SqlDbType.NVarChar,21, Iif(Record.ContactNo= "" ,Convert.DBNull, Record.ContactNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Address1",SqlDbType.NVarChar,61, Iif(Record.Address1= "" ,Convert.DBNull, Record.Address1))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Address2",SqlDbType.NVarChar,61, Iif(Record.Address2= "" ,Convert.DBNull, Record.Address2))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Address3",SqlDbType.NVarChar,61, Iif(Record.Address3= "" ,Convert.DBNull, Record.Address3))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Address4",SqlDbType.NVarChar,61, Iif(Record.Address4= "" ,Convert.DBNull, Record.Address4))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ToEMailID",SqlDbType.NVarChar,251, Iif(Record.ToEMailID= "" ,Convert.DBNull, Record.ToEMailID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CCEmailID",SqlDbType.NVarChar,251, Iif(Record.CCEmailID= "" ,Convert.DBNull, Record.CCEmailID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectSiteEMailID",SqlDbType.NVarChar,251, Iif(Record.ProjectSiteEMailID= "" ,Convert.DBNull, Record.ProjectSiteEMailID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectSiteEMailPassword",SqlDbType.NVarChar,51, Iif(Record.ProjectSiteEMailPassword= "" ,Convert.DBNull, Record.ProjectSiteEMailPassword))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LastNumber",SqlDbType.Int,11, Iif(Record.LastNumber= "" ,Convert.DBNull, Record.LastNumber))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BusinessPartnerID",SqlDbType.NVarChar,10, Iif(Record.BusinessPartnerID= "" ,Convert.DBNull, Record.BusinessPartnerID))
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
    Public Shared Function eitlProjectsDelete(ByVal Record As SIS.EITL.eitlProjects) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlProjectsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID",SqlDbType.NVarChar,Record.ProjectID.ToString.Length, Record.ProjectID)
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
		Public Shared Function SelecteitlProjectsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "speitlProjectsAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
					Results = New List(Of String)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Not Reader.HasRows Then
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),""))
					End If
					While (Reader.Read())
            Dim Tmp As SIS.EITL.eitlProjects = New SIS.EITL.eitlProjects(Reader)
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results.ToArray
		End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _ProjectID = Ctype(Reader("ProjectID"),String)
      _Description = Ctype(Reader("Description"),String)
      If Convert.IsDBNull(Reader("CustomerOrderReference")) Then
        _CustomerOrderReference = String.Empty
      Else
        _CustomerOrderReference = Ctype(Reader("CustomerOrderReference"), String)
      End If
      If Convert.IsDBNull(Reader("ContactPerson")) Then
        _ContactPerson = String.Empty
      Else
        _ContactPerson = Ctype(Reader("ContactPerson"), String)
      End If
      If Convert.IsDBNull(Reader("EmailID")) Then
        _EmailID = String.Empty
      Else
        _EmailID = Ctype(Reader("EmailID"), String)
      End If
      If Convert.IsDBNull(Reader("ContactNo")) Then
        _ContactNo = String.Empty
      Else
        _ContactNo = Ctype(Reader("ContactNo"), String)
      End If
      If Convert.IsDBNull(Reader("Address1")) Then
        _Address1 = String.Empty
      Else
        _Address1 = Ctype(Reader("Address1"), String)
      End If
      If Convert.IsDBNull(Reader("Address2")) Then
        _Address2 = String.Empty
      Else
        _Address2 = Ctype(Reader("Address2"), String)
      End If
      If Convert.IsDBNull(Reader("Address3")) Then
        _Address3 = String.Empty
      Else
        _Address3 = Ctype(Reader("Address3"), String)
      End If
      If Convert.IsDBNull(Reader("Address4")) Then
        _Address4 = String.Empty
      Else
        _Address4 = Ctype(Reader("Address4"), String)
      End If
      If Convert.IsDBNull(Reader("ToEMailID")) Then
        _ToEMailID = String.Empty
      Else
        _ToEMailID = Ctype(Reader("ToEMailID"), String)
      End If
      If Convert.IsDBNull(Reader("CCEmailID")) Then
        _CCEmailID = String.Empty
      Else
        _CCEmailID = Ctype(Reader("CCEmailID"), String)
      End If
      If Convert.IsDBNull(Reader("ProjectSiteEMailID")) Then
        _ProjectSiteEMailID = String.Empty
      Else
        _ProjectSiteEMailID = Ctype(Reader("ProjectSiteEMailID"), String)
      End If
      If Convert.IsDBNull(Reader("ProjectSiteEMailPassword")) Then
        _ProjectSiteEMailPassword = String.Empty
      Else
        _ProjectSiteEMailPassword = Ctype(Reader("ProjectSiteEMailPassword"), String)
      End If
      If Convert.IsDBNull(Reader("LastNumber")) Then
        _LastNumber = String.Empty
      Else
        _LastNumber = Ctype(Reader("LastNumber"), String)
      End If
      If Convert.IsDBNull(Reader("BusinessPartnerID")) Then
        _BusinessPartnerID = String.Empty
      Else
        _BusinessPartnerID = Ctype(Reader("BusinessPartnerID"), String)
      End If
      _EITL_Suppliers1_SupplierName = Ctype(Reader("EITL_Suppliers1_SupplierName"),String)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
