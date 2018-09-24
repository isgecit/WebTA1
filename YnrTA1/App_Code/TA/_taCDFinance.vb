Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taCDFinance
    Inherits SIS.TA.taBillDetails
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCDFinanceGetNewRecord() As SIS.TA.taCDFinance
      Return New SIS.TA.taCDFinance()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCDFinanceSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taCDFinance)
      Dim Results As List(Of SIS.TA.taCDFinance) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaCDFinanceSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaCDFinanceSelectListFilteres"
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
          Results = New List(Of SIS.TA.taCDFinance)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taCDFinance(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taCDFinanceSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCDFinanceGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32) As SIS.TA.taCDFinance
      Dim Results As SIS.TA.taCDFinance = Nothing
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
            Results = New SIS.TA.taCDFinance(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCDFinanceGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32, ByVal Filter_TABillNo As Int32) As SIS.TA.taCDFinance
      Dim Results As SIS.TA.taCDFinance = SIS.TA.taCDFinance.taCDFinanceGetByID(TABillNo, SerialNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function taCDFinanceInsert(ByVal Record As SIS.TA.taCDFinance) As SIS.TA.taCDFinance
      Dim _Rec As SIS.TA.taCDFinance = SIS.TA.taCDFinance.taCDFinanceGetNewRecord()
      With _Rec
        .TABillNo = Record.TABillNo
        .Date1Time = Record.Date1Time
        .ModeFinanceID = Record.ModeFinanceID
        .ModeText = Record.ModeText
        .AmountFactor = Record.AmountFactor
        .Remarks = Record.Remarks
        .BillAttached = Record.BillAttached
        .Date2Time = Record.Date2Time
        .City1Text = Record.City1Text
        .SanctionAttached = Record.SanctionAttached
        .NotStayedAnyWhere = Record.NotStayedAnyWhere
        .AirportToClientLocation = Record.AirportToClientLocation
        .AutoCalculated = Record.AutoCalculated
        .OOEBySystem = Record.OOEBySystem
        .City1ID = Record.City1ID
        .ComponentID = Record.ComponentID
        .ModeTravelID = Record.ModeTravelID
        .BillDiskFile = Record.BillDiskFile
        .StayedAtSite = Record.StayedAtSite
        .StayedInGuestHouse = Record.StayedInGuestHouse
        .ModeLCID = Record.ModeLCID
        .TourExtended = Record.TourExtended
        .LodgingProvided = Record.LodgingProvided
        .HotelToAirport = Record.HotelToAirport
        .StayedInHotel = Record.StayedInHotel
        .CityTypeID = Record.CityTypeID
        .BillFileName = Record.BillFileName
        .City2ID = Record.City2ID
        .OOEByAccounts = Record.OOEByAccounts
        .AirportToHotel = Record.AirportToHotel
        .BoardingProvided = Record.BoardingProvided
        .CurrencyID = Record.CurrencyID
        .AmountTax = Record.AmountTax
        .ProjectID = Record.ProjectID
        .ModeExpenseID = Record.ModeExpenseID
        .AmountInINR = Record.AmountInINR
        .ConversionFactorINR = Record.ConversionFactorINR
        .AmountBasic = Record.AmountBasic
        .PassedAmountTotal = Record.PassedAmountTotal
        .AmountTotal = Record.AmountTotal
        .SystemText = Record.SystemText
        .OOERemarks = Record.OOERemarks
        .CostCenterID = Record.CostCenterID
        .SanctionFileName = Record.SanctionFileName
        .AmountRate = Record.AmountRate
        .ApprovalWFTypeID = Record.ApprovalWFTypeID
        .OOEReasonID = Record.OOEReasonID
        .ApprovalRemarks = Record.ApprovalRemarks
        .ApprovedOn = Record.ApprovedOn
        .ApprovedBy = Record.ApprovedBy
        .City2Text = Record.City2Text
        .StayedWithRelative = Record.StayedWithRelative
        .SanctionDiskFile = Record.SanctionDiskFile
        .Setteled = Record.Setteled
        .PassedAmountBasic = Record.PassedAmountBasic
        .PassedAmountRate = Record.PassedAmountRate
        .PassedAmountFactor = Record.PassedAmountFactor
        .AccountsRemarks = Record.AccountsRemarks
        .PassedAmountInINR = Record.PassedAmountInINR
        .PassedAmountTax = Record.PassedAmountTax
      End With
      Return SIS.TA.taCDFinance.InsertData(_Rec)
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taCDFinanceUpdate(ByVal Record As SIS.TA.taCDFinance) As SIS.TA.taCDFinance
      Dim _Rec As SIS.TA.taCDFinance = SIS.TA.taCDFinance.taCDFinanceGetByID(Record.TABillNo, Record.SerialNo)
      With _Rec
        .Date1Time = Record.Date1Time
        .ModeFinanceID = Record.ModeFinanceID
        .ModeText = Record.ModeText
        .AmountFactor = Record.AmountFactor
        .Remarks = Record.Remarks
        .BillAttached = Record.BillAttached
        .Date2Time = Record.Date2Time
        .City1Text = Record.City1Text
        .SanctionAttached = Record.SanctionAttached
        .NotStayedAnyWhere = Record.NotStayedAnyWhere
        .AirportToClientLocation = Record.AirportToClientLocation
        .AutoCalculated = Record.AutoCalculated
        .OOEBySystem = Record.OOEBySystem
        .City1ID = Record.City1ID
        .ComponentID = Record.ComponentID
        .ModeTravelID = Record.ModeTravelID
        .BillDiskFile = Record.BillDiskFile
        .StayedAtSite = Record.StayedAtSite
        .StayedInGuestHouse = Record.StayedInGuestHouse
        .ModeLCID = Record.ModeLCID
        .TourExtended = Record.TourExtended
        .LodgingProvided = Record.LodgingProvided
        .HotelToAirport = Record.HotelToAirport
        .StayedInHotel = Record.StayedInHotel
        .CityTypeID = Record.CityTypeID
        .BillFileName = Record.BillFileName
        .City2ID = Record.City2ID
        .OOEByAccounts = Record.OOEByAccounts
        .AirportToHotel = Record.AirportToHotel
        .BoardingProvided = Record.BoardingProvided
        .CurrencyID = Record.CurrencyID
        .AmountTax = Record.AmountTax
        .ProjectID = Record.ProjectID
        .ModeExpenseID = Record.ModeExpenseID
        .AmountInINR = Record.AmountInINR
        .ConversionFactorINR = Record.ConversionFactorINR
        .AmountBasic = Record.AmountBasic
        .PassedAmountTotal = Record.PassedAmountTotal
        .AmountTotal = Record.AmountTotal
        .SystemText = Record.SystemText
        .OOERemarks = Record.OOERemarks
        .CostCenterID = Record.CostCenterID
        .SanctionFileName = Record.SanctionFileName
        .AmountRate = Record.AmountRate
        .ApprovalWFTypeID = Record.ApprovalWFTypeID
        .OOEReasonID = Record.OOEReasonID
        .ApprovalRemarks = Record.ApprovalRemarks
        .ApprovedOn = Record.ApprovedOn
        .ApprovedBy = Record.ApprovedBy
        .City2Text = Record.City2Text
        .StayedWithRelative = Record.StayedWithRelative
        .SanctionDiskFile = Record.SanctionDiskFile
        .Setteled = Record.Setteled
        .PassedAmountBasic = Record.PassedAmountBasic
        .PassedAmountRate = Record.PassedAmountRate
        .PassedAmountFactor = Record.PassedAmountFactor
        .AccountsRemarks = Record.AccountsRemarks
        .PassedAmountInINR = Record.PassedAmountInINR
        .PassedAmountTax = Record.PassedAmountTax
      End With
      Return SIS.TA.taCDFinance.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
