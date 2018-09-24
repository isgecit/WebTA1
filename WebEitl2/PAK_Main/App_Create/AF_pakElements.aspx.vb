Partial Class AF_pakElements
  Inherits SIS.SYS.InsertBase
  Protected Sub FVpakElements_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakElements.Init
    DataClassName = "ApakElements"
    SetFormView = FVpakElements
  End Sub
  Protected Sub TBLpakElements_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLpakElements.Init
    SetToolBar = TBLpakElements
  End Sub
  Protected Sub FVpakElements_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakElements.DataBound
    SIS.PAK.pakElements.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVpakElements_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVpakElements.PreRender
    Dim oF_ResponsibleAgencyID As LC_pakResponsibleAgencies = FVpakElements.FindControl("F_ResponsibleAgencyID")
    oF_ResponsibleAgencyID.Enabled = True
    oF_ResponsibleAgencyID.SelectedValue = String.Empty
    If Not Session("F_ResponsibleAgencyID") Is Nothing Then
      If Session("F_ResponsibleAgencyID") <> String.Empty Then
        oF_ResponsibleAgencyID.SelectedValue = Session("F_ResponsibleAgencyID")
      End If
    End If
    Dim oF_ParentElementID_Display As Label  = FVpakElements.FindControl("F_ParentElementID_Display")
    Dim oF_ParentElementID As TextBox  = FVpakElements.FindControl("F_ParentElementID")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/PAK_Main/App_Create") & "/AF_pakElements.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptpakElements") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptpakElements", mStr)
    End If
    If Request.QueryString("ElementID") IsNot Nothing Then
      CType(FVpakElements.FindControl("F_ElementID"), TextBox).Text = Request.QueryString("ElementID")
      CType(FVpakElements.FindControl("F_ElementID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ParentElementIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.PAK.pakElements.SelectpakElementsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validatePK_pakElements(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ElementID As String = CType(aVal(1),String)
    Dim oVar As SIS.PAK.pakElements = SIS.PAK.pakElements.pakElementsGetByID(ElementID)
    If Not oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record allready exists." 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_PAK_Elements_ParentElementID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ParentElementID As String = CType(aVal(1),String)
    Dim oVar As SIS.PAK.pakElements = SIS.PAK.pakElements.pakElementsGetByID(ParentElementID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
