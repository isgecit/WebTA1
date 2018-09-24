Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakSTCPOLRD
    Public ReadOnly Property IsAdmin As Boolean
      Get
        Return IIf(HttpContext.Current.Session("LoginID") = "0340", True, False)
      End Get
    End Property
    'As Comments Attached In ERP
    Public ReadOnly Property GetCommentsLink() As String
      Get
        Dim UrlAuthority As String = HttpContext.Current.Request.Url.Authority
        If UrlAuthority.ToLower <> "cloud.isgec.co.in" Then
          UrlAuthority = "192.9.200.146"
        End If
        Dim mRet As String = HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & UrlAuthority
        mRet &= "/Attachment/Attachment.aspx?AthHandle=IDMS_PO_CONSOLIDATED_COMMENT_200"
        Dim Index As String = ReceiptNo & "_" & RevisionNo & "_" & ERPDocSerialNo
        Dim User As String = FK_PAK_POLineRecDoc_UploadNo.CreatedBy
        Dim canEdit As String = "n"
        mRet &= "&Index=" & Index & "&AttachedBy=" & User & "&ed=" & canEdit
        Return mRet
      End Get
    End Property
    'As Copied in ERP
    Public ReadOnly Property GetRecAttachLink() As String
      Get
        Dim UrlAuthority As String = HttpContext.Current.Request.Url.Authority
        If UrlAuthority.ToLower <> "cloud.isgec.co.in" Then
          UrlAuthority = "192.9.200.146"
        End If
        Dim mRet As String = HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & UrlAuthority
        mRet &= "/Attachment/Attachment.aspx?AthHandle=IDMSRECEIPTS_200"
        Dim Index As String = ReceiptNo & "_" & RevisionNo & "_" & ERPDocSerialNo
        Dim User As String = FK_PAK_POLineRecDoc_UploadNo.CreatedBy
        Dim canEdit As String = "n"
        mRet &= "&Index=" & Index & "&AttachedBy=" & User & "&ed=" & canEdit
        Return mRet
      End Get
    End Property
    'AS Linked in Joomla
    Public ReadOnly Property GetAttachLink() As String
      Get
        Dim UrlAuthority As String = HttpContext.Current.Request.Url.Authority
        If UrlAuthority.ToLower <> "cloud.isgec.co.in" Then
          UrlAuthority = "192.9.200.146"
        End If
        Dim mRet As String = HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & UrlAuthority
        mRet &= "/Attachment/Attachment.aspx?AthHandle=J_IDMSPOSTORDERREC"
        Dim Index As String = SerialNo & "_" & ItemNo & "_" & UploadNo & "_" & DocSerialNo
        Dim User As String = HttpContext.Current.Session("LoginID")
        'User = 1
        Dim canEdit As String = "n"
        If Editable Then
          canEdit = "y"
        End If
        mRet &= "&Index=" & Index & "&AttachedBy=" & User & "&ed=" & canEdit
        Return mRet
      End Get
    End Property
    Public Shared Function DeleteERPAttachments(ByVal STCPOLRD As SIS.PAK.pakSTCPOLRD) As SIS.PAK.pakSTCPOLRD
      'Use this procedure after deleting physical files from library
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "Delete from tdmisg132200 where t_hndl='J_IDMSPOSTORDERREC' and t_indx like '" & STCPOLRD.SerialNo & "_" & STCPOLRD.ItemNo & "_" & STCPOLRD.UploadNo & "_" & STCPOLRD.DocSerialNo & "%'"
          Con.Open()
          Cmd.ExecuteNonQuery()
        End Using
      End Using
      Return STCPOLRD
    End Function

    Public Shadows Function GetEditable() As Boolean
      Dim mRet As Boolean = False
      Select Case FK_PAK_POLineRecDoc_UploadNo.UploadStatusID
        Case pakTCUploadStates.Free
          mRet = True
      End Select
      Return mRet
    End Function
    Public Shadows Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      Select Case FK_PAK_POLineRecDoc_UploadNo.UploadStatusID
        Case pakTCUploadStates.Free
          mRet = True
      End Select
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
    Public Shared Function GetByFileName(ByVal SerialNo As Int32, ByVal ItemNo As Int32, ByVal UploadNo As Int32, ByVal FileName As String) As SIS.PAK.pakSTCPOLRD
      Dim Results As SIS.PAK.pakSTCPOLRD = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppak_LG_TCPOLRDGetByFileName"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo", SqlDbType.Int, SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo", SqlDbType.Int, ItemNo.ToString.Length, ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UploadNo", SqlDbType.Int, UploadNo.ToString.Length, UploadNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileName", SqlDbType.NVarChar, FileName.ToString.Length, FileName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakSTCPOLRD(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakSTCPOLRDSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal ItemNo As Int32, ByVal UploadNo As Int32) As List(Of SIS.PAK.pakSTCPOLRD)
      Dim Results As List(Of SIS.PAK.pakSTCPOLRD) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_STCPOLRDSelectListSearch"
            Cmd.CommandText = "sppakSTCPOLRDSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_STCPOLRDSelectListFilteres"
            Cmd.CommandText = "sppakSTCPOLRDSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo", SqlDbType.Int, 10, IIf(SerialNo = Nothing, 0, SerialNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ItemNo", SqlDbType.Int, 10, IIf(ItemNo = Nothing, 0, ItemNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_UploadNo", SqlDbType.Int, 10, IIf(UploadNo = Nothing, 0, UploadNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PAK.pakSTCPOLRD)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSTCPOLRD(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakSTCPOLRDInsert(ByVal Record As SIS.PAK.pakSTCPOLRD) As SIS.PAK.pakSTCPOLRD
      Dim _Result As SIS.PAK.pakSTCPOLRD = pakSTCPOLRDInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakSTCPOLRDUpdate(ByVal Record As SIS.PAK.pakSTCPOLRD) As SIS.PAK.pakSTCPOLRD
      Dim _Result As SIS.PAK.pakSTCPOLRD = pakSTCPOLRDUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakSTCPOLRDDelete(ByVal Record As SIS.PAK.pakSTCPOLRD) As Int32
      Dim _Result As Integer = pakTCPOLRDDelete(Record)
      If IO.File.Exists(Record.DiskFileName) Then
        IO.File.Delete(Record.DiskFileName)
      End If
      Return _Result
    End Function
    Public Shared Function GetERPRecD(ByVal STCPOLRD As SIS.PAK.pakSTCPOLRD) As SIS.PAK.pakERPRecD
      Dim tmp As New SIS.PAK.pakERPRecD
      With tmp
        .t_rcno = STCPOLRD.ReceiptNo
        .t_revn = STCPOLRD.RevisionNo
        .t_srno = STCPOLRD.ERPDocSerialNo
        .t_docn = STCPOLRD.DocumentID
        .t_revi = STCPOLRD.DocumentRev
        .t_dsca = STCPOLRD.DocumentDescription
        .t_idoc = ""
        .t_irev = ""
        .t_date = "01/01/1970"
        .t_remk = ""
        .t_proc = 2 'No
        .t_Refcntd = 0
        .t_Refcntu = 0
      End With
      Return tmp
    End Function
  End Class
End Namespace
