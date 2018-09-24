Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakSiteIssRecD
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      Select Case FK_PAK_SiteIssueD_IssueNo.IssueStatusID
        Case siteIssueStates.UnderIssue
          mRet = Drawing.Color.Green
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
      Select Case FK_PAK_SiteIssueD_IssueNo.IssueStatusID
        Case siteIssueStates.Free, siteIssueStates.Returned
          mRet = True
      End Select
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      Select Case FK_PAK_SiteIssueD_IssueNo.IssueStatusID
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
    Public Shared Function UZ_pakSiteIssRecDInsert(ByVal Record As SIS.PAK.pakSiteIssRecD) As SIS.PAK.pakSiteIssRecD
      Record.UOMQuantity = Record.FK_PAK_SiteIssueD_SiteMarkNo.UOMQuantity
      Record.QuantityIssued = Record.QuantityRequired
      Dim _Result As SIS.PAK.pakSiteIssRecD = pakSiteIssRecDInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakSiteIssRecDUpdate(ByVal Record As SIS.PAK.pakSiteIssRecD) As SIS.PAK.pakSiteIssRecD
      Record.UOMQuantity = Record.FK_PAK_SiteIssueD_SiteMarkNo.UOMQuantity
      Record.QuantityIssued = Record.QuantityRequired
      Dim _Result As SIS.PAK.pakSiteIssRecD = pakSiteIssRecDUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakSiteIssRecDDelete(ByVal Record As SIS.PAK.pakSiteIssRecD) As Integer
      Dim _Result as Integer = pakSiteIssRecDDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_IssueSrNo"), TextBox).Text = ""
        CType(.FindControl("F_SiteMarkNo"), TextBox).Text = ""
        CType(.FindControl("F_SiteMarkNo_Display"), Label).Text = ""
        CType(.FindControl("F_QuantityRequired"), TextBox).Text = 0
        CType(.FindControl("F_IssueNo"), TextBox).Text = ""
        CType(.FindControl("F_IssueNo_Display"), Label).Text = ""
        CType(.FindControl("F_Remarks"), TextBox).Text = ""
        CType(.FindControl("F_ProjectID"), TextBox).Text = ""
        CType(.FindControl("F_ProjectID_Display"), Label).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
