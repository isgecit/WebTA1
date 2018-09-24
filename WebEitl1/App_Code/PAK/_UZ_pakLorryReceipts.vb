Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakLorryReceipts
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
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_ProjectID"), TextBox).Text = ""
        CType(.FindControl("F_ProjectID_Display"), Label).Text = ""
        CType(.FindControl("F_MRNNo"), TextBox).Text = 0
        CType(.FindControl("F_MRNDate"), TextBox).Text = ""
        CType(.FindControl("F_RequestExecutionNo"), TextBox).Text = ""
        CType(.FindControl("F_RequestExecutionNo_Display"), Label).Text = ""
        CType(.FindControl("F_CustomerID"), TextBox).Text = ""
        CType(.FindControl("F_CustomerID_Display"), Label).Text = ""
        CType(.FindControl("F_VehicleInDate"), TextBox).Text = ""
        CType(.FindControl("F_VehicleOutDate"), TextBox).Text = ""
        CType(.FindControl("F_TransporterID"), TextBox).Text = ""
        CType(.FindControl("F_TransporterID_Display"), Label).Text = ""
        CType(.FindControl("F_TransporterName"), TextBox).Text = ""
        CType(.FindControl("F_VehicleRegistrationNo"), TextBox).Text = ""
        CType(.FindControl("F_WayBillFormNo"), TextBox).Text = ""
        CType(.FindControl("F_PaymentMadeAtSite"), CheckBox).Checked = False
        CType(.FindControl("F_AmountPaid"), TextBox).Text = 0
        CType(.FindControl("F_CreatedBy"), TextBox).Text = ""
        CType(.FindControl("F_CreatedBy_Display"), Label).Text = ""
        CType(.FindControl("F_CreatedOn"), TextBox).Text = ""
        CType(.FindControl("F_OverDimensionConsignment"), TextBox).Text = ""
        CType(.FindControl("F_DetentionAtSite"), TextBox).Text = ""
        CType(.FindControl("F_ReasonForDetention"), TextBox).Text = ""
        CType(.FindControl("F_OtherRemarks"), TextBox).Text = ""
        CType(.FindControl("F_MaterialStateID"), TextBox).Text = ""
        CType(.FindControl("F_MaterialStateID_Display"), Label).Text = ""
        CType(.FindControl("F_RemarksForDamageOrShortage"), TextBox).Text = ""
        CType(.FindControl("F_DriverNameAndContactNo"), TextBox).Text = ""
        CType(.FindControl("F_TempMRNNo"), TextBox).Text = 0
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
