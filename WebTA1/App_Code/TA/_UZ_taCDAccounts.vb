Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  Partial Public Class taCDAccounts
    Public Shadows Function GetEditable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Shadows Function GetDeleteable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Shadows ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property DeleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property DeleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Shadows Function DeleteWF(ByVal TABillNo As Int32, ByVal SerialNo As Int32) As SIS.TA.taCDAccounts
      Dim Results As SIS.TA.taCDAccounts = taCDAccountsGetByID(TABillNo, SerialNo)
      UZ_taCDAccountsDelete(Results)
      Return Results
    End Function
    Public Shared Function UZ_taCDAccountsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taCDAccounts)
      Dim Results As List(Of SIS.TA.taCDAccounts) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spta_LG_CDAccountsSelectListSearch"
            Cmd.CommandText = "sptaCDAccountsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spta_LG_CDAccountsSelectListFilteres"
            Cmd.CommandText = "sptaCDAccountsSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo", SqlDbType.Int, 10, IIf(TABillNo = Nothing, 0, TABillNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ComponentID",SqlDbType.Int,10, TAComponentTypes.AccountsEntry)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.TA.taCDAccounts)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taCDAccounts(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_taCDAccountsInsert(ByVal Record As SIS.TA.taCDAccounts) As SIS.TA.taCDAccounts
      With Record
        .ComponentID = TAComponentTypes.AccountsEntry
        .AutoCalculated = False
        .TourExtended = False
        .ProjectID = .FK_TA_BillDetails_TABillNo.ProjectID
        .CostCenterID = .FK_TA_BillDetails_TABillNo.CostCenterID
        .ConversionFactorINR = .FK_TA_BillDetails_TABillNo.ConversionFactorINR
        If .FK_TA_BillDetails_TABillNo.BillCurrencyID <> "INR" Then
          If .CurrencyID = "INR" Then
            .ConversionFactorOU = 1
            .ConversionFactorINR = 1
          End If
        End If
        .AmountFactor = 1
        .AmountTaxOU = 0
        .AmountRate = .AmountRateOU * .ConversionFactorOU
        .AmountBasic = (.AmountFactor * .AmountRate)
        .AmountTax = .AmountTaxOU * .ConversionFactorOU
        .AmountTotal = (.AmountBasic + .AmountTax)
        .AmountInINR = .AmountTotal * .ConversionFactorINR
        .PassedAmountFactor = .AmountFactor
        .PassedAmountRate = .AmountRate
        .PassedAmountBasic = .AmountBasic
        .PassedAmountTax = .AmountTax
        .PassedAmountTotal = .AmountTotal
        .PassedAmountInINR = .AmountInINR
        .ApprovedBy = HttpContext.Current.Session("LoginID")
        .ApprovedOn = Now
      End With
      Dim _Result As SIS.TA.taCDAccounts = InsertData(Record)
      SIS.TA.taCH.ValidateBillPassing(Record.TABillNo)
      Return _Result
    End Function
    Public Shared Function UZ_taCDAccountsUpdate(ByVal Record As SIS.TA.taCDAccounts) As SIS.TA.taCDAccounts
      With Record
        If .FK_TA_BillDetails_TABillNo.BillCurrencyID <> "INR" Then
          If .CurrencyID = "INR" Then
            .ConversionFactorOU = 1
            .ConversionFactorINR = 1
          End If
        End If
        .AmountFactor = 1
        .AmountTaxOU = 0
        .ComponentID = TAComponentTypes.AccountsEntry
        .AmountRate = .AmountRateOU * .ConversionFactorOU
        .AmountBasic = (.AmountFactor * .AmountRate)
        .AmountTax = .AmountTaxOU * .ConversionFactorOU
        .AmountTotal = (.AmountBasic + .AmountTax)
        .AmountInINR = .AmountTotal * .ConversionFactorINR
        .PassedAmountFactor = .AmountFactor
        .PassedAmountRate = .AmountRate
        .PassedAmountBasic = .AmountBasic
        .PassedAmountTax = .AmountTax
        .PassedAmountTotal = .AmountTotal
        .PassedAmountInINR = .AmountInINR
        .ApprovedBy = HttpContext.Current.Session("LoginID")
        .ApprovedOn = Now
      End With
      Dim _Result As SIS.TA.taCDAccounts = UpdateData(Record)
      SIS.TA.taCH.ValidateBillPassing(Record.TABillNo)
      Return _Result
    End Function
    Public Shared Function UZ_taCDAccountsDelete(ByVal Record As SIS.TA.taCDAccounts) As Int32
      Dim _Result As Integer = taBillDetailsDelete(Record)
      SIS.TA.taCH.ValidateBillPassing(Record.TABillNo)
      Return _Result
    End Function
  End Class
End Namespace
