Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.COST
  <DataObject()> _
  Partial Public Class costProjectsInput
    Private Shared _RecordCount As Integer
    Private _ProjectGroupID As Int32 = 0
    Private _FinYear As Int32 = 0
    Private _Quarter As Int32 = 0
    Private _CurrencyGOV As String = ""
    Private _GroupOrderValue As String = "0.00"
    Private _CFforGOV As String = "0.00"
    Private _GroupOrderValueINR As String = "0.00"
    Private _CurrencyPR As String = ""
    Private _ProjectRevenue As String = "0.00"
    Private _ProjectMargin As String = "0.00"
    Private _ExportIncentive As String = "0.00"
    Private _CFforPR As String = "0.00"
    Private _ProjectRevenueINR As String = "0.00"
    Private _ProjectMarginINR As String = "0.00"
    Private _ExportIncentiveINR As String = "0.00"
    Private _CurrencyPRByAC As String = ""
    Private _ProjectRevenueByAC As String = "0.00"
    Private _ProjectMarginByAC As String = "0.00"
    Private _ExportIncentiveByAC As String = "0.00"
    Private _CFforPRByAC As String = "0.00"
    Private _ProjectRevenueByACINR As String = "0.00"
    Private _ProjectMarginByACINR As String = "0.00"
    Private _ExportIncentiveByACINR As String = "0.00"
    Private _CFforBalanceCalculationByAC As String = "0.00"
    Private _Remarks As String = ""
    Private _CreatedBy As String = ""
    Private _CreatedOn As String = ""
    Private _ApproverRemarks As String = ""
    Private _ApprovedBy As String = ""
    Private _ApprovedOn As String = ""
    Private _StatusID As String = ""
    Private _ReceiverRemarks As String = ""
    Private _ReceivedOn As String = ""
    Private _ReceivedBy As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _aspnet_Users2_UserFullName As String = ""
    Private _COST_FinYear3_Descpription As String = ""
    Private _COST_ProjectGroups4_ProjectGroupDescription As String = ""
    Private _COST_ProjectInputStatus5_Description As String = ""
    Private _COST_Quarters6_Description As String = ""
    Private _aspnet_Users7_UserFullName As String = ""
    Private _TA_Currencies8_CurrencyName As String = ""
    Private _TA_Currencies9_CurrencyName As String = ""
    Private _TA_Currencies10_CurrencyName As String = ""
    Private _FK_COST_ProjectsInput_CraetedBy As SIS.TA.taWebUsers = Nothing
    Private _FK_COST_ProjectsInput_ApprovedBy As SIS.TA.taWebUsers = Nothing
    Private _FK_COST_ProjectsInput_FinYear As SIS.COST.costFinYear = Nothing
    Private _FK_COST_ProjectsInput_ProjectGroupID As SIS.COST.costProjectGroups = Nothing
    Private _FK_COST_ProjectsInput_StatusID As SIS.COST.costProjectInputStatus = Nothing
    Private _FK_COST_ProjectsInput_Quarter As SIS.COST.costQuarters = Nothing
    Private _FK_COST_ProjectsInput_ReceivedBy As SIS.TA.taWebUsers = Nothing
    Private _FK_COST_ProjectsInput_CurrencyGOV As SIS.TA.taCurrencies = Nothing
    Private _FK_COST_ProjectsInput_CurrencyPR As SIS.TA.taCurrencies = Nothing
    Private _FK_COST_ProjectsInput_CurrencyPRByAC As SIS.TA.taCurrencies = Nothing
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
    Public Property CurrencyGOV() As String
      Get
        Return _CurrencyGOV
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CurrencyGOV = ""
         Else
           _CurrencyGOV = value
         End If
      End Set
    End Property
    Public Property GroupOrderValue() As String
      Get
        Return _GroupOrderValue
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _GroupOrderValue = "0.00"
         Else
           _GroupOrderValue = value
         End If
      End Set
    End Property
    Public Property CFforGOV() As String
      Get
        Return _CFforGOV
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CFforGOV = "0.00"
         Else
           _CFforGOV = value
         End If
      End Set
    End Property
    Public Property GroupOrderValueINR() As String
      Get
        Return _GroupOrderValueINR
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _GroupOrderValueINR = "0.00"
         Else
           _GroupOrderValueINR = value
         End If
      End Set
    End Property
    Public Property CurrencyPR() As String
      Get
        Return _CurrencyPR
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CurrencyPR = ""
         Else
           _CurrencyPR = value
         End If
      End Set
    End Property
    Public Property ProjectRevenue() As String
      Get
        Return _ProjectRevenue
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ProjectRevenue = "0.00"
         Else
           _ProjectRevenue = value
         End If
      End Set
    End Property
    Public Property ProjectMargin() As String
      Get
        Return _ProjectMargin
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ProjectMargin = "0.00"
         Else
           _ProjectMargin = value
         End If
      End Set
    End Property
    Public Property ExportIncentive() As String
      Get
        Return _ExportIncentive
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ExportIncentive = "0.00"
         Else
           _ExportIncentive = value
         End If
      End Set
    End Property
    Public Property CFforPR() As String
      Get
        Return _CFforPR
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CFforPR = "0.00"
         Else
           _CFforPR = value
         End If
      End Set
    End Property
    Public Property ProjectRevenueINR() As String
      Get
        Return _ProjectRevenueINR
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ProjectRevenueINR = "0.00"
         Else
           _ProjectRevenueINR = value
         End If
      End Set
    End Property
    Public Property ProjectMarginINR() As String
      Get
        Return _ProjectMarginINR
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ProjectMarginINR = "0.00"
         Else
           _ProjectMarginINR = value
         End If
      End Set
    End Property
    Public Property ExportIncentiveINR() As String
      Get
        Return _ExportIncentiveINR
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ExportIncentiveINR = "0.00"
         Else
           _ExportIncentiveINR = value
         End If
      End Set
    End Property
    Public Property CurrencyPRByAC() As String
      Get
        Return _CurrencyPRByAC
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CurrencyPRByAC = ""
         Else
           _CurrencyPRByAC = value
         End If
      End Set
    End Property
    Public Property ProjectRevenueByAC() As String
      Get
        Return _ProjectRevenueByAC
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ProjectRevenueByAC = "0.00"
         Else
           _ProjectRevenueByAC = value
         End If
      End Set
    End Property
    Public Property ProjectMarginByAC() As String
      Get
        Return _ProjectMarginByAC
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ProjectMarginByAC = "0.00"
         Else
           _ProjectMarginByAC = value
         End If
      End Set
    End Property
    Public Property ExportIncentiveByAC() As String
      Get
        Return _ExportIncentiveByAC
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ExportIncentiveByAC = "0.00"
         Else
           _ExportIncentiveByAC = value
         End If
      End Set
    End Property
    Public Property CFforPRByAC() As String
      Get
        Return _CFforPRByAC
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CFforPRByAC = "0.00"
         Else
           _CFforPRByAC = value
         End If
      End Set
    End Property
    Public Property ProjectRevenueByACINR() As String
      Get
        Return _ProjectRevenueByACINR
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ProjectRevenueByACINR = "0.00"
         Else
           _ProjectRevenueByACINR = value
         End If
      End Set
    End Property
    Public Property ProjectMarginByACINR() As String
      Get
        Return _ProjectMarginByACINR
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ProjectMarginByACINR = "0.00"
         Else
           _ProjectMarginByACINR = value
         End If
      End Set
    End Property
    Public Property ExportIncentiveByACINR() As String
      Get
        Return _ExportIncentiveByACINR
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ExportIncentiveByACINR = "0.00"
         Else
           _ExportIncentiveByACINR = value
         End If
      End Set
    End Property
    Public Property CFforBalanceCalculationByAC() As String
      Get
        Return _CFforBalanceCalculationByAC
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CFforBalanceCalculationByAC = "0.00"
         Else
           _CFforBalanceCalculationByAC = value
         End If
      End Set
    End Property
    Public Property Remarks() As String
      Get
        Return _Remarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Remarks = ""
         Else
           _Remarks = value
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
    Public Property CreatedOn() As String
      Get
        If Not _CreatedOn = String.Empty Then
          Return Convert.ToDateTime(_CreatedOn).ToString("dd/MM/yyyy")
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
    Public Property ApproverRemarks() As String
      Get
        Return _ApproverRemarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ApproverRemarks = ""
         Else
           _ApproverRemarks = value
         End If
      End Set
    End Property
    Public Property ApprovedBy() As String
      Get
        Return _ApprovedBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ApprovedBy = ""
         Else
           _ApprovedBy = value
         End If
      End Set
    End Property
    Public Property ApprovedOn() As String
      Get
        If Not _ApprovedOn = String.Empty Then
          Return Convert.ToDateTime(_ApprovedOn).ToString("dd/MM/yyyy")
        End If
        Return _ApprovedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ApprovedOn = ""
         Else
           _ApprovedOn = value
         End If
      End Set
    End Property
    Public Property StatusID() As String
      Get
        Return _StatusID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _StatusID = ""
         Else
           _StatusID = value
         End If
      End Set
    End Property
    Public Property ReceiverRemarks() As String
      Get
        Return _ReceiverRemarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ReceiverRemarks = ""
         Else
           _ReceiverRemarks = value
         End If
      End Set
    End Property
    Public Property ReceivedOn() As String
      Get
        If Not _ReceivedOn = String.Empty Then
          Return Convert.ToDateTime(_ReceivedOn).ToString("dd/MM/yyyy")
        End If
        Return _ReceivedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ReceivedOn = ""
         Else
           _ReceivedOn = value
         End If
      End Set
    End Property
    Public Property ReceivedBy() As String
      Get
        Return _ReceivedBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ReceivedBy = ""
         Else
           _ReceivedBy = value
         End If
      End Set
    End Property
    Public Property aspnet_Users1_UserFullName() As String
      Get
        Return _aspnet_Users1_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users1_UserFullName = value
      End Set
    End Property
    Public Property aspnet_Users2_UserFullName() As String
      Get
        Return _aspnet_Users2_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users2_UserFullName = value
      End Set
    End Property
    Public Property COST_FinYear3_Descpription() As String
      Get
        Return _COST_FinYear3_Descpription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _COST_FinYear3_Descpription = ""
         Else
           _COST_FinYear3_Descpription = value
         End If
      End Set
    End Property
    Public Property COST_ProjectGroups4_ProjectGroupDescription() As String
      Get
        Return _COST_ProjectGroups4_ProjectGroupDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _COST_ProjectGroups4_ProjectGroupDescription = ""
         Else
           _COST_ProjectGroups4_ProjectGroupDescription = value
         End If
      End Set
    End Property
    Public Property COST_ProjectInputStatus5_Description() As String
      Get
        Return _COST_ProjectInputStatus5_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _COST_ProjectInputStatus5_Description = ""
         Else
           _COST_ProjectInputStatus5_Description = value
         End If
      End Set
    End Property
    Public Property COST_Quarters6_Description() As String
      Get
        Return _COST_Quarters6_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _COST_Quarters6_Description = ""
         Else
           _COST_Quarters6_Description = value
         End If
      End Set
    End Property
    Public Property aspnet_Users7_UserFullName() As String
      Get
        Return _aspnet_Users7_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users7_UserFullName = value
      End Set
    End Property
    Public Property TA_Currencies8_CurrencyName() As String
      Get
        Return _TA_Currencies8_CurrencyName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_Currencies8_CurrencyName = ""
         Else
           _TA_Currencies8_CurrencyName = value
         End If
      End Set
    End Property
    Public Property TA_Currencies9_CurrencyName() As String
      Get
        Return _TA_Currencies9_CurrencyName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_Currencies9_CurrencyName = ""
         Else
           _TA_Currencies9_CurrencyName = value
         End If
      End Set
    End Property
    Public Property TA_Currencies10_CurrencyName() As String
      Get
        Return _TA_Currencies10_CurrencyName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_Currencies10_CurrencyName = ""
         Else
           _TA_Currencies10_CurrencyName = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _GroupOrderValueINR.ToString.PadRight(14, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _ProjectGroupID & "|" & _FinYear & "|" & _Quarter
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
    Public Class PKcostProjectsInput
      Private _ProjectGroupID As Int32 = 0
      Private _FinYear As Int32 = 0
      Private _Quarter As Int32 = 0
      Public Property ProjectGroupID() As Int32
        Get
          Return _ProjectGroupID
        End Get
        Set(ByVal value As Int32)
          _ProjectGroupID = value
        End Set
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
    End Class
    Public ReadOnly Property FK_COST_ProjectsInput_CraetedBy() As SIS.TA.taWebUsers
      Get
        If _FK_COST_ProjectsInput_CraetedBy Is Nothing Then
          _FK_COST_ProjectsInput_CraetedBy = SIS.TA.taWebUsers.taWebUsersGetByID(_CreatedBy)
        End If
        Return _FK_COST_ProjectsInput_CraetedBy
      End Get
    End Property
    Public ReadOnly Property FK_COST_ProjectsInput_ApprovedBy() As SIS.TA.taWebUsers
      Get
        If _FK_COST_ProjectsInput_ApprovedBy Is Nothing Then
          _FK_COST_ProjectsInput_ApprovedBy = SIS.TA.taWebUsers.taWebUsersGetByID(_ApprovedBy)
        End If
        Return _FK_COST_ProjectsInput_ApprovedBy
      End Get
    End Property
    Public ReadOnly Property FK_COST_ProjectsInput_FinYear() As SIS.COST.costFinYear
      Get
        If _FK_COST_ProjectsInput_FinYear Is Nothing Then
          _FK_COST_ProjectsInput_FinYear = SIS.COST.costFinYear.costFinYearGetByID(_FinYear)
        End If
        Return _FK_COST_ProjectsInput_FinYear
      End Get
    End Property
    Public ReadOnly Property FK_COST_ProjectsInput_ProjectGroupID() As SIS.COST.costProjectGroups
      Get
        If _FK_COST_ProjectsInput_ProjectGroupID Is Nothing Then
          _FK_COST_ProjectsInput_ProjectGroupID = SIS.COST.costProjectGroups.costProjectGroupsGetByID(_ProjectGroupID)
        End If
        Return _FK_COST_ProjectsInput_ProjectGroupID
      End Get
    End Property
    Public ReadOnly Property FK_COST_ProjectsInput_StatusID() As SIS.COST.costProjectInputStatus
      Get
        If _FK_COST_ProjectsInput_StatusID Is Nothing Then
          _FK_COST_ProjectsInput_StatusID = SIS.COST.costProjectInputStatus.costProjectInputStatusGetByID(_StatusID)
        End If
        Return _FK_COST_ProjectsInput_StatusID
      End Get
    End Property
    Public ReadOnly Property FK_COST_ProjectsInput_Quarter() As SIS.COST.costQuarters
      Get
        If _FK_COST_ProjectsInput_Quarter Is Nothing Then
          _FK_COST_ProjectsInput_Quarter = SIS.COST.costQuarters.costQuartersGetByID(_Quarter)
        End If
        Return _FK_COST_ProjectsInput_Quarter
      End Get
    End Property
    Public ReadOnly Property FK_COST_ProjectsInput_ReceivedBy() As SIS.TA.taWebUsers
      Get
        If _FK_COST_ProjectsInput_ReceivedBy Is Nothing Then
          _FK_COST_ProjectsInput_ReceivedBy = SIS.TA.taWebUsers.taWebUsersGetByID(_ReceivedBy)
        End If
        Return _FK_COST_ProjectsInput_ReceivedBy
      End Get
    End Property
    Public ReadOnly Property FK_COST_ProjectsInput_CurrencyGOV() As SIS.TA.taCurrencies
      Get
        If _FK_COST_ProjectsInput_CurrencyGOV Is Nothing Then
          _FK_COST_ProjectsInput_CurrencyGOV = SIS.TA.taCurrencies.taCurrenciesGetByID(_CurrencyGOV)
        End If
        Return _FK_COST_ProjectsInput_CurrencyGOV
      End Get
    End Property
    Public ReadOnly Property FK_COST_ProjectsInput_CurrencyPR() As SIS.TA.taCurrencies
      Get
        If _FK_COST_ProjectsInput_CurrencyPR Is Nothing Then
          _FK_COST_ProjectsInput_CurrencyPR = SIS.TA.taCurrencies.taCurrenciesGetByID(_CurrencyPR)
        End If
        Return _FK_COST_ProjectsInput_CurrencyPR
      End Get
    End Property
    Public ReadOnly Property FK_COST_ProjectsInput_CurrencyPRByAC() As SIS.TA.taCurrencies
      Get
        If _FK_COST_ProjectsInput_CurrencyPRByAC Is Nothing Then
          _FK_COST_ProjectsInput_CurrencyPRByAC = SIS.TA.taCurrencies.taCurrenciesGetByID(_CurrencyPRByAC)
        End If
        Return _FK_COST_ProjectsInput_CurrencyPRByAC
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costProjectsInputSelectList(ByVal OrderBy As String) As List(Of SIS.COST.costProjectsInput)
      Dim Results As List(Of SIS.COST.costProjectsInput) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostProjectsInputSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.COST.costProjectsInput)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.COST.costProjectsInput(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costProjectsInputGetNewRecord() As SIS.COST.costProjectsInput
      Return New SIS.COST.costProjectsInput()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costProjectsInputGetByID(ByVal ProjectGroupID As Int32, ByVal FinYear As Int32, ByVal Quarter As Int32) As SIS.COST.costProjectsInput
      Dim Results As SIS.COST.costProjectsInput = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostProjectsInputSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectGroupID",SqlDbType.Int,ProjectGroupID.ToString.Length, ProjectGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,FinYear.ToString.Length, FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quarter",SqlDbType.Int,Quarter.ToString.Length, Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.COST.costProjectsInput(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costProjectsInputSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectGroupID As Int32, ByVal FinYear As Int32, ByVal Quarter As Int32) As List(Of SIS.COST.costProjectsInput)
      Dim Results As List(Of SIS.COST.costProjectsInput) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spcostProjectsInputSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spcostProjectsInputSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectGroupID",SqlDbType.Int,10, IIf(ProjectGroupID = Nothing, 0,ProjectGroupID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FinYear",SqlDbType.Int,10, IIf(FinYear = Nothing, 0,FinYear))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_Quarter",SqlDbType.Int,10, IIf(Quarter = Nothing, 0,Quarter))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.COST.costProjectsInput)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.COST.costProjectsInput(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function costProjectsInputSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectGroupID As Int32, ByVal FinYear As Int32, ByVal Quarter As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costProjectsInputGetByID(ByVal ProjectGroupID As Int32, ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal Filter_ProjectGroupID As Int32, ByVal Filter_FinYear As Int32, ByVal Filter_Quarter As Int32) As SIS.COST.costProjectsInput
      Return costProjectsInputGetByID(ProjectGroupID, FinYear, Quarter)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function costProjectsInputInsert(ByVal Record As SIS.COST.costProjectsInput) As SIS.COST.costProjectsInput
      Dim _Rec As SIS.COST.costProjectsInput = SIS.COST.costProjectsInput.costProjectsInputGetNewRecord()
      With _Rec
        .ProjectGroupID = Record.ProjectGroupID
        .FinYear = Record.FinYear
        .Quarter = Record.Quarter
        .CurrencyGOV = Record.CurrencyGOV
        .GroupOrderValue = Record.GroupOrderValue
        .CFforGOV = Record.CFforGOV
        .GroupOrderValueINR = Record.GroupOrderValueINR
        .CurrencyPR = Record.CurrencyPR
        .ProjectRevenue = Record.ProjectRevenue
        .ProjectMargin = Record.ProjectMargin
        .ExportIncentive = Record.ExportIncentive
        .CFforPR = Record.CFforPR
        .ProjectRevenueINR = Record.ProjectRevenueINR
        .ProjectMarginINR = Record.ProjectMarginINR
        .ExportIncentiveINR = Record.ExportIncentiveINR
        .CurrencyPRByAC = Record.CurrencyPRByAC
        .ProjectRevenueByAC = Record.ProjectRevenueByAC
        .ProjectMarginByAC = Record.ProjectMarginByAC
        .ExportIncentiveByAC = Record.ExportIncentiveByAC
        .CFforPRByAC = Record.CFforPRByAC
        .ProjectRevenueByACINR = Record.ProjectRevenueByACINR
        .ProjectMarginByACINR = Record.ProjectMarginByACINR
        .ExportIncentiveByACINR = Record.ExportIncentiveByACINR
        .Remarks = Record.Remarks
        .CreatedBy =  Global.System.Web.HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
        .StatusID = 1
      End With
      Return SIS.COST.costProjectsInput.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.COST.costProjectsInput) As SIS.COST.costProjectsInput
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostProjectsInputInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectGroupID",SqlDbType.Int,11, Record.ProjectGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quarter",SqlDbType.Int,11, Record.Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyGOV",SqlDbType.NVarChar,7, Iif(Record.CurrencyGOV= "" ,Convert.DBNull, Record.CurrencyGOV))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GroupOrderValue",SqlDbType.Decimal,17, Iif(Record.GroupOrderValue= "" ,Convert.DBNull, Record.GroupOrderValue))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CFforGOV",SqlDbType.Decimal,11, Iif(Record.CFforGOV= "" ,Convert.DBNull, Record.CFforGOV))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GroupOrderValueINR",SqlDbType.Decimal,17, Iif(Record.GroupOrderValueINR= "" ,Convert.DBNull, Record.GroupOrderValueINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyPR",SqlDbType.NVarChar,7, Iif(Record.CurrencyPR= "" ,Convert.DBNull, Record.CurrencyPR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectRevenue",SqlDbType.Decimal,17, Iif(Record.ProjectRevenue= "" ,Convert.DBNull, Record.ProjectRevenue))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectMargin",SqlDbType.Decimal,17, Iif(Record.ProjectMargin= "" ,Convert.DBNull, Record.ProjectMargin))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExportIncentive",SqlDbType.Decimal,17, Iif(Record.ExportIncentive= "" ,Convert.DBNull, Record.ExportIncentive))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CFforPR",SqlDbType.Decimal,11, Iif(Record.CFforPR= "" ,Convert.DBNull, Record.CFforPR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectRevenueINR",SqlDbType.Decimal,17, Iif(Record.ProjectRevenueINR= "" ,Convert.DBNull, Record.ProjectRevenueINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectMarginINR",SqlDbType.Decimal,17, Iif(Record.ProjectMarginINR= "" ,Convert.DBNull, Record.ProjectMarginINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExportIncentiveINR",SqlDbType.Decimal,17, Iif(Record.ExportIncentiveINR= "" ,Convert.DBNull, Record.ExportIncentiveINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyPRByAC",SqlDbType.NVarChar,7, Iif(Record.CurrencyPRByAC= "" ,Convert.DBNull, Record.CurrencyPRByAC))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectRevenueByAC",SqlDbType.Decimal,17, Iif(Record.ProjectRevenueByAC= "" ,Convert.DBNull, Record.ProjectRevenueByAC))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectMarginByAC",SqlDbType.Decimal,17, Iif(Record.ProjectMarginByAC= "" ,Convert.DBNull, Record.ProjectMarginByAC))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExportIncentiveByAC",SqlDbType.Decimal,17, Iif(Record.ExportIncentiveByAC= "" ,Convert.DBNull, Record.ExportIncentiveByAC))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CFforPRByAC",SqlDbType.Decimal,11, Iif(Record.CFforPRByAC= "" ,Convert.DBNull, Record.CFforPRByAC))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectRevenueByACINR",SqlDbType.Decimal,17, Iif(Record.ProjectRevenueByACINR= "" ,Convert.DBNull, Record.ProjectRevenueByACINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectMarginByACINR",SqlDbType.Decimal,17, Iif(Record.ProjectMarginByACINR= "" ,Convert.DBNull, Record.ProjectMarginByACINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExportIncentiveByACINR",SqlDbType.Decimal,17, Iif(Record.ExportIncentiveByACINR= "" ,Convert.DBNull, Record.ExportIncentiveByACINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CFforBalanceCalculationByAC",SqlDbType.Decimal,11, Iif(Record.CFforBalanceCalculationByAC= "" ,Convert.DBNull, Record.CFforBalanceCalculationByAC))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,251, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApproverRemarks",SqlDbType.NVarChar,251, Iif(Record.ApproverRemarks= "" ,Convert.DBNull, Record.ApproverRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy",SqlDbType.NVarChar,9, Iif(Record.ApprovedBy= "" ,Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedOn",SqlDbType.DateTime,21, Iif(Record.ApprovedOn= "" ,Convert.DBNull, Record.ApprovedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiverRemarks",SqlDbType.NVarChar,251, Iif(Record.ReceiverRemarks= "" ,Convert.DBNull, Record.ReceiverRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedOn",SqlDbType.DateTime,21, Iif(Record.ReceivedOn= "" ,Convert.DBNull, Record.ReceivedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedBy",SqlDbType.NVarChar,9, Iif(Record.ReceivedBy= "" ,Convert.DBNull, Record.ReceivedBy))
          Cmd.Parameters.Add("@Return_ProjectGroupID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ProjectGroupID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_FinYear", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_FinYear").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_Quarter", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_Quarter").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ProjectGroupID = Cmd.Parameters("@Return_ProjectGroupID").Value
          Record.FinYear = Cmd.Parameters("@Return_FinYear").Value
          Record.Quarter = Cmd.Parameters("@Return_Quarter").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function costProjectsInputUpdate(ByVal Record As SIS.COST.costProjectsInput) As SIS.COST.costProjectsInput
      Dim _Rec As SIS.COST.costProjectsInput = SIS.COST.costProjectsInput.costProjectsInputGetByID(Record.ProjectGroupID, Record.FinYear, Record.Quarter)
      With _Rec
        .CurrencyGOV = Record.CurrencyGOV
        .GroupOrderValue = Record.GroupOrderValue
        .CFforGOV = Record.CFforGOV
        .GroupOrderValueINR = Record.GroupOrderValueINR
        .CurrencyPR = Record.CurrencyPR
        .ProjectRevenue = Record.ProjectRevenue
        .ProjectMargin = Record.ProjectMargin
        .ExportIncentive = Record.ExportIncentive
        .CFforPR = Record.CFforPR
        .ProjectRevenueINR = Record.ProjectRevenueINR
        .ProjectMarginINR = Record.ProjectMarginINR
        .ExportIncentiveINR = Record.ExportIncentiveINR
        .CurrencyPRByAC = Record.CurrencyPRByAC
        .ProjectRevenueByAC = Record.ProjectRevenueByAC
        .ProjectMarginByAC = Record.ProjectMarginByAC
        .ExportIncentiveByAC = Record.ExportIncentiveByAC
        .CFforPRByAC = Record.CFforPRByAC
        .ProjectRevenueByACINR = Record.ProjectRevenueByACINR
        .ProjectMarginByACINR = Record.ProjectMarginByACINR
        .ExportIncentiveByACINR = Record.ExportIncentiveByACINR
        .Remarks = Record.Remarks
        .StatusID = Record.StatusID
      End With
      Return SIS.COST.costProjectsInput.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.COST.costProjectsInput) As SIS.COST.costProjectsInput
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostProjectsInputUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectGroupID",SqlDbType.Int,11, Record.ProjectGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FinYear",SqlDbType.Int,11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_Quarter",SqlDbType.Int,11, Record.Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectGroupID",SqlDbType.Int,11, Record.ProjectGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quarter",SqlDbType.Int,11, Record.Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyGOV",SqlDbType.NVarChar,7, Iif(Record.CurrencyGOV= "" ,Convert.DBNull, Record.CurrencyGOV))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GroupOrderValue",SqlDbType.Decimal,17, Iif(Record.GroupOrderValue= "" ,Convert.DBNull, Record.GroupOrderValue))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CFforGOV",SqlDbType.Decimal,11, Iif(Record.CFforGOV= "" ,Convert.DBNull, Record.CFforGOV))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GroupOrderValueINR",SqlDbType.Decimal,17, Iif(Record.GroupOrderValueINR= "" ,Convert.DBNull, Record.GroupOrderValueINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyPR",SqlDbType.NVarChar,7, Iif(Record.CurrencyPR= "" ,Convert.DBNull, Record.CurrencyPR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectRevenue",SqlDbType.Decimal,17, Iif(Record.ProjectRevenue= "" ,Convert.DBNull, Record.ProjectRevenue))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectMargin",SqlDbType.Decimal,17, Iif(Record.ProjectMargin= "" ,Convert.DBNull, Record.ProjectMargin))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExportIncentive",SqlDbType.Decimal,17, Iif(Record.ExportIncentive= "" ,Convert.DBNull, Record.ExportIncentive))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CFforPR",SqlDbType.Decimal,11, Iif(Record.CFforPR= "" ,Convert.DBNull, Record.CFforPR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectRevenueINR",SqlDbType.Decimal,17, Iif(Record.ProjectRevenueINR= "" ,Convert.DBNull, Record.ProjectRevenueINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectMarginINR",SqlDbType.Decimal,17, Iif(Record.ProjectMarginINR= "" ,Convert.DBNull, Record.ProjectMarginINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExportIncentiveINR",SqlDbType.Decimal,17, Iif(Record.ExportIncentiveINR= "" ,Convert.DBNull, Record.ExportIncentiveINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyPRByAC",SqlDbType.NVarChar,7, Iif(Record.CurrencyPRByAC= "" ,Convert.DBNull, Record.CurrencyPRByAC))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectRevenueByAC",SqlDbType.Decimal,17, Iif(Record.ProjectRevenueByAC= "" ,Convert.DBNull, Record.ProjectRevenueByAC))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectMarginByAC",SqlDbType.Decimal,17, Iif(Record.ProjectMarginByAC= "" ,Convert.DBNull, Record.ProjectMarginByAC))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExportIncentiveByAC",SqlDbType.Decimal,17, Iif(Record.ExportIncentiveByAC= "" ,Convert.DBNull, Record.ExportIncentiveByAC))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CFforPRByAC",SqlDbType.Decimal,11, Iif(Record.CFforPRByAC= "" ,Convert.DBNull, Record.CFforPRByAC))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectRevenueByACINR",SqlDbType.Decimal,17, Iif(Record.ProjectRevenueByACINR= "" ,Convert.DBNull, Record.ProjectRevenueByACINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectMarginByACINR",SqlDbType.Decimal,17, Iif(Record.ProjectMarginByACINR= "" ,Convert.DBNull, Record.ProjectMarginByACINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExportIncentiveByACINR",SqlDbType.Decimal,17, Iif(Record.ExportIncentiveByACINR= "" ,Convert.DBNull, Record.ExportIncentiveByACINR))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CFforBalanceCalculationByAC",SqlDbType.Decimal,11, Iif(Record.CFforBalanceCalculationByAC= "" ,Convert.DBNull, Record.CFforBalanceCalculationByAC))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,251, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApproverRemarks",SqlDbType.NVarChar,251, Iif(Record.ApproverRemarks= "" ,Convert.DBNull, Record.ApproverRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy",SqlDbType.NVarChar,9, Iif(Record.ApprovedBy= "" ,Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedOn",SqlDbType.DateTime,21, Iif(Record.ApprovedOn= "" ,Convert.DBNull, Record.ApprovedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiverRemarks",SqlDbType.NVarChar,251, Iif(Record.ReceiverRemarks= "" ,Convert.DBNull, Record.ReceiverRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedOn",SqlDbType.DateTime,21, Iif(Record.ReceivedOn= "" ,Convert.DBNull, Record.ReceivedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedBy",SqlDbType.NVarChar,9, Iif(Record.ReceivedBy= "" ,Convert.DBNull, Record.ReceivedBy))
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
    Public Shared Function costProjectsInputDelete(ByVal Record As SIS.COST.costProjectsInput) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostProjectsInputDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectGroupID",SqlDbType.Int,Record.ProjectGroupID.ToString.Length, Record.ProjectGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FinYear",SqlDbType.Int,Record.FinYear.ToString.Length, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_Quarter",SqlDbType.Int,Record.Quarter.ToString.Length, Record.Quarter)
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
    Public Shared Function SelectcostProjectsInputAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostProjectsInputAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(14, " "),"" & "|" & "" & "|" & ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.COST.costProjectsInput = New SIS.COST.costProjectsInput(Reader)
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
