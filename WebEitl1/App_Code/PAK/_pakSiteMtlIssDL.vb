Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakSiteMtlIssDL
    Private Shared _RecordCount As Integer
    Private _IssueSrLNo As Int32 = 0
    Private _SiteMarkNo As String = ""
    Private _LocationID As Int32 = 0
    Private _UOMQuantity As String = ""
    Private _QuantityAvailable As Decimal = 0
    Private _QuantityIssued As Decimal = 0
    Private _IssueNo As Int32 = 0
    Private _ProjectID As String = ""
    Private _Support As Boolean = False
    Private _IssueSrNo As Int32 = 0
    Private _Remarks As String = ""
    Private _IDM_Projects1_Description As String = ""
    Private _PAK_SiteIssueD2_SiteMarkNo As String = ""
    Private _PAK_SiteIssueH3_RequesterRemarks As String = ""
    Private _PAK_SiteItemMaster4_ItemDescription As String = ""
    Private _PAK_SiteLocations5_Description As String = ""
    Private _PAK_Units6_Description As String = ""
    Private _FK_PAK_SiteIssueDLocation_ProjectID As SIS.EITL.eitlProjects = Nothing
    Private _FK_PAK_SiteIssueDLocation_IssueSrNo As SIS.PAK.pakSiteIssRecD = Nothing
    Private _FK_PAK_SiteIssueDLocation_IssueNo As SIS.PAK.pakSiteIssReqH = Nothing
    Private _FK_PAK_SiteIssueDLocation_SiteMarkNo As SIS.PAK.pakSiteItemMaster = Nothing
    Private _FK_PAK_SiteIssueDLocation_LocationID As SIS.PAK.pakSiteLocations = Nothing
    Private _FK_PAK_SiteIssueDLocation_UOMQuantity As SIS.PAK.pakUnits = Nothing
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
    Public Property IssueSrLNo() As Int32
      Get
        Return _IssueSrLNo
      End Get
      Set(ByVal value As Int32)
        _IssueSrLNo = value
      End Set
    End Property
    Public Property SiteMarkNo() As String
      Get
        Return _SiteMarkNo
      End Get
      Set(ByVal value As String)
        _SiteMarkNo = value
      End Set
    End Property
    Public Property LocationID() As Int32
      Get
        Return _LocationID
      End Get
      Set(ByVal value As Int32)
        _LocationID = value
      End Set
    End Property
    Public Property UOMQuantity() As String
      Get
        Return _UOMQuantity
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _UOMQuantity = ""
         Else
           _UOMQuantity = value
         End If
      End Set
    End Property
    Public Property QuantityAvailable() As Decimal
      Get
        Return _QuantityAvailable
      End Get
      Set(ByVal value As Decimal)
        _QuantityAvailable = value
      End Set
    End Property
    Public Property QuantityIssued() As Decimal
      Get
        Return _QuantityIssued
      End Get
      Set(ByVal value As Decimal)
        _QuantityIssued = value
      End Set
    End Property
    Public Property IssueNo() As Int32
      Get
        Return _IssueNo
      End Get
      Set(ByVal value As Int32)
        _IssueNo = value
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
    Public Property Support() As Boolean
      Get
        Return _Support
      End Get
      Set(ByVal value As Boolean)
        _Support = value
      End Set
    End Property
    Public Property IssueSrNo() As Int32
      Get
        Return _IssueSrNo
      End Get
      Set(ByVal value As Int32)
        _IssueSrNo = value
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
    Public Property IDM_Projects1_Description() As String
      Get
        Return _IDM_Projects1_Description
      End Get
      Set(ByVal value As String)
        _IDM_Projects1_Description = value
      End Set
    End Property
    Public Property PAK_SiteIssueD2_SiteMarkNo() As String
      Get
        Return _PAK_SiteIssueD2_SiteMarkNo
      End Get
      Set(ByVal value As String)
        _PAK_SiteIssueD2_SiteMarkNo = value
      End Set
    End Property
    Public Property PAK_SiteIssueH3_RequesterRemarks() As String
      Get
        Return _PAK_SiteIssueH3_RequesterRemarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_SiteIssueH3_RequesterRemarks = ""
         Else
           _PAK_SiteIssueH3_RequesterRemarks = value
         End If
      End Set
    End Property
    Public Property PAK_SiteItemMaster4_ItemDescription() As String
      Get
        Return _PAK_SiteItemMaster4_ItemDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_SiteItemMaster4_ItemDescription = ""
         Else
           _PAK_SiteItemMaster4_ItemDescription = value
         End If
      End Set
    End Property
    Public Property PAK_SiteLocations5_Description() As String
      Get
        Return _PAK_SiteLocations5_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_SiteLocations5_Description = ""
         Else
           _PAK_SiteLocations5_Description = value
         End If
      End Set
    End Property
    Public Property PAK_Units6_Description() As String
      Get
        Return _PAK_Units6_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_Units6_Description = ""
         Else
           _PAK_Units6_Description = value
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
        Return _ProjectID & "|" & _IssueNo & "|" & _IssueSrNo & "|" & _IssueSrLNo
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
    Public Class PKpakSiteMtlIssDL
      Private _ProjectID As String = ""
      Private _IssueNo As Int32 = 0
      Private _IssueSrNo As Int32 = 0
      Private _IssueSrLNo As Int32 = 0
      Public Property ProjectID() As String
        Get
          Return _ProjectID
        End Get
        Set(ByVal value As String)
          _ProjectID = value
        End Set
      End Property
      Public Property IssueNo() As Int32
        Get
          Return _IssueNo
        End Get
        Set(ByVal value As Int32)
          _IssueNo = value
        End Set
      End Property
      Public Property IssueSrNo() As Int32
        Get
          Return _IssueSrNo
        End Get
        Set(ByVal value As Int32)
          _IssueSrNo = value
        End Set
      End Property
      Public Property IssueSrLNo() As Int32
        Get
          Return _IssueSrLNo
        End Get
        Set(ByVal value As Int32)
          _IssueSrLNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PAK_SiteIssueDLocation_ProjectID() As SIS.EITL.eitlProjects
      Get
        If _FK_PAK_SiteIssueDLocation_ProjectID Is Nothing Then
          _FK_PAK_SiteIssueDLocation_ProjectID = SIS.EITL.eitlProjects.eitlProjectsGetByID(_ProjectID)
        End If
        Return _FK_PAK_SiteIssueDLocation_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SiteIssueDLocation_IssueSrNo() As SIS.PAK.pakSiteIssRecD
      Get
        If _FK_PAK_SiteIssueDLocation_IssueSrNo Is Nothing Then
          _FK_PAK_SiteIssueDLocation_IssueSrNo = SIS.PAK.pakSiteIssRecD.pakSiteIssRecDGetByID(_ProjectID, _IssueNo, _IssueSrNo)
        End If
        Return _FK_PAK_SiteIssueDLocation_IssueSrNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SiteIssueDLocation_IssueNo() As SIS.PAK.pakSiteIssReqH
      Get
        If _FK_PAK_SiteIssueDLocation_IssueNo Is Nothing Then
          _FK_PAK_SiteIssueDLocation_IssueNo = SIS.PAK.pakSiteIssReqH.pakSiteIssReqHGetByID(_ProjectID, _IssueNo)
        End If
        Return _FK_PAK_SiteIssueDLocation_IssueNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SiteIssueDLocation_SiteMarkNo() As SIS.PAK.pakSiteItemMaster
      Get
        If _FK_PAK_SiteIssueDLocation_SiteMarkNo Is Nothing Then
          _FK_PAK_SiteIssueDLocation_SiteMarkNo = SIS.PAK.pakSiteItemMaster.pakSiteItemMasterGetByID(_ProjectID, _SiteMarkNo)
        End If
        Return _FK_PAK_SiteIssueDLocation_SiteMarkNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SiteIssueDLocation_LocationID() As SIS.PAK.pakSiteLocations
      Get
        If _FK_PAK_SiteIssueDLocation_LocationID Is Nothing Then
          _FK_PAK_SiteIssueDLocation_LocationID = SIS.PAK.pakSiteLocations.pakSiteLocationsGetByID(_LocationID)
        End If
        Return _FK_PAK_SiteIssueDLocation_LocationID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SiteIssueDLocation_UOMQuantity() As SIS.PAK.pakUnits
      Get
        If _FK_PAK_SiteIssueDLocation_UOMQuantity Is Nothing Then
          _FK_PAK_SiteIssueDLocation_UOMQuantity = SIS.PAK.pakUnits.pakUnitsGetByID(_UOMQuantity)
        End If
        Return _FK_PAK_SiteIssueDLocation_UOMQuantity
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSiteMtlIssDLGetNewRecord() As SIS.PAK.pakSiteMtlIssDL
      Return New SIS.PAK.pakSiteMtlIssDL()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSiteMtlIssDLGetByID(ByVal ProjectID As String, ByVal IssueNo As Int32, ByVal IssueSrNo As Int32, ByVal IssueSrLNo As Int32) As SIS.PAK.pakSiteMtlIssDL
      Dim Results As SIS.PAK.pakSiteMtlIssDL = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSiteMtlIssDLSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,ProjectID.ToString.Length, ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssueNo",SqlDbType.Int,IssueNo.ToString.Length, IssueNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssueSrNo",SqlDbType.Int,IssueSrNo.ToString.Length, IssueSrNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssueSrLNo",SqlDbType.Int,IssueSrLNo.ToString.Length, IssueSrLNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakSiteMtlIssDL(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSiteMtlIssDLSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal IssueNo As Int32, ByVal ProjectID As String, ByVal IssueSrNo As Int32) As List(Of SIS.PAK.pakSiteMtlIssDL)
      Dim Results As List(Of SIS.PAK.pakSiteMtlIssDL) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakSiteMtlIssDLSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakSiteMtlIssDLSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_IssueNo",SqlDbType.Int,10, IIf(IssueNo = Nothing, 0,IssueNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_IssueSrNo",SqlDbType.Int,10, IIf(IssueSrNo = Nothing, 0,IssueSrNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakSiteMtlIssDL)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSiteMtlIssDL(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakSiteMtlIssDLSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal IssueNo As Int32, ByVal ProjectID As String, ByVal IssueSrNo As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSiteMtlIssDLGetByID(ByVal ProjectID As String, ByVal IssueNo As Int32, ByVal IssueSrNo As Int32, ByVal IssueSrLNo As Int32, ByVal Filter_IssueNo As Int32, ByVal Filter_ProjectID As String, ByVal Filter_IssueSrNo As Int32) As SIS.PAK.pakSiteMtlIssDL
      Return pakSiteMtlIssDLGetByID(ProjectID, IssueNo, IssueSrNo, IssueSrLNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function pakSiteMtlIssDLInsert(ByVal Record As SIS.PAK.pakSiteMtlIssDL) As SIS.PAK.pakSiteMtlIssDL
      Dim _Rec As SIS.PAK.pakSiteMtlIssDL = SIS.PAK.pakSiteMtlIssDL.pakSiteMtlIssDLGetNewRecord()
      With _Rec
        .SiteMarkNo = Record.SiteMarkNo
        .LocationID = Record.LocationID
        .UOMQuantity = Record.UOMQuantity
        .QuantityAvailable = Record.QuantityAvailable
        .QuantityIssued = Record.QuantityIssued
        .IssueNo = Record.IssueNo
        .ProjectID = Record.ProjectID
        .Support = Record.Support
        .IssueSrNo = Record.IssueSrNo
        .Remarks = Record.Remarks
      End With
      Return SIS.PAK.pakSiteMtlIssDL.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PAK.pakSiteMtlIssDL) As SIS.PAK.pakSiteMtlIssDL
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSiteMtlIssDLInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteMarkNo",SqlDbType.NVarChar,31, Record.SiteMarkNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LocationID",SqlDbType.Int,11, Record.LocationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMQuantity",SqlDbType.Int,11, Iif(Record.UOMQuantity= "" ,Convert.DBNull, Record.UOMQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QuantityAvailable",SqlDbType.Decimal,21, Record.QuantityAvailable)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QuantityIssued",SqlDbType.Decimal,21, Record.QuantityIssued)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssueNo",SqlDbType.Int,11, Record.IssueNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Support",SqlDbType.Bit,3, Record.Support)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssueSrNo",SqlDbType.Int,11, Record.IssueSrNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,101, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          Cmd.Parameters.Add("@Return_ProjectID", SqlDbType.NVarChar, 7)
          Cmd.Parameters("@Return_ProjectID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_IssueNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_IssueNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_IssueSrNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_IssueSrNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_IssueSrLNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_IssueSrLNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ProjectID = Cmd.Parameters("@Return_ProjectID").Value
          Record.IssueNo = Cmd.Parameters("@Return_IssueNo").Value
          Record.IssueSrNo = Cmd.Parameters("@Return_IssueSrNo").Value
          Record.IssueSrLNo = Cmd.Parameters("@Return_IssueSrLNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakSiteMtlIssDLUpdate(ByVal Record As SIS.PAK.pakSiteMtlIssDL) As SIS.PAK.pakSiteMtlIssDL
      Dim _Rec As SIS.PAK.pakSiteMtlIssDL = SIS.PAK.pakSiteMtlIssDL.pakSiteMtlIssDLGetByID(Record.ProjectID, Record.IssueNo, Record.IssueSrNo, Record.IssueSrLNo)
      With _Rec
        .SiteMarkNo = Record.SiteMarkNo
        .LocationID = Record.LocationID
        .UOMQuantity = Record.UOMQuantity
        .QuantityAvailable = Record.QuantityAvailable
        .QuantityIssued = Record.QuantityIssued
        .Support = Record.Support
        .Remarks = Record.Remarks
      End With
      Return SIS.PAK.pakSiteMtlIssDL.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PAK.pakSiteMtlIssDL) As SIS.PAK.pakSiteMtlIssDL
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSiteMtlIssDLUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_IssueSrLNo",SqlDbType.Int,11, Record.IssueSrLNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_IssueNo",SqlDbType.Int,11, Record.IssueNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_IssueSrNo",SqlDbType.Int,11, Record.IssueSrNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteMarkNo",SqlDbType.NVarChar,31, Record.SiteMarkNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LocationID",SqlDbType.Int,11, Record.LocationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMQuantity",SqlDbType.Int,11, Iif(Record.UOMQuantity= "" ,Convert.DBNull, Record.UOMQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QuantityAvailable",SqlDbType.Decimal,21, Record.QuantityAvailable)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QuantityIssued",SqlDbType.Decimal,21, Record.QuantityIssued)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssueNo",SqlDbType.Int,11, Record.IssueNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Support",SqlDbType.Bit,3, Record.Support)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssueSrNo",SqlDbType.Int,11, Record.IssueSrNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,101, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
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
    Public Shared Function pakSiteMtlIssDLDelete(ByVal Record As SIS.PAK.pakSiteMtlIssDL) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSiteMtlIssDLDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID",SqlDbType.NVarChar,Record.ProjectID.ToString.Length, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_IssueNo",SqlDbType.Int,Record.IssueNo.ToString.Length, Record.IssueNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_IssueSrNo",SqlDbType.Int,Record.IssueSrNo.ToString.Length, Record.IssueSrNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_IssueSrLNo",SqlDbType.Int,Record.IssueSrLNo.ToString.Length, Record.IssueSrLNo)
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
