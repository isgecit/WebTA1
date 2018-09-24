Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.COST
  <DataObject()> _
  Partial Public Class costQProjects
    Private Shared _RecordCount As Integer
    Private _ProjectID As String = ""
    Private _Description As String = ""
    Private _FinYear As Int32 = 0
    Private _Quarter As Int32 = 0
    Private _ProjectTypeID As String = ""
    Private _WorkOrderTypeID As String = ""
    Private _DivisionID As String = ""
    Private _CurrencyID As String = ""
    Private _CFforPOV As Decimal = 0
    Private _ProjectOrderValue As Decimal = 0
    Private _ProjectCost As Decimal = 0
    Private _MarginCurrentYear As Decimal = 0
    Private _WarrantyPercentage As Decimal = 0
    Private _ProjectOrderValueINR As Decimal = 0
    Private _MarginCurrentYearINR As Decimal = 0
    Private _ProjectCostINR As Decimal = 0
    Private _BusinessPartnerID As String = ""
    Private _COST_Divisions1_DivisionName As String = ""
    Private _COST_FinYear2_Descpription As String = ""
    Private _COST_ProjectTypes3_ProjectTypeDescription As String = ""
    Private _COST_Quarters4_Description As String = ""
    Private _COST_WorkOrderTypes5_WorkOrderTypeDescription As String = ""
    Private _IDM_Projects6_Description As String = ""
    Private _TA_Currencies7_CurrencyName As String = ""
    Private _FK_COST_Projects_DivisionID As SIS.COST.costDivisions = Nothing
    Private _FK_COST_Projects_FinYear As SIS.COST.costFinYear = Nothing
    Private _FK_COST_Projects_ProjectTypeID As SIS.COST.costProjectTypes = Nothing
    Private _FK_COST_Projects_Quarter As SIS.COST.costQuarters = Nothing
    Private _FK_COST_Projects_WorkOrderTypeID As SIS.COST.costWorkOrderTypes = Nothing
    Private _FK_COST_Projects_ProjectID As SIS.COST.costProjects = Nothing
    Private _FK_COST_Projects_CurrencyID As SIS.TA.taCurrencies = Nothing
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
    Public Property WorkOrderTypeID() As String
      Get
        Return _WorkOrderTypeID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _WorkOrderTypeID = ""
         Else
           _WorkOrderTypeID = value
         End If
      End Set
    End Property
    Public Property DivisionID() As String
      Get
        Return _DivisionID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DivisionID = ""
         Else
           _DivisionID = value
         End If
      End Set
    End Property
    Public Property CurrencyID() As String
      Get
        Return _CurrencyID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CurrencyID = ""
         Else
           _CurrencyID = value
         End If
      End Set
    End Property
    Public Property CFforPOV() As Decimal
      Get
        Return _CFforPOV
      End Get
      Set(ByVal value As Decimal)
        _CFforPOV = value
      End Set
    End Property
    Public Property ProjectOrderValue() As Decimal
      Get
        Return _ProjectOrderValue
      End Get
      Set(ByVal value As Decimal)
        _ProjectOrderValue = value
      End Set
    End Property
    Public Property ProjectCost() As Decimal
      Get
        Return _ProjectCost
      End Get
      Set(ByVal value As Decimal)
        _ProjectCost = value
      End Set
    End Property
    Public Property MarginCurrentYear() As Decimal
      Get
        Return _MarginCurrentYear
      End Get
      Set(ByVal value As Decimal)
        _MarginCurrentYear = value
      End Set
    End Property
    Public Property WarrantyPercentage() As Decimal
      Get
        Return _WarrantyPercentage
      End Get
      Set(ByVal value As Decimal)
        _WarrantyPercentage = value
      End Set
    End Property
    Public Property ProjectOrderValueINR() As Decimal
      Get
        Return _ProjectOrderValueINR
      End Get
      Set(ByVal value As Decimal)
        _ProjectOrderValueINR = value
      End Set
    End Property
    Public Property MarginCurrentYearINR() As Decimal
      Get
        Return _MarginCurrentYearINR
      End Get
      Set(ByVal value As Decimal)
        _MarginCurrentYearINR = value
      End Set
    End Property
    Public Property ProjectCostINR() As Decimal
      Get
        Return _ProjectCostINR
      End Get
      Set(ByVal value As Decimal)
        _ProjectCostINR = value
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
    Public Property COST_Divisions1_DivisionName() As String
      Get
        Return _COST_Divisions1_DivisionName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _COST_Divisions1_DivisionName = ""
         Else
           _COST_Divisions1_DivisionName = value
         End If
      End Set
    End Property
    Public Property COST_FinYear2_Descpription() As String
      Get
        Return _COST_FinYear2_Descpription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _COST_FinYear2_Descpription = ""
         Else
           _COST_FinYear2_Descpription = value
         End If
      End Set
    End Property
    Public Property COST_ProjectTypes3_ProjectTypeDescription() As String
      Get
        Return _COST_ProjectTypes3_ProjectTypeDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _COST_ProjectTypes3_ProjectTypeDescription = ""
         Else
           _COST_ProjectTypes3_ProjectTypeDescription = value
         End If
      End Set
    End Property
    Public Property COST_Quarters4_Description() As String
      Get
        Return _COST_Quarters4_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _COST_Quarters4_Description = ""
         Else
           _COST_Quarters4_Description = value
         End If
      End Set
    End Property
    Public Property COST_WorkOrderTypes5_WorkOrderTypeDescription() As String
      Get
        Return _COST_WorkOrderTypes5_WorkOrderTypeDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _COST_WorkOrderTypes5_WorkOrderTypeDescription = ""
         Else
           _COST_WorkOrderTypes5_WorkOrderTypeDescription = value
         End If
      End Set
    End Property
    Public Property IDM_Projects6_Description() As String
      Get
        Return _IDM_Projects6_Description
      End Get
      Set(ByVal value As String)
        _IDM_Projects6_Description = value
      End Set
    End Property
    Public Property TA_Currencies7_CurrencyName() As String
      Get
        Return _TA_Currencies7_CurrencyName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_Currencies7_CurrencyName = ""
         Else
           _TA_Currencies7_CurrencyName = value
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
        Return _ProjectID & "|" & _FinYear & "|" & _Quarter
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
    Public Class PKcostQProjects
      Private _ProjectID As String = ""
      Private _FinYear As Int32 = 0
      Private _Quarter As Int32 = 0
      Public Property ProjectID() As String
        Get
          Return _ProjectID
        End Get
        Set(ByVal value As String)
          _ProjectID = value
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
    Public ReadOnly Property FK_COST_Projects_DivisionID() As SIS.COST.costDivisions
      Get
        If _FK_COST_Projects_DivisionID Is Nothing Then
          _FK_COST_Projects_DivisionID = SIS.COST.costDivisions.costDivisionsGetByID(_DivisionID)
        End If
        Return _FK_COST_Projects_DivisionID
      End Get
    End Property
    Public ReadOnly Property FK_COST_Projects_FinYear() As SIS.COST.costFinYear
      Get
        If _FK_COST_Projects_FinYear Is Nothing Then
          _FK_COST_Projects_FinYear = SIS.COST.costFinYear.costFinYearGetByID(_FinYear)
        End If
        Return _FK_COST_Projects_FinYear
      End Get
    End Property
    Public ReadOnly Property FK_COST_Projects_ProjectTypeID() As SIS.COST.costProjectTypes
      Get
        If _FK_COST_Projects_ProjectTypeID Is Nothing Then
          _FK_COST_Projects_ProjectTypeID = SIS.COST.costProjectTypes.costProjectTypesGetByID(_ProjectTypeID)
        End If
        Return _FK_COST_Projects_ProjectTypeID
      End Get
    End Property
    Public ReadOnly Property FK_COST_Projects_Quarter() As SIS.COST.costQuarters
      Get
        If _FK_COST_Projects_Quarter Is Nothing Then
          _FK_COST_Projects_Quarter = SIS.COST.costQuarters.costQuartersGetByID(_Quarter)
        End If
        Return _FK_COST_Projects_Quarter
      End Get
    End Property
    Public ReadOnly Property FK_COST_Projects_WorkOrderTypeID() As SIS.COST.costWorkOrderTypes
      Get
        If _FK_COST_Projects_WorkOrderTypeID Is Nothing Then
          _FK_COST_Projects_WorkOrderTypeID = SIS.COST.costWorkOrderTypes.costWorkOrderTypesGetByID(_WorkOrderTypeID)
        End If
        Return _FK_COST_Projects_WorkOrderTypeID
      End Get
    End Property
    Public ReadOnly Property FK_COST_Projects_ProjectID() As SIS.COST.costProjects
      Get
        If _FK_COST_Projects_ProjectID Is Nothing Then
          _FK_COST_Projects_ProjectID = SIS.COST.costProjects.costProjectsGetByID(_ProjectID)
        End If
        Return _FK_COST_Projects_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_COST_Projects_CurrencyID() As SIS.TA.taCurrencies
      Get
        If _FK_COST_Projects_CurrencyID Is Nothing Then
          _FK_COST_Projects_CurrencyID = SIS.TA.taCurrencies.taCurrenciesGetByID(_CurrencyID)
        End If
        Return _FK_COST_Projects_CurrencyID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costQProjectsGetNewRecord() As SIS.COST.costQProjects
      Return New SIS.COST.costQProjects()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costQProjectsGetByID(ByVal ProjectID As String, ByVal FinYear As Int32, ByVal Quarter As Int32) As SIS.COST.costQProjects
      Dim Results As SIS.COST.costQProjects = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostQProjectsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,ProjectID.ToString.Length, ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,FinYear.ToString.Length, FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quarter",SqlDbType.Int,Quarter.ToString.Length, Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.COST.costQProjects(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costQProjectsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String) As List(Of SIS.COST.costQProjects)
      Dim Results As List(Of SIS.COST.costQProjects) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spcostQProjectsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spcostQProjectsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.COST.costQProjects)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.COST.costQProjects(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function costQProjectsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costQProjectsGetByID(ByVal ProjectID As String, ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal Filter_ProjectID As String) As SIS.COST.costQProjects
      Return costQProjectsGetByID(ProjectID, FinYear, Quarter)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function costQProjectsInsert(ByVal Record As SIS.COST.costQProjects) As SIS.COST.costQProjects
      Dim _Rec As SIS.COST.costQProjects = SIS.COST.costQProjects.costQProjectsGetNewRecord()
      With _Rec
        .ProjectID = Record.ProjectID
        .Description = Record.Description
        .FinYear = Record.FinYear
        .Quarter = Record.Quarter
        .ProjectTypeID = Record.ProjectTypeID
        .WorkOrderTypeID = Record.WorkOrderTypeID
        .DivisionID = Record.DivisionID
        .CurrencyID = Record.CurrencyID
        .CFforPOV = Record.CFforPOV
        .ProjectOrderValue = Record.ProjectOrderValue
        .ProjectCost = Record.ProjectCost
        .MarginCurrentYear = Record.MarginCurrentYear
        .WarrantyPercentage = Record.WarrantyPercentage
        .ProjectOrderValueINR = Record.ProjectOrderValueINR
        .MarginCurrentYearINR = Record.MarginCurrentYearINR
        .ProjectCostINR = Record.ProjectCostINR
        .BusinessPartnerID = Record.BusinessPartnerID
      End With
      Return SIS.COST.costQProjects.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.COST.costQProjects) As SIS.COST.costQProjects
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostQProjectsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,61, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quarter",SqlDbType.Int,11, Record.Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectTypeID",SqlDbType.NVarChar,11, Iif(Record.ProjectTypeID= "" ,Convert.DBNull, Record.ProjectTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WorkOrderTypeID",SqlDbType.Int,11, Iif(Record.WorkOrderTypeID= "" ,Convert.DBNull, Record.WorkOrderTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.Int,11, Iif(Record.DivisionID= "" ,Convert.DBNull, Record.DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyID",SqlDbType.NVarChar,7, Iif(Record.CurrencyID= "" ,Convert.DBNull, Record.CurrencyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CFforPOV",SqlDbType.Decimal,17, Record.CFforPOV)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectOrderValue",SqlDbType.Decimal,15, Record.ProjectOrderValue)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectCost",SqlDbType.Decimal,15, Record.ProjectCost)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MarginCurrentYear",SqlDbType.Decimal,15, Record.MarginCurrentYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WarrantyPercentage",SqlDbType.Decimal,9, Record.WarrantyPercentage)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectOrderValueINR",SqlDbType.Decimal,15, Record.ProjectOrderValueINR)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MarginCurrentYearINR",SqlDbType.Decimal,15, Record.MarginCurrentYearINR)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectCostINR",SqlDbType.Decimal,15, Record.ProjectCostINR)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BusinessPartnerID",SqlDbType.NVarChar,10, Iif(Record.BusinessPartnerID= "" ,Convert.DBNull, Record.BusinessPartnerID))
          Cmd.Parameters.Add("@Return_ProjectID", SqlDbType.NVarChar, 7)
          Cmd.Parameters("@Return_ProjectID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_FinYear", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_FinYear").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_Quarter", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_Quarter").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ProjectID = Cmd.Parameters("@Return_ProjectID").Value
          Record.FinYear = Cmd.Parameters("@Return_FinYear").Value
          Record.Quarter = Cmd.Parameters("@Return_Quarter").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function costQProjectsUpdate(ByVal Record As SIS.COST.costQProjects) As SIS.COST.costQProjects
      Dim _Rec As SIS.COST.costQProjects = SIS.COST.costQProjects.costQProjectsGetByID(Record.ProjectID, Record.FinYear, Record.Quarter)
      With _Rec
        .Description = Record.Description
        .ProjectTypeID = Record.ProjectTypeID
        .WorkOrderTypeID = Record.WorkOrderTypeID
        .DivisionID = Record.DivisionID
        .CurrencyID = Record.CurrencyID
        .CFforPOV = Record.CFforPOV
        .ProjectOrderValue = Record.ProjectOrderValue
        .ProjectCost = Record.ProjectCost
        .MarginCurrentYear = Record.MarginCurrentYear
        .WarrantyPercentage = Record.WarrantyPercentage
        .ProjectOrderValueINR = Record.ProjectOrderValueINR
        .MarginCurrentYearINR = Record.MarginCurrentYearINR
        .ProjectCostINR = Record.ProjectCostINR
        .BusinessPartnerID = Record.BusinessPartnerID
      End With
      Return SIS.COST.costQProjects.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.COST.costQProjects) As SIS.COST.costQProjects
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostQProjectsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FinYear",SqlDbType.Int,11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_Quarter",SqlDbType.Int,11, Record.Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,61, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quarter",SqlDbType.Int,11, Record.Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectTypeID",SqlDbType.NVarChar,11, Iif(Record.ProjectTypeID= "" ,Convert.DBNull, Record.ProjectTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WorkOrderTypeID",SqlDbType.Int,11, Iif(Record.WorkOrderTypeID= "" ,Convert.DBNull, Record.WorkOrderTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.Int,11, Iif(Record.DivisionID= "" ,Convert.DBNull, Record.DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyID",SqlDbType.NVarChar,7, Iif(Record.CurrencyID= "" ,Convert.DBNull, Record.CurrencyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CFforPOV",SqlDbType.Decimal,17, Record.CFforPOV)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectOrderValue",SqlDbType.Decimal,15, Record.ProjectOrderValue)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectCost",SqlDbType.Decimal,15, Record.ProjectCost)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MarginCurrentYear",SqlDbType.Decimal,15, Record.MarginCurrentYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WarrantyPercentage",SqlDbType.Decimal,9, Record.WarrantyPercentage)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectOrderValueINR",SqlDbType.Decimal,15, Record.ProjectOrderValueINR)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MarginCurrentYearINR",SqlDbType.Decimal,15, Record.MarginCurrentYearINR)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectCostINR",SqlDbType.Decimal,15, Record.ProjectCostINR)
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
    Public Shared Function costQProjectsDelete(ByVal Record As SIS.COST.costQProjects) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostQProjectsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID",SqlDbType.NVarChar,Record.ProjectID.ToString.Length, Record.ProjectID)
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
