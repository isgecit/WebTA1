Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  Partial Public Class taBillPrjAmounts
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
          mRet = FK_TA_BillPrjAmounts_TABillNo.GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = FK_TA_BillPrjAmounts_TABillNo.GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property CompleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = FK_TA_BillPrjAmounts_TABillNo.GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property CompleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function CompleteWF(ByVal ProjectID As String, ByVal TABillNo As Int32, ByVal Percentage As String) As SIS.TA.taBillPrjAmounts
      Dim Results As SIS.TA.taBillPrjAmounts = taBillPrjAmountsGetByID(TABillNo, ProjectID)
      With Results
        .Percentage = Percentage
      End With
      SIS.TA.taBillPrjAmounts.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function UZ_taBillPrjAmountsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TABillNo As Int32) As List(Of SIS.TA.taBillPrjAmounts)
      Dim Results As List(Of SIS.TA.taBillPrjAmounts) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spta_LG_BillPrjAmountsSelectListSearch"
            Cmd.CommandText = "sptaBillPrjAmountsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spta_LG_BillPrjAmountsSelectListFilteres"
            Cmd.CommandText = "sptaBillPrjAmountsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TABillNo", SqlDbType.Int, 10, IIf(TABillNo = Nothing, 0, TABillNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taBillPrjAmounts)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBillPrjAmounts(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_taBillPrjAmountsInsert(ByVal Record As SIS.TA.taBillPrjAmounts) As SIS.TA.taBillPrjAmounts
      Dim _Result As SIS.TA.taBillPrjAmounts = taBillPrjAmountsInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_taBillPrjAmountsUpdate(ByVal Record As SIS.TA.taBillPrjAmounts) As SIS.TA.taBillPrjAmounts
      Dim _Result As SIS.TA.taBillPrjAmounts = taBillPrjAmountsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_taBillPrjAmountsDelete(ByVal Record As SIS.TA.taBillPrjAmounts) As Integer
      Dim _Result as Integer = taBillPrjAmountsDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        'CType(.FindControl("F_TABillNo"), TextBox).Text = ""
        'CType(.FindControl("F_TABillNo_Display"), Label).Text = ""
        'CType(.FindControl("F_ProjectID"), TextBox).Text = ""
        'CType(.FindControl("F_ProjectID_Display"), Label).Text = ""
        'CType(.FindControl("F_Percentage"), TextBox).Text = 0
      End With
      Return sender
    End Function
  End Class
End Namespace
