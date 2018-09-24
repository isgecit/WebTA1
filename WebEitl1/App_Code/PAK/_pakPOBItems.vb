Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  <DataObject()> _
  Partial Public Class pakPOBItems
    Private Shared _RecordCount As Integer
    Private _ItemNo As Int32 = 0
    Private _ItemCode As String = ""
    Private _ItemDescription As String = ""
    Private _ElementID As String = ""
    Private _Quantity As Decimal = 0
    Private _WeightPerUnit As Decimal = 0
    Private _StatusID As String = ""
    Private _Bottom As Boolean = False
    Private _Free As Boolean = False
    Private _Middle As Boolean = False
    Private _Root As Boolean = False
    Private _ChangedBySupplier As Boolean = False
    Private _CreatedBySupplier As Boolean = False
    Private _Changed As Boolean = False
    Private _Active As Boolean = False
    Private _FreezedBySupplier As Boolean = False
    Private _AcceptedBySupplier As Boolean = False
    Private _QuantityDespatched As Decimal = 0
    Private _TotalWeightToDespatch As Decimal = 0
    Private _TotalWeightDespatched As Decimal = 0
    Private _TotalWeightReceived As Decimal = 0
    Private _QuantityReceived As Decimal = 0
    Private _Prefix As String = ""
    Private _ItemLevel As Int32 = 0
    Private _QuantityToPack As Decimal = 0
    Private _QuantityToDespatch As Decimal = 0
    Private _TotalWeightToPack As Decimal = 0
    Private _DocumentNo As String = ""
    Private _UOMWeight As String = ""
    Private _ParentItemNo As String = ""
    Private _SupplierRemarks As String = ""
    Private _ISGECRemarks As String = ""
    Private _BOMNo As Int32 = 0
    Private _SerialNo As Int32 = 0
    Private _SupplierItemCode As String = ""
    Private _UOMQuantity As String = ""
    Private _DivisionID As String = ""
    Private _AcceptedOn As String = ""
    Private _AcceptedBy As String = ""
    Private _Freezed As Boolean = False
    Private _FreezedOn As String = ""
    Private _FreezedBy As String = ""
    Private _ISGECWeightPerUnit As Decimal = 0
    Private _ISGECQuantity As Decimal = 0
    Private _SupplierQuantity As Decimal = 0
    Private _Accepted As Boolean = False
    Private _SupplierWeightPerUnit As Decimal = 0
    Private _aspnet_Users1_UserFullName As String = ""
    Private _aspnet_Users2_UserFullName As String = ""
    Private _PAK_Divisions3_Description As String = ""
    Private _PAK_Documents4_cmba As String = ""
    Private _PAK_Elements5_Description As String = ""
    Private _PAK_PO6_PODescription As String = ""
    Private _PAK_POBItems7_ItemDescription As String = ""
    Private _PAK_POBOM8_ItemDescription As String = ""
    Private _PAK_POBOMStatus9_Description As String = ""
    Private _PAK_Units10_Description As String = ""
    Private _PAK_Units11_Description As String = ""
    Private _FK_PAK_POBItems_AcceptedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_PAK_POBItems_FreezedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_PAK_POBItems_DivisionID As SIS.PAK.pakDivisions = Nothing
    Private _FK_PAK_POBItems_DocumentNo As SIS.PAK.pakDocuments = Nothing
    Private _FK_PAK_POBItems_ElementID As SIS.PAK.pakElements = Nothing
    Private _FK_PAK_POBItems_SerialNo As SIS.PAK.pakPO = Nothing
    Private _FK_PAK_POBItems_ParentItemNo As SIS.PAK.pakPOBItems = Nothing
    Private _FK_PAK_POBItems_PAK_POBOM As SIS.PAK.pakPOBOM = Nothing
    Private _FK_PAK_POBItems_StatusID As SIS.PAK.pakPOBOMStatus = Nothing
    Private _FK_PAK_POBItems_UOMQuantity As SIS.PAK.pakUnits = Nothing
    Private _FK_PAK_POBItems_UOMWeight As SIS.PAK.pakUnits = Nothing
    Public Property QualityClearedQty As Decimal = 0
    Public ReadOnly Property ForeColor() As System.Drawing.Color
      Get
        Dim mRet As System.Drawing.Color = Drawing.Color.Blue
        Try
          mRet = GetColor()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Visible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Enable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Property ItemNo() As Int32
      Get
        Return _ItemNo
      End Get
      Set(ByVal value As Int32)
        _ItemNo = value
      End Set
    End Property
    Public Property ItemCode() As String
      Get
        Return _ItemCode
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ItemCode = ""
         Else
           _ItemCode = value
         End If
      End Set
    End Property
    Public Property ItemDescription() As String
      Get
        Return _ItemDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ItemDescription = ""
         Else
           _ItemDescription = value
         End If
      End Set
    End Property
    Public Property ElementID() As String
      Get
        Return _ElementID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ElementID = ""
         Else
           _ElementID = value
         End If
      End Set
    End Property
    Public Property Quantity() As Decimal
      Get
        Return _Quantity
      End Get
      Set(ByVal value As Decimal)
        _Quantity = value
      End Set
    End Property
    Public Property WeightPerUnit() As Decimal
      Get
        Return _WeightPerUnit
      End Get
      Set(ByVal value As Decimal)
        _WeightPerUnit = value
      End Set
    End Property
    Public Property StatusID() As String
      Get
        Return _StatusID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _StatusID = ""
         Else
           _StatusID = value
         End If
      End Set
    End Property
    Public Property Bottom() As Boolean
      Get
        Return _Bottom
      End Get
      Set(ByVal value As Boolean)
        _Bottom = value
      End Set
    End Property
    Public Property Free() As Boolean
      Get
        Return _Free
      End Get
      Set(ByVal value As Boolean)
        _Free = value
      End Set
    End Property
    Public Property Middle() As Boolean
      Get
        Return _Middle
      End Get
      Set(ByVal value As Boolean)
        _Middle = value
      End Set
    End Property
    Public Property Root() As Boolean
      Get
        Return _Root
      End Get
      Set(ByVal value As Boolean)
        _Root = value
      End Set
    End Property
    Public Property ChangedBySupplier() As Boolean
      Get
        Return _ChangedBySupplier
      End Get
      Set(ByVal value As Boolean)
        _ChangedBySupplier = value
      End Set
    End Property
    Public Property CreatedBySupplier() As Boolean
      Get
        Return _CreatedBySupplier
      End Get
      Set(ByVal value As Boolean)
        _CreatedBySupplier = value
      End Set
    End Property
    Public Property Changed() As Boolean
      Get
        Return _Changed
      End Get
      Set(ByVal value As Boolean)
        _Changed = value
      End Set
    End Property
    Public Property Active() As Boolean
      Get
        Return _Active
      End Get
      Set(ByVal value As Boolean)
        _Active = value
      End Set
    End Property
    Public Property FreezedBySupplier() As Boolean
      Get
        Return _FreezedBySupplier
      End Get
      Set(ByVal value As Boolean)
        _FreezedBySupplier = value
      End Set
    End Property
    Public Property AcceptedBySupplier() As Boolean
      Get
        Return _AcceptedBySupplier
      End Get
      Set(ByVal value As Boolean)
        _AcceptedBySupplier = value
      End Set
    End Property
    Public Property QuantityDespatched() As Decimal
      Get
        Return _QuantityDespatched
      End Get
      Set(ByVal value As Decimal)
        _QuantityDespatched = value
      End Set
    End Property
    Public Property TotalWeightToDespatch() As Decimal
      Get
        Return _TotalWeightToDespatch
      End Get
      Set(ByVal value As Decimal)
        _TotalWeightToDespatch = value
      End Set
    End Property
    Public Property TotalWeightDespatched() As Decimal
      Get
        Return _TotalWeightDespatched
      End Get
      Set(ByVal value As Decimal)
        _TotalWeightDespatched = value
      End Set
    End Property
    Public Property TotalWeightReceived() As Decimal
      Get
        Return _TotalWeightReceived
      End Get
      Set(ByVal value As Decimal)
        _TotalWeightReceived = value
      End Set
    End Property
    Public Property QuantityReceived() As Decimal
      Get
        Return _QuantityReceived
      End Get
      Set(ByVal value As Decimal)
        _QuantityReceived = value
      End Set
    End Property
    Public Property Prefix() As String
      Get
        Return _Prefix
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Prefix = ""
         Else
           _Prefix = value
         End If
      End Set
    End Property
    Public Property ItemLevel() As Int32
      Get
        Return _ItemLevel
      End Get
      Set(ByVal value As Int32)
        _ItemLevel = value
      End Set
    End Property
    Public Property QuantityToPack() As Decimal
      Get
        Return _QuantityToPack
      End Get
      Set(ByVal value As Decimal)
        _QuantityToPack = value
      End Set
    End Property
    Public Property QuantityToDespatch() As Decimal
      Get
        Return _QuantityToDespatch
      End Get
      Set(ByVal value As Decimal)
        _QuantityToDespatch = value
      End Set
    End Property
    Public Property TotalWeightToPack() As Decimal
      Get
        Return _TotalWeightToPack
      End Get
      Set(ByVal value As Decimal)
        _TotalWeightToPack = value
      End Set
    End Property
    Public Property DocumentNo() As String
      Get
        Return _DocumentNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DocumentNo = ""
         Else
           _DocumentNo = value
         End If
      End Set
    End Property
    Public Property UOMWeight() As String
      Get
        Return _UOMWeight
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _UOMWeight = ""
         Else
           _UOMWeight = value
         End If
      End Set
    End Property
    Public Property ParentItemNo() As String
      Get
        Return _ParentItemNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ParentItemNo = ""
         Else
           _ParentItemNo = value
         End If
      End Set
    End Property
    Public Property SupplierRemarks() As String
      Get
        Return _SupplierRemarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SupplierRemarks = ""
         Else
           _SupplierRemarks = value
         End If
      End Set
    End Property
    Public Property ISGECRemarks() As String
      Get
        Return _ISGECRemarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ISGECRemarks = ""
         Else
           _ISGECRemarks = value
         End If
      End Set
    End Property
    Public Property BOMNo() As Int32
      Get
        Return _BOMNo
      End Get
      Set(ByVal value As Int32)
        _BOMNo = value
      End Set
    End Property
    Public Property SerialNo() As Int32
      Get
        Return _SerialNo
      End Get
      Set(ByVal value As Int32)
        _SerialNo = value
      End Set
    End Property
    Public Property SupplierItemCode() As String
      Get
        Return _SupplierItemCode
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SupplierItemCode = ""
         Else
           _SupplierItemCode = value
         End If
      End Set
    End Property
    Public Property UOMQuantity() As String
      Get
        Return _UOMQuantity
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _UOMQuantity = ""
         Else
           _UOMQuantity = value
         End If
      End Set
    End Property
    Public Property DivisionID() As String
      Get
        Return _DivisionID
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _DivisionID = ""
         Else
           _DivisionID = value
         End If
      End Set
    End Property
    Public Property AcceptedOn() As String
      Get
        If Not _AcceptedOn = String.Empty Then
          Return Convert.ToDateTime(_AcceptedOn).ToString("dd/MM/yyyy")
        End If
        Return _AcceptedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AcceptedOn = ""
         Else
           _AcceptedOn = value
         End If
      End Set
    End Property
    Public Property AcceptedBy() As String
      Get
        Return _AcceptedBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _AcceptedBy = ""
         Else
           _AcceptedBy = value
         End If
      End Set
    End Property
    Public Property Freezed() As Boolean
      Get
        Return _Freezed
      End Get
      Set(ByVal value As Boolean)
        _Freezed = value
      End Set
    End Property
    Public Property FreezedOn() As String
      Get
        If Not _FreezedOn = String.Empty Then
          Return Convert.ToDateTime(_FreezedOn).ToString("dd/MM/yyyy")
        End If
        Return _FreezedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _FreezedOn = ""
         Else
           _FreezedOn = value
         End If
      End Set
    End Property
    Public Property FreezedBy() As String
      Get
        Return _FreezedBy
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _FreezedBy = ""
         Else
           _FreezedBy = value
         End If
      End Set
    End Property
    Public Property ISGECWeightPerUnit() As Decimal
      Get
        Return _ISGECWeightPerUnit
      End Get
      Set(ByVal value As Decimal)
        _ISGECWeightPerUnit = value
      End Set
    End Property
    Public Property ISGECQuantity() As Decimal
      Get
        Return _ISGECQuantity
      End Get
      Set(ByVal value As Decimal)
        _ISGECQuantity = value
      End Set
    End Property
    Public Property SupplierQuantity() As Decimal
      Get
        Return _SupplierQuantity
      End Get
      Set(ByVal value As Decimal)
        _SupplierQuantity = value
      End Set
    End Property
    Public Property Accepted() As Boolean
      Get
        Return _Accepted
      End Get
      Set(ByVal value As Boolean)
        _Accepted = value
      End Set
    End Property
    Public Property SupplierWeightPerUnit() As Decimal
      Get
        Return _SupplierWeightPerUnit
      End Get
      Set(ByVal value As Decimal)
        _SupplierWeightPerUnit = value
      End Set
    End Property
    Public Property aspnet_Users1_UserFullName() As String
      Get
        Return _aspnet_Users1_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users1_UserFullName = value
      End Set
    End Property
    Public Property aspnet_Users2_UserFullName() As String
      Get
        Return _aspnet_Users2_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users2_UserFullName = value
      End Set
    End Property
    Public Property PAK_Divisions3_Description() As String
      Get
        Return _PAK_Divisions3_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_Divisions3_Description = ""
         Else
           _PAK_Divisions3_Description = value
         End If
      End Set
    End Property
    Public Property PAK_Documents4_cmba() As String
      Get
        Return _PAK_Documents4_cmba
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_Documents4_cmba = ""
         Else
           _PAK_Documents4_cmba = value
         End If
      End Set
    End Property
    Public Property PAK_Elements5_Description() As String
      Get
        Return _PAK_Elements5_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_Elements5_Description = ""
         Else
           _PAK_Elements5_Description = value
         End If
      End Set
    End Property
    Public Property PAK_PO6_PODescription() As String
      Get
        Return _PAK_PO6_PODescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_PO6_PODescription = ""
         Else
           _PAK_PO6_PODescription = value
         End If
      End Set
    End Property
    Public Property PAK_POBItems7_ItemDescription() As String
      Get
        Return _PAK_POBItems7_ItemDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_POBItems7_ItemDescription = ""
         Else
           _PAK_POBItems7_ItemDescription = value
         End If
      End Set
    End Property
    Public Property PAK_POBOM8_ItemDescription() As String
      Get
        Return _PAK_POBOM8_ItemDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_POBOM8_ItemDescription = ""
         Else
           _PAK_POBOM8_ItemDescription = value
         End If
      End Set
    End Property
    Public Property PAK_POBOMStatus9_Description() As String
      Get
        Return _PAK_POBOMStatus9_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_POBOMStatus9_Description = ""
         Else
           _PAK_POBOMStatus9_Description = value
         End If
      End Set
    End Property
    Public Property PAK_Units10_Description() As String
      Get
        Return _PAK_Units10_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_Units10_Description = ""
         Else
           _PAK_Units10_Description = value
         End If
      End Set
    End Property
    Public Property PAK_Units11_Description() As String
      Get
        Return _PAK_Units11_Description
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PAK_Units11_Description = ""
         Else
           _PAK_Units11_Description = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _ItemDescription.ToString.PadRight(100, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _SerialNo & "|" & _BOMNo & "|" & _ItemNo
      End Get
    End Property
    Public Shared Property RecordCount() As Integer
      Get
        Return _RecordCount
      End Get
      Set(ByVal value As Integer)
        _RecordCount = value
      End Set
    End Property
    Public Class PKpakPOBItems
      Private _SerialNo As Int32 = 0
      Private _BOMNo As Int32 = 0
      Private _ItemNo As Int32 = 0
      Public Property SerialNo() As Int32
        Get
          Return _SerialNo
        End Get
        Set(ByVal value As Int32)
          _SerialNo = value
        End Set
      End Property
      Public Property BOMNo() As Int32
        Get
          Return _BOMNo
        End Get
        Set(ByVal value As Int32)
          _BOMNo = value
        End Set
      End Property
      Public Property ItemNo() As Int32
        Get
          Return _ItemNo
        End Get
        Set(ByVal value As Int32)
          _ItemNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_PAK_POBItems_AcceptedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_PAK_POBItems_AcceptedBy Is Nothing Then
          _FK_PAK_POBItems_AcceptedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_AcceptedBy)
        End If
        Return _FK_PAK_POBItems_AcceptedBy
      End Get
    End Property
    Public ReadOnly Property FK_PAK_POBItems_FreezedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_PAK_POBItems_FreezedBy Is Nothing Then
          _FK_PAK_POBItems_FreezedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_FreezedBy)
        End If
        Return _FK_PAK_POBItems_FreezedBy
      End Get
    End Property
    Public ReadOnly Property FK_PAK_POBItems_DivisionID() As SIS.PAK.pakDivisions
      Get
        If _FK_PAK_POBItems_DivisionID Is Nothing Then
          _FK_PAK_POBItems_DivisionID = SIS.PAK.pakDivisions.pakDivisionsGetByID(_DivisionID)
        End If
        Return _FK_PAK_POBItems_DivisionID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_POBItems_DocumentNo() As SIS.PAK.pakDocuments
      Get
        If _FK_PAK_POBItems_DocumentNo Is Nothing Then
          _FK_PAK_POBItems_DocumentNo = SIS.PAK.pakDocuments.pakDocumentsGetByID(_DocumentNo)
        End If
        Return _FK_PAK_POBItems_DocumentNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_POBItems_ElementID() As SIS.PAK.pakElements
      Get
        If _FK_PAK_POBItems_ElementID Is Nothing Then
          _FK_PAK_POBItems_ElementID = SIS.PAK.pakElements.pakElementsGetByID(_ElementID)
        End If
        Return _FK_PAK_POBItems_ElementID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_POBItems_SerialNo() As SIS.PAK.pakPO
      Get
        If _FK_PAK_POBItems_SerialNo Is Nothing Then
          _FK_PAK_POBItems_SerialNo = SIS.PAK.pakPO.pakPOGetByID(_SerialNo)
        End If
        Return _FK_PAK_POBItems_SerialNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_POBItems_ParentItemNo() As SIS.PAK.pakPOBItems
      Get
        If _FK_PAK_POBItems_ParentItemNo Is Nothing Then
          _FK_PAK_POBItems_ParentItemNo = SIS.PAK.pakPOBItems.pakPOBItemsGetByID(_SerialNo, _BOMNo, _ParentItemNo)
        End If
        Return _FK_PAK_POBItems_ParentItemNo
      End Get
    End Property
    Public ReadOnly Property FK_PAK_POBItems_PAK_POBOM() As SIS.PAK.pakPOBOM
      Get
        If _FK_PAK_POBItems_PAK_POBOM Is Nothing Then
          _FK_PAK_POBItems_PAK_POBOM = SIS.PAK.pakPOBOM.pakPOBOMGetByID(_SerialNo, _BOMNo)
        End If
        Return _FK_PAK_POBItems_PAK_POBOM
      End Get
    End Property
    Public ReadOnly Property FK_PAK_POBItems_StatusID() As SIS.PAK.pakPOBOMStatus
      Get
        If _FK_PAK_POBItems_StatusID Is Nothing Then
          _FK_PAK_POBItems_StatusID = SIS.PAK.pakPOBOMStatus.pakPOBOMStatusGetByID(_StatusID)
        End If
        Return _FK_PAK_POBItems_StatusID
      End Get
    End Property
    Public ReadOnly Property FK_PAK_POBItems_UOMQuantity() As SIS.PAK.pakUnits
      Get
        If _FK_PAK_POBItems_UOMQuantity Is Nothing Then
          _FK_PAK_POBItems_UOMQuantity = SIS.PAK.pakUnits.pakUnitsGetByID(_UOMQuantity)
        End If
        Return _FK_PAK_POBItems_UOMQuantity
      End Get
    End Property
    Public ReadOnly Property FK_PAK_POBItems_UOMWeight() As SIS.PAK.pakUnits
      Get
        If _FK_PAK_POBItems_UOMWeight Is Nothing Then
          _FK_PAK_POBItems_UOMWeight = SIS.PAK.pakUnits.pakUnitsGetByID(_UOMWeight)
        End If
        Return _FK_PAK_POBItems_UOMWeight
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakPOBItemsSelectList(ByVal OrderBy As String) As List(Of SIS.PAK.pakPOBItems)
      Dim Results As List(Of SIS.PAK.pakPOBItems) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakPOBItemsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakPOBItems)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakPOBItems(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakPOBItemsGetNewRecord() As SIS.PAK.pakPOBItems
      Return New SIS.PAK.pakPOBItems()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakPOBItemsGetByID(ByVal SerialNo As Int32, ByVal BOMNo As Int32, ByVal ItemNo As Int32) As SIS.PAK.pakPOBItems
      Dim Results As SIS.PAK.pakPOBItems = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakPOBItemsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BOMNo",SqlDbType.Int,BOMNo.ToString.Length, BOMNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo",SqlDbType.Int,ItemNo.ToString.Length, ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakPOBItems(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakPOBItemsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal BOMNo As Int32, ByVal SerialNo As Int32) As List(Of SIS.PAK.pakPOBItems)
      Dim Results As List(Of SIS.PAK.pakPOBItems) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppakPOBItemsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppakPOBItemsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BOMNo",SqlDbType.Int,10, IIf(BOMNo = Nothing, 0,BOMNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakPOBItems)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakPOBItems(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakPOBItemsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal BOMNo As Int32, ByVal SerialNo As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function pakPOBItemsGetByID(ByVal SerialNo As Int32, ByVal BOMNo As Int32, ByVal ItemNo As Int32, ByVal Filter_BOMNo As Int32, ByVal Filter_SerialNo As Int32) As SIS.PAK.pakPOBItems
      Return pakPOBItemsGetByID(SerialNo, BOMNo, ItemNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function pakPOBItemsInsert(ByVal Record As SIS.PAK.pakPOBItems) As SIS.PAK.pakPOBItems
      Dim _Rec As SIS.PAK.pakPOBItems = SIS.PAK.pakPOBItems.pakPOBItemsGetNewRecord()
      With _Rec
        .ItemNo = Record.ItemNo
        .ItemCode = Record.ItemCode
        .ItemDescription = Record.ItemDescription
        .ElementID = Record.ElementID
        .Quantity = Record.Quantity
        .WeightPerUnit = Record.WeightPerUnit
        .StatusID = Record.StatusID
        .Bottom = Record.Bottom
        .Free = Record.Free
        .Middle = Record.Middle
        .Root = Record.Root
        .ChangedBySupplier = Record.ChangedBySupplier
        .CreatedBySupplier = Record.CreatedBySupplier
        .Changed = Record.Changed
        .Active = Record.Active
        .FreezedBySupplier = Record.FreezedBySupplier
        .AcceptedBySupplier = Record.AcceptedBySupplier
        .QuantityDespatched = Record.QuantityDespatched
        .TotalWeightToDespatch = Record.TotalWeightToDespatch
        .TotalWeightDespatched = Record.TotalWeightDespatched
        .TotalWeightReceived = Record.TotalWeightReceived
        .QuantityReceived = Record.QuantityReceived
        .Prefix = Record.Prefix
        .ItemLevel = Record.ItemLevel
        .QuantityToPack = Record.QuantityToPack
        .QuantityToDespatch = Record.QuantityToDespatch
        .TotalWeightToPack = Record.TotalWeightToPack
        .DocumentNo = Record.DocumentNo
        .UOMWeight = Record.UOMWeight
        .ParentItemNo = Record.ParentItemNo
        .SupplierRemarks = Record.SupplierRemarks
        .ISGECRemarks = Record.ISGECRemarks
        .BOMNo = Record.BOMNo
        .SerialNo = Record.SerialNo
        .SupplierItemCode = Record.SupplierItemCode
        .UOMQuantity = Record.UOMQuantity
        .DivisionID = Record.DivisionID
        .AcceptedOn = Record.AcceptedOn
        .AcceptedBy = Record.AcceptedBy
        .Freezed = Record.Freezed
        .FreezedOn = Record.FreezedOn
        .FreezedBy = Record.FreezedBy
        .ISGECWeightPerUnit = Record.ISGECWeightPerUnit
        .ISGECQuantity = Record.ISGECQuantity
        .SupplierQuantity = Record.SupplierQuantity
        .Accepted = Record.Accepted
        .SupplierWeightPerUnit = Record.SupplierWeightPerUnit
        .QualityClearedQty = Record.QualityClearedQty
      End With
      Return SIS.PAK.pakPOBItems.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.PAK.pakPOBItems) As SIS.PAK.pakPOBItems
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakPOBItemsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo",SqlDbType.Int,11, Record.ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCode",SqlDbType.NVarChar,51, Iif(Record.ItemCode= "" ,Convert.DBNull, Record.ItemCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemDescription",SqlDbType.NVarChar,101, Iif(Record.ItemDescription= "" ,Convert.DBNull, Record.ItemDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID",SqlDbType.NVarChar,9, Iif(Record.ElementID= "" ,Convert.DBNull, Record.ElementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quantity",SqlDbType.Decimal,21, Record.Quantity)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WeightPerUnit",SqlDbType.Decimal,21, Record.WeightPerUnit)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Bottom",SqlDbType.Bit,3, Record.Bottom)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Free",SqlDbType.Bit,3, Record.Free)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Middle",SqlDbType.Bit,3, Record.Middle)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Root",SqlDbType.Bit,3, Record.Root)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ChangedBySupplier",SqlDbType.Bit,3, Record.ChangedBySupplier)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBySupplier",SqlDbType.Bit,3, Record.CreatedBySupplier)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Changed",SqlDbType.Bit,3, Record.Changed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active",SqlDbType.Bit,3, Record.Active)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FreezedBySupplier",SqlDbType.Bit,3, Record.FreezedBySupplier)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AcceptedBySupplier",SqlDbType.Bit,3, Record.AcceptedBySupplier)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QuantityDespatched",SqlDbType.Decimal,21, Record.QuantityDespatched)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalWeightToDespatch",SqlDbType.Decimal,21, Record.TotalWeightToDespatch)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalWeightDespatched",SqlDbType.Decimal,21, Record.TotalWeightDespatched)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalWeightReceived",SqlDbType.Decimal,21, Record.TotalWeightReceived)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QuantityReceived",SqlDbType.Decimal,21, Record.QuantityReceived)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Prefix",SqlDbType.NVarChar,1001, Iif(Record.Prefix= "" ,Convert.DBNull, Record.Prefix))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemLevel",SqlDbType.Int,11, Record.ItemLevel)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QuantityToPack",SqlDbType.Decimal,21, Record.QuantityToPack)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QuantityToDespatch",SqlDbType.Decimal,21, Record.QuantityToDespatch)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalWeightToPack",SqlDbType.Decimal,21, Record.TotalWeightToPack)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentNo",SqlDbType.Int,11, Iif(Record.DocumentNo= "" ,Convert.DBNull, Record.DocumentNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMWeight",SqlDbType.Int,11, Iif(Record.UOMWeight= "" ,Convert.DBNull, Record.UOMWeight))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentItemNo",SqlDbType.Int,11, Iif(Record.ParentItemNo= "" ,Convert.DBNull, Record.ParentItemNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierRemarks",SqlDbType.NVarChar,501, Iif(Record.SupplierRemarks= "" ,Convert.DBNull, Record.SupplierRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ISGECRemarks",SqlDbType.NVarChar,501, Iif(Record.ISGECRemarks= "" ,Convert.DBNull, Record.ISGECRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BOMNo",SqlDbType.Int,11, Record.BOMNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierItemCode",SqlDbType.NVarChar,51, Iif(Record.SupplierItemCode= "" ,Convert.DBNull, Record.SupplierItemCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMQuantity",SqlDbType.Int,11, Iif(Record.UOMQuantity= "" ,Convert.DBNull, Record.UOMQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.Int,11, Iif(Record.DivisionID= "" ,Convert.DBNull, Record.DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AcceptedOn",SqlDbType.DateTime,21, Iif(Record.AcceptedOn= "" ,Convert.DBNull, Record.AcceptedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AcceptedBy",SqlDbType.NVarChar,9, Iif(Record.AcceptedBy= "" ,Convert.DBNull, Record.AcceptedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Freezed",SqlDbType.Bit,3, Record.Freezed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FreezedOn",SqlDbType.DateTime,21, Iif(Record.FreezedOn= "" ,Convert.DBNull, Record.FreezedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FreezedBy",SqlDbType.NVarChar,9, Iif(Record.FreezedBy= "" ,Convert.DBNull, Record.FreezedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ISGECWeightPerUnit",SqlDbType.Decimal,21, Record.ISGECWeightPerUnit)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ISGECQuantity",SqlDbType.Decimal,21, Record.ISGECQuantity)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierQuantity",SqlDbType.Decimal,21, Record.SupplierQuantity)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Accepted",SqlDbType.Bit,3, Record.Accepted)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierWeightPerUnit",SqlDbType.Decimal,21, Record.SupplierWeightPerUnit)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QualityClearedQty", SqlDbType.Decimal, 21, Record.QualityClearedQty)
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_BOMNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_BOMNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_ItemNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ItemNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
          Record.BOMNo = Cmd.Parameters("@Return_BOMNo").Value
          Record.ItemNo = Cmd.Parameters("@Return_ItemNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function pakPOBItemsUpdate(ByVal Record As SIS.PAK.pakPOBItems) As SIS.PAK.pakPOBItems
      Dim _Rec As SIS.PAK.pakPOBItems = SIS.PAK.pakPOBItems.pakPOBItemsGetByID(Record.SerialNo, Record.BOMNo, Record.ItemNo)
      With _Rec
        .ItemCode = Record.ItemCode
        .ItemDescription = Record.ItemDescription
        .ElementID = Record.ElementID
        .Quantity = Record.Quantity
        .WeightPerUnit = Record.WeightPerUnit
        .StatusID = Record.StatusID
        .Bottom = Record.Bottom
        .Free = Record.Free
        .Middle = Record.Middle
        .Root = Record.Root
        .ChangedBySupplier = Record.ChangedBySupplier
        .CreatedBySupplier = Record.CreatedBySupplier
        .Changed = Record.Changed
        .Active = Record.Active
        .FreezedBySupplier = Record.FreezedBySupplier
        .AcceptedBySupplier = Record.AcceptedBySupplier
        .QuantityDespatched = Record.QuantityDespatched
        .TotalWeightToDespatch = Record.TotalWeightToDespatch
        .TotalWeightDespatched = Record.TotalWeightDespatched
        .TotalWeightReceived = Record.TotalWeightReceived
        .QuantityReceived = Record.QuantityReceived
        .Prefix = Record.Prefix
        .ItemLevel = Record.ItemLevel
        .QuantityToPack = Record.QuantityToPack
        .QuantityToDespatch = Record.QuantityToDespatch
        .TotalWeightToPack = Record.TotalWeightToPack
        .DocumentNo = Record.DocumentNo
        .UOMWeight = Record.UOMWeight
        .ParentItemNo = Record.ParentItemNo
        .SupplierRemarks = Record.SupplierRemarks
        .ISGECRemarks = Record.ISGECRemarks
        .SupplierItemCode = Record.SupplierItemCode
        .UOMQuantity = Record.UOMQuantity
        .DivisionID = Record.DivisionID
        .AcceptedOn = Record.AcceptedOn
        .AcceptedBy = Record.AcceptedBy
        .Freezed = Record.Freezed
        .FreezedOn = Record.FreezedOn
        .FreezedBy = Record.FreezedBy
        .ISGECWeightPerUnit = Record.ISGECWeightPerUnit
        .ISGECQuantity = Record.ISGECQuantity
        .SupplierQuantity = Record.SupplierQuantity
        .Accepted = Record.Accepted
        .SupplierWeightPerUnit = Record.SupplierWeightPerUnit
        .QualityClearedQty = Record.QualityClearedQty
      End With
      Return SIS.PAK.pakPOBItems.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.PAK.pakPOBItems) As SIS.PAK.pakPOBItems
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakPOBItemsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ItemNo",SqlDbType.Int,11, Record.ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_BOMNo",SqlDbType.Int,11, Record.BOMNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo",SqlDbType.Int,11, Record.ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemCode",SqlDbType.NVarChar,51, Iif(Record.ItemCode= "" ,Convert.DBNull, Record.ItemCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemDescription",SqlDbType.NVarChar,101, Iif(Record.ItemDescription= "" ,Convert.DBNull, Record.ItemDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID",SqlDbType.NVarChar,9, Iif(Record.ElementID= "" ,Convert.DBNull, Record.ElementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quantity",SqlDbType.Decimal,21, Record.Quantity)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WeightPerUnit",SqlDbType.Decimal,21, Record.WeightPerUnit)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Iif(Record.StatusID= "" ,Convert.DBNull, Record.StatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Bottom",SqlDbType.Bit,3, Record.Bottom)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Free",SqlDbType.Bit,3, Record.Free)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Middle",SqlDbType.Bit,3, Record.Middle)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Root",SqlDbType.Bit,3, Record.Root)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ChangedBySupplier",SqlDbType.Bit,3, Record.ChangedBySupplier)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBySupplier",SqlDbType.Bit,3, Record.CreatedBySupplier)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Changed",SqlDbType.Bit,3, Record.Changed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active",SqlDbType.Bit,3, Record.Active)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FreezedBySupplier",SqlDbType.Bit,3, Record.FreezedBySupplier)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AcceptedBySupplier",SqlDbType.Bit,3, Record.AcceptedBySupplier)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QuantityDespatched",SqlDbType.Decimal,21, Record.QuantityDespatched)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalWeightToDespatch",SqlDbType.Decimal,21, Record.TotalWeightToDespatch)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalWeightDespatched",SqlDbType.Decimal,21, Record.TotalWeightDespatched)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalWeightReceived",SqlDbType.Decimal,21, Record.TotalWeightReceived)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QuantityReceived",SqlDbType.Decimal,21, Record.QuantityReceived)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Prefix",SqlDbType.NVarChar,1001, Iif(Record.Prefix= "" ,Convert.DBNull, Record.Prefix))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemLevel",SqlDbType.Int,11, Record.ItemLevel)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QuantityToPack",SqlDbType.Decimal,21, Record.QuantityToPack)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QuantityToDespatch",SqlDbType.Decimal,21, Record.QuantityToDespatch)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TotalWeightToPack",SqlDbType.Decimal,21, Record.TotalWeightToPack)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DocumentNo",SqlDbType.Int,11, Iif(Record.DocumentNo= "" ,Convert.DBNull, Record.DocumentNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMWeight",SqlDbType.Int,11, Iif(Record.UOMWeight= "" ,Convert.DBNull, Record.UOMWeight))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentItemNo",SqlDbType.Int,11, Iif(Record.ParentItemNo= "" ,Convert.DBNull, Record.ParentItemNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierRemarks",SqlDbType.NVarChar,501, Iif(Record.SupplierRemarks= "" ,Convert.DBNull, Record.SupplierRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ISGECRemarks",SqlDbType.NVarChar,501, Iif(Record.ISGECRemarks= "" ,Convert.DBNull, Record.ISGECRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BOMNo",SqlDbType.Int,11, Record.BOMNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierItemCode",SqlDbType.NVarChar,51, Iif(Record.SupplierItemCode= "" ,Convert.DBNull, Record.SupplierItemCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UOMQuantity",SqlDbType.Int,11, Iif(Record.UOMQuantity= "" ,Convert.DBNull, Record.UOMQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID",SqlDbType.Int,11, Iif(Record.DivisionID= "" ,Convert.DBNull, Record.DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AcceptedOn",SqlDbType.DateTime,21, Iif(Record.AcceptedOn= "" ,Convert.DBNull, Record.AcceptedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@AcceptedBy",SqlDbType.NVarChar,9, Iif(Record.AcceptedBy= "" ,Convert.DBNull, Record.AcceptedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Freezed",SqlDbType.Bit,3, Record.Freezed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FreezedOn",SqlDbType.DateTime,21, Iif(Record.FreezedOn= "" ,Convert.DBNull, Record.FreezedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FreezedBy",SqlDbType.NVarChar,9, Iif(Record.FreezedBy= "" ,Convert.DBNull, Record.FreezedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ISGECWeightPerUnit",SqlDbType.Decimal,21, Record.ISGECWeightPerUnit)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ISGECQuantity",SqlDbType.Decimal,21, Record.ISGECQuantity)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierQuantity",SqlDbType.Decimal,21, Record.SupplierQuantity)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Accepted",SqlDbType.Bit,3, Record.Accepted)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierWeightPerUnit",SqlDbType.Decimal,21, Record.SupplierWeightPerUnit)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@QualityClearedQty", SqlDbType.Decimal, 21, Record.QualityClearedQty)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    Public Shared Function pakPOBItemsDelete(ByVal Record As SIS.PAK.pakPOBItems) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakPOBItemsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,Record.SerialNo.ToString.Length, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_BOMNo",SqlDbType.Int,Record.BOMNo.ToString.Length, Record.BOMNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ItemNo",SqlDbType.Int,Record.ItemNo.ToString.Length, Record.ItemNo)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _RecordCount
    End Function
'    Autocomplete Method
    Public Shared Function SelectpakPOBItemsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakPOBItemsAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(100, " "),"" & "|" & "" & "|" & ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.PAK.pakPOBItems = New SIS.PAK.pakPOBItems(Reader)
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results.ToArray
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              Dim Found As Boolean = False
              For I As Integer = 0 To Reader.FieldCount - 1
                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                  Found = True
                  Exit For
                End If
              Next
              If Found Then
                If Convert.IsDBNull(Reader(pi.Name)) Then
                  Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                    Case "decimal"
                      CallByName(Me, pi.Name, CallType.Let, "0.00")
                    Case "bit"
                      CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                    Case Else
                      CallByName(Me, pi.Name, CallType.Let, String.Empty)
                  End Select
                Else
                  CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                End If
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
