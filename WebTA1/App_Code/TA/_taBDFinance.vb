Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taBDFinance
    Inherits SIS.TA.taBillDetails
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBDFinanceGetNewRecord() As SIS.TA.taBDFinance
      Return New SIS.TA.taBDFinance()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBDFinanceSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taBDFinance)
      Dim Results As List(Of SIS.TA.taBDFinance) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaBDFinanceSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaBDFinanceSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo",SqlDbType.Int,10, IIf(TABillNo = Nothing, 0,TABillNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ComponentID",SqlDbType.Int,10, TAComponentTypes.Finance)
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
    Public Shared Function taBDFinanceSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBDFinanceGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32) As SIS.TA.taBDFinance
      Dim Results As SIS.TA.taBDFinance = Nothing
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
            Results = New SIS.TA.taBDFinance(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBDFinanceGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32, ByVal Filter_TABillNo As Int32) As SIS.TA.taBDFinance
      Dim Results As SIS.TA.taBDFinance = SIS.TA.taBDFinance.taBDFinanceGetByID(TABillNo, SerialNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function taBDFinanceInsert(ByVal Record As SIS.TA.taBDFinance) As SIS.TA.taBDFinance
      Dim _Rec As SIS.TA.taBDFinance = SIS.TA.taBDFinance.taBDFinanceGetNewRecord()
      With _Rec
        .TABillNo = Record.TABillNo
        .Date1Time = Record.Date1Time
        .ModeFinanceID = Record.ModeFinanceID
        .ModeText = Record.ModeText
        .AmountFactor = Record.AmountFactor
        .Remarks = Record.Remarks
        .ProjectID = Record.ProjectID
        .PassedAmountTotal = Record.PassedAmountTotal
        .ComponentID = Record.ComponentID
        .PassedAmountRate = Record.PassedAmountRate
        .OOERemarks = Record.OOERemarks
        .CurrencyID = Record.CurrencyID
        .SystemText = Record.SystemText
        .ApprovalWFTypeID = Record.ApprovalWFTypeID
        .OOEReasonID = Record.OOEReasonID
        .AmountInINR = Record.AmountInINR
        .AmountTotal = Record.AmountTotal
        .AmountRate = Record.AmountRate
        .HotelToAirport = Record.HotelToAirport
        .StayedAtSite = Record.StayedAtSite
        .PassedAmountTax = Record.PassedAmountTax
        .PassedAmountFactor = Record.PassedAmountFactor
        .AmountTax = Record.AmountTax
        .ApprovedOn = Record.ApprovedOn
        .PassedAmountInINR = Record.PassedAmountInINR
        .AccountsRemarks = Record.AccountsRemarks
        .PassedAmountBasic = Record.PassedAmountBasic
        .AirportToClientLocation = Record.AirportToClientLocation
        .AmountBasic = Record.AmountBasic
        .BoardingProvided = Record.BoardingProvided
        .ApprovedBy = Record.ApprovedBy
        .NotStayedAnyWhere = Record.NotStayedAnyWhere
        .ApprovalRemarks = Record.ApprovalRemarks
        .City2Text = Record.City2Text
        .ModeExpenseID = Record.ModeExpenseID
        .StayedWithRelative = Record.StayedWithRelative
        .SanctionFileName = Record.SanctionFileName
        .StayedInHotel = Record.StayedInHotel
        .BillAttached = Record.BillAttached
        .OOEBySystem = Record.OOEBySystem
        .City2ID = Record.City2ID
        .TourExtended = Record.TourExtended
        .Date2Time = Record.Date2Time
        .SanctionDiskFile = Record.SanctionDiskFile
        .SanctionAttached = Record.SanctionAttached
        .LodgingProvided = Record.LodgingProvided
        .StayedInGuestHouse = Record.StayedInGuestHouse
        .ModeTravelID = Record.ModeTravelID
        .AutoCalculated = Record.AutoCalculated
        .OOEByAccounts = Record.OOEByAccounts
        .CostCenterID = Record.CostCenterID
        .Setteled = Record.Setteled
        .ConversionFactorINR = Record.ConversionFactorINR
        .BillDiskFile = Record.BillDiskFile
        .City1Text = Record.City1Text
        .City1ID = Record.City1ID
        .ModeLCID = Record.ModeLCID
        .CityTypeID = Record.CityTypeID
        .BillFileName = Record.BillFileName
        .AirportToHotel = Record.AirportToHotel
      End With
      Return SIS.TA.taBDFinance.InsertData(_Rec)
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taBDFinanceUpdate(ByVal Record As SIS.TA.taBDFinance) As SIS.TA.taBDFinance
      Dim _Rec As SIS.TA.taBDFinance = SIS.TA.taBDFinance.taBDFinanceGetByID(Record.TABillNo, Record.SerialNo)
      With _Rec
        .Date1Time = Record.Date1Time
        .ModeFinanceID = Record.ModeFinanceID
        .ModeText = Record.ModeText
        .AmountFactor = Record.AmountFactor
        .Remarks = Record.Remarks
        .ProjectID = Record.ProjectID
        .PassedAmountTotal = Record.PassedAmountTotal
        .ComponentID = Record.ComponentID
        .PassedAmountRate = Record.PassedAmountRate
        .OOERemarks = Record.OOERemarks
        .CurrencyID = Record.CurrencyID
        .SystemText = Record.SystemText
        .ApprovalWFTypeID = Record.ApprovalWFTypeID
        .OOEReasonID = Record.OOEReasonID
        .AmountInINR = Record.AmountInINR
        .AmountTotal = Record.AmountTotal
        .AmountRate = Record.AmountRate
        .HotelToAirport = Record.HotelToAirport
        .StayedAtSite = Record.StayedAtSite
        .PassedAmountTax = Record.PassedAmountTax
        .PassedAmountFactor = Record.PassedAmountFactor
        .AmountTax = Record.AmountTax
        .ApprovedOn = Record.ApprovedOn
        .PassedAmountInINR = Record.PassedAmountInINR
        .AccountsRemarks = Record.AccountsRemarks
        .PassedAmountBasic = Record.PassedAmountBasic
        .AirportToClientLocation = Record.AirportToClientLocation
        .AmountBasic = Record.AmountBasic
        .BoardingProvided = Record.BoardingProvided
        .ApprovedBy = Record.ApprovedBy
        .NotStayedAnyWhere = Record.NotStayedAnyWhere
        .ApprovalRemarks = Record.ApprovalRemarks
        .City2Text = Record.City2Text
        .ModeExpenseID = Record.ModeExpenseID
        .StayedWithRelative = Record.StayedWithRelative
        .SanctionFileName = Record.SanctionFileName
        .StayedInHotel = Record.StayedInHotel
        .BillAttached = Record.BillAttached
        .OOEBySystem = Record.OOEBySystem
        .City2ID = Record.City2ID
        .TourExtended = Record.TourExtended
        .Date2Time = Record.Date2Time
        .SanctionDiskFile = Record.SanctionDiskFile
        .SanctionAttached = Record.SanctionAttached
        .LodgingProvided = Record.LodgingProvided
        .StayedInGuestHouse = Record.StayedInGuestHouse
        .ModeTravelID = Record.ModeTravelID
        .AutoCalculated = Record.AutoCalculated
        .OOEByAccounts = Record.OOEByAccounts
        .CostCenterID = Record.CostCenterID
        .Setteled = Record.Setteled
        .ConversionFactorINR = Record.ConversionFactorINR
        .BillDiskFile = Record.BillDiskFile
        .City1Text = Record.City1Text
        .City1ID = Record.City1ID
        .ModeLCID = Record.ModeLCID
        .CityTypeID = Record.CityTypeID
        .BillFileName = Record.BillFileName
        .AirportToHotel = Record.AirportToHotel
      End With
      Return SIS.TA.taBDFinance.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
