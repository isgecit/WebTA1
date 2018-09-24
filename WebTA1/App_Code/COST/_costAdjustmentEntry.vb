Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.COST
  <DataObject()> _
  Partial Public Class costAdjustmentEntry
    Private Shared _RecordCount As Integer
    Private _AdjustmentSerialNo As Int32 = 0
    Private _ProjectID As String = ""
    Private _CrGLCode As String = ""
    Private _DrGLCode As String = ""
    Private _Amount As Decimal = 0
    Private _Active As Boolean = False
    Private _Remarks As String = ""
    Private _FinYear As Int32 = 0
    Private _ProjectGroupID As Int32 = 0
    Private _Revision As Int32 = 0
    Private _CreatedOn As String = ""
    Private _CreatedBy As String = ""
    Private _Quarter As Int32 = 0
    Private _aspnet_Users1_UserFullName As String = ""
    Private _COST_CostSheet2_Remarks As String = ""
    Private _COST_ERPGLCodes3_GLDescription As String = ""
    Private _COST_ERPGLCodes4_GLDescription As String = ""
    Private _COST_FinYear5_Descpription As String = ""
    Private _COST_ProjectGroups6_ProjectGroupDescription As String = ""
    Private _COST_Quarters7_Description As String = ""
    Private _IDM_Projects8_Description As String = ""
    Private _FK_COST_AdjustmentEntry_CreatedBy As SIS.TA.taWebUsers = Nothing
    Private _FK_COST_AdjustmentEntry_CostSheet As SIS.COST.costCostSheet = Nothing
    Private _FK_COST_AdjustmentEntry_CrGLCode As SIS.COST.costERPGLCodes = Nothing
    Private _FK_COST_AdjustmentEntry_DrGLCode As SIS.COST.costERPGLCodes = Nothing
    Private _FK_COST_AdjustmentEntry_FinYear As SIS.COST.costFinYear = Nothing
    Private _FK_COST_AdjustmentEntry_ProjectGroupID As SIS.COST.costProjectGroups = Nothing
    Private _FK_COST_AdjustmentEntry_Quarter As SIS.COST.costQuarters = Nothing
    Private _FK_COST_AdjustmentEntry_ProjectID As SIS.COST.costProjects = Nothing
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
         If Convert.IsDBNull(Value) Then
           _ProjectID = ""
         Else
           _ProjectID = value
         End If
      End Set
    End Property
    Public Property CrGLCode() As String
      Get
        Return _CrGLCode
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CrGLCode = ""
         Else
           _CrGLCode = value
         End If
      End Set
    End Property
    Public Property DrGLCode() As String
      Get
        Return _DrGLCode
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DrGLCode = ""
         Else
           _DrGLCode = value
         End If
      End Set
    End Property
    Public Property Amount() As Decimal
      Get
        Return _Amount
      End Get
      Set(ByVal value As Decimal)
        _Amount = value
      End Set
    End Property
    Public Property Active() As Boolean
      Get
        Return _Active
      End Get
      Set(ByVal value As Boolean)
        _Active = value
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
    Public Property Quarter() As Int32
      Get
        Return _Quarter
      End Get
      Set(ByVal value As Int32)
        _Quarter = value
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
    Public Property COST_CostSheet2_Remarks() As String
      Get
        Return _COST_CostSheet2_Remarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _COST_CostSheet2_Remarks = ""
         Else
           _COST_CostSheet2_Remarks = value
         End If
      End Set
    End Property
    Public Property COST_ERPGLCodes3_GLDescription() As String
      Get
        Return _COST_ERPGLCodes3_GLDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _COST_ERPGLCodes3_GLDescription = ""
         Else
           _COST_ERPGLCodes3_GLDescription = value
         End If
      End Set
    End Property
    Public Property COST_ERPGLCodes4_GLDescription() As String
      Get
        Return _COST_ERPGLCodes4_GLDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _COST_ERPGLCodes4_GLDescription = ""
         Else
           _COST_ERPGLCodes4_GLDescription = value
         End If
      End Set
    End Property
    Public Property COST_FinYear5_Descpription() As String
      Get
        Return _COST_FinYear5_Descpription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _COST_FinYear5_Descpription = ""
         Else
           _COST_FinYear5_Descpription = value
         End If
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
    Public Property COST_Quarters7_Description() As String
      Get
        Return _COST_Quarters7_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _COST_Quarters7_Description = ""
         Else
           _COST_Quarters7_Description = value
         End If
      End Set
    End Property
    Public Property IDM_Projects8_Description() As String
      Get
        Return _IDM_Projects8_Description
      End Get
      Set(ByVal value As String)
        _IDM_Projects8_Description = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _ProjectGroupID & "|" & _FinYear & "|" & _Quarter & "|" & _Revision & "|" & _AdjustmentSerialNo
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
    Public Class PKcostAdjustmentEntry
      Private _ProjectGroupID As Int32 = 0
      Private _FinYear As Int32 = 0
      Private _Quarter As Int32 = 0
      Private _Revision As Int32 = 0
      Private _AdjustmentSerialNo As Int32 = 0
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
      Public Property AdjustmentSerialNo() As Int32
        Get
          Return _AdjustmentSerialNo
        End Get
        Set(ByVal value As Int32)
          _AdjustmentSerialNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_COST_AdjustmentEntry_CreatedBy() As SIS.TA.taWebUsers
      Get
        If _FK_COST_AdjustmentEntry_CreatedBy Is Nothing Then
          _FK_COST_AdjustmentEntry_CreatedBy = SIS.TA.taWebUsers.taWebUsersGetByID(_CreatedBy)
        End If
        Return _FK_COST_AdjustmentEntry_CreatedBy
      End Get
    End Property
    Public ReadOnly Property FK_COST_AdjustmentEntry_CostSheet() As SIS.COST.costCostSheet
      Get
        If _FK_COST_AdjustmentEntry_CostSheet Is Nothing Then
          _FK_COST_AdjustmentEntry_CostSheet = SIS.COST.costCostSheet.costCostSheetGetByID(_ProjectGroupID, _FinYear, _Quarter, _Revision)
        End If
        Return _FK_COST_AdjustmentEntry_CostSheet
      End Get
    End Property
    Public ReadOnly Property FK_COST_AdjustmentEntry_CrGLCode() As SIS.COST.costERPGLCodes
      Get
        If _FK_COST_AdjustmentEntry_CrGLCode Is Nothing Then
          _FK_COST_AdjustmentEntry_CrGLCode = SIS.COST.costERPGLCodes.costERPGLCodesGetByID(_CrGLCode)
        End If
        Return _FK_COST_AdjustmentEntry_CrGLCode
      End Get
    End Property
    Public ReadOnly Property FK_COST_AdjustmentEntry_DrGLCode() As SIS.COST.costERPGLCodes
      Get
        If _FK_COST_AdjustmentEntry_DrGLCode Is Nothing Then
          _FK_COST_AdjustmentEntry_DrGLCode = SIS.COST.costERPGLCodes.costERPGLCodesGetByID(_DrGLCode)
        End If
        Return _FK_COST_AdjustmentEntry_DrGLCode
      End Get
    End Property
    Public ReadOnly Property FK_COST_AdjustmentEntry_FinYear() As SIS.COST.costFinYear
      Get
        If _FK_COST_AdjustmentEntry_FinYear Is Nothing Then
          _FK_COST_AdjustmentEntry_FinYear = SIS.COST.costFinYear.costFinYearGetByID(_FinYear)
        End If
        Return _FK_COST_AdjustmentEntry_FinYear
      End Get
    End Property
    Public ReadOnly Property FK_COST_AdjustmentEntry_ProjectGroupID() As SIS.COST.costProjectGroups
      Get
        If _FK_COST_AdjustmentEntry_ProjectGroupID Is Nothing Then
          _FK_COST_AdjustmentEntry_ProjectGroupID = SIS.COST.costProjectGroups.costProjectGroupsGetByID(_ProjectGroupID)
        End If
        Return _FK_COST_AdjustmentEntry_ProjectGroupID
      End Get
    End Property
    Public ReadOnly Property FK_COST_AdjustmentEntry_Quarter() As SIS.COST.costQuarters
      Get
        If _FK_COST_AdjustmentEntry_Quarter Is Nothing Then
          _FK_COST_AdjustmentEntry_Quarter = SIS.COST.costQuarters.costQuartersGetByID(_Quarter)
        End If
        Return _FK_COST_AdjustmentEntry_Quarter
      End Get
    End Property
    Public ReadOnly Property FK_COST_AdjustmentEntry_ProjectID() As SIS.COST.costProjects
      Get
        If _FK_COST_AdjustmentEntry_ProjectID Is Nothing Then
          _FK_COST_AdjustmentEntry_ProjectID = SIS.COST.costProjects.costProjectsGetByID(_ProjectID)
        End If
        Return _FK_COST_AdjustmentEntry_ProjectID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costAdjustmentEntryGetNewRecord() As SIS.COST.costAdjustmentEntry
      Return New SIS.COST.costAdjustmentEntry()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costAdjustmentEntryGetByID(ByVal ProjectGroupID As Int32, ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal Revision As Int32, ByVal AdjustmentSerialNo As Int32) As SIS.COST.costAdjustmentEntry
      Dim Results As SIS.COST.costAdjustmentEntry = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostAdjustmentEntrySelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectGroupID",SqlDbType.Int,ProjectGroupID.ToString.Length, ProjectGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,FinYear.ToString.Length, FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quarter",SqlDbType.Int,Quarter.ToString.Length, Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Revision",SqlDbType.Int,Revision.ToString.Length, Revision)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdjustmentSerialNo",SqlDbType.Int,AdjustmentSerialNo.ToString.Length, AdjustmentSerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.COST.costAdjustmentEntry(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costAdjustmentEntrySelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal FinYear As Int32, ByVal ProjectGroupID As Int32, ByVal Revision As Int32, ByVal Quarter As Int32) As List(Of SIS.COST.costAdjustmentEntry)
      Dim Results As List(Of SIS.COST.costAdjustmentEntry) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spcostAdjustmentEntrySelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spcostAdjustmentEntrySelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FinYear",SqlDbType.Int,10, IIf(FinYear = Nothing, 0,FinYear))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectGroupID",SqlDbType.Int,10, IIf(ProjectGroupID = Nothing, 0,ProjectGroupID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_Revision",SqlDbType.Int,10, IIf(Revision = Nothing, 0,Revision))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_Quarter",SqlDbType.Int,10, IIf(Quarter = Nothing, 0,Quarter))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.COST.costAdjustmentEntry)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.COST.costAdjustmentEntry(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function costAdjustmentEntrySelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal FinYear As Int32, ByVal ProjectGroupID As Int32, ByVal Revision As Int32, ByVal Quarter As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costAdjustmentEntryGetByID(ByVal ProjectGroupID As Int32, ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal Revision As Int32, ByVal AdjustmentSerialNo As Int32, ByVal Filter_FinYear As Int32, ByVal Filter_ProjectGroupID As Int32, ByVal Filter_Revision As Int32, ByVal Filter_Quarter As Int32) As SIS.COST.costAdjustmentEntry
      Return costAdjustmentEntryGetByID(ProjectGroupID, FinYear, Quarter, Revision, AdjustmentSerialNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function costAdjustmentEntryInsert(ByVal Record As SIS.COST.costAdjustmentEntry) As SIS.COST.costAdjustmentEntry
      Dim _Rec As SIS.COST.costAdjustmentEntry = SIS.COST.costAdjustmentEntry.costAdjustmentEntryGetNewRecord()
      With _Rec
        .ProjectID = Record.ProjectID
        .CrGLCode = Record.CrGLCode
        .DrGLCode = Record.DrGLCode
        .Amount = Record.Amount
        .Active = Record.Active
        .Remarks = Record.Remarks
        .FinYear = Record.FinYear
        .ProjectGroupID = Record.ProjectGroupID
        .Revision = Record.Revision
        .CreatedOn = Now
        .CreatedBy =  Global.System.Web.HttpContext.Current.Session("LoginID")
        .Quarter = Record.Quarter
      End With
      Return SIS.COST.costAdjustmentEntry.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.COST.costAdjustmentEntry) As SIS.COST.costAdjustmentEntry
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostAdjustmentEntryInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CrGLCode",SqlDbType.NVarChar,8, Iif(Record.CrGLCode= "" ,Convert.DBNull, Record.CrGLCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DrGLCode",SqlDbType.NVarChar,8, Iif(Record.DrGLCode= "" ,Convert.DBNull, Record.DrGLCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Amount",SqlDbType.Decimal,17, Record.Amount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active",SqlDbType.Bit,3, Record.Active)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,251, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectGroupID",SqlDbType.Int,11, Record.ProjectGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Revision",SqlDbType.Int,11, Record.Revision)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quarter",SqlDbType.Int,11, Record.Quarter)
          Cmd.Parameters.Add("@Return_ProjectGroupID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ProjectGroupID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_FinYear", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_FinYear").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_Quarter", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_Quarter").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_Revision", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_Revision").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_AdjustmentSerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_AdjustmentSerialNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ProjectGroupID = Cmd.Parameters("@Return_ProjectGroupID").Value
          Record.FinYear = Cmd.Parameters("@Return_FinYear").Value
          Record.Quarter = Cmd.Parameters("@Return_Quarter").Value
          Record.Revision = Cmd.Parameters("@Return_Revision").Value
          Record.AdjustmentSerialNo = Cmd.Parameters("@Return_AdjustmentSerialNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function costAdjustmentEntryUpdate(ByVal Record As SIS.COST.costAdjustmentEntry) As SIS.COST.costAdjustmentEntry
      Dim _Rec As SIS.COST.costAdjustmentEntry = SIS.COST.costAdjustmentEntry.costAdjustmentEntryGetByID(Record.ProjectGroupID, Record.FinYear, Record.Quarter, Record.Revision, Record.AdjustmentSerialNo)
      With _Rec
        .ProjectID = Record.ProjectID
        .CrGLCode = Record.CrGLCode
        .DrGLCode = Record.DrGLCode
        .Amount = Record.Amount
        .Active = Record.Active
        .Remarks = Record.Remarks
        .CreatedOn = Now
        .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
      End With
      Return SIS.COST.costAdjustmentEntry.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.COST.costAdjustmentEntry) As SIS.COST.costAdjustmentEntry
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostAdjustmentEntryUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_AdjustmentSerialNo",SqlDbType.Int,11, Record.AdjustmentSerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FinYear",SqlDbType.Int,11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectGroupID",SqlDbType.Int,11, Record.ProjectGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_Revision",SqlDbType.Int,11, Record.Revision)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_Quarter",SqlDbType.Int,11, Record.Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CrGLCode",SqlDbType.NVarChar,8, Iif(Record.CrGLCode= "" ,Convert.DBNull, Record.CrGLCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DrGLCode",SqlDbType.NVarChar,8, Iif(Record.DrGLCode= "" ,Convert.DBNull, Record.DrGLCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Amount",SqlDbType.Decimal,17, Record.Amount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active",SqlDbType.Bit,3, Record.Active)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,251, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectGroupID",SqlDbType.Int,11, Record.ProjectGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Revision",SqlDbType.Int,11, Record.Revision)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quarter",SqlDbType.Int,11, Record.Quarter)
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
    Public Shared Function costAdjustmentEntryDelete(ByVal Record As SIS.COST.costAdjustmentEntry) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostAdjustmentEntryDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectGroupID",SqlDbType.Int,Record.ProjectGroupID.ToString.Length, Record.ProjectGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FinYear",SqlDbType.Int,Record.FinYear.ToString.Length, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_Quarter",SqlDbType.Int,Record.Quarter.ToString.Length, Record.Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_Revision",SqlDbType.Int,Record.Revision.ToString.Length, Record.Revision)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_AdjustmentSerialNo",SqlDbType.Int,Record.AdjustmentSerialNo.ToString.Length, Record.AdjustmentSerialNo)
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
