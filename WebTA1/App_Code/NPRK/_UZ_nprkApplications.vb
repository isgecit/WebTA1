Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  Partial Public Class nprkApplications
    Public Property ClaimRefNo As String
      Get
        Return FK_PRK_Applications_ClaimID.ClaimRefNo
      End Get
      Set(value As String)

      End Set
    End Property
    Public ReadOnly Property ChildAddable() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          mRet = FK_PRK_Applications_ClaimID.Editable
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Notification() As String
      Get
        Dim mRet As String = ""
        If ExcessClaimed Then
          mRet = "<img alt='warning' src='../../images/Error.gif' title='Excess Claimed' style='height:14px; width:14px' />"
        End If
        Return mRet
      End Get
    End Property

    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
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
      Dim mRet As Boolean = True
      If Value > 0 Then
        mRet = False
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
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function UZ_nprkApplicationsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ClaimID As Int32) As List(Of SIS.NPRK.nprkApplications)
      Dim Results As List(Of SIS.NPRK.nprkApplications) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "ApplicationID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprk_LG_ApplicationsSelectListSearch"
            'Cmd.CommandText = "spnprkApplicationsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprk_LG_ApplicationsSelectListFilteres"
            'Cmd.CommandText = "spnprkApplicationsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ClaimID", SqlDbType.Int, 10, IIf(ClaimID = Nothing, 0, ClaimID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          'SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.Int, 10, Global.System.Web.HttpContext.Current.Session("LoginID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkApplications)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkApplications(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_nprkApplicationsInsert(ByVal Record As SIS.NPRK.nprkApplications) As SIS.NPRK.nprkApplications
      Dim ci As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("en-GB", True)
      Record = nprkApplicationsInsert(Record)
      Dim RequireClaimUpdate As Boolean = False
      Select Case Record.PerkID
        Case prkPerk.DriverCharges
          Dim CanPay As Decimal = SIS.NPRK.nprkPerks.GetNetPayable(Record.EmployeeID, Record.PerkID, Record.FinYear)
          Dim inPay As Decimal = 0
          Dim oEnts As List(Of SIS.NPRK.nprkEntitlements) = SIS.NPRK.nprkEntitlements.GetByEmployeeIDPerkID(Record.EmployeeID, Record.PerkID)
          oEnts.Sort(Function(x, y) Convert.ToDateTime(x.EffectiveDate, ci).CompareTo(Convert.ToDateTime(y.EffectiveDate, ci)))
          For I As Integer = oEnts.Count - 1 To 0 Step -1
            Dim tmp As SIS.NPRK.nprkEntitlements = oEnts(I)
            If Not tmp.Selected Then
              If inPay + tmp.Value <= CanPay Then
                Dim tmpBill As New SIS.NPRK.nprkBillDetails
                With tmpBill
                  .ClaimID = Record.ClaimID
                  .ApplicationID = Record.ApplicationID
                  .AttachmentID = 0
                  .SerialNo = 0
                  .ClaimRefNo = Record.ClaimRefNo
                  .FromDate = Convert.ToDateTime("01/" & Convert.ToDateTime(tmp.EffectiveDate, ci).Month.ToString.PadLeft(2, "0") & "/" & Convert.ToDateTime(tmp.EffectiveDate, ci).Year)
                  .ToDate = tmp.EffectiveDate
                  .Quantity = tmp.Value
                  .Amount = tmp.Value
                  .VerifiedByAdmin = False
                  .EntitlementID = tmp.EntitlementID
                  .PerkID = tmp.PerkID
                  .WithDriver = tmp.WithDriver
                End With
                tmpBill = SIS.NPRK.nprkBillDetails.UZ_nprkBillDetailsInsert(tmpBill)
                tmp.Selected = True
                SIS.NPRK.nprkEntitlements.UpdateData(tmp)
                RequireClaimUpdate = True
                inPay += tmp.Value
              End If
            End If
          Next
      End Select
      If RequireClaimUpdate Then
        SIS.NPRK.nprkUserClaims.ValidateClaim(Record.ClaimID)
      End If
      Return Record
    End Function
    Public Shared Function UZ_nprkApplicationsUpdate(ByVal Record As SIS.NPRK.nprkApplications) As SIS.NPRK.nprkApplications
      Dim _Result As SIS.NPRK.nprkApplications = nprkApplicationsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_nprkApplicationsDelete(ByVal Record As SIS.NPRK.nprkApplications) As Integer
      Dim _Result As Integer = nprkApplicationsDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_PerkID"), Object).SelectedValue = ""
          CType(.FindControl("F_ApplicationID"), TextBox).Text = ""
          CType(.FindControl("F_UserRemark"), TextBox).Text = ""
          CType(.FindControl("F_ClaimID"), TextBox).Text = ""
          CType(.FindControl("F_ClaimID_Display"), Label).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function UZ_nprkApplicationsGetByID(ByVal ApplicationID As Int32) As SIS.NPRK.nprkApplications
      Dim Results As SIS.NPRK.nprkApplications = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprk_LG_ApplicationsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID", SqlDbType.Int, ApplicationID.ToString.Length, ApplicationID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.NPRK.nprkApplications(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function CanApply(ByVal EmployeeID As Int32, ByVal PerkID As Int32, ByVal AplID As Integer) As Integer
      Dim _Result As Integer = 0
      Dim mRet As Boolean = True
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "SELECT ISNULL([PRK_Applications].[ApplicationID],0) FROM [PRK_Applications] WHERE [PRK_Applications].[EmployeeID] = " & EmployeeID & " AND [PRK_Applications].[PerkID] = " & PerkID & " AND [PRK_Applications].[ApplicationID] <> " & AplID & " AND [PRK_Applications].[FinYear] = " & Global.System.Web.HttpContext.Current.Session("FinYear") & " AND [PRK_Applications].[StatusID] IN (1,2,3,7)"
          Con.Open()
          _Result = Cmd.ExecuteScalar
        End Using
      End Using
      If _Result > 0 Then
        mRet = False
      End If
      Return _Result
    End Function
  End Class
End Namespace
