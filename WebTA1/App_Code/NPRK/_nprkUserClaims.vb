Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel

Namespace SIS.NPRK
  <DataObject()> _
  Partial Public Class nprkUserClaims
    Private Shared _RecordCount As Integer
    Private _ClaimID As Int32 = 0
    Private _Description As String = ""
    Private _CardNo As String = ""
    Private _PassedAmount As Decimal = 0
    Private _TotalAmount As Decimal = 0
    Private _DeclarationAccepted As Boolean = False
    Private _SubmittedOn As String = ""
    Private _ReceivedOn As String = ""
    Private _ReceivedBy As String = ""
    Private _ReturnedOn As String = ""
    Private _ReturnedBy As String = ""
    Private _CompletedOn As String = ""
    Private _AccountsRemarks As String = ""
    Private _ClaimStatusID As String = ""
    Private _ClaimRefNo As String = ""
    Private _FinYear As String = ""
    Private _forRef As String = ""

    Private _PRK_ClaimStatus4_Description As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _aspnet_Users2_UserFullName As String = ""
    Private _aspnet_Users3_UserFullName As String = ""
    Private _PRK_FinYears5_Description As String = ""
    Private _FK_PRK_UserClaims_ClaimStatusID As SIS.NPRK.nprkClaimStatus = Nothing
    Private _FK_PRK_UserClaims_CardNo As SIS.TA.taWebUsers = Nothing
    Private _FK_PRK_UserClaims_ReceivedBy As SIS.TA.taWebUsers = Nothing
    Private _FK_PRK_UserClaims_ReturnedBy As SIS.TA.taWebUsers = Nothing
    Private _FK_PRK_UserClaims_FinYear As SIS.NPRK.nprkFinYears = Nothing

    Public Property VerifiedBy As String = ""
    Public Property VerifiedOn As String = ""

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
    Public Property ClaimID() As Int32
      Get
        Return _ClaimID
      End Get
      Set(ByVal value As Int32)
        _ClaimID = value
      End Set
    End Property
    Public Property Description() As String
      Get
        Return _Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Description = ""
         Else
           _Description = value
         End If
      End Set
    End Property
    Public Property CardNo() As String
      Get
        Return _CardNo
      End Get
      Set(ByVal value As String)
        _CardNo = value
      End Set
    End Property
    Public Property PassedAmount() As Decimal
      Get
        Return _PassedAmount
      End Get
      Set(ByVal value As Decimal)
        _PassedAmount = value
      End Set
    End Property
    Public Property TotalAmount() As Decimal
      Get
        Return _TotalAmount
      End Get
      Set(ByVal value As Decimal)
        _TotalAmount = value
      End Set
    End Property
    Public Property DeclarationAccepted() As Boolean
      Get
        Return _DeclarationAccepted
      End Get
      Set(ByVal value As Boolean)
        _DeclarationAccepted = value
      End Set
    End Property
    Public Property SubmittedOn() As String
      Get
        If Not _SubmittedOn = String.Empty Then
          Return Convert.ToDateTime(_SubmittedOn).ToString("dd/MM/yyyy")
        End If
        Return _SubmittedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SubmittedOn = ""
         Else
           _SubmittedOn = value
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
    Public Property ReturnedOn() As String
      Get
        If Not _ReturnedOn = String.Empty Then
          Return Convert.ToDateTime(_ReturnedOn).ToString("dd/MM/yyyy")
        End If
        Return _ReturnedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ReturnedOn = ""
         Else
           _ReturnedOn = value
         End If
      End Set
    End Property
    Public Property ReturnedBy() As String
      Get
        Return _ReturnedBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ReturnedBy = ""
         Else
           _ReturnedBy = value
         End If
      End Set
    End Property
    Public Property CompletedOn() As String
      Get
        If Not _CompletedOn = String.Empty Then
          Return Convert.ToDateTime(_CompletedOn).ToString("dd/MM/yyyy")
        End If
        Return _CompletedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CompletedOn = ""
         Else
           _CompletedOn = value
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
    Public Property ClaimStatusID() As String
      Get
        Return _ClaimStatusID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ClaimStatusID = ""
         Else
           _ClaimStatusID = value
         End If
      End Set
    End Property
    Public Property ClaimRefNo() As String
      Get
        Return _ClaimRefNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ClaimRefNo = ""
         Else
           _ClaimRefNo = value
         End If
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
    Public Property forRef() As String
      Get
        Return _forRef
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _forRef = ""
         Else
           _forRef = value
         End If
      End Set
    End Property
    Public Property PRK_ClaimStatus4_Description() As String
      Get
        Return _PRK_ClaimStatus4_Description
      End Get
      Set(ByVal value As String)
        _PRK_ClaimStatus4_Description = value
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
    Public Property PRK_FinYears5_Description() As String
      Get
        Return _PRK_FinYears5_Description
      End Get
      Set(ByVal value As String)
        _PRK_FinYears5_Description = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _Description.ToString.PadRight(250, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _ClaimID
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
    Public Class PKnprkUserClaims
      Private _ClaimID As Int32 = 0
      Public Property ClaimID() As Int32
        Get
          Return _ClaimID
        End Get
        Set(ByVal value As Int32)
          _ClaimID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PRK_UserClaims_ClaimStatusID() As SIS.NPRK.nprkClaimStatus
      Get
        If _FK_PRK_UserClaims_ClaimStatusID Is Nothing Then
          _FK_PRK_UserClaims_ClaimStatusID = SIS.NPRK.nprkClaimStatus.nprkClaimStatusGetByID(_ClaimStatusID)
        End If
        Return _FK_PRK_UserClaims_ClaimStatusID
      End Get
    End Property
    Public ReadOnly Property FK_PRK_UserClaims_CardNo() As SIS.TA.taWebUsers
      Get
        If _FK_PRK_UserClaims_CardNo Is Nothing Then
          _FK_PRK_UserClaims_CardNo = SIS.TA.taWebUsers.taWebUsersGetByID(_CardNo)
        End If
        Return _FK_PRK_UserClaims_CardNo
      End Get
    End Property
    Public ReadOnly Property FK_PRK_UserClaims_ReceivedBy() As SIS.TA.taWebUsers
      Get
        If _FK_PRK_UserClaims_ReceivedBy Is Nothing Then
          _FK_PRK_UserClaims_ReceivedBy = SIS.TA.taWebUsers.taWebUsersGetByID(_ReceivedBy)
        End If
        Return _FK_PRK_UserClaims_ReceivedBy
      End Get
    End Property
    Public ReadOnly Property FK_PRK_UserClaims_ReturnedBy() As SIS.TA.taWebUsers
      Get
        If _FK_PRK_UserClaims_ReturnedBy Is Nothing Then
          _FK_PRK_UserClaims_ReturnedBy = SIS.TA.taWebUsers.taWebUsersGetByID(_ReturnedBy)
        End If
        Return _FK_PRK_UserClaims_ReturnedBy
      End Get
    End Property
    Public ReadOnly Property FK_PRK_UserClaims_FinYear() As SIS.NPRK.nprkFinYears
      Get
        If _FK_PRK_UserClaims_FinYear Is Nothing Then
          _FK_PRK_UserClaims_FinYear = SIS.NPRK.nprkFinYears.nprkFinYearsGetByID(_FinYear)
        End If
        Return _FK_PRK_UserClaims_FinYear
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkUserClaimsSelectList(ByVal OrderBy As String) As List(Of SIS.NPRK.nprkUserClaims)
      Dim Results As List(Of SIS.NPRK.nprkUserClaims) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "ClaimID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkUserClaimsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkUserClaims)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkUserClaims(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkUserClaimsGetNewRecord() As SIS.NPRK.nprkUserClaims
      Return New SIS.NPRK.nprkUserClaims()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkUserClaimsGetByID(ByVal ClaimID As Int32) As SIS.NPRK.nprkUserClaims
      Dim Results As SIS.NPRK.nprkUserClaims = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkUserClaimsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClaimID",SqlDbType.Int,ClaimID.ToString.Length, ClaimID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.NPRK.nprkUserClaims(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkUserClaimsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ClaimStatusID As Int32) As List(Of SIS.NPRK.nprkUserClaims)
      Dim Results As List(Of SIS.NPRK.nprkUserClaims) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "ClaimID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprkUserClaimsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprkUserClaimsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ClaimStatusID",SqlDbType.Int,10, IIf(ClaimStatusID = Nothing, 0,ClaimStatusID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkUserClaims)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkUserClaims(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function nprkUserClaimsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ClaimStatusID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkUserClaimsGetByID(ByVal ClaimID As Int32, ByVal Filter_ClaimStatusID As Int32) As SIS.NPRK.nprkUserClaims
      Return nprkUserClaimsGetByID(ClaimID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function nprkUserClaimsInsert(ByVal Record As SIS.NPRK.nprkUserClaims) As SIS.NPRK.nprkUserClaims
      Dim _Rec As SIS.NPRK.nprkUserClaims = SIS.NPRK.nprkUserClaims.nprkUserClaimsGetNewRecord()
      With _Rec
        .forRef = Record.forRef
        .Description = Record.Description
        .CardNo = Global.System.Web.HttpContext.Current.Session("LoginID")
        .PassedAmount = Record.PassedAmount
        .TotalAmount = Record.TotalAmount
        .DeclarationAccepted = Record.DeclarationAccepted
        .SubmittedOn = Record.SubmittedOn
        .ReceivedOn = Record.ReceivedOn
        .ReceivedBy = Record.ReceivedBy
        .ReturnedOn = Record.ReturnedOn
        .ReturnedBy = Record.ReturnedBy
        .CompletedOn = Record.CompletedOn
        .AccountsRemarks = Record.AccountsRemarks
        .ClaimStatusID = prkClaimStates.Free
        .ClaimRefNo = Record.ClaimRefNo
        .FinYear = Global.System.Web.HttpContext.Current.Session("FinYear")
      End With
      Return SIS.NPRK.nprkUserClaims.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.NPRK.nprkUserClaims) As SIS.NPRK.nprkUserClaims
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkUserClaimsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,251, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PassedAmount",SqlDbType.Decimal,15, Record.PassedAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalAmount",SqlDbType.Decimal,15, Record.TotalAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeclarationAccepted",SqlDbType.Bit,3, Record.DeclarationAccepted)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SubmittedOn",SqlDbType.DateTime,21, Iif(Record.SubmittedOn= "" ,Convert.DBNull, Record.SubmittedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedOn",SqlDbType.DateTime,21, Iif(Record.ReceivedOn= "" ,Convert.DBNull, Record.ReceivedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedBy",SqlDbType.NVarChar,9, Iif(Record.ReceivedBy= "" ,Convert.DBNull, Record.ReceivedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReturnedOn",SqlDbType.DateTime,21, Iif(Record.ReturnedOn= "" ,Convert.DBNull, Record.ReturnedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReturnedBy",SqlDbType.NVarChar,9, Iif(Record.ReturnedBy= "" ,Convert.DBNull, Record.ReturnedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CompletedOn",SqlDbType.DateTime,21, Iif(Record.CompletedOn= "" ,Convert.DBNull, Record.CompletedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AccountsRemarks",SqlDbType.NVarChar,251, Iif(Record.AccountsRemarks= "" ,Convert.DBNull, Record.AccountsRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClaimStatusID",SqlDbType.Int,11, Iif(Record.ClaimStatusID= "" ,Convert.DBNull, Record.ClaimStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClaimRefNo",SqlDbType.NVarChar,51, Iif(Record.ClaimRefNo= "" ,Convert.DBNull, Record.ClaimRefNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,11, Iif(Record.FinYear= "" ,Convert.DBNull, Record.FinYear))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@forRef",SqlDbType.Int,11, Iif(Record.forRef= "" ,Convert.DBNull, Record.forRef))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedOn", SqlDbType.DateTime, 21, IIf(Record.VerifiedOn = "", Convert.DBNull, Record.VerifiedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedBy", SqlDbType.NVarChar, 9, IIf(Record.VerifiedBy = "", Convert.DBNull, Record.VerifiedBy))
          Cmd.Parameters.Add("@Return_ClaimID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ClaimID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ClaimID = Cmd.Parameters("@Return_ClaimID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function nprkUserClaimsUpdate(ByVal Record As SIS.NPRK.nprkUserClaims) As SIS.NPRK.nprkUserClaims
      Dim _Rec As SIS.NPRK.nprkUserClaims = SIS.NPRK.nprkUserClaims.nprkUserClaimsGetByID(Record.ClaimID)
      With _Rec
        .Description = Record.Description
        .CardNo = Global.System.Web.HttpContext.Current.Session("LoginID")
        .PassedAmount = Record.PassedAmount
        .TotalAmount = Record.TotalAmount
        .DeclarationAccepted = Record.DeclarationAccepted
        .SubmittedOn = Record.SubmittedOn
        .ReceivedOn = Record.ReceivedOn
        .ReceivedBy = Record.ReceivedBy
        .ReturnedOn = Record.ReturnedOn
        .ReturnedBy = Record.ReturnedBy
        .CompletedOn = Record.CompletedOn
        .AccountsRemarks = Record.AccountsRemarks
        .ClaimStatusID = Record.ClaimStatusID
        .ClaimRefNo = Record.ClaimRefNo
        .FinYear = Global.System.Web.HttpContext.Current.Session("FinYear")
        '.forRef = Record.forRef
      End With
      Return SIS.NPRK.nprkUserClaims.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.NPRK.nprkUserClaims) As SIS.NPRK.nprkUserClaims
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkUserClaimsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ClaimID",SqlDbType.Int,11, Record.ClaimID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,251, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,9, Record.CardNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PassedAmount",SqlDbType.Decimal,15, Record.PassedAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalAmount",SqlDbType.Decimal,15, Record.TotalAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeclarationAccepted",SqlDbType.Bit,3, Record.DeclarationAccepted)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SubmittedOn",SqlDbType.DateTime,21, Iif(Record.SubmittedOn= "" ,Convert.DBNull, Record.SubmittedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedOn",SqlDbType.DateTime,21, Iif(Record.ReceivedOn= "" ,Convert.DBNull, Record.ReceivedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedBy",SqlDbType.NVarChar,9, Iif(Record.ReceivedBy= "" ,Convert.DBNull, Record.ReceivedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReturnedOn",SqlDbType.DateTime,21, Iif(Record.ReturnedOn= "" ,Convert.DBNull, Record.ReturnedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReturnedBy",SqlDbType.NVarChar,9, Iif(Record.ReturnedBy= "" ,Convert.DBNull, Record.ReturnedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CompletedOn",SqlDbType.DateTime,21, Iif(Record.CompletedOn= "" ,Convert.DBNull, Record.CompletedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AccountsRemarks",SqlDbType.NVarChar,251, Iif(Record.AccountsRemarks= "" ,Convert.DBNull, Record.AccountsRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClaimStatusID",SqlDbType.Int,11, Iif(Record.ClaimStatusID= "" ,Convert.DBNull, Record.ClaimStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClaimRefNo",SqlDbType.NVarChar,51, Iif(Record.ClaimRefNo= "" ,Convert.DBNull, Record.ClaimRefNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,11, Iif(Record.FinYear= "" ,Convert.DBNull, Record.FinYear))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@forRef",SqlDbType.Int,11, Iif(Record.forRef= "" ,Convert.DBNull, Record.forRef))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedOn", SqlDbType.DateTime, 21, IIf(Record.VerifiedOn = "", Convert.DBNull, Record.VerifiedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedBy", SqlDbType.NVarChar, 9, IIf(Record.VerifiedBy = "", Convert.DBNull, Record.VerifiedBy))
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
    Public Shared Function nprkUserClaimsDelete(ByVal Record As SIS.NPRK.nprkUserClaims) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkUserClaimsDelete"
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
    Public Shared Function SelectnprkUserClaimsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkUserClaimsAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo",SqlDbType.NVarChar,8, Global.System.Web.HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("FinYear"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(250, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.NPRK.nprkUserClaims = New SIS.NPRK.nprkUserClaims(Reader)
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
