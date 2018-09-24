Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ELOG
  Partial Public Class elogChargeCategories
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
    Public Shared Function LG_elogChargeCategoriesSelectList(ByVal OrderBy As String) As List(Of SIS.ELOG.elogChargeCategories)
      Dim Results As List(Of SIS.ELOG.elogChargeCategories) = Nothing
      Dim aVal() As String = OrderBy.Split("|".ToCharArray)
      Dim ShipmentModeID As String = aVal(0)
      Dim LocationCountryID As String = aVal(1)
      Dim CargoTypeID As String = aVal(2)
      Dim StuffingTypeID As String = aVal(3)
      Dim StuffingPointID As String = aVal(4)
      Dim BreakBulkTypeID As String = aVal(5)
      Dim ChargeTypeID As String = aVal(6)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelog_LG_ChargeCategoriesSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ShipmentModeID", SqlDbType.Int, 11, IIf(ShipmentModeID = "", Convert.DBNull, ShipmentModeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LocationCountryID", SqlDbType.Int, 11, IIf(LocationCountryID = "", Convert.DBNull, LocationCountryID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CargoTypeID", SqlDbType.Int, 11, IIf(CargoTypeID = "", Convert.DBNull, CargoTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StuffingTypeID", SqlDbType.Int, 11, IIf(StuffingTypeID = "", Convert.DBNull, StuffingTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StuffingPointID", SqlDbType.Int, 11, IIf(StuffingPointID = "", Convert.DBNull, StuffingPointID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BreakbulkTypeID", SqlDbType.Int, 11, IIf(BreakBulkTypeID = "", Convert.DBNull, BreakBulkTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ChargeTypeID", SqlDbType.Int, 11, IIf(ChargeTypeID = "", Convert.DBNull, ChargeTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ELOG.elogChargeCategories)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ELOG.elogChargeCategories(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_elogChargeCategoriesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ShipmentModeID As Int32, ByVal LocationCountryID As Int32, ByVal CargoTypeID As Int32, ByVal StuffingTypeID As Int32, ByVal StuffingPointID As Int32, ByVal BreakbulkTypeID As Int32, ByVal ChargeTypeID As Int32) As List(Of SIS.ELOG.elogChargeCategories)
      Dim Results As List(Of SIS.ELOG.elogChargeCategories) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spelog_LG_ChargeCategoriesSelectListSearch"
            Cmd.CommandText = "spelogChargeCategoriesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spelog_LG_ChargeCategoriesSelectListFilteres"
            Cmd.CommandText = "spelogChargeCategoriesSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ShipmentModeID", SqlDbType.Int, 10, IIf(ShipmentModeID = Nothing, 0, ShipmentModeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_LocationCountryID", SqlDbType.Int, 10, IIf(LocationCountryID = Nothing, 0, LocationCountryID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CargoTypeID", SqlDbType.Int, 10, IIf(CargoTypeID = Nothing, 0, CargoTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StuffingTypeID", SqlDbType.Int, 10, IIf(StuffingTypeID = Nothing, 0, StuffingTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StuffingPointID", SqlDbType.Int, 10, IIf(StuffingPointID = Nothing, 0, StuffingPointID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BreakbulkTypeID", SqlDbType.Int, 10, IIf(BreakbulkTypeID = Nothing, 0, BreakbulkTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ChargeTypeID", SqlDbType.Int, 10, IIf(ChargeTypeID = Nothing, 0, ChargeTypeID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ELOG.elogChargeCategories)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ELOG.elogChargeCategories(Reader))
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
        CType(.FindControl("F_ChargeCategoryID"), TextBox).Text = ""
        CType(.FindControl("F_ShipmentModeID"),Object).SelectedValue = ""
        CType(.FindControl("F_LocationCountryID"),Object).SelectedValue = ""
        CType(.FindControl("F_CargoTypeID"),Object).SelectedValue = ""
        CType(.FindControl("F_StuffingTypeID"),Object).SelectedValue = ""
        CType(.FindControl("F_StuffingPointID"),Object).SelectedValue = ""
        CType(.FindControl("F_BreakbulkTypeID"),Object).SelectedValue = ""
        CType(.FindControl("F_ChargeTypeID"),Object).SelectedValue = ""
        CType(.FindControl("F_Description"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
