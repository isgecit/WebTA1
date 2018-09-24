Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakERPPOLChild
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
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function UZ_pakERPPOLChildSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.PAK.pakERPPOLChild)
      Dim Results As List(Of SIS.PAK.pakERPPOLChild) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_ERPPOLChildSelectListSearch"
            Cmd.CommandText = "sppakERPPOLChildSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_ERPPOLChildSelectListFilteres"
            Cmd.CommandText = "sppakERPPOLChildSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakERPPOLChild)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakERPPOLChild(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    'sppak_LG_DocumentsSelectByDocRevID
    Public Shared Function GetPOBItems(ByVal ERPPOLChild As SIS.PAK.pakERPPOLChild, ByVal PO As SIS.PAK.pakPO, ByVal POBOM As SIS.PAK.pakPOBOM) As SIS.PAK.pakPOBItems
      Dim tmp As New SIS.PAK.pakPOBItems
      With tmp
        .SerialNo = PO.SerialNo
        .BOMNo = POBOM.BOMNo
        .ItemNo = 0 'Put Identity
        .ItemCode = ERPPOLChild.t_item.Trim
        .ItemDescription = ERPPOLChild.t_desc
        .SupplierItemCode = ""
        .DivisionID = PO.DivisionID
        .ElementID = POBOM.ElementID
        If ERPPOLChild.t_quom <> "" Then
          .UOMQuantity = SIS.PAK.pakUnits.pakUnitsGetByDescription(ERPPOLChild.t_quom).UnitID
        End If
        .Quantity = ERPPOLChild.t_qnty
        .UOMWeight = SIS.PAK.pakUnits.pakUnitsGetByDescription("kg").UnitID
        If ERPPOLChild.t_qnty > 0 Then
          .WeightPerUnit = ERPPOLChild.t_wght / ERPPOLChild.t_qnty
        Else
          .WeightPerUnit = ERPPOLChild.t_wght
        End If
        'Create or Get DocumentNO
        Dim tmpDoc As List(Of SIS.PAK.pakDocuments) = SIS.PAK.pakDocuments.pakDocumentsSelectByDocID(ERPPOLChild.t_docn)
        If tmpDoc.Count <= 0 Then
          Dim tmpD = New SIS.PAK.pakDocuments
          With tmpD
            .DocumentID = ERPPOLChild.t_docn
            .DocumentRevision = ERPPOLChild.t_revi
            .Description = ERPPOLChild.DocumentDescription
            .ExternalDocument = False
            .DisskFile = ""
            .Filename = ""
          End With
          tmpD = SIS.PAK.pakDocuments.InsertData(tmpD)
          .DocumentNo = tmpD.DocumentNo
        Else
          For Each tmpD As SIS.PAK.pakDocuments In tmpDoc
            With tmpD
              .DocumentID = ERPPOLChild.t_docn
              .DocumentRevision = ERPPOLChild.t_revi
              .Description = ERPPOLChild.DocumentDescription
              .ExternalDocument = False
              .DisskFile = ""
              .Filename = ""
            End With
            tmpD = SIS.PAK.pakDocuments.UpdateData(tmpD)
          Next
        End If
        .ParentItemNo = POBOM.ItemNo
        .StatusID = pakItemStates.FreezedbyISGEC
        .ISGECRemarks = ""
        .SupplierRemarks = ""
        .ISGECQuantity = 0
        .ISGECWeightPerUnit = 0
        .SupplierQuantity = 0
        .SupplierWeightPerUnit = 0
        .Accepted = True
        .AcceptedBy = ""
        .AcceptedOn = ""
        .Freezed = True
        .FreezedBy = ""
        .FreezedOn = ""
        .Changed = False
        .CreatedBySupplier = False
        .ChangedBySupplier = False
        .AcceptedBySupplier = True
        .FreezedBySupplier = False
        .Active = True
        .Root = False
        .Middle = False
        .Bottom = True
        .Free = False
        .ItemLevel = 1
        .Prefix = "»"
        .QuantityToPack = 0
        .TotalWeightToPack = 0
        .QuantityToDespatch = 0
        .TotalWeightToDespatch = 0
        .QuantityDespatched = 0
        .TotalWeightDespatched = 0
        .QuantityReceived = 0
        .TotalWeightReceived = 0
      End With
      Return tmp
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_t_orno"), TextBox).Text = ""
          CType(.FindControl("F_t_vrsn"), TextBox).Text = 0
          CType(.FindControl("F_t_pono"), TextBox).Text = 0
          CType(.FindControl("F_t_item"), TextBox).Text = ""
          CType(.FindControl("F_t_desc"), TextBox).Text = ""
          CType(.FindControl("F_t_qnty"), TextBox).Text = 0
          CType(.FindControl("F_t_quom"), TextBox).Text = ""
          CType(.FindControl("F_t_wght"), TextBox).Text = 0
          CType(.FindControl("F_t_slct"), TextBox).Text = 0
          CType(.FindControl("F_t_stat"), TextBox).Text = 0
          CType(.FindControl("F_t_pric"), TextBox).Text = 0
          CType(.FindControl("F_t_amnt"), TextBox).Text = 0
          CType(.FindControl("F_t_qoor"), TextBox).Text = 0
          CType(.FindControl("F_t_acht"), TextBox).Text = 0
          CType(.FindControl("F_t_docn"), TextBox).Text = ""
          CType(.FindControl("F_t_revi"), TextBox).Text = ""
          CType(.FindControl("F_t_Refcntd"), TextBox).Text = 0
          CType(.FindControl("F_t_Refcntu"), TextBox).Text = 0
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
