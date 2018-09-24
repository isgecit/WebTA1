Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakSTCPO
    Public Shadows Function GetEditable() As Boolean
      Dim mRet As Boolean = False
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
    Public Shadows ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case POStatusID
            Case pakTCPOStates.IssuedToSupplier
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property ApproveWFEnable() As Boolean
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
        Dim mRet As Boolean = False
        Try
          Select Case POStatusID
            Case pakTCPOStates.Closed
              mRet = True
          End Select
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
    Public Shared Shadows Function ApproveWF(ByVal SerialNo As Int32) As SIS.PAK.pakSTCPO
      Dim Results As SIS.PAK.pakSTCPO = pakSTCPOGetByID(SerialNo)
      Return Results
    End Function
    Public Shared Function CompleteWF(ByVal SerialNo As Int32) As SIS.PAK.pakSTCPO
      Dim Results As SIS.PAK.pakSTCPO = pakSTCPOGetByID(SerialNo)
      Return Results
    End Function
    Public Shared Function UZ_pakSTCPOSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal POTypeID As Int32, ByVal SupplierID As String, ByVal ProjectID As String, ByVal BuyerID As String, ByVal POStatusID As Int32, ByVal IssuedBy As String) As List(Of SIS.PAK.pakSTCPO)
      Dim Results As List(Of SIS.PAK.pakSTCPO) = Nothing
      If OrderBy = "" Then OrderBy = "SerialNo DESC"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_STCPOSelectListSearch"
            Cmd.CommandText = "sppakSTCPOSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_STCPOSelectListFilteres"
            Cmd.CommandText = "sppakSTCPOSelectListFilteres"
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
          RecordCount = -1
          Results = New List(Of SIS.PAK.pakSTCPO)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSTCPO(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakSTCPOInsert(ByVal Record As SIS.PAK.pakSTCPO) As SIS.PAK.pakSTCPO
      Dim _Result As SIS.PAK.pakSTCPO = pakSTCPOInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakSTCPOUpdate(ByVal Record As SIS.PAK.pakSTCPO) As SIS.PAK.pakSTCPO
      Dim _Result As SIS.PAK.pakSTCPO = pakSTCPOUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakSTCPODelete(ByVal Record As SIS.PAK.pakSTCPO) As Int32
      Dim _Result As Integer = pakTCPODelete(Record)
      Return _Result
    End Function
  End Class
End Namespace
