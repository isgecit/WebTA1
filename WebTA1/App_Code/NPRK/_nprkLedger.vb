Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  <DataObject()> _
  Partial Public Class nprkLedger
    Private Shared _RecordCount As Integer
    Private _DocumentID As Int32 = 0
    Private _EmployeeID As Int32 = 0
    Private _PerkID As Int32 = 0
    Private _TranType As String = ""
    Private _TranDate As String = ""
    Private _FinYear As Int32 = 0
    Private _Value As Decimal = 0
    Private _UOM As String = ""
    Private _Amount As Decimal = 0
    Private _Remarks As String = ""
    Private _CreatedBy As Int32 = 0
    Private _ParentDocumentID As Int32 = 0
    Private _ApplicationID As Int32 = 0
    Private _PostedInBaaN As Boolean = False
    Private _PostedOn As String = ""
    Private _PostedBy As String = ""
    Private _BatchNo As String = ""
    Private _VoucherNo As String = ""
    Private _VoucherLineNo As String = ""
    Private _PRK_Employees1_EmployeeName As String = ""
    Private _PRK_Employees2_EmployeeName As String = ""
    Private _PRK_Employees3_EmployeeName As String = ""
    Private _PRK_FinYears4_Description As String = ""
    Private _PRK_Perks5_Description As String = ""
    Private _FK_PRK_Ledger_PRK_Employees As SIS.NPRK.nprkEmployees = Nothing
    Private _FK_PRK_Ledger_PRK_Employees1 As SIS.NPRK.nprkEmployees = Nothing
    Private _FK_PRK_Ledger_PRK_Employees2 As SIS.NPRK.nprkEmployees = Nothing
    Private _FK_PRK_Ledger_PRK_FinYears As SIS.NPRK.nprkFinYears = Nothing
    Private _FK_PRK_Ledger_PRK_Perks As SIS.NPRK.nprkPerks = Nothing
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
    Public Property DocumentID() As Int32
      Get
        Return _DocumentID
      End Get
      Set(ByVal value As Int32)
        _DocumentID = value
      End Set
    End Property
    Public Property EmployeeID() As Int32
      Get
        Return _EmployeeID
      End Get
      Set(ByVal value As Int32)
        _EmployeeID = value
      End Set
    End Property
    Public Property PerkID() As Int32
      Get
        Return _PerkID
      End Get
      Set(ByVal value As Int32)
        _PerkID = value
      End Set
    End Property
    Public Property TranType() As String
      Get
        Return _TranType
      End Get
      Set(ByVal value As String)
        _TranType = value
      End Set
    End Property
    Public Property TranDate() As String
      Get
        If Not _TranDate = String.Empty Then
          Return Convert.ToDateTime(_TranDate).ToString("dd/MM/yyyy")
        End If
        Return _TranDate
      End Get
      Set(ByVal value As String)
         _TranDate = value
      End Set
    End Property
    Public Property FinYear() As Int32
      Get
        Return _FinYear
      End Get
      Set(ByVal value As Int32)
        _FinYear = value
      End Set
    End Property
    Public Property Value() As Decimal
      Get
        Return _Value
      End Get
      Set(ByVal value As Decimal)
        _Value = value
      End Set
    End Property
    Public Property UOM() As String
      Get
        Return _UOM
      End Get
      Set(ByVal value As String)
        _UOM = value
      End Set
    End Property
    Public Property Amount() As Decimal
      Get
        Return _Amount
      End Get
      Set(ByVal value As Decimal)
        _Amount = value
      End Set
    End Property
    Public Property Remarks() As String
      Get
        Return _Remarks
      End Get
      Set(ByVal value As String)
        _Remarks = value
      End Set
    End Property
    Public Property CreatedBy() As Int32
      Get
        Return _CreatedBy
      End Get
      Set(ByVal value As Int32)
        _CreatedBy = value
      End Set
    End Property
    Public Property ParentDocumentID() As Int32
      Get
        Return _ParentDocumentID
      End Get
      Set(ByVal value As Int32)
        _ParentDocumentID = value
      End Set
    End Property
    Public Property ApplicationID() As Int32
      Get
        Return _ApplicationID
      End Get
      Set(ByVal value As Int32)
        _ApplicationID = value
      End Set
    End Property
    Public Property PostedInBaaN() As Boolean
      Get
        Return _PostedInBaaN
      End Get
      Set(ByVal value As Boolean)
        _PostedInBaaN = value
      End Set
    End Property
    Public Property PostedOn() As String
      Get
        If Not _PostedOn = String.Empty Then
          Return Convert.ToDateTime(_PostedOn).ToString("dd/MM/yyyy")
        End If
        Return _PostedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PostedOn = ""
         Else
           _PostedOn = value
         End If
      End Set
    End Property
    Public Property PostedBy() As String
      Get
        Return _PostedBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PostedBy = ""
         Else
           _PostedBy = value
         End If
      End Set
    End Property
    Public Property BatchNo() As String
      Get
        Return _BatchNo
      End Get
      Set(ByVal value As String)
        _BatchNo = value
      End Set
    End Property
    Public Property VoucherNo() As String
      Get
        Return _VoucherNo
      End Get
      Set(ByVal value As String)
        _VoucherNo = value
      End Set
    End Property
    Public Property VoucherLineNo() As String
      Get
        Return _VoucherLineNo
      End Get
      Set(ByVal value As String)
        _VoucherLineNo = value
      End Set
    End Property
    Public Property PRK_Employees1_EmployeeName() As String
      Get
        Return _PRK_Employees1_EmployeeName
      End Get
      Set(ByVal value As String)
        _PRK_Employees1_EmployeeName = value
      End Set
    End Property
    Public Property PRK_Employees2_EmployeeName() As String
      Get
        Return _PRK_Employees2_EmployeeName
      End Get
      Set(ByVal value As String)
        _PRK_Employees2_EmployeeName = value
      End Set
    End Property
    Public Property PRK_Employees3_EmployeeName() As String
      Get
        Return _PRK_Employees3_EmployeeName
      End Get
      Set(ByVal value As String)
        _PRK_Employees3_EmployeeName = value
      End Set
    End Property
    Public Property PRK_FinYears4_Description() As String
      Get
        Return _PRK_FinYears4_Description
      End Get
      Set(ByVal value As String)
        _PRK_FinYears4_Description = value
      End Set
    End Property
    Public Property PRK_Perks5_Description() As String
      Get
        Return _PRK_Perks5_Description
      End Get
      Set(ByVal value As String)
        _PRK_Perks5_Description = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _DocumentID
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
    Public Class PKnprkLedger
      Private _DocumentID As Int32 = 0
      Public Property DocumentID() As Int32
        Get
          Return _DocumentID
        End Get
        Set(ByVal value As Int32)
          _DocumentID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PRK_Ledger_PRK_Employees() As SIS.NPRK.nprkEmployees
      Get
        If _FK_PRK_Ledger_PRK_Employees Is Nothing Then
          _FK_PRK_Ledger_PRK_Employees = SIS.NPRK.nprkEmployees.nprkEmployeesGetByID(_EmployeeID)
        End If
        Return _FK_PRK_Ledger_PRK_Employees
      End Get
    End Property
    Public ReadOnly Property FK_PRK_Ledger_PRK_Employees1() As SIS.NPRK.nprkEmployees
      Get
        If _FK_PRK_Ledger_PRK_Employees1 Is Nothing Then
          _FK_PRK_Ledger_PRK_Employees1 = SIS.NPRK.nprkEmployees.nprkEmployeesGetByID(_CreatedBy)
        End If
        Return _FK_PRK_Ledger_PRK_Employees1
      End Get
    End Property
    Public ReadOnly Property FK_PRK_Ledger_PRK_Employees2() As SIS.NPRK.nprkEmployees
      Get
        If _FK_PRK_Ledger_PRK_Employees2 Is Nothing Then
          _FK_PRK_Ledger_PRK_Employees2 = SIS.NPRK.nprkEmployees.nprkEmployeesGetByID(_PostedBy)
        End If
        Return _FK_PRK_Ledger_PRK_Employees2
      End Get
    End Property
    Public ReadOnly Property FK_PRK_Ledger_PRK_FinYears() As SIS.NPRK.nprkFinYears
      Get
        If _FK_PRK_Ledger_PRK_FinYears Is Nothing Then
          _FK_PRK_Ledger_PRK_FinYears = SIS.NPRK.nprkFinYears.nprkFinYearsGetByID(_FinYear)
        End If
        Return _FK_PRK_Ledger_PRK_FinYears
      End Get
    End Property
    Public ReadOnly Property FK_PRK_Ledger_PRK_Perks() As SIS.NPRK.nprkPerks
      Get
        If _FK_PRK_Ledger_PRK_Perks Is Nothing Then
          _FK_PRK_Ledger_PRK_Perks = SIS.NPRK.nprkPerks.nprkPerksGetByID(_PerkID)
        End If
        Return _FK_PRK_Ledger_PRK_Perks
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkLedgerGetNewRecord() As SIS.NPRK.nprkLedger
      Return New SIS.NPRK.nprkLedger()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkLedgerGetByID(ByVal DocumentID As Int32) As SIS.NPRK.nprkLedger
      Dim Results As SIS.NPRK.nprkLedger = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkLedgerSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentID",SqlDbType.Int,DocumentID.ToString.Length, DocumentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.NPRK.nprkLedger(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkLedgerSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.NPRK.nprkLedger)
      Dim Results As List(Of SIS.NPRK.nprkLedger) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprkLedgerSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprkLedgerSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkLedger)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkLedger(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function nprkLedgerSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function nprkLedgerInsert(ByVal Record As SIS.NPRK.nprkLedger) As SIS.NPRK.nprkLedger
      Dim _Rec As SIS.NPRK.nprkLedger = SIS.NPRK.nprkLedger.nprkLedgerGetNewRecord()
      With _Rec
        .EmployeeID = Record.EmployeeID
        .PerkID = Record.PerkID
        .TranType = Record.TranType
        .TranDate = Record.TranDate
        .FinYear = Record.FinYear
        .Value = Record.Value
        .UOM = Record.UOM
        .Amount = Record.Amount
        .Remarks = Record.Remarks
        .CreatedBy = Record.CreatedBy
        .ParentDocumentID = Record.ParentDocumentID
        .ApplicationID = Record.ApplicationID
        .PostedInBaaN = Record.PostedInBaaN
        .PostedOn = Record.PostedOn
        .PostedBy = Record.PostedBy
        .BatchNo = Record.BatchNo
        .VoucherNo = Record.VoucherNo
        .VoucherLineNo = Record.VoucherLineNo
      End With
      Return SIS.NPRK.nprkLedger.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.NPRK.nprkLedger) As SIS.NPRK.nprkLedger
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkLedgerInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.Int,11, Record.EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PerkID",SqlDbType.Int,11, Record.PerkID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranType",SqlDbType.NVarChar,4, Record.TranType)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranDate",SqlDbType.DateTime,21, Record.TranDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Value",SqlDbType.Decimal,13, Record.Value)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOM",SqlDbType.NVarChar,6, Record.UOM)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Amount",SqlDbType.Decimal,13, Record.Amount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,501, Record.Remarks)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.Int,11, Record.CreatedBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentDocumentID",SqlDbType.Int,11, Record.ParentDocumentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID",SqlDbType.Int,11, Record.ApplicationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedInBaaN",SqlDbType.Bit,3, Record.PostedInBaaN)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedOn",SqlDbType.DateTime,21, Iif(Record.PostedOn= "" ,Convert.DBNull, Record.PostedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedBy",SqlDbType.Int,11, Iif(Record.PostedBy= "" ,Convert.DBNull, Record.PostedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BatchNo",SqlDbType.NVarChar,7, Record.BatchNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VoucherNo",SqlDbType.NVarChar,9, Record.VoucherNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VoucherLineNo",SqlDbType.NVarChar,11, Record.VoucherLineNo)
          Cmd.Parameters.Add("@Return_DocumentID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_DocumentID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.DocumentID = Cmd.Parameters("@Return_DocumentID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function nprkLedgerUpdate(ByVal Record As SIS.NPRK.nprkLedger) As SIS.NPRK.nprkLedger
      Dim _Rec As SIS.NPRK.nprkLedger = SIS.NPRK.nprkLedger.nprkLedgerGetByID(Record.DocumentID)
      With _Rec
        .EmployeeID = Record.EmployeeID
        .PerkID = Record.PerkID
        .TranType = Record.TranType
        .TranDate = Record.TranDate
        .FinYear = Record.FinYear
        .Value = Record.Value
        .UOM = Record.UOM
        .Amount = Record.Amount
        .Remarks = Record.Remarks
        .CreatedBy = Record.CreatedBy
        .ParentDocumentID = Record.ParentDocumentID
        .ApplicationID = Record.ApplicationID
        .PostedInBaaN = Record.PostedInBaaN
        .PostedOn = Record.PostedOn
        .PostedBy = Record.PostedBy
        .BatchNo = Record.BatchNo
        .VoucherNo = Record.VoucherNo
        .VoucherLineNo = Record.VoucherLineNo
      End With
      Return SIS.NPRK.nprkLedger.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.NPRK.nprkLedger) As SIS.NPRK.nprkLedger
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkLedgerUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DocumentID",SqlDbType.Int,11, Record.DocumentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID",SqlDbType.Int,11, Record.EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PerkID",SqlDbType.Int,11, Record.PerkID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranType",SqlDbType.NVarChar,4, Record.TranType)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TranDate",SqlDbType.DateTime,21, Record.TranDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,11, Record.FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Value",SqlDbType.Decimal,13, Record.Value)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOM",SqlDbType.NVarChar,6, Record.UOM)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Amount",SqlDbType.Decimal,13, Record.Amount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,501, Record.Remarks)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.Int,11, Record.CreatedBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentDocumentID",SqlDbType.Int,11, Record.ParentDocumentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID",SqlDbType.Int,11, Record.ApplicationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedInBaaN",SqlDbType.Bit,3, Record.PostedInBaaN)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedOn",SqlDbType.DateTime,21, Iif(Record.PostedOn= "" ,Convert.DBNull, Record.PostedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PostedBy",SqlDbType.Int,11, Iif(Record.PostedBy= "" ,Convert.DBNull, Record.PostedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BatchNo",SqlDbType.NVarChar,7, Record.BatchNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VoucherNo",SqlDbType.NVarChar,9, Record.VoucherNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VoucherLineNo",SqlDbType.NVarChar,11, Record.VoucherLineNo)
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
    Public Shared Function nprkLedgerDelete(ByVal Record As SIS.NPRK.nprkLedger) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkLedgerDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_DocumentID",SqlDbType.Int,Record.DocumentID.ToString.Length, Record.DocumentID)
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
