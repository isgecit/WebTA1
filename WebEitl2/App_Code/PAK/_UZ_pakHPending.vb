Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakHPending
    Public Shadows Function GetEditable() As Boolean
      Dim mRet As Boolean = False
      Return mRet
    End Function
    Public Shadows Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      Return mRet
    End Function
    Public Shadows ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property ApproveWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Shadows Function ReceivedAtPortWF(ByVal SerialNo As Int32, ByVal PkgNo As Int32) As SIS.PAK.pakHPending
      Dim Results As SIS.PAK.pakHPending = pakHPendingGetByID(SerialNo, PkgNo)
      Dim tmpItems As List(Of SIS.PAK.pakDPending) = SIS.PAK.pakDPending.pakDPendingSelectList(0, 99999, "", False, "", PkgNo, SerialNo)
      For Each tmpI As SIS.PAK.pakDPending In tmpItems
        With tmpI
          .FK_PAK_PkgListD_ItemNo.QuantityReceivedAtPort += .Quantity
          .FK_PAK_PkgListD_ItemNo.TotalWeightReceivedAtPort += .TotalWeight
        End With
        SIS.PAK.pakPOBItems.UpdateData(tmpI.FK_PAK_PkgListD_ItemNo)
      Next
      With Results
        .ReceivedAtPortBy = HttpContext.Current.Session("LoginID")
        .ReceivedAtPortOn = Now
        .StatusID = pakPkgStates.ReceivedAtPort
      End With
      Results = SIS.PAK.pakHPending.UpdateData(Results)
      Try
        SIS.CT.ctUpdates.CT_ReceivedAtPort(Results)
      Catch ex As Exception
      End Try
      Return Results
    End Function
    Public Shared Shadows Function ApproveWF(ByVal SerialNo As Int32, ByVal PkgNo As Int32) As SIS.PAK.pakHPending
      Dim Results As SIS.PAK.pakHPending = pakHPendingGetByID(SerialNo, PkgNo)
      'Create Receipt Header
      Dim tmpRecH As SIS.PAK.pakSitePkgH = SIS.PAK.pakHPending.GetSitePkgH(Results)
      tmpRecH = SIS.PAK.pakSitePkgH.InsertData(tmpRecH)
      'Create Receipt Details
      Dim tmpItems As List(Of SIS.PAK.pakDPending) = SIS.PAK.pakDPending.pakDPendingSelectList(0, 99999, "", False, "", PkgNo, SerialNo)
      For Each tmpI As SIS.PAK.pakDPending In tmpItems
        Dim tmpRecD As SIS.PAK.pakSitePkgD = SIS.PAK.pakDPending.GetSitePkgD(tmpI)
        tmpRecD.RecNo = tmpRecH.RecNo
        tmpRecD = SIS.PAK.pakSitePkgD.InsertData(tmpRecD)
        'Create Location Record
        Dim tmpRecDL As SIS.PAK.pakSitePkgDLocation = SIS.PAK.pakSitePkgD.GetSitePkgDLocation(tmpRecD)
        tmpRecDL = SIS.PAK.pakSitePkgDLocation.InsertData(tmpRecDL)
        'Find Available Locations For ProjectID & SiteMarkNo
        Dim tmpLs As List(Of SIS.PAK.pakSiteItemMasterLocation) = SIS.PAK.pakSiteItemMasterLocation.pakSiteItemMasterLocationSelectList(0, 99999, "", False, "", tmpRecDL.ProjectID, tmpRecDL.SiteMarkNo)
        If tmpLs.Count > 0 Then
          For Each tmpL As SIS.PAK.pakSiteItemMasterLocation In tmpLs
            With tmpRecDL
              .RecSrLNo = 0
              .Support = True
              .Quantity = tmpL.Quantity
              .LocationID = tmpL.LocationID
            End With
            tmpRecDL = SIS.PAK.pakSitePkgDLocation.InsertData(tmpRecDL)
          Next
        End If
      Next
      'Update Result
      Results.StatusID = pakPkgStates.ReceivedAtSite
      Results = SIS.PAK.pakHPending.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function UZ_pakHPendingSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32) As List(Of SIS.PAK.pakHPending)
      Dim Results As List(Of SIS.PAK.pakHPending) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          'Project ID Belongs to SiteUserProjects and PackageStatus is Despatched
          If SearchState Then
            Cmd.CommandText = "sppak_LG_HPendingSelectListSearch"
            'Cmd.CommandText = "sppakHPendingSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_HPendingSelectListFilteres"
            'Cmd.CommandText = "sppakHPendingSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PAK.pakHPending)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakHPending(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakHPendingAtPortSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32) As List(Of SIS.PAK.pakHPending)
      Dim Results As List(Of SIS.PAK.pakHPending) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          'Project ID Belongs to SiteUserProjects and PackageStatus is Despatched
          If SearchState Then
            Cmd.CommandText = "sppak_LG_HPendingAtPortSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_HPendingAtPortSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo", SqlDbType.Int, 10, IIf(SerialNo = Nothing, 0, SerialNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PAK.pakHPending)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakHPending(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakHPendingUpdate(ByVal Record As SIS.PAK.pakHPending) As SIS.PAK.pakHPending
      Dim _Result As SIS.PAK.pakHPending = pakHPendingUpdate(Record)
      Return _Result
    End Function
    Public Shared Function GetSitePkgH(ByVal pkgH As SIS.PAK.pakPkgListH) As SIS.PAK.pakSitePkgH
      Dim tmp As New SIS.PAK.pakSitePkgH
      With tmp
        .ProjectID = pkgH.FK_PAK_PkgListH_SerialNo.ProjectID
        .RecNo = 0
        .SerialNo = pkgH.SerialNo
        .PkgNo = pkgH.PkgNo
        .MRNNo = ""
        .SupplierID = pkgH.FK_PAK_PkgListH_SerialNo.SupplierID
        .SupplierName = pkgH.FK_PAK_PkgListH_SerialNo.VR_BusinessPartner9_BPName
        .SupplierRefNo = pkgH.SupplierRefNo
        .TransporterID = pkgH.TransporterID
        .TransporterName = pkgH.TransporterName
        .VehicleNo = pkgH.VehicleNo
        .GRNo = pkgH.GRNo
        .GRDate = pkgH.GRDate
        .UOMTotalWeight = pkgH.UOMTotalWeight
        .TotalWeight = pkgH.TotalWeight
        .ODC = False
        .MaterialStatusID = 1
        .Remarks = ""
        .ReceiveStatusID = siteReceiveStates.Free
        .CreatedBy = HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
      End With
      Return tmp
    End Function
  End Class
End Namespace
