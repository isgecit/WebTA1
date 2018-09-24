Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taCDExpense
    Inherits SIS.TA.taBillDetails
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCDExpenseGetNewRecord() As SIS.TA.taCDExpense
      Return New SIS.TA.taCDExpense()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCDExpenseSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taCDExpense)
      Dim Results As List(Of SIS.TA.taCDExpense) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaCDExpenseSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaCDExpenseSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo",SqlDbType.Int,10, IIf(TABillNo = Nothing, 0,TABillNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ComponentID",SqlDbType.Int,10, TAComponentTypes.Expense)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.TA.taCDExpense)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taCDExpense(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taCDExpenseSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCDExpenseGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32) As SIS.TA.taCDExpense
      Dim Results As SIS.TA.taCDExpense = Nothing
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
            Results = New SIS.TA.taCDExpense(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCDExpenseGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32, ByVal Filter_TABillNo As Int32) As SIS.TA.taCDExpense
      Dim Results As SIS.TA.taCDExpense = SIS.TA.taCDExpense.taCDExpenseGetByID(TABillNo, SerialNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function taCDExpenseInsert(ByVal Record As SIS.TA.taCDExpense) As SIS.TA.taCDExpense
      Dim _Rec As SIS.TA.taCDExpense = SIS.TA.taCDExpense.taCDExpenseGetNewRecord()
      With _Rec
        .TABillNo = Record.TABillNo
        .Date1Time = Record.Date1Time
        .ModeExpenseID = Record.ModeExpenseID
        .ModeText = Record.ModeText
        .AmountFactor = Record.AmountFactor
        .Remarks = Record.Remarks
        .CostCenterID = Record.CostCenterID
        .ProjectID = Record.ProjectID
        .AmountRate = Record.AmountRate
        .AmountBasic = Record.AmountBasic
        .AmountTax = Record.AmountTax
        .AmountTotal = Record.AmountTotal
        .CurrencyID = Record.CurrencyID
        .ConversionFactorINR = Record.ConversionFactorINR
        .AmountInINR = Record.AmountInINR
        .OOERemarks = Record.OOERemarks
        .ApprovalWFTypeID = Record.ApprovalWFTypeID
        .OOEReasonID = Record.OOEReasonID
        .PassedAmountFactor = Record.PassedAmountFactor
        .PassedAmountRate = Record.PassedAmountRate
        .PassedAmountBasic = Record.PassedAmountBasic
        .PassedAmountTax = Record.PassedAmountTax
        .PassedAmountTotal = Record.PassedAmountTotal
        .PassedAmountInINR = Record.PassedAmountInINR
        .AccountsRemarks = Record.AccountsRemarks
        .Setteled = Record.Setteled
        .ApprovedBy = Record.ApprovedBy
        .ApprovedOn = Record.ApprovedOn
        .ApprovalRemarks = Record.ApprovalRemarks
        .AirportToHotel = Record.AirportToHotel
        .AutoCalculated = Record.AutoCalculated
        .BillFileName = Record.BillFileName
        .StayedWithRelative = Record.StayedWithRelative
        .StayedAtSite = Record.StayedAtSite
        .ModeTravelID = Record.ModeTravelID
        .StayedInHotel = Record.StayedInHotel
        .City1Text = Record.City1Text
        .BillAttached = Record.BillAttached
        .CityTypeID = Record.CityTypeID
        .OOEBySystem = Record.OOEBySystem
        .SanctionDiskFile = Record.SanctionDiskFile
        .City2Text = Record.City2Text
        .City1ID = Record.City1ID
        .SanctionAttached = Record.SanctionAttached
        .HotelToAirport = Record.HotelToAirport
        .ModeLCID = Record.ModeLCID
        .AirportToClientLocation = Record.AirportToClientLocation
        .StayedInGuestHouse = Record.StayedInGuestHouse
        .LodgingProvided = Record.LodgingProvided
        .ModeFinanceID = Record.ModeFinanceID
        .City2ID = Record.City2ID
        .OOEByAccounts = Record.OOEByAccounts
        .SanctionFileName = Record.SanctionFileName
        .BillDiskFile = Record.BillDiskFile
        .SystemText = Record.SystemText
        .BoardingProvided = Record.BoardingProvided
        .Date2Time = Record.Date2Time
        .TourExtended = Record.TourExtended
        .ComponentID = Record.ComponentID
        .NotStayedAnyWhere = Record.NotStayedAnyWhere
      End With
      Return SIS.TA.taCDExpense.InsertData(_Rec)
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taCDExpenseUpdate(ByVal Record As SIS.TA.taCDExpense) As SIS.TA.taCDExpense
      Dim _Rec As SIS.TA.taCDExpense = SIS.TA.taCDExpense.taCDExpenseGetByID(Record.TABillNo, Record.SerialNo)
      With _Rec
        .Date1Time = Record.Date1Time
        .ModeExpenseID = Record.ModeExpenseID
        .ModeText = Record.ModeText
        .AmountFactor = Record.AmountFactor
        .Remarks = Record.Remarks
        .CostCenterID = Record.CostCenterID
        .ProjectID = Record.ProjectID
        .AmountRate = Record.AmountRate
        .AmountBasic = Record.AmountBasic
        .AmountTax = Record.AmountTax
        .AmountTotal = Record.AmountTotal
        .CurrencyID = Record.CurrencyID
        .ConversionFactorINR = Record.ConversionFactorINR
        .AmountInINR = Record.AmountInINR
        .OOERemarks = Record.OOERemarks
        .ApprovalWFTypeID = Record.ApprovalWFTypeID
        .OOEReasonID = Record.OOEReasonID
        .PassedAmountFactor = Record.PassedAmountFactor
        .PassedAmountRate = Record.PassedAmountRate
        .PassedAmountBasic = Record.PassedAmountBasic
        .PassedAmountTax = Record.PassedAmountTax
        .PassedAmountTotal = Record.PassedAmountTotal
        .PassedAmountInINR = Record.PassedAmountInINR
        .AccountsRemarks = Record.AccountsRemarks
        .Setteled = Record.Setteled
        .ApprovedBy = Record.ApprovedBy
        .ApprovedOn = Record.ApprovedOn
        .ApprovalRemarks = Record.ApprovalRemarks
        .AirportToHotel = Record.AirportToHotel
        .AutoCalculated = Record.AutoCalculated
        .BillFileName = Record.BillFileName
        .StayedWithRelative = Record.StayedWithRelative
        .StayedAtSite = Record.StayedAtSite
        .ModeTravelID = Record.ModeTravelID
        .StayedInHotel = Record.StayedInHotel
        .City1Text = Record.City1Text
        .BillAttached = Record.BillAttached
        .CityTypeID = Record.CityTypeID
        .OOEBySystem = Record.OOEBySystem
        .SanctionDiskFile = Record.SanctionDiskFile
        .City2Text = Record.City2Text
        .City1ID = Record.City1ID
        .SanctionAttached = Record.SanctionAttached
        .HotelToAirport = Record.HotelToAirport
        .ModeLCID = Record.ModeLCID
        .AirportToClientLocation = Record.AirportToClientLocation
        .StayedInGuestHouse = Record.StayedInGuestHouse
        .LodgingProvided = Record.LodgingProvided
        .ModeFinanceID = Record.ModeFinanceID
        .City2ID = Record.City2ID
        .OOEByAccounts = Record.OOEByAccounts
        .SanctionFileName = Record.SanctionFileName
        .BillDiskFile = Record.BillDiskFile
        .SystemText = Record.SystemText
        .BoardingProvided = Record.BoardingProvided
        .Date2Time = Record.Date2Time
        .TourExtended = Record.TourExtended
        .ComponentID = Record.ComponentID
        .NotStayedAnyWhere = Record.NotStayedAnyWhere
      End With
      Return SIS.TA.taCDExpense.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
