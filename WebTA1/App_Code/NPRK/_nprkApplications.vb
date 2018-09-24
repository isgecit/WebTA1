Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  <DataObject()> _
  Partial Public Class nprkApplications
    Private Shared _RecordCount As Integer
    Private _PerkID As Int32 = 0
    Private _AppliedOn As String = ""
    Private _Value As Decimal = 0
    Private _VerifiedOn As String = ""
    Private _ApprovedOn As String = ""
    Private _PostedOn As String = ""
    Private _ApprovedAmt As Decimal = 0
    Private _StatusID As Int32 = 0
    Private _ApplicationID As Int32 = 0
    Private _UserRemark As String = ""
    Private _PostedInBaaN As Boolean = False
    Private _Applied As Boolean = False
    Private _EmployeeID As Int32 = 0
    Private _ClaimID As Int32 = 0
    Private _VerifiedAmt As Decimal = 0
    Private _FinYear As String = ""
    Private _VerifierRemark As String = ""
    Private _UpdatedOn As String = ""
    Private _ExcessClaimed As Boolean = False
    Private _Verified As Boolean = False
    Private _VerifiedBy As String = ""
    Private _ApproverRemark As String = ""
    Private _PaymentMethod As String = ""
    Private _UpdatedBy As String = ""
    Private _ApprovedBy As String = ""
    Private _UpdatedInLedger As Boolean = False
    Private _Documents As Boolean = False
    Private _VerifiedValue As Decimal = 0
    Private _Approved As Boolean = False
    Private _PostedBy As String = ""
    Private _Selected As Boolean = False
    Private _ApprovedValue As Decimal = 0
    Private _PRK_Employees1_EmployeeName As String = ""
    Private _PRK_Employees2_EmployeeName As String = ""
    Private _PRK_Employees3_EmployeeName As String = ""
    Private _PRK_Employees4_EmployeeName As String = ""
    Private _PRK_Employees5_EmployeeName As String = ""
    Private _PRK_FinYears6_Description As String = ""
    Private _PRK_Perks7_Description As String = ""
    Private _PRK_Status8_Description As String = ""
    Private _PRK_UserClaims9_Description As String = ""
    Private _FK_PRK_Applications_PRK_Employees As SIS.NPRK.nprkEmployees = Nothing
    Private _FK_PRK_Applications_PRK_Employees1 As SIS.NPRK.nprkEmployees = Nothing
    Private _FK_PRK_Applications_PRK_Employees2 As SIS.NPRK.nprkEmployees = Nothing
    Private _FK_PRK_Applications_PRK_Employees3 As SIS.NPRK.nprkEmployees = Nothing
    Private _FK_PRK_Applications_PRK_Employees4 As SIS.NPRK.nprkEmployees = Nothing
    Private _FK_PRK_Applications_PRK_FinYears As SIS.NPRK.nprkFinYears = Nothing
    Private _FK_PRK_Applications_PRK_Perks As SIS.NPRK.nprkPerks = Nothing
    Private _FK_PRK_Applications_PRK_Status As SIS.NPRK.nprkStatus = Nothing
    Private _FK_PRK_Applications_ClaimID As SIS.NPRK.nprkUserClaims = Nothing
    Public Property ReportAttached As Boolean = False
    Public Property ReportFileName As String = ""
    Public Property ReportDiskFile As String = ""
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
    Public Property PerkID() As Int32
      Get
        Return _PerkID
      End Get
      Set(ByVal value As Int32)
        _PerkID = value
      End Set
    End Property
    Public Property AppliedOn() As String
      Get
        If Not _AppliedOn = String.Empty Then
          Return Convert.ToDateTime(_AppliedOn).ToString("dd/MM/yyyy")
        End If
        Return _AppliedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AppliedOn = ""
         Else
           _AppliedOn = value
         End If
      End Set
    End Property
    Public Property Value() As Decimal
      Get
        Return _Value
      End Get
      Set(ByVal value As Decimal)
        _Value = value
      End Set
    End Property
    Public Property VerifiedOn() As String
      Get
        If Not _VerifiedOn = String.Empty Then
          Return Convert.ToDateTime(_VerifiedOn).ToString("dd/MM/yyyy")
        End If
        Return _VerifiedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VerifiedOn = ""
         Else
           _VerifiedOn = value
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
    Public Property PostedOn() As String
      Get
        If Not _PostedOn = String.Empty Then
          Return Convert.ToDateTime(_PostedOn).ToString("dd/MM/yyyy")
        End If
        Return _PostedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PostedOn = ""
         Else
           _PostedOn = value
         End If
      End Set
    End Property
    Public Property ApprovedAmt() As Decimal
      Get
        Return _ApprovedAmt
      End Get
      Set(ByVal value As Decimal)
        _ApprovedAmt = value
      End Set
    End Property
    Public Property StatusID() As Int32
      Get
        Return _StatusID
      End Get
      Set(ByVal value As Int32)
        _StatusID = value
      End Set
    End Property
    Public Property ApplicationID() As Int32
      Get
        Return _ApplicationID
      End Get
      Set(ByVal value As Int32)
        _ApplicationID = value
      End Set
    End Property
    Public Property UserRemark() As String
      Get
        Return _UserRemark
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _UserRemark = ""
         Else
           _UserRemark = value
         End If
      End Set
    End Property
    Public Property PostedInBaaN() As Boolean
      Get
        Return _PostedInBaaN
      End Get
      Set(ByVal value As Boolean)
        _PostedInBaaN = value
      End Set
    End Property
    Public Property Applied() As Boolean
      Get
        Return _Applied
      End Get
      Set(ByVal value As Boolean)
        _Applied = value
      End Set
    End Property
    Public Property EmployeeID() As Int32
      Get
        Return _EmployeeID
      End Get
      Set(ByVal value As Int32)
        _EmployeeID = value
      End Set
    End Property
    Public Property ClaimID() As Int32
      Get
        Return _ClaimID
      End Get
      Set(ByVal value As Int32)
        _ClaimID = value
      End Set
    End Property
    Public Property VerifiedAmt() As Decimal
      Get
        Return _VerifiedAmt
      End Get
      Set(ByVal value As Decimal)
        _VerifiedAmt = value
      End Set
    End Property
    Public Property FinYear() As String
      Get
        Return _FinYear
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _FinYear = ""
         Else
           _FinYear = value
         End If
      End Set
    End Property
    Public Property VerifierRemark() As String
      Get
        Return _VerifierRemark
      End Get
      Set(ByVal value As String)
        _VerifierRemark = value
      End Set
    End Property
    Public Property UpdatedOn() As String
      Get
        If Not _UpdatedOn = String.Empty Then
          Return Convert.ToDateTime(_UpdatedOn).ToString("dd/MM/yyyy")
        End If
        Return _UpdatedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _UpdatedOn = ""
         Else
           _UpdatedOn = value
         End If
      End Set
    End Property
    Public Property ExcessClaimed() As Boolean
      Get
        Return _ExcessClaimed
      End Get
      Set(ByVal value As Boolean)
        _ExcessClaimed = value
      End Set
    End Property
    Public Property Verified() As Boolean
      Get
        Return _Verified
      End Get
      Set(ByVal value As Boolean)
        _Verified = value
      End Set
    End Property
    Public Property VerifiedBy() As String
      Get
        Return _VerifiedBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VerifiedBy = ""
         Else
           _VerifiedBy = value
         End If
      End Set
    End Property
    Public Property ApproverRemark() As String
      Get
        Return _ApproverRemark
      End Get
      Set(ByVal value As String)
        _ApproverRemark = value
      End Set
    End Property
    Public Property PaymentMethod() As String
      Get
        Return _PaymentMethod
      End Get
      Set(ByVal value As String)
        _PaymentMethod = value
      End Set
    End Property
    Public Property UpdatedBy() As String
      Get
        Return _UpdatedBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _UpdatedBy = ""
         Else
           _UpdatedBy = value
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
    Public Property UpdatedInLedger() As Boolean
      Get
        Return _UpdatedInLedger
      End Get
      Set(ByVal value As Boolean)
        _UpdatedInLedger = value
      End Set
    End Property
    Public Property Documents() As Boolean
      Get
        Return _Documents
      End Get
      Set(ByVal value As Boolean)
        _Documents = value
      End Set
    End Property
    Public Property VerifiedValue() As Decimal
      Get
        Return _VerifiedValue
      End Get
      Set(ByVal value As Decimal)
        _VerifiedValue = value
      End Set
    End Property
    Public Property Approved() As Boolean
      Get
        Return _Approved
      End Get
      Set(ByVal value As Boolean)
        _Approved = value
      End Set
    End Property
    Public Property PostedBy() As String
      Get
        Return _PostedBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PostedBy = ""
         Else
           _PostedBy = value
         End If
      End Set
    End Property
    Public Property Selected() As Boolean
      Get
        Return _Selected
      End Get
      Set(ByVal value As Boolean)
        _Selected = value
      End Set
    End Property
    Public Property ApprovedValue() As Decimal
      Get
        Return _ApprovedValue
      End Get
      Set(ByVal value As Decimal)
        _ApprovedValue = value
      End Set
    End Property
    Public Property PRK_Employees1_EmployeeName() As String
      Get
        Return _PRK_Employees1_EmployeeName
      End Get
      Set(ByVal value As String)
        _PRK_Employees1_EmployeeName = value
      End Set
    End Property
    Public Property PRK_Employees2_EmployeeName() As String
      Get
        Return _PRK_Employees2_EmployeeName
      End Get
      Set(ByVal value As String)
        _PRK_Employees2_EmployeeName = value
      End Set
    End Property
    Public Property PRK_Employees3_EmployeeName() As String
      Get
        Return _PRK_Employees3_EmployeeName
      End Get
      Set(ByVal value As String)
        _PRK_Employees3_EmployeeName = value
      End Set
    End Property
    Public Property PRK_Employees4_EmployeeName() As String
      Get
        Return _PRK_Employees4_EmployeeName
      End Get
      Set(ByVal value As String)
        _PRK_Employees4_EmployeeName = value
      End Set
    End Property
    Public Property PRK_Employees5_EmployeeName() As String
      Get
        Return _PRK_Employees5_EmployeeName
      End Get
      Set(ByVal value As String)
        _PRK_Employees5_EmployeeName = value
      End Set
    End Property
    Public Property PRK_FinYears6_Description() As String
      Get
        Return _PRK_FinYears6_Description
      End Get
      Set(ByVal value As String)
        _PRK_FinYears6_Description = value
      End Set
    End Property
    Public Property PRK_Perks7_Description() As String
      Get
        Return _PRK_Perks7_Description
      End Get
      Set(ByVal value As String)
        _PRK_Perks7_Description = value
      End Set
    End Property
    Public Property PRK_Status8_Description() As String
      Get
        Return _PRK_Status8_Description
      End Get
      Set(ByVal value As String)
        _PRK_Status8_Description = value
      End Set
    End Property
    Public Property PRK_UserClaims9_Description() As String
      Get
        Return _PRK_UserClaims9_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PRK_UserClaims9_Description = ""
         Else
           _PRK_UserClaims9_Description = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _UserRemark.ToString.PadRight(200, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _ClaimID & "|" & _ApplicationID
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
    Public Class PKnprkApplications
      Private _ApplicationID As Int32 = 0
      Private _ClaimID As Int32 = 0
      Public Property ApplicationID() As Int32
        Get
          Return _ApplicationID
        End Get
        Set(ByVal value As Int32)
          _ApplicationID = value
        End Set
      End Property
      Public Property ClaimID() As Int32
        Get
          Return _ClaimID
        End Get
        Set(ByVal value As Int32)
          _ClaimID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PRK_Applications_PRK_Employees() As SIS.NPRK.nprkEmployees
      Get
        If _FK_PRK_Applications_PRK_Employees Is Nothing Then
          _FK_PRK_Applications_PRK_Employees = SIS.NPRK.nprkEmployees.nprkEmployeesGetByID(_EmployeeID)
        End If
        Return _FK_PRK_Applications_PRK_Employees
      End Get
    End Property
    Public ReadOnly Property FK_PRK_Applications_PRK_Employees1() As SIS.NPRK.nprkEmployees
      Get
        If _FK_PRK_Applications_PRK_Employees1 Is Nothing Then
          _FK_PRK_Applications_PRK_Employees1 = SIS.NPRK.nprkEmployees.nprkEmployeesGetByID(_ApprovedBy)
        End If
        Return _FK_PRK_Applications_PRK_Employees1
      End Get
    End Property
    Public ReadOnly Property FK_PRK_Applications_PRK_Employees2() As SIS.NPRK.nprkEmployees
      Get
        If _FK_PRK_Applications_PRK_Employees2 Is Nothing Then
          _FK_PRK_Applications_PRK_Employees2 = SIS.NPRK.nprkEmployees.nprkEmployeesGetByID(_VerifiedBy)
        End If
        Return _FK_PRK_Applications_PRK_Employees2
      End Get
    End Property
    Public ReadOnly Property FK_PRK_Applications_PRK_Employees3() As SIS.NPRK.nprkEmployees
      Get
        If _FK_PRK_Applications_PRK_Employees3 Is Nothing Then
          _FK_PRK_Applications_PRK_Employees3 = SIS.NPRK.nprkEmployees.nprkEmployeesGetByID(_UpdatedBy)
        End If
        Return _FK_PRK_Applications_PRK_Employees3
      End Get
    End Property
    Public ReadOnly Property FK_PRK_Applications_PRK_Employees4() As SIS.NPRK.nprkEmployees
      Get
        If _FK_PRK_Applications_PRK_Employees4 Is Nothing Then
          _FK_PRK_Applications_PRK_Employees4 = SIS.NPRK.nprkEmployees.nprkEmployeesGetByID(_PostedBy)
        End If
        Return _FK_PRK_Applications_PRK_Employees4
      End Get
    End Property
    Public ReadOnly Property FK_PRK_Applications_PRK_FinYears() As SIS.NPRK.nprkFinYears
      Get
        If _FK_PRK_Applications_PRK_FinYears Is Nothing Then
          _FK_PRK_Applications_PRK_FinYears = SIS.NPRK.nprkFinYears.nprkFinYearsGetByID(_FinYear)
        End If
        Return _FK_PRK_Applications_PRK_FinYears
      End Get
    End Property
    Public ReadOnly Property FK_PRK_Applications_PRK_Perks() As SIS.NPRK.nprkPerks
      Get
        If _FK_PRK_Applications_PRK_Perks Is Nothing Then
          _FK_PRK_Applications_PRK_Perks = SIS.NPRK.nprkPerks.nprkPerksGetByID(_PerkID)
        End If
        Return _FK_PRK_Applications_PRK_Perks
      End Get
    End Property
    Public ReadOnly Property FK_PRK_Applications_PRK_Status() As SIS.NPRK.nprkStatus
      Get
        If _FK_PRK_Applications_PRK_Status Is Nothing Then
          _FK_PRK_Applications_PRK_Status = SIS.NPRK.nprkStatus.nprkStatusGetByID(_StatusID)
        End If
        Return _FK_PRK_Applications_PRK_Status
      End Get
    End Property
    Public ReadOnly Property FK_PRK_Applications_ClaimID() As SIS.NPRK.nprkUserClaims
      Get
        If _FK_PRK_Applications_ClaimID Is Nothing Then
          _FK_PRK_Applications_ClaimID = SIS.NPRK.nprkUserClaims.nprkUserClaimsGetByID(_ClaimID)
        End If
        Return _FK_PRK_Applications_ClaimID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkApplicationsSelectList(ByVal OrderBy As String) As List(Of SIS.NPRK.nprkApplications)
      Dim Results As List(Of SIS.NPRK.nprkApplications) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "ApplicationID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkApplicationsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("LoginID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkApplications)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkApplications(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function nprkApplicationsGetNewRecord() As SIS.NPRK.nprkApplications
      Return New SIS.NPRK.nprkApplications()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function nprkApplicationsGetByID(ByVal ClaimID As Int32, ByVal ApplicationID As Int32) As SIS.NPRK.nprkApplications
      Dim Results As SIS.NPRK.nprkApplications = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkApplicationsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID", SqlDbType.Int, ApplicationID.ToString.Length, ApplicationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClaimID", SqlDbType.Int, ClaimID.ToString.Length, ClaimID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.NPRK.nprkApplications(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkApplicationsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ClaimID As Int32) As List(Of SIS.NPRK.nprkApplications)
      Dim Results As List(Of SIS.NPRK.nprkApplications) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "ApplicationID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprkApplicationsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprkApplicationsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ClaimID",SqlDbType.Int,10, IIf(ClaimID = Nothing, 0,ClaimID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("LoginID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkApplications)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkApplications(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function nprkApplicationsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ClaimID As Int32) As Integer
      Return _RecordCount
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function nprkApplicationsGetByID(ByVal ClaimID As Int32, ByVal ApplicationID As Int32, ByVal Filter_ClaimID As Int32) As SIS.NPRK.nprkApplications
      Return nprkApplicationsGetByID(ClaimID, ApplicationID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function nprkApplicationsInsert(ByVal Record As SIS.NPRK.nprkApplications) As SIS.NPRK.nprkApplications
      Dim _Rec As SIS.NPRK.nprkApplications = SIS.NPRK.nprkApplications.nprkApplicationsGetNewRecord()
      With _Rec
        .PerkID = Record.PerkID
        .AppliedOn = HttpContext.Current.Session("Today")
        .Value = Record.Value
        .VerifiedOn = Record.VerifiedOn
        .ApprovedOn = Record.ApprovedOn
        .PostedOn = Record.PostedOn
        .ApprovedAmt = Record.ApprovedAmt
        .StatusID = prkPerkStates.free
        .UserRemark = Record.UserRemark
        .PostedInBaaN = Record.PostedInBaaN
        .Applied = Record.Applied
        .EmployeeID = Global.System.Web.HttpContext.Current.Session("LoginID")
        .ClaimID = Record.ClaimID
        .VerifiedAmt = Record.VerifiedAmt
        .FinYear = Global.System.Web.HttpContext.Current.Session("FinYear")
        .VerifierRemark = Record.VerifierRemark
        .UpdatedOn = Record.UpdatedOn
        .ExcessClaimed = Record.ExcessClaimed
        .Verified = Record.Verified
        .VerifiedBy = Record.VerifiedBy
        .ApproverRemark = Record.ApproverRemark
        .PaymentMethod = Record.PaymentMethod
        .UpdatedBy = Record.UpdatedBy
        .ApprovedBy = Record.ApprovedBy
        .UpdatedInLedger = Record.UpdatedInLedger
        .Documents = Record.Documents
        .VerifiedValue = Record.VerifiedValue
        .Approved = Record.Approved
        .PostedBy = Record.PostedBy
        .Selected = Record.Selected
        .ApprovedValue = Record.ApprovedValue
        .ReportAttached = Record.ReportAttached
        .ReportDiskFile = Record.ReportDiskFile
        .ReportFileName = Record.ReportFileName
      End With
      'If Not Applyable(_Rec.EmployeeID, _Rec.PerkID, _Rec.FinYear) Then
      '  Throw New Exception("There is NO balance amount to claim.")
      'End If
      Return SIS.NPRK.nprkApplications.InsertData(_Rec)
    End Function
    Public Shared Function Applyable(ByVal EmpID As Integer, ByVal PerkID As Integer, ByVal FinYear As String) As Boolean
      Dim mRet As Boolean = False
      Select Case PerkID
        Case prkPerk.Mobile, prkPerk.Telephone
          mRet = True
        Case Else
          Dim tmpEnt As Decimal = SIS.NPRK.nprkEntitlements.GetNetValue(EmpID, PerkID, FinYear)
          Dim tmpLgr As Decimal = SIS.NPRK.nprkLedger.GetNetValue(EmpID, PerkID, FinYear)
          If tmpEnt - tmpLgr > 0 Then
            mRet = True
          End If
      End Select
      Return mRet
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.NPRK.nprkApplications) As SIS.NPRK.nprkApplications
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkApplicationsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PerkID", SqlDbType.Int, 11, Record.PerkID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AppliedOn", SqlDbType.DateTime, 21, IIf(Record.AppliedOn = "", Convert.DBNull, Record.AppliedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Value", SqlDbType.Decimal, 13, Record.Value)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedOn", SqlDbType.DateTime, 21, IIf(Record.VerifiedOn = "", Convert.DBNull, Record.VerifiedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedOn", SqlDbType.DateTime, 21, IIf(Record.ApprovedOn = "", Convert.DBNull, Record.ApprovedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedOn", SqlDbType.DateTime, 21, IIf(Record.PostedOn = "", Convert.DBNull, Record.PostedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedAmt", SqlDbType.Decimal, 13, Record.ApprovedAmt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID", SqlDbType.Int, 11, Record.StatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserRemark", SqlDbType.NVarChar, 201, IIf(Record.UserRemark = "", Convert.DBNull, Record.UserRemark))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedInBaaN", SqlDbType.Bit, 3, Record.PostedInBaaN)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Applied", SqlDbType.Bit, 3, Record.Applied)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.Int, 11, Record.EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClaimID", SqlDbType.Int, 11, Record.ClaimID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedAmt", SqlDbType.Decimal, 13, Record.VerifiedAmt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.Int, 11, IIf(Record.FinYear = "", Convert.DBNull, Record.FinYear))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifierRemark", SqlDbType.NVarChar, 101, Record.VerifierRemark)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UpdatedOn", SqlDbType.DateTime, 21, IIf(Record.UpdatedOn = "", Convert.DBNull, Record.UpdatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExcessClaimed", SqlDbType.Bit, 3, Record.ExcessClaimed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Verified", SqlDbType.Bit, 3, Record.Verified)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedBy", SqlDbType.Int, 11, IIf(Record.VerifiedBy = "", Convert.DBNull, Record.VerifiedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApproverRemark", SqlDbType.NVarChar, 101, Record.ApproverRemark)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PaymentMethod", SqlDbType.NVarChar, 21, Record.PaymentMethod)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UpdatedBy", SqlDbType.Int, 11, IIf(Record.UpdatedBy = "", Convert.DBNull, Record.UpdatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy", SqlDbType.Int, 11, IIf(Record.ApprovedBy = "", Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UpdatedInLedger", SqlDbType.Bit, 3, Record.UpdatedInLedger)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Documents", SqlDbType.Bit, 3, Record.Documents)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedValue", SqlDbType.Decimal, 13, Record.VerifiedValue)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Approved", SqlDbType.Bit, 3, Record.Approved)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedBy", SqlDbType.Int, 11, IIf(Record.PostedBy = "", Convert.DBNull, Record.PostedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Selected", SqlDbType.Bit, 3, Record.Selected)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedValue", SqlDbType.Decimal, 13, Record.ApprovedValue)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReportAttached", SqlDbType.Bit, 3, Record.ReportAttached)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReportDiskFile", SqlDbType.NVarChar, 251, IIf(Record.ReportDiskFile = "", Convert.DBNull, Record.ReportDiskFile))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReportFileName", SqlDbType.NVarChar, 101, IIf(Record.ReportFileName = "", Convert.DBNull, Record.ReportFileName))
          Cmd.Parameters.Add("@Return_ApplicationID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ApplicationID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_ClaimID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ClaimID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ApplicationID = Cmd.Parameters("@Return_ApplicationID").Value
          Record.ClaimID = Cmd.Parameters("@Return_ClaimID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function nprkApplicationsUpdate(ByVal Record As SIS.NPRK.nprkApplications) As SIS.NPRK.nprkApplications
      Dim _Rec As SIS.NPRK.nprkApplications = SIS.NPRK.nprkApplications.nprkApplicationsGetByID(Record.ClaimID, Record.ApplicationID)
      With _Rec
        .PerkID = Record.PerkID
        .AppliedOn = HttpContext.Current.Session("Today")
        .Value = Record.Value
        .VerifiedOn = Record.VerifiedOn
        .ApprovedOn = Record.ApprovedOn
        .PostedOn = Record.PostedOn
        .ApprovedAmt = Record.ApprovedAmt
        .StatusID = record.StatusID
        .UserRemark = Record.UserRemark
        .PostedInBaaN = Record.PostedInBaaN
        .Applied = Record.Applied
        .EmployeeID = Global.System.Web.HttpContext.Current.Session("LoginID")
        .VerifiedAmt = Record.VerifiedAmt
        .FinYear = Global.System.Web.HttpContext.Current.Session("FinYear")
        .VerifierRemark = Record.VerifierRemark
        .UpdatedOn = Record.UpdatedOn
        .ExcessClaimed = Record.ExcessClaimed
        .Verified = Record.Verified
        .VerifiedBy = Record.VerifiedBy
        .ApproverRemark = Record.ApproverRemark
        .PaymentMethod = Record.PaymentMethod
        .UpdatedBy = Record.UpdatedBy
        .ApprovedBy = Record.ApprovedBy
        .UpdatedInLedger = Record.UpdatedInLedger
        .Documents = Record.Documents
        .VerifiedValue = Record.VerifiedValue
        .Approved = Record.Approved
        .PostedBy = Record.PostedBy
        .Selected = Record.Selected
        .ApprovedValue = Record.ApprovedValue
        .ReportAttached = Record.ReportAttached
        .ReportDiskFile = Record.ReportDiskFile
        .ReportFileName = Record.ReportFileName
      End With
      'If Not Applyable(_Rec.EmployeeID, _Rec.PerkID, _Rec.FinYear) Then
      '  Throw New Exception("There is balance amount to claim.")
      'End If
      Return SIS.NPRK.nprkApplications.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.NPRK.nprkApplications) As SIS.NPRK.nprkApplications
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkApplicationsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ApplicationID",SqlDbType.Int,11, Record.ApplicationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ClaimID",SqlDbType.Int,11, Record.ClaimID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PerkID",SqlDbType.Int,11, Record.PerkID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AppliedOn",SqlDbType.DateTime,21, Iif(Record.AppliedOn= "" ,Convert.DBNull, Record.AppliedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Value",SqlDbType.Decimal,13, Record.Value)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedOn",SqlDbType.DateTime,21, Iif(Record.VerifiedOn= "" ,Convert.DBNull, Record.VerifiedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedOn",SqlDbType.DateTime,21, Iif(Record.ApprovedOn= "" ,Convert.DBNull, Record.ApprovedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedOn",SqlDbType.DateTime,21, Iif(Record.PostedOn= "" ,Convert.DBNull, Record.PostedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedAmt",SqlDbType.Decimal,13, Record.ApprovedAmt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Record.StatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserRemark",SqlDbType.NVarChar,201, Iif(Record.UserRemark= "" ,Convert.DBNull, Record.UserRemark))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedInBaaN",SqlDbType.Bit,3, Record.PostedInBaaN)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Applied",SqlDbType.Bit,3, Record.Applied)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.Int,11, Record.EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClaimID",SqlDbType.Int,11, Record.ClaimID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedAmt",SqlDbType.Decimal,13, Record.VerifiedAmt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,11, Iif(Record.FinYear= "" ,Convert.DBNull, Record.FinYear))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifierRemark",SqlDbType.NVarChar,101, Record.VerifierRemark)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UpdatedOn",SqlDbType.DateTime,21, Iif(Record.UpdatedOn= "" ,Convert.DBNull, Record.UpdatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExcessClaimed",SqlDbType.Bit,3, Record.ExcessClaimed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Verified",SqlDbType.Bit,3, Record.Verified)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedBy",SqlDbType.Int,11, Iif(Record.VerifiedBy= "" ,Convert.DBNull, Record.VerifiedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApproverRemark",SqlDbType.NVarChar,101, Record.ApproverRemark)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PaymentMethod",SqlDbType.NVarChar,21, Record.PaymentMethod)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UpdatedBy",SqlDbType.Int,11, Iif(Record.UpdatedBy= "" ,Convert.DBNull, Record.UpdatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy",SqlDbType.Int,11, Iif(Record.ApprovedBy= "" ,Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UpdatedInLedger",SqlDbType.Bit,3, Record.UpdatedInLedger)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Documents",SqlDbType.Bit,3, Record.Documents)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedValue",SqlDbType.Decimal,13, Record.VerifiedValue)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Approved",SqlDbType.Bit,3, Record.Approved)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedBy",SqlDbType.Int,11, Iif(Record.PostedBy= "" ,Convert.DBNull, Record.PostedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Selected",SqlDbType.Bit,3, Record.Selected)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedValue",SqlDbType.Decimal,13, Record.ApprovedValue)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReportAttached", SqlDbType.Bit, 3, Record.ReportAttached)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReportDiskFile", SqlDbType.NVarChar, 251, IIf(Record.ReportDiskFile = "", Convert.DBNull, Record.ReportDiskFile))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReportFileName", SqlDbType.NVarChar, 101, IIf(Record.ReportFileName = "", Convert.DBNull, Record.ReportFileName))
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
    Public Shared Function nprkApplicationsDelete(ByVal Record As SIS.NPRK.nprkApplications) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkApplicationsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ApplicationID",SqlDbType.Int,Record.ApplicationID.ToString.Length, Record.ApplicationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ClaimID",SqlDbType.Int,Record.ClaimID.ToString.Length, Record.ClaimID)
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
    Public Shared Function SelectnprkApplicationsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkApplicationsAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(200, " "),"" & "|" & ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.NPRK.nprkApplications = New SIS.NPRK.nprkApplications(Reader)
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
