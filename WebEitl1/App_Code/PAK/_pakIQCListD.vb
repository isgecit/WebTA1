Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakIQCListD
    Inherits SIS.PAK.pakQCListD
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakIQCListDGetNewRecord() As SIS.PAK.pakIQCListD
      Return New SIS.PAK.pakIQCListD()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakIQCListDSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal QCLNo As Int32) As List(Of SIS.PAK.pakIQCListD)
      Dim Results As List(Of SIS.PAK.pakIQCListD) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakIQCListDSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakIQCListDSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_QCLNo",SqlDbType.Int,10, IIf(QCLNo = Nothing, 0,QCLNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PAK.pakIQCListD)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakIQCListD(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakIQCListDSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal QCLNo As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakIQCListDGetByID(ByVal SerialNo As Int32, ByVal QCLNo As Int32, ByVal BOMNo As Int32, ByVal ItemNo As Int32) As SIS.PAK.pakIQCListD
      Dim Results As SIS.PAK.pakIQCListD = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakQCListDSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QCLNo",SqlDbType.Int,QCLNo.ToString.Length, QCLNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BOMNo",SqlDbType.Int,BOMNo.ToString.Length, BOMNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo",SqlDbType.Int,ItemNo.ToString.Length, ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakIQCListD(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakIQCListDGetByID(ByVal SerialNo As Int32, ByVal QCLNo As Int32, ByVal BOMNo As Int32, ByVal ItemNo As Int32, ByVal Filter_SerialNo As Int32, ByVal Filter_QCLNo As Int32) As SIS.PAK.pakIQCListD
      Dim Results As SIS.PAK.pakIQCListD = SIS.PAK.pakIQCListD.pakIQCListDGetByID(SerialNo, QCLNo, BOMNo, ItemNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakIQCListDUpdate(ByVal Record As SIS.PAK.pakIQCListD) As SIS.PAK.pakIQCListD
      Dim _Rec As SIS.PAK.pakIQCListD = SIS.PAK.pakIQCListD.pakIQCListDGetByID(Record.SerialNo, Record.QCLNo, Record.BOMNo, Record.ItemNo)
      With _Rec
        .UOMQuantity = Record.UOMQuantity
        .Quantity = Record.Quantity
        .QualityClearedQty = Record.QualityClearedQty
        .ClearedOn = Now
        .UOMWeight = Record.UOMWeight
        .WeightPerUnit = Record.WeightPerUnit
        .Remarks = Record.Remarks
        .ClearedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
      End With
      Return SIS.PAK.pakIQCListD.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
