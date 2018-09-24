Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  Partial Public Class taEmployees
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
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = True
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
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
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
    Public Shared Function InitiateWF(ByVal CardNo As String) As SIS.TA.taEmployees
      Dim Results As SIS.TA.taEmployees = taEmployeesGetByID(CardNo)
      Return Results
    End Function
    Public Shared Function ApproveWF(ByVal CardNo As String) As SIS.TA.taEmployees
      Dim Results As SIS.TA.taEmployees = taEmployeesGetByID(CardNo)
      Return Results
    End Function
    Public Shared Sub CreateWebUserAndAuthorization(ByVal Record As SIS.TA.taEmployees)
      Dim oUsr As MembershipUser = Membership.GetUser(Record.CardNo)
      If oUsr Is Nothing Then
        Try
          oUsr = Membership.CreateUser(Record.CardNo, Record.CardNo)
          If Not oUsr Is Nothing Then
            Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
              Using Cmd As SqlCommand = Con.CreateCommand()
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.CommandText = "sptaUsersUpdate"
                SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_UserName", SqlDbType.NVarChar, 21, Record.CardNo)
                SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserFullName", SqlDbType.NVarChar, 51, Record.EmployeeName)
                SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_CompanyID", SqlDbType.NVarChar, 7, IIf(Record.C_CompanyID = "", Convert.DBNull, Record.C_CompanyID))
                SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DivisionID", SqlDbType.NVarChar, 7, IIf(Record.C_DivisionID = "", Convert.DBNull, Record.C_DivisionID))
                SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_OfficeID", SqlDbType.Int, 11, IIf(Record.C_OfficeID = "", Convert.DBNull, Record.C_OfficeID))
                SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DepartmentID", SqlDbType.NVarChar, 7, IIf(Record.C_DepartmentID = "", Convert.DBNull, Record.C_DepartmentID))
                SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EMailID", SqlDbType.NVarChar, 50, IIf(Record.EMailID = "", Convert.DBNull, Record.EMailID))
                SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@C_DesignationID", SqlDbType.Int, 11, IIf(Record.C_DesignationID = "", Convert.DBNull, Record.C_DesignationID))
                SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActiveState", SqlDbType.Bit, 3, Record.ActiveState)
                Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
                Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
                Con.Open()
                Cmd.ExecuteNonQuery()
              End Using
            End Using
          End If
        Catch ex As Exception
        End Try
      End If
      'Create User Authorization
      Dim oWS As New YnrWebAuth.WebAuthorizationService
      Dim UseLive As Boolean = Convert.ToBoolean(Web.Configuration.WebConfigurationManager.AppSettings("UseLive").ToString)
      Dim aAuth() As String = {""}
      If UseLive Then
        aAuth = Web.Configuration.WebConfigurationManager.AppSettings("LiveAuth").ToString.Split(",".ToCharArray)
      Else
        aAuth = Web.Configuration.WebConfigurationManager.AppSettings("TestAuth").ToString.Split(",".ToCharArray)
      End If
      Dim str As String = ""
      For Each auth As String In aAuth
        Dim appl As String = ""
        Dim role As String = ""
        Dim tmp() As String = auth.Split(":".ToCharArray)
        appl = tmp(0)
        role = tmp(1)
        str = oWS.CreateWebAuthorization(appl, oUsr.UserName, role)
      Next
    End Sub
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_CardNo"), TextBox).Text = ""
        CType(.FindControl("F_EmployeeName"), TextBox).Text = ""
        CType(.FindControl("F_C_CompanyID"),Object).SelectedValue = ""
        CType(.FindControl("F_C_DivisionID"),Object).SelectedValue = ""
        CType(.FindControl("F_C_DepartmentID"),Object).SelectedValue = ""
        CType(.FindControl("F_C_DesignationID"),Object).SelectedValue = ""
        CType(.FindControl("F_C_OfficeID"),Object).SelectedValue = ""
        CType(.FindControl("F_ActiveState"), CheckBox).Checked = False
        CType(.FindControl("F_TASelfApproval"), CheckBox).Checked = False
        CType(.FindControl("F_TAVerifier"), TextBox).Text = ""
        CType(.FindControl("F_TAVerifier_Display"), Label).Text = ""
        CType(.FindControl("F_TAApprover"), TextBox).Text = ""
        CType(.FindControl("F_TAApprover_Display"), Label).Text = ""
        CType(.FindControl("F_TASanctioningAuthority"), TextBox).Text = ""
        CType(.FindControl("F_TASanctioningAuthority_Display"), Label).Text = ""
        CType(.FindControl("F_CategoryID"),Object).SelectedValue = ""
        CType(.FindControl("F_EMailID"), TextBox).Text = ""
        CType(.FindControl("F_Contractual"), CheckBox).Checked = False
        CType(.FindControl("F_NonTechnical"), CheckBox).Checked = False
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
