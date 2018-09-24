Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakTCPOLR
    Private Shared _RecordCount As Integer
    Private _UploadNo As Int32 = 0
    Private _DocumentCategoryID As String = ""
    Private _CreatedOn As String = ""
    Private _ReceiptNo As String = ""
    Private _RevisionNo As String = ""
    Private _UploadStatusID As String = ""
    Private _SerialNo As Int32 = 0
    Private _ItemNo As Int32 = 0
    Private _UploadRemarks As String = ""
    Private _CreatedBy As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _PAK_PO2_PODescription As String = ""
    Private _PAK_POLine3_ItemCode As String = ""
    Private _PAK_POLineRecCategory4_Description As String = ""
    Private _PAK_POLineRecStatus5_Description As String = ""
    Private _FK_PAK_POLineRec_CreatedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_PAK_POLineRec_SerialNo As SIS.PAK.pakPO = Nothing
    Private _FK_PAK_POLineRec_ItemNo As SIS.PAK.pakTCPOL = Nothing
    Private _FK_PAK_POLineRec_DocumentCategoryID As SIS.PAK.pakTCPOLRCate = Nothing
    Private _FK_PAK_POLineRec_UploadStatusID As SIS.PAK.pakTCPOLRStatus = Nothing
    Public Property SDocSerialNo As Integer = 0
    Public Property ERPTransmittalNo As String = ""
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
    Public Property UploadNo() As Int32
      Get
        Return _UploadNo
      End Get
      Set(ByVal value As Int32)
        _UploadNo = value
      End Set
    End Property
    Public Property DocumentCategoryID() As String
      Get
        Return _DocumentCategoryID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DocumentCategoryID = ""
         Else
           _DocumentCategoryID = value
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
    Public Property ReceiptNo() As String
      Get
        Return _ReceiptNo
      End Get
      Set(ByVal value As String)
        _ReceiptNo = value
      End Set
    End Property
    Public Property RevisionNo() As String
      Get
        Return _RevisionNo
      End Get
      Set(ByVal value As String)
        _RevisionNo = value
      End Set
    End Property
    Public Property UploadStatusID() As String
      Get
        Return _UploadStatusID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _UploadStatusID = ""
         Else
           _UploadStatusID = value
         End If
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
    Public Property ItemNo() As Int32
      Get
        Return _ItemNo
      End Get
      Set(ByVal value As Int32)
        _ItemNo = value
      End Set
    End Property
    Public Property UploadRemarks() As String
      Get
        Return _UploadRemarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _UploadRemarks = ""
         Else
           _UploadRemarks = value
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
    Public Property PAK_POLine3_ItemCode() As String
      Get
        Return _PAK_POLine3_ItemCode
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_POLine3_ItemCode = ""
         Else
           _PAK_POLine3_ItemCode = value
         End If
      End Set
    End Property
    Public Property PAK_POLineRecCategory4_Description() As String
      Get
        Return _PAK_POLineRecCategory4_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_POLineRecCategory4_Description = ""
         Else
           _PAK_POLineRecCategory4_Description = value
         End If
      End Set
    End Property
    Public Property PAK_POLineRecStatus5_Description() As String
      Get
        Return _PAK_POLineRecStatus5_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_POLineRecStatus5_Description = ""
         Else
           _PAK_POLineRecStatus5_Description = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _UploadNo.ToString.PadRight(10, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _SerialNo & "|" & _ItemNo & "|" & _UploadNo
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
    Public Class PKpakTCPOLR
      Private _SerialNo As Int32 = 0
      Private _ItemNo As Int32 = 0
      Private _UploadNo As Int32 = 0
      Public Property SerialNo() As Int32
        Get
          Return _SerialNo
        End Get
        Set(ByVal value As Int32)
          _SerialNo = value
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
      Public Property UploadNo() As Int32
        Get
          Return _UploadNo
        End Get
        Set(ByVal value As Int32)
          _UploadNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PAK_POLineRec_CreatedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_PAK_POLineRec_CreatedBy Is Nothing Then
          _FK_PAK_POLineRec_CreatedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_CreatedBy)
        End If
        Return _FK_PAK_POLineRec_CreatedBy
      End Get
    End Property
    Public ReadOnly Property FK_PAK_POLineRec_SerialNo() As SIS.PAK.pakPO
      Get
        If _FK_PAK_POLineRec_SerialNo Is Nothing Then
          _FK_PAK_POLineRec_SerialNo = SIS.PAK.pakPO.pakPOGetByID(_SerialNo)
        End If
        Return _FK_PAK_POLineRec_SerialNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_POLineRec_ItemNo() As SIS.PAK.pakTCPOL
      Get
        If _FK_PAK_POLineRec_ItemNo Is Nothing Then
          _FK_PAK_POLineRec_ItemNo = SIS.PAK.pakTCPOL.pakTCPOLGetByID(_SerialNo, _ItemNo)
        End If
        Return _FK_PAK_POLineRec_ItemNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_POLineRec_DocumentCategoryID() As SIS.PAK.pakTCPOLRCate
      Get
        If _FK_PAK_POLineRec_DocumentCategoryID Is Nothing Then
          _FK_PAK_POLineRec_DocumentCategoryID = SIS.PAK.pakTCPOLRCate.pakTCPOLRCateGetByID(_DocumentCategoryID)
        End If
        Return _FK_PAK_POLineRec_DocumentCategoryID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_POLineRec_UploadStatusID() As SIS.PAK.pakTCPOLRStatus
      Get
        If _FK_PAK_POLineRec_UploadStatusID Is Nothing Then
          _FK_PAK_POLineRec_UploadStatusID = SIS.PAK.pakTCPOLRStatus.pakTCPOLRStatusGetByID(_UploadStatusID)
        End If
        Return _FK_PAK_POLineRec_UploadStatusID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakTCPOLRSelectList(ByVal OrderBy As String) As List(Of SIS.PAK.pakTCPOLR)
      Dim Results As List(Of SIS.PAK.pakTCPOLR) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakTCPOLRSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakTCPOLR)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakTCPOLR(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakTCPOLRGetNewRecord() As SIS.PAK.pakTCPOLR
      Return New SIS.PAK.pakTCPOLR()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakTCPOLRGetByID(ByVal SerialNo As Int32, ByVal ItemNo As Int32, ByVal UploadNo As Int32) As SIS.PAK.pakTCPOLR
      Dim Results As SIS.PAK.pakTCPOLR = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakTCPOLRSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo",SqlDbType.Int,ItemNo.ToString.Length, ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UploadNo",SqlDbType.Int,UploadNo.ToString.Length, UploadNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakTCPOLR(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakTCPOLRSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal ItemNo As Int32) As List(Of SIS.PAK.pakTCPOLR)
      Dim Results As List(Of SIS.PAK.pakTCPOLR) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakTCPOLRSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakTCPOLRSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ItemNo",SqlDbType.Int,10, IIf(ItemNo = Nothing, 0,ItemNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakTCPOLR)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakTCPOLR(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakTCPOLRSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal ItemNo As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakTCPOLRGetByID(ByVal SerialNo As Int32, ByVal ItemNo As Int32, ByVal UploadNo As Int32, ByVal Filter_SerialNo As Int32, ByVal Filter_ItemNo As Int32) As SIS.PAK.pakTCPOLR
      Return pakTCPOLRGetByID(SerialNo, ItemNo, UploadNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function pakTCPOLRInsert(ByVal Record As SIS.PAK.pakTCPOLR) As SIS.PAK.pakTCPOLR
      Dim _Rec As SIS.PAK.pakTCPOLR = SIS.PAK.pakTCPOLR.pakTCPOLRGetNewRecord()
      With _Rec
        .DocumentCategoryID = Record.DocumentCategoryID
        .CreatedOn = Record.CreatedOn
        .ReceiptNo = Record.ReceiptNo
        .RevisionNo = Record.RevisionNo
        .UploadStatusID = Record.UploadStatusID
        .SerialNo = Record.SerialNo
        .ItemNo = Record.ItemNo
        .UploadRemarks = Record.UploadRemarks
        .CreatedBy = Record.CreatedBy
        .SDocSerialNo = Record.SDocSerialNo
        .ERPTransmittalNo = Record.ERPTransmittalNo
      End With
      Return SIS.PAK.pakTCPOLR.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PAK.pakTCPOLR) As SIS.PAK.pakTCPOLR
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakTCPOLRInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentCategoryID",SqlDbType.Int,11, Iif(Record.DocumentCategoryID= "" ,Convert.DBNull, Record.DocumentCategoryID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptNo",SqlDbType.NVarChar,10, Record.ReceiptNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RevisionNo",SqlDbType.NVarChar,21, Record.RevisionNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UploadStatusID",SqlDbType.Int,11, Iif(Record.UploadStatusID= "" ,Convert.DBNull, Record.UploadStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo",SqlDbType.Int,11, Record.ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UploadRemarks",SqlDbType.NVarChar,501, Iif(Record.UploadRemarks= "" ,Convert.DBNull, Record.UploadRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SDocSerialNo", SqlDbType.Int, 11, Record.SDocSerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ERPTransmittalNo", SqlDbType.NVarChar, 10, Record.ERPTransmittalNo)
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_ItemNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ItemNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_UploadNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_UploadNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
          Record.ItemNo = Cmd.Parameters("@Return_ItemNo").Value
          Record.UploadNo = Cmd.Parameters("@Return_UploadNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakTCPOLRUpdate(ByVal Record As SIS.PAK.pakTCPOLR) As SIS.PAK.pakTCPOLR
      Dim _Rec As SIS.PAK.pakTCPOLR = SIS.PAK.pakTCPOLR.pakTCPOLRGetByID(Record.SerialNo, Record.ItemNo, Record.UploadNo)
      With _Rec
        .DocumentCategoryID = Record.DocumentCategoryID
        .CreatedOn = Record.CreatedOn
        .ReceiptNo = Record.ReceiptNo
        .RevisionNo = Record.RevisionNo
        .UploadStatusID = Record.UploadStatusID
        .UploadRemarks = Record.UploadRemarks
        .CreatedBy = Record.CreatedBy
        .SDocSerialNo = Record.SDocSerialNo
        .ERPTransmittalNo = Record.ERPTransmittalNo
      End With
      Return SIS.PAK.pakTCPOLR.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PAK.pakTCPOLR) As SIS.PAK.pakTCPOLR
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakTCPOLRUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_UploadNo",SqlDbType.Int,11, Record.UploadNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ItemNo",SqlDbType.Int,11, Record.ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentCategoryID",SqlDbType.Int,11, Iif(Record.DocumentCategoryID= "" ,Convert.DBNull, Record.DocumentCategoryID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptNo",SqlDbType.NVarChar,10, Record.ReceiptNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RevisionNo",SqlDbType.NVarChar,21, Record.RevisionNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UploadStatusID",SqlDbType.Int,11, Iif(Record.UploadStatusID= "" ,Convert.DBNull, Record.UploadStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo",SqlDbType.Int,11, Record.ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UploadRemarks",SqlDbType.NVarChar,501, Iif(Record.UploadRemarks= "" ,Convert.DBNull, Record.UploadRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Iif(Record.CreatedBy= "" ,Convert.DBNull, Record.CreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SDocSerialNo", SqlDbType.Int, 11, Record.SDocSerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ERPTransmittalNo", SqlDbType.NVarChar, 10, Record.ERPTransmittalNo)
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
    Public Shared Function pakTCPOLRDelete(ByVal Record As SIS.PAK.pakTCPOLR) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakTCPOLRDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,Record.SerialNo.ToString.Length, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ItemNo",SqlDbType.Int,Record.ItemNo.ToString.Length, Record.ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_UploadNo",SqlDbType.Int,Record.UploadNo.ToString.Length, Record.UploadNo)
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
    Public Shared Function SelectpakTCPOLRAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakTCPOLRAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(10, " "),"" & "|" & "" & "|" & ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.PAK.pakTCPOLR = New SIS.PAK.pakTCPOLR(Reader)
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
