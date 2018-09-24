Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taApprovalWFTypes
    Private Shared _RecordCount As Integer
    Private _WFTypeID As Int32 = 0
    Private _WFTypeDescription As String = ""
    Private _RequiredDivisionHeadApproval As Boolean = False
    Private _RequiredMDApproval As Boolean = False
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
    Public Property WFTypeID() As Int32
      Get
        Return _WFTypeID
      End Get
      Set(ByVal value As Int32)
        _WFTypeID = value
      End Set
    End Property
    Public Property WFTypeDescription() As String
      Get
        Return _WFTypeDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WFTypeDescription = ""
         Else
           _WFTypeDescription = value
         End If
      End Set
    End Property
    Public Property RequiredDivisionHeadApproval() As Boolean
      Get
        Return _RequiredDivisionHeadApproval
      End Get
      Set(ByVal value As Boolean)
        _RequiredDivisionHeadApproval = value
      End Set
    End Property
    Public Property RequiredMDApproval() As Boolean
      Get
        Return _RequiredMDApproval
      End Get
      Set(ByVal value As Boolean)
        _RequiredMDApproval = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _WFTypeDescription.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _WFTypeID
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
    Public Class PKtaApprovalWFTypes
      Private _WFTypeID As Int32 = 0
      Public Property WFTypeID() As Int32
        Get
          Return _WFTypeID
        End Get
        Set(ByVal value As Int32)
          _WFTypeID = value
        End Set
      End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taApprovalWFTypesSelectList(ByVal OrderBy As String) As List(Of SIS.TA.taApprovalWFTypes)
      Dim Results As List(Of SIS.TA.taApprovalWFTypes) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "WFTypeID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaApprovalWFTypesSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taApprovalWFTypes)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taApprovalWFTypes(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taApprovalWFTypesGetNewRecord() As SIS.TA.taApprovalWFTypes
      Return New SIS.TA.taApprovalWFTypes()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taApprovalWFTypesGetByID(ByVal WFTypeID As Int32) As SIS.TA.taApprovalWFTypes
      Dim Results As SIS.TA.taApprovalWFTypes = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaApprovalWFTypesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WFTypeID",SqlDbType.Int,WFTypeID.ToString.Length, WFTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TA.taApprovalWFTypes(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taApprovalWFTypesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.TA.taApprovalWFTypes)
      Dim Results As List(Of SIS.TA.taApprovalWFTypes) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "WFTypeID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaApprovalWFTypesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaApprovalWFTypesSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taApprovalWFTypes)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taApprovalWFTypes(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taApprovalWFTypesSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function taApprovalWFTypesInsert(ByVal Record As SIS.TA.taApprovalWFTypes) As SIS.TA.taApprovalWFTypes
      Dim _Rec As SIS.TA.taApprovalWFTypes = SIS.TA.taApprovalWFTypes.taApprovalWFTypesGetNewRecord()
      With _Rec
        .WFTypeDescription = Record.WFTypeDescription
        .RequiredDivisionHeadApproval = Record.RequiredDivisionHeadApproval
        .RequiredMDApproval = Record.RequiredMDApproval
      End With
      Return SIS.TA.taApprovalWFTypes.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.TA.taApprovalWFTypes) As SIS.TA.taApprovalWFTypes
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaApprovalWFTypesInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WFTypeDescription",SqlDbType.NVarChar,51, Iif(Record.WFTypeDescription= "" ,Convert.DBNull, Record.WFTypeDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequiredDivisionHeadApproval",SqlDbType.Bit,3, Record.RequiredDivisionHeadApproval)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequiredMDApproval",SqlDbType.Bit,3, Record.RequiredMDApproval)
          Cmd.Parameters.Add("@Return_WFTypeID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_WFTypeID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.WFTypeID = Cmd.Parameters("@Return_WFTypeID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taApprovalWFTypesUpdate(ByVal Record As SIS.TA.taApprovalWFTypes) As SIS.TA.taApprovalWFTypes
      Dim _Rec As SIS.TA.taApprovalWFTypes = SIS.TA.taApprovalWFTypes.taApprovalWFTypesGetByID(Record.WFTypeID)
      With _Rec
        .WFTypeDescription = Record.WFTypeDescription
        .RequiredDivisionHeadApproval = Record.RequiredDivisionHeadApproval
        .RequiredMDApproval = Record.RequiredMDApproval
      End With
      Return SIS.TA.taApprovalWFTypes.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.TA.taApprovalWFTypes) As SIS.TA.taApprovalWFTypes
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaApprovalWFTypesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_WFTypeID",SqlDbType.Int,11, Record.WFTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WFTypeDescription",SqlDbType.NVarChar,51, Iif(Record.WFTypeDescription= "" ,Convert.DBNull, Record.WFTypeDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequiredDivisionHeadApproval",SqlDbType.Bit,3, Record.RequiredDivisionHeadApproval)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequiredMDApproval",SqlDbType.Bit,3, Record.RequiredMDApproval)
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
    Public Shared Function taApprovalWFTypesDelete(ByVal Record As SIS.TA.taApprovalWFTypes) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaApprovalWFTypesDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_WFTypeID",SqlDbType.Int,Record.WFTypeID.ToString.Length, Record.WFTypeID)
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
'    Autocomplete Method
    Public Shared Function SelecttaApprovalWFTypesAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaApprovalWFTypesAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.TA.taApprovalWFTypes = New SIS.TA.taApprovalWFTypes(Reader)
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results.ToArray
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _WFTypeID = Ctype(Reader("WFTypeID"),Int32)
      If Convert.IsDBNull(Reader("WFTypeDescription")) Then
        _WFTypeDescription = String.Empty
      Else
        _WFTypeDescription = Ctype(Reader("WFTypeDescription"), String)
      End If
      _RequiredDivisionHeadApproval = Ctype(Reader("RequiredDivisionHeadApproval"),Boolean)
      _RequiredMDApproval = Ctype(Reader("RequiredMDApproval"),Boolean)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
