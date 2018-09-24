Partial Class AF_elogStuffingTypes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVelogStuffingTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogStuffingTypes.Init
    DataClassName = "AelogStuffingTypes"
    SetFormView = FVelogStuffingTypes
  End Sub
  Protected Sub TBLelogStuffingTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogStuffingTypes.Init
    SetToolBar = TBLelogStuffingTypes
  End Sub
  Protected Sub FVelogStuffingTypes_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogStuffingTypes.DataBound
    SIS.ELOG.elogStuffingTypes.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVelogStuffingTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogStuffingTypes.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Create") & "/AF_elogStuffingTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogStuffingTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogStuffingTypes", mStr)
    End If
    If Request.QueryString("StuffingTypeID") IsNot Nothing Then
      CType(FVelogStuffingTypes.FindControl("F_StuffingTypeID"), TextBox).Text = Request.QueryString("StuffingTypeID")
      CType(FVelogStuffingTypes.FindControl("F_StuffingTypeID"), TextBox).Enabled = False
    End If
  End Sub

End Class
