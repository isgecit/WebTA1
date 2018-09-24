Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakSitePkgH
    Private Shared _RecordCount As Integer
    Private _ProjectID As String = ""
    Private _RecNo As Int32 = 0
    Private _SerialNo As String = ""
    Private _PkgNo As String = ""
    Private _MRNNo As String = ""
    Private _SupplierID As String = ""
    Private _SupplierName As String = ""
    Private _SupplierRefNo As String = ""
    Private _TransporterID As String = ""
    Private _TransporterName As String = ""
    Private _VehicleNo As String = ""
    Private _GRNo As String = ""
    Private _GRDate As String = ""
    Private _UOMTotalWeight As String = ""
    Private _TotalWeight As String = "0.0000"
    Private _ODC As String = ""
    Private _MaterialStatusID As String = ""
    Private _Remarks As String = ""
    Private _CreatedBy As String = ""
    Private _CreatedOn As String = ""
    Private _ReceiveStatusID As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _IDM_Projects2_Description As String = ""
    Private _PAK_PkgListH3_SupplierRefNo As String = ""
    Private _PAK_PO4_PODescription As String = ""
    Private _PAK_ReceiveStatus5_Description As String = ""
    Private _PAK_Units6_Description As String = ""
    Private _VR_BusinessPartner7_BPName As String = ""
    Private _VR_BusinessPartner8_BPName As String = ""
    Private _VR_LorryReceipts9_TransporterName As String = ""
    Private _VR_MaterialStates10_Description As String = ""
    Private _FK_PAK_SitePkgH_CreatedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_PAK_SitePkgH_ProjectID As SIS.QCM.qcmProjects = Nothing
    Private _FK_PAK_SitePkgH_PkgNo As SIS.PAK.pakPkgListH = Nothing
    Private _FK_PAK_SitePkgH_SerialNo As SIS.PAK.pakPO = Nothing
    Private _FK_PAK_SitePkgH_ReceiveStatusID As SIS.PAK.pakReceiveStatus = Nothing
    Private _FK_PAK_SitePkgH_UOMTotalWeight As SIS.PAK.pakUnits = Nothing
    Private _FK_PAK_SitePkgH_TransporterID As SIS.PAK.pakBusinessPartner = Nothing
    Private _FK_PAK_SitePkgH_SupplierID As SIS.PAK.pakBusinessPartner = Nothing
    Private _FK_PAK_SitePkgH_MRNNo As SIS.PAK.pakLorryReceipts = Nothing
    Private _FK_PAK_SitePkgH_MaterialStatusID As SIS.PAK.pakMaterialStates = Nothing
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
    Public Property RecNo() As Int32
      Get
        Return _RecNo
      End Get
      Set(ByVal value As Int32)
        _RecNo = value
      End Set
    End Property
    Public Property SerialNo() As String
      Get
        Return _SerialNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SerialNo = ""
         Else
           _SerialNo = value
         End If
      End Set
    End Property
    Public Property PkgNo() As String
      Get
        Return _PkgNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PkgNo = ""
         Else
           _PkgNo = value
         End If
      End Set
    End Property
    Public Property MRNNo() As String
      Get
        Return _MRNNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _MRNNo = ""
         Else
           _MRNNo = value
         End If
      End Set
    End Property
    Public Property SupplierID() As String
      Get
        Return _SupplierID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SupplierID = ""
         Else
           _SupplierID = value
         End If
      End Set
    End Property
    Public Property SupplierName() As String
      Get
        Return _SupplierName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SupplierName = ""
         Else
           _SupplierName = value
         End If
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
    Public Property ODC() As String
      Get
        Return _ODC
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ODC = ""
         Else
           _ODC = value
         End If
      End Set
    End Property
    Public Property MaterialStatusID() As String
      Get
        Return _MaterialStatusID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _MaterialStatusID = ""
         Else
           _MaterialStatusID = value
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
    Public Property ReceiveStatusID() As String
      Get
        Return _ReceiveStatusID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ReceiveStatusID = ""
         Else
           _ReceiveStatusID = value
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
    Public Property PAK_PkgListH3_SupplierRefNo() As String
      Get
        Return _PAK_PkgListH3_SupplierRefNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_PkgListH3_SupplierRefNo = ""
         Else
           _PAK_PkgListH3_SupplierRefNo = value
         End If
      End Set
    End Property
    Public Property PAK_PO4_PODescription() As String
      Get
        Return _PAK_PO4_PODescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_PO4_PODescription = ""
         Else
           _PAK_PO4_PODescription = value
         End If
      End Set
    End Property
    Public Property PAK_ReceiveStatus5_Description() As String
      Get
        Return _PAK_ReceiveStatus5_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_ReceiveStatus5_Description = ""
         Else
           _PAK_ReceiveStatus5_Description = value
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
    Public Property VR_BusinessPartner7_BPName() As String
      Get
        Return _VR_BusinessPartner7_BPName
      End Get
      Set(ByVal value As String)
        _VR_BusinessPartner7_BPName = value
      End Set
    End Property
    Public Property VR_BusinessPartner8_BPName() As String
      Get
        Return _VR_BusinessPartner8_BPName
      End Get
      Set(ByVal value As String)
        _VR_BusinessPartner8_BPName = value
      End Set
    End Property
    Public Property VR_LorryReceipts9_TransporterName() As String
      Get
        Return _VR_LorryReceipts9_TransporterName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VR_LorryReceipts9_TransporterName = ""
         Else
           _VR_LorryReceipts9_TransporterName = value
         End If
      End Set
    End Property
    Public Property VR_MaterialStates10_Description() As String
      Get
        Return _VR_MaterialStates10_Description
      End Get
      Set(ByVal value As String)
        _VR_MaterialStates10_Description = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _SupplierRefNo.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _ProjectID & "|" & _RecNo
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
    Public Class PKpakSitePkgH
      Private _ProjectID As String = ""
      Private _RecNo As Int32 = 0
      Public Property ProjectID() As String
        Get
          Return _ProjectID
        End Get
        Set(ByVal value As String)
          _ProjectID = value
        End Set
      End Property
      Public Property RecNo() As Int32
        Get
          Return _RecNo
        End Get
        Set(ByVal value As Int32)
          _RecNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PAK_SitePkgH_CreatedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_PAK_SitePkgH_CreatedBy Is Nothing Then
          _FK_PAK_SitePkgH_CreatedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_CreatedBy)
        End If
        Return _FK_PAK_SitePkgH_CreatedBy
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SitePkgH_ProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_PAK_SitePkgH_ProjectID Is Nothing Then
          _FK_PAK_SitePkgH_ProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_ProjectID)
        End If
        Return _FK_PAK_SitePkgH_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SitePkgH_PkgNo() As SIS.PAK.pakPkgListH
      Get
        If _FK_PAK_SitePkgH_PkgNo Is Nothing Then
          _FK_PAK_SitePkgH_PkgNo = SIS.PAK.pakPkgListH.pakPkgListHGetByID(_SerialNo, _PkgNo)
        End If
        Return _FK_PAK_SitePkgH_PkgNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SitePkgH_SerialNo() As SIS.PAK.pakPO
      Get
        If _FK_PAK_SitePkgH_SerialNo Is Nothing Then
          _FK_PAK_SitePkgH_SerialNo = SIS.PAK.pakPO.pakPOGetByID(_SerialNo)
        End If
        Return _FK_PAK_SitePkgH_SerialNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SitePkgH_ReceiveStatusID() As SIS.PAK.pakReceiveStatus
      Get
        If _FK_PAK_SitePkgH_ReceiveStatusID Is Nothing Then
          _FK_PAK_SitePkgH_ReceiveStatusID = SIS.PAK.pakReceiveStatus.pakReceiveStatusGetByID(_ReceiveStatusID)
        End If
        Return _FK_PAK_SitePkgH_ReceiveStatusID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SitePkgH_UOMTotalWeight() As SIS.PAK.pakUnits
      Get
        If _FK_PAK_SitePkgH_UOMTotalWeight Is Nothing Then
          _FK_PAK_SitePkgH_UOMTotalWeight = SIS.PAK.pakUnits.pakUnitsGetByID(_UOMTotalWeight)
        End If
        Return _FK_PAK_SitePkgH_UOMTotalWeight
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SitePkgH_TransporterID() As SIS.PAK.pakBusinessPartner
      Get
        If _FK_PAK_SitePkgH_TransporterID Is Nothing Then
          _FK_PAK_SitePkgH_TransporterID = SIS.PAK.pakBusinessPartner.pakBusinessPartnerGetByID(_TransporterID)
        End If
        Return _FK_PAK_SitePkgH_TransporterID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SitePkgH_SupplierID() As SIS.PAK.pakBusinessPartner
      Get
        If _FK_PAK_SitePkgH_SupplierID Is Nothing Then
          _FK_PAK_SitePkgH_SupplierID = SIS.PAK.pakBusinessPartner.pakBusinessPartnerGetByID(_SupplierID)
        End If
        Return _FK_PAK_SitePkgH_SupplierID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SitePkgH_MRNNo() As SIS.PAK.pakLorryReceipts
      Get
        If _FK_PAK_SitePkgH_MRNNo Is Nothing Then
          _FK_PAK_SitePkgH_MRNNo = SIS.PAK.pakLorryReceipts.pakLorryReceiptsGetByID(_ProjectID, _MRNNo)
        End If
        Return _FK_PAK_SitePkgH_MRNNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SitePkgH_MaterialStatusID() As SIS.PAK.pakMaterialStates
      Get
        If _FK_PAK_SitePkgH_MaterialStatusID Is Nothing Then
          _FK_PAK_SitePkgH_MaterialStatusID = SIS.PAK.pakMaterialStates.pakMaterialStatesGetByID(_MaterialStatusID)
        End If
        Return _FK_PAK_SitePkgH_MaterialStatusID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSitePkgHSelectList(ByVal OrderBy As String) As List(Of SIS.PAK.pakSitePkgH)
      Dim Results As List(Of SIS.PAK.pakSitePkgH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSitePkgHSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakSitePkgH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSitePkgH(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSitePkgHGetNewRecord() As SIS.PAK.pakSitePkgH
      Return New SIS.PAK.pakSitePkgH()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSitePkgHGetByID(ByVal ProjectID As String, ByVal RecNo As Int32) As SIS.PAK.pakSitePkgH
      Dim Results As SIS.PAK.pakSitePkgH = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSitePkgHSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,ProjectID.ToString.Length, ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RecNo",SqlDbType.Int,RecNo.ToString.Length, RecNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakSitePkgH(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSitePkgHSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String, ByVal SerialNo As Int32, ByVal PkgNo As Int32, ByVal SupplierID As String) As List(Of SIS.PAK.pakSitePkgH)
      Dim Results As List(Of SIS.PAK.pakSitePkgH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakSitePkgHSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakSitePkgHSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PkgNo",SqlDbType.Int,10, IIf(PkgNo = Nothing, 0,PkgNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SupplierID",SqlDbType.NVarChar,9, IIf(SupplierID Is Nothing, String.Empty,SupplierID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakSitePkgH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSitePkgH(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakSitePkgHSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String, ByVal SerialNo As Int32, ByVal PkgNo As Int32, ByVal SupplierID As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSitePkgHGetByID(ByVal ProjectID As String, ByVal RecNo As Int32, ByVal Filter_ProjectID As String, ByVal Filter_SerialNo As Int32, ByVal Filter_PkgNo As Int32, ByVal Filter_SupplierID As String) As SIS.PAK.pakSitePkgH
      Return pakSitePkgHGetByID(ProjectID, RecNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function pakSitePkgHInsert(ByVal Record As SIS.PAK.pakSitePkgH) As SIS.PAK.pakSitePkgH
      Dim _Rec As SIS.PAK.pakSitePkgH = SIS.PAK.pakSitePkgH.pakSitePkgHGetNewRecord()
      With _Rec
        .ProjectID = Record.ProjectID
        .SerialNo = Record.SerialNo
        .PkgNo = Record.PkgNo
        .MRNNo = Record.MRNNo
        .SupplierID = Record.SupplierID
        .SupplierName = Record.SupplierName
        .SupplierRefNo = Record.SupplierRefNo
        .TransporterID = Record.TransporterID
        .TransporterName = Record.TransporterName
        .VehicleNo = Record.VehicleNo
        .GRNo = Record.GRNo
        .GRDate = Record.GRDate
        .UOMTotalWeight = Record.UOMTotalWeight
        .TotalWeight = Record.TotalWeight
        .ODC = Record.ODC
        .MaterialStatusID = Record.MaterialStatusID
        .Remarks = Record.Remarks
        .CreatedBy =  Global.System.Web.HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
        .ReceiveStatusID = siteReceiveStates.Free
      End With
      Return SIS.PAK.pakSitePkgH.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PAK.pakSitePkgH) As SIS.PAK.pakSitePkgH
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSitePkgHInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Iif(Record.SerialNo= "" ,Convert.DBNull, Record.SerialNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PkgNo",SqlDbType.Int,11, Iif(Record.PkgNo= "" ,Convert.DBNull, Record.PkgNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MRNNo",SqlDbType.Int,11, Iif(Record.MRNNo= "" ,Convert.DBNull, Record.MRNNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID",SqlDbType.NVarChar,10, Iif(Record.SupplierID= "" ,Convert.DBNull, Record.SupplierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierName",SqlDbType.NVarChar,51, Iif(Record.SupplierName= "" ,Convert.DBNull, Record.SupplierName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierRefNo",SqlDbType.NVarChar,51, Iif(Record.SupplierRefNo= "" ,Convert.DBNull, Record.SupplierRefNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransporterID",SqlDbType.NVarChar,10, Iif(Record.TransporterID= "" ,Convert.DBNull, Record.TransporterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransporterName",SqlDbType.NVarChar,51, Iif(Record.TransporterName= "" ,Convert.DBNull, Record.TransporterName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleNo",SqlDbType.NVarChar,51, Iif(Record.VehicleNo= "" ,Convert.DBNull, Record.VehicleNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GRNo",SqlDbType.NVarChar,51, Iif(Record.GRNo= "" ,Convert.DBNull, Record.GRNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GRDate",SqlDbType.DateTime,21, Iif(Record.GRDate= "" ,Convert.DBNull, Record.GRDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMTotalWeight",SqlDbType.Int,11, Iif(Record.UOMTotalWeight= "" ,Convert.DBNull, Record.UOMTotalWeight))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalWeight",SqlDbType.Decimal,21, Iif(Record.TotalWeight= "" ,Convert.DBNull, Record.TotalWeight))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ODC",SqlDbType.Bit,3, Iif(Record.ODC= "" ,Convert.DBNull, Record.ODC))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaterialStatusID",SqlDbType.Int,11, Iif(Record.MaterialStatusID= "" ,Convert.DBNull, Record.MaterialStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,501, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiveStatusID",SqlDbType.Int,11, Iif(Record.ReceiveStatusID= "" ,Convert.DBNull, Record.ReceiveStatusID))
          Cmd.Parameters.Add("@Return_ProjectID", SqlDbType.NVarChar, 7)
          Cmd.Parameters("@Return_ProjectID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_RecNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_RecNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ProjectID = Cmd.Parameters("@Return_ProjectID").Value
          Record.RecNo = Cmd.Parameters("@Return_RecNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakSitePkgHUpdate(ByVal Record As SIS.PAK.pakSitePkgH) As SIS.PAK.pakSitePkgH
      Dim _Rec As SIS.PAK.pakSitePkgH = SIS.PAK.pakSitePkgH.pakSitePkgHGetByID(Record.ProjectID, Record.RecNo)
      With _Rec
        .SerialNo = Record.SerialNo
        .PkgNo = Record.PkgNo
        .MRNNo = Record.MRNNo
        .SupplierID = Record.SupplierID
        .SupplierName = Record.SupplierName
        .SupplierRefNo = Record.SupplierRefNo
        .TransporterID = Record.TransporterID
        .TransporterName = Record.TransporterName
        .VehicleNo = Record.VehicleNo
        .GRNo = Record.GRNo
        .GRDate = Record.GRDate
        .UOMTotalWeight = Record.UOMTotalWeight
        .TotalWeight = Record.TotalWeight
        .ODC = Record.ODC
        .MaterialStatusID = Record.MaterialStatusID
        .Remarks = Record.Remarks
        .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .CreatedOn = Record.CreatedOn
        .ReceiveStatusID = Record.ReceiveStatusID
      End With
      Return SIS.PAK.pakSitePkgH.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PAK.pakSitePkgH) As SIS.PAK.pakSitePkgH
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSitePkgHUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RecNo",SqlDbType.Int,11, Record.RecNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Iif(Record.SerialNo= "" ,Convert.DBNull, Record.SerialNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PkgNo",SqlDbType.Int,11, Iif(Record.PkgNo= "" ,Convert.DBNull, Record.PkgNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MRNNo",SqlDbType.Int,11, Iif(Record.MRNNo= "" ,Convert.DBNull, Record.MRNNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID",SqlDbType.NVarChar,10, Iif(Record.SupplierID= "" ,Convert.DBNull, Record.SupplierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierName",SqlDbType.NVarChar,51, Iif(Record.SupplierName= "" ,Convert.DBNull, Record.SupplierName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierRefNo",SqlDbType.NVarChar,51, Iif(Record.SupplierRefNo= "" ,Convert.DBNull, Record.SupplierRefNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransporterID",SqlDbType.NVarChar,10, Iif(Record.TransporterID= "" ,Convert.DBNull, Record.TransporterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransporterName",SqlDbType.NVarChar,51, Iif(Record.TransporterName= "" ,Convert.DBNull, Record.TransporterName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleNo",SqlDbType.NVarChar,51, Iif(Record.VehicleNo= "" ,Convert.DBNull, Record.VehicleNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GRNo",SqlDbType.NVarChar,51, Iif(Record.GRNo= "" ,Convert.DBNull, Record.GRNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GRDate",SqlDbType.DateTime,21, Iif(Record.GRDate= "" ,Convert.DBNull, Record.GRDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMTotalWeight",SqlDbType.Int,11, Iif(Record.UOMTotalWeight= "" ,Convert.DBNull, Record.UOMTotalWeight))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalWeight",SqlDbType.Decimal,21, Iif(Record.TotalWeight= "" ,Convert.DBNull, Record.TotalWeight))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ODC",SqlDbType.Bit,3, Iif(Record.ODC= "" ,Convert.DBNull, Record.ODC))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaterialStatusID",SqlDbType.Int,11, Iif(Record.MaterialStatusID= "" ,Convert.DBNull, Record.MaterialStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,501, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiveStatusID",SqlDbType.Int,11, Iif(Record.ReceiveStatusID= "" ,Convert.DBNull, Record.ReceiveStatusID))
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
    Public Shared Function pakSitePkgHDelete(ByVal Record As SIS.PAK.pakSitePkgH) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSitePkgHDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID",SqlDbType.NVarChar,Record.ProjectID.ToString.Length, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RecNo",SqlDbType.Int,Record.RecNo.ToString.Length, Record.RecNo)
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
    Public Shared Function SelectpakSitePkgHAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSitePkgHAutoCompleteList"
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
            Dim Tmp As SIS.PAK.pakSitePkgH = New SIS.PAK.pakSitePkgH(Reader)
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
