Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  Partial Public Class pakUnits
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
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_UnitID"), TextBox).Text = ""
          CType(.FindControl("F_Description"), TextBox).Text = ""
          CType(.FindControl("F_UnitSetID"), Object).SelectedValue = ""
          CType(.FindControl("F_ConversionFactor"), TextBox).Text = 0
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function pakUnitsGetByDescription(ByVal Description As String) As SIS.PAK.pakUnits
      Dim Results As SIS.PAK.pakUnits = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppakUnitsSelectByDescription"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description", SqlDbType.NVarChar, 51, Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakUnits(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
  End Class
  Public Class UnitMultiplicationFactor
    Public Property Unit As SIS.PAK.pakUnits = Nothing
    Public Property BaseUnit As SIS.PAK.pakUnits = Nothing
    Public Property MF As Decimal = 0
    Public Shared Function GetMultiplicationFactorToBaseUnit(ByVal mcUnit As UnitMultiplicationFactor) As UnitMultiplicationFactor
      Dim tmpUS As SIS.PAK.pakUnitSets = SIS.PAK.pakUnitSets.pakUnitSetsGetByID(mcUnit.Unit.UnitSetID)
      mcUnit.BaseUnit = SIS.PAK.pakUnits.pakUnitsGetByID(tmpUS.BaseUnitID)
      mcUnit.MF = mcUnit.Unit.ConversionFactor / mcUnit.BaseUnit.ConversionFactor
      Return mcUnit
    End Function
  End Class
End Namespace
