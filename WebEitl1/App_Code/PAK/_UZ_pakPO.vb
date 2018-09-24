Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakPO
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
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      Select Case POStatusID
        Case pakPOStates.UnderSupplierVerification
          mRet = Drawing.Color.Green
        Case pakPOStates.UnderISGECApproval
          mRet = Drawing.Color.Crimson
        Case pakPOStates.IssuedtoSupplier
          mRet = Drawing.Color.LightSeaGreen
        Case pakPOStates.UnderDespatch
          mRet = Drawing.Color.MediumVioletRed
        Case pakPOStates.Closed
          mRet = Drawing.Color.Olive
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
      Select Case POStatusID
        Case pakPOStates.Free, pakPOStates.UnderISGECApproval
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
        Dim mRet As Boolean = False
        Try
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
            Case pakPOStates.Free, pakPOStates.UnderISGECApproval
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
            Case pakPOStates.UnderISGECApproval, pakPOStates.ImportedFromERP
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
    Public ReadOnly Property RejectWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property RejectWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property CompleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
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
    Public Shared Function InitiateWF(ByVal SerialNo As Int32) As SIS.PAK.pakPO
      Dim Results As SIS.PAK.pakPO = pakPOGetByID(SerialNo)
      Dim tmp As List(Of SIS.PAK.pakPOBOM) = SIS.PAK.pakPOBOM.UZ_pakPOBOMSelectList(0, 999, "", False, "", SerialNo)
      If tmp.Count <= 0 Then
        Throw New Exception("Package Item NOT Linked to this PO, can NOT send for verification.")
      End If
      If Results.POStatusID = pakPOStates.UnderISGECApproval Then
        For Each ttmp As SIS.PAK.pakPOBOM In tmp
          'All Items not checked 
          Dim tmpI As Integer = SIS.PAK.pakPOBItems.GetpakPOBItemsUnCheckedISGECCount(ttmp.SerialNo, ttmp.BOMNo)
          If tmpI > 0 Then
            Throw New Exception("All Items NOT checked/updated, can NOT send for Re-verification.")
          End If
        Next
      End If
      With Results
        .POStatusID = pakPOStates.UnderSupplierVerification
        .IssuedBy = HttpContext.Current.Session("LoginID")
        .IssuedOn = Now
      End With
      Results = SIS.PAK.pakPO.UpdateData(Results)
      'Create WebUser for supplier
      ''WebLoginID
      Dim LoginID As String = Results.SupplierID.Substring(1, 8).Trim
      Dim owUsr As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(LoginID)
      If owUsr Is Nothing Then
        owUsr = New SIS.QCM.qcmUsers
        With owUsr
          .UserName = LoginID
          .UserFullName = Results.FK_PAK_SupplierID.BPName
          .ActiveState = 1
          .EMailID = Results.FK_PAK_SupplierID.EMailID
        End With
        owUsr.PW = SIS.QCM.qcmUsers.CreateWebUser(owUsr)
        SIS.QCM.qcmUsers.UpdateData(owUsr)
      End If
      If owUsr IsNot Nothing Then
        owUsr = SIS.QCM.qcmUsers.ValidatePassword(owUsr)
        Dim oWS As New WebAuthorization.WebAuthorizationServiceSoapClient
        Dim Roles() As String = Web.Configuration.WebConfigurationManager.AppSettings("SupplierRoleID").ToString.Split(",".ToCharArray)
        Dim str As String = ""
        For Each role As String In Roles
          str = oWS.CreateWebAuthorization(23, owUsr.UserName, role)
          If str <> String.Empty Then
            Exit For
          End If
        Next
        If str <> String.Empty Then
          Roles = Web.Configuration.WebConfigurationManager.AppSettings("SupplierRoleID1").ToString.Split(",".ToCharArray)
          For Each role As String In Roles
            str = oWS.CreateWebAuthorization(23, owUsr.UserName, role)
          Next
        End If
      End If
      '===========================================
      'Send Verification E-Mail
      SIS.PAK.Alerts.Alert(SerialNo, pakAlertEvents.POVerification)
      '===========================================
      Return Results
    End Function
    Public Shared Function ApproveWF(ByVal SerialNo As Int32) As SIS.PAK.pakPO
      Dim tmp As List(Of SIS.PAK.pakPOBOM) = SIS.PAK.pakPOBOM.UZ_pakPOBOMSelectList(0, 999, "", False, "", SerialNo)
      If tmp.Count <= 0 Then
        Throw New Exception("Package Item NOT Linked to this PO, can NOT be Issued.")
      Else
        For Each tmpB As SIS.PAK.pakPOBOM In tmp
          Dim cnt As Integer = SIS.PAK.pakPOBItems.GetpakPOBItemsUnFreezedCount(tmpB.SerialNo, tmpB.BOMNo)
          If cnt > 0 Then
            Throw New Exception("All BOM Items are NOT Freezed, PO can NOT be Issued.")
          End If
        Next
      End If
      Dim Results As SIS.PAK.pakPO = pakPOGetByID(SerialNo)
      With Results
        .POStatusID = pakPOStates.UnderDespatch
        .IssuedBy = HttpContext.Current.Session("LoginID")
        .IssuedOn = Now
      End With
      Results = SIS.PAK.pakPO.UpdateData(Results)
      If Results.POTypeID = pakErpPOTypes.ISGECEngineered Then
        'Create WebUser for supplier
        ''WebLoginID
        Dim LoginID As String = Results.SupplierID.Substring(1, 8).Trim
        Dim owUsr As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(LoginID)
        If owUsr Is Nothing Then
          owUsr = New SIS.QCM.qcmUsers
          With owUsr
            .UserName = LoginID
            .UserFullName = Results.FK_PAK_SupplierID.BPName
            .ActiveState = 1
            .EMailID = Results.FK_PAK_SupplierID.EMailID
          End With
          owUsr.PW = SIS.QCM.qcmUsers.CreateWebUser(owUsr)
          SIS.QCM.qcmUsers.UpdateData(owUsr)
        End If
        If owUsr IsNot Nothing Then
          owUsr = SIS.QCM.qcmUsers.ValidatePassword(owUsr)
          Dim oWS As New WebAuthorization.WebAuthorizationServiceSoapClient
          Dim Roles() As String = Web.Configuration.WebConfigurationManager.AppSettings("SupplierRoleID").ToString.Split(",".ToCharArray)
          Dim str As String = ""
          For Each role As String In Roles
            Str = oWS.CreateWebAuthorization(23, owUsr.UserName, role)
            If str <> String.Empty Then
              Exit For
            End If
          Next
          If str <> String.Empty Then
            Roles = Web.Configuration.WebConfigurationManager.AppSettings("SupplierRoleID1").ToString.Split(",".ToCharArray)
            For Each role As String In Roles
              str = oWS.CreateWebAuthorization(23, owUsr.UserName, role)
            Next
          End If
        End If
      End If
      'Send Issue E-Mail
      SIS.PAK.Alerts.Alert(SerialNo, pakAlertEvents.POIssued)
      Return Results
    End Function
    Public Shared Function RejectWF(ByVal SerialNo As Int32) As SIS.PAK.pakPO
      Dim Results As SIS.PAK.pakPO = pakPOGetByID(SerialNo)
      Return Results
    End Function
    Public Shared Function CompleteWF(ByVal SerialNo As Int32) As SIS.PAK.pakPO
      Dim Results As SIS.PAK.pakPO = pakPOGetByID(SerialNo)
      Return Results
    End Function
    Public Shared Function UZ_pakPOSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal POTypeID As Int32, ByVal SupplierID As String, ByVal ProjectID As String, ByVal BuyerID As String, ByVal POStatusID As Int32, ByVal IssuedBy As String) As List(Of SIS.PAK.pakPO)
      Dim Results As List(Of SIS.PAK.pakPO) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_POSelectListSearch"
            'Cmd.CommandText = "sppakPOSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_POSelectListFilteres"
            'Cmd.CommandText = "sppakPOSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_POTypeID",SqlDbType.Int,10, IIf(POTypeID = Nothing, 0,POTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SupplierID",SqlDbType.NVarChar,9, IIf(SupplierID Is Nothing, String.Empty,SupplierID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BuyerID",SqlDbType.NVarChar,8, IIf(BuyerID Is Nothing, String.Empty,BuyerID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_POStatusID",SqlDbType.Int,10, IIf(POStatusID = Nothing, 0,POStatusID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_IssuedBy",SqlDbType.NVarChar,8, IIf(IssuedBy Is Nothing, String.Empty,IssuedBy))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.Int,10, Global.System.Web.HttpContext.Current.Session("DivisionID"))
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakPO)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakPO(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakPOInsert(ByVal Record As SIS.PAK.pakPO) As SIS.PAK.pakPO
      Dim _Result As SIS.PAK.pakPO = pakPOInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakPOUpdate(ByVal Record As SIS.PAK.pakPO) As SIS.PAK.pakPO
      Dim _Rec As SIS.PAK.pakPO = SIS.PAK.pakPO.pakPOGetByID(Record.SerialNo)
      With _Rec
        .IssueReasonID = Record.IssueReasonID
        .POTypeID = Record.POTypeID
        .ISGECRemarks = Record.ISGECRemarks
      End With
      Return SIS.PAK.pakPO.UpdateData(_Rec)
    End Function
    Public Shared Function UZ_pakPODelete(ByVal Record As SIS.PAK.pakPO) As Integer
      Dim _Result as Integer = pakPODelete(Record)
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
    Public Shared Function GetTotalWeight(ByVal Qty As String, ByVal UnitWt As String, ByVal UOMqty As String, ByVal UOMWt As String) As Decimal
      Dim mRet As Decimal = 0
      Dim mc As SIS.PAK.UnitMultiplicationFactor = Nothing
      Try
        Dim tmpUnit As SIS.PAK.pakUnits = SIS.PAK.pakUnits.pakUnitsGetByID(UOMqty)
        If tmpUnit.UnitSetID = 3 Then '3=>Weight Unit Set
          Try
            mc = New SIS.PAK.UnitMultiplicationFactor
            mc.Unit = tmpUnit
            mc = SIS.PAK.UnitMultiplicationFactor.GetMultiplicationFactorToBaseUnit(mc)
            mRet = Qty * mc.MF
          Catch ex As Exception
          End Try
        Else
          Try
            mc = New SIS.PAK.UnitMultiplicationFactor
            mc.Unit = SIS.PAK.pakUnits.pakUnitsGetByID(UOMWt)
            mc = SIS.PAK.UnitMultiplicationFactor.GetMultiplicationFactorToBaseUnit(mc)
            mRet = Qty * UnitWt * mc.MF
          Catch ex As Exception
          End Try
        End If
      Catch ex As Exception
        Try
          mc = New SIS.PAK.UnitMultiplicationFactor
          mc.Unit = SIS.PAK.pakUnits.pakUnitsGetByID(UOMWt)
          mc = SIS.PAK.UnitMultiplicationFactor.GetMultiplicationFactorToBaseUnit(mc)
          mRet = Qty * UnitWt * mc.MF
        Catch ex1 As Exception
        End Try
      End Try
      Return mRet
    End Function
    Public Shared Function pakPOGetByPONo(ByVal PONo As String) As SIS.PAK.pakPO
      Dim Results As SIS.PAK.pakPO = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppak_LG_POSelectByPONo"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PONo", SqlDbType.NVarChar, PONo.Length, PONo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakPO(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
  End Class
End Namespace
