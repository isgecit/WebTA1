Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakSPO
    Public Shadows ReadOnly Property Editable As Boolean
      Get
        Dim mRet As Boolean = False
        Select Case POStatusID
          Case pakPOStates.UnderSupplierVerification
            mRet = True
        End Select
        Return mRet
      End Get
    End Property

    Public Shadows ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case POStatusID
            Case pakPOStates.UnderSupplierVerification
              mRet = True
          End Select
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
        Dim mRet As Boolean = False
        Try
          Select Case POStatusID
            Case pakPOStates.IssuedtoSupplier
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
          mRet = GetVisible()
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
        Dim mRet As Boolean = False
        Try
          Select Case POStatusID
            Case pakPOStates.IssuedtoSupplier, pakPOStates.UnderDespatch
          End Select
        Catch ex As Exception
        End Try
        Return False
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
    Public Shared Shadows Function InitiateWF(ByVal SerialNo As Int32) As SIS.PAK.pakSPO
      Dim tmp As List(Of SIS.PAK.pakPOBOM) = SIS.PAK.pakPOBOM.UZ_pakPOBOMSelectList(0, 999, "", False, "", SerialNo)
      For Each ttmp As SIS.PAK.pakPOBOM In tmp
        Dim cnt As Integer = SIS.PAK.pakPOBItems.GetpakPOBItemsCreatedByISGECCount(ttmp.SerialNo, ttmp.BOMNo)
        If cnt > 0 Then
          Throw New Exception("Item(s) NOT Verified, Pl. Verify the Item before transfer to ISGEC.")
        End If
      Next
      Dim Results As SIS.PAK.pakPO = pakSPOGetByID(SerialNo)
      With Results
        .POStatusID = pakPOStates.UnderISGECApproval
        .IssuedBy = HttpContext.Current.Session("LoginID")
        .IssuedOn = Now
      End With
      Results = SIS.PAK.pakSPO.UpdateData(Results)
      '===========================================
      'Send Verification DONE E-Mail
      SIS.PAK.Alerts.Alert(SerialNo, pakAlertEvents.POApproval)
      '===========================================
      Return Results
    End Function
    Public Shared Shadows Function ApproveWF(ByVal SerialNo As Int32) As SIS.PAK.pakSPO
      Dim Results As SIS.PAK.pakSPO = pakSPOGetByID(SerialNo)
      Return Results
    End Function
    Public Shared Shadows Function RejectWF(ByVal SerialNo As Int32) As SIS.PAK.pakSPO
      Dim Results As SIS.PAK.pakSPO = pakSPOGetByID(SerialNo)
      Return Results
    End Function
    Public Shared Shadows Function CompleteWF(ByVal SerialNo As Int32) As SIS.PAK.pakSPO
      Dim Results As SIS.PAK.pakSPO = pakSPOGetByID(SerialNo)
      Return Results
    End Function
    Public Shared Function UZ_pakSPOSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal POTypeID As Int32, ByVal ProjectID As String, ByVal BuyerID As String, ByVal IssuedBy As String) As List(Of SIS.PAK.pakSPO)
      Dim Results As List(Of SIS.PAK.pakSPO) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_SPOSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_SPOSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_POTypeID", SqlDbType.Int, 10, IIf(POTypeID = Nothing, 0, POTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID", SqlDbType.NVarChar, 6, IIf(ProjectID Is Nothing, String.Empty, ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BuyerID", SqlDbType.NVarChar, 8, IIf(BuyerID Is Nothing, String.Empty, BuyerID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_IssuedBy", SqlDbType.NVarChar, 8, IIf(IssuedBy Is Nothing, String.Empty, IssuedBy))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID", SqlDbType.NVarChar, 9, "S" & HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@POStatusID", SqlDbType.Int, 10, pakPOStates.UnderSupplierVerification)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PAK.pakSPO)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSPO(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakSPOUpdate(ByVal Record As SIS.PAK.pakSPO) As SIS.PAK.pakSPO
      Dim _Rec As SIS.PAK.pakSPO = SIS.PAK.pakSPO.pakSPOGetByID(Record.SerialNo)
      With _Rec
        .SupplierRemarks = Record.SupplierRemarks
      End With
      Return SIS.PAK.pakSPO.UpdateData(_Rec)
    End Function
  End Class
End Namespace
