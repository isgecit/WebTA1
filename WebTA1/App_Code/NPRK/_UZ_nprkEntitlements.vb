Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  Partial Public Class nprkEntitlements
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
    Public Shared Function UZ_nprkEntitlementsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.NPRK.nprkEntitlements)
      Dim Results As List(Of SIS.NPRK.nprkEntitlements) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spnprk_LG_EntitlementsSelectListSearch"
            Cmd.CommandText = "spnprkEntitlementsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spnprk_LG_EntitlementsSelectListFilteres"
            Cmd.CommandText = "spnprkEntitlementsSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkEntitlements)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkEntitlements(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_nprkEntitlementsInsert(ByVal Record As SIS.NPRK.nprkEntitlements) As SIS.NPRK.nprkEntitlements
      Dim _Result As SIS.NPRK.nprkEntitlements = nprkEntitlementsInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_nprkEntitlementsUpdate(ByVal Record As SIS.NPRK.nprkEntitlements) As SIS.NPRK.nprkEntitlements
      Dim _Result As SIS.NPRK.nprkEntitlements = nprkEntitlementsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_nprkEntitlementsDelete(ByVal Record As SIS.NPRK.nprkEntitlements) As Integer
      Dim _Result as Integer = nprkEntitlementsDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_EntitlementID"), TextBox).Text = ""
        CType(.FindControl("F_EmployeeID"), TextBox).Text = ""
        CType(.FindControl("F_EmployeeID_Display"), Label).Text = ""
        CType(.FindControl("F_PerkID"), TextBox).Text = ""
        CType(.FindControl("F_PerkID_Display"), Label).Text = ""
        CType(.FindControl("F_EffectiveDate"), TextBox).Text = ""
        CType(.FindControl("F_FinYear"), TextBox).Text = ""
        CType(.FindControl("F_FinYear_Display"), Label).Text = ""
        CType(.FindControl("F_Value"), TextBox).Text = 0
        CType(.FindControl("F_UOM"), DropDownList).SelectedValue = ""
        CType(.FindControl("F_CategoryID"), TextBox).Text = ""
        CType(.FindControl("F_CategoryID_Display"), Label).Text = ""
        CType(.FindControl("F_PostedAt"), TextBox).Text = ""
        CType(.FindControl("F_VehicleType"), TextBox).Text = ""
        CType(.FindControl("F_Basic"), TextBox).Text = 0
        CType(.FindControl("F_ESI"), CheckBox).Checked = False
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function GetByEmployeeIDPerkID(ByVal EmployeeID As Int32, ByVal PerkID As Int32) As List(Of SIS.NPRK.nprkEntitlements)
      Dim Results As List(Of SIS.NPRK.nprkEntitlements) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnPrk_LG_EntitlementsSelectByEmployeeIDPerkID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.Int, EmployeeID.ToString.Length, EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PerkID", SqlDbType.Int, PerkID.ToString.Length, PerkID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.Int, 10, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkEntitlements)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkEntitlements(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function SelectListSep(ByVal EmployeeID As Int32, ByVal PerkID As Int32, ByVal EffectiveDate As DateTime) As List(Of SIS.NPRK.nprkEntitlements)
      Dim Results As List(Of SIS.NPRK.nprkEntitlements) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnPrk_LG_EntitlementsSelectSep"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.Int, EmployeeID.ToString.Length, EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PerkID", SqlDbType.Int, PerkID.ToString.Length, PerkID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EffectiveDate", SqlDbType.DateTime, EffectiveDate.ToString.Length, EffectiveDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.Int, 10, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkEntitlements)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkEntitlements(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function SelectListAsOn(ByVal EmployeeID As Int32, ByVal PerkID As Int32, ByVal EffectiveDate As DateTime) As List(Of SIS.NPRK.nprkEntitlements)
      Dim Results As List(Of SIS.NPRK.nprkEntitlements) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnPrk_LG_EntitlementsSelectAsOn"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.Int, EmployeeID.ToString.Length, EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PerkID", SqlDbType.Int, PerkID.ToString.Length, PerkID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EffectiveDate", SqlDbType.DateTime, EffectiveDate.ToString.Length, EffectiveDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.Int, 10, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkEntitlements)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkEntitlements(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function GetNetValue(ByVal EmployeeID As Integer, ByVal PerkID As Integer, ByVal FinYear As Integer) As Decimal
      Dim Results As Decimal = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnPrk_LG_NetEntitlementValue"
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
    Public Shared Function GetNetValueMigratedClubedOPB(ByVal EmployeeID As Integer, ByVal PerkID As Integer, ByVal FinYear As Integer) As Decimal
      Dim Results As Decimal = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprk_LG_NetLedgerValue_MigratedClubOPB"
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
    Public Shared Function GetBalanceMedicalForYear(ByVal EmployeeID As Integer, ByVal FinYear As Integer) As SIS.NPRK.nprkEntitlements
      Dim Results As SIS.NPRK.nprkEntitlements = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnprk_LG_GetBalanceMedicalForYear"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.Int, EmployeeID.ToString.Length, EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.Int, FinYear.ToString.Length, FinYear)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.NPRK.nprkEntitlements(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function GetEntitlementsByEmployeeID(ByVal EmployeeID As Int32) As List(Of SIS.NPRK.nprkEntitlements)
      Dim Results As List(Of SIS.NPRK.nprkEntitlements) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spnPrk_LG_EntitlementsSelectByEmployeeID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmployeeID", SqlDbType.Int, EmployeeID.ToString.Length, EmployeeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinYear", SqlDbType.Int, 10, Global.System.Web.HttpContext.Current.Session("FinYear"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.NPRK.nprkEntitlements)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.NPRK.nprkEntitlements(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function

  End Class
End Namespace
