Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakSitePkgD
    Private Shared _RecordCount As Integer
    Private _RecSrNo As Int32 = 0
    Private _ItemNo As Int32 = 0
    Private _SiteMarkNo As String = ""
    Private _UOMQuantity As String = ""
    Private _Quantity As Decimal = 0
    Private _PackTypeID As String = ""
    Private _OnlyPackageReceived As Boolean = False
    Private _InventoryStatusID As String = ""
    Private _Remarks As String = ""
    Private _DocumentReceived As Boolean = False
    Private _PackHeight As Decimal = 0
    Private _UOMPack As String = ""
    Private _InventoryUpdatedBy As String = ""
    Private _InventoryUpdatedOn As String = ""
    Private _NotFromPackingList As Boolean = False
    Private _MaterialStatusID As String = ""
    Private _BOMNo As Int32 = 0
    Private _DocumentNo As String = ""
    Private _PkgNo As Int32 = 0
    Private _RecNo As Int32 = 0
    Private _SerialNo As Int32 = 0
    Private _PackLength As Decimal = 0
    Private _PackWidth As Decimal = 0
    Private _PackingMark As String = ""
    Private _DocumentRevision As String = ""
    Private _ProjectID As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _IDM_Projects2_Description As String = ""
    Private _PAK_Documents3_cmba As String = ""
    Private _PAK_InventoryStatus4_Description As String = ""
    Private _PAK_PakTypes5_Description As String = ""
    Private _PAK_PkgListD6_PackingMark As String = ""
    Private _PAK_PkgListH7_SupplierRefNo As String = ""
    Private _PAK_PO8_PODescription As String = ""
    Private _PAK_SiteItemMaster9_ItemDescription As String = ""
    Private _PAK_SitePkgH10_SupplierRefNo As String = ""
    Private _PAK_Units11_Description As String = ""
    Private _PAK_Units12_Description As String = ""
    Private _VR_MaterialStates13_Description As String = ""
    Private _FK_PAK_SitePkgD_InventoryUpdatedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_PAK_SitePkgD_ProjectID As SIS.EITL.eitlProjects = Nothing
    Private _FK_PAK_SitePkgD_DocumentNo As SIS.PAK.pakDocuments = Nothing
    Private _FK_PAK_SitePkgD_InventoryStatusID As SIS.PAK.pakInventoryStatus = Nothing
    Private _FK_PAK_SitePkgD_PAKTypeID As SIS.PAK.pakPakTypes = Nothing
    Private _FK_PAK_SitePkgD_ItemNo As SIS.PAK.pakPkgListD = Nothing
    Private _FK_PAK_SitePkgD_PkgNo As SIS.PAK.pakPkgListH = Nothing
    Private _FK_PAK_SitePkgD_SerialNo As SIS.PAK.pakPO = Nothing
    Private _FK_PAK_SitePkgD_SiteMarkNo As SIS.PAK.pakSiteItemMaster = Nothing
    Private _FK_PAK_SitePkgD_RecNo As SIS.PAK.pakSitePkgH = Nothing
    Private _FK_PAK_SitePkgD_UOMQuantity As SIS.PAK.pakUnits = Nothing
    Private _FK_PAK_SitePkgD_UOMPack As SIS.PAK.pakUnits = Nothing
    Private _FK_PAK_SitePkgD_MaterialStatusID As SIS.PAK.pakMaterialStates = Nothing
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
    Public Property RecSrNo() As Int32
      Get
        Return _RecSrNo
      End Get
      Set(ByVal value As Int32)
        _RecSrNo = value
      End Set
    End Property
    Public Property ItemNo() As Int32
      Get
        Return _ItemNo
      End Get
      Set(ByVal value As Int32)
        _ItemNo = value
      End Set
    End Property
    Public Property SiteMarkNo() As String
      Get
        Return _SiteMarkNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SiteMarkNo = ""
         Else
           _SiteMarkNo = value
         End If
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
    Public Property Quantity() As Decimal
      Get
        Return _Quantity
      End Get
      Set(ByVal value As Decimal)
        _Quantity = value
      End Set
    End Property
    Public Property PackTypeID() As String
      Get
        Return _PackTypeID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PackTypeID = ""
         Else
           _PackTypeID = value
         End If
      End Set
    End Property
    Public Property OnlyPackageReceived() As Boolean
      Get
        Return _OnlyPackageReceived
      End Get
      Set(ByVal value As Boolean)
        _OnlyPackageReceived = value
      End Set
    End Property
    Public Property InventoryStatusID() As String
      Get
        Return _InventoryStatusID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _InventoryStatusID = ""
         Else
           _InventoryStatusID = value
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
    Public Property DocumentReceived() As Boolean
      Get
        Return _DocumentReceived
      End Get
      Set(ByVal value As Boolean)
        _DocumentReceived = value
      End Set
    End Property
    Public Property PackHeight() As Decimal
      Get
        Return _PackHeight
      End Get
      Set(ByVal value As Decimal)
        _PackHeight = value
      End Set
    End Property
    Public Property UOMPack() As String
      Get
        Return _UOMPack
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _UOMPack = ""
         Else
           _UOMPack = value
         End If
      End Set
    End Property
    Public Property InventoryUpdatedBy() As String
      Get
        Return _InventoryUpdatedBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _InventoryUpdatedBy = ""
         Else
           _InventoryUpdatedBy = value
         End If
      End Set
    End Property
    Public Property InventoryUpdatedOn() As String
      Get
        If Not _InventoryUpdatedOn = String.Empty Then
          Return Convert.ToDateTime(_InventoryUpdatedOn).ToString("dd/MM/yyyy")
        End If
        Return _InventoryUpdatedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _InventoryUpdatedOn = ""
         Else
           _InventoryUpdatedOn = value
         End If
      End Set
    End Property
    Public Property NotFromPackingList() As Boolean
      Get
        Return _NotFromPackingList
      End Get
      Set(ByVal value As Boolean)
        _NotFromPackingList = value
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
    Public Property BOMNo() As Int32
      Get
        Return _BOMNo
      End Get
      Set(ByVal value As Int32)
        _BOMNo = value
      End Set
    End Property
    Public Property DocumentNo() As String
      Get
        Return _DocumentNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DocumentNo = ""
         Else
           _DocumentNo = value
         End If
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
    Public Property RecNo() As Int32
      Get
        Return _RecNo
      End Get
      Set(ByVal value As Int32)
        _RecNo = value
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
    Public Property PackLength() As Decimal
      Get
        Return _PackLength
      End Get
      Set(ByVal value As Decimal)
        _PackLength = value
      End Set
    End Property
    Public Property PackWidth() As Decimal
      Get
        Return _PackWidth
      End Get
      Set(ByVal value As Decimal)
        _PackWidth = value
      End Set
    End Property
    Public Property PackingMark() As String
      Get
        Return _PackingMark
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PackingMark = ""
         Else
           _PackingMark = value
         End If
      End Set
    End Property
    Public Property DocumentRevision() As String
      Get
        Return _DocumentRevision
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DocumentRevision = ""
         Else
           _DocumentRevision = value
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
    Public Property PAK_Documents3_cmba() As String
      Get
        Return _PAK_Documents3_cmba
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_Documents3_cmba = ""
         Else
           _PAK_Documents3_cmba = value
         End If
      End Set
    End Property
    Public Property PAK_InventoryStatus4_Description() As String
      Get
        Return _PAK_InventoryStatus4_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_InventoryStatus4_Description = ""
         Else
           _PAK_InventoryStatus4_Description = value
         End If
      End Set
    End Property
    Public Property PAK_PakTypes5_Description() As String
      Get
        Return _PAK_PakTypes5_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_PakTypes5_Description = ""
         Else
           _PAK_PakTypes5_Description = value
         End If
      End Set
    End Property
    Public Property PAK_PkgListD6_PackingMark() As String
      Get
        Return _PAK_PkgListD6_PackingMark
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_PkgListD6_PackingMark = ""
         Else
           _PAK_PkgListD6_PackingMark = value
         End If
      End Set
    End Property
    Public Property PAK_PkgListH7_SupplierRefNo() As String
      Get
        Return _PAK_PkgListH7_SupplierRefNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_PkgListH7_SupplierRefNo = ""
         Else
           _PAK_PkgListH7_SupplierRefNo = value
         End If
      End Set
    End Property
    Public Property PAK_PO8_PODescription() As String
      Get
        Return _PAK_PO8_PODescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_PO8_PODescription = ""
         Else
           _PAK_PO8_PODescription = value
         End If
      End Set
    End Property
    Public Property PAK_SiteItemMaster9_ItemDescription() As String
      Get
        Return _PAK_SiteItemMaster9_ItemDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_SiteItemMaster9_ItemDescription = ""
         Else
           _PAK_SiteItemMaster9_ItemDescription = value
         End If
      End Set
    End Property
    Public Property PAK_SitePkgH10_SupplierRefNo() As String
      Get
        Return _PAK_SitePkgH10_SupplierRefNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_SitePkgH10_SupplierRefNo = ""
         Else
           _PAK_SitePkgH10_SupplierRefNo = value
         End If
      End Set
    End Property
    Public Property PAK_Units11_Description() As String
      Get
        Return _PAK_Units11_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_Units11_Description = ""
         Else
           _PAK_Units11_Description = value
         End If
      End Set
    End Property
    Public Property PAK_Units12_Description() As String
      Get
        Return _PAK_Units12_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_Units12_Description = ""
         Else
           _PAK_Units12_Description = value
         End If
      End Set
    End Property
    Public Property VR_MaterialStates13_Description() As String
      Get
        Return _VR_MaterialStates13_Description
      End Get
      Set(ByVal value As String)
        _VR_MaterialStates13_Description = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _SiteMarkNo.ToString.PadRight(30, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _ProjectID & "|" & _RecNo & "|" & _RecSrNo
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
    Public Class PKpakSitePkgD
      Private _ProjectID As String = ""
      Private _RecNo As Int32 = 0
      Private _RecSrNo As Int32 = 0
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
      Public Property RecSrNo() As Int32
        Get
          Return _RecSrNo
        End Get
        Set(ByVal value As Int32)
          _RecSrNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PAK_SitePkgD_InventoryUpdatedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_PAK_SitePkgD_InventoryUpdatedBy Is Nothing Then
          _FK_PAK_SitePkgD_InventoryUpdatedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_InventoryUpdatedBy)
        End If
        Return _FK_PAK_SitePkgD_InventoryUpdatedBy
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SitePkgD_ProjectID() As SIS.EITL.eitlProjects
      Get
        If _FK_PAK_SitePkgD_ProjectID Is Nothing Then
          _FK_PAK_SitePkgD_ProjectID = SIS.EITL.eitlProjects.eitlProjectsGetByID(_ProjectID)
        End If
        Return _FK_PAK_SitePkgD_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SitePkgD_DocumentNo() As SIS.PAK.pakDocuments
      Get
        If _FK_PAK_SitePkgD_DocumentNo Is Nothing Then
          _FK_PAK_SitePkgD_DocumentNo = SIS.PAK.pakDocuments.pakDocumentsGetByID(_DocumentNo)
        End If
        Return _FK_PAK_SitePkgD_DocumentNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SitePkgD_InventoryStatusID() As SIS.PAK.pakInventoryStatus
      Get
        If _FK_PAK_SitePkgD_InventoryStatusID Is Nothing Then
          _FK_PAK_SitePkgD_InventoryStatusID = SIS.PAK.pakInventoryStatus.pakInventoryStatusGetByID(_InventoryStatusID)
        End If
        Return _FK_PAK_SitePkgD_InventoryStatusID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SitePkgD_PAKTypeID() As SIS.PAK.pakPakTypes
      Get
        If _FK_PAK_SitePkgD_PAKTypeID Is Nothing Then
          _FK_PAK_SitePkgD_PAKTypeID = SIS.PAK.pakPakTypes.pakPakTypesGetByID(_PackTypeID)
        End If
        Return _FK_PAK_SitePkgD_PAKTypeID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SitePkgD_ItemNo() As SIS.PAK.pakPkgListD
      Get
        If _FK_PAK_SitePkgD_ItemNo Is Nothing Then
          _FK_PAK_SitePkgD_ItemNo = SIS.PAK.pakPkgListD.pakPkgListDGetByID(_SerialNo, _PkgNo, _BOMNo, _ItemNo)
        End If
        Return _FK_PAK_SitePkgD_ItemNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SitePkgD_PkgNo() As SIS.PAK.pakPkgListH
      Get
        If _FK_PAK_SitePkgD_PkgNo Is Nothing Then
          _FK_PAK_SitePkgD_PkgNo = SIS.PAK.pakPkgListH.pakPkgListHGetByID(_SerialNo, _PkgNo)
        End If
        Return _FK_PAK_SitePkgD_PkgNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SitePkgD_SerialNo() As SIS.PAK.pakPO
      Get
        If _FK_PAK_SitePkgD_SerialNo Is Nothing Then
          _FK_PAK_SitePkgD_SerialNo = SIS.PAK.pakPO.pakPOGetByID(_SerialNo)
        End If
        Return _FK_PAK_SitePkgD_SerialNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SitePkgD_SiteMarkNo() As SIS.PAK.pakSiteItemMaster
      Get
        If _FK_PAK_SitePkgD_SiteMarkNo Is Nothing Then
          _FK_PAK_SitePkgD_SiteMarkNo = SIS.PAK.pakSiteItemMaster.pakSiteItemMasterGetByID(_ProjectID, _SiteMarkNo)
        End If
        Return _FK_PAK_SitePkgD_SiteMarkNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SitePkgD_RecNo() As SIS.PAK.pakSitePkgH
      Get
        If _FK_PAK_SitePkgD_RecNo Is Nothing Then
          _FK_PAK_SitePkgD_RecNo = SIS.PAK.pakSitePkgH.pakSitePkgHGetByID(_ProjectID, _RecNo)
        End If
        Return _FK_PAK_SitePkgD_RecNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SitePkgD_UOMQuantity() As SIS.PAK.pakUnits
      Get
        If _FK_PAK_SitePkgD_UOMQuantity Is Nothing Then
          _FK_PAK_SitePkgD_UOMQuantity = SIS.PAK.pakUnits.pakUnitsGetByID(_UOMQuantity)
        End If
        Return _FK_PAK_SitePkgD_UOMQuantity
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SitePkgD_UOMPack() As SIS.PAK.pakUnits
      Get
        If _FK_PAK_SitePkgD_UOMPack Is Nothing Then
          _FK_PAK_SitePkgD_UOMPack = SIS.PAK.pakUnits.pakUnitsGetByID(_UOMPack)
        End If
        Return _FK_PAK_SitePkgD_UOMPack
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SitePkgD_MaterialStatusID() As SIS.PAK.pakMaterialStates
      Get
        If _FK_PAK_SitePkgD_MaterialStatusID Is Nothing Then
          _FK_PAK_SitePkgD_MaterialStatusID = SIS.PAK.pakMaterialStates.pakMaterialStatesGetByID(_MaterialStatusID)
        End If
        Return _FK_PAK_SitePkgD_MaterialStatusID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSitePkgDSelectList(ByVal OrderBy As String) As List(Of SIS.PAK.pakSitePkgD)
      Dim Results As List(Of SIS.PAK.pakSitePkgD) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSitePkgDSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakSitePkgD)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSitePkgD(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSitePkgDGetNewRecord() As SIS.PAK.pakSitePkgD
      Return New SIS.PAK.pakSitePkgD()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSitePkgDGetByID(ByVal ProjectID As String, ByVal RecNo As Int32, ByVal RecSrNo As Int32) As SIS.PAK.pakSitePkgD
      Dim Results As SIS.PAK.pakSitePkgD = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSitePkgDSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,ProjectID.ToString.Length, ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RecNo",SqlDbType.Int,RecNo.ToString.Length, RecNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RecSrNo",SqlDbType.Int,RecSrNo.ToString.Length, RecSrNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakSitePkgD(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSitePkgDSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal RecNo As Int32, ByVal ProjectID As String) As List(Of SIS.PAK.pakSitePkgD)
      Dim Results As List(Of SIS.PAK.pakSitePkgD) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakSitePkgDSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakSitePkgDSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RecNo",SqlDbType.Int,10, IIf(RecNo = Nothing, 0,RecNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakSitePkgD)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSitePkgD(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakSitePkgDSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal RecNo As Int32, ByVal ProjectID As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSitePkgDGetByID(ByVal ProjectID As String, ByVal RecNo As Int32, ByVal RecSrNo As Int32, ByVal Filter_RecNo As Int32, ByVal Filter_ProjectID As String) As SIS.PAK.pakSitePkgD
      Return pakSitePkgDGetByID(ProjectID, RecNo, RecSrNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function pakSitePkgDInsert(ByVal Record As SIS.PAK.pakSitePkgD) As SIS.PAK.pakSitePkgD
      Dim _Rec As SIS.PAK.pakSitePkgD = SIS.PAK.pakSitePkgD.pakSitePkgDGetNewRecord()
      With _Rec
        .ItemNo = Record.ItemNo
        .SiteMarkNo = Record.SiteMarkNo
        .UOMQuantity = Record.UOMQuantity
        .Quantity = Record.Quantity
        .PackTypeID = Record.PackTypeID
        .OnlyPackageReceived = Record.OnlyPackageReceived
        .InventoryStatusID = siteInventoryStates.Free
        .Remarks = Record.Remarks
        .DocumentReceived = Record.DocumentReceived
        .PackHeight = Record.PackHeight
        .UOMPack = Record.UOMPack
        .InventoryUpdatedBy =  Global.System.Web.HttpContext.Current.Session("LoginID")
        .InventoryUpdatedOn = Now
        .NotFromPackingList = Record.NotFromPackingList
        .MaterialStatusID = Record.MaterialStatusID
        .BOMNo = Record.BOMNo
        .DocumentNo = Record.DocumentNo
        .PkgNo = Record.PkgNo
        .RecNo = Record.RecNo
        .SerialNo = Record.SerialNo
        .PackLength = Record.PackLength
        .PackWidth = Record.PackWidth
        .PackingMark = Record.PackingMark
        .DocumentRevision = Record.DocumentRevision
        .ProjectID = Record.ProjectID
      End With
      Return SIS.PAK.pakSitePkgD.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PAK.pakSitePkgD) As SIS.PAK.pakSitePkgD
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSitePkgDInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo",SqlDbType.Int,11, Record.ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteMarkNo",SqlDbType.NVarChar,31, Iif(Record.SiteMarkNo= "" ,Convert.DBNull, Record.SiteMarkNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMQuantity",SqlDbType.Int,11, Iif(Record.UOMQuantity= "" ,Convert.DBNull, Record.UOMQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quantity",SqlDbType.Decimal,21, Record.Quantity)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PackTypeID",SqlDbType.Int,11, Iif(Record.PackTypeID= "" ,Convert.DBNull, Record.PackTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OnlyPackageReceived",SqlDbType.Bit,3, Record.OnlyPackageReceived)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InventoryStatusID",SqlDbType.Int,11, Iif(Record.InventoryStatusID= "" ,Convert.DBNull, Record.InventoryStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,101, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentReceived",SqlDbType.Bit,3, Record.DocumentReceived)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PackHeight",SqlDbType.Decimal,21, Record.PackHeight)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMPack",SqlDbType.Int,11, Iif(Record.UOMPack= "" ,Convert.DBNull, Record.UOMPack))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InventoryUpdatedBy",SqlDbType.NVarChar,9, Iif(Record.InventoryUpdatedBy= "" ,Convert.DBNull, Record.InventoryUpdatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InventoryUpdatedOn",SqlDbType.DateTime,21, Iif(Record.InventoryUpdatedOn= "" ,Convert.DBNull, Record.InventoryUpdatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NotFromPackingList",SqlDbType.Bit,3, Record.NotFromPackingList)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaterialStatusID",SqlDbType.Int,11, Iif(Record.MaterialStatusID= "" ,Convert.DBNull, Record.MaterialStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BOMNo",SqlDbType.Int,11, Record.BOMNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentNo",SqlDbType.Int,11, Iif(Record.DocumentNo= "" ,Convert.DBNull, Record.DocumentNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PkgNo",SqlDbType.Int,11, Record.PkgNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RecNo",SqlDbType.Int,11, Record.RecNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PackLength",SqlDbType.Decimal,21, Record.PackLength)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PackWidth",SqlDbType.Decimal,21, Record.PackWidth)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PackingMark",SqlDbType.NVarChar,51, Iif(Record.PackingMark= "" ,Convert.DBNull, Record.PackingMark))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentRevision",SqlDbType.NVarChar,11, Iif(Record.DocumentRevision= "" ,Convert.DBNull, Record.DocumentRevision))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          Cmd.Parameters.Add("@Return_ProjectID", SqlDbType.NVarChar, 7)
          Cmd.Parameters("@Return_ProjectID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_RecNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_RecNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_RecSrNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_RecSrNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ProjectID = Cmd.Parameters("@Return_ProjectID").Value
          Record.RecNo = Cmd.Parameters("@Return_RecNo").Value
          Record.RecSrNo = Cmd.Parameters("@Return_RecSrNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakSitePkgDUpdate(ByVal Record As SIS.PAK.pakSitePkgD) As SIS.PAK.pakSitePkgD
      Dim _Rec As SIS.PAK.pakSitePkgD = SIS.PAK.pakSitePkgD.pakSitePkgDGetByID(Record.ProjectID, Record.RecNo, Record.RecSrNo)
      With _Rec
        .ItemNo = Record.ItemNo
        .SiteMarkNo = Record.SiteMarkNo
        .UOMQuantity = Record.UOMQuantity
        .Quantity = Record.Quantity
        .PackTypeID = Record.PackTypeID
        .OnlyPackageReceived = Record.OnlyPackageReceived
        .InventoryStatusID = Record.InventoryStatusID
        .Remarks = Record.Remarks
        .DocumentReceived = Record.DocumentReceived
        .PackHeight = Record.PackHeight
        .UOMPack = Record.UOMPack
        .InventoryUpdatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .InventoryUpdatedOn = Now
        .NotFromPackingList = Record.NotFromPackingList
        .MaterialStatusID = Record.MaterialStatusID
        .BOMNo = Record.BOMNo
        .DocumentNo = Record.DocumentNo
        .PkgNo = Record.PkgNo
        .SerialNo = Record.SerialNo
        .PackLength = Record.PackLength
        .PackWidth = Record.PackWidth
        .PackingMark = Record.PackingMark
        .DocumentRevision = Record.DocumentRevision
      End With
      Return SIS.PAK.pakSitePkgD.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PAK.pakSitePkgD) As SIS.PAK.pakSitePkgD
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSitePkgDUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RecSrNo",SqlDbType.Int,11, Record.RecSrNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RecNo",SqlDbType.Int,11, Record.RecNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo",SqlDbType.Int,11, Record.ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteMarkNo",SqlDbType.NVarChar,31, Iif(Record.SiteMarkNo= "" ,Convert.DBNull, Record.SiteMarkNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMQuantity",SqlDbType.Int,11, Iif(Record.UOMQuantity= "" ,Convert.DBNull, Record.UOMQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quantity",SqlDbType.Decimal,21, Record.Quantity)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PackTypeID",SqlDbType.Int,11, Iif(Record.PackTypeID= "" ,Convert.DBNull, Record.PackTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OnlyPackageReceived",SqlDbType.Bit,3, Record.OnlyPackageReceived)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InventoryStatusID",SqlDbType.Int,11, Iif(Record.InventoryStatusID= "" ,Convert.DBNull, Record.InventoryStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,101, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentReceived",SqlDbType.Bit,3, Record.DocumentReceived)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PackHeight",SqlDbType.Decimal,21, Record.PackHeight)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMPack",SqlDbType.Int,11, Iif(Record.UOMPack= "" ,Convert.DBNull, Record.UOMPack))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InventoryUpdatedBy",SqlDbType.NVarChar,9, Iif(Record.InventoryUpdatedBy= "" ,Convert.DBNull, Record.InventoryUpdatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InventoryUpdatedOn",SqlDbType.DateTime,21, Iif(Record.InventoryUpdatedOn= "" ,Convert.DBNull, Record.InventoryUpdatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NotFromPackingList",SqlDbType.Bit,3, Record.NotFromPackingList)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaterialStatusID",SqlDbType.Int,11, Iif(Record.MaterialStatusID= "" ,Convert.DBNull, Record.MaterialStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BOMNo",SqlDbType.Int,11, Record.BOMNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentNo",SqlDbType.Int,11, Iif(Record.DocumentNo= "" ,Convert.DBNull, Record.DocumentNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PkgNo",SqlDbType.Int,11, Record.PkgNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RecNo",SqlDbType.Int,11, Record.RecNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PackLength",SqlDbType.Decimal,21, Record.PackLength)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PackWidth",SqlDbType.Decimal,21, Record.PackWidth)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PackingMark",SqlDbType.NVarChar,51, Iif(Record.PackingMark= "" ,Convert.DBNull, Record.PackingMark))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentRevision",SqlDbType.NVarChar,11, Iif(Record.DocumentRevision= "" ,Convert.DBNull, Record.DocumentRevision))
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
    Public Shared Function pakSitePkgDDelete(ByVal Record As SIS.PAK.pakSitePkgD) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSitePkgDDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID",SqlDbType.NVarChar,Record.ProjectID.ToString.Length, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RecNo",SqlDbType.Int,Record.RecNo.ToString.Length, Record.RecNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RecSrNo",SqlDbType.Int,Record.RecSrNo.ToString.Length, Record.RecSrNo)
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
    Public Shared Function SelectpakSitePkgDAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSitePkgDAutoCompleteList"
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
            Dim Tmp As SIS.PAK.pakSitePkgD = New SIS.PAK.pakSitePkgD(Reader)
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
