Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  Partial Public Class nprkLedgerEntry
    Public Shadows Function GetEditable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Shadows Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      Return mRet
    End Function
    Public Shadows ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function UZ_nprkLedgerEntrySelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal EmployeeID As Int32, ByVal PerkID As Int32) As List(Of SIS.NPRK.nprkLedgerEntry)
      Dim Results As List(Of SIS.NPRK.nprkLedgerEntry) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "DocumentID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprk_LG_LedgerEntrySelectListSearch"
            Cmd.CommandText = "spnprkLedgerEntrySelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprk_LG_LedgerEntrySelectListFilteres"
            Cmd.CommandText = "spnprkLedgerEntrySelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EmployeeID", SqlDbType.Int, 10, IIf(EmployeeID = Nothing, 0, EmployeeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PerkID", SqlDbType.Int, 10, IIf(PerkID = Nothing, 0, PerkID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.Int, 10, Global.System.Web.HttpContext.Current.Session("FinYear"))
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
    Public Shared Function UZ_nprkLedgerEntryInsert(ByVal Record As SIS.NPRK.nprkLedgerEntry) As SIS.NPRK.nprkLedgerEntry
      Dim _Rec As SIS.NPRK.nprkLedgerEntry = SIS.NPRK.nprkLedgerEntry.nprkLedgerEntryGetNewRecord()
      With _Rec
        .EmployeeID = Record.EmployeeID
        .PerkID = Record.PerkID
        .TranType = Record.TranType
        .Amount = Record.Amount
        .Remarks = Record.Remarks
        .Value = Record.Amount
        .FinYear = Global.System.Web.HttpContext.Current.Session("FinYear")
        .UOM = "Rs."
        .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .TranDate = Now
      End With
      _Rec = SIS.NPRK.nprkLedgerEntry.InsertData(_Rec)
      If Record.PostedInBaaN Then
        Dim __Rec As SIS.NPRK.nprkLedgerEntry = SIS.NPRK.nprkLedgerEntry.nprkLedgerEntryGetNewRecord()
        With __Rec
          .ParentDocumentID = _Rec.DocumentID
          .EmployeeID = Record.EmployeeID
          .PerkID = Record.TargetPerkID
          .TranType = Record.TranType
          .Amount = Record.Amount * -1
          .Remarks = Record.Remarks
          .Value = Record.Amount * -1
          .FinYear = Global.System.Web.HttpContext.Current.Session("FinYear")
          .UOM = "Rs."
          .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
          .TranDate = Now
        End With
        __Rec = SIS.NPRK.nprkLedgerEntry.InsertData(__Rec)
      End If
      Return _Rec
    End Function
  End Class
End Namespace
