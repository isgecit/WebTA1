Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taCDLodging
    Inherits SIS.TA.taBillDetails
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCDLodgingGetNewRecord() As SIS.TA.taCDLodging
      Return New SIS.TA.taCDLodging()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCDLodgingSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taCDLodging)
      Dim Results As List(Of SIS.TA.taCDLodging) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaCDLodgingSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaCDLodgingSelectListFilteres"
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
          Results = New List(Of SIS.TA.taCDLodging)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taCDLodging(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taCDLodgingSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCDLodgingGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32) As SIS.TA.taCDLodging
      Dim Results As SIS.TA.taCDLodging = Nothing
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
            Results = New SIS.TA.taCDLodging(Reader)
            Try
              Results = SIS.TA.taCDLodging.UpdateGSTDataInCDL(Results)
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
    Public Shared Function taCDLodgingGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32, ByVal Filter_TABillNo As Int32) As SIS.TA.taCDLodging
      Dim Results As SIS.TA.taCDLodging = SIS.TA.taCDLodging.taCDLodgingGetByID(TABillNo, SerialNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taCDLodgingUpdate(ByVal Record As SIS.TA.taCDLodging) As SIS.TA.taCDLodging
      Dim _Rec As SIS.TA.taCDLodging = SIS.TA.taCDLodging.taCDLodgingGetByID(Record.TABillNo, Record.SerialNo)
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
        .CostCenterID = Record.CostCenterID
        .ProjectID = Record.ProjectID
        .AmountBasic = Record.AmountBasic
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
        .SanctionAttached = Record.SanctionAttached
        .City2ID = Record.City2ID
        .CityTypeID = Record.CityTypeID
        .ModeTravelID = Record.ModeTravelID
        .City2Text = Record.City2Text
        .AutoCalculated = Record.AutoCalculated
        .ModeFinanceID = Record.ModeFinanceID
        .BillFileName = Record.BillFileName
        .AirportToHotel = Record.AirportToHotel
        .ModeLCID = Record.ModeLCID
        .SanctionFileName = Record.SanctionFileName
        .OOEBySystem = Record.OOEBySystem
        .SystemText = Record.SystemText
        .BillDiskFile = Record.BillDiskFile
        .HotelToAirport = Record.HotelToAirport
        .SanctionDiskFile = Record.SanctionDiskFile
        .ComponentID = Record.ComponentID
        .TourExtended = Record.TourExtended
        .BillAttached = Record.BillAttached
        .ModeExpenseID = Record.ModeExpenseID
        .AirportToClientLocation = Record.AirportToClientLocation
        .OOEByAccounts = Record.OOEByAccounts
      End With
      Return SIS.TA.taCDLodging.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
