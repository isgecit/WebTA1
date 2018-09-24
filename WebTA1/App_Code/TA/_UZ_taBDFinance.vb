Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  Partial Public Class taBDFinance
    Public Shared Function UZ_taBDFinanceSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taBDFinance)
      Dim Results As List(Of SIS.TA.taBDFinance) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spta_LG_BDFinanceSelectListSearch"
            Cmd.CommandText = "sptaBDFinanceSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spta_LG_BDFinanceSelectListFilteres"
            Cmd.CommandText = "sptaBDFinanceSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo", SqlDbType.Int, 10, IIf(TABillNo = Nothing, 0, TABillNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ComponentID", SqlDbType.Int, 10, TAComponentTypes.Finance)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.TA.taBDFinance)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBDFinance(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_taBDFinanceInsert(ByVal Record As SIS.TA.taBDFinance) As SIS.TA.taBDFinance
      With Record
        .ComponentID = TAComponentTypes.Finance
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
        .AmountRate = 1
        .AmountFactor = .AmountRateOU * .ConversionFactorOU
        .AmountBasic = (.AmountFactor * .AmountRate)
        .AmountTaxOU = 0
        .AmountTax = .AmountTaxOU * .ConversionFactorOU
        .AmountTotal = (.AmountBasic + .AmountTax)
        .AmountInINR = .AmountTotal * .ConversionFactorINR
        .PassedAmountFactor = .AmountFactor
        .PassedAmountRate = .AmountRate
        .PassedAmountBasic = .AmountBasic
        .PassedAmountTax = .AmountTax
        .PassedAmountTotal = .AmountTotal
        .PassedAmountInINR = .AmountInINR
        If .ModeFinanceID <> String.Empty Then
          .ModeText = .FK_TA_BillDetails_ModeFinanceID.Description
        End If
        .SystemText = "Finance Source: " & .ModeText & ", Dated " & .Date1Time
      End With
      Dim _Result As SIS.TA.taBDFinance = InsertData(Record)
      taBH.ValidateTABill(Record.TABillNo)
      Return _Result
    End Function
    Public Shared Function UZ_taBDFinanceUpdate(ByVal Record As SIS.TA.taBDFinance) As SIS.TA.taBDFinance
      With Record
        .ComponentID = TAComponentTypes.Finance
        .AutoCalculated = False
        .TourExtended = False
        .AmountRate = 1
        .AmountFactor = .AmountRateOU * .ConversionFactorOU
        .AmountBasic = (.AmountFactor * .AmountRate)
        .AmountTaxOU = 0
        .AmountTax = .AmountTaxOU * .ConversionFactorOU
        .AmountTotal = (.AmountBasic + .AmountTax)
        .AmountInINR = .AmountTotal * .ConversionFactorINR
        .PassedAmountFactor = .AmountFactor
        .PassedAmountRate = .AmountRate
        .PassedAmountBasic = .AmountBasic
        .PassedAmountTax = .AmountTax
        .PassedAmountTotal = .AmountTotal
        .PassedAmountInINR = .AmountInINR
        If .ModeFinanceID <> String.Empty Then
          .ModeText = .FK_TA_BillDetails_ModeFinanceID.Description
        End If
        .SystemText = "Finance Source: " & .ModeText & ", Dated " & .Date1Time
      End With
      Dim _Result As SIS.TA.taBDFinance = UpdateData(Record)
      taBH.ValidateTABill(Record.TABillNo)
      Return _Result
    End Function
    Public Shared Function UZ_taBDFinanceDelete(ByVal Record As SIS.TA.taBDFinance) As Int32
      Dim _Result As Integer = taBillDetailsDelete(Record)
      taBH.ValidateTABill(Record.TABillNo)
      Return _Result
    End Function
  End Class
End Namespace
