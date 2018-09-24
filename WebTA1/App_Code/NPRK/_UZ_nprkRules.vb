Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  Partial Public Class nprkRules
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
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_RuleID"), TextBox).Text = ""
        CType(.FindControl("F_PerkID"),Object).SelectedValue = ""
        CType(.FindControl("F_CategoryID"),Object).SelectedValue = ""
        CType(.FindControl("F_EffectiveDate"), TextBox).Text = ""
        CType(.FindControl("F_PercentageOfBasic"), CheckBox).Checked = False
        CType(.FindControl("F_Percentage"), TextBox).Text = 0
        CType(.FindControl("F_FixedValue"), TextBox).Text = 0
        CType(.FindControl("F_PostedAt"), DropDownList).SelectedValue = ""
        CType(.FindControl("F_VehicleType"), DropDownList).SelectedValue = ""
        CType(.FindControl("F_InSalary"), CheckBox).Checked = False
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function GetLatestRulesByCategoryID(ByVal CategoryID As Int32) As List(Of SIS.NPRK.nprkRules)
      Dim Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
      Dim Cmd As SqlCommand = Con.CreateCommand()
      Cmd.CommandType = CommandType.StoredProcedure
      Cmd.CommandText = "spPrk_LG_RulesSelectByCategoryID"
      SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryID", SqlDbType.Int, CategoryID.ToString.Length, CategoryID)
      Dim Results As List(Of SIS.NPRK.nprkRules) = New List(Of SIS.NPRK.nprkRules)()
      Using Con
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        While (Reader.Read())
          Results.Add(New SIS.NPRK.nprkRules(Reader))
        End While
        Reader.Close()
      End Using
      Return Results
    End Function
    Public Shared Function GetLatestRulesByCategoryIDPerkID(ByVal CategoryID As Int32, ByVal PerkID As Integer, ByVal StartDate As DateTime) As List(Of SIS.NPRK.nprkRules)
      Dim Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
      Dim Cmd As SqlCommand = Con.CreateCommand()
      Cmd.CommandType = CommandType.StoredProcedure
      Cmd.CommandText = "spPrk_LG_RulesSelectByCategoryIDPerkID"
      SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CategoryID", SqlDbType.Int, CategoryID.ToString.Length, CategoryID)
      SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PerkID", SqlDbType.Int, PerkID, PerkID)
      SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartDate", SqlDbType.DateTime, 20, StartDate)
      Dim Results As List(Of SIS.NPRK.nprkRules) = New List(Of SIS.NPRK.nprkRules)()
      Using Con
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        While (Reader.Read())
          Results.Add(New SIS.NPRK.nprkRules(Reader))
        End While
        Reader.Close()
      End Using
      Return Results
    End Function
  End Class
End Namespace
