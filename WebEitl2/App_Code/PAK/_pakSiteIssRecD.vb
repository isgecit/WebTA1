Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakSiteIssRecD
    Private Shared _RecordCount As Integer
    Private _IssueSrNo As Int32 = 0
    Private _SiteMarkNo As String = ""
    Private _UOMQuantity As String = ""
    Private _QuantityRequired As Decimal = 0
    Private _QuantityIssued As Decimal = 0
    Private _IssuerRemarks As String = ""
    Private _IssueNo As Int32 = 0
    Private _Remarks As String = ""
    Private _ProjectID As String = ""
    Private _IDM_Projects1_Description As String = ""
    Private _PAK_SiteIssueH2_RequesterRemarks As String = ""
    Private _PAK_SiteItemMaster3_ItemDescription As String = ""
    Private _PAK_Units4_Description As String = ""
    Private _FK_PAK_SiteIssueD_ProjectID As SIS.QCM.qcmProjects = Nothing
    Private _FK_PAK_SiteIssueD_IssueNo As SIS.PAK.pakSiteIssReqH = Nothing
    Private _FK_PAK_SiteIssueD_SiteMarkNo As SIS.PAK.pakSiteItemMaster = Nothing
    Private _FK_PAK_SiteIssueD_UOMQuantity As SIS.PAK.pakUnits = Nothing
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
    Public Property IssueSrNo() As Int32
      Get
        Return _IssueSrNo
      End Get
      Set(ByVal value As Int32)
        _IssueSrNo = value
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
    Public Property UOMQuantity() As String
      Get
        Return _UOMQuantity
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _UOMQuantity = ""
        Else
          _UOMQuantity = value
        End If
      End Set
    End Property
    Public Property QuantityRequired() As Decimal
      Get
        Return _QuantityRequired
      End Get
      Set(ByVal value As Decimal)
        _QuantityRequired = value
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
    Public Property IssuerRemarks() As String
      Get
        Return _IssuerRemarks
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _IssuerRemarks = ""
        Else
          _IssuerRemarks = value
        End If
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
    Public Property Remarks() As String
      Get
        Return _Remarks
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _Remarks = ""
        Else
          _Remarks = value
        End If
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
    Public Property IDM_Projects1_Description() As String
      Get
        Return _IDM_Projects1_Description
      End Get
      Set(ByVal value As String)
        _IDM_Projects1_Description = value
      End Set
    End Property
    Public Property PAK_SiteIssueH2_RequesterRemarks() As String
      Get
        Return _PAK_SiteIssueH2_RequesterRemarks
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _PAK_SiteIssueH2_RequesterRemarks = ""
        Else
          _PAK_SiteIssueH2_RequesterRemarks = value
        End If
      End Set
    End Property
    Public Property PAK_SiteItemMaster3_ItemDescription() As String
      Get
        Return _PAK_SiteItemMaster3_ItemDescription
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _PAK_SiteItemMaster3_ItemDescription = ""
        Else
          _PAK_SiteItemMaster3_ItemDescription = value
        End If
      End Set
    End Property
    Public Property PAK_Units4_Description() As String
      Get
        Return _PAK_Units4_Description
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _PAK_Units4_Description = ""
        Else
          _PAK_Units4_Description = value
        End If
      End Set
    End Property
    Public ReadOnly Property DisplayField() As String
      Get
        Return "" & _SiteMarkNo.ToString.PadRight(30, " ")
      End Get
    End Property
    Public ReadOnly Property PrimaryKey() As String
      Get
        Return _ProjectID & "|" & _IssueNo & "|" & _IssueSrNo
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
    Public Class PKpakSiteIssRecD
      Private _ProjectID As String = ""
      Private _IssueNo As Int32 = 0
      Private _IssueSrNo As Int32 = 0
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
    End Class
    Public ReadOnly Property FK_PAK_SiteIssueD_ProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_PAK_SiteIssueD_ProjectID Is Nothing Then
          _FK_PAK_SiteIssueD_ProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_ProjectID)
        End If
        Return _FK_PAK_SiteIssueD_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SiteIssueD_IssueNo() As SIS.PAK.pakSiteIssReqH
      Get
        If _FK_PAK_SiteIssueD_IssueNo Is Nothing Then
          _FK_PAK_SiteIssueD_IssueNo = SIS.PAK.pakSiteIssReqH.pakSiteIssReqHGetByID(_ProjectID, _IssueNo)
        End If
        Return _FK_PAK_SiteIssueD_IssueNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SiteIssueD_SiteMarkNo() As SIS.PAK.pakSiteItemMaster
      Get
        If _FK_PAK_SiteIssueD_SiteMarkNo Is Nothing Then
          _FK_PAK_SiteIssueD_SiteMarkNo = SIS.PAK.pakSiteItemMaster.pakSiteItemMasterGetByID(_ProjectID, _SiteMarkNo)
        End If
        Return _FK_PAK_SiteIssueD_SiteMarkNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SiteIssueD_UOMQuantity() As SIS.PAK.pakUnits
      Get
        If _FK_PAK_SiteIssueD_UOMQuantity Is Nothing Then
          _FK_PAK_SiteIssueD_UOMQuantity = SIS.PAK.pakUnits.pakUnitsGetByID(_UOMQuantity)
        End If
        Return _FK_PAK_SiteIssueD_UOMQuantity
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSiteIssRecDSelectList(ByVal OrderBy As String) As List(Of SIS.PAK.pakSiteIssRecD)
      Dim Results As List(Of SIS.PAK.pakSiteIssRecD) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSiteIssRecDSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakSiteIssRecD)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSiteIssRecD(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSiteIssRecDGetNewRecord() As SIS.PAK.pakSiteIssRecD
      Return New SIS.PAK.pakSiteIssRecD()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSiteIssRecDGetByID(ByVal ProjectID As String, ByVal IssueNo As Int32, ByVal IssueSrNo As Int32) As SIS.PAK.pakSiteIssRecD
      Dim Results As SIS.PAK.pakSiteIssRecD = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSiteIssRecDSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,ProjectID.ToString.Length, ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssueNo",SqlDbType.Int,IssueNo.ToString.Length, IssueNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssueSrNo",SqlDbType.Int,IssueSrNo.ToString.Length, IssueSrNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakSiteIssRecD(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSiteIssRecDSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal IssueNo As Int32, ByVal ProjectID As String) As List(Of SIS.PAK.pakSiteIssRecD)
      Dim Results As List(Of SIS.PAK.pakSiteIssRecD) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakSiteIssRecDSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakSiteIssRecDSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_IssueNo",SqlDbType.Int,10, IIf(IssueNo = Nothing, 0,IssueNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakSiteIssRecD)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSiteIssRecD(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakSiteIssRecDSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal IssueNo As Int32, ByVal ProjectID As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSiteIssRecDGetByID(ByVal ProjectID As String, ByVal IssueNo As Int32, ByVal IssueSrNo As Int32, ByVal Filter_IssueNo As Int32, ByVal Filter_ProjectID As String) As SIS.PAK.pakSiteIssRecD
      Return pakSiteIssRecDGetByID(ProjectID, IssueNo, IssueSrNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function pakSiteIssRecDInsert(ByVal Record As SIS.PAK.pakSiteIssRecD) As SIS.PAK.pakSiteIssRecD
      Dim _Rec As SIS.PAK.pakSiteIssRecD = SIS.PAK.pakSiteIssRecD.pakSiteIssRecDGetNewRecord()
      With _Rec
        .SiteMarkNo = Record.SiteMarkNo
        .UOMQuantity = Record.UOMQuantity
        .QuantityRequired = Record.QuantityRequired
        .QuantityIssued = Record.QuantityIssued
        .IssuerRemarks = Record.IssuerRemarks
        .IssueNo = Record.IssueNo
        .Remarks = Record.Remarks
        .ProjectID = Record.ProjectID
      End With
      Return SIS.PAK.pakSiteIssRecD.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PAK.pakSiteIssRecD) As SIS.PAK.pakSiteIssRecD
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSiteIssRecDInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteMarkNo",SqlDbType.NVarChar,31, Record.SiteMarkNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMQuantity",SqlDbType.Int,11, Iif(Record.UOMQuantity= "" ,Convert.DBNull, Record.UOMQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QuantityRequired",SqlDbType.Decimal,21, Record.QuantityRequired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QuantityIssued",SqlDbType.Decimal,21, Record.QuantityIssued)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssuerRemarks",SqlDbType.NVarChar,101, Iif(Record.IssuerRemarks= "" ,Convert.DBNull, Record.IssuerRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssueNo",SqlDbType.Int,11, Record.IssueNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,101, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          Cmd.Parameters.Add("@Return_ProjectID", SqlDbType.NVarChar, 7)
          Cmd.Parameters("@Return_ProjectID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_IssueNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_IssueNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_IssueSrNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_IssueSrNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ProjectID = Cmd.Parameters("@Return_ProjectID").Value
          Record.IssueNo = Cmd.Parameters("@Return_IssueNo").Value
          Record.IssueSrNo = Cmd.Parameters("@Return_IssueSrNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakSiteIssRecDUpdate(ByVal Record As SIS.PAK.pakSiteIssRecD) As SIS.PAK.pakSiteIssRecD
      Dim _Rec As SIS.PAK.pakSiteIssRecD = SIS.PAK.pakSiteIssRecD.pakSiteIssRecDGetByID(Record.ProjectID, Record.IssueNo, Record.IssueSrNo)
      With _Rec
        .SiteMarkNo = Record.SiteMarkNo
        .UOMQuantity = Record.UOMQuantity
        .QuantityRequired = Record.QuantityRequired
        .QuantityIssued = Record.QuantityIssued
        .IssuerRemarks = Record.IssuerRemarks
        .Remarks = Record.Remarks
      End With
      Return SIS.PAK.pakSiteIssRecD.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PAK.pakSiteIssRecD) As SIS.PAK.pakSiteIssRecD
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSiteIssRecDUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_IssueSrNo",SqlDbType.Int,11, Record.IssueSrNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_IssueNo",SqlDbType.Int,11, Record.IssueNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteMarkNo",SqlDbType.NVarChar,31, Record.SiteMarkNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMQuantity",SqlDbType.Int,11, Iif(Record.UOMQuantity= "" ,Convert.DBNull, Record.UOMQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QuantityRequired",SqlDbType.Decimal,21, Record.QuantityRequired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QuantityIssued",SqlDbType.Decimal,21, Record.QuantityIssued)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssuerRemarks",SqlDbType.NVarChar,101, Iif(Record.IssuerRemarks= "" ,Convert.DBNull, Record.IssuerRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssueNo",SqlDbType.Int,11, Record.IssueNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,101, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
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
    Public Shared Function pakSiteIssRecDDelete(ByVal Record As SIS.PAK.pakSiteIssRecD) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSiteIssRecDDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID",SqlDbType.NVarChar,Record.ProjectID.ToString.Length, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_IssueNo",SqlDbType.Int,Record.IssueNo.ToString.Length, Record.IssueNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_IssueSrNo",SqlDbType.Int,Record.IssueSrNo.ToString.Length, Record.IssueSrNo)
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
    Public Shared Function SelectpakSiteIssRecDAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSiteIssRecDAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(30, " "),"" & "|" & "" & "|" & ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.PAK.pakSiteIssRecD = New SIS.PAK.pakSiteIssRecD(Reader)
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
