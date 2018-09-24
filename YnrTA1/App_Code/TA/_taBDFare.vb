Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taBDFare
    Inherits SIS.TA.taBillDetails
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBDFareGetNewRecord() As SIS.TA.taBDFare
      Return New SIS.TA.taBDFare()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBDFareSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taBDFare)
      Dim Results As List(Of SIS.TA.taBDFare) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaBDFareSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaBDFareSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo",SqlDbType.Int,10, IIf(TABillNo = Nothing, 0,TABillNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ComponentID",SqlDbType.Int,10, TAComponentTypes.Fare)
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
    Public Shared Function taBDFareSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBDFareGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32) As SIS.TA.taBDFare
      Dim Results As SIS.TA.taBDFare = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBillDetailsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TABillNo",SqlDbType.Int,TABillNo.ToString.Length, TABillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TA.taBDFare(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBDFareGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32, ByVal Filter_TABillNo As Int32) As SIS.TA.taBDFare
      Dim Results As SIS.TA.taBDFare = SIS.TA.taBDFare.taBDFareGetByID(TABillNo, SerialNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function taBDFareInsert(ByVal Record As SIS.TA.taBDFare) As SIS.TA.taBDFare
      Dim _Rec As SIS.TA.taBDFare = SIS.TA.taBDFare.taBDFareGetNewRecord()
      With _Rec
        .TABillNo = Record.TABillNo
        .City1ID = Record.City1ID
        .City1Text = Record.City1Text
        .City2ID = Record.City2ID
        .City2Text = Record.City2Text
        .Date1Time = Record.Date1Time
        .Date2Time = Record.Date2Time
        .ModeTravelID = Record.ModeTravelID
        .ModeText = Record.ModeText
        .AmountFactor = Record.AmountFactor
        .Remarks = Record.Remarks
        .OOERemarks = Record.OOERemarks
        .ProjectID = Record.ProjectID
        .OOEReasonID = Record.OOEReasonID
        .PassedAmountFactor = Record.PassedAmountFactor
        .AmountBasic = Record.AmountBasic
        .AmountTax = Record.AmountTax
        .AmountTotal = Record.AmountTotal
        .AmountRate = Record.AmountRate
        .ModeFinanceID = Record.ModeFinanceID
        .PassedAmountTotal = Record.PassedAmountTotal
        .ComponentID = Record.ComponentID
        .SystemText = Record.SystemText
        .ApprovalRemarks = Record.ApprovalRemarks
        .Setteled = Record.Setteled
        .AmountInINR = Record.AmountInINR
        .BillAttached = Record.BillAttached
        .PassedAmountRate = Record.PassedAmountRate
        .PassedAmountTax = Record.PassedAmountTax
        .AirportToHotel = Record.AirportToHotel
        .AccountsRemarks = Record.AccountsRemarks
        .CostCenterID = Record.CostCenterID
        .PassedAmountBasic = Record.PassedAmountBasic
        .PassedAmountInINR = Record.PassedAmountInINR
        .ApprovedOn = Record.ApprovedOn
        .ConversionFactorINR = Record.ConversionFactorINR
        .SanctionFileName = Record.SanctionFileName
        .StayedInHotel = Record.StayedInHotel
        .BillDiskFile = Record.BillDiskFile
        .OOEBySystem = Record.OOEBySystem
        .LodgingProvided = Record.LodgingProvided
        .AirportToClientLocation = Record.AirportToClientLocation
        .SanctionDiskFile = Record.SanctionDiskFile
        .NotStayedAnyWhere = Record.NotStayedAnyWhere
        .StayedInGuestHouse = Record.StayedInGuestHouse
        .StayedWithRelative = Record.StayedWithRelative
        .ModeExpenseID = Record.ModeExpenseID
        .ApprovedBy = Record.ApprovedBy
        .OOEByAccounts = Record.OOEByAccounts
        .SanctionAttached = Record.SanctionAttached
        .AutoCalculated = Record.AutoCalculated
        .CurrencyID = Record.CurrencyID
        .StayedAtSite = Record.StayedAtSite
        .ApprovalWFTypeID = Record.ApprovalWFTypeID
        .TourExtended = Record.TourExtended
        .BillFileName = Record.BillFileName
        .CityTypeID = Record.CityTypeID
        .ModeLCID = Record.ModeLCID
        .BoardingProvided = Record.BoardingProvided
        .HotelToAirport = Record.HotelToAirport
      End With
      Return SIS.TA.taBDFare.InsertData(_Rec)
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taBDFareUpdate(ByVal Record As SIS.TA.taBDFare) As SIS.TA.taBDFare
      Dim _Rec As SIS.TA.taBDFare = SIS.TA.taBDFare.taBDFareGetByID(Record.TABillNo, Record.SerialNo)
      With _Rec
        .City1ID = Record.City1ID
        .City1Text = Record.City1Text
        .City2ID = Record.City2ID
        .City2Text = Record.City2Text
        .Date1Time = Record.Date1Time
        .Date2Time = Record.Date2Time
        .ModeTravelID = Record.ModeTravelID
        .ModeText = Record.ModeText
        .AmountFactor = Record.AmountFactor
        .Remarks = Record.Remarks
        .OOERemarks = Record.OOERemarks
        .ProjectID = Record.ProjectID
        .OOEReasonID = Record.OOEReasonID
        .PassedAmountFactor = Record.PassedAmountFactor
        .AmountBasic = Record.AmountBasic
        .AmountTax = Record.AmountTax
        .AmountTotal = Record.AmountTotal
        .AmountRate = Record.AmountRate
        .ModeFinanceID = Record.ModeFinanceID
        .PassedAmountTotal = Record.PassedAmountTotal
        .ComponentID = Record.ComponentID
        .SystemText = Record.SystemText
        .ApprovalRemarks = Record.ApprovalRemarks
        .Setteled = Record.Setteled
        .AmountInINR = Record.AmountInINR
        .BillAttached = Record.BillAttached
        .PassedAmountRate = Record.PassedAmountRate
        .PassedAmountTax = Record.PassedAmountTax
        .AirportToHotel = Record.AirportToHotel
        .AccountsRemarks = Record.AccountsRemarks
        .CostCenterID = Record.CostCenterID
        .PassedAmountBasic = Record.PassedAmountBasic
        .PassedAmountInINR = Record.PassedAmountInINR
        .ApprovedOn = Record.ApprovedOn
        .ConversionFactorINR = Record.ConversionFactorINR
        .SanctionFileName = Record.SanctionFileName
        .StayedInHotel = Record.StayedInHotel
        .BillDiskFile = Record.BillDiskFile
        .OOEBySystem = Record.OOEBySystem
        .LodgingProvided = Record.LodgingProvided
        .AirportToClientLocation = Record.AirportToClientLocation
        .SanctionDiskFile = Record.SanctionDiskFile
        .NotStayedAnyWhere = Record.NotStayedAnyWhere
        .StayedInGuestHouse = Record.StayedInGuestHouse
        .StayedWithRelative = Record.StayedWithRelative
        .ModeExpenseID = Record.ModeExpenseID
        .ApprovedBy = Record.ApprovedBy
        .OOEByAccounts = Record.OOEByAccounts
        .SanctionAttached = Record.SanctionAttached
        .AutoCalculated = Record.AutoCalculated
        .CurrencyID = Record.CurrencyID
        .StayedAtSite = Record.StayedAtSite
        .ApprovalWFTypeID = Record.ApprovalWFTypeID
        .TourExtended = Record.TourExtended
        .BillFileName = Record.BillFileName
        .CityTypeID = Record.CityTypeID
        .ModeLCID = Record.ModeLCID
        .BoardingProvided = Record.BoardingProvided
        .HotelToAirport = Record.HotelToAirport
      End With
      Return SIS.TA.taBDFare.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
