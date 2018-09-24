Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taCDMileage
    Inherits SIS.TA.taBillDetails
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCDMileageGetNewRecord() As SIS.TA.taCDMileage
      Return New SIS.TA.taCDMileage()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCDMileageSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taCDMileage)
      Dim Results As List(Of SIS.TA.taCDMileage) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaCDMileageSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaCDMileageSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo",SqlDbType.Int,10, IIf(TABillNo = Nothing, 0,TABillNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ComponentID",SqlDbType.Int,10, TAComponentTypes.Mileage)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.TA.taCDMileage)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taCDMileage(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taCDMileageSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCDMileageGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32) As SIS.TA.taCDMileage
      Dim Results As SIS.TA.taCDMileage = Nothing
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
            Results = New SIS.TA.taCDMileage(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCDMileageGetByID(ByVal TABillNo As Int32, ByVal SerialNo As Int32, ByVal Filter_TABillNo As Int32) As SIS.TA.taCDMileage
      Dim Results As SIS.TA.taCDMileage = SIS.TA.taCDMileage.taCDMileageGetByID(TABillNo, SerialNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taCDMileageUpdate(ByVal Record As SIS.TA.taCDMileage) As SIS.TA.taCDMileage
      Dim _Rec As SIS.TA.taCDMileage = SIS.TA.taCDMileage.taCDMileageGetByID(Record.TABillNo, Record.SerialNo)
      With _Rec
        .City1ID = Record.City1ID
        .City1Text = Record.City1Text
        .City2ID = Record.City2ID
        .City2Text = Record.City2Text
        .Date1Time = Record.Date1Time
        .Date2Time = Record.Date2Time
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
        .SanctionDiskFile = Record.SanctionDiskFile
        .StayedWithRelative = Record.StayedWithRelative
        .ModeTravelID = Record.ModeTravelID
        .SanctionFileName = Record.SanctionFileName
        .TourExtended = Record.TourExtended
        .HotelToAirport = Record.HotelToAirport
        .ModeExpenseID = Record.ModeExpenseID
        .AirportToHotel = Record.AirportToHotel
        .SanctionAttached = Record.SanctionAttached
        .OOEByAccounts = Record.OOEByAccounts
        .BillFileName = Record.BillFileName
        .ModeFinanceID = Record.ModeFinanceID
        .StayedInHotel = Record.StayedInHotel
        .BillDiskFile = Record.BillDiskFile
        .NotStayedAnyWhere = Record.NotStayedAnyWhere
        .ModeLCID = Record.ModeLCID
        .StayedAtSite = Record.StayedAtSite
        .AirportToClientLocation = Record.AirportToClientLocation
        .ComponentID = Record.ComponentID
        .ModeText = Record.ModeText
        .BillAttached = Record.BillAttached
        .OOEBySystem = Record.OOEBySystem
        .LodgingProvided = Record.LodgingProvided
        .StayedInGuestHouse = Record.StayedInGuestHouse
        .SystemText = Record.SystemText
        .CityTypeID = Record.CityTypeID
        .AutoCalculated = Record.AutoCalculated
        .BoardingProvided = Record.BoardingProvided
      End With
      Return SIS.TA.taCDMileage.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
