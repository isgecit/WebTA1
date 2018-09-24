Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taBillPrjAmounts
    Private Shared _RecordCount As Integer
    Private _TABillNo As Int32 = 0
    Private _ProjectID As String = ""
    Private _Percentage As Decimal = 0
    Private _TotalAmountinINR As Decimal = 0
    Private _IDM_Projects1_Description As String = ""
    Private _TA_Bills2_PurposeOfJourney As String = ""
    Private _FK_TA_BillPrjAmounts_ProjectID As SIS.QCM.qcmProjects = Nothing
    Private _FK_TA_BillPrjAmounts_TABillNo As SIS.TA.taBH = Nothing
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
    Public Property TABillNo() As Int32
      Get
        Return _TABillNo
      End Get
      Set(ByVal value As Int32)
        _TABillNo = value
      End Set
    End Property
    Public Property ProjectID() As String
      Get
        Return _ProjectID
      End Get
      Set(ByVal value As String)
        _ProjectID = value
      End Set
    End Property
    Public Property Percentage() As Decimal
      Get
        Return _Percentage
      End Get
      Set(ByVal value As Decimal)
        _Percentage = value
      End Set
    End Property
    Public Property TotalAmountinINR() As Decimal
      Get
        Return _TotalAmountinINR
      End Get
      Set(ByVal value As Decimal)
        _TotalAmountinINR = value
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
    Public Property TA_Bills2_PurposeOfJourney() As String
      Get
        Return _TA_Bills2_PurposeOfJourney
      End Get
      Set(ByVal value As String)
        _TA_Bills2_PurposeOfJourney = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _TABillNo & "|" & _ProjectID
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
    Public Class PKtaBillPrjAmounts
      Private _TABillNo As Int32 = 0
      Private _ProjectID As String = ""
      Public Property TABillNo() As Int32
        Get
          Return _TABillNo
        End Get
        Set(ByVal value As Int32)
          _TABillNo = value
        End Set
      End Property
      Public Property ProjectID() As String
        Get
          Return _ProjectID
        End Get
        Set(ByVal value As String)
          _ProjectID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_TA_BillPrjAmounts_ProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_TA_BillPrjAmounts_ProjectID Is Nothing Then
          _FK_TA_BillPrjAmounts_ProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_ProjectID)
        End If
        Return _FK_TA_BillPrjAmounts_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillPrjAmounts_TABillNo() As SIS.TA.taBH
      Get
        If _FK_TA_BillPrjAmounts_TABillNo Is Nothing Then
          _FK_TA_BillPrjAmounts_TABillNo = SIS.TA.taBH.taBHGetByID(_TABillNo)
        End If
        Return _FK_TA_BillPrjAmounts_TABillNo
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBillPrjAmountsGetNewRecord() As SIS.TA.taBillPrjAmounts
      Return New SIS.TA.taBillPrjAmounts()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBillPrjAmountsGetByID(ByVal TABillNo As Int32, ByVal ProjectID As String) As SIS.TA.taBillPrjAmounts
      Dim Results As SIS.TA.taBillPrjAmounts = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBillPrjAmountsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TABillNo",SqlDbType.Int,TABillNo.ToString.Length, TABillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,ProjectID.ToString.Length, ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TA.taBillPrjAmounts(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByProjectID(ByVal ProjectID As String, ByVal OrderBy as String) As List(Of SIS.TA.taBillPrjAmounts)
      Dim Results As List(Of SIS.TA.taBillPrjAmounts) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBillPrjAmountsSelectByProjectID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,ProjectID.ToString.Length, ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taBillPrjAmounts)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBillPrjAmounts(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBillPrjAmountsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taBillPrjAmounts)
      Dim Results As List(Of SIS.TA.taBillPrjAmounts) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaBillPrjAmountsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaBillPrjAmountsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo",SqlDbType.Int,10, IIf(TABillNo = Nothing, 0,TABillNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taBillPrjAmounts)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBillPrjAmounts(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taBillPrjAmountsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBillPrjAmountsGetByID(ByVal TABillNo As Int32, ByVal ProjectID As String, ByVal Filter_TABillNo As Int32) As SIS.TA.taBillPrjAmounts
      Return taBillPrjAmountsGetByID(TABillNo, ProjectID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function taBillPrjAmountsInsert(ByVal Record As SIS.TA.taBillPrjAmounts) As SIS.TA.taBillPrjAmounts
      Dim _Rec As SIS.TA.taBillPrjAmounts = SIS.TA.taBillPrjAmounts.taBillPrjAmountsGetNewRecord()
      With _Rec
        .TABillNo = Record.TABillNo
        .ProjectID = Record.ProjectID
        .Percentage = Record.Percentage
        .TotalAmountinINR = Record.TotalAmountinINR
      End With
      Return SIS.TA.taBillPrjAmounts.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.TA.taBillPrjAmounts) As SIS.TA.taBillPrjAmounts
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBillPrjAmountsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TABillNo",SqlDbType.Int,11, Record.TABillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Percentage",SqlDbType.Decimal,9, Record.Percentage)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalAmountinINR",SqlDbType.Decimal,21, Record.TotalAmountinINR)
          Cmd.Parameters.Add("@Return_TABillNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_TABillNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_ProjectID", SqlDbType.NVarChar, 7)
          Cmd.Parameters("@Return_ProjectID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.TABillNo = Cmd.Parameters("@Return_TABillNo").Value
          Record.ProjectID = Cmd.Parameters("@Return_ProjectID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taBillPrjAmountsUpdate(ByVal Record As SIS.TA.taBillPrjAmounts) As SIS.TA.taBillPrjAmounts
      Dim _Rec As SIS.TA.taBillPrjAmounts = SIS.TA.taBillPrjAmounts.taBillPrjAmountsGetByID(Record.TABillNo, Record.ProjectID)
      With _Rec
        .Percentage = Record.Percentage
        .TotalAmountinINR = Record.TotalAmountinINR
      End With
      Return SIS.TA.taBillPrjAmounts.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.TA.taBillPrjAmounts) As SIS.TA.taBillPrjAmounts
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBillPrjAmountsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TABillNo",SqlDbType.Int,11, Record.TABillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TABillNo",SqlDbType.Int,11, Record.TABillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Percentage",SqlDbType.Decimal,9, Record.Percentage)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalAmountinINR",SqlDbType.Decimal,21, Record.TotalAmountinINR)
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
    <DataObjectMethod(DataObjectMethodType.Delete, True)>
    Public Shared Function taBillPrjAmountsDelete(ByVal Record As SIS.TA.taBillPrjAmounts) As Int32
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBillPrjAmountsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TABillNo", SqlDbType.Int, Record.TABillNo.ToString.Length, Record.TABillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID", SqlDbType.NVarChar, Record.ProjectID.ToString.Length, Record.ProjectID)
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

    'Public Sub New(ByVal Reader As SqlDataReader)
    '  On Error Resume Next
    '  _TABillNo = Ctype(Reader("TABillNo"),Int32)
    '  _ProjectID = Ctype(Reader("ProjectID"),String)
    '  _Percentage = Ctype(Reader("Percentage"),Decimal)
    '  _TotalAmountinINR = Ctype(Reader("TotalAmountinINR"),Decimal)
    '  _IDM_Projects1_Description = Ctype(Reader("IDM_Projects1_Description"),String)
    '  _TA_Bills2_PurposeOfJourney = Ctype(Reader("TA_Bills2_PurposeOfJourney"),String)
    'End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
