Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taCDLC
    Inherits SIS.TA.taBillDetails
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCDLCGetNewRecord() As SIS.TA.taCDLC
      Return New SIS.TA.taCDLC()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCDLCSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taCDLC)
      Dim Results As List(Of SIS.TA.taCDLC) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaCDLCSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaCDLCSelectListFilteres"
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
          Results = New List(Of SIS.TA.taCDLC)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taCDLC(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taCDLCSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCDLCGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32) As SIS.TA.taCDLC
      Dim Results As SIS.TA.taCDLC = Nothing
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
            Results = New SIS.TA.taCDLC(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCDLCGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32, ByVal Filter_TABillNo As Int32) As SIS.TA.taCDLC
      Dim Results As SIS.TA.taCDLC = SIS.TA.taCDLC.taCDLCGetByID(TABillNo, SerialNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taCDLCUpdate(ByVal Record As SIS.TA.taCDLC) As SIS.TA.taCDLC
      Dim _Rec As SIS.TA.taCDLC = SIS.TA.taCDLC.taCDLCGetByID(Record.TABillNo, Record.SerialNo)
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
        .StayedAtSite = Record.StayedAtSite
        .AutoCalculated = Record.AutoCalculated
        .ModeTravelID = Record.ModeTravelID
        .BillAttached = Record.BillAttached
        .ComponentID = Record.ComponentID
        .StayedInGuestHouse = Record.StayedInGuestHouse
        .OOEBySystem = Record.OOEBySystem
        .ModeExpenseID = Record.ModeExpenseID
        .NotStayedAnyWhere = Record.NotStayedAnyWhere
        .ModeFinanceID = Record.ModeFinanceID
        .SanctionFileName = Record.SanctionFileName
        .StayedInHotel = Record.StayedInHotel
        .SanctionAttached = Record.SanctionAttached
        .BillFileName = Record.BillFileName
        .City2ID = Record.City2ID
        .StayedWithRelative = Record.StayedWithRelative
        .BoardingProvided = Record.BoardingProvided
        .TourExtended = Record.TourExtended
        .SystemText = Record.SystemText
        .City1ID = Record.City1ID
        .LodgingProvided = Record.LodgingProvided
        .CityTypeID = Record.CityTypeID
        .BillDiskFile = Record.BillDiskFile
        .OOEByAccounts = Record.OOEByAccounts
        .SanctionDiskFile = Record.SanctionDiskFile
      End With
      Return SIS.TA.taCDLC.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
