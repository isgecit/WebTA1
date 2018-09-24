Partial Class AF_elogBLTypes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVelogBLTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogBLTypes.Init
    DataClassName = "AelogBLTypes"
    SetFormView = FVelogBLTypes
  End Sub
  Protected Sub TBLelogBLTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLelogBLTypes.Init
    SetToolBar = TBLelogBLTypes
  End Sub
  Protected Sub FVelogBLTypes_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogBLTypes.DataBound
    SIS.ELOG.elogBLTypes.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVelogBLTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVelogBLTypes.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/ELOG_Main/App_Create") & "/AF_elogBLTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptelogBLTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptelogBLTypes", mStr)
    End If
    If Request.QueryString("BLTypeID") IsNot Nothing Then
      CType(FVelogBLTypes.FindControl("F_BLTypeID"), TextBox).Text = Request.QueryString("BLTypeID")
      CType(FVelogBLTypes.FindControl("F_BLTypeID"), TextBox).Enabled = False
    End If
  End Sub

End Class
