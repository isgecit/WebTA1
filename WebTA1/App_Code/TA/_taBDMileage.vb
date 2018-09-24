Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taBDMileage
    Inherits SIS.TA.taBillDetails
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBDMileageGetNewRecord() As SIS.TA.taBDMileage
      Return New SIS.TA.taBDMileage()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBDMileageSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taBDMileage)
      Dim Results As List(Of SIS.TA.taBDMileage) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaBDMileageSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaBDMileageSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo",SqlDbType.Int,10, IIf(TABillNo = Nothing, 0,TABillNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ComponentID",SqlDbType.Int,10, TAComponentTypes.Mileage)
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
    Public Shared Function taBDMileageSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBDMileageGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32) As SIS.TA.taBDMileage
      Dim Results As SIS.TA.taBDMileage = Nothing
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
            Results = New SIS.TA.taBDMileage(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBDMileageGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32, ByVal Filter_TABillNo As Int32) As SIS.TA.taBDMileage
      Dim Results As SIS.TA.taBDMileage = SIS.TA.taBDMileage.taBDMileageGetByID(TABillNo, SerialNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function taBDMileageInsert(ByVal Record As SIS.TA.taBDMileage) As SIS.TA.taBDMileage
      Dim _Rec As SIS.TA.taBDMileage = SIS.TA.taBDMileage.taBDMileageGetNewRecord()
      With _Rec
        .TABillNo = Record.TABillNo
        .City1ID = Record.City1ID
        .City1Text = Record.City1Text
        .City2ID = Record.City2ID
        .City2Text = Record.City2Text
        .Date1Time = Record.Date1Time
        .Date2Time = Record.Date2Time
        .AmountFactor = Record.AmountFactor
        .Remarks = Record.Remarks
        .ApprovalWFTypeID = Record.ApprovalWFTypeID
        .OOEReasonID = Record.OOEReasonID
        .PassedAmountTotal = Record.PassedAmountTotal
        .AccountsRemarks = Record.AccountsRemarks
        .AmountInINR = Record.AmountInINR
        .OOERemarks = Record.OOERemarks
        .AutoCalculated = Record.AutoCalculated
        .AmountBasic = Record.AmountBasic
        .ConversionFactorINR = Record.ConversionFactorINR
        .ComponentID = Record.ComponentID
        .SystemText = Record.SystemText
        .AmountTotal = Record.AmountTotal
        .ApprovedBy = Record.ApprovedBy
        .NotStayedAnyWhere = Record.NotStayedAnyWhere
        .ModeExpenseID = Record.ModeExpenseID
        .CostCenterID = Record.CostCenterID
        .BillFileName = Record.BillFileName
        .PassedAmountRate = Record.PassedAmountRate
        .PassedAmountBasic = Record.PassedAmountBasic
        .ApprovalRemarks = Record.ApprovalRemarks
        .AmountTax = Record.AmountTax
        .PassedAmountTax = Record.PassedAmountTax
        .BoardingProvided = Record.BoardingProvided
        .PassedAmountInINR = Record.PassedAmountInINR
        .ApprovedOn = Record.ApprovedOn
        .SanctionDiskFile = Record.SanctionDiskFile
        .StayedAtSite = Record.StayedAtSite
        .StayedInGuestHouse = Record.StayedInGuestHouse
        .ModeLCID = Record.ModeLCID
        .SanctionAttached = Record.SanctionAttached
        .HotelToAirport = Record.HotelToAirport
        .LodgingProvided = Record.LodgingProvided
        .StayedInHotel = Record.StayedInHotel
        .BillAttached = Record.BillAttached
        .SanctionFileName = Record.SanctionFileName
        .OOEBySystem = Record.OOEBySystem
        .ModeTravelID = Record.ModeTravelID
        .AirportToClientLocation = Record.AirportToClientLocation
        .StayedWithRelative = Record.StayedWithRelative
        .PassedAmountFactor = Record.PassedAmountFactor
        .ModeText = Record.ModeText
        .BillDiskFile = Record.BillDiskFile
        .AmountRate = Record.AmountRate
        .ProjectID = Record.ProjectID
        .CurrencyID = Record.CurrencyID
        .AirportToHotel = Record.AirportToHotel
        .OOEByAccounts = Record.OOEByAccounts
        .TourExtended = Record.TourExtended
        .Setteled = Record.Setteled
        .ModeFinanceID = Record.ModeFinanceID
        .CityTypeID = Record.CityTypeID
      End With
      Return SIS.TA.taBDMileage.InsertData(_Rec)
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taBDMileageUpdate(ByVal Record As SIS.TA.taBDMileage) As SIS.TA.taBDMileage
      Dim _Rec As SIS.TA.taBDMileage = SIS.TA.taBDMileage.taBDMileageGetByID(Record.TABillNo, Record.SerialNo)
      With _Rec
        .City1ID = Record.City1ID
        .City1Text = Record.City1Text
        .City2ID = Record.City2ID
        .City2Text = Record.City2Text
        .Date1Time = Record.Date1Time
        .Date2Time = Record.Date2Time
        .AmountFactor = Record.AmountFactor
        .Remarks = Record.Remarks
        .ApprovalWFTypeID = Record.ApprovalWFTypeID
        .OOEReasonID = Record.OOEReasonID
        .PassedAmountTotal = Record.PassedAmountTotal
        .AccountsRemarks = Record.AccountsRemarks
        .AmountInINR = Record.AmountInINR
        .OOERemarks = Record.OOERemarks
        .AutoCalculated = Record.AutoCalculated
        .AmountBasic = Record.AmountBasic
        .ConversionFactorINR = Record.ConversionFactorINR
        .ComponentID = Record.ComponentID
        .SystemText = Record.SystemText
        .AmountTotal = Record.AmountTotal
        .ApprovedBy = Record.ApprovedBy
        .NotStayedAnyWhere = Record.NotStayedAnyWhere
        .ModeExpenseID = Record.ModeExpenseID
        .CostCenterID = Record.CostCenterID
        .BillFileName = Record.BillFileName
        .PassedAmountRate = Record.PassedAmountRate
        .PassedAmountBasic = Record.PassedAmountBasic
        .ApprovalRemarks = Record.ApprovalRemarks
        .AmountTax = Record.AmountTax
        .PassedAmountTax = Record.PassedAmountTax
        .BoardingProvided = Record.BoardingProvided
        .PassedAmountInINR = Record.PassedAmountInINR
        .ApprovedOn = Record.ApprovedOn
        .SanctionDiskFile = Record.SanctionDiskFile
        .StayedAtSite = Record.StayedAtSite
        .StayedInGuestHouse = Record.StayedInGuestHouse
        .ModeLCID = Record.ModeLCID
        .SanctionAttached = Record.SanctionAttached
        .HotelToAirport = Record.HotelToAirport
        .LodgingProvided = Record.LodgingProvided
        .StayedInHotel = Record.StayedInHotel
        .BillAttached = Record.BillAttached
        .SanctionFileName = Record.SanctionFileName
        .OOEBySystem = Record.OOEBySystem
        .ModeTravelID = Record.ModeTravelID
        .AirportToClientLocation = Record.AirportToClientLocation
        .StayedWithRelative = Record.StayedWithRelative
        .PassedAmountFactor = Record.PassedAmountFactor
        .ModeText = Record.ModeText
        .BillDiskFile = Record.BillDiskFile
        .AmountRate = Record.AmountRate
        .ProjectID = Record.ProjectID
        .CurrencyID = Record.CurrencyID
        .AirportToHotel = Record.AirportToHotel
        .OOEByAccounts = Record.OOEByAccounts
        .TourExtended = Record.TourExtended
        .Setteled = Record.Setteled
        .ModeFinanceID = Record.ModeFinanceID
        .CityTypeID = Record.CityTypeID
      End With
      Return SIS.TA.taBDMileage.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
