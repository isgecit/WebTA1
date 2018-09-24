Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakPOBIDocuments
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
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
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case FK_PAK_POBIDocuments_SerialNo.POStatusID
            Case pakPOStates.Free, pakPOStates.UnderISGECApproval
              If Not FK_PAK_POBIDocuments_ItemNo.Freezed Then
                mRet = True
              End If
          End Select
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
    Public ReadOnly Property DeleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case FK_PAK_POBIDocuments_SerialNo.POStatusID
            Case pakPOStates.Free, pakPOStates.UnderISGECApproval
              If Not FK_PAK_POBIDocuments_ItemNo.Freezed Then
                mRet = True
              End If
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DeleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function DeleteWF(ByVal SerialNo As Int32, ByVal BOMNo As Int32, ByVal ItemNo As Int32, ByVal DocNo As Int32) As SIS.PAK.pakPOBIDocuments
      Dim Results As SIS.PAK.pakPOBIDocuments = pakPOBIDocumentsGetByID(SerialNo, BOMNo, ItemNo, DocNo)
      Return Results
    End Function
    Public Shared Function UZ_pakPOBIDocumentsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal BOMNo As Int32, ByVal ItemNo As Int32) As List(Of SIS.PAK.pakPOBIDocuments)
      Dim Results As List(Of SIS.PAK.pakPOBIDocuments) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_POBIDocumentsSelectListSearch"
            Cmd.CommandText = "sppakPOBIDocumentsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_POBIDocumentsSelectListFilteres"
            Cmd.CommandText = "sppakPOBIDocumentsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BOMNo",SqlDbType.Int,10, IIf(BOMNo = Nothing, 0,BOMNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ItemNo",SqlDbType.Int,10, IIf(ItemNo = Nothing, 0,ItemNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakPOBIDocuments)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakPOBIDocuments(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakPOBIDocumentsInsert(ByVal Record As SIS.PAK.pakPOBIDocuments) As SIS.PAK.pakPOBIDocuments
      Dim _Result As SIS.PAK.pakPOBIDocuments = pakPOBIDocumentsInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakPOBIDocumentsUpdate(ByVal Record As SIS.PAK.pakPOBIDocuments) As SIS.PAK.pakPOBIDocuments
      Dim _Result As SIS.PAK.pakPOBIDocuments = pakPOBIDocumentsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakPOBIDocumentsDelete(ByVal Record As SIS.PAK.pakPOBIDocuments) As Integer
      Dim _Result as Integer = pakPOBIDocumentsDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_SerialNo"), TextBox).Text = ""
        CType(.FindControl("F_SerialNo_Display"), Label).Text = ""
        CType(.FindControl("F_BOMNo"), TextBox).Text = ""
        CType(.FindControl("F_BOMNo_Display"), Label).Text = ""
        CType(.FindControl("F_ItemNo"), TextBox).Text = ""
        CType(.FindControl("F_ItemNo_Display"), Label).Text = ""
        CType(.FindControl("F_DocNo"), TextBox).Text = ""
        CType(.FindControl("F_DocumentID"), TextBox).Text = ""
        CType(.FindControl("F_DocumentRevision"), TextBox).Text = ""
        CType(.FindControl("F_DocumentName"), TextBox).Text = ""
        CType(.FindControl("F_FileName"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
