Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PSF
  Partial Public Class psfSupplier
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
    Public Shared Function UZ_psfSupplierInsert(ByVal Record As SIS.PSF.psfSupplier) As SIS.PSF.psfSupplier
      Dim _Result As SIS.PSF.psfSupplier = psfSupplierInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_psfSupplierUpdate(ByVal Record As SIS.PSF.psfSupplier) As SIS.PSF.psfSupplier
      Dim _Result As SIS.PSF.psfSupplier = psfSupplierUpdate(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_SupplierID"), TextBox).Text = ""
        CType(.FindControl("F_SupplierName"), TextBox).Text = ""
        CType(.FindControl("F_BankName"), TextBox).Text = ""
        CType(.FindControl("F_BranchAddress"), TextBox).Text = ""
        CType(.FindControl("F_BankAccountNo"), TextBox).Text = ""
        CType(.FindControl("F_IFSCCode"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
