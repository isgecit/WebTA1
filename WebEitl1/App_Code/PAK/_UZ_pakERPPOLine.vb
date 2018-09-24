Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakERPPOLine
    Public Property ItemDescription As String = ""

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
    Public Shared Function GetTCPOL(ByVal ERPPOLine As SIS.PAK.pakERPPOLine) As SIS.PAK.pakTCPOL
      Dim tmp As New SIS.PAK.pakTCPOL
      With tmp
        .ItemNo = ERPPOLine.t_pono
        .ItemCode = ERPPOLine.t_item
        .ItemDescription = ERPPOLine.ItemDescription
        .ItemQuantity = ERPPOLine.t_qoor
        .ItemUnit = ERPPOLine.t_cuqp
        .ItemPrice = ERPPOLine.t_pric
        .ItemAmount = ERPPOLine.t_oamt
        .ItemElement = ERPPOLine.t_cspa
      End With
      Return tmp
    End Function
    Public Shared Function GetPOBOM(ByVal ERPPOLine As SIS.PAK.pakERPPOLine, ByVal PO As SIS.PAK.pakPO) As SIS.PAK.pakPOBOM
      Dim tmp As New SIS.PAK.pakPOBOM
      With tmp
        .SerialNo = PO.SerialNo
        .BOMNo = 0
        .ItemNo = ERPPOLine.t_pono
        .ItemCode = ERPPOLine.t_item.Trim
        .ItemDescription = ERPPOLine.ItemDescription
        .SupplierItemCode = ""
        .DivisionID = PO.DivisionID
        .ElementID = ERPPOLine.t_cspa
        If ERPPOLine.t_cuqp <> "" Then
          .UOMQuantity = SIS.PAK.pakUnits.pakUnitsGetByDescription(ERPPOLine.t_cuqp).UnitID
        End If
        .Quantity = ERPPOLine.t_qoor
        .UOMWeight = ""
        .WeightPerUnit = 0
        .DocumentNo = ""
        .ParentItemNo = ""
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
        .Root = True
        .Middle = False
        .Bottom = False
        .Free = False
        .ItemLevel = 0
        .Prefix = ""
      End With
      Return tmp
    End Function
    Public Shared Function UZ_pakERPPOLineSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.PAK.pakERPPOLine)
      Dim Results As List(Of SIS.PAK.pakERPPOLine) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_ERPPOLineSelectListSearch"
            Cmd.CommandText = "sppakERPPOLineSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_ERPPOLineSelectListFilteres"
            Cmd.CommandText = "sppakERPPOLineSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakERPPOLine)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakERPPOLine(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_t_orno"), TextBox).Text = ""
          CType(.FindControl("F_t_pono"), TextBox).Text = 0
          CType(.FindControl("F_t_item"), TextBox).Text = ""
          CType(.FindControl("F_t_qoor"), TextBox).Text = 0
          CType(.FindControl("F_t_cuqp"), TextBox).Text = ""
          CType(.FindControl("F_t_pric"), TextBox).Text = 0
          CType(.FindControl("F_t_oamt"), TextBox).Text = 0
          CType(.FindControl("F_t_cprj"), TextBox).Text = ""
          CType(.FindControl("F_t_cspa"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
