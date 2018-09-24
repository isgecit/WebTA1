Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakTCPO
    Public ReadOnly Property GetNotesLink() As String
      Get
        Dim mRet As String = HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority
        If HttpContext.Current.Request.Url.Authority.ToLower = "localhost" Then
          mRet = "http://192.9.200.146"
        End If
        mRet &= "/Attachment/Notes.aspx?handle=J_POISSUE"
        Dim Index As String = SerialNo
        Dim User As String = HttpContext.Current.Session("LoginID")
        Dim canEdit As String = "y"
        mRet &= "&Index=" & Index & "&user=" & User & "&ed=" & canEdit
        mRet = "javascript:window.open('" & mRet & "', 'win" & SerialNo & "', 'left=20,top=20,width=1000,height=700,toolbar=1,resizable=1,scrollbars=1'); return false;"
        Return mRet
      End Get
    End Property
    Public ReadOnly Property UpdateUploadStatusFromERP As String
      Get
        Dim mRet As String = ""
        Dim uploads As List(Of SIS.PAK.pakSTCPOLR) = SIS.PAK.pakSTCPOLR.pakSTCPOLRSelectList(0, 9999, "", False, "", SerialNo, 0)
        For Each upl As SIS.PAK.pakSTCPOLR In uploads
          If upl.UploadStatusID = "2" Then
            Dim NewStatus As pakTCUploadStates = upl.UploadStatusID
            Dim erpStatus As String = "3"
            If upl.FK_PAK_POLineRec_pakERPRecH IsNot Nothing Then
              If upl.FK_PAK_POLineRec_pakERPRecH.t_stat = "0" Then
                erpStatus = "3"
              Else
                erpStatus = upl.FK_PAK_POLineRec_pakERPRecH.t_stat
              End If
            End If
            Select Case erpStatus
              Case "4"
                NewStatus = pakTCUploadStates.CommentSubmitted
              Case "5"
                NewStatus = pakTCUploadStates.TechnicallyCleared
              Case "8"
                NewStatus = pakTCUploadStates.Closed
            End Select
            If NewStatus <> upl.UploadStatusID Then
              Dim tmp As SIS.PAK.pakTCPOLR = SIS.PAK.pakTCPOLR.pakTCPOLRGetByID(upl.SerialNo, upl.ItemNo, upl.UploadNo)
              tmp.UploadStatusID = NewStatus
              SIS.PAK.pakTCPOLR.UpdateData(tmp)
              tmp = SIS.PAK.pakTCPOLR.pakTCPOLRGetByID(upl.SerialNo, upl.ItemNo, upl.UploadNo)
            End If
          End If
        Next
        Return mRet
      End Get
    End Property

    Public ReadOnly Property CountUploadedBySupplier As Integer
      Get
        Dim mRet As Integer = 0
        Dim x As String = UpdateUploadStatusFromERP
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "SELECT ISNULL(COUNT(UploadNo), 0) AS Cnt FROM PAK_POLineRec WHERE (UploadStatusID > 1) AND SerialNo =" & SerialNo
            Con.Open()
            mRet = Cmd.ExecuteScalar
          End Using
        End Using
        Return mRet
      End Get
    End Property
    Public ReadOnly Property CountRespondedByIsgec As Integer
      Get
        Dim mRet As Integer = 0
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "SELECT ISNULL(COUNT(UploadNo), 0) AS Cnt FROM PAK_POLineRec WHERE (UploadStatusID > 2) AND SerialNo =" & SerialNo
            Con.Open()
            mRet = Cmd.ExecuteScalar
          End Using
        End Using
        Return mRet
      End Get
    End Property
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      Select Case POStatusID
        Case pakTCPOStates.IssuedToSupplier
          mRet = Drawing.Color.Green
        Case pakTCPOStates.Closed
          mRet = Drawing.Color.DarkGoldenrod
        Case pakTCPOStates.ReopenRequested
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
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case POStatusID
            Case pakTCPOStates.Free, pakTCPOStates.IssuedToSupplier
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
    Public ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case POStatusID
            Case pakTCPOStates.ReopenRequested
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ApproveWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function InitiateWF(ByVal SerialNo As Int32) As SIS.PAK.pakTCPO
      Dim tmpPO As SIS.PAK.pakTCPO = pakTCPOGetByID(SerialNo)
      Dim tmpItems As List(Of SIS.PAK.pakTCPOL) = SIS.PAK.pakTCPOL.pakTCPOLSelectList(0, 9999, "", False, "", tmpPO.SerialNo)
      If tmpItems.Count <= 0 Then
        Throw New Exception("Item NOT Found in this PO, can not be issued to Supplier.")
      End If
      With tmpPO
        .POStatusID = pakTCPOStates.IssuedToSupplier
        .IssuedBy = HttpContext.Current.Session("LoginID")
        .IssuedOn = Now
      End With
      tmpPO = SIS.PAK.pakTCPO.UpdateData(tmpPO)
      'Create WebUser for supplier
      ''WebLoginID
      Dim LoginID As String = tmpPO.SupplierID.Substring(1, 8).Trim
      Dim owUsr As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(LoginID)
      If owUsr Is Nothing Then
        owUsr = New SIS.QCM.qcmUsers
        With owUsr
          .UserName = LoginID
          .UserFullName = tmpPO.FK_PAK_SupplierID.BPName
          .ActiveState = 1
          .EMailID = tmpPO.FK_PAK_SupplierID.EMailID
        End With
        owUsr.PW = SIS.QCM.qcmUsers.CreateWebUser(owUsr)
        SIS.QCM.qcmUsers.UpdateData(owUsr)
      End If
      If owUsr IsNot Nothing Then
        owUsr = SIS.QCM.qcmUsers.ValidatePassword(owUsr)
        Dim oWS As New WebAuthorization.WebAuthorizationServiceSoapClient
        Dim errFound As Boolean = False
        Dim aRoles() As String = Web.Configuration.WebConfigurationManager.AppSettings("SupplierRoleID").ToString.Split(",".ToCharArray)
        For Each tmp As String In aRoles
          Dim str As String = oWS.CreateWebAuthorization(23, owUsr.UserName, tmp)
          If str <> "" Then
            errFound = True
            Exit For
          End If
        Next
        If errFound Then
          aRoles = Web.Configuration.WebConfigurationManager.AppSettings("SupplierRoleID1").ToString.Split(",".ToCharArray)
          For Each tmp As String In aRoles
            Dim str As String = oWS.CreateWebAuthorization(23, owUsr.UserName, tmp)
          Next
        End If
      End If
      '===========================================
      'Send TC
      SIS.PAK.Alerts.TCAlert(SerialNo, pakAlertEvents.TCPOIssued)
      '===========================================

      Return tmpPO
    End Function
    Public Shared Function ApproveWF(ByVal SerialNo As Int32) As SIS.PAK.pakTCPO
      Dim Results As SIS.PAK.pakTCPO = pakTCPOGetByID(SerialNo)
      Return Results
    End Function
    Public Shared Function UZ_pakTCPOSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal POTypeID As Int32, ByVal SupplierID As String, ByVal ProjectID As String, ByVal BuyerID As String, ByVal POStatusID As Int32, ByVal IssuedBy As String) As List(Of SIS.PAK.pakTCPO)
      Dim Results As List(Of SIS.PAK.pakTCPO) = Nothing
      If OrderBy = "" Then OrderBy = "SerialNo DESC"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_TCPOSelectListSearch"
            'Cmd.CommandText = "sppakTCPOSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_TCPOSelectListFilteres"
            'Cmd.CommandText = "sppakTCPOSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_POTypeID", SqlDbType.Int, 10, IIf(POTypeID = Nothing, 0, POTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SupplierID", SqlDbType.NVarChar, 9, IIf(SupplierID Is Nothing, String.Empty, SupplierID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID", SqlDbType.NVarChar, 6, IIf(ProjectID Is Nothing, String.Empty, ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BuyerID", SqlDbType.NVarChar, 8, IIf(BuyerID Is Nothing, String.Empty, BuyerID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_POStatusID", SqlDbType.Int, 10, IIf(POStatusID = Nothing, 0, POStatusID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_IssuedBy", SqlDbType.NVarChar, 8, IIf(IssuedBy Is Nothing, String.Empty, IssuedBy))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID", SqlDbType.Int, 10, Global.System.Web.HttpContext.Current.Session("DivisionID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakTCPO)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakTCPO(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakTCPOInsert(ByVal Record As SIS.PAK.pakTCPO) As SIS.PAK.pakTCPO
      Dim _Result As SIS.PAK.pakTCPO = pakTCPOInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakTCPOUpdate(ByVal Record As SIS.PAK.pakTCPO) As SIS.PAK.pakTCPO
      Dim _Result As SIS.PAK.pakTCPO = pakTCPOUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakTCPODelete(ByVal Record As SIS.PAK.pakTCPO) As Integer
      Dim _Result As Integer = pakTCPODelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_SerialNo"), TextBox).Text = ""
          CType(.FindControl("F_POConsignee"), TextBox).Text = ""
          CType(.FindControl("F_POOtherDetails"), TextBox).Text = ""
          CType(.FindControl("F_IssueReasonID"), Object).SelectedValue = ""
          CType(.FindControl("F_PONumber"), TextBox).Text = ""
          CType(.FindControl("F_PORevision"), TextBox).Text = ""
          CType(.FindControl("F_PODate"), TextBox).Text = ""
          CType(.FindControl("F_PODescription"), TextBox).Text = ""
          CType(.FindControl("F_POTypeID"), Object).SelectedValue = ""
          CType(.FindControl("F_SupplierID"), TextBox).Text = ""
          CType(.FindControl("F_SupplierID_Display"), Label).Text = ""
          CType(.FindControl("F_ProjectID"), TextBox).Text = ""
          CType(.FindControl("F_ProjectID_Display"), Label).Text = ""
          CType(.FindControl("F_BuyerID"), TextBox).Text = ""
          CType(.FindControl("F_BuyerID_Display"), Label).Text = ""
          CType(.FindControl("F_POStatusID"), Object).SelectedValue = ""
          CType(.FindControl("F_ISGECRemarks"), TextBox).Text = ""
          CType(.FindControl("F_SupplierRemarks"), TextBox).Text = ""
          CType(.FindControl("F_IssuedBy"), TextBox).Text = ""
          CType(.FindControl("F_IssuedBy_Display"), Label).Text = ""
          CType(.FindControl("F_IssuedOn"), TextBox).Text = ""
          CType(.FindControl("F_ClosedBy"), TextBox).Text = ""
          CType(.FindControl("F_ClosedBy_Display"), Label).Text = ""
          CType(.FindControl("F_ClosedOn"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
