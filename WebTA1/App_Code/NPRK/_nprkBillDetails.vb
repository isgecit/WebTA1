Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  <DataObject()>
  Partial Public Class nprkBillDetails
    Private Shared _RecordCount As Integer
    Private _BillNo As String = ""
    Private _BillDate As String = ""
    Private _FromDate As String = ""
    Private _ToDate As String = ""
    Private _Description As String = ""
    Private _Particulars As String = ""
    Private _Quantity As Decimal = 0
    Private _Amount As Decimal = 0
    Private _SerialNo As Int32 = 0
    Private _AttachmentID As Int32 = 0
    Private _ApplicationID As Int32 = 0
    Private _ClaimID As String = ""
    Public Property WithDriver As Boolean = False
    Public Property VerifiedByAdmin As Boolean = False
    Public Property EntitlementID As String = ""
    Public Property PerkID As String = ""
    Private _PRK_Applications2_UserRemark As String = ""
    Private _PRK_UserClaims1_Description As String = ""
    Private _FK_PRK_BillDetails_PRK_Applications As SIS.NPRK.nprkApplications = Nothing
    Private _FK_PRK_BillDetails_ClaimID As SIS.NPRK.nprkUserClaims = Nothing
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
    Public Property BillNo() As String
      Get
        Return _BillNo
      End Get
      Set(ByVal value As String)
        _BillNo = value
      End Set
    End Property
    Public Property BillDate() As String
      Get
        If Not _BillDate = String.Empty Then
          Return Convert.ToDateTime(_BillDate).ToString("dd/MM/yyyy")
        End If
        Return _BillDate
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _BillDate = ""
        Else
          _BillDate = value
        End If
      End Set
    End Property
    Public Property FromDate() As String
      Get
        If Not _FromDate = String.Empty Then
          Return Convert.ToDateTime(_FromDate).ToString("dd/MM/yyyy")
        End If
        Return _FromDate
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _FromDate = ""
        Else
          _FromDate = value
        End If
      End Set
    End Property
    Public Property ToDate() As String
      Get
        If Not _ToDate = String.Empty Then
          Return Convert.ToDateTime(_ToDate).ToString("dd/MM/yyyy")
        End If
        Return _ToDate
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ToDate = ""
        Else
          _ToDate = value
        End If
      End Set
    End Property
    Public Property Description() As String
      Get
        Return _Description
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _Description = ""
        Else
          _Description = value
        End If
      End Set
    End Property
    Public Property Particulars() As String
      Get
        Return _Particulars
      End Get
      Set(ByVal value As String)
        _Particulars = value
      End Set
    End Property
    Public Property Quantity() As Decimal
      Get
        Return _Quantity
      End Get
      Set(ByVal value As Decimal)
        _Quantity = value
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
    Public Property SerialNo() As Int32
      Get
        Return _SerialNo
      End Get
      Set(ByVal value As Int32)
        _SerialNo = value
      End Set
    End Property
    Public Property AttachmentID() As Int32
      Get
        Return _AttachmentID
      End Get
      Set(ByVal value As Int32)
        _AttachmentID = value
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
    Public Property ClaimID() As String
      Get
        Return _ClaimID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ClaimID = ""
        Else
          _ClaimID = value
        End If
      End Set
    End Property
    Public Property PRK_Applications2_UserRemark() As String
      Get
        Return _PRK_Applications2_UserRemark
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _PRK_Applications2_UserRemark = ""
        Else
          _PRK_Applications2_UserRemark = value
        End If
      End Set
    End Property
    Public Property PRK_UserClaims1_Description() As String
      Get
        Return _PRK_UserClaims1_Description
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _PRK_UserClaims1_Description = ""
        Else
          _PRK_UserClaims1_Description = value
        End If
      End Set
    End Property
    Public ReadOnly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public ReadOnly Property PrimaryKey() As String
      Get
        Return _ClaimID & "|" & _ApplicationID & "|" & _AttachmentID
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
    Public Class PKnprkBillDetails
      Private _ClaimID As Int32 = 0
      Private _ApplicationID As Int32 = 0
      Private _AttachmentID As Int32 = 0
      Public Property ClaimID() As Int32
        Get
          Return _ClaimID
        End Get
        Set(ByVal value As Int32)
          _ClaimID = value
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
      Public Property AttachmentID() As Int32
        Get
          Return _AttachmentID
        End Get
        Set(ByVal value As Int32)
          _AttachmentID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PRK_BillDetails_PRK_Applications() As SIS.NPRK.nprkApplications
      Get
        If _FK_PRK_BillDetails_PRK_Applications Is Nothing Then
          _FK_PRK_BillDetails_PRK_Applications = SIS.NPRK.nprkApplications.nprkApplicationsGetByID(_ClaimID, _ApplicationID)
        End If
        Return _FK_PRK_BillDetails_PRK_Applications
      End Get
    End Property
    Public ReadOnly Property FK_PRK_BillDetails_ClaimID() As SIS.NPRK.nprkUserClaims
      Get
        If _FK_PRK_BillDetails_ClaimID Is Nothing Then
          _FK_PRK_BillDetails_ClaimID = SIS.NPRK.nprkUserClaims.nprkUserClaimsGetByID(_ClaimID)
        End If
        Return _FK_PRK_BillDetails_ClaimID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function nprkBillDetailsGetNewRecord() As SIS.NPRK.nprkBillDetails
      Return New SIS.NPRK.nprkBillDetails()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function nprkBillDetailsGetByID(ByVal ClaimID As Int32, ByVal ApplicationID As Int32, ByVal AttachmentID As Int32) As SIS.NPRK.nprkBillDetails
      Dim Results As SIS.NPRK.nprkBillDetails = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkBillDetailsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClaimID", SqlDbType.Int, ClaimID.ToString.Length, ClaimID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID", SqlDbType.Int, ApplicationID.ToString.Length, ApplicationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AttachmentID", SqlDbType.Int, AttachmentID.ToString.Length, AttachmentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.NPRK.nprkBillDetails(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function nprkBillDetailsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ApplicationID As Int32, ByVal ClaimID As Int32) As List(Of SIS.NPRK.nprkBillDetails)
      Dim Results As List(Of SIS.NPRK.nprkBillDetails) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprkBillDetailsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprkBillDetailsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ApplicationID", SqlDbType.Int, 10, IIf(ApplicationID = Nothing, 0, ApplicationID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ClaimID", SqlDbType.Int, 10, IIf(ClaimID = Nothing, 0, ClaimID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkBillDetails)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkBillDetails(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function nprkBillDetailsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ApplicationID As Int32, ByVal ClaimID As Int32) As Integer
      Return _RecordCount
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function nprkBillDetailsGetByID(ByVal ClaimID As Int32, ByVal ApplicationID As Int32, ByVal AttachmentID As Int32, ByVal Filter_ApplicationID As Int32, ByVal Filter_ClaimID As Int32) As SIS.NPRK.nprkBillDetails
      Return nprkBillDetailsGetByID(ClaimID, ApplicationID, AttachmentID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)>
    Public Shared Function nprkBillDetailsInsert(ByVal Record As SIS.NPRK.nprkBillDetails) As SIS.NPRK.nprkBillDetails
      Dim _Rec As SIS.NPRK.nprkBillDetails = SIS.NPRK.nprkBillDetails.nprkBillDetailsGetNewRecord()
      With _Rec
        .BillNo = Record.BillNo
        .BillDate = Record.BillDate
        .FromDate = Record.FromDate
        .ToDate = Record.ToDate
        .Description = Record.Description
        .Particulars = Record.Particulars
        .Quantity = Record.Quantity
        .Amount = Record.Amount
        .SerialNo = 0
        .ApplicationID = Record.ApplicationID
        .ClaimID = Record.ClaimID
        .WithDriver = Record.WithDriver
        .VerifiedByAdmin = Record.VerifiedByAdmin
        .EntitlementID = Record.EntitlementID
        .PerkID = Record.PerkID
      End With
      Return SIS.NPRK.nprkBillDetails.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.NPRK.nprkBillDetails) As SIS.NPRK.nprkBillDetails
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkBillDetailsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillNo", SqlDbType.NVarChar, 21, Record.BillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillDate", SqlDbType.DateTime, 21, IIf(Record.BillDate = "", Convert.DBNull, Record.BillDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FromDate", SqlDbType.DateTime, 21, IIf(Record.FromDate = "", Convert.DBNull, Record.FromDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ToDate", SqlDbType.DateTime, 21, IIf(Record.ToDate = "", Convert.DBNull, Record.ToDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description", SqlDbType.NVarChar, 251, IIf(Record.Description = "", Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Particulars", SqlDbType.NVarChar, 251, Record.Particulars)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quantity", SqlDbType.Decimal, 21, Record.Quantity)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Amount", SqlDbType.Decimal, 21, Record.Amount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo", SqlDbType.Int, 11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID", SqlDbType.Int, 11, Record.ApplicationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClaimID", SqlDbType.Int, 11, IIf(Record.ClaimID = "", Convert.DBNull, Record.ClaimID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WithDriver", SqlDbType.Bit, 3, Record.WithDriver)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedByAdmin", SqlDbType.Bit, 3, Record.VerifiedByAdmin)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EntitlementID", SqlDbType.Int, 11, IIf(Record.EntitlementID = "", Convert.DBNull, Record.EntitlementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PerkID", SqlDbType.Int, 11, IIf(Record.PerkID = "", Convert.DBNull, Record.PerkID))
          Cmd.Parameters.Add("@Return_ClaimID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ClaimID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_ApplicationID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ApplicationID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_AttachmentID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_AttachmentID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ClaimID = Cmd.Parameters("@Return_ClaimID").Value
          Record.ApplicationID = Cmd.Parameters("@Return_ApplicationID").Value
          Record.AttachmentID = Cmd.Parameters("@Return_AttachmentID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)>
    Public Shared Function nprkBillDetailsUpdate(ByVal Record As SIS.NPRK.nprkBillDetails) As SIS.NPRK.nprkBillDetails
      Dim _Rec As SIS.NPRK.nprkBillDetails = SIS.NPRK.nprkBillDetails.nprkBillDetailsGetByID(Record.ClaimID, Record.ApplicationID, Record.AttachmentID)
      With _Rec
        .BillNo = Record.BillNo
        .BillDate = Record.BillDate
        .FromDate = Record.FromDate
        .ToDate = Record.ToDate
        .Description = Record.Description
        .Particulars = Record.Particulars
        .Quantity = Record.Quantity
        .Amount = Record.Amount
        .SerialNo = 0
        .WithDriver = Record.WithDriver
        .VerifiedByAdmin = Record.VerifiedByAdmin
        .EntitlementID = Record.EntitlementID
        .PerkID = Record.PerkID
      End With
      Return SIS.NPRK.nprkBillDetails.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.NPRK.nprkBillDetails) As SIS.NPRK.nprkBillDetails
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkBillDetailsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_AttachmentID", SqlDbType.Int, 11, Record.AttachmentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ApplicationID", SqlDbType.Int, 11, Record.ApplicationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ClaimID", SqlDbType.Int, 11, Record.ClaimID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillNo", SqlDbType.NVarChar, 21, Record.BillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillDate", SqlDbType.DateTime, 21, IIf(Record.BillDate = "", Convert.DBNull, Record.BillDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FromDate", SqlDbType.DateTime, 21, IIf(Record.FromDate = "", Convert.DBNull, Record.FromDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ToDate", SqlDbType.DateTime, 21, IIf(Record.ToDate = "", Convert.DBNull, Record.ToDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description", SqlDbType.NVarChar, 251, IIf(Record.Description = "", Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Particulars", SqlDbType.NVarChar, 251, Record.Particulars)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quantity", SqlDbType.Decimal, 21, Record.Quantity)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Amount", SqlDbType.Decimal, 21, Record.Amount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo", SqlDbType.Int, 11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID", SqlDbType.Int, 11, Record.ApplicationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClaimID", SqlDbType.Int, 11, IIf(Record.ClaimID = "", Convert.DBNull, Record.ClaimID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WithDriver", SqlDbType.Bit, 3, Record.WithDriver)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VerifiedByAdmin", SqlDbType.Bit, 3, Record.VerifiedByAdmin)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EntitlementID", SqlDbType.Int, 11, IIf(Record.EntitlementID = "", Convert.DBNull, Record.EntitlementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PerkID", SqlDbType.Int, 11, IIf(Record.PerkID = "", Convert.DBNull, Record.PerkID))
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
    Public Shared Function nprkBillDetailsDelete(ByVal Record As SIS.NPRK.nprkBillDetails) As Int32
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkBillDetailsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ClaimID", SqlDbType.Int, Record.ClaimID.ToString.Length, Record.ClaimID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ApplicationID", SqlDbType.Int, Record.ApplicationID.ToString.Length, Record.ApplicationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_AttachmentID", SqlDbType.Int, Record.AttachmentID.ToString.Length, Record.AttachmentID)
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