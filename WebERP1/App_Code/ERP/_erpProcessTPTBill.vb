Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ERP
  <DataObject()> _
  Partial Public Class erpProcessTPTBill
    Inherits SIS.ERP.erpCreateTPTBill
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpProcessTPTBillGetNewRecord() As SIS.ERP.erpProcessTPTBill
      Return New SIS.ERP.erpProcessTPTBill()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpProcessTPTBillSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TPTCode As String, ByVal ProjectID As String, ByVal BillStatus As Int32) As List(Of SIS.ERP.erpProcessTPTBill)
      Dim Results As List(Of SIS.ERP.erpProcessTPTBill) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sperpProcessTPTBillSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sperpProcessTPTBillSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TPTCode",SqlDbType.NVarChar,9, IIf(TPTCode Is Nothing, String.Empty,TPTCode))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BillStatus",SqlDbType.Int,10, IIf(BillStatus = Nothing, 0,BillStatus))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.ERP.erpProcessTPTBill)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ERP.erpProcessTPTBill(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function erpProcessTPTBillSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TPTCode As String, ByVal ProjectID As String, ByVal BillStatus As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpProcessTPTBillGetByID(ByVal SerialNo As Int32) As SIS.ERP.erpProcessTPTBill
      Dim Results As SIS.ERP.erpProcessTPTBill = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sperpCreateTPTBillSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.ERP.erpProcessTPTBill(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function erpProcessTPTBillGetByID(ByVal SerialNo As Int32, ByVal Filter_TPTCode As String, ByVal Filter_ProjectID As String, ByVal Filter_BillStatus As Int32) As SIS.ERP.erpProcessTPTBill
      Dim Results As SIS.ERP.erpProcessTPTBill = SIS.ERP.erpProcessTPTBill.erpProcessTPTBillGetByID(SerialNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function erpProcessTPTBillUpdate(ByVal Record As SIS.ERP.erpProcessTPTBill) As SIS.ERP.erpProcessTPTBill
      Dim _Rec As SIS.ERP.erpProcessTPTBill = SIS.ERP.erpProcessTPTBill.erpProcessTPTBillGetByID(Record.SerialNo)
      With _Rec
        .PTRNo = Record.PTRNo
        .PTRAmount = Record.PTRAmount
        .PTRDate = Record.PTRDate
        .BankVCHNo = Record.BankVCHNo
        .BankVCHAmount = Record.BankVCHAmount
        .BankVCHDate = Record.BankVCHDate
				.AccountsRemarks = Record.AccountsRemarks
				.ReasonID = Record.ReasonID
				.BillStatus = Record.BillStatus
      End With
      Return SIS.ERP.erpProcessTPTBill.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
