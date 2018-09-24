Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakSPOBIDocuments
    Public Shadows ReadOnly Property DeleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property DeleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Shadows Function DeleteWF(ByVal SerialNo As Int32, ByVal BOMNo As Int32, ByVal ItemNo As Int32, ByVal DocNo As Int32) As SIS.PAK.pakSPOBIDocuments
      Dim Results As SIS.PAK.pakSPOBIDocuments = pakSPOBIDocumentsGetByID(SerialNo, BOMNo, ItemNo, DocNo)
      Return Results
    End Function
    Public Shared Function UZ_pakSPOBIDocumentsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32, ByVal BOMNo As Int32, ByVal ItemNo As Int32) As List(Of SIS.PAK.pakSPOBIDocuments)
      Dim Results As List(Of SIS.PAK.pakSPOBIDocuments) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_SPOBIDocumentsSelectListSearch"
            Cmd.CommandText = "sppakSPOBIDocumentsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_SPOBIDocumentsSelectListFilteres"
            Cmd.CommandText = "sppakSPOBIDocumentsSelectListFilteres"
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
          RecordCount = -1
          Results = New List(Of SIS.PAK.pakSPOBIDocuments)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSPOBIDocuments(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakSPOBIDocumentsInsert(ByVal Record As SIS.PAK.pakSPOBIDocuments) As SIS.PAK.pakSPOBIDocuments
      Dim _Result As SIS.PAK.pakSPOBIDocuments = pakSPOBIDocumentsInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakSPOBIDocumentsUpdate(ByVal Record As SIS.PAK.pakSPOBIDocuments) As SIS.PAK.pakSPOBIDocuments
      Dim _Result As SIS.PAK.pakSPOBIDocuments = pakSPOBIDocumentsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakSPOBIDocumentsDelete(ByVal Record As SIS.PAK.pakSPOBIDocuments) As Int32
      Dim _Result As Integer = pakPOBIDocumentsDelete(Record)
      Return _Result
    End Function
  End Class
End Namespace
