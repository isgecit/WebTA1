Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ELOG
  Partial Public Class elogIRBL
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      If StatusID = "2" Then
        mRet = Drawing.Color.DarkGreen
      End If
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
      If StatusID = "1" Then
        mRet = True
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
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          If StatusID = "1" Then
            mRet = True
          End If
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
    Public Shared Function ApproveWF(ByVal IRNo As Int32) As SIS.ELOG.elogIRBL
      Dim Results As SIS.ELOG.elogIRBL = elogIRBLGetByID(IRNo)
      Results.StatusID = "2"
      SIS.ELOG.elogIRBL.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function UZ_elogIRBLInsert(ByVal Record As SIS.ELOG.elogIRBL) As SIS.ELOG.elogIRBL
      Record.StatusID = 1
      Dim _Result As SIS.ELOG.elogIRBL = elogIRBLInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_elogIRBLUpdate(ByVal Record As SIS.ELOG.elogIRBL) As SIS.ELOG.elogIRBL
      Dim _Result As SIS.ELOG.elogIRBL = elogIRBLUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_elogIRBLDelete(ByVal Record As SIS.ELOG.elogIRBL) As Integer
      Dim _Result as Integer = elogIRBLDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_IRNo"), TextBox).Text = 0
        CType(.FindControl("F_SupplierID"), TextBox).Text = ""
        CType(.FindControl("F_SupplierID_Display"), Label).Text = ""
        CType(.FindControl("F_ProjectID"), TextBox).Text = ""
        CType(.FindControl("F_ProjectID_Display"), Label).Text = ""
        CType(.FindControl("F_PONo"), TextBox).Text = ""
        CType(.FindControl("F_SupplierBillNo"), TextBox).Text = ""
        CType(.FindControl("F_supplierBillDate"), TextBox).Text = ""
        CType(.FindControl("F_SupplierBillAmount"), TextBox).Text = 0
        CType(.FindControl("F_IRDate"), TextBox).Text = ""
        CType(.FindControl("F_BLID"), TextBox).Text = ""
        CType(.FindControl("F_BLID_Display"), Label).Text = ""
        CType(.FindControl("F_BLType"),Object).SelectedValue = ""
        CType(.FindControl("F_MBLNo"), TextBox).Text = ""
        CType(.FindControl("F_Remarks"), TextBox).Text = ""
        CType(.FindControl("F_ShipmentModeID"),Object).SelectedValue = ""
        CType(.FindControl("F_CarrierID"),Object).SelectedValue = ""
        CType(.FindControl("F_OtherCarrier"), TextBox).Text = ""
        CType(.FindControl("F_LocationCountryID"),Object).SelectedValue = ""
        CType(.FindControl("F_OtherCountry"), TextBox).Text = ""
        CType(.FindControl("F_CargoTypeID"),Object).SelectedValue = ""
        CType(.FindControl("F_PortID"),Object).SelectedValue = ""
        CType(.FindControl("F_OtherPortLoadingOrigin"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
