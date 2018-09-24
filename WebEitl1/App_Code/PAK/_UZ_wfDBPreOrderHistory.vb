Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.WFDB
  Partial Public Class wfDBPreOrderHistory
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
    Public Shared Function UZ_wfDBPreOrderHistorySelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.WFDB.wfDBPreOrderHistory)
      Dim Results As List(Of SIS.WFDB.wfDBPreOrderHistory) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spwfdb_LG_wfDBPreOrderHistorySelectListSearch"
            Cmd.CommandText = "spwfDBPreOrderHistorySelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spwfdb_LG_wfDBPreOrderHistorySelectListFilteres"
            Cmd.CommandText = "spwfDBPreOrderHistorySelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.WFDB.wfDBPreOrderHistory)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.WFDB.wfDBPreOrderHistory(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_wfDBPreOrderHistoryInsert(ByVal Record As SIS.WFDB.wfDBPreOrderHistory) As SIS.WFDB.wfDBPreOrderHistory
      Dim _Result As SIS.WFDB.wfDBPreOrderHistory = wfDBPreOrderHistoryInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_wfDBPreOrderHistoryUpdate(ByVal Record As SIS.WFDB.wfDBPreOrderHistory) As SIS.WFDB.wfDBPreOrderHistory
      Dim _Result As SIS.WFDB.wfDBPreOrderHistory = wfDBPreOrderHistoryUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_wfDBPreOrderHistoryDelete(ByVal Record As SIS.WFDB.wfDBPreOrderHistory) As Integer
      Dim _Result as Integer = wfDBPreOrderHistoryDelete(Record)
      Return _Result
    End Function
    Public Shared Function UZ_wfDBPreOrderHistoryGetByID(ByVal WFID As Int32) As SIS.WFDB.wfDBPreOrderHistory
      Dim Results As SIS.WFDB.wfDBPreOrderHistory = wfDBPreOrderHistoryGetByID(WFID)
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_WFID"), TextBox).Text = 0
        CType(.FindControl("F_Project"), TextBox).Text = ""
        CType(.FindControl("F_Element"), TextBox).Text = ""
        CType(.FindControl("F_SpecificationNo"), TextBox).Text = ""
        CType(.FindControl("F_Buyer"), TextBox).Text = ""
        CType(.FindControl("F_SupplierName"), TextBox).Text = ""
        CType(.FindControl("F_Supplier"), TextBox).Text = ""
        CType(.FindControl("F_Notes"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
