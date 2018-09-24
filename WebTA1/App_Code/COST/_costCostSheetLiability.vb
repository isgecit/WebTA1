Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.COST
  <DataObject()>
  Partial Public Class costCostSheetLiability
    Private Shared _RecordCount As Integer
    Private _AdjustmentSerialNo As Int32 = 0
    Private _ProjectID As String = ""
    Private _GLCode As String = ""
    Private _CrAmount As String = "0.00"
    Private _DrAmount As String = "0.00"
    Private _Amount As String = "0.00"
    Private _CrFC As String = "0.00"
    Private _DrFC As String = "0.00"
    Private _NetFC As String = "0.00"
    Private _FC As String = ""
    Private _AdjustmentEntry As Boolean = False
    Private _AdjustmentCredit As Boolean = False
    Private _Quarter As Int32 = 0
    Private _FinYear As Int32 = 0
    Private _ProjectGroupID As Int32 = 0
    Private _Revision As Int32 = 0
    Private _COST_CostSheet1_Remarks As String = ""
    Private _COST_ERPGLCodes2_GLDescription As String = ""
    Private _COST_FinYear3_Descpription As String = ""
    Private _COST_ProjectGroups4_ProjectGroupDescription As String = ""
    Private _COST_Quarters5_Description As String = ""
    Private _IDM_Projects6_Description As String = ""
    Private _FK_COST_CostSheetLiability_CostSheet As SIS.COST.costCostSheet = Nothing
    Private _FK_COST_CostSheetLiability_GLCode As SIS.COST.costERPGLCodes = Nothing
    Private _FK_COST_CostSheetLiability_FinYear As SIS.COST.costFinYear = Nothing
    Private _FK_COST_CostSheetLiability_ProjectGroupID As SIS.COST.costProjectGroups = Nothing
    Private _FK_COST_CostSheetLiability_Quarter As SIS.COST.costQuarters = Nothing
    Private _FK_COST_CostSheetLiability_ProjectID As SIS.COST.costProjects = Nothing
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
    Public Property AdjustmentSerialNo() As Int32
      Get
        Return _AdjustmentSerialNo
      End Get
      Set(ByVal value As Int32)
        _AdjustmentSerialNo = value
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
    Public Property GLCode() As String
      Get
        Return _GLCode
      End Get
      Set(ByVal value As String)
        _GLCode = value
      End Set
    End Property
    Public Property CrFC() As String
      Get
        Return _CrFC
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _CrFC = "0.00"
        Else
          _CrFC = value
        End If
      End Set
    End Property
    Public Property DrFC() As String
      Get
        Return _DrFC
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _DrFC = "0.00"
        Else
          _DrFC = value
        End If
      End Set
    End Property
    Public Property NetFC() As String
      Get
        Return _NetFC
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _NetFC = "0.00"
        Else
          _NetFC = value
        End If
      End Set
    End Property
    Public Property FC As String
      Get
        Return _FC
      End Get
      Set(value As String)
        If Convert.IsDBNull(value) Then
          _FC = ""
        Else
          _FC = value
        End If
      End Set
    End Property
    Public Property CrAmount() As String
      Get
        Return _CrAmount
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _CrAmount = "0.00"
        Else
          _CrAmount = value
        End If
      End Set
    End Property
    Public Property DrAmount() As String
      Get
        Return _DrAmount
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _DrAmount = "0.00"
        Else
          _DrAmount = value
        End If
      End Set
    End Property
    Public Property Amount() As String
      Get
        Return _Amount
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _Amount = "0.00"
        Else
          _Amount = value
        End If
      End Set
    End Property
    Public Property AdjustmentEntry() As Boolean
      Get
        Return _AdjustmentEntry
      End Get
      Set(ByVal value As Boolean)
        _AdjustmentEntry = value
      End Set
    End Property
    Public Property AdjustmentCredit() As Boolean
      Get
        Return _AdjustmentCredit
      End Get
      Set(ByVal value As Boolean)
        _AdjustmentCredit = value
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
    Public Property FinYear() As Int32
      Get
        Return _FinYear
      End Get
      Set(ByVal value As Int32)
        _FinYear = value
      End Set
    End Property
    Public Property ProjectGroupID() As Int32
      Get
        Return _ProjectGroupID
      End Get
      Set(ByVal value As Int32)
        _ProjectGroupID = value
      End Set
    End Property
    Public Property Revision() As Int32
      Get
        Return _Revision
      End Get
      Set(ByVal value As Int32)
        _Revision = value
      End Set
    End Property
    Public Property COST_CostSheet1_Remarks() As String
      Get
        Return _COST_CostSheet1_Remarks
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _COST_CostSheet1_Remarks = ""
        Else
          _COST_CostSheet1_Remarks = value
        End If
      End Set
    End Property
    Public Property COST_ERPGLCodes2_GLDescription() As String
      Get
        Return _COST_ERPGLCodes2_GLDescription
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _COST_ERPGLCodes2_GLDescription = ""
        Else
          _COST_ERPGLCodes2_GLDescription = value
        End If
      End Set
    End Property
    Public Property COST_FinYear3_Descpription() As String
      Get
        Return _COST_FinYear3_Descpription
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
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
        If Convert.IsDBNull(value) Then
          _COST_ProjectGroups4_ProjectGroupDescription = ""
        Else
          _COST_ProjectGroups4_ProjectGroupDescription = value
        End If
      End Set
    End Property
    Public Property COST_Quarters5_Description() As String
      Get
        Return _COST_Quarters5_Description
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _COST_Quarters5_Description = ""
        Else
          _COST_Quarters5_Description = value
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
    Public ReadOnly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public ReadOnly Property PrimaryKey() As String
      Get
        Return _ProjectGroupID & "|" & _FinYear & "|" & _Quarter & "|" & _Revision & "|" & _ProjectID & "|" & _GLCode & "|" & _AdjustmentSerialNo & "|" & _AdjustmentCredit
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
    Public Class PKcostCostSheetLiability
      Private _ProjectGroupID As Int32 = 0
      Private _FinYear As Int32 = 0
      Private _Quarter As Int32 = 0
      Private _Revision As Int32 = 0
      Private _ProjectID As String = ""
      Private _GLCode As String = ""
      Private _AdjustmentSerialNo As Int32 = 0
      Private _AdjustmentCredit As Boolean = False
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
      Public Property Revision() As Int32
        Get
          Return _Revision
        End Get
        Set(ByVal value As Int32)
          _Revision = value
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
      Public Property GLCode() As String
        Get
          Return _GLCode
        End Get
        Set(ByVal value As String)
          _GLCode = value
        End Set
      End Property
      Public Property AdjustmentSerialNo() As Int32
        Get
          Return _AdjustmentSerialNo
        End Get
        Set(ByVal value As Int32)
          _AdjustmentSerialNo = value
        End Set
      End Property
      Public Property AdjustmentCredit() As Boolean
        Get
          Return _AdjustmentCredit
        End Get
        Set(ByVal value As Boolean)
          _AdjustmentCredit = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_COST_CostSheetLiability_CostSheet() As SIS.COST.costCostSheet
      Get
        If _FK_COST_CostSheetLiability_CostSheet Is Nothing Then
          _FK_COST_CostSheetLiability_CostSheet = SIS.COST.costCostSheet.costCostSheetGetByID(_ProjectGroupID, _FinYear, _Quarter, _Revision)
        End If
        Return _FK_COST_CostSheetLiability_CostSheet
      End Get
    End Property
    Public ReadOnly Property FK_COST_CostSheetLiability_GLCode() As SIS.COST.costERPGLCodes
      Get
        If _FK_COST_CostSheetLiability_GLCode Is Nothing Then
          _FK_COST_CostSheetLiability_GLCode = SIS.COST.costERPGLCodes.costERPGLCodesGetByID(_GLCode)
        End If
        Return _FK_COST_CostSheetLiability_GLCode
      End Get
    End Property
    Public ReadOnly Property FK_COST_CostSheetLiability_FinYear() As SIS.COST.costFinYear
      Get
        If _FK_COST_CostSheetLiability_FinYear Is Nothing Then
          _FK_COST_CostSheetLiability_FinYear = SIS.COST.costFinYear.costFinYearGetByID(_FinYear)
        End If
        Return _FK_COST_CostSheetLiability_FinYear
      End Get
    End Property
    Public ReadOnly Property FK_COST_CostSheetLiability_ProjectGroupID() As SIS.COST.costProjectGroups
      Get
        If _FK_COST_CostSheetLiability_ProjectGroupID Is Nothing Then
          _FK_COST_CostSheetLiability_ProjectGroupID = SIS.COST.costProjectGroups.costProjectGroupsGetByID(_ProjectGroupID)
        End If
        Return _FK_COST_CostSheetLiability_ProjectGroupID
      End Get
    End Property
    Public ReadOnly Property FK_COST_CostSheetLiability_Quarter() As SIS.COST.costQuarters
      Get
        If _FK_COST_CostSheetLiability_Quarter Is Nothing Then
          _FK_COST_CostSheetLiability_Quarter = SIS.COST.costQuarters.costQuartersGetByID(_Quarter)
        End If
        Return _FK_COST_CostSheetLiability_Quarter
      End Get
    End Property
    Public ReadOnly Property FK_COST_CostSheetLiability_ProjectID() As SIS.COST.costProjects
      Get
        If _FK_COST_CostSheetLiability_ProjectID Is Nothing Then
          _FK_COST_CostSheetLiability_ProjectID = SIS.COST.costProjects.costProjectsGetByID(_ProjectID)
        End If
        Return _FK_COST_CostSheetLiability_ProjectID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function costCostSheetLiabilityGetNewRecord() As SIS.COST.costCostSheetLiability
      Return New SIS.COST.costCostSheetLiability()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function costCostSheetLiabilityGetByID(ByVal ProjectGroupID As Int32, ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal Revision As Int32, ByVal ProjectID As String, ByVal GLCode As String, ByVal AdjustmentSerialNo As Int32, ByVal AdjustmentCredit As Boolean) As SIS.COST.costCostSheetLiability
      Dim Results As SIS.COST.costCostSheetLiability = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostCostSheetLiabilitySelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectGroupID", SqlDbType.Int, ProjectGroupID.ToString.Length, ProjectGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.Int, FinYear.ToString.Length, FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quarter", SqlDbType.Int, Quarter.ToString.Length, Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Revision", SqlDbType.Int, Revision.ToString.Length, Revision)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, ProjectID.ToString.Length, ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GLCode", SqlDbType.NVarChar, GLCode.ToString.Length, GLCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdjustmentSerialNo", SqlDbType.Int, AdjustmentSerialNo.ToString.Length, AdjustmentSerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdjustmentCredit", SqlDbType.Bit, AdjustmentCredit.ToString.Length, AdjustmentCredit)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.COST.costCostSheetLiability(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function GetByAdjustmentSerialNo(ByVal AdjustmentSerialNo As Int32, ByVal OrderBy As String) As List(Of SIS.COST.costCostSheetLiability)
      Dim Results As List(Of SIS.COST.costCostSheetLiability) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostCostSheetLiabilitySelectByAdjustmentSerialNo"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdjustmentSerialNo", SqlDbType.Int, AdjustmentSerialNo.ToString.Length, AdjustmentSerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.COST.costCostSheetLiability)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.COST.costCostSheetLiability(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function costCostSheetLiabilitySelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal Quarter As Int32, ByVal FinYear As Int32, ByVal ProjectGroupID As Int32, ByVal Revision As Int32) As List(Of SIS.COST.costCostSheetLiability)
      Dim Results As List(Of SIS.COST.costCostSheetLiability) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spcostCostSheetLiabilitySelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spcostCostSheetLiabilitySelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_Quarter", SqlDbType.Int, 10, IIf(Quarter = Nothing, 0, Quarter))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FinYear", SqlDbType.Int, 10, IIf(FinYear = Nothing, 0, FinYear))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectGroupID", SqlDbType.Int, 10, IIf(ProjectGroupID = Nothing, 0, ProjectGroupID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_Revision", SqlDbType.Int, 10, IIf(Revision = Nothing, 0, Revision))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.COST.costCostSheetLiability)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.COST.costCostSheetLiability(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function costCostSheetLiabilitySelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal Quarter As Int32, ByVal FinYear As Int32, ByVal ProjectGroupID As Int32, ByVal Revision As Int32) As Integer
      Return _RecordCount
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function costCostSheetLiabilityGetByID(ByVal ProjectGroupID As Int32, ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal Revision As Int32, ByVal ProjectID As String, ByVal GLCode As String, ByVal AdjustmentSerialNo As Int32, ByVal AdjustmentCredit As Boolean, ByVal Filter_Quarter As Int32, ByVal Filter_FinYear As Int32, ByVal Filter_ProjectGroupID As Int32, ByVal Filter_Revision As Int32) As SIS.COST.costCostSheetLiability
      Return costCostSheetLiabilityGetByID(ProjectGroupID, FinYear, Quarter, Revision, ProjectID, GLCode, AdjustmentSerialNo, AdjustmentCredit)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)>
    Public Shared Function costCostSheetLiabilityInsert(ByVal Record As SIS.COST.costCostSheetLiability) As SIS.COST.costCostSheetLiability
      Dim _Rec As SIS.COST.costCostSheetLiability = SIS.COST.costCostSheetLiability.costCostSheetLiabilityGetNewRecord()
      With _Rec
        .AdjustmentSerialNo = Record.AdjustmentSerialNo
        .ProjectID = Record.ProjectID
        .GLCode = Record.GLCode
        .CrAmount = Record.CrAmount
        .DrAmount = Record.DrAmount
        .Amount = Record.Amount
        .AdjustmentEntry = Record.AdjustmentEntry
        .AdjustmentCredit = Record.AdjustmentCredit
        .Quarter = Record.Quarter
        .FinYear = Record.FinYear
        .ProjectGroupID = Record.ProjectGroupID
        .Revision = Record.Revision
        .CrFC = Record.CrFC
        .DrFC = Record.DrFC
        .NetFC = Record.NetFC
        .FC = Record.FC
      End With
      Return SIS.COST.costCostSheetLiability.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.COST.costCostSheetLiability) As SIS.COST.costCostSheetLiability
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostCostSheetLiabilityInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdjustmentSerialNo", SqlDbType.Int, 11, Record.AdjustmentSerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, 7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GLCode", SqlDbType.NVarChar, 8, Record.GLCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CrAmount", SqlDbType.Decimal, 17, IIf(Record.CrAmount = "", Convert.DBNull, Record.CrAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DrAmount", SqlDbType.Decimal, 17, IIf(Record.DrAmount = "", Convert.DBNull, Record.DrAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Amount", SqlDbType.Decimal, 17, IIf(Record.Amount = "", Convert.DBNull, Record.Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CrFC", SqlDbType.Decimal, 17, IIf(Record.CrFC = "", Convert.DBNull, Record.CrFC))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DrFC", SqlDbType.Decimal, 17, IIf(Record.DrFC = "", Convert.DBNull, Record.DrFC))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NetFC", SqlDbType.Decimal, 17, IIf(Record.NetFC = "", Convert.DBNull, Record.NetFC))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FC", SqlDbType.NVarChar, 10, IIf(Record.FC = "", Convert.DBNull, Record.FC))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdjustmentEntry", SqlDbType.Bit, 3, Record.AdjustmentEntry)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdjustmentCredit", SqlDbType.Bit, 3, Record.AdjustmentCredit)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quarter", SqlDbType.Int, 11, Record.Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.Int, 11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectGroupID", SqlDbType.Int, 11, Record.ProjectGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Revision", SqlDbType.Int, 11, Record.Revision)
          Cmd.Parameters.Add("@Return_ProjectGroupID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ProjectGroupID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_FinYear", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_FinYear").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_Quarter", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_Quarter").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_Revision", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_Revision").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_ProjectID", SqlDbType.NVarChar, 7)
          Cmd.Parameters("@Return_ProjectID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_GLCode", SqlDbType.NVarChar, 8)
          Cmd.Parameters("@Return_GLCode").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_AdjustmentSerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_AdjustmentSerialNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_AdjustmentCredit", SqlDbType.Bit, 3)
          Cmd.Parameters("@Return_AdjustmentCredit").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ProjectGroupID = Cmd.Parameters("@Return_ProjectGroupID").Value
          Record.FinYear = Cmd.Parameters("@Return_FinYear").Value
          Record.Quarter = Cmd.Parameters("@Return_Quarter").Value
          Record.Revision = Cmd.Parameters("@Return_Revision").Value
          Record.ProjectID = Cmd.Parameters("@Return_ProjectID").Value
          Record.GLCode = Cmd.Parameters("@Return_GLCode").Value
          Record.AdjustmentSerialNo = Cmd.Parameters("@Return_AdjustmentSerialNo").Value
          Record.AdjustmentCredit = Cmd.Parameters("@Return_AdjustmentCredit").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)>
    Public Shared Function costCostSheetLiabilityUpdate(ByVal Record As SIS.COST.costCostSheetLiability) As SIS.COST.costCostSheetLiability
      Dim _Rec As SIS.COST.costCostSheetLiability = SIS.COST.costCostSheetLiability.costCostSheetLiabilityGetByID(Record.ProjectGroupID, Record.FinYear, Record.Quarter, Record.Revision, Record.ProjectID, Record.GLCode, Record.AdjustmentSerialNo, Record.AdjustmentCredit)
      With _Rec
        .CrAmount = Record.CrAmount
        .DrAmount = Record.DrAmount
        .Amount = Record.Amount
        .AdjustmentEntry = Record.AdjustmentEntry
        .CrFC = Record.CrFC
        .DrFC = Record.DrFC
        .NetFC = Record.NetFC
        .FC = Record.FC
      End With
      Return SIS.COST.costCostSheetLiability.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.COST.costCostSheetLiability) As SIS.COST.costCostSheetLiability
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostCostSheetLiabilityUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_AdjustmentSerialNo", SqlDbType.Int, 11, Record.AdjustmentSerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID", SqlDbType.NVarChar, 7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_GLCode", SqlDbType.NVarChar, 8, Record.GLCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_AdjustmentCredit", SqlDbType.Bit, 3, Record.AdjustmentCredit)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_Quarter", SqlDbType.Int, 11, Record.Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FinYear", SqlDbType.Int, 11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectGroupID", SqlDbType.Int, 11, Record.ProjectGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_Revision", SqlDbType.Int, 11, Record.Revision)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdjustmentSerialNo", SqlDbType.Int, 11, Record.AdjustmentSerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, 7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GLCode", SqlDbType.NVarChar, 8, Record.GLCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CrAmount", SqlDbType.Decimal, 17, IIf(Record.CrAmount = "", Convert.DBNull, Record.CrAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DrAmount", SqlDbType.Decimal, 17, IIf(Record.DrAmount = "", Convert.DBNull, Record.DrAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Amount", SqlDbType.Decimal, 17, IIf(Record.Amount = "", Convert.DBNull, Record.Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CrFC", SqlDbType.Decimal, 17, IIf(Record.CrFC = "", Convert.DBNull, Record.CrFC))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DrFC", SqlDbType.Decimal, 17, IIf(Record.DrFC = "", Convert.DBNull, Record.DrFC))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NetFC", SqlDbType.Decimal, 17, IIf(Record.NetFC = "", Convert.DBNull, Record.NetFC))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FC", SqlDbType.NVarChar, 10, IIf(Record.FC = "", Convert.DBNull, Record.FC))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdjustmentEntry", SqlDbType.Bit, 3, Record.AdjustmentEntry)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdjustmentCredit", SqlDbType.Bit, 3, Record.AdjustmentCredit)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quarter", SqlDbType.Int, 11, Record.Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.Int, 11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectGroupID", SqlDbType.Int, 11, Record.ProjectGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Revision", SqlDbType.Int, 11, Record.Revision)
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
    <DataObjectMethod(DataObjectMethodType.Delete, True)>
    Public Shared Function costCostSheetLiabilityDelete(ByVal Record As SIS.COST.costCostSheetLiability) As Int32
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostCostSheetLiabilityDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectGroupID",SqlDbType.Int,Record.ProjectGroupID.ToString.Length, Record.ProjectGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FinYear",SqlDbType.Int,Record.FinYear.ToString.Length, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_Quarter",SqlDbType.Int,Record.Quarter.ToString.Length, Record.Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_Revision",SqlDbType.Int,Record.Revision.ToString.Length, Record.Revision)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID",SqlDbType.NVarChar,Record.ProjectID.ToString.Length, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_GLCode",SqlDbType.NVarChar,Record.GLCode.ToString.Length, Record.GLCode)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_AdjustmentSerialNo",SqlDbType.Int,Record.AdjustmentSerialNo.ToString.Length, Record.AdjustmentSerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_AdjustmentCredit",SqlDbType.Bit,Record.AdjustmentCredit.ToString.Length, Record.AdjustmentCredit)
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
