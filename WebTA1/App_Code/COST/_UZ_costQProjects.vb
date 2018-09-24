Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.COST
  Partial Public Class costQProjects
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
    Public Shared Function UZ_costQProjectsInsert(ByVal Record As SIS.COST.costQProjects) As SIS.COST.costQProjects
      With Record
        .ProjectOrderValueINR = .ProjectOrderValue * .CFforPOV
        .ProjectCostINR = .ProjectCost * .CFforPOV
        .MarginCurrentYearINR = .MarginCurrentYear * .CFforPOV
      End With
      Dim _Result As SIS.COST.costQProjects = costQProjectsInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_costQProjectsUpdate(ByVal Record As SIS.COST.costQProjects) As SIS.COST.costQProjects
      With Record
        .ProjectOrderValueINR = .ProjectOrderValue * .CFforPOV
        .ProjectCostINR = .ProjectCost * .CFforPOV
        .MarginCurrentYearINR = .MarginCurrentYear * .CFforPOV
      End With
      Dim _Result As SIS.COST.costQProjects = costQProjectsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_costQProjectsDelete(ByVal Record As SIS.COST.costQProjects) As Integer
      Dim _Result as Integer = costQProjectsDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_ProjectID"), TextBox).Text = ""
          CType(.FindControl("F_ProjectID_Display"), Label).Text = ""
          CType(.FindControl("F_FinYear"), Object).SelectedValue = ""
          CType(.FindControl("F_Quarter"), Object).SelectedValue = ""
          CType(.FindControl("F_Description"), TextBox).Text = ""
          CType(.FindControl("F_ProjectTypeID"), Object).SelectedValue = ""
          CType(.FindControl("F_WorkOrderTypeID"), Object).SelectedValue = ""
          CType(.FindControl("F_DivisionID"), Object).SelectedValue = ""
          CType(.FindControl("F_CurrencyID"), Object).SelectedValue = "INR"
          CType(.FindControl("F_CFforPOV"), TextBox).Text = "1.000000"
          CType(.FindControl("F_ProjectOrderValue"), TextBox).Text = "0.00"
          CType(.FindControl("F_ProjectCost"), TextBox).Text = "0.00"
          CType(.FindControl("F_MarginCurrentYear"), TextBox).Text = "0.00"
          CType(.FindControl("F_WarrantyPercentage"), TextBox).Text = "0.00"
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
