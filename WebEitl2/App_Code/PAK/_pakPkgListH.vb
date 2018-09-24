Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakPkgListH
    Private Shared _RecordCount As Integer
    Private _SerialNo As Int32 = 0
    Private _PkgNo As Int32 = 0
    Private _SupplierRefNo As String = ""
    Private _TransporterID As String = ""
    Private _TransporterName As String = ""
    Private _VehicleNo As String = ""
    Private _GRNo As String = ""
    Private _GRDate As String = ""
    Private _VRExecutionNo As String = ""
    Private _Remarks As String = ""
    Private _CreatedBy As String = ""
    Private _UOMTotalWeight As String = ""
    Private _Additional1Info As String = ""
    Private _Additional2Info As String = ""
    Private _CreatedOn As String = ""
    Private _TotalWeight As String = "0.00"
    Private _StatusID As String = ""
    Private _ReceivedAtPortOn As String = ""
    Public Property ReceivedAtPortBy As String = ""
    Private _PortID As String = ""
    Private _ProjectID As String = ""
    Private _ELOG_Ports8_Description As String = ""
    Private _IDM_Projects9_Description As String = ""
    Private _aspnet_Users7_UserFullName As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _PAK_PO2_PODescription As String = ""
    Private _PAK_Units3_Description As String = ""
    Private _VR_BusinessPartner4_BPName As String = ""
    Private _VR_RequestExecution5_ExecutionDescription As String = ""
    Private _PAK_PkgStatus6_Description As String = ""
    Private _FK_PAK_PkgListH_ReceivedAtPortBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_PAK_PkgListH_CreatedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_PAK_PkgListH_SerialNo As SIS.PAK.pakPO = Nothing
    Private _FK_PAK_PkgListH_UOMTotalWeight As SIS.PAK.pakUnits = Nothing
    Private _FK_PAK_PkgListH_TransporterID As SIS.PAK.pakBusinessPartner = Nothing
    Private _FK_PAK_PkgListH_VRExecutionNo As SIS.VR.vrRequestExecution = Nothing
    Private _FK_PAK_PkgListH_StatusID As SIS.PAK.pakPkgStatus = Nothing
    Private _FK_PAK_PkgListH_PortID As SIS.ELOG.elogPorts = Nothing
    Private _FK_PAK_PkgListH_ProjectID As SIS.QCM.qcmProjects = Nothing
    Public Property ELOG_Ports8_Description() As String
      Get
        Return _ELOG_Ports8_Description
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ELOG_Ports8_Description = ""
        Else
          _ELOG_Ports8_Description = value
        End If
      End Set
    End Property
    Public Property IDM_Projects9_Description() As String
      Get
        Return _IDM_Projects9_Description
      End Get
      Set(ByVal value As String)
        _IDM_Projects9_Description = value
      End Set
    End Property
    Public Property PortID() As String
      Get
        Return _PortID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _PortID = ""
        Else
          _PortID = value
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
    Public Property ReceivedAtPortOn() As String
      Get
        If Not _ReceivedAtPortOn = String.Empty Then
          Return Convert.ToDateTime(_ReceivedAtPortOn).ToString("dd/MM/yyyy")
        End If
        Return _ReceivedAtPortOn
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ReceivedAtPortOn = ""
        Else
          _ReceivedAtPortOn = value
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
    Public Property SerialNo() As Int32
      Get
        Return _SerialNo
      End Get
      Set(ByVal value As Int32)
        _SerialNo = value
      End Set
    End Property
    Public Property PkgNo() As Int32
      Get
        Return _PkgNo
      End Get
      Set(ByVal value As Int32)
        _PkgNo = value
      End Set
    End Property
    Public Property SupplierRefNo() As String
      Get
        Return _SupplierRefNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SupplierRefNo = ""
         Else
           _SupplierRefNo = value
         End If
      End Set
    End Property
    Public Property TransporterID() As String
      Get
        Return _TransporterID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
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
         If Convert.IsDBNull(Value) Then
           _TransporterName = ""
         Else
           _TransporterName = value
         End If
      End Set
    End Property
    Public Property VehicleNo() As String
      Get
        Return _VehicleNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VehicleNo = ""
         Else
           _VehicleNo = value
         End If
      End Set
    End Property
    Public Property GRNo() As String
      Get
        Return _GRNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _GRNo = ""
         Else
           _GRNo = value
         End If
      End Set
    End Property
    Public Property GRDate() As String
      Get
        If Not _GRDate = String.Empty Then
          Return Convert.ToDateTime(_GRDate).ToString("dd/MM/yyyy")
        End If
        Return _GRDate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _GRDate = ""
         Else
           _GRDate = value
         End If
      End Set
    End Property
    Public Property VRExecutionNo() As String
      Get
        Return _VRExecutionNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VRExecutionNo = ""
         Else
           _VRExecutionNo = value
         End If
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
    Public Property UOMTotalWeight() As String
      Get
        Return _UOMTotalWeight
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _UOMTotalWeight = ""
         Else
           _UOMTotalWeight = value
         End If
      End Set
    End Property
    Public Property Additional1Info() As String
      Get
        Return _Additional1Info
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Additional1Info = ""
         Else
           _Additional1Info = value
         End If
      End Set
    End Property
    Public Property Additional2Info() As String
      Get
        Return _Additional2Info
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Additional2Info = ""
         Else
           _Additional2Info = value
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
    Public Property TotalWeight() As String
      Get
        Return _TotalWeight
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
          _TotalWeight = "0.0000"
        Else
           _TotalWeight = value
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
    Public Property aspnet_Users1_UserFullName() As String
      Get
        Return _aspnet_Users1_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users1_UserFullName = value
      End Set
    End Property
    Public Property PAK_PO2_PODescription() As String
      Get
        Return _PAK_PO2_PODescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_PO2_PODescription = ""
         Else
           _PAK_PO2_PODescription = value
         End If
      End Set
    End Property
    Public Property PAK_Units3_Description() As String
      Get
        Return _PAK_Units3_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_Units3_Description = ""
         Else
           _PAK_Units3_Description = value
         End If
      End Set
    End Property
    Public Property VR_BusinessPartner4_BPName() As String
      Get
        Return _VR_BusinessPartner4_BPName
      End Get
      Set(ByVal value As String)
        _VR_BusinessPartner4_BPName = value
      End Set
    End Property
    Public Property VR_RequestExecution5_ExecutionDescription() As String
      Get
        Return _VR_RequestExecution5_ExecutionDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VR_RequestExecution5_ExecutionDescription = ""
         Else
           _VR_RequestExecution5_ExecutionDescription = value
         End If
      End Set
    End Property
    Public Property PAK_PkgStatus6_Description() As String
      Get
        Return _PAK_PkgStatus6_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_PkgStatus6_Description = ""
         Else
           _PAK_PkgStatus6_Description = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _SupplierRefNo.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _SerialNo & "|" & _PkgNo
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
    Public Class PKpakPkgListH
      Private _SerialNo As Int32 = 0
      Private _PkgNo As Int32 = 0
      Public Property SerialNo() As Int32
        Get
          Return _SerialNo
        End Get
        Set(ByVal value As Int32)
          _SerialNo = value
        End Set
      End Property
      Public Property PkgNo() As Int32
        Get
          Return _PkgNo
        End Get
        Set(ByVal value As Int32)
          _PkgNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PAK_PkgListH_PortID() As SIS.ELOG.elogPorts
      Get
        If _FK_PAK_PkgListH_PortID Is Nothing Then
          _FK_PAK_PkgListH_PortID = SIS.ELOG.elogPorts.elogPortsGetByID(_PortID)
        End If
        Return _FK_PAK_PkgListH_PortID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_PkgListH_ProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_PAK_PkgListH_ProjectID Is Nothing Then
          _FK_PAK_PkgListH_ProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_ProjectID)
        End If
        Return _FK_PAK_PkgListH_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_PkgListH_ReceivedAtPortBy() As SIS.QCM.qcmUsers
      Get
        If _FK_PAK_PkgListH_ReceivedAtPortBy Is Nothing Then
          _FK_PAK_PkgListH_ReceivedAtPortBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_ReceivedAtPortBy)
        End If
        Return _FK_PAK_PkgListH_ReceivedAtPortBy
      End Get
    End Property
    Public ReadOnly Property FK_PAK_PkgListH_CreatedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_PAK_PkgListH_CreatedBy Is Nothing Then
          _FK_PAK_PkgListH_CreatedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_CreatedBy)
        End If
        Return _FK_PAK_PkgListH_CreatedBy
      End Get
    End Property
    Public ReadOnly Property FK_PAK_PkgListH_SerialNo() As SIS.PAK.pakPO
      Get
        If _FK_PAK_PkgListH_SerialNo Is Nothing Then
          _FK_PAK_PkgListH_SerialNo = SIS.PAK.pakPO.pakPOGetByID(_SerialNo)
        End If
        Return _FK_PAK_PkgListH_SerialNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_PkgListH_UOMTotalWeight() As SIS.PAK.pakUnits
      Get
        If _FK_PAK_PkgListH_UOMTotalWeight Is Nothing Then
          _FK_PAK_PkgListH_UOMTotalWeight = SIS.PAK.pakUnits.pakUnitsGetByID(_UOMTotalWeight)
        End If
        Return _FK_PAK_PkgListH_UOMTotalWeight
      End Get
    End Property
    Public ReadOnly Property FK_PAK_PkgListH_TransporterID() As SIS.PAK.pakBusinessPartner
      Get
        If _FK_PAK_PkgListH_TransporterID Is Nothing Then
          _FK_PAK_PkgListH_TransporterID = SIS.PAK.pakBusinessPartner.pakBusinessPartnerGetByID(_TransporterID)
        End If
        Return _FK_PAK_PkgListH_TransporterID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_PkgListH_VRExecutionNo() As SIS.VR.vrRequestExecution
      Get
        If _FK_PAK_PkgListH_VRExecutionNo Is Nothing Then
          _FK_PAK_PkgListH_VRExecutionNo = SIS.VR.vrRequestExecution.vrRequestExecutionGetByID(_VRExecutionNo)
        End If
        Return _FK_PAK_PkgListH_VRExecutionNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_PkgListH_StatusID() As SIS.PAK.pakPkgStatus
      Get
        If _FK_PAK_PkgListH_StatusID Is Nothing Then
          _FK_PAK_PkgListH_StatusID = SIS.PAK.pakPkgStatus.pakPkgStatusGetByID(_StatusID)
        End If
        Return _FK_PAK_PkgListH_StatusID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakPkgListHSelectList(ByVal OrderBy As String) As List(Of SIS.PAK.pakPkgListH)
      Dim Results As List(Of SIS.PAK.pakPkgListH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakPkgListHSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakPkgListH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakPkgListH(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakPkgListHGetNewRecord() As SIS.PAK.pakPkgListH
      Return New SIS.PAK.pakPkgListH()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakPkgListHGetByID(ByVal SerialNo As Int32, ByVal PkgNo As Int32) As SIS.PAK.pakPkgListH
      Dim Results As SIS.PAK.pakPkgListH = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakPkgListHSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PkgNo",SqlDbType.Int,PkgNo.ToString.Length, PkgNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakPkgListH(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakPkgListHSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32) As List(Of SIS.PAK.pakPkgListH)
      Dim Results As List(Of SIS.PAK.pakPkgListH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakPkgListHSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakPkgListHSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakPkgListH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakPkgListH(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakPkgListHSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakPkgListHGetByID(ByVal SerialNo As Int32, ByVal PkgNo As Int32, ByVal Filter_SerialNo As Int32) As SIS.PAK.pakPkgListH
      Return pakPkgListHGetByID(SerialNo, PkgNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function pakPkgListHInsert(ByVal Record As SIS.PAK.pakPkgListH) As SIS.PAK.pakPkgListH
      Dim _Rec As SIS.PAK.pakPkgListH = SIS.PAK.pakPkgListH.pakPkgListHGetNewRecord()
      With _Rec
        .SerialNo = Record.SerialNo
        .SupplierRefNo = Record.SupplierRefNo
        .TransporterID = Record.TransporterID
        .TransporterName = Record.TransporterName
        .VehicleNo = Record.VehicleNo
        .GRNo = Record.GRNo
        .GRDate = Record.GRDate
        .VRExecutionNo = Record.VRExecutionNo
        .Remarks = Record.Remarks
        .CreatedBy =  Global.System.Web.HttpContext.Current.Session("LoginID")
        .UOMTotalWeight = Record.UOMTotalWeight
        .Additional1Info = Record.Additional1Info
        .Additional2Info = Record.Additional2Info
        .CreatedOn = Now
        .TotalWeight = Record.TotalWeight
        .StatusID = pakPkgStates.Free
        .PortID = Record.PortID
        .ProjectID = Record.ProjectID
      End With
      Return SIS.PAK.pakPkgListH.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PAK.pakPkgListH) As SIS.PAK.pakPkgListH
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakPkgListHInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierRefNo",SqlDbType.NVarChar,51, Iif(Record.SupplierRefNo= "" ,Convert.DBNull, Record.SupplierRefNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransporterID",SqlDbType.NVarChar,10, Iif(Record.TransporterID= "" ,Convert.DBNull, Record.TransporterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransporterName",SqlDbType.NVarChar,51, Iif(Record.TransporterName= "" ,Convert.DBNull, Record.TransporterName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleNo",SqlDbType.NVarChar,51, Iif(Record.VehicleNo= "" ,Convert.DBNull, Record.VehicleNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GRNo",SqlDbType.NVarChar,51, Iif(Record.GRNo= "" ,Convert.DBNull, Record.GRNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GRDate",SqlDbType.DateTime,21, Iif(Record.GRDate= "" ,Convert.DBNull, Record.GRDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VRExecutionNo",SqlDbType.Int,11, Iif(Record.VRExecutionNo= "" ,Convert.DBNull, Record.VRExecutionNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,501, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMTotalWeight",SqlDbType.Int,11, Iif(Record.UOMTotalWeight= "" ,Convert.DBNull, Record.UOMTotalWeight))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Additional1Info",SqlDbType.NVarChar,51, Iif(Record.Additional1Info= "" ,Convert.DBNull, Record.Additional1Info))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Additional2Info",SqlDbType.NVarChar,51, Iif(Record.Additional2Info= "" ,Convert.DBNull, Record.Additional2Info))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalWeight",SqlDbType.Decimal,21, Iif(Record.TotalWeight= "" ,Convert.DBNull, Record.TotalWeight))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedAtPortOn", SqlDbType.DateTime, 21, IIf(Record.ReceivedAtPortOn = "", Convert.DBNull, Record.ReceivedAtPortOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedAtPortBy", SqlDbType.NVarChar, 9, IIf(Record.ReceivedAtPortBy = "", Convert.DBNull, Record.ReceivedAtPortBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PortID", SqlDbType.Int, 11, IIf(Record.PortID = "", Convert.DBNull, Record.PortID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, 7, IIf(Record.ProjectID = "", Convert.DBNull, Record.ProjectID))
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_PkgNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_PkgNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
          Record.PkgNo = Cmd.Parameters("@Return_PkgNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakPkgListHUpdate(ByVal Record As SIS.PAK.pakPkgListH) As SIS.PAK.pakPkgListH
      Dim _Rec As SIS.PAK.pakPkgListH = SIS.PAK.pakPkgListH.pakPkgListHGetByID(Record.SerialNo, Record.PkgNo)
      With _Rec
        .SupplierRefNo = Record.SupplierRefNo
        .TransporterID = Record.TransporterID
        .TransporterName = Record.TransporterName
        .VehicleNo = Record.VehicleNo
        .GRNo = Record.GRNo
        .GRDate = Record.GRDate
        .VRExecutionNo = Record.VRExecutionNo
        .Remarks = Record.Remarks
        .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .UOMTotalWeight = Record.UOMTotalWeight
        .Additional1Info = Record.Additional1Info
        .Additional2Info = Record.Additional2Info
        .CreatedOn = Record.CreatedOn
        .TotalWeight = Record.TotalWeight
        .StatusID = Record.StatusID
      End With
      Return SIS.PAK.pakPkgListH.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PAK.pakPkgListH) As SIS.PAK.pakPkgListH
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakPkgListHUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_PkgNo",SqlDbType.Int,11, Record.PkgNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierRefNo",SqlDbType.NVarChar,51, Iif(Record.SupplierRefNo= "" ,Convert.DBNull, Record.SupplierRefNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransporterID",SqlDbType.NVarChar,10, Iif(Record.TransporterID= "" ,Convert.DBNull, Record.TransporterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransporterName",SqlDbType.NVarChar,51, Iif(Record.TransporterName= "" ,Convert.DBNull, Record.TransporterName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleNo",SqlDbType.NVarChar,51, Iif(Record.VehicleNo= "" ,Convert.DBNull, Record.VehicleNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GRNo",SqlDbType.NVarChar,51, Iif(Record.GRNo= "" ,Convert.DBNull, Record.GRNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GRDate",SqlDbType.DateTime,21, Iif(Record.GRDate= "" ,Convert.DBNull, Record.GRDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VRExecutionNo",SqlDbType.Int,11, Iif(Record.VRExecutionNo= "" ,Convert.DBNull, Record.VRExecutionNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,501, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMTotalWeight",SqlDbType.Int,11, Iif(Record.UOMTotalWeight= "" ,Convert.DBNull, Record.UOMTotalWeight))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Additional1Info",SqlDbType.NVarChar,51, Iif(Record.Additional1Info= "" ,Convert.DBNull, Record.Additional1Info))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Additional2Info",SqlDbType.NVarChar,51, Iif(Record.Additional2Info= "" ,Convert.DBNull, Record.Additional2Info))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalWeight",SqlDbType.Decimal,21, Iif(Record.TotalWeight= "" ,Convert.DBNull, Record.TotalWeight))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedAtPortOn", SqlDbType.DateTime, 21, IIf(Record.ReceivedAtPortOn = "", Convert.DBNull, Record.ReceivedAtPortOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceivedAtPortBy", SqlDbType.NVarChar, 9, IIf(Record.ReceivedAtPortBy = "", Convert.DBNull, Record.ReceivedAtPortBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PortID", SqlDbType.Int, 11, IIf(Record.PortID = "", Convert.DBNull, Record.PortID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, 7, IIf(Record.ProjectID = "", Convert.DBNull, Record.ProjectID))
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
    Public Shared Function pakPkgListHDelete(ByVal Record As SIS.PAK.pakPkgListH) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakPkgListHDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,Record.SerialNo.ToString.Length, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_PkgNo",SqlDbType.Int,Record.PkgNo.ToString.Length, Record.PkgNo)
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
    Public Shared Function SelectpakPkgListHAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakPkgListHAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),"" & "|" & ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.PAK.pakPkgListH = New SIS.PAK.pakPkgListH(Reader)
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
