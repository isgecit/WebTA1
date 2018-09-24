Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakSPOBIDocuments
    Inherits SIS.PAK.pakPOBIDocuments
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSPOBIDocumentsGetNewRecord() As SIS.PAK.pakSPOBIDocuments
      Return New SIS.PAK.pakSPOBIDocuments()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSPOBIDocumentsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal BOMNo As Int32, ByVal ItemNo As Int32) As List(Of SIS.PAK.pakSPOBIDocuments)
      Dim Results As List(Of SIS.PAK.pakSPOBIDocuments) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakSPOBIDocumentsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakSPOBIDocumentsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BOMNo",SqlDbType.Int,10, IIf(BOMNo = Nothing, 0,BOMNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ItemNo",SqlDbType.Int,10, IIf(ItemNo = Nothing, 0,ItemNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PAK.pakSPOBIDocuments)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSPOBIDocuments(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakSPOBIDocumentsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal BOMNo As Int32, ByVal ItemNo As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSPOBIDocumentsGetByID(ByVal SerialNo As Int32, ByVal BOMNo As Int32, ByVal ItemNo As Int32, ByVal DocNo As Int32) As SIS.PAK.pakSPOBIDocuments
      Dim Results As SIS.PAK.pakSPOBIDocuments = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakPOBIDocumentsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BOMNo",SqlDbType.Int,BOMNo.ToString.Length, BOMNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo",SqlDbType.Int,ItemNo.ToString.Length, ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocNo",SqlDbType.Int,DocNo.ToString.Length, DocNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakSPOBIDocuments(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSPOBIDocumentsGetByID(ByVal SerialNo As Int32, ByVal BOMNo As Int32, ByVal ItemNo As Int32, ByVal DocNo As Int32, ByVal Filter_SerialNo As Int32, ByVal Filter_BOMNo As Int32, ByVal Filter_ItemNo As Int32) As SIS.PAK.pakSPOBIDocuments
      Dim Results As SIS.PAK.pakSPOBIDocuments = SIS.PAK.pakSPOBIDocuments.pakSPOBIDocumentsGetByID(SerialNo, BOMNo, ItemNo, DocNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function pakSPOBIDocumentsInsert(ByVal Record As SIS.PAK.pakSPOBIDocuments) As SIS.PAK.pakSPOBIDocuments
      Dim _Rec As SIS.PAK.pakSPOBIDocuments = SIS.PAK.pakSPOBIDocuments.pakSPOBIDocumentsGetNewRecord()
      With _Rec
        .SerialNo = Record.SerialNo
        .BOMNo = Record.BOMNo
        .ItemNo = Record.ItemNo
        .DocumentID = Record.DocumentID
        .DocumentRevision = Record.DocumentRevision
        .DocumentName = Record.DocumentName
        .FileName = Record.FileName
        .DiskFile = Record.DiskFile
        .CreatedBySupplier = Record.CreatedBySupplier
      End With
      Return SIS.PAK.pakSPOBIDocuments.InsertData(_Rec)
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakSPOBIDocumentsUpdate(ByVal Record As SIS.PAK.pakSPOBIDocuments) As SIS.PAK.pakSPOBIDocuments
      Dim _Rec As SIS.PAK.pakSPOBIDocuments = SIS.PAK.pakSPOBIDocuments.pakSPOBIDocumentsGetByID(Record.SerialNo, Record.BOMNo, Record.ItemNo, Record.DocNo)
      With _Rec
        .DocumentID = Record.DocumentID
        .DocumentRevision = Record.DocumentRevision
        .DocumentName = Record.DocumentName
        .FileName = Record.FileName
        .DiskFile = Record.DiskFile
        .CreatedBySupplier = Record.CreatedBySupplier
      End With
      Return SIS.PAK.pakSPOBIDocuments.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
