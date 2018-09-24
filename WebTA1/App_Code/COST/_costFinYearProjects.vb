Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.COST
  <DataObject()> _
  Partial Public Class costFinYearProjects
    Private Shared _RecordCount As Integer
    Private _FinYear As Int32 = 0
    Private _Quarter As Int32 = 0
    Private _ProjectID As String = ""
    Private _Descpription As String = ""
    Private _IndividualGroup As Boolean = False
    Private _CombinedGroup As Boolean = False
    Private _IndividualGroupID As String = ""
    Private _CombinedGroupID As String = ""
    Private _Blocked As Boolean = False
    Private _BlockingRemarks As String = ""
    Private _EntryConfirmed As Boolean = False
    Private _COST_FinYear1_Descpription As String = ""
    Private _COST_Quarters2_Description As String = ""
    Private _IDM_Projects3_Description As String = ""
    Private _COST_ProjectGroupProjects4_ProjectID As String = ""
    Private _COST_ProjectGroupProjects5_ProjectID As String = ""
    Private _COST_ProjectGroups6_ProjectGroupDescription As String = ""
    Private _COST_ProjectGroups7_ProjectGroupDescription As String = ""
    Private _FK_COST_FinYearProjects_FinYear As SIS.COST.costFinYear = Nothing
    Private _FK_COST_FinYearProjects_Quarter As SIS.COST.costQuarters = Nothing
    Private _FK_COST_FinYearProjects_ProjectID As SIS.COST.costProjects = Nothing
    Private _FK_COST_FinYearProjects_IndividualGroupID As SIS.COST.costProjectGroupProjects = Nothing
    Private _FK_COST_FinYearProjects_CombinedGroupID As SIS.COST.costProjectGroupProjects = Nothing
    Private _FK_COST_FinYearProjects_IDCombinedGroup As SIS.COST.costProjectGroups = Nothing
    Private _FK_COST_FinYearProjects_IDIndividualGroup As SIS.COST.costProjectGroups = Nothing
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
    Public Property FinYear() As Int32
      Get
        Return _FinYear
      End Get
      Set(ByVal value As Int32)
        _FinYear = value
      End Set
    End Property
    Public Property Quarter() As Int32
      Get
        Return _Quarter
      End Get
      Set(ByVal value As Int32)
        _Quarter = value
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
    Public Property Descpription() As String
      Get
        Return _Descpription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Descpription = ""
         Else
           _Descpription = value
         End If
      End Set
    End Property
    Public Property IndividualGroup() As Boolean
      Get
        Return _IndividualGroup
      End Get
      Set(ByVal value As Boolean)
        _IndividualGroup = value
      End Set
    End Property
    Public Property CombinedGroup() As Boolean
      Get
        Return _CombinedGroup
      End Get
      Set(ByVal value As Boolean)
        _CombinedGroup = value
      End Set
    End Property
    Public Property IndividualGroupID() As String
      Get
        Return _IndividualGroupID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _IndividualGroupID = ""
         Else
           _IndividualGroupID = value
         End If
      End Set
    End Property
    Public Property CombinedGroupID() As String
      Get
        Return _CombinedGroupID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CombinedGroupID = ""
         Else
           _CombinedGroupID = value
         End If
      End Set
    End Property
    Public Property Blocked() As Boolean
      Get
        Return _Blocked
      End Get
      Set(ByVal value As Boolean)
        _Blocked = value
      End Set
    End Property
    Public Property BlockingRemarks() As String
      Get
        Return _BlockingRemarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _BlockingRemarks = ""
         Else
           _BlockingRemarks = value
         End If
      End Set
    End Property
    Public Property EntryConfirmed() As Boolean
      Get
        Return _EntryConfirmed
      End Get
      Set(ByVal value As Boolean)
        _EntryConfirmed = value
      End Set
    End Property
    Public Property COST_FinYear1_Descpription() As String
      Get
        Return _COST_FinYear1_Descpription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _COST_FinYear1_Descpription = ""
         Else
           _COST_FinYear1_Descpription = value
         End If
      End Set
    End Property
    Public Property COST_Quarters2_Description() As String
      Get
        Return _COST_Quarters2_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _COST_Quarters2_Description = ""
         Else
           _COST_Quarters2_Description = value
         End If
      End Set
    End Property
    Public Property IDM_Projects3_Description() As String
      Get
        Return _IDM_Projects3_Description
      End Get
      Set(ByVal value As String)
        _IDM_Projects3_Description = value
      End Set
    End Property
    Public Property COST_ProjectGroupProjects4_ProjectID() As String
      Get
        Return _COST_ProjectGroupProjects4_ProjectID
      End Get
      Set(ByVal value As String)
        _COST_ProjectGroupProjects4_ProjectID = value
      End Set
    End Property
    Public Property COST_ProjectGroupProjects5_ProjectID() As String
      Get
        Return _COST_ProjectGroupProjects5_ProjectID
      End Get
      Set(ByVal value As String)
        _COST_ProjectGroupProjects5_ProjectID = value
      End Set
    End Property
    Public Property COST_ProjectGroups6_ProjectGroupDescription() As String
      Get
        Return _COST_ProjectGroups6_ProjectGroupDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _COST_ProjectGroups6_ProjectGroupDescription = ""
         Else
           _COST_ProjectGroups6_ProjectGroupDescription = value
         End If
      End Set
    End Property
    Public Property COST_ProjectGroups7_ProjectGroupDescription() As String
      Get
        Return _COST_ProjectGroups7_ProjectGroupDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _COST_ProjectGroups7_ProjectGroupDescription = ""
         Else
           _COST_ProjectGroups7_ProjectGroupDescription = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _FinYear & "|" & _Quarter & "|" & _ProjectID
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
    Public Class PKcostFinYearProjects
      Private _FinYear As Int32 = 0
      Private _Quarter As Int32 = 0
      Private _ProjectID As String = ""
      Public Property FinYear() As Int32
        Get
          Return _FinYear
        End Get
        Set(ByVal value As Int32)
          _FinYear = value
        End Set
      End Property
      Public Property Quarter() As Int32
        Get
          Return _Quarter
        End Get
        Set(ByVal value As Int32)
          _Quarter = value
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
    End Class
    Public ReadOnly Property FK_COST_FinYearProjects_FinYear() As SIS.COST.costFinYear
      Get
        If _FK_COST_FinYearProjects_FinYear Is Nothing Then
          _FK_COST_FinYearProjects_FinYear = SIS.COST.costFinYear.costFinYearGetByID(_FinYear)
        End If
        Return _FK_COST_FinYearProjects_FinYear
      End Get
    End Property
    Public ReadOnly Property FK_COST_FinYearProjects_Quarter() As SIS.COST.costQuarters
      Get
        If _FK_COST_FinYearProjects_Quarter Is Nothing Then
          _FK_COST_FinYearProjects_Quarter = SIS.COST.costQuarters.costQuartersGetByID(_Quarter)
        End If
        Return _FK_COST_FinYearProjects_Quarter
      End Get
    End Property
    Public ReadOnly Property FK_COST_FinYearProjects_ProjectID() As SIS.COST.costProjects
      Get
        If _FK_COST_FinYearProjects_ProjectID Is Nothing Then
          _FK_COST_FinYearProjects_ProjectID = SIS.COST.costProjects.costProjectsGetByID(_ProjectID)
        End If
        Return _FK_COST_FinYearProjects_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_COST_FinYearProjects_IndividualGroupID() As SIS.COST.costProjectGroupProjects
      Get
        If _FK_COST_FinYearProjects_IndividualGroupID Is Nothing Then
          _FK_COST_FinYearProjects_IndividualGroupID = SIS.COST.costProjectGroupProjects.costProjectGroupProjectsGetByID(_IndividualGroupID, _ProjectID)
        End If
        Return _FK_COST_FinYearProjects_IndividualGroupID
      End Get
    End Property
    Public ReadOnly Property FK_COST_FinYearProjects_CombinedGroupID() As SIS.COST.costProjectGroupProjects
      Get
        If _FK_COST_FinYearProjects_CombinedGroupID Is Nothing Then
          _FK_COST_FinYearProjects_CombinedGroupID = SIS.COST.costProjectGroupProjects.costProjectGroupProjectsGetByID(_CombinedGroupID, _ProjectID)
        End If
        Return _FK_COST_FinYearProjects_CombinedGroupID
      End Get
    End Property
    Public ReadOnly Property FK_COST_FinYearProjects_IDCombinedGroup() As SIS.COST.costProjectGroups
      Get
        If _FK_COST_FinYearProjects_IDCombinedGroup Is Nothing Then
          _FK_COST_FinYearProjects_IDCombinedGroup = SIS.COST.costProjectGroups.costProjectGroupsGetByID(_CombinedGroupID)
        End If
        Return _FK_COST_FinYearProjects_IDCombinedGroup
      End Get
    End Property
    Public ReadOnly Property FK_COST_FinYearProjects_IDIndividualGroup() As SIS.COST.costProjectGroups
      Get
        If _FK_COST_FinYearProjects_IDIndividualGroup Is Nothing Then
          _FK_COST_FinYearProjects_IDIndividualGroup = SIS.COST.costProjectGroups.costProjectGroupsGetByID(_IndividualGroupID)
        End If
        Return _FK_COST_FinYearProjects_IDIndividualGroup
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costFinYearProjectsGetNewRecord() As SIS.COST.costFinYearProjects
      Return New SIS.COST.costFinYearProjects()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costFinYearProjectsGetByID(ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal ProjectID As String) As SIS.COST.costFinYearProjects
      Dim Results As SIS.COST.costFinYearProjects = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostFinYearProjectsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,FinYear.ToString.Length, FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quarter",SqlDbType.Int,Quarter.ToString.Length, Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,ProjectID.ToString.Length, ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.COST.costFinYearProjects(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costFinYearProjectsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal ProjectID As String) As List(Of SIS.COST.costFinYearProjects)
      Dim Results As List(Of SIS.COST.costFinYearProjects) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spcostFinYearProjectsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spcostFinYearProjectsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FinYear",SqlDbType.Int,10, IIf(FinYear = Nothing, 0,FinYear))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_Quarter",SqlDbType.Int,10, IIf(Quarter = Nothing, 0,Quarter))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.COST.costFinYearProjects)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.COST.costFinYearProjects(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function costFinYearProjectsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal ProjectID As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costFinYearProjectsGetByID(ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal ProjectID As String, ByVal Filter_FinYear As Int32, ByVal Filter_Quarter As Int32, ByVal Filter_ProjectID As String) As SIS.COST.costFinYearProjects
      Return costFinYearProjectsGetByID(FinYear, Quarter, ProjectID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function costFinYearProjectsInsert(ByVal Record As SIS.COST.costFinYearProjects) As SIS.COST.costFinYearProjects
      Dim _Rec As SIS.COST.costFinYearProjects = SIS.COST.costFinYearProjects.costFinYearProjectsGetNewRecord()
      With _Rec
        .FinYear = Record.FinYear
        .Quarter = Record.Quarter
        .ProjectID = Record.ProjectID
        .Descpription = Record.Descpription
        .IndividualGroup = Record.IndividualGroup
        .CombinedGroup = Record.CombinedGroup
        .IndividualGroupID = Record.IndividualGroupID
        .CombinedGroupID = Record.CombinedGroupID
        .Blocked = Record.Blocked
        .BlockingRemarks = Record.BlockingRemarks
        .EntryConfirmed = Record.EntryConfirmed
      End With
      Return SIS.COST.costFinYearProjects.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.COST.costFinYearProjects) As SIS.COST.costFinYearProjects
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostFinYearProjectsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quarter",SqlDbType.Int,11, Record.Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Descpription",SqlDbType.NVarChar,51, Iif(Record.Descpription= "" ,Convert.DBNull, Record.Descpription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndividualGroup",SqlDbType.Bit,3, Record.IndividualGroup)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CombinedGroup",SqlDbType.Bit,3, Record.CombinedGroup)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndividualGroupID",SqlDbType.Int,11, Iif(Record.IndividualGroupID= "" ,Convert.DBNull, Record.IndividualGroupID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CombinedGroupID",SqlDbType.Int,11, Iif(Record.CombinedGroupID= "" ,Convert.DBNull, Record.CombinedGroupID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Blocked",SqlDbType.Bit,3, Record.Blocked)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BlockingRemarks",SqlDbType.NVarChar,51, Iif(Record.BlockingRemarks= "" ,Convert.DBNull, Record.BlockingRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EntryConfirmed",SqlDbType.Bit,3, Record.EntryConfirmed)
          Cmd.Parameters.Add("@Return_FinYear", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_FinYear").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_Quarter", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_Quarter").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_ProjectID", SqlDbType.NVarChar, 7)
          Cmd.Parameters("@Return_ProjectID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.FinYear = Cmd.Parameters("@Return_FinYear").Value
          Record.Quarter = Cmd.Parameters("@Return_Quarter").Value
          Record.ProjectID = Cmd.Parameters("@Return_ProjectID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function costFinYearProjectsUpdate(ByVal Record As SIS.COST.costFinYearProjects) As SIS.COST.costFinYearProjects
      Dim _Rec As SIS.COST.costFinYearProjects = SIS.COST.costFinYearProjects.costFinYearProjectsGetByID(Record.FinYear, Record.Quarter, Record.ProjectID)
      With _Rec
        .Descpription = Record.Descpription
        .IndividualGroup = Record.IndividualGroup
        .CombinedGroup = Record.CombinedGroup
        .IndividualGroupID = Record.IndividualGroupID
        .CombinedGroupID = Record.CombinedGroupID
        .Blocked = Record.Blocked
        .BlockingRemarks = Record.BlockingRemarks
        .EntryConfirmed = Record.EntryConfirmed
      End With
      Return SIS.COST.costFinYearProjects.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.COST.costFinYearProjects) As SIS.COST.costFinYearProjects
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostFinYearProjectsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FinYear",SqlDbType.Int,11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_Quarter",SqlDbType.Int,11, Record.Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quarter",SqlDbType.Int,11, Record.Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Descpription",SqlDbType.NVarChar,51, Iif(Record.Descpription= "" ,Convert.DBNull, Record.Descpription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndividualGroup",SqlDbType.Bit,3, Record.IndividualGroup)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CombinedGroup",SqlDbType.Bit,3, Record.CombinedGroup)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndividualGroupID",SqlDbType.Int,11, Iif(Record.IndividualGroupID= "" ,Convert.DBNull, Record.IndividualGroupID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CombinedGroupID",SqlDbType.Int,11, Iif(Record.CombinedGroupID= "" ,Convert.DBNull, Record.CombinedGroupID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Blocked",SqlDbType.Bit,3, Record.Blocked)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BlockingRemarks",SqlDbType.NVarChar,51, Iif(Record.BlockingRemarks= "" ,Convert.DBNull, Record.BlockingRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EntryConfirmed",SqlDbType.Bit,3, Record.EntryConfirmed)
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
    Public Shared Function costFinYearProjectsDelete(ByVal Record As SIS.COST.costFinYearProjects) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostFinYearProjectsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FinYear",SqlDbType.Int,Record.FinYear.ToString.Length, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_Quarter",SqlDbType.Int,Record.Quarter.ToString.Length, Record.Quarter)
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
