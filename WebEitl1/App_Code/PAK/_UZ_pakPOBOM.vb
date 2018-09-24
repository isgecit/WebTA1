Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakPOBOM
    Public ReadOnly Property GetDownloadLink() As String
      Get
        Return "javascript:window.open('" & HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath & "/PAK_Main/App_Downloads/filedownload.aspx?bomi=" & PrimaryKey & "', 'win" & _ItemNo & "', 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1'); return false;"
      End Get
    End Property
    Public ReadOnly Property GetDownloadLinkPOItem() As String
      Get
        Return "javascript:window.open('" & HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath & "/PAK_Main/App_Downloads/filedownload.aspx?bomipo=" & PrimaryKey & "', 'win" & _ItemNo & "', 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1'); return false;"
      End Get
    End Property
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Red
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
          Select Case FK_PAK_POBOM_SerialNo.POStatusID
            Case pakPOStates.Free, pakPOStates.UnderISGECApproval
              mRet = True
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
          Select Case FK_PAK_POBOM_SerialNo.POStatusID
            Case pakPOStates.Free, pakPOStates.UnderISGECApproval
              mRet = True
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
    Public Shared Function DeleteWF(ByVal SerialNo As Int32, ByVal BOMNo As Int32) As SIS.PAK.pakPOBOM
      SIS.PAK.pakPOBItems.pakPOBItemsDeleteAll(SerialNo, BOMNo)
      Dim Results As SIS.PAK.pakPOBOM = pakPOBOMGetByID(SerialNo, BOMNo)
      SIS.PAK.pakPOBOM.pakPOBOMDelete(Results)
      Return Results
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
        Dim mRet As Boolean = False
        Try
          Select Case FK_PAK_POBOM_SerialNo.POStatusID
            Case pakPOStates.UnderISGECApproval
              If Not Freezed Then
                mRet = True
              End If
          End Select
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
    Public ReadOnly Property RejectWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case FK_PAK_POBOM_SerialNo.POStatusID
            Case pakPOStates.UnderISGECApproval
              If Freezed Then
                mRet = True
              End If
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property RejectWFEnable() As Boolean
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
    Public Shared Function InitiateWF(ByVal SerialNo As Int32, ByVal BOMNo As Int32) As SIS.PAK.pakPOBOM
      Dim Results As SIS.PAK.pakPOBOM = pakPOBOMGetByID(SerialNo, BOMNo)
      Return Results
    End Function
    Public Shared Function ApproveWF(ByVal SerialNo As Int32, ByVal BOMNo As Int32) As SIS.PAK.pakPOBOM
      Dim Results As SIS.PAK.pakPOBOM = pakPOBOMGetByID(SerialNo, BOMNo)
      Return Results
    End Function
    Public Shared Function RejectWF(ByVal SerialNo As Int32, ByVal BOMNo As Int32) As SIS.PAK.pakPOBOM
      Dim Results As SIS.PAK.pakPOBOM = pakPOBOMGetByID(SerialNo, BOMNo)
      Return Results
    End Function
    Public Shared Function CompleteWF(ByVal SerialNo As Int32, ByVal BOMNo As Int32) As SIS.PAK.pakPOBOM
      Dim Results As SIS.PAK.pakPOBOM = pakPOBOMGetByID(SerialNo, BOMNo)
      Return Results
    End Function
    Public Shared Function UZ_pakPOBOMSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32) As List(Of SIS.PAK.pakPOBOM)
      Dim Results As List(Of SIS.PAK.pakPOBOM) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_POBOMSelectListSearch"
            Cmd.CommandText = "sppakPOBOMSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_POBOMSelectListFilteres"
            Cmd.CommandText = "sppakPOBOMSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakPOBOM)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakPOBOM(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakPOBOMInsert(ByVal Record As SIS.PAK.pakPOBOM) As SIS.PAK.pakPOBOM
      Dim _Result As SIS.PAK.pakPOBOM = pakPOBOMInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakPOBOMUpdate(ByVal Record As SIS.PAK.pakPOBOM) As SIS.PAK.pakPOBOM
      Dim _Rec As SIS.PAK.pakPOBOM = SIS.PAK.pakPOBOM.pakPOBOMGetByID(Record.SerialNo, Record.BOMNo)
      With _Rec
        .ISGECRemarks = Record.ISGECRemarks
      End With
      Return SIS.PAK.pakPOBOM.UpdateData(_Rec)
    End Function
    Public Shared Function UZ_pakPOBOMDelete(ByVal Record As SIS.PAK.pakPOBOM) As Integer
      Dim _Result as Integer = pakPOBOMDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_BOMNo"), TextBox).Text = ""
          CType(.FindControl("F_ItemNo"), TextBox).Text = 0
          CType(.FindControl("F_ItemDescription"), TextBox).Text = ""
          CType(.FindControl("F_ElementID"), TextBox).Text = ""
          CType(.FindControl("F_ElementID_Display"), Label).Text = ""
          CType(.FindControl("F_StatusID"), TextBox).Text = ""
          CType(.FindControl("F_StatusID_Display"), Label).Text = ""
          CType(.FindControl("F_ISGECRemarks"), TextBox).Text = ""
          CType(.FindControl("F_SupplierRemarks"), TextBox).Text = ""
          CType(.FindControl("F_AcceptedBySupplier"), CheckBox).Checked = False
          CType(.FindControl("F_FreezedBySupplier"), CheckBox).Checked = False
          CType(.FindControl("F_Active"), CheckBox).Checked = False
          CType(.FindControl("F_Changed"), CheckBox).Checked = False
          CType(.FindControl("F_CreatedBySupplier"), CheckBox).Checked = False
          CType(.FindControl("F_ChangedBySupplier"), CheckBox).Checked = False
          CType(.FindControl("F_Root"), CheckBox).Checked = False
          CType(.FindControl("F_ItemLevel"), TextBox).Text = 0
          CType(.FindControl("F_Prefix"), TextBox).Text = ""
          CType(.FindControl("F_SerialNo"), TextBox).Text = ""
          CType(.FindControl("F_SerialNo_Display"), Label).Text = ""
          CType(.FindControl("F_Middle"), CheckBox).Checked = False
          CType(.FindControl("F_Bottom"), CheckBox).Checked = False
          CType(.FindControl("F_Free"), CheckBox).Checked = False
          CType(.FindControl("F_FreezedOn"), TextBox).Text = ""
          CType(.FindControl("F_WeightPerUnit"), TextBox).Text = "0.0000"
          CType(.FindControl("F_UOMWeight"), Object).SelectedValue = ""
          CType(.FindControl("F_ParentItemNo"), TextBox).Text = 0
          CType(.FindControl("F_DocumentNo"), TextBox).Text = ""
          CType(.FindControl("F_DocumentNo_Display"), Label).Text = ""
          CType(.FindControl("F_Quantity"), TextBox).Text = "0.0000"
          CType(.FindControl("F_SupplierItemCode"), TextBox).Text = ""
          CType(.FindControl("F_ItemCode"), TextBox).Text = ""
          CType(.FindControl("F_UOMQuantity"), Object).SelectedValue = ""
          CType(.FindControl("F_DivisionID"), Object).SelectedValue = ""
          CType(.FindControl("F_AcceptedOn"), TextBox).Text = ""
          CType(.FindControl("F_AcceptedBy"), TextBox).Text = ""
          CType(.FindControl("F_AcceptedBy_Display"), Label).Text = ""
          CType(.FindControl("F_FreezedBy"), TextBox).Text = ""
          CType(.FindControl("F_FreezedBy_Display"), Label).Text = ""
          CType(.FindControl("F_Freezed"), CheckBox).Checked = False
          CType(.FindControl("F_Accepted"), CheckBox).Checked = False
          CType(.FindControl("F_ISGECWeightPerUnit"), TextBox).Text = "0.0000"
          CType(.FindControl("F_ISGECQuantity"), TextBox).Text = "0.0000"
          CType(.FindControl("F_SupplierWeightPerUnit"), TextBox).Text = "0.0000"
          CType(.FindControl("F_SupplierQuantity"), TextBox).Text = "0.0000"
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function GetPOBItem(ByVal POBom As SIS.PAK.pakPOBOM) As SIS.PAK.pakPOBItems
      Dim tmpPOBItem As New SIS.PAK.pakPOBItems
      With tmpPOBItem
        .SerialNo = POBom.SerialNo
        .BOMNo = POBom.BOMNo
        .ItemNo = POBom.ItemNo
        .ItemCode = POBom.ItemCode
        .ItemDescription = POBom.ItemDescription
        .SupplierItemCode = POBom.SupplierItemCode
        .DivisionID = POBom.DivisionID
        .ElementID = POBom.ElementID
        .UOMQuantity = POBom.UOMQuantity
        .Quantity = POBom.Quantity
        .UOMWeight = POBom.UOMWeight
        .WeightPerUnit = POBom.WeightPerUnit
        .DocumentNo = POBom.DocumentNo
        .ParentItemNo = POBom.ParentItemNo
        .StatusID = POBom.StatusID
        .ISGECRemarks = POBom.ISGECRemarks
        .SupplierRemarks = POBom.SupplierRemarks
        .ISGECQuantity = POBom.ISGECQuantity
        .ISGECWeightPerUnit = POBom.ISGECWeightPerUnit
        .SupplierQuantity = POBom.SupplierQuantity
        .SupplierWeightPerUnit = POBom.SupplierWeightPerUnit
        .QualityClearedQty = POBom.QualityClearedQty
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
        .Root = True
        .Middle = False
        .Bottom = False
        .Free = False
        .ItemLevel = 0
        .Prefix = ""
      End With
      Return tmpPOBItem
    End Function
    Public Shared Function pakPOBOMGetByERPPOLine(ByVal SerialNo As Int32, ByVal ItemNo As Int32) As SIS.PAK.pakPOBOM
      Dim Results As SIS.PAK.pakPOBOM = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppak_LG_POBOMSelectByERPPOLine"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo", SqlDbType.Int, SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemNo", SqlDbType.Int, ItemNo.ToString.Length, ItemNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakPOBOM(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
  End Class
End Namespace
