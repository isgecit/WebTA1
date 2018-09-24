Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.COST
  <DataObject()> _
  Partial Public Class costProjectGroups
    Private Shared _RecordCount As Integer
    Private _ProjectGroupID As Int32 = 0
    Private _ProjectGroupDescription As String = ""
    Private _ProjectTypeID As String = ""
    Private _COST_ProjectTypes1_ProjectTypeDescription As String = ""
    Private _FK_COST_ProjectGroups_ProjectTypeID As SIS.COST.costProjectTypes = Nothing
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
    Public Property ProjectGroupID() As Int32
      Get
        Return _ProjectGroupID
      End Get
      Set(ByVal value As Int32)
        _ProjectGroupID = value
      End Set
    End Property
    Public Property ProjectGroupDescription() As String
      Get
        Return _ProjectGroupDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ProjectGroupDescription = ""
         Else
           _ProjectGroupDescription = value
         End If
      End Set
    End Property
    Public Property ProjectTypeID() As String
      Get
        Return _ProjectTypeID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ProjectTypeID = ""
         Else
           _ProjectTypeID = value
         End If
      End Set
    End Property
    Public Property COST_ProjectTypes1_ProjectTypeDescription() As String
      Get
        Return _COST_ProjectTypes1_ProjectTypeDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _COST_ProjectTypes1_ProjectTypeDescription = ""
         Else
           _COST_ProjectTypes1_ProjectTypeDescription = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _ProjectGroupDescription.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _ProjectGroupID
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
    Public Class PKcostProjectGroups
      Private _ProjectGroupID As Int32 = 0
      Public Property ProjectGroupID() As Int32
        Get
          Return _ProjectGroupID
        End Get
        Set(ByVal value As Int32)
          _ProjectGroupID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_COST_ProjectGroups_ProjectTypeID() As SIS.COST.costProjectTypes
      Get
        If _FK_COST_ProjectGroups_ProjectTypeID Is Nothing Then
          _FK_COST_ProjectGroups_ProjectTypeID = SIS.COST.costProjectTypes.costProjectTypesGetByID(_ProjectTypeID)
        End If
        Return _FK_COST_ProjectGroups_ProjectTypeID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costProjectGroupsSelectList(ByVal OrderBy As String) As List(Of SIS.COST.costProjectGroups)
      Dim Results As List(Of SIS.COST.costProjectGroups) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostProjectGroupsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.COST.costProjectGroups)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.COST.costProjectGroups(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costProjectGroupsGetNewRecord() As SIS.COST.costProjectGroups
      Return New SIS.COST.costProjectGroups()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costProjectGroupsGetByID(ByVal ProjectGroupID As Int32) As SIS.COST.costProjectGroups
      Dim Results As SIS.COST.costProjectGroups = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostProjectGroupsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectGroupID",SqlDbType.Int,ProjectGroupID.ToString.Length, ProjectGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.COST.costProjectGroups(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costProjectGroupsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectGroupID As Int32) As List(Of SIS.COST.costProjectGroups)
      Dim Results As List(Of SIS.COST.costProjectGroups) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spcostProjectGroupsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spcostProjectGroupsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectGroupID",SqlDbType.Int,10, IIf(ProjectGroupID = Nothing, 0,ProjectGroupID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.COST.costProjectGroups)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.COST.costProjectGroups(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function costProjectGroupsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectGroupID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costProjectGroupsGetByID(ByVal ProjectGroupID As Int32, ByVal Filter_ProjectGroupID As Int32) As SIS.COST.costProjectGroups
      Return costProjectGroupsGetByID(ProjectGroupID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function costProjectGroupsInsert(ByVal Record As SIS.COST.costProjectGroups) As SIS.COST.costProjectGroups
      Dim _Rec As SIS.COST.costProjectGroups = SIS.COST.costProjectGroups.costProjectGroupsGetNewRecord()
      With _Rec
        .ProjectGroupDescription = Record.ProjectGroupDescription
        .ProjectTypeID = Record.ProjectTypeID
      End With
      Return SIS.COST.costProjectGroups.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.COST.costProjectGroups) As SIS.COST.costProjectGroups
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostProjectGroupsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectGroupDescription",SqlDbType.NVarChar,51, Iif(Record.ProjectGroupDescription= "" ,Convert.DBNull, Record.ProjectGroupDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectTypeID",SqlDbType.NVarChar,11, Iif(Record.ProjectTypeID= "" ,Convert.DBNull, Record.ProjectTypeID))
          Cmd.Parameters.Add("@Return_ProjectGroupID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ProjectGroupID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ProjectGroupID = Cmd.Parameters("@Return_ProjectGroupID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function costProjectGroupsUpdate(ByVal Record As SIS.COST.costProjectGroups) As SIS.COST.costProjectGroups
      Dim _Rec As SIS.COST.costProjectGroups = SIS.COST.costProjectGroups.costProjectGroupsGetByID(Record.ProjectGroupID)
      With _Rec
        .ProjectGroupDescription = Record.ProjectGroupDescription
        .ProjectTypeID = Record.ProjectTypeID
      End With
      Return SIS.COST.costProjectGroups.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.COST.costProjectGroups) As SIS.COST.costProjectGroups
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostProjectGroupsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectGroupID",SqlDbType.Int,11, Record.ProjectGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectGroupDescription",SqlDbType.NVarChar,51, Iif(Record.ProjectGroupDescription= "" ,Convert.DBNull, Record.ProjectGroupDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectTypeID",SqlDbType.NVarChar,11, Iif(Record.ProjectTypeID= "" ,Convert.DBNull, Record.ProjectTypeID))
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
    Public Shared Function costProjectGroupsDelete(ByVal Record As SIS.COST.costProjectGroups) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostProjectGroupsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectGroupID",SqlDbType.Int,Record.ProjectGroupID.ToString.Length, Record.ProjectGroupID)
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
    Public Shared Function SelectcostProjectGroupsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostProjectGroupsAutoCompleteList"
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
            Dim Tmp As SIS.COST.costProjectGroups = New SIS.COST.costProjectGroups(Reader)
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results.ToArray
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              Dim Found As Boolean = False
              For I As Integer = 0 To Reader.FieldCount - 1
                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                  Found = True
                  Exit For
                End If
              Next
              If Found Then
                If Convert.IsDBNull(Reader(pi.Name)) Then
                  Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                    Case "decimal"
                      CallByName(Me, pi.Name, CallType.Let, "0.00")
                    Case "bit"
                      CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                    Case Else
                      CallByName(Me, pi.Name, CallType.Let, String.Empty)
                  End Select
                Else
                  CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                End If
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
