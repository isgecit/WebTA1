Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ERP
  <DataObject()> _
  Partial Public Class erpDCRDetail
    Private Shared _RecordCount As Integer
    Private _DCRNo As String = ""
    Private _DocumentID As String = ""
    Private _RevisionNo As String = ""
    Private _IndentNo As String = ""
    Private _IndentLine As String = ""
    Private _LotItem As String = ""
    Private _ItemDescription As String = ""
    Private _IndenterID As String = ""
    Private _BuyerID As String = ""
    Private _OrderNo As String = ""
    Private _OrderLine As String = ""
    Private _SupplierID As String = ""
    Private _BuyerIDinPO As String = ""
    Private _IndenterName As String = ""
    Private _IndenterEMail As String = ""
    Private _BuyerName As String = ""
    Private _BuyerEMail As String = ""
    Private _BuyerIDinPOName As String = ""
    Private _BuyerIDinPOEMail As String = ""
    Private _SupplierName As String = ""
    Private _DocumentTitle As String = ""
    Private _ERP_DCRHeader1_DCRDescription As String = ""
    Private _FK_ERP_DCRDetail_DCRNo As SIS.ERP.erpDCRHeader = Nothing
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
    Public Property DCRNo() As String
      Get
        Return _DCRNo
      End Get
      Set(ByVal value As String)
        _DCRNo = value
      End Set
    End Property
    Public Property DocumentID() As String
      Get
        Return _DocumentID
      End Get
      Set(ByVal value As String)
        _DocumentID = value
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
    Public Property IndentNo() As String
      Get
        Return _IndentNo
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _IndentNo = ""
				 Else
					 _IndentNo = value
			   End If
      End Set
    End Property
    Public Property IndentLine() As String
      Get
        Return _IndentLine
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _IndentLine = ""
				 Else
					 _IndentLine = value
			   End If
      End Set
    End Property
    Public Property LotItem() As String
      Get
        Return _LotItem
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _LotItem = ""
				 Else
					 _LotItem = value
			   End If
      End Set
    End Property
    Public Property ItemDescription() As String
      Get
        Return _ItemDescription
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ItemDescription = ""
				 Else
					 _ItemDescription = value
			   End If
      End Set
    End Property
    Public Property IndenterID() As String
      Get
        Return _IndenterID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _IndenterID = ""
				 Else
					 _IndenterID = value
			   End If
      End Set
    End Property
    Public Property BuyerID() As String
      Get
        Return _BuyerID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _BuyerID = ""
				 Else
					 _BuyerID = value
			   End If
      End Set
    End Property
    Public Property OrderNo() As String
      Get
        Return _OrderNo
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _OrderNo = ""
				 Else
					 _OrderNo = value
			   End If
      End Set
    End Property
    Public Property OrderLine() As String
      Get
        Return _OrderLine
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _OrderLine = ""
				 Else
					 _OrderLine = value
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
    Public Property BuyerIDinPO() As String
      Get
        Return _BuyerIDinPO
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _BuyerIDinPO = ""
				 Else
					 _BuyerIDinPO = value
			   End If
      End Set
    End Property
    Public Property IndenterName() As String
      Get
        Return _IndenterName
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _IndenterName = ""
				 Else
					 _IndenterName = value
			   End If
      End Set
    End Property
    Public Property IndenterEMail() As String
      Get
        Return _IndenterEMail
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _IndenterEMail = ""
				 Else
					 _IndenterEMail = value
			   End If
      End Set
    End Property
    Public Property BuyerName() As String
      Get
        Return _BuyerName
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _BuyerName = ""
				 Else
					 _BuyerName = value
			   End If
      End Set
    End Property
    Public Property BuyerEMail() As String
      Get
        Return _BuyerEMail
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _BuyerEMail = ""
				 Else
					 _BuyerEMail = value
			   End If
      End Set
    End Property
    Public Property BuyerIDinPOName() As String
      Get
        Return _BuyerIDinPOName
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _BuyerIDinPOName = ""
				 Else
					 _BuyerIDinPOName = value
			   End If
      End Set
    End Property
    Public Property BuyerIDinPOEMail() As String
      Get
        Return _BuyerIDinPOEMail
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _BuyerIDinPOEMail = ""
				 Else
					 _BuyerIDinPOEMail = value
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
    Public Property DocumentTitle() As String
      Get
        Return _DocumentTitle
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _DocumentTitle = ""
				 Else
					 _DocumentTitle = value
			   End If
      End Set
    End Property
    Public Property ERP_DCRHeader1_DCRDescription() As String
      Get
        Return _ERP_DCRHeader1_DCRDescription
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ERP_DCRHeader1_DCRDescription = ""
				 Else
					 _ERP_DCRHeader1_DCRDescription = value
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
        Return _DCRNo & "|" & _DocumentID & "|" & _RevisionNo
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
    Public Class PKerpDCRDetail
			Private _DCRNo As String = ""
			Private _DocumentID As String = ""
			Private _RevisionNo As String = ""
			Public Property DCRNo() As String
				Get
					Return _DCRNo
				End Get
				Set(ByVal value As String)
					_DCRNo = value
				End Set
			End Property
			Public Property DocumentID() As String
				Get
					Return _DocumentID
				End Get
				Set(ByVal value As String)
					_DocumentID = value
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
    End Class
    Public ReadOnly Property FK_ERP_DCRDetail_DCRNo() As SIS.ERP.erpDCRHeader
      Get
        If _FK_ERP_DCRDetail_DCRNo Is Nothing Then
          _FK_ERP_DCRDetail_DCRNo = SIS.ERP.erpDCRHeader.erpDCRHeaderGetByID(_DCRNo)
        End If
        Return _FK_ERP_DCRDetail_DCRNo
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpDCRDetailGetNewRecord() As SIS.ERP.erpDCRDetail
      Return New SIS.ERP.erpDCRDetail()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpDCRDetailGetByID(ByVal DCRNo As String, ByVal DocumentID As String, ByVal RevisionNo As String) As SIS.ERP.erpDCRDetail
      Dim Results As SIS.ERP.erpDCRDetail = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpDCRDetailSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DCRNo",SqlDbType.NVarChar,DCRNo.ToString.Length, DCRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentID",SqlDbType.NVarChar,DocumentID.ToString.Length, DocumentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RevisionNo",SqlDbType.NVarChar,RevisionNo.ToString.Length, RevisionNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.ERP.erpDCRDetail(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpDCRDetailSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal DCRNo As String) As List(Of SIS.ERP.erpDCRDetail)
      Dim Results As List(Of SIS.ERP.erpDCRDetail) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "sperpDCRDetailSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "sperpDCRDetailSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DCRNo",SqlDbType.NVarChar,10, IIf(DCRNo Is Nothing, String.Empty,DCRNo))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ERP.erpDCRDetail)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ERP.erpDCRDetail(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function erpDCRDetailSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal DCRNo As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpDCRDetailGetByID(ByVal DCRNo As String, ByVal DocumentID As String, ByVal RevisionNo As String, ByVal Filter_DCRNo As String) As SIS.ERP.erpDCRDetail
      Return erpDCRDetailGetByID(DCRNo, DocumentID, RevisionNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function erpDCRDetailInsert(ByVal Record As SIS.ERP.erpDCRDetail) As SIS.ERP.erpDCRDetail
      Dim _Rec As SIS.ERP.erpDCRDetail = SIS.ERP.erpDCRDetail.erpDCRDetailGetNewRecord()
      With _Rec
        .DCRNo = Record.DCRNo
        .DocumentID = Record.DocumentID
        .RevisionNo = Record.RevisionNo
        .IndentNo = Record.IndentNo
        .IndentLine = Record.IndentLine
        .LotItem = Record.LotItem
        .ItemDescription = Record.ItemDescription
        .IndenterID = Record.IndenterID
        .BuyerID = Record.BuyerID
        .OrderNo = Record.OrderNo
        .OrderLine = Record.OrderLine
        .SupplierID = Record.SupplierID
        .BuyerIDinPO = Record.BuyerIDinPO
        .IndenterName = Record.IndenterName
        .IndenterEMail = Record.IndenterEMail
        .BuyerName = Record.BuyerName
        .BuyerEMail = Record.BuyerEMail
        .BuyerIDinPOName = Record.BuyerIDinPOName
        .BuyerIDinPOEMail = Record.BuyerIDinPOEMail
        .SupplierName = Record.SupplierName
        .DocumentTitle = Record.DocumentTitle
      End With
      Return SIS.ERP.erpDCRDetail.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.ERP.erpDCRDetail) As SIS.ERP.erpDCRDetail
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpDCRDetailInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DCRNo",SqlDbType.NVarChar,11, Record.DCRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentID",SqlDbType.NVarChar,31, Record.DocumentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RevisionNo",SqlDbType.NVarChar,6, Record.RevisionNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndentNo",SqlDbType.NVarChar,11, Iif(Record.IndentNo= "" ,Convert.DBNull, Record.IndentNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndentLine",SqlDbType.NVarChar,6, Iif(Record.IndentLine= "" ,Convert.DBNull, Record.IndentLine))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LotItem",SqlDbType.NVarChar,51, Iif(Record.LotItem= "" ,Convert.DBNull, Record.LotItem))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemDescription",SqlDbType.NVarChar,101, Iif(Record.ItemDescription= "" ,Convert.DBNull, Record.ItemDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndenterID",SqlDbType.NVarChar,9, Iif(Record.IndenterID= "" ,Convert.DBNull, Record.IndenterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerID",SqlDbType.NVarChar,9, Iif(Record.BuyerID= "" ,Convert.DBNull, Record.BuyerID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderNo",SqlDbType.NVarChar,11, Iif(Record.OrderNo= "" ,Convert.DBNull, Record.OrderNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderLine",SqlDbType.NVarChar,6, Iif(Record.OrderLine= "" ,Convert.DBNull, Record.OrderLine))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID",SqlDbType.NVarChar,11, Iif(Record.SupplierID= "" ,Convert.DBNull, Record.SupplierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerIDinPO",SqlDbType.NVarChar,9, Iif(Record.BuyerIDinPO= "" ,Convert.DBNull, Record.BuyerIDinPO))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndenterName",SqlDbType.NVarChar,51, Iif(Record.IndenterName= "" ,Convert.DBNull, Record.IndenterName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndenterEMail",SqlDbType.NVarChar,51, Iif(Record.IndenterEMail= "" ,Convert.DBNull, Record.IndenterEMail))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerName",SqlDbType.NVarChar,51, Iif(Record.BuyerName= "" ,Convert.DBNull, Record.BuyerName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerEMail",SqlDbType.NVarChar,51, Iif(Record.BuyerEMail= "" ,Convert.DBNull, Record.BuyerEMail))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerIDinPOName",SqlDbType.NVarChar,51, Iif(Record.BuyerIDinPOName= "" ,Convert.DBNull, Record.BuyerIDinPOName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerIDinPOEMail",SqlDbType.NVarChar,51, Iif(Record.BuyerIDinPOEMail= "" ,Convert.DBNull, Record.BuyerIDinPOEMail))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierName",SqlDbType.NVarChar,101, Iif(Record.SupplierName= "" ,Convert.DBNull, Record.SupplierName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentTitle",SqlDbType.NVarChar,101, Iif(Record.DocumentTitle= "" ,Convert.DBNull, Record.DocumentTitle))
          Cmd.Parameters.Add("@Return_DCRNo", SqlDbType.NVarChar, 11)
          Cmd.Parameters("@Return_DCRNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_DocumentID", SqlDbType.NVarChar, 31)
          Cmd.Parameters("@Return_DocumentID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_RevisionNo", SqlDbType.NVarChar, 6)
          Cmd.Parameters("@Return_RevisionNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.DCRNo = Cmd.Parameters("@Return_DCRNo").Value
          Record.DocumentID = Cmd.Parameters("@Return_DocumentID").Value
          Record.RevisionNo = Cmd.Parameters("@Return_RevisionNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function erpDCRDetailUpdate(ByVal Record As SIS.ERP.erpDCRDetail) As SIS.ERP.erpDCRDetail
      Dim _Rec As SIS.ERP.erpDCRDetail = SIS.ERP.erpDCRDetail.erpDCRDetailGetByID(Record.DCRNo, Record.DocumentID, Record.RevisionNo)
      With _Rec
        .IndentNo = Record.IndentNo
        .IndentLine = Record.IndentLine
        .LotItem = Record.LotItem
        .ItemDescription = Record.ItemDescription
        .IndenterID = Record.IndenterID
        .BuyerID = Record.BuyerID
        .OrderNo = Record.OrderNo
        .OrderLine = Record.OrderLine
        .SupplierID = Record.SupplierID
        .BuyerIDinPO = Record.BuyerIDinPO
        .IndenterName = Record.IndenterName
        .IndenterEMail = Record.IndenterEMail
        .BuyerName = Record.BuyerName
        .BuyerEMail = Record.BuyerEMail
        .BuyerIDinPOName = Record.BuyerIDinPOName
        .BuyerIDinPOEMail = Record.BuyerIDinPOEMail
        .SupplierName = Record.SupplierName
        .DocumentTitle = Record.DocumentTitle
      End With
      Return SIS.ERP.erpDCRDetail.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.ERP.erpDCRDetail) As SIS.ERP.erpDCRDetail
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpDCRDetailUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DCRNo",SqlDbType.NVarChar,11, Record.DCRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DocumentID",SqlDbType.NVarChar,31, Record.DocumentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RevisionNo",SqlDbType.NVarChar,6, Record.RevisionNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DCRNo",SqlDbType.NVarChar,11, Record.DCRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentID",SqlDbType.NVarChar,31, Record.DocumentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RevisionNo",SqlDbType.NVarChar,6, Record.RevisionNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndentNo",SqlDbType.NVarChar,11, Iif(Record.IndentNo= "" ,Convert.DBNull, Record.IndentNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndentLine",SqlDbType.NVarChar,6, Iif(Record.IndentLine= "" ,Convert.DBNull, Record.IndentLine))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LotItem",SqlDbType.NVarChar,51, Iif(Record.LotItem= "" ,Convert.DBNull, Record.LotItem))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemDescription",SqlDbType.NVarChar,101, Iif(Record.ItemDescription= "" ,Convert.DBNull, Record.ItemDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndenterID",SqlDbType.NVarChar,9, Iif(Record.IndenterID= "" ,Convert.DBNull, Record.IndenterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerID",SqlDbType.NVarChar,9, Iif(Record.BuyerID= "" ,Convert.DBNull, Record.BuyerID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderNo",SqlDbType.NVarChar,11, Iif(Record.OrderNo= "" ,Convert.DBNull, Record.OrderNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderLine",SqlDbType.NVarChar,6, Iif(Record.OrderLine= "" ,Convert.DBNull, Record.OrderLine))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID",SqlDbType.NVarChar,11, Iif(Record.SupplierID= "" ,Convert.DBNull, Record.SupplierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerIDinPO",SqlDbType.NVarChar,9, Iif(Record.BuyerIDinPO= "" ,Convert.DBNull, Record.BuyerIDinPO))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndenterName",SqlDbType.NVarChar,51, Iif(Record.IndenterName= "" ,Convert.DBNull, Record.IndenterName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IndenterEMail",SqlDbType.NVarChar,51, Iif(Record.IndenterEMail= "" ,Convert.DBNull, Record.IndenterEMail))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerName",SqlDbType.NVarChar,51, Iif(Record.BuyerName= "" ,Convert.DBNull, Record.BuyerName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerEMail",SqlDbType.NVarChar,51, Iif(Record.BuyerEMail= "" ,Convert.DBNull, Record.BuyerEMail))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerIDinPOName",SqlDbType.NVarChar,51, Iif(Record.BuyerIDinPOName= "" ,Convert.DBNull, Record.BuyerIDinPOName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerIDinPOEMail",SqlDbType.NVarChar,51, Iif(Record.BuyerIDinPOEMail= "" ,Convert.DBNull, Record.BuyerIDinPOEMail))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierName",SqlDbType.NVarChar,101, Iif(Record.SupplierName= "" ,Convert.DBNull, Record.SupplierName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentTitle",SqlDbType.NVarChar,101, Iif(Record.DocumentTitle= "" ,Convert.DBNull, Record.DocumentTitle))
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
    Public Shared Function erpDCRDetailDelete(ByVal Record As SIS.ERP.erpDCRDetail) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpDCRDetailDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DCRNo",SqlDbType.NVarChar,Record.DCRNo.ToString.Length, Record.DCRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DocumentID",SqlDbType.NVarChar,Record.DocumentID.ToString.Length, Record.DocumentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RevisionNo",SqlDbType.NVarChar,Record.RevisionNo.ToString.Length, Record.RevisionNo)
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
      On Error Resume Next
      _DCRNo = Ctype(Reader("DCRNo"),String)
      _DocumentID = Ctype(Reader("DocumentID"),String)
      _RevisionNo = Ctype(Reader("RevisionNo"),String)
      If Convert.IsDBNull(Reader("IndentNo")) Then
        _IndentNo = String.Empty
      Else
        _IndentNo = Ctype(Reader("IndentNo"), String)
      End If
      If Convert.IsDBNull(Reader("IndentLine")) Then
        _IndentLine = String.Empty
      Else
        _IndentLine = Ctype(Reader("IndentLine"), String)
      End If
      If Convert.IsDBNull(Reader("LotItem")) Then
        _LotItem = String.Empty
      Else
        _LotItem = Ctype(Reader("LotItem"), String)
      End If
      If Convert.IsDBNull(Reader("ItemDescription")) Then
        _ItemDescription = String.Empty
      Else
        _ItemDescription = Ctype(Reader("ItemDescription"), String)
      End If
      If Convert.IsDBNull(Reader("IndenterID")) Then
        _IndenterID = String.Empty
      Else
        _IndenterID = Ctype(Reader("IndenterID"), String)
      End If
      If Convert.IsDBNull(Reader("BuyerID")) Then
        _BuyerID = String.Empty
      Else
        _BuyerID = Ctype(Reader("BuyerID"), String)
      End If
      If Convert.IsDBNull(Reader("OrderNo")) Then
        _OrderNo = String.Empty
      Else
        _OrderNo = Ctype(Reader("OrderNo"), String)
      End If
      If Convert.IsDBNull(Reader("OrderLine")) Then
        _OrderLine = String.Empty
      Else
        _OrderLine = Ctype(Reader("OrderLine"), String)
      End If
      If Convert.IsDBNull(Reader("SupplierID")) Then
        _SupplierID = String.Empty
      Else
        _SupplierID = Ctype(Reader("SupplierID"), String)
      End If
      If Convert.IsDBNull(Reader("BuyerIDinPO")) Then
        _BuyerIDinPO = String.Empty
      Else
        _BuyerIDinPO = Ctype(Reader("BuyerIDinPO"), String)
      End If
      If Convert.IsDBNull(Reader("IndenterName")) Then
        _IndenterName = String.Empty
      Else
        _IndenterName = Ctype(Reader("IndenterName"), String)
      End If
      If Convert.IsDBNull(Reader("IndenterEMail")) Then
        _IndenterEMail = String.Empty
      Else
        _IndenterEMail = Ctype(Reader("IndenterEMail"), String)
      End If
      If Convert.IsDBNull(Reader("BuyerName")) Then
        _BuyerName = String.Empty
      Else
        _BuyerName = Ctype(Reader("BuyerName"), String)
      End If
      If Convert.IsDBNull(Reader("BuyerEMail")) Then
        _BuyerEMail = String.Empty
      Else
        _BuyerEMail = Ctype(Reader("BuyerEMail"), String)
      End If
      If Convert.IsDBNull(Reader("BuyerIDinPOName")) Then
        _BuyerIDinPOName = String.Empty
      Else
        _BuyerIDinPOName = Ctype(Reader("BuyerIDinPOName"), String)
      End If
      If Convert.IsDBNull(Reader("BuyerIDinPOEMail")) Then
        _BuyerIDinPOEMail = String.Empty
      Else
        _BuyerIDinPOEMail = Ctype(Reader("BuyerIDinPOEMail"), String)
      End If
      If Convert.IsDBNull(Reader("SupplierName")) Then
        _SupplierName = String.Empty
      Else
        _SupplierName = Ctype(Reader("SupplierName"), String)
      End If
      If Convert.IsDBNull(Reader("DocumentTitle")) Then
        _DocumentTitle = String.Empty
      Else
        _DocumentTitle = Ctype(Reader("DocumentTitle"), String)
      End If
      If Convert.IsDBNull(Reader("ERP_DCRHeader1_DCRDescription")) Then
        _ERP_DCRHeader1_DCRDescription = String.Empty
      Else
        _ERP_DCRHeader1_DCRDescription = Ctype(Reader("ERP_DCRHeader1_DCRDescription"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
