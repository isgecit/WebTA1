Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  Partial Public Class taBDLC
    Public Shared Function UZ_taBDLCSelectListForNew(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taBDLC)
      Dim Results As List(Of SIS.TA.taBDLC) = Nothing
      Results = New List(Of SIS.TA.taBDLC)()
      Dim tmp As SIS.TA.taBH = SIS.TA.taBH.taBHGetByID(TABillNo)
      For i As Integer = 1 To 10
        Dim x As New SIS.TA.taBDLC
        With x
          .TABillNo = TABillNo
          .SerialNo = i
          .CurrencyMain = tmp.BillCurrencyID
          .ConversionFactorINR = tmp.ConversionFactorINR
          .ConversionFactorOU = "1.000000"
          .CurrencyID = tmp.BillCurrencyID
        End With
        Results.Add(x)
      Next
      RecordCount = 10
      Return Results
    End Function
    Public Shared Function UZ_taBDLCSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taBDLC)
      Dim Results As List(Of SIS.TA.taBDLC) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spta_LG_BDLCSelectListSearch"
            Cmd.CommandText = "sptaBDLCSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spta_LG_BDLCSelectListFilteres"
            Cmd.CommandText = "sptaBDLCSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo", SqlDbType.Int, 10, IIf(TABillNo = Nothing, 0, TABillNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ComponentID", SqlDbType.Int, 10, TAComponentTypes.LC)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.TA.taBDLC)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBDLC(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_taBDLCInsert(ByVal Record As SIS.TA.taBDLC) As SIS.TA.taBDLC
      With Record
        .ComponentID = TAComponentTypes.LC
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
        If .ModeLCID <> String.Empty Then
          .ModeText = .FK_TA_BillDetails_ModeLCID.ModeName
        End If
        .SystemText = "From " & .City1Text & " To " & .City2Text & " LC Mode " & .ModeText & " On " & .Date1Time
      End With
      Dim _Result As SIS.TA.taBDLC = InsertData(Record)
      'taBH.ValidateTABill(Record.TABillNo)
      Return _Result
    End Function
    Public Shared Function UZ_taBDLCUpdate(ByVal Record As SIS.TA.taBDLC) As SIS.TA.taBDLC
      With Record
        .ComponentID = TAComponentTypes.LC
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
        If .ModeLCID <> String.Empty Then
          .ModeText = .FK_TA_BillDetails_ModeLCID.ModeName
        End If
        .SystemText = "From " & .City1Text & " To " & .City2Text & " LC Mode " & .ModeText & " Duration " & .Date1Time & " - " & .Date2Time
      End With
      Dim _Result As SIS.TA.taBDLC = UpdateData(Record)
      taBH.ValidateTABill(Record.TABillNo)
      Return _Result
    End Function
    Public Shared Function UZ_taBDLCDelete(ByVal Record As SIS.TA.taBDLC) As Int32
      Dim _Result As Integer = taBillDetailsDelete(Record)
      taBH.ValidateTABill(Record.TABillNo)
      Return _Result
    End Function
  End Class
End Namespace
