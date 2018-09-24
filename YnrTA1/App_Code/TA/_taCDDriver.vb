Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taCDDriver
    Inherits SIS.TA.taBillDetails
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function taCDDriverGetNewRecord() As SIS.TA.taCDDriver
      Return New SIS.TA.taCDDriver()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCDDriverSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taCDDriver)
      Dim Results As List(Of SIS.TA.taCDDriver) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaCDDriverSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaCDDriverSelectListFilteres"
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
          Results = New List(Of SIS.TA.taCDDriver)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taCDDriver(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taCDDriverSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCDDriverGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32) As SIS.TA.taCDDriver
      Dim Results As SIS.TA.taCDDriver = Nothing
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
            Results = New SIS.TA.taCDDriver(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCDDriverGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32, ByVal Filter_TABillNo As Int32) As SIS.TA.taCDDriver
      Dim Results As SIS.TA.taCDDriver = SIS.TA.taCDDriver.taCDDriverGetByID(TABillNo, SerialNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taCDDriverUpdate(ByVal Record As SIS.TA.taCDDriver) As SIS.TA.taCDDriver
      Dim _Rec As SIS.TA.taCDDriver = SIS.TA.taCDDriver.taCDDriverGetByID(Record.TABillNo, Record.SerialNo)
      With _Rec
        .Date1Time = Record.Date1Time
        .SystemText = Record.SystemText
        .AmountTotal = Record.AmountTotal
        .PassedAmountTotal = Record.PassedAmountTotal
        .OOERemarks = Record.OOERemarks
        .OOEReasonID = Record.OOEReasonID
        .AmountTax = Record.AmountTax
        .CityTypeID = Record.CityTypeID
        .ApprovalWFTypeID = Record.ApprovalWFTypeID
        .AmountBasic = Record.AmountBasic
        .ProjectID = Record.ProjectID
        .CurrencyID = Record.CurrencyID
        .SanctionDiskFile = Record.SanctionDiskFile
        .CostCenterID = Record.CostCenterID
        .ConversionFactorINR = Record.ConversionFactorINR
        .PassedAmountFactor = Record.PassedAmountFactor
        .PassedAmountRate = Record.PassedAmountRate
        .PassedAmountInINR = Record.PassedAmountInINR
        .ApprovalRemarks = Record.ApprovalRemarks
        .BillFileName = Record.BillFileName
        .PassedAmountTax = Record.PassedAmountTax
        .AccountsRemarks = Record.AccountsRemarks
        .ApprovedBy = Record.ApprovedBy
        .ApprovedOn = Record.ApprovedOn
        .NotStayedAnyWhere = Record.NotStayedAnyWhere
        .PassedAmountBasic = Record.PassedAmountBasic
        .AmountInINR = Record.AmountInINR
        .SanctionFileName = Record.SanctionFileName
        .OOEBySystem = Record.OOEBySystem
        .BoardingProvided = Record.BoardingProvided
        .City2Text = Record.City2Text
        .City2ID = Record.City2ID
        .StayedInGuestHouse = Record.StayedInGuestHouse
        .StayedInHotel = Record.StayedInHotel
        .ModeTravelID = Record.ModeTravelID
        .LodgingProvided = Record.LodgingProvided
        .ModeText = Record.ModeText
        .City1ID = Record.City1ID
        .AmountFactor = Record.AmountFactor
        .Date2Time = Record.Date2Time
        .AmountRate = Record.AmountRate
        .HotelToAirport = Record.HotelToAirport
        .ComponentID = Record.ComponentID
        .Remarks = Record.Remarks
        .BillAttached = Record.BillAttached
        .StayedAtSite = Record.StayedAtSite
        .ModeFinanceID = Record.ModeFinanceID
        .Setteled = Record.Setteled
        .AirportToHotel = Record.AirportToHotel
        .AutoCalculated = Record.AutoCalculated
        .BillDiskFile = Record.BillDiskFile
        .OOEByAccounts = Record.OOEByAccounts
        .City1Text = Record.City1Text
        .TourExtended = Record.TourExtended
        .ModeExpenseID = Record.ModeExpenseID
        .SanctionAttached = Record.SanctionAttached
        .ModeLCID = Record.ModeLCID
        .StayedWithRelative = Record.StayedWithRelative
        .AirportToClientLocation = Record.AirportToClientLocation
      End With
      Return SIS.TA.taCDDriver.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
