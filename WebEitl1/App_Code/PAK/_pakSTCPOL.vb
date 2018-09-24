Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakSTCPOL
    Inherits SIS.PAK.pakTCPOL
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSTCPOLGetNewRecord() As SIS.PAK.pakSTCPOL
      Return New SIS.PAK.pakSTCPOL()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSTCPOLSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32) As List(Of SIS.PAK.pakSTCPOL)
      Dim Results As List(Of SIS.PAK.pakSTCPOL) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakSTCPOLSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakSTCPOLSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PAK.pakSTCPOL)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSTCPOL(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakSTCPOLSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSTCPOLGetByID(ByVal SerialNo As Int32, ByVal ItemNo As Int32) As SIS.PAK.pakSTCPOL
      Dim Results As SIS.PAK.pakSTCPOL = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakTCPOLSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo",SqlDbType.Int,ItemNo.ToString.Length, ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakSTCPOL(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSTCPOLGetByID(ByVal SerialNo As Int32, ByVal ItemNo As Int32, ByVal Filter_SerialNo As Int32) As SIS.PAK.pakSTCPOL
      Dim Results As SIS.PAK.pakSTCPOL = SIS.PAK.pakSTCPOL.pakSTCPOLGetByID(SerialNo, ItemNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function pakSTCPOLInsert(ByVal Record As SIS.PAK.pakSTCPOL) As SIS.PAK.pakSTCPOL
      Dim _Rec As SIS.PAK.pakSTCPOL = SIS.PAK.pakSTCPOL.pakSTCPOLGetNewRecord()
      With _Rec
        .SerialNo = Record.SerialNo
        .ItemNo = Record.ItemNo
        .ItemCode = Record.ItemCode
        .ItemDescription = Record.ItemDescription
        .ItemQuantity = Record.ItemQuantity
        .ItemUnit = Record.ItemUnit
        .ItemPrice = Record.ItemPrice
        .ItemAmount = Record.ItemAmount
        .ItemElement = Record.ItemElement
        .ItemStatusID = Record.ItemStatusID
      End With
      Return SIS.PAK.pakSTCPOL.InsertData(_Rec)
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakSTCPOLUpdate(ByVal Record As SIS.PAK.pakSTCPOL) As SIS.PAK.pakSTCPOL
      Dim _Rec As SIS.PAK.pakSTCPOL = SIS.PAK.pakSTCPOL.pakSTCPOLGetByID(Record.SerialNo, Record.ItemNo)
      With _Rec
        .ItemCode = Record.ItemCode
        .ItemDescription = Record.ItemDescription
        .ItemQuantity = Record.ItemQuantity
        .ItemUnit = Record.ItemUnit
        .ItemPrice = Record.ItemPrice
        .ItemAmount = Record.ItemAmount
        .ItemElement = Record.ItemElement
        .ItemStatusID = Record.ItemStatusID
      End With
      Return SIS.PAK.pakSTCPOL.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
