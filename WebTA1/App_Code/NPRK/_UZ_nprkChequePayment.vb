Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  Partial Public Class nprkChequePayment
    Public ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ApproveWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property RejectWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property RejectWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function ApproveWF(ByVal ClaimID As Int32, ByVal ApplicationID As Int32, ByVal UpdatedInLedger As Boolean) As SIS.NPRK.nprkChequePayment
      If Not UpdatedInLedger Then
        Throw New Exception("Paid Value is NO, cannot process.")
      End If
      Dim Results As SIS.NPRK.nprkChequePayment = nprkChequePaymentGetByID(ClaimID, ApplicationID)
      With Results
        .StatusID = prkPerkStates.Paid
        .UpdatedInLedger = UpdatedInLedger
        .UpdatedOn = HttpContext.Current.Session("Today")
        .UpdatedBy = HttpContext.Current.Session("LoginID")
      End With
      SIS.NPRK.nprkChequePayment.UpdateData(Results)
      SIS.NPRK.nprkUserClaims.UpdatePaid(Results.ClaimID)
      ' Insert in ledger
      Dim oApl As SIS.NPRK.nprkApplications = SIS.NPRK.nprkApplications.nprkApplicationsGetByID(Results.ClaimID, Results.ApplicationID)
      Dim oLgr As SIS.NPRK.nprkLedger = SIS.NPRK.nprkLedger.GetByApplicationID(Results.ApplicationID)
      If oLgr Is Nothing Then
        oLgr = New SIS.NPRK.nprkLedger
        With oLgr
          .Amount = (-1) * oApl.ApprovedAmt
          .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
          .EmployeeID = oApl.EmployeeID
          .FinYear = Global.System.Web.HttpContext.Current.Session("FinYear")
          .PerkID = oApl.PerkID
          Select Case oApl.PerkID
            Case 5, 12
              Dim First As Boolean = True
              Dim oBills As List(Of SIS.NPRK.nprkBillDetails) = SIS.NPRK.nprkBillDetails.nprkBillDetailsSelectList(0, 999, "", False, "", oApl.ApplicationID, oApl.ClaimID)
              .Remarks = ""
              For Each bl As SIS.NPRK.nprkBillDetails In oBills
                If First Then
                  .Remarks &= bl.BillDate
                  First = False
                Else
                  .Remarks &= "- " & Convert.ToDateTime(bl.BillDate).Month
                End If
              Next
            Case Else
              .Remarks = "Paid to " & oApl.PRK_Employees1_EmployeeName
          End Select
          .TranDate = Global.System.Web.HttpContext.Current.Session("Today")
          .TranType = "JVR"
          .UOM = oApl.FK_PRK_Applications_PRK_Perks.UOM
          .Value = (-1) * oApl.ApprovedValue
          .ApplicationID = oApl.ApplicationID
        End With
        SIS.NPRK.nprkLedger.InsertData(oLgr)
      End If
      ' Ledger Inserted
      Return Results
    End Function
    Public Shared Function RejectWF(ByVal ClaimID As Int32, ByVal ApplicationID As Int32, ByVal UpdatedInLedger As Boolean) As SIS.NPRK.nprkChequePayment
      If UpdatedInLedger Then
        Throw New Exception("Paid Value is YES, cannot return.")
      End If
      Dim Results As SIS.NPRK.nprkChequePayment = nprkChequePaymentGetByID(ClaimID, ApplicationID)
      With Results
        .StatusID = prkPerkStates.UnderApproval
        .ApproverRemark = "Returned From Cheque Payment"
        .UpdatedOn = HttpContext.Current.Session("Today")
        .UpdatedBy = HttpContext.Current.Session("LoginID")
      End With
      SIS.NPRK.nprkChequePayment.UpdateData(Results)
      'Dim oLgr As SIS.NPRK.nprkLedger = SIS.NPRK.nprkLedger.GetByApplicationID(Results.ApplicationID)
      'SIS.NPRK.nprkLedger.UZ_nprkLedgerDelete(oLgr)
      Return Results
    End Function
    Public Shared Function UZ_nprkChequePaymentSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PerkID As Int32, ByVal EmployeeID As Int32) As List(Of SIS.NPRK.nprkChequePayment)
      Dim Results As List(Of SIS.NPRK.nprkChequePayment) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "ApplicationID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprk_LG_ChequePaymentSelectListSearch"
            Cmd.CommandText = "spnprkChequePaymentSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprk_LG_ChequePaymentSelectListFilteres"
            Cmd.CommandText = "spnprkChequePaymentSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PerkID",SqlDbType.Int,10, IIf(PerkID = Nothing, 0,PerkID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_EmployeeID",SqlDbType.Int,10, IIf(EmployeeID = Nothing, 0,EmployeeID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,10, prkPerkStates.UnderPayment)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("FinYear"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PaymentMethod",SqlDbType.NVarChar,20, "Cheque")
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkChequePayment)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkChequePayment(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_nprkChequePaymentUpdate(ByVal Record As SIS.NPRK.nprkChequePayment) As SIS.NPRK.nprkChequePayment
      Dim _Result As SIS.NPRK.nprkChequePayment = nprkChequePaymentUpdate(Record)
      Return _Result
    End Function
  End Class
End Namespace
