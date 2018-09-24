Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.COST
  <DataObject()> _
  Partial Public Class costCSDataWOnGLGroup
    Private Shared _RecordCount As Integer
    Private _ProjectGroupID As Int32 = 0
    Private _FinYear As Int32 = 0
    Private _Quarter As Int32 = 0
    Private _Revision As Int32 = 0
    Private _WorkOrderTypeID As Int32 = 0
    Private _GLGroupID As Int32 = 0
    Private _CrAmount As Decimal = 0
    Private _DrAmount As Decimal = 0
    Private _Amount As Decimal = 0
    Private _CrFC As Decimal = 0
    Private _DrFC As Decimal = 0
    Private _NetFC As Decimal = 0
    Private _FC As String = ""
    Private _COST_CostSheet1_Remarks As String = ""
    Private _COST_FinYear2_Descpription As String = ""
    Private _COST_GLGroups3_GLGroupDescriptions As String = ""
    Private _COST_ProjectGroups4_ProjectGroupDescription As String = ""
    Private _COST_Quarters5_Description As String = ""
    Private _COST_WorkOrderTypes6_WorkOrderTypeDescription As String = ""
    Private _FK_COST_CSDataWOnGLGroup_CostSheet As SIS.COST.costCostSheet = Nothing
    Private _FK_COST_CSDataWOnGLGroup_FinYear As SIS.COST.costFinYear = Nothing
    Private _FK_COST_CSDataWOnGLGroup_GLGroupID As SIS.COST.costGLGroups = Nothing
    Private _FK_COST_CSDataWOnGLGroup_ProjectGroupID As SIS.COST.costProjectGroups = Nothing
    Private _FK_COST_CSDataWOnGLGroup_Quarter As SIS.COST.costQuarters = Nothing
    Private _FK_COST_CSDataWOnGLGroup_WorkOrderTypeID As SIS.COST.costWorkOrderTypes = Nothing
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
    Public Property Revision() As Int32
      Get
        Return _Revision
      End Get
      Set(ByVal value As Int32)
        _Revision = value
      End Set
    End Property
    Public Property WorkOrderTypeID() As Int32
      Get
        Return _WorkOrderTypeID
      End Get
      Set(ByVal value As Int32)
        _WorkOrderTypeID = value
      End Set
    End Property
    Public Property GLGroupID() As Int32
      Get
        Return _GLGroupID
      End Get
      Set(ByVal value As Int32)
        _GLGroupID = value
      End Set
    End Property
    Public Property CrFC() As Decimal
      Get
        Return _CrFC
      End Get
      Set(ByVal value As Decimal)
        _CrFC = value
      End Set
    End Property
    Public Property DrFC() As Decimal
      Get
        Return _DrFC
      End Get
      Set(ByVal value As Decimal)
        _DrFC = value
      End Set
    End Property
    Public Property NetFC() As Decimal
      Get
        Return _NetFC
      End Get
      Set(ByVal value As Decimal)
        _NetFC = value
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
    Public Property CrAmount() As Decimal
      Get
        Return _CrAmount
      End Get
      Set(ByVal value As Decimal)
        _CrAmount = value
      End Set
    End Property
    Public Property DrAmount() As Decimal
      Get
        Return _DrAmount
      End Get
      Set(ByVal value As Decimal)
        _DrAmount = value
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
    Public Property COST_CostSheet1_Remarks() As String
      Get
        Return _COST_CostSheet1_Remarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _COST_CostSheet1_Remarks = ""
         Else
           _COST_CostSheet1_Remarks = value
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
    Public Property COST_GLGroups3_GLGroupDescriptions() As String
      Get
        Return _COST_GLGroups3_GLGroupDescriptions
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _COST_GLGroups3_GLGroupDescriptions = ""
         Else
           _COST_GLGroups3_GLGroupDescriptions = value
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
    Public Property COST_Quarters5_Description() As String
      Get
        Return _COST_Quarters5_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _COST_Quarters5_Description = ""
         Else
           _COST_Quarters5_Description = value
         End If
      End Set
    End Property
    Public Property COST_WorkOrderTypes6_WorkOrderTypeDescription() As String
      Get
        Return _COST_WorkOrderTypes6_WorkOrderTypeDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _COST_WorkOrderTypes6_WorkOrderTypeDescription = ""
         Else
           _COST_WorkOrderTypes6_WorkOrderTypeDescription = value
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
        Return _ProjectGroupID & "|" & _FinYear & "|" & _Quarter & "|" & _Revision & "|" & _WorkOrderTypeID & "|" & _GLGroupID
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
    Public Class PKcostCSDataWOnGLGroup
      Private _ProjectGroupID As Int32 = 0
      Private _FinYear As Int32 = 0
      Private _Quarter As Int32 = 0
      Private _Revision As Int32 = 0
      Private _WorkOrderTypeID As Int32 = 0
      Private _GLGroupID As Int32 = 0
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
      Public Property WorkOrderTypeID() As Int32
        Get
          Return _WorkOrderTypeID
        End Get
        Set(ByVal value As Int32)
          _WorkOrderTypeID = value
        End Set
      End Property
      Public Property GLGroupID() As Int32
        Get
          Return _GLGroupID
        End Get
        Set(ByVal value As Int32)
          _GLGroupID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_COST_CSDataWOnGLGroup_CostSheet() As SIS.COST.costCostSheet
      Get
        If _FK_COST_CSDataWOnGLGroup_CostSheet Is Nothing Then
          _FK_COST_CSDataWOnGLGroup_CostSheet = SIS.COST.costCostSheet.costCostSheetGetByID(_ProjectGroupID, _FinYear, _Quarter, _Revision)
        End If
        Return _FK_COST_CSDataWOnGLGroup_CostSheet
      End Get
    End Property
    Public ReadOnly Property FK_COST_CSDataWOnGLGroup_FinYear() As SIS.COST.costFinYear
      Get
        If _FK_COST_CSDataWOnGLGroup_FinYear Is Nothing Then
          _FK_COST_CSDataWOnGLGroup_FinYear = SIS.COST.costFinYear.costFinYearGetByID(_FinYear)
        End If
        Return _FK_COST_CSDataWOnGLGroup_FinYear
      End Get
    End Property
    Public ReadOnly Property FK_COST_CSDataWOnGLGroup_GLGroupID() As SIS.COST.costGLGroups
      Get
        If _FK_COST_CSDataWOnGLGroup_GLGroupID Is Nothing Then
          _FK_COST_CSDataWOnGLGroup_GLGroupID = SIS.COST.costGLGroups.costGLGroupsGetByID(_GLGroupID)
        End If
        Return _FK_COST_CSDataWOnGLGroup_GLGroupID
      End Get
    End Property
    Public ReadOnly Property FK_COST_CSDataWOnGLGroup_ProjectGroupID() As SIS.COST.costProjectGroups
      Get
        If _FK_COST_CSDataWOnGLGroup_ProjectGroupID Is Nothing Then
          _FK_COST_CSDataWOnGLGroup_ProjectGroupID = SIS.COST.costProjectGroups.costProjectGroupsGetByID(_ProjectGroupID)
        End If
        Return _FK_COST_CSDataWOnGLGroup_ProjectGroupID
      End Get
    End Property
    Public ReadOnly Property FK_COST_CSDataWOnGLGroup_Quarter() As SIS.COST.costQuarters
      Get
        If _FK_COST_CSDataWOnGLGroup_Quarter Is Nothing Then
          _FK_COST_CSDataWOnGLGroup_Quarter = SIS.COST.costQuarters.costQuartersGetByID(_Quarter)
        End If
        Return _FK_COST_CSDataWOnGLGroup_Quarter
      End Get
    End Property
    Public ReadOnly Property FK_COST_CSDataWOnGLGroup_WorkOrderTypeID() As SIS.COST.costWorkOrderTypes
      Get
        If _FK_COST_CSDataWOnGLGroup_WorkOrderTypeID Is Nothing Then
          _FK_COST_CSDataWOnGLGroup_WorkOrderTypeID = SIS.COST.costWorkOrderTypes.costWorkOrderTypesGetByID(_WorkOrderTypeID)
        End If
        Return _FK_COST_CSDataWOnGLGroup_WorkOrderTypeID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costCSDataWOnGLGroupGetNewRecord() As SIS.COST.costCSDataWOnGLGroup
      Return New SIS.COST.costCSDataWOnGLGroup()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costCSDataWOnGLGroupGetByID(ByVal ProjectGroupID As Int32, ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal Revision As Int32, ByVal WorkOrderTypeID As Int32, ByVal GLGroupID As Int32) As SIS.COST.costCSDataWOnGLGroup
      Dim Results As SIS.COST.costCSDataWOnGLGroup = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostCSDataWOnGLGroupSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectGroupID",SqlDbType.Int,ProjectGroupID.ToString.Length, ProjectGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,FinYear.ToString.Length, FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quarter",SqlDbType.Int,Quarter.ToString.Length, Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Revision",SqlDbType.Int,Revision.ToString.Length, Revision)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WorkOrderTypeID",SqlDbType.Int,WorkOrderTypeID.ToString.Length, WorkOrderTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GLGroupID",SqlDbType.Int,GLGroupID.ToString.Length, GLGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.COST.costCSDataWOnGLGroup(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costCSDataWOnGLGroupSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectGroupID As Int32, ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal Revision As Int32) As List(Of SIS.COST.costCSDataWOnGLGroup)
      Dim Results As List(Of SIS.COST.costCSDataWOnGLGroup) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spcostCSDataWOnGLGroupSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spcostCSDataWOnGLGroupSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectGroupID",SqlDbType.Int,10, IIf(ProjectGroupID = Nothing, 0,ProjectGroupID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FinYear",SqlDbType.Int,10, IIf(FinYear = Nothing, 0,FinYear))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_Quarter",SqlDbType.Int,10, IIf(Quarter = Nothing, 0,Quarter))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_Revision",SqlDbType.Int,10, IIf(Revision = Nothing, 0,Revision))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.COST.costCSDataWOnGLGroup)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.COST.costCSDataWOnGLGroup(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function costCSDataWOnGLGroupSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectGroupID As Int32, ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal Revision As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function costCSDataWOnGLGroupGetByID(ByVal ProjectGroupID As Int32, ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal Revision As Int32, ByVal WorkOrderTypeID As Int32, ByVal GLGroupID As Int32, ByVal Filter_ProjectGroupID As Int32, ByVal Filter_FinYear As Int32, ByVal Filter_Quarter As Int32, ByVal Filter_Revision As Int32) As SIS.COST.costCSDataWOnGLGroup
      Return costCSDataWOnGLGroupGetByID(ProjectGroupID, FinYear, Quarter, Revision, WorkOrderTypeID, GLGroupID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function costCSDataWOnGLGroupInsert(ByVal Record As SIS.COST.costCSDataWOnGLGroup) As SIS.COST.costCSDataWOnGLGroup
      Dim _Rec As SIS.COST.costCSDataWOnGLGroup = SIS.COST.costCSDataWOnGLGroup.costCSDataWOnGLGroupGetNewRecord()
      With _Rec
        .ProjectGroupID = Record.ProjectGroupID
        .FinYear = Record.FinYear
        .Quarter = Record.Quarter
        .Revision = Record.Revision
        .WorkOrderTypeID = Record.WorkOrderTypeID
        .GLGroupID = Record.GLGroupID
        .CrAmount = Record.CrAmount
        .DrAmount = Record.DrAmount
        .Amount = Record.Amount
      End With
      Return SIS.COST.costCSDataWOnGLGroup.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.COST.costCSDataWOnGLGroup) As SIS.COST.costCSDataWOnGLGroup
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostCSDataWOnGLGroupInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectGroupID",SqlDbType.Int,11, Record.ProjectGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quarter",SqlDbType.Int,11, Record.Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Revision",SqlDbType.Int,11, Record.Revision)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WorkOrderTypeID",SqlDbType.Int,11, Record.WorkOrderTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GLGroupID",SqlDbType.Int,11, Record.GLGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CrAmount", SqlDbType.Decimal, 17, Record.CrAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DrAmount", SqlDbType.Decimal, 17, Record.DrAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Amount", SqlDbType.Decimal, 17, Record.Amount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CrFC", SqlDbType.Decimal, 17, Record.CrFC)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DrFC", SqlDbType.Decimal, 17, Record.DrFC)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NetFC", SqlDbType.Decimal, 17, Record.NetFC)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FC", SqlDbType.NVarChar, 10, IIf(Record.FC = "", Convert.DBNull, Record.FC))
          Cmd.Parameters.Add("@Return_ProjectGroupID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ProjectGroupID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_FinYear", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_FinYear").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_Quarter", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_Quarter").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_Revision", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_Revision").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_WorkOrderTypeID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_WorkOrderTypeID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_GLGroupID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_GLGroupID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ProjectGroupID = Cmd.Parameters("@Return_ProjectGroupID").Value
          Record.FinYear = Cmd.Parameters("@Return_FinYear").Value
          Record.Quarter = Cmd.Parameters("@Return_Quarter").Value
          Record.Revision = Cmd.Parameters("@Return_Revision").Value
          Record.WorkOrderTypeID = Cmd.Parameters("@Return_WorkOrderTypeID").Value
          Record.GLGroupID = Cmd.Parameters("@Return_GLGroupID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function costCSDataWOnGLGroupUpdate(ByVal Record As SIS.COST.costCSDataWOnGLGroup) As SIS.COST.costCSDataWOnGLGroup
      Dim _Rec As SIS.COST.costCSDataWOnGLGroup = SIS.COST.costCSDataWOnGLGroup.costCSDataWOnGLGroupGetByID(Record.ProjectGroupID, Record.FinYear, Record.Quarter, Record.Revision, Record.WorkOrderTypeID, Record.GLGroupID)
      With _Rec
        .CrAmount = Record.CrAmount
        .DrAmount = Record.DrAmount
        .Amount = Record.Amount
      End With
      Return SIS.COST.costCSDataWOnGLGroup.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.COST.costCSDataWOnGLGroup) As SIS.COST.costCSDataWOnGLGroup
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostCSDataWOnGLGroupUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectGroupID",SqlDbType.Int,11, Record.ProjectGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FinYear",SqlDbType.Int,11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_Quarter",SqlDbType.Int,11, Record.Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_Revision",SqlDbType.Int,11, Record.Revision)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_WorkOrderTypeID",SqlDbType.Int,11, Record.WorkOrderTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_GLGroupID",SqlDbType.Int,11, Record.GLGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectGroupID",SqlDbType.Int,11, Record.ProjectGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quarter",SqlDbType.Int,11, Record.Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Revision",SqlDbType.Int,11, Record.Revision)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WorkOrderTypeID",SqlDbType.Int,11, Record.WorkOrderTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GLGroupID",SqlDbType.Int,11, Record.GLGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CrAmount",SqlDbType.Decimal,17, Record.CrAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DrAmount",SqlDbType.Decimal,17, Record.DrAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Amount",SqlDbType.Decimal,17, Record.Amount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CrFC", SqlDbType.Decimal, 17, Record.CrFC)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DrFC", SqlDbType.Decimal, 17, Record.DrFC)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NetFC", SqlDbType.Decimal, 17, Record.NetFC)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FC", SqlDbType.NVarChar, 10, IIf(Record.FC = "", Convert.DBNull, Record.FC))
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
    Public Shared Function costCSDataWOnGLGroupDelete(ByVal Record As SIS.COST.costCSDataWOnGLGroup) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spcostCSDataWOnGLGroupDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectGroupID",SqlDbType.Int,Record.ProjectGroupID.ToString.Length, Record.ProjectGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FinYear",SqlDbType.Int,Record.FinYear.ToString.Length, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_Quarter",SqlDbType.Int,Record.Quarter.ToString.Length, Record.Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_Revision",SqlDbType.Int,Record.Revision.ToString.Length, Record.Revision)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_WorkOrderTypeID",SqlDbType.Int,Record.WorkOrderTypeID.ToString.Length, Record.WorkOrderTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_GLGroupID",SqlDbType.Int,Record.GLGroupID.ToString.Length, Record.GLGroupID)
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
