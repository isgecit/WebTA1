Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakLorryReceipts
    Private Shared _RecordCount As Integer
    Private _ProjectID As String = ""
    Private _MRNNo As Int32 = 0
    Private _MRNDate As String = ""
    Private _RequestExecutionNo As String = ""
    Private _CustomerID As String = ""
    Private _VehicleInDate As String = ""
    Private _VehicleOutDate As String = ""
    Private _TransporterID As String = ""
    Private _TransporterName As String = ""
    Private _VehicleRegistrationNo As String = ""
    Private _WayBillFormNo As String = ""
    Private _PaymentMadeAtSite As Boolean = False
    Private _AmountPaid As Decimal = 0
    Private _CreatedBy As String = ""
    Private _CreatedOn As String = ""
    Private _OverDimensionConsignment As String = ""
    Private _DetentionAtSite As String = ""
    Private _ReasonForDetention As String = ""
    Private _OtherRemarks As String = ""
    Private _MaterialStateID As String = ""
    Private _RemarksForDamageOrShortage As String = ""
    Private _DriverNameAndContactNo As String = ""
    Private _TempMRNNo As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _IDM_Projects2_Description As String = ""
    Private _VR_BusinessPartner3_BPName As String = ""
    Private _VR_MaterialStates5_Description As String = ""
    Private _VR_RequestExecution6_ExecutionDescription As String = ""
    Private _VR_BusinessPartner7_BPName As String = ""
    Private _FK_VR_LorryReceipts_CreatedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_VR_LorryReceipts_ProjectID As SIS.QCM.qcmProjects = Nothing
    Private _FK_VR_LorryReceipts_CustomerID As SIS.PAK.pakBusinessPartner = Nothing
    Private _FK_VR_LorryReceipts_MaterialStatusID As SIS.PAK.pakMaterialStates = Nothing
    Private _FK_VR_LorryReceipts_ExecutionNo As SIS.VR.vrRequestExecution = Nothing
    Private _FK_VR_LorryReceipts_TransporterID As SIS.PAK.pakBusinessPartner = Nothing
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
    Public Property ProjectID() As String
      Get
        Return _ProjectID
      End Get
      Set(ByVal value As String)
        _ProjectID = value
      End Set
    End Property
    Public Property MRNNo() As Int32
      Get
        Return _MRNNo
      End Get
      Set(ByVal value As Int32)
        _MRNNo = value
      End Set
    End Property
    Public Property MRNDate() As String
      Get
        If Not _MRNDate = String.Empty Then
          Return Convert.ToDateTime(_MRNDate).ToString("dd/MM/yyyy")
        End If
        Return _MRNDate
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _MRNDate = ""
        Else
          _MRNDate = value
        End If
      End Set
    End Property
    Public Property RequestExecutionNo() As String
      Get
        Return _RequestExecutionNo
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _RequestExecutionNo = ""
        Else
          _RequestExecutionNo = value
        End If
      End Set
    End Property
    Public Property CustomerID() As String
      Get
        Return _CustomerID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _CustomerID = ""
        Else
          _CustomerID = value
        End If
      End Set
    End Property
    Public Property VehicleInDate() As String
      Get
        If Not _VehicleInDate = String.Empty Then
          Return Convert.ToDateTime(_VehicleInDate).ToString("dd/MM/yyyy")
        End If
        Return _VehicleInDate
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _VehicleInDate = ""
        Else
          _VehicleInDate = value
        End If
      End Set
    End Property
    Public Property VehicleOutDate() As String
      Get
        If Not _VehicleOutDate = String.Empty Then
          Return Convert.ToDateTime(_VehicleOutDate).ToString("dd/MM/yyyy")
        End If
        Return _VehicleOutDate
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _VehicleOutDate = ""
        Else
          _VehicleOutDate = value
        End If
      End Set
    End Property
    Public Property TransporterID() As String
      Get
        Return _TransporterID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TransporterID = ""
        Else
          _TransporterID = value
        End If
      End Set
    End Property
    Public Property TransporterName() As String
      Get
        Return _TransporterName
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TransporterName = ""
        Else
          _TransporterName = value
        End If
      End Set
    End Property
    Public Property VehicleRegistrationNo() As String
      Get
        Return _VehicleRegistrationNo
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _VehicleRegistrationNo = ""
        Else
          _VehicleRegistrationNo = value
        End If
      End Set
    End Property
    Public Property WayBillFormNo() As String
      Get
        Return _WayBillFormNo
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _WayBillFormNo = ""
        Else
          _WayBillFormNo = value
        End If
      End Set
    End Property
    Public Property PaymentMadeAtSite() As Boolean
      Get
        Return _PaymentMadeAtSite
      End Get
      Set(ByVal value As Boolean)
        _PaymentMadeAtSite = value
      End Set
    End Property
    Public Property AmountPaid() As Decimal
      Get
        Return _AmountPaid
      End Get
      Set(ByVal value As Decimal)
        _AmountPaid = value
      End Set
    End Property
    Public Property CreatedBy() As String
      Get
        Return _CreatedBy
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _CreatedBy = ""
        Else
          _CreatedBy = value
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
        If Convert.IsDBNull(value) Then
          _CreatedOn = ""
        Else
          _CreatedOn = value
        End If
      End Set
    End Property
    Public Property OverDimensionConsignment() As String
      Get
        Return _OverDimensionConsignment
      End Get
      Set(ByVal value As String)
        _OverDimensionConsignment = value
      End Set
    End Property
    Public Property DetentionAtSite() As String
      Get
        Return _DetentionAtSite
      End Get
      Set(ByVal value As String)
        _DetentionAtSite = value
      End Set
    End Property
    Public Property ReasonForDetention() As String
      Get
        Return _ReasonForDetention
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ReasonForDetention = ""
        Else
          _ReasonForDetention = value
        End If
      End Set
    End Property
    Public Property OtherRemarks() As String
      Get
        Return _OtherRemarks
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _OtherRemarks = ""
        Else
          _OtherRemarks = value
        End If
      End Set
    End Property
    Public Property MaterialStateID() As String
      Get
        Return _MaterialStateID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _MaterialStateID = ""
        Else
          _MaterialStateID = value
        End If
      End Set
    End Property
    Public Property RemarksForDamageOrShortage() As String
      Get
        Return _RemarksForDamageOrShortage
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _RemarksForDamageOrShortage = ""
        Else
          _RemarksForDamageOrShortage = value
        End If
      End Set
    End Property
    Public Property DriverNameAndContactNo() As String
      Get
        Return _DriverNameAndContactNo
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _DriverNameAndContactNo = ""
        Else
          _DriverNameAndContactNo = value
        End If
      End Set
    End Property
    Public Property TempMRNNo() As String
      Get
        Return _TempMRNNo
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _TempMRNNo = ""
        Else
          _TempMRNNo = value
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
    Public Property IDM_Projects2_Description() As String
      Get
        Return _IDM_Projects2_Description
      End Get
      Set(ByVal value As String)
        _IDM_Projects2_Description = value
      End Set
    End Property
    Public Property VR_BusinessPartner3_BPName() As String
      Get
        Return _VR_BusinessPartner3_BPName
      End Get
      Set(ByVal value As String)
        _VR_BusinessPartner3_BPName = value
      End Set
    End Property
    Public Property VR_MaterialStates5_Description() As String
      Get
        Return _VR_MaterialStates5_Description
      End Get
      Set(ByVal value As String)
        _VR_MaterialStates5_Description = value
      End Set
    End Property
    Public Property VR_RequestExecution6_ExecutionDescription() As String
      Get
        Return _VR_RequestExecution6_ExecutionDescription
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _VR_RequestExecution6_ExecutionDescription = ""
        Else
          _VR_RequestExecution6_ExecutionDescription = value
        End If
      End Set
    End Property
    Public Property VR_BusinessPartner7_BPName() As String
      Get
        Return _VR_BusinessPartner7_BPName
      End Get
      Set(ByVal value As String)
        _VR_BusinessPartner7_BPName = value
      End Set
    End Property
    Public ReadOnly Property DisplayField() As String
      Get
        Return "" & _TransporterName.ToString.PadRight(50, " ")
      End Get
    End Property
    Public ReadOnly Property PrimaryKey() As String
      Get
        Return _ProjectID & "|" & _MRNNo
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
    Public Class PKpakLorryReceipts
      Private _ProjectID As String = ""
      Private _MRNNo As Int32 = 0
      Public Property ProjectID() As String
        Get
          Return _ProjectID
        End Get
        Set(ByVal value As String)
          _ProjectID = value
        End Set
      End Property
      Public Property MRNNo() As Int32
        Get
          Return _MRNNo
        End Get
        Set(ByVal value As Int32)
          _MRNNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_VR_LorryReceipts_CreatedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_VR_LorryReceipts_CreatedBy Is Nothing Then
          _FK_VR_LorryReceipts_CreatedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_CreatedBy)
        End If
        Return _FK_VR_LorryReceipts_CreatedBy
      End Get
    End Property
    Public ReadOnly Property FK_VR_LorryReceipts_ProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_VR_LorryReceipts_ProjectID Is Nothing Then
          _FK_VR_LorryReceipts_ProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_ProjectID)
        End If
        Return _FK_VR_LorryReceipts_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_VR_LorryReceipts_CustomerID() As SIS.PAK.pakBusinessPartner
      Get
        If _FK_VR_LorryReceipts_CustomerID Is Nothing Then
          _FK_VR_LorryReceipts_CustomerID = SIS.PAK.pakBusinessPartner.pakBusinessPartnerGetByID(_CustomerID)
        End If
        Return _FK_VR_LorryReceipts_CustomerID
      End Get
    End Property
    Public ReadOnly Property FK_VR_LorryReceipts_MaterialStatusID() As SIS.PAK.pakMaterialStates
      Get
        If _FK_VR_LorryReceipts_MaterialStatusID Is Nothing Then
          _FK_VR_LorryReceipts_MaterialStatusID = SIS.PAK.pakMaterialStates.pakMaterialStatesGetByID(_MaterialStateID)
        End If
        Return _FK_VR_LorryReceipts_MaterialStatusID
      End Get
    End Property
    Public ReadOnly Property FK_VR_LorryReceipts_ExecutionNo() As SIS.VR.vrRequestExecution
      Get
        If _FK_VR_LorryReceipts_ExecutionNo Is Nothing Then
          _FK_VR_LorryReceipts_ExecutionNo = SIS.VR.vrRequestExecution.vrRequestExecutionGetByID(_RequestExecutionNo)
        End If
        Return _FK_VR_LorryReceipts_ExecutionNo
      End Get
    End Property
    Public ReadOnly Property FK_VR_LorryReceipts_TransporterID() As SIS.PAK.pakBusinessPartner
      Get
        If _FK_VR_LorryReceipts_TransporterID Is Nothing Then
          _FK_VR_LorryReceipts_TransporterID = SIS.PAK.pakBusinessPartner.pakBusinessPartnerGetByID(_TransporterID)
        End If
        Return _FK_VR_LorryReceipts_TransporterID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakLorryReceiptsSelectList(ByVal OrderBy As String) As List(Of SIS.PAK.pakLorryReceipts)
      Dim Results As List(Of SIS.PAK.pakLorryReceipts) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakLorryReceiptsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakLorryReceipts)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakLorryReceipts(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakLorryReceiptsGetNewRecord() As SIS.PAK.pakLorryReceipts
      Return New SIS.PAK.pakLorryReceipts()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakLorryReceiptsGetByID(ByVal ProjectID As String, ByVal MRNNo As Int32) As SIS.PAK.pakLorryReceipts
      Dim Results As SIS.PAK.pakLorryReceipts = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakLorryReceiptsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,ProjectID.ToString.Length, ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MRNNo",SqlDbType.Int,MRNNo.ToString.Length, MRNNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakLorryReceipts(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakLorryReceiptsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.PAK.pakLorryReceipts)
      Dim Results As List(Of SIS.PAK.pakLorryReceipts) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakLorryReceiptsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakLorryReceiptsSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakLorryReceipts)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakLorryReceipts(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakLorryReceiptsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function pakLorryReceiptsInsert(ByVal Record As SIS.PAK.pakLorryReceipts) As SIS.PAK.pakLorryReceipts
      Dim _Rec As SIS.PAK.pakLorryReceipts = SIS.PAK.pakLorryReceipts.pakLorryReceiptsGetNewRecord()
      With _Rec
        .ProjectID = Record.ProjectID
        .MRNNo = Record.MRNNo
        .MRNDate = Record.MRNDate
        .RequestExecutionNo = Record.RequestExecutionNo
        .CustomerID = Record.CustomerID
        .VehicleInDate = Record.VehicleInDate
        .VehicleOutDate = Record.VehicleOutDate
        .TransporterID = Record.TransporterID
        .TransporterName = Record.TransporterName
        .VehicleRegistrationNo = Record.VehicleRegistrationNo
        .WayBillFormNo = Record.WayBillFormNo
        .PaymentMadeAtSite = Record.PaymentMadeAtSite
        .AmountPaid = Record.AmountPaid
        .CreatedBy = Record.CreatedBy
        .CreatedOn = Record.CreatedOn
        .OverDimensionConsignment = Record.OverDimensionConsignment
        .DetentionAtSite = Record.DetentionAtSite
        .ReasonForDetention = Record.ReasonForDetention
        .OtherRemarks = Record.OtherRemarks
        .MaterialStateID = Record.MaterialStateID
        .RemarksForDamageOrShortage = Record.RemarksForDamageOrShortage
        .DriverNameAndContactNo = Record.DriverNameAndContactNo
        .TempMRNNo = Record.TempMRNNo
      End With
      Return SIS.PAK.pakLorryReceipts.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PAK.pakLorryReceipts) As SIS.PAK.pakLorryReceipts
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakLorryReceiptsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MRNNo",SqlDbType.Int,11, Record.MRNNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MRNDate",SqlDbType.DateTime,21, Iif(Record.MRNDate= "" ,Convert.DBNull, Record.MRNDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestExecutionNo",SqlDbType.Int,11, Iif(Record.RequestExecutionNo= "" ,Convert.DBNull, Record.RequestExecutionNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CustomerID",SqlDbType.NVarChar,10, Iif(Record.CustomerID= "" ,Convert.DBNull, Record.CustomerID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleInDate",SqlDbType.DateTime,21, Iif(Record.VehicleInDate= "" ,Convert.DBNull, Record.VehicleInDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleOutDate",SqlDbType.DateTime,21, Iif(Record.VehicleOutDate= "" ,Convert.DBNull, Record.VehicleOutDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransporterID",SqlDbType.NVarChar,10, Iif(Record.TransporterID= "" ,Convert.DBNull, Record.TransporterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransporterName",SqlDbType.NVarChar,51, Iif(Record.TransporterName= "" ,Convert.DBNull, Record.TransporterName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleRegistrationNo",SqlDbType.NVarChar,51, Iif(Record.VehicleRegistrationNo= "" ,Convert.DBNull, Record.VehicleRegistrationNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WayBillFormNo",SqlDbType.NVarChar,51, Iif(Record.WayBillFormNo= "" ,Convert.DBNull, Record.WayBillFormNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PaymentMadeAtSite",SqlDbType.Bit,3, Record.PaymentMadeAtSite)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AmountPaid",SqlDbType.Decimal,13, Record.AmountPaid)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OverDimensionConsignment",SqlDbType.NVarChar,11, Record.OverDimensionConsignment)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DetentionAtSite",SqlDbType.NVarChar,11, Record.DetentionAtSite)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReasonForDetention",SqlDbType.NVarChar,501, Iif(Record.ReasonForDetention= "" ,Convert.DBNull, Record.ReasonForDetention))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OtherRemarks",SqlDbType.NVarChar,501, Iif(Record.OtherRemarks= "" ,Convert.DBNull, Record.OtherRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaterialStateID",SqlDbType.Int,11, Iif(Record.MaterialStateID= "" ,Convert.DBNull, Record.MaterialStateID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RemarksForDamageOrShortage",SqlDbType.NVarChar,501, Iif(Record.RemarksForDamageOrShortage= "" ,Convert.DBNull, Record.RemarksForDamageOrShortage))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DriverNameAndContactNo",SqlDbType.NVarChar,51, Iif(Record.DriverNameAndContactNo= "" ,Convert.DBNull, Record.DriverNameAndContactNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TempMRNNo",SqlDbType.Int,11, Iif(Record.TempMRNNo= "" ,Convert.DBNull, Record.TempMRNNo))
          Cmd.Parameters.Add("@Return_ProjectID", SqlDbType.NVarChar, 7)
          Cmd.Parameters("@Return_ProjectID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_MRNNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_MRNNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ProjectID = Cmd.Parameters("@Return_ProjectID").Value
          Record.MRNNo = Cmd.Parameters("@Return_MRNNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakLorryReceiptsUpdate(ByVal Record As SIS.PAK.pakLorryReceipts) As SIS.PAK.pakLorryReceipts
      Dim _Rec As SIS.PAK.pakLorryReceipts = SIS.PAK.pakLorryReceipts.pakLorryReceiptsGetByID(Record.ProjectID, Record.MRNNo)
      With _Rec
        .MRNDate = Record.MRNDate
        .RequestExecutionNo = Record.RequestExecutionNo
        .CustomerID = Record.CustomerID
        .VehicleInDate = Record.VehicleInDate
        .VehicleOutDate = Record.VehicleOutDate
        .TransporterID = Record.TransporterID
        .TransporterName = Record.TransporterName
        .VehicleRegistrationNo = Record.VehicleRegistrationNo
        .WayBillFormNo = Record.WayBillFormNo
        .PaymentMadeAtSite = Record.PaymentMadeAtSite
        .AmountPaid = Record.AmountPaid
        .CreatedBy = Record.CreatedBy
        .CreatedOn = Record.CreatedOn
        .OverDimensionConsignment = Record.OverDimensionConsignment
        .DetentionAtSite = Record.DetentionAtSite
        .ReasonForDetention = Record.ReasonForDetention
        .OtherRemarks = Record.OtherRemarks
        .MaterialStateID = Record.MaterialStateID
        .RemarksForDamageOrShortage = Record.RemarksForDamageOrShortage
        .DriverNameAndContactNo = Record.DriverNameAndContactNo
        .TempMRNNo = Record.TempMRNNo
      End With
      Return SIS.PAK.pakLorryReceipts.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PAK.pakLorryReceipts) As SIS.PAK.pakLorryReceipts
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakLorryReceiptsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_MRNNo",SqlDbType.Int,11, Record.MRNNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MRNNo",SqlDbType.Int,11, Record.MRNNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MRNDate",SqlDbType.DateTime,21, Iif(Record.MRNDate= "" ,Convert.DBNull, Record.MRNDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestExecutionNo",SqlDbType.Int,11, Iif(Record.RequestExecutionNo= "" ,Convert.DBNull, Record.RequestExecutionNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CustomerID",SqlDbType.NVarChar,10, Iif(Record.CustomerID= "" ,Convert.DBNull, Record.CustomerID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleInDate",SqlDbType.DateTime,21, Iif(Record.VehicleInDate= "" ,Convert.DBNull, Record.VehicleInDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleOutDate",SqlDbType.DateTime,21, Iif(Record.VehicleOutDate= "" ,Convert.DBNull, Record.VehicleOutDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransporterID",SqlDbType.NVarChar,10, Iif(Record.TransporterID= "" ,Convert.DBNull, Record.TransporterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransporterName",SqlDbType.NVarChar,51, Iif(Record.TransporterName= "" ,Convert.DBNull, Record.TransporterName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleRegistrationNo",SqlDbType.NVarChar,51, Iif(Record.VehicleRegistrationNo= "" ,Convert.DBNull, Record.VehicleRegistrationNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WayBillFormNo",SqlDbType.NVarChar,51, Iif(Record.WayBillFormNo= "" ,Convert.DBNull, Record.WayBillFormNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PaymentMadeAtSite",SqlDbType.Bit,3, Record.PaymentMadeAtSite)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AmountPaid",SqlDbType.Decimal,13, Record.AmountPaid)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OverDimensionConsignment",SqlDbType.NVarChar,11, Record.OverDimensionConsignment)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DetentionAtSite",SqlDbType.NVarChar,11, Record.DetentionAtSite)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReasonForDetention",SqlDbType.NVarChar,501, Iif(Record.ReasonForDetention= "" ,Convert.DBNull, Record.ReasonForDetention))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OtherRemarks",SqlDbType.NVarChar,501, Iif(Record.OtherRemarks= "" ,Convert.DBNull, Record.OtherRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaterialStateID",SqlDbType.Int,11, Iif(Record.MaterialStateID= "" ,Convert.DBNull, Record.MaterialStateID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RemarksForDamageOrShortage",SqlDbType.NVarChar,501, Iif(Record.RemarksForDamageOrShortage= "" ,Convert.DBNull, Record.RemarksForDamageOrShortage))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DriverNameAndContactNo",SqlDbType.NVarChar,51, Iif(Record.DriverNameAndContactNo= "" ,Convert.DBNull, Record.DriverNameAndContactNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TempMRNNo",SqlDbType.Int,11, Iif(Record.TempMRNNo= "" ,Convert.DBNull, Record.TempMRNNo))
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
    Public Shared Function pakLorryReceiptsDelete(ByVal Record As SIS.PAK.pakLorryReceipts) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakLorryReceiptsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID",SqlDbType.NVarChar,Record.ProjectID.ToString.Length, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_MRNNo",SqlDbType.Int,Record.MRNNo.ToString.Length, Record.MRNNo)
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
    Public Shared Function SelectpakLorryReceiptsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakLorryReceiptsAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),"" & "|" & ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.PAK.pakLorryReceipts = New SIS.PAK.pakLorryReceipts(Reader)
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
