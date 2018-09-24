Partial Class EmployeeInfoForReports
  Inherits System.Web.UI.UserControl
  Public Property cssClass() As String
    Get
      Return TblEmp.CssClass
    End Get
    Set(ByVal value As String)
      TblEmp.CssClass = value
    End Set
  End Property
  Public Property Width() As Unit
    Get
      Return TblEmp.Width
    End Get
    Set(ByVal value As Unit)
      TblEmp.Width = value
    End Set
  End Property
  Public Property EmployeeToDisplay() As Integer
    Get
      Return -1
    End Get
    Set(ByVal value As Integer)
      DisplayEmployeeInfo(value)
      Me.Visible = True
    End Set
  End Property
  Public Sub DisplayEmployeeInfo(ByVal EmployeeID As Integer)
    If Session("Today") Is Nothing Then
      Response.Redirect("~/Expired.aspx")
    Else
      If Session("Today").ToString = "" Then
        Response.Redirect("~/Expired.aspx")
      End If
    End If
    If EmployeeID = -1 Then
      EmployeeID = HttpContext.Current.Session("LoginID")
    End If
    Dim oEmp As SIS.NPRK.nprkEmployees = SIS.NPRK.nprkEmployees.nprkEmployeesGetByID(EmployeeID)
    If oEmp Is Nothing Then
      Me.Visible = False
      Exit Sub
    End If
    With TblEmp
      .Attributes.Add("style", "width: 100%;height: 18px;")
      .BorderStyle = BorderStyle.Solid
      .BorderWidth = 2
    End With
    With TblEmp
      .Rows.Clear()
      Dim oRow As TableRow = Nothing
      Dim oCol As TableCell = Nothing
      Dim oLnk As ImageButton = Nothing

      oRow = New TableRow

      oCol = NewTableCell()
      oLnk = New ImageButton
			oLnk.PostBackUrl = HttpContext.Current.Session("ApplicationDefaultPage")
      oLnk.ImageUrl = "~/TblImages/can0.png"
      oLnk.ToolTip = "Back to previous page"
      oCol.Controls.Add(oLnk)
      oRow.Cells.Add(oCol)

      oCol = NewTableCell()
      oCol.Text = "EMP.:"
      oCol.Font.Bold = True
      oRow.Cells.Add(oCol)

      oCol = NewTableCell()
      oCol.Text = oEmp.EmployeeName
      oCol.Attributes.Add("style", "text-align: left;")
      oRow.Cells.Add(oCol)

      oCol = NewTableCell()
      oCol.Text = "CATE.:"
      oCol.Font.Bold = True
      oCol.Attributes.Add("style", "text-align: right; padding-left: 20px;")
      oRow.Cells.Add(oCol)

      oCol = NewTableCell()
      oCol.Text = oEmp.FK_PRK_Employees_CategoryID.Description
      oRow.Cells.Add(oCol)


      oCol = NewTableCell()
      oCol.Text = "Date:"
      oCol.Font.Bold = True
      oCol.Attributes.Add("style", "text-align: right; padding-left: 20px;")
      oRow.Cells.Add(oCol)

      oCol = NewTableCell()
      oCol.Text = Convert.ToDateTime(Session("Today")).ToString("dd/MM/yyyy")
      oCol.ForeColor = Drawing.Color.Blue
      oRow.Cells.Add(oCol)

      .Rows.Add(oRow)
    End With
  End Sub
  Private Function NewTableCell() As TableCell
    Dim oCol As New TableCell
    oCol.VerticalAlign = VerticalAlign.Top
    Return oCol
  End Function
End Class
