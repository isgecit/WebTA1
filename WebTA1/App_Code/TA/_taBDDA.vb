Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taBDDA
    Inherits SIS.TA.taBillDetails
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBDDAGetNewRecord() As SIS.TA.taBDDA
      Return New SIS.TA.taBDDA()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBDDASelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taBDDA)
      Dim Results As List(Of SIS.TA.taBDDA) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaBDDASelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaBDDASelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo",SqlDbType.Int,10, IIf(TABillNo = Nothing, 0,TABillNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ComponentID",SqlDbType.Int,10, TAComponentTypes.DA)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.TA.taBDDA)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBDDA(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taBDDASelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBDDAGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32) As SIS.TA.taBDDA
      Dim Results As SIS.TA.taBDDA = Nothing
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
            Results = New SIS.TA.taBDDA(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBDDAGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32, ByVal Filter_TABillNo As Int32) As SIS.TA.taBDDA
      Dim Results As SIS.TA.taBDDA = SIS.TA.taBDDA.taBDDAGetByID(TABillNo, SerialNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function taBDDAInsert(ByVal Record As SIS.TA.taBDDA) As SIS.TA.taBDDA
      Dim _Rec As SIS.TA.taBDDA = SIS.TA.taBDDA.taBDDAGetNewRecord()
      With _Rec
        .TABillNo = Record.TABillNo
        .City1ID = Record.City1ID
        .City1Text = Record.City1Text
        .Date1Time = Record.Date1Time
        .Date2Time = Record.Date2Time
        .BoardingProvided = Record.BoardingProvided
        .LodgingProvided = Record.LodgingProvided
        .StayedWithRelative = Record.StayedWithRelative
        .StayedInHotel = Record.StayedInHotel
        .StayedAtSite = Record.StayedAtSite
        .StayedInGuestHouse = Record.StayedInGuestHouse
        .NotStayedAnyWhere = Record.NotStayedAnyWhere
        .AmountFactor = Record.AmountFactor
        .AmountRate = Record.AmountRate
        .Remarks = Record.Remarks
        .CostCenterID = Record.CostCenterID
        .OOERemarks = Record.OOERemarks
        .AmountBasic = Record.AmountBasic
        .ProjectID = Record.ProjectID
        .PassedAmountFactor = Record.PassedAmountFactor
        .ConversionFactorINR = Record.ConversionFactorINR
        .SystemText = Record.SystemText
        .AmountTotal = Record.AmountTotal
        .ComponentID = Record.ComponentID
        .OOEReasonID = Record.OOEReasonID
        .PassedAmountTotal = Record.PassedAmountTotal
        .ApprovalRemarks = Record.ApprovalRemarks
        .ModeLCID = Record.ModeLCID
        .PassedAmountTax = Record.PassedAmountTax
        .SanctionFileName = Record.SanctionFileName
        .PassedAmountRate = Record.PassedAmountRate
        .ModeTravelID = Record.ModeTravelID
        .ApprovedOn = Record.ApprovedOn
        .AccountsRemarks = Record.AccountsRemarks
        .AmountTax = Record.AmountTax
        .PassedAmountInINR = Record.PassedAmountInINR
        .PassedAmountBasic = Record.PassedAmountBasic
        .ModeFinanceID = Record.ModeFinanceID
        .BillDiskFile = Record.BillDiskFile
        .SanctionAttached = Record.SanctionAttached
        .AirportToHotel = Record.AirportToHotel
        .CityTypeID = Record.CityTypeID
        .OOEByAccounts = Record.OOEByAccounts
        .ModeText = Record.ModeText
        .HotelToAirport = Record.HotelToAirport
        .AirportToClientLocation = Record.AirportToClientLocation
        .BillFileName = Record.BillFileName
        .ApprovedBy = Record.ApprovedBy
        .BillAttached = Record.BillAttached
        .ModeExpenseID = Record.ModeExpenseID
        .CurrencyID = Record.CurrencyID
        .AmountInINR = Record.AmountInINR
        .Setteled = Record.Setteled
        .City2ID = Record.City2ID
        .ApprovalWFTypeID = Record.ApprovalWFTypeID
        .OOEBySystem = Record.OOEBySystem
        .AutoCalculated = Record.AutoCalculated
        .SanctionDiskFile = Record.SanctionDiskFile
        .City2Text = Record.City2Text
        .TourExtended = Record.TourExtended
      End With
      Return SIS.TA.taBDDA.InsertData(_Rec)
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taBDDAUpdate(ByVal Record As SIS.TA.taBDDA) As SIS.TA.taBDDA
      Dim _Rec As SIS.TA.taBDDA = SIS.TA.taBDDA.taBDDAGetByID(Record.TABillNo, Record.SerialNo)
      With _Rec
        .City1ID = Record.City1ID
        .City1Text = Record.City1Text
        .Date1Time = Record.Date1Time
        .Date2Time = Record.Date2Time
        .BoardingProvided = Record.BoardingProvided
        .LodgingProvided = Record.LodgingProvided
        .StayedWithRelative = Record.StayedWithRelative
        .StayedInHotel = Record.StayedInHotel
        .StayedAtSite = Record.StayedAtSite
        .StayedInGuestHouse = Record.StayedInGuestHouse
        .NotStayedAnyWhere = Record.NotStayedAnyWhere
        .AmountFactor = Record.AmountFactor
        .AmountRate = Record.AmountRate
        .Remarks = Record.Remarks
        .CostCenterID = Record.CostCenterID
        .OOERemarks = Record.OOERemarks
        .AmountBasic = Record.AmountBasic
        .ProjectID = Record.ProjectID
        .PassedAmountFactor = Record.PassedAmountFactor
        .ConversionFactorINR = Record.ConversionFactorINR
        .SystemText = Record.SystemText
        .AmountTotal = Record.AmountTotal
        .ComponentID = Record.ComponentID
        .OOEReasonID = Record.OOEReasonID
        .PassedAmountTotal = Record.PassedAmountTotal
        .ApprovalRemarks = Record.ApprovalRemarks
        .ModeLCID = Record.ModeLCID
        .PassedAmountTax = Record.PassedAmountTax
        .SanctionFileName = Record.SanctionFileName
        .PassedAmountRate = Record.PassedAmountRate
        .ModeTravelID = Record.ModeTravelID
        .ApprovedOn = Record.ApprovedOn
        .AccountsRemarks = Record.AccountsRemarks
        .AmountTax = Record.AmountTax
        .PassedAmountInINR = Record.PassedAmountInINR
        .PassedAmountBasic = Record.PassedAmountBasic
        .ModeFinanceID = Record.ModeFinanceID
        .BillDiskFile = Record.BillDiskFile
        .SanctionAttached = Record.SanctionAttached
        .AirportToHotel = Record.AirportToHotel
        .CityTypeID = Record.CityTypeID
        .OOEByAccounts = Record.OOEByAccounts
        .ModeText = Record.ModeText
        .HotelToAirport = Record.HotelToAirport
        .AirportToClientLocation = Record.AirportToClientLocation
        .BillFileName = Record.BillFileName
        .ApprovedBy = Record.ApprovedBy
        .BillAttached = Record.BillAttached
        .ModeExpenseID = Record.ModeExpenseID
        .CurrencyID = Record.CurrencyID
        .AmountInINR = Record.AmountInINR
        .Setteled = Record.Setteled
        .City2ID = Record.City2ID
        .ApprovalWFTypeID = Record.ApprovalWFTypeID
        .OOEBySystem = Record.OOEBySystem
        .AutoCalculated = Record.AutoCalculated
        .SanctionDiskFile = Record.SanctionDiskFile
        .City2Text = Record.City2Text
        .TourExtended = Record.TourExtended
      End With
      Return SIS.TA.taBDDA.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
