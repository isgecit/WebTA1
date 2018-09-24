Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  Partial Public Class taBDMileage
    Public Shared Function UZ_taBDMileageSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taBDMileage)
      Dim Results As List(Of SIS.TA.taBDMileage) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spta_LG_BDMileageSelectListSearch"
            Cmd.CommandText = "sptaBDMileageSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spta_LG_BDMileageSelectListFilteres"
            Cmd.CommandText = "sptaBDMileageSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo", SqlDbType.Int, 10, IIf(TABillNo = Nothing, 0, TABillNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ComponentID", SqlDbType.Int, 10, TAComponentTypes.Mileage)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.TA.taBDMileage)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBDMileage(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_taBDMileageInsert(ByVal Record As SIS.TA.taBDMileage) As SIS.TA.taBDMileage
      If Not ValidateTmp(Record) Then
        Return Record
      End If
      With Record
        'Get Employees City From Location ID
        Dim LocationID As Integer = Record.FK_TA_BillDetails_TABillNo.FK_TA_Bills_EmployeeID.C_OfficeID
        Dim cityID As String = ""
        Select Case LocationID
          Case 4 'Chennai
            cityID = "Chennai-TN"
          Case 5 'Pune
            cityID = "Pune-MH"
          Case 7 ' Kolkatta
            cityID = "Kolkata-WB"
          Case 8 'Mumbai
            cityID = "MumbaiCity-MH"
        End Select
        Dim Rate As Decimal = 0
        Dim tmp As SIS.TA.taD_Mileage = SIS.TA.taD_Mileage.GetByCategoryID(Convert.ToInt32(.FK_TA_BillDetails_TABillNo.TACategoryID), cityID, Convert.ToDateTime(.Date1Time))
        If tmp IsNot Nothing Then
          Rate = tmp.AmountPerKM
        End If
        .ComponentID = TAComponentTypes.Mileage
        .AutoCalculated = False
        .TourExtended = False
        .ProjectID = .FK_TA_BillDetails_TABillNo.ProjectID
        .CostCenterID = .FK_TA_BillDetails_TABillNo.CostCenterID
        .CurrencyID = .FK_TA_BillDetails_TABillNo.BillCurrencyID
        .ConversionFactorINR = .FK_TA_BillDetails_TABillNo.ConversionFactorINR
        .AmountRate = Rate
        .AmountBasic = (.AmountFactor * .AmountRate)
        .AmountTax = 0
        .AmountTotal = (.AmountBasic + .AmountTax)
        .AmountInINR = .AmountTotal * .ConversionFactorINR
        .PassedAmountFactor = .AmountFactor
        .PassedAmountRate = .AmountRate
        .PassedAmountBasic = .AmountBasic
        .PassedAmountTax = .AmountTax
        .PassedAmountTotal = .AmountTotal
        .PassedAmountInINR = .AmountInINR
        .ModeTravelID = 15 'Own Car
        .ModeText = "Own Car"
        If .City1ID <> String.Empty Then
          .City1Text = .FK_TA_BillDetails_City1ID.CityName
        End If
        If .City2ID <> String.Empty Then
          .City2Text = .FK_TA_BillDetails_City2ID.CityName
        End If
        .SystemText = "From: " & .City1Text & " To: " & .City2Text & ", Travel Mode: " & .ModeText & ", Duration: " & .Date1Time & " - " & .Date2Time & ", Distance: " & .AmountFactor & ", @ " & .AmountRate & " per KM"
      End With
      Dim _Result As SIS.TA.taBDMileage = taBDMileageInsert(Record)
      taBH.ValidateTABill(Record.TABillNo)
      Return _Result
    End Function
    Public Shared Function UZ_taBDMileageUpdate(ByVal Record As SIS.TA.taBDMileage) As SIS.TA.taBDMileage
      If Not ValidateTmp(Record) Then
        Return Record
      End If
      With Record
        'Get Employees City From Location ID
        Dim LocationID As Integer = Record.FK_TA_BillDetails_TABillNo.FK_TA_Bills_EmployeeID.C_OfficeID
        Dim cityID As String = ""
        Select Case LocationID
          Case 4 'Chennai
            cityID = "Chennai-TN"
          Case 5 'Pune
            cityID = "Pune-MH"
          Case 7 ' Kolkatta
            cityID = "Kolkata-WB"
          Case 8 'Mumbai
            cityID = "MumbaiCity-MH"
        End Select
        Dim Rate As Decimal = 0
        Dim tmp As SIS.TA.taD_Mileage = SIS.TA.taD_Mileage.GetByCategoryID(Convert.ToInt32(.FK_TA_BillDetails_TABillNo.TACategoryID), cityID, Convert.ToDateTime(.Date1Time))
        If tmp IsNot Nothing Then
          Rate = tmp.AmountPerKM
        End If
        .ComponentID = TAComponentTypes.Mileage
        .AutoCalculated = False
        .TourExtended = False
        .AmountRate = Rate
        .AmountBasic = (.AmountFactor * .AmountRate)
        .AmountTax = 0
        .AmountTotal = (.AmountBasic + .AmountTax)
        .AmountInINR = .AmountTotal * .ConversionFactorINR
        .PassedAmountFactor = .AmountFactor
        .PassedAmountRate = .AmountRate
        .PassedAmountBasic = .AmountBasic
        .PassedAmountTax = .AmountTax
        .PassedAmountTotal = .AmountTotal
        .PassedAmountInINR = .AmountInINR
        .ModeTravelID = 15 'Own Car
        .ModeText = "Own Car"
        If .City1ID <> String.Empty Then
          .City1Text = .FK_TA_BillDetails_City1ID.CityName
        End If
        If .City2ID <> String.Empty Then
          .City2Text = .FK_TA_BillDetails_City2ID.CityName
        End If
        .SystemText = "From: " & .City1Text & " To: " & .City2Text & ", Travel Mode: " & .ModeText & ", Duration: " & .Date1Time & " - " & .Date2Time & ", Distance: " & .AmountFactor & ", @ " & .AmountRate & " per KM"
      End With
      Dim _Result As SIS.TA.taBDMileage = taBDMileageUpdate(Record)
      taBH.ValidateTABill(Record.TABillNo)
      Return _Result
    End Function
    Public Shared Function ValidateTmp(ByVal tmp As SIS.TA.taBDMileage) As Boolean
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
              Throw New Exception("Proceeding Date-Time is conflicting with " & sTmp.TA_Components9_Description & " Record No.: " & sTmp.SerialNo)
            End If
            If (Convert.ToDateTime(sTmp.Date1Time, ci) >= Convert.ToDateTime(tmp.Date1Time, ci) And Convert.ToDateTime(sTmp.Date1Time, ci) <= Convert.ToDateTime(tmp.Date2Time, ci)) Then
              Throw New Exception("Reaching Date-Time is conflicting with " & sTmp.TA_Components9_Description & " Record No.: " & sTmp.SerialNo)
            End If
            If (Convert.ToDateTime(tmp.Date2Time, ci) >= Convert.ToDateTime(sTmp.Date1Time, ci) And Convert.ToDateTime(tmp.Date2Time, ci) <= Convert.ToDateTime(sTmp.Date2Time, ci)) Then
              Throw New Exception("Reaching Date-Time is conflicting with " & sTmp.TA_Components9_Description & " Record No.: " & sTmp.SerialNo)
            End If
            If (Convert.ToDateTime(sTmp.Date2Time, ci) >= Convert.ToDateTime(tmp.Date1Time, ci) And Convert.ToDateTime(sTmp.Date2Time, ci) <= Convert.ToDateTime(tmp.Date2Time, ci)) Then
              Throw New Exception("Proceeding Date-Time is conflicting with " & sTmp.TA_Components9_Description & " Record No.: " & sTmp.SerialNo)
            End If
        End Select
      Next
      Return mRet
    End Function
    Public Shared Function UZ_taBDMileageDelete(ByVal Record As SIS.TA.taBDMileage) As Int32
      Dim _Result As Integer = taBillDetailsDelete(Record)
      taBH.ValidateTABill(Record.TABillNo)
      Return _Result
    End Function
  End Class
End Namespace
