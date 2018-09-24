Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakQCListD
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
      Select Case FK_PAK_QCListD_QCLNo.StatusID
        Case pakQCStates.Free, pakQCStates.Returned
          mRet = True
      End Select
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Return GetEditable()
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
        CType(.FindControl("F_SerialNo"), TextBox).Text = ""
        CType(.FindControl("F_SerialNo_Display"), Label).Text = ""
        CType(.FindControl("F_QCLNo"), TextBox).Text = ""
        CType(.FindControl("F_QCLNo_Display"), Label).Text = ""
        CType(.FindControl("F_BOMNo"), TextBox).Text = ""
        CType(.FindControl("F_BOMNo_Display"), Label).Text = ""
        CType(.FindControl("F_ItemNo"), TextBox).Text = ""
        CType(.FindControl("F_ItemNo_Display"), Label).Text = ""
        CType(.FindControl("F_UOMQuantity"), TextBox).Text = ""
        CType(.FindControl("F_UOMQuantity_Display"), Label).Text = ""
        CType(.FindControl("F_Quantity"), TextBox).Text = 0
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
