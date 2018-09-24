Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ELOG
  Partial Public Class elogBLHeader
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
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function LG_elogBLHeaderGetByID(ByVal BLID As String) As SIS.ELOG.elogBLHeader
      Dim Results As SIS.ELOG.elogBLHeader = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spelog_LG_BLHeaderSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BLID", SqlDbType.NVarChar, BLID.ToString.Length, BLID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.ELOG.elogBLHeader(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_BLID"), TextBox).Text = ""
          CType(.FindControl("F_BLNumber"), TextBox).Text = ""
          CType(.FindControl("F_BLDate"), TextBox).Text = ""
          CType(.FindControl("F_PortOfLoading"), TextBox).Text = ""
          CType(.FindControl("F_VesselOrFlightNo"), TextBox).Text = ""
          CType(.FindControl("F_VoyageNo"), TextBox).Text = ""
          CType(.FindControl("F_TransShipmentPortID"), Object).SelectedValue = ""
          CType(.FindControl("F_PrepaidFlight"), CheckBox).Checked = False
          CType(.FindControl("F_ShippingLine"), TextBox).Text = ""
          CType(.FindControl("F_SOBDate"), TextBox).Text = ""
          CType(.FindControl("F_MBLNo"), TextBox).Text = ""
          CType(.FindControl("F_PreCarriageBy"), TextBox).Text = ""
          CType(.FindControl("F_PlaceOfReceiptBy"), TextBox).Text = ""
          CType(.FindControl("F_Air1Freight"), TextBox).Text = ""
          CType(.FindControl("F_Air2Freight"), TextBox).Text = ""
          CType(.FindControl("F_Air3Freight"), TextBox).Text = ""
          CType(.FindControl("F_Air4Freight"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
