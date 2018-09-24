Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakSitePkgDLocation
    Private Shared _RecordCount As Integer
    Private _RecSrLNo As Int32 = 0
    Private _ItemNo As Int32 = 0
    Private _SiteMarkNo As String = ""
    Private _UOMQuantity As String = ""
    Private _Quantity As Decimal = 0
    Private _LocationID As String = ""
    Private _Support As Boolean = False
    Private _Remarks As String = ""
    Private _RecSrNo As Int32 = 0
    Private _RecNo As Int32 = 0
    Private _ProjectID As String = ""
    Private _BOMNo As Int32 = 0
    Private _PkgNo As Int32 = 0
    Private _SerialNo As Int32 = 0
    Private _IDM_Projects1_Description As String = ""
    Private _PAK_PkgListD2_PackingMark As String = ""
    Private _PAK_PkgListH3_SupplierRefNo As String = ""
    Private _PAK_PO4_PODescription As String = ""
    Private _PAK_SiteItemMaster5_ItemDescription As String = ""
    Private _PAK_SiteLocations6_Description As String = ""
    Private _PAK_SitePkgD7_SiteMarkNo As String = ""
    Private _PAK_SitePkgH8_SupplierRefNo As String = ""
    Private _PAK_Units9_Description As String = ""
    Private _FK_PAK_SitePkgDLocation_ProjectID As SIS.QCM.qcmProjects = Nothing
    Private _FK_PAK_SitePkgDLocation_ItemNo As SIS.PAK.pakPkgListD = Nothing
    Private _FK_PAK_SitePkgDLocation_PkgNo As SIS.PAK.pakPkgListH = Nothing
    Private _FK_PAK_SitePkgDLocation_SerialNo As SIS.PAK.pakPO = Nothing
    Private _FK_PAK_SitePkgDLocation_SiteMarkNo As SIS.PAK.pakSiteItemMaster = Nothing
    Private _FK_PAK_SitePkgDLocation_LocationID As SIS.PAK.pakSiteLocations = Nothing
    Private _FK_PAK_SitePkgDLocation_RecSrNo As SIS.PAK.pakSitePkgD = Nothing
    Private _FK_PAK_SitePkgDLocation_RecNo As SIS.PAK.pakSitePkgH = Nothing
    Private _FK_PAK_SitePkgDLocation_UOMQuantity As SIS.PAK.pakUnits = Nothing
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
    Public Property RecSrLNo() As Int32
      Get
        Return _RecSrLNo
      End Get
      Set(ByVal value As Int32)
        _RecSrLNo = value
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
    Public Property LocationID() As String
      Get
        Return _LocationID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _LocationID = ""
         Else
           _LocationID = value
         End If
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
    Public Property RecSrNo() As Int32
      Get
        Return _RecSrNo
      End Get
      Set(ByVal value As Int32)
        _RecSrNo = value
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
    Public Property ProjectID() As String
      Get
        Return _ProjectID
      End Get
      Set(ByVal value As String)
        _ProjectID = value
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
    Public Property PkgNo() As Int32
      Get
        Return _PkgNo
      End Get
      Set(ByVal value As Int32)
        _PkgNo = value
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
    Public Property IDM_Projects1_Description() As String
      Get
        Return _IDM_Projects1_Description
      End Get
      Set(ByVal value As String)
        _IDM_Projects1_Description = value
      End Set
    End Property
    Public Property PAK_PkgListD2_PackingMark() As String
      Get
        Return _PAK_PkgListD2_PackingMark
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_PkgListD2_PackingMark = ""
         Else
           _PAK_PkgListD2_PackingMark = value
         End If
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
    Public Property PAK_SiteItemMaster5_ItemDescription() As String
      Get
        Return _PAK_SiteItemMaster5_ItemDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_SiteItemMaster5_ItemDescription = ""
         Else
           _PAK_SiteItemMaster5_ItemDescription = value
         End If
      End Set
    End Property
    Public Property PAK_SiteLocations6_Description() As String
      Get
        Return _PAK_SiteLocations6_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_SiteLocations6_Description = ""
         Else
           _PAK_SiteLocations6_Description = value
         End If
      End Set
    End Property
    Public Property PAK_SitePkgD7_SiteMarkNo() As String
      Get
        Return _PAK_SitePkgD7_SiteMarkNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_SitePkgD7_SiteMarkNo = ""
         Else
           _PAK_SitePkgD7_SiteMarkNo = value
         End If
      End Set
    End Property
    Public Property PAK_SitePkgH8_SupplierRefNo() As String
      Get
        Return _PAK_SitePkgH8_SupplierRefNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_SitePkgH8_SupplierRefNo = ""
         Else
           _PAK_SitePkgH8_SupplierRefNo = value
         End If
      End Set
    End Property
    Public Property PAK_Units9_Description() As String
      Get
        Return _PAK_Units9_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_Units9_Description = ""
         Else
           _PAK_Units9_Description = value
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
        Return _ProjectID & "|" & _RecNo & "|" & _RecSrNo & "|" & _RecSrLNo
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
    Public Class PKpakSitePkgDLocation
      Private _ProjectID As String = ""
      Private _RecNo As Int32 = 0
      Private _RecSrNo As Int32 = 0
      Private _RecSrLNo As Int32 = 0
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
      Public Property RecSrLNo() As Int32
        Get
          Return _RecSrLNo
        End Get
        Set(ByVal value As Int32)
          _RecSrLNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PAK_SitePkgDLocation_ProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_PAK_SitePkgDLocation_ProjectID Is Nothing Then
          _FK_PAK_SitePkgDLocation_ProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_ProjectID)
        End If
        Return _FK_PAK_SitePkgDLocation_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SitePkgDLocation_ItemNo() As SIS.PAK.pakPkgListD
      Get
        If _FK_PAK_SitePkgDLocation_ItemNo Is Nothing Then
          _FK_PAK_SitePkgDLocation_ItemNo = SIS.PAK.pakPkgListD.pakPkgListDGetByID(_SerialNo, _PkgNo, _BOMNo, _ItemNo)
        End If
        Return _FK_PAK_SitePkgDLocation_ItemNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SitePkgDLocation_PkgNo() As SIS.PAK.pakPkgListH
      Get
        If _FK_PAK_SitePkgDLocation_PkgNo Is Nothing Then
          _FK_PAK_SitePkgDLocation_PkgNo = SIS.PAK.pakPkgListH.pakPkgListHGetByID(_SerialNo, _PkgNo)
        End If
        Return _FK_PAK_SitePkgDLocation_PkgNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SitePkgDLocation_SerialNo() As SIS.PAK.pakPO
      Get
        If _FK_PAK_SitePkgDLocation_SerialNo Is Nothing Then
          _FK_PAK_SitePkgDLocation_SerialNo = SIS.PAK.pakPO.pakPOGetByID(_SerialNo)
        End If
        Return _FK_PAK_SitePkgDLocation_SerialNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SitePkgDLocation_SiteMarkNo() As SIS.PAK.pakSiteItemMaster
      Get
        If _FK_PAK_SitePkgDLocation_SiteMarkNo Is Nothing Then
          _FK_PAK_SitePkgDLocation_SiteMarkNo = SIS.PAK.pakSiteItemMaster.pakSiteItemMasterGetByID(_ProjectID, _SiteMarkNo)
        End If
        Return _FK_PAK_SitePkgDLocation_SiteMarkNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SitePkgDLocation_LocationID() As SIS.PAK.pakSiteLocations
      Get
        If _FK_PAK_SitePkgDLocation_LocationID Is Nothing Then
          _FK_PAK_SitePkgDLocation_LocationID = SIS.PAK.pakSiteLocations.pakSiteLocationsGetByID(_LocationID)
        End If
        Return _FK_PAK_SitePkgDLocation_LocationID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SitePkgDLocation_RecSrNo() As SIS.PAK.pakSitePkgD
      Get
        If _FK_PAK_SitePkgDLocation_RecSrNo Is Nothing Then
          _FK_PAK_SitePkgDLocation_RecSrNo = SIS.PAK.pakSitePkgD.pakSitePkgDGetByID(_ProjectID, _RecNo, _RecSrNo)
        End If
        Return _FK_PAK_SitePkgDLocation_RecSrNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SitePkgDLocation_RecNo() As SIS.PAK.pakSitePkgH
      Get
        If _FK_PAK_SitePkgDLocation_RecNo Is Nothing Then
          _FK_PAK_SitePkgDLocation_RecNo = SIS.PAK.pakSitePkgH.pakSitePkgHGetByID(_ProjectID, _RecNo)
        End If
        Return _FK_PAK_SitePkgDLocation_RecNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SitePkgDLocation_UOMQuantity() As SIS.PAK.pakUnits
      Get
        If _FK_PAK_SitePkgDLocation_UOMQuantity Is Nothing Then
          _FK_PAK_SitePkgDLocation_UOMQuantity = SIS.PAK.pakUnits.pakUnitsGetByID(_UOMQuantity)
        End If
        Return _FK_PAK_SitePkgDLocation_UOMQuantity
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSitePkgDLocationGetNewRecord() As SIS.PAK.pakSitePkgDLocation
      Return New SIS.PAK.pakSitePkgDLocation()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSitePkgDLocationGetByID(ByVal ProjectID As String, ByVal RecNo As Int32, ByVal RecSrNo As Int32, ByVal RecSrLNo As Int32) As SIS.PAK.pakSitePkgDLocation
      Dim Results As SIS.PAK.pakSitePkgDLocation = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSitePkgDLocationSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,ProjectID.ToString.Length, ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RecNo",SqlDbType.Int,RecNo.ToString.Length, RecNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RecSrNo",SqlDbType.Int,RecSrNo.ToString.Length, RecSrNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RecSrLNo",SqlDbType.Int,RecSrLNo.ToString.Length, RecSrLNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakSitePkgDLocation(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSitePkgDLocationSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal RecSrNo As Int32, ByVal RecNo As Int32, ByVal ProjectID As String) As List(Of SIS.PAK.pakSitePkgDLocation)
      Dim Results As List(Of SIS.PAK.pakSitePkgDLocation) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakSitePkgDLocationSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakSitePkgDLocationSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RecSrNo",SqlDbType.Int,10, IIf(RecSrNo = Nothing, 0,RecSrNo))
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
          Results = New List(Of SIS.PAK.pakSitePkgDLocation)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSitePkgDLocation(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakSitePkgDLocationSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal RecSrNo As Int32, ByVal RecNo As Int32, ByVal ProjectID As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSitePkgDLocationGetByID(ByVal ProjectID As String, ByVal RecNo As Int32, ByVal RecSrNo As Int32, ByVal RecSrLNo As Int32, ByVal Filter_RecSrNo As Int32, ByVal Filter_RecNo As Int32, ByVal Filter_ProjectID As String) As SIS.PAK.pakSitePkgDLocation
      Return pakSitePkgDLocationGetByID(ProjectID, RecNo, RecSrNo, RecSrLNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function pakSitePkgDLocationInsert(ByVal Record As SIS.PAK.pakSitePkgDLocation) As SIS.PAK.pakSitePkgDLocation
      Dim _Rec As SIS.PAK.pakSitePkgDLocation = SIS.PAK.pakSitePkgDLocation.pakSitePkgDLocationGetNewRecord()
      With _Rec
        .ItemNo = Record.ItemNo
        .SiteMarkNo = Record.SiteMarkNo
        .UOMQuantity = Record.UOMQuantity
        .Quantity = Record.Quantity
        .LocationID = Record.LocationID
        .Support = Record.Support
        .Remarks = Record.Remarks
        .RecSrNo = Record.RecSrNo
        .RecNo = Record.RecNo
        .ProjectID = Record.ProjectID
        .BOMNo = Record.BOMNo
        .PkgNo = Record.PkgNo
        .SerialNo = Record.SerialNo
      End With
      Return SIS.PAK.pakSitePkgDLocation.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PAK.pakSitePkgDLocation) As SIS.PAK.pakSitePkgDLocation
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSitePkgDLocationInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo",SqlDbType.Int,11, Record.ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteMarkNo",SqlDbType.NVarChar,31, Iif(Record.SiteMarkNo= "" ,Convert.DBNull, Record.SiteMarkNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMQuantity",SqlDbType.Int,11, Iif(Record.UOMQuantity= "" ,Convert.DBNull, Record.UOMQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quantity",SqlDbType.Decimal,21, Record.Quantity)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LocationID",SqlDbType.Int,11, Iif(Record.LocationID= "" ,Convert.DBNull, Record.LocationID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Support",SqlDbType.Bit,3, Record.Support)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,101, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RecSrNo",SqlDbType.Int,11, Record.RecSrNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RecNo",SqlDbType.Int,11, Record.RecNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BOMNo",SqlDbType.Int,11, Record.BOMNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PkgNo",SqlDbType.Int,11, Record.PkgNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          Cmd.Parameters.Add("@Return_ProjectID", SqlDbType.NVarChar, 7)
          Cmd.Parameters("@Return_ProjectID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_RecNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_RecNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_RecSrNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_RecSrNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_RecSrLNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_RecSrLNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ProjectID = Cmd.Parameters("@Return_ProjectID").Value
          Record.RecNo = Cmd.Parameters("@Return_RecNo").Value
          Record.RecSrNo = Cmd.Parameters("@Return_RecSrNo").Value
          Record.RecSrLNo = Cmd.Parameters("@Return_RecSrLNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakSitePkgDLocationUpdate(ByVal Record As SIS.PAK.pakSitePkgDLocation) As SIS.PAK.pakSitePkgDLocation
      Dim _Rec As SIS.PAK.pakSitePkgDLocation = SIS.PAK.pakSitePkgDLocation.pakSitePkgDLocationGetByID(Record.ProjectID, Record.RecNo, Record.RecSrNo, Record.RecSrLNo)
      With _Rec
        .ItemNo = Record.ItemNo
        .SiteMarkNo = Record.SiteMarkNo
        .UOMQuantity = Record.UOMQuantity
        .Quantity = Record.Quantity
        .LocationID = Record.LocationID
        .Support = Record.Support
        .Remarks = Record.Remarks
        .BOMNo = Record.BOMNo
        .PkgNo = Record.PkgNo
        .SerialNo = Record.SerialNo
      End With
      Return SIS.PAK.pakSitePkgDLocation.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PAK.pakSitePkgDLocation) As SIS.PAK.pakSitePkgDLocation
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSitePkgDLocationUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RecSrLNo",SqlDbType.Int,11, Record.RecSrLNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RecSrNo",SqlDbType.Int,11, Record.RecSrNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RecNo",SqlDbType.Int,11, Record.RecNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo",SqlDbType.Int,11, Record.ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteMarkNo",SqlDbType.NVarChar,31, Iif(Record.SiteMarkNo= "" ,Convert.DBNull, Record.SiteMarkNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMQuantity",SqlDbType.Int,11, Iif(Record.UOMQuantity= "" ,Convert.DBNull, Record.UOMQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quantity",SqlDbType.Decimal,21, Record.Quantity)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LocationID",SqlDbType.Int,11, Iif(Record.LocationID= "" ,Convert.DBNull, Record.LocationID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Support",SqlDbType.Bit,3, Record.Support)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,101, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RecSrNo",SqlDbType.Int,11, Record.RecSrNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RecNo",SqlDbType.Int,11, Record.RecNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BOMNo",SqlDbType.Int,11, Record.BOMNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PkgNo",SqlDbType.Int,11, Record.PkgNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
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
    Public Shared Function pakSitePkgDLocationDelete(ByVal Record As SIS.PAK.pakSitePkgDLocation) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSitePkgDLocationDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID",SqlDbType.NVarChar,Record.ProjectID.ToString.Length, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RecNo",SqlDbType.Int,Record.RecNo.ToString.Length, Record.RecNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RecSrNo",SqlDbType.Int,Record.RecSrNo.ToString.Length, Record.RecSrNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RecSrLNo",SqlDbType.Int,Record.RecSrLNo.ToString.Length, Record.RecSrLNo)
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
