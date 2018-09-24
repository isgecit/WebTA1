Partial Class AF_nprkPetrolRate
  Inherits SIS.SYS.InsertBase
  Protected Sub FVnprkPetrolRate_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkPetrolRate.Init
    DataClassName = "AnprkPetrolRate"
    SetFormView = FVnprkPetrolRate
  End Sub
  Protected Sub TBLnprkPetrolRate_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkPetrolRate.Init
    SetToolBar = TBLnprkPetrolRate
  End Sub
  Protected Sub FVnprkPetrolRate_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkPetrolRate.DataBound
    SIS.NPRK.nprkPetrolRate.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVnprkPetrolRate_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkPetrolRate.PreRender
    Dim oF_FinYear As LC_nprkFinYears = FVnprkPetrolRate.FindControl("F_FinYear")
    oF_FinYear.Enabled = True
    oF_FinYear.SelectedValue = String.Empty
    If Not Session("F_FinYear") Is Nothing Then
      If Session("F_FinYear") <> String.Empty Then
        oF_FinYear.SelectedValue = Session("F_FinYear")
      End If
    End If
    Dim oF_MonthID As LC_nprkMonths = FVnprkPetrolRate.FindControl("F_MonthID")
    oF_MonthID.Enabled = True
    oF_MonthID.SelectedValue = String.Empty
    If Not Session("F_MonthID") Is Nothing Then
      If Session("F_MonthID") <> String.Empty Then
        oF_MonthID.SelectedValue = Session("F_MonthID")
      End If
    End If
    Dim oF_LocationID As LC_hrmLocations = FVnprkPetrolRate.FindControl("F_LocationID")
    oF_LocationID.Enabled = True
    oF_LocationID.SelectedValue = String.Empty
    If Not Session("F_LocationID") Is Nothing Then
      If Session("F_LocationID") <> String.Empty Then
        oF_LocationID.SelectedValue = Session("F_LocationID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Create") & "/AF_nprkPetrolRate.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkPetrolRate") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkPetrolRate", mStr)
    End If
    If Request.QueryString("FinYear") IsNot Nothing Then
      CType(FVnprkPetrolRate.FindControl("F_FinYear"), TextBox).Text = Request.QueryString("FinYear")
      CType(FVnprkPetrolRate.FindControl("F_FinYear"), TextBox).Enabled = False
    End If
    If Request.QueryString("MonthID") IsNot Nothing Then
      CType(FVnprkPetrolRate.FindControl("F_MonthID"), TextBox).Text = Request.QueryString("MonthID")
      CType(FVnprkPetrolRate.FindControl("F_MonthID"), TextBox).Enabled = False
    End If
    If Request.QueryString("LocationID") IsNot Nothing Then
      CType(FVnprkPetrolRate.FindControl("F_LocationID"), TextBox).Text = Request.QueryString("LocationID")
      CType(FVnprkPetrolRate.FindControl("F_LocationID"), TextBox).Enabled = False
    End If
  End Sub

End Class
