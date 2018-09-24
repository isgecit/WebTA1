Partial Class AF_taD_Driver
  Inherits SIS.SYS.InsertBase
  Protected Sub FVtaD_Driver_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_Driver.Init
    DataClassName = "AtaD_Driver"
    SetFormView = FVtaD_Driver
  End Sub
  Protected Sub TBLtaD_Driver_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLtaD_Driver.Init
    SetToolBar = TBLtaD_Driver
  End Sub
  Protected Sub FVtaD_Driver_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_Driver.DataBound
    SIS.TA.taD_Driver.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVtaD_Driver_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVtaD_Driver.PreRender
    Dim oF_CategoryID As LC_taCategories = FVtaD_Driver.FindControl("F_CategoryID")
    oF_CategoryID.Enabled = True
    oF_CategoryID.SelectedValue = String.Empty
    If Not Session("F_CategoryID") Is Nothing Then
      If Session("F_CategoryID") <> String.Empty Then
        oF_CategoryID.SelectedValue = Session("F_CategoryID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/TA_Main/App_Create") & "/AF_taD_Driver.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scripttaD_Driver") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scripttaD_Driver", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVtaD_Driver.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVtaD_Driver.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub

End Class
