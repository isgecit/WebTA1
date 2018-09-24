Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.EITL
  Partial Public Class eitlPOList
    Public ReadOnly Property GetDownloadLink() As String
      Get
        Return "javascript:window.open('" & HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath & "/EITL_Main/App_Downloads/filedownload.aspx?tmpl=" & PrimaryKey & "', 'win" & _SerialNo & "', 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1'); return false;"
      End Get
    End Property
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Red
      If POStatusID = 3 Then
        mRet = Drawing.Color.Green
      ElseIf POStatusID = 4 Then
        mRet = Drawing.Color.DarkMagenta
      ElseIf POStatusID = 5 Then
        mRet = Drawing.Color.DarkOrange
      ElseIf POStatusID = 6 Then
        mRet = Drawing.Color.DarkGoldenrod
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
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetVisible()
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
    'Close PO
    Public ReadOnly Property CompleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          If _POStatusID = 3 Then
            'PO Status when Partial 
            mRet = True
          End If
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
    Public Shared Function InitiateWF(ByVal SerialNo As Int32) As SIS.EITL.eitlPOList
      Dim Results As SIS.EITL.eitlPOList = eitlPOListGetByID(SerialNo)
      'Partially Executed PO
      With Results
        .POStatusID = 3
        'Update Dispatches
      End With
      Results = SIS.EITL.eitlPOList.UpdateData(Results)
      'Update Items
      Dim oItems As List(Of SIS.EITL.eitlPOItemList) = SIS.EITL.eitlPOItemList.eitlPOItemListSelectList(0, 99999, "", False, "", SerialNo)
      For Each itm As SIS.EITL.eitlPOItemList In oItems
        If itm.ReadyToDespatch Then
          itm.DespatchDate = Now
          itm.Despatched = True
          SIS.EITL.eitlPOItemList.UpdateData(itm)
        End If
      Next
      'Update Documents
      Dim oDocs As List(Of SIS.EITL.eitlPODocumentList) = SIS.EITL.eitlPODocumentList.eitlPODocumentListSelectList(0, 99999, "", False, "", SerialNo)
      For Each doc As SIS.EITL.eitlPODocumentList In oDocs
        If doc.ReadyToDespatch Then
          doc.Despatched = True
          doc.DespatchDate = Now
          SIS.EITL.eitlPODocumentList.UpdateData(doc)
        End If
      Next
      'Send E-Mail
      SIS.EITL.Alerts.Alert(SerialNo, AlertEvents.MaterialDespatched)
      Return Results
    End Function
    Public Shared Function ApproveWF(ByVal SerialNo As Int32) As SIS.EITL.eitlPOList
      Dim Results As SIS.EITL.eitlPOList = eitlPOListGetByID(SerialNo)
      Return Results
    End Function
    Public Shared Function CompleteWF(ByVal SerialNo As Int32) As SIS.EITL.eitlPOList
      'PO Closed By supplier
      Dim Results As SIS.EITL.eitlPOList = eitlPOListGetByID(SerialNo)
      With Results
        .POStatusID = 4
        .ClosedBy = HttpContext.Current.Session("LoginID")
        .ClosedOn = Now
      End With
      Results = SIS.EITL.eitlPOList.UpdateData(Results)
      'Send E-Mail
      SIS.EITL.Alerts.Alert(SerialNo, AlertEvents.POClosed)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function UZ_eitlPOListSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String) As List(Of SIS.EITL.eitlPOList)
      Dim Results As List(Of SIS.EITL.eitlPOList) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "SerialNo DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "speitlPOListSelectListSearch"
            Cmd.CommandText = "speitl_LG_POListSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "speitlPOListSelectListFilteres"
            Cmd.CommandText = "speitl_LG_POListSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID", SqlDbType.NVarChar, 6, IIf(ProjectID Is Nothing, String.Empty, ProjectID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.EITL.eitlPOList)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.EITL.eitlPOList(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_eitlPOListDelete(ByVal SerialNo As Integer) As Boolean
      Dim mRet As Boolean = False
      Dim oDocs As List(Of SIS.EITL.eitlPODocumentList) = SIS.EITL.eitlPODocumentList.eitlPODocumentListSelectList(0, 9999, "", False, "", SerialNo)
      For Each doc As SIS.EITL.eitlPODocumentList In oDocs
        SIS.EITL.eitlPODocumentList.eitlPODocumentListDelete(doc)
      Next
      Dim oItms As List(Of SIS.EITL.eitlPOItemList) = SIS.EITL.eitlPOItemList.eitlPOItemListSelectList(0, 9999, "", False, "", SerialNo)
      For Each Itm As SIS.EITL.eitlPOItemList In oItms
        SIS.EITL.eitlPOItemList.eitlPOItemListDelete(Itm)
      Next
      'Delete PO is pending
      Return True
    End Function
  End Class
End Namespace
