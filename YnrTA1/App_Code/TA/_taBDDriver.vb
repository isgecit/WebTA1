Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taBDDriver
    Inherits SIS.TA.taBillDetails
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBDDriverGetNewRecord() As SIS.TA.taBDDriver
      Return New SIS.TA.taBDDriver()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBDDriverSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taBDDriver)
      Dim Results As List(Of SIS.TA.taBDDriver) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaBDDriverSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaBDDriverSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo",SqlDbType.Int,10, IIf(TABillNo = Nothing, 0,TABillNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ComponentID",SqlDbType.Int,10, TAComponentTypes.Driver)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.TA.taBDDriver)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBDDriver(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taBDDriverSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBDDriverGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32) As SIS.TA.taBDDriver
      Dim Results As SIS.TA.taBDDriver = Nothing
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
            Results = New SIS.TA.taBDDriver(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBDDriverGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32, ByVal Filter_TABillNo As Int32) As SIS.TA.taBDDriver
      Dim Results As SIS.TA.taBDDriver = SIS.TA.taBDDriver.taBDDriverGetByID(TABillNo, SerialNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function taBDDriverInsert(ByVal Record As SIS.TA.taBDDriver) As SIS.TA.taBDDriver
      Dim _Rec As SIS.TA.taBDDriver = SIS.TA.taBDDriver.taBDDriverGetNewRecord()
      With _Rec
        .ComponentID = Record.ComponentID
        .SystemText = Record.SystemText
        .AmountTotal = Record.AmountTotal
        .PassedAmountTotal = Record.PassedAmountTotal
        .Remarks = Record.Remarks
        .AmountFactor = Record.AmountFactor
        .City1ID = Record.City1ID
        .Date2Time = Record.Date2Time
        .AmountRate = Record.AmountRate
        .TABillNo = Record.TABillNo
        .ProjectID = Record.ProjectID
        .ApprovalWFTypeID = Record.ApprovalWFTypeID
        .LodgingProvided = Record.LodgingProvided
        .PassedAmountBasic = Record.PassedAmountBasic
        .ConversionFactorINR = Record.ConversionFactorINR
        .SanctionAttached = Record.SanctionAttached
        .AmountBasic = Record.AmountBasic
        .NotStayedAnyWhere = Record.NotStayedAnyWhere
        .OOEReasonID = Record.OOEReasonID
        .ApprovedBy = Record.ApprovedBy
        .AccountsRemarks = Record.AccountsRemarks
        .PassedAmountFactor = Record.PassedAmountFactor
        .AirportToHotel = Record.AirportToHotel
        .PassedAmountInINR = Record.PassedAmountInINR
        .City2ID = Record.City2ID
        .AmountTax = Record.AmountTax
        .AmountInINR = Record.AmountInINR
        .ApprovalRemarks = Record.ApprovalRemarks
        .PassedAmountTax = Record.PassedAmountTax
        .ApprovedOn = Record.ApprovedOn
        .HotelToAirport = Record.HotelToAirport
        .PassedAmountRate = Record.PassedAmountRate
        .BillDiskFile = Record.BillDiskFile
        .BoardingProvided = Record.BoardingProvided
        .TourExtended = Record.TourExtended
        .City2Text = Record.City2Text
        .SanctionFileName = Record.SanctionFileName
        .StayedInHotel = Record.StayedInHotel
        .BillAttached = Record.BillAttached
        .SanctionDiskFile = Record.SanctionDiskFile
        .OOERemarks = Record.OOERemarks
        .Date1Time = Record.Date1Time
        .ModeTravelID = Record.ModeTravelID
        .OOEByAccounts = Record.OOEByAccounts
        .ModeExpenseID = Record.ModeExpenseID
        .AirportToClientLocation = Record.AirportToClientLocation
        .StayedWithRelative = Record.StayedWithRelative
        .StayedAtSite = Record.StayedAtSite
        .AutoCalculated = Record.AutoCalculated
        .CityTypeID = Record.CityTypeID
        .CurrencyID = Record.CurrencyID
        .CostCenterID = Record.CostCenterID
        .BillFileName = Record.BillFileName
        .StayedInGuestHouse = Record.StayedInGuestHouse
        .ModeLCID = Record.ModeLCID
        .ModeFinanceID = Record.ModeFinanceID
        .Setteled = Record.Setteled
        .ModeText = Record.ModeText
        .City1Text = Record.City1Text
        .OOEBySystem = Record.OOEBySystem
      End With
      Return SIS.TA.taBDDriver.InsertData(_Rec)
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taBDDriverUpdate(ByVal Record As SIS.TA.taBDDriver) As SIS.TA.taBDDriver
      Dim _Rec As SIS.TA.taBDDriver = SIS.TA.taBDDriver.taBDDriverGetByID(Record.TABillNo, Record.SerialNo)
      With _Rec
        .ComponentID = Record.ComponentID
        .SystemText = Record.SystemText
        .AmountTotal = Record.AmountTotal
        .PassedAmountTotal = Record.PassedAmountTotal
        .Remarks = Record.Remarks
        .AmountFactor = Record.AmountFactor
        .City1ID = Record.City1ID
        .Date2Time = Record.Date2Time
        .AmountRate = Record.AmountRate
        .ProjectID = Record.ProjectID
        .ApprovalWFTypeID = Record.ApprovalWFTypeID
        .LodgingProvided = Record.LodgingProvided
        .PassedAmountBasic = Record.PassedAmountBasic
        .ConversionFactorINR = Record.ConversionFactorINR
        .SanctionAttached = Record.SanctionAttached
        .AmountBasic = Record.AmountBasic
        .NotStayedAnyWhere = Record.NotStayedAnyWhere
        .OOEReasonID = Record.OOEReasonID
        .ApprovedBy = Record.ApprovedBy
        .AccountsRemarks = Record.AccountsRemarks
        .PassedAmountFactor = Record.PassedAmountFactor
        .AirportToHotel = Record.AirportToHotel
        .PassedAmountInINR = Record.PassedAmountInINR
        .City2ID = Record.City2ID
        .AmountTax = Record.AmountTax
        .AmountInINR = Record.AmountInINR
        .ApprovalRemarks = Record.ApprovalRemarks
        .PassedAmountTax = Record.PassedAmountTax
        .ApprovedOn = Record.ApprovedOn
        .HotelToAirport = Record.HotelToAirport
        .PassedAmountRate = Record.PassedAmountRate
        .BillDiskFile = Record.BillDiskFile
        .BoardingProvided = Record.BoardingProvided
        .TourExtended = Record.TourExtended
        .City2Text = Record.City2Text
        .SanctionFileName = Record.SanctionFileName
        .StayedInHotel = Record.StayedInHotel
        .BillAttached = Record.BillAttached
        .SanctionDiskFile = Record.SanctionDiskFile
        .OOERemarks = Record.OOERemarks
        .Date1Time = Record.Date1Time
        .ModeTravelID = Record.ModeTravelID
        .OOEByAccounts = Record.OOEByAccounts
        .ModeExpenseID = Record.ModeExpenseID
        .AirportToClientLocation = Record.AirportToClientLocation
        .StayedWithRelative = Record.StayedWithRelative
        .StayedAtSite = Record.StayedAtSite
        .AutoCalculated = Record.AutoCalculated
        .CityTypeID = Record.CityTypeID
        .CurrencyID = Record.CurrencyID
        .CostCenterID = Record.CostCenterID
        .BillFileName = Record.BillFileName
        .StayedInGuestHouse = Record.StayedInGuestHouse
        .ModeLCID = Record.ModeLCID
        .ModeFinanceID = Record.ModeFinanceID
        .Setteled = Record.Setteled
        .ModeText = Record.ModeText
        .City1Text = Record.City1Text
        .OOEBySystem = Record.OOEBySystem
      End With
      Return SIS.TA.taBDDriver.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
