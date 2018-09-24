Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakSPO
    Inherits SIS.PAK.pakPO
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSPOGetNewRecord() As SIS.PAK.pakSPO
      Return New SIS.PAK.pakSPO()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSPOSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal POTypeID As Int32, ByVal ProjectID As String, ByVal BuyerID As String, ByVal IssuedBy As String) As List(Of SIS.PAK.pakSPO)
      Dim Results As List(Of SIS.PAK.pakSPO) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakSPOSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakSPOSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_POTypeID",SqlDbType.Int,10, IIf(POTypeID = Nothing, 0,POTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BuyerID",SqlDbType.NVarChar,8, IIf(BuyerID Is Nothing, String.Empty,BuyerID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_IssuedBy",SqlDbType.NVarChar,8, IIf(IssuedBy Is Nothing, String.Empty,IssuedBy))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID",SqlDbType.NVarChar,9, "S" & HTTPContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@POStatusID",SqlDbType.Int,10, pakPOStates.UnderSupplierVerification)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PAK.pakSPO)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSPO(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakSPOSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal POTypeID As Int32, ByVal ProjectID As String, ByVal BuyerID As String, ByVal IssuedBy As String) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSPOGetByID(ByVal SerialNo As Int32) As SIS.PAK.pakSPO
      Dim Results As SIS.PAK.pakSPO = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakPOSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakSPO(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSPOGetByID(ByVal SerialNo As Int32, ByVal Filter_POTypeID As Int32, ByVal Filter_ProjectID As String, ByVal Filter_BuyerID As String, ByVal Filter_IssuedBy As String) As SIS.PAK.pakSPO
      Dim Results As SIS.PAK.pakSPO = SIS.PAK.pakSPO.pakSPOGetByID(SerialNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakSPOUpdate(ByVal Record As SIS.PAK.pakSPO) As SIS.PAK.pakSPO
      Dim _Rec As SIS.PAK.pakSPO = SIS.PAK.pakSPO.pakSPOGetByID(Record.SerialNo)
      With _Rec
        .POConsignee = Record.POConsignee
        .POOtherDetails = Record.POOtherDetails
        .IssueReasonID = Record.IssueReasonID
        .PONumber = Record.PONumber
        .PORevision = Record.PORevision
        .PODate = Record.PODate
        .PODescription = Record.PODescription
        .POTypeID = Record.POTypeID
        .SupplierID = Record.SupplierID
        .ProjectID = Record.ProjectID
        .BuyerID = Record.BuyerID
        .POStatusID = Record.POStatusID
        .ISGECRemarks = Record.ISGECRemarks
        .SupplierRemarks = Record.SupplierRemarks
        .IssuedBy = Record.IssuedBy
        .IssuedOn = Record.IssuedOn
        .ClosedBy = Record.ClosedBy
        .ClosedOn = Record.ClosedOn
        .DivisionID = Record.DivisionID
      End With
      Return SIS.PAK.pakSPO.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
