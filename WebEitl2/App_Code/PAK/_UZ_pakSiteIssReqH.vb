Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakSiteIssReqH
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      Select Case IssueStatusID
        Case siteIssueStates.UnderIssue
          mRet = Drawing.Color.DarkViolet
        Case siteIssueStates.Issued
          mRet = Drawing.Color.Green
        Case siteIssueStates.Returned
          mRet = Drawing.Color.Red
      End Select
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
      Select Case IssueStatusID
        Case siteIssueStates.Free, siteIssueStates.Returned
          mRet = True
      End Select
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      Select Case IssueStatusID
        Case siteIssueStates.Free, siteIssueStates.Returned
          mRet = True
      End Select
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
        Dim mRet As Boolean = False
        Try
          Select Case IssueStatusID
            Case siteIssueStates.Free, siteIssueStates.Returned
              mRet = True
          End Select
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
    Public Shared Sub InsertIssueLocation(ByVal Results As SIS.PAK.pakSiteIssReqH, Optional ByVal IssueSrNo As Integer = 0)
      'Find Available Locations For ProjectID & SiteMarkNo
      Dim tmpIs As List(Of SIS.PAK.pakSiteIssRecD) = SIS.PAK.pakSiteIssRecD.pakSiteIssRecDSelectList(0, 99999, "", False, "", Results.IssueNo, Results.ProjectID)
      For Each tmpI As SIS.PAK.pakSiteIssRecD In tmpIs
        If IssueSrNo > 0 Then
          If tmpI.IssueSrNo <> IssueSrNo Then
            Continue For
          End If
        End If
        'Delete Last data
        Dim delILs As List(Of SIS.PAK.pakSiteMtlIssDL) = SIS.PAK.pakSiteMtlIssDL.pakSiteMtlIssDLSelectList(0, 99999, "", False, "", tmpI.IssueNo, tmpI.ProjectID, tmpI.IssueSrNo)
        For Each delIL As SIS.PAK.pakSiteMtlIssDL In delILs
          SIS.PAK.pakSiteMtlIssDL.pakSiteMtlIssDLDelete(delIL)
        Next
        'Insert New Data
        Dim tmpLs As List(Of SIS.PAK.pakSiteItemMasterLocation) = SIS.PAK.pakSiteItemMasterLocation.pakSiteItemMasterLocationSelectList(0, 99999, "", False, "", tmpI.ProjectID, tmpI.SiteMarkNo)
        If tmpLs.Count > 0 Then
          Dim balQty As Decimal = tmpI.QuantityRequired
          For Each tmpL As SIS.PAK.pakSiteItemMasterLocation In tmpLs
            If tmpL.Quantity > 0 Then
              Dim tmpIL As New SIS.PAK.pakSiteMtlIssDL
              tmpIL.ProjectID = tmpI.ProjectID
              tmpIL.IssueNo = tmpI.IssueNo
              tmpIL.IssueSrNo = tmpI.IssueSrNo
              tmpIL.IssueSrLNo = 0
              tmpIL.SiteMarkNo = tmpI.SiteMarkNo
              tmpIL.UOMQuantity = tmpI.UOMQuantity
              tmpIL.QuantityAvailable = tmpL.Quantity
              If balQty > 0 Then
                If tmpL.Quantity <= balQty Then
                  tmpIL.QuantityIssued = tmpL.Quantity
                  balQty -= tmpL.Quantity
                Else
                  tmpIL.QuantityIssued = balQty
                  balQty = 0
                End If
              End If
              tmpIL.LocationID = tmpL.LocationID
              tmpIL = SIS.PAK.pakSiteMtlIssDL.InsertData(tmpIL)
            End If
          Next
        End If
      Next
    End Sub
    Public Shared Function InitiateWF(ByVal ProjectID As String, ByVal IssueNo As Int32) As SIS.PAK.pakSiteIssReqH
      Dim Results As SIS.PAK.pakSiteIssReqH = pakSiteIssReqHGetByID(ProjectID, IssueNo)
      Results.RequestedBy = HttpContext.Current.Session("LoginID")
      Results.RequestedOn = Now
      Results.IssueStatusID = siteIssueStates.UnderIssue
      InsertIssueLocation(Results)
      Results = SIS.PAK.pakSiteIssReqH.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function UZ_pakSiteIssReqHSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String) As List(Of SIS.PAK.pakSiteIssReqH)
      Dim Results As List(Of SIS.PAK.pakSiteIssReqH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_SiteIssReqHSelectListSearch"
            Cmd.CommandText = "sppakSiteIssReqHSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_SiteIssReqHSelectListFilteres"
            Cmd.CommandText = "sppakSiteIssReqHSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakSiteIssReqH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSiteIssReqH(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakSiteIssReqHInsert(ByVal Record As SIS.PAK.pakSiteIssReqH) As SIS.PAK.pakSiteIssReqH
      Dim _Result As SIS.PAK.pakSiteIssReqH = pakSiteIssReqHInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakSiteIssReqHUpdate(ByVal Record As SIS.PAK.pakSiteIssReqH) As SIS.PAK.pakSiteIssReqH
      Dim _Result As SIS.PAK.pakSiteIssReqH = pakSiteIssReqHUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakSiteIssReqHDelete(ByVal Record As SIS.PAK.pakSiteIssReqH) As Integer
      Dim _Result as Integer = pakSiteIssReqHDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_ProjectID"), TextBox).Text = ""
        CType(.FindControl("F_ProjectID_Display"), Label).Text = ""
        CType(.FindControl("F_IssueNo"), TextBox).Text = ""
        CType(.FindControl("F_IssueToName"), TextBox).Text = ""
        CType(.FindControl("F_RequesterRemarks"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
