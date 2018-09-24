Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakPkgListD
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
      Dim mRet As Boolean = False
      If Me.FK_PAK_PkgListD_PkgNo.FK_PAK_PkgListH_SerialNo.POStatusID = pakPOStates.UnderDespatch Then
        If Me.FK_PAK_PkgListD_PkgNo.StatusID = pakPkgStates.Free Then
          mRet = True
        End If
      End If
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      If Me.FK_PAK_PkgListD_PkgNo.FK_PAK_PkgListH_SerialNo.POStatusID = pakPOStates.UnderDespatch Then
        If Me.FK_PAK_PkgListD_PkgNo.StatusID = pakPkgStates.Free Then
          mRet = True
        End If
      End If
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
    Public Shared Function UZ_pakPkgListDSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PkgNo As Int32, ByVal SerialNo As Int32) As List(Of SIS.PAK.pakPkgListD)
      Dim Results As List(Of SIS.PAK.pakPkgListD) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_PkgListDSelectListSearch"
            Cmd.CommandText = "sppakPkgListDSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_PkgListDSelectListFilteres"
            Cmd.CommandText = "sppakPkgListDSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PkgNo",SqlDbType.Int,10, IIf(PkgNo = Nothing, 0,PkgNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo",SqlDbType.Int,10, IIf(SerialNo = Nothing, 0,SerialNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakPkgListD)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakPkgListD(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakPkgListDInsert(ByVal Record As SIS.PAK.pakPkgListD) As SIS.PAK.pakPkgListD
      Dim _Result As SIS.PAK.pakPkgListD = pakPkgListDInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakPkgListDUpdate(ByVal Record As SIS.PAK.pakPkgListD) As SIS.PAK.pakPkgListD
      Dim _Result As SIS.PAK.pakPkgListD = pakPkgListDUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakPkgListDDelete(ByVal Record As SIS.PAK.pakPkgListD) As Integer
      Dim _Result as Integer = pakPkgListDDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_ItemNo"), TextBox).Text = ""
        CType(.FindControl("F_ItemNo_Display"), Label).Text = ""
        CType(.FindControl("F_UOMQuantity"),Object).SelectedValue = ""
        CType(.FindControl("F_Quantity"), TextBox).Text = 0
        CType(.FindControl("F_UOMWeight"),Object).SelectedValue = ""
        CType(.FindControl("F_WeightPerUnit"), TextBox).Text = 0
        CType(.FindControl("F_UOMPack"),Object).SelectedValue = ""
        CType(.FindControl("F_PackHeight"), TextBox).Text = 0
        CType(.FindControl("F_Remarks"), TextBox).Text = ""
        CType(.FindControl("F_BOMNo"), TextBox).Text = ""
        CType(.FindControl("F_BOMNo_Display"), Label).Text = ""
        CType(.FindControl("F_PkgNo"), TextBox).Text = ""
        CType(.FindControl("F_PkgNo_Display"), Label).Text = ""
        CType(.FindControl("F_SerialNo"), TextBox).Text = ""
        CType(.FindControl("F_SerialNo_Display"), Label).Text = ""
        CType(.FindControl("F_PackTypeID"),Object).SelectedValue = ""
        CType(.FindControl("F_PackWidth"), TextBox).Text = 0
        CType(.FindControl("F_PackLength"), TextBox).Text = 0
        CType(.FindControl("F_PackingMark"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function GetERPPkgD(ByVal PkgListD As SIS.PAK.pakPkgListD) As SIS.PAK.pakERPPkgD
      Dim tmp As New SIS.PAK.pakERPPkgD
      With tmp
        .t_orno = PkgListD.FK_PAK_PkgListD_SerialNo.PONumber
        .t_pkno = 1 'Package No for Header
        .t_rcln = 1 '1,2,3 . . . Running Number for a Package
        .t_citm = PkgListD.FK_PAK_PkgListD_ItemNo.ItemCode
        .t_pkgn = PkgListD.PkgNo 'Joomla Key 2
        .t_bomn = PkgListD.BOMNo 'Joomla Key 3
        If PkgListD.UOMQuantity <> "" Then
          .t_cuni = PkgListD.FK_PAK_PkgListD_UOMQuantity.Description
        End If
        .t_itmn = PkgListD.ItemNo 'Joomla Key 4
        .t_qnty = PkgListD.Quantity
        .t_uwgt = PkgListD.WeightPerUnit         'FK_PAK_PkgListD_UOMWeight.Description
        .t_twgt = PkgListD.WeightPerUnit * PkgListD.Quantity
        .t_docn = PkgListD.DocumentNo
        .t_revn = PkgListD.DocumentRevision
        .t_ptyp = PkgListD.PAK_PakTypes1_Description
        .t_pmrk = PkgListD.PackingMark
        .t_leng = PkgListD.PackLength
        .t_widt = PkgListD.PackWidth
        .t_hght = PkgListD.PackHeight
        If PkgListD.UOMPack <> "" Then
          .t_unit = PkgListD.FK_PAK_PkgListD_UOMPack.Description
        End If
        .t_rcno = ""
        .t_srno = PkgListD.SerialNo 'Joomla Key 1
        .t_Refcntd = 0
        .t_Refcntu = 0
      End With
      Return tmp
    End Function
  End Class
End Namespace
