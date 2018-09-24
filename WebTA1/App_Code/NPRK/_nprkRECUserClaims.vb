Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  <DataObject()> _
  Partial Public Class nprkRECUserClaims
    Inherits SIS.NPRK.nprkUserClaims
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkRECUserClaimsGetNewRecord() As SIS.NPRK.nprkRECUserClaims
      Return New SIS.NPRK.nprkRECUserClaims()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkRECUserClaimsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String) As List(Of SIS.NPRK.nprkRECUserClaims)
      Dim Results As List(Of SIS.NPRK.nprkRECUserClaims) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "ClaimID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprkRECUserClaimsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprkRECUserClaimsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CardNo",SqlDbType.NVarChar,8, IIf(CardNo Is Nothing, String.Empty,CardNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClaimStatusID",SqlDbType.Int,10, prkClaimStates.SubmittedToAccounts)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkRECUserClaims)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkRECUserClaims(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function nprkRECUserClaimsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal CardNo As String) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkRECUserClaimsGetByID(ByVal ClaimID As Int32) As SIS.NPRK.nprkRECUserClaims
      Dim Results As SIS.NPRK.nprkRECUserClaims = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkUserClaimsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ClaimID",SqlDbType.Int,ClaimID.ToString.Length, ClaimID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.NPRK.nprkRECUserClaims(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function nprkRECUserClaimsGetByID(ByVal ClaimID As Int32, ByVal Filter_CardNo As String) As SIS.NPRK.nprkRECUserClaims
      Dim Results As SIS.NPRK.nprkRECUserClaims = SIS.NPRK.nprkRECUserClaims.nprkRECUserClaimsGetByID(ClaimID)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function nprkRECUserClaimsUpdate(ByVal Record As SIS.NPRK.nprkRECUserClaims) As SIS.NPRK.nprkRECUserClaims
      Dim _Rec As SIS.NPRK.nprkRECUserClaims = SIS.NPRK.nprkRECUserClaims.nprkRECUserClaimsGetByID(Record.ClaimID)
      With _Rec
        .Description = Record.Description
        .CardNo = Record.CardNo
        .PassedAmount = Record.PassedAmount
        .TotalAmount = Record.TotalAmount
        .DeclarationAccepted = Record.DeclarationAccepted
        .SubmittedOn = Record.SubmittedOn
        .ReceivedOn = Record.ReceivedOn
        .ReceivedBy = Record.ReceivedBy
        .ReturnedOn = Record.ReturnedOn
        .ReturnedBy = Record.ReturnedBy
        .CompletedOn = Record.CompletedOn
        .AccountsRemarks = Record.AccountsRemarks
        .ClaimStatusID = Record.ClaimStatusID
        .ClaimRefNo = Record.ClaimRefNo
        .FinYear = Record.FinYear
      End With
      Return SIS.NPRK.nprkRECUserClaims.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
