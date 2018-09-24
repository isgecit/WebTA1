Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakSPOBOM
    Public Shadows ReadOnly Property Editable As Boolean
      Get
        Dim mRet As Boolean = False
        Select Case FK_PAK_POBOM_SerialNo.POStatusID
          Case pakPOStates.UnderSupplierVerification
            mRet = True
        End Select
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          Select Case StatusID
            Case pakItemStates.CreatedByISGEC
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
    Public Shadows ReadOnly Property RejectWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          Select Case StatusID
            Case pakItemStates.VerifiedbySupplier
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property RejectWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property CompleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property CompleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Shadows Function InitiateWF(ByVal SerialNo As Int32, ByVal BOMNo As Int32) As SIS.PAK.pakSPOBOM
      Dim Results As SIS.PAK.pakSPOBOM = pakSPOBOMGetByID(SerialNo, BOMNo)
      Return Results
    End Function
    Public Shared Shadows Function ApproveWF(ByVal SerialNo As Int32, ByVal BOMNo As Int32) As SIS.PAK.pakSPOBOM
      Dim Results As SIS.PAK.pakSPOBOM = pakSPOBOMGetByID(SerialNo, BOMNo)
      Dim tmp As List(Of SIS.PAK.pakPOBItems) = SIS.PAK.pakPOBItems.pakPOBItemsSelectList(0, 99999, "", False, "", BOMNo, SerialNo)
      For Each ttmp As SIS.PAK.pakPOBItems In tmp
        With ttmp
          .StatusID = pakItemStates.VerifiedbySupplier
          .AcceptedBy = HttpContext.Current.Session("LoginID")
          .AcceptedOn = Now
          .Accepted = True
          .Changed = False
        End With
        ttmp = SIS.PAK.pakPOBItems.UpdateData(ttmp)
      Next
      Return Results
    End Function
    Public Shared Shadows Function RejectWF(ByVal SerialNo As Int32, ByVal BOMNo As Int32) As SIS.PAK.pakSPOBOM
      Dim Results As SIS.PAK.pakSPOBOM = pakSPOBOMGetByID(SerialNo, BOMNo)
      Dim tmp As List(Of SIS.PAK.pakPOBItems) = SIS.PAK.pakPOBItems.pakPOBItemsSelectList(0, 99999, "", False, "", BOMNo, SerialNo)
      For Each ttmp As SIS.PAK.pakPOBItems In tmp
        With ttmp
          .StatusID = pakItemStates.ChangeRequiredBySupplier
          .AcceptedBy = HttpContext.Current.Session("LoginID")
          .AcceptedOn = Now
          .Accepted = False
          .Changed = True
        End With
        ttmp = SIS.PAK.pakPOBItems.UpdateData(ttmp)
      Next
      Return Results
    End Function
    Public Shared Shadows Function CompleteWF(ByVal SerialNo As Int32, ByVal BOMNo As Int32) As SIS.PAK.pakSPOBOM
      Dim Results As SIS.PAK.pakSPOBOM = pakSPOBOMGetByID(SerialNo, BOMNo)
      Return Results
    End Function
    Public Shared Function UZ_pakSPOBOMSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32) As List(Of SIS.PAK.pakSPOBOM)
      Dim Results As List(Of SIS.PAK.pakSPOBOM) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_SPOBOMSelectListSearch"
            Cmd.CommandText = "sppakSPOBOMSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_SPOBOMSelectListFilteres"
            Cmd.CommandText = "sppakSPOBOMSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PAK.pakSPOBOM)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSPOBOM(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakSPOBOMUpdate(ByVal Record As SIS.PAK.pakSPOBOM) As SIS.PAK.pakSPOBOM
      Dim _Rec As SIS.PAK.pakSPOBOM = SIS.PAK.pakSPOBOM.pakSPOBOMGetByID(Record.SerialNo, Record.BOMNo)
      With _Rec
        .SupplierRemarks = Record.SupplierRemarks
      End With
      Return SIS.PAK.pakSPOBOM.UpdateData(_Rec)
    End Function
  End Class
End Namespace
