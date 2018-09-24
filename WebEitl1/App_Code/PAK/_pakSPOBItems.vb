Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakSPOBItems
    Inherits SIS.PAK.pakPOBItems
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSPOBItemsGetNewRecord() As SIS.PAK.pakSPOBItems
      Return New SIS.PAK.pakSPOBItems()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSPOBItemsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal BOMNo As Int32, ByVal SerialNo As Int32) As List(Of SIS.PAK.pakSPOBItems)
      Dim Results As List(Of SIS.PAK.pakSPOBItems) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakSPOBItemsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakSPOBItemsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BOMNo",SqlDbType.Int,10, IIf(BOMNo = Nothing, 0,BOMNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PAK.pakSPOBItems)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSPOBItems(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakSPOBItemsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal BOMNo As Int32, ByVal SerialNo As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSPOBItemsGetByID(ByVal SerialNo As Int32, ByVal BOMNo As Int32, ByVal ItemNo As Int32) As SIS.PAK.pakSPOBItems
      Dim Results As SIS.PAK.pakSPOBItems = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakPOBItemsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BOMNo",SqlDbType.Int,BOMNo.ToString.Length, BOMNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo",SqlDbType.Int,ItemNo.ToString.Length, ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakSPOBItems(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSPOBItemsGetByID(ByVal SerialNo As Int32, ByVal BOMNo As Int32, ByVal ItemNo As Int32, ByVal Filter_BOMNo As Int32, ByVal Filter_SerialNo As Int32) As SIS.PAK.pakSPOBItems
      Dim Results As SIS.PAK.pakSPOBItems = SIS.PAK.pakSPOBItems.pakSPOBItemsGetByID(SerialNo, BOMNo, ItemNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakSPOBItemsUpdate(ByVal Record As SIS.PAK.pakSPOBItems) As SIS.PAK.pakSPOBItems
      Dim _Rec As SIS.PAK.pakSPOBItems = SIS.PAK.pakSPOBItems.pakSPOBItemsGetByID(Record.SerialNo, Record.BOMNo, Record.ItemNo)
      With _Rec
        .ItemCode = Record.ItemCode
        .ItemDescription = Record.ItemDescription
        .ElementID = Record.ElementID
        .Quantity = Record.Quantity
        .WeightPerUnit = Record.WeightPerUnit
        .StatusID = Record.StatusID
        .Bottom = Record.Bottom
        .Free = Record.Free
        .Middle = Record.Middle
        .Root = Record.Root
        .ChangedBySupplier = Record.ChangedBySupplier
        .CreatedBySupplier = Record.CreatedBySupplier
        .Changed = Record.Changed
        .Active = Record.Active
        .FreezedBySupplier = Record.FreezedBySupplier
        .AcceptedBySupplier = Record.AcceptedBySupplier
        .QuantityDespatched = Record.QuantityDespatched
        .TotalWeightToDespatch = Record.TotalWeightToDespatch
        .TotalWeightDespatched = Record.TotalWeightDespatched
        .TotalWeightReceived = Record.TotalWeightReceived
        .QuantityReceived = Record.QuantityReceived
        .Prefix = Record.Prefix
        .ItemLevel = Record.ItemLevel
        .QuantityToPack = Record.QuantityToPack
        .QuantityToDespatch = Record.QuantityToDespatch
        .TotalWeightToPack = Record.TotalWeightToPack
        .DocumentNo = Record.DocumentNo
        .UOMWeight = Record.UOMWeight
        .ParentItemNo = Record.ParentItemNo
        .SupplierRemarks = Record.SupplierRemarks
        .ISGECRemarks = Record.ISGECRemarks
        .SupplierItemCode = Record.SupplierItemCode
        .UOMQuantity = Record.UOMQuantity
        .DivisionID = Record.DivisionID
        .AcceptedOn = Record.AcceptedOn
        .AcceptedBy = Record.AcceptedBy
        .Freezed = Record.Freezed
        .FreezedOn = Record.FreezedOn
        .FreezedBy = Record.FreezedBy
        .ISGECWeightPerUnit = Record.ISGECWeightPerUnit
        .ISGECQuantity = Record.ISGECQuantity
        .SupplierQuantity = Record.SupplierQuantity
        .Accepted = Record.Accepted
        .SupplierWeightPerUnit = Record.SupplierWeightPerUnit
      End With
      Return SIS.PAK.pakSPOBItems.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
