Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakSiteMtlIssDL
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      If FK_PAK_SiteIssueDLocation_IssueNo.IssueStatusID = siteIssueStates.Issued Then
        mRet = Drawing.Color.Green
      ElseIf QuantityIssued > 0 Then
        mRet = Drawing.Color.DarkViolet
      End If
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
      Dim mRet As Boolean = False
      If FK_PAK_SiteIssueDLocation_IssueNo.IssueStatusID = siteIssueStates.UnderIssue Then
        mRet = True
      End If
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
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
    Public Shared Function UZ_pakSiteMtlIssDLSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String, ByVal IssueSrNo As Int32, ByVal IssueNo As Int32) As List(Of SIS.PAK.pakSiteMtlIssDL)
      Dim Results As List(Of SIS.PAK.pakSiteMtlIssDL) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_SiteMtlIssDLSelectListSearch"
            Cmd.CommandText = "sppakSiteMtlIssDLSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_SiteMtlIssDLSelectListFilteres"
            Cmd.CommandText = "sppakSiteMtlIssDLSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_IssueSrNo",SqlDbType.Int,10, IIf(IssueSrNo = Nothing, 0,IssueSrNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_IssueNo",SqlDbType.Int,10, IIf(IssueNo = Nothing, 0,IssueNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakSiteMtlIssDL)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSiteMtlIssDL(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakSiteMtlIssDLInsert(ByVal Record As SIS.PAK.pakSiteMtlIssDL) As SIS.PAK.pakSiteMtlIssDL
      Dim _Result As SIS.PAK.pakSiteMtlIssDL = pakSiteMtlIssDLInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakSiteMtlIssDLUpdate(ByVal Record As SIS.PAK.pakSiteMtlIssDL) As SIS.PAK.pakSiteMtlIssDL
      Dim _Result As SIS.PAK.pakSiteMtlIssDL = pakSiteMtlIssDLUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakSiteMtlIssDLDelete(ByVal Record As SIS.PAK.pakSiteMtlIssDL) As Integer
      Dim _Result as Integer = pakSiteMtlIssDLDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_IssueSrLNo"), TextBox).Text = ""
        CType(.FindControl("F_SiteMarkNo"), TextBox).Text = ""
        CType(.FindControl("F_SiteMarkNo_Display"), Label).Text = ""
        CType(.FindControl("F_LocationID"),Object).SelectedValue = ""
        CType(.FindControl("F_QuantityIssued"), TextBox).Text = 0
        CType(.FindControl("F_ProjectID"), TextBox).Text = ""
        CType(.FindControl("F_ProjectID_Display"), Label).Text = ""
        CType(.FindControl("F_Remarks"), TextBox).Text = ""
        CType(.FindControl("F_IssueSrNo"), TextBox).Text = ""
        CType(.FindControl("F_IssueSrNo_Display"), Label).Text = ""
        CType(.FindControl("F_IssueNo"), TextBox).Text = ""
        CType(.FindControl("F_IssueNo_Display"), Label).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
