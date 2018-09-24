Partial Class AF_nprkBillDetails
  Inherits SIS.SYS.GridBase
  Public Property PerkID As Integer
    Get
      If ViewState("PerkID") IsNot Nothing Then
        Return CType(ViewState("PerkID"), Integer)
      End If
      Return 0
    End Get
    Set(value As Integer)
      ViewState.Add("PerkID", value)
    End Set
  End Property
  Public Property PerkDescription As String
    Get
      If ViewState("PerkDescription") IsNot Nothing Then
        Return CType(ViewState("PerkDescription"), String)
      End If
      Return ""
    End Get
    Set(value As String)
      ViewState.Add("PerkDescription", value)
    End Set
  End Property

  Protected Sub GVnprkBillDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVnprkBillDetails.Init
    DataClassName = "GnprkBillDetails"
    SetGridView = GVnprkBillDetails
  End Sub
  Protected Sub TBLnprkBillDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkBillDetails.Init
    SetToolBar = TBLnprkBillDetails
  End Sub
  Private Sub AF_nprkBillDetails_Init(sender As Object, e As EventArgs) Handles Me.Init
    If Request.QueryString("ClaimID") IsNot Nothing Then
      F_ClaimID.Text = Request.QueryString("ClaimID")
    End If
    If Request.QueryString("ApplicationID") IsNot Nothing Then
      F_ApplicationID.Text = Request.QueryString("ApplicationID")
    End If
    Dim tmp As SIS.NPRK.nprkApplications = SIS.NPRK.nprkApplications.nprkApplicationsGetByID(F_ClaimID.Text, F_ApplicationID.Text)
    PerkID = tmp.PerkID
    PerkDescription = tmp.PRK_Perks7_Description
  End Sub

  Private Sub AF_nprkBillDetails_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    Lbl_Perk.Text = PerkDescription
    lblDeclaration.Text = SIS.NPRK.nprkBillDetails.GetDeclaration(PerkID)
    SIS.NPRK.nprkBillDetails.FormatGrid(GVnprkBillDetails, PerkID)
  End Sub
  Private Sub TBLnprkBillDetails_SaveClicked(sender As Object, e As ImageClickEventArgs) Handles TBLnprkBillDetails.SaveClicked
    Dim OK As Boolean = True
    Dim AnySaved As Boolean = False
    Dim sTmps As New List(Of SIS.NPRK.nprkBillDetails)
    With GVnprkBillDetails
      For Each r As GridViewRow In .Rows
        If Convert.ToBoolean(CType(r.FindControl("F_Saved"), Label).Text) Then Continue For
        CType(r.FindControl("errMsg"), Label).Text = ""
        Dim x As SIS.NPRK.nprkBillDetails = GetObjectFromRow(r)
        'If PerkID <> prkPerk.DriverCharges Then
        '  If x.BillNo = String.Empty Then Continue For
        '  If x.BillDate = String.Empty Then Continue For
        'End If
        If x.Quantity = 0 And x.Amount = 0 Then Continue For
        If x.Quantity = 0 Then x.Quantity = x.Amount
        If x.Amount = 0 Then x.Amount = x.Quantity
        x.ClaimID = F_ClaimID.Text
        x.ApplicationID = F_ApplicationID.Text
        sTmps.Add(x)
      Next
      If OK Then
        Dim i As Integer = 1
        For Each x As SIS.NPRK.nprkBillDetails In sTmps
          i = x.SerialNo - 1
          x.SerialNo = 0
          Try
            x = SIS.NPRK.nprkBillDetails.UZ_nprkBillDetailsInsert(x)
            CType(.Rows(i).FindControl("F_Saved"), Label).Text = True
            CType(.Rows(i).FindControl("F_SerialNo"), Label).Text = x.SerialNo
            Dim L As Label = CType(.Rows(i).FindControl("errMsg"), Label)
            L.Text = "***SAVED***"
            L.ForeColor = Drawing.Color.DarkGreen
          Catch ex As Exception
            CType(.Rows(i).FindControl("errMsg"), Label).Text = ex.Message
            OK = False
          End Try
        Next
      End If
      If OK Then
        SIS.NPRK.nprkUserClaims.ValidateClaim(F_ClaimID.Text)
        MyBase.Saved()
      End If
    End With
  End Sub
  Private Function GetObjectFromRow(ByVal r As GridViewRow) As SIS.NPRK.nprkBillDetails
    On Error Resume Next
    Dim tmp As New SIS.NPRK.nprkBillDetails
    tmp.ClaimID = CType(r.FindControl("F_ClaimID"), TextBox).Text
    tmp.ApplicationID = CType(r.FindControl("F_ApplicationID"), TextBox).Text
    tmp.SerialNo = CType(r.FindControl("F_SerialNo"), Label).Text
    tmp.Particulars = CType(r.FindControl("F_Particulars"), TextBox).Text
    tmp.BillNo = CType(r.FindControl("F_BillNo"), TextBox).Text
    tmp.BillDate = CType(r.FindControl("F_BillDate"), TextBox).Text
    tmp.FromDate = CType(r.FindControl("F_FromDate"), TextBox).Text
    tmp.ToDate = CType(r.FindControl("F_ToDate"), TextBox).Text
    tmp.Quantity = CType(r.FindControl("F_Quantity"), TextBox).Text
    tmp.Amount = CType(r.FindControl("F_Amount"), TextBox).Text
    Return tmp
  End Function
End Class
