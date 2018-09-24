Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections.Generic
Partial Public Class LC_YearDate
  Inherits System.Web.UI.UserControl
  Public Event YearDateChanged(ByVal s As Object, ByVal e As EventArgs)
  Private Sub F_FinYears_SelectedIndexChanged(sender As Object, e As EventArgs) Handles F_FinYears.SelectedIndexChanged
    Dim oFr As SIS.NPRK.nprkFinYears = SIS.NPRK.nprkFinYears.nprkFinYearsGetByID(F_FinYears.SelectedValue)
    Try
      If Convert.ToDateTime(F_Today.Text) < Convert.ToDateTime(oFr.StartDate) Or Convert.ToDateTime(F_Today.Text) > Convert.ToDateTime(oFr.EndDate) Then
        F_Today.Text = oFr.EndDate
        HttpContext.Current.Session("Today") = oFr.EndDate
        HttpContext.Current.Session("FinYear") = F_FinYears.SelectedValue
        RaiseEvent YearDateChanged(Me, Nothing)
      Else
        HttpContext.Current.Session("FinYear") = F_FinYears.SelectedValue
        RaiseEvent YearDateChanged(Me, Nothing)
      End If
    Catch ex As Exception
      F_FinYears.SelectedValue = HttpContext.Current.Session("FinYear")
      F_Today.Text = HttpContext.Current.Session("Today")
    End Try
  End Sub

  Private Sub F_Today_TextChanged(sender As Object, e As EventArgs) Handles F_Today.TextChanged
    Dim oFr As SIS.NPRK.nprkFinYears = SIS.NPRK.nprkFinYears.nprkFinYearsGetByID(HttpContext.Current.Session("FinYear"))
    Try
      If Convert.ToDateTime(F_Today.Text) < Convert.ToDateTime(oFr.StartDate) Or Convert.ToDateTime(F_Today.Text) > Convert.ToDateTime(oFr.EndDate) Then
        F_Today.Text = oFr.StartDate
        HttpContext.Current.Session("Today") = oFr.StartDate
      Else
        HttpContext.Current.Session("Today") = F_Today.Text
      End If
    Catch ex As Exception
      F_FinYears.SelectedValue = HttpContext.Current.Session("FinYear")
      F_Today.Text = HttpContext.Current.Session("Today")
    End Try
  End Sub
  Private Sub LC_YearDate_Load(sender As Object, e As EventArgs) Handles Me.Load
    If Not Page.IsCallback And Not Page.IsPostBack Then
      F_FinYears.SelectedValue = HttpContext.Current.Session("FinYear")
      F_Today.Text = HttpContext.Current.Session("Today")
    End If
  End Sub
End Class
