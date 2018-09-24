Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  <DataObject()> _
  Partial Public Class vrTransporters
    Private Shared _RecordCount As Integer
    Private _TransporterID As String = ""
    Private _TransporterName As String = ""
    Private _Address1Line As String = ""
    Private _Address2Line As String = ""
    Private _City As String = ""
    Private _EMailID As String = ""
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
    Public Property TransporterID() As String
      Get
        Return _TransporterID
      End Get
      Set(ByVal value As String)
        _TransporterID = value
      End Set
    End Property
    Public Property TransporterName() As String
      Get
        Return _TransporterName
      End Get
      Set(ByVal value As String)
        _TransporterName = value
      End Set
    End Property
    Public Property Address1Line() As String
      Get
        Return _Address1Line
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Address1Line = ""
				 Else
					 _Address1Line = value
			   End If
      End Set
    End Property
    Public Property Address2Line() As String
      Get
        Return _Address2Line
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Address2Line = ""
				 Else
					 _Address2Line = value
			   End If
      End Set
    End Property
    Public Property City() As String
      Get
        Return _City
      End Get
      Set(ByVal value As String)
        _City = value
      End Set
    End Property
    Public Property EMailID() As String
      Get
        Return _EMailID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _EMailID = ""
				 Else
					 _EMailID = value
			   End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _TransporterName.ToString.PadRight(100, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _TransporterID
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
    Public Class PKvrTransporters
			Private _TransporterID As String = ""
			Public Property TransporterID() As String
				Get
					Return _TransporterID
				End Get
				Set(ByVal value As String)
					_TransporterID = value
				End Set
			End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrTransportersSelectList(ByVal OrderBy As String) As List(Of SIS.VR.vrTransporters)
      Dim Results As List(Of SIS.VR.vrTransporters) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrTransportersSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrTransporters)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrTransporters(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrTransportersGetNewRecord() As SIS.VR.vrTransporters
      Return New SIS.VR.vrTransporters()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrTransportersGetByID(ByVal TransporterID As String) As SIS.VR.vrTransporters
      Dim Results As SIS.VR.vrTransporters = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrTransportersSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransporterID",SqlDbType.NVarChar,TransporterID.ToString.Length, TransporterID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.VR.vrTransporters(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrTransportersSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.VR.vrTransporters)
      Dim Results As List(Of SIS.VR.vrTransporters) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spvrTransportersSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spvrTransportersSelectListFilteres"
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrTransporters)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrTransporters(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function vrTransportersSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function vrTransportersInsert(ByVal Record As SIS.VR.vrTransporters) As SIS.VR.vrTransporters
      Dim _Rec As SIS.VR.vrTransporters = SIS.VR.vrTransporters.vrTransportersGetNewRecord()
      With _Rec
        .TransporterID = Record.TransporterID
        .TransporterName = Record.TransporterName
        .Address1Line = Record.Address1Line
        .Address2Line = Record.Address2Line
        .City = Record.City
        .EMailID = Record.EMailID
      End With
      Return SIS.VR.vrTransporters.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.VR.vrTransporters) As SIS.VR.vrTransporters
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrTransportersInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransporterID",SqlDbType.NVarChar,10, Record.TransporterID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransporterName",SqlDbType.NVarChar,101, Record.TransporterName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Address1Line",SqlDbType.NVarChar,101, Iif(Record.Address1Line= "" ,Convert.DBNull, Record.Address1Line))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Address2Line",SqlDbType.NVarChar,101, Iif(Record.Address2Line= "" ,Convert.DBNull, Record.Address2Line))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@City",SqlDbType.NVarChar,51, Record.City)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EMailID",SqlDbType.NVarChar,201, Iif(Record.EMailID= "" ,Convert.DBNull, Record.EMailID))
          Cmd.Parameters.Add("@Return_TransporterID", SqlDbType.NVarChar, 10)
          Cmd.Parameters("@Return_TransporterID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.TransporterID = Cmd.Parameters("@Return_TransporterID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function vrTransportersUpdate(ByVal Record As SIS.VR.vrTransporters) As SIS.VR.vrTransporters
      Dim _Rec As SIS.VR.vrTransporters = SIS.VR.vrTransporters.vrTransportersGetByID(Record.TransporterID)
      With _Rec
        .TransporterName = Record.TransporterName
        .Address1Line = Record.Address1Line
        .Address2Line = Record.Address2Line
        .City = Record.City
        .EMailID = Record.EMailID
      End With
      Return SIS.VR.vrTransporters.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.VR.vrTransporters) As SIS.VR.vrTransporters
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrTransportersUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TransporterID",SqlDbType.NVarChar,10, Record.TransporterID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransporterID",SqlDbType.NVarChar,10, Record.TransporterID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransporterName",SqlDbType.NVarChar,101, Record.TransporterName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Address1Line",SqlDbType.NVarChar,101, Iif(Record.Address1Line= "" ,Convert.DBNull, Record.Address1Line))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Address2Line",SqlDbType.NVarChar,101, Iif(Record.Address2Line= "" ,Convert.DBNull, Record.Address2Line))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@City",SqlDbType.NVarChar,51, Record.City)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EMailID",SqlDbType.NVarChar,201, Iif(Record.EMailID= "" ,Convert.DBNull, Record.EMailID))
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
    Public Shared Function vrTransportersDelete(ByVal Record As SIS.VR.vrTransporters) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrTransportersDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TransporterID",SqlDbType.NVarChar,Record.TransporterID.ToString.Length, Record.TransporterID)
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
		Public Shared Function SelectvrTransportersAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spvrTransportersAutoCompleteList"
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
            Dim Tmp As SIS.VR.vrTransporters = New SIS.VR.vrTransporters(Reader)
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results.ToArray
		End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _TransporterID = Ctype(Reader("TransporterID"),String)
      _TransporterName = Ctype(Reader("TransporterName"),String)
      If Convert.IsDBNull(Reader("Address1Line")) Then
        _Address1Line = String.Empty
      Else
        _Address1Line = Ctype(Reader("Address1Line"), String)
      End If
      If Convert.IsDBNull(Reader("Address2Line")) Then
        _Address2Line = String.Empty
      Else
        _Address2Line = Ctype(Reader("Address2Line"), String)
      End If
      _City = Ctype(Reader("City"),String)
      If Convert.IsDBNull(Reader("EMailID")) Then
        _EMailID = String.Empty
      Else
        _EMailID = Ctype(Reader("EMailID"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
