Partial Class AF_elogCargoTypes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVelogCargoTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogCargoTypes.Init
    DataClassName = "AelogCargoTypes"
    SetFormView = FVelogCargoTypes
  End Sub
  Protected Sub TBLelogCargoTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogCargoTypes.Init
    SetToolBar = TBLelogCargoTypes
  End Sub
  Protected Sub FVelogCargoTypes_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogCargoTypes.DataBound
    SIS.ELOG.elogCargoTypes.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVelogCargoTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogCargoTypes.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Create") & "/AF_elogCargoTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogCargoTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogCargoTypes", mStr)
    End If
    If Request.QueryString("CargoTypeID") IsNot Nothing Then
      CType(FVelogCargoTypes.FindControl("F_CargoTypeID"), TextBox).Text = Request.QueryString("CargoTypeID")
      CType(FVelogCargoTypes.FindControl("F_CargoTypeID"), TextBox).Enabled = False
    End If
  End Sub

End Class
