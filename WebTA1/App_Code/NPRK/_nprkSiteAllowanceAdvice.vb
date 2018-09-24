Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  <DataObject()> _
  Partial Public Class nprkSiteAllowanceAdvice
    Private Shared _RecordCount As Integer
    Private _FinYear As Int32 = 0
    Private _Quarter As Int32 = 0
    Private _AdviceNo As Int32 = 0
    Private _Remarks As String = ""
    Private _TotalAdviceAmount As String = "0.00"
    Private _StatusID As String = ""
    Private _AccountsRemarks As String = ""
    Private _CreatedOn As String = ""
    Private _CreatedBy As String = ""
    Private _VoucherType As String = ""
    Private _LockedOn As String = ""
    Private _ReceivedBy As String = ""
    Private _LockedBy As String = ""
    Private _ProcessedBy As String = ""
    Private _ERPCompany As String = ""
    Private _VoucherNo As String = ""
    Private _ProcessedOn As String = ""
    Private _ReceivedOn As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _aspnet_Users2_UserFullName As String = ""
    Private _aspnet_Users3_UserFullName As String = ""
    Private _aspnet_Users4_UserFullName As String = ""
    Private _COST_FinYear5_Descpription As String = ""
    Private _COST_Quarters6_Description As String = ""
    Private _PRK_SAAdviceStatus7_Description As String = ""
    Private _FK_PRK_SiteAllowanceAdvice_CreatedBy As SIS.TA.taWebUsers = Nothing
    Private _FK_PRK_SiteAllowanceAdvice_ReceivedBy As SIS.TA.taWebUsers = Nothing
    Private _FK_PRK_SiteAllowanceAdvice_ProcessedBy As SIS.TA.taWebUsers = Nothing
    Private _FK_PRK_SiteAllowanceAdvice_LockedBy As SIS.TA.taWebUsers = Nothing
    Private _FK_PRK_SiteAllowanceAdvice_FinYear As SIS.COST.costFinYear = Nothing
    Private _FK_PRK_SiteAllowanceAdvice_Quarter As SIS.COST.costQuarters = Nothing
    Private _FK_PRK_SiteAllowanceAdvice_StatusID As SIS.NPRK.nprkSAAdviceStatus = Nothing
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
    Public Property AdviceNo() As Int32
      Get
        Return _AdviceNo
      End Get
      Set(ByVal value As Int32)
        _AdviceNo = value
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
    Public Property TotalAdviceAmount() As String
      Get
        Return _TotalAdviceAmount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TotalAdviceAmount = "0.00"
         Else
           _TotalAdviceAmount = value
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
    Public Property AccountsRemarks() As String
      Get
        Return _AccountsRemarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AccountsRemarks = ""
         Else
           _AccountsRemarks = value
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
    Public Property VoucherType() As String
      Get
        Return _VoucherType
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VoucherType = ""
         Else
           _VoucherType = value
         End If
      End Set
    End Property
    Public Property LockedOn() As String
      Get
        If Not _LockedOn = String.Empty Then
          Return Convert.ToDateTime(_LockedOn).ToString("dd/MM/yyyy")
        End If
        Return _LockedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _LockedOn = ""
         Else
           _LockedOn = value
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
    Public Property LockedBy() As String
      Get
        Return _LockedBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _LockedBy = ""
         Else
           _LockedBy = value
         End If
      End Set
    End Property
    Public Property ProcessedBy() As String
      Get
        Return _ProcessedBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ProcessedBy = ""
         Else
           _ProcessedBy = value
         End If
      End Set
    End Property
    Public Property ERPCompany() As String
      Get
        Return _ERPCompany
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ERPCompany = ""
         Else
           _ERPCompany = value
         End If
      End Set
    End Property
    Public Property VoucherNo() As String
      Get
        Return _VoucherNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VoucherNo = ""
         Else
           _VoucherNo = value
         End If
      End Set
    End Property
    Public Property ProcessedOn() As String
      Get
        If Not _ProcessedOn = String.Empty Then
          Return Convert.ToDateTime(_ProcessedOn).ToString("dd/MM/yyyy")
        End If
        Return _ProcessedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ProcessedOn = ""
         Else
           _ProcessedOn = value
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
    Public Property aspnet_Users3_UserFullName() As String
      Get
        Return _aspnet_Users3_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users3_UserFullName = value
      End Set
    End Property
    Public Property aspnet_Users4_UserFullName() As String
      Get
        Return _aspnet_Users4_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users4_UserFullName = value
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
    Public Property PRK_SAAdviceStatus7_Description() As String
      Get
        Return _PRK_SAAdviceStatus7_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PRK_SAAdviceStatus7_Description = ""
         Else
           _PRK_SAAdviceStatus7_Description = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _Remarks.ToString.PadRight(250, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _FinYear & "|" & _Quarter & "|" & _AdviceNo
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
    Public Class PKnprkSiteAllowanceAdvice
      Private _FinYear As Int32 = 0
      Private _Quarter As Int32 = 0
      Private _AdviceNo As Int32 = 0
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
      Public Property AdviceNo() As Int32
        Get
          Return _AdviceNo
        End Get
        Set(ByVal value As Int32)
          _AdviceNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PRK_SiteAllowanceAdvice_CreatedBy() As SIS.TA.taWebUsers
      Get
        If _FK_PRK_SiteAllowanceAdvice_CreatedBy Is Nothing Then
          _FK_PRK_SiteAllowanceAdvice_CreatedBy = SIS.TA.taWebUsers.taWebUsersGetByID(_CreatedBy)
        End If
        Return _FK_PRK_SiteAllowanceAdvice_CreatedBy
      End Get
    End Property
    Public ReadOnly Property FK_PRK_SiteAllowanceAdvice_ReceivedBy() As SIS.TA.taWebUsers
      Get
        If _FK_PRK_SiteAllowanceAdvice_ReceivedBy Is Nothing Then
          _FK_PRK_SiteAllowanceAdvice_ReceivedBy = SIS.TA.taWebUsers.taWebUsersGetByID(_ReceivedBy)
        End If
        Return _FK_PRK_SiteAllowanceAdvice_ReceivedBy
      End Get
    End Property
    Public ReadOnly Property FK_PRK_SiteAllowanceAdvice_ProcessedBy() As SIS.TA.taWebUsers
      Get
        If _FK_PRK_SiteAllowanceAdvice_ProcessedBy Is Nothing Then
          _FK_PRK_SiteAllowanceAdvice_ProcessedBy = SIS.TA.taWebUsers.taWebUsersGetByID(_ProcessedBy)
        End If
        Return _FK_PRK_SiteAllowanceAdvice_ProcessedBy
      End Get
    End Property
    Public ReadOnly Property FK_PRK_SiteAllowanceAdvice_LockedBy() As SIS.TA.taWebUsers
      Get
        If _FK_PRK_SiteAllowanceAdvice_LockedBy Is Nothing Then
          _FK_PRK_SiteAllowanceAdvice_LockedBy = SIS.TA.taWebUsers.taWebUsersGetByID(_LockedBy)
        End If
        Return _FK_PRK_SiteAllowanceAdvice_LockedBy
      End Get
    End Property
    Public ReadOnly Property FK_PRK_SiteAllowanceAdvice_FinYear() As SIS.COST.costFinYear
      Get
        If _FK_PRK_SiteAllowanceAdvice_FinYear Is Nothing Then
          _FK_PRK_SiteAllowanceAdvice_FinYear = SIS.COST.costFinYear.costFinYearGetByID(_FinYear)
        End If
        Return _FK_PRK_SiteAllowanceAdvice_FinYear
      End Get
    End Property
    Public ReadOnly Property FK_PRK_SiteAllowanceAdvice_Quarter() As SIS.COST.costQuarters
      Get
        If _FK_PRK_SiteAllowanceAdvice_Quarter Is Nothing Then
          _FK_PRK_SiteAllowanceAdvice_Quarter = SIS.COST.costQuarters.costQuartersGetByID(_Quarter)
        End If
        Return _FK_PRK_SiteAllowanceAdvice_Quarter
      End Get
    End Property
    Public ReadOnly Property FK_PRK_SiteAllowanceAdvice_StatusID() As SIS.NPRK.nprkSAAdviceStatus
      Get
        If _FK_PRK_SiteAllowanceAdvice_StatusID Is Nothing Then
          _FK_PRK_SiteAllowanceAdvice_StatusID = SIS.NPRK.nprkSAAdviceStatus.nprkSAAdviceStatusGetByID(_StatusID)
        End If
        Return _FK_PRK_SiteAllowanceAdvice_StatusID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkSiteAllowanceAdviceSelectList(ByVal OrderBy As String) As List(Of SIS.NPRK.nprkSiteAllowanceAdvice)
      Dim Results As List(Of SIS.NPRK.nprkSiteAllowanceAdvice) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "AdviceNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkSiteAllowanceAdviceSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkSiteAllowanceAdvice)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkSiteAllowanceAdvice(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkSiteAllowanceAdviceGetNewRecord() As SIS.NPRK.nprkSiteAllowanceAdvice
      Return New SIS.NPRK.nprkSiteAllowanceAdvice()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkSiteAllowanceAdviceGetByID(ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal AdviceNo As Int32) As SIS.NPRK.nprkSiteAllowanceAdvice
      Dim Results As SIS.NPRK.nprkSiteAllowanceAdvice = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkSiteAllowanceAdviceSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,FinYear.ToString.Length, FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quarter",SqlDbType.Int,Quarter.ToString.Length, Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdviceNo",SqlDbType.Int,AdviceNo.ToString.Length, AdviceNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.NPRK.nprkSiteAllowanceAdvice(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkSiteAllowanceAdviceSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal StatusID As Int32) As List(Of SIS.NPRK.nprkSiteAllowanceAdvice)
      Dim Results As List(Of SIS.NPRK.nprkSiteAllowanceAdvice) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "AdviceNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprkSiteAllowanceAdviceSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprkSiteAllowanceAdviceSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FinYear",SqlDbType.Int,10, IIf(FinYear = Nothing, 0,FinYear))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_Quarter",SqlDbType.Int,10, IIf(Quarter = Nothing, 0,Quarter))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StatusID",SqlDbType.Int,10, IIf(StatusID = Nothing, 0,StatusID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkSiteAllowanceAdvice)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkSiteAllowanceAdvice(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function nprkSiteAllowanceAdviceSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal StatusID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkSiteAllowanceAdviceGetByID(ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal AdviceNo As Int32, ByVal Filter_FinYear As Int32, ByVal Filter_Quarter As Int32, ByVal Filter_StatusID As Int32) As SIS.NPRK.nprkSiteAllowanceAdvice
      Return nprkSiteAllowanceAdviceGetByID(FinYear, Quarter, AdviceNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function nprkSiteAllowanceAdviceInsert(ByVal Record As SIS.NPRK.nprkSiteAllowanceAdvice) As SIS.NPRK.nprkSiteAllowanceAdvice
      Dim _Rec As SIS.NPRK.nprkSiteAllowanceAdvice = SIS.NPRK.nprkSiteAllowanceAdvice.nprkSiteAllowanceAdviceGetNewRecord()
      With _Rec
        .FinYear = Record.FinYear
        .Quarter = Record.Quarter
        .Remarks = Record.Remarks
        .TotalAdviceAmount = 0.00
        .StatusID = saAdviceStates.Free
        .CreatedOn = Now
        .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
      End With
      Return SIS.NPRK.nprkSiteAllowanceAdvice.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.NPRK.nprkSiteAllowanceAdvice) As SIS.NPRK.nprkSiteAllowanceAdvice
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkSiteAllowanceAdviceInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quarter",SqlDbType.Int,11, Record.Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,251, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalAdviceAmount",SqlDbType.Decimal,21, Iif(Record.TotalAdviceAmount= "" ,Convert.DBNull, Record.TotalAdviceAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AccountsRemarks",SqlDbType.NVarChar,251, Iif(Record.AccountsRemarks= "" ,Convert.DBNull, Record.AccountsRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VoucherType",SqlDbType.NVarChar,6, Iif(Record.VoucherType= "" ,Convert.DBNull, Record.VoucherType))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LockedOn",SqlDbType.DateTime,21, Iif(Record.LockedOn= "" ,Convert.DBNull, Record.LockedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedBy",SqlDbType.NVarChar,9, Iif(Record.ReceivedBy= "" ,Convert.DBNull, Record.ReceivedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LockedBy",SqlDbType.NVarChar,9, Iif(Record.LockedBy= "" ,Convert.DBNull, Record.LockedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProcessedBy",SqlDbType.NVarChar,9, Iif(Record.ProcessedBy= "" ,Convert.DBNull, Record.ProcessedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ERPCompany",SqlDbType.NVarChar,6, Iif(Record.ERPCompany= "" ,Convert.DBNull, Record.ERPCompany))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VoucherNo",SqlDbType.NVarChar,11, Iif(Record.VoucherNo= "" ,Convert.DBNull, Record.VoucherNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProcessedOn",SqlDbType.DateTime,21, Iif(Record.ProcessedOn= "" ,Convert.DBNull, Record.ProcessedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedOn",SqlDbType.DateTime,21, Iif(Record.ReceivedOn= "" ,Convert.DBNull, Record.ReceivedOn))
          Cmd.Parameters.Add("@Return_FinYear", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_FinYear").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_Quarter", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_Quarter").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_AdviceNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_AdviceNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.FinYear = Cmd.Parameters("@Return_FinYear").Value
          Record.Quarter = Cmd.Parameters("@Return_Quarter").Value
          Record.AdviceNo = Cmd.Parameters("@Return_AdviceNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function nprkSiteAllowanceAdviceUpdate(ByVal Record As SIS.NPRK.nprkSiteAllowanceAdvice) As SIS.NPRK.nprkSiteAllowanceAdvice
      Dim _Rec As SIS.NPRK.nprkSiteAllowanceAdvice = SIS.NPRK.nprkSiteAllowanceAdvice.nprkSiteAllowanceAdviceGetByID(Record.FinYear, Record.Quarter, Record.AdviceNo)
      With _Rec
        .Remarks = Record.Remarks
      End With
      Return SIS.NPRK.nprkSiteAllowanceAdvice.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.NPRK.nprkSiteAllowanceAdvice) As SIS.NPRK.nprkSiteAllowanceAdvice
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkSiteAllowanceAdviceUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FinYear",SqlDbType.Int,11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_Quarter",SqlDbType.Int,11, Record.Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_AdviceNo",SqlDbType.Int,11, Record.AdviceNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quarter",SqlDbType.Int,11, Record.Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,251, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalAdviceAmount",SqlDbType.Decimal,21, Iif(Record.TotalAdviceAmount= "" ,Convert.DBNull, Record.TotalAdviceAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AccountsRemarks",SqlDbType.NVarChar,251, Iif(Record.AccountsRemarks= "" ,Convert.DBNull, Record.AccountsRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VoucherType",SqlDbType.NVarChar,6, Iif(Record.VoucherType= "" ,Convert.DBNull, Record.VoucherType))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LockedOn",SqlDbType.DateTime,21, Iif(Record.LockedOn= "" ,Convert.DBNull, Record.LockedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedBy",SqlDbType.NVarChar,9, Iif(Record.ReceivedBy= "" ,Convert.DBNull, Record.ReceivedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LockedBy",SqlDbType.NVarChar,9, Iif(Record.LockedBy= "" ,Convert.DBNull, Record.LockedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProcessedBy",SqlDbType.NVarChar,9, Iif(Record.ProcessedBy= "" ,Convert.DBNull, Record.ProcessedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ERPCompany",SqlDbType.NVarChar,6, Iif(Record.ERPCompany= "" ,Convert.DBNull, Record.ERPCompany))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VoucherNo",SqlDbType.NVarChar,11, Iif(Record.VoucherNo= "" ,Convert.DBNull, Record.VoucherNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProcessedOn",SqlDbType.DateTime,21, Iif(Record.ProcessedOn= "" ,Convert.DBNull, Record.ProcessedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedOn",SqlDbType.DateTime,21, Iif(Record.ReceivedOn= "" ,Convert.DBNull, Record.ReceivedOn))
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
    Public Shared Function nprkSiteAllowanceAdviceDelete(ByVal Record As SIS.NPRK.nprkSiteAllowanceAdvice) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkSiteAllowanceAdviceDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FinYear",SqlDbType.Int,Record.FinYear.ToString.Length, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_Quarter",SqlDbType.Int,Record.Quarter.ToString.Length, Record.Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_AdviceNo",SqlDbType.Int,Record.AdviceNo.ToString.Length, Record.AdviceNo)
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
    Public Shared Function SelectnprkSiteAllowanceAdviceAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkSiteAllowanceAdviceAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(250, " "),"" & "|" & "" & "|" & ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.NPRK.nprkSiteAllowanceAdvice = New SIS.NPRK.nprkSiteAllowanceAdvice(Reader)
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
