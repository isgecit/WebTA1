Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taBillApprovalByHD
    Inherits SIS.TA.taBH
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBillApprovalByHDGetNewRecord() As SIS.TA.taBillApprovalByHD
      Return New SIS.TA.taBillApprovalByHD()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBillApprovalByHDSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32, ByVal EmployeeID As String, ByVal ProjectID As String, ByVal BillStatusID As Int32, ByVal TravelTypeID As Int32, ByVal DestinationCity As String) As List(Of SIS.TA.taBillApprovalByHD)
      Dim Results As List(Of SIS.TA.taBillApprovalByHD) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "TABillNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaBillApprovalByHDSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaBillApprovalByHDSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo",SqlDbType.Int,10, IIf(TABillNo = Nothing, 0,TABillNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EmployeeID",SqlDbType.NVarChar,8, IIf(EmployeeID Is Nothing, String.Empty,EmployeeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BillStatusID",SqlDbType.Int,10, IIf(BillStatusID = Nothing, 0,BillStatusID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TravelTypeID",SqlDbType.Int,10, IIf(TravelTypeID = Nothing, 0,TravelTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DestinationCity",SqlDbType.NVarChar,30, IIf(DestinationCity Is Nothing, String.Empty,DestinationCity))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.TA.taBillApprovalByHD)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBillApprovalByHD(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taBillApprovalByHDSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32, ByVal EmployeeID As String, ByVal ProjectID As String, ByVal BillStatusID As Int32, ByVal TravelTypeID As Int32, ByVal DestinationCity As String) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBillApprovalByHDGetByID(ByVal TABillNo As Int32) As SIS.TA.taBillApprovalByHD
      Dim Results As SIS.TA.taBillApprovalByHD = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBillsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TABillNo",SqlDbType.Int,TABillNo.ToString.Length, TABillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TA.taBillApprovalByHD(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taBillApprovalByHDGetByID(ByVal TABillNo As Int32, ByVal Filter_TABillNo As Int32, ByVal Filter_EmployeeID As String, ByVal Filter_ProjectID As String, ByVal Filter_BillStatusID As Int32, ByVal Filter_TravelTypeID As Int32, ByVal Filter_DestinationCity As String) As SIS.TA.taBillApprovalByHD
      Dim Results As SIS.TA.taBillApprovalByHD = SIS.TA.taBillApprovalByHD.taBillApprovalByHDGetByID(TABillNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taBillApprovalByHDUpdate(ByVal Record As SIS.TA.taBillApprovalByHD) As SIS.TA.taBillApprovalByHD
      Dim _Rec As SIS.TA.taBillApprovalByHD = SIS.TA.taBillApprovalByHD.taBillApprovalByHDGetByID(Record.TABillNo)
      With _Rec
        .CostCenterID = Record.CostCenterID
        .ProjectID = Record.ProjectID
        .PurposeOfJourney = Record.PurposeOfJourney
        .BriefTourReport = Record.BriefTourReport
        .SanctionedDA = Record.SanctionedDA
        .SanctionedLodging = Record.SanctionedLodging
        .BillStatusID = Record.BillStatusID
        .TrainingProgram = Record.TrainingProgram
        .CityOfOrigin = Record.CityOfOrigin
        .Within25KM = Record.Within25KM
        .SiteToAnotherSite = Record.SiteToAnotherSite
        .TravelTypeID = Record.TravelTypeID
        .SameDayVisit = Record.SameDayVisit
        .BillCurrencyID = Record.BillCurrencyID
        .ConversionFactorINR = Record.ConversionFactorINR
        .OwnVehicleUsed = Record.OwnVehicleUsed
        .DestinationCity = Record.DestinationCity
        .PrjCalcType = Record.PrjCalcType
        .TaxiHired = Record.TaxiHired
      End With
      Return SIS.TA.taBillApprovalByHD.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
