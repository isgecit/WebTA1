Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taCDFare
    Inherits SIS.TA.taBillDetails
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCDFareGetNewRecord() As SIS.TA.taCDFare
      Return New SIS.TA.taCDFare()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCDFareSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taCDFare)
      Dim Results As List(Of SIS.TA.taCDFare) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaCDFareSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaCDFareSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo",SqlDbType.Int,10, IIf(TABillNo = Nothing, 0,TABillNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ComponentID",SqlDbType.Int,10, TAComponentTypes.Fare)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.TA.taCDFare)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taCDFare(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taCDFareSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCDFareGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32) As SIS.TA.taCDFare
      Dim Results As SIS.TA.taCDFare = Nothing
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
            Results = New SIS.TA.taCDFare(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCDFareGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32, ByVal Filter_TABillNo As Int32) As SIS.TA.taCDFare
      Dim Results As SIS.TA.taCDFare = SIS.TA.taCDFare.taCDFareGetByID(TABillNo, SerialNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taCDFareUpdate(ByVal Record As SIS.TA.taCDFare) As SIS.TA.taCDFare
      Dim _Rec As SIS.TA.taCDFare = SIS.TA.taCDFare.taCDFareGetByID(Record.TABillNo, Record.SerialNo)
      With _Rec
        .City1ID = Record.City1ID
        .City1Text = Record.City1Text
        .City2ID = Record.City2ID
        .City2Text = Record.City2Text
        .Date1Time = Record.Date1Time
        .Date2Time = Record.Date2Time
        .ModeTravelID = Record.ModeTravelID
        .ModeText = Record.ModeText
        .AmountFactor = Record.AmountFactor
        .Remarks = Record.Remarks
        .AmountRate = Record.AmountRate
        .AmountBasic = Record.AmountBasic
        .AmountTax = Record.AmountTax
        .AmountTotal = Record.AmountTotal
        .AmountInINR = Record.AmountInINR
        .OOERemarks = Record.OOERemarks
        .ApprovalWFTypeID = Record.ApprovalWFTypeID
        .OOEReasonID = Record.OOEReasonID
        .CostCenterID = Record.CostCenterID
        .ProjectID = Record.ProjectID
        .CurrencyID = Record.CurrencyID
        .ConversionFactorINR = Record.ConversionFactorINR
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
        .BillAttached = Record.BillAttached
        .AirportToHotel = Record.AirportToHotel
        .OOEBySystem = Record.OOEBySystem
        .SanctionDiskFile = Record.SanctionDiskFile
        .HotelToAirport = Record.HotelToAirport
        .LodgingProvided = Record.LodgingProvided
        .StayedInHotel = Record.StayedInHotel
        .StayedInGuestHouse = Record.StayedInGuestHouse
        .StayedWithRelative = Record.StayedWithRelative
        .SanctionFileName = Record.SanctionFileName
        .BillFileName = Record.BillFileName
        .AirportToClientLocation = Record.AirportToClientLocation
        .NotStayedAnyWhere = Record.NotStayedAnyWhere
        .ModeLCID = Record.ModeLCID
        .ModeExpenseID = Record.ModeExpenseID
        .BillDiskFile = Record.BillDiskFile
        .BoardingProvided = Record.BoardingProvided
        .TourExtended = Record.TourExtended
        .AutoCalculated = Record.AutoCalculated
        .ModeFinanceID = Record.ModeFinanceID
        .CityTypeID = Record.CityTypeID
        .OOEByAccounts = Record.OOEByAccounts
        .StayedAtSite = Record.StayedAtSite
        .ComponentID = Record.ComponentID
        .SanctionAttached = Record.SanctionAttached
        .SystemText = Record.SystemText
      End With
      Return SIS.TA.taCDFare.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
