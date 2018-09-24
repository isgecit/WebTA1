Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TA
  Partial Public Class taCountries
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
    Public Shared Function UZ_taCountriesInsert(ByVal Record As SIS.TA.taCountries) As SIS.TA.taCountries
      Dim _Result As SIS.TA.taCountries = taCountriesInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_taCountriesUpdate(ByVal Record As SIS.TA.taCountries) As SIS.TA.taCountries
      Dim _Result As SIS.TA.taCountries = taCountriesUpdate(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        'CType(.FindControl("F_CountryID"), TextBox).Text = ""
        'CType(.FindControl("F_CountryName"), TextBox).Text = ""
        'CType(.FindControl("F_RegionID"), TextBox).Text = ""
        'CType(.FindControl("F_RegionID_Display"), Label).Text = ""
        'CType(.FindControl("F_CurrencyID"), TextBox).Text = ""
        'CType(.FindControl("F_CurrencyID_Display"), Label).Text = ""
        'CType(.FindControl("F_RegionTypeID"), TextBox).Text = ""
        'CType(.FindControl("F_RegionTypeID_Display"), Label).Text = ""
        'CType(.FindControl("F_ContingencyAmount"), TextBox).Text = ""
      End With
      Return sender
    End Function
  End Class
End Namespace
