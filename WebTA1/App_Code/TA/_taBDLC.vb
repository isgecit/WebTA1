Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taBDLC
    Inherits SIS.TA.taBillDetails
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBDLCGetNewRecord() As SIS.TA.taBDLC
      Return New SIS.TA.taBDLC()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBDLCSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taBDLC)
      Dim Results As List(Of SIS.TA.taBDLC) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaBDLCSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaBDLCSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo",SqlDbType.Int,10, IIf(TABillNo = Nothing, 0,TABillNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ComponentID",SqlDbType.Int,10, TAComponentTypes.LC)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.TA.taBDLC)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBDLC(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taBDLCSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBDLCGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32) As SIS.TA.taBDLC
      Dim Results As SIS.TA.taBDLC = Nothing
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
            Results = New SIS.TA.taBDLC(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBDLCGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32, ByVal Filter_TABillNo As Int32) As SIS.TA.taBDLC
      Dim Results As SIS.TA.taBDLC = SIS.TA.taBDLC.taBDLCGetByID(TABillNo, SerialNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function taBDLCInsert(ByVal Record As SIS.TA.taBDLC) As SIS.TA.taBDLC
      Dim _Rec As SIS.TA.taBDLC = SIS.TA.taBDLC.taBDLCGetNewRecord()
      With _Rec
        .TABillNo = Record.TABillNo
        .City1Text = Record.City1Text
        .City2Text = Record.City2Text
        .Date1Time = Record.Date1Time
        .Date2Time = Record.Date2Time
        .ModeLCID = Record.ModeLCID
        .ModeText = Record.ModeText
        .AirportToHotel = Record.AirportToHotel
        .AirportToClientLocation = Record.AirportToClientLocation
        .HotelToAirport = Record.HotelToAirport
        .AmountFactor = Record.AmountFactor
        .Remarks = Record.Remarks
        .OOERemarks = Record.OOERemarks
        .OOEReasonID = Record.OOEReasonID
        .CurrencyID = Record.CurrencyID
        .AmountTax = Record.AmountTax
        .PassedAmountTax = Record.PassedAmountTax
        .CostCenterID = Record.CostCenterID
        .AmountTotal = Record.AmountTotal
        .ApprovalWFTypeID = Record.ApprovalWFTypeID
        .NotStayedAnyWhere = Record.NotStayedAnyWhere
        .PassedAmountTotal = Record.PassedAmountTotal
        .ComponentID = Record.ComponentID
        .SystemText = Record.SystemText
        .StayedInGuestHouse = Record.StayedInGuestHouse
        .StayedAtSite = Record.StayedAtSite
        .ApprovalRemarks = Record.ApprovalRemarks
        .PassedAmountBasic = Record.PassedAmountBasic
        .PassedAmountInINR = Record.PassedAmountInINR
        .PassedAmountFactor = Record.PassedAmountFactor
        .ApprovedBy = Record.ApprovedBy
        .ApprovedOn = Record.ApprovedOn
        .AmountBasic = Record.AmountBasic
        .ModeExpenseID = Record.ModeExpenseID
        .PassedAmountRate = Record.PassedAmountRate
        .AccountsRemarks = Record.AccountsRemarks
        .OOEByAccounts = Record.OOEByAccounts
        .StayedInHotel = Record.StayedInHotel
        .Setteled = Record.Setteled
        .ModeFinanceID = Record.ModeFinanceID
        .OOEBySystem = Record.OOEBySystem
        .BoardingProvided = Record.BoardingProvided
        .CityTypeID = Record.CityTypeID
        .TourExtended = Record.TourExtended
        .LodgingProvided = Record.LodgingProvided
        .SanctionFileName = Record.SanctionFileName
        .StayedWithRelative = Record.StayedWithRelative
        .SanctionAttached = Record.SanctionAttached
        .ProjectID = Record.ProjectID
        .AmountRate = Record.AmountRate
        .BillFileName = Record.BillFileName
        .ConversionFactorINR = Record.ConversionFactorINR
        .AmountInINR = Record.AmountInINR
        .AutoCalculated = Record.AutoCalculated
        .BillAttached = Record.BillAttached
        .City1ID = Record.City1ID
        .City2ID = Record.City2ID
        .SanctionDiskFile = Record.SanctionDiskFile
        .BillDiskFile = Record.BillDiskFile
        .ModeTravelID = Record.ModeTravelID
      End With
      Return SIS.TA.taBDLC.InsertData(_Rec)
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taBDLCUpdate(ByVal Record As SIS.TA.taBDLC) As SIS.TA.taBDLC
      Dim _Rec As SIS.TA.taBDLC = SIS.TA.taBDLC.taBDLCGetByID(Record.TABillNo, Record.SerialNo)
      With _Rec
        .City1Text = Record.City1Text
        .City2Text = Record.City2Text
        .Date1Time = Record.Date1Time
        .Date2Time = Record.Date2Time
        .ModeLCID = Record.ModeLCID
        .ModeText = Record.ModeText
        .AirportToHotel = Record.AirportToHotel
        .AirportToClientLocation = Record.AirportToClientLocation
        .HotelToAirport = Record.HotelToAirport
        .AmountFactor = Record.AmountFactor
        .Remarks = Record.Remarks
        .OOERemarks = Record.OOERemarks
        .OOEReasonID = Record.OOEReasonID
        .CurrencyID = Record.CurrencyID
        .AmountTax = Record.AmountTax
        .PassedAmountTax = Record.PassedAmountTax
        .CostCenterID = Record.CostCenterID
        .AmountTotal = Record.AmountTotal
        .ApprovalWFTypeID = Record.ApprovalWFTypeID
        .NotStayedAnyWhere = Record.NotStayedAnyWhere
        .PassedAmountTotal = Record.PassedAmountTotal
        .ComponentID = Record.ComponentID
        .SystemText = Record.SystemText
        .StayedInGuestHouse = Record.StayedInGuestHouse
        .StayedAtSite = Record.StayedAtSite
        .ApprovalRemarks = Record.ApprovalRemarks
        .PassedAmountBasic = Record.PassedAmountBasic
        .PassedAmountInINR = Record.PassedAmountInINR
        .PassedAmountFactor = Record.PassedAmountFactor
        .ApprovedBy = Record.ApprovedBy
        .ApprovedOn = Record.ApprovedOn
        .AmountBasic = Record.AmountBasic
        .ModeExpenseID = Record.ModeExpenseID
        .PassedAmountRate = Record.PassedAmountRate
        .AccountsRemarks = Record.AccountsRemarks
        .OOEByAccounts = Record.OOEByAccounts
        .StayedInHotel = Record.StayedInHotel
        .Setteled = Record.Setteled
        .ModeFinanceID = Record.ModeFinanceID
        .OOEBySystem = Record.OOEBySystem
        .BoardingProvided = Record.BoardingProvided
        .CityTypeID = Record.CityTypeID
        .TourExtended = Record.TourExtended
        .LodgingProvided = Record.LodgingProvided
        .SanctionFileName = Record.SanctionFileName
        .StayedWithRelative = Record.StayedWithRelative
        .SanctionAttached = Record.SanctionAttached
        .ProjectID = Record.ProjectID
        .AmountRate = Record.AmountRate
        .BillFileName = Record.BillFileName
        .ConversionFactorINR = Record.ConversionFactorINR
        .AmountInINR = Record.AmountInINR
        .AutoCalculated = Record.AutoCalculated
        .BillAttached = Record.BillAttached
        .City1ID = Record.City1ID
        .City2ID = Record.City2ID
        .SanctionDiskFile = Record.SanctionDiskFile
        .BillDiskFile = Record.BillDiskFile
        .ModeTravelID = Record.ModeTravelID
      End With
      Return SIS.TA.taBDLC.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
