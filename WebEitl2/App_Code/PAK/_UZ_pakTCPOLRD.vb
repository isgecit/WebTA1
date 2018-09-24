Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakTCPOLRD
    Public ReadOnly Property GetDownloadLink() As String
      Get
        Return "javascript:window.open('" & HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath & "/PAK_Main/App_Downloads/filedownload.aspx?stcpolrd=" & PrimaryKey & "', 'win" & DocSerialNo & "', 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1'); return false;"
      End Get
    End Property
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
      If DiskFileName = "" Then
        mRet = Drawing.Color.Red
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
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_SerialNo"), TextBox).Text = ""
        CType(.FindControl("F_SerialNo_Display"), Label).Text = ""
        CType(.FindControl("F_ItemNo"), TextBox).Text = ""
        CType(.FindControl("F_ItemNo_Display"), Label).Text = ""
        CType(.FindControl("F_UploadNo"), TextBox).Text = ""
        CType(.FindControl("F_UploadNo_Display"), Label).Text = ""
        CType(.FindControl("F_DocSerialNo"), TextBox).Text = ""
        CType(.FindControl("F_DocumentID"), TextBox).Text = ""
        CType(.FindControl("F_DocumentRev"), TextBox).Text = ""
        CType(.FindControl("F_DocumentDescription"), TextBox).Text = ""
        CType(.FindControl("F_ReceiptNo"), TextBox).Text = ""
        CType(.FindControl("F_RevisionNo"), TextBox).Text = ""
        CType(.FindControl("F_FileName"), TextBox).Text = ""
        CType(.FindControl("F_DiskFileName"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
