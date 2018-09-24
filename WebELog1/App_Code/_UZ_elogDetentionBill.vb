Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.ELOG
  Partial Public Class elogDetentionBill
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
    Public ReadOnly Property LockWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property LockWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function LockWF(ByVal IRNo As Int32) As SIS.ELOG.elogDetentionBill
      Dim Results As SIS.ELOG.elogDetentionBill = elogDetentionBillGetByID(IRNo)
      Return Results
    End Function
    Public Shared Function UZ_elogDetentionBillSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SupplierID As String, ByVal ProjectID As String) As List(Of SIS.ELOG.elogDetentionBill)
      Dim Results As List(Of SIS.ELOG.elogDetentionBill) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spelog_LG_DetentionBillSelectListSearch"
            Cmd.CommandText = "spelogDetentionBillSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spelog_LG_DetentionBillSelectListFilteres"
            Cmd.CommandText = "spelogDetentionBillSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SupplierID", SqlDbType.NVarChar, 9, IIf(SupplierID Is Nothing, String.Empty, SupplierID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID", SqlDbType.NVarChar, 6, IIf(ProjectID Is Nothing, String.Empty, ProjectID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.ELOG.elogDetentionBill)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ELOG.elogDetentionBill(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_elogDetentionBillInsert(ByVal Record As SIS.ELOG.elogDetentionBill) As SIS.ELOG.elogDetentionBill
      Dim _Result As SIS.ELOG.elogDetentionBill = elogDetentionBillInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_elogDetentionBillUpdate(ByVal Record As SIS.ELOG.elogDetentionBill) As SIS.ELOG.elogDetentionBill
      Dim _Result As SIS.ELOG.elogDetentionBill = elogDetentionBillUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_elogDetentionBillDelete(ByVal Record As SIS.ELOG.elogDetentionBill) As Integer
      Dim _Result As Integer = elogDetentionBillDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_IRNo"), TextBox).Text = 0
          CType(.FindControl("F_IRDate"), TextBox).Text = ""
          CType(.FindControl("F_SupplierID"), TextBox).Text = ""
          CType(.FindControl("F_SupplierID_Display"), Label).Text = ""
          CType(.FindControl("F_SupplierBillNo"), TextBox).Text = ""
          CType(.FindControl("F_SupplierBillDate"), TextBox).Text = ""
          CType(.FindControl("F_BillAmount"), TextBox).Text = 0
          CType(.FindControl("F_GRNo"), TextBox).Text = ""
          CType(.FindControl("F_GRDate"), TextBox).Text = ""
          CType(.FindControl("F_ProjectID"), TextBox).Text = ""
          CType(.FindControl("F_ProjectID_Display"), Label).Text = ""
          CType(.FindControl("F_PONumber"), TextBox).Text = ""
          CType(.FindControl("F_BillTypeID"), Object).SelectedValue = ""
          CType(.FindControl("F_OtherBillType"), TextBox).Text = ""
          CType(.FindControl("F_VehicleExeNo"), TextBox).Text = 0
          CType(.FindControl("F_MRNNo"), TextBox).Text = 0
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
  Public Class GRDetails
    Public Property t_irno As String = ""
    Public Property t_grbp As String = ""
    Public Property t_grdt As String = ""
    Public Property t_bpid As String = ""
    Public Property t_nama As String = ""
    Public Shared Function GetIRFromBaaN(ByVal IRNo As Int32) As List(Of SIS.ELOG.GRDetails)
      Dim Results As New List(Of SIS.ELOG.GRDetails)
      Dim Sql As String = ""
      Sql &= " select t_irno,t_grno,t_grbp,t_grdt,t_bpid,t_nama from ttfisg002200 "
      Sql &= " INNER JOIN dbo.ttccom100200  ON dbo.ttfisg002200.t_grbp = dbo.ttccom100200.t_bpid "
      Sql &= " where t_grno='" & IRNo & "'"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.ELOG.GRDetails(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              Dim Found As Boolean = False
              For I As Integer = 0 To Reader.FieldCount - 1
                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                  Found = True
                  Exit For
                End If
              Next
              If Found Then
                If Convert.IsDBNull(Reader(pi.Name)) Then
                  Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                    Case "decimal"
                      CallByName(Me, pi.Name, CallType.Let, "0.00")
                    Case "bit"
                      CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                    Case Else
                      CallByName(Me, pi.Name, CallType.Let, String.Empty)
                  End Select
                Else
                  CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                End If
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub
    Public Sub New()
    End Sub

  End Class
End Namespace
