Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.Script.Serialization
Namespace SIS.TA
  Partial Public Class taBDLodging
    Public Shared Function UZ_taBDLodgingSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taBDLodging)
      Dim Results As List(Of SIS.TA.taBDLodging) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spta_LG_BDLodgingSelectListSearch"
            Cmd.CommandText = "sptaBDLodgingSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spta_LG_BDLodgingSelectListFilteres"
            Cmd.CommandText = "sptaBDLodgingSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo", SqlDbType.Int, 10, IIf(TABillNo = Nothing, 0, TABillNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ComponentID", SqlDbType.Int, 10, TAComponentTypes.Lodging)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.TA.taBDLodging)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBDLodging(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_taBDLodgingInsert(ByVal Record As SIS.TA.taBDLodging) As SIS.TA.taBDLodging
      If Not ValidateTmp(Record) Then
        Return Record
      End If
      With Record
        .ComponentID = TAComponentTypes.Lodging
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
        If .City1ID <> String.Empty Then
          .City1Text = .FK_TA_BillDetails_City1ID.CityName
          .Country1ID = .FK_TA_BillDetails_City1ID.CountryID
        End If
        .SystemText = "City " & .City1Text & " Stay Details " & .ModeText & " Duration " & .Date1Time & " - " & .Date2Time
      End With
      Dim _Result As SIS.TA.taBDLodging = InsertData(Record)
      Try
        Dim tmp As SIS.TA.taBillGST = SIS.TA.taBDLodging.GetGSTDataFromBDL(_Result)
        tmp = SIS.TA.taBillGST.InsertData(tmp)
      Catch ex As Exception
      End Try
      taBH.ValidateTABill(Record.TABillNo)
      Return _Result
    End Function
    Public Shared Function UZ_taBDLodgingUpdate(ByVal Record As SIS.TA.taBDLodging) As SIS.TA.taBDLodging
      If Not ValidateTmp(Record) Then
        Return Record
      End If
      With Record
        .ComponentID = TAComponentTypes.Lodging
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
        If .City1ID <> String.Empty Then
          .City1Text = .FK_TA_BillDetails_City1ID.CityName
          .Country1ID = .FK_TA_BillDetails_City1ID.CountryID
        End If
        .SystemText = "City " & .City1Text & " Stay Details " & .ModeText & " Duration " & .Date1Time & " - " & .Date2Time
      End With
      Dim _Result As SIS.TA.taBDLodging = UpdateData(Record)
      Try
        Dim tmp As SIS.TA.taBillGST = SIS.TA.taBDLodging.GetGSTDataFromBDL(_Result)
        Dim oldRec As SIS.TA.taBillGST = SIS.TA.taBillGST.taBillGSTGetByID(tmp.TABillNo, tmp.SerialNo)
        If oldRec Is Nothing Then
          tmp = SIS.TA.taBillGST.InsertData(tmp)
        Else
          tmp = SIS.TA.taBillGST.UpdateData(tmp)
        End If
      Catch ex As Exception
      End Try
      taBH.ValidateTABill(Record.TABillNo)
      Return _Result
    End Function
    Public Shared Function ValidateTmp(ByVal tmp As SIS.TA.taBDLodging) As Boolean
      Dim mRet As Boolean = True
      Dim ci As System.Globalization.CultureInfo = SIS.SYS.Utilities.SessionManager.ci
      If Convert.ToDateTime(tmp.Date1Time, ci) > Convert.ToDateTime(tmp.Date2Time, ci) Then
        Throw New Exception("Lodging End Date-Time CAN NOT be less than Start Date-Time")
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
              Throw New Exception("Check-In Date-Time is conflicting with " & sTmp.TA_Components9_Description & " Record No.: " & sTmp.SerialNo)
              mRet = False
            End If
            If (Convert.ToDateTime(sTmp.Date1Time, ci) >= Convert.ToDateTime(tmp.Date1Time, ci) And Convert.ToDateTime(sTmp.Date1Time, ci) <= Convert.ToDateTime(tmp.Date2Time, ci)) Then
              Throw New Exception("Check-Out Date-Time is conflicting with " & sTmp.TA_Components9_Description & " Record No.: " & sTmp.SerialNo)
              mRet = False
            End If
            If (Convert.ToDateTime(tmp.Date2Time, ci) >= Convert.ToDateTime(sTmp.Date1Time, ci) And Convert.ToDateTime(tmp.Date2Time, ci) <= Convert.ToDateTime(sTmp.Date2Time, ci)) Then
              Throw New Exception("Check-Out Date-Time is conflicting with " & sTmp.TA_Components9_Description & " Record No.: " & sTmp.SerialNo)
              mRet = False
            End If
            If (Convert.ToDateTime(sTmp.Date2Time, ci) >= Convert.ToDateTime(tmp.Date1Time, ci) And Convert.ToDateTime(sTmp.Date2Time, ci) <= Convert.ToDateTime(tmp.Date2Time, ci)) Then
              Throw New Exception("Check-In Date-Time is conflicting with " & sTmp.TA_Components9_Description & " Record No.: " & sTmp.SerialNo)
              mRet = False
            End If
        End Select
      Next
      Return mRet
    End Function
    Public Shared Function UZ_taBDLodgingDelete(ByVal Record As SIS.TA.taBDLodging) As Int32
      Dim oGST As SIS.TA.taBillGST = SIS.TA.taBillGST.taBillGSTGetByID(Record.TABillNo, Record.SerialNo)
      SIS.TA.taBillGST.taBillGSTDelete(oGST)
      Dim _Result As Integer = taBillDetailsDelete(Record)
      taBH.ValidateTABill(Record.TABillNo)
      Return _Result
    End Function
    Public Shared Function UpdateGSTDataInBDL(ByVal oBDL As SIS.TA.taBillDetails) As SIS.TA.taBillDetails
      Dim tmp As SIS.TA.taBillGST = SIS.TA.taBillGST.taBillGSTGetByID(oBDL.TABillNo, oBDL.SerialNo)
      If tmp IsNot Nothing Then
        Try
          For Each pi As System.Reflection.PropertyInfo In tmp.GetType.GetProperties
            If pi.MemberType = Reflection.MemberTypes.Property Then
              Try
                Dim si As System.Reflection.PropertyInfo = tmp.GetType.GetProperty(pi.Name)
                Dim _tskip As SIS.SYS.Utilities.lgSkipAttribute = Attribute.GetCustomAttribute(si, GetType(SIS.SYS.Utilities.lgSkipAttribute))
                If _tskip IsNot Nothing Then Continue For
                CallByName(oBDL, pi.Name, CallType.Let, CallByName(tmp, pi.Name, CallType.Get))
              Catch ex As Exception
              End Try
            End If
          Next
        Catch ex As Exception
          Dim aa As String = ex.Message
        End Try
      End If
      Return oBDL
    End Function

    Public Shared Function UpdateGSTDataInBDL(ByVal oBDL As SIS.TA.taBDLodging) As SIS.TA.taBDLodging
      Dim tmp As SIS.TA.taBillGST = SIS.TA.taBillGST.taBillGSTGetByID(oBDL.TABillNo, oBDL.SerialNo)
      If tmp IsNot Nothing Then
        Try
          For Each pi As System.Reflection.PropertyInfo In tmp.GetType.GetProperties
            If pi.MemberType = Reflection.MemberTypes.Property Then
              Try
                Dim si As System.Reflection.PropertyInfo = tmp.GetType.GetProperty(pi.Name)
                Dim _tskip As SIS.SYS.Utilities.lgSkipAttribute = Attribute.GetCustomAttribute(si, GetType(SIS.SYS.Utilities.lgSkipAttribute))
                If _tskip IsNot Nothing Then Continue For
                CallByName(oBDL, pi.Name, CallType.Let, CallByName(tmp, pi.Name, CallType.Get))
              Catch ex As Exception
              End Try
            End If
          Next
        Catch ex As Exception
          Dim aa As String = ex.Message
        End Try
      End If
      Return oBDL
    End Function
    Public Shared Function GetGSTDataFromBDL(ByVal oBDL As SIS.TA.taBDLodging) As SIS.TA.taBillGST
      Dim tmp As New SIS.TA.taBillGST
      Try
        For Each pi As System.Reflection.PropertyInfo In tmp.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              CallByName(tmp, pi.Name, CallType.Let, CallByName(oBDL, pi.Name, CallType.Get))
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
        Dim aa As String = ex.Message
      End Try
      Return tmp
    End Function
  End Class
End Namespace
