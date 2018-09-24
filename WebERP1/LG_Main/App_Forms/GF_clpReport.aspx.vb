Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Partial Class GF_clpReport
	Inherits SIS.SYS.GridBase

	Protected Sub cmdGetCLP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGetCLP.Click
		Dim ProjectID As String = F_ProjectID.Text.ToUpper
		Dim BaselineID As String = F_BaseLineID.SelectedValue
		Dim clpDays As String = F_days.Text
		Dim clpFunction As String = F_Function.SelectedValue
		If ProjectID = String.Empty Then Exit Sub
		If clpDays = "" Then clpDays = "0"
		If Not IsNumeric(clpDays) Then clpDays = "0"


		Dim tbl As Table = Nothing
		Dim row As TableRow = Nothing
		Dim col As TableCell = Nothing
		Dim oVar As List(Of clsProjectCLP) = clsProjectCLP.GetProjectCLP(ProjectID, "", clpDays, clpFunction)
		If oVar.Count > 0 Then
			Dim tblH As New Table
			tblH.Width = 1300
			tblH.Style.Add("margin-top", "15px")
			tblH.Style.Add("margin-left", "10px")
			tblH.Style.Add("margin-right", "10px")
			Dim rowH As TableRow = New TableRow
			Dim colH As TableCell = New TableCell

			colH.Font.Bold = True
			colH.Font.Underline = True
			colH.Font.Size = 14
			colH.CssClass = "grpHD"
			colH.Text = "CLP STATUS AS ON " & Now.ToString("dd/MM/yyyy")
			colH.Style.Add("text-align", "center")
			rowH.Cells.Add(colH)
			tblH.Rows.Add(rowH)

			rowH = New TableRow
			colH = New TableCell
			colH.Font.Bold = True
			colH.Font.Underline = True
			colH.Font.Size = 10
			colH.CssClass = "grpHD"
			colH.Text = "PROJECT : " & ProjectID
			colH.Style.Add("text-align", "center")
			rowH.Cells.Add(colH)
			tblH.Rows.Add(rowH)

			rowH = New TableRow
			colH = New TableCell
			colH.Font.Bold = True
			colH.Font.Underline = True
			colH.Font.Size = 10
			colH.CssClass = "grpHD"
			colH.Text = F_BaseLineID.SelectedItem.Text
			colH.Style.Add("text-align", "center")
			rowH.Cells.Add(colH)
			tblH.Rows.Add(rowH)

			pnlCLP.Controls.Add(tblH)

			tbl = New Table
			With tbl
				.Style.Add("margin-top", "15px")
				.Style.Add("margin-left", "10px")
				.Style.Add("margin-right", "10px")
				.GridLines = GridLines.Both
			End With
			row = New TableRow
			col = New TableCell
			With col
				.Font.Bold = True
				.Text = "TD"
			End With
			row.Cells.Add(col)

			col = New TableCell
			With col
				.Text = "Activity not started, delay days from Today"
			End With
			row.Cells.Add(col)
			tbl.Rows.Add(row)
			row = New TableRow
			col = New TableCell
			With col
				.Font.Bold = True
				.Text = "SD"
			End With
			row.Cells.Add(col)

			col = New TableCell
			With col
				.Text = "Activity started, delay days from Start Date"
			End With
			row.Cells.Add(col)
			tbl.Rows.Add(row)
			row = New TableRow
			col = New TableCell
			With col
				.Font.Bold = True
				.Text = "ED"
			End With
			row.Cells.Add(col)

			col = New TableCell
			With col
				.Text = "Activity completed, delay days from End Date"
			End With
			row.Cells.Add(col)
			tbl.Rows.Add(row)
			pnlCLP.Controls.Add(tbl)



			tbl = New Table
			tbl.Width = 1300
			tbl.GridLines = GridLines.Both
			tbl.Style.Add("margin-left", "10px")
			tbl.Style.Add("margin-right", "10px")

			row = New TableRow

			col = New TableCell
			col.Text = "S.N."
			col.Width = 40
			col.Font.Bold = True
			col.CssClass = "colHD"
			col.Style.Add("text-align", "center")
			col.RowSpan = 2
			row.Cells.Add(col)

			col = New TableCell
			col.Text = "CLP Description"
			col.Font.Bold = True
			col.CssClass = "colHD"
			col.Width = 400
			col.Style.Add("text-align", "left")
			col.RowSpan = 2
			row.Cells.Add(col)

			col = New TableCell
			col.Text = ""
			col.CssClass = "colHD"
			col.Width = 20
			col.Style.Add("text-align", "center")
			col.RowSpan = 2
			row.Cells.Add(col)

			col = New TableCell
			col.Text = "Engineering"
			col.Font.Bold = True
			col.CssClass = "colHD"
			col.ColumnSpan = 3
			col.Width = 260
			col.Style.Add("text-align", "center")
			row.Cells.Add(col)

			col = New TableCell
			col.Text = "Indenting"
			col.Font.Bold = True
			col.CssClass = "colHD"
			col.ColumnSpan = 3
			col.Width = 260
			col.Style.Add("text-align", "center")
			row.Cells.Add(col)

			col = New TableCell
			col.Text = "Ordering"
			col.Font.Bold = True
			col.CssClass = "colHD"
			col.ColumnSpan = 3
			col.Width = 260
			col.Style.Add("text-align", "center")
			row.Cells.Add(col)

			col = New TableCell
			col.Text = "Despatch"
			col.Font.Bold = True
			col.CssClass = "colHD"
			col.ColumnSpan = 3
			col.Width = 260
			col.Style.Add("text-align", "center")
			row.Cells.Add(col)

			col = New TableCell
			col.Text = "Erection"
			col.Font.Bold = True
			col.CssClass = "colHD"
			col.ColumnSpan = 3
			col.Width = 260
			col.Style.Add("text-align", "center")
			row.Cells.Add(col)

			tbl.Rows.Add(row)

			row = New TableRow


			col = New TableCell
			col.Text = "Planned"
			col.Font.Bold = True
			col.CssClass = "colHD"
			col.Width = 80
			col.Style.Add("text-align", "center")
			row.Cells.Add(col)

			col = New TableCell
			col.Text = "Actual"
			col.Font.Bold = True
			col.CssClass = "colHD"
			col.Width = 80
			col.Style.Add("text-align", "center")
			row.Cells.Add(col)

			col = New TableCell
			col.Text = "Status"
			col.Font.Bold = True
			col.CssClass = "colHD"
			col.Width = 100
			col.Style.Add("text-align", "center")
			row.Cells.Add(col)

			col = New TableCell
			col.Text = "Planned"
			col.Font.Bold = True
			col.CssClass = "colHD"
			col.Width = 80
			col.Style.Add("text-align", "center")
			row.Cells.Add(col)

			col = New TableCell
			col.Text = "Actual"
			col.Font.Bold = True
			col.CssClass = "colHD"
			col.Width = 80
			col.Style.Add("text-align", "center")
			row.Cells.Add(col)

			col = New TableCell
			col.Text = "Status"
			col.Font.Bold = True
			col.CssClass = "colHD"
			col.Width = 100
			col.Style.Add("text-align", "center")
			row.Cells.Add(col)

			col = New TableCell
			col.Text = "Planned"
			col.Font.Bold = True
			col.CssClass = "colHD"
			col.Width = 80
			col.Style.Add("text-align", "center")
			row.Cells.Add(col)

			col = New TableCell
			col.Text = "Actual"
			col.Font.Bold = True
			col.CssClass = "colHD"
			col.Width = 80
			col.Style.Add("text-align", "center")
			row.Cells.Add(col)

			col = New TableCell
			col.Text = "Status"
			col.Font.Bold = True
			col.CssClass = "colHD"
			col.Width = 100
			col.Style.Add("text-align", "center")
			row.Cells.Add(col)

			col = New TableCell
			col.Text = "Planned"
			col.Font.Bold = True
			col.CssClass = "colHD"
			col.Width = 80
			col.Style.Add("text-align", "center")
			row.Cells.Add(col)

			col = New TableCell
			col.Text = "Actual"
			col.Font.Bold = True
			col.CssClass = "colHD"
			col.Width = 80
			col.Style.Add("text-align", "center")
			row.Cells.Add(col)

			col = New TableCell
			col.Text = "Status"
			col.Font.Bold = True
			col.CssClass = "colHD"
			col.Width = 100
			col.Style.Add("text-align", "center")
			row.Cells.Add(col)

			col = New TableCell
			col.Text = "Planned"
			col.Font.Bold = True
			col.CssClass = "colHD"
			col.Width = 80
			col.Style.Add("text-align", "center")
			row.Cells.Add(col)

			col = New TableCell
			col.Text = "Actual"
			col.Font.Bold = True
			col.CssClass = "colHD"
			col.Width = 80
			col.Style.Add("text-align", "center")
			row.Cells.Add(col)

			col = New TableCell
			col.Text = "Status"
			col.Font.Bold = True
			col.CssClass = "colHD"
			col.Width = 100
			col.Style.Add("text-align", "center")
			row.Cells.Add(col)

			tbl.Rows.Add(row)

			Dim bClp As New List(Of clsProjectCLP)
			Dim bCnt As Integer = 0
			Dim rSpan As Integer = 0
			bClp = clsProjectCLP.GetBaseLineCount(ProjectID)
			If BaselineID = "" Then
				bCnt = 1 'bClp.Count
				rSpan = 1 'bCnt + 1
			Else
				bCnt = 1
				rSpan = 1
			End If
			Dim sn As Integer = 0
			For Each tmp As clsProjectCLP In oVar
				sn += 1
				row = New TableRow
				row.Style.Add("border", "solid 1pt black")
				row.CssClass = "rowHD"

				col = New TableCell
				col.CssClass = "rowHD"
				col.Text = sn
				col.Style.Add("text-align", "center")
				If rSpan > 1 Then
					col.RowSpan = rSpan
				End If
				row.Cells.Add(col)

				col = New TableCell
				col.CssClass = "rowHD"
				col.Text = tmp.ActivityDescription
				col.Style.Add("text-align", "left")
				col.RowSpan = rSpan
				row.Cells.Add(col)

				Dim oChds As New List(Of clsProjectCLP)
				oChds = clsProjectCLP.GetProjectCLP(ProjectID, tmp.ActivityID, clpDays, clpFunction)

				If BaselineID = "" Then
					col = New TableCell
					col.Text = "C"
					col.Font.Bold = True
					col.CssClass = "rowHD"
					col.Style.Add("text-align", "center")
					row.Cells.Add(col)
					For I As Integer = 1 To 5
						Dim Found As Boolean = False
						For Each chd As clsProjectCLP In oChds
							If chd.CustomActivityType = I Then
								col = New TableCell
								col.CssClass = "rowHD"
								col.Text = chd.PlannedEndDate
								col.Style.Add("text-align", "center")
								row.Cells.Add(col)

								col = New TableCell
								col.CssClass = "rowHD"
								col.Text = chd.ActualEndDate
								col.Style.Add("text-align", "center")
								row.Cells.Add(col)

								Dim Days As Integer = 0
								Dim note As String = ""
								Dim mColor As System.Drawing.Color = Drawing.Color.LightGray
								If chd.ActualEndDate <> String.Empty Then
									Days = DateDiff(DateInterval.Day, Convert.ToDateTime(chd.PlannedEndDate), Convert.ToDateTime(chd.ActualEndDate))
									note = " frm ED"
									If Days <= 0 Then
										mColor = Drawing.Color.GreenYellow
									Else
										mColor = Drawing.Color.Red
									End If
								ElseIf chd.ActualStartDate <> String.Empty Then
									Days = DateDiff(DateInterval.Day, Convert.ToDateTime(chd.PlannedStartDate), Convert.ToDateTime(chd.ActualStartDate))
									note = " frm SD"
									If Days <= 0 Then
										mColor = Drawing.Color.GreenYellow
									Else
										mColor = Drawing.Color.Orange
										If Convert.ToDateTime(chd.ActualStartDate) > Convert.ToDateTime(chd.PlannedEndDate) Then
											mColor = Drawing.Color.Red
										End If
									End If
								Else
									Days = DateDiff(DateInterval.Day, Convert.ToDateTime(chd.PlannedStartDate), Now)
									note = " frm TD"
									If Days <= 0 Then
										mColor = Drawing.Color.LightGray
									Else
										mColor = Drawing.Color.Orange
										If Now > Convert.ToDateTime(chd.PlannedEndDate) Then
											mColor = Drawing.Color.Red
										End If
									End If
								End If

								col = New TableCell
								col.CssClass = "rowHD"
								col.BackColor = mColor
								col.Text = IIf(Days > 0, "+", "") & Days & note
								col.Style.Add("text-align", "center")
								row.Cells.Add(col)
								Found = True
								Exit For
							End If
						Next
						If Not Found Then
							col = New TableCell
							col.CssClass = "rowHD"
							col.Text = "-"
							col.Style.Add("text-align", "center")
							row.Cells.Add(col)

							col = New TableCell
							col.CssClass = "rowHD"
							col.Text = "-"
							col.Style.Add("text-align", "center")
							row.Cells.Add(col)

							col = New TableCell
							col.CssClass = "rowHD"
							col.Text = ""
							col.Style.Add("text-align", "center")
							row.Cells.Add(col)
						End If
					Next
					tbl.Rows.Add(row)
				End If ' If BaseLineID=""
				If BaselineID <> "" Then
					Dim oBChds As List(Of clsProjectCLP) = clsProjectCLP.GetBaseLineCLP(ProjectID, tmp.ActivityID, BaselineID, clpDays, clpFunction)

					For Each bTmp As clsProjectCLP In bClp
						If BaselineID = "" Then
							row = New TableRow
						End If
						row.Style.Add("border", "solid 1pt black")
						row.CssClass = "rowHD"

						If bTmp.BaseLineID <> "1" Then
							col = New TableCell
							col.Text = "O" & Convert.ToInt32(bTmp.BaseLineID) - 1
							col.Font.Bold = True
							col.CssClass = "rowHD"
							col.Style.Add("text-align", "center")
							row.Cells.Add(col)
						Else
							col = New TableCell
							col.Text = "B"
							col.Font.Bold = True
							col.CssClass = "rowHD"
							col.Style.Add("text-align", "center")
							row.Cells.Add(col)
						End If
						For I As Integer = 1 To 5
							Dim Found As Boolean = False
							For Each chd As clsProjectCLP In oChds
								If chd.CustomActivityType = I Then
									For Each bChd As clsProjectCLP In oBChds
										If bChd.BaseLineID = bTmp.BaseLineID Then
											If bChd.ActivityID = chd.ActivityID Then
												col = New TableCell
												col.CssClass = "rowHD"
												col.Text = bChd.PlannedEndDate
												col.Style.Add("text-align", "center")
												row.Cells.Add(col)

												col = New TableCell
												col.CssClass = "rowHD"
												col.Text = chd.ActualEndDate
												col.Style.Add("text-align", "center")
												row.Cells.Add(col)

												Dim Days As Integer = 0
												Dim note As String = ""
												Dim mColor As System.Drawing.Color = Drawing.Color.LightGray
												If chd.ActualEndDate <> String.Empty Then
													Days = DateDiff(DateInterval.Day, Convert.ToDateTime(bChd.PlannedEndDate), Convert.ToDateTime(chd.ActualEndDate))
													note = " frm ED"
													If Days <= 0 Then
														mColor = Drawing.Color.GreenYellow
													Else
														mColor = Drawing.Color.Red
													End If
												ElseIf chd.ActualStartDate <> String.Empty Then
													Days = DateDiff(DateInterval.Day, Convert.ToDateTime(bChd.PlannedStartDate), Convert.ToDateTime(chd.ActualStartDate))
													note = " frm SD"
													If Days <= 0 Then
														mColor = Drawing.Color.GreenYellow
													Else
														mColor = Drawing.Color.Orange
														If Convert.ToDateTime(chd.ActualStartDate) > Convert.ToDateTime(chd.PlannedEndDate) Then
															mColor = Drawing.Color.Red
														End If
													End If
												Else
													Days = DateDiff(DateInterval.Day, Convert.ToDateTime(bChd.PlannedStartDate), Now)
													note = " frm TD"
													If Days <= 0 Then
														mColor = Drawing.Color.LightGray
													Else
														mColor = Drawing.Color.Orange
														If Now > Convert.ToDateTime(chd.PlannedEndDate) Then
															mColor = Drawing.Color.Red
														End If
													End If
												End If

												col = New TableCell
												col.CssClass = "rowHD"
												col.BackColor = mColor
												col.Text = IIf(Days > 0, "+", "") & Days & note
												col.Style.Add("text-align", "center")
												row.Cells.Add(col)
												Found = True
												Exit For
											End If
										End If
									Next
								End If
							Next
							If Not Found Then
								col = New TableCell
								col.CssClass = "rowHD"
								col.Text = "-"
								col.Style.Add("text-align", "center")
								row.Cells.Add(col)

								col = New TableCell
								col.CssClass = "rowHD"
								col.Text = "-"
								col.Style.Add("text-align", "center")
								row.Cells.Add(col)

								col = New TableCell
								col.CssClass = "rowHD"
								col.Text = ""
								col.Style.Add("text-align", "center")
								row.Cells.Add(col)
							End If
						Next
						If BaselineID = "" Then
							tbl.Rows.Add(row)
						End If
					Next 'BaseLine
				End If
				If BaselineID <> "" Then
					tbl.Rows.Add(row)
				End If

			Next ' For OVar
		pnlCLP.Controls.Add(tbl)
		End If 'Ovar.Count > 0

	End Sub

	Protected Sub F_ProjectID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ProjectID.TextChanged
		Dim tmp As New List(Of clsBaseLines)
		If F_ProjectID.Text <> "" Then
			F_ProjectID.Text = F_ProjectID.Text.ToUpper
			tmp = clsBaseLines.GetBaseLines(F_ProjectID.Text)
		End If
		F_BaseLineID.Items.Clear()
		Dim tmpItem As New ListItem
		With tmpItem
			.Selected = True
			.Text = "Current"
			.Value = ""
		End With
		F_BaseLineID.Items.Add(tmpItem)
		If tmp.Count > 0 Then
			For Each tm As clsBaseLines In tmp
				tmpItem = New ListItem
				With tmpItem
					.Selected = False
					.Text = tm.Description
					.Value = tm.BaseLineID
				End With
				F_BaseLineID.Items.Add(tmpItem)
			Next
		End If
	End Sub
End Class
Public Class clsBaseLines
	Private _ProjectID As String = ""
	Private _BaseLineID As String = ""
	Private _Description As String = ""
	Private _CreatedOn As String = ""
	Public Property ProjectID() As String
		Get
			Return _ProjectID
		End Get
		Set(ByVal value As String)
			_ProjectID = value
		End Set
	End Property

	Public Property BaseLineID() As String
		Get
			Return _BaseLineID
		End Get
		Set(ByVal value As String)
			_BaseLineID = value
		End Set
	End Property
	Public Property Description() As String
		Get
			Return _Description
		End Get
		Set(ByVal value As String)
			_Description = value
		End Set
	End Property
	Public Property CreatedOn() As String
		Get
			Return _CreatedOn
		End Get
		Set(ByVal value As String)
			_CreatedOn = value
		End Set
	End Property

	Public Shared Function GetBaseLines(ByVal ProjectID As String) As List(Of clsBaseLines)
		Dim Results As List(Of clsBaseLines) = Nothing
		Dim Sql As String = ""
		Sql = Sql & "	SELECT "
		Sql = Sql & "  t_cprj		 As ProjectID         "
		Sql = Sql & " ,t_basn		 As BaseLineID        "
		Sql = Sql & " ,t_dsca		 As Description       "
		Sql = Sql & " ,t_crdt		 As CreatedOn         "
		Sql = Sql & "	FROM ttppss020200 "
		Sql = Sql & "	WHERE t_cprj ='" & ProjectID & "'"
		Sql = Sql & "	ORDER BY t_basn DESC"
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = Sql
        Results = New List(Of clsBaseLines)
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        While (Reader.Read())
          Results.Add(New clsBaseLines(Reader))
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
            If Convert.IsDBNull(Reader(pi.Name)) Then
              CallByName(Me, pi.Name, CallType.Let, String.Empty)
            Else
              CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
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
Public Class clsProjectCLP
  Private _ProjectID As String = ""
  Private _ActivityID As String = ""
  Private _ActivitySequence As Integer = 0
  Private _ActivityType As Integer = 0
  Private _ActivityDescription As String = ""
  Private _ParentActivity As String = ""
  Private _PlannedStartDate As String = ""
  Private _PlannedEndDate As String = ""
  Private _ActualStartDate As String = ""
  Private _ActualEndDate As String = ""
  Private _CustomActivityType As Integer = 0
  Private _BaseLineID As String = ""
  Private VeryOldDate As String = "31/12/1999"
  Public Property BaseLineID() As String
    Get
      Return _BaseLineID
    End Get
    Set(ByVal value As String)
      If Not Convert.IsDBNull(value) Then
        _BaseLineID = value
      Else
        _BaseLineID = ""
      End If
    End Set
  End Property
  Public Property ProjectID() As String
    Get
      Return _ProjectID
    End Get
    Set(ByVal value As String)
      If Not Convert.IsDBNull(value) Then
        _ProjectID = value
      Else
        _ProjectID = ""
      End If
    End Set
  End Property
  Public Property ActivityID() As String
    Get
      Return _ActivityID
    End Get
    Set(ByVal value As String)
      If Not Convert.IsDBNull(value) Then
        _ActivityID = value
      Else
        _ActivityID = ""
      End If
    End Set
  End Property
  Public Property ActivitySequence() As Integer
    Get
      Return _ActivitySequence
    End Get
    Set(ByVal value As Integer)
      If Not Convert.IsDBNull(value) Then
        _ActivitySequence = value
      Else
        _ActivitySequence = 0
      End If
    End Set
  End Property
  Public Property ActivityType() As Integer
    Get
      Return _ActivityType
    End Get
    Set(ByVal value As Integer)
      If Not Convert.IsDBNull(value) Then
        _ActivityType = value
      Else
        _ActivityType = 0
      End If
    End Set
  End Property
  Public Property ActivityDescription() As String
    Get
      Return _ActivityDescription
    End Get
    Set(ByVal value As String)
      If Not Convert.IsDBNull(value) Then
        _ActivityDescription = value
      Else
        _ActivityDescription = ""
      End If
    End Set
  End Property
  Public Property ParentActivity() As String
    Get
      Return _ParentActivity
    End Get
    Set(ByVal value As String)
      If Not Convert.IsDBNull(value) Then
        _ParentActivity = value
      Else
        _ParentActivity = ""
      End If
    End Set
  End Property
  Public Property PlannedStartDate() As String
    Get
      Return _PlannedStartDate
    End Get
    Set(ByVal value As String)
      If Not Convert.IsDBNull(value) Then
        If Convert.ToDateTime(value) < Convert.ToDateTime(VeryOldDate) Then
          value = ""
        End If
        _PlannedStartDate = value
      Else
        _PlannedStartDate = ""
      End If
    End Set
  End Property
  Public Property PlannedEndDate() As String
    Get
      If _PlannedEndDate = String.Empty Then
        Return _PlannedEndDate
      Else
        Return Convert.ToDateTime(_PlannedEndDate).ToString("dd/MM/yyyy")
      End If
    End Get
    Set(ByVal value As String)
      If Not Convert.IsDBNull(value) Then
        If Convert.ToDateTime(value) < Convert.ToDateTime(VeryOldDate) Then
          value = ""
        End If
        _PlannedEndDate = value
      Else
        _PlannedEndDate = ""
      End If
    End Set
  End Property
  Public Property ActualStartDate() As String
    Get
      Return _ActualStartDate
    End Get
    Set(ByVal value As String)
      If Not Convert.IsDBNull(value) Then
        If Convert.ToDateTime(value) < Convert.ToDateTime(VeryOldDate) Then
          value = ""
        End If
        _ActualStartDate = value
      Else
        _ActualStartDate = ""
      End If
    End Set
  End Property
  Public Property ActualEndDate() As String
    Get
      If _ActualEndDate = String.Empty Then
        Return _ActualEndDate
      Else
        Return Convert.ToDateTime(_ActualEndDate).ToString("dd/MM/yyyy")
      End If
    End Get
    Set(ByVal value As String)
      If Not Convert.IsDBNull(value) Then
        If Convert.ToDateTime(value) < Convert.ToDateTime(VeryOldDate) Then
          value = ""
        End If
        _ActualEndDate = value
      Else
        _ActualEndDate = ""
      End If
    End Set
  End Property
  Public Property CustomActivityType() As Integer
    Get
      Return _CustomActivityType
    End Get
    Set(ByVal value As Integer)
      If Not Convert.IsDBNull(value) Then
        _CustomActivityType = value
      Else
        _CustomActivityType = 0
      End If
    End Set
  End Property

  Public Shared Function GetProjectCLP(ByVal ProjectID As String, Optional ByVal Parent As String = "", Optional ByVal clpDays As String = "0", Optional ByVal clpFunction As String = "") As List(Of clsProjectCLP)
    Dim Results As List(Of clsProjectCLP) = Nothing
    Dim Sql As String = ""
    Sql = Sql & "	SELECT "
    Sql = Sql & " t_cprj     As ProjectID          "
    Sql = Sql & ",t_cact		 As ActivityID         "
    Sql = Sql & ",t_actp		 As ActivitySequence   "
    Sql = Sql & ",t_tact		 As ActivityType       "
    Sql = Sql & ",t_desc		 As ActivityDescription"
    Sql = Sql & ",t_pact		 As ParentActivity     "
    Sql = Sql & ",t_ssdt		 As PlannedStartDate   "
    Sql = Sql & ",t_sfdt		 As PlannedEndDate     "
    Sql = Sql & ",t_asdt		 As ActualStartDate    "
    Sql = Sql & ",t_afdt		 As ActualEndDate      "
    Sql = Sql & ",t_cdf_acty As CustomActivityType "
    Sql = Sql & "	FROM ttppss200200 "
    Sql = Sql & "	WHERE t_cprj ='" & ProjectID & "'"
    If Parent <> String.Empty Then
      Sql = Sql & "	AND t_pact ='" & Parent & "'"
      If clpDays <> "0" Then
        Dim sDt As String = Now.ToString("dd/MM/yyyy")
        Dim lDt As String = Now.AddDays(clpDays).ToString("dd/MM/yyyy")
        If Convert.ToInt32(clpDays) > 0 Then
          Sql = Sql & " AND t_sfdt between convert(datetime,'" & sDt & "',103) and convert(datetime,'" & lDt & "',103)"
        Else
          Sql = Sql & " AND t_sfdt between convert(datetime,'" & lDt & "',103) and convert(datetime,'" & sDt & "',103)"
        End If
      End If
      If clpFunction <> "" Then
        Sql = Sql & " AND t_cdf_acty =" & clpFunction
      End If
    Else
      'Sql = Sql & "	AND t_tact = 2"
      Sql = Sql & " AND t_cdf_acty  = 0 "
    End If
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = Sql
        Results = New List(Of clsProjectCLP)
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        While (Reader.Read())
          Results.Add(New clsProjectCLP(Reader))
        End While
        Reader.Close()
      End Using
    End Using
    Return Results
  End Function

  Public Shared Function GetBaseLineCLP(ByVal ProjectID As String, Optional ByVal Parent As String = "", Optional ByVal BaseLineID As String = "", Optional ByVal clpDays As String = "0", Optional ByVal clpFunction As String = "") As List(Of clsProjectCLP)
    Dim Results As List(Of clsProjectCLP) = Nothing
    Dim Sql As String = ""
    Sql = Sql & "	SELECT "
    Sql = Sql & " t_cprj     As ProjectID          "
    Sql = Sql & ",t_cact		 As ActivityID         "
    Sql = Sql & ",t_tact		 As ActivityType       "
    Sql = Sql & ",t_basn		 As BaseLineID         "
    Sql = Sql & ",t_pact		 As ParentActivity     "
    Sql = Sql & ",t_bsdt		 As PlannedStartDate   "
    Sql = Sql & ",t_bfdt		 As PlannedEndDate     "
    Sql = Sql & "	FROM ttppss220200 "
    Sql = Sql & "	WHERE t_cprj ='" & ProjectID & "'"
    Sql = Sql & "	AND t_pact ='" & Parent & "'"
    Sql = Sql & "	AND t_tact = 4"
    If clpDays <> "0" Then
      Dim sDt As String = Now.ToString("dd/MM/yyyy")
      Dim lDt As String = Now.AddDays(clpDays).ToString("dd/MM/yyyy")
      If Convert.ToInt32(clpDays) > 0 Then
        Sql = Sql & " AND t_bfdt between convert(datetime,'" & sDt & "',103) and convert(datetime,'" & lDt & "',103)"
      Else
        Sql = Sql & " AND t_bfdt between convert(datetime,'" & lDt & "',103) and convert(datetime,'" & sDt & "',103)"
      End If
    End If
    If clpFunction <> "" Then

    End If
    If BaseLineID <> "" Then
      Sql = Sql & "	AND t_basn = " & BaseLineID
    End If
    Sql = Sql & "	ORDER BY t_basn DESC"
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = Sql
        Results = New List(Of clsProjectCLP)
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        While (Reader.Read())
          Results.Add(New clsProjectCLP(Reader))
        End While
        Reader.Close()
      End Using
    End Using
    Return Results
  End Function
  Public Shared Function GetBaseLineCount(ByVal ProjectID As String) As List(Of clsProjectCLP)
    Dim Results As List(Of clsProjectCLP) = Nothing
    Dim Sql As String = ""
    Sql = Sql & "	SELECT DISTINCT "
    Sql = Sql & " t_basn		 As BaseLineID         "
    Sql = Sql & "	FROM ttppss220200 "
    Sql = Sql & "	WHERE t_cprj ='" & ProjectID & "'"
    Sql = Sql & "	ORDER BY t_basn DESC"
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = Sql
        Results = New List(Of clsProjectCLP)
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        While (Reader.Read())
          Results.Add(New clsProjectCLP(Reader))
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
						If Convert.IsDBNull(Reader(pi.Name)) Then
							CallByName(Me, pi.Name, CallType.Let, String.Empty)
						Else
							CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
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