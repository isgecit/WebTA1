Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakTCPOLR
    'Public Shared Function GetCopyLink(ByVal SerialNo As Int32, ByVal ItemNo As Int32, ByVal UploadNo As Int32) As String
    '  Dim xUpd As SIS.PAK.pakSTCPOLR = SIS.PAK.pakSTCPOLR.pakSTCPOLRGetByID(SerialNo, ItemNo, UploadNo)
    '  Dim mRet As String = HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & "/ProjectApi/AttachmentApi.svc/Attachments"
    '  Dim AthHandleS As String = "J_IDMSPOSTORDERREC"
    '  Dim AthHandleT As String = "IDMS_POSTORDER"
    '  Dim IndexS As String = SerialNo & "_" & ItemNo & "_" & UploadNo
    '  Dim IndexT As String = xUpd.ReceiptNo & "_" & xUpd.RevisionNo
    '  Return mRet & "/" & AthHandleS & "/" & AthHandleT & "/" & IndexS & "/" & IndexT
    'End Function
    Public Shared Function GetCopyLink() As String
      Dim UrlAuthority As String = HttpContext.Current.Request.Url.Authority
      If UrlAuthority.ToLower <> "cloud.isgec.co.in" Then
        UrlAuthority = "192.9.200.146"
      End If
      Dim mRet As String = HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & UrlAuthority & "/ProjectApi/AttachmentApi.svc/Attachments"
      Dim AthHandleS As String = "J_IDMSPOSTORDERREC"
      Dim AthHandleT As String = "IDMSRECEIPTS_200"
      Return mRet & "/" & AthHandleS & "/" & AthHandleT
    End Function
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      Select Case UploadStatusID
        Case pakTCUploadStates.UnderEvaluation
          mRet = Drawing.Color.Blue
        Case pakTCUploadStates.TechnicallyCleared
          mRet = Drawing.Color.Green
        Case pakTCUploadStates.CommentSubmitted
          mRet = Drawing.Color.Red
        Case pakTCUploadStates.Closed, pakTCUploadStates.Superseded
          mRet = Drawing.Color.Olive
        Case pakTCUploadStates.Free
          If ReceiptNo <> "" Then
            mRet = Drawing.Color.DeepPink
          End If
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
          CType(.FindControl("F_UploadNo"), TextBox).Text = ""
          CType(.FindControl("F_DocumentCategoryID"), Object).SelectedValue = ""
          CType(.FindControl("F_CreatedOn"), TextBox).Text = ""
          CType(.FindControl("F_ReceiptNo"), TextBox).Text = ""
          CType(.FindControl("F_RevisionNo"), TextBox).Text = ""
          CType(.FindControl("F_UploadStatusID"), TextBox).Text = ""
          CType(.FindControl("F_UploadStatusID_Display"), Label).Text = ""
          CType(.FindControl("F_SerialNo"), TextBox).Text = ""
          CType(.FindControl("F_SerialNo_Display"), Label).Text = ""
          CType(.FindControl("F_ItemNo"), TextBox).Text = ""
          CType(.FindControl("F_ItemNo_Display"), Label).Text = ""
          CType(.FindControl("F_UploadRemarks"), TextBox).Text = ""
          CType(.FindControl("F_CreatedBy"), TextBox).Text = ""
          CType(.FindControl("F_CreatedBy_Display"), Label).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
