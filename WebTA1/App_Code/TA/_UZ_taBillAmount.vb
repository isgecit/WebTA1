Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  Partial Public Class taBillAmount
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = False
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
    Public Shared Function UZ_taBillAmountSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taBillAmount)
      Dim Results As List(Of SIS.TA.taBillAmount) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sptaBillAmountSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sptaBillAmountSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo",SqlDbType.Int,10, IIf(TABillNo = Nothing, 0,TABillNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taBillAmount)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBillAmount(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_taBillAmountInsert(ByVal Record As SIS.TA.taBillAmount) As SIS.TA.taBillAmount
      Dim _Result As SIS.TA.taBillAmount = taBillAmountInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_taBillAmountUpdate(ByVal Record As SIS.TA.taBillAmount) As SIS.TA.taBillAmount
      Dim _Result As SIS.TA.taBillAmount = taBillAmountUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_taBillAmountDelete(ByVal Record As SIS.TA.taBillAmount) As Integer
      Dim _Result as Integer = taBillAmountDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        'CType(.FindControl("F_TABillNo"), TextBox).Text = ""
        'CType(.FindControl("F_TABillNo_Display"), Label).Text = ""
        'CType(.FindControl("F_ComponentID"), TextBox).Text = ""
        'CType(.FindControl("F_ComponentID_Display"), Label).Text = ""
        'CType(.FindControl("F_CurrencyID"), TextBox).Text = ""
        'CType(.FindControl("F_CurrencyID_Display"), Label).Text = ""
        'CType(.FindControl("F_CostCenterID"), TextBox).Text = ""
        'CType(.FindControl("F_CostCenterID_Display"), Label).Text = ""
        'CType(.FindControl("F_TotalInCurrency"), TextBox).Text = ""
        'CType(.FindControl("F_ConversionFactorINR"), TextBox).Text = ""
        'CType(.FindControl("F_CalculationTypeID"), TextBox).Text = ""
        'CType(.FindControl("F_CalculationTypeID_Display"), Label).Text = ""
        'CType(.FindControl("F_TotalInINR"), TextBox).Text = ""
      End With
      Return sender
    End Function
  End Class
End Namespace
