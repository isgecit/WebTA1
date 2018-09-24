Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.QCM
  <DataObject()> _
  Partial Public Class qcmRequests
    Private Shared _RecordCount As Integer
    Private _RequestID As Int32 = 0
    Private _ProjectID As String = ""
    Private _OrderNo As String = ""
    Private _OrderDate As String = ""
    Private _SupplierID As String = ""
    Private _Description As String = ""
    Private _TotalRequestedQuantity As String = ""
    Private _RequestedInspectionStartDate As String = ""
    Private _RequestedInspectionFinishDate As String = ""
    Private _ClientInspectionRequired As Boolean = False
    Private _ThirdPartyInspectionRequired As Boolean = False
    Private _ReceivedOn As String = ""
    Private _ReceivedBy As String = ""
    Private _ReceivingMediumID As String = ""
    Private _CreationRemarks As String = ""
    Private _CreatedBy As String = ""
    Private _CreatedOn As String = ""
    Private _RequestStateID As String = ""
    Private _FileAttached As Boolean = False
    Private _InspectionStageiD As String = ""
    Private _AllotedTo As String = ""
    Private _AllotedStartDate As String = ""
    Private _AllotedFinishDate As String = ""
    Private _AllotedOn As String = ""
    Private _AllotedBy As String = ""
    Private _AllotmentRemarks As String = ""
    Private _InspectionStartDate As String = ""
    Private _InspectionFinishDate As String = ""
    Private _InspectionStatusID As String = ""
    Private _CancelledOn As String = ""
    Private _CancelledBy As String = ""
    Private _CancellationRemarks As String = ""
    Private _RegionID As String = ""
    Private _LotSize As String = ""
    Private _UOM As String = ""
    Private _DocumentID As String = ""
    Private _ReturnRemarks As String = ""
    Private _HRM_Employees1_EmployeeName As String = ""
    Private _HRM_Employees2_EmployeeName As String = ""
    Private _HRM_Employees3_EmployeeName As String = ""
    Private _HRM_Employees4_EmployeeName As String = ""
    Private _HRM_Employees5_EmployeeName As String = ""
    Private _IDM_Projects6_Description As String = ""
    Private _IDM_Vendors7_Description As String = ""
    Private _QCM_InspectionStages8_Description As String = ""
    Private _QCM_ReceivingMediums9_Description As String = ""
    Private _QCM_RequestStates10_Description As String = ""
    Private _QCM_InspectionStatus11_Description As String = ""
    Private _QCM_Regions12_RegionName As String = ""
    Private _FK_QCM_Requests_Createdby As SIS.QCM.qcmEmployees = Nothing
    Private _FK_QCM_Requests_AllotedTo As SIS.QCM.qcmEmployees = Nothing
    Private _FK_QCM_Requests_AllotedBy As SIS.QCM.qcmEmployees = Nothing
    Private _FK_QCM_Requests_CancelledBy As SIS.QCM.qcmEmployees = Nothing
    Private _FK_QCM_Requests_ReceivedBy As SIS.QCM.qcmEmployees = Nothing
    Private _FK_QCM_Requests_ProjectID As SIS.QCM.qcmProjects = Nothing
    Private _FK_QCM_Requests_SupplierID As SIS.QCM.qcmVendors = Nothing
    Private _FK_QCM_Requests_InspectionStageID As SIS.QCM.qcmInspectionStages = Nothing
    Private _FK_QCM_Requests_RequestStateID As SIS.QCM.qcmRequestStates = Nothing
    Private _FK_QCM_Requests_RegionID As SIS.QCM.qcmRegions = Nothing
    Public Property Paused As Boolean = False
    Public Property PausedHrs As Decimal = 0
    Public Property LastPausedOn As String = ""
    Public Property TotalHrs As Decimal = 0
    Public Property LotSize As String
      Get
        Return _LotSize
      End Get
      Set(value As String)
        If Convert.IsDBNull(value) Then
          _LotSize = ""
        Else
          _LotSize = value
        End If
      End Set
    End Property
    Public Property UOM As String
      Get
        Return _UOM
      End Get
      Set(value As String)
        If Convert.IsDBNull(value) Then
          _UOM = ""
        Else
          _UOM = value
        End If
      End Set
    End Property
    Public Property DocumentID As String
      Get
        Return _DocumentID
      End Get
      Set(value As String)
        If Convert.IsDBNull(value) Then
          _DocumentID = ""
        Else
          _DocumentID = value
        End If
      End Set
    End Property
    Public Property ReturnRemarks As String
      Get
        Return _ReturnRemarks
      End Get
      Set(value As String)
        If Convert.IsDBNull(value) Then
          _ReturnRemarks = ""
        Else
          _ReturnRemarks = value
        End If
      End Set
    End Property
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
    Public Property RequestID() As Int32
      Get
        Return _RequestID
      End Get
      Set(ByVal value As Int32)
        _RequestID = value
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
    Public Property OrderNo() As String
      Get
        Return _OrderNo
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _OrderNo = ""
				 Else
					 _OrderNo = value
			   End If
      End Set
    End Property
    Public Property OrderDate() As String
      Get
        If Not _OrderDate = String.Empty Then
          Return Convert.ToDateTime(_OrderDate).ToString("dd/MM/yyyy")
        End If
        Return _OrderDate
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _OrderDate = ""
				 Else
					 _OrderDate = value
			   End If
      End Set
    End Property
    Public Property SupplierID() As String
      Get
        Return _SupplierID
      End Get
      Set(ByVal value As String)
        _SupplierID = value
      End Set
    End Property
    Public Property Description() As String
      Get
        Return _Description
      End Get
      Set(ByVal value As String)
        _Description = value
      End Set
    End Property
    Public Property TotalRequestedQuantity() As String
      Get
        Return _TotalRequestedQuantity
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _TotalRequestedQuantity = ""
				 Else
					 _TotalRequestedQuantity = value
			   End If
      End Set
    End Property
    Public Property RequestedInspectionStartDate() As String
      Get
        If Not _RequestedInspectionStartDate = String.Empty Then
          Return Convert.ToDateTime(_RequestedInspectionStartDate).ToString("dd/MM/yyyy")
        End If
        Return _RequestedInspectionStartDate
      End Get
      Set(ByVal value As String)
			   _RequestedInspectionStartDate = value
      End Set
    End Property
    Public Property RequestedInspectionFinishDate() As String
      Get
        If Not _RequestedInspectionFinishDate = String.Empty Then
          Return Convert.ToDateTime(_RequestedInspectionFinishDate).ToString("dd/MM/yyyy")
        End If
        Return _RequestedInspectionFinishDate
      End Get
      Set(ByVal value As String)
			   _RequestedInspectionFinishDate = value
      End Set
    End Property
    Public Property ClientInspectionRequired() As Boolean
      Get
        Return _ClientInspectionRequired
      End Get
      Set(ByVal value As Boolean)
        _ClientInspectionRequired = value
      End Set
    End Property
    Public Property ThirdPartyInspectionRequired() As Boolean
      Get
        Return _ThirdPartyInspectionRequired
      End Get
      Set(ByVal value As Boolean)
        _ThirdPartyInspectionRequired = value
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
    Public Property ReceivingMediumID() As String
      Get
        Return _ReceivingMediumID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ReceivingMediumID = ""
				 Else
					 _ReceivingMediumID = value
			   End If
      End Set
    End Property
    Public Property CreationRemarks() As String
      Get
        Return _CreationRemarks
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _CreationRemarks = ""
				 Else
					 _CreationRemarks = value
			   End If
      End Set
    End Property
    Public Property CreatedBy() As String
      Get
        Return _CreatedBy
      End Get
      Set(ByVal value As String)
        _CreatedBy = value
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
			   _CreatedOn = value
      End Set
    End Property
    Public Property RequestStateID() As String
      Get
        Return _RequestStateID
      End Get
      Set(ByVal value As String)
        _RequestStateID = value
      End Set
    End Property
    Public Property FileAttached() As Boolean
      Get
        Return _FileAttached
      End Get
      Set(ByVal value As Boolean)
        _FileAttached = value
      End Set
    End Property
    Public Property InspectionStageiD() As String
      Get
        Return _InspectionStageiD
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _InspectionStageiD = ""
				 Else
					 _InspectionStageiD = value
			   End If
      End Set
    End Property
    Public Property AllotedTo() As String
      Get
        Return _AllotedTo
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _AllotedTo = ""
				 Else
					 _AllotedTo = value
			   End If
      End Set
    End Property
    Public Property AllotedStartDate() As String
      Get
        If Not _AllotedStartDate = String.Empty Then
          Return Convert.ToDateTime(_AllotedStartDate).ToString("dd/MM/yyyy")
        End If
        Return _AllotedStartDate
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _AllotedStartDate = ""
				 Else
					 _AllotedStartDate = value
			   End If
      End Set
    End Property
    Public Property AllotedFinishDate() As String
      Get
        If Not _AllotedFinishDate = String.Empty Then
          Return Convert.ToDateTime(_AllotedFinishDate).ToString("dd/MM/yyyy")
        End If
        Return _AllotedFinishDate
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _AllotedFinishDate = ""
				 Else
					 _AllotedFinishDate = value
			   End If
      End Set
    End Property
    Public Property AllotedOn() As String
      Get
        If Not _AllotedOn = String.Empty Then
          Return Convert.ToDateTime(_AllotedOn).ToString("dd/MM/yyyy")
        End If
        Return _AllotedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _AllotedOn = ""
				 Else
					 _AllotedOn = value
			   End If
      End Set
    End Property
    Public Property AllotedBy() As String
      Get
        Return _AllotedBy
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _AllotedBy = ""
				 Else
					 _AllotedBy = value
			   End If
      End Set
    End Property
    Public Property AllotmentRemarks() As String
      Get
        Return _AllotmentRemarks
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _AllotmentRemarks = ""
				 Else
					 _AllotmentRemarks = value
			   End If
      End Set
    End Property
    Public Property InspectionStartDate() As String
      Get
        If Not _InspectionStartDate = String.Empty Then
          Return Convert.ToDateTime(_InspectionStartDate).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _InspectionStartDate
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _InspectionStartDate = ""
				 Else
					 _InspectionStartDate = value
			   End If
      End Set
    End Property
    Public Property InspectionFinishDate() As String
      Get
        If Not _InspectionFinishDate = String.Empty Then
          Return Convert.ToDateTime(_InspectionFinishDate).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _InspectionFinishDate
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _InspectionFinishDate = ""
				 Else
					 _InspectionFinishDate = value
			   End If
      End Set
    End Property
    Public Property InspectionStatusID() As String
      Get
        Return _InspectionStatusID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _InspectionStatusID = ""
				 Else
					 _InspectionStatusID = value
			   End If
      End Set
    End Property
    Public Property CancelledOn() As String
      Get
        If Not _CancelledOn = String.Empty Then
          Return Convert.ToDateTime(_CancelledOn).ToString("dd/MM/yyyy")
        End If
        Return _CancelledOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _CancelledOn = ""
				 Else
					 _CancelledOn = value
			   End If
      End Set
    End Property
    Public Property CancelledBy() As String
      Get
        Return _CancelledBy
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _CancelledBy = ""
				 Else
					 _CancelledBy = value
			   End If
      End Set
    End Property
    Public Property CancellationRemarks() As String
      Get
        Return _CancellationRemarks
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _CancellationRemarks = ""
				 Else
					 _CancellationRemarks = value
			   End If
      End Set
    End Property
    Public Property RegionID() As String
      Get
        Return _RegionID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _RegionID = ""
				 Else
					 _RegionID = value
			   End If
      End Set
    End Property
    Public Property HRM_Employees1_EmployeeName() As String
      Get
        Return _HRM_Employees1_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees1_EmployeeName = value
      End Set
    End Property
    Public Property HRM_Employees2_EmployeeName() As String
      Get
        Return _HRM_Employees2_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees2_EmployeeName = value
      End Set
    End Property
    Public Property HRM_Employees3_EmployeeName() As String
      Get
        Return _HRM_Employees3_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees3_EmployeeName = value
      End Set
    End Property
    Public Property HRM_Employees4_EmployeeName() As String
      Get
        Return _HRM_Employees4_EmployeeName
      End Get
      Set(ByVal value As String)
        _HRM_Employees4_EmployeeName = value
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
    Public Property IDM_Projects6_Description() As String
      Get
        Return _IDM_Projects6_Description
      End Get
      Set(ByVal value As String)
        _IDM_Projects6_Description = value
      End Set
    End Property
    Public Property IDM_Vendors7_Description() As String
      Get
        Return _IDM_Vendors7_Description
      End Get
      Set(ByVal value As String)
        _IDM_Vendors7_Description = value
      End Set
    End Property
    Public Property QCM_InspectionStages8_Description() As String
      Get
        Return _QCM_InspectionStages8_Description
      End Get
      Set(ByVal value As String)
        _QCM_InspectionStages8_Description = value
      End Set
    End Property
    Public Property QCM_ReceivingMediums9_Description() As String
      Get
        Return _QCM_ReceivingMediums9_Description
      End Get
      Set(ByVal value As String)
        _QCM_ReceivingMediums9_Description = value
      End Set
    End Property
    Public Property QCM_RequestStates10_Description() As String
      Get
        Return _QCM_RequestStates10_Description
      End Get
      Set(ByVal value As String)
        _QCM_RequestStates10_Description = value
      End Set
    End Property
    Public Property QCM_InspectionStatus11_Description() As String
      Get
        Return _QCM_InspectionStatus11_Description
      End Get
      Set(ByVal value As String)
        _QCM_InspectionStatus11_Description = value
      End Set
    End Property
    Public Property QCM_Regions12_RegionName() As String
      Get
        Return _QCM_Regions12_RegionName
      End Get
      Set(ByVal value As String)
        _QCM_Regions12_RegionName = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        If _Description.Length > 100 Then
          Return "[" & _RequestID & "] " & _Description.Substring(0, 99)
        Else
          Return "[" & _RequestID & "] " & _Description
        End If
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _RequestID
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
    Public Class PKqcmRequests
			Private _RequestID As Int32 = 0
			Public Property RequestID() As Int32
				Get
					Return _RequestID
				End Get
				Set(ByVal value As Int32)
					_RequestID = value
				End Set
			End Property
    End Class
    Public ReadOnly Property FK_QCM_Requests_Createdby() As SIS.QCM.qcmEmployees
      Get
        If _FK_QCM_Requests_Createdby Is Nothing Then
          _FK_QCM_Requests_Createdby = SIS.QCM.qcmEmployees.qcmEmployeesGetByID(_CreatedBy)
        End If
        Return _FK_QCM_Requests_Createdby
      End Get
    End Property
    Public ReadOnly Property FK_QCM_Requests_AllotedTo() As SIS.QCM.qcmEmployees
      Get
        If _FK_QCM_Requests_AllotedTo Is Nothing Then
          _FK_QCM_Requests_AllotedTo = SIS.QCM.qcmEmployees.qcmEmployeesGetByID(_AllotedTo)
        End If
        Return _FK_QCM_Requests_AllotedTo
      End Get
    End Property
    Public ReadOnly Property FK_QCM_Requests_AllotedBy() As SIS.QCM.qcmEmployees
      Get
        If _FK_QCM_Requests_AllotedBy Is Nothing Then
          _FK_QCM_Requests_AllotedBy = SIS.QCM.qcmEmployees.qcmEmployeesGetByID(_AllotedBy)
        End If
        Return _FK_QCM_Requests_AllotedBy
      End Get
    End Property
    Public ReadOnly Property FK_QCM_Requests_CancelledBy() As SIS.QCM.qcmEmployees
      Get
        If _FK_QCM_Requests_CancelledBy Is Nothing Then
          _FK_QCM_Requests_CancelledBy = SIS.QCM.qcmEmployees.qcmEmployeesGetByID(_CancelledBy)
        End If
        Return _FK_QCM_Requests_CancelledBy
      End Get
    End Property
    Public ReadOnly Property FK_QCM_Requests_ReceivedBy() As SIS.QCM.qcmEmployees
      Get
        If _FK_QCM_Requests_ReceivedBy Is Nothing Then
          _FK_QCM_Requests_ReceivedBy = SIS.QCM.qcmEmployees.qcmEmployeesGetByID(_ReceivedBy)
        End If
        Return _FK_QCM_Requests_ReceivedBy
      End Get
    End Property
    Public ReadOnly Property FK_QCM_Requests_ProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_QCM_Requests_ProjectID Is Nothing Then
          _FK_QCM_Requests_ProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_ProjectID)
        End If
        Return _FK_QCM_Requests_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_QCM_Requests_SupplierID() As SIS.QCM.qcmVendors
      Get
        If _FK_QCM_Requests_SupplierID Is Nothing Then
          _FK_QCM_Requests_SupplierID = SIS.QCM.qcmVendors.qcmVendorsGetByID(_SupplierID)
        End If
        Return _FK_QCM_Requests_SupplierID
      End Get
    End Property
    Public ReadOnly Property FK_QCM_Requests_InspectionStageID() As SIS.QCM.qcmInspectionStages
      Get
        If _FK_QCM_Requests_InspectionStageID Is Nothing Then
          _FK_QCM_Requests_InspectionStageID = SIS.QCM.qcmInspectionStages.qcmInspectionStagesGetByID(_InspectionStageiD)
        End If
        Return _FK_QCM_Requests_InspectionStageID
      End Get
    End Property
    Public ReadOnly Property FK_QCM_Requests_RequestStateID() As SIS.QCM.qcmRequestStates
      Get
        If _FK_QCM_Requests_RequestStateID Is Nothing Then
          _FK_QCM_Requests_RequestStateID = SIS.QCM.qcmRequestStates.qcmRequestStatesGetByID(_RequestStateID)
        End If
        Return _FK_QCM_Requests_RequestStateID
      End Get
    End Property
    Public ReadOnly Property FK_QCM_Requests_RegionID() As SIS.QCM.qcmRegions
      Get
        If _FK_QCM_Requests_RegionID Is Nothing Then
          _FK_QCM_Requests_RegionID = SIS.QCM.qcmRegions.qcmRegionsGetByID(_RegionID)
        End If
        Return _FK_QCM_Requests_RegionID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function qcmRequestsSelectList(ByVal OrderBy As String) As List(Of SIS.QCM.qcmRequests)
      Dim Results As List(Of SIS.QCM.qcmRequests) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "RequestID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spqcmRequestsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.QCM.qcmRequests)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.QCM.qcmRequests(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function qcmRequestsGetNewRecord() As SIS.QCM.qcmRequests
      Return New SIS.QCM.qcmRequests()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function qcmRequestsGetByID(ByVal RequestID As Int32) As SIS.QCM.qcmRequests
      Dim Results As SIS.QCM.qcmRequests = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spqcmRequestsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestID",SqlDbType.Int,RequestID.ToString.Length, RequestID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.QCM.qcmRequests(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function qcmRequestsGetByID(ByVal RequestID As Int32, ByVal Filter_ProjectID As String, ByVal Filter_SupplierID As String, ByVal Filter_RequestStateID As String, ByVal Filter_InspectionStatusID As Int32) As SIS.QCM.qcmRequests
      Return qcmRequestsGetByID(RequestID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function qcmRequestsInsert(ByVal Record As SIS.QCM.qcmRequests) As SIS.QCM.qcmRequests
      Dim _Rec As SIS.QCM.qcmRequests = SIS.QCM.qcmRequests.qcmRequestsGetNewRecord()
      With _Rec
        .ProjectID = Record.ProjectID
        .OrderNo = Record.OrderNo
        .OrderDate = Record.OrderDate
        .SupplierID = Record.SupplierID
        .Description = Record.Description
        .TotalRequestedQuantity = Record.TotalRequestedQuantity
        .RequestedInspectionStartDate = Record.RequestedInspectionStartDate
        .ClientInspectionRequired = Record.ClientInspectionRequired
        .ThirdPartyInspectionRequired = Record.ThirdPartyInspectionRequired
        .ReceivedOn = Record.ReceivedOn
        .ReceivedBy = Record.ReceivedBy
        .ReceivingMediumID = Record.ReceivingMediumID
        .CreationRemarks = Record.CreationRemarks
        .CreatedBy =  Global.System.Web.HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
        .RequestStateID = "OPEN"
        .RegionID = Record.RegionID
        .LotSize = Record.LotSize
        .UOM = Record.UOM
        .InspectionStageiD = Record.InspectionStageiD
        .ReturnRemarks = Record.ReturnRemarks
      End With
      Return SIS.QCM.qcmRequests.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.QCM.qcmRequests) As SIS.QCM.qcmRequests
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spqcmRequestsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, 7, IIf(Record.ProjectID = "", Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderNo",SqlDbType.NVarChar,51, Iif(Record.OrderNo= "" ,Convert.DBNull, Record.OrderNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderDate",SqlDbType.DateTime,21, Iif(Record.OrderDate= "" ,Convert.DBNull, Record.OrderDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID", SqlDbType.NVarChar, 9, IIf(Record.SupplierID = "", Convert.DBNull, Record.SupplierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,501, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalRequestedQuantity",SqlDbType.NVarChar,51, Iif(Record.TotalRequestedQuantity= "" ,Convert.DBNull, Record.TotalRequestedQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestedInspectionStartDate", SqlDbType.DateTime, 21, IIf(Record.RequestedInspectionStartDate = "", Convert.DBNull, Record.RequestedInspectionStartDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestedInspectionFinishDate", SqlDbType.DateTime, 21, IIf(Record.RequestedInspectionFinishDate = "", Convert.DBNull, Record.RequestedInspectionFinishDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClientInspectionRequired", SqlDbType.Bit, 3, Record.ClientInspectionRequired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ThirdPartyInspectionRequired",SqlDbType.Bit,3, Record.ThirdPartyInspectionRequired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedOn",SqlDbType.DateTime,21, Iif(Record.ReceivedOn= "" ,Convert.DBNull, Record.ReceivedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedBy",SqlDbType.NVarChar,9, Iif(Record.ReceivedBy= "" ,Convert.DBNull, Record.ReceivedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivingMediumID",SqlDbType.Int,11, Iif(Record.ReceivingMediumID= "" ,Convert.DBNull, Record.ReceivingMediumID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreationRemarks",SqlDbType.NVarChar,501, Iif(Record.CreationRemarks= "" ,Convert.DBNull, Record.CreationRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Record.CreatedBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Record.CreatedOn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestStateID",SqlDbType.NVarChar,11, Record.RequestStateID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileAttached",SqlDbType.Bit,3, Record.FileAttached)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InspectionStageiD",SqlDbType.Int,11, Iif(Record.InspectionStageiD= "" ,Convert.DBNull, Record.InspectionStageiD))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AllotedTo",SqlDbType.NVarChar,9, Iif(Record.AllotedTo= "" ,Convert.DBNull, Record.AllotedTo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AllotedStartDate",SqlDbType.DateTime,21, Iif(Record.AllotedStartDate= "" ,Convert.DBNull, Record.AllotedStartDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AllotedFinishDate",SqlDbType.DateTime,21, Iif(Record.AllotedFinishDate= "" ,Convert.DBNull, Record.AllotedFinishDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AllotedOn",SqlDbType.DateTime,21, Iif(Record.AllotedOn= "" ,Convert.DBNull, Record.AllotedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AllotedBy",SqlDbType.NVarChar,9, Iif(Record.AllotedBy= "" ,Convert.DBNull, Record.AllotedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AllotmentRemarks",SqlDbType.NVarChar,501, Iif(Record.AllotmentRemarks= "" ,Convert.DBNull, Record.AllotmentRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InspectionStartDate",SqlDbType.DateTime,21, Iif(Record.InspectionStartDate= "" ,Convert.DBNull, Record.InspectionStartDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InspectionFinishDate",SqlDbType.DateTime,21, Iif(Record.InspectionFinishDate= "" ,Convert.DBNull, Record.InspectionFinishDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InspectionStatusID",SqlDbType.Int,11, Iif(Record.InspectionStatusID= "" ,Convert.DBNull, Record.InspectionStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CancelledOn",SqlDbType.DateTime,21, Iif(Record.CancelledOn= "" ,Convert.DBNull, Record.CancelledOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CancelledBy",SqlDbType.NVarChar,9, Iif(Record.CancelledBy= "" ,Convert.DBNull, Record.CancelledBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CancellationRemarks",SqlDbType.NVarChar,501, Iif(Record.CancellationRemarks= "" ,Convert.DBNull, Record.CancellationRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RegionID",SqlDbType.Int,11, Iif(Record.RegionID= "" ,Convert.DBNull, Record.RegionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReturnRemarks", SqlDbType.NVarChar, 250, IIf(Record.ReturnRemarks = "", Convert.DBNull, Record.ReturnRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOM", SqlDbType.NVarChar, 10, IIf(Record.UOM = "", Convert.DBNull, Record.UOM))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentID", SqlDbType.NVarChar, 50, IIf(Record.DocumentID = "", Convert.DBNull, Record.DocumentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LotSize", SqlDbType.NVarChar, 50, IIf(Record.LotSize = "", Convert.DBNull, Record.LotSize))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Paused", SqlDbType.Bit, 3, Record.Paused)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PausedHrs", SqlDbType.Decimal, 21, Record.PausedHrs)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalHrs", SqlDbType.Decimal, 21, Record.TotalHrs)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LastPausedOn", SqlDbType.DateTime, 21, IIf(Record.LastPausedOn = "", Convert.DBNull, Record.LastPausedOn))
          Cmd.Parameters.Add("@Return_RequestID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_RequestID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.RequestID = Cmd.Parameters("@Return_RequestID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function qcmRequestsUpdate(ByVal Record As SIS.QCM.qcmRequests) As SIS.QCM.qcmRequests
      Dim _Rec As SIS.QCM.qcmRequests = SIS.QCM.qcmRequests.qcmRequestsGetByID(Record.RequestID)
      With _Rec
        .ProjectID = Record.ProjectID
        .OrderNo = Record.OrderNo
        .OrderDate = Record.OrderDate
        .SupplierID = Record.SupplierID
        .Description = Record.Description
        .TotalRequestedQuantity = Record.TotalRequestedQuantity
        .RequestedInspectionStartDate = Record.RequestedInspectionStartDate
        .ClientInspectionRequired = Record.ClientInspectionRequired
        .ThirdPartyInspectionRequired = Record.ThirdPartyInspectionRequired
        .ReceivedOn = Record.ReceivedOn
        .ReceivedBy = Record.ReceivedBy
        .ReceivingMediumID = Record.ReceivingMediumID
        .CreationRemarks = Record.CreationRemarks
        .RegionID = Record.RegionID
        .LotSize = Record.LotSize
        .UOM = Record.UOM
        .InspectionStageiD = Record.InspectionStageiD
        .ReturnRemarks = Record.ReturnRemarks
      End With
      Return SIS.QCM.qcmRequests.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.QCM.qcmRequests) As SIS.QCM.qcmRequests
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spqcmRequestsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RequestID",SqlDbType.Int,11, Record.RequestID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, 7, IIf(Record.ProjectID = "", Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderNo", SqlDbType.NVarChar, 51, IIf(Record.OrderNo = "", Convert.DBNull, Record.OrderNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderDate",SqlDbType.DateTime,21, Iif(Record.OrderDate= "" ,Convert.DBNull, Record.OrderDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID", SqlDbType.NVarChar, 9, IIf(Record.SupplierID = "", Convert.DBNull, Record.SupplierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description", SqlDbType.NVarChar, 501, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalRequestedQuantity",SqlDbType.NVarChar,51, Iif(Record.TotalRequestedQuantity= "" ,Convert.DBNull, Record.TotalRequestedQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestedInspectionStartDate", SqlDbType.DateTime, 21, IIf(Record.RequestedInspectionStartDate = "", Convert.DBNull, Record.RequestedInspectionStartDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestedInspectionFinishDate", SqlDbType.DateTime, 21, IIf(Record.RequestedInspectionFinishDate = "", Convert.DBNull, Record.RequestedInspectionFinishDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClientInspectionRequired",SqlDbType.Bit,3, Record.ClientInspectionRequired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ThirdPartyInspectionRequired",SqlDbType.Bit,3, Record.ThirdPartyInspectionRequired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedOn",SqlDbType.DateTime,21, Iif(Record.ReceivedOn= "" ,Convert.DBNull, Record.ReceivedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedBy",SqlDbType.NVarChar,9, Iif(Record.ReceivedBy= "" ,Convert.DBNull, Record.ReceivedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivingMediumID",SqlDbType.Int,11, Iif(Record.ReceivingMediumID= "" ,Convert.DBNull, Record.ReceivingMediumID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreationRemarks",SqlDbType.NVarChar,501, Iif(Record.CreationRemarks= "" ,Convert.DBNull, Record.CreationRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Record.CreatedBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Record.CreatedOn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestStateID",SqlDbType.NVarChar,11, Record.RequestStateID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileAttached",SqlDbType.Bit,3, Record.FileAttached)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InspectionStageiD",SqlDbType.Int,11, Iif(Record.InspectionStageiD= "" ,Convert.DBNull, Record.InspectionStageiD))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AllotedTo",SqlDbType.NVarChar,9, Iif(Record.AllotedTo= "" ,Convert.DBNull, Record.AllotedTo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AllotedStartDate",SqlDbType.DateTime,21, Iif(Record.AllotedStartDate= "" ,Convert.DBNull, Record.AllotedStartDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AllotedFinishDate",SqlDbType.DateTime,21, Iif(Record.AllotedFinishDate= "" ,Convert.DBNull, Record.AllotedFinishDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AllotedOn",SqlDbType.DateTime,21, Iif(Record.AllotedOn= "" ,Convert.DBNull, Record.AllotedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AllotedBy",SqlDbType.NVarChar,9, Iif(Record.AllotedBy= "" ,Convert.DBNull, Record.AllotedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AllotmentRemarks",SqlDbType.NVarChar,501, Iif(Record.AllotmentRemarks= "" ,Convert.DBNull, Record.AllotmentRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InspectionStartDate",SqlDbType.DateTime,21, Iif(Record.InspectionStartDate= "" ,Convert.DBNull, Record.InspectionStartDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InspectionFinishDate",SqlDbType.DateTime,21, Iif(Record.InspectionFinishDate= "" ,Convert.DBNull, Record.InspectionFinishDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InspectionStatusID",SqlDbType.Int,11, Iif(Record.InspectionStatusID= "" ,Convert.DBNull, Record.InspectionStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CancelledOn",SqlDbType.DateTime,21, Iif(Record.CancelledOn= "" ,Convert.DBNull, Record.CancelledOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CancelledBy",SqlDbType.NVarChar,9, Iif(Record.CancelledBy= "" ,Convert.DBNull, Record.CancelledBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CancellationRemarks",SqlDbType.NVarChar,501, Iif(Record.CancellationRemarks= "" ,Convert.DBNull, Record.CancellationRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RegionID",SqlDbType.Int,11, Iif(Record.RegionID= "" ,Convert.DBNull, Record.RegionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReturnRemarks", SqlDbType.NVarChar, 250, IIf(Record.ReturnRemarks = "", Convert.DBNull, Record.ReturnRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOM", SqlDbType.NVarChar, 10, IIf(Record.UOM = "", Convert.DBNull, Record.UOM))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentID", SqlDbType.NVarChar, 50, IIf(Record.DocumentID = "", Convert.DBNull, Record.DocumentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LotSize", SqlDbType.NVarChar, 50, IIf(Record.LotSize = "", Convert.DBNull, Record.LotSize))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Paused", SqlDbType.Bit, 3, Record.Paused)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PausedHrs", SqlDbType.Decimal, 21, Record.PausedHrs)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalHrs", SqlDbType.Decimal, 21, Record.TotalHrs)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LastPausedOn", SqlDbType.DateTime, 21, IIf(Record.LastPausedOn = "", Convert.DBNull, Record.LastPausedOn))
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
    Public Shared Function qcmRequestsDelete(ByVal Record As SIS.QCM.qcmRequests) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spqcmRequestsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RequestID",SqlDbType.Int,Record.RequestID.ToString.Length, Record.RequestID)
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
