Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.EITL
  <DataObject()> _
  Partial Public Class eitlPODocumentList
    Private Shared _RecordCount As Integer
    Private _SerialNo As Int32 = 0
    Private _DocumentLineNo As Int32 = 0
    Private _DocumentID As String = ""
    Private _RevisionNo As String = ""
    Private _Description As String = ""
    Private _ReadyToDespatch As Boolean = False
    Private _Despatched As Boolean = False
    Private _DespatchDate As String = ""
    Private _EITL_POList1_PONumber As String = ""
    Private _FK_EITL_PODocumentList_SerialNo As SIS.EITL.eitlPOList = Nothing
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
    Public Property DocumentLineNo() As Int32
      Get
        Return _DocumentLineNo
      End Get
      Set(ByVal value As Int32)
        _DocumentLineNo = value
      End Set
    End Property
    Public Property DocumentID() As String
      Get
        Return _DocumentID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _DocumentID = ""
				 Else
					 _DocumentID = value
			   End If
      End Set
    End Property
    Public Property RevisionNo() As String
      Get
        Return _RevisionNo
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _RevisionNo = ""
				 Else
					 _RevisionNo = value
			   End If
      End Set
    End Property
    Public Property Description() As String
      Get
        Return _Description
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Description = ""
				 Else
					 _Description = value
			   End If
      End Set
    End Property
    Public Property ReadyToDespatch() As Boolean
      Get
        Return _ReadyToDespatch
      End Get
      Set(ByVal value As Boolean)
        _ReadyToDespatch = value
      End Set
    End Property
    Public Property Despatched() As Boolean
      Get
        Return _Despatched
      End Get
      Set(ByVal value As Boolean)
        _Despatched = value
      End Set
    End Property
    Public Property DespatchDate() As String
      Get
        If Not _DespatchDate = String.Empty Then
          Return Convert.ToDateTime(_DespatchDate).ToString("dd/MM/yyyy")
        End If
        Return _DespatchDate
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _DespatchDate = ""
				 Else
					 _DespatchDate = value
			   End If
      End Set
    End Property
    Public Property EITL_POList1_PONumber() As String
      Get
        Return _EITL_POList1_PONumber
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _EITL_POList1_PONumber = ""
				 Else
					 _EITL_POList1_PONumber = value
			   End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _DocumentID.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _SerialNo & "|" & _DocumentLineNo
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
    Public Class PKeitlPODocumentList
			Private _SerialNo As Int32 = 0
			Private _DocumentLineNo As Int32 = 0
			Public Property SerialNo() As Int32
				Get
					Return _SerialNo
				End Get
				Set(ByVal value As Int32)
					_SerialNo = value
				End Set
			End Property
			Public Property DocumentLineNo() As Int32
				Get
					Return _DocumentLineNo
				End Get
				Set(ByVal value As Int32)
					_DocumentLineNo = value
				End Set
			End Property
    End Class
    Public ReadOnly Property FK_EITL_PODocumentList_SerialNo() As SIS.EITL.eitlPOList
      Get
        If _FK_EITL_PODocumentList_SerialNo Is Nothing Then
          _FK_EITL_PODocumentList_SerialNo = SIS.EITL.eitlPOList.eitlPOListGetByID(_SerialNo)
        End If
        Return _FK_EITL_PODocumentList_SerialNo
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlPODocumentListSelectList(ByVal OrderBy As String) As List(Of SIS.EITL.eitlPODocumentList)
      Dim Results As List(Of SIS.EITL.eitlPODocumentList) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlPODocumentListSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.EITL.eitlPODocumentList)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.EITL.eitlPODocumentList(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlPODocumentListGetNewRecord() As SIS.EITL.eitlPODocumentList
      Return New SIS.EITL.eitlPODocumentList()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlPODocumentListGetByID(ByVal SerialNo As Int32, ByVal DocumentLineNo As Int32) As SIS.EITL.eitlPODocumentList
      Dim Results As SIS.EITL.eitlPODocumentList = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlPODocumentListSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentLineNo",SqlDbType.Int,DocumentLineNo.ToString.Length, DocumentLineNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.EITL.eitlPODocumentList(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlPODocumentListSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32) As List(Of SIS.EITL.eitlPODocumentList)
      Dim Results As List(Of SIS.EITL.eitlPODocumentList) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "DocumentLineNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "speitlPODocumentListSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "speitlPODocumentListSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.EITL.eitlPODocumentList)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.EITL.eitlPODocumentList(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function eitlPODocumentListSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function eitlPODocumentListGetByID(ByVal SerialNo As Int32, ByVal DocumentLineNo As Int32, ByVal Filter_SerialNo As Int32) As SIS.EITL.eitlPODocumentList
      Return eitlPODocumentListGetByID(SerialNo, DocumentLineNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function eitlPODocumentListInsert(ByVal Record As SIS.EITL.eitlPODocumentList) As SIS.EITL.eitlPODocumentList
      Dim _Rec As SIS.EITL.eitlPODocumentList = SIS.EITL.eitlPODocumentList.eitlPODocumentListGetNewRecord()
      With _Rec
        .SerialNo = Record.SerialNo
        .DocumentID = Record.DocumentID
        .RevisionNo = Record.RevisionNo
        .Description = Record.Description
        .ReadyToDespatch = Record.ReadyToDespatch
      End With
      Return SIS.EITL.eitlPODocumentList.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.EITL.eitlPODocumentList) As SIS.EITL.eitlPODocumentList
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlPODocumentListInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentID",SqlDbType.NVarChar,51, Iif(Record.DocumentID= "" ,Convert.DBNull, Record.DocumentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RevisionNo",SqlDbType.NVarChar,4, Iif(Record.RevisionNo= "" ,Convert.DBNull, Record.RevisionNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,201, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReadyToDespatch",SqlDbType.Bit,3, Record.ReadyToDespatch)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Despatched",SqlDbType.Bit,3, Record.Despatched)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DespatchDate",SqlDbType.DateTime,21, Iif(Record.DespatchDate= "" ,Convert.DBNull, Record.DespatchDate))
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_DocumentLineNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_DocumentLineNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
          Record.DocumentLineNo = Cmd.Parameters("@Return_DocumentLineNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function eitlPODocumentListUpdate(ByVal Record As SIS.EITL.eitlPODocumentList) As SIS.EITL.eitlPODocumentList
      Dim _Rec As SIS.EITL.eitlPODocumentList = SIS.EITL.eitlPODocumentList.eitlPODocumentListGetByID(Record.SerialNo, Record.DocumentLineNo)
      With _Rec
        .DocumentID = Record.DocumentID
        .RevisionNo = Record.RevisionNo
        .Description = Record.Description
        .ReadyToDespatch = Record.ReadyToDespatch
      End With
      Return SIS.EITL.eitlPODocumentList.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.EITL.eitlPODocumentList) As SIS.EITL.eitlPODocumentList
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlPODocumentListUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DocumentLineNo",SqlDbType.Int,11, Record.DocumentLineNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentID",SqlDbType.NVarChar,51, Iif(Record.DocumentID= "" ,Convert.DBNull, Record.DocumentID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RevisionNo",SqlDbType.NVarChar,4, Iif(Record.RevisionNo= "" ,Convert.DBNull, Record.RevisionNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,201, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReadyToDespatch",SqlDbType.Bit,3, Record.ReadyToDespatch)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Despatched",SqlDbType.Bit,3, Record.Despatched)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DespatchDate",SqlDbType.DateTime,21, Iif(Record.DespatchDate= "" ,Convert.DBNull, Record.DespatchDate))
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
    Public Shared Function eitlPODocumentListDelete(ByVal Record As SIS.EITL.eitlPODocumentList) As Int32
      Dim _Result as Integer = 0
      'Delete Linked Files
      Dim oFiles As List(Of SIS.EITL.eitlPODocumentFile) = SIS.EITL.eitlPODocumentFile.eitlPODocumentFileSelectList(0, 9999, "", False, "", Record.SerialNo, Record.DocumentLineNo)
      For Each fil As SIS.EITL.eitlPODocumentFile In oFiles
        SIS.EITL.eitlPODocumentFile.eitlPODocumentFileDelete(fil)
      Next
      'Delete Linked Items
      Dim oItems As List(Of SIS.EITL.eitlPOItemList) = SIS.EITL.eitlPOItemList.GetItemListByPODocument(Record.SerialNo, Record.DocumentLineNo)
      For Each itm As SIS.EITL.eitlPOItemList In oItems
        SIS.EITL.eitlPOItemList.eitlPOItemListDelete(itm)
      Next
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "speitlPODocumentListDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo", SqlDbType.Int, Record.SerialNo.ToString.Length, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DocumentLineNo", SqlDbType.Int, Record.DocumentLineNo.ToString.Length, Record.DocumentLineNo)
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
'		Autocomplete Method
		Public Shared Function SelecteitlPODocumentListAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "speitlPODocumentListAutoCompleteList"
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
            Dim Tmp As SIS.EITL.eitlPODocumentList = New SIS.EITL.eitlPODocumentList(Reader)
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results.ToArray
		End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _SerialNo = Ctype(Reader("SerialNo"),Int32)
      _DocumentLineNo = Ctype(Reader("DocumentLineNo"),Int32)
      If Convert.IsDBNull(Reader("DocumentID")) Then
        _DocumentID = String.Empty
      Else
        _DocumentID = Ctype(Reader("DocumentID"), String)
      End If
      If Convert.IsDBNull(Reader("RevisionNo")) Then
        _RevisionNo = String.Empty
      Else
        _RevisionNo = Ctype(Reader("RevisionNo"), String)
      End If
      If Convert.IsDBNull(Reader("Description")) Then
        _Description = String.Empty
      Else
        _Description = Ctype(Reader("Description"), String)
      End If
      _ReadyToDespatch = Ctype(Reader("ReadyToDespatch"),Boolean)
      _Despatched = Ctype(Reader("Despatched"),Boolean)
      If Convert.IsDBNull(Reader("DespatchDate")) Then
        _DespatchDate = String.Empty
      Else
        _DespatchDate = Ctype(Reader("DespatchDate"), String)
      End If
      If Convert.IsDBNull(Reader("EITL_POList1_PONumber")) Then
        _EITL_POList1_PONumber = String.Empty
      Else
        _EITL_POList1_PONumber = Ctype(Reader("EITL_POList1_PONumber"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
