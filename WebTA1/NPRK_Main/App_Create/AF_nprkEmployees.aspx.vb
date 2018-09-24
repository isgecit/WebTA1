Partial Class AF_nprkEmployees
  Inherits SIS.SYS.InsertBase
  Protected Sub FVnprkEmployees_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkEmployees.Init
    DataClassName = "AnprkEmployees"
    SetFormView = FVnprkEmployees
  End Sub
  Protected Sub TBLnprkEmployees_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLnprkEmployees.Init
    SetToolBar = TBLnprkEmployees
  End Sub
  Protected Sub FVnprkEmployees_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkEmployees.DataBound
    SIS.NPRK.nprkEmployees.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVnprkEmployees_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVnprkEmployees.PreRender
    CType(FVnprkEmployees.FindControl("F_VehicleOwnedByEmployee"), CheckBox).Checked = True
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/NPRK_Main/App_Create") & "/AF_nprkEmployees.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptnprkEmployees") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptnprkEmployees", mStr)
    End If
    If Request.QueryString("EmployeeID") IsNot Nothing Then
      CType(FVnprkEmployees.FindControl("F_EmployeeID"), TextBox).Text = Request.QueryString("EmployeeID")
      CType(FVnprkEmployees.FindControl("F_EmployeeID"), TextBox).Enabled = False
    End If
  End Sub

End Class
