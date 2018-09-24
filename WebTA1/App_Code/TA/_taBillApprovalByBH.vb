Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taBillApprovalByBH
    Inherits SIS.TA.taBH
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBillApprovalByBHGetNewRecord() As SIS.TA.taBillApprovalByBH
      Return New SIS.TA.taBillApprovalByBH()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBillApprovalByBHSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32, ByVal TravelTypeID As Int32, ByVal DestinationCity As String, ByVal ProjectID As String, ByVal BillStatusID As Int32, ByVal EmployeeID As String) As List(Of SIS.TA.taBillApprovalByBH)
      Dim Results As List(Of SIS.TA.taBillApprovalByBH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "TABillNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaBillApprovalByBHSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaBillApprovalByBHSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo",SqlDbType.Int,10, IIf(TABillNo = Nothing, 0,TABillNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TravelTypeID",SqlDbType.Int,10, IIf(TravelTypeID = Nothing, 0,TravelTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DestinationCity",SqlDbType.NVarChar,30, IIf(DestinationCity Is Nothing, String.Empty,DestinationCity))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BillStatusID",SqlDbType.Int,10, IIf(BillStatusID = Nothing, 0,BillStatusID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EmployeeID",SqlDbType.NVarChar,8, IIf(EmployeeID Is Nothing, String.Empty,EmployeeID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.TA.taBillApprovalByBH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBillApprovalByBH(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taBillApprovalByBHSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32, ByVal TravelTypeID As Int32, ByVal DestinationCity As String, ByVal ProjectID As String, ByVal BillStatusID As Int32, ByVal EmployeeID As String) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBillApprovalByBHGetByID(ByVal TABillNo As Int32) As SIS.TA.taBillApprovalByBH
      Dim Results As SIS.TA.taBillApprovalByBH = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBillsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TABillNo",SqlDbType.Int,TABillNo.ToString.Length, TABillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TA.taBillApprovalByBH(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBillApprovalByBHGetByID(ByVal TABillNo As Int32, ByVal Filter_TABillNo As Int32, ByVal Filter_TravelTypeID As Int32, ByVal Filter_DestinationCity As String, ByVal Filter_ProjectID As String, ByVal Filter_BillStatusID As Int32, ByVal Filter_EmployeeID As String) As SIS.TA.taBillApprovalByBH
      Dim Results As SIS.TA.taBillApprovalByBH = SIS.TA.taBillApprovalByBH.taBillApprovalByBHGetByID(TABillNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taBillApprovalByBHUpdate(ByVal Record As SIS.TA.taBillApprovalByBH) As SIS.TA.taBillApprovalByBH
      Dim _Rec As SIS.TA.taBillApprovalByBH = SIS.TA.taBillApprovalByBH.taBillApprovalByBHGetByID(Record.TABillNo)
      With _Rec
        .TravelTypeID = Record.TravelTypeID
        .CityOfOrigin = Record.CityOfOrigin
        .DestinationCity = Record.DestinationCity
        .ProjectID = Record.ProjectID
        .TrainingProgram = Record.TrainingProgram
        .SameDayVisit = Record.SameDayVisit
        .Within25KM = Record.Within25KM
        .SiteToAnotherSite = Record.SiteToAnotherSite
        .TaxiHired = Record.TaxiHired
        .OwnVehicleUsed = Record.OwnVehicleUsed
        .PurposeOfJourney = Record.PurposeOfJourney
        .BriefTourReport = Record.BriefTourReport
        .SanctionedLodging = Record.SanctionedLodging
        .BillCurrencyID = Record.BillCurrencyID
        .PrjCalcType = Record.PrjCalcType
        .CostCenterID = Record.CostCenterID
        .SanctionedDA = Record.SanctionedDA
        .ConversionFactorINR = Record.ConversionFactorINR
        .BillStatusID = Record.BillStatusID
      End With
      Return SIS.TA.taBillApprovalByBH.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
