Imports System.Xml
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Net.Mail
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Text
Namespace SIS.PAK
  Partial Public Class pakPkgListH
    Public ReadOnly Property IsAdmin As Boolean
      Get
        Dim mRet As Boolean = False
        If HttpContext.Current.Session("LoginID") = "0340" Then
          mRet = True
        End If
        Return mRet
      End Get
    End Property
    Public ReadOnly Property GetDownloadLink() As String
      Get
        Return "javascript:window.open('" & HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath & "/PAK_Main/App_Downloads/pkgdownload.aspx?pkg=" & PrimaryKey & "', 'win" & PkgNo & "', 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1'); return false;"
      End Get
    End Property
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      If StatusID = pakPkgStates.Despatched Then
        mRet = Drawing.Color.Green
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
      If Me.FK_PAK_PkgListH_SerialNo.POStatusID = pakPOStates.UnderDespatch Then
        If StatusID = pakPkgStates.Free Then
          mRet = True
        End If
      End If
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      If Me.FK_PAK_PkgListH_SerialNo.POStatusID = pakPOStates.UnderDespatch Then
        If StatusID = pakPkgStates.Free Then
          mRet = True
        End If
      End If
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
          If StatusID = pakPkgStates.Free Then
            mRet = True
          End If
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
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
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
        Dim mRet As Boolean = False
        Try
          If StatusID = pakPkgStates.Despatched Then
            mRet = IsAdmin
          End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function RejectWF(ByVal SerialNo As Int32, ByVal PkgNo As Int32, ByVal UnProtected As Boolean) As SIS.PAK.pakPkgListH
      Dim Results As SIS.PAK.pakPkgListH = pakPkgListHGetByID(SerialNo, PkgNo)
      If Results.StatusID <> pakPkgStates.Despatched Then Return Results
      'Delete Packing List From ERP Detail & Header
      Dim ReceiptCreated As Boolean = False
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        If UnProtected Then
          Using Cmd2 As SqlCommand = Con.CreateCommand()
            Cmd2.CommandType = CommandType.Text
            Cmd2.CommandText = "select t_rcno from ttdisg018200 where t_srno = " & SerialNo & " and t_pkgn = " & PkgNo
            Con.Open()
            Dim Reader As SqlDataReader = Cmd2.ExecuteReader()
            Dim t_rcno As String = ""
            If Reader.Read() Then
              If Not Convert.IsDBNull(Reader("t_rcno")) Then
                t_rcno = Reader("t_rcno")
              End If
            End If
            Reader.Close()
            If t_rcno <> "" Then
              ReceiptCreated = True
            End If
          End Using
          If ReceiptCreated Then
            Throw New Exception("Payment Receipt created in ERP, can not return. ")
          End If
        Else
          Con.Open()
        End If

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          If UnProtected Then
            Cmd.CommandText = "Delete ttdisg018200 where t_srno = " & SerialNo & " and t_pkgn = " & PkgNo
          Else
            Cmd.CommandText = "Delete ttdisg018200 where t_rcno='' and t_srno = " & SerialNo & " and t_pkgn = " & PkgNo
          End If
          Cmd.ExecuteNonQuery()
        End Using
        Using Cmd1 As SqlCommand = Con.CreateCommand()
          Cmd1.CommandType = CommandType.Text
          If UnProtected Then
            Cmd1.CommandText = "Delete ttdisg017200 where t_srno = " & SerialNo & " and t_pkgn = " & PkgNo
          Else
            Cmd1.CommandText = "Delete ttdisg017200 where t_rcno='' and t_srno = " & SerialNo & " and t_pkgn = " & PkgNo
          End If
          Cmd1.ExecuteNonQuery()
        End Using
      End Using
      'Revert Allready Despatched Quantity
      Dim PkgItems As List(Of SIS.PAK.pakPkgListD) = SIS.PAK.pakPkgListD.pakPkgListDSelectList(0, 99999, "", False, "", PkgNo, SerialNo)
      For Each pkgItm As SIS.PAK.pakPkgListD In PkgItems
        Dim bomItm As SIS.PAK.pakPOBItems = SIS.PAK.pakPOBItems.pakPOBItemsGetByID(pkgItm.SerialNo, pkgItm.BOMNo, pkgItm.ItemNo)
        bomItm.QuantityDespatched -= pkgItm.Quantity
        bomItm.TotalWeightDespatched -= pkgItm.TotalWeight
        bomItm = SIS.PAK.pakPOBItems.UpdateData(bomItm)
      Next
      'Update Paking List as Free
      Results.StatusID = pakPkgStates.Free
      Results = SIS.PAK.pakPkgListH.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function InitiateWF(ByVal SerialNo As Int32, ByVal PkgNo As Int32) As SIS.PAK.pakPkgListH
      Dim Results As SIS.PAK.pakPkgListH = pakPkgListHGetByID(SerialNo, PkgNo)
      If Results.GRNo = "" Or Results.GRDate = "" Then
        Throw New Exception("GR No / GR Date is blank Cannot despatch.")
      End If
      Dim pkgDs As List(Of SIS.PAK.pakPkgListD) = SIS.PAK.pakPkgListD.pakPkgListDSelectList(0, 99999, "", False, "", PkgNo, SerialNo)
      If pkgDs.Count <= 0 Then
        Throw New Exception("No Item entered in packing list. Cannot despatch.")
      End If
      'Update POBItems From Packing List Items
      Dim tmpTotalWt As Decimal = 0
      Results.StatusID = pakPkgStates.Despatched
      Results.CreatedBy = HttpContext.Current.Session("LoginID")
      Results.CreatedOn = Now
      For Each pkgD As SIS.PAK.pakPkgListD In pkgDs
        'Packing List Uploaded earlier, where Total Weight is not calculated
        '=========Can be deleted after July 2018===============
        If pkgD.TotalWeight = 0 Then
          pkgD.TotalWeight = SIS.PAK.pakPO.GetTotalWeight(pkgD.Quantity, pkgD.WeightPerUnit, pkgD.UOMQuantity, pkgD.UOMWeight)
          pkgD = SIS.PAK.pakPkgListD.UpdateData(pkgD)
        End If
        '===========End Of Can Be Deleted After July==============
        '=========================================================
        tmpTotalWt += pkgD.TotalWeight
        'Update BOM Item Despached
        Dim bomItm As SIS.PAK.pakPOBItems = SIS.PAK.pakPOBItems.pakPOBItemsGetByID(pkgD.SerialNo, pkgD.BOMNo, pkgD.ItemNo)
        bomItm.QuantityDespatched += pkgD.Quantity
        bomItm.TotalWeightDespatched += pkgD.TotalWeight
        bomItm = SIS.PAK.pakPOBItems.UpdateData(bomItm)
      Next
      Results.TotalWeight = tmpTotalWt
      '=======Update ERP Packing List========
      Dim UpdateInERP As Boolean = Convert.ToBoolean(ConfigurationManager.AppSettings("UpdateERP"))
      If UpdateInERP Then
        Try
          Dim mNextPkgNo As Integer = GetNextPkgNo()
          Dim tmpPkgH As SIS.PAK.pakERPPkgH = SIS.PAK.pakPkgListH.GetERPPkgH(Results)
          tmpPkgH.t_pkno = mNextPkgNo
          tmpPkgH = SIS.PAK.pakERPPkgH.InsertData(tmpPkgH)
          Dim I As Integer = 0
          For Each pkgItm As SIS.PAK.pakPkgListD In pkgDs
            I = I + 1
            Dim tmpPkgD As SIS.PAK.pakERPPkgD = SIS.PAK.pakPkgListD.GetERPPkgD(pkgItm)
            tmpPkgD.t_pkno = mNextPkgNo
            tmpPkgD.t_rcln = I
            tmpPkgD = SIS.PAK.pakERPPkgD.InsertData(tmpPkgD)
          Next
        Catch ex As Exception
          Throw New Exception(ex.Message)
        End Try
      End If
      '==========End In ERP Update===========
      'Update Paking List as Despatched
      Results.TotalWeight = tmpTotalWt
      Results = SIS.PAK.pakPkgListH.UpdateData(Results)
      'Send E-Mail
      Try
        PackageDispatchedEMail(Results)
      Catch ex As Exception
        Throw New Exception("E-Mail : " & ex.Message)
      End Try
      Return Results
    End Function
    Private Shared Function GetNextPkgNo() As Integer
      Dim NextNo As Integer = 1
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select MAX(ISNULL(t_pkno,1)) from ttdisg017200"
          Con.Open()
          NextNo = Cmd.ExecuteScalar
          NextNo += 1
        End Using
      End Using
      Return NextNo
    End Function

    Public Shared Function ApproveWF(ByVal SerialNo As Int32, ByVal PkgNo As Int32) As SIS.PAK.pakPkgListH
      Dim Results As SIS.PAK.pakPkgListH = pakPkgListHGetByID(SerialNo, PkgNo)
      Return Results
    End Function
    Public Shared Function UZ_pakPkgListHSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32) As List(Of SIS.PAK.pakPkgListH)
      Dim Results As List(Of SIS.PAK.pakPkgListH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_PkgListHSelectListSearch"
            Cmd.CommandText = "sppakPkgListHSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_PkgListHSelectListFilteres"
            Cmd.CommandText = "sppakPkgListHSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo", SqlDbType.Int, 10, IIf(SerialNo = Nothing, 0, SerialNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakPkgListH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakPkgListH(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakPkgListHInsert(ByVal Record As SIS.PAK.pakPkgListH) As SIS.PAK.pakPkgListH
      Dim _Result As SIS.PAK.pakPkgListH = pakPkgListHInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakPkgListHUpdate(ByVal Record As SIS.PAK.pakPkgListH) As SIS.PAK.pakPkgListH
      Dim _Result As SIS.PAK.pakPkgListH = pakPkgListHUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakPkgListHDelete(ByVal Record As SIS.PAK.pakPkgListH) As Integer
      Dim _Result As Integer = pakPkgListHDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_SerialNo"), TextBox).Text = ""
          CType(.FindControl("F_SerialNo_Display"), Label).Text = ""
          CType(.FindControl("F_PkgNo"), TextBox).Text = ""
          CType(.FindControl("F_SupplierRefNo"), TextBox).Text = ""
          CType(.FindControl("F_TransporterID"), TextBox).Text = ""
          CType(.FindControl("F_TransporterID_Display"), Label).Text = ""
          CType(.FindControl("F_TransporterName"), TextBox).Text = ""
          CType(.FindControl("F_VehicleNo"), TextBox).Text = ""
          CType(.FindControl("F_GRNo"), TextBox).Text = ""
          CType(.FindControl("F_GRDate"), TextBox).Text = ""
          CType(.FindControl("F_VRExecutionNo"), TextBox).Text = ""
          CType(.FindControl("F_VRExecutionNo_Display"), Label).Text = ""
          CType(.FindControl("F_Remarks"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Private Shared Sub PackageDispatchedEMail(ByVal Rec As SIS.PAK.pakPkgListH)
      Dim aErr As New ArrayList
      Dim mRet As String = ""
      Dim ad As MailAddress = Nothing
      Dim oClient As SmtpClient = New SmtpClient("192.9.200.214", 25)
      oClient.Credentials = New Net.NetworkCredential("adskvaultadmin", "isgec@123")
      Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
      With oMsg
        '1. From Supplier
        Dim oPO As SIS.PAK.pakPO = Rec.FK_PAK_PkgListH_SerialNo
        If oPO.FK_PAK_SupplierID.EMailID = String.Empty Then
          aErr.Add(oPO.SupplierID & " " & oPO.FK_PAK_SupplierID.BPName)
          .From = New MailAddress("baansupport@isgec.co.in", "BaaN Support")
        Else
          Dim aIDs() As String = oPO.FK_PAK_SupplierID.EMailID.Split(",".ToCharArray)
          For Each tmp As String In aIDs
            .From = New MailAddress(tmp.Trim, tmp.Trim)
            Exit For
          Next
        End If
        '2. To buyer
        If oPO.FK_PAK_PO_BuyerID.EMailID = String.Empty Then
          aErr.Add(oPO.BuyerID & " " & oPO.FK_PAK_PO_BuyerID.UserFullName)
          .To.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
        Else
          .To.Add(New MailAddress(oPO.FK_PAK_PO_BuyerID.EMailID, oPO.FK_PAK_PO_BuyerID.UserFullName))
        End If
        '3. To Issuer
        If oPO.FK_PAK_PO_IssuedBy.EMailID = String.Empty Then
          aErr.Add(oPO.IssuedBy & " " & oPO.FK_PAK_PO_IssuedBy.UserFullName)
        Else
          ad = New MailAddress(oPO.FK_PAK_PO_IssuedBy.EMailID, oPO.FK_PAK_PO_IssuedBy.UserFullName)
          If Not .To.Contains(ad) Then
            .To.Add(ad)
          End If
        End If
        '4. CC to Project Group
        Dim Users As List(Of SIS.EITL.eitlProjectWiseUser) = SIS.EITL.eitlProjectWiseUser.GetByProjectID(oPO.ProjectID, "")
        For Each usr As SIS.EITL.eitlProjectWiseUser In Users
          Try
            If usr.FK_EITL_ProjectWiseUser_UserID.EMailID <> "" Then
              ad = New MailAddress(usr.FK_EITL_ProjectWiseUser_UserID.EMailID, usr.FK_EITL_ProjectWiseUser_UserID.UserFullName)
              If Not .CC.Contains(ad) Then
                .CC.Add(ad)
              End If
            Else
              aErr.Add(usr.UserID & " " & usr.aspnet_Users1_UserFullName)
            End If
          Catch ex As Exception
          End Try
        Next
        '5. 
        .Subject = "Packing List Submitted: " & oPO.PONumber & " / " & oPO.ProjectID
        If .To.Count <= 0 Then
          .To.Add(New MailAddress("baansupport@isgec.co.in", "BaaN Support"))
        End If
        .IsBodyHtml = True
        Dim sb As StringBuilder = New StringBuilder()

        Try
          sb.Append("<br /><br />")
          sb.Append("Supplier has despatched material as per attached Packing List.")
        Catch ex As Exception
        End Try
        Dim FileName As String = SIS.PAK.pakPkgPO.DownloadTmplForPkg(Rec.PrimaryKey)

        Try
          Dim oAt As New System.Net.Mail.Attachment(FileName)
          oAt.Name = "PackingList_" & Rec.SerialNo & "_" & Rec.PkgNo & ".xlsx"
          .Attachments.Add(oAt)
        Catch ex As Exception
        End Try


        Dim Header As String = ""
        Header = Header & "<html xmlns=""http://www.w3.org/1999/xhtml"">"
        Header = Header & "<head>"
        Header = Header & "<title></title>"
        Header = Header & "<style>"
        Header = Header & "body{margin: 10px auto auto 60px;}"
        Header = Header & ".tblHd, .tblHd td{font-size: 12px;font-weight: bold;height: 30px !important;background-color:lightgray;}"
        Header = Header & "table{"
        Header = Header & "border: solid 1pt black;"
        Header = Header & "border-collapse:collapse;"
        Header = Header & "font-family: Tahoma;}"

        Header = Header & "td{padding-left: 4px;"
        Header = Header & "border: solid 1pt black;"
        Header = Header & "font-family: Tahoma;"
        Header = Header & "font-size: 9px;"
        Header = Header & "vertical-align:top;}"

        Header = Header & "</style>"
        Header = Header & "</head>"
        Header = Header & "<body>"
        If aErr.Count > 0 Then
          Header = Header & "<table>"
          Header = Header & "<tr><td style=""color: red""><i><b>"
          Header = Header & "NOTE: E-Mail Alert could not be delivered to following recipient(s), Please update their E-Mail ID in EITL/ERP Application."
          Header = Header & "</b></i></td></tr>"
          For Each Err As String In aErr
            Header = Header & "<tr><td color=""red""><i>"
            Header = Header & Err
            Header = Header & "</i></td></tr>"
          Next
          Header = Header & "</table>"
        End If
        Header = Header & sb.ToString
        Header = Header & "</body></html>"
        .Body = Header
      End With
      Try
        oClient.Send(oMsg)
      Catch ex As Exception
      End Try
    End Sub
    Public Shared Function GetERPPkgH(ByVal PkgListH As SIS.PAK.pakPkgListH) As SIS.PAK.pakERPPkgH
      Dim tmp As New SIS.PAK.pakERPPkgH
      With tmp
        .t_orno = PkgListH.FK_PAK_PkgListH_SerialNo.PONumber
        .t_pkno = 1 'get max pkno in ERP + 1 when Inserting
        .t_srno = PkgListH.SerialNo
        .t_pkgn = PkgListH.PkgNo
        .t_rcno = ""
        .t_isup = PkgListH.SupplierRefNo
        .t_pkdt = PkgListH.CreatedOn
        .t_ntwt = PkgListH.TotalWeight
        .t_grwt = PkgListH.TotalWeight
        .t_tnam = IIf(PkgListH.TransporterID = "", PkgListH.TransporterName, PkgListH.VR_BusinessPartner4_BPName)
        .t_vhno = PkgListH.VehicleNo
        .t_lrno = PkgListH.GRNo
        .t_lrdt = PkgListH.GRDate
        .t_Refcntd = 0
        .t_Refcntu = 0
      End With
      Return tmp
    End Function
  End Class
End Namespace
