Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PSF
  <DataObject()> _
  Partial Public Class psfApproved
    Inherits SIS.PSF.psfCreation
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function psfApprovedGetNewRecord() As SIS.PSF.psfApproved
      Return New SIS.PSF.psfApproved()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function psfApprovedSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal SupplierCode As String, ByVal CreatedBy As String, ByVal ApprovedBy As String) As List(Of SIS.PSF.psfApproved)
      Dim Results As List(Of SIS.PSF.psfApproved) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppsfApprovedSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppsfApprovedSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SupplierCode",SqlDbType.NVarChar,9, IIf(SupplierCode Is Nothing, String.Empty,SupplierCode))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CreatedBy",SqlDbType.NVarChar,8, IIf(CreatedBy Is Nothing, String.Empty,CreatedBy))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ApprovedBy",SqlDbType.NVarChar,8, IIf(ApprovedBy Is Nothing, String.Empty,ApprovedBy))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PSFStatus",SqlDbType.Int,10, "3")
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PSF.psfApproved)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PSF.psfApproved(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function psfApprovedSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal SupplierCode As String, ByVal CreatedBy As String, ByVal ApprovedBy As String) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function psfApprovedGetByID(ByVal SerialNo As Int32) As SIS.PSF.psfApproved
      Dim Results As SIS.PSF.psfApproved = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppsfCreationSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PSF.psfApproved(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function psfApprovedGetByID(ByVal SerialNo As Int32, ByVal Filter_SerialNo As Int32, ByVal Filter_SupplierCode As String, ByVal Filter_CreatedBy As String, ByVal Filter_ApprovedBy As String) As SIS.PSF.psfApproved
      Dim Results As SIS.PSF.psfApproved = SIS.PSF.psfApproved.psfApprovedGetByID(SerialNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function psfApprovedUpdate(ByVal Record As SIS.PSF.psfApproved) As SIS.PSF.psfApproved
      Dim _Rec As SIS.PSF.psfApproved = SIS.PSF.psfApproved.psfApprovedGetByID(Record.SerialNo)
      With _Rec
        .PaymentDateToBank = Record.PaymentDateToBank
        .ChequeNoPaidToBank = Record.ChequeNoPaidToBank
        .HSBCToVendor = Record.HSBCToVendor
        .HSBCInterestDays = Record.HSBCInterestDays
        .HSBCInterestAmountInStatement = Record.HSBCInterestAmountInStatement
        .ModifiedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .ModifiedOn = Now
      End With
      Return SIS.PSF.psfApproved.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
