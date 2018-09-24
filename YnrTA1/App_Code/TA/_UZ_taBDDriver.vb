Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  Partial Public Class taBDDriver
    Public Shared Function UZ_taBDDriverSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taBDDriver)
      Dim Results As List(Of SIS.TA.taBDDriver) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spta_LG_BDDriverSelectListSearch"
            Cmd.CommandText = "sptaBDDriverSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spta_LG_BDDriverSelectListFilteres"
            Cmd.CommandText = "sptaBDDriverSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo", SqlDbType.Int, 10, IIf(TABillNo = Nothing, 0, TABillNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ComponentID", SqlDbType.Int, 10, TAComponentTypes.Driver)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.TA.taBDDriver)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBDDriver(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_taBDDriverInsert(ByVal Record As SIS.TA.taBDDriver) As SIS.TA.taBDDriver
      Dim _Result As SIS.TA.taBDDriver = taBDDriverInsert(Record)
      taBH.ValidateTABill(Record.TABillNo)
      Return _Result
    End Function
    Public Shared Function UZ_taBDDriverUpdate(ByVal Record As SIS.TA.taBDDriver) As SIS.TA.taBDDriver
      Dim _Result As SIS.TA.taBDDriver = taBDDriverUpdate(Record)
      taBH.ValidateTABill(Record.TABillNo)
      Return _Result
    End Function
    Public Shared Function UZ_taBDDriverDelete(ByVal Record As SIS.TA.taBDDriver) As Int32
      Dim _Result As Integer = taBillDetailsDelete(Record)
      taBH.ValidateTABill(Record.TABillNo)
      Return _Result
    End Function
  End Class
End Namespace
