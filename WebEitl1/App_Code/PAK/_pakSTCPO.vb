Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakSTCPO
    Inherits SIS.PAK.pakTCPO
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSTCPOGetNewRecord() As SIS.PAK.pakSTCPO
      Return New SIS.PAK.pakSTCPO()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSTCPOSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SupplierID As String, ByVal ProjectID As String, ByVal BuyerID As String, ByVal POStatusID As Int32, ByVal IssuedBy As String, ByVal POTypeID As Int32) As List(Of SIS.PAK.pakSTCPO)
      Dim Results As List(Of SIS.PAK.pakSTCPO) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakSTCPOSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakSTCPOSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SupplierID",SqlDbType.NVarChar,9, IIf(SupplierID Is Nothing, String.Empty,SupplierID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BuyerID",SqlDbType.NVarChar,8, IIf(BuyerID Is Nothing, String.Empty,BuyerID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_POStatusID",SqlDbType.Int,10, IIf(POStatusID = Nothing, 0,POStatusID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_IssuedBy",SqlDbType.NVarChar,8, IIf(IssuedBy Is Nothing, String.Empty,IssuedBy))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_POTypeID",SqlDbType.Int,10, IIf(POTypeID = Nothing, 0,POTypeID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("DivisionID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PAK.pakSTCPO)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSTCPO(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakSTCPOSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SupplierID As String, ByVal ProjectID As String, ByVal BuyerID As String, ByVal POStatusID As Int32, ByVal IssuedBy As String, ByVal POTypeID As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSTCPOGetByID(ByVal SerialNo As Int32) As SIS.PAK.pakSTCPO
      Dim Results As SIS.PAK.pakSTCPO = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakTCPOSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakSTCPO(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakSTCPOGetByID(ByVal SerialNo As Int32, ByVal Filter_SupplierID As String, ByVal Filter_ProjectID As String, ByVal Filter_BuyerID As String, ByVal Filter_POStatusID As Int32, ByVal Filter_IssuedBy As String, ByVal Filter_POTypeID As Int32) As SIS.PAK.pakSTCPO
      Dim Results As SIS.PAK.pakSTCPO = SIS.PAK.pakSTCPO.pakSTCPOGetByID(SerialNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function pakSTCPOInsert(ByVal Record As SIS.PAK.pakSTCPO) As SIS.PAK.pakSTCPO
      Dim _Rec As SIS.PAK.pakSTCPO = SIS.PAK.pakSTCPO.pakSTCPOGetNewRecord()
      With _Rec
        .PONumber = Record.PONumber
        .PORevision = Record.PORevision
        .PODate = Record.PODate
        .PODescription = Record.PODescription
        .SupplierID = Record.SupplierID
        .ProjectID = Record.ProjectID
        .BuyerID = Record.BuyerID
        .POStatusID = Record.POStatusID
        .IssuedBy = Record.IssuedBy
        .IssuedOn = Record.IssuedOn
        .ClosedBy = Record.ClosedBy
        .ClosedOn = Record.ClosedOn
        .ISGECRemarks = Record.ISGECRemarks
        .SupplierRemarks = Record.SupplierRemarks
        .DivisionID =  Global.System.Web.HttpContext.Current.Session("DivisionID")
        .IssueReasonID = Record.IssueReasonID
        .POTypeID = Record.POTypeID
        .POConsignee = Record.POConsignee
        .POOtherDetails = Record.POOtherDetails
      End With
      Return SIS.PAK.pakSTCPO.InsertData(_Rec)
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakSTCPOUpdate(ByVal Record As SIS.PAK.pakSTCPO) As SIS.PAK.pakSTCPO
      Dim _Rec As SIS.PAK.pakSTCPO = SIS.PAK.pakSTCPO.pakSTCPOGetByID(Record.SerialNo)
      With _Rec
        .PONumber = Record.PONumber
        .PORevision = Record.PORevision
        .PODate = Record.PODate
        .PODescription = Record.PODescription
        .SupplierID = Record.SupplierID
        .ProjectID = Record.ProjectID
        .BuyerID = Record.BuyerID
        .POStatusID = Record.POStatusID
        .IssuedBy = Record.IssuedBy
        .IssuedOn = Record.IssuedOn
        .ClosedBy = Record.ClosedBy
        .ClosedOn = Record.ClosedOn
        .ISGECRemarks = Record.ISGECRemarks
        .SupplierRemarks = Record.SupplierRemarks
        .DivisionID = Global.System.Web.HttpContext.Current.Session("DivisionID")
        .IssueReasonID = Record.IssueReasonID
        .POTypeID = Record.POTypeID
        .POConsignee = Record.POConsignee
        .POOtherDetails = Record.POOtherDetails
      End With
      Return SIS.PAK.pakSTCPO.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
