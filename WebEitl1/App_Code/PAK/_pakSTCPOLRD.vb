Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakSTCPOLRD
    Inherits SIS.PAK.pakTCPOLRD
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSTCPOLRDGetNewRecord() As SIS.PAK.pakSTCPOLRD
      Return New SIS.PAK.pakSTCPOLRD()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSTCPOLRDSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal ItemNo As Int32, ByVal UploadNo As Int32) As List(Of SIS.PAK.pakSTCPOLRD)
      Dim Results As List(Of SIS.PAK.pakSTCPOLRD) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakSTCPOLRDSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakSTCPOLRDSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ItemNo",SqlDbType.Int,10, IIf(ItemNo = Nothing, 0,ItemNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_UploadNo",SqlDbType.Int,10, IIf(UploadNo = Nothing, 0,UploadNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PAK.pakSTCPOLRD)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSTCPOLRD(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakSTCPOLRDSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal ItemNo As Int32, ByVal UploadNo As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSTCPOLRDGetByID(ByVal SerialNo As Int32, ByVal ItemNo As Int32, ByVal UploadNo As Int32, ByVal DocSerialNo As Int32) As SIS.PAK.pakSTCPOLRD
      Dim Results As SIS.PAK.pakSTCPOLRD = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakTCPOLRDSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo",SqlDbType.Int,ItemNo.ToString.Length, ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UploadNo",SqlDbType.Int,UploadNo.ToString.Length, UploadNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocSerialNo",SqlDbType.Int,DocSerialNo.ToString.Length, DocSerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakSTCPOLRD(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSTCPOLRDGetByID(ByVal SerialNo As Int32, ByVal ItemNo As Int32, ByVal UploadNo As Int32, ByVal DocSerialNo As Int32, ByVal Filter_SerialNo As Int32, ByVal Filter_ItemNo As Int32, ByVal Filter_UploadNo As Int32) As SIS.PAK.pakSTCPOLRD
      Dim Results As SIS.PAK.pakSTCPOLRD = SIS.PAK.pakSTCPOLRD.pakSTCPOLRDGetByID(SerialNo, ItemNo, UploadNo, DocSerialNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function pakSTCPOLRDInsert(ByVal Record As SIS.PAK.pakSTCPOLRD) As SIS.PAK.pakSTCPOLRD
      Dim _Rec As SIS.PAK.pakSTCPOLRD = SIS.PAK.pakSTCPOLRD.pakSTCPOLRDGetNewRecord()
      With _Rec
        .SerialNo = Record.SerialNo
        .ItemNo = Record.ItemNo
        .UploadNo = Record.UploadNo
        .DocumentID = Record.DocumentID
        .DocumentRev = Record.DocumentRev
        .DocumentDescription = Record.DocumentDescription
        .RevisionNo = Record.RevisionNo
        .FileName = Record.FileName
        .ReceiptNo = Record.ReceiptNo
        .DiskFileName = Record.DiskFileName
      End With
      Return SIS.PAK.pakSTCPOLRD.InsertData(_Rec)
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakSTCPOLRDUpdate(ByVal Record As SIS.PAK.pakSTCPOLRD) As SIS.PAK.pakSTCPOLRD
      Dim _Rec As SIS.PAK.pakSTCPOLRD = SIS.PAK.pakSTCPOLRD.pakSTCPOLRDGetByID(Record.SerialNo, Record.ItemNo, Record.UploadNo, Record.DocSerialNo)
      With _Rec
        .DocumentID = Record.DocumentID
        .DocumentRev = Record.DocumentRev
        .DocumentDescription = Record.DocumentDescription
        .RevisionNo = Record.RevisionNo
        .FileName = Record.FileName
        .ReceiptNo = Record.ReceiptNo
        .DiskFileName = Record.DiskFileName
      End With
      Return SIS.PAK.pakSTCPOLRD.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
