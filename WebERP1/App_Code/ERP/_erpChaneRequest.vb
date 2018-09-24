Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ERP
  <DataObject()> _
  Partial Public Class erpChaneRequest
    Private Shared _RecordCount As Integer
    Private _ApplID As Int32 = 0
    Private _RequestID As Int32 = 0
    Private _RequestedBy As String = ""
    Private _RequestedOn As String = ""
    Private _RequestTypeID As Int32 = 0
    Private _ChangeSubject As String = ""
    Private _ChangeDetails As String = ""
    Private _ReturnRemarks As String = ""
    Private _ApprovedBy As String = ""
    Private _ApprovedOn As String = ""
    Private _EvaluationByIT As String = ""
    Private _EvaluationByITOn As String = ""
    Private _EvaluationByESC As String = ""
    Private _EvaluationByESCOn As String = ""
    Private _Justification As String = ""
    Private _StatusID As Int32 = 0
    Private _PriorityID As String = ""
    Private _MSLPortalNumber As String = ""
    Private _MSLPortalOn As String = ""
    Private _EffortEstimation As String = ""
    Private _PlannedDeliveryDate As String = ""
    Private _ActualDeliveryDate As String = ""
    Private _ClosingRemarks As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _aspnet_Users2_UserFullName As String = ""
    Private _ERP_Applications3_ApplName As String = ""
    Private _ERP_RequestPriority4_Description As String = ""
    Private _ERP_RequestStatus5_Description As String = ""
    Private _ERP_RequestTypes6_Description As String = ""
    Private _FK_ERP_ChaneRequest_RequestedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_ERP_ChaneRequest_ApprovedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_ERP_ChaneRequest_ApplID As SIS.ERP.erpApplications = Nothing
    Private _FK_ERP_ChaneRequest_PriorityID As SIS.ERP.erpRequestPriority = Nothing
    Private _FK_ERP_ChaneRequest_StatusID As SIS.ERP.erpRequestStatus = Nothing
    Private _FK_ERP_ChaneRequest_RequestTypeID As SIS.ERP.erpRequestTypes = Nothing
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
    Public Property ApplID() As Int32
      Get
        Return _ApplID
      End Get
      Set(ByVal value As Int32)
        _ApplID = value
      End Set
    End Property
    Public Property RequestID() As Int32
      Get
        Return _RequestID
      End Get
      Set(ByVal value As Int32)
        _RequestID = value
      End Set
    End Property
    Public Property RequestedBy() As String
      Get
        Return _RequestedBy
      End Get
      Set(ByVal value As String)
        _RequestedBy = value
      End Set
    End Property
    Public Property RequestedOn() As String
      Get
        If Not _RequestedOn = String.Empty Then
          Return Convert.ToDateTime(_RequestedOn).ToString("dd/MM/yyyy")
        End If
        Return _RequestedOn
      End Get
      Set(ByVal value As String)
			   _RequestedOn = value
      End Set
    End Property
    Public Property RequestTypeID() As Int32
      Get
        Return _RequestTypeID
      End Get
      Set(ByVal value As Int32)
        _RequestTypeID = value
      End Set
    End Property
    Public Property ChangeSubject() As String
      Get
        Return _ChangeSubject
      End Get
      Set(ByVal value As String)
        _ChangeSubject = value
      End Set
    End Property
    Public Property ChangeDetails() As String
      Get
        Return _ChangeDetails
      End Get
      Set(ByVal value As String)
        _ChangeDetails = value
      End Set
    End Property
    Public Property ReturnRemarks() As String
      Get
        Return _ReturnRemarks
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ReturnRemarks = ""
				 Else
					 _ReturnRemarks = value
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
    Public Property EvaluationByIT() As String
      Get
        Return _EvaluationByIT
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _EvaluationByIT = ""
				 Else
					 _EvaluationByIT = value
			   End If
      End Set
    End Property
    Public Property EvaluationByITOn() As String
      Get
        If Not _EvaluationByITOn = String.Empty Then
          Return Convert.ToDateTime(_EvaluationByITOn).ToString("dd/MM/yyyy")
        End If
        Return _EvaluationByITOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _EvaluationByITOn = ""
				 Else
					 _EvaluationByITOn = value
			   End If
      End Set
    End Property
    Public Property EvaluationByESC() As String
      Get
        Return _EvaluationByESC
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _EvaluationByESC = ""
				 Else
					 _EvaluationByESC = value
			   End If
      End Set
    End Property
    Public Property EvaluationByESCOn() As String
      Get
        If Not _EvaluationByESCOn = String.Empty Then
          Return Convert.ToDateTime(_EvaluationByESCOn).ToString("dd/MM/yyyy")
        End If
        Return _EvaluationByESCOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _EvaluationByESCOn = ""
				 Else
					 _EvaluationByESCOn = value
			   End If
      End Set
    End Property
    Public Property Justification() As String
      Get
        Return _Justification
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Justification = ""
				 Else
					 _Justification = value
			   End If
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
    Public Property PriorityID() As String
      Get
        Return _PriorityID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _PriorityID = ""
				 Else
					 _PriorityID = value
			   End If
      End Set
    End Property
    Public Property MSLPortalNumber() As String
      Get
        Return _MSLPortalNumber
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _MSLPortalNumber = ""
				 Else
					 _MSLPortalNumber = value
			   End If
      End Set
    End Property
    Public Property MSLPortalOn() As String
      Get
        If Not _MSLPortalOn = String.Empty Then
          Return Convert.ToDateTime(_MSLPortalOn).ToString("dd/MM/yyyy")
        End If
        Return _MSLPortalOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _MSLPortalOn = ""
				 Else
					 _MSLPortalOn = value
			   End If
      End Set
    End Property
    Public Property EffortEstimation() As String
      Get
        Return _EffortEstimation
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _EffortEstimation = ""
				 Else
					 _EffortEstimation = value
			   End If
      End Set
    End Property
    Public Property PlannedDeliveryDate() As String
      Get
        If Not _PlannedDeliveryDate = String.Empty Then
          Return Convert.ToDateTime(_PlannedDeliveryDate).ToString("dd/MM/yyyy")
        End If
        Return _PlannedDeliveryDate
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _PlannedDeliveryDate = ""
				 Else
					 _PlannedDeliveryDate = value
			   End If
      End Set
    End Property
    Public Property ActualDeliveryDate() As String
      Get
        If Not _ActualDeliveryDate = String.Empty Then
          Return Convert.ToDateTime(_ActualDeliveryDate).ToString("dd/MM/yyyy")
        End If
        Return _ActualDeliveryDate
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ActualDeliveryDate = ""
				 Else
					 _ActualDeliveryDate = value
			   End If
      End Set
    End Property
    Public Property ClosingRemarks() As String
      Get
        Return _ClosingRemarks
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ClosingRemarks = ""
				 Else
					 _ClosingRemarks = value
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
    Public Property ERP_Applications3_ApplName() As String
      Get
        Return _ERP_Applications3_ApplName
      End Get
      Set(ByVal value As String)
        _ERP_Applications3_ApplName = value
      End Set
    End Property
    Public Property ERP_RequestPriority4_Description() As String
      Get
        Return _ERP_RequestPriority4_Description
      End Get
      Set(ByVal value As String)
        _ERP_RequestPriority4_Description = value
      End Set
    End Property
    Public Property ERP_RequestStatus5_Description() As String
      Get
        Return _ERP_RequestStatus5_Description
      End Get
      Set(ByVal value As String)
        _ERP_RequestStatus5_Description = value
      End Set
    End Property
    Public Property ERP_RequestTypes6_Description() As String
      Get
        Return _ERP_RequestTypes6_Description
      End Get
      Set(ByVal value As String)
        _ERP_RequestTypes6_Description = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _ChangeSubject.ToString.PadRight(100, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _ApplID & "|" & _RequestID
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
    Public Class PKerpChaneRequest
			Private _ApplID As Int32 = 0
			Private _RequestID As Int32 = 0
			Public Property ApplID() As Int32
				Get
					Return _ApplID
				End Get
				Set(ByVal value As Int32)
					_ApplID = value
				End Set
			End Property
			Public Property RequestID() As Int32
				Get
					Return _RequestID
				End Get
				Set(ByVal value As Int32)
					_RequestID = value
				End Set
			End Property
    End Class
    Public ReadOnly Property FK_ERP_ChaneRequest_RequestedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_ERP_ChaneRequest_RequestedBy Is Nothing Then
          _FK_ERP_ChaneRequest_RequestedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_RequestedBy)
        End If
        Return _FK_ERP_ChaneRequest_RequestedBy
      End Get
    End Property
    Public ReadOnly Property FK_ERP_ChaneRequest_ApprovedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_ERP_ChaneRequest_ApprovedBy Is Nothing Then
          _FK_ERP_ChaneRequest_ApprovedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_ApprovedBy)
        End If
        Return _FK_ERP_ChaneRequest_ApprovedBy
      End Get
    End Property
    Public ReadOnly Property FK_ERP_ChaneRequest_ApplID() As SIS.ERP.erpApplications
      Get
        If _FK_ERP_ChaneRequest_ApplID Is Nothing Then
          _FK_ERP_ChaneRequest_ApplID = SIS.ERP.erpApplications.erpApplicationsGetByID(_ApplID)
        End If
        Return _FK_ERP_ChaneRequest_ApplID
      End Get
    End Property
    Public ReadOnly Property FK_ERP_ChaneRequest_PriorityID() As SIS.ERP.erpRequestPriority
      Get
        If _FK_ERP_ChaneRequest_PriorityID Is Nothing Then
          _FK_ERP_ChaneRequest_PriorityID = SIS.ERP.erpRequestPriority.erpRequestPriorityGetByID(_PriorityID)
        End If
        Return _FK_ERP_ChaneRequest_PriorityID
      End Get
    End Property
    Public ReadOnly Property FK_ERP_ChaneRequest_StatusID() As SIS.ERP.erpRequestStatus
      Get
        If _FK_ERP_ChaneRequest_StatusID Is Nothing Then
          _FK_ERP_ChaneRequest_StatusID = SIS.ERP.erpRequestStatus.erpRequestStatusGetByID(_StatusID)
        End If
        Return _FK_ERP_ChaneRequest_StatusID
      End Get
    End Property
    Public ReadOnly Property FK_ERP_ChaneRequest_RequestTypeID() As SIS.ERP.erpRequestTypes
      Get
        If _FK_ERP_ChaneRequest_RequestTypeID Is Nothing Then
          _FK_ERP_ChaneRequest_RequestTypeID = SIS.ERP.erpRequestTypes.erpRequestTypesGetByID(_RequestTypeID)
        End If
        Return _FK_ERP_ChaneRequest_RequestTypeID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpChaneRequestSelectList(ByVal OrderBy As String) As List(Of SIS.ERP.erpChaneRequest)
      Dim Results As List(Of SIS.ERP.erpChaneRequest) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "ApplID, RequestID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpChaneRequestSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ERP.erpChaneRequest)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ERP.erpChaneRequest(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpChaneRequestGetNewRecord() As SIS.ERP.erpChaneRequest
      Return New SIS.ERP.erpChaneRequest()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpChaneRequestGetByID(ByVal ApplID As Int32, ByVal RequestID As Int32) As SIS.ERP.erpChaneRequest
      Dim Results As SIS.ERP.erpChaneRequest = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpChaneRequestSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplID",SqlDbType.Int,ApplID.ToString.Length, ApplID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestID",SqlDbType.Int,RequestID.ToString.Length, RequestID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.ERP.erpChaneRequest(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpChaneRequestSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ApplID As Int32, ByVal RequestedBy As String, ByVal RequestTypeID As Int32, ByVal StatusID As Int32, ByVal PriorityID As Int32) As List(Of SIS.ERP.erpChaneRequest)
      Dim Results As List(Of SIS.ERP.erpChaneRequest) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "ApplID, RequestID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "sperpChaneRequestSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "sperpChaneRequestSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ApplID",SqlDbType.Int,10, IIf(ApplID = Nothing, 0,ApplID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RequestedBy",SqlDbType.NVarChar,8, IIf(RequestedBy Is Nothing, String.Empty,RequestedBy))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RequestTypeID",SqlDbType.Int,10, IIf(RequestTypeID = Nothing, 0,RequestTypeID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StatusID",SqlDbType.Int,10, IIf(StatusID = Nothing, 0,StatusID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PriorityID",SqlDbType.Int,10, IIf(PriorityID = Nothing, 0,PriorityID))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ERP.erpChaneRequest)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ERP.erpChaneRequest(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function erpChaneRequestSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ApplID As Int32, ByVal RequestedBy As String, ByVal RequestTypeID As Int32, ByVal StatusID As Int32, ByVal PriorityID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpChaneRequestGetByID(ByVal ApplID As Int32, ByVal RequestID As Int32, ByVal Filter_ApplID As Int32, ByVal Filter_RequestedBy As String, ByVal Filter_RequestTypeID As Int32, ByVal Filter_StatusID As Int32, ByVal Filter_PriorityID As Int32) As SIS.ERP.erpChaneRequest
      Return erpChaneRequestGetByID(ApplID, RequestID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function erpChaneRequestInsert(ByVal Record As SIS.ERP.erpChaneRequest) As SIS.ERP.erpChaneRequest
      Dim _Rec As SIS.ERP.erpChaneRequest = SIS.ERP.erpChaneRequest.erpChaneRequestGetNewRecord()
      With _Rec
        .ApplID = Record.ApplID
        .RequestedBy =  Global.System.Web.HttpContext.Current.Session("LoginID")
        .RequestedOn = Now
        .RequestTypeID = Record.RequestTypeID
        .ChangeSubject = Record.ChangeSubject
        .ChangeDetails = Record.ChangeDetails
        .StatusID = "3"
      End With
      Return SIS.ERP.erpChaneRequest.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.ERP.erpChaneRequest) As SIS.ERP.erpChaneRequest
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpChaneRequestInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplID",SqlDbType.Int,11, Record.ApplID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestedBy",SqlDbType.NVarChar,9, Record.RequestedBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestedOn",SqlDbType.DateTime,21, Record.RequestedOn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestTypeID",SqlDbType.Int,11, Record.RequestTypeID)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ChangeSubject", SqlDbType.NVarChar, 1001, Record.ChangeSubject)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ChangeDetails", SqlDbType.NVarChar, 2001, Record.ChangeDetails)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReturnRemarks",SqlDbType.NVarChar,101, Iif(Record.ReturnRemarks= "" ,Convert.DBNull, Record.ReturnRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy",SqlDbType.NVarChar,9, Iif(Record.ApprovedBy= "" ,Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedOn",SqlDbType.DateTime,21, Iif(Record.ApprovedOn= "" ,Convert.DBNull, Record.ApprovedOn))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EvaluationByIT", SqlDbType.NVarChar, 2001, IIf(Record.EvaluationByIT = "", Convert.DBNull, Record.EvaluationByIT))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EvaluationByITOn",SqlDbType.DateTime,21, Iif(Record.EvaluationByITOn= "" ,Convert.DBNull, Record.EvaluationByITOn))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EvaluationByESC", SqlDbType.NVarChar, 2001, IIf(Record.EvaluationByESC = "", Convert.DBNull, Record.EvaluationByESC))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EvaluationByESCOn",SqlDbType.DateTime,21, Iif(Record.EvaluationByESCOn= "" ,Convert.DBNull, Record.EvaluationByESCOn))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Justification", SqlDbType.NVarChar, 1001, IIf(Record.Justification = "", Convert.DBNull, Record.Justification))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Record.StatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PriorityID",SqlDbType.Int,11, Iif(Record.PriorityID= "" ,Convert.DBNull, Record.PriorityID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MSLPortalNumber",SqlDbType.NVarChar,51, Iif(Record.MSLPortalNumber= "" ,Convert.DBNull, Record.MSLPortalNumber))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MSLPortalOn",SqlDbType.DateTime,21, Iif(Record.MSLPortalOn= "" ,Convert.DBNull, Record.MSLPortalOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EffortEstimation",SqlDbType.Decimal,13, Iif(Record.EffortEstimation= "" ,Convert.DBNull, Record.EffortEstimation))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PlannedDeliveryDate",SqlDbType.DateTime,21, Iif(Record.PlannedDeliveryDate= "" ,Convert.DBNull, Record.PlannedDeliveryDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActualDeliveryDate",SqlDbType.DateTime,21, Iif(Record.ActualDeliveryDate= "" ,Convert.DBNull, Record.ActualDeliveryDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClosingRemarks",SqlDbType.NVarChar,101, Iif(Record.ClosingRemarks= "" ,Convert.DBNull, Record.ClosingRemarks))
          Cmd.Parameters.Add("@Return_ApplID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ApplID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_RequestID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_RequestID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ApplID = Cmd.Parameters("@Return_ApplID").Value
          Record.RequestID = Cmd.Parameters("@Return_RequestID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function erpChaneRequestUpdate(ByVal Record As SIS.ERP.erpChaneRequest) As SIS.ERP.erpChaneRequest
      Dim _Rec As SIS.ERP.erpChaneRequest = SIS.ERP.erpChaneRequest.erpChaneRequestGetByID(Record.ApplID, Record.RequestID)
      With _Rec
        .RequestedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .RequestedOn = Now
        .RequestTypeID = Record.RequestTypeID
        .ChangeSubject = Record.ChangeSubject
        .ChangeDetails = Record.ChangeDetails
      End With
      Return SIS.ERP.erpChaneRequest.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.ERP.erpChaneRequest) As SIS.ERP.erpChaneRequest
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpChaneRequestUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ApplID",SqlDbType.Int,11, Record.ApplID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RequestID",SqlDbType.Int,11, Record.RequestID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplID",SqlDbType.Int,11, Record.ApplID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestedBy",SqlDbType.NVarChar,9, Record.RequestedBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestedOn",SqlDbType.DateTime,21, Record.RequestedOn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestTypeID",SqlDbType.Int,11, Record.RequestTypeID)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ChangeSubject", SqlDbType.NVarChar, 1001, Record.ChangeSubject)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ChangeDetails", SqlDbType.NVarChar, 2001, Record.ChangeDetails)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReturnRemarks",SqlDbType.NVarChar,101, Iif(Record.ReturnRemarks= "" ,Convert.DBNull, Record.ReturnRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy",SqlDbType.NVarChar,9, Iif(Record.ApprovedBy= "" ,Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedOn",SqlDbType.DateTime,21, Iif(Record.ApprovedOn= "" ,Convert.DBNull, Record.ApprovedOn))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EvaluationByIT", SqlDbType.NVarChar, 2001, IIf(Record.EvaluationByIT = "", Convert.DBNull, Record.EvaluationByIT))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EvaluationByITOn",SqlDbType.DateTime,21, Iif(Record.EvaluationByITOn= "" ,Convert.DBNull, Record.EvaluationByITOn))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EvaluationByESC", SqlDbType.NVarChar, 2001, IIf(Record.EvaluationByESC = "", Convert.DBNull, Record.EvaluationByESC))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EvaluationByESCOn",SqlDbType.DateTime,21, Iif(Record.EvaluationByESCOn= "" ,Convert.DBNull, Record.EvaluationByESCOn))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Justification", SqlDbType.NVarChar, 1001, IIf(Record.Justification = "", Convert.DBNull, Record.Justification))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Record.StatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PriorityID",SqlDbType.Int,11, Iif(Record.PriorityID= "" ,Convert.DBNull, Record.PriorityID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MSLPortalNumber",SqlDbType.NVarChar,51, Iif(Record.MSLPortalNumber= "" ,Convert.DBNull, Record.MSLPortalNumber))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MSLPortalOn",SqlDbType.DateTime,21, Iif(Record.MSLPortalOn= "" ,Convert.DBNull, Record.MSLPortalOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EffortEstimation",SqlDbType.Decimal,13, Iif(Record.EffortEstimation= "" ,Convert.DBNull, Record.EffortEstimation))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PlannedDeliveryDate",SqlDbType.DateTime,21, Iif(Record.PlannedDeliveryDate= "" ,Convert.DBNull, Record.PlannedDeliveryDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActualDeliveryDate",SqlDbType.DateTime,21, Iif(Record.ActualDeliveryDate= "" ,Convert.DBNull, Record.ActualDeliveryDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClosingRemarks",SqlDbType.NVarChar,101, Iif(Record.ClosingRemarks= "" ,Convert.DBNull, Record.ClosingRemarks))
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
    Public Shared Function erpChaneRequestDelete(ByVal Record As SIS.ERP.erpChaneRequest) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpChaneRequestDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ApplID",SqlDbType.Int,Record.ApplID.ToString.Length, Record.ApplID)
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
'		Autocomplete Method
		Public Shared Function SelecterpChaneRequestAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "sperpChaneRequestAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
					Results = New List(Of String)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Not Reader.HasRows Then
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(100, " "),"" & "|" & ""))
					End If
					While (Reader.Read())
            Dim Tmp As SIS.ERP.erpChaneRequest = New SIS.ERP.erpChaneRequest(Reader)
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results.ToArray
		End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _ApplID = Ctype(Reader("ApplID"),Int32)
      _RequestID = Ctype(Reader("RequestID"),Int32)
      _RequestedBy = Ctype(Reader("RequestedBy"),String)
      _RequestedOn = Ctype(Reader("RequestedOn"),DateTime)
      _RequestTypeID = Ctype(Reader("RequestTypeID"),Int32)
      _ChangeSubject = Ctype(Reader("ChangeSubject"),String)
      _ChangeDetails = Ctype(Reader("ChangeDetails"),String)
      If Convert.IsDBNull(Reader("ReturnRemarks")) Then
        _ReturnRemarks = String.Empty
      Else
        _ReturnRemarks = Ctype(Reader("ReturnRemarks"), String)
      End If
      If Convert.IsDBNull(Reader("ApprovedBy")) Then
        _ApprovedBy = String.Empty
      Else
        _ApprovedBy = Ctype(Reader("ApprovedBy"), String)
      End If
      If Convert.IsDBNull(Reader("ApprovedOn")) Then
        _ApprovedOn = String.Empty
      Else
        _ApprovedOn = Ctype(Reader("ApprovedOn"), String)
      End If
      If Convert.IsDBNull(Reader("EvaluationByIT")) Then
        _EvaluationByIT = String.Empty
      Else
        _EvaluationByIT = Ctype(Reader("EvaluationByIT"), String)
      End If
      If Convert.IsDBNull(Reader("EvaluationByITOn")) Then
        _EvaluationByITOn = String.Empty
      Else
        _EvaluationByITOn = Ctype(Reader("EvaluationByITOn"), String)
      End If
      If Convert.IsDBNull(Reader("EvaluationByESC")) Then
        _EvaluationByESC = String.Empty
      Else
        _EvaluationByESC = Ctype(Reader("EvaluationByESC"), String)
      End If
      If Convert.IsDBNull(Reader("EvaluationByESCOn")) Then
        _EvaluationByESCOn = String.Empty
      Else
        _EvaluationByESCOn = Ctype(Reader("EvaluationByESCOn"), String)
      End If
      If Convert.IsDBNull(Reader("Justification")) Then
        _Justification = String.Empty
      Else
        _Justification = Ctype(Reader("Justification"), String)
      End If
      _StatusID = Ctype(Reader("StatusID"),Int32)
      If Convert.IsDBNull(Reader("PriorityID")) Then
        _PriorityID = String.Empty
      Else
        _PriorityID = Ctype(Reader("PriorityID"), String)
      End If
      If Convert.IsDBNull(Reader("MSLPortalNumber")) Then
        _MSLPortalNumber = String.Empty
      Else
        _MSLPortalNumber = Ctype(Reader("MSLPortalNumber"), String)
      End If
      If Convert.IsDBNull(Reader("MSLPortalOn")) Then
        _MSLPortalOn = String.Empty
      Else
        _MSLPortalOn = Ctype(Reader("MSLPortalOn"), String)
      End If
      If Convert.IsDBNull(Reader("EffortEstimation")) Then
        _EffortEstimation = String.Empty
      Else
        _EffortEstimation = Ctype(Reader("EffortEstimation"), String)
      End If
      If Convert.IsDBNull(Reader("PlannedDeliveryDate")) Then
        _PlannedDeliveryDate = String.Empty
      Else
        _PlannedDeliveryDate = Ctype(Reader("PlannedDeliveryDate"), String)
      End If
      If Convert.IsDBNull(Reader("ActualDeliveryDate")) Then
        _ActualDeliveryDate = String.Empty
      Else
        _ActualDeliveryDate = Ctype(Reader("ActualDeliveryDate"), String)
      End If
      If Convert.IsDBNull(Reader("ClosingRemarks")) Then
        _ClosingRemarks = String.Empty
      Else
        _ClosingRemarks = Ctype(Reader("ClosingRemarks"), String)
      End If
      _aspnet_Users1_UserFullName = Ctype(Reader("aspnet_Users1_UserFullName"),String)
      _aspnet_Users2_UserFullName = Ctype(Reader("aspnet_Users2_UserFullName"),String)
      _ERP_Applications3_ApplName = Ctype(Reader("ERP_Applications3_ApplName"),String)
      _ERP_RequestPriority4_Description = Ctype(Reader("ERP_RequestPriority4_Description"),String)
      _ERP_RequestStatus5_Description = Ctype(Reader("ERP_RequestStatus5_Description"),String)
      _ERP_RequestTypes6_Description = Ctype(Reader("ERP_RequestTypes6_Description"),String)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
