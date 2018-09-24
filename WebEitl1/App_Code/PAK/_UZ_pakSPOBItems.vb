Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakSPOBItems
    Public Shadows ReadOnly Property Editable As Boolean
      Get
        Dim mRet As Boolean = False
        Select Case FK_PAK_POBItems_SerialNo.POStatusID
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
        Dim mRet As Boolean = False
        Select Case FK_PAK_POBItems_SerialNo.POStatusID
          Case pakPOStates.UnderSupplierVerification
            If Not Accepted Then
              mRet = True
            End If
        End Select
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
        Dim mRet As Boolean = False
        Select Case FK_PAK_POBItems_SerialNo.POStatusID
          Case pakPOStates.UnderSupplierVerification
            If Accepted Then
              mRet = True
            End If
        End Select
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
    Public Shared Shadows Function InitiateWF(ByVal SerialNo As Int32, ByVal BOMNo As Int32, ByVal ItemNo As Int32) As SIS.PAK.pakSPOBItems
      Dim Results As SIS.PAK.pakSPOBItems = pakSPOBItemsGetByID(SerialNo, BOMNo, ItemNo)
      Return Results
    End Function
    Private Shared Sub rApproveWF(ByVal pItm As SIS.PAK.pakPOBItems, ByVal ParentItemNo As Integer)
      Dim Items As List(Of SIS.PAK.pakPOBItems) = SIS.PAK.pakPOBItems.GetByParentPOBItemNo(pItm.SerialNo, pItm.BOMNo, ParentItemNo, "")
      If Items.Count > 0 Then
        For Each Itm As SIS.PAK.pakPOBItems In Items
          With Itm
            .StatusID = pakItemStates.VerifiedbySupplier
            .AcceptedBy = HttpContext.Current.Session("LoginID")
            .AcceptedOn = Now
            .Accepted = True
            .Changed = False
          End With
          Itm = pakPOBItems.UpdateData(Itm)
          rApproveWF(Itm, Itm.ItemNo)
        Next
      End If
    End Sub
    Public Shared Shadows Function ApproveWF(ByVal SerialNo As Int32, ByVal BOMNo As Int32, ByVal ItemNo As Int32) As SIS.PAK.pakSPOBItems
      Dim Results As SIS.PAK.pakPOBItems = pakPOBItemsGetByID(SerialNo, BOMNo, ItemNo)
      With Results
        .StatusID = pakItemStates.VerifiedbySupplier
        .AcceptedBy = HttpContext.Current.Session("LoginID")
        .AcceptedOn = Now
        .Accepted = True
        .Changed = False
      End With
      Results = pakPOBItems.UpdateData(Results)
      rApproveWF(Results, ItemNo)
      Return pakSPOBItemsGetByID(SerialNo, BOMNo, ItemNo)
    End Function
    Private Shared Sub rRejectWF(ByVal pItm As SIS.PAK.pakPOBItems, ByVal ParentItemNo As Integer)
      Dim Items As List(Of SIS.PAK.pakPOBItems) = SIS.PAK.pakPOBItems.GetByParentPOBItemNo(pItm.SerialNo, pItm.BOMNo, ParentItemNo, "")
      If Items.Count > 0 Then
        For Each Itm As SIS.PAK.pakPOBItems In Items
          With Itm
            .StatusID = pakItemStates.ChangeRequiredBySupplier
            .AcceptedBy = HttpContext.Current.Session("LoginID")
            .AcceptedOn = Now
            .Accepted = False
            .Changed = True
          End With
          Itm = pakPOBItems.UpdateData(Itm)
          rRejectWF(Itm, Itm.ItemNo)
        Next
      End If
    End Sub
    Public Shared Shadows Function RejectWF(ByVal SerialNo As Int32, ByVal BOMNo As Int32, ByVal ItemNo As Int32) As SIS.PAK.pakSPOBItems
      Dim Results As SIS.PAK.pakPOBItems = pakPOBItemsGetByID(SerialNo, BOMNo, ItemNo)
      With Results
        .StatusID = pakItemStates.ChangeRequiredBySupplier
        .AcceptedBy = HttpContext.Current.Session("LoginID")
        .AcceptedOn = Now
        .Accepted = False
        .Changed = True
      End With
      Results = pakPOBItems.UpdateData(Results)
      rRejectWF(Results, ItemNo)
      Return pakSPOBItemsGetByID(SerialNo, BOMNo, ItemNo)
    End Function
    Public Shared Shadows Function CompleteWF(ByVal SerialNo As Int32, ByVal BOMNo As Int32, ByVal ItemNo As Int32) As SIS.PAK.pakSPOBItems
      Dim Results As SIS.PAK.pakSPOBItems = pakSPOBItemsGetByID(SerialNo, BOMNo, ItemNo)
      Return Results
    End Function
    Public Shared Function UZ_pakSPOBItemsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal BOMNo As Int32, ByVal SerialNo As Int32) As List(Of SIS.PAK.pakSPOBItems)
      Dim Results As List(Of SIS.PAK.pakSPOBItems) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_SPOBItemsSelectListSearch"
            Cmd.CommandText = "sppakSPOBItemsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_SPOBItemsSelectListFilteres"
            Cmd.CommandText = "sppakSPOBItemsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BOMNo",SqlDbType.Int,10, IIf(BOMNo = Nothing, 0,BOMNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PAK.pakSPOBItems)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakSPOBItems(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakSPOBItemsUpdate(ByVal Record As SIS.PAK.pakSPOBItems) As SIS.PAK.pakSPOBItems
      Dim _Rec As SIS.PAK.pakSPOBItems = SIS.PAK.pakSPOBItems.pakSPOBItemsGetByID(Record.SerialNo, Record.BOMNo, Record.ItemNo)
      With _Rec
        .Quantity = Record.Quantity
        .WeightPerUnit = Record.WeightPerUnit
        .UOMWeight = Record.UOMWeight
        .UOMQuantity = Record.UOMQuantity
        .SupplierRemarks = Record.SupplierRemarks
        .SupplierItemCode = Record.SupplierItemCode
      End With
      Return SIS.PAK.pakSPOBItems.UpdateData(_Rec)
    End Function
  End Class
End Namespace
