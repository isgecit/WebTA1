Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  Partial Public Class nprkSiteAllowanceAdvice
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      Select Case StatusID
        Case saAdviceStates.Returned
          mRet = Drawing.Color.Red
        Case saAdviceStates.Free
          mRet = Drawing.Color.Black
        Case saAdviceStates.ClaimsLinked
          mRet = Drawing.Color.DarkGreen
        Case Else
          mRet = Drawing.Color.DarkGoldenrod
      End Select
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = False
      If StatusID = saAdviceStates.Free Then
        mRet = True
      End If
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      If StatusID = saAdviceStates.Free Then
        mRet = True
      End If
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case StatusID
            Case saAdviceStates.ClaimsLinked, saAdviceStates.Returned
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function InitiateWF(ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal AdviceNo As Int32) As SIS.NPRK.nprkSiteAllowanceAdvice
      Dim Results As SIS.NPRK.nprkSiteAllowanceAdvice = nprkSiteAllowanceAdviceGetByID(FinYear, Quarter, AdviceNo)
      With Results
        .AccountsRemarks = ""
        .StatusID = saAdviceStates.UnderReceiveByAccounts
        .CreatedOn = Now
      End With
      Results = SIS.NPRK.nprkSiteAllowanceAdvice.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function UZ_nprkSiteAllowanceAdviceSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal FinYear As Int32, ByVal Quarter As Int32, ByVal StatusID As Int32) As List(Of SIS.NPRK.nprkSiteAllowanceAdvice)
      Dim Results As List(Of SIS.NPRK.nprkSiteAllowanceAdvice) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "AdviceNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprk_LG_SiteAllowanceAdviceSelectListSearch"
            Cmd.CommandText = "spnprkSiteAllowanceAdviceSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprk_LG_SiteAllowanceAdviceSelectListFilteres"
            Cmd.CommandText = "spnprkSiteAllowanceAdviceSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FinYear", SqlDbType.Int, 10, IIf(FinYear = Nothing, 0, FinYear))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_Quarter", SqlDbType.Int, 10, IIf(Quarter = Nothing, 0, Quarter))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StatusID", SqlDbType.Int, 10, IIf(StatusID = Nothing, 0, StatusID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkSiteAllowanceAdvice)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkSiteAllowanceAdvice(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Class tmpEmp
      Public Property CardNo As String = ""
      Sub New(ByVal rd As SqlDataReader)
        CardNo = rd("CardNo")
      End Sub
      Public Shared Function GetPendingEmps(ByVal FinYear As Integer, ByVal Quarter As Integer) As List(Of tmpEmp)
        Dim Sql As String = ""
        Sql &= " select CardNo from hrm_employees where activestate=1 and c_officeid=6 and CategoryID is not null "
        Sql &= " and cardno not in (select employeeid from prk_siteallowanceclaims where finyear=" & FinYear & " and quarter=" & Quarter & ") "
        Dim rd As SqlDataReader = Nothing
        Dim tmpEmps As New List(Of tmpEmp)
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = System.Data.CommandType.Text
            Cmd.CommandText = Sql
            Con.Open()
            rd = Cmd.ExecuteReader()
            While (rd.Read())
              tmpEmps.Add(New tmpEmp(rd))
            End While
            rd.Close()
          End Using
        End Using
        Return tmpEmps
      End Function
    End Class
    Public Shared Sub GetAndLinkSiteAllowanceClaims(ByVal Record As SIS.NPRK.nprkSiteAllowanceAdvice)
      Dim FinYear As Integer = Record.FinYear
      Dim Quarter As Integer = Record.Quarter
      '1. Get Pending Employees List
      Dim tmpEmps As List(Of tmpEmp) = tmpEmp.GetPendingEmps(FinYear, Quarter)
      '2. Process Pending Employees
      For Each tmp As tmpEmp In tmpEmps
        '2.1 Create Claim Record
        Dim tmpClaim As New SIS.NPRK.nprkSiteAllowanceClaims
        With tmpClaim
          .FinYear = FinYear
          .Quarter = Quarter
          .EmployeeID = tmp.CardNo
          .CreatedBy = tmp.CardNo
          .CreatedOn = Now
          .AdviceNo = Record.AdviceNo
          .StatusID = saClaimStates.LinkedInAdvice
          .Linked = True
        End With
        '2.2 Update Entitlement Days and Amount
        tmpClaim = SIS.NPRK.nprkSiteAllowanceClaims.UpdateEntitlementDaysAndAmounts(tmpClaim)
        tmpClaim = SIS.NPRK.nprkLinkedSAClaims.InsertData(tmpClaim)
      Next
      '3. Get Total Amount in Advice
      Dim tmpTot As Decimal = 0
      tmpTot = ExecuteScalar("select ISNULL(sum(TotalApprovedAmount),0) as tot from  PRK_SiteAllowanceClaims where adviceno=" & Record.AdviceNo)
      With Record
        .TotalAdviceAmount = tmpTot
        .StatusID = saAdviceStates.ClaimsLinked
      End With
      '4. Update Advice
      Record = SIS.NPRK.nprkSiteAllowanceAdvice.UpdateData(Record)
    End Sub
    Public Shared Function ExecuteScalar(ByVal mSQL As String) As Object
      Dim mRet As Object = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = System.Data.CommandType.Text
          Cmd.CommandText = mSQL
          Con.Open()
          mRet = Cmd.ExecuteScalar()
        End Using
      End Using
      Return mRet
    End Function
    Public Shared Function UZ_nprkSiteAllowanceAdviceInsert(ByVal Record As SIS.NPRK.nprkSiteAllowanceAdvice) As SIS.NPRK.nprkSiteAllowanceAdvice
      Dim _Result As SIS.NPRK.nprkSiteAllowanceAdvice = nprkSiteAllowanceAdviceInsert(Record)
      GetAndLinkSiteAllowanceClaims(_Result)
      Return _Result
    End Function
    Public Shared Function UZ_nprkSiteAllowanceAdviceUpdate(ByVal Record As SIS.NPRK.nprkSiteAllowanceAdvice) As SIS.NPRK.nprkSiteAllowanceAdvice
      Dim _Result As SIS.NPRK.nprkSiteAllowanceAdvice = nprkSiteAllowanceAdviceUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_nprkSiteAllowanceAdviceDelete(ByVal Record As SIS.NPRK.nprkSiteAllowanceAdvice) As Integer
      Dim _Result as Integer = nprkSiteAllowanceAdviceDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_FinYear"), Object).SelectedValue = ""
          CType(.FindControl("F_Quarter"), Object).SelectedValue = ""
          CType(.FindControl("F_AdviceNo"), TextBox).Text = ""
          CType(.FindControl("F_Remarks"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function nprkSiteAllowanceAdviceGetByID(ByVal PrimaryKey As String) As SIS.NPRK.nprkSiteAllowanceAdvice
      Dim tmp() As String = PrimaryKey.Split("|".ToCharArray)
      Dim FinYear As Int32 = tmp(0)
      Dim Quarter As Int32 = tmp(1)
      Dim AdviceNo As Int32 = tmp(2)
      Dim Results As SIS.NPRK.nprkSiteAllowanceAdvice = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprkSiteAllowanceAdviceSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.Int, FinYear.ToString.Length, FinYear)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quarter", SqlDbType.Int, Quarter.ToString.Length, Quarter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AdviceNo", SqlDbType.Int, AdviceNo.ToString.Length, AdviceNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.NPRK.nprkSiteAllowanceAdvice(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function

    Public Shared Sub Validate(ByVal PrimaryKey As String)
      Dim tmpA As SIS.NPRK.nprkSiteAllowanceAdvice = SIS.NPRK.nprkSiteAllowanceAdvice.nprkSiteAllowanceAdviceGetByID(PrimaryKey)
      tmpA.TotalAdviceAmount = "0.00"
      tmpA.StatusID = saAdviceStates.Free
      Dim tmp As Decimal = 0
      tmp = ExecuteScalar("select ISNull(sum(TotalApprovedAmount),0) as tot from  PRK_SiteAllowanceClaims where adviceno=" & tmpA.AdviceNo)
      If tmp > 0 Then
        tmpA.TotalAdviceAmount = tmp
      End If
      tmpA.StatusID = saAdviceStates.ClaimsLinked
      SIS.NPRK.nprkSiteAllowanceAdvice.UpdateData(tmpA)
    End Sub
  End Class
End Namespace
