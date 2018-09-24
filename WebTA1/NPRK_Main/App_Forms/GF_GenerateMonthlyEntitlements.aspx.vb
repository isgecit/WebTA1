Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Web.Script.Serialization

Partial Class GF_GenerateMonthlyEntitlements
  Inherits SIS.SYS.GridBase
  Private L_ScriptTimeOut As Integer = 0
  Protected Sub CmdGenerate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdGenerate.Click
    Dim L_SessionTimeOut As Integer = HttpContext.Current.Session.Timeout
    HttpContext.Current.Session.Timeout = 60
    Dim oFYr As SIS.NPRK.nprkFinYears = SIS.NPRK.nprkFinYears.nprkFinYearsGetByID(HttpContext.Current.Session("FinYear"))
    Dim FMon As String = F_Qtr.SelectedValue
    Dim FYr As String = ""
    If FMon = "1" Then
      FYr = Convert.ToDateTime(oFYr.EndDate).Year
    Else
      FYr = Convert.ToDateTime(oFYr.StartDate).Year
    End If
    Dim Fdt As DateTime = Convert.ToDateTime("01/" & FMon.PadLeft(2, "0") & "/" & FYr)

    Dim Tdt As DateTime = Now
    If FMon = "10" Then
      Tdt = Convert.ToDateTime("31/12" & "/" & FYr)
    Else
      Tdt = Convert.ToDateTime("01/" & (Convert.ToInt32(FMon) + 3).ToString.PadLeft(2, "0") & "/" & FYr).AddDays(-1)
    End If
    Dim F_Date As String = Fdt.ToString("dd/MM/yyyy")
    Dim T_Date As String = Tdt.ToString("dd/MM/yyyy")
    Dim PerkID As Integer = 0
    If LC_PerkID1.SelectedValue <> String.Empty Then
      PerkID = LC_PerkID1.SelectedValue
    End If
    Dim oGen As SIS.NPRK.Utilities.GenerateEntitlements = New SIS.NPRK.Utilities.GenerateEntitlements
    Try
      oGen.Generate("", "", F_Date, T_Date, PerkID)
    Catch ex As Exception
      Dim message As String = New JavaScriptSerializer().Serialize(ex.Message)
      Dim script As String = String.Format("alert({0});", message)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
    End Try
    HttpContext.Current.Session.Timeout = L_SessionTimeOut
  End Sub
  Protected Sub Cmd2Generate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd2Generate.Click
    Dim L_SessionTimeOut As Integer = HttpContext.Current.Session.Timeout
    HttpContext.Current.Session.Timeout = 60
    Dim oFYr As SIS.NPRK.nprkFinYears = SIS.NPRK.nprkFinYears.nprkFinYearsGetByID(HttpContext.Current.Session("FinYear"))
    Dim FMon As String = F_Qtr1.SelectedValue
    Dim FYr As String = ""
    If FMon = "1" Then
      FYr = Convert.ToDateTime(oFYr.EndDate).Year
    Else
      FYr = Convert.ToDateTime(oFYr.StartDate).Year
    End If
    Dim Fdt As DateTime = Convert.ToDateTime("01/" & FMon.PadLeft(2, "0") & "/" & FYr)
    Dim Tdt As DateTime = Now
    If FMon = "10" Then
      Tdt = Convert.ToDateTime("31/12" & "/" & FYr)
    Else
      Tdt = Convert.ToDateTime("01/" & (Convert.ToInt32(FMon) + 3).ToString.PadLeft(2, "0") & "/" & FYr).AddDays(-1)
    End If
    Dim F_Date As String = Fdt.ToString("dd/MM/yyyy")
    Dim T_Date As String = Tdt.ToString("dd/MM/yyyy")
    Dim PerkID As Integer = 0
    If LC_PerkID2.SelectedValue <> String.Empty Then
      PerkID = LC_PerkID2.SelectedValue
    End If
    Dim oGen As SIS.NPRK.Utilities.GenerateEntitlements = New SIS.NPRK.Utilities.GenerateEntitlements
    Try
      oGen.Generate(Me.T_CardNo2.Text, Me.T_CardNo2.Text, F_Date, T_Date, PerkID)
    Catch ex As Exception
      Dim message As String = New JavaScriptSerializer().Serialize(ex.Message)
      Dim script As String = String.Format("alert({0});", message)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
    End Try
    HttpContext.Current.Session.Timeout = L_SessionTimeOut
  End Sub
  Protected Sub Cmd3Generate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd3Generate.Click
    Dim L_SessionTimeOut As Integer = HttpContext.Current.Session.Timeout
    HttpContext.Current.Session.Timeout = 60
    Dim oFYr As SIS.NPRK.nprkFinYears = SIS.NPRK.nprkFinYears.nprkFinYearsGetByID(HttpContext.Current.Session("FinYear"))
    Dim FMon As String = F_Qtr2.SelectedValue
    Dim FYr As String = ""
    If FMon = "1" Then
      FYr = Convert.ToDateTime(oFYr.EndDate).Year
    Else
      FYr = Convert.ToDateTime(oFYr.StartDate).Year
    End If
    Dim Fdt As DateTime = Convert.ToDateTime("01/" & FMon.PadLeft(2, "0") & "/" & FYr)
    Dim Tdt As DateTime = Now
    If FMon = "10" Then
      Tdt = Convert.ToDateTime("31/12" & "/" & FYr)
    Else
      Tdt = Convert.ToDateTime("01/" & (Convert.ToInt32(FMon) + 3).ToString.PadLeft(2, "0") & "/" & FYr).AddDays(-1)
    End If
    Dim F_Date As String = Fdt.ToString("dd/MM/yyyy")
    Dim T_Date As String = Tdt.ToString("dd/MM/yyyy")
    Dim oGen As SIS.NPRK.Utilities.GenerateEntitlements = New SIS.NPRK.Utilities.GenerateEntitlements
    Try
      oGen.Generate(Me.F_CardNo3.Text, Me.T_CardNo3.Text, F_Date, T_Date, 0)
    Catch ex As Exception
      Dim message As String = New JavaScriptSerializer().Serialize(ex.Message)
      Dim script As String = String.Format("alert({0});", message)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
    End Try
    HttpContext.Current.Session.Timeout = L_SessionTimeOut
  End Sub
  Protected Sub CmdOPBTransfer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdOPBTransfer.Click
  End Sub
  Protected Sub TBLnprkStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkStatus.Init
    SetToolBar = TBLnprkStatus
  End Sub

  Private Sub GF_GenerateMonthlyEntitlements_Init(sender As Object, e As EventArgs) Handles Me.Init
    L_ScriptTimeOut = HttpContext.Current.Server.ScriptTimeout
    HttpContext.Current.Server.ScriptTimeout = 3600
  End Sub

  Private Sub GF_GenerateMonthlyEntitlements_Unload(sender As Object, e As EventArgs) Handles Me.Unload
    HttpContext.Current.Server.ScriptTimeout = L_ScriptTimeOut
  End Sub
  <System.Web.Services.WebMethod()>
  Public Shared Function generateEntitlement(ByVal value As String) As String
    Dim L_SessionTimeOut As Integer = HttpContext.Current.Session.Timeout
    HttpContext.Current.Session.Timeout = 60
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim CardNo As String = aVal(0)
    Dim Mon As String = aVal(1)
    Dim Prk As String = aVal(2)
    Dim mRet As String = "0|" & aVal(0)
    Dim FMon As String = Mon.Split("|".ToCharArray)(0)
    Dim FYr As String = Mon.Split("|".ToCharArray)(1)
    Dim Fdt As DateTime = Convert.ToDateTime("01/" & FMon & "/" & FYr)
    Dim Tdt As DateTime = Convert.ToDateTime(DateTime.DaysInMonth(Convert.ToInt32(FYr), FMon) & "/" & FMon & "/" & FYr)
    Dim F_Date As String = Fdt.ToString("dd/MM/yyyy")
    Dim T_Date As String = Tdt.ToString("dd/MM/yyyy")
    Dim PerkID As Integer = 0
    If Prk <> String.Empty Then
      PerkID = Prk
    End If
    Dim oFinYear As SIS.NPRK.nprkFinYears
    oFinYear = SIS.NPRK.nprkFinYears.nprkFinYearsGetByID(HttpContext.Current.Session("FinYear"))
    Dim oGen As SIS.NPRK.Utilities.GenerateEntitlements = New SIS.NPRK.Utilities.GenerateEntitlements
    Try
      oGen.DoGenerate(CardNo, F_Date, T_Date, PerkID, oFinYear)
      mRet = aVal(0) & "| Processed"
    Catch ex As Exception
      mRet = aVal(0) & "|" & ex.Message
    End Try
    HttpContext.Current.Session.Timeout = L_SessionTimeOut
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function getEmpList(ByVal value As String) As String
    Dim L_SessionTimeOut As Integer = HttpContext.Current.Session.Timeout
    HttpContext.Current.Session.Timeout = 60
    Dim mRet As String = ""
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
      Using Cmd As SqlCommand = Con.CreateCommand()
        Dim mSql As String = "SELECT CARDNO FROM HRM_Employees WHERE ActiveState=1 order by CardNo"
        Cmd.CommandType = System.Data.CommandType.Text
        Cmd.CommandText = mSql
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        While (Reader.Read())
          If mRet = String.Empty Then
            mRet = Reader("CardNo")
          Else
            mRet &= "|" & Reader("CardNo")
          End If
        End While
        Reader.Close()
      End Using
    End Using
    HttpContext.Current.Session.Timeout = L_SessionTimeOut
    Return mRet
  End Function

  Private Sub GF_GenerateMonthlyEntitlements_Load(sender As Object, e As EventArgs) Handles Me.Load
    If Request.QueryString("closefinyear") IsNot Nothing Then
      If Request.QueryString("closefinyear") = "zaq12wsxcde3" Then
        Dim emp As String = Request.QueryString("emp")
        SIS.NPRK.Utilities.ClosingBalance.UpdateClosingBalance(emp)
      Else
        Dim emp As String = Request.QueryString("emp")
        SIS.NPRK.Utilities.ClosingBalance.DeleteClosingRecord(emp)
      End If
    End If

    If Not Page.IsCallback And Not Page.IsPostBack Then
      Select Case Now.Month
        Case 4, 5, 6
          F_Qtr.SelectedValue = "4"
          F_Qtr1.SelectedValue = "4"
          F_Qtr2.SelectedValue = "4"
        Case 7, 8, 9
          F_Qtr.SelectedValue = "7"
          F_Qtr1.SelectedValue = "7"
          F_Qtr2.SelectedValue = "7"
        Case 10, 11, 12
          F_Qtr.SelectedValue = "10"
          F_Qtr1.SelectedValue = "10"
          F_Qtr2.SelectedValue = "10"
        Case 1, 2, 3
          F_Qtr.SelectedValue = "1"
          F_Qtr1.SelectedValue = "1"
          F_Qtr2.SelectedValue = "1"
      End Select
    End If
  End Sub
End Class
