Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakQCListH
    Private Shared _RecordCount As Integer
    Private _SerialNo As Int32 = 0
    Private _QCLNo As Int32 = 0
    Private _SupplierRef As String = ""
    Private _ClearedOn As String = ""
    Private _ClearedBy As String = ""
    Private _PkgNo As String = ""
    Private _Remarks As String = ""
    Private _StatusID As String = ""
    Private _UOMTotalWeight As String = ""
    Private _TotalWeight As String = "0.00"
    Public Property QualityClearedWt As Decimal = 0.0000
    Public Property QCRequestNo As String = ""
    Private _CreatedBy As String = ""
    Private _CreatedOn As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _PAK_PO2_PODescription As String = ""
    Private _PAK_QCListStatus3_Description As String = ""
    Private _PAK_Units4_Description As String = ""
    Private _aspnet_Users5_UserFullName As String = ""
    Private _FK_PAK_QCListH_CreatedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_PAK_QCListH_SerialNo As SIS.PAK.pakPO = Nothing
    Private _FK_PAK_QCListH_StatusID As SIS.PAK.pakQCListStatus = Nothing
    Private _FK_PAK_QCListH_UOMTotalWeight As SIS.PAK.pakUnits = Nothing
    Private _FK_PAK_QCListH_ClearedBy As SIS.QCM.qcmUsers = Nothing
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
    Public Property QCLNo() As Int32
      Get
        Return _QCLNo
      End Get
      Set(ByVal value As Int32)
        _QCLNo = value
      End Set
    End Property
    Public Property SupplierRef() As String
      Get
        Return _SupplierRef
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SupplierRef = ""
         Else
           _SupplierRef = value
         End If
      End Set
    End Property
    Public Property ClearedOn() As String
      Get
        If Not _ClearedOn = String.Empty Then
          Return Convert.ToDateTime(_ClearedOn).ToString("dd/MM/yyyy")
        End If
        Return _ClearedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ClearedOn = ""
         Else
           _ClearedOn = value
         End If
      End Set
    End Property
    Public Property ClearedBy() As String
      Get
        Return _ClearedBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ClearedBy = ""
         Else
           _ClearedBy = value
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
           _TotalWeight = "0.00"
         Else
           _TotalWeight = value
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
    Public Property PAK_QCListStatus3_Description() As String
      Get
        Return _PAK_QCListStatus3_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_QCListStatus3_Description = ""
         Else
           _PAK_QCListStatus3_Description = value
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
    Public Property aspnet_Users5_UserFullName() As String
      Get
        Return _aspnet_Users5_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users5_UserFullName = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _SupplierRef.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _SerialNo & "|" & _QCLNo
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
    Public Class PKpakQCListH
      Private _SerialNo As Int32 = 0
      Private _QCLNo As Int32 = 0
      Public Property SerialNo() As Int32
        Get
          Return _SerialNo
        End Get
        Set(ByVal value As Int32)
          _SerialNo = value
        End Set
      End Property
      Public Property QCLNo() As Int32
        Get
          Return _QCLNo
        End Get
        Set(ByVal value As Int32)
          _QCLNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PAK_QCListH_CreatedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_PAK_QCListH_CreatedBy Is Nothing Then
          _FK_PAK_QCListH_CreatedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_CreatedBy)
        End If
        Return _FK_PAK_QCListH_CreatedBy
      End Get
    End Property
    Public ReadOnly Property FK_PAK_QCListH_SerialNo() As SIS.PAK.pakPO
      Get
        If _FK_PAK_QCListH_SerialNo Is Nothing Then
          _FK_PAK_QCListH_SerialNo = SIS.PAK.pakPO.pakPOGetByID(_SerialNo)
        End If
        Return _FK_PAK_QCListH_SerialNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_QCListH_StatusID() As SIS.PAK.pakQCListStatus
      Get
        If _FK_PAK_QCListH_StatusID Is Nothing Then
          _FK_PAK_QCListH_StatusID = SIS.PAK.pakQCListStatus.pakQCListStatusGetByID(_StatusID)
        End If
        Return _FK_PAK_QCListH_StatusID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_QCListH_UOMTotalWeight() As SIS.PAK.pakUnits
      Get
        If _FK_PAK_QCListH_UOMTotalWeight Is Nothing Then
          _FK_PAK_QCListH_UOMTotalWeight = SIS.PAK.pakUnits.pakUnitsGetByID(_UOMTotalWeight)
        End If
        Return _FK_PAK_QCListH_UOMTotalWeight
      End Get
    End Property
    Public ReadOnly Property FK_PAK_QCListH_ClearedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_PAK_QCListH_ClearedBy Is Nothing Then
          _FK_PAK_QCListH_ClearedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_ClearedBy)
        End If
        Return _FK_PAK_QCListH_ClearedBy
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakQCListHSelectList(ByVal OrderBy As String) As List(Of SIS.PAK.pakQCListH)
      Dim Results As List(Of SIS.PAK.pakQCListH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakQCListHSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakQCListH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakQCListH(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakQCListHGetNewRecord() As SIS.PAK.pakQCListH
      Return New SIS.PAK.pakQCListH()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakQCListHGetByID(ByVal SerialNo As Int32, ByVal QCLNo As Int32) As SIS.PAK.pakQCListH
      Dim Results As SIS.PAK.pakQCListH = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakQCListHSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QCLNo",SqlDbType.Int,QCLNo.ToString.Length, QCLNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakQCListH(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakQCListHSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32) As List(Of SIS.PAK.pakQCListH)
      Dim Results As List(Of SIS.PAK.pakQCListH) = Nothing
      If OrderBy = "" Then OrderBy = "QCLNo DESC"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakQCListHSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakQCListHSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakQCListH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakQCListH(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakQCListHSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakQCListHGetByID(ByVal SerialNo As Int32, ByVal QCLNo As Int32, ByVal Filter_SerialNo As Int32) As SIS.PAK.pakQCListH
      Return pakQCListHGetByID(SerialNo, QCLNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function pakQCListHInsert(ByVal Record As SIS.PAK.pakQCListH) As SIS.PAK.pakQCListH
      Dim _Rec As SIS.PAK.pakQCListH = SIS.PAK.pakQCListH.pakQCListHGetNewRecord()
      With _Rec
        .SerialNo = Record.SerialNo
        .SupplierRef = Record.SupplierRef
        .StatusID = pakQCStates.Free
        .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
      End With
      Return SIS.PAK.pakQCListH.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PAK.pakQCListH) As SIS.PAK.pakQCListH
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakQCListHInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierRef",SqlDbType.NVarChar,51, Iif(Record.SupplierRef= "" ,Convert.DBNull, Record.SupplierRef))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClearedOn",SqlDbType.DateTime,21, Iif(Record.ClearedOn= "" ,Convert.DBNull, Record.ClearedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClearedBy",SqlDbType.NVarChar,9, Iif(Record.ClearedBy= "" ,Convert.DBNull, Record.ClearedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PkgNo",SqlDbType.Int,11, Iif(Record.PkgNo= "" ,Convert.DBNull, Record.PkgNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,501, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMTotalWeight",SqlDbType.Int,11, Iif(Record.UOMTotalWeight= "" ,Convert.DBNull, Record.UOMTotalWeight))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalWeight",SqlDbType.Decimal,21, Iif(Record.TotalWeight= "" ,Convert.DBNull, Record.TotalWeight))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QualityClearedWt", SqlDbType.Decimal, 21, Record.QualityClearedWt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QCRequestNo", SqlDbType.Int, 11, IIf(Record.QCRequestNo = "", Convert.DBNull, Record.QCRequestNo))
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_QCLNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_QCLNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
          Record.QCLNo = Cmd.Parameters("@Return_QCLNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakQCListHUpdate(ByVal Record As SIS.PAK.pakQCListH) As SIS.PAK.pakQCListH
      Dim _Rec As SIS.PAK.pakQCListH = SIS.PAK.pakQCListH.pakQCListHGetByID(Record.SerialNo, Record.QCLNo)
      With _Rec
        .SupplierRef = Record.SupplierRef
        .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
      End With
      Return SIS.PAK.pakQCListH.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PAK.pakQCListH) As SIS.PAK.pakQCListH
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakQCListHUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_QCLNo",SqlDbType.Int,11, Record.QCLNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierRef",SqlDbType.NVarChar,51, Iif(Record.SupplierRef= "" ,Convert.DBNull, Record.SupplierRef))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClearedOn",SqlDbType.DateTime,21, Iif(Record.ClearedOn= "" ,Convert.DBNull, Record.ClearedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClearedBy",SqlDbType.NVarChar,9, Iif(Record.ClearedBy= "" ,Convert.DBNull, Record.ClearedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PkgNo",SqlDbType.Int,11, Iif(Record.PkgNo= "" ,Convert.DBNull, Record.PkgNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,501, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMTotalWeight",SqlDbType.Int,11, Iif(Record.UOMTotalWeight= "" ,Convert.DBNull, Record.UOMTotalWeight))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalWeight",SqlDbType.Decimal,21, Iif(Record.TotalWeight= "" ,Convert.DBNull, Record.TotalWeight))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QualityClearedWt", SqlDbType.Decimal, 21, Record.QualityClearedWt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QCRequestNo", SqlDbType.Int, 11, IIf(Record.QCRequestNo = "", Convert.DBNull, Record.QCRequestNo))
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
    Public Shared Function pakQCListHDelete(ByVal Record As SIS.PAK.pakQCListH) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakQCListHDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,Record.SerialNo.ToString.Length, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_QCLNo",SqlDbType.Int,Record.QCLNo.ToString.Length, Record.QCLNo)
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
    Public Shared Function SelectpakQCListHAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakQCListHAutoCompleteList"
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
            Dim Tmp As SIS.PAK.pakQCListH = New SIS.PAK.pakQCListH(Reader)
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
