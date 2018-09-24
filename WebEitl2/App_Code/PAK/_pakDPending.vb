Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakDPending
    Inherits SIS.PAK.pakPkgListD
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakDPendingGetNewRecord() As SIS.PAK.pakDPending
      Return New SIS.PAK.pakDPending()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakDPendingSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PkgNo As Int32, ByVal SerialNo As Int32) As List(Of SIS.PAK.pakDPending)
      Dim Results As List(Of SIS.PAK.pakDPending) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakDPendingSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakDPendingSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PkgNo",SqlDbType.Int,10, IIf(PkgNo = Nothing, 0,PkgNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PAK.pakDPending)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakDPending(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakDPendingSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PkgNo As Int32, ByVal SerialNo As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakDPendingGetByID(ByVal SerialNo As Int32, ByVal PkgNo As Int32, ByVal BOMNo As Int32, ByVal ItemNo As Int32) As SIS.PAK.pakDPending
      Dim Results As SIS.PAK.pakDPending = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakPkgListDSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PkgNo",SqlDbType.Int,PkgNo.ToString.Length, PkgNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BOMNo",SqlDbType.Int,BOMNo.ToString.Length, BOMNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo",SqlDbType.Int,ItemNo.ToString.Length, ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakDPending(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakDPendingGetByID(ByVal SerialNo As Int32, ByVal PkgNo As Int32, ByVal BOMNo As Int32, ByVal ItemNo As Int32, ByVal Filter_PkgNo As Int32, ByVal Filter_SerialNo As Int32) As SIS.PAK.pakDPending
      Dim Results As SIS.PAK.pakDPending = SIS.PAK.pakDPending.pakDPendingGetByID(SerialNo, PkgNo, BOMNo, ItemNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function pakDPendingInsert(ByVal Record As SIS.PAK.pakDPending) As SIS.PAK.pakDPending
      Dim _Rec As SIS.PAK.pakDPending = SIS.PAK.pakDPending.pakDPendingGetNewRecord()
      With _Rec
        .ItemNo = Record.ItemNo
        .UOMQuantity = Record.UOMQuantity
        .Quantity = Record.Quantity
        .UOMWeight = Record.UOMWeight
        .WeightPerUnit = Record.WeightPerUnit
        .UOMPack = Record.UOMPack
        .PackHeight = Record.PackHeight
        .Remarks = Record.Remarks
        .QuantityReceived = Record.QuantityReceived
        .TotalWeightReceived = Record.TotalWeightReceived
        .QuantityBalance = Record.QuantityBalance
        .TotalWeightBalance = Record.TotalWeightBalance
        .BOMNo = Record.BOMNo
        .PkgNo = Record.PkgNo
        .SerialNo = Record.SerialNo
        .PackTypeID = Record.PackTypeID
        .PackWidth = Record.PackWidth
        .PackLength = Record.PackLength
        .PackingMark = Record.PackingMark
      End With
      Return SIS.PAK.pakDPending.InsertData(_Rec)
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakDPendingUpdate(ByVal Record As SIS.PAK.pakDPending) As SIS.PAK.pakDPending
      Dim _Rec As SIS.PAK.pakDPending = SIS.PAK.pakDPending.pakDPendingGetByID(Record.SerialNo, Record.PkgNo, Record.BOMNo, Record.ItemNo)
      With _Rec
        .UOMQuantity = Record.UOMQuantity
        .Quantity = Record.Quantity
        .UOMWeight = Record.UOMWeight
        .WeightPerUnit = Record.WeightPerUnit
        .UOMPack = Record.UOMPack
        .PackHeight = Record.PackHeight
        .Remarks = Record.Remarks
        .QuantityReceived = Record.QuantityReceived
        .TotalWeightReceived = Record.TotalWeightReceived
        .QuantityBalance = Record.QuantityBalance
        .TotalWeightBalance = Record.TotalWeightBalance
        .PackTypeID = Record.PackTypeID
        .PackWidth = Record.PackWidth
        .PackLength = Record.PackLength
        .PackingMark = Record.PackingMark
      End With
      Return SIS.PAK.pakDPending.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
