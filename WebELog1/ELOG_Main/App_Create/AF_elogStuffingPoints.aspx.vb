Partial Class AF_elogStuffingPoints
  Inherits SIS.SYS.InsertBase
  Protected Sub FVelogStuffingPoints_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogStuffingPoints.Init
    DataClassName = "AelogStuffingPoints"
    SetFormView = FVelogStuffingPoints
  End Sub
  Protected Sub TBLelogStuffingPoints_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogStuffingPoints.Init
    SetToolBar = TBLelogStuffingPoints
  End Sub
  Protected Sub FVelogStuffingPoints_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogStuffingPoints.DataBound
    SIS.ELOG.elogStuffingPoints.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVelogStuffingPoints_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogStuffingPoints.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Create") & "/AF_elogStuffingPoints.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogStuffingPoints") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogStuffingPoints", mStr)
    End If
    If Request.QueryString("StuffingPointID") IsNot Nothing Then
      CType(FVelogStuffingPoints.FindControl("F_StuffingPointID"), TextBox).Text = Request.QueryString("StuffingPointID")
      CType(FVelogStuffingPoints.FindControl("F_StuffingPointID"), TextBox).Enabled = False
    End If
  End Sub

End Class
