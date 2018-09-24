Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  Partial Public Class taBDFare
    Public Shared Function UZ_taBDFareSelectListForNew(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taBDFare)
      Dim Results As List(Of SIS.TA.taBDFare) = Nothing
      Results = New List(Of SIS.TA.taBDFare)()
      Dim tmp As SIS.TA.taBH = SIS.TA.taBH.taBHGetByID(TABillNo)
      For i As Integer = 1 To 10
        Dim x As New SIS.TA.taBDFare
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

    Public Shared Function UZ_taBDFareSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taBDFare)
      Dim Results As List(Of SIS.TA.taBDFare) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spta_LG_BDFareSelectListSearch"
            Cmd.CommandText = "sptaBDFareSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spta_LG_BDFareSelectListFilteres"
            Cmd.CommandText = "sptaBDFareSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo", SqlDbType.Int, 10, IIf(TABillNo = Nothing, 0, TABillNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ComponentID", SqlDbType.Int, 10, TAComponentTypes.Fare)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.TA.taBDFare)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBDFare(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_taBDFareInsert(ByVal Record As SIS.TA.taBDFare) As SIS.TA.taBDFare
      If Not ValidateFare(Record) Then
        Return Record
      End If
      With Record
        .ComponentID = TAComponentTypes.Fare
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
        If .City1ID <> String.Empty Then
          .City1Text = .FK_TA_BillDetails_City1ID.CityName
          .Country1ID = .FK_TA_BillDetails_City1ID.CountryID
        End If
        If .City2ID <> String.Empty Then
          .City2Text = .FK_TA_BillDetails_City2ID.CityName
          .Country2ID = .FK_TA_BillDetails_City2ID.CountryID
        End If
        If .ModeTravelID <> String.Empty Then
          .ModeText = .FK_TA_BillDetails_ModeTravelID.ModeName
        End If
        .SystemText = "From " & .City1Text & " To " & .City2Text & " Travel Mode " & .ModeText & " Duration " & .Date1Time & " - " & .Date2Time
      End With
      Dim _Result As SIS.TA.taBDFare = InsertData(Record)
      'taBH.ValidateTABill(Record.TABillNo)
      Return _Result
    End Function
    Public Shared Function UZ_taBDFareUpdate(ByVal Record As SIS.TA.taBDFare) As SIS.TA.taBDFare
      If Not ValidateFare(Record) Then
        Return Record
      End If
      With Record
        .ComponentID = TAComponentTypes.Fare
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
        If .City1ID <> String.Empty Then
          .City1Text = .FK_TA_BillDetails_City1ID.CityName
          .Country1ID = .FK_TA_BillDetails_City1ID.CountryID
        End If
        If .City2ID <> String.Empty Then
          .City2Text = .FK_TA_BillDetails_City2ID.CityName
          .Country2ID = .FK_TA_BillDetails_City2ID.CountryID
        End If
        If .ModeTravelID <> String.Empty Then
          .ModeText = .FK_TA_BillDetails_ModeTravelID.ModeName
        End If
        .SystemText = "From " & .City1Text & " To " & .City2Text & " Travel Mode " & .ModeText & " Duration " & .Date1Time & " - " & .Date2Time
      End With
      Dim _Result As SIS.TA.taBDFare = UpdateData(Record)
      taBH.ValidateTABill(Record.TABillNo)
      Return _Result
    End Function
    Public Shared Function ValidateFare(ByVal tmp As SIS.TA.taBDFare) As Boolean
      Dim mRet As Boolean = True
      Dim ci As System.Globalization.CultureInfo = SIS.SYS.Utilities.SessionManager.ci
      If Convert.ToDateTime(tmp.Date1Time, ci) > Convert.ToDateTime(tmp.Date2Time, ci) Then
        Throw New Exception("Journey End Date-Time CAN NOT be less than Start Date-Time")
        mRet = False
        Return mRet
      End If
      'Check existing Journey Records
      Dim sTmps As List(Of SIS.TA.taBillDetails) = SIS.TA.taBillDetails.taBillDetailsSelectList(0, 999, "", False, "", tmp.TABillNo)
      'Check all overlapping Date Time Records
      For Each sTmp As SIS.TA.taBillDetails In sTmps
        If sTmp.SerialNo = tmp.SerialNo Then Continue For
        Select Case sTmp.ComponentID
          Case TAComponentTypes.Fare, TAComponentTypes.Mileage, TAComponentTypes.Lodging
            If (Convert.ToDateTime(tmp.Date1Time, ci) >= Convert.ToDateTime(sTmp.Date1Time, ci) And Convert.ToDateTime(tmp.Date1Time, ci) <= Convert.ToDateTime(sTmp.Date2Time, ci)) Then
              Throw New Exception("Departure Date-Time is conflicting with " & sTmp.TA_Components9_Description & " Record No.: " & sTmp.SerialNo & ", Where First Date is: " & sTmp.Date1Time & " and Second Date is: " & sTmp.Date2Time)
            End If
            If (Convert.ToDateTime(sTmp.Date1Time, ci) >= Convert.ToDateTime(tmp.Date1Time, ci) And Convert.ToDateTime(sTmp.Date1Time, ci) <= Convert.ToDateTime(tmp.Date2Time, ci)) Then
              Throw New Exception("Arrival Date-Time is conflicting with " & sTmp.TA_Components9_Description & " Record No.: " & sTmp.SerialNo & ", Where First Date is: " & sTmp.Date1Time & " and Second Date is: " & sTmp.Date2Time)
            End If
            If (Convert.ToDateTime(tmp.Date2Time, ci) >= Convert.ToDateTime(sTmp.Date1Time, ci) And Convert.ToDateTime(tmp.Date2Time, ci) <= Convert.ToDateTime(sTmp.Date2Time, ci)) Then
              Throw New Exception("Arrival Date-Time is conflicting with " & sTmp.TA_Components9_Description & " Record No.: " & sTmp.SerialNo & ", Where First Date is: " & sTmp.Date1Time & " and Second Date is: " & sTmp.Date2Time)
            End If
            If (Convert.ToDateTime(sTmp.Date2Time, ci) >= Convert.ToDateTime(tmp.Date1Time, ci) And Convert.ToDateTime(sTmp.Date2Time, ci) <= Convert.ToDateTime(tmp.Date2Time, ci)) Then
              Throw New Exception("Departure Date-Time is conflicting with " & sTmp.TA_Components9_Description & " Record No.: " & sTmp.SerialNo & ", Where First Date is: " & sTmp.Date1Time & " and Second Date is: " & sTmp.Date2Time)
            End If
        End Select
      Next
      Return mRet
    End Function
    Public Shared Function UZ_taBDFareDelete(ByVal Record As SIS.TA.taBDFare) As Int32
      Dim _Result As Integer = taBillDetailsDelete(Record)
      taBH.ValidateTABill(Record.TABillNo)
      Return _Result
    End Function
  End Class
End Namespace
