Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  Partial Public Class taCDExpense
    Public Shadows ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case FK_TA_BillDetails_TABillNo.BillStatusID
            Case TAStates.UnderProcessByAccounts
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property DeleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property DeleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Shadows Function DeleteWF(ByVal TABillNo As Int32, ByVal SerialNo As Int32) As SIS.TA.taCDExpense
      Dim Results As SIS.TA.taCDExpense = taCDExpenseGetByID(TABillNo, SerialNo)
      Return Results
    End Function
    Public Shared Function UZ_taCDExpenseSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taCDExpense)
      Dim Results As List(Of SIS.TA.taCDExpense) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spta_LG_CDExpenseSelectListSearch"
            Cmd.CommandText = "sptaCDExpenseSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spta_LG_CDExpenseSelectListFilteres"
            Cmd.CommandText = "sptaCDExpenseSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo", SqlDbType.Int, 10, IIf(TABillNo = Nothing, 0, TABillNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ComponentID",SqlDbType.Int,10, TAComponentTypes.Expense)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.TA.taCDExpense)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taCDExpense(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_taCDExpenseInsert(ByVal Record As SIS.TA.taCDExpense) As SIS.TA.taCDExpense
      Dim _Result As SIS.TA.taCDExpense = taCDExpenseInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_taCDExpenseUpdate(ByVal Record As SIS.TA.taCDExpense) As SIS.TA.taCDExpense
      Dim _Rec As SIS.TA.taCDExpense = SIS.TA.taCDExpense.taCDExpenseGetByID(Record.TABillNo, Record.SerialNo)
      With _Rec
        .CostCenterID = Record.CostCenterID
        .ProjectID = Record.ProjectID
        .CurrencyID = Record.CurrencyID
        .ConversionFactorINR = Record.ConversionFactorINR
        .ApprovalWFTypeID = Record.ApprovalWFTypeID
        .OOEReasonID = Record.OOEReasonID
        .PassedAmountFactor = Record.PassedAmountFactor
        .PassedAmountRate = 1
        .PassedAmountBasic = .PassedAmountFactor * .PassedAmountRate
        .PassedAmountTax = 0.00
        .PassedAmountTotal = .PassedAmountBasic + .PassedAmountTax
        .PassedAmountInINR = .PassedAmountTotal * .ConversionFactorINR
        .AccountsRemarks = Record.AccountsRemarks
        .Setteled = Record.Setteled
      End With
      _Rec = SIS.TA.taCDExpense.UpdateData(_Rec)
      SIS.TA.taCH.ValidateBillPassing(_Rec.TABillNo)
      Return _Rec
    End Function
    Public Shared Function UZ_taCDExpenseDelete(ByVal Record As SIS.TA.taCDExpense) As Int32
      Dim _Result As Integer = taBillDetailsDelete(Record)
      Return _Result
    End Function
  End Class
End Namespace
