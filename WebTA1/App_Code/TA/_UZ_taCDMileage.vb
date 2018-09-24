Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  Partial Public Class taCDMileage
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
    Public Shared Function UZ_taCDMileageSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taCDMileage)
      Dim Results As List(Of SIS.TA.taCDMileage) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spta_LG_CDMileageSelectListSearch"
            Cmd.CommandText = "sptaCDMileageSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spta_LG_CDMileageSelectListFilteres"
            Cmd.CommandText = "sptaCDMileageSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo", SqlDbType.Int, 10, IIf(TABillNo = Nothing, 0, TABillNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ComponentID", SqlDbType.Int, 10, TAComponentTypes.Mileage)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.TA.taCDMileage)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taCDMileage(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_taCDMileageUpdate(ByVal Record As SIS.TA.taCDMileage) As SIS.TA.taCDMileage
      Dim _Rec As SIS.TA.taCDMileage = SIS.TA.taCDMileage.taCDMileageGetByID(Record.TABillNo, Record.SerialNo)
      With _Rec
        .CostCenterID = Record.CostCenterID
        .ProjectID = Record.ProjectID
        .CurrencyID = Record.CurrencyID
        .ConversionFactorINR = Record.ConversionFactorINR
        .ApprovalWFTypeID = Record.ApprovalWFTypeID
        .OOEReasonID = Record.OOEReasonID
        .PassedAmountFactor = Record.PassedAmountFactor
        .PassedAmountRate = Record.PassedAmountRate
        .PassedAmountBasic = .PassedAmountFactor * .PassedAmountRate
        .PassedAmountTax = 0.00
        .PassedAmountTotal = .PassedAmountBasic + .PassedAmountTax
        .PassedAmountInINR = .PassedAmountTotal * .ConversionFactorINR
        .AccountsRemarks = Record.AccountsRemarks
        .Setteled = Record.Setteled
      End With
      _Rec = SIS.TA.taCDMileage.UpdateData(_Rec)
      SIS.TA.taCH.ValidateBillPassing(_Rec.TABillNo)
      Return _Rec
    End Function
  End Class
End Namespace
