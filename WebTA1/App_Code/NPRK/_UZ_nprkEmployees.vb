Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.NPRK
  Partial Public Class nprkEmployees
    Public ReadOnly Property IsVehicleOwned As Boolean
      Get
        Dim mRet As Boolean = False
        If VehicleType <> "None" Then
          mRet = True
        End If
        Return mRet
      End Get
    End Property
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
    Public Shared Function UZ_nprkEmployeesInsert(ByVal Record As SIS.NPRK.nprkEmployees) As SIS.NPRK.nprkEmployees
      Dim _Result As SIS.NPRK.nprkEmployees = nprkEmployeesInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_nprkEmployeesUpdate(ByVal Record As SIS.NPRK.nprkEmployees) As SIS.NPRK.nprkEmployees
      Dim _Result As SIS.NPRK.nprkEmployees = nprkEmployeesUpdate(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_EmployeeID"), TextBox).Text = 0
          CType(.FindControl("F_CardNo"), TextBox).Text = ""
          CType(.FindControl("F_EmployeeName"), TextBox).Text = ""
          CType(.FindControl("F_CategoryID"), Object).SelectedValue = ""
          CType(.FindControl("F_Basic"), TextBox).Text = 0
          CType(.FindControl("F_DOJ"), TextBox).Text = ""
          CType(.FindControl("F_DOR"), TextBox).Text = ""
          CType(.FindControl("F_PostedAt"), DropDownList).SelectedValue = ""
          CType(.FindControl("F_VehicleType"), DropDownList).SelectedValue = ""
          CType(.FindControl("F_MaintenanceAllowed"), CheckBox).Checked = False
          CType(.FindControl("F_TWInSalary"), CheckBox).Checked = False
          CType(.FindControl("F_ESI"), CheckBox).Checked = False
          CType(.FindControl("F_Department"), TextBox).Text = ""
          CType(.FindControl("F_Company"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function GetByCardNo(ByVal CardNo As String) As SIS.NPRK.nprkEmployees
      Dim Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
      Dim Cmd As SqlCommand = Con.CreateCommand()
      Cmd.CommandType = CommandType.StoredProcedure
      Cmd.CommandText = "spnprk_LG_EmployeesSelectByID"
      SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CardNo", SqlDbType.NVarChar, 8, CardNo)
      Dim Results As SIS.NPRK.nprkEmployees = Nothing
      Using Con
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        If Reader.Read Then
          Results = New SIS.NPRK.nprkEmployees(Reader)
        End If
        Reader.Close()
      End Using
      Return Results
    End Function
  End Class
End Namespace
