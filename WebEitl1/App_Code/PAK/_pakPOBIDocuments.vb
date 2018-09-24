Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakPOBIDocuments
    Private Shared _RecordCount As Integer
    Private _SerialNo As Int32 = 0
    Private _BOMNo As Int32 = 0
    Private _ItemNo As Int32 = 0
    Private _DocNo As Int32 = 0
    Private _DocumentID As String = ""
    Private _DocumentRevision As String = ""
    Private _DocumentName As String = ""
    Private _FileName As String = ""
    Private _DiskFile As String = ""
    Private _CreatedBySupplier As Boolean = False
    Private _PAK_PO1_PODescription As String = ""
    Private _PAK_POBItems2_ItemDescription As String = ""
    Private _PAK_POBOM3_ItemDescription As String = ""
    Private _FK_PAK_POBIDocuments_SerialNo As SIS.PAK.pakPO = Nothing
    Private _FK_PAK_POBIDocuments_ItemNo As SIS.PAK.pakPOBItems = Nothing
    Private _FK_PAK_POBIDocuments_BOMNo As SIS.PAK.pakPOBOM = Nothing
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
    Public Property BOMNo() As Int32
      Get
        Return _BOMNo
      End Get
      Set(ByVal value As Int32)
        _BOMNo = value
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
    Public Property DocNo() As Int32
      Get
        Return _DocNo
      End Get
      Set(ByVal value As Int32)
        _DocNo = value
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
    Public Property DocumentRevision() As String
      Get
        Return _DocumentRevision
      End Get
      Set(ByVal value As String)
        _DocumentRevision = value
      End Set
    End Property
    Public Property DocumentName() As String
      Get
        Return _DocumentName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DocumentName = ""
         Else
           _DocumentName = value
         End If
      End Set
    End Property
    Public Property FileName() As String
      Get
        Return _FileName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _FileName = ""
         Else
           _FileName = value
         End If
      End Set
    End Property
    Public Property DiskFile() As String
      Get
        Return _DiskFile
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DiskFile = ""
         Else
           _DiskFile = value
         End If
      End Set
    End Property
    Public Property CreatedBySupplier() As Boolean
      Get
        Return _CreatedBySupplier
      End Get
      Set(ByVal value As Boolean)
        _CreatedBySupplier = value
      End Set
    End Property
    Public Property PAK_PO1_PODescription() As String
      Get
        Return _PAK_PO1_PODescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_PO1_PODescription = ""
         Else
           _PAK_PO1_PODescription = value
         End If
      End Set
    End Property
    Public Property PAK_POBItems2_ItemDescription() As String
      Get
        Return _PAK_POBItems2_ItemDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_POBItems2_ItemDescription = ""
         Else
           _PAK_POBItems2_ItemDescription = value
         End If
      End Set
    End Property
    Public Property PAK_POBOM3_ItemDescription() As String
      Get
        Return _PAK_POBOM3_ItemDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_POBOM3_ItemDescription = ""
         Else
           _PAK_POBOM3_ItemDescription = value
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
        Return _SerialNo & "|" & _BOMNo & "|" & _ItemNo & "|" & _DocNo
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
    Public Class PKpakPOBIDocuments
      Private _SerialNo As Int32 = 0
      Private _BOMNo As Int32 = 0
      Private _ItemNo As Int32 = 0
      Private _DocNo As Int32 = 0
      Public Property SerialNo() As Int32
        Get
          Return _SerialNo
        End Get
        Set(ByVal value As Int32)
          _SerialNo = value
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
      Public Property ItemNo() As Int32
        Get
          Return _ItemNo
        End Get
        Set(ByVal value As Int32)
          _ItemNo = value
        End Set
      End Property
      Public Property DocNo() As Int32
        Get
          Return _DocNo
        End Get
        Set(ByVal value As Int32)
          _DocNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PAK_POBIDocuments_SerialNo() As SIS.PAK.pakPO
      Get
        If _FK_PAK_POBIDocuments_SerialNo Is Nothing Then
          _FK_PAK_POBIDocuments_SerialNo = SIS.PAK.pakPO.pakPOGetByID(_SerialNo)
        End If
        Return _FK_PAK_POBIDocuments_SerialNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_POBIDocuments_ItemNo() As SIS.PAK.pakPOBItems
      Get
        If _FK_PAK_POBIDocuments_ItemNo Is Nothing Then
          _FK_PAK_POBIDocuments_ItemNo = SIS.PAK.pakPOBItems.pakPOBItemsGetByID(_SerialNo, _BOMNo, _ItemNo)
        End If
        Return _FK_PAK_POBIDocuments_ItemNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_POBIDocuments_BOMNo() As SIS.PAK.pakPOBOM
      Get
        If _FK_PAK_POBIDocuments_BOMNo Is Nothing Then
          _FK_PAK_POBIDocuments_BOMNo = SIS.PAK.pakPOBOM.pakPOBOMGetByID(_SerialNo, _BOMNo)
        End If
        Return _FK_PAK_POBIDocuments_BOMNo
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakPOBIDocumentsSelectList(ByVal OrderBy As String) As List(Of SIS.PAK.pakPOBIDocuments)
      Dim Results As List(Of SIS.PAK.pakPOBIDocuments) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakPOBIDocumentsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakPOBIDocuments)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakPOBIDocuments(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakPOBIDocumentsGetNewRecord() As SIS.PAK.pakPOBIDocuments
      Return New SIS.PAK.pakPOBIDocuments()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakPOBIDocumentsGetByID(ByVal SerialNo As Int32, ByVal BOMNo As Int32, ByVal ItemNo As Int32, ByVal DocNo As Int32) As SIS.PAK.pakPOBIDocuments
      Dim Results As SIS.PAK.pakPOBIDocuments = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakPOBIDocumentsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BOMNo",SqlDbType.Int,BOMNo.ToString.Length, BOMNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo",SqlDbType.Int,ItemNo.ToString.Length, ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocNo",SqlDbType.Int,DocNo.ToString.Length, DocNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakPOBIDocuments(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakPOBIDocumentsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal BOMNo As Int32, ByVal ItemNo As Int32) As List(Of SIS.PAK.pakPOBIDocuments)
      Dim Results As List(Of SIS.PAK.pakPOBIDocuments) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakPOBIDocumentsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakPOBIDocumentsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BOMNo",SqlDbType.Int,10, IIf(BOMNo = Nothing, 0,BOMNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ItemNo",SqlDbType.Int,10, IIf(ItemNo = Nothing, 0,ItemNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakPOBIDocuments)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakPOBIDocuments(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakPOBIDocumentsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal BOMNo As Int32, ByVal ItemNo As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakPOBIDocumentsGetByID(ByVal SerialNo As Int32, ByVal BOMNo As Int32, ByVal ItemNo As Int32, ByVal DocNo As Int32, ByVal Filter_SerialNo As Int32, ByVal Filter_BOMNo As Int32, ByVal Filter_ItemNo As Int32) As SIS.PAK.pakPOBIDocuments
      Return pakPOBIDocumentsGetByID(SerialNo, BOMNo, ItemNo, DocNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function pakPOBIDocumentsInsert(ByVal Record As SIS.PAK.pakPOBIDocuments) As SIS.PAK.pakPOBIDocuments
      Dim _Rec As SIS.PAK.pakPOBIDocuments = SIS.PAK.pakPOBIDocuments.pakPOBIDocumentsGetNewRecord()
      With _Rec
        .SerialNo = Record.SerialNo
        .BOMNo = Record.BOMNo
        .ItemNo = Record.ItemNo
        .DocumentID = Record.DocumentID
        .DocumentRevision = Record.DocumentRevision
        .DocumentName = Record.DocumentName
        .FileName = Record.FileName
        .DiskFile = Record.DiskFile
        .CreatedBySupplier = Record.CreatedBySupplier
      End With
      Return SIS.PAK.pakPOBIDocuments.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PAK.pakPOBIDocuments) As SIS.PAK.pakPOBIDocuments
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakPOBIDocumentsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BOMNo",SqlDbType.Int,11, Record.BOMNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo",SqlDbType.Int,11, Record.ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentID",SqlDbType.NVarChar,51, Record.DocumentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentRevision",SqlDbType.NVarChar,11, Record.DocumentRevision)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentName",SqlDbType.NVarChar,101, Iif(Record.DocumentName= "" ,Convert.DBNull, Record.DocumentName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileName",SqlDbType.NVarChar,251, Iif(Record.FileName= "" ,Convert.DBNull, Record.FileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DiskFile",SqlDbType.NVarChar,251, Iif(Record.DiskFile= "" ,Convert.DBNull, Record.DiskFile))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBySupplier",SqlDbType.Bit,3, Record.CreatedBySupplier)
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_BOMNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_BOMNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_ItemNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ItemNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_DocNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_DocNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
          Record.BOMNo = Cmd.Parameters("@Return_BOMNo").Value
          Record.ItemNo = Cmd.Parameters("@Return_ItemNo").Value
          Record.DocNo = Cmd.Parameters("@Return_DocNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakPOBIDocumentsUpdate(ByVal Record As SIS.PAK.pakPOBIDocuments) As SIS.PAK.pakPOBIDocuments
      Dim _Rec As SIS.PAK.pakPOBIDocuments = SIS.PAK.pakPOBIDocuments.pakPOBIDocumentsGetByID(Record.SerialNo, Record.BOMNo, Record.ItemNo, Record.DocNo)
      With _Rec
        .DocumentID = Record.DocumentID
        .DocumentRevision = Record.DocumentRevision
        .DocumentName = Record.DocumentName
        .FileName = Record.FileName
        .DiskFile = Record.DiskFile
        .CreatedBySupplier = Record.CreatedBySupplier
      End With
      Return SIS.PAK.pakPOBIDocuments.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PAK.pakPOBIDocuments) As SIS.PAK.pakPOBIDocuments
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakPOBIDocumentsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_BOMNo",SqlDbType.Int,11, Record.BOMNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ItemNo",SqlDbType.Int,11, Record.ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DocNo",SqlDbType.Int,11, Record.DocNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BOMNo",SqlDbType.Int,11, Record.BOMNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo",SqlDbType.Int,11, Record.ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentID",SqlDbType.NVarChar,51, Record.DocumentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentRevision",SqlDbType.NVarChar,11, Record.DocumentRevision)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentName",SqlDbType.NVarChar,101, Iif(Record.DocumentName= "" ,Convert.DBNull, Record.DocumentName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileName",SqlDbType.NVarChar,251, Iif(Record.FileName= "" ,Convert.DBNull, Record.FileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DiskFile",SqlDbType.NVarChar,251, Iif(Record.DiskFile= "" ,Convert.DBNull, Record.DiskFile))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBySupplier",SqlDbType.Bit,3, Record.CreatedBySupplier)
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
    Public Shared Function pakPOBIDocumentsDelete(ByVal Record As SIS.PAK.pakPOBIDocuments) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakPOBIDocumentsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,Record.SerialNo.ToString.Length, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_BOMNo",SqlDbType.Int,Record.BOMNo.ToString.Length, Record.BOMNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ItemNo",SqlDbType.Int,Record.ItemNo.ToString.Length, Record.ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DocNo",SqlDbType.Int,Record.DocNo.ToString.Length, Record.DocNo)
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
    Public Shared Function SelectpakPOBIDocumentsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakPOBIDocumentsAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),"" & "|" & "" & "|" & "" & "|" & ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.PAK.pakPOBIDocuments = New SIS.PAK.pakPOBIDocuments(Reader)
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
