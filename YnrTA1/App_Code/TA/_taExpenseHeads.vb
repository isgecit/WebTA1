Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taExpenseHeads
    Private Shared _RecordCount As Integer
    Private _ExpenseHeadID As Int32 = 0
    Private _Description As String = ""
    Private _OneTimeInTour As Boolean = False
    Private _RequiresMDApproval As Boolean = False
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
    Public Property ExpenseHeadID() As Int32
      Get
        Return _ExpenseHeadID
      End Get
      Set(ByVal value As Int32)
        _ExpenseHeadID = value
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
    Public Property OneTimeInTour() As Boolean
      Get
        Return _OneTimeInTour
      End Get
      Set(ByVal value As Boolean)
        _OneTimeInTour = value
      End Set
    End Property
    Public Property RequiresMDApproval() As Boolean
      Get
        Return _RequiresMDApproval
      End Get
      Set(ByVal value As Boolean)
        _RequiresMDApproval = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _Description.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _ExpenseHeadID
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
    Public Class PKtaExpenseHeads
      Private _ExpenseHeadID As Int32 = 0
      Public Property ExpenseHeadID() As Int32
        Get
          Return _ExpenseHeadID
        End Get
        Set(ByVal value As Int32)
          _ExpenseHeadID = value
        End Set
      End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taExpenseHeadsSelectList(ByVal OrderBy As String) As List(Of SIS.TA.taExpenseHeads)
      Dim Results As List(Of SIS.TA.taExpenseHeads) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "ExpenseHeadID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaExpenseHeadsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taExpenseHeads)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taExpenseHeads(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taExpenseHeadsGetNewRecord() As SIS.TA.taExpenseHeads
      Return New SIS.TA.taExpenseHeads()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taExpenseHeadsGetByID(ByVal ExpenseHeadID As Int32) As SIS.TA.taExpenseHeads
      Dim Results As SIS.TA.taExpenseHeads = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaExpenseHeadsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExpenseHeadID",SqlDbType.Int,ExpenseHeadID.ToString.Length, ExpenseHeadID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TA.taExpenseHeads(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taExpenseHeadsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.TA.taExpenseHeads)
      Dim Results As List(Of SIS.TA.taExpenseHeads) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "ExpenseHeadID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaExpenseHeadsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaExpenseHeadsSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taExpenseHeads)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taExpenseHeads(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taExpenseHeadsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function taExpenseHeadsInsert(ByVal Record As SIS.TA.taExpenseHeads) As SIS.TA.taExpenseHeads
      Dim _Rec As SIS.TA.taExpenseHeads = SIS.TA.taExpenseHeads.taExpenseHeadsGetNewRecord()
      With _Rec
        .Description = Record.Description
        .OneTimeInTour = Record.OneTimeInTour
        .RequiresMDApproval = Record.RequiresMDApproval
      End With
      Return SIS.TA.taExpenseHeads.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.TA.taExpenseHeads) As SIS.TA.taExpenseHeads
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaExpenseHeadsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OneTimeInTour",SqlDbType.Bit,3, Record.OneTimeInTour)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequiresMDApproval",SqlDbType.Bit,3, Record.RequiresMDApproval)
          Cmd.Parameters.Add("@Return_ExpenseHeadID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ExpenseHeadID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ExpenseHeadID = Cmd.Parameters("@Return_ExpenseHeadID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taExpenseHeadsUpdate(ByVal Record As SIS.TA.taExpenseHeads) As SIS.TA.taExpenseHeads
      Dim _Rec As SIS.TA.taExpenseHeads = SIS.TA.taExpenseHeads.taExpenseHeadsGetByID(Record.ExpenseHeadID)
      With _Rec
        .Description = Record.Description
        .OneTimeInTour = Record.OneTimeInTour
        .RequiresMDApproval = Record.RequiresMDApproval
      End With
      Return SIS.TA.taExpenseHeads.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.TA.taExpenseHeads) As SIS.TA.taExpenseHeads
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaExpenseHeadsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ExpenseHeadID",SqlDbType.Int,11, Record.ExpenseHeadID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OneTimeInTour",SqlDbType.Bit,3, Record.OneTimeInTour)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequiresMDApproval",SqlDbType.Bit,3, Record.RequiresMDApproval)
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
    Public Shared Function taExpenseHeadsDelete(ByVal Record As SIS.TA.taExpenseHeads) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaExpenseHeadsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ExpenseHeadID",SqlDbType.Int,Record.ExpenseHeadID.ToString.Length, Record.ExpenseHeadID)
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
    Public Shared Function SelecttaExpenseHeadsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaExpenseHeadsAutoCompleteList"
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
            Dim Tmp As SIS.TA.taExpenseHeads = New SIS.TA.taExpenseHeads(Reader)
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results.ToArray
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _ExpenseHeadID = Ctype(Reader("ExpenseHeadID"),Int32)
      If Convert.IsDBNull(Reader("Description")) Then
        _Description = String.Empty
      Else
        _Description = Ctype(Reader("Description"), String)
      End If
      _OneTimeInTour = Ctype(Reader("OneTimeInTour"),Boolean)
      _RequiresMDApproval = Ctype(Reader("RequiresMDApproval"),Boolean)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
