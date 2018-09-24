Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakIQCListH
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
    Public Shadows ReadOnly Property GetPrintLink() As String
      Get
        Return "javascript:window.open('" & HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath & "/PAK_Main/App_Downloads/qcldownload.aspx?qcl=" & PrimaryKey & "&typ=1" & "', 'win" & QCLNo & "', 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1'); return false;"
      End Get
    End Property
    Public Shadows Function GetEditable() As Boolean
      Dim mRet As Boolean = False
      Select Case StatusID
        Case pakQCStates.UnderQualityInspection
          mRet = True
      End Select
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
    Public ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
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
          'Show Reject In MyLogin upto FREE Packing List Created
          mRet = GetEditable()
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
    Public Shared Function ApproveWF(ByVal SerialNo As Int32, ByVal QCLNo As Int32, ByVal QCRequestNo As String, ByVal Remarks As String) As SIS.PAK.pakIQCListH
      If QCRequestNo Is Nothing Then QCRequestNo = ""
      Dim Results As SIS.PAK.pakIQCListH = pakIQCListHGetByID(SerialNo, QCLNo)
      Dim tmpDs As List(Of SIS.PAK.pakIQCListD) = SIS.PAK.pakIQCListD.pakIQCListDSelectList(0, 99999, "", False, "", SerialNo, QCLNo)
      For Each tmpD As SIS.PAK.pakIQCListD In tmpDs
        Dim tmpItm As SIS.PAK.pakPOBItems = SIS.PAK.pakPOBItems.pakPOBItemsGetByID(tmpD.SerialNo, tmpD.BOMNo, tmpD.ItemNo)
        If tmpItm IsNot Nothing Then
          Dim x As Decimal = 0
          If tmpD.QualityClearedQty <> "" Then x = Convert.ToDecimal(tmpD.QualityClearedQty)
          tmpItm.QualityClearedQty += x
          tmpItm = SIS.PAK.pakPOBItems.UpdateData(tmpItm)
        End If
      Next
      With Results
        .ClearedBy = HttpContext.Current.Session("LoginID")
        .ClearedOn = Now
        .StatusID = pakQCStates.QCCompleted
        .QCRequestNo = QCRequestNo
        .Remarks = Remarks
      End With
      Results = SIS.PAK.pakIQCListH.UpdateData(Results)
      Try
        SIS.CT.ctUpdates.CT_QCCleared(Results)
      Catch ex As Exception
      End Try
      Return Results
    End Function
    Public Shared Function RejectWF(ByVal SerialNo As Int32, ByVal QCLNo As Int32, ByVal Remarks As String) As SIS.PAK.pakIQCListH
      '1 & 2 are written to execute return, even if packing list is created and Free (Not Dispatched i.e. Receipt Not created in ERP)
      'Enable Visible in Admin Login
      '1.
      Dim Results As SIS.PAK.pakIQCListH = pakIQCListHGetByID(SerialNo, QCLNo)
      If Results.StatusID = pakQCStates.PackingListCreated Then
        Dim tmpH As SIS.PAK.pakPkgListH = SIS.PAK.pakPkgListH.pakPkgListHGetByID(Results.SerialNo, Results.PkgNo)
        Try
          If tmpH.StatusID = pakPkgStates.Free Then
            Dim tmpDs As List(Of SIS.PAK.pakPkgListD) = SIS.PAK.pakPkgListD.pakPkgListDSelectList(0, 99999, "", False, "", Results.PkgNo, Results.SerialNo)
            For Each tmpD As SIS.PAK.pakPkgListD In tmpDs
              SIS.PAK.pakPkgListD.pakPkgListDDelete(tmpD)
            Next
            SIS.PAK.pakPkgListH.pakPkgListHDelete(tmpH)
          End If
        Catch ex As Exception
        End Try
        Results.StatusID = pakQCStates.QCCompleted
      End If
      '2.
      If Results.StatusID = pakQCStates.QCCompleted Then
        Dim tmpDs As List(Of SIS.PAK.pakQCListD) = SIS.PAK.pakQCListD.pakQCListDSelectList(0, 99999, "", False, "", Results.SerialNo, Results.QCLNo)
        For Each tmpD As SIS.PAK.pakQCListD In tmpDs
          Dim tmpItm As SIS.PAK.pakPOBItems = SIS.PAK.pakPOBItems.pakPOBItemsGetByID(tmpD.SerialNo, tmpD.BOMNo, tmpD.ItemNo)
          If tmpItm IsNot Nothing Then
            Dim x As Decimal = 0
            If tmpD.QualityClearedQty <> "" Then x = Convert.ToDecimal(tmpD.QualityClearedQty)
            tmpItm.QualityClearedQty -= x
            tmpItm = SIS.PAK.pakPOBItems.UpdateData(tmpItm)
          End If
        Next
      End If
      '3.
      With Results
        .ClearedBy = HttpContext.Current.Session("LoginID")
        .ClearedOn = Now
        .StatusID = pakQCStates.Returned
        .Remarks = Remarks
      End With
      Results = SIS.PAK.pakIQCListH.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function UZ_pakIQCListHSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal QCLNo As Int32, ByVal StatusID As Int32, ByVal ClearedBy As String, ByVal CreatedBy As String) As List(Of SIS.PAK.pakIQCListH)
      Dim Results As List(Of SIS.PAK.pakIQCListH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "QCLNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_IQCListHSelectListSearch"
            'Cmd.CommandText = "sppakIQCListHSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_IQCListHSelectListFilteres"
            'Cmd.CommandText = "sppakIQCListHSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo", SqlDbType.Int, 10, IIf(SerialNo = Nothing, 0, SerialNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_QCLNo", SqlDbType.Int, 10, IIf(QCLNo = Nothing, 0, QCLNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StatusID", SqlDbType.Int, 10, IIf(StatusID = Nothing, 0, StatusID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ClearedBy", SqlDbType.NVarChar, 8, IIf(ClearedBy Is Nothing, String.Empty, ClearedBy))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CreatedBy", SqlDbType.NVarChar, 8, IIf(CreatedBy Is Nothing, String.Empty, CreatedBy))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PAK.pakIQCListH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakIQCListH(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakIQCListHUpdate(ByVal Record As SIS.PAK.pakIQCListH) As SIS.PAK.pakIQCListH
      Dim _Result As SIS.PAK.pakIQCListH = pakIQCListHUpdate(Record)
      Return _Result
    End Function
  End Class
End Namespace
