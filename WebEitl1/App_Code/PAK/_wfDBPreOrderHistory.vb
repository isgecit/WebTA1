Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.WFDB
  <DataObject()> _
  Partial Public Class wfDBPreOrderHistory
    Private Shared _RecordCount As Integer
    Private _WFID As Int32 = 0
    Private _Project As String = ""
    Private _Element As String = ""
    Private _SpecificationNo As String = ""
    Private _Buyer As String = ""
    Private _SupplierName As String = ""
    Private _Supplier As String = ""
    Private _Notes As String = ""
    Private _DateTime As String = ""
    Private _UserId As String = ""
    Private _Parent_WFID As String = ""
    Private _WFID_SlNo As Int32 = 0
    Private _WF_Status As String = ""
    Private _WF_HistoryID As Int32 = 0
    Private _aspnet_Users3_UserFullName As String = ""
    Private _aspnet_Users2_UserFullName As String = ""
    Private _FK_WF1_PreOrder_History_UserId As SIS.QCM.qcmUsers = Nothing
    Private _FK_WF1_PreOrder_History_Buyer As SIS.QCM.qcmUsers = Nothing
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
    Public Property WFID() As Int32
      Get
        Return _WFID
      End Get
      Set(ByVal value As Int32)
        _WFID = value
      End Set
    End Property
    Public Property Project() As String
      Get
        Return _Project
      End Get
      Set(ByVal value As String)
        _Project = value
      End Set
    End Property
    Public Property Element() As String
      Get
        Return _Element
      End Get
      Set(ByVal value As String)
        _Element = value
      End Set
    End Property
    Public Property SpecificationNo() As String
      Get
        Return _SpecificationNo
      End Get
      Set(ByVal value As String)
        _SpecificationNo = value
      End Set
    End Property
    Public Property Buyer() As String
      Get
        Return _Buyer
      End Get
      Set(ByVal value As String)
        _Buyer = value
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
    Public Property Supplier() As String
      Get
        Return _Supplier
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Supplier = ""
         Else
           _Supplier = value
         End If
      End Set
    End Property
    Public Property Notes() As String
      Get
        Return _Notes
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Notes = ""
         Else
           _Notes = value
         End If
      End Set
    End Property
    Public Property DateTime() As String
      Get
        If Not _DateTime = String.Empty Then
          Return Convert.ToDateTime(_DateTime).ToString("dd/MM/yyyy")
        End If
        Return _DateTime
      End Get
      Set(ByVal value As String)
         _DateTime = value
      End Set
    End Property
    Public Property UserId() As String
      Get
        Return _UserId
      End Get
      Set(ByVal value As String)
        _UserId = value
      End Set
    End Property
    Public Property Parent_WFID() As String
      Get
        Return _Parent_WFID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Parent_WFID = ""
         Else
           _Parent_WFID = value
         End If
      End Set
    End Property
    Public Property WFID_SlNo() As Int32
      Get
        Return _WFID_SlNo
      End Get
      Set(ByVal value As Int32)
        _WFID_SlNo = value
      End Set
    End Property
    Public Property WF_Status() As String
      Get
        Return _WF_Status
      End Get
      Set(ByVal value As String)
        _WF_Status = value
      End Set
    End Property
    Public Property WF_HistoryID() As Int32
      Get
        Return _WF_HistoryID
      End Get
      Set(ByVal value As Int32)
        _WF_HistoryID = value
      End Set
    End Property
    Public Property aspnet_Users3_UserFullName() As String
      Get
        Return _aspnet_Users3_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users3_UserFullName = value
      End Set
    End Property
    Public Property aspnet_Users2_UserFullName() As String
      Get
        Return _aspnet_Users2_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users2_UserFullName = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _WFID
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
    Public Class PKwfDBPreOrderHistory
      Private _WFID As Int32 = 0
      Public Property WFID() As Int32
        Get
          Return _WFID
        End Get
        Set(ByVal value As Int32)
          _WFID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_WF1_PreOrder_History_UserId() As SIS.QCM.qcmUsers
      Get
        If _FK_WF1_PreOrder_History_UserId Is Nothing Then
          _FK_WF1_PreOrder_History_UserId = SIS.QCM.qcmUsers.qcmUsersGetByID(_UserId)
        End If
        Return _FK_WF1_PreOrder_History_UserId
      End Get
    End Property
    Public ReadOnly Property FK_WF1_PreOrder_History_Buyer() As SIS.QCM.qcmUsers
      Get
        If _FK_WF1_PreOrder_History_Buyer Is Nothing Then
          _FK_WF1_PreOrder_History_Buyer = SIS.QCM.qcmUsers.qcmUsersGetByID(_Buyer)
        End If
        Return _FK_WF1_PreOrder_History_Buyer
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfDBPreOrderHistoryGetNewRecord() As SIS.WFDB.wfDBPreOrderHistory
      Return New SIS.WFDB.wfDBPreOrderHistory()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfDBPreOrderHistoryGetByID(ByVal WFID As Int32) As SIS.WFDB.wfDBPreOrderHistory
      Dim Results As SIS.WFDB.wfDBPreOrderHistory = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDBPreOrderHistorySelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WFID",SqlDbType.Int,WFID.ToString.Length, WFID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.WFDB.wfDBPreOrderHistory(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function wfDBPreOrderHistorySelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.WFDB.wfDBPreOrderHistory)
      Dim Results As List(Of SIS.WFDB.wfDBPreOrderHistory) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spwfDBPreOrderHistorySelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spwfDBPreOrderHistorySelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.WFDB.wfDBPreOrderHistory)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.WFDB.wfDBPreOrderHistory(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function wfDBPreOrderHistorySelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function wfDBPreOrderHistoryInsert(ByVal Record As SIS.WFDB.wfDBPreOrderHistory) As SIS.WFDB.wfDBPreOrderHistory
      Dim _Rec As SIS.WFDB.wfDBPreOrderHistory = SIS.WFDB.wfDBPreOrderHistory.wfDBPreOrderHistoryGetNewRecord()
      With _Rec
        .WFID = Record.WFID
        .Project = Record.Project
        .Element = Record.Element
        .SpecificationNo = Record.SpecificationNo
        .Buyer = Record.Buyer
        .SupplierName = Record.SupplierName
        .Supplier = Record.Supplier
        .Notes = Record.Notes
        .DateTime = Record.DateTime
        .UserId = Record.UserId
        .Parent_WFID = Record.Parent_WFID
        .WFID_SlNo = Record.WFID_SlNo
        .WF_Status = Record.WF_Status
        .WF_HistoryID = Record.WF_HistoryID
      End With
      Return SIS.WFDB.wfDBPreOrderHistory.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.WFDB.wfDBPreOrderHistory) As SIS.WFDB.wfDBPreOrderHistory
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDBPreOrderHistoryInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WFID",SqlDbType.Int,11, Record.WFID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Project",SqlDbType.VarChar,51, Record.Project)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Element",SqlDbType.VarChar,51, Record.Element)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SpecificationNo",SqlDbType.VarChar,101, Record.SpecificationNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Buyer",SqlDbType.VarChar,9, Record.Buyer)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierName",SqlDbType.VarChar,101, Iif(Record.SupplierName= "" ,Convert.DBNull, Record.SupplierName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Supplier",SqlDbType.VarChar,51, Iif(Record.Supplier= "" ,Convert.DBNull, Record.Supplier))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Notes",SqlDbType.VarChar,4001, Iif(Record.Notes= "" ,Convert.DBNull, Record.Notes))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DateTime",SqlDbType.DateTime,21, Record.DateTime)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserId",SqlDbType.VarChar,9, Record.UserId)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Parent_WFID",SqlDbType.Int,11, Iif(Record.Parent_WFID= "" ,Convert.DBNull, Record.Parent_WFID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WFID_SlNo",SqlDbType.Int,11, Record.WFID_SlNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WF_Status",SqlDbType.VarChar,101, Record.WF_Status)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WF_HistoryID",SqlDbType.Int,11, Record.WF_HistoryID)
          Cmd.Parameters.Add("@Return_WFID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_WFID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.WFID = Cmd.Parameters("@Return_WFID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function wfDBPreOrderHistoryUpdate(ByVal Record As SIS.WFDB.wfDBPreOrderHistory) As SIS.WFDB.wfDBPreOrderHistory
      Dim _Rec As SIS.WFDB.wfDBPreOrderHistory = SIS.WFDB.wfDBPreOrderHistory.UZ_wfDBPreOrderHistoryGetByID(Record.WFID)
      With _Rec
        .Project = Record.Project
        .Element = Record.Element
        .SpecificationNo = Record.SpecificationNo
        .Buyer = Record.Buyer
        .SupplierName = Record.SupplierName
        .Supplier = Record.Supplier
        .Notes = Record.Notes
        .DateTime = Record.DateTime
        .UserId = Record.UserId
        .Parent_WFID = Record.Parent_WFID
        .WFID_SlNo = Record.WFID_SlNo
        .WF_Status = Record.WF_Status
        .WF_HistoryID = Record.WF_HistoryID
      End With
      Return SIS.WFDB.wfDBPreOrderHistory.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.WFDB.wfDBPreOrderHistory) As SIS.WFDB.wfDBPreOrderHistory
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDBPreOrderHistoryUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_WFID",SqlDbType.Int,11, Record.WFID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WFID",SqlDbType.Int,11, Record.WFID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Project",SqlDbType.VarChar,51, Record.Project)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Element",SqlDbType.VarChar,51, Record.Element)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SpecificationNo",SqlDbType.VarChar,101, Record.SpecificationNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Buyer",SqlDbType.VarChar,9, Record.Buyer)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierName",SqlDbType.VarChar,101, Iif(Record.SupplierName= "" ,Convert.DBNull, Record.SupplierName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Supplier",SqlDbType.VarChar,51, Iif(Record.Supplier= "" ,Convert.DBNull, Record.Supplier))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Notes",SqlDbType.VarChar,4001, Iif(Record.Notes= "" ,Convert.DBNull, Record.Notes))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DateTime",SqlDbType.DateTime,21, Record.DateTime)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserId",SqlDbType.VarChar,9, Record.UserId)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Parent_WFID",SqlDbType.Int,11, Iif(Record.Parent_WFID= "" ,Convert.DBNull, Record.Parent_WFID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WFID_SlNo",SqlDbType.Int,11, Record.WFID_SlNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WF_Status",SqlDbType.VarChar,101, Record.WF_Status)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WF_HistoryID",SqlDbType.Int,11, Record.WF_HistoryID)
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
    Public Shared Function wfDBPreOrderHistoryDelete(ByVal Record As SIS.WFDB.wfDBPreOrderHistory) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spwfDBPreOrderHistoryDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_WFID",SqlDbType.Int,Record.WFID.ToString.Length, Record.WFID)
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
