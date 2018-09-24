Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taCDAccounts
    Inherits SIS.TA.taBillDetails
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCDAccountsGetNewRecord() As SIS.TA.taCDAccounts
      Return New SIS.TA.taCDAccounts()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCDAccountsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taCDAccounts)
      Dim Results As List(Of SIS.TA.taCDAccounts) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaCDAccountsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaCDAccountsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo",SqlDbType.Int,10, IIf(TABillNo = Nothing, 0,TABillNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ComponentID",SqlDbType.Int,10, TAComponentTypes.AccountsEntry)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.TA.taCDAccounts)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taCDAccounts(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taCDAccountsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCDAccountsGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32) As SIS.TA.taCDAccounts
      Dim Results As SIS.TA.taCDAccounts = Nothing
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
            Results = New SIS.TA.taCDAccounts(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCDAccountsGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32, ByVal Filter_TABillNo As Int32) As SIS.TA.taCDAccounts
      Dim Results As SIS.TA.taCDAccounts = SIS.TA.taCDAccounts.taCDAccountsGetByID(TABillNo, SerialNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function taCDAccountsInsert(ByVal Record As SIS.TA.taCDAccounts) As SIS.TA.taCDAccounts
      Dim _Rec As SIS.TA.taCDAccounts = SIS.TA.taCDAccounts.taCDAccountsGetNewRecord()
      With _Rec
        .Remarks = Record.Remarks
        .PassedAmountTotal = Record.PassedAmountTotal
        .ApprovedBy =  Global.System.Web.HttpContext.Current.Session("LoginID")
        .ApprovedOn = Now
        .City2ID = Record.City2ID
        .OOEBySystem = Record.OOEBySystem
        .BillFileName = Record.BillFileName
        .ModeTravelID = Record.ModeTravelID
        .PassedAmountTax = Record.PassedAmountTax
        .SanctionAttached = Record.SanctionAttached
        .AmountFactor = Record.AmountFactor
        .PassedAmountInINR = Record.PassedAmountInINR
        .OOERemarks = Record.OOERemarks
        .AirportToHotel = Record.AirportToHotel
        .SanctionDiskFile = Record.SanctionDiskFile
        .ModeLCID = Record.ModeLCID
        .ApprovalRemarks = Record.ApprovalRemarks
        .TourExtended = Record.TourExtended
        .SystemText = Record.SystemText
        .ModeExpenseID = Record.ModeExpenseID
        .NotStayedAnyWhere = Record.NotStayedAnyWhere
        .AirportToClientLocation = Record.AirportToClientLocation
        .ComponentID = Record.ComponentID
        .AutoCalculated = Record.AutoCalculated
        .City2Text = Record.City2Text
        .CityTypeID = Record.CityTypeID
        .BillAttached = Record.BillAttached
        .BillDiskFile = Record.BillDiskFile
        .OOEByAccounts = Record.OOEByAccounts
        .City1ID = Record.City1ID
        .AccountsRemarks = Record.AccountsRemarks
        .HotelToAirport = Record.HotelToAirport
        .StayedInGuestHouse = Record.StayedInGuestHouse
        .AmountInINR = Record.AmountInINR
        .AmountTotal = Record.AmountTotal
        .StayedWithRelative = Record.StayedWithRelative
        .OOEReasonID = Record.OOEReasonID
        .LodgingProvided = Record.LodgingProvided
        .BoardingProvided = Record.BoardingProvided
        .CurrencyID = Record.CurrencyID
        .AmountRate = Record.AmountRate
        .TABillNo = Record.TABillNo
        .ConversionFactorINR = Record.ConversionFactorINR
        .ProjectID = Record.ProjectID
        .CostCenterID = Record.CostCenterID
        .CurrencyMain = Record.CurrencyMain
        .Setteled = Record.Setteled
        .SanctionFileName = Record.SanctionFileName
        .AmountTax = Record.AmountTax
        .AmountBasic = Record.AmountBasic
        .ApprovalWFTypeID = Record.ApprovalWFTypeID
        .PassedAmountRate = Record.PassedAmountRate
        .ModeFinanceID = Record.ModeFinanceID
        .PassedAmountBasic = Record.PassedAmountBasic
        .StayedAtSite = Record.StayedAtSite
        .StayedInHotel = Record.StayedInHotel
        .ModeText = Record.ModeText
        .Date1Time = Record.Date1Time
        .PassedAmountFactor = Record.PassedAmountFactor
        .Date2Time = Record.Date2Time
        .City1Text = Record.City1Text
      End With
      Return SIS.TA.taCDAccounts.InsertData(_Rec)
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taCDAccountsUpdate(ByVal Record As SIS.TA.taCDAccounts) As SIS.TA.taCDAccounts
      Dim _Rec As SIS.TA.taCDAccounts = SIS.TA.taCDAccounts.taCDAccountsGetByID(Record.TABillNo, Record.SerialNo)
      With _Rec
        .Remarks = Record.Remarks
        .PassedAmountTotal = Record.PassedAmountTotal
        .ApprovedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .ApprovedOn = Now
        .City2ID = Record.City2ID
        .OOEBySystem = Record.OOEBySystem
        .BillFileName = Record.BillFileName
        .ModeTravelID = Record.ModeTravelID
        .PassedAmountTax = Record.PassedAmountTax
        .SanctionAttached = Record.SanctionAttached
        .AmountFactor = Record.AmountFactor
        .PassedAmountInINR = Record.PassedAmountInINR
        .OOERemarks = Record.OOERemarks
        .AirportToHotel = Record.AirportToHotel
        .SanctionDiskFile = Record.SanctionDiskFile
        .ModeLCID = Record.ModeLCID
        .ApprovalRemarks = Record.ApprovalRemarks
        .TourExtended = Record.TourExtended
        .SystemText = Record.SystemText
        .ModeExpenseID = Record.ModeExpenseID
        .NotStayedAnyWhere = Record.NotStayedAnyWhere
        .AirportToClientLocation = Record.AirportToClientLocation
        .ComponentID = Record.ComponentID
        .AutoCalculated = Record.AutoCalculated
        .City2Text = Record.City2Text
        .CityTypeID = Record.CityTypeID
        .BillAttached = Record.BillAttached
        .BillDiskFile = Record.BillDiskFile
        .OOEByAccounts = Record.OOEByAccounts
        .City1ID = Record.City1ID
        .AccountsRemarks = Record.AccountsRemarks
        .HotelToAirport = Record.HotelToAirport
        .StayedInGuestHouse = Record.StayedInGuestHouse
        .AmountInINR = Record.AmountInINR
        .AmountTotal = Record.AmountTotal
        .StayedWithRelative = Record.StayedWithRelative
        .OOEReasonID = Record.OOEReasonID
        .LodgingProvided = Record.LodgingProvided
        .BoardingProvided = Record.BoardingProvided
        .CurrencyID = Record.CurrencyID
        .AmountRate = Record.AmountRate
        .ConversionFactorINR = Record.ConversionFactorINR
        .ProjectID = Record.ProjectID
        .CostCenterID = Record.CostCenterID
        .CurrencyMain = Record.CurrencyMain
        .Setteled = Record.Setteled
        .SanctionFileName = Record.SanctionFileName
        .AmountTax = Record.AmountTax
        .AmountBasic = Record.AmountBasic
        .ApprovalWFTypeID = Record.ApprovalWFTypeID
        .PassedAmountRate = Record.PassedAmountRate
        .ModeFinanceID = Record.ModeFinanceID
        .PassedAmountBasic = Record.PassedAmountBasic
        .StayedAtSite = Record.StayedAtSite
        .StayedInHotel = Record.StayedInHotel
        .ModeText = Record.ModeText
        .Date1Time = Record.Date1Time
        .PassedAmountFactor = Record.PassedAmountFactor
        .Date2Time = Record.Date2Time
        .City1Text = Record.City1Text
      End With
      Return SIS.TA.taCDAccounts.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
