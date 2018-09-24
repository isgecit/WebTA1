Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  Partial Public Class taCDLodging
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
    Public Shared Function UZ_taCDLodgingSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taCDLodging)
      Dim Results As List(Of SIS.TA.taCDLodging) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spta_LG_CDLodgingSelectListSearch"
            Cmd.CommandText = "sptaCDLodgingSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spta_LG_CDLodgingSelectListFilteres"
            Cmd.CommandText = "sptaCDLodgingSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo", SqlDbType.Int, 10, IIf(TABillNo = Nothing, 0, TABillNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ComponentID", SqlDbType.Int, 10, TAComponentTypes.Lodging)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.TA.taCDLodging)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taCDLodging(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_taCDLodgingUpdate(ByVal Record As SIS.TA.taCDLodging) As SIS.TA.taCDLodging
      Dim _Rec As SIS.TA.taCDLodging = SIS.TA.taCDLodging.taCDLodgingGetByID(Record.TABillNo, Record.SerialNo)
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
        .PassedAmountTax = Record.PassedAmountTax
        .PassedAmountTotal = .PassedAmountBasic + .PassedAmountTax
        .PassedAmountInINR = .PassedAmountTotal * .ConversionFactorINR
        .AccountsRemarks = Record.AccountsRemarks
        .Setteled = Record.Setteled
      End With
      _Rec = SIS.TA.taCDLodging.UpdateData(_Rec)
      Try
        Dim tmp As SIS.TA.taBillGST = SIS.TA.taCDLodging.GetGSTDataFromCDL(Record)
        Dim oldRec As SIS.TA.taBillGST = SIS.TA.taBillGST.taBillGSTGetByID(tmp.TABillNo, tmp.SerialNo)
        If oldRec Is Nothing Then
          tmp = SIS.TA.taBillGST.InsertData(tmp)
        Else
          tmp = SIS.TA.taBillGST.UpdateData(tmp)
        End If
      Catch ex As Exception
      End Try
      SIS.TA.taCH.ValidateBillPassing(_Rec.TABillNo)
      Return _Rec
    End Function
    Public Shared Function GetGSTDataFromCDL(ByVal oCDL As SIS.TA.taCDLodging) As SIS.TA.taBillGST
      Dim tmp As New SIS.TA.taBillGST
      Try
        For Each pi As System.Reflection.PropertyInfo In tmp.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              CallByName(tmp, pi.Name, CallType.Let, CallByName(oCDL, pi.Name, CallType.Get))
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
        Dim aa As String = ex.Message
      End Try
      Return tmp
    End Function
    Public Shared Function UpdateGSTDataInCDL(ByVal oCDL As SIS.TA.taCDLodging) As SIS.TA.taCDLodging
      Dim tmp As SIS.TA.taBillGST = SIS.TA.taBillGST.taBillGSTGetByID(oCDL.TABillNo, oCDL.SerialNo)
      If tmp IsNot Nothing Then
        Try
          For Each pi As System.Reflection.PropertyInfo In tmp.GetType.GetProperties
            If pi.MemberType = Reflection.MemberTypes.Property Then
              Try
                Dim si As System.Reflection.PropertyInfo = tmp.GetType.GetProperty(pi.Name)
                Dim _tskip As SIS.SYS.Utilities.lgSkipAttribute = Attribute.GetCustomAttribute(si, GetType(SIS.SYS.Utilities.lgSkipAttribute))
                If _tskip IsNot Nothing Then Continue For
                CallByName(oCDL, pi.Name, CallType.Let, CallByName(tmp, pi.Name, CallType.Get))
              Catch ex As Exception
              End Try
            End If
          Next
        Catch ex As Exception
          Dim aa As String = ex.Message
        End Try
      End If
      Return oCDL
    End Function
  End Class
End Namespace
