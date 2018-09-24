Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakHPending
    Inherits SIS.PAK.pakPkgListH
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakHPendingGetNewRecord() As SIS.PAK.pakHPending
      Return New SIS.PAK.pakHPending()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakHPendingSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32) As List(Of SIS.PAK.pakHPending)
      Dim Results As List(Of SIS.PAK.pakHPending) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakHPendingSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakHPendingSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PAK.pakHPending)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakHPending(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakHPendingSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakHPendingGetByID(ByVal SerialNo As Int32, ByVal PkgNo As Int32) As SIS.PAK.pakHPending
      Dim Results As SIS.PAK.pakHPending = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakPkgListHSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PkgNo",SqlDbType.Int,PkgNo.ToString.Length, PkgNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakHPending(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakHPendingGetByID(ByVal SerialNo As Int32, ByVal PkgNo As Int32, ByVal Filter_SerialNo As Int32) As SIS.PAK.pakHPending
      Dim Results As SIS.PAK.pakHPending = SIS.PAK.pakHPending.pakHPendingGetByID(SerialNo, PkgNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakHPendingUpdate(ByVal Record As SIS.PAK.pakHPending) As SIS.PAK.pakHPending
      Dim _Rec As SIS.PAK.pakHPending = SIS.PAK.pakHPending.pakHPendingGetByID(Record.SerialNo, Record.PkgNo)
      With _Rec
        .SupplierRefNo = Record.SupplierRefNo
        .TransporterID = Record.TransporterID
        .TransporterName = Record.TransporterName
        .VehicleNo = Record.VehicleNo
        .GRNo = Record.GRNo
        .GRDate = Record.GRDate
        .VRExecutionNo = Record.VRExecutionNo
        .Remarks = Record.Remarks
        .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .Additional2Info = Record.Additional2Info
        .Additional1Info = Record.Additional1Info
        .CreatedOn = Record.CreatedOn
        .TotalWeight = Record.TotalWeight
        .UOMTotalWeight = Record.UOMTotalWeight
        .StatusID = Record.StatusID
      End With
      Return SIS.PAK.pakHPending.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
