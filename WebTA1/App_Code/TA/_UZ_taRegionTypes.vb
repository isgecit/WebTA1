Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  Partial Public Class taRegionTypes
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
    Public Shared Function UZ_taRegionTypesInsert(ByVal Record As SIS.TA.taRegionTypes) As SIS.TA.taRegionTypes
      Dim _Result As SIS.TA.taRegionTypes = taRegionTypesInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_taRegionTypesUpdate(ByVal Record As SIS.TA.taRegionTypes) As SIS.TA.taRegionTypes
      Dim _Result As SIS.TA.taRegionTypes = taRegionTypesUpdate(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        'CType(.FindControl("F_RegionTypeID"), TextBox).Text = ""
        'CType(.FindControl("F_RegionTypeName"), TextBox).Text = ""
      End With
      Return sender
    End Function
  End Class
End Namespace
