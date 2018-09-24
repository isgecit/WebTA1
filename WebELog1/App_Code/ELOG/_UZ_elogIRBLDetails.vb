Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ELOG
  Partial Public Class elogIRBLDetails
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
      Dim mRet As Boolean = FK_ELOG_IRBLDetails_IRNo.GetEditable
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
    Public Shared Function UZ_elogIRBLDetailsInsert(ByVal Record As SIS.ELOG.elogIRBLDetails) As SIS.ELOG.elogIRBLDetails
      Dim _Result As SIS.ELOG.elogIRBLDetails = elogIRBLDetailsInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_elogIRBLDetailsUpdate(ByVal Record As SIS.ELOG.elogIRBLDetails) As SIS.ELOG.elogIRBLDetails
      Dim _Result As SIS.ELOG.elogIRBLDetails = elogIRBLDetailsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_elogIRBLDetailsDelete(ByVal Record As SIS.ELOG.elogIRBLDetails) As Integer
      Dim _Result as Integer = elogIRBLDetailsDelete(Record)
      Return _Result
    End Function
    Public Shared Function getUsedAmount(ByVal IRNo As Int32) As Decimal
      Dim Results As Decimal = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select ISNull(sum(isnull(Amount,0)),0) as amt from ELOG_IRBLDetails where IRNo = " & IRNo
          Con.Open()
          Results = Cmd.ExecuteScalar
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function getUsedChargeCode(ByVal BLID As String, ByVal ChargeCode As Integer) As Integer
      Dim Results As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select ISNull(ChargeCodeID,0) as amt from ELOG_IRBLDetails where ChargeCodeID=" & ChargeCode & " AND IRNo IN (Select IRNo FROM ELOG_IRBL WHERE BLID ='" & BLID & "')"
          Con.Open()
          Results = Cmd.ExecuteScalar
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_IRNo"), TextBox).Text = ""
          CType(.FindControl("F_IRNo_Display"), Label).Text = ""
          CType(.FindControl("F_SerialNo"), TextBox).Text = ""
          CType(.FindControl("F_StuffingTypeID"), Object).SelectedValue = ""
          CType(.FindControl("F_StuffingPointID"), Object).SelectedValue = ""
          CType(.FindControl("F_ICDCFSID"), Object).SelectedValue = ""
          CType(.FindControl("F_OtherICDCFS"), TextBox).Text = ""
          CType(.FindControl("F_BreakBulkID"), Object).SelectedValue = ""
          CType(.FindControl("F_ChargeTypeID"), Object).SelectedValue = ""
          CType(.FindControl("F_ChargeCategoryID"), Object).SelectedValue = ""
          CType(.FindControl("F_ChargeCodeID"), Object).SelectedValue = ""
          CType(.FindControl("F_Amount"), TextBox).Text = 0
          CType(.FindControl("F_Remarks"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
