Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  <DataObject()> _
  Partial Public Class nprkLedgerEntry
    Inherits SIS.NPRK.nprkLedger
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkLedgerEntryGetNewRecord() As SIS.NPRK.nprkLedgerEntry
      Return New SIS.NPRK.nprkLedgerEntry()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkLedgerEntrySelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal EmployeeID As Int32, ByVal PerkID As Int32) As List(Of SIS.NPRK.nprkLedgerEntry)
      Dim Results As List(Of SIS.NPRK.nprkLedgerEntry) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "DocumentID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprkLedgerEntrySelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprkLedgerEntrySelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EmployeeID",SqlDbType.Int,10, IIf(EmployeeID = Nothing, 0,EmployeeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PerkID",SqlDbType.Int,10, IIf(PerkID = Nothing, 0,PerkID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkLedgerEntry)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkLedgerEntry(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function nprkLedgerEntrySelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal EmployeeID As Int32, ByVal PerkID As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkLedgerEntryGetByID(ByVal DocumentID As Int32) As SIS.NPRK.nprkLedgerEntry
      Dim Results As SIS.NPRK.nprkLedgerEntry = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkLedgerSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentID",SqlDbType.Int,DocumentID.ToString.Length, DocumentID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.NPRK.nprkLedgerEntry(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkLedgerEntryGetByID(ByVal DocumentID As Int32, ByVal Filter_EmployeeID As Int32, ByVal Filter_PerkID As Int32) As SIS.NPRK.nprkLedgerEntry
      Dim Results As SIS.NPRK.nprkLedgerEntry = SIS.NPRK.nprkLedgerEntry.nprkLedgerEntryGetByID(DocumentID)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function nprkLedgerEntryInsert(ByVal Record As SIS.NPRK.nprkLedgerEntry) As SIS.NPRK.nprkLedgerEntry
      Dim _Rec As SIS.NPRK.nprkLedgerEntry = SIS.NPRK.nprkLedgerEntry.nprkLedgerEntryGetNewRecord()
      With _Rec
        .EmployeeID = Record.EmployeeID
        .PerkID = Record.PerkID
        .TranType = Record.TranType
        .PostedInBaaN = Record.PostedInBaaN
        .Amount = Record.Amount
        .Remarks = Record.Remarks
        .Value = Record.Value
        .FinYear = Global.System.Web.HttpContext.Current.Session("FinYear")
        .ParentDocumentID = Record.ParentDocumentID
        .UOM = Record.UOM
        .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .TranDate = Now
      End With
      Return SIS.NPRK.nprkLedgerEntry.InsertData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
