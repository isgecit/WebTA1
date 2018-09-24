Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakSPOBOM
    Inherits SIS.PAK.pakPOBOM
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSPOBOMGetNewRecord() As SIS.PAK.pakSPOBOM
      Return New SIS.PAK.pakSPOBOM()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSPOBOMSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32) As List(Of SIS.PAK.pakSPOBOM)
      Dim Results As List(Of SIS.PAK.pakSPOBOM) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakSPOBOMSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakSPOBOMSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PAK.pakSPOBOM)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSPOBOM(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakSPOBOMSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSPOBOMGetByID(ByVal SerialNo As Int32, ByVal BOMNo As Int32) As SIS.PAK.pakSPOBOM
      Dim Results As SIS.PAK.pakSPOBOM = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakPOBOMSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BOMNo",SqlDbType.Int,BOMNo.ToString.Length, BOMNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakSPOBOM(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSPOBOMGetByID(ByVal SerialNo As Int32, ByVal BOMNo As Int32, ByVal Filter_SerialNo As Int32) As SIS.PAK.pakSPOBOM
      Dim Results As SIS.PAK.pakSPOBOM = SIS.PAK.pakSPOBOM.pakSPOBOMGetByID(SerialNo, BOMNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakSPOBOMUpdate(ByVal Record As SIS.PAK.pakSPOBOM) As SIS.PAK.pakSPOBOM
      Dim _Rec As SIS.PAK.pakSPOBOM = SIS.PAK.pakSPOBOM.pakSPOBOMGetByID(Record.SerialNo, Record.BOMNo)
      With _Rec
        .ItemNo = Record.ItemNo
        .ItemDescription = Record.ItemDescription
        .ElementID = Record.ElementID
        .StatusID = Record.StatusID
        .ISGECRemarks = Record.ISGECRemarks
        .SupplierRemarks = Record.SupplierRemarks
        .AcceptedBySupplier = Record.AcceptedBySupplier
        .FreezedBySupplier = Record.FreezedBySupplier
        .Active = Record.Active
        .Changed = Record.Changed
        .CreatedBySupplier = Record.CreatedBySupplier
        .ChangedBySupplier = Record.ChangedBySupplier
        .Root = Record.Root
        .ItemLevel = Record.ItemLevel
        .Prefix = Record.Prefix
        .Middle = Record.Middle
        .Bottom = Record.Bottom
        .Free = Record.Free
        .FreezedOn = Record.FreezedOn
        .WeightPerUnit = Record.WeightPerUnit
        .UOMWeight = Record.UOMWeight
        .ParentItemNo = Record.ParentItemNo
        .DocumentNo = Record.DocumentNo
        .Quantity = Record.Quantity
        .SupplierItemCode = Record.SupplierItemCode
        .ItemCode = Record.ItemCode
        .UOMQuantity = Record.UOMQuantity
        .DivisionID = Record.DivisionID
        .AcceptedOn = Record.AcceptedOn
        .AcceptedBy = Record.AcceptedBy
        .FreezedBy = Record.FreezedBy
        .Freezed = Record.Freezed
        .Accepted = Record.Accepted
        .ISGECWeightPerUnit = Record.ISGECWeightPerUnit
        .ISGECQuantity = Record.ISGECQuantity
        .SupplierWeightPerUnit = Record.SupplierWeightPerUnit
        .SupplierQuantity = Record.SupplierQuantity
      End With
      Return SIS.PAK.pakSPOBOM.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
