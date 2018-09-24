Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taBDExpense
    Inherits SIS.TA.taBillDetails
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBDExpenseGetNewRecord() As SIS.TA.taBDExpense
      Return New SIS.TA.taBDExpense()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBDExpenseSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taBDExpense)
      Dim Results As List(Of SIS.TA.taBDExpense) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaBDExpenseSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaBDExpenseSelectListFilteres"
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
          Results = New List(Of SIS.TA.taBDExpense)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBDExpense(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taBDExpenseSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBDExpenseGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32) As SIS.TA.taBDExpense
      Dim Results As SIS.TA.taBDExpense = Nothing
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
            Results = New SIS.TA.taBDExpense(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBDExpenseGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32, ByVal Filter_TABillNo As Int32) As SIS.TA.taBDExpense
      Dim Results As SIS.TA.taBDExpense = SIS.TA.taBDExpense.taBDExpenseGetByID(TABillNo, SerialNo)
      Return Results
    End Function
    '<DataObjectMethod(DataObjectMethodType.Insert, True)> _
    'Public Shared Function taBDExpenseInsert(ByVal Record As SIS.TA.taBDExpense) As SIS.TA.taBDExpense
    '  Dim _Rec As SIS.TA.taBDExpense = SIS.TA.taBDExpense.taBDExpenseGetNewRecord()
    '  With _Rec
    '    .TABillNo = Record.TABillNo
    '    .Date1Time = Record.Date1Time
    '    .ModeExpenseID = Record.ModeExpenseID
    '    .ModeText = Record.ModeText
    '    .AmountFactor = Record.AmountFactor
    '    .Remarks = Record.Remarks
    '    .CurrencyID = Record.CurrencyID
    '    .PassedAmountTotal = Record.PassedAmountTotal
    '    .ComponentID = Record.ComponentID
    '    .AmountBasic = Record.AmountBasic
    '    .OOERemarks = Record.OOERemarks
    '    .AmountRate = Record.AmountRate
    '    .SystemText = Record.SystemText
    '    .SanctionFileName = Record.SanctionFileName
    '    .OOEReasonID = Record.OOEReasonID
    '    .PassedAmountInINR = Record.PassedAmountInINR
    '    .AmountTotal = Record.AmountTotal
    '    .ApprovalWFTypeID = Record.ApprovalWFTypeID
    '    .StayedInHotel = Record.StayedInHotel
    '    .PassedAmountRate = Record.PassedAmountRate
    '    .StayedWithRelative = Record.StayedWithRelative
    '    .PassedAmountFactor = Record.PassedAmountFactor
    '    .ConversionFactorINR = Record.ConversionFactorINR
    '    .Date2Time = Record.Date2Time
    '    .PassedAmountTax = Record.PassedAmountTax
    '    .AccountsRemarks = Record.AccountsRemarks
    '    .ApprovedOn = Record.ApprovedOn
    '    .ApprovalRemarks = Record.ApprovalRemarks
    '    .AmountTax = Record.AmountTax
    '    .PassedAmountBasic = Record.PassedAmountBasic
    '    .ApprovedBy = Record.ApprovedBy
    '    .BillAttached = Record.BillAttached
    '    .NotStayedAnyWhere = Record.NotStayedAnyWhere
    '    .BillFileName = Record.BillFileName
    '    .CityTypeID = Record.CityTypeID
    '    .ModeLCID = Record.ModeLCID
    '    .AirportToHotel = Record.AirportToHotel
    '    .HotelToAirport = Record.HotelToAirport
    '    .SanctionDiskFile = Record.SanctionDiskFile
    '    .StayedInGuestHouse = Record.StayedInGuestHouse
    '    .AutoCalculated = Record.AutoCalculated
    '    .LodgingProvided = Record.LodgingProvided
    '    .BoardingProvided = Record.BoardingProvided
    '    .OOEBySystem = Record.OOEBySystem
    '    .BillDiskFile = Record.BillDiskFile
    '    .ModeTravelID = Record.ModeTravelID
    '    .City2ID = Record.City2ID
    '    .TourExtended = Record.TourExtended
    '    .Setteled = Record.Setteled
    '    .SanctionAttached = Record.SanctionAttached
    '    .AmountInINR = Record.AmountInINR
    '    .CostCenterID = Record.CostCenterID
    '    .ProjectID = Record.ProjectID
    '    .City1Text = Record.City1Text
    '    .City1ID = Record.City1ID
    '    .AirportToClientLocation = Record.AirportToClientLocation
    '    .ModeFinanceID = Record.ModeFinanceID
    '    .StayedAtSite = Record.StayedAtSite
    '    .City2Text = Record.City2Text
    '    .OOEByAccounts = Record.OOEByAccounts
    '  End With
    '  Return SIS.TA.taBDExpense.InsertData(_Rec)
    'End Function
    '<DataObjectMethod(DataObjectMethodType.Update, True)> _
    'Public Shared Function taBDExpenseUpdate(ByVal Record As SIS.TA.taBDExpense) As SIS.TA.taBDExpense
    '  Dim _Rec As SIS.TA.taBDExpense = SIS.TA.taBDExpense.taBDExpenseGetByID(Record.TABillNo, Record.SerialNo)
    '  With _Rec
    '    .Date1Time = Record.Date1Time
    '    .ModeExpenseID = Record.ModeExpenseID
    '    .ModeText = Record.ModeText
    '    .AmountFactor = Record.AmountFactor
    '    .Remarks = Record.Remarks
    '    .CurrencyID = Record.CurrencyID
    '    .PassedAmountTotal = Record.PassedAmountTotal
    '    .ComponentID = Record.ComponentID
    '    .AmountBasic = Record.AmountBasic
    '    .OOERemarks = Record.OOERemarks
    '    .AmountRate = Record.AmountRate
    '    .SystemText = Record.SystemText
    '    .SanctionFileName = Record.SanctionFileName
    '    .OOEReasonID = Record.OOEReasonID
    '    .PassedAmountInINR = Record.PassedAmountInINR
    '    .AmountTotal = Record.AmountTotal
    '    .ApprovalWFTypeID = Record.ApprovalWFTypeID
    '    .StayedInHotel = Record.StayedInHotel
    '    .PassedAmountRate = Record.PassedAmountRate
    '    .StayedWithRelative = Record.StayedWithRelative
    '    .PassedAmountFactor = Record.PassedAmountFactor
    '    .ConversionFactorINR = Record.ConversionFactorINR
    '    .Date2Time = Record.Date2Time
    '    .PassedAmountTax = Record.PassedAmountTax
    '    .AccountsRemarks = Record.AccountsRemarks
    '    .ApprovedOn = Record.ApprovedOn
    '    .ApprovalRemarks = Record.ApprovalRemarks
    '    .AmountTax = Record.AmountTax
    '    .PassedAmountBasic = Record.PassedAmountBasic
    '    .ApprovedBy = Record.ApprovedBy
    '    .BillAttached = Record.BillAttached
    '    .NotStayedAnyWhere = Record.NotStayedAnyWhere
    '    .BillFileName = Record.BillFileName
    '    .CityTypeID = Record.CityTypeID
    '    .ModeLCID = Record.ModeLCID
    '    .AirportToHotel = Record.AirportToHotel
    '    .HotelToAirport = Record.HotelToAirport
    '    .SanctionDiskFile = Record.SanctionDiskFile
    '    .StayedInGuestHouse = Record.StayedInGuestHouse
    '    .AutoCalculated = Record.AutoCalculated
    '    .LodgingProvided = Record.LodgingProvided
    '    .BoardingProvided = Record.BoardingProvided
    '    .OOEBySystem = Record.OOEBySystem
    '    .BillDiskFile = Record.BillDiskFile
    '    .ModeTravelID = Record.ModeTravelID
    '    .City2ID = Record.City2ID
    '    .TourExtended = Record.TourExtended
    '    .Setteled = Record.Setteled
    '    .SanctionAttached = Record.SanctionAttached
    '    .AmountInINR = Record.AmountInINR
    '    .CostCenterID = Record.CostCenterID
    '    .ProjectID = Record.ProjectID
    '    .City1Text = Record.City1Text
    '    .City1ID = Record.City1ID
    '    .AirportToClientLocation = Record.AirportToClientLocation
    '    .ModeFinanceID = Record.ModeFinanceID
    '    .StayedAtSite = Record.StayedAtSite
    '    .City2Text = Record.City2Text
    '    .OOEByAccounts = Record.OOEByAccounts
    '  End With
    '  Return SIS.TA.taBDExpense.UpdateData(_Rec)
    'End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
