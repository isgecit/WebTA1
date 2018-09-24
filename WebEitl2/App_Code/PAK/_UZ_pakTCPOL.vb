Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakTCPOL
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      Select Case ItemStatusID
        Case pakTCPOLineStates.TCCreated
          mRet = Drawing.Color.DarkGoldenrod
        Case pakTCPOLineStates.TCSubmitted
          mRet = Drawing.Color.Crimson
        Case pakTCPOLineStates.TCCommented
          mRet = Drawing.Color.Red
        Case pakTCPOLineStates.TCCleared
          mRet = Drawing.Color.Green
      End Select
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
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
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
    Public Shared Function UZ_pakTCPOLInsert(ByVal Record As SIS.PAK.pakTCPOL) As SIS.PAK.pakTCPOL
      Dim _Result As SIS.PAK.pakTCPOL = pakTCPOLInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakTCPOLUpdate(ByVal Record As SIS.PAK.pakTCPOL) As SIS.PAK.pakTCPOL
      Dim _Result As SIS.PAK.pakTCPOL = pakTCPOLUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakTCPOLDelete(ByVal Record As SIS.PAK.pakTCPOL) As Integer
      Dim _Result as Integer = pakTCPOLDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_ItemNo"), TextBox).Text = 0
        CType(.FindControl("F_ItemCode"), TextBox).Text = ""
        CType(.FindControl("F_ItemDescription"), TextBox).Text = ""
        CType(.FindControl("F_ItemQuantity"), TextBox).Text = 0
        CType(.FindControl("F_ItemElement"), TextBox).Text = ""
        CType(.FindControl("F_ItemElement_Display"), Label).Text = ""
        CType(.FindControl("F_ItemStatusID"), TextBox).Text = ""
        CType(.FindControl("F_ItemStatusID_Display"), Label).Text = ""
        CType(.FindControl("F_SerialNo"), TextBox).Text = ""
        CType(.FindControl("F_SerialNo_Display"), Label).Text = ""
        CType(.FindControl("F_ItemAmount"), TextBox).Text = 0
        CType(.FindControl("F_ItemUnit"), TextBox).Text = ""
        CType(.FindControl("F_ItemPrice"), TextBox).Text = 0
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
