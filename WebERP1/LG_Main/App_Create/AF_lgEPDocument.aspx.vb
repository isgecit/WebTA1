Partial Class AF_lgEPDocument
  Inherits SIS.SYS.InsertBase
  Protected Sub FVlgEPDocument_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVlgEPDocument.Init
    DataClassName = "AlgEPDocument"
    SetFormView = FVlgEPDocument
  End Sub
  Protected Sub TBLlgEPDocument_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLlgEPDocument.Init
    SetToolBar = TBLlgEPDocument
  End Sub
  Protected Sub ODSlgEPDocument_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSlgEPDocument.Inserted
		If e.Exception Is Nothing Then
			Dim oDC As SIS.LG.lgEPDocument = CType(e.ReturnValue,SIS.LG.lgEPDocument)
			Dim tmpURL As String = "?tmp=1"
			tmpURL &= "&DocPK=" & oDC.DocPK
			TBLlgEPDocument.AfterInsertURL &= tmpURL 
		End If
  End Sub
  Protected Sub FVlgEPDocument_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVlgEPDocument.PreRender
    Dim oF_ProjectID_Display As Label  = FVlgEPDocument.FindControl("F_ProjectID_Display")
    oF_ProjectID_Display.Text = String.Empty
    If Not Session("F_ProjectID_Display") Is Nothing Then
      If Session("F_ProjectID_Display") <> String.Empty Then
        oF_ProjectID_Display.Text = Session("F_ProjectID_Display")
      End If
    End If
    Dim oF_ProjectID As TextBox  = FVlgEPDocument.FindControl("F_ProjectID")
    oF_ProjectID.Enabled = True
    oF_ProjectID.Text = String.Empty
    If Not Session("F_ProjectID") Is Nothing Then
      If Session("F_ProjectID") <> String.Empty Then
        oF_ProjectID.Text = Session("F_ProjectID")
      End If
    End If
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/LG_Main/App_Create") & "/AF_lgEPDocument.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptlgEPDocument") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptlgEPDocument", mStr)
    End If
    If Request.QueryString("DocPK") IsNot Nothing Then
      CType(FVlgEPDocument.FindControl("F_DocPK"), TextBox).Text = Request.QueryString("DocPK")
      CType(FVlgEPDocument.FindControl("F_DocPK"), TextBox).Enabled = False
    End If
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.LG.lgProjects.SelectlgProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_LG_EPDocument_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim ProjectID As String = CType(aVal(1),String)
		Dim oVar As SIS.LG.lgProjects = SIS.LG.lgProjects.lgProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
