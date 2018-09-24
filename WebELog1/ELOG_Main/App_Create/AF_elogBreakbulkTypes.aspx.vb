Partial Class AF_elogBreakbulkTypes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVelogBreakbulkTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogBreakbulkTypes.Init
    DataClassName = "AelogBreakbulkTypes"
    SetFormView = FVelogBreakbulkTypes
  End Sub
  Protected Sub TBLelogBreakbulkTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogBreakbulkTypes.Init
    SetToolBar = TBLelogBreakbulkTypes
  End Sub
  Protected Sub FVelogBreakbulkTypes_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogBreakbulkTypes.DataBound
    SIS.ELOG.elogBreakbulkTypes.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVelogBreakbulkTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogBreakbulkTypes.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Create") & "/AF_elogBreakbulkTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogBreakbulkTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogBreakbulkTypes", mStr)
    End If
    If Request.QueryString("BreakbulkTypeID") IsNot Nothing Then
      CType(FVelogBreakbulkTypes.FindControl("F_BreakbulkTypeID"), TextBox).Text = Request.QueryString("BreakbulkTypeID")
      CType(FVelogBreakbulkTypes.FindControl("F_BreakbulkTypeID"), TextBox).Enabled = False
    End If
  End Sub

End Class
