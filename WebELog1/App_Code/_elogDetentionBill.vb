Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ELOG
  <DataObject()> _
  Partial Public Class elogDetentionBill
    Private Shared _RecordCount As Integer
    Private _IRNo As Int32 = 0
    Private _IRDate As String = ""
    Private _SupplierID As String = ""
    Private _SupplierBillNo As String = ""
    Private _SupplierBillDate As String = ""
    Private _BillAmount As String = "0.00"
    Private _GRNo As String = ""
    Private _GRDate As String = ""
    Private _ProjectID As String = ""
    Private _PONumber As String = ""
    Private _BillTypeID As String = ""
    Private _OtherBillType As String = ""
    Private _VehicleExeNo As String = ""
    Private _MRNNo As String = ""
    Private _CreatedOn As String = ""
    Private _StatusID As String = ""
    Private _CreatedBy As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _ELOG_DetentionBillStatus2_Description As String = ""
    Private _ELOG_DetentionBillTypes3_Description As String = ""
    Private _IDM_Projects4_Description As String = ""
    Private _VR_BusinessPartner5_BPName As String = ""
    Private _FK_ELOG_DetentionBill_CreatedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_ELOG_DetentionBill_StatusID As SIS.ELOG.elogDetentionBillStatus = Nothing
    Private _FK_ELOG_DetentionBill_BillTypeID As SIS.ELOG.elogDetentionBillTypes = Nothing
    Private _FK_ELOG_DetentionBill_ProjectID As SIS.QCM.qcmProjects = Nothing
    Private _FK_ELOG_DetentionBill_SupplierID As SIS.VR.vrBusinessPartner = Nothing
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
    Public Property IRDate() As String
      Get
        If Not _IRDate = String.Empty Then
          Return Convert.ToDateTime(_IRDate).ToString("dd/MM/yyyy")
        End If
        Return _IRDate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _IRDate = ""
         Else
           _IRDate = value
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
    Public Property SupplierBillNo() As String
      Get
        Return _SupplierBillNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SupplierBillNo = ""
         Else
           _SupplierBillNo = value
         End If
      End Set
    End Property
    Public Property SupplierBillDate() As String
      Get
        If Not _SupplierBillDate = String.Empty Then
          Return Convert.ToDateTime(_SupplierBillDate).ToString("dd/MM/yyyy")
        End If
        Return _SupplierBillDate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SupplierBillDate = ""
         Else
           _SupplierBillDate = value
         End If
      End Set
    End Property
    Public Property BillAmount() As String
      Get
        Return _BillAmount
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _BillAmount = "0.00"
         Else
           _BillAmount = value
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
    Public Property ProjectID() As String
      Get
        Return _ProjectID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ProjectID = ""
         Else
           _ProjectID = value
         End If
      End Set
    End Property
    Public Property PONumber() As String
      Get
        Return _PONumber
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PONumber = ""
         Else
           _PONumber = value
         End If
      End Set
    End Property
    Public Property BillTypeID() As String
      Get
        Return _BillTypeID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _BillTypeID = ""
         Else
           _BillTypeID = value
         End If
      End Set
    End Property
    Public Property OtherBillType() As String
      Get
        Return _OtherBillType
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _OtherBillType = ""
         Else
           _OtherBillType = value
         End If
      End Set
    End Property
    Public Property VehicleExeNo() As String
      Get
        Return _VehicleExeNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VehicleExeNo = ""
         Else
           _VehicleExeNo = value
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
    Public Property aspnet_Users1_UserFullName() As String
      Get
        Return _aspnet_Users1_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users1_UserFullName = value
      End Set
    End Property
    Public Property ELOG_DetentionBillStatus2_Description() As String
      Get
        Return _ELOG_DetentionBillStatus2_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ELOG_DetentionBillStatus2_Description = ""
         Else
           _ELOG_DetentionBillStatus2_Description = value
         End If
      End Set
    End Property
    Public Property ELOG_DetentionBillTypes3_Description() As String
      Get
        Return _ELOG_DetentionBillTypes3_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ELOG_DetentionBillTypes3_Description = ""
         Else
           _ELOG_DetentionBillTypes3_Description = value
         End If
      End Set
    End Property
    Public Property IDM_Projects4_Description() As String
      Get
        Return _IDM_Projects4_Description
      End Get
      Set(ByVal value As String)
        _IDM_Projects4_Description = value
      End Set
    End Property
    Public Property VR_BusinessPartner5_BPName() As String
      Get
        Return _VR_BusinessPartner5_BPName
      End Get
      Set(ByVal value As String)
        _VR_BusinessPartner5_BPName = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
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
    Public Class PKelogDetentionBill
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
    Public ReadOnly Property FK_ELOG_DetentionBill_CreatedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_ELOG_DetentionBill_CreatedBy Is Nothing Then
          _FK_ELOG_DetentionBill_CreatedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_CreatedBy)
        End If
        Return _FK_ELOG_DetentionBill_CreatedBy
      End Get
    End Property
    Public ReadOnly Property FK_ELOG_DetentionBill_StatusID() As SIS.ELOG.elogDetentionBillStatus
      Get
        If _FK_ELOG_DetentionBill_StatusID Is Nothing Then
          _FK_ELOG_DetentionBill_StatusID = SIS.ELOG.elogDetentionBillStatus.elogDetentionBillStatusGetByID(_StatusID)
        End If
        Return _FK_ELOG_DetentionBill_StatusID
      End Get
    End Property
    Public ReadOnly Property FK_ELOG_DetentionBill_BillTypeID() As SIS.ELOG.elogDetentionBillTypes
      Get
        If _FK_ELOG_DetentionBill_BillTypeID Is Nothing Then
          _FK_ELOG_DetentionBill_BillTypeID = SIS.ELOG.elogDetentionBillTypes.elogDetentionBillTypesGetByID(_BillTypeID)
        End If
        Return _FK_ELOG_DetentionBill_BillTypeID
      End Get
    End Property
    Public ReadOnly Property FK_ELOG_DetentionBill_ProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_ELOG_DetentionBill_ProjectID Is Nothing Then
          _FK_ELOG_DetentionBill_ProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_ProjectID)
        End If
        Return _FK_ELOG_DetentionBill_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_ELOG_DetentionBill_SupplierID() As SIS.VR.vrBusinessPartner
      Get
        If _FK_ELOG_DetentionBill_SupplierID Is Nothing Then
          _FK_ELOG_DetentionBill_SupplierID = SIS.VR.vrBusinessPartner.vrBusinessPartnerGetByID(_SupplierID)
        End If
        Return _FK_ELOG_DetentionBill_SupplierID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function elogDetentionBillGetNewRecord() As SIS.ELOG.elogDetentionBill
      Return New SIS.ELOG.elogDetentionBill()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function elogDetentionBillGetByID(ByVal IRNo As Int32) As SIS.ELOG.elogDetentionBill
      Dim Results As SIS.ELOG.elogDetentionBill = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogDetentionBillSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRNo",SqlDbType.Int,IRNo.ToString.Length, IRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ELOG.elogDetentionBill(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function elogDetentionBillSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SupplierID As String, ByVal ProjectID As String) As List(Of SIS.ELOG.elogDetentionBill)
      Dim Results As List(Of SIS.ELOG.elogDetentionBill) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spelogDetentionBillSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spelogDetentionBillSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SupplierID",SqlDbType.NVarChar,9, IIf(SupplierID Is Nothing, String.Empty,SupplierID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ELOG.elogDetentionBill)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ELOG.elogDetentionBill(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function elogDetentionBillSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SupplierID As String, ByVal ProjectID As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function elogDetentionBillGetByID(ByVal IRNo As Int32, ByVal Filter_SupplierID As String, ByVal Filter_ProjectID As String) As SIS.ELOG.elogDetentionBill
      Return elogDetentionBillGetByID(IRNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function elogDetentionBillInsert(ByVal Record As SIS.ELOG.elogDetentionBill) As SIS.ELOG.elogDetentionBill
      Dim _Rec As SIS.ELOG.elogDetentionBill = SIS.ELOG.elogDetentionBill.elogDetentionBillGetNewRecord()
      With _Rec
        .IRNo = Record.IRNo
        .IRDate = Record.IRDate
        .SupplierID = Record.SupplierID
        .SupplierBillNo = Record.SupplierBillNo
        .SupplierBillDate = Record.SupplierBillDate
        .BillAmount = Record.BillAmount
        .GRNo = Record.GRNo
        .GRDate = Record.GRDate
        .ProjectID = Record.ProjectID
        .PONumber = Record.PONumber
        .BillTypeID = Record.BillTypeID
        .OtherBillType = Record.OtherBillType
        .VehicleExeNo = Record.VehicleExeNo
        .MRNNo = Record.MRNNo
        .CreatedOn = Now
        .StatusID = 1
        .CreatedBy =  Global.System.Web.HttpContext.Current.Session("LoginID")
      End With
      Return SIS.ELOG.elogDetentionBill.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.ELOG.elogDetentionBill) As SIS.ELOG.elogDetentionBill
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogDetentionBillInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRNo",SqlDbType.Int,11, Record.IRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRDate",SqlDbType.DateTime,21, Iif(Record.IRDate= "" ,Convert.DBNull, Record.IRDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID",SqlDbType.NVarChar,10, Iif(Record.SupplierID= "" ,Convert.DBNull, Record.SupplierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierBillNo",SqlDbType.NVarChar,51, Iif(Record.SupplierBillNo= "" ,Convert.DBNull, Record.SupplierBillNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierBillDate",SqlDbType.DateTime,21, Iif(Record.SupplierBillDate= "" ,Convert.DBNull, Record.SupplierBillDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillAmount",SqlDbType.Decimal,21, Iif(Record.BillAmount= "" ,Convert.DBNull, Record.BillAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GRNo",SqlDbType.NVarChar,51, Iif(Record.GRNo= "" ,Convert.DBNull, Record.GRNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GRDate",SqlDbType.DateTime,21, Iif(Record.GRDate= "" ,Convert.DBNull, Record.GRDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PONumber",SqlDbType.NVarChar,10, Iif(Record.PONumber= "" ,Convert.DBNull, Record.PONumber))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillTypeID",SqlDbType.Int,11, Iif(Record.BillTypeID= "" ,Convert.DBNull, Record.BillTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OtherBillType",SqlDbType.NVarChar,21, Iif(Record.OtherBillType= "" ,Convert.DBNull, Record.OtherBillType))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleExeNo",SqlDbType.Int,11, Iif(Record.VehicleExeNo= "" ,Convert.DBNull, Record.VehicleExeNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MRNNo",SqlDbType.Int,11, Iif(Record.MRNNo= "" ,Convert.DBNull, Record.MRNNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          Cmd.Parameters.Add("@Return_IRNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_IRNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.IRNo = Cmd.Parameters("@Return_IRNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function elogDetentionBillUpdate(ByVal Record As SIS.ELOG.elogDetentionBill) As SIS.ELOG.elogDetentionBill
      Dim _Rec As SIS.ELOG.elogDetentionBill = SIS.ELOG.elogDetentionBill.elogDetentionBillGetByID(Record.IRNo)
      With _Rec
        .IRDate = Record.IRDate
        .SupplierID = Record.SupplierID
        .SupplierBillNo = Record.SupplierBillNo
        .SupplierBillDate = Record.SupplierBillDate
        .BillAmount = Record.BillAmount
        .GRNo = Record.GRNo
        .GRDate = Record.GRDate
        .ProjectID = Record.ProjectID
        .PONumber = Record.PONumber
        .BillTypeID = Record.BillTypeID
        .OtherBillType = Record.OtherBillType
        .VehicleExeNo = Record.VehicleExeNo
        .MRNNo = Record.MRNNo
        .CreatedOn = Now
        .StatusID = Record.StatusID
        .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
      End With
      Return SIS.ELOG.elogDetentionBill.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.ELOG.elogDetentionBill) As SIS.ELOG.elogDetentionBill
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogDetentionBillUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_IRNo",SqlDbType.Int,11, Record.IRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRNo",SqlDbType.Int,11, Record.IRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRDate",SqlDbType.DateTime,21, Iif(Record.IRDate= "" ,Convert.DBNull, Record.IRDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID",SqlDbType.NVarChar,10, Iif(Record.SupplierID= "" ,Convert.DBNull, Record.SupplierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierBillNo",SqlDbType.NVarChar,51, Iif(Record.SupplierBillNo= "" ,Convert.DBNull, Record.SupplierBillNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierBillDate",SqlDbType.DateTime,21, Iif(Record.SupplierBillDate= "" ,Convert.DBNull, Record.SupplierBillDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillAmount",SqlDbType.Decimal,21, Iif(Record.BillAmount= "" ,Convert.DBNull, Record.BillAmount))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GRNo",SqlDbType.NVarChar,51, Iif(Record.GRNo= "" ,Convert.DBNull, Record.GRNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GRDate",SqlDbType.DateTime,21, Iif(Record.GRDate= "" ,Convert.DBNull, Record.GRDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PONumber",SqlDbType.NVarChar,10, Iif(Record.PONumber= "" ,Convert.DBNull, Record.PONumber))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillTypeID",SqlDbType.Int,11, Iif(Record.BillTypeID= "" ,Convert.DBNull, Record.BillTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OtherBillType",SqlDbType.NVarChar,21, Iif(Record.OtherBillType= "" ,Convert.DBNull, Record.OtherBillType))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleExeNo",SqlDbType.Int,11, Iif(Record.VehicleExeNo= "" ,Convert.DBNull, Record.VehicleExeNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MRNNo",SqlDbType.Int,11, Iif(Record.MRNNo= "" ,Convert.DBNull, Record.MRNNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
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
    Public Shared Function elogDetentionBillDelete(ByVal Record As SIS.ELOG.elogDetentionBill) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelogDetentionBillDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_IRNo",SqlDbType.Int,Record.IRNo.ToString.Length, Record.IRNo)
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
