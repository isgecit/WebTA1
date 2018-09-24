Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakSiteItemMasterLocation
    Private Shared _RecordCount As Integer
    Private _ProjectID As String = ""
    Private _SiteMarkNo As String = ""
    Private _LocationID As Int32 = 0
    Private _UOMQuantity As String = ""
    Private _Quantity As Decimal = 0
    Private _IDM_Projects1_Description As String = ""
    Private _PAK_SiteItemMaster2_ItemDescription As String = ""
    Private _PAK_SiteLocations3_Description As String = ""
    Private _PAK_Units4_Description As String = ""
    Private _FK_PAK_SiteItemMasterLocation_ProjectID As SIS.QCM.qcmProjects = Nothing
    Private _FK_PAK_SiteItemMasterLocation_SiteMarkNo As SIS.PAK.pakSiteItemMaster = Nothing
    Private _FK_PAK_SiteItemMasterLocation_LocationID As SIS.PAK.pakSiteLocations = Nothing
    Private _FK_PAK_SiteItemMasterLocation_UOMQuantity As SIS.PAK.pakUnits = Nothing
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
    Public Property SiteMarkNo() As String
      Get
        Return _SiteMarkNo
      End Get
      Set(ByVal value As String)
        _SiteMarkNo = value
      End Set
    End Property
    Public Property LocationID() As Int32
      Get
        Return _LocationID
      End Get
      Set(ByVal value As Int32)
        _LocationID = value
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
    Public Property IDM_Projects1_Description() As String
      Get
        Return _IDM_Projects1_Description
      End Get
      Set(ByVal value As String)
        _IDM_Projects1_Description = value
      End Set
    End Property
    Public Property PAK_SiteItemMaster2_ItemDescription() As String
      Get
        Return _PAK_SiteItemMaster2_ItemDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_SiteItemMaster2_ItemDescription = ""
         Else
           _PAK_SiteItemMaster2_ItemDescription = value
         End If
      End Set
    End Property
    Public Property PAK_SiteLocations3_Description() As String
      Get
        Return _PAK_SiteLocations3_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_SiteLocations3_Description = ""
         Else
           _PAK_SiteLocations3_Description = value
         End If
      End Set
    End Property
    Public Property PAK_Units4_Description() As String
      Get
        Return _PAK_Units4_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_Units4_Description = ""
         Else
           _PAK_Units4_Description = value
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
        Return _ProjectID & "|" & _SiteMarkNo & "|" & _LocationID
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
    Public Class PKpakSiteItemMasterLocation
      Private _ProjectID As String = ""
      Private _SiteMarkNo As String = ""
      Private _LocationID As Int32 = 0
      Public Property ProjectID() As String
        Get
          Return _ProjectID
        End Get
        Set(ByVal value As String)
          _ProjectID = value
        End Set
      End Property
      Public Property SiteMarkNo() As String
        Get
          Return _SiteMarkNo
        End Get
        Set(ByVal value As String)
          _SiteMarkNo = value
        End Set
      End Property
      Public Property LocationID() As Int32
        Get
          Return _LocationID
        End Get
        Set(ByVal value As Int32)
          _LocationID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PAK_SiteItemMasterLocation_ProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_PAK_SiteItemMasterLocation_ProjectID Is Nothing Then
          _FK_PAK_SiteItemMasterLocation_ProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_ProjectID)
        End If
        Return _FK_PAK_SiteItemMasterLocation_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SiteItemMasterLocation_SiteMarkNo() As SIS.PAK.pakSiteItemMaster
      Get
        If _FK_PAK_SiteItemMasterLocation_SiteMarkNo Is Nothing Then
          _FK_PAK_SiteItemMasterLocation_SiteMarkNo = SIS.PAK.pakSiteItemMaster.pakSiteItemMasterGetByID(_ProjectID, _SiteMarkNo)
        End If
        Return _FK_PAK_SiteItemMasterLocation_SiteMarkNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SiteItemMasterLocation_LocationID() As SIS.PAK.pakSiteLocations
      Get
        If _FK_PAK_SiteItemMasterLocation_LocationID Is Nothing Then
          _FK_PAK_SiteItemMasterLocation_LocationID = SIS.PAK.pakSiteLocations.pakSiteLocationsGetByID(_LocationID)
        End If
        Return _FK_PAK_SiteItemMasterLocation_LocationID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_SiteItemMasterLocation_UOMQuantity() As SIS.PAK.pakUnits
      Get
        If _FK_PAK_SiteItemMasterLocation_UOMQuantity Is Nothing Then
          _FK_PAK_SiteItemMasterLocation_UOMQuantity = SIS.PAK.pakUnits.pakUnitsGetByID(_UOMQuantity)
        End If
        Return _FK_PAK_SiteItemMasterLocation_UOMQuantity
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSiteItemMasterLocationGetNewRecord() As SIS.PAK.pakSiteItemMasterLocation
      Return New SIS.PAK.pakSiteItemMasterLocation()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSiteItemMasterLocationGetByID(ByVal ProjectID As String, ByVal SiteMarkNo As String, ByVal LocationID As Int32) As SIS.PAK.pakSiteItemMasterLocation
      Dim Results As SIS.PAK.pakSiteItemMasterLocation = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSiteItemMasterLocationSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,ProjectID.ToString.Length, ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteMarkNo",SqlDbType.NVarChar,SiteMarkNo.ToString.Length, SiteMarkNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LocationID",SqlDbType.Int,LocationID.ToString.Length, LocationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakSiteItemMasterLocation(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSiteItemMasterLocationSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String, ByVal SiteMarkNo As String) As List(Of SIS.PAK.pakSiteItemMasterLocation)
      Dim Results As List(Of SIS.PAK.pakSiteItemMasterLocation) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakSiteItemMasterLocationSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakSiteItemMasterLocationSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SiteMarkNo",SqlDbType.NVarChar,30, IIf(SiteMarkNo Is Nothing, String.Empty,SiteMarkNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakSiteItemMasterLocation)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSiteItemMasterLocation(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakSiteItemMasterLocationSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String, ByVal SiteMarkNo As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSiteItemMasterLocationGetByID(ByVal ProjectID As String, ByVal SiteMarkNo As String, ByVal LocationID As Int32, ByVal Filter_ProjectID As String, ByVal Filter_SiteMarkNo As String) As SIS.PAK.pakSiteItemMasterLocation
      Return pakSiteItemMasterLocationGetByID(ProjectID, SiteMarkNo, LocationID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function pakSiteItemMasterLocationInsert(ByVal Record As SIS.PAK.pakSiteItemMasterLocation) As SIS.PAK.pakSiteItemMasterLocation
      Dim _Rec As SIS.PAK.pakSiteItemMasterLocation = SIS.PAK.pakSiteItemMasterLocation.pakSiteItemMasterLocationGetNewRecord()
      With _Rec
        .ProjectID = Record.ProjectID
        .SiteMarkNo = Record.SiteMarkNo
        .LocationID = Record.LocationID
        .UOMQuantity = Record.UOMQuantity
        .Quantity = Record.Quantity
      End With
      Return SIS.PAK.pakSiteItemMasterLocation.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PAK.pakSiteItemMasterLocation) As SIS.PAK.pakSiteItemMasterLocation
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSiteItemMasterLocationInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteMarkNo",SqlDbType.NVarChar,31, Record.SiteMarkNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LocationID",SqlDbType.Int,11, Record.LocationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMQuantity",SqlDbType.Int,11, Iif(Record.UOMQuantity= "" ,Convert.DBNull, Record.UOMQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quantity",SqlDbType.Decimal,21, Record.Quantity)
          Cmd.Parameters.Add("@Return_ProjectID", SqlDbType.NVarChar, 7)
          Cmd.Parameters("@Return_ProjectID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_SiteMarkNo", SqlDbType.NVarChar, 31)
          Cmd.Parameters("@Return_SiteMarkNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_LocationID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_LocationID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ProjectID = Cmd.Parameters("@Return_ProjectID").Value
          Record.SiteMarkNo = Cmd.Parameters("@Return_SiteMarkNo").Value
          Record.LocationID = Cmd.Parameters("@Return_LocationID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakSiteItemMasterLocationUpdate(ByVal Record As SIS.PAK.pakSiteItemMasterLocation) As SIS.PAK.pakSiteItemMasterLocation
      Dim _Rec As SIS.PAK.pakSiteItemMasterLocation = SIS.PAK.pakSiteItemMasterLocation.pakSiteItemMasterLocationGetByID(Record.ProjectID, Record.SiteMarkNo, Record.LocationID)
      With _Rec
        .UOMQuantity = Record.UOMQuantity
        .Quantity = Record.Quantity
      End With
      Return SIS.PAK.pakSiteItemMasterLocation.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PAK.pakSiteItemMasterLocation) As SIS.PAK.pakSiteItemMasterLocation
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSiteItemMasterLocationUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SiteMarkNo",SqlDbType.NVarChar,31, Record.SiteMarkNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_LocationID",SqlDbType.Int,11, Record.LocationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteMarkNo",SqlDbType.NVarChar,31, Record.SiteMarkNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LocationID",SqlDbType.Int,11, Record.LocationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMQuantity",SqlDbType.Int,11, Iif(Record.UOMQuantity= "" ,Convert.DBNull, Record.UOMQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quantity",SqlDbType.Decimal,21, Record.Quantity)
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
    Public Shared Function pakSiteItemMasterLocationDelete(ByVal Record As SIS.PAK.pakSiteItemMasterLocation) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakSiteItemMasterLocationDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID",SqlDbType.NVarChar,Record.ProjectID.ToString.Length, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SiteMarkNo",SqlDbType.NVarChar,Record.SiteMarkNo.ToString.Length, Record.SiteMarkNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_LocationID",SqlDbType.Int,Record.LocationID.ToString.Length, Record.LocationID)
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
