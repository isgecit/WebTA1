Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  <DataObject()> _
  Partial Public Class nprkSiteAllowanceClaims
    Private Shared _RecordCount As Integer
    Private _FinYear As Int32 = 0
    Private _Quarter As Int32 = 0
    Private _Entitled1Days As String = "0.00"
    Private _Entitled2Days As String = "0.00"
    Private _Entitled3Days As String = "0.00"
    Private _Applied1Days As String = "0.00"
    Private _Applied2Days As String = "0.00"
    Private _Applied3Days As String = "0.00"
    Private _UserRemarks As String = ""
    Private _Entitled1Amount As String = "0.00"
    Private _Approved2Days As String = "0.00"
    Private _CreatedOn As String = ""
    Private _Approved1Days As String = "0.00"
    Private _TotalEntitledAmount As String = "0.00"
    Private _CreatedBy As String = ""
    Private _ApprovedBy As String = ""
    Private _AdviceNo As String = ""
    Private _ApprovedOn As String = ""
    Private _Approved3Days As String = "0.00"
    Private _Applied1Amount As String = "0.00"
    Private _TotalApprovedAmount As String = "0.00"
    Private _Entitled3Amount As String = "0.00"
    Private _Approved3Amount As String = "0.00"
    Private _ApproverRemarks As String = ""
    Private _TotalAppliedAmount As String = "0.00"
    Private _StatusID As String = ""
    Private _Approved2Amount As String = "0.00"
    Private _Applied3Amount As String = "0.00"
    Private _Linked As String = ""
    Private _EmployeeID As String = ""
    Private _Entitled2Amount As String = "0.00"
    Private _Approved1Amount As String = "0.00"
    Private _Applied2Amount As String = "0.00"
    Private _aspnet_Users1_UserFullName As String = ""
    Private _aspnet_Users2_UserFullName As String = ""
    Private _COST_FinYear3_Descpription As String = ""
    Private _COST_Quarters4_Description As String = ""
    Private _HRM_Employees5_EmployeeName As String = ""
    Private _PRK_SAClaimStatus6_Description As String = ""
    Private _PRK_SiteAllowanceAdvice7_Remarks As String = ""
    Private _FK_PRK_SiteAllowanceClaims_CreatedBy As SIS.TA.taWebUsers = Nothing
    Private _FK_PRK_SiteAllowanceClaims_ApprovedBy As SIS.TA.taWebUsers = Nothing
    Private _FK_PRK_SiteAllowanceClaims_FinYear As SIS.COST.costFinYear = Nothing
    Private _FK_PRK_SiteAllowanceClaims_Quarter As SIS.COST.costQuarters = Nothing
    Private _FK_PRK_SiteAllowanceClaims_EmployeeID As SIS.TA.taEmployees = Nothing
    Private _FK_PRK_SiteAllowanceClaims_StatusID As SIS.NPRK.nprkSAClaimStatus = Nothing
    Private _FK_PRK_SiteAllowanceClaims_AdviceNo As SIS.NPRK.nprkSiteAllowanceAdvice = Nothing
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
    Public Property Entitled1Days() As String
      Get
        Return _Entitled1Days
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Entitled1Days = "0.00"
         Else
           _Entitled1Days = value
         End If
      End Set
    End Property
    Public Property Entitled2Days() As String
      Get
        Return _Entitled2Days
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Entitled2Days = "0.00"
         Else
           _Entitled2Days = value
         End If
      End Set
    End Property
    Public Property Entitled3Days() As String
      Get
        Return _Entitled3Days
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Entitled3Days = "0.00"
         Else
           _Entitled3Days = value
         End If
      End Set
    End Property
    Public Property Applied1Days() As String
      Get
        Return _Applied1Days
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Applied1Days = "0.00"
         Else
           _Applied1Days = value
         End If
      End Set
    End Property
    Public Property Applied2Days() As String
      Get
        Return _Applied2Days
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Applied2Days = "0.00"
         Else
           _Applied2Days = value
         End If
      End Set
    End Property
    Public Property Applied3Days() As String
      Get
        Return _Applied3Days
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Applied3Days = "0.00"
         Else
           _Applied3Days = value
         End If
      End Set
    End Property
    Public Property UserRemarks() As String
      Get
        Return _UserRemarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _UserRemarks = ""
         Else
           _UserRemarks = value
         End If
      End Set
    End Property
    Public Property Entitled1Amount() As String
      Get
        Return _Entitled1Amount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Entitled1Amount = "0.00"
         Else
           _Entitled1Amount = value
         End If
      End Set
    End Property
    Public Property Approved2Days() As String
      Get
        Return _Approved2Days
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Approved2Days = "0.00"
         Else
           _Approved2Days = value
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
    Public Property Approved1Days() As String
      Get
        Return _Approved1Days
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Approved1Days = "0.00"
         Else
           _Approved1Days = value
         End If
      End Set
    End Property
    Public Property TotalEntitledAmount() As String
      Get
        Return _TotalEntitledAmount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TotalEntitledAmount = "0.00"
         Else
           _TotalEntitledAmount = value
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
    Public Property AdviceNo() As String
      Get
        Return _AdviceNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AdviceNo = ""
         Else
           _AdviceNo = value
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
    Public Property Approved3Days() As String
      Get
        Return _Approved3Days
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Approved3Days = "0.00"
         Else
           _Approved3Days = value
         End If
      End Set
    End Property
    Public Property Applied1Amount() As String
      Get
        Return _Applied1Amount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Applied1Amount = "0.00"
         Else
           _Applied1Amount = value
         End If
      End Set
    End Property
    Public Property TotalApprovedAmount() As String
      Get
        Return _TotalApprovedAmount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TotalApprovedAmount = "0.00"
         Else
           _TotalApprovedAmount = value
         End If
      End Set
    End Property
    Public Property Entitled3Amount() As String
      Get
        Return _Entitled3Amount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Entitled3Amount = "0.00"
         Else
           _Entitled3Amount = value
         End If
      End Set
    End Property
    Public Property Approved3Amount() As String
      Get
        Return _Approved3Amount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Approved3Amount = "0.00"
         Else
           _Approved3Amount = value
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
    Public Property TotalAppliedAmount() As String
      Get
        Return _TotalAppliedAmount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TotalAppliedAmount = "0.00"
         Else
           _TotalAppliedAmount = value
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
    Public Property Approved2Amount() As String
      Get
        Return _Approved2Amount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Approved2Amount = "0.00"
         Else
           _Approved2Amount = value
         End If
      End Set
    End Property
    Public Property Applied3Amount() As String
      Get
        Return _Applied3Amount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Applied3Amount = "0.00"
         Else
           _Applied3Amount = value
         End If
      End Set
    End Property
    Public Property Linked() As String
      Get
        Return _Linked
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Linked = ""
         Else
           _Linked = value
         End If
      End Set
    End Property
    Public Property EmployeeID() As String
      Get
        Return _EmployeeID
      End Get
      Set(ByVal value As String)
        _EmployeeID = value
      End Set
    End Property
    Public Property Entitled2Amount() As String
      Get
        Return _Entitled2Amount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Entitled2Amount = "0.00"
         Else
           _Entitled2Amount = value
         End If
      End Set
    End Property
    Public Property Approved1Amount() As String
      Get
        Return _Approved1Amount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Approved1Amount = "0.00"
         Else
           _Approved1Amount = value
         End If
      End Set
    End Property
    Public Property Applied2Amount() As String
      Get
        Return _Applied2Amount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Applied2Amount = "0.00"
         Else
           _Applied2Amount = value
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
    Public Property HRM_Employees5_EmployeeName() As String
      Get
        Return _HRM_Employees5_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees5_EmployeeName = value
      End Set
    End Property
    Public Property PRK_SAClaimStatus6_Description() As String
      Get
        Return _PRK_SAClaimStatus6_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PRK_SAClaimStatus6_Description = ""
         Else
           _PRK_SAClaimStatus6_Description = value
         End If
      End Set
    End Property
    Public Property PRK_SiteAllowanceAdvice7_Remarks() As String
      Get
        Return _PRK_SiteAllowanceAdvice7_Remarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PRK_SiteAllowanceAdvice7_Remarks = ""
         Else
           _PRK_SiteAllowanceAdvice7_Remarks = value
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
        Return _FinYear & "|" & _Quarter & "|" & _EmployeeID
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
    Public Class PKnprkSiteAllowanceClaims
      Private _FinYear As Int32 = 0
      Private _Quarter As Int32 = 0
      Private _EmployeeID As String = ""
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
      Public Property EmployeeID() As String
        Get
          Return _EmployeeID
        End Get
        Set(ByVal value As String)
          _EmployeeID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PRK_SiteAllowanceClaims_CreatedBy() As SIS.TA.taWebUsers
      Get
        If _FK_PRK_SiteAllowanceClaims_CreatedBy Is Nothing Then
          _FK_PRK_SiteAllowanceClaims_CreatedBy = SIS.TA.taWebUsers.taWebUsersGetByID(_CreatedBy)
        End If
        Return _FK_PRK_SiteAllowanceClaims_CreatedBy
      End Get
    End Property
    Public ReadOnly Property FK_PRK_SiteAllowanceClaims_ApprovedBy() As SIS.TA.taWebUsers
      Get
        If _FK_PRK_SiteAllowanceClaims_ApprovedBy Is Nothing Then
          _FK_PRK_SiteAllowanceClaims_ApprovedBy = SIS.TA.taWebUsers.taWebUsersGetByID(_ApprovedBy)
        End If
        Return _FK_PRK_SiteAllowanceClaims_ApprovedBy
      End Get
    End Property
    Public ReadOnly Property FK_PRK_SiteAllowanceClaims_FinYear() As SIS.COST.costFinYear
      Get
        If _FK_PRK_SiteAllowanceClaims_FinYear Is Nothing Then
          _FK_PRK_SiteAllowanceClaims_FinYear = SIS.COST.costFinYear.costFinYearGetByID(_FinYear)
        End If
        Return _FK_PRK_SiteAllowanceClaims_FinYear
      End Get
    End Property
    Public ReadOnly Property FK_PRK_SiteAllowanceClaims_Quarter() As SIS.COST.costQuarters
      Get
        If _FK_PRK_SiteAllowanceClaims_Quarter Is Nothing Then
          _FK_PRK_SiteAllowanceClaims_Quarter = SIS.COST.costQuarters.costQuartersGetByID(_Quarter)
        End If
        Return _FK_PRK_SiteAllowanceClaims_Quarter
      End Get
    End Property
    Public ReadOnly Property FK_PRK_SiteAllowanceClaims_EmployeeID() As SIS.TA.taEmployees
      Get
        If _FK_PRK_SiteAllowanceClaims_EmployeeID Is Nothing Then
          _FK_PRK_SiteAllowanceClaims_EmployeeID = SIS.TA.taEmployees.taEmployeesGetByID(_EmployeeID)
        End If
        Return _FK_PRK_SiteAllowanceClaims_EmployeeID
      End Get
    End Property
    Public ReadOnly Property FK_PRK_SiteAllowanceClaims_StatusID() As SIS.NPRK.nprkSAClaimStatus
      Get
        If _FK_PRK_SiteAllowanceClaims_StatusID Is Nothing Then
          _FK_PRK_SiteAllowanceClaims_StatusID = SIS.NPRK.nprkSAClaimStatus.nprkSAClaimStatusGetByID(_StatusID)
        End If
        Return _FK_PRK_SiteAllowanceClaims_StatusID
      End Get
    End Property
    Public ReadOnly Property FK_PRK_SiteAllowanceClaims_AdviceNo() As SIS.NPRK.nprkSiteAllowanceAdvice
      Get
        If _FK_PRK_SiteAllowanceClaims_AdviceNo Is Nothing Then
          _FK_PRK_SiteAllowanceClaims_AdviceNo = SIS.NPRK.nprkSiteAllowanceAdvice.nprkSiteAllowanceAdviceGetByID(_FinYear, _Quarter, _AdviceNo)
        End If
        Return _FK_PRK_SiteAllowanceClaims_AdviceNo
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkSiteAllowanceClaimsGetNewRecord() As SIS.NPRK.nprkSiteAllowanceClaims
      Return New SIS.NPRK.nprkSiteAllowanceClaims()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkSiteAllowanceClaimsGetByID(ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal EmployeeID As String) As SIS.NPRK.nprkSiteAllowanceClaims
      Dim Results As SIS.NPRK.nprkSiteAllowanceClaims = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkSiteAllowanceClaimsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,FinYear.ToString.Length, FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quarter",SqlDbType.Int,Quarter.ToString.Length, Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.NVarChar,EmployeeID.ToString.Length, EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.NPRK.nprkSiteAllowanceClaims(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkSiteAllowanceClaimsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal FinYear As Int32, ByVal Quarter As Int32) As List(Of SIS.NPRK.nprkSiteAllowanceClaims)
      Dim Results As List(Of SIS.NPRK.nprkSiteAllowanceClaims) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprkSiteAllowanceClaimsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprkSiteAllowanceClaimsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FinYear",SqlDbType.Int,10, IIf(FinYear = Nothing, 0,FinYear))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_Quarter",SqlDbType.Int,10, IIf(Quarter = Nothing, 0,Quarter))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.NVarChar,8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkSiteAllowanceClaims)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkSiteAllowanceClaims(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function nprkSiteAllowanceClaimsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal FinYear As Int32, ByVal Quarter As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkSiteAllowanceClaimsGetByID(ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal EmployeeID As String, ByVal Filter_FinYear As Int32, ByVal Filter_Quarter As Int32) As SIS.NPRK.nprkSiteAllowanceClaims
      Return nprkSiteAllowanceClaimsGetByID(FinYear, Quarter, EmployeeID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function nprkSiteAllowanceClaimsInsert(ByVal Record As SIS.NPRK.nprkSiteAllowanceClaims) As SIS.NPRK.nprkSiteAllowanceClaims
      Dim _Rec As SIS.NPRK.nprkSiteAllowanceClaims = SIS.NPRK.nprkSiteAllowanceClaims.nprkSiteAllowanceClaimsGetNewRecord()
      With _Rec
        .FinYear = Record.FinYear
        .Quarter = Record.Quarter
        .Entitled1Days = Record.Entitled1Days
        .Entitled2Days = Record.Entitled2Days
        .Entitled3Days = Record.Entitled3Days
        .Applied1Days = Record.Applied1Days
        .Applied2Days = Record.Applied2Days
        .Applied3Days = Record.Applied3Days
        .UserRemarks = Record.UserRemarks
        .Entitled1Amount = Record.Entitled1Amount
        .Approved2Days = Record.Approved2Days
        .CreatedOn = Now
        .Approved1Days = Record.Approved1Days
        .TotalEntitledAmount = Record.TotalEntitledAmount
        .CreatedBy =  Global.System.Web.HttpContext.Current.Session("LoginID")
        .ApprovedBy = Record.ApprovedBy
        .AdviceNo = Record.AdviceNo
        .ApprovedOn = Record.ApprovedOn
        .Approved3Days = Record.Approved3Days
        .Applied1Amount = Record.Applied1Amount
        .TotalApprovedAmount = Record.TotalApprovedAmount
        .Entitled3Amount = Record.Entitled3Amount
        .Approved3Amount = Record.Approved3Amount
        .ApproverRemarks = Record.ApproverRemarks
        .TotalAppliedAmount = Record.TotalAppliedAmount
        .StatusID = saClaimStates.Free
        .Approved2Amount = Record.Approved2Amount
        .Applied3Amount = Record.Applied3Amount
        .Linked = Record.Linked
        .EmployeeID =  Global.System.Web.HttpContext.Current.Session("LoginID")
        .Entitled2Amount = Record.Entitled2Amount
        .Approved1Amount = Record.Approved1Amount
        .Applied2Amount = Record.Applied2Amount
      End With
      Return SIS.NPRK.nprkSiteAllowanceClaims.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.NPRK.nprkSiteAllowanceClaims) As SIS.NPRK.nprkSiteAllowanceClaims
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkSiteAllowanceClaimsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quarter",SqlDbType.Int,11, Record.Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Entitled1Days",SqlDbType.Decimal,9, Iif(Record.Entitled1Days= "" ,Convert.DBNull, Record.Entitled1Days))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Entitled2Days",SqlDbType.Decimal,9, Iif(Record.Entitled2Days= "" ,Convert.DBNull, Record.Entitled2Days))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Entitled3Days",SqlDbType.Decimal,9, Iif(Record.Entitled3Days= "" ,Convert.DBNull, Record.Entitled3Days))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Applied1Days",SqlDbType.Decimal,9, Iif(Record.Applied1Days= "" ,Convert.DBNull, Record.Applied1Days))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Applied2Days",SqlDbType.Decimal,9, Iif(Record.Applied2Days= "" ,Convert.DBNull, Record.Applied2Days))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Applied3Days",SqlDbType.Decimal,9, Iif(Record.Applied3Days= "" ,Convert.DBNull, Record.Applied3Days))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserRemarks",SqlDbType.NVarChar,101, Iif(Record.UserRemarks= "" ,Convert.DBNull, Record.UserRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Entitled1Amount",SqlDbType.Decimal,21, Iif(Record.Entitled1Amount= "" ,Convert.DBNull, Record.Entitled1Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Approved2Days",SqlDbType.Decimal,9, Iif(Record.Approved2Days= "" ,Convert.DBNull, Record.Approved2Days))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Approved1Days",SqlDbType.Decimal,9, Iif(Record.Approved1Days= "" ,Convert.DBNull, Record.Approved1Days))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalEntitledAmount",SqlDbType.Decimal,21, Iif(Record.TotalEntitledAmount= "" ,Convert.DBNull, Record.TotalEntitledAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy",SqlDbType.NVarChar,9, Iif(Record.ApprovedBy= "" ,Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdviceNo",SqlDbType.Int,11, Iif(Record.AdviceNo= "" ,Convert.DBNull, Record.AdviceNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedOn",SqlDbType.DateTime,21, Iif(Record.ApprovedOn= "" ,Convert.DBNull, Record.ApprovedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Approved3Days",SqlDbType.Decimal,9, Iif(Record.Approved3Days= "" ,Convert.DBNull, Record.Approved3Days))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Applied1Amount",SqlDbType.Decimal,21, Iif(Record.Applied1Amount= "" ,Convert.DBNull, Record.Applied1Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalApprovedAmount",SqlDbType.Decimal,21, Iif(Record.TotalApprovedAmount= "" ,Convert.DBNull, Record.TotalApprovedAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Entitled3Amount",SqlDbType.Decimal,21, Iif(Record.Entitled3Amount= "" ,Convert.DBNull, Record.Entitled3Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Approved3Amount",SqlDbType.Decimal,21, Iif(Record.Approved3Amount= "" ,Convert.DBNull, Record.Approved3Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApproverRemarks",SqlDbType.NVarChar,101, Iif(Record.ApproverRemarks= "" ,Convert.DBNull, Record.ApproverRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalAppliedAmount",SqlDbType.Decimal,21, Iif(Record.TotalAppliedAmount= "" ,Convert.DBNull, Record.TotalAppliedAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Approved2Amount",SqlDbType.Decimal,21, Iif(Record.Approved2Amount= "" ,Convert.DBNull, Record.Approved2Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Applied3Amount",SqlDbType.Decimal,21, Iif(Record.Applied3Amount= "" ,Convert.DBNull, Record.Applied3Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Linked",SqlDbType.Bit,3, Iif(Record.Linked= "" ,Convert.DBNull, Record.Linked))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.NVarChar,9, Record.EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Entitled2Amount",SqlDbType.Decimal,21, Iif(Record.Entitled2Amount= "" ,Convert.DBNull, Record.Entitled2Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Approved1Amount",SqlDbType.Decimal,21, Iif(Record.Approved1Amount= "" ,Convert.DBNull, Record.Approved1Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Applied2Amount",SqlDbType.Decimal,21, Iif(Record.Applied2Amount= "" ,Convert.DBNull, Record.Applied2Amount))
          Cmd.Parameters.Add("@Return_FinYear", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_FinYear").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_Quarter", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_Quarter").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_EmployeeID", SqlDbType.NVarChar, 9)
          Cmd.Parameters("@Return_EmployeeID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.FinYear = Cmd.Parameters("@Return_FinYear").Value
          Record.Quarter = Cmd.Parameters("@Return_Quarter").Value
          Record.EmployeeID = Cmd.Parameters("@Return_EmployeeID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function nprkSiteAllowanceClaimsUpdate(ByVal Record As SIS.NPRK.nprkSiteAllowanceClaims) As SIS.NPRK.nprkSiteAllowanceClaims
      Dim _Rec As SIS.NPRK.nprkSiteAllowanceClaims = SIS.NPRK.nprkSiteAllowanceClaims.nprkSiteAllowanceClaimsGetByID(Record.FinYear, Record.Quarter, Record.EmployeeID)
      With _Rec
        .Entitled1Days = Record.Entitled1Days
        .Entitled2Days = Record.Entitled2Days
        .Entitled3Days = Record.Entitled3Days
        .Applied1Days = Record.Applied1Days
        .Applied2Days = Record.Applied2Days
        .Applied3Days = Record.Applied3Days
        .Approved1Days = Record.Approved1Days
        .Approved2Days = Record.Approved2Days
        .Approved3Days = Record.Approved3Days
        .Entitled1Amount = Record.Entitled1Amount
        .Entitled2Amount = Record.Entitled2Amount
        .Entitled3Amount = Record.Entitled3Amount
        .Applied1Amount = Record.Applied1Amount
        .Applied2Amount = Record.Applied2Amount
        .Applied3Amount = Record.Applied3Amount
        .Approved1Amount = Record.Approved1Amount
        .Approved2Amount = Record.Approved2Amount
        .Approved3Amount = Record.Approved3Amount
        .UserRemarks = Record.UserRemarks
        .TotalEntitledAmount = Record.TotalEntitledAmount
        .TotalAppliedAmount = Record.TotalAppliedAmount
        .TotalApprovedAmount = Record.TotalApprovedAmount
        .CreatedOn = Now
        .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .ApproverRemarks = ""
        .StatusID = saClaimStates.Free
        .Linked = False
      End With
      Return SIS.NPRK.nprkSiteAllowanceClaims.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.NPRK.nprkSiteAllowanceClaims) As SIS.NPRK.nprkSiteAllowanceClaims
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkSiteAllowanceClaimsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FinYear",SqlDbType.Int,11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_Quarter",SqlDbType.Int,11, Record.Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_EmployeeID",SqlDbType.NVarChar,9, Record.EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quarter",SqlDbType.Int,11, Record.Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Entitled1Days",SqlDbType.Decimal,9, Iif(Record.Entitled1Days= "" ,Convert.DBNull, Record.Entitled1Days))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Entitled2Days",SqlDbType.Decimal,9, Iif(Record.Entitled2Days= "" ,Convert.DBNull, Record.Entitled2Days))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Entitled3Days",SqlDbType.Decimal,9, Iif(Record.Entitled3Days= "" ,Convert.DBNull, Record.Entitled3Days))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Applied1Days",SqlDbType.Decimal,9, Iif(Record.Applied1Days= "" ,Convert.DBNull, Record.Applied1Days))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Applied2Days",SqlDbType.Decimal,9, Iif(Record.Applied2Days= "" ,Convert.DBNull, Record.Applied2Days))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Applied3Days",SqlDbType.Decimal,9, Iif(Record.Applied3Days= "" ,Convert.DBNull, Record.Applied3Days))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserRemarks",SqlDbType.NVarChar,101, Iif(Record.UserRemarks= "" ,Convert.DBNull, Record.UserRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Entitled1Amount",SqlDbType.Decimal,21, Iif(Record.Entitled1Amount= "" ,Convert.DBNull, Record.Entitled1Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Approved2Days",SqlDbType.Decimal,9, Iif(Record.Approved2Days= "" ,Convert.DBNull, Record.Approved2Days))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Approved1Days",SqlDbType.Decimal,9, Iif(Record.Approved1Days= "" ,Convert.DBNull, Record.Approved1Days))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalEntitledAmount",SqlDbType.Decimal,21, Iif(Record.TotalEntitledAmount= "" ,Convert.DBNull, Record.TotalEntitledAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy",SqlDbType.NVarChar,9, Iif(Record.ApprovedBy= "" ,Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdviceNo",SqlDbType.Int,11, Iif(Record.AdviceNo= "" ,Convert.DBNull, Record.AdviceNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedOn",SqlDbType.DateTime,21, Iif(Record.ApprovedOn= "" ,Convert.DBNull, Record.ApprovedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Approved3Days",SqlDbType.Decimal,9, Iif(Record.Approved3Days= "" ,Convert.DBNull, Record.Approved3Days))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Applied1Amount",SqlDbType.Decimal,21, Iif(Record.Applied1Amount= "" ,Convert.DBNull, Record.Applied1Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalApprovedAmount",SqlDbType.Decimal,21, Iif(Record.TotalApprovedAmount= "" ,Convert.DBNull, Record.TotalApprovedAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Entitled3Amount",SqlDbType.Decimal,21, Iif(Record.Entitled3Amount= "" ,Convert.DBNull, Record.Entitled3Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Approved3Amount",SqlDbType.Decimal,21, Iif(Record.Approved3Amount= "" ,Convert.DBNull, Record.Approved3Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApproverRemarks",SqlDbType.NVarChar,101, Iif(Record.ApproverRemarks= "" ,Convert.DBNull, Record.ApproverRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalAppliedAmount",SqlDbType.Decimal,21, Iif(Record.TotalAppliedAmount= "" ,Convert.DBNull, Record.TotalAppliedAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Approved2Amount",SqlDbType.Decimal,21, Iif(Record.Approved2Amount= "" ,Convert.DBNull, Record.Approved2Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Applied3Amount",SqlDbType.Decimal,21, Iif(Record.Applied3Amount= "" ,Convert.DBNull, Record.Applied3Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Linked",SqlDbType.Bit,3, Iif(Record.Linked= "" ,Convert.DBNull, Record.Linked))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.NVarChar,9, Record.EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Entitled2Amount",SqlDbType.Decimal,21, Iif(Record.Entitled2Amount= "" ,Convert.DBNull, Record.Entitled2Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Approved1Amount",SqlDbType.Decimal,21, Iif(Record.Approved1Amount= "" ,Convert.DBNull, Record.Approved1Amount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Applied2Amount",SqlDbType.Decimal,21, Iif(Record.Applied2Amount= "" ,Convert.DBNull, Record.Applied2Amount))
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
    Public Shared Function nprkSiteAllowanceClaimsDelete(ByVal Record As SIS.NPRK.nprkSiteAllowanceClaims) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkSiteAllowanceClaimsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FinYear",SqlDbType.Int,Record.FinYear.ToString.Length, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_Quarter",SqlDbType.Int,Record.Quarter.ToString.Length, Record.Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_EmployeeID",SqlDbType.NVarChar,Record.EmployeeID.ToString.Length, Record.EmployeeID)
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
