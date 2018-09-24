Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakSiteMtlIssH
    Public Shadows Function GetEditable() As Boolean
      Dim mRet As Boolean = False
      If IssueStatusID = siteIssueStates.UnderIssue Then
        mRet = True
      End If
      Return mRet
    End Function
    Public Shadows Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      Return mRet
    End Function
    Public Shadows ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          If IssueStatusID = siteIssueStates.UnderIssue Then
            mRet = True
          End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Shadows Function InitiateWF(ByVal ProjectID As String, ByVal IssueNo As Int32) As SIS.PAK.pakSiteMtlIssH
      Dim issH As SIS.PAK.pakSiteMtlIssH = pakSiteMtlIssHGetByID(ProjectID, IssueNo)
      Dim issDs As List(Of SIS.PAK.pakSiteMtlIssD) = SIS.PAK.pakSiteMtlIssD.UZ_pakSiteMtlIssDSelectList(0, 99999, "", False, "", issH.IssueNo, issH.ProjectID)
      'Check for Error
      For Each issD As SIS.PAK.pakSiteMtlIssD In issDs
        Dim issDLs As List(Of SIS.PAK.pakSiteMtlIssDL) = SIS.PAK.pakSiteMtlIssDL.UZ_pakSiteMtlIssDLSelectList(0, 99999, "", False, "", issD.ProjectID, issD.IssueSrNo, issD.IssueNo)
        For Each issDL As SIS.PAK.pakSiteMtlIssDL In issDLs
          If issDL.QuantityIssued > 0 Then
            Dim itmL As SIS.PAK.pakSiteItemMasterLocation = SIS.PAK.pakSiteItemMasterLocation.pakSiteItemMasterLocationGetByID(issDL.ProjectID, issDL.SiteMarkNo, issDL.LocationID)
            If itmL.Quantity < issDL.QuantityIssued Then
              Throw New Exception("Issued quantity is more than Item available. Line No: " & issDL.IssueSrNo & " Issue Location: " & issDL.IssueSrLNo)
            End If
          End If
        Next
      Next
      'End Checking
      For Each issD As SIS.PAK.pakSiteMtlIssD In issDs
        Dim issQty As Decimal = 0
        Dim issDLs As List(Of SIS.PAK.pakSiteMtlIssDL) = SIS.PAK.pakSiteMtlIssDL.UZ_pakSiteMtlIssDLSelectList(0, 99999, "", False, "", issD.ProjectID, issD.IssueSrNo, issD.IssueNo)
        For Each issDL As SIS.PAK.pakSiteMtlIssDL In issDLs
          If issDL.QuantityIssued <= 0 Then
            SIS.PAK.pakSiteMtlIssDL.pakSiteMtlIssDLDelete(issDL)
          Else
            issQty += issDL.QuantityIssued
            Dim itmL As SIS.PAK.pakSiteItemMasterLocation = SIS.PAK.pakSiteItemMasterLocation.pakSiteItemMasterLocationGetByID(issDL.ProjectID, issDL.SiteMarkNo, issDL.LocationID)
            itmL.Quantity -= issDL.QuantityIssued
            itmL = SIS.PAK.pakSiteItemMasterLocation.UpdateData(itmL)
          End If
        Next
        Dim itm As SIS.PAK.pakSiteItemMaster = SIS.PAK.pakSiteItemMaster.pakSiteItemMasterGetByID(issD.ProjectID, issD.SiteMarkNo)
        itm.Quantity -= issQty
        itm = SIS.PAK.pakSiteItemMaster.UpdateData(itm)
        issD.QuantityIssued = issQty
        issD = SIS.PAK.pakSiteMtlIssD.UpdateData(issD)
      Next
      issH.IssuedBy = HttpContext.Current.Session("LoginID")
      issH.IssuedOn = Now
      issH.IssueStatusID = siteIssueStates.Issued
      issH = SIS.PAK.pakSiteMtlIssH.UpdateData(issH)
      Return issH
    End Function
    Public Shared Function UZ_pakSiteMtlIssHSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String) As List(Of SIS.PAK.pakSiteMtlIssH)
      Dim Results As List(Of SIS.PAK.pakSiteMtlIssH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_SiteMtlIssHSelectListSearch"
            Cmd.CommandText = "sppakSiteMtlIssHSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_SiteMtlIssHSelectListFilteres"
            Cmd.CommandText = "sppakSiteMtlIssHSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PAK.pakSiteMtlIssH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSiteMtlIssH(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakSiteMtlIssHUpdate(ByVal Record As SIS.PAK.pakSiteMtlIssH) As SIS.PAK.pakSiteMtlIssH
      Dim _Result As SIS.PAK.pakSiteMtlIssH = pakSiteMtlIssHUpdate(Record)
      Return _Result
    End Function
  End Class
End Namespace
