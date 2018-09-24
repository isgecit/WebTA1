Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakTCPO
    Private Shared _RecordCount As Integer
    Private _SerialNo As Int32 = 0
    Private _POConsignee As String = ""
    Private _POOtherDetails As String = ""
    Private _IssueReasonID As String = ""
    Private _PONumber As String = ""
    Private _PORevision As String = ""
    Private _PODate As String = ""
    Private _PODescription As String = ""
    Private _POTypeID As String = ""
    Private _SupplierID As String = ""
    Private _ProjectID As String = ""
    Private _BuyerID As String = ""
    Private _POStatusID As String = ""
    Private _ISGECRemarks As String = ""
    Private _SupplierRemarks As String = ""
    Private _IssuedBy As String = ""
    Private _IssuedOn As String = ""
    Private _ClosedBy As String = ""
    Private _ClosedOn As String = ""
    Private _DivisionID As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _aspnet_Users2_UserFullName As String = ""
    Private _aspnet_Users3_UserFullName As String = ""
    Private _IDM_Projects4_Description As String = ""
    Private _PAK_Divisions5_Description As String = ""
    Private _PAK_POStatus6_Description As String = ""
    Private _PAK_POTypes7_Description As String = ""
    Private _PAK_Reasons8_Description As String = ""
    Private _VR_BusinessPartner9_BPName As String = ""
    Private _FK_PAK_PO_BuyerID As SIS.QCM.qcmUsers = Nothing
    Private _FK_PAK_PO_IssuedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_PAK_PO_ClosedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_PAK_PO_ProjectID As SIS.QCM.qcmProjects = Nothing
    Private _FK_PAK_PO_DivisionID As SIS.PAK.pakDivisions = Nothing
    Private _FK_PAK_PO_POStatusID As SIS.PAK.pakPOStatus = Nothing
    Private _FK_PAK_PO_POTypeID As SIS.PAK.pakPOTypes = Nothing
    Private _FK_PAK_PO_IssueReasonID As SIS.PAK.pakReasons = Nothing
    Private _FK_PAK_SupplierID As SIS.PAK.pakBusinessPartner = Nothing
    Public Property POFOR As String = "TC"
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
    Public Property SerialNo() As Int32
      Get
        Return _SerialNo
      End Get
      Set(ByVal value As Int32)
        _SerialNo = value
      End Set
    End Property
    Public Property POConsignee() As String
      Get
        Return _POConsignee
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _POConsignee = ""
        Else
          _POConsignee = value
        End If
      End Set
    End Property
    Public Property POOtherDetails() As String
      Get
        Return _POOtherDetails
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _POOtherDetails = ""
        Else
          _POOtherDetails = value
        End If
      End Set
    End Property
    Public Property IssueReasonID() As String
      Get
        Return _IssueReasonID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _IssueReasonID = ""
        Else
          _IssueReasonID = value
        End If
      End Set
    End Property
    Public Property PONumber() As String
      Get
        Return _PONumber
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _PONumber = ""
        Else
          _PONumber = value
        End If
      End Set
    End Property
    Public Property PORevision() As String
      Get
        Return _PORevision
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _PORevision = ""
        Else
          _PORevision = value
        End If
      End Set
    End Property
    Public Property PODate() As String
      Get
        If Not _PODate = String.Empty Then
          Return Convert.ToDateTime(_PODate).ToString("dd/MM/yyyy")
        End If
        Return _PODate
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _PODate = ""
        Else
          _PODate = value
        End If
      End Set
    End Property
    Public Property PODescription() As String
      Get
        Return _PODescription
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _PODescription = ""
        Else
          _PODescription = value
        End If
      End Set
    End Property
    Public Property POTypeID() As String
      Get
        Return _POTypeID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _POTypeID = ""
        Else
          _POTypeID = value
        End If
      End Set
    End Property
    Public Property SupplierID() As String
      Get
        Return _SupplierID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _SupplierID = ""
        Else
          _SupplierID = value
        End If
      End Set
    End Property
    Public Property ProjectID() As String
      Get
        Return _ProjectID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ProjectID = ""
        Else
          _ProjectID = value
        End If
      End Set
    End Property
    Public Property BuyerID() As String
      Get
        Return _BuyerID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _BuyerID = ""
        Else
          _BuyerID = value
        End If
      End Set
    End Property
    Public Property POStatusID() As String
      Get
        Return _POStatusID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _POStatusID = ""
        Else
          _POStatusID = value
        End If
      End Set
    End Property
    Public Property ISGECRemarks() As String
      Get
        Return _ISGECRemarks
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ISGECRemarks = ""
        Else
          _ISGECRemarks = value
        End If
      End Set
    End Property
    Public Property SupplierRemarks() As String
      Get
        Return _SupplierRemarks
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _SupplierRemarks = ""
        Else
          _SupplierRemarks = value
        End If
      End Set
    End Property
    Public Property IssuedBy() As String
      Get
        Return _IssuedBy
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _IssuedBy = ""
        Else
          _IssuedBy = value
        End If
      End Set
    End Property
    Public Property IssuedOn() As String
      Get
        If Not _IssuedOn = String.Empty Then
          Return Convert.ToDateTime(_IssuedOn).ToString("dd/MM/yyyy")
        End If
        Return _IssuedOn
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _IssuedOn = ""
        Else
          _IssuedOn = value
        End If
      End Set
    End Property
    Public Property ClosedBy() As String
      Get
        Return _ClosedBy
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ClosedBy = ""
        Else
          _ClosedBy = value
        End If
      End Set
    End Property
    Public Property ClosedOn() As String
      Get
        If Not _ClosedOn = String.Empty Then
          Return Convert.ToDateTime(_ClosedOn).ToString("dd/MM/yyyy")
        End If
        Return _ClosedOn
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ClosedOn = ""
        Else
          _ClosedOn = value
        End If
      End Set
    End Property
    Public Property DivisionID() As String
      Get
        Return _DivisionID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _DivisionID = ""
        Else
          _DivisionID = value
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
    Public Property IDM_Projects4_Description() As String
      Get
        Return _IDM_Projects4_Description
      End Get
      Set(ByVal value As String)
        _IDM_Projects4_Description = value
      End Set
    End Property
    Public Property PAK_Divisions5_Description() As String
      Get
        Return _PAK_Divisions5_Description
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _PAK_Divisions5_Description = ""
        Else
          _PAK_Divisions5_Description = value
        End If
      End Set
    End Property
    Public Property PAK_POStatus6_Description() As String
      Get
        Return _PAK_POStatus6_Description
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _PAK_POStatus6_Description = ""
        Else
          _PAK_POStatus6_Description = value
        End If
      End Set
    End Property
    Public Property PAK_POTypes7_Description() As String
      Get
        Return _PAK_POTypes7_Description
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _PAK_POTypes7_Description = ""
        Else
          _PAK_POTypes7_Description = value
        End If
      End Set
    End Property
    Public Property PAK_Reasons8_Description() As String
      Get
        Return _PAK_Reasons8_Description
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _PAK_Reasons8_Description = ""
        Else
          _PAK_Reasons8_Description = value
        End If
      End Set
    End Property
    Public Property VR_BusinessPartner9_BPName() As String
      Get
        Return _VR_BusinessPartner9_BPName
      End Get
      Set(ByVal value As String)
        _VR_BusinessPartner9_BPName = value
      End Set
    End Property
    Public ReadOnly Property DisplayField() As String
      Get
        Return "" & _PODescription.ToString.PadRight(100, " ")
      End Get
    End Property
    Public ReadOnly Property PrimaryKey() As String
      Get
        Return _SerialNo
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
    Public Class PKpakTCPO
      Private _SerialNo As Int32 = 0
      Public Property SerialNo() As Int32
        Get
          Return _SerialNo
        End Get
        Set(ByVal value As Int32)
          _SerialNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PAK_PO_BuyerID() As SIS.QCM.qcmUsers
      Get
        If _FK_PAK_PO_BuyerID Is Nothing Then
          _FK_PAK_PO_BuyerID = SIS.QCM.qcmUsers.qcmUsersGetByID(_BuyerID)
        End If
        Return _FK_PAK_PO_BuyerID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_PO_IssuedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_PAK_PO_IssuedBy Is Nothing Then
          _FK_PAK_PO_IssuedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_IssuedBy)
        End If
        Return _FK_PAK_PO_IssuedBy
      End Get
    End Property
    Public ReadOnly Property FK_PAK_PO_ClosedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_PAK_PO_ClosedBy Is Nothing Then
          _FK_PAK_PO_ClosedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_ClosedBy)
        End If
        Return _FK_PAK_PO_ClosedBy
      End Get
    End Property
    Public ReadOnly Property FK_PAK_PO_ProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_PAK_PO_ProjectID Is Nothing Then
          _FK_PAK_PO_ProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_ProjectID)
        End If
        Return _FK_PAK_PO_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_PO_DivisionID() As SIS.PAK.pakDivisions
      Get
        If _FK_PAK_PO_DivisionID Is Nothing Then
          _FK_PAK_PO_DivisionID = SIS.PAK.pakDivisions.pakDivisionsGetByID(_DivisionID)
        End If
        Return _FK_PAK_PO_DivisionID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_PO_POStatusID() As SIS.PAK.pakPOStatus
      Get
        If _FK_PAK_PO_POStatusID Is Nothing Then
          _FK_PAK_PO_POStatusID = SIS.PAK.pakPOStatus.pakPOStatusGetByID(_POStatusID)
        End If
        Return _FK_PAK_PO_POStatusID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_PO_POTypeID() As SIS.PAK.pakPOTypes
      Get
        If _FK_PAK_PO_POTypeID Is Nothing Then
          _FK_PAK_PO_POTypeID = SIS.PAK.pakPOTypes.pakPOTypesGetByID(_POTypeID)
        End If
        Return _FK_PAK_PO_POTypeID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_PO_IssueReasonID() As SIS.PAK.pakReasons
      Get
        If _FK_PAK_PO_IssueReasonID Is Nothing Then
          _FK_PAK_PO_IssueReasonID = SIS.PAK.pakReasons.pakReasonsGetByID(_IssueReasonID)
        End If
        Return _FK_PAK_PO_IssueReasonID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SupplierID() As SIS.PAK.pakBusinessPartner
      Get
        If _FK_PAK_SupplierID Is Nothing Then
          _FK_PAK_SupplierID = SIS.PAK.pakBusinessPartner.pakBusinessPartnerGetByID(_SupplierID)
        End If
        Return _FK_PAK_SupplierID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakTCPOSelectList(ByVal OrderBy As String) As List(Of SIS.PAK.pakTCPO)
      Dim Results As List(Of SIS.PAK.pakTCPO) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakTCPOSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("DivisionID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakTCPO)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakTCPO(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakTCPOGetNewRecord() As SIS.PAK.pakTCPO
      Return New SIS.PAK.pakTCPO()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakTCPOGetByID(ByVal SerialNo As Int32) As SIS.PAK.pakTCPO
      Dim Results As SIS.PAK.pakTCPO = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakTCPOSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakTCPO(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetBySupplierID(ByVal SupplierID As String, ByVal OrderBy as String) As List(Of SIS.PAK.pakTCPO)
      Dim Results As List(Of SIS.PAK.pakTCPO) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakTCPOSelectBySupplierID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID",SqlDbType.NVarChar,SupplierID.ToString.Length, SupplierID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("DivisionID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakTCPO)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakTCPO(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByProjectID(ByVal ProjectID As String, ByVal OrderBy as String) As List(Of SIS.PAK.pakTCPO)
      Dim Results As List(Of SIS.PAK.pakTCPO) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakTCPOSelectByProjectID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,ProjectID.ToString.Length, ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("DivisionID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakTCPO)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakTCPO(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakTCPOSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal POTypeID As Int32, ByVal SupplierID As String, ByVal ProjectID As String, ByVal BuyerID As String, ByVal POStatusID As Int32, ByVal IssuedBy As String) As List(Of SIS.PAK.pakTCPO)
      Dim Results As List(Of SIS.PAK.pakTCPO) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakTCPOSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakTCPOSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_POTypeID",SqlDbType.Int,10, IIf(POTypeID = Nothing, 0,POTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SupplierID",SqlDbType.NVarChar,9, IIf(SupplierID Is Nothing, String.Empty,SupplierID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BuyerID",SqlDbType.NVarChar,8, IIf(BuyerID Is Nothing, String.Empty,BuyerID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_POStatusID",SqlDbType.Int,10, IIf(POStatusID = Nothing, 0,POStatusID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_IssuedBy",SqlDbType.NVarChar,8, IIf(IssuedBy Is Nothing, String.Empty,IssuedBy))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("DivisionID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakTCPO)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakTCPO(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakTCPOSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal POTypeID As Int32, ByVal SupplierID As String, ByVal ProjectID As String, ByVal BuyerID As String, ByVal POStatusID As Int32, ByVal IssuedBy As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakTCPOGetByID(ByVal SerialNo As Int32, ByVal Filter_POTypeID As Int32, ByVal Filter_SupplierID As String, ByVal Filter_ProjectID As String, ByVal Filter_BuyerID As String, ByVal Filter_POStatusID As Int32, ByVal Filter_IssuedBy As String) As SIS.PAK.pakTCPO
      Return pakTCPOGetByID(SerialNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function pakTCPOInsert(ByVal Record As SIS.PAK.pakTCPO) As SIS.PAK.pakTCPO
      Dim _Rec As SIS.PAK.pakTCPO = SIS.PAK.pakTCPO.pakTCPOGetNewRecord()
      With _Rec
        .POConsignee = Record.POConsignee
        .POOtherDetails = Record.POOtherDetails
        .IssueReasonID = Record.IssueReasonID
        .PONumber = Record.PONumber
        .PORevision = Record.PORevision
        .PODate = Record.PODate
        .PODescription = Record.PODescription
        .POTypeID = Record.POTypeID
        .SupplierID = Record.SupplierID
        .ProjectID = Record.ProjectID
        .BuyerID = Record.BuyerID
        .POStatusID = Record.POStatusID
        .ISGECRemarks = Record.ISGECRemarks
        .SupplierRemarks = Record.SupplierRemarks
        .IssuedBy = Record.IssuedBy
        .IssuedOn = Record.IssuedOn
        .ClosedBy = Record.ClosedBy
        .ClosedOn = Record.ClosedOn
        .POFOR = "TC"
        .DivisionID =  Global.System.Web.HttpContext.Current.Session("DivisionID")
      End With
      Return SIS.PAK.pakTCPO.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PAK.pakTCPO) As SIS.PAK.pakTCPO
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakTCPOInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@POConsignee",SqlDbType.NVarChar,101, Iif(Record.POConsignee= "" ,Convert.DBNull, Record.POConsignee))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@POOtherDetails",SqlDbType.NVarChar,501, Iif(Record.POOtherDetails= "" ,Convert.DBNull, Record.POOtherDetails))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssueReasonID",SqlDbType.Int,11, Iif(Record.IssueReasonID= "" ,Convert.DBNull, Record.IssueReasonID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PONumber",SqlDbType.NVarChar,11, Iif(Record.PONumber= "" ,Convert.DBNull, Record.PONumber))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PORevision",SqlDbType.NVarChar,11, Iif(Record.PORevision= "" ,Convert.DBNull, Record.PORevision))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PODate",SqlDbType.DateTime,21, Iif(Record.PODate= "" ,Convert.DBNull, Record.PODate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PODescription",SqlDbType.NVarChar,101, Iif(Record.PODescription= "" ,Convert.DBNull, Record.PODescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@POTypeID",SqlDbType.Int,11, Iif(Record.POTypeID= "" ,Convert.DBNull, Record.POTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID",SqlDbType.NVarChar,10, Iif(Record.SupplierID= "" ,Convert.DBNull, Record.SupplierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerID",SqlDbType.NVarChar,9, Iif(Record.BuyerID= "" ,Convert.DBNull, Record.BuyerID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@POStatusID",SqlDbType.Int,11, Iif(Record.POStatusID= "" ,Convert.DBNull, Record.POStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ISGECRemarks",SqlDbType.NVarChar,501, Iif(Record.ISGECRemarks= "" ,Convert.DBNull, Record.ISGECRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierRemarks",SqlDbType.NVarChar,501, Iif(Record.SupplierRemarks= "" ,Convert.DBNull, Record.SupplierRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssuedBy",SqlDbType.NVarChar,9, Iif(Record.IssuedBy= "" ,Convert.DBNull, Record.IssuedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssuedOn",SqlDbType.DateTime,21, Iif(Record.IssuedOn= "" ,Convert.DBNull, Record.IssuedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClosedBy",SqlDbType.NVarChar,9, Iif(Record.ClosedBy= "" ,Convert.DBNull, Record.ClosedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClosedOn",SqlDbType.DateTime,21, Iif(Record.ClosedOn= "" ,Convert.DBNull, Record.ClosedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.Int,11, Iif(Record.DivisionID= "" ,Convert.DBNull, Record.DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@POFOR", SqlDbType.NVarChar, 2, Record.POFOR)
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakTCPOUpdate(ByVal Record As SIS.PAK.pakTCPO) As SIS.PAK.pakTCPO
      Dim _Rec As SIS.PAK.pakTCPO = SIS.PAK.pakTCPO.pakTCPOGetByID(Record.SerialNo)
      With _Rec
        .POConsignee = Record.POConsignee
        .POOtherDetails = Record.POOtherDetails
        .IssueReasonID = Record.IssueReasonID
        .PONumber = Record.PONumber
        .PORevision = Record.PORevision
        .PODate = Record.PODate
        .PODescription = Record.PODescription
        .POTypeID = Record.POTypeID
        .SupplierID = Record.SupplierID
        .ProjectID = Record.ProjectID
        .BuyerID = Record.BuyerID
        .POStatusID = Record.POStatusID
        .ISGECRemarks = Record.ISGECRemarks
        .SupplierRemarks = Record.SupplierRemarks
        .IssuedBy = Record.IssuedBy
        .IssuedOn = Record.IssuedOn
        .ClosedBy = Record.ClosedBy
        .ClosedOn = Record.ClosedOn
        .POFOR = "TC"
        .DivisionID = Global.System.Web.HttpContext.Current.Session("DivisionID")
      End With
      Return SIS.PAK.pakTCPO.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PAK.pakTCPO) As SIS.PAK.pakTCPO
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakTCPOUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@POConsignee",SqlDbType.NVarChar,101, Iif(Record.POConsignee= "" ,Convert.DBNull, Record.POConsignee))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@POOtherDetails",SqlDbType.NVarChar,501, Iif(Record.POOtherDetails= "" ,Convert.DBNull, Record.POOtherDetails))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssueReasonID",SqlDbType.Int,11, Iif(Record.IssueReasonID= "" ,Convert.DBNull, Record.IssueReasonID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PONumber",SqlDbType.NVarChar,11, Iif(Record.PONumber= "" ,Convert.DBNull, Record.PONumber))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PORevision",SqlDbType.NVarChar,11, Iif(Record.PORevision= "" ,Convert.DBNull, Record.PORevision))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PODate",SqlDbType.DateTime,21, Iif(Record.PODate= "" ,Convert.DBNull, Record.PODate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PODescription",SqlDbType.NVarChar,101, Iif(Record.PODescription= "" ,Convert.DBNull, Record.PODescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@POTypeID",SqlDbType.Int,11, Iif(Record.POTypeID= "" ,Convert.DBNull, Record.POTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID",SqlDbType.NVarChar,10, Iif(Record.SupplierID= "" ,Convert.DBNull, Record.SupplierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerID",SqlDbType.NVarChar,9, Iif(Record.BuyerID= "" ,Convert.DBNull, Record.BuyerID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@POStatusID",SqlDbType.Int,11, Iif(Record.POStatusID= "" ,Convert.DBNull, Record.POStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ISGECRemarks",SqlDbType.NVarChar,501, Iif(Record.ISGECRemarks= "" ,Convert.DBNull, Record.ISGECRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierRemarks",SqlDbType.NVarChar,501, Iif(Record.SupplierRemarks= "" ,Convert.DBNull, Record.SupplierRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssuedBy",SqlDbType.NVarChar,9, Iif(Record.IssuedBy= "" ,Convert.DBNull, Record.IssuedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IssuedOn",SqlDbType.DateTime,21, Iif(Record.IssuedOn= "" ,Convert.DBNull, Record.IssuedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClosedBy",SqlDbType.NVarChar,9, Iif(Record.ClosedBy= "" ,Convert.DBNull, Record.ClosedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClosedOn",SqlDbType.DateTime,21, Iif(Record.ClosedOn= "" ,Convert.DBNull, Record.ClosedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.Int,11, Iif(Record.DivisionID= "" ,Convert.DBNull, Record.DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@POFOR", SqlDbType.NVarChar, 2, Record.POFOR)
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
    Public Shared Function pakTCPODelete(ByVal Record As SIS.PAK.pakTCPO) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakTCPODelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,Record.SerialNo.ToString.Length, Record.SerialNo)
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
    Public Shared Function SelectpakTCPOAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakTCPOAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("DivisionID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(100, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.PAK.pakTCPO = New SIS.PAK.pakTCPO(Reader)
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
