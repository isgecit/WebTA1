Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  Partial Public Class taRegions
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
    Public Shared Function UZ_taRegionsInsert(ByVal Record As SIS.TA.taRegions) As SIS.TA.taRegions
      Dim _Result As SIS.TA.taRegions = taRegionsInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_taRegionsUpdate(ByVal Record As SIS.TA.taRegions) As SIS.TA.taRegions
      Dim _Result As SIS.TA.taRegions = taRegionsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        'CType(.FindControl("F_RegionID"), TextBox).Text = ""
        'CType(.FindControl("F_RegionName"), TextBox).Text = ""
        'CType(.FindControl("F_RegionTypeID"), TextBox).Text = ""
        'CType(.FindControl("F_RegionTypeID_Display"), Label).Text = ""
        'CType(.FindControl("F_CurrencyID"), TextBox).Text = ""
        'CType(.FindControl("F_CurrencyID_Display"), Label).Text = ""
      End With
      Return sender
    End Function
  End Class
End Namespace
