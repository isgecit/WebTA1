Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  Partial Public Class taBillGST
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
    Public Shared Function UZ_taBillGSTSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.TA.taBillGST)
      Dim Results As List(Of SIS.TA.taBillGST) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spta_LG_BillGSTSelectListSearch"
            Cmd.CommandText = "sptaBillGSTSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spta_LG_BillGSTSelectListFilteres"
            Cmd.CommandText = "sptaBillGSTSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.TA.taBillGST)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.TA.taBillGST(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_taBillGSTInsert(ByVal Record As SIS.TA.taBillGST) As SIS.TA.taBillGST
      Dim _Result As SIS.TA.taBillGST = taBillGSTInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_taBillGSTUpdate(ByVal Record As SIS.TA.taBillGST) As SIS.TA.taBillGST
      Dim _Result As SIS.TA.taBillGST = taBillGSTUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_taBillGSTDelete(ByVal Record As SIS.TA.taBillGST) As Integer
      Dim _Result as Integer = taBillGSTDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_TABillNo"), TextBox).Text = ""
        CType(.FindControl("F_TABillNo_Display"), Label).Text = ""
        CType(.FindControl("F_SerialNo"), TextBox).Text = ""
        CType(.FindControl("F_SerialNo_Display"), Label).Text = ""
        CType(.FindControl("F_IsgecGSTIN"),Object).SelectedValue = ""
        CType(.FindControl("F_BillNumber"), TextBox).Text = ""
        CType(.FindControl("F_BillDate"), TextBox).Text = ""
        CType(.FindControl("F_BPID"), TextBox).Text = ""
        CType(.FindControl("F_BPID_Display"), Label).Text = ""
        CType(.FindControl("F_SupplierGSTIN"), TextBox).Text = ""
        CType(.FindControl("F_SupplierGSTIN_Display"), Label).Text = ""
        CType(.FindControl("F_SupplierGSTINNo"), TextBox).Text = ""
        CType(.FindControl("F_StateID"),Object).SelectedValue = ""
        CType(.FindControl("F_BillType"),Object).SelectedValue = ""
        CType(.FindControl("F_HSNSACCode"), TextBox).Text = ""
        CType(.FindControl("F_HSNSACCode_Display"), Label).Text = ""
        CType(.FindControl("F_AssessableValue"), TextBox).Text = 0
        CType(.FindControl("F_IGSTRate"), TextBox).Text = 0
        CType(.FindControl("F_IGSTAmount"), TextBox).Text = 0
        CType(.FindControl("F_SGSTRate"), TextBox).Text = 0
        CType(.FindControl("F_SGSTAmount"), TextBox).Text = 0
        CType(.FindControl("F_CGSTRate"), TextBox).Text = 0
        CType(.FindControl("F_CGSTAmount"), TextBox).Text = 0
        CType(.FindControl("F_CessRate"), TextBox).Text = 0
        CType(.FindControl("F_CessAmount"), TextBox).Text = 0
        CType(.FindControl("F_TotalGST"), TextBox).Text = 0
        CType(.FindControl("F_TotalAmount"), TextBox).Text = 0
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
