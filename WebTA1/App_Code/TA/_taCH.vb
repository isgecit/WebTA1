Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  <DataObject()> _
  Partial Public Class taCH
    Inherits SIS.TA.taBH
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCHGetNewRecord() As SIS.TA.taCH
      Return New SIS.TA.taCH()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCHSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TravelTypeID As Int32, ByVal DestinationCity As String, ByVal ProjectID As String, ByVal EmployeeID As String, ByVal BillStatusID As Int32) As List(Of SIS.TA.taCH)
      Dim Results As List(Of SIS.TA.taCH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "TABillNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaCHSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaCHSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TravelTypeID",SqlDbType.Int,10, IIf(TravelTypeID = Nothing, 0,TravelTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_DestinationCity",SqlDbType.NVarChar,30, IIf(DestinationCity Is Nothing, String.Empty,DestinationCity))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EmployeeID",SqlDbType.NVarChar,8, IIf(EmployeeID Is Nothing, String.Empty,EmployeeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BillStatusID",SqlDbType.Int,10, IIf(BillStatusID = Nothing, 0,BillStatusID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.TA.taCH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taCH(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function taCHSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TravelTypeID As Int32, ByVal DestinationCity As String, ByVal ProjectID As String, ByVal EmployeeID As String, ByVal BillStatusID As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCHGetByID(ByVal TABillNo As Int32) As SIS.TA.taCH
      Dim Results As SIS.TA.taCH = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptaBHSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TABillNo",SqlDbType.Int,TABillNo.ToString.Length, TABillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TA.taCH(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function taCHGetByID(ByVal TABillNo As Int32, ByVal Filter_TravelTypeID As Int32, ByVal Filter_DestinationCity As String, ByVal Filter_ProjectID As String, ByVal Filter_EmployeeID As String, ByVal Filter_BillStatusID As Int32) As SIS.TA.taCH
      Dim Results As SIS.TA.taCH = SIS.TA.taCH.taCHGetByID(TABillNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function taCHUpdate(ByVal Record As SIS.TA.taCH) As SIS.TA.taCH
      Dim _Rec As SIS.TA.taCH = SIS.TA.taCH.taCHGetByID(Record.TABillNo)
      With _Rec
        .ProjectID = Record.ProjectID
        .BillStatusID = Record.BillStatusID
        .ApprovalWFTypeID = Record.ApprovalWFTypeID
        .OOEReasonID = Record.OOEReasonID
        .SanctionedDA = Record.SanctionedDA
        .Setteled = Record.Setteled
        .CostCenterID = Record.CostCenterID
        .BillCurrencyID = Record.BillCurrencyID
        .SanctionedLodging = Record.SanctionedLodging
        .PrjCalcType = Record.PrjCalcType
        .ConversionFactorINR = Record.ConversionFactorINR
      End With
      Return SIS.TA.taCH.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
      Try
        VoucherType = ERPBatchNo.Split(",".ToCharArray)(0)
        VoucherCompany = ERPBatchNo.Split(",".ToCharArray)(1)
        VoucherNo = ERPDocumentNo
      Catch ex As Exception

      End Try
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
