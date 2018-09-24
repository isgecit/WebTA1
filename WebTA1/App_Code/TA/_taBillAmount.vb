Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taBillAmount
    Private Shared _RecordCount As Integer
    Private _TABillNo As Int32 = 0
    Private _ComponentID As Int32 = 0
    Private _CurrencyID As String = ""
    Private _CostCenterID As String = ""
    Private _TotalInCurrency As Decimal = 0
    Private _ConversionFactorINR As Decimal = 0
    Private _CalculationTypeID As String = ""
    Private _TotalInINR As Decimal = 0
    Private _ProjectID As String = ""
    Private _HRM_Departments1_Description As String = ""
    Private _TA_Bills2_PurposeOfJourney As String = ""
    Private _TA_CalcMethod3_CalculationDescription As String = ""
    Private _TA_Components4_Description As String = ""
    Private _TA_Currencies5_CurrencyName As String = ""
    Private _IDM_Projects1_Description As String = ""
    Private _FK_TA_BillAmount_CostCenterID As SIS.TA.taDepartments = Nothing
    Private _FK_TA_BillAmount_TABillNo As SIS.TA.taBH = Nothing
    Private _FK_TA_BillAmount_CalculationTypeID As SIS.TA.taCalcMethod = Nothing
    Private _FK_TA_BillAmount_ComponentID As SIS.TA.taComponents = Nothing
    Private _FK_TA_BillAmount_CurrencyID As SIS.TA.taCurrencies = Nothing
    Private _FK_TA_BillAmount_ProjectID As SIS.QCM.qcmProjects = Nothing
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
    Public Property ComponentID() As Int32
      Get
        Return _ComponentID
      End Get
      Set(ByVal value As Int32)
        _ComponentID = value
      End Set
    End Property
    Public Property CurrencyID() As String
      Get
        Return _CurrencyID
      End Get
      Set(ByVal value As String)
        _CurrencyID = value
      End Set
    End Property
    Public Property CostCenterID() As String
      Get
        Return _CostCenterID
      End Get
      Set(ByVal value As String)
        _CostCenterID = value
      End Set
    End Property
    Public Property TotalInCurrency() As Decimal
      Get
        Return _TotalInCurrency
      End Get
      Set(ByVal value As Decimal)
        _TotalInCurrency = value
      End Set
    End Property
    Public Property ConversionFactorINR() As Decimal
      Get
        Return _ConversionFactorINR
      End Get
      Set(ByVal value As Decimal)
        _ConversionFactorINR = value
      End Set
    End Property
    Public Property CalculationTypeID() As String
      Get
        Return _CalculationTypeID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CalculationTypeID = ""
         Else
           _CalculationTypeID = value
         End If
      End Set
    End Property
    Public Property TotalInINR() As Decimal
      Get
        Return _TotalInINR
      End Get
      Set(ByVal value As Decimal)
        _TotalInINR = value
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
    Public Property HRM_Departments1_Description() As String
      Get
        Return _HRM_Departments1_Description
      End Get
      Set(ByVal value As String)
        _HRM_Departments1_Description = value
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
    Public Property TA_CalcMethod3_CalculationDescription() As String
      Get
        Return _TA_CalcMethod3_CalculationDescription
      End Get
      Set(ByVal value As String)
        _TA_CalcMethod3_CalculationDescription = value
      End Set
    End Property
    Public Property TA_Components4_Description() As String
      Get
        Return _TA_Components4_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_Components4_Description = ""
         Else
           _TA_Components4_Description = value
         End If
      End Set
    End Property
    Public Property TA_Currencies5_CurrencyName() As String
      Get
        Return _TA_Currencies5_CurrencyName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _TA_Currencies5_CurrencyName = ""
         Else
           _TA_Currencies5_CurrencyName = value
         End If
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
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _TABillNo & "|" & _ComponentID & "|" & _CurrencyID & "|" & _CostCenterID
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
    Public Class PKtaBillAmount
      Private _TABillNo As Int32 = 0
      Private _ComponentID As Int32 = 0
      Private _CurrencyID As String = ""
      Private _CostCenterID As String = ""
      Public Property TABillNo() As Int32
        Get
          Return _TABillNo
        End Get
        Set(ByVal value As Int32)
          _TABillNo = value
        End Set
      End Property
      Public Property ComponentID() As Int32
        Get
          Return _ComponentID
        End Get
        Set(ByVal value As Int32)
          _ComponentID = value
        End Set
      End Property
      Public Property CurrencyID() As String
        Get
          Return _CurrencyID
        End Get
        Set(ByVal value As String)
          _CurrencyID = value
        End Set
      End Property
      Public Property CostCenterID() As String
        Get
          Return _CostCenterID
        End Get
        Set(ByVal value As String)
          _CostCenterID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_TA_BillAmount_CostCenterID() As SIS.TA.taDepartments
      Get
        If _FK_TA_BillAmount_CostCenterID Is Nothing Then
          _FK_TA_BillAmount_CostCenterID = SIS.TA.taDepartments.taDepartmentsGetByID(_CostCenterID)
        End If
        Return _FK_TA_BillAmount_CostCenterID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillAmount_TABillNo() As SIS.TA.taBH
      Get
        If _FK_TA_BillAmount_TABillNo Is Nothing Then
          _FK_TA_BillAmount_TABillNo = SIS.TA.taBH.taBHGetByID(_TABillNo)
        End If
        Return _FK_TA_BillAmount_TABillNo
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillAmount_CalculationTypeID() As SIS.TA.taCalcMethod
      Get
        If _FK_TA_BillAmount_CalculationTypeID Is Nothing Then
          _FK_TA_BillAmount_CalculationTypeID = SIS.TA.taCalcMethod.taCalcMethodGetByID(_CalculationTypeID)
        End If
        Return _FK_TA_BillAmount_CalculationTypeID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillAmount_ComponentID() As SIS.TA.taComponents
      Get
        If _FK_TA_BillAmount_ComponentID Is Nothing Then
          _FK_TA_BillAmount_ComponentID = SIS.TA.taComponents.taComponentsGetByID(_ComponentID)
        End If
        Return _FK_TA_BillAmount_ComponentID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillAmount_CurrencyID() As SIS.TA.taCurrencies
      Get
        If _FK_TA_BillAmount_CurrencyID Is Nothing Then
          _FK_TA_BillAmount_CurrencyID = SIS.TA.taCurrencies.taCurrenciesGetByID(_CurrencyID)
        End If
        Return _FK_TA_BillAmount_CurrencyID
      End Get
    End Property
    Public ReadOnly Property FK_TA_BillAmount_ProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_TA_BillAmount_ProjectID Is Nothing Then
          _FK_TA_BillAmount_ProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_ProjectID)
        End If
        Return _FK_TA_BillAmount_ProjectID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBillAmountGetNewRecord() As SIS.TA.taBillAmount
      Return New SIS.TA.taBillAmount()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBillAmountGetByID(ByVal TABillNo As Int32, ByVal ComponentID As Int32, ByVal CurrencyID As String, ByVal CostCenterID As String) As SIS.TA.taBillAmount
      Dim Results As SIS.TA.taBillAmount = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBillAmountSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TABillNo",SqlDbType.Int,TABillNo.ToString.Length, TABillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ComponentID",SqlDbType.Int,ComponentID.ToString.Length, ComponentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyID",SqlDbType.NVarChar,CurrencyID.ToString.Length, CurrencyID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostCenterID",SqlDbType.NVarChar,CostCenterID.ToString.Length, CostCenterID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TA.taBillAmount(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBillAmountSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taBillAmount)
      Dim Results As List(Of SIS.TA.taBillAmount) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaBillAmountSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaBillAmountSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo",SqlDbType.Int,10, IIf(TABillNo = Nothing, 0,TABillNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taBillAmount)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBillAmount(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taBillAmountSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBillAmountGetByID(ByVal TABillNo As Int32, ByVal ComponentID As Int32, ByVal CurrencyID As String, ByVal CostCenterID As String, ByVal Filter_TABillNo As Int32) As SIS.TA.taBillAmount
      Return taBillAmountGetByID(TABillNo, ComponentID, CurrencyID, CostCenterID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function taBillAmountInsert(ByVal Record As SIS.TA.taBillAmount) As SIS.TA.taBillAmount
      Dim _Rec As SIS.TA.taBillAmount = SIS.TA.taBillAmount.taBillAmountGetNewRecord()
      With _Rec
        .TABillNo = Record.TABillNo
        .ComponentID = Record.ComponentID
        .CurrencyID = Record.CurrencyID
        .CostCenterID = Record.CostCenterID
        .TotalInCurrency = Record.TotalInCurrency
        .ConversionFactorINR = Record.ConversionFactorINR
        .CalculationTypeID = Record.CalculationTypeID
        .TotalInINR = Record.TotalInINR
        .ProjectID = Record.ProjectID
      End With
      Return SIS.TA.taBillAmount.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.TA.taBillAmount) As SIS.TA.taBillAmount
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBillAmountInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TABillNo",SqlDbType.Int,11, Record.TABillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ComponentID",SqlDbType.Int,11, Record.ComponentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyID",SqlDbType.NVarChar,7, Record.CurrencyID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostCenterID",SqlDbType.NVarChar,7, Record.CostCenterID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalInCurrency",SqlDbType.Decimal,21, Record.TotalInCurrency)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConversionFactorINR",SqlDbType.Decimal,11, Record.ConversionFactorINR)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CalculationTypeID",SqlDbType.NVarChar,11, Iif(Record.CalculationTypeID= "" ,Convert.DBNull, Record.CalculationTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalInINR",SqlDbType.Decimal,21, Record.TotalInINR)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
          Cmd.Parameters.Add("@Return_TABillNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_TABillNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_ComponentID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ComponentID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_CurrencyID", SqlDbType.NVarChar, 7)
          Cmd.Parameters("@Return_CurrencyID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_CostCenterID", SqlDbType.NVarChar, 7)
          Cmd.Parameters("@Return_CostCenterID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.TABillNo = Cmd.Parameters("@Return_TABillNo").Value
          Record.ComponentID = Cmd.Parameters("@Return_ComponentID").Value
          Record.CurrencyID = Cmd.Parameters("@Return_CurrencyID").Value
          Record.CostCenterID = Cmd.Parameters("@Return_CostCenterID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taBillAmountUpdate(ByVal Record As SIS.TA.taBillAmount) As SIS.TA.taBillAmount
      Dim _Rec As SIS.TA.taBillAmount = SIS.TA.taBillAmount.taBillAmountGetByID(Record.TABillNo, Record.ComponentID, Record.CurrencyID, Record.CostCenterID)
      With _Rec
        .TotalInCurrency = Record.TotalInCurrency
        .ConversionFactorINR = Record.ConversionFactorINR
        .CalculationTypeID = Record.CalculationTypeID
        .TotalInINR = Record.TotalInINR
        .ProjectID = Record.ProjectID
      End With
      Return SIS.TA.taBillAmount.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.TA.taBillAmount) As SIS.TA.taBillAmount
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBillAmountUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TABillNo",SqlDbType.Int,11, Record.TABillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ComponentID",SqlDbType.Int,11, Record.ComponentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CurrencyID",SqlDbType.NVarChar,7, Record.CurrencyID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CostCenterID",SqlDbType.NVarChar,7, Record.CostCenterID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TABillNo",SqlDbType.Int,11, Record.TABillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ComponentID",SqlDbType.Int,11, Record.ComponentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CurrencyID",SqlDbType.NVarChar,7, Record.CurrencyID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CostCenterID",SqlDbType.NVarChar,7, Record.CostCenterID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalInCurrency",SqlDbType.Decimal,21, Record.TotalInCurrency)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ConversionFactorINR",SqlDbType.Decimal,11, Record.ConversionFactorINR)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CalculationTypeID",SqlDbType.NVarChar,11, Iif(Record.CalculationTypeID= "" ,Convert.DBNull, Record.CalculationTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalInINR",SqlDbType.Decimal,21, Record.TotalInINR)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Iif(Record.ProjectID= "" ,Convert.DBNull, Record.ProjectID))
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
    Public Shared Function taBillAmountDelete(ByVal Record As SIS.TA.taBillAmount) As Int32
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBillAmountDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TABillNo", SqlDbType.Int, Record.TABillNo.ToString.Length, Record.TABillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ComponentID", SqlDbType.Int, Record.ComponentID.ToString.Length, Record.ComponentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CurrencyID", SqlDbType.NVarChar, Record.CurrencyID.ToString.Length, Record.CurrencyID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_CostCenterID", SqlDbType.NVarChar, Record.CostCenterID.ToString.Length, Record.CostCenterID)
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
    '  _ComponentID = Ctype(Reader("ComponentID"),Int32)
    '  _CurrencyID = Ctype(Reader("CurrencyID"),String)
    '  _CostCenterID = Ctype(Reader("CostCenterID"),String)
    '  _TotalInCurrency = Ctype(Reader("TotalInCurrency"),Decimal)
    '  _ConversionFactorINR = Ctype(Reader("ConversionFactorINR"),Decimal)
    '  If Convert.IsDBNull(Reader("CalculationTypeID")) Then
    '    _CalculationTypeID = String.Empty
    '  Else
    '    _CalculationTypeID = Ctype(Reader("CalculationTypeID"), String)
    '  End If
    '  _TotalInINR = Ctype(Reader("TotalInINR"),Decimal)
    '  If Convert.IsDBNull(Reader("ProjectID")) Then
    '    _ProjectID = String.Empty
    '  Else
    '    _ProjectID = Ctype(Reader("ProjectID"), String)
    '  End If
    '  _HRM_Departments1_Description = Ctype(Reader("HRM_Departments1_Description"),String)
    '  _TA_Bills2_PurposeOfJourney = Ctype(Reader("TA_Bills2_PurposeOfJourney"),String)
    '  _TA_CalcMethod3_CalculationDescription = Ctype(Reader("TA_CalcMethod3_CalculationDescription"),String)
    '  If Convert.IsDBNull(Reader("TA_Components4_Description")) Then
    '    _TA_Components4_Description = String.Empty
    '  Else
    '    _TA_Components4_Description = Ctype(Reader("TA_Components4_Description"), String)
    '  End If
    '  If Convert.IsDBNull(Reader("TA_Currencies5_CurrencyName")) Then
    '    _TA_Currencies5_CurrencyName = String.Empty
    '  Else
    '    _TA_Currencies5_CurrencyName = Ctype(Reader("TA_Currencies5_CurrencyName"), String)
    '  End If
    '  _IDM_Projects1_Description = Ctype(Reader("IDM_Projects1_Description"),String)
    'End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
