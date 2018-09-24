Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  Partial Public Class nprkPerks
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
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function nprkPerksSelectListClaimable(ByVal OrderBy As String) As List(Of SIS.NPRK.nprkPerks)
      Dim Results As List(Of SIS.NPRK.nprkPerks) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprk_LG_PerksSelectListClaimable"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkPerks)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkPerks(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_PerkID"), TextBox).Text = ""
          CType(.FindControl("F_PerkCode"), TextBox).Text = ""
          CType(.FindControl("F_Description"), TextBox).Text = ""
          CType(.FindControl("F_AdvanceApplicable"), CheckBox).Checked = False
          CType(.FindControl("F_AdvanceMonths"), TextBox).Text = 0
          CType(.FindControl("F_LockedMonths"), TextBox).Text = 0
          CType(.FindControl("F_NoOfPayments"), TextBox).Text = 0
          CType(.FindControl("F_CarryForward"), CheckBox).Checked = False
          CType(.FindControl("F_UOM"), DropDownList).SelectedValue = ""
          CType(.FindControl("F_Active"), CheckBox).Checked = False
          CType(.FindControl("F_BaaNGL"), TextBox).Text = ""
          CType(.FindControl("F_BaaNReference"), TextBox).Text = ""
          CType(.FindControl("F_CreditGLForCheque"), TextBox).Text = ""
          CType(.FindControl("F_CreditGLForCash24"), TextBox).Text = ""
          CType(.FindControl("F_CreditGLForImprest"), TextBox).Text = ""
          CType(.FindControl("F_CreditGLForCash63"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function GetNetPayable(ByVal EmployeeID As Integer, ByVal PerkID As Integer, ByVal FinYear As Integer) As Decimal
      Dim Results As Decimal = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnPrk_LG_NetPayable"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.Int, 11, EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PerkID", SqlDbType.Int, 11, PerkID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.Int, 11, FinYear)
          Cmd.Parameters.Add("@NetValue", SqlDbType.Decimal)
          Cmd.Parameters("@NetValue").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Results = Cmd.Parameters("@NetValue").Value
        End Using
      End Using
      Return Results
    End Function
  End Class
End Namespace
