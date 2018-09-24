Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakSTCPOLR
    Inherits SIS.PAK.pakTCPOLR
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSTCPOLRGetNewRecord() As SIS.PAK.pakSTCPOLR
      Return New SIS.PAK.pakSTCPOLR()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSTCPOLRSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal ItemNo As Int32) As List(Of SIS.PAK.pakSTCPOLR)
      Dim Results As List(Of SIS.PAK.pakSTCPOLR) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakSTCPOLRSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakSTCPOLRSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ItemNo",SqlDbType.Int,10, IIf(ItemNo = Nothing, 0,ItemNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PAK.pakSTCPOLR)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSTCPOLR(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakSTCPOLRSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal ItemNo As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSTCPOLRGetByID(ByVal SerialNo As Int32, ByVal ItemNo As Int32, ByVal UploadNo As Int32) As SIS.PAK.pakSTCPOLR
      Dim Results As SIS.PAK.pakSTCPOLR = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakTCPOLRSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo",SqlDbType.Int,ItemNo.ToString.Length, ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UploadNo",SqlDbType.Int,UploadNo.ToString.Length, UploadNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakSTCPOLR(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSTCPOLRGetByID(ByVal SerialNo As Int32, ByVal ItemNo As Int32, ByVal UploadNo As Int32, ByVal Filter_SerialNo As Int32, ByVal Filter_ItemNo As Int32) As SIS.PAK.pakSTCPOLR
      Dim Results As SIS.PAK.pakSTCPOLR = SIS.PAK.pakSTCPOLR.pakSTCPOLRGetByID(SerialNo, ItemNo, UploadNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function pakSTCPOLRInsert(ByVal Record As SIS.PAK.pakSTCPOLR) As SIS.PAK.pakSTCPOLR
      Dim _Rec As SIS.PAK.pakSTCPOLR = SIS.PAK.pakSTCPOLR.pakSTCPOLRGetNewRecord()
      With _Rec
        .SerialNo = Record.SerialNo
        .ItemNo = Record.ItemNo
        .DocumentCategoryID = Record.DocumentCategoryID
        .UploadRemarks = Record.UploadRemarks
        .UploadStatusID = pakTCUploadStates.Free
        .RevisionNo = Record.RevisionNo
        .CreatedOn = Record.CreatedOn
        .CreatedBy = Record.CreatedBy
        .ReceiptNo = Record.ReceiptNo
      End With
      Return SIS.PAK.pakSTCPOLR.InsertData(_Rec)
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakSTCPOLRUpdate(ByVal Record As SIS.PAK.pakSTCPOLR) As SIS.PAK.pakSTCPOLR
      Dim _Rec As SIS.PAK.pakSTCPOLR = SIS.PAK.pakSTCPOLR.pakSTCPOLRGetByID(Record.SerialNo, Record.ItemNo, Record.UploadNo)
      With _Rec
        .DocumentCategoryID = Record.DocumentCategoryID
        .UploadRemarks = Record.UploadRemarks
        .UploadStatusID = Record.UploadStatusID
        .RevisionNo = Record.RevisionNo
        .CreatedOn = Record.CreatedOn
        .CreatedBy = Record.CreatedBy
        .ReceiptNo = Record.ReceiptNo
      End With
      Return SIS.PAK.pakSTCPOLR.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
