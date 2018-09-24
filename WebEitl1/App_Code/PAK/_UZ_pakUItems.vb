Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakUItems
    Public Shadows Property Editable As Boolean = False

    Public ReadOnly Property CompleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
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
    Public Shared Function CompleteWF(ByVal ItemNo As Int32, ByVal PrimaryKey As String) As SIS.PAK.pakUItems
      Dim oVar() As String = PrimaryKey.Split("|".ToCharArray)
      Dim SerialNo As String = oVar(0)
      Dim Results As SIS.PAK.pakUItems = pakUItemsGetByID(ItemNo)
      Dim tmp As SIS.PAK.pakPOBOM = New SIS.PAK.pakPOBOM
      With tmp
        .SerialNo = SerialNo
        .ItemNo = Results.ItemNo
        .ItemCode = Results.ItemCode
        .SupplierItemCode = Results.ItemCode
        .ItemDescription = Results.ItemDescription
        .DivisionID = Results.DivisionID
        .ElementID = Results.ElementID
        .UOMQuantity = Results.UOMQuantity
        .Quantity = Results.Quantity
        .UOMWeight = Results.UOMWeight
        .WeightPerUnit = Results.WeightPerUnit
        .DocumentNo = Results.DocumentNo
        .ParentItemNo = Results.ParentItemNo
        .StatusID = 1 'free
        .Active = True
        .Root = Results.Root
        .Middle = Results.Middle
        .Bottom = Results.Bottom
        .Free = Results.Free
        .ItemLevel = Results.ItemLevel
        .Prefix = Results.Prefix
      End With
      tmp = SIS.PAK.pakPOBOM.InsertData(tmp)

      Dim oResults As List(Of SIS.PAK.pakItems) = SIS.PAK.pakItems.GetByRootItem(ItemNo, "")
      For Each res As SIS.PAK.pakItems In oResults
        Dim ttmp As SIS.PAK.pakPOBItems = New SIS.PAK.pakPOBItems
        With ttmp
          .SerialNo = SerialNo
          .BOMNo = tmp.BOMNo
          .ItemNo = res.ItemNo
          .ItemCode = res.ItemCode
          .SupplierItemCode = res.ItemCode
          .ItemDescription = res.ItemDescription
          .DivisionID = res.DivisionID
          .ElementID = res.ElementID
          .UOMQuantity = res.UOMQuantity
          .Quantity = res.Quantity
          .UOMWeight = res.UOMWeight
          .WeightPerUnit = res.WeightPerUnit
          .DocumentNo = res.DocumentNo
          .ParentItemNo = res.ParentItemNo
          .StatusID = 1 'free
          .Active = True
          .Root = res.Root
          .Middle = res.Middle
          .Bottom = res.Bottom
          .Free = res.Free
          .ItemLevel = res.ItemLevel
          .Prefix = res.Prefix
        End With
        SIS.PAK.pakPOBItems.InsertData(ttmp)
      Next
      Return Results
    End Function
    Public Shared Function UZ_pakUItemsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As String) As List(Of SIS.PAK.pakUItems)
      Dim Results As List(Of SIS.PAK.pakUItems) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_UItemsSelectListSearch"
            Cmd.CommandText = "sppakUItemsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_UItemsSelectListFilteres"
            'Cmd.CommandText = "sppakUItemsSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Root", SqlDbType.Bit, 2, True)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID", SqlDbType.Int, 10, Global.System.Web.HttpContext.Current.Session("DivisionID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo", SqlDbType.NVarChar, 10, SerialNo)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.PAK.pakUItems)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakUItems(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function pakUItemsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As String) As Integer
      Return RecordCount
    End Function
  End Class
End Namespace
