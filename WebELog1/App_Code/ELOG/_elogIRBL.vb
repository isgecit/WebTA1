Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ELOG
  <DataObject()>
  Partial Public Class elogIRBL
    Private Shared _RecordCount As Integer
    Private _IRNo As Int32 = 0
    Private _SupplierID As String = ""
    Private _ProjectID As String = ""
    Private _PONo As String = ""
    Private _SupplierBillNo As String = ""
    Private _supplierBillDate As String = ""
    Private _SupplierBillAmount As String = "0.00"
    Private _IRDate As String = ""
    Private _BLID As String = ""
    Private _BLType As String = ""
    Private _MBLNo As String = ""
    Private _Remarks As String = ""
    Private _ShipmentModeID As String = ""
    Private _CarrierID As String = ""
    Private _OtherCarrier As String = ""
    Private _LocationCountryID As String = ""
    Private _OtherCountry As String = ""
    Private _CargoTypeID As String = ""
    Private _PortID As String = ""
    Private _OtherPortLoadingOrigin As String = ""
    Private _StatusID As String = ""
    Private _CreatedOn As String = ""
    Private _CreatedBy As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _ELOG_BLHeader2_BLNumber As String = ""
    Private _ELOG_BLTypes3_Description As String = ""
    Private _ELOG_CargoTypes4_Description As String = ""
    Private _ELOG_Carriers5_Description As String = ""
    Private _ELOG_LocationCountries6_Description As String = ""
    Private _ELOG_Ports7_Description As String = ""
    Private _ELOG_ShipmentModes8_Description As String = ""
    Private _IDM_Projects9_Description As String = ""
    Private _VR_BusinessPartner10_BPName As String = ""
    Private _ELOG_IRBLStates11_Description As String = ""
    Private _FK_ELOG_IRBL_CreatedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_ELOG_IRBL_BLID As SIS.ELOG.elogBLHeader = Nothing
    Private _FK_ELOG_IRBL_BLType As SIS.ELOG.elogBLTypes = Nothing
    Private _FK_ELOG_IRBL_CargoTypeID As SIS.ELOG.elogCargoTypes = Nothing
    Private _FK_ELOG_IRBL_CarrierID As SIS.ELOG.elogCarriers = Nothing
    Private _FK_ELOG_IRBL_LocationCountryID As SIS.ELOG.elogLocationCountries = Nothing
    Private _FK_ELOG_IRBL_PortID As SIS.ELOG.elogPorts = Nothing
    Private _FK_ELOG_IRBL_ShipmentModeID As SIS.ELOG.elogShipmentModes = Nothing
    Private _FK_ELOG_IRBL_ProjectID As SIS.QCM.qcmProjects = Nothing
    Private _FK_ELOG_IRBL_SupplierID As SIS.VR.vrBusinessPartner = Nothing
    Private _FK_ELOG_IRBL_StatusID As SIS.ELOG.elogIRBLStates = Nothing
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
    Public Property IRNo() As Int32
      Get
        Return _IRNo
      End Get
      Set(ByVal value As Int32)
        _IRNo = value
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
    Public Property PONo() As String
      Get
        Return _PONo
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _PONo = ""
        Else
          _PONo = value
        End If
      End Set
    End Property
    Public Property SupplierBillNo() As String
      Get
        Return _SupplierBillNo
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _SupplierBillNo = ""
        Else
          _SupplierBillNo = value
        End If
      End Set
    End Property
    Public Property supplierBillDate() As String
      Get
        If Not _supplierBillDate = String.Empty Then
          Return Convert.ToDateTime(_supplierBillDate).ToString("dd/MM/yyyy")
        End If
        Return _supplierBillDate
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _supplierBillDate = ""
        Else
          _supplierBillDate = value
        End If
      End Set
    End Property
    Public Property SupplierBillAmount() As String
      Get
        Return _SupplierBillAmount
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _SupplierBillAmount = "0.00"
        Else
          _SupplierBillAmount = value
        End If
      End Set
    End Property
    Public Property IRDate() As String
      Get
        If Not _IRDate = String.Empty Then
          Return Convert.ToDateTime(_IRDate).ToString("dd/MM/yyyy")
        End If
        Return _IRDate
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _IRDate = ""
        Else
          _IRDate = value
        End If
      End Set
    End Property
    Public Property BLID() As String
      Get
        Return _BLID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _BLID = ""
        Else
          _BLID = value
        End If
      End Set
    End Property
    Public Property BLType() As String
      Get
        Return _BLType
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _BLType = ""
        Else
          _BLType = value
        End If
      End Set
    End Property
    Public Property MBLNo() As String
      Get
        Return _MBLNo
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _MBLNo = ""
        Else
          _MBLNo = value
        End If
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
    Public Property ShipmentModeID() As String
      Get
        Return _ShipmentModeID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ShipmentModeID = ""
        Else
          _ShipmentModeID = value
        End If
      End Set
    End Property
    Public Property CarrierID() As String
      Get
        Return _CarrierID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _CarrierID = ""
        Else
          _CarrierID = value
        End If
      End Set
    End Property
    Public Property OtherCarrier() As String
      Get
        Return _OtherCarrier
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _OtherCarrier = ""
        Else
          _OtherCarrier = value
        End If
      End Set
    End Property
    Public Property LocationCountryID() As String
      Get
        Return _LocationCountryID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _LocationCountryID = ""
        Else
          _LocationCountryID = value
        End If
      End Set
    End Property
    Public Property OtherCountry() As String
      Get
        Return _OtherCountry
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _OtherCountry = ""
        Else
          _OtherCountry = value
        End If
      End Set
    End Property
    Public Property CargoTypeID() As String
      Get
        Return _CargoTypeID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _CargoTypeID = ""
        Else
          _CargoTypeID = value
        End If
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
    Public Property OtherPortLoadingOrigin() As String
      Get
        Return _OtherPortLoadingOrigin
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _OtherPortLoadingOrigin = ""
        Else
          _OtherPortLoadingOrigin = value
        End If
      End Set
    End Property
    Public Property StatusID() As String
      Get
        Return _StatusID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _StatusID = ""
        Else
          _StatusID = value
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
    Public Property aspnet_Users1_UserFullName() As String
      Get
        Return _aspnet_Users1_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users1_UserFullName = value
      End Set
    End Property
    Public Property ELOG_BLHeader2_BLNumber() As String
      Get
        Return _ELOG_BLHeader2_BLNumber
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ELOG_BLHeader2_BLNumber = ""
        Else
          _ELOG_BLHeader2_BLNumber = value
        End If
      End Set
    End Property
    Public Property ELOG_BLTypes3_Description() As String
      Get
        Return _ELOG_BLTypes3_Description
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ELOG_BLTypes3_Description = ""
        Else
          _ELOG_BLTypes3_Description = value
        End If
      End Set
    End Property
    Public Property ELOG_CargoTypes4_Description() As String
      Get
        Return _ELOG_CargoTypes4_Description
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ELOG_CargoTypes4_Description = ""
        Else
          _ELOG_CargoTypes4_Description = value
        End If
      End Set
    End Property
    Public Property ELOG_Carriers5_Description() As String
      Get
        Return _ELOG_Carriers5_Description
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ELOG_Carriers5_Description = ""
        Else
          _ELOG_Carriers5_Description = value
        End If
      End Set
    End Property
    Public Property ELOG_LocationCountries6_Description() As String
      Get
        Return _ELOG_LocationCountries6_Description
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ELOG_LocationCountries6_Description = ""
        Else
          _ELOG_LocationCountries6_Description = value
        End If
      End Set
    End Property
    Public Property ELOG_Ports7_Description() As String
      Get
        Return _ELOG_Ports7_Description
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ELOG_Ports7_Description = ""
        Else
          _ELOG_Ports7_Description = value
        End If
      End Set
    End Property
    Public Property ELOG_ShipmentModes8_Description() As String
      Get
        Return _ELOG_ShipmentModes8_Description
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ELOG_ShipmentModes8_Description = ""
        Else
          _ELOG_ShipmentModes8_Description = value
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
    Public Property VR_BusinessPartner10_BPName() As String
      Get
        Return _VR_BusinessPartner10_BPName
      End Get
      Set(ByVal value As String)
        _VR_BusinessPartner10_BPName = value
      End Set
    End Property
    Public Property ELOG_IRBLStates11_Description() As String
      Get
        Return _ELOG_IRBLStates11_Description
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _ELOG_IRBLStates11_Description = ""
        Else
          _ELOG_IRBLStates11_Description = value
        End If
      End Set
    End Property
    Public ReadOnly Property DisplayField() As String
      Get
        Return "" & _SupplierBillNo.ToString.PadRight(50, " ")
      End Get
    End Property
    Public ReadOnly Property PrimaryKey() As String
      Get
        Return _IRNo
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
    Public Class PKelogIRBL
      Private _IRNo As Int32 = 0
      Public Property IRNo() As Int32
        Get
          Return _IRNo
        End Get
        Set(ByVal value As Int32)
          _IRNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_ELOG_IRBL_CreatedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_ELOG_IRBL_CreatedBy Is Nothing Then
          _FK_ELOG_IRBL_CreatedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_CreatedBy)
        End If
        Return _FK_ELOG_IRBL_CreatedBy
      End Get
    End Property
    Public ReadOnly Property FK_ELOG_IRBL_BLID() As SIS.ELOG.elogBLHeader
      Get
        If _FK_ELOG_IRBL_BLID Is Nothing Then
          _FK_ELOG_IRBL_BLID = SIS.ELOG.elogBLHeader.elogBLHeaderGetByID(_BLID)
        End If
        Return _FK_ELOG_IRBL_BLID
      End Get
    End Property
    Public ReadOnly Property FK_ELOG_IRBL_BLType() As SIS.ELOG.elogBLTypes
      Get
        If _FK_ELOG_IRBL_BLType Is Nothing Then
          _FK_ELOG_IRBL_BLType = SIS.ELOG.elogBLTypes.elogBLTypesGetByID(_BLType)
        End If
        Return _FK_ELOG_IRBL_BLType
      End Get
    End Property
    Public ReadOnly Property FK_ELOG_IRBL_CargoTypeID() As SIS.ELOG.elogCargoTypes
      Get
        If _FK_ELOG_IRBL_CargoTypeID Is Nothing Then
          _FK_ELOG_IRBL_CargoTypeID = SIS.ELOG.elogCargoTypes.elogCargoTypesGetByID(_CargoTypeID)
        End If
        Return _FK_ELOG_IRBL_CargoTypeID
      End Get
    End Property
    Public ReadOnly Property FK_ELOG_IRBL_CarrierID() As SIS.ELOG.elogCarriers
      Get
        If _FK_ELOG_IRBL_CarrierID Is Nothing Then
          _FK_ELOG_IRBL_CarrierID = SIS.ELOG.elogCarriers.elogCarriersGetByID(_CarrierID)
        End If
        Return _FK_ELOG_IRBL_CarrierID
      End Get
    End Property
    Public ReadOnly Property FK_ELOG_IRBL_LocationCountryID() As SIS.ELOG.elogLocationCountries
      Get
        If _FK_ELOG_IRBL_LocationCountryID Is Nothing Then
          _FK_ELOG_IRBL_LocationCountryID = SIS.ELOG.elogLocationCountries.elogLocationCountriesGetByID(_LocationCountryID)
        End If
        Return _FK_ELOG_IRBL_LocationCountryID
      End Get
    End Property
    Public ReadOnly Property FK_ELOG_IRBL_PortID() As SIS.ELOG.elogPorts
      Get
        If _FK_ELOG_IRBL_PortID Is Nothing Then
          _FK_ELOG_IRBL_PortID = SIS.ELOG.elogPorts.elogPortsGetByID(_PortID)
        End If
        Return _FK_ELOG_IRBL_PortID
      End Get
    End Property
    Public ReadOnly Property FK_ELOG_IRBL_ShipmentModeID() As SIS.ELOG.elogShipmentModes
      Get
        If _FK_ELOG_IRBL_ShipmentModeID Is Nothing Then
          _FK_ELOG_IRBL_ShipmentModeID = SIS.ELOG.elogShipmentModes.elogShipmentModesGetByID(_ShipmentModeID)
        End If
        Return _FK_ELOG_IRBL_ShipmentModeID
      End Get
    End Property
    Public ReadOnly Property FK_ELOG_IRBL_ProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_ELOG_IRBL_ProjectID Is Nothing Then
          _FK_ELOG_IRBL_ProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_ProjectID)
        End If
        Return _FK_ELOG_IRBL_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_ELOG_IRBL_SupplierID() As SIS.VR.vrBusinessPartner
      Get
        If _FK_ELOG_IRBL_SupplierID Is Nothing Then
          _FK_ELOG_IRBL_SupplierID = SIS.VR.vrBusinessPartner.vrBusinessPartnerGetByID(_SupplierID)
        End If
        Return _FK_ELOG_IRBL_SupplierID
      End Get
    End Property
    Public ReadOnly Property FK_ELOG_IRBL_StatusID() As SIS.ELOG.elogIRBLStates
      Get
        If _FK_ELOG_IRBL_StatusID Is Nothing Then
          _FK_ELOG_IRBL_StatusID = SIS.ELOG.elogIRBLStates.elogIRBLStatesGetByID(_StatusID)
        End If
        Return _FK_ELOG_IRBL_StatusID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function elogIRBLSelectList(ByVal OrderBy As String) As List(Of SIS.ELOG.elogIRBL)
      Dim Results As List(Of SIS.ELOG.elogIRBL) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogIRBLSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ELOG.elogIRBL)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ELOG.elogIRBL(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function elogIRBLGetNewRecord() As SIS.ELOG.elogIRBL
      Return New SIS.ELOG.elogIRBL()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function elogIRBLGetByID(ByVal IRNo As Int32) As SIS.ELOG.elogIRBL
      Dim Results As SIS.ELOG.elogIRBL = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogIRBLSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRNo", SqlDbType.Int, IRNo.ToString.Length, IRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ELOG.elogIRBL(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function GetByBLID(ByVal BLID As String, ByVal OrderBy As String) As List(Of SIS.ELOG.elogIRBL)
      Dim Results As List(Of SIS.ELOG.elogIRBL) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogIRBLSelectByBLID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BLID", SqlDbType.NVarChar, BLID.ToString.Length, BLID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ELOG.elogIRBL)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ELOG.elogIRBL(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function elogIRBLSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SupplierID As String, ByVal ProjectID As String, ByVal BLID As String) As List(Of SIS.ELOG.elogIRBL)
      Dim Results As List(Of SIS.ELOG.elogIRBL) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spelogIRBLSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spelogIRBLSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SupplierID", SqlDbType.NVarChar, 9, IIf(SupplierID Is Nothing, String.Empty, SupplierID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID", SqlDbType.NVarChar, 6, IIf(ProjectID Is Nothing, String.Empty, ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BLID", SqlDbType.NVarChar, 9, IIf(BLID Is Nothing, String.Empty, BLID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ELOG.elogIRBL)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ELOG.elogIRBL(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function elogIRBLSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SupplierID As String, ByVal ProjectID As String, ByVal BLID As String) As Integer
      Return _RecordCount
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function elogIRBLGetByID(ByVal IRNo As Int32, ByVal Filter_SupplierID As String, ByVal Filter_ProjectID As String, ByVal Filter_BLID As String) As SIS.ELOG.elogIRBL
      Return elogIRBLGetByID(IRNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)>
    Public Shared Function elogIRBLInsert(ByVal Record As SIS.ELOG.elogIRBL) As SIS.ELOG.elogIRBL
      Dim _Rec As SIS.ELOG.elogIRBL = SIS.ELOG.elogIRBL.elogIRBLGetNewRecord()
      With _Rec
        .IRNo = Record.IRNo
        .SupplierID = Record.SupplierID
        .ProjectID = Record.ProjectID
        .PONo = Record.PONo
        .SupplierBillNo = Record.SupplierBillNo
        .supplierBillDate = Record.supplierBillDate
        .SupplierBillAmount = Record.SupplierBillAmount
        .IRDate = Record.IRDate
        .BLID = Record.BLID
        .BLType = Record.BLType
        .MBLNo = Record.MBLNo
        .Remarks = Record.Remarks
        .ShipmentModeID = Record.ShipmentModeID
        .CarrierID = Record.CarrierID
        .OtherCarrier = Record.OtherCarrier
        .LocationCountryID = Record.LocationCountryID
        .OtherCountry = Record.OtherCountry
        .CargoTypeID = Record.CargoTypeID
        .PortID = Record.PortID
        .OtherPortLoadingOrigin = Record.OtherPortLoadingOrigin
        .StatusID = Record.StatusID
        .CreatedOn = Now
        .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
      End With
      Return SIS.ELOG.elogIRBL.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.ELOG.elogIRBL) As SIS.ELOG.elogIRBL
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogIRBLInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRNo", SqlDbType.Int, 11, Record.IRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID", SqlDbType.NVarChar, 10, IIf(Record.SupplierID = "", Convert.DBNull, Record.SupplierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, 7, IIf(Record.ProjectID = "", Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PONo", SqlDbType.NVarChar, 10, IIf(Record.PONo = "", Convert.DBNull, Record.PONo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierBillNo", SqlDbType.NVarChar, 51, IIf(Record.SupplierBillNo = "", Convert.DBNull, Record.SupplierBillNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@supplierBillDate", SqlDbType.DateTime, 21, IIf(Record.supplierBillDate = "", Convert.DBNull, Record.supplierBillDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierBillAmount", SqlDbType.Decimal, 21, IIf(Record.SupplierBillAmount = "", Convert.DBNull, Record.SupplierBillAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRDate", SqlDbType.DateTime, 21, IIf(Record.IRDate = "", Convert.DBNull, Record.IRDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BLID", SqlDbType.NVarChar, 10, IIf(Record.BLID = "", Convert.DBNull, Record.BLID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BLType", SqlDbType.Int, 11, IIf(Record.BLType = "", Convert.DBNull, Record.BLType))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MBLNo", SqlDbType.NVarChar, 51, IIf(Record.MBLNo = "", Convert.DBNull, Record.MBLNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks", SqlDbType.NVarChar, 501, IIf(Record.Remarks = "", Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ShipmentModeID", SqlDbType.Int, 11, IIf(Record.ShipmentModeID = "", Convert.DBNull, Record.ShipmentModeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CarrierID", SqlDbType.Int, 11, IIf(Record.CarrierID = "", Convert.DBNull, Record.CarrierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OtherCarrier", SqlDbType.NVarChar, 101, IIf(Record.OtherCarrier = "", Convert.DBNull, Record.OtherCarrier))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LocationCountryID", SqlDbType.Int, 11, IIf(Record.LocationCountryID = "", Convert.DBNull, Record.LocationCountryID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OtherCountry", SqlDbType.NVarChar, 101, IIf(Record.OtherCountry = "", Convert.DBNull, Record.OtherCountry))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CargoTypeID", SqlDbType.Int, 11, IIf(Record.CargoTypeID = "", Convert.DBNull, Record.CargoTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PortID", SqlDbType.Int, 11, IIf(Record.PortID = "", Convert.DBNull, Record.PortID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OtherPortLoadingOrigin", SqlDbType.NVarChar, 101, IIf(Record.OtherPortLoadingOrigin = "", Convert.DBNull, Record.OtherPortLoadingOrigin))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID", SqlDbType.Int, 11, IIf(Record.StatusID = "", Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn", SqlDbType.DateTime, 21, IIf(Record.CreatedOn = "", Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy", SqlDbType.NVarChar, 9, IIf(Record.CreatedBy = "", Convert.DBNull, Record.CreatedBy))
          Cmd.Parameters.Add("@Return_IRNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_IRNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.IRNo = Cmd.Parameters("@Return_IRNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)>
    Public Shared Function elogIRBLUpdate(ByVal Record As SIS.ELOG.elogIRBL) As SIS.ELOG.elogIRBL
      Dim _Rec As SIS.ELOG.elogIRBL = SIS.ELOG.elogIRBL.elogIRBLGetByID(Record.IRNo)
      With _Rec
        .SupplierID = Record.SupplierID
        .ProjectID = Record.ProjectID
        .PONo = Record.PONo
        .SupplierBillNo = Record.SupplierBillNo
        .supplierBillDate = Record.supplierBillDate
        .SupplierBillAmount = Record.SupplierBillAmount
        .IRDate = Record.IRDate
        .BLID = Record.BLID
        .BLType = Record.BLType
        .MBLNo = Record.MBLNo
        .Remarks = Record.Remarks
        .ShipmentModeID = Record.ShipmentModeID
        .CarrierID = Record.CarrierID
        .OtherCarrier = Record.OtherCarrier
        .LocationCountryID = Record.LocationCountryID
        .OtherCountry = Record.OtherCountry
        .CargoTypeID = Record.CargoTypeID
        .PortID = Record.PortID
        .OtherPortLoadingOrigin = Record.OtherPortLoadingOrigin
        .StatusID = Record.StatusID
        .CreatedOn = Now
        .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
      End With
      Return SIS.ELOG.elogIRBL.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.ELOG.elogIRBL) As SIS.ELOG.elogIRBL
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogIRBLUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_IRNo", SqlDbType.Int, 11, Record.IRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRNo", SqlDbType.Int, 11, Record.IRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID", SqlDbType.NVarChar, 10, IIf(Record.SupplierID = "", Convert.DBNull, Record.SupplierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, 7, IIf(Record.ProjectID = "", Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PONo", SqlDbType.NVarChar, 10, IIf(Record.PONo = "", Convert.DBNull, Record.PONo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierBillNo", SqlDbType.NVarChar, 51, IIf(Record.SupplierBillNo = "", Convert.DBNull, Record.SupplierBillNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@supplierBillDate", SqlDbType.DateTime, 21, IIf(Record.supplierBillDate = "", Convert.DBNull, Record.supplierBillDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierBillAmount", SqlDbType.Decimal, 21, IIf(Record.SupplierBillAmount = "", Convert.DBNull, Record.SupplierBillAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRDate", SqlDbType.DateTime, 21, IIf(Record.IRDate = "", Convert.DBNull, Record.IRDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BLID", SqlDbType.NVarChar, 10, IIf(Record.BLID = "", Convert.DBNull, Record.BLID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BLType", SqlDbType.Int, 11, IIf(Record.BLType = "", Convert.DBNull, Record.BLType))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MBLNo", SqlDbType.NVarChar, 51, IIf(Record.MBLNo = "", Convert.DBNull, Record.MBLNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks", SqlDbType.NVarChar, 501, IIf(Record.Remarks = "", Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ShipmentModeID", SqlDbType.Int, 11, IIf(Record.ShipmentModeID = "", Convert.DBNull, Record.ShipmentModeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CarrierID", SqlDbType.Int, 11, IIf(Record.CarrierID = "", Convert.DBNull, Record.CarrierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OtherCarrier", SqlDbType.NVarChar, 101, IIf(Record.OtherCarrier = "", Convert.DBNull, Record.OtherCarrier))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LocationCountryID", SqlDbType.Int, 11, IIf(Record.LocationCountryID = "", Convert.DBNull, Record.LocationCountryID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OtherCountry", SqlDbType.NVarChar, 101, IIf(Record.OtherCountry = "", Convert.DBNull, Record.OtherCountry))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CargoTypeID", SqlDbType.Int, 11, IIf(Record.CargoTypeID = "", Convert.DBNull, Record.CargoTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PortID", SqlDbType.Int, 11, IIf(Record.PortID = "", Convert.DBNull, Record.PortID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OtherPortLoadingOrigin", SqlDbType.NVarChar, 101, IIf(Record.OtherPortLoadingOrigin = "", Convert.DBNull, Record.OtherPortLoadingOrigin))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID", SqlDbType.Int, 11, IIf(Record.StatusID = "", Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn", SqlDbType.DateTime, 21, IIf(Record.CreatedOn = "", Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy", SqlDbType.NVarChar, 9, IIf(Record.CreatedBy = "", Convert.DBNull, Record.CreatedBy))
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
    Public Shared Function elogIRBLDelete(ByVal Record As SIS.ELOG.elogIRBL) As Int32
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogIRBLDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_IRNo", SqlDbType.Int, Record.IRNo.ToString.Length, Record.IRNo)
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
    Public Shared Function SelectelogIRBLAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogIRBLAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, IIf(Prefix.ToLower = Prefix, 0, 1)))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "), ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.ELOG.elogIRBL = New SIS.ELOG.elogIRBL(Reader)
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
              If Convert.IsDBNull(Reader(pi.Name)) Then
                CallByName(Me, pi.Name, CallType.Let, String.Empty)
              Else
                CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
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
