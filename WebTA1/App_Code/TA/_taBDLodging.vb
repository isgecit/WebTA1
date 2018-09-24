Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taBDLodging
    Inherits SIS.TA.taBillDetails
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBDLodgingGetNewRecord() As SIS.TA.taBDLodging
      Return New SIS.TA.taBDLodging()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBDLodgingSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taBDLodging)
      Dim Results As List(Of SIS.TA.taBDLodging) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaBDLodgingSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaBDLodgingSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo",SqlDbType.Int,10, IIf(TABillNo = Nothing, 0,TABillNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ComponentID",SqlDbType.Int,10, TAComponentTypes.Lodging)
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
    Public Shared Function taBDLodgingSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBDLodgingGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32) As SIS.TA.taBDLodging
      Dim Results As SIS.TA.taBDLodging = Nothing
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
            Results = New SIS.TA.taBDLodging(Reader)
            Try
              Results = SIS.TA.taBDLodging.UpdateGSTDataInBDL(Results)
            Catch ex As Exception
            End Try
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBDLodgingGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32, ByVal Filter_TABillNo As Int32) As SIS.TA.taBDLodging
      Dim Results As SIS.TA.taBDLodging = SIS.TA.taBDLodging.taBDLodgingGetByID(TABillNo, SerialNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function taBDLodgingInsert(ByVal Record As SIS.TA.taBDLodging) As SIS.TA.taBDLodging
      Dim _Rec As SIS.TA.taBDLodging = SIS.TA.taBDLodging.taBDLodgingGetNewRecord()
      With _Rec
        .TABillNo = Record.TABillNo
        .City1ID = Record.City1ID
        .City1Text = Record.City1Text
        .Date1Time = Record.Date1Time
        .Date2Time = Record.Date2Time
        .ModeText = Record.ModeText
        .BoardingProvided = Record.BoardingProvided
        .LodgingProvided = Record.LodgingProvided
        .StayedWithRelative = Record.StayedWithRelative
        .StayedInHotel = Record.StayedInHotel
        .StayedAtSite = Record.StayedAtSite
        .StayedInGuestHouse = Record.StayedInGuestHouse
        .NotStayedAnyWhere = Record.NotStayedAnyWhere
        .AmountFactor = Record.AmountFactor
        .AmountRate = Record.AmountRate
        .AmountTax = Record.AmountTax
        .Remarks = Record.Remarks
        .Setteled = Record.Setteled
        .OOERemarks = Record.OOERemarks
        .AmountBasic = Record.AmountBasic
        .PassedAmountTax = Record.PassedAmountTax
        .CurrencyID = Record.CurrencyID
        .ComponentID = Record.ComponentID
        .SystemText = Record.SystemText
        .PassedAmountTotal = Record.PassedAmountTotal
        .AmountInINR = Record.AmountInINR
        .OOEReasonID = Record.OOEReasonID
        .CostCenterID = Record.CostCenterID
        .ApprovalRemarks = Record.ApprovalRemarks
        .SanctionFileName = Record.SanctionFileName
        .PassedAmountInINR = Record.PassedAmountInINR
        .BillFileName = Record.BillFileName
        .PassedAmountRate = Record.PassedAmountRate
        .ApprovedOn = Record.ApprovedOn
        .AccountsRemarks = Record.AccountsRemarks
        .PassedAmountFactor = Record.PassedAmountFactor
        .ProjectID = Record.ProjectID
        .PassedAmountBasic = Record.PassedAmountBasic
        .AmountTotal = Record.AmountTotal
        .BillAttached = Record.BillAttached
        .OOEBySystem = Record.OOEBySystem
        .AutoCalculated = Record.AutoCalculated
        .ModeExpenseID = Record.ModeExpenseID
        .City2ID = Record.City2ID
        .AirportToHotel = Record.AirportToHotel
        .HotelToAirport = Record.HotelToAirport
        .ModeLCID = Record.ModeLCID
        .City2Text = Record.City2Text
        .TourExtended = Record.TourExtended
        .SanctionDiskFile = Record.SanctionDiskFile
        .SanctionAttached = Record.SanctionAttached
        .ConversionFactorINR = Record.ConversionFactorINR
        .AirportToClientLocation = Record.AirportToClientLocation
        .BillDiskFile = Record.BillDiskFile
        .ModeFinanceID = Record.ModeFinanceID
        .ModeTravelID = Record.ModeTravelID
        .CityTypeID = Record.CityTypeID
        .ApprovedBy = Record.ApprovedBy
        .ApprovalWFTypeID = Record.ApprovalWFTypeID
        .OOEByAccounts = Record.OOEByAccounts
      End With
      Return SIS.TA.taBDLodging.InsertData(_Rec)
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taBDLodgingUpdate(ByVal Record As SIS.TA.taBDLodging) As SIS.TA.taBDLodging
      Dim _Rec As SIS.TA.taBDLodging = SIS.TA.taBDLodging.taBDLodgingGetByID(Record.TABillNo, Record.SerialNo)
      With _Rec
        .City1ID = Record.City1ID
        .City1Text = Record.City1Text
        .Date1Time = Record.Date1Time
        .Date2Time = Record.Date2Time
        .ModeText = Record.ModeText
        .BoardingProvided = Record.BoardingProvided
        .LodgingProvided = Record.LodgingProvided
        .StayedWithRelative = Record.StayedWithRelative
        .StayedInHotel = Record.StayedInHotel
        .StayedAtSite = Record.StayedAtSite
        .StayedInGuestHouse = Record.StayedInGuestHouse
        .NotStayedAnyWhere = Record.NotStayedAnyWhere
        .AmountFactor = Record.AmountFactor
        .AmountRate = Record.AmountRate
        .AmountTax = Record.AmountTax
        .Remarks = Record.Remarks
        .Setteled = Record.Setteled
        .OOERemarks = Record.OOERemarks
        .AmountBasic = Record.AmountBasic
        .PassedAmountTax = Record.PassedAmountTax
        .CurrencyID = Record.CurrencyID
        .ComponentID = Record.ComponentID
        .SystemText = Record.SystemText
        .PassedAmountTotal = Record.PassedAmountTotal
        .AmountInINR = Record.AmountInINR
        .OOEReasonID = Record.OOEReasonID
        .CostCenterID = Record.CostCenterID
        .ApprovalRemarks = Record.ApprovalRemarks
        .SanctionFileName = Record.SanctionFileName
        .PassedAmountInINR = Record.PassedAmountInINR
        .BillFileName = Record.BillFileName
        .PassedAmountRate = Record.PassedAmountRate
        .ApprovedOn = Record.ApprovedOn
        .AccountsRemarks = Record.AccountsRemarks
        .PassedAmountFactor = Record.PassedAmountFactor
        .ProjectID = Record.ProjectID
        .PassedAmountBasic = Record.PassedAmountBasic
        .AmountTotal = Record.AmountTotal
        .BillAttached = Record.BillAttached
        .OOEBySystem = Record.OOEBySystem
        .AutoCalculated = Record.AutoCalculated
        .ModeExpenseID = Record.ModeExpenseID
        .City2ID = Record.City2ID
        .AirportToHotel = Record.AirportToHotel
        .HotelToAirport = Record.HotelToAirport
        .ModeLCID = Record.ModeLCID
        .City2Text = Record.City2Text
        .TourExtended = Record.TourExtended
        .SanctionDiskFile = Record.SanctionDiskFile
        .SanctionAttached = Record.SanctionAttached
        .ConversionFactorINR = Record.ConversionFactorINR
        .AirportToClientLocation = Record.AirportToClientLocation
        .BillDiskFile = Record.BillDiskFile
        .ModeFinanceID = Record.ModeFinanceID
        .ModeTravelID = Record.ModeTravelID
        .CityTypeID = Record.CityTypeID
        .ApprovedBy = Record.ApprovedBy
        .ApprovalWFTypeID = Record.ApprovalWFTypeID
        .OOEByAccounts = Record.OOEByAccounts
      End With
      Return SIS.TA.taBDLodging.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
